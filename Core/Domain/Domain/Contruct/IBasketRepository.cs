using Domain.Models.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contruct
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string Key);
        Task<CustomerBasket?> CreateOrUpdateAsync(CustomerBasket customerBasket,TimeSpan? timeToLive=null);
        Task<bool> DeleteBasketAsync(string Key);
    }
}
