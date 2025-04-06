namespace REG.Core.Abstractions.Services.Exceptions;

public class ServiceException : Exception
{
    public const string GeneralAggregateError = "GeneralAggregateError";
    public const string EntityNotFoundException = "EntityNotFoundException";
    public const string RequiredValidation = "RequiredValidation";
    public const string EncounterNotPossible = "EncounterNotPossible";

    public object[] Args { get; }

    public ServiceException(string message, params object[] args) : base(message)
    {
        Args = args;
    }

    public ServiceException(string message, Exception innerException, params object[] args) : base(message,
        innerException)
    {
        Args = args;
    }
}