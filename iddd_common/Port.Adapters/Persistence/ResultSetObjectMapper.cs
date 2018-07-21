using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SaaSOvation.Common.Port.Adapters.Persistence
{
    public class ResultSetObjectMapper<T>
    {
        public ResultSetObjectMapper(IDataReader dataReader, JoinOn joinOn, string columnPrefix = null)
        {
            this._dataReader = dataReader;
            this._joinOn = joinOn;
            this._columnPrefix = columnPrefix;
        }

        private readonly IDataReader _dataReader;
        private readonly JoinOn _joinOn;
        private readonly string _columnPrefix;

        public T MapResultToType()
        {
            var obj = default(T);

            var associationsToMap = new HashSet<string>();

            var fields = typeof(T).GetFields();

            foreach (var field in fields)
            {
                var columnName = FieldNameToColumnName(field.Name);
                var columnIndex = _dataReader.GetOrdinal(columnName);
                if (columnIndex >= 0)
                {
                    var columnValue = ColumnValueFrom(columnIndex, field.FieldType);

                    _joinOn.SaveCurrentLeftQualifier(columnName, columnValue);

                    field.SetValue(obj, columnValue);
                }
                else
                {
                    var objectPrefix = ToObjectPrefix(columnName);
                    if (!associationsToMap.Contains(objectPrefix) && HasAssociation(objectPrefix))
                    {
                        associationsToMap.Add(field.Name);
                    }
                }
            }

            if (associationsToMap.Count > 0)
            {
                MapAssociations(obj, associationsToMap);
            }

            return obj;
        }

        private void MapAssociations(object obj, ISet<string> associationsToMap)
        {
            var mappedCollections = new Dictionary<string, ICollection<object>>();
            while (_dataReader.NextResult())
            {
                foreach (var fieldName in associationsToMap)
                {
                    var associationField = typeof(T).GetField(fieldName);
                    var associationFieldType = default(Type);
                    var collection = default(ICollection<object>);

                    if (typeof(IEnumerable).IsAssignableFrom(associationField.FieldType))
                    {
                        if (!mappedCollections.TryGetValue(fieldName, out collection))
                        {
                            collection = CreateCollectionFrom(associationField.FieldType);
                            mappedCollections.Add(fieldName, collection);
                            associationField.SetValue(obj, collection);
                        }

                        var genericType = associationField.FieldType.GetGenericTypeDefinition();
                        associationFieldType = genericType.GetGenericArguments()[0];
                    }
                    else
                    {
                        associationFieldType = associationField.FieldType;
                    }

                    var columnName = FieldNameToColumnName(fieldName);

                    var mapper = new ResultSetObjectMapper<object>(_dataReader, _joinOn, ToObjectPrefix(columnName));

                    var associationObject = mapper.MapResultToType();

                    if (collection != null)
                    {
                        collection.Add(associationObject);
                    }
                    else
                    {
                        associationField.SetValue(obj, associationObject);
                    }
                }

            }
        }

        /// <summary>
        /// TODO: ensure correctness
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private ICollection<object> CreateCollectionFrom(Type type)
        {
            var genericType = type.GetGenericTypeDefinition();
            if (typeof(IList<>).IsAssignableFrom(genericType))
            {
                return new List<object>();
            }
            else if (typeof(ISet<>).IsAssignableFrom(genericType))
            {
                return new HashSet<object>();
            }
            else
            {
                return null;
            }
        }

        private bool HasAssociation(string objectPrefix)
        {
            var fieldCount = _dataReader.FieldCount;
            for (var i = 0; i < fieldCount; i++)
            {
                var columnName = _dataReader.GetName(i);
                if (columnName.StartsWith(objectPrefix) && _joinOn.IsJoinedOn(_dataReader))
                {

                    return true;
                }
            }
            return false;
        }

        private string ToObjectPrefix(string columnName)
        {
            return "o_" + columnName + "_";
        }

        private object ColumnValueFrom(int columnIndex, Type columnType)
        {
            switch (Type.GetTypeCode(columnType))
            {
                case TypeCode.Int32:
                    return _dataReader.GetInt32(columnIndex);
                case TypeCode.Int64:
                    return _dataReader.GetInt64(columnIndex);
                case TypeCode.Boolean:
                    return _dataReader.GetBoolean(columnIndex);
                case TypeCode.Int16:
                    return _dataReader.GetInt16(columnIndex);
                case TypeCode.Single:
                    return _dataReader.GetFloat(columnIndex);
                case TypeCode.Double:
                    return _dataReader.GetDouble(columnIndex);
                case TypeCode.Byte:
                    return _dataReader.GetByte(columnIndex);
                case TypeCode.Char:
                    return _dataReader.GetChar(columnIndex);
                case TypeCode.String:
                    return _dataReader.GetString(columnIndex);
                case TypeCode.DateTime:
                    return _dataReader.GetDateTime(columnIndex);
                default:
                    throw new InvalidOperationException("Unsupported type.");
            }
        }

        private string FieldNameToColumnName(string fieldName)
        {
            var sb = new StringBuilder();

            if (_columnPrefix != null)
            {
                sb.Append(_columnPrefix);
            }

            foreach (var ch in fieldName)
            {
                if (char.IsLetter(ch) && char.IsUpper(ch))
                {
                    sb.Append('_').Append(char.ToLower(ch));
                }
                else
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

    }
}
