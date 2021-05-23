using Identity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity.Domain.Filters
{
    public class UserFilter
    {
        private IQueryable<User> _query;
        public UserFilter(IQueryable<User> query)
        {
            _query = query;
        }

        public UserFilter HasId(int id)
        {
            if (id != default)
                _query = _query.Where(user => user.Id == id);

            return this;
        }

        public UserFilter HasFirstName(string firstName)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
                _query = _query.Where(
                    user => user.Firstname
                        .ToLower()
                        .Contains(firstName)
                    );

            return this;
        }

        public UserFilter HasLastName(string lastName)
        {
            if (!string.IsNullOrWhiteSpace(lastName))
                _query = _query.Where(
                    user => user.Lastname
                        .ToLower()
                        .Contains(lastName)
                    );

            return this;
        }

        public IQueryable<User> GetQuery() => _query;
    }
}
