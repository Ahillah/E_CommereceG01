using Domain.Contruct;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery <TEntity, TKey>(IQueryable<TEntity> inputQuery, ISpecifications<TEntity,TKey> spec)
         where TEntity : ModelBase<TKey>
        { 
           var Query = inputQuery;
            if(spec.Criteria is not null)
                Query=Query.Where(spec.Criteria);
            if(spec.IncludeExpressions is not null && spec.IncludeExpressions.Count()>0)
            {
                Query = spec.IncludeExpressions.Aggregate(Query,(Current, EXP) => Current.Include(EXP));
            }
            return Query;
        
        }
    }
}
