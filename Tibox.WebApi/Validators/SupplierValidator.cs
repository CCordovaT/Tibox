using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tibox.Models;

namespace Tibox.WebApi.Validators
{
    public class SupplierValidator: AbstractValidator<Supplier>
    {

        public SupplierValidator()
        {            
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.CompanyName).NotNull().NotEmpty().WithName("Compañia").WithMessage("El nombre de la compañia es requerido");
            RuleFor(p => p.CompanyName).Length(1, 80).WithName("Compañia").WithMessage("El nombre de la compañia excedio los 80 caracteres");

            RuleFor(p => p.ContactName).Length(1, 100).WithName("Contacto").WithMessage("El nombre del contacto excedio los 100 caracteres");

            RuleFor(p => p.ContactTitle).Length(1, 80).WithName("Cargo").WithMessage("El cargo del contacto excedio los 80 caracteres");

            RuleFor(p => p.City).Length(1, 80).WithName("Ciudad").WithMessage("El nombre de la ciudad excedio los 80 caracteres");

            RuleFor(p => p.Country).Length(1, 80).WithName("Pais").WithMessage("El nombre del pais excedio los 80 caracteres");

            RuleFor(p => p.Phone).Length(1, 60).WithName("Teléfono").WithMessage("El teléfono excedio los 60 caracteres");

            RuleFor(p => p.Fax).Length(1, 60).WithName("Fax").WithMessage("El fax excedio los 60 caracteres");
        }

    }

}