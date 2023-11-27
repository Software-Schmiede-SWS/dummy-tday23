namespace DummyApp.Services;

public class DummyService(ILogger<DummyService> logger) : IDummyService
{
    private readonly ILogger _logger = logger;

    public bool DoSomething(bool fail)
    {
        _logger.LogInformation("Doing something...");
        if (fail) throw new NotImplementedException("zum test");
        return true;
    }
}
