namespace SaaSOvation.Collaboration.Application.Forums.Data
{
    public interface IDiscussionCommandResult
    {
        void SetResultingDiscussionId(string discussionId);

        void SetResultingPostId(string postId);

        void SetRresultingInReplyToPostId(string replyToPostId);
    }
}
