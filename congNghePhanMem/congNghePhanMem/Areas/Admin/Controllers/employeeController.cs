using congNghePhanMem.Models;
using congNghePhanMem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace congNghePhanMem.Areas.Admin.Controllers
{
    public class employeeController : baseController
    {
        // GET: Admin/employee
        public ActionResult Index(string search, int page = 1, int pageSize = 10)
        {
            var dao = new employeeDao();
            var model = dao.listAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //tao user
        public ActionResult Create(information acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new employeeDao();
                int id = dao.Insert(acc);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm nhân viên thành công");
                }
            }
            return View("Index");
        }

        //view update
        public ActionResult Edit(int id)
        {
            var employee = new employeeDao().viewDetail(id);
            return View(employee);
        }

        [HttpPost]
        //tao user
        public ActionResult Edit(information acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new employeeDao();
                var result = dao.update(acc);
                if (result)
                {
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập thành công");
                }
            }
            return View("Index");
        }

        //Xoa ban ghi
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new employeeDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}