using FluentValidation;

namespace AudIT.Applicationa.Requests.Document.TemplateDocument.Commands.Create;

public class CreateTemplateDocValidator : AbstractValidator<CreateTemplateDocCommand>
{
    public CreateTemplateDocValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(p => p.Extension).NotEmpty().WithMessage("Extension is required");

        RuleFor(p => p.Version).GreaterThan(0).WithMessage("Version has to be bigger than 0");
    }
}