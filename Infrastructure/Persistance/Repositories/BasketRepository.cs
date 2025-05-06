using Domain.Contruct;
using Domain.Models.Basket;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connection) : IBasketRepository
    { private readonly IDatabase _database=connection.GetDatabase();
        public async Task<CustomerBasket?> GetBasketAsync(string Key)
        {
            var Basket= await _database.StringGetAsync(Key);
            if (Basket.IsNullOrEmpty)
                return null;
            return JsonSerializer.Deserialize<CustomerBasket>(Basket!);
        }
        public async Task<CustomerBasket?> CreateOrUpdateAsync(CustomerBasket customerBasket, TimeSpan? timeToLive = null)
        {
           var jsonBasket=JsonSerializer.Serialize(customerBasket);
            var IsCreateOrUpdate = await _database.StringSetAsync(customerBasket.Id, jsonBasket, timeToLive ?? TimeSpan.FromDays(30));
            if (IsCreateOrUpdate)
                return await GetBasketAsync(customerBasket.Id);
            return null;
        }

        public async Task<bool> DeleteBasketAsync(string Key)
        {
           return await _database.KeyDeleteAsync(Key);
        }

        
    }
}
