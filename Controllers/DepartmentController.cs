using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC_A_CRUD.Models;


namespace ASP.NET_MVC_A_CRUD.Controllers
{
    public class DepartmentController : Controller
    {
        StudentDBEntities _context = new StudentDBEntities();
        // GET: Department
        public ActionResult Index()
        {
            
            //var listofData = _context.Departments.ToList();
            var listofData = _context.Departments.ToList();
            return View(listofData);
            //return View();
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            //var _context = new StudentDBEntities();
            var listofData = _context.Departments.Where(D=>D.Department_Id==id).FirstOrDefault();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Departments.Where(x => x.Department_Id == id).FirstOrDefault();
            return View(data);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Department collection)
        {
            try
            {
                var _context = new StudentDBEntities();
                _context.Departments.Add(collection);
                _context.SaveChanges();
                ViewBag.Message = "Data Insert Successfully";
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Department collection)
        {
            try
            {
                // TODO: Add update logic here
                var data = _context.Departments.Where(x => x.Department_Id == collection.Department_Id).FirstOrDefault();
                if (data != null)
                {
                    data.Department_Name = collection.Department_Name;
                    //data.StudentName = Model.StudentName;
                    //data.StudentFees = Model.StudentFees;
                    _context.SaveChanges();
                }
                return RedirectToAction("index");

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Department/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                Department data = _context.Departments.Where(x => x.Department_Id == id).FirstOrDefault();
                _context.Departments.Remove(data);
                _context.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
