using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Models
{
    public class TenantRole
    {

        public TenantRole(int id, string name, int roleId, string roleName)
        {
            Id = id;
            Name = name;
            RoleId = roleId;
            RoleName = roleName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
