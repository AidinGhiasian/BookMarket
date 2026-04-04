


using AccountManagement.Domain.RoleAgg;

namespace AccountM.Application.Contracts.RoleApplication
{
    public class CreateViewModel
    {
        public string RoleName { get; set; }
        public List<int> Permissions { get; set; }
        public string details { get; set; }
    }
}
