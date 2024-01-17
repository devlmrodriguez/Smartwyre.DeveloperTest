using Smartwyre.DeveloperTest.Application.Interfaces;
using Smartwyre.DeveloperTest.Domain.Models;

namespace Smartwyre.DeveloperTest.Application.Handlers;

public class IncentiveHandlerFactory : IIncentiveHandlerFactory
{
    private readonly Dictionary<IncentiveType, IIncentiveHandler> _handlers;

    public IncentiveHandlerFactory(Dictionary<IncentiveType, IIncentiveHandler> handlers)
    {
        _handlers = handlers;
    }

    public IIncentiveHandler Create(IncentiveType incentiveType)
    {
        return _handlers[incentiveType];
    }
}
