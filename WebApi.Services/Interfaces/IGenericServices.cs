

namespace WebApi.Services.Interfaces
{
    public interface IGenericServices<T> where T : class
    {
        Task<List<T>?> GetAll();
        Task Add(params T[] elements);
        Task Update(params T[] elements);
        Task Remove(params T[] elements);
    }
}
