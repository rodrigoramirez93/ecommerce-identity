using Identity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity.Domain.Filters
{
    public class UserFilter : SearchFilter<User>
    {
        public UserFilter(IQueryable<User> query) : base(query) { }

        public UserFilter HasId(int id)
        {
            if (id != default)
                Query = Query.Where(user => user.Id == id);

            return this;
        }

        public UserFilter HasFirstName(string firstName)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
                Query = Query.Where(
                    user => user.Firstname
                        .ToLower()
                        .Contains(firstName)
                    );

            return this;
        }

        public UserFilter HasLastName(string lastName)
        {
            if (!string.IsNullOrWhiteSpace(lastName))
                Query = Query.Where(
                    user => user.Lastname
                        .ToLower()
                        .Contains(lastName)
                    );

            return this;
        }

        public IQueryable<User> GetQuery() => Query;
    }
}
