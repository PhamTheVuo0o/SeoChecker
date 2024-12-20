using AppCore.Infrastructure.RestClient;
using ASW.SM.Core.API.Application.Commands;
using ASW.SM.Core.API.Application.Responses;
using ASW.SM.Infrastructure.DataSync.Contracts;
using AutoMapper;
using MediatR;
using ASW.SM.Infrastructure.Cache.Contracts;
using ASW.SM.Infrastructure.Cache.Common;
using ASW.SM.Core.Domain.Models;

namespace ASW.SM.Core.API.Application.Handlers
{
    public class GetSeoPositionHandler : BaseClient<GetSeoPositionResponse>,
        IRequestHandler<GetSeoPositionCommand, GetSeoPositionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEnumerable<ISearchEngine> _searchEngines;
        private readonly ICacheManager _cacheManager;
        public GetSeoPositionHandler(
            IMapper mapper,
            IEnumerable<ISearchEngine> searchEngines,
            ICacheManager cacheManager,
            IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _mapper = mapper;
            _searchEngines = searchEngines;
            _cacheManager = cacheManager;
        }
        public async Task<GetSeoPositionResponse> Handle(GetSeoPositionCommand request, CancellationToken cancellationToken)
        {

            var response = new GetSeoPositionResponse();

            var results = new List<SeoPostionModel>();

            var cacheKey = $"{request.Keyword}_{request.Url}_{request.Provider}";

            if (_cacheManager.IsSet(cacheKey) && !(request.IsGetCurrentData.HasValue && request.IsGetCurrentData.Value))
            {
                results = _cacheManager.Get< List<SeoPostionModel>> (cacheKey);
            }
            else
            {
                foreach (var engine in _searchEngines)
                {
                    var engineName = engine.GetType().Name;
                    if (!string.IsNullOrEmpty(request.Provider))
                    {
                        if (engineName.ToLower().Contains(request.Provider.ToLower()))
                        {
                            var item = new SeoPostionModel()
                            {
                                Provider = engineName,
                                Positions = await engine.SearchAsync(request.Keyword, request.Url)
                            };
                            results.Add(item);
                            break;
                        }
                    }
                    else
                    {
                        var item = new SeoPostionModel()
                        {
                            Provider = engineName,
                            Positions = await engine.SearchAsync(request.Keyword, request.Url)
                        };
                        results.Add(item);
                    }
                }
                _cacheManager.Set(cacheKey, results, CacheConstant.DEFAULT_CACHE_TIME_IN_MINUTES);
            }
            response.IsSuccess = results != null ? results.Count > 0 : false;
            response.Data = results;

            return response;
        }
    }
}
