using System;
using SaaSOvation.AgilePM.Domain.Model.Teams;
using SaaSOvation.AgilePM.Domain.Model.Tenants;

namespace SaaSOvation.AgilePM.Application.Teams
{
    public class TeamApplicationService
    {
        public TeamApplicationService(ITeamMemberRepository teamMemberRepository, IProductOwnerRepository productOwnerRepository)
        {
            this._teamMemberRepository = teamMemberRepository;
            this._productOwnerRepository = productOwnerRepository;
        }

        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IProductOwnerRepository _productOwnerRepository;

        public void EnableProductOwner(EnableProductOwnerCommand command)
        {
            var tenantId = new TenantId(command.TenantId);
            ApplicationServiceLifeCycle.Begin();
            try
            {
                var productOwner = _productOwnerRepository.Get(tenantId, command.Username);
                if (productOwner != null)
                {
                    productOwner.Enable(command.OccurredOn);
                }
                else
                {
                    productOwner = new ProductOwner(tenantId, command.Username, command.FirstName, command.LastName, command.EmailAddress, command.OccurredOn);
                    _productOwnerRepository.Save(productOwner);
                }
                ApplicationServiceLifeCycle.Success();
            }
            catch (Exception ex)
            {
                ApplicationServiceLifeCycle.Fail(ex);
            }
        }

        public void EnableTeamMember(EnableTeamMemberCommand command)
        {
            var tenantId = new TenantId(command.TenantId);
            ApplicationServiceLifeCycle.Begin();
            try
            {
                var teamMember = _teamMemberRepository.Get(tenantId, command.Username);
                if (teamMember != null)
                {
                    teamMember.Enable(command.OccurredOn);
                }
                else
                {
                    teamMember = new TeamMember(tenantId, command.Username, command.FirstName, command.LastName, command.EmailAddress, command.OccurredOn);
                    _teamMemberRepository.Save(teamMember);
                }
                ApplicationServiceLifeCycle.Success();
            }
            catch (Exception ex)
            {
                ApplicationServiceLifeCycle.Fail(ex);
            }
        }

        public void ChangeTeamMemberEmailAddress(ChangeTeamMemberEmailAddressCommand command)
        {
            var tenantId = new TenantId(command.TenantId);
            ApplicationServiceLifeCycle.Begin();
            try
            {
                var productOwner = _productOwnerRepository.Get(tenantId, command.Username);
                if (productOwner != null)
                {
                    productOwner.ChangeEmailAddress(command.EmailAddress, command.OccurredOn);
                    _productOwnerRepository.Save(productOwner);
                }

                var teamMember = _teamMemberRepository.Get(tenantId, command.Username);
                if (teamMember != null)
                {
                    teamMember.ChangeEmailAddress(command.EmailAddress, command.OccurredOn);
                    _teamMemberRepository.Save(teamMember);
                }

                ApplicationServiceLifeCycle.Success();
            }
            catch (Exception ex)
            {
                ApplicationServiceLifeCycle.Fail(ex);
            }
        }

        public void ChangeTeamMemberName(ChangeTeamMemberNameCommand command)
        {
            var tenantId = new TenantId(command.TenantId);
            ApplicationServiceLifeCycle.Begin();
            try
            {
                var productOwner = _productOwnerRepository.Get(tenantId, command.Username);
                if (productOwner != null)
                {
                    productOwner.ChangeName(command.FirstName, command.LastName, command.OccurredOn);
                    _productOwnerRepository.Save(productOwner);
                }

                var teamMember = _teamMemberRepository.Get(tenantId, command.Username);
                if (teamMember != null)
                {
                    teamMember.ChangeName(command.FirstName, command.LastName, command.OccurredOn);
                    _teamMemberRepository.Save(teamMember);
                }

                ApplicationServiceLifeCycle.Success();
            }
            catch (Exception ex)
            {
                ApplicationServiceLifeCycle.Fail(ex);
            }
        }

        public void DisableProductOwner(DisableProductOwnerCommand command)
        {
            var tenantId = new TenantId(command.TenantId);
            ApplicationServiceLifeCycle.Begin();
            try
            {
                var productOwner = _productOwnerRepository.Get(tenantId, command.Username);
                if (productOwner != null)
                {
                    productOwner.Disable(command.OccurredOn);
                    _productOwnerRepository.Save(productOwner);
                }
                ApplicationServiceLifeCycle.Success();
            }
            catch (Exception ex)
            {
                ApplicationServiceLifeCycle.Fail(ex);
            }
        }

        public void DisableTeamMember(DisableTeamMemberCommand command)
        {
            var tenantId = new TenantId(command.TenantId);
            ApplicationServiceLifeCycle.Begin();
            try
            {
                var teamMember = _teamMemberRepository.Get(tenantId, command.Username);
                if (teamMember != null)
                {
                    teamMember.Disable(command.OccurredOn);
                    _teamMemberRepository.Save(teamMember);
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
