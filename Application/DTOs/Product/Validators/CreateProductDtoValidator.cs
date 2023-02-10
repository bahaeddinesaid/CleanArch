using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductDtoValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(p => p.Description)
                           .NotEmpty().WithMessage("{PropertyName} is required.")
                           .NotNull()
                           .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
