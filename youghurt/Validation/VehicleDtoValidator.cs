/*using FluentValidation;
using youghurt.DTOs;

public class VehicleDtoValidator : AbstractValidator<VehicleCreateDto>
{
    public VehicleDtoValidator()
    {
        RuleFor(v => v.Make)
            .NotEmpty().WithMessage("Make is required")
            .MaximumLength(50).WithMessage("Make can't exceed 50 characters");

        RuleFor(v => v.Model)
            .NotEmpty().WithMessage("Model is required")
            .MaximumLength(50).WithMessage("Model can't exceed 50 characters");

        RuleFor(v => v.Year)
            .InclusiveBetween(1886, 2050).WithMessage("Year must be between 1886 and 2050");
    }
}*/