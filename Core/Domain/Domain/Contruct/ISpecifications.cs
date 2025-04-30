using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contruct
{
    public interface ISpecifications<TEntity , TKey> where TEntity : ModelBase<TKey>
    {
       public  Expression<Func<TEntity,bool>>? Criteria { get;  }
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
        public Expression<Func<TEntity, object>>? OrderBy { get; }
        public Expression<Func<TEntity, object>>? OrderByDes { get; }
        public int Take { get; }
        public int Skip { get; }
        public bool IsPaginated { get; set; }

    }
}
