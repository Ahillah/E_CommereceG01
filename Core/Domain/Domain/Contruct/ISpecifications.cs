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
    }
}
