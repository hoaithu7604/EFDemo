using DatabaseFirst.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseFirst;

namespace MVC.Controllers
{
    public class DatabaseFirstController : Controller
    {
        private readonly IShoesRepository _shoesRepository;
        private readonly IShoesStyleRepository _shoesStyleRepository;
        private readonly IBrandRepository _brandRepository;
        public DatabaseFirstController(IShoesRepository shoesRepository,IShoesStyleRepository shoesStyleRepository,IBrandRepository brandRepository)
        {
            this._shoesRepository = shoesRepository;
            this._shoesStyleRepository = shoesStyleRepository;
            this._brandRepository = brandRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var result = this._shoesRepository.Get();
            ViewBag.Styles = this._shoesStyleRepository.Get();
            ViewBag.Brand = this._brandRepository.Get();
            return View(result);
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var Id = collection["Id"]==null?Guid.Empty:Guid.Parse(collection["id"]);
            if (Id == Guid.Empty)
            {
                var Name = collection["Name"];
                var Styles = collection["Styles"]==null?new List<ShoesStyle>():collection["Styles"].Split(',').Select(x => new ShoesStyle() { Id = Guid.Parse(x) }).ToList();
                var Brand = new Brand() { Id = Guid.Parse(collection["Brand"]) };
                var Shoes = new Shoes()
                {
                    Name = Name,
                    ShoesStyles = Styles,
                    Brand = Brand,
                    CreateBy = "Me"
                };
                this._shoesRepository.InsertOrUpdate(Shoes);
            }
            else
            {
                var Name = collection["Name"];
                var Styles = collection["Styles"] == null ? new List<ShoesStyle>() : collection["Styles"].Split(',').Select(x => new ShoesStyle() { Id = Guid.Parse(x) }).ToList();
                var Brand = new Brand() { Id = Guid.Parse(collection["Brand"]) };
                var Shoes = new Shoes()
                {
                    Id = Id,
                    Name = Name,
                    ShoesStyles = Styles,
                    Brand = Brand,
                    ModifiedBy = "Me"
                };
                this._shoesRepository.InsertOrUpdate(Shoes);
            };
            return Redirect("/DatabaseFirst");
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            if (Id != null)
            {
                this._shoesRepository.Delete(Guid.Parse(Id));
            }
            return Redirect("/DatabaseFirst");
        }
    }
}