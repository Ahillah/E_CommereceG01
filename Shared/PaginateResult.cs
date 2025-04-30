using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PaginateResult<TEntity> 
    {
        public int pageSize {  get; set; }
        public int pageIndex { get; set; }
        public int totalCount { get; set; }
        public IEnumerable<TEntity> Data { get; set; }

        public PaginateResult(int pageSize, int pageIndex, int totalCount, IEnumerable<TEntity> data)
        {
            this.pageSize = pageSize;
            this.pageIndex = pageIndex;
            this.totalCount = totalCount;
            Data = data;
        }
    }
}
