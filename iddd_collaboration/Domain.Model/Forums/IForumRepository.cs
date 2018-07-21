namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public interface IForumRepository
    {
        Forum Get(Tenants.Tenant tenantId, ForumId forumId);
        
        ForumId GetNextIdentity();

        void Save(Forum forum);
    }
}
