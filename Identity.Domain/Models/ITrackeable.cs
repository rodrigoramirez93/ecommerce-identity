using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Models
{
    public interface ITrackable
    {
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
