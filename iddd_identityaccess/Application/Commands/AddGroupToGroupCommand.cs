namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class AddGroupToGroupCommand
    {
        public AddGroupToGroupCommand()
        {
        }

        public AddGroupToGroupCommand(string tenantId, string childGroupName, string parentGroupName)
        {
            TenantId = tenantId;
            ChildGroupName = childGroupName;
            ParentGroupName = parentGroupName;
        }

        public string TenantId { get; set; }
        public string ChildGroupName { get; set; }
        public string ParentGroupName { get; set; }
    }
}
