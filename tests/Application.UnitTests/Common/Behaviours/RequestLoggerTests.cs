using ReservationService.Application.Common.Behaviours;
using ReservationService.Application.Common.Interfaces;
using ReservationService.Application.Tables.Commands.CreateTable;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ReservationService.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateTableCommand>> _logger = null!;
    private Mock<ICurrentUserService> _currentUserService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateTableCommand>>();
        _currentUserService = new Mock<ICurrentUserService>();
    }

    [Test]
    public async Task ShouldCallUserNameOnceIfUserIdHasValue()
    {
        _currentUserService.Setup(x => x.UserId).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateTableCommand>(_logger.Object, _currentUserService.Object);

        await requestLogger.Process(new CreateTableCommand { Capacity = 1 }, new CancellationToken());

        _currentUserService.Verify(i => i.UserName, Times.Once);
    }

    [Test]
    public async Task ShouldNotCallUserNameOnceIfUserIdHasNotValue()
    {
        var requestLogger = new LoggingBehaviour<CreateTableCommand>(_logger.Object, _currentUserService.Object);

        await requestLogger.Process(new CreateTableCommand { Capacity = 1 }, new CancellationToken());

        _currentUserService.Verify(i => i.UserName, Times.Never);
    }
}
