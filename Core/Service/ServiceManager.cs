
using Abstraction;
using AutoMapper;
using Domain.Contruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper) : IServicesManager
    {
        private readonly Lazy<IProductServices> _LazyproductServices = new Lazy<IProductServices>(() => new ProductServices(unitOfWork, mapper));
        public IProductServices ProductServices => _LazyproductServices.Value;
}
