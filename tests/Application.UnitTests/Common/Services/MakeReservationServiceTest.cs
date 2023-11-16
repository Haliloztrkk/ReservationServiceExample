using FluentAssertions;
using Moq;
using NUnit.Framework;
using ReservationService.Application.Common.Exceptions;
using ReservationService.Application.Common.Interfaces;
using ReservationService.Application.Common.Services;
using ReservationService.Application.Reservation.Commands.MakeReservation;
using ReservationService.Domain.Entities;
using ReservationService.Infrastructure.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ReservationService.Application.UnitTests.Common.Services;
public class InMemoryDbContextFactory
{
    public ApplicationDbContext GetDbContext()
    {
        var dbContext = new ApplicationDbContext();

        return dbContext;
    }
}

public class MakeReservationServiceTest
{
    private Mock<IEmailSender> _emailSender;
    private readonly IMakeReservationService _makeReservationService;

    [SetUp]
    public void Setup()
    {
        _emailSender = new Mock<IEmailSender>();
    }

    [Test]
    public async Task MakeReservationService_MakeReservation_ReturnTableNotFoundResult()
    {
        // Arrange
        var context = new ApplicationDbContext();
        context.Tables.AddRange(new List<Table>
        {
            new Table { Id = 1, Number = 1, Capacity = 3 }
        });

        context.Reservations.AddRange(new List<Domain.Entities.Reservation>());
        await context.SaveChangesAsync(new CancellationToken());


        _emailSender.Setup(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        var makeReservationService = new MakeReservationService(context, _emailSender.Object);

        // Act
        var makeReservationResponse = await makeReservationService.MakeReservationAsync(new MakeReservationCommand
        {
            CustomerName = "Customer 1",
            NumberOfGuests = 5,
            ReservationDate = DateTime.Now
        }, new CancellationToken());

        // Assert
        makeReservationResponse.Succeeded.Should().BeFalse();
        makeReservationResponse.Errors.Should().BeEquivalentTo(new[] { "Available table not found." });
    }

    [Test]
    public async Task MakeReservationService_MakeReservation_ReturnSuccessResult()
    {
        // Arrange
        var context = new ApplicationDbContext();
        context.Tables.AddRange(new List<Table>
        {
            new Table { Id = 1, Number = 1, Capacity = 3 }
        });

        context.Reservations.AddRange(new List<Domain.Entities.Reservation>());
        await context.SaveChangesAsync(new CancellationToken());


        _emailSender.Setup(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        var makeReservationService = new MakeReservationService(context, _emailSender.Object);

        // Act
        var makeReservationResponse = await makeReservationService.MakeReservationAsync(new MakeReservationCommand
        {
            CustomerName = "Customer 1",
            NumberOfGuests = 2,
            ReservationDate = DateTime.Now
        }, new CancellationToken());

        // Assert
        makeReservationResponse.Succeeded.Should().BeTrue();
        makeReservationResponse.Data.Should().BeGreaterThan(0);
        makeReservationResponse.Errors.Should().BeEmpty();
        _emailSender.Verify(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task MakeReservationService_MakeReservation_EMailSender_ThrowsNotImplamentedExeption()
    {
        // Arrange
        var context = new ApplicationDbContext();
        context.Tables.AddRange(new List<Table>
        {
            new Table { Id = 1, Number = 1, Capacity = 3 }
        });

        context.Reservations.AddRange(new List<Domain.Entities.Reservation>());
        await context.SaveChangesAsync(new CancellationToken());


        _emailSender.Setup(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<CancellationToken>())).Throws<NotImplementedException>();

        var makeReservationService = new MakeReservationService(context, _emailSender.Object);

        // Assert
        await FluentActions.Invoking(() => makeReservationService.MakeReservationAsync(new MakeReservationCommand
        {
            CustomerName = "Customer 1",
            NumberOfGuests = 2,
            ReservationDate = DateTime.Now
        }, new CancellationToken())).Should().ThrowAsync<NotImplementedException>();
    }
}
