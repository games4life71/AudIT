using FluentValidation;

namespace AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Create;

public class CreateStandDocumentValidation: AbstractValidator<CreateStandDocumentCommand>
{
    public CreateStandDocumentValidation()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(100)
            .WithMessage("{PropertyName} must not exceed 100 characters");

        // RuleFor(p => p.Extension)
        //     .NotNull()
        //     .NotEmpty()
        //     .WithMessage("{PropertyName} is required")
        //     .MaximumLength(10)
        //     .WithMessage("{PropertyName} must not exceed 10 characters");

        RuleFor(p => p.OwnerId)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(p => p.DepartmentId)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
}