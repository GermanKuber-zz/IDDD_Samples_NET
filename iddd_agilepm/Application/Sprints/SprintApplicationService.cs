using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems;
using SaaSOvation.AgilePM.Domain.Model.Products.Sprints;
using SaaSOvation.AgilePM.Domain.Model.Tenants;

namespace SaaSOvation.AgilePM.Application.Sprints
{
    public class SprintApplicationService
    {
        public SprintApplicationService(ISprintRepository sprintRepository, IBacklogItemRepository backlogItemRepository)
        {
            this._sprintRepository = sprintRepository;
            this._backlogItemRepository = backlogItemRepository;
        }

        private readonly ISprintRepository _sprintRepository;
        private readonly IBacklogItemRepository _backlogItemRepository;

        public void CommitBacklogItemToSprint(CommitBacklogItemToSprintCommand command)
        {
            var tenantId = new TenantId(command.TenantId);
            var sprint = _sprintRepository.Get(tenantId, new SprintId(command.SprintId));
            var backlogItem = _backlogItemRepository.Get(tenantId, new BacklogItemId(command.BacklogItemId));

            sprint.Commit(backlogItem);

            _sprintRepository.Save(sprint);
        }

    }
}
