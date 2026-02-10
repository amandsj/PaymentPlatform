using Microsoft.AspNetCore.Mvc;
using PaymentPlatform.Application.Services;

namespace PaymentPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly PaymentService _service;

    public PaymentsController(PaymentService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(decimal amount, string description)
    {
        var payment = _service.Create(amount, description);
        return Ok(payment);
    }

    [HttpPost("{id}/process")]
    public IActionResult Process(Guid id, bool approved)
    {
        _service.Process(id, approved);
        return Ok("Pagamento processado.");
    }
}
