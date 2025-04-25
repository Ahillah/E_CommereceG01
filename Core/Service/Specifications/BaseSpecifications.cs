using Domain.Contruct;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : ModelBase<TKey>
    {
        protected BaseSpecifications(Expression<Func<TEntity, bool>>? PassedExp)
        {Criteria= PassedExp; }
            
        
        public Expression<Func<TEntity, bool>>? Criteria {  get; private set; }

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new List<Expression<Func<TEntity, object>>>();
 
      protected void AddInclude (Expression<Func<TEntity, object>> IncludeExpression)
        {
            IncludeExpressions.Add(IncludeExpression);

        }
    }
}
