namespace Smartwyre.DeveloperTest.Infrastructure.Interfaces;

public interface IDataStoreContext
{
    IProductDataStore ProductDataStore { get; }
    IRebateDataStore RebateDataStore { get; }
}
