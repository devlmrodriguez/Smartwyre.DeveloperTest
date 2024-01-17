using Cocona.Builder;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Application.Handlers;
using Smartwyre.DeveloperTest.Application.Interfaces;
using Smartwyre.DeveloperTest.Application.Services;
using Smartwyre.DeveloperTest.Domain.Models;
using Smartwyre.DeveloperTest.Infrastructure.Data;
using Smartwyre.DeveloperTest.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Runner;

internal static class AppServices
{
    public static void AddAppServices(this CoconaAppBuilder builder)
    {
        var services = builder.Services;

        // Data stores
        services.AddSingleton<IProductDataStore, ProductDataStore>();
        services.AddSingleton<IRebateDataStore, RebateDataStore>();
        services.AddSingleton<IDataStoreContext, DataStoreContext>();

        // Handlers
        services.AddTransient<IIncentiveHandlerFactory>(_ =>
        {
            var handlers = new Dictionary<IncentiveType, IIncentiveHandler>()
            {
                { IncentiveType.FixedCashAmount, new FixedCashAmountIncentiveHandler() },
                { IncentiveType.FixedRateRebate, new FixedRateRebateIncentiveHandler() },
                { IncentiveType.AmountPerUom, new AmountPerUomIncentiveHandler() }
            };

            return new IncentiveHandlerFactory(handlers);
        });

        // Services
        services.AddTransient<IRebateService, RebateService>();
    }
}
