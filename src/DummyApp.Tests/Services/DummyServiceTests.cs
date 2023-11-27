using DummyApp.Services;
using Microsoft.Extensions.Logging;

namespace DummyApp.Tests.Services;

[TestClass]
public class DummyServiceTests
{
    [TestMethod]
    public void DoSomethingShouldLogInfoMessage()
    {
        // Arrange
        Mock<ILogger<DummyService>> loggerMock = new();
        loggerMock.Setup(x =>
            x.Log(LogLevel.Information,
                  It.IsAny<EventId>(),
                  It.IsAny<It.IsAnyType>(),
                  It.IsAny<Exception?>(),
                  It.IsAny<Func<It.IsAnyType, Exception?, string>>()))
            .Verifiable();

        DummyService service = new(loggerMock.Object);

        // Act
        bool result = service.DoSomething(fail: false);

        // Assert
        result.Should().BeTrue();
        loggerMock.Verify(x =>
            x.Log(LogLevel.Information,
                  It.IsAny<EventId>(),
                  It.IsAny<It.IsAnyType>(),
                  It.IsAny<Exception?>(),
                  It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [TestMethod]
    public void DoSomethingShouldThrowNotImplementedException()
    {
        // Arrange
        Mock<ILogger<DummyService>> loggerMock = new();

        DummyService dummyService = new(loggerMock.Object);

        // Act
        Action act = () => dummyService.DoSomething(fail: true);

        // Assert
        act.Should().Throw<NotImplementedException>()
            .Which.Message.Should().Be("zum test");
    }
}
