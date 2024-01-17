using Smartwyre.DeveloperTest.Domain.Specifications;

namespace Smartwyre.DeveloperTest.Application.Interfaces;

public interface IRebateService
{
    CalculateRebateResult Calculate(CalculateRebateRequest request);
}
