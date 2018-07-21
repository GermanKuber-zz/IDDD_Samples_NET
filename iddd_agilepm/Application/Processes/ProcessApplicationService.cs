using System;
using SaaSOvation.Common.Domain.Model.LongRunningProcess;

namespace SaaSOvation.AgilePM.Application.Processes
{
    public class ProcessApplicationService
    {
        public ProcessApplicationService(ITimeConstrainedProcessTrackerRepository processTrackerRepository)
        {
            this._processTrackerRepository = processTrackerRepository;
        }

        private readonly ITimeConstrainedProcessTrackerRepository _processTrackerRepository;

        public void CheckForTimedOutProccesses()
        {
            ApplicationServiceLifeCycle.Begin();
            try
            {
                var trackers = _processTrackerRepository.GetAllTimedOut();

                foreach (var tracker in trackers)
                {
                    tracker.InformProcessTimedOut();
                    _processTrackerRepository.Save(tracker);
                }

                ApplicationServiceLifeCycle.Success();
            }
            catch (Exception ex)
            {
                ApplicationServiceLifeCycle.Fail(ex);
            }
        }
    }
}
