using LuxiCart.BL.IRepositories;
using LuxiCart.EF.Data;
using LuxiCart.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuxiCart.UI.ViewComponents
{
    public class CountryViewComponent : ViewComponent
    {
        

        public IBaseRepository<Country> _CountrybaseRepository;
        public CountryViewComponent(IBaseRepository<Country> CountrybaseRepository)
        {
            _CountrybaseRepository = CountrybaseRepository;
        }

        public IViewComponentResult Invoke()
        {
            var countries = _CountrybaseRepository.GetAll().OrderBy((x => x.CountryName));
            return View(countries);
        }
    }
}
