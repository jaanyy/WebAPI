using FilmsProject.BusinessLogicLayer.DTOs;
using FilmsProject.BusinessLogicLayer.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsProject.API.Validators
{
    public class CountryDTOValidator: AbstractValidator<CountryDTO>
    {
        public CountryDTOValidator(ICountryService countryService)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Country Name should not be empty!")
                .MaximumLength(50)
                .WithMessage("Country Name should not be logner than 50 symbols!")
                .Must(countryService.CountryNameIsUnique)
                .WithMessage("This country already exists!");
        }
    }
}
