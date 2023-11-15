using Microsoft.EntityFrameworkCore;
using ReservationService.Application.Common.Interfaces;
using ReservationService.Application.Common.Models;
using ReservationService.Application.Reservation.Commands.MakeReservation;

namespace ReservationService.Application.Common.Services;

public class MakeReservationService : IMakeReservationService
{
    private readonly IApplicationDbContext _context;
    private readonly IEmailSender _emailSender;
    public MakeReservationService(IApplicationDbContext context, IEmailSender emailSender)
    {
        _context = context;
        _emailSender = emailSender;
    }

    public async Task<Result<int>> MakeReservationAsync(MakeReservationCommand request, CancellationToken cancellationToken = default)
    {
        var a = await _context.Tables
            .Where(x => x.Capacity >= request.NumberOfGuests).ToListAsync(cancellationToken);
        var table = await _context.Tables
            .Where(x => x.Capacity >= request.NumberOfGuests)
            .GroupJoin(_context.Reservations.Where(x => x.ReservationDate.Date == request.ReservationDate.Date),
                table => table.Number, reservation => reservation.TableNumber,
                (table, reservation) => new { table, reservation })
            .Select(x => x.table).FirstOrDefaultAsync(cancellationToken);

        if (table == null)
        {
            return Result.Failure<int>(new[] { "Available table not found." });
        }

        var entity = new Domain.Entities.Reservation
        {
            CustomerName = request.CustomerName,
            ReservationDate = request.ReservationDate,
            NumberOfGuests = request.NumberOfGuests,
            TableNumber = table.Number
        };

        _context.Reservations.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        var emailBody = $"Sayın {request.CustomerName}, rezervasyonunuz başarıyla alındı. Masa No: {table.Number}, Tarih: {request.ReservationDate}, Kişi Sayısı: {request.NumberOfGuests}";
        await _emailSender.SendEmailAsync($"{request.CustomerName}@domain.com", "noreply@domain.com", "Rezervasyon Onayı", emailBody, cancellationToken);

        return Result.Success(entity.Id);
    }
}
