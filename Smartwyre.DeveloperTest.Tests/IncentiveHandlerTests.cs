using FluentAssertions;
using Smartwyre.DeveloperTest.Application.Handlers;
using Smartwyre.DeveloperTest.Application.Interfaces;
using Smartwyre.DeveloperTest.Domain.Models;
using Smartwyre.DeveloperTest.Domain.Specifications;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class IncentiveHandlerTests
{
    [Fact]
    public void CalculateRebate_Success_Should_BeFalse_When_All_Parameters_Are_Null()
    {
        IIncentiveHandler handler1 = new FixedCashAmountIncentiveHandler();
        IIncentiveHandler handler2 = new FixedRateRebateIncentiveHandler();
        IIncentiveHandler handler3 = new AmountPerUomIncentiveHandler();

        CalculateRebateRequest request = null;
        Rebate rebate = null;
        Product product = null;

        handler1.CalculateRebate(request, rebate, product).Success.Should().BeFalse();
        handler2.CalculateRebate(request, rebate, product).Success.Should().BeFalse();
        handler3.CalculateRebate(request, rebate, product).Success.Should().BeFalse();
    }

    [Fact]
    public void CalculateRebate_Success_Should_BeTrue_When_Incentives_Match()
    {
        IIncentiveHandler handler1 = new FixedCashAmountIncentiveHandler();
        IIncentiveHandler handler2 = new FixedRateRebateIncentiveHandler();
        IIncentiveHandler handler3 = new AmountPerUomIncentiveHandler();

        CalculateRebateRequest request = new()
        {
            Volume = 10m
        };
        Rebate rebate = new()
        {
            Amount = 10m,
            Percentage = 10m
        };
        Product product = new()
        {
            Price = 10m
        };

        rebate.Incentive = IncentiveType.FixedCashAmount;
        product.SupportedIncentives = SupportedIncentiveType.FixedCashAmount;
        handler1.CalculateRebate(request, rebate, product).Success.Should().BeTrue();

        rebate.Incentive = IncentiveType.FixedRateRebate;
        product.SupportedIncentives = SupportedIncentiveType.FixedRateRebate;
        handler2.CalculateRebate(request, rebate, product).Success.Should().BeTrue();

        rebate.Incentive = IncentiveType.AmountPerUom;
        product.SupportedIncentives = SupportedIncentiveType.AmountPerUom;
        handler3.CalculateRebate(request, rebate, product).Success.Should().BeTrue();
    }

    [Fact]
    public void CalculateRebate_Success_Should_BeFalse_When_Incentives_Not_Match()
    {
        IIncentiveHandler handler1 = new FixedCashAmountIncentiveHandler();
        IIncentiveHandler handler2 = new FixedRateRebateIncentiveHandler();
        IIncentiveHandler handler3 = new AmountPerUomIncentiveHandler();

        CalculateRebateRequest request = new()
        {
        };
        Rebate rebate = new()
        {
            Amount = 10m
        };
        Product product = new()
        {
        };
        
        rebate.Incentive = IncentiveType.AmountPerUom;
        product.SupportedIncentives = SupportedIncentiveType.AmountPerUom;
        handler1.CalculateRebate(request, rebate, product).Success.Should().BeFalse();

        rebate.Incentive = IncentiveType.FixedCashAmount;
        product.SupportedIncentives = SupportedIncentiveType.FixedCashAmount;
        handler2.CalculateRebate(request, rebate, product).Success.Should().BeFalse();

        rebate.Incentive = IncentiveType.FixedRateRebate;
        product.SupportedIncentives = SupportedIncentiveType.FixedRateRebate;
        handler3.CalculateRebate(request, rebate, product).Success.Should().BeFalse();
    }

    [Fact]
    public void CalculateRebate_FixedCashAmountIncentiveHandler_Success_Should_BeFalse_When_Rebate_Amount_Is_0()
    {
        IIncentiveHandler handler = new FixedCashAmountIncentiveHandler();

        CalculateRebateRequest request = new()
        {
        };
        Rebate rebate = new()
        {
            Incentive = IncentiveType.FixedCashAmount,
            Amount = 0m
        };
        Product product = new()
        {
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount
        };

        handler.CalculateRebate(request, rebate, product).Success.Should().BeFalse();
    }

    [Fact]
    public void CalculateRebate_FixedCashAmountIncentiveHandler_Success_Should_BeTrue_When_Rebate_Amount_Is_10()
    {
        IIncentiveHandler handler = new FixedCashAmountIncentiveHandler();

        CalculateRebateRequest request = new()
        {
        };
        Rebate rebate = new()
        {
            Incentive = IncentiveType.FixedCashAmount,
            Amount = 10m
        };
        Product product = new()
        {
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount
        };

        handler.CalculateRebate(request, rebate, product).Success.Should().BeTrue();
    }

    [Fact]
    public void CalculateRebate_FixedCashAmountIncentiveHandler_Amount_Should_Be_10_When_Rebate_Amount_Is_10()
    {
        IIncentiveHandler handler = new FixedCashAmountIncentiveHandler();

        CalculateRebateRequest request = new()
        {
        };
        Rebate rebate = new()
        {
            Incentive = IncentiveType.FixedCashAmount,
            Amount = 10m
        };
        Product product = new()
        {
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount
        };

        handler.CalculateRebate(request, rebate, product).Amount.Should().Be(10m);
    }

    [Fact]
    public void CalculateRebate_FixedRateRebateIncentiveHandler_Success_Should_BeFalse_When_Percentage_Price_Volume_Are_0()
    {
        IIncentiveHandler handler = new FixedRateRebateIncentiveHandler();

        CalculateRebateRequest request = new()
        {
            Volume = 0m
        };
        Rebate rebate = new()
        {
            Incentive = IncentiveType.FixedRateRebate,
            Amount = 0m,
            Percentage = 0m
        };
        Product product = new()
        {
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
            Price = 0m
        };

        handler.CalculateRebate(request, rebate, product).Success.Should().BeFalse();
    }

    [Fact]
    public void CalculateRebate_FixedRateRebateIncentiveHandler_Success_Should_BeTrue_When_Percentage_Price_Volume_Are_Not_0()
    {
        IIncentiveHandler handler = new FixedRateRebateIncentiveHandler();

        CalculateRebateRequest request = new()
        {
            Volume = 10m
        };
        Rebate rebate = new()
        {
            Incentive = IncentiveType.FixedRateRebate,
            Amount = 10m,
            Percentage = 10m
        };
        Product product = new()
        {
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
            Price = 10m
        };

        handler.CalculateRebate(request, rebate, product).Success.Should().BeTrue();
    }


    [Fact]
    public void CalculateRebate_FixedRateRebateIncentiveHandler_Amount_Should_Be_1000_When_Percentage_Price_Volume_Are_10()
    {
        IIncentiveHandler handler = new FixedRateRebateIncentiveHandler();

        CalculateRebateRequest request = new()
        {
            Volume = 10m
        };
        Rebate rebate = new()
        {
            Incentive = IncentiveType.FixedRateRebate,
            Amount = 10m,
            Percentage = 10m
        };
        Product product = new()
        {
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
            Price = 10m
        };

        handler.CalculateRebate(request, rebate, product).Amount.Should().Be(1000m);
    }

    [Fact]
    public void CalculateRebate_AmountPerUomIncentiveHandler_Success_Should_BeFalse_When_Rebate_Amount_Volume_Are_0()
    {
        IIncentiveHandler handler = new AmountPerUomIncentiveHandler();

        CalculateRebateRequest request = new()
        {
            Volume = 0m
        };
        Rebate rebate = new()
        {
            Incentive = IncentiveType.AmountPerUom,
            Amount = 0m,
        };
        Product product = new()
        {
            SupportedIncentives = SupportedIncentiveType.AmountPerUom,
        };

        handler.CalculateRebate(request, rebate, product).Success.Should().BeFalse();
    }

    [Fact]
    public void CalculateRebate_AmountPerUomIncentiveHandler_Success_Should_BeTrue_When_Rebate_Amount_Volume_Are_10()
    {
        IIncentiveHandler handler = new AmountPerUomIncentiveHandler();

        CalculateRebateRequest request = new()
        {
            Volume = 10m
        };
        Rebate rebate = new()
        {
            Incentive = IncentiveType.AmountPerUom,
            Amount = 10m,
        };
        Product product = new()
        {
            SupportedIncentives = SupportedIncentiveType.AmountPerUom,
        };

        handler.CalculateRebate(request, rebate, product).Success.Should().BeTrue();
    }

    [Fact]
    public void CalculateRebate_AmountPerUomIncentiveHandler_Amount_Should_Be_100_When_Rebate_Amount_Volume_Are_10()
    {
        IIncentiveHandler handler = new AmountPerUomIncentiveHandler();

        CalculateRebateRequest request = new()
        {
            Volume = 10m
        };
        Rebate rebate = new()
        {
            Incentive = IncentiveType.AmountPerUom,
            Amount = 10m,
        };
        Product product = new()
        {
            SupportedIncentives = SupportedIncentiveType.AmountPerUom,
        };

        handler.CalculateRebate(request, rebate, product).Amount.Should().Be(100m);
    }
}
