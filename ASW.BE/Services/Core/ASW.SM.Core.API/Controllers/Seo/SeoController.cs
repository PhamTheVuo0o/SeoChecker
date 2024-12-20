using ASW.SM.Core.API.Application.Commands;
using ASW.SM.Core.API.Application.Responses;
using ASW.SM.Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASW.SM.Core.API.Controllers.Seo
{
    [ApiController]
    [Route("api/[action]")]
    public class SeoController : Controller
    {
        private IMediator _mediator;
        private readonly IOptions<AppSetting> _config;
        public SeoController(IMediator mediator, IOptions<AppSetting> config)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<GetSeoPositionResponse>> GetSeoPosition(GetSeoPositionCommand command)
        {
            var result = await _mediator.Send(command);
            return result != null ? result.IsSuccess ? Ok(result) : BadRequest(result) : Unauthorized();
        }
    }
}
