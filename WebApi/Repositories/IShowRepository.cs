using Models;

namespace WebApi.Repositories
{
    public interface IShowRepository
    {
        Task<Show?> GetById(string id);
        Task<IEnumerable<Show>> GetAll(int pageNumber = 1);
    }
}