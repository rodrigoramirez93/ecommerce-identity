using Identity.Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Model
{
    public class UserLogin : IdentityUserLogin<int>, IAuditable
    {
        public DateTime? DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedBy { get; set; }
    }
}
