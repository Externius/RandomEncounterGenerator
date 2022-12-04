using System;
using System.Resources;

namespace REG.Core.Abstractions.Services.Exceptions;

public class ServiceException : Exception
{
    public static readonly string EntityNotFoundException = "EntityNotFoundException";
    public static readonly string RequiredValidation = "RequiredValidation";
    public static readonly string EncounterNotPossible = "EncounterNotPossible";

    public object[] Args { get; }

    public ServiceException()
    {
    }

    public ServiceException(string message, params object[] args) : base(message)
    {
        Args = args;
    }

    public ServiceException(string message, Exception innerException, params object[] args) : base(message, innerException)
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

        if (resourceManager == null)
            return serviceException.Message;
        try
        {
            return serviceException.Args != null ? string.Format(resourceManager.GetString(serviceException.Message) ?? string.Empty,
                serviceException.Args) : resourceManager.GetString(serviceException.Message);
        }
        catch (Exception)
        {
            // ignored
        }

        return serviceException.Message;
    }
}