using Microsoft.AspNetCore.Builder;

namespace DummyApp.UiTests.Utils;

internal static class TestEnvironment
{
    public static string Url => Application == null
            ? string.Empty
            : Application.Urls.First();

    private static WebApplication? Application { get; set; }

    public static void StartApp()
    {
        Application = Program.BuildApp([]);
        Application.RunAsync();
    }

    public static void StopApp()
    {
        if (Application == null) { return; }
        Application.StopAsync().Wait();
    }
}
