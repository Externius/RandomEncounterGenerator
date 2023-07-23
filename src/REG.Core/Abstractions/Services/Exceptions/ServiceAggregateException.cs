using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace REG.Core.Abstractions.Services.Exceptions;

public class ServiceAggregateException : Exception
{
    private readonly IEnumerable<ServiceException> _innerExceptions;

    public ReadOnlyCollection<ServiceException> GetInnerExceptions()
    {
        return new ReadOnlyCollection<ServiceException>(_innerExceptions.ToList());
    }

    public ServiceAggregateException(IEnumerable<ServiceException> innerExceptions)
        : base(ServiceException.GeneralAggregateError)
    {
        _innerExceptions = innerExceptions;
    }

    public ServiceAggregateException(params ServiceException[] innerExceptions)
        : base(ServiceException.GeneralAggregateError)
    {
        _innerExceptions = innerExceptions;
    }
}