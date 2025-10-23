using _10_FluentValidation.Models;
using _10_FluentValidation.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _10_FluentValidation.Controllers
{
    public class HomeController : Controller
    {
        //Sadece ctor üzerinden enjekte edilebilir
        private readonly IValidator<homePageViewModel> _validator;
        public HomeController(IValidator<homePageViewModel> validator)
        {
            _validator= validator;//Dependency Injection ile validator nesnesi alýndý
            //Dýþa baðýmlýlýk
        }

        public IActionResult Index()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult Submit(homePageViewModel model)
        {
            ValidationResult result = _validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View("Index", model);
            }
            return RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            return View();
        }


    }
}
