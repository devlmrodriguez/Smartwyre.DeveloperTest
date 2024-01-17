using FluentAssertions;
using Smartwyre.DeveloperTest.Application.Handlers;
using Smartwyre.DeveloperTest.Application.Interfaces;
using Smartwyre.DeveloperTest.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class IncentiveHandlerFactoryTests
{
    private readonly Dictionary<IncentiveType, IIncentiveHandler> _handlersMock;

    public IncentiveHandlerFactoryTests()
    {
        _handlersMock = new()
        {
            { IncentiveType.FixedCashAmount, new FixedCashAmountIncentiveHandler() },
            { IncentiveType.FixedRateRebate, new FixedRateRebateIncentiveHandler() },
            { IncentiveType.AmountPerUom, new AmountPerUomIncentiveHandler() }
        };
    }

    [Fact]
    public void Create_FixedCashAmount_Should_Return_FixedCashAmountIncentiveHandler()
    {
        IIncentiveHandlerFactory factory = new IncentiveHandlerFactory(_handlersMock);
        factory.Create(IncentiveType.FixedCashAmount).Should().BeOfType<FixedCashAmountIncentiveHandler>();
    }

    [Fact]
    public void Create_FixedRateRebate_Should_Return_FixedRateRebateIncentiveHandler()
    {
        IIncentiveHandlerFactory factory = new IncentiveHandlerFactory(_handlersMock);
        factory.Create(IncentiveType.FixedRateRebate).Should().BeOfType<FixedRateRebateIncentiveHandler>();
    }

    [Fact]
    public void Create_AmountPerUom_Should_Return_AmountPerUomIncentiveHandler()
    {
        IIncentiveHandlerFactory factory = new IncentiveHandlerFactory(_handlersMock);
        factory.Create(IncentiveType.AmountPerUom).Should().BeOfType<AmountPerUomIncentiveHandler>();
    }
}
