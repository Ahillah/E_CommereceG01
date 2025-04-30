using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryParms
    {
        private const int DefualtPageSize = 5;
        private const int MaxPageSize = 5;
     

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public  ProductSortingOptions SortingOptions { get; set; }
        public string? SearchValue { get; set; }

        private int pageSize=MaxPageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize= value>MaxPageSize? MaxPageSize:value; }
        }



        public int pageIndex { get; set; } = 1;
    }
}
