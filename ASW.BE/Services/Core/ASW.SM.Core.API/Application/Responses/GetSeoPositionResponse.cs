using ASW.SM.Core.Domain.Models;
using ASW.SM.Infrastructure.Models;

namespace ASW.SM.Core.API.Application.Responses
{
    public class GetSeoPositionResponse : BaseResponse<List<SeoPostionModel>>
    {
        public GetSeoPositionResponse() : base(new List<SeoPostionModel>())
        {
        }
    }
}
