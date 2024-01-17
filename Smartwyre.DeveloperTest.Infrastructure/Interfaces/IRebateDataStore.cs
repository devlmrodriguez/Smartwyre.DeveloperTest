using Smartwyre.DeveloperTest.Domain.Models;

namespace Smartwyre.DeveloperTest.Infrastructure.Interfaces;

public interface IRebateDataStore
{
    Rebate GetRebate(string rebateIdentifier);
    void StoreCalculationResult(Rebate account, decimal rebateAmount);
}
