using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Model
{
    public interface ITrackable
    {
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
