using Smartwyre.DeveloperTest.Domain.Models;
using Smartwyre.DeveloperTest.Domain.Specifications;

namespace Smartwyre.DeveloperTest.Application.Interfaces;

public interface IIncentiveHandler
{
    CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product);
}
