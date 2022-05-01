using GenericCore.Notifier;
using Microsoft.AspNetCore.Mvc;

namespace GenericApi.Controllers
{
    [ApiController]
    public abstract class BaseController : Controller
    {
        private readonly INotifier _notifier;
        
        public BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }
        
        protected ActionResult CustomResponse(object result = null)
        {
            if (!HasNotification())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetErrors()
            });
        }

        private bool HasNotification()
        {
            return _notifier.HasNotification();
        }
    }
}
