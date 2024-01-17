using Smartwyre.DeveloperTest.Application.Interfaces;
using Smartwyre.DeveloperTest.Domain.Specifications;
using Smartwyre.DeveloperTest.Infrastructure.Interfaces;

namespace Smartwyre.DeveloperTest.Application.Services;

public class RebateService : IRebateService
{
    private readonly IDataStoreContext _dataStoreContext;
    private readonly IIncentiveHandlerFactory _incentiveHandlerFactory;

    public RebateService(IDataStoreContext dataStoreContext, IIncentiveHandlerFactory incentiveHandlerFactory)
    {
        _dataStoreContext = dataStoreContext;
        _incentiveHandlerFactory = incentiveHandlerFactory;
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var rebate = _dataStoreContext.RebateDataStore.GetRebate(request.RebateIdentifier);
        var product = _dataStoreContext.ProductDataStore.GetProduct(request.ProductIdentifier);

        var incentiveHandler = _incentiveHandlerFactory.Create(rebate.Incentive);
        var rebateResult = incentiveHandler.CalculateRebate(request, rebate, product);

        if (rebateResult.Success)
        {
            _dataStoreContext.RebateDataStore.StoreCalculationResult(rebate, rebateResult.Amount);
        }

        return rebateResult;
    }
}
