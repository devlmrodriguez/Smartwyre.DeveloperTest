using Smartwyre.DeveloperTest.Application.Interfaces;
using Smartwyre.DeveloperTest.Domain.Models;
using Smartwyre.DeveloperTest.Domain.Specifications;

namespace Smartwyre.DeveloperTest.Application.Handlers;

public class FixedRateRebateIncentiveHandler : IIncentiveHandler
{
    public CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        if (rebate is null || product is null)
        {
            return CalculateRebateResult.Fail();
        }

        if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
        {
            return CalculateRebateResult.Fail();
        }

        if (rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
        {
            return CalculateRebateResult.Fail();
        }

        var rebateAmount = product.Price * rebate.Percentage * request.Volume;
        return CalculateRebateResult.Succeed(rebateAmount);
    }
}
