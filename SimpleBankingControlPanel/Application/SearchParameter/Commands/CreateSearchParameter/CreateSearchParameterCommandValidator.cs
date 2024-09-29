using FluentValidation;

namespace SimpleBankingControlPanel.Application.SearchParameter.Commands.CreateSearchParameter;

public class CreateSearchParameterCommandValidator : AbstractValidator<CreateSearchParameterCommand>
{
    public CreateSearchParameterCommandValidator()
    {
        RuleFor(x => x.Parameter)
            .NotEmpty().WithMessage("Parameter is required.")
            .MaximumLength(250).WithMessage("Parameter must not exceed 50 characters.");
    }
}