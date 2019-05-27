using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineLibrary.DAL;
using OnlineLibrary.Models;

namespace OnlineLibrary.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();

        // GET: Comments
        public ActionResult Index([Bind(Prefix = "ID")]int bookId)
        {
            var book = db.Books.Find(bookId);
            if (book != null)
                return View(book);

            return HttpNotFound();
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }

        // GET: Comments/Create
        public ActionResult Create(int bookId)
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comments comments)
        {
            if (ModelState.IsValid)
            {
                comments.Author = User.Identity.Name;
                db.Comments.Add(comments);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = comments.BookId });
            }

            return View(comments);
        }

        // GET: Comments/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            //ViewBag.BookId = new SelectList(db.Books, "ID", "UserId", comments.BookId);

            return View(comments);

        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BookId,Author, Comment, Rating")] Comments comments)
        {
                if (ModelState.IsValid)
                {
                //var book = db.Comments.Find(comments.ID);
                //comments.BookId = book.BookId;
                db.Entry(comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = comments.BookId });
                }
                
                
            //ViewBag.BookId = new SelectList(db.Books, "ID", "UserId", comments.BookId);
            return View(comments);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            if (comments.Author == User.Identity.Name)
            {
                if (comments != null)
                    return View(comments);
            }
            return RedirectToAction("Index", "Books");
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comments comments = db.Comments.Find(id);
            db.Comments.Remove(comments);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = comments.BookId });
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
