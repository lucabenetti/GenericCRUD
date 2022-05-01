using GenericCore.Pagination;
using GenericDomain.Entities;

namespace GenericDomain.Repository
{
    public interface IGenericRepository
    {
        Task<T> GetById<T>(Guid id) where T : BaseEntity;
        Task<PaginatedResult<T>> GetPaginated<T>(PaginatedInput input) where T : BaseEntity;
        Task Add<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        public Task CommitAsync();
    }
}
