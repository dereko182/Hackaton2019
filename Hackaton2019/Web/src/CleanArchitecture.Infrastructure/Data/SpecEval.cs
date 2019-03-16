using CleanArchitecture.Core;
using CleanArchitecture.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null) query = query.Where(specification.Criteria);

            if (specification.Includes != null)
                query = specification.Includes.Aggregate(query,
                    (current, include) => current.Include(include));

            if (specification.IncludeStrings != null)
                query = specification.IncludeStrings.Aggregate(query,
                    (current, include) => current.Include(include));

            if (specification.OrderBy != null)
                query = query.OrderBy(specification.OrderBy);
            else if (specification.OrderByDescending != null)
                query = query.OrderByDescending(specification.OrderByDescending);

            if (specification.IsPagingEnabled)
                query = query.Skip(specification.Skip)
                    .Take(specification.Take);

            return query;
        }
    }
}
