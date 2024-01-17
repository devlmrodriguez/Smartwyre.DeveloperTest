using FluentAssertions;
using Moq;
using Smartwyre.DeveloperTest.Application.Handlers;
using Smartwyre.DeveloperTest.Application.Interfaces;
using Smartwyre.DeveloperTest.Application.Services;
using Smartwyre.DeveloperTest.Domain.Models;
using Smartwyre.DeveloperTest.Domain.Specifications;
using Smartwyre.DeveloperTest.Infrastructure.Interfaces;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class RebateServiceTests
{
    [Fact]
    public void Calculate_FixedCashAmountIncentiveHandler_Success_Should_BeFalse_When_Rebate_Amount_Is_0()
    {
        Mock<IProductDataStore> productDataStoreMock = new Mock<IProductDataStore>();
        productDataStoreMock.Setup(x => x.GetProduct(It.IsAny<string>()))
            .Returns(new Product()
            {
                SupportedIncentives = SupportedIncentiveType.FixedCashAmount,
                Price = 10m
            });

        Mock<IRebateDataStore> rebateDataStoreMock = new Mock<IRebateDataStore>();
        rebateDataStoreMock.Setup(x => x.GetRebate(It.IsAny<string>()))
            .Returns(new Rebate()
            {
                Incentive = IncentiveType.FixedCashAmount,
                Amount = 0m
            });

        Mock<IDataStoreContext> dataStoreContextMock = new Mock<IDataStoreContext>();
        dataStoreContextMock.Setup(x => x.ProductDataStore)
            .Returns(productDataStoreMock.Object);
        dataStoreContextMock.Setup(x => x.RebateDataStore)
            .Returns(rebateDataStoreMock.Object);

        Mock<IIncentiveHandlerFactory> incentiveHandlerFactoryMock = new Mock<IIncentiveHandlerFactory>();
        incentiveHandlerFactoryMock.Setup(x => x.Create(It.IsAny<IncentiveType>()))
            .Returns(new FixedCashAmountIncentiveHandler());

        IRebateService rebateService = new RebateService(dataStoreContextMock.Object, incentiveHandlerFactoryMock.Object);

        CalculateRebateRequest request = new CalculateRebateRequest()
        {
            Volume = 10m
        };

        rebateService.Calculate(request).Success.Should().BeFalse();
    }

    [Fact]
    public void Calculate_FixedCashAmountIncentiveHandler_Success_Should_BeTrue_And_Amount_Shoud_Be_10()
    {
        Mock<IProductDataStore> productDataStoreMock = new Mock<IProductDataStore>();
        productDataStoreMock.Setup(x => x.GetProduct(It.IsAny<string>()))
            .Returns(new Product()
            {
                SupportedIncentives = SupportedIncentiveType.FixedCashAmount,
                Price = 10m
            });

        Mock<IRebateDataStore> rebateDataStoreMock = new Mock<IRebateDataStore>();
        rebateDataStoreMock.Setup(x => x.GetRebate(It.IsAny<string>()))
            .Returns(new Rebate()
            {
                Incentive = IncentiveType.FixedCashAmount,
                Amount = 10m
            });

        Mock<IDataStoreContext> dataStoreContextMock = new Mock<IDataStoreContext>();
        dataStoreContextMock.Setup(x => x.ProductDataStore)
            .Returns(productDataStoreMock.Object);
        dataStoreContextMock.Setup(x => x.RebateDataStore)
            .Returns(rebateDataStoreMock.Object);

        Mock<IIncentiveHandlerFactory> incentiveHandlerFactoryMock = new Mock<IIncentiveHandlerFactory>();
        incentiveHandlerFactoryMock.Setup(x => x.Create(It.IsAny<IncentiveType>()))
            .Returns(new FixedCashAmountIncentiveHandler());

        IRebateService rebateService = new RebateService(dataStoreContextMock.Object, incentiveHandlerFactoryMock.Object);

        CalculateRebateRequest request = new CalculateRebateRequest()
        {
            Volume = 10m
        };

        rebateService.Calculate(request).Success.Should().BeTrue();
        rebateService.Calculate(request).Amount.Should().Be(10m);
    }
}
