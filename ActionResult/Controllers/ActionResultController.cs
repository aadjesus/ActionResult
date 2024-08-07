using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ActionResult.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActionResultController : ControllerBase
    {
        public readonly Cliente _cliente;

        public ActionResultController()
        {
            _cliente = new Cliente("Alessandro", "Augusto");
        }

        [HttpGet(nameof(AcceptedActionResult))]
        public AcceptedResult AcceptedActionResult()
        {
            return Accepted(new Uri("/Home/Index", UriKind.Relative), _cliente);
        }

        [HttpGet(nameof(AcceptedAtActionActionResult))]
        public AcceptedAtActionResult AcceptedAtActionActionResult()
        {
            return AcceptedAtAction("IndexWithId", "Home", new { Id = 2, area = "" }, _cliente);
        }

        [HttpGet(nameof(AcceptedAtRouteActionResult))]
        public AcceptedAtRouteResult AcceptedAtRouteActionResult()
        {
            return AcceptedAtRoute("default", new { Id = 2, area = "" }, _cliente);
        }

        [HttpGet(nameof(BadRequestActionResult))]
        public BadRequestResult BadRequestActionResult()
        {
            return BadRequest();
        }

        [HttpGet(nameof(BadRequestObjectActionResult))]
        public BadRequestObjectResult BadRequestObjectActionResult()
        {
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("Nome", "Nome obrigatorio.");
            return BadRequest(modelState);
        }

        [HttpGet(nameof(CreatedActionResult))]
        public CreatedResult CreatedActionResult()
        {
            return Created(new Uri("/Home/Index", UriKind.Relative), _cliente);
        }

        [HttpGet(nameof(CreatedAtActionActionResult))]
        public CreatedAtActionResult CreatedAtActionActionResult()
        {
            return CreatedAtAction("IndexWithId", "Home", new { id = 2, area = "" }, _cliente);
        }

        [HttpGet(nameof(CreatedAtRouteActionResult))]
        public CreatedAtRouteResult CreatedAtRouteActionResult()
        {
            return CreatedAtRoute("default", new { Id = 2, area = "" }, _cliente);
        }

        [HttpGet(nameof(NotFoundActionResult))]
        public NotFoundResult NotFoundActionResult()
        {
            return NotFound();
        }

        [HttpGet(nameof(NotFoundObjectActionResult))]
        public NotFoundObjectResult NotFoundObjectActionResult()
        {
            return NotFound(new { Id = 1, error = "ID 1 não encontrado" });
        }

        [HttpGet(nameof(OkEmptyWithoutObject))]
        public OkResult OkEmptyWithoutObject()
        {
            return Ok();
        }

        [HttpGet(nameof(OkObjectResult))]
        public OkObjectResult OkObjectResult()
        {
            return new OkObjectResult(new { Message = "Ok" });
        }

        [HttpGet(nameof(NoContentActionResult))]
        public NoContentResult NoContentActionResult()
        {
            return NoContent();
        }

        [HttpGet(nameof(StatusCodeActionResult))]
        public StatusCodeResult StatusCodeActionResult()
        {
            return StatusCode(404);
        }
    }

    public struct Cliente(string Nome, string SobreNome) { }
}
