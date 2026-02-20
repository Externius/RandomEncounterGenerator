using REG.Core.Abstractions.Services;

namespace REG.Core.Tests;

public class TestFixture : IDisposable
{
    private readonly TestEnvironment _env = new();
    private bool _disposedValue;
    public readonly IEncounterService EncounterService;

    public TestFixture()
    {
        EncounterService = _env.GetService<IEncounterService>();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue)
            return;
        if (disposing)
        {
            _env.Dispose();
        }

        _disposedValue = true;
    }

    ~TestFixture()
    {
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}