using SaaSOvation.Collaboration.Domain.Model.Forums;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Application.Forums.Data;

namespace SaaSOvation.Collaboration.Application.Forums
{
    public class ForumApplicationService
    {
        public ForumApplicationService(
            ForumQueryService forumQueryService,
            IForumRepository forumRepository,
            ForumIdentityService forumIdentityService,
            DiscussionQueryService discussionQueryService,
            IDiscussionRepository discussionRepository,
            ICollaboratorService collaboratorService)
        {
            this._forumQueryService = forumQueryService;
            this._forumRepository = forumRepository;
            this._forumIdentityService = forumIdentityService;
            this._discussionQueryService = discussionQueryService;
            this._discussionRepository = discussionRepository;
            this._collaboratorService = collaboratorService;
        }

        private readonly ForumQueryService _forumQueryService;
        private readonly IForumRepository _forumRepository;
        private readonly ForumIdentityService _forumIdentityService;
        private readonly DiscussionQueryService _discussionQueryService;
        private readonly IDiscussionRepository _discussionRepository;
        private readonly ICollaboratorService _collaboratorService;

        public void AssignModeratorToForum(string tenantId, string forumId, string moderatorId)
        {
            var tenant = new Tenant(tenantId);

            var forum = _forumRepository.Get(tenant, new ForumId(forumId));

            var moderator = _collaboratorService.GetModeratorFrom(tenant, moderatorId);

            forum.AssignModerator(moderator);

            _forumRepository.Save(forum);
        }

        public void ChangeForumDescription(string tenantId, string forumId, string description)
        {
            var forum = _forumRepository.Get(new Tenant(tenantId), new ForumId(forumId));

            forum.ChangeDescription(description);

            _forumRepository.Save(forum);
        }

        public void ChangeForumSubject(string tenantId, string forumId, string subject)
        {
            var forum = _forumRepository.Get(new Tenant(tenantId), new ForumId(forumId));

            forum.ChangeSubject(subject);

            _forumRepository.Save(forum);
        }

        public void CloseForum(string tenantId, string forumId)
        {
            var forum = _forumRepository.Get(new Tenant(tenantId), new ForumId(forumId));

            forum.Close();

            _forumRepository.Save(forum);
        }

        public void ReOpenForum(string tenantId, string forumId)
        {
            var forum = _forumRepository.Get(new Tenant(tenantId), new ForumId(forumId));

            forum.ReOpen();

            _forumRepository.Save(forum);
        }

        public void StartForum(string tenantId, string creatorId, string moderatorId, string subject, string description, IForumCommandResult result = null)
        {
            var forum = StartNewForum(new Tenant(tenantId), creatorId, moderatorId, subject, description, null);

            if (result != null)
            {
                result.SetResultingForumId(forum.ForumId.Id);
            }
        }

        public void StartExclusiveForum(string tenantId, string exclusiveOwner, string creatorId, string moderatorId, string subject, string description, IForumCommandResult result = null)
        {
            var tenant = new Tenant(tenantId);

            Forum forum = null;

            var forumId = _forumQueryService.GetForumIdByExclusiveOwner(tenantId, exclusiveOwner);
            if (forumId != null)
            {
                forum = _forumRepository.Get(tenant, new ForumId(forumId));
            }

            if (forum == null)
            {
                forum = StartNewForum(tenant, creatorId, moderatorId, subject, description, exclusiveOwner);
            }

            if (result != null)
            {
                result.SetResultingForumId(forum.ForumId.Id);
            }
        }

        public void StartExclusiveForumWithDiscussion(
            string tenantId,
            string exclusiveOwner,
            string creatorId,
            string moderatorId,
            string authorId,
            string forumSubject,
            string forumDescription,
            string discussionSubject,
            IForumCommandResult result = null)
        {

            var tenant = new Tenant(tenantId);

            Forum forum = null;

            var forumId = _forumQueryService.GetForumIdByExclusiveOwner(tenantId, exclusiveOwner);
            if (forumId != null)
            {
                forum = _forumRepository.Get(tenant, new ForumId(forumId));
            }

            if (forum == null)
            {
                forum = StartNewForum(tenant, creatorId, moderatorId, forumSubject, forumDescription, exclusiveOwner);
            }

            Discussion discussion = null;

            var discussionId = _discussionQueryService.GetDiscussionIdByExclusiveOwner(tenantId, exclusiveOwner);
            if (discussionId != null)
            {
                discussion = _discussionRepository.Get(tenant, new DiscussionId(discussionId));
            }

            if (discussion == null)
            {
                var author = _collaboratorService.GetAuthorFrom(tenant, authorId);

                discussion = forum.StartDiscussionFor(_forumIdentityService, author, discussionSubject, exclusiveOwner);

                _discussionRepository.Save(discussion);
            }

            if (result != null)
            {
                result.SetResultingForumId(forum.ForumId.Id);
                result.SetResultingDiscussionId(discussion.DiscussionId.Id);
            }
        }

        private Forum StartNewForum(
            Tenant tenant,
            string creatorId,
            string moderatorId,
            string subject,
            string description,
            string exclusiveOwner)
        {
            var creator = _collaboratorService.GetCreatorFrom(tenant, creatorId);

            var moderator = _collaboratorService.GetModeratorFrom(tenant, moderatorId);

            var newForum = new Forum(
                        tenant,
                        _forumRepository.GetNextIdentity(),
                        creator,
                        moderator,
                        subject,
                        description,
                        exclusiveOwner);

            _forumRepository.Save(newForum);

            return newForum;
        }
    }
}
