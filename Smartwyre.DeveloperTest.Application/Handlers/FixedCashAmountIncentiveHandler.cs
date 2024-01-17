using Smartwyre.DeveloperTest.Application.Interfaces;
using Smartwyre.DeveloperTest.Domain.Models;
using Smartwyre.DeveloperTest.Domain.Specifications;

namespace Smartwyre.DeveloperTest.Application.Handlers;

public class FixedCashAmountIncentiveHandler : IIncentiveHandler
{
    public CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        if (rebate is null || product is null)
        {
            return CalculateRebateResult.Fail();
        }

        if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
        {
            return CalculateRebateResult.Fail();
        }

        if (rebate.Amount == 0)
        {
            return CalculateRebateResult.Fail();
        }

        var rebateAmount = rebate.Amount;
        return CalculateRebateResult.Succeed(rebateAmount);
    }
}
