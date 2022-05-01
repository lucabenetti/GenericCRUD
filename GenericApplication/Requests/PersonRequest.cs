using FluentValidation;
using GenericApplication.Validators;

namespace GenericApplication.Requests
{
    public class PersonRequest : BaseRequest
    {
        private readonly PersonRequestValidator _validator;

        public PersonRequest()
        {
            _validator = new PersonRequestValidator();
        }

        public string Name { get; set; }
        public DateTime Birth { get; set; }

        public async override Task<IEnumerable<string>> GetErrors()
        {
            var result = await _validator.ValidateAsync(this);
            return result.Errors.Select(x => x.ErrorMessage);
        }

        public async override Task<bool> IsValid()
        {
            var result = await _validator.ValidateAsync(this);
            return result.IsValid;
        }
    }
}
