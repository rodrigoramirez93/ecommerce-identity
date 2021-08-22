using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core.Dto
{
    public class TenantRoleDto
    {
        public TenantRoleDto(int tenantId, string tenantName, string tenantHeader, int roleId, string roleName)
        {
            TenantId = tenantId;
            TenantName = tenantName;
            TenantHeader = tenantHeader;
            RoleId = roleId;
            RoleName = roleName;
        }

        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string TenantHeader { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class UserDto
    {
        public UserDto(string id, string firstname, string lastname)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
        }

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
