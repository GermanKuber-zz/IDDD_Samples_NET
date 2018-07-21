using SaaSOvation.Collaboration.Domain.Model.Forums;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Application.Forums.Data;

namespace SaaSOvation.Collaboration.Application.Forums
{
    public class DiscussionApplicationService
    {
        public DiscussionApplicationService(
            IDiscussionRepository discussionRepository,
            ForumIdentityService forumIdentityService,
            IPostRepository postRepository,
            ICollaboratorService collaboratorService)
        {
            this._discussionRepository = discussionRepository;
            this._forumIdentityService = forumIdentityService;
            this._postRepository = postRepository;
            this._collaboratorService = collaboratorService;
        }

        private readonly ICollaboratorService _collaboratorService;
        private readonly IDiscussionRepository _discussionRepository;
        private readonly ForumIdentityService _forumIdentityService;
        private readonly IPostRepository _postRepository;

        public void CloseDiscussion(string tenantId, string discussionId)
        {
            var discussion = _discussionRepository.Get(new Tenant(tenantId), new DiscussionId(discussionId));

            discussion.Close();

            _discussionRepository.Save(discussion);
        }

        public void PostToDiscussion(string tenantId, string discussionId, string authorId, string subject, string bodyText, IDiscussionCommandResult discussionCommandResult)
        {
            var discussion = _discussionRepository.Get(new Tenant(tenantId), new DiscussionId(discussionId));

            var author = _collaboratorService.GetAuthorFrom(new Tenant(tenantId), authorId);

            var post = discussion.Post(_forumIdentityService, author, subject, bodyText);

            _postRepository.Save(post);

            discussionCommandResult.SetResultingDiscussionId(discussionId);
            discussionCommandResult.SetResultingPostId(post.PostId.Id);
        }

        public void PostToDiscussionInReplyTo(string tenantId, string discussionId, string replyToPostId, string authorId,
            string subject, string bodyText, IDiscussionCommandResult discussionCommandResult)
        {
            var discussion = _discussionRepository.Get(new Tenant(tenantId), new DiscussionId(discussionId));

            var author = _collaboratorService.GetAuthorFrom(new Tenant(tenantId), authorId);

            var post = discussion.Post(_forumIdentityService, author, subject, bodyText, new PostId(replyToPostId));

            _postRepository.Save(post);

            discussionCommandResult.SetResultingDiscussionId(discussionId);
            discussionCommandResult.SetResultingPostId(post.PostId.Id);
            discussionCommandResult.SetRresultingInReplyToPostId(replyToPostId);
        }

        public void ReOpenDiscussion(string tenantId, string discussionId)
        {
            var discussion = _discussionRepository.Get(new Tenant(tenantId), new DiscussionId(discussionId));

            discussion.ReOpen();

            _discussionRepository.Save(discussion);
        }
    }
}
