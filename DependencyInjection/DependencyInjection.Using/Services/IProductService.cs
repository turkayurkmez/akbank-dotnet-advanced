using DependencyInjection.Using.Models;

namespace DependencyInjection.Using.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}