using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity.Domain.Filters
{
    public class SearchFilter<T> where T: IAuditable
    {
        public IQueryable<T> Query { get; set; }

        public SearchFilter(IQueryable<T> query)
        {
            Query = query;
        }

        public SearchFilter<T> ModifiedSince(DateTime? date)
        {
            Query = Query.Where(t => t.DateUpdated > date);

            return this;
        }

        public SearchFilter<T> DeletedSince(DateTime? date)
        {
            Query = Query.Where(t => t.DateDeleted > date);

            return this;
        }

        public SearchFilter<T> CreatedSince(DateTime? date)
        {
            Query = Query.Where(t => t.DateCreated > date);

            return this;
        }
    }
}
