using Cocona;
using Serilog;
using Smartwyre.DeveloperTest.Application.Interfaces;
using Smartwyre.DeveloperTest.Domain.Specifications;

namespace Smartwyre.DeveloperTest.Runner;

internal static class AppCommands
{
    public static void AddAppCommands (this CoconaApp app)
    {
        app.AddCommand("CalculateRebate", ([Option]string rebateId, [Option] string productId, [Option] decimal volume, IRebateService rebateService) =>
        {
            Log.Logger.Information("--- CalculateRebate command started ---");

            Log.Logger.Information("RebateId: {tRebateId}", rebateId);
            Log.Logger.Information("ProductId: {tProductId}", productId);
            Log.Logger.Information("Volume: {tVolume}", volume);

            var request = new CalculateRebateRequest()
            {
                ProductIdentifier = productId,
                RebateIdentifier = rebateId,
                Volume = volume
            };
            var result = rebateService.Calculate(request);

            Log.Logger.Information("Success: {Success}, Amount: {Amount}", result.Success, result.Amount);

            Log.Logger.Information("--- CalculateRebate command stopped ---");
        });
    }
}
