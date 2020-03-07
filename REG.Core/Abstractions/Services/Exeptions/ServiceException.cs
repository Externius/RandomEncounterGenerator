using System;
using System.Resources;

namespace REG.Core.Abstractions.Services.Exeptions
{
    public class ServiceException : Exception
    {
        public static readonly string EntityNotFoundException = "EntityNotFoundException";
        public static readonly string RequiredValidation = "RequiredValidation";
        public static readonly string EncounterNotPossible = "EncounterNotPossible";

        public string[] Args { get; }

        public ServiceException() : base()
        {
        }

        public ServiceException(string message, params string[] args) : base(message)
        {
            Args = args;
        }

        public ServiceException(string message, Exception innerException, params string[] args) : base(message, innerException)
        {
            Args = args;
        }

    }
    public static class ServiceExceptionExtensions
    {
        public static string LocalizedMessage(this ServiceException serviceException, ResourceManager resourceManager)
        {
            if (string.IsNullOrEmpty(serviceException?.Message))
                return null;

            if (resourceManager != null)
            {
                try
                {
                    if (serviceException.Args != null)
                        return string.Format(resourceManager.GetString(serviceException.Message), serviceException.Args);

                    return resourceManager.GetString(serviceException.Message);
                }
                catch (Exception)
                {
                }
            }
            return serviceException.Message;
        }
    }
}
