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
            var data = unitOfWork.ProductRepository.Get().Select(i => new ProductResult
            {
                ID = i.ID,
                Name = i.Name,
                UnitPrice = i.UnitPrice,
                CategoryID = i.CategoryID
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public string AddProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    unitOfWork.ProductRepository.Insert(product);
                    unitOfWork.Save();
                    return "Success";
                }
                else
                {
                    return "null";
                }
            }
            catch (Exception ex)
            {
                return "error: " + ex.ToString();
            }
        }

        public string UpdateProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    unitOfWork.ProductRepository.Update(product);
                    unitOfWork.Save();
                    return "Success";
                }
                else
                {
                    return "null";
                }
            }
            catch (Exception ex)
            {
                return "error: " + ex.ToString();
            }
        }

        public string DeleteProduct(int id)
        {
            try
            {
                unitOfWork.ProductRepository.Delete(id);
                unitOfWork.Save();
                return "Success";
            }
            catch (Exception ex)
            {
                return "error: " + ex.ToString();
            }
        }
    }
}