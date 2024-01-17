using Smartwyre.DeveloperTest.Domain.Models;

namespace Smartwyre.DeveloperTest.Infrastructure.Interfaces;

public interface IProductDataStore
{
    Product GetProduct(string productIdentifier);
}
