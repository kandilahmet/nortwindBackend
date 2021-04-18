using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün İsmi Boş Olamaz");
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("Ürün İsmi 2 Karakterden Fazla Olmalı");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Brim Fiyat Boş Olamaz");
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Brim Fiyat 0 dan Büyük Olmalı");
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.ProductId == 1).WithMessage("Ürün No 1 ise Brim Fiyat 0 dan Büyük Olmalı");
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün Adı A Harfi ile Başlamalı");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
