using FluentValidation;
using SimpleBankingControlPanel.Application.Client.Dto;

namespace SimpleBankingControlPanel.Application.Client.Commands.CreateClient;

public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(60).WithMessage("First name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(60).WithMessage("Last name must not exceed 50 characters.");

        RuleFor(x => x.PersonalId)
            .NotEmpty().WithMessage("Personal ID is required.")
            .Length(11).WithMessage("Personal ID must be 11 characters long.");

        RuleFor(x => x.ProfilePhoto)
            .MaximumLength(1000).WithMessage("Profile photo URL must not exceed 255 characters.");

        RuleFor(x => x.MobileNumber)
            .NotEmpty().WithMessage("Mobile number is required.")
            .Matches(@"^\+(?:[0-9] ?){6,14}[0-9]$").WithMessage("A valid mobile number is required.");

        RuleFor(x => x.Sex)
            .NotEmpty().WithMessage("Sex is required.")
            .IsInEnum().WithMessage("Invalid sex value.");

        RuleFor(x => x.Address)
            .NotNull().WithMessage("Address is required.")
            .SetValidator(new AddressDtoValidator());

        RuleFor(x => x.Accounts)
            .NotNull().WithMessage("Accounts are required.")
            .Must(x => x != null && x.Count != 0).WithMessage("At least one account is required.")
            .ForEach(account => account.SetValidator(new AccountDtoValidator()));
    }
}