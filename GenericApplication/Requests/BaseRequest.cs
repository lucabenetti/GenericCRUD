using FluentValidation;
using FluentValidation.Results;

namespace GenericApplication.Requests
{
    public abstract class BaseRequest
    {   
        public abstract Task<bool> IsValid();

        public abstract Task<IEnumerable<string>> GetErrors();
    }
}
