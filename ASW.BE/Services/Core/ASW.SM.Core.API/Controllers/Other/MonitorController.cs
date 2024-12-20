using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ASW.SM.Infrastructure.Common;
using Microsoft.Extensions.Options;

namespace ASW.SM.Core.API.Controllers.Other
{
    [ApiController]
    [Route("api/[action]")]
    public class MonitorController : Controller
    {
        private IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;
        private readonly IOptions<AppSetting> _config;
        public MonitorController(IMediator mediator, IOptions<AppSetting> config, IServiceProvider serviceProvider)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _config = config;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok(new
            {
                ServiceName = "CoreService",
            });
        }
    }
}
