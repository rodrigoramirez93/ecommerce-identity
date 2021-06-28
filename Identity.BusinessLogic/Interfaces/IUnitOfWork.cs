using Identity.Domain;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.BusinessLogic.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Tenant> Tenants { get; }
        void Commit();
    }
}
