using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerece.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public Product Get()
        {  return new Product() { Id=1, Name="Chai"}; }

        [HttpPost]
        public Product InsertProduct()
        { return new Product() { Id = 2, Name = "Coffie" }; }

        [HttpPut]
            
        public Product UpdateProduct()
        { return new Product() { Id = 2, Name = "Coffie" }; }
        [HttpDelete]

        [HttpDelete]
        public Product DeleteProduct()
        { return new Product() { Id = 2, Name = "Coffie" }; }
    }
}
