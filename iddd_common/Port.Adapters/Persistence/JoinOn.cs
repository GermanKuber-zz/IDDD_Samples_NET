using System.Data;

namespace SaaSOvation.Common.Port.Adapters.Persistence
{
    public class JoinOn
    {
        public JoinOn()
        {
        }

        public JoinOn(string leftKey, string rightKey)
        {
            this._leftKey = leftKey;
            this._rightKey = rightKey;
        }

        private object _currentLeftQualifier;
        private string _leftKey;
        private string _rightKey;

        public bool IsSpecified
        {
            get
            {
                return _leftKey != null && _rightKey != null;
            }
        }

        public bool HasCurrentLeftQualifier(IDataReader dataReader)
        {
            try
            {
                var columnValue = dataReader.GetValue(dataReader.GetOrdinal(_leftKey));
                if (columnValue == null)
                {
                    return false;
                }
                return columnValue.Equals(_currentLeftQualifier);
            }
            catch
            {
                return false;
            }
        }

        public bool IsJoinedOn(IDataReader dataReader)
        {
            var leftColumn = default(object);
            var rightColumn = default(object);
            try
            {
                if (IsSpecified)
                {
                    leftColumn = dataReader.GetValue(dataReader.GetOrdinal(_leftKey));
                    rightColumn = dataReader.GetValue(dataReader.GetOrdinal(_rightKey));
                }
            }
            catch
            {
                // ignore
            }
            return leftColumn != null && rightColumn != null;
        }

        public void SaveCurrentLeftQualifier(string columnName, object columnValue)
        {
            if (columnName.Equals(_leftKey))
            {
                _currentLeftQualifier = columnValue;
            }
        }
    }
}
