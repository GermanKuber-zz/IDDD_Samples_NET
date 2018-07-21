using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Teams
{
    public class TeamMemberId : ValueObject
    {
        public TeamMemberId(Tenants.TenantId tenantId, string id)
        {
            AssertionConcern.AssertArgumentNotNull(tenantId, "The tenantId must be provided.");
            AssertionConcern.AssertArgumentNotEmpty(id, "The id must be provided.");
            AssertionConcern.AssertArgumentLength(id, 36, "The id must be 36 characters or less.");

            TenantId = tenantId;
            Id = id;
        }

        public Tenants.TenantId TenantId { get; }

        public string Id { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TenantId;
            yield return Id;
        }
    }
}
