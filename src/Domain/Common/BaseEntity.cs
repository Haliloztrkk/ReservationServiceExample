using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationService.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
}
