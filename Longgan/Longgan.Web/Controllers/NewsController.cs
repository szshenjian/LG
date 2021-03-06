﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Longgan.Models.Home;
using Longgan.Web.Models;
using Longgan.Logics.Home;

namespace Longgan.Web.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        NewsLogic logic = new NewsLogic();
        // GET: News
        public ActionResult Index()
        {
            if (Session["Login"] == null || !(bool)Session["Login"])
            {
                return RedirectToAction("Login", "Account");
            }

            return View(logic.GetNews());
        }

        // GET: News/Details/5
        public ActionResult Details(string id)
        {
            if (Session["Login"] == null || !(bool)Session["Login"])
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = logic.GetNew(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            return View(@new);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            if (Session["Login"] == null || !(bool)Session["Login"])
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,Hot,Created")] New @new)
        {
            if (Session["Login"] == null || !(bool)Session["Login"])
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                logic.AddNews(@new);
                return RedirectToAction("Index");
            }

            return View(@new);
        }

        // GET: News/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["Login"] == null || !(bool)Session["Login"])
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = logic.GetNew(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            return View(@new);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,Hot,Created")] New @new)
        {
            if (Session["Login"] == null || !(bool)Session["Login"])
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                logic.UpdateNews(@new);
                return RedirectToAction("Index");
            }
            return View(@new);
        }

        // GET: News/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["Login"] == null || !(bool)Session["Login"])
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = logic.GetNew(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            return View(@new);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (Session["Login"] == null || !(bool)Session["Login"])
            {
                return RedirectToAction("Login", "Account");
            }

            New @new = logic.GetNew(id);
            logic.RemoveNews(@new);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
