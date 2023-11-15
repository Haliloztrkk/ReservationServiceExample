namespace ReservationService.Domain.Entities;

public class Table : BaseEntity
{
    public int Number { get; set; }

    public int Capacity { get; set; }
}