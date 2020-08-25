using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_Kaido14.Controllers
{
    public class ClassificationsController : Controller
    {
        private DrugInfoContext db = new DrugInfoContext();

        // GET: Classifications
        public ActionResult Index()
        {
            return View(db.Classifications.ToList());
        }

        // GET: Classifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classifications classifications = db.Classifications.Find(id);
            if (classifications == null)
            {
                return HttpNotFound();
            }
            return View(classifications);
        }

        // GET: Classifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classifications/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassificationId,ClassificationCode,Name")] Classifications classifications)
        {
            if (ModelState.IsValid)
            {
                db.Classifications.Add(classifications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classifications);
        }

        // GET: Classifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classifications classifications = db.Classifications.Find(id);
            if (classifications == null)
            {
                return HttpNotFound();
            }
            return View(classifications);
        }

        // POST: Classifications/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassificationId,ClassificationCode,Name")] Classifications classifications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classifications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classifications);
        }

        // GET: Classifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classifications classifications = db.Classifications.Find(id);
            if (classifications == null)
            {
                return HttpNotFound();
            }
            return View(classifications);
        }

        // POST: Classifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classifications classifications = db.Classifications.Find(id);
            db.Classifications.Remove(classifications);
            db.SaveChanges();
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
