using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DoinikSokal.BLL.Contracts;
using DoinikSokal.Models.Models;
using DoinikSokal.Repository.Contracts;
using DoinikSokal.ViewModels;
using Microsoft.AspNet.Identity;

namespace DoinikSokal.Controllers
{
    [Authorize(Roles = "Admin,Editor,Employee")]
    public class PostController : Controller
    {
        private ICategoryManager categoryManager;
        private IPostManager postManager;

        public PostController(ICategoryManager category, IPostManager post)
        {
            this.categoryManager = category;
            this.postManager = post;
        }
        // GET: Post
        public ActionResult Index()
        {
            var userId = Convert.ToInt32(User.Identity.GetUserId());
            var post = postManager.GetAll().OrderByDescending(c=>c.Id);
            var allPost = post.Where(c => c.UserId == userId);
            return View(allPost);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var category = categoryManager.GetAll();
            PostViewModel postViewModel = new PostViewModel();

            var catList = categoryDropDownViewModels(category);
            ViewBag.CategoryId = new SelectList(catList, "Id", "Details");
            //postViewModel.Categories = catList.ToList();
            return View(postViewModel);
        }

        private static List<CategoryDropDownViewModel> categoryDropDownViewModels(ICollection<Category> categories)
        {
            List<CategoryDropDownViewModel> categoryDropDownViewModelsList = new List<CategoryDropDownViewModel>();
            foreach (var item in categories)
            {
                var ite = item.SubCat;
                if (ite == null)
                {
                    CategoryDropDownViewModel categoryDropDownViews = new CategoryDropDownViewModel()
                    {
                        Id = item.Id,
                        Details = item.Name
                    };
                    categoryDropDownViewModelsList.Add(categoryDropDownViews);
                }

                if (ite != null)
                {
                    var iteName = ite.Name;
                    CategoryDropDownViewModel categoryDropDownView = new CategoryDropDownViewModel()
                    {
                        Id = item.Id,
                        Details = item.Name + "->" + iteName
                    };
                    categoryDropDownViewModelsList.Add(categoryDropDownView);
                }

            }
            return categoryDropDownViewModelsList;
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PostViewModel postViewModel)
        {
            var userId = User.Identity.GetUserId();
            var userName = User.Identity.GetUserName();

            string fileName = Path.GetFileNameWithoutExtension(postViewModel.Image.FileName);
            string extension = Path.GetExtension(postViewModel.Image.FileName);
            var fileNames = fileName + DateTime.Now.ToString("yy-mm-dd") + extension;
            string path = fileName + DateTime.Now.ToString("yy-mm-dd") + extension;
            fileName = Path.Combine(Server.MapPath("~/PostImages/"), fileNames);
            postViewModel.Image.SaveAs(fileName);

            Post post = new Post()
            {
                Title = postViewModel.Title,
                ImagePath = path,
                Description = postViewModel.Description,
                Tags = postViewModel.Tags,
                CategoryId = postViewModel.CategoryId,
                Status = "New",
                UserId = Convert.ToInt32(userId),
                UserName = userName,
                PostDate = DateTime.Now
            };
            bool isSaved = postManager.Add(post);
            if (isSaved)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postDetails = postManager.GetById((int)id);
            if (postDetails == null)
            {
                return HttpNotFound();
            }

            DetailsPostViewModel detailsPostViewModel = Mapper.Map<DetailsPostViewModel>(postDetails);

            return View(detailsPostViewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AllPost()
        {
            var result = postManager.GetAll().OrderByDescending(c=>c.Id);
            return View(result);
        }
        

        [HttpGet]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var singlePost = postManager.GetById((int)id);
            PostViewModel postViewModel = new PostViewModel();
            postViewModel.Id = singlePost.Id;
            postViewModel.Title = singlePost.Title;
            postViewModel.Description = singlePost.Description;
            //postViewModel.CategoryId = (int)singlePost.CategoryId;
            postViewModel.ImagePath = singlePost.ImagePath;
            postViewModel.Tags = singlePost.Tags;
            postViewModel.PostDate = singlePost.PostDate;
            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name", singlePost.CategoryId);

            return View(postViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPost(PostViewModel postViewModel)
        {
            Post posts = new Post();
            var userId = User.Identity.GetUserId();
            var userName = User.Identity.GetUserName();

            if (postViewModel.Image != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(postViewModel.Image.FileName);
                string extension = Path.GetExtension(postViewModel.Image.FileName);
                var fileNames = fileName + DateTime.Now.ToString("yy-mm-dd") + extension;
                string path = fileName + DateTime.Now.ToString("yy-mm-dd") + extension;
                fileName = Path.Combine(Server.MapPath("~/PostImages/"), fileNames);
                postViewModel.Image.SaveAs(fileName);

                posts.Id = postViewModel.Id;
                posts.Title = postViewModel.Title;
                posts.Description = postViewModel.Description;
                posts.Tags = postViewModel.Tags;
                posts.CategoryId = postViewModel.CategoryId;
                posts.ImagePath = path;
                posts.UserId = Convert.ToInt32(userId);
                posts.UserName = userName;
                posts.Status = "Updated";
                posts.PostDate = DateTime.Now;
                bool isUpdate = postManager.Update(posts);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                posts.Id = postViewModel.Id;
                posts.Title = postViewModel.Title;
                posts.Description = postViewModel.Description;
                posts.Tags = postViewModel.Tags;
                posts.CategoryId = postViewModel.CategoryId;
                posts.ImagePath = postViewModel.ImagePath;
                posts.UserId = Convert.ToInt32(userId);
                posts.UserName = userName;
                posts.Status = "Updated";
                posts.PostDate = DateTime.Now;
                bool isUpdate = postManager.Update(posts);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var deletePost = postManager.GetById((int)id);
            if (deletePost == null)
            {
                return HttpNotFound();
            }
            bool isDelete = postManager.Remove(deletePost);
            if (isDelete)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        
    }
}