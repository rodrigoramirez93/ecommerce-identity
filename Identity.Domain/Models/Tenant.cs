using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Models
{
    public class Tenant : Entity, IAuditable 
    {
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedBy { get; set; }
    }
}
