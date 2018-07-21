using System.Collections.Generic;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.AgilePM.Domain.Model.Tenants;
using SaaSOvation.AgilePM.Domain.Model.Products.Sprints;
using SaaSOvation.AgilePM.Domain.Model.Products.Releases;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public interface IBacklogItemRepository
    {
        ICollection<BacklogItem.BacklogItem> GetAllComittedTo(TenantId tenantId, SprintId sprintId);

        ICollection<BacklogItem.BacklogItem> GetAllScheduledFor(TenantId tenantId, ReleaseId releaseId);

        ICollection<BacklogItem.BacklogItem> GetAllOutstanding(TenantId tenantId, ProductId productId);

        ICollection<BacklogItem.BacklogItem> GetAll(TenantId tenantId, ProductId productId);

        BacklogItem.BacklogItem Get(TenantId tenantId, BacklogItemId backlogItemId);

        BacklogItemId GetNextIdentity();

        void Remove(BacklogItem.BacklogItem backlogItem);

        void RemoveAll(IEnumerable<BacklogItem.BacklogItem> backlogItems);

        void Save(BacklogItem.BacklogItem backlogItem);

        void SaveAll(IEnumerable<BacklogItem.BacklogItem> backlogItems);
    }
}
