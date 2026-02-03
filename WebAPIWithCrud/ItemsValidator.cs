using FluentValidation;
using WebAPIWithCrud.Models; // this matches your namespace

public class ItemsValidator : AbstractValidator<Items>
{
    public ItemsValidator()
    {
        // Rule: Name cannot be empty
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required!")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

     
    }
}