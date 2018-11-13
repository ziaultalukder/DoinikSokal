using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DoinikSokal.BLL.Contracts;
using DoinikSokal.Identity.IdentityConfig;
using DoinikSokal.Models.Models;
using DoinikSokal.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DoinikSokal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        
        // GET: Employee
        private AppUserManager userManager;
        private IEmployeeManager employeeManager;

        public EmployeeController(IEmployeeManager employee)
        {
            this.employeeManager = employee;
        }
        public AppUserManager AppUserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
        public ActionResult Index()
        {
            var employee = employeeManager.GetAll();
            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {

            string userId = User.Identity.GetUserId();
            var userName = User.Identity.Name;

            string fileName = Path.GetFileNameWithoutExtension(employeeViewModel.Image.FileName);
            string extension = Path.GetExtension(employeeViewModel.Image.FileName);
            var fileNames = fileName + DateTime.Now.ToString("yy-mm-dd") + extension;

            string path = fileName + DateTime.Now.ToString("yy-mm-dd") + extension;

            fileName = Path.Combine(Server.MapPath("~/EmployeeImage/"), fileNames);
            employeeViewModel.Image.SaveAs(fileName);


            Employee employee = new Employee();
            employee.Name = employeeViewModel.Name;
            employee.Email = employeeViewModel.Email;
            employee.ContactNo = employeeViewModel.ContactNo;
            employee.Address = employeeViewModel.Address;
            employee.Gender = employeeViewModel.Gender;
            employee.UserId = Convert.ToInt32(userId);
            employee.UserName = userName;
            employee.FilePath =path;

            bool isSaved = employeeManager.Add(employee);
            if (isSaved)
            {
                AppUserManager.AddEmployeeToUser(employee);
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
            var employee = employeeManager.GetById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = employeeManager.GetById((int) id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.Id = employee.Id;
            employeeViewModel.Name = employee.Name;
            employeeViewModel.Email = employee.Email;
            employeeViewModel.ContactNo = employee.ContactNo;
            employeeViewModel.Address = employee.Address;
            employeeViewModel.Gender = employee.Gender;
            employeeViewModel.FilePath = employee.FilePath;
            return View(employeeViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            Employee employee = new Employee();

            if (employeeViewModel.Image != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(employeeViewModel.Image.FileName);
                string extension = Path.GetExtension(employeeViewModel.Image.FileName);
                var fileNames = fileName + DateTime.Now.ToString("yy-mm-dd") + extension;

                string path = fileName + DateTime.Now.ToString("yy-mm-dd") + extension;

                fileName = Path.Combine(Server.MapPath("~/EmployeeImage/"), fileNames);
                employeeViewModel.Image.SaveAs(fileName);
                
                employee.Id = employeeViewModel.Id;
                employee.Name = employeeViewModel.Name;
                employee.Email = employeeViewModel.Email;
                employee.ContactNo = employeeViewModel.ContactNo;
                employee.Address = employeeViewModel.Address;
                employee.Gender = employeeViewModel.Gender;
                employee.FilePath = path;

                bool isUpdate = employeeManager.Update(employee);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                employee.Id = employeeViewModel.Id;
                employee.Name = employeeViewModel.Name;
                employee.Email = employeeViewModel.Email;
                employee.ContactNo = employeeViewModel.ContactNo;
                employee.Address = employeeViewModel.Address;
                employee.Gender = employeeViewModel.Gender;
                employee.FilePath = employeeViewModel.FilePath;

                bool isUpdate = employeeManager.Update(employee);
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
            var employee = employeeManager.GetById((int) id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            bool isDeleted = employeeManager.Remove(employee);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}