using Identity.Domain;
using Identity.Domain.Models;

namespace Identity.BusinessLogic.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Tenant> Tenants { get; }
        void Commit();
    }
}
