using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace REG.Core.Abstractions.Services.Exeptions
{
    public class ServiceAggregateException : ServiceException
    {
        private readonly IEnumerable<ServiceException> _innerExceptions;

        public ReadOnlyCollection<ServiceException> InnerExceptions => new ReadOnlyCollection<ServiceException>(_innerExceptions.ToList());

        public ServiceAggregateException(IEnumerable<ServiceException> innerExceptions) : base()
        {
            _innerExceptions = innerExceptions;
        }

        public ServiceAggregateException(params ServiceException[] innerExceptions) : base()
        {
            _innerExceptions = innerExceptions;
        }
    }
}
