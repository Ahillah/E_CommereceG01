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
        #region Criteria
        protected BaseSpecifications(Expression<Func<TEntity, bool>> PassedExp)
        { Criteria = PassedExp; }


        public Expression<Func<TEntity, bool>> Criteria { get; private set; } 
        #endregion

        #region Include
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new List<Expression<Func<TEntity, object>>>();


        protected void AddInclude(Expression<Func<TEntity, object>> IncludeExpression)
        {
            IncludeExpressions.Add(IncludeExpression);

            #endregion
        }
        #region Sorting
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDes { get; private set; }
        protected void AddOrderBy (Expression<Func<TEntity, object>> OrderByExp)=> OrderBy=OrderByExp;
        protected void AddOrderByDes(Expression<Func<TEntity, object>> OrderByDesExp) => OrderByDes = OrderByDesExp;
        #endregion
    }
}
