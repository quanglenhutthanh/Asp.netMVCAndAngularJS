using core.Entities;
using core.Infra;
using sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllProducts()
        {
            var data = unitOfWork.ProductRepository.Get().Select(i => new ProductResult { 
                ID = i.ID,
                Name = i.Name,
                UnitPrice = i.UnitPrice,
                CategoryID = i.CategoryID
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
	}
}