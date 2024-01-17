using Smartwyre.DeveloperTest.Infrastructure.Interfaces;

namespace Smartwyre.DeveloperTest.Infrastructure.Data;

public class DataStoreContext : IDataStoreContext
{
    private readonly IProductDataStore _productDataStore;
    private readonly IRebateDataStore _rebateDataStore;

    public DataStoreContext(IProductDataStore productDataStore, IRebateDataStore rebateDataStore)
    {
        _productDataStore = productDataStore;
        _rebateDataStore = rebateDataStore;
    }

    public IProductDataStore ProductDataStore => _productDataStore;
    public IRebateDataStore RebateDataStore => _rebateDataStore;
}
