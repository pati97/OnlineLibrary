using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineLibrary.DAL;
using OnlineLibrary.Models;
using System.Security.Claims;

namespace OnlineLibrary.Controllers
{
    public class BooksController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();

        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.User);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            { 
                string userIdValue = String.Empty; 
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    // the principal identity is a claims identity.
                    // now we need to find the NameIdentifier claim
                    var userIdClaim = claimsIdentity.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                    if (userIdClaim != null)
                    {
                        userIdValue = userIdClaim.Value;
                    }
                }

                string FileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Files"), FileName);
                file.SaveAs(path);
                db.Books.Add(new Book
                {
                    Author = book.Author, CategoryID = book.CategoryID, Description = book.Description, Title = book.Title,
                    YearOfPublication = book.YearOfPublication, FilePath = "~/Files/" + FileName, ID = book.ID, UserId = userIdValue,
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public JsonResult IsUserExists(string Title)
        {
            //check if any of the Title matches the Title specified in the Parameter using the ANY extension method.  
            return Json(!db.Books.Any(b => b.Title == Title), JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsCategoryExists(int CategoryID)
        {
            //check if any of the Title matches the Title specified in the Parameter using the ANY extension method.  
            return Json(db.Categories.Any(c => c.ID == CategoryID), JsonRequestBehavior.AllowGet);
        }

        // GET: Books/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", book.UserId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,Title,Author,Description,YearOfPublication,CategoryID,FilePath")] Book book)
        {
            if (ModelState.IsValid)
            {
                string userIdValue = String.Empty;
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    // the principal identity is a claims identity.
                    // now we need to find the NameIdentifier claim
                    var userIdClaim = claimsIdentity.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                    if (userIdClaim != null)
                    {
                        userIdValue = userIdClaim.Value;
                    }
                }
                book.UserId = userIdValue;
                
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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

        public FileResult Download(string id)
        {
            
            int fid = Convert.ToInt32(id);
            var books = db.Books.Include(b => b.User);
            string filename = (from b in books
                               where b.ID == fid
                               select b.FilePath).First();
            string contentType = "application/pdf";
            return File(filename, contentType, filename + ".pdf");
        }

    }
}
