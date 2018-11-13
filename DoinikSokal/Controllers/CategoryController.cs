using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DoinikSokal.BLL.Contracts;
using DoinikSokal.Models.Models;
using DoinikSokal.Repository.Contracts;
using DoinikSokal.ViewModels;

namespace DoinikSokal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private ICategoryManager categoryManager;
        public CategoryController(ICategoryManager category)
        {
            this.categoryManager = category;
        }
        // GET: Category
        public ActionResult Index()
        {
            var category = categoryManager.GetAll();
            return View(category);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Category category = new Category();
            var categories = categoryManager.GetAll();
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            var categoryList = categoryDropDownViewModels(categories);
            ViewBag.SubCatId = new SelectList(categoryList, "Id", "Details", category.SubCatId);
            return View(categoryViewModel);
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
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            Category category = Mapper.Map<Category>(categoryViewModel);
            bool isSaved = categoryManager.Add(category);
            if (isSaved)
            {
                TempData["msg"] = "Category Save Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = categoryManager.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.SubCatId = new SelectList(categoryManager.GetAll(), "Id", "Name", category.SubCatId);
            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);

            return View(categoryViewModel);
        }

        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            Category category = Mapper.Map<Category>(categoryViewModel);
            bool isUpdate = categoryManager.Update(category);
            if (isUpdate)
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
            var category = categoryManager.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }

            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);
            return View(categoryViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = categoryManager.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }

            bool isDeleted = categoryManager.Remove(category);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}