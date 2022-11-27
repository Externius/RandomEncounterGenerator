using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace REG.Core.Abstractions.Services.Exceptions;

public class ServiceAggregateException : ServiceException
{
    private readonly IEnumerable<ServiceException> _innerExceptions;

    public ReadOnlyCollection<ServiceException> InnerExceptions => new(_innerExceptions.ToList());

    public ServiceAggregateException(IEnumerable<ServiceException> innerExceptions)
    {
        _innerExceptions = innerExceptions;
    }

    public ServiceAggregateException(params ServiceException[] innerExceptions)
    {
        _innerExceptions = innerExceptions;
    }
}