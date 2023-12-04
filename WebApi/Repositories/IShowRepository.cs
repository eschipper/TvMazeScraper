using Models;

namespace WebApi.Repositories
{
    public interface IShowRepository
    {
        Task<Show?> GetById(string id);
    }
}