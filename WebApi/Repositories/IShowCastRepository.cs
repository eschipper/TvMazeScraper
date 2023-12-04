using Models;

namespace WebApi.Repositories
{
    public interface IShowCastRepository
    {
        Task<ShowCast?> GetById(string id);
    }
}