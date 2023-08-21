using DependencyInjection.Using.Models;

namespace DependencyInjection.Using.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new(){ Name ="zzz", Price =1},
                new(){ Name ="xxx", Price =2},

            };
        }
    }


    public class AnotherProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new(){ Name ="Abc", Price =1},
                new(){ Name ="cde", Price =2},

            };
        }
    }
}
