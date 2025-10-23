using _10_FluentValidation.ViewModels;
using FluentValidation;


namespace _10_FluentValidation.Validators
{
    public class homePageViewModelValidator: AbstractValidator<homePageViewModel>
    {
        public homePageViewModelValidator()
        {
            RuleFor(vm => vm.KisiNesnesi).NotNull().WithMessage("Kişi bilgileri null olamaz");
            RuleFor(vm => vm.AdresNesnesi).NotNull().WithMessage("Adres bilgileri null olamaz");

            RuleFor(vm => vm.KisiNesnesi.Ad)
                .NotEmpty()
                .WithMessage("Ad alanı boş olamaz")
            .NotNull()
            .WithMessage("Ad Alanı boş bırakılamaz")
            .Length(3, 60).WithMessage("Ad alanı 3 ile 60 karakter arasında olmalıdır");

            RuleFor(vm => vm.KisiNesnesi.Soyad)
                .NotEmpty()
                .WithMessage("Soyad alanı boş olamaz")
                .NotNull().WithMessage("Soyad alanı boş bırakılamaz")
                .Length(3, 50).WithMessage("Soyad alanı 3 ile 50 karakter arasında olmalıdır");
            RuleFor(vm => vm.KisiNesnesi.Yas)
                .GreaterThan(0).WithMessage("Yaş alanı 0'dan büyük olmalıdır")
                .LessThan(150).WithMessage("Yaş alanı 150'den küçük olmalıdır");

            RuleFor(vm => vm.AdresNesnesi.AdresTanim)
                .NotNull().WithMessage("Adres tanımı boş bırakılamaz")
                .NotEmpty().WithMessage("Adres tanımı boş olamaz")
                .Length(10, 200).WithMessage("Adres tanımı 10 ile 200 karakter arasında olmalıdır");

            RuleFor(vm => vm.AdresNesnesi.Sehir)
                .NotNull().WithMessage("Şehir alanı boş bırakılamaz")
                .NotEmpty().WithMessage("Şehir alanı boş olamaz")
                .Length(2, 50).WithMessage("Şehir alanı 2 ile 50 karakter arasında olmalıdır");
        }
    }
}
