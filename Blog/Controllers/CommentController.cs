using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class CommentController : Controller
    {
        // GET: /Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Comment/Create
        [HttpPost]
        public ActionResult Create(int? id, Comment comment)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                // Get the article from database
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .FirstOrDefault();

                // Check if artileId is null
                if (article == null)
                {
                    return HttpNotFound();
                }

                // Get User Id
                var userId = database.Users
                    .Where(u => u.UserName == this.User.Identity.Name)
                    .First()
                    .Id;

                comment.Article = article;
                comment.ArticleId = article.Id;
                comment.AuthorId = userId;

                article.Comments.Add(comment);
                database.SaveChanges();
                
                return RedirectToAction("Details", "Article", new { id = id });
            }

        }
    }
}