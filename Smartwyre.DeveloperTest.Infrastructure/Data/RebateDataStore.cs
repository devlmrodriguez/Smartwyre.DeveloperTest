using Smartwyre.DeveloperTest.Domain.Models;
using Smartwyre.DeveloperTest.Infrastructure.Interfaces;

namespace Smartwyre.DeveloperTest.Infrastructure.Data;

public class RebateDataStore : IRebateDataStore
{
    public Rebate GetRebate(string rebateIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return new Rebate();
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        // Update account in database, code removed for brevity
    }
}
