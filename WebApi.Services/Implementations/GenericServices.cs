using WebApi.Data.Interfaces;

namespace WebApi.Services.Implementations
{
    public abstract class GenericServices<T, R>
         where T : class
         where R : IGenericRepository<T>
    {
        protected R _repository;

        public async Task<List<T>?> GetAll()
        {
            return await _repository.GetAll() as List<T>;
        }

        public async Task Add(params T[] elements)
        {
            if (elements.All(IsValid))
            {
                await _repository.Add(elements);
            }
        }

        public async Task Update(params T[] elements)
        {
            if (elements.All(IsValid))
            {
                await _repository.Update(elements);
            } 
        }

        public async Task Remove(params T[] elements)
        {
            await _repository.Remove(elements);
        }


        public virtual bool IsValid(T element)
        {
            return element != null;
        }
    }
}
