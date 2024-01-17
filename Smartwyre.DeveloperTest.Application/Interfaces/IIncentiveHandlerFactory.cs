using Smartwyre.DeveloperTest.Domain.Models;

namespace Smartwyre.DeveloperTest.Application.Interfaces;

public interface IIncentiveHandlerFactory
{
    IIncentiveHandler Create(IncentiveType incentiveType);
}
