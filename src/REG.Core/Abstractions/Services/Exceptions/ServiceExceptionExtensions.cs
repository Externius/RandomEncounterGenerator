using System;
using System.Resources;

namespace REG.Core.Abstractions.Services.Exceptions;
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