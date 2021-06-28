using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core.Dto
{
    public class ReadRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AccessDto> Claims { get; set; }
    }

    public class UpdateRoleDto
    {
        public string Name { get; set; }
    }

    public class CreateRoleDto
    {
        public string Name { get; set; }
        public int TenantId { get; set; }
    }

    public class AccessDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
