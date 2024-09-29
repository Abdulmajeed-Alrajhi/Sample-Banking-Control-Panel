using FluentValidation;

namespace SimpleBankingControlPanel.Application.Client.Dto;

public class AccountDtoValidator : AbstractValidator<AccountDto>
{
    public AccountDtoValidator()
    {
        RuleFor(x => x.AccountNumber)
            .NotEmpty().WithMessage("Account number is required.")
            .MaximumLength(20).WithMessage("Account number must not exceed 20 characters.");

        RuleFor(x => x.Balance)
            .GreaterThanOrEqualTo(0).WithMessage("Balance must be greater than or equal to 0.");
    }
}