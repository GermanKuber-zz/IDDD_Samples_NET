namespace SaaSOvation.IdentityAccess.Application
{
	using System;

	using Commands;
	using Domain.Model.Access;
	using Domain.Model.Identity;

	[CLSCompliant(true)]
	public sealed class AccessApplicationService
	{
		private readonly IGroupRepository _groupRepository;
		private readonly IRoleRepository _roleRepository;
		private readonly ITenantRepository _tenantRepository;
		private readonly IUserRepository _userRepository;

		public AccessApplicationService(
			IGroupRepository groupRepository,
			IRoleRepository roleRepository,
			ITenantRepository tenantRepository,
			IUserRepository userRepository)
		{
			this._groupRepository = groupRepository;
			this._roleRepository = roleRepository;
			this._tenantRepository = tenantRepository;
			this._userRepository = userRepository;
		}

		public void AssignUserToRole(AssignUserToRoleCommand command)
		{
			var tenantId = new TenantId(command.TenantId);
			var user = _userRepository.UserWithUsername(tenantId, command.Username);
			if (user != null)
			{
				var role = _roleRepository.RoleNamed(tenantId, command.RoleName);
				if (role != null)
				{
					role.AssignUser(user);
				}
			}
		}

		public bool IsUserInRole(string tenantId, string userName, string roleName)
		{
			return UserInRole(tenantId, userName, roleName) != null;
		}

		public User UserInRole(string tenantId, string userName, string roleName)
		{
			var id = new TenantId(tenantId);
			var user = _userRepository.UserWithUsername(id, userName);
			if (user != null)
			{
				var role = _roleRepository.RoleNamed(id, roleName);
				if (role != null)
				{
					if (role.IsInRole(user, new GroupMemberService(_userRepository, _groupRepository)))
					{
						return user;
					}
				}
			}

			return null;
		}

		public void ProvisionRole(ProvisionRoleCommand command)
		{
			var tenantId = new TenantId(command.TenantId);
			var tenant = _tenantRepository.Get(tenantId);
			var role = tenant.ProvisionRole(command.RoleName, command.Description, command.SupportsNesting);
			_roleRepository.Add(role);
		}
	}
}