using AccountM.Application.Contracts.RoleApplication;
using AccountManagement.Domain.RoleAgg;
using Services.Application;
using Services.Infrastructure;

namespace AccountM.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult Create(CreateViewModel command)
        {
            var operation = new OperationResult();
            if (string.IsNullOrWhiteSpace(command.RoleName))
                return operation.Failed("نام نقش الزامی است.");

            var role = new Role(command.RoleName, new List<Permission>(), command.details ?? "");
            _roleRepository.Create(role);
            _roleRepository.SaveChanges();
            return operation.IsSuccess();
        }

        public OperationResult Edit(EditViewModel command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.GetById(command.Id);
            if (role == null)
                return operation.Failed(ApplicationMessage.NotFound);

            var permissions = new List<Permission>();
            if (command.Permissions != null)
                command.Permissions.ForEach(code => permissions.Add(new Permission(code, "")));

            role.Edit(command.RoleName, permissions, command.details ?? "", command.isActive);
            _roleRepository.SaveChanges();
            return operation.IsSuccess();
        }

        private static List<PermissionDto> MapPermissions(IEnumerable<Permission> permissions)
            => permissions.Select(x => new PermissionDto(x.PermissionCode, x.NamePermission)).ToList();

        public EditViewModel GetDetails(int id)
        {
            var role = _roleRepository.GetDetails(id);
            if (role == null)
                throw new InvalidOperationException(ApplicationMessage.NotFound);

            var roles = new EditViewModel
            {
                Id = role.Id,
                RoleName = role.RoleName,
                details = role.Details,
                isActive = role.IsActive,
                MappedPermissions = MapPermissions(role.Permissions ?? new List<Permission>()),
            };
            if (roles.MappedPermissions != null)
                roles.Permissions = roles.MappedPermissions.Select(x => x.Code).ToList();
            return roles;
        }

        public List<RoleViewModel> List()
        {
            var roleList = _roleRepository.List();
            return roleList.Select(Map).ToList();
        }

        private static RoleViewModel Map(Role roles)
        {
            return new RoleViewModel
            {
                Id = roles.Id,
                RoleName = roles.RoleName,
                Details = roles.Details,
            };
        }
    }
}
