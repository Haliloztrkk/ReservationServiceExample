using Microsoft.AspNetCore.Mvc;
using ReservationService.Application.Tables.Commands.CreateTable;
using ReservationService.Application.Tables.Commands.DeleteTable;
using ReservationService.Application.Tables.Commands.UpdateTable;
using ReservationService.Application.Tables.Queries.GetTables;

namespace ReservationService.Api.Controllers;

public class TableController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<TableDto>> Get([FromQuery] GetTablesQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTableCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{number}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int number, UpdateTableCommand command)
    {
        if (number != command.Number)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{number}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int number)
    {
        await Mediator.Send(new DeleteTableCommand(number));

        return NoContent();
    }
}
