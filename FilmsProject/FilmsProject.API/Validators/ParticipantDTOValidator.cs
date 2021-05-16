using FilmsProject.BusinessLogicLayer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsProject.API.Validators
{
    public class ParticipantDTOValidator : AbstractValidator<ParticipantDTO>
    {
        public ParticipantDTOValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("First Name should not be empty!")
                .MaximumLength(50)
                .WithMessage("First Name should not be logner than 50 symbols!");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("Last Name should not be empty!")
                .MaximumLength(50)
                .WithMessage("Last Name should not be logner than 50 symbols!");

            RuleFor(c => c.DateOfBirth)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Date of Birth should not be greater than today");

            RuleFor(c => c.Biography)
                .MaximumLength(500);
        }
    }
}
