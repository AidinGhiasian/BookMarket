using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMInfrastructureConfiguration.Permissions
{
    public class PermissionDTO
    {
        public int Code { get; set; }
        public string Name { get; set; }
        
        public PermissionDTO(int code,string name)
        {
            Code = code;
            Name = name;
        }
    }
}
