using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoinikSokal.BLL;
using DoinikSokal.ViewModels;

namespace DoinikSokal.Controllers
{
    public class PostDetailsController : Controller
    {
        private CategoryManager categoryManager;
        private PostManager postManager;

        public PostDetailsController(CategoryManager category, PostManager post)
        {
            this.categoryManager = category;
            this.postManager = post;
        }
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postDetails = postManager.GetById((int)id);
            PostViewModel postViewModel = new PostViewModel()
            {
                Id = postDetails.Id,
                Title = postDetails.Title,
                Description = postDetails.Description,
                ImagePath = postDetails.ImagePath
            };
            ViewBag.Title = postDetails.Title;
            ViewBag.Tags = postDetails.Tags;

            return View(postViewModel);
        }
        
    }
}