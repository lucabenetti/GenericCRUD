using AutoMapper;
using GenericApplication.Requests;
using GenericApplication.Responses;
using GenericApplication.Services.Interface;
using GenericCore.Notifier;
using GenericCore.Pagination;
using GenericDomain.Entities;
using GenericDomain.Repository;

namespace GenericApplication.Services
{
    public class GenericService : IGenericService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;
        private readonly INotifier _notifier;

        public GenericService(IGenericRepository genericRepository, IMapper mapper, INotifier notifier)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _notifier = notifier;
        }

        public async Task<PaginatedResult<K>> GetPaginated<T, K>(PaginatedInput input)
            where T : BaseEntity
            where K : BaseResponse
        {
            var result = await _genericRepository.GetPaginated<T>(input);

            return new PaginatedResult<K>
            {
                Itens = _mapper.Map<IEnumerable<K>>(result.Itens),
                PaginatedInfo = result.PaginatedInfo
            };
        }

        public async Task<K> GetById<T, K>(Guid id)
            where T : BaseEntity
            where K : BaseResponse
        {
            return _mapper.Map<T, K>(await _genericRepository.GetById<T>(id));
        }

        public async Task<Guid?> Add<T, K>(K request)
            where T : BaseEntity
            where K : BaseRequest
        {
            if (!await request.IsValid())
            {
                _notifier.AddNotifications(await request.GetErrors());
                return null;
            }

            var entity = _mapper.Map<T>(request);

            await _genericRepository.Add(entity);
            await _genericRepository.CommitAsync();

            return entity.Id;
        }

        public async Task Delete<T>(Guid id) where T : BaseEntity
        {
            var entity = await _genericRepository.GetById<T>(id);

            if (entity is null)
            {
                _notifier.AddNotification("Entity not found");
                return;
            }

            _genericRepository.Delete(entity);
            await _genericRepository.CommitAsync();
        }
    }
}
