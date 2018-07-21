namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class ForumIdentityService
    {
        public ForumIdentityService(IDiscussionRepository discussionRepository, IForumRepository forumRepository, IPostRepository postRepository)
        {
            this._discussionRepository = discussionRepository;
            this._forumRepository = forumRepository;
            this._postRepository = postRepository;
        }

        private readonly IDiscussionRepository _discussionRepository;
        private readonly IForumRepository _forumRepository;
        private readonly IPostRepository _postRepository;

        public DiscussionId GetNextDiscussionId()
        {
            return _discussionRepository.GetNextIdentity();
        }

        public ForumId GetNextForumId()
        {
            return _forumRepository.GetNextIdentity();
        }

        public PostId GetNexPostId()
        {
            return _postRepository.GetNextIdentity();
        }
    }
}
