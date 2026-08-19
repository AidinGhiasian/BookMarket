using BlogMInfrastructureConfiguration.Permissions;
using System.Collections.Generic;

namespace Services.Infrastructure
{
    public interface IPermissionExposer
    {
        Dictionary<string, List<PermissionDTO>> Expose();
    }
}