namespace SaaSOvation.AgilePM.Application.Sprints
{
    public class CommitBacklogItemToSprintCommand
    {
        public CommitBacklogItemToSprintCommand()
        {
        }

        public CommitBacklogItemToSprintCommand(string tenantId, string backlogItemId, string sprintId)
        {
            TenantId = tenantId;
            BacklogItemId = backlogItemId;
            SprintId = sprintId;
        }

        public string TenantId { get; set; }
        public string BacklogItemId { get; set; }
        public string SprintId { get; set;}
    }
}
