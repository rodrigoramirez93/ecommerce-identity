using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Identity.Domain.Models
{
    public class LoggedUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
        public IEnumerable<Claim> Tenants { get; set; }
    }
}
