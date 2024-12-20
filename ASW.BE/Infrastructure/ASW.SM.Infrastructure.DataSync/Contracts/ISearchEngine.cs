namespace ASW.SM.Infrastructure.DataSync.Contracts
{
    public interface ISearchEngine
    {
        Task<List<int>> SearchAsync(string keyword, string url);
    }
}
