using GenericApplication.Requests;
using GenericApplication.Responses;
using GenericApplication.Services.Interface;
using GenericCore.Notifier;
using GenericCore.Pagination;
using GenericDomain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GenericApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        private readonly IGenericService _genericService;
        
        public PersonController(INotifier notifier, IGenericService genericService) : base(notifier)
        {
            _genericService = genericService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PersonRequest request)
        {
            var response = await _genericService.Add<Person, PersonRequest>(request);
            return CustomResponse(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] PaginatedInput input)
        {
            var response = await _genericService.GetPaginated<Person, PersonResponse>(input);
            return CustomResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var response = await _genericService.GetById<Person, PersonResponse>(id);
            return CustomResponse(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _genericService.Delete<Person>(id);
            return CustomResponse(true);
        }
    }
}
