using SaaSOvation.Collaboration.Domain.Model.Forums;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Application.Forums
{
    public class PostApplicationService
    {
        public PostApplicationService(IPostRepository postRepository, IForumRepository forumRepository, ICollaboratorService collaboratorService)
        {
            this._postRepository = postRepository;
            this._forumRepository = forumRepository;
            this._collaboratorService = collaboratorService;
        }

        private readonly IPostRepository _postRepository;
        private readonly IForumRepository _forumRepository;
        private readonly ICollaboratorService _collaboratorService;

        public void ModeratePost(
            string tenantId,
            string forumId,
            string postId,
            string moderatorId,
            string subject,
            string bodyText)
        {
            var tenant = new Tenant(tenantId);

            var forum = _forumRepository.Get(tenant, new ForumId(forumId));

            var moderator = _collaboratorService.GetModeratorFrom(tenant, moderatorId);

            var post = _postRepository.Get(tenant, new PostId(postId));

            forum.ModeratePost(post, moderator, subject, bodyText);

            _postRepository.Save(post);
        }
    }
}
