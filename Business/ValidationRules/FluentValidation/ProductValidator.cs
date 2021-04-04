using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //Burada Fluent Validationu yani doğrulama kurallarını nasıl yapacağımızı kodlayacaz
    //AbstractValidator FluentValidation dan geliyor
    public class ProductValidator : AbstractValidator<Product>
    {
        //Bu doğrulama kuralları Constructors içine yazılır
        public ProductValidator()
        {
            //Rulefor --> Kim için kural
            RuleFor(p => p.ProductName).NotEmpty();
            //NotEmpty --> Boş geçilemez
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            //GreaterThan --> UnitPrice 0'dan büyük olmalı
            //Örneğin içecek kategorisinin ürünlerinin fiyatı min 10 tl olmalı kuralı aşağıdaki gibi olmalıdır
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId ==1);
            //GreaterThanOrEqualTo --> eşit ve büyük anlamına gelir
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır.");
            //Yukarıdaki işlemde Must --> Denktir anlamında StarWith ise Başlamalıdır yani productName A ile başlamalıdır
            //StartWith bizim yazdığımız bir metodtur

            //Yukarıdaki hatalara kendi özel mesajlarımız verilmek istenirse WithMessage kullanılabilir
        }

        //Aşağıdaki arg bizim ProductName e karşılık gelmektedir
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
