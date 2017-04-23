using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tibox.Models;

namespace Tibox.WebApi.Validators
{
    public class ProductValidator: AbstractValidator<Product>
    {

        public ProductValidator()
        {

            //Ni bien no se cumple uno, salga
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(p => p.ProductName).NotNull().NotEmpty().WithMessage("El nombre del producto es requerido");
            RuleFor(p => p.SupplierId).GreaterThan(0).WithName("Proveedor").WithMessage("No ha seleccionado un proveedor válido");

            When(p => p.UnitPrice > 0, () =>
            {
                RuleFor(p => p.UnitPrice).LessThan(100000).WithName("Precio unitario").WithMessage("Costo muy elevado");
            });

            When(p => !string.IsNullOrWhiteSpace(p.Package), () =>
            {
                RuleFor(p => p.Package).Length(1, 30).WithMessage("El nombre del paquete excedio el límite permitido");
            });

        }

    }
}