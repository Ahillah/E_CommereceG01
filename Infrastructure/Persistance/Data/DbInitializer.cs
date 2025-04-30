using Domain.Contruct;
using Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistance.Data
{
    public class DbInitializer(StoreDBContext context) : IDbInitializer
    {
        public async Task initializeAsync()
        {
            if ((await context.Database.GetPendingMigrationsAsync()).Any())

            {

                await context.Database.MigrateAsync();
                    }
            try
            {
                if (!context.Set<ProductBrand>().Any())
                {
                    var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\Seeds\brands.json");
                    var objects = JsonSerializer.Deserialize<List<ProductBrand>>(data);


                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductBrand>().AddRange(objects);
                        await context.SaveChangesAsync();

                    }




                }

                if (!context.Set<ProductType>().Any())
                {
                    var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\Seeds\types.json");
                    var objects = JsonSerializer.Deserialize<List<ProductType>>(data);


                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductType>().AddRange(objects);
                        await context.SaveChangesAsync();

                    }
                }
                if (!context.Set<Product>().Any())
                {
                    var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\Seeds\products.json");
                    var objects = JsonSerializer.Deserialize<List<Product>>(data);


                    if (objects is not null && objects.Any())
                    {
                        context.Set<Product>().AddRange(objects);
                        await context.SaveChangesAsync();

                    }




                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }



    } }
    

