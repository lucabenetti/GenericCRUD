using GenericApplication.Requests;
using GenericApplication.Responses;
using GenericCore.Pagination;
using GenericDomain.Entities;

namespace GenericApplication.Services.Interface
{
    public interface IGenericService
    {
        Task<PaginatedResult<K>> GetPaginated<T, K>(PaginatedInput input)
            where T : BaseEntity
            where K : BaseResponse;

        Task<K> GetById<T, K>(Guid id)
                    where T : BaseEntity
                    where K : BaseResponse;

        Task<Guid?> Add<T, K>(K request)
                    where T : BaseEntity
                    where K : BaseRequest;

        Task Delete<T>(Guid id) where T : BaseEntity;
    }
}
