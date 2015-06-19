using Longgan.Logics.Home;
using Longgan.Models.Home;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Longgan.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string success)
        {
            @ViewBag.Success = success;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Message msg)
        {
            MessageLogic logic = new MessageLogic();
            if (ModelState.IsValid)
            {
                logic.AddMessage(msg);
                return RedirectToAction("Contact", new { success = "留言成功" });
            }

            return View(msg);
        }

        public ActionResult Message()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Advantage()
        {
            ViewBag.Message = "Your Advantage page.";

            return View();
        }

        public ActionResult News()
        {
            NewsLogic nLogic = new NewsLogic();
            List<New> news = nLogic.GetNews();
            return View(news);
        }

        public ActionResult Case(int? page)
        {
            CaseLogic logic = new CaseLogic();
            int pageIndex = page ?? 1;
            int pageSize = 20;
            int totalCount = 0;
            @ViewBag.pageindex = pageIndex;
            List<SetCase> cases = logic.GetCasesPaging(pageIndex, pageSize, ref totalCount);
            var casesAsIPagedList = new StaticPagedList<SetCase>(cases, pageIndex, pageSize, totalCount);
            return View(casesAsIPagedList);
        }
        public ActionResult CaseDetail(string Id)
        {
            CaseLogic logic = new CaseLogic();
            SetCase scase = logic.GetCase(Id);
            return View(scase);
        }

        public ActionResult ProductsList()
        {
            ProductsLogic pl = new ProductsLogic();
            List<Product> prs = pl.GetProducts();
            return View(prs);
        }

        public ActionResult ProductsDetail(string Id)
        {
            ProductsLogic pl = new ProductsLogic();
            Product p = pl.GetProduct(Id);
            return View(p);
        }

        public ActionResult AfterSale()
        {
            return View();
        }

        public ActionResult Show()
        {
            return View();
        }
    }
}