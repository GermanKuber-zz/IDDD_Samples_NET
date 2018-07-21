using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems;

namespace SaaSOvation.AgilePM.Application.Products.BacklogItems
{
    public class BacklogItemApplicationService
    {
        public BacklogItemApplicationService(IBacklogItemRepository backlogItemRepository)
        {
            this._backlogItemRepository = backlogItemRepository;
        }

        private readonly IBacklogItemRepository _backlogItemRepository;

        // TODO: APIs for student assignment
    }
}
