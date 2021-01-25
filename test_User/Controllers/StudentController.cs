using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using test_User.IRepository;
using test_User.Models;
using test_User.Repository;

namespace test_User.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _repository;
        public StudentController(IStudentRepository repository)
        {
                      
            _repository = repository;
        }
        // GET: StudentController
        public ActionResult Index()
        {
           
            List<Student> students = _repository.GetAll();
           
            return View(students);
        }



        [HttpPost]
        public ActionResult Index(String SearchName)
        {
            if (!string.IsNullOrEmpty(SearchName))
            {
                List<Student> students = _repository.SeachByName(SearchName);

                //return RedirectToAction("Index", students);
                return View(students);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Student model)
        {
            if (!ModelState.IsValid)
            {
                @TempData["UserCreateFailed"] = "There are some mistake try again";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                _repository.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                @TempData["UserCreateFailed"] = "There are some mistake try again";
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            
            try
            {
                Student student = _repository.GetById(id);
                return View(student);
            }
            catch
            {
                
                return RedirectToAction(nameof(Index));
            }
            
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection,Student model)
        {
            if (!ModelState.IsValid)
            {
                @TempData["UserUpdateFailed"] = "There are some mistake try again";
                return RedirectToAction(nameof(Edit));
            }

            try
            {
                _repository.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                @TempData["UserUpdateFailed"] = "There are some mistake try again";
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _repository.DeleteById(id);
                return View();
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
            
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
