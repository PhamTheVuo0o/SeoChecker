using ASW.SM.Core.API.Application.Responses;
using MediatR;

namespace ASW.SM.Core.API.Application.Commands
{
    public class GetSeoPositionCommand : IRequest<GetSeoPositionResponse>
    {
        public string Keyword { get; set; }
        public string Url { get; set; }
        public string? Provider { get; set; }
        public bool? IsGetCurrentData { get; set; }
    }
}
