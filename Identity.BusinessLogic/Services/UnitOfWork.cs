using Identity.BusinessLogic.Interfaces;
using Identity.Domain;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.BusinessLogic.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _context;
        private Repository<Tenant> _tenantRepository;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IRepository<Tenant> Tenants
        {
            get
            {
                return _tenantRepository ?? (_tenantRepository = new Repository<Tenant>(_context));
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
