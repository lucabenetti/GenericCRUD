using FluentValidation;
using GenericApplication.Requests;

namespace GenericApplication.Validators
{
    public class PersonRequestValidator : AbstractValidator<PersonRequest>
    {
        public PersonRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Birth).NotEmpty();
        }
    }
}
