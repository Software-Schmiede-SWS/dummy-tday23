using System.Diagnostics.CodeAnalysis;

namespace DummyApp.UiTests.Utils;

[TestClass]
[SuppressMessage("Roslynator", "RCS1102:Make class static.")]
public class TestEnvironmentInitialization
{
    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext testContext) => TestEnvironment.StartApp();

    [AssemblyCleanup]
    public static void AssemblyCleanup() => TestEnvironment.StopApp();
}
