using Smartwyre.DeveloperTest.Domain.Models;
using Smartwyre.DeveloperTest.Infrastructure.Interfaces;

namespace Smartwyre.DeveloperTest.Infrastructure.Data;

public class ProductDataStore : IProductDataStore
{
    public Product GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return new Product();
    }
}
