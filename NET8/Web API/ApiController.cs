namespace Templates.Web.Controllers
{
    /// <summary>
    /// A base class for an WebApi controller which derives from <see cref="ControllerBase"/> with all the common attribute applied.
    /// </summary>
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(ValidationProblemDetails))]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ProblemDetails))]
    public class ApiController : ControllerBase
    {
    }
}