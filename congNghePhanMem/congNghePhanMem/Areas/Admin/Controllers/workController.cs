using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using congNghePhanMem.Models;
using congNghePhanMem.Models.Dao;
using PagedList;

namespace congNghePhanMem.Areas.Admin.Controllers
{
    public class workController : baseController
    {
        // GET: Admin/work
        public ActionResult Index(string search, int page = 1, int pageSize = 10)
        {
            var dao = new workDao();
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
        public ActionResult Create(work acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new workDao();
                int id = dao.Insert(acc);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Work");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công");
                }
            }
            return View("Index");
        }

        //view update
        public ActionResult Edit(int id)
        {
            var user = new workDao().viewDetail(id);
            return View(user);
        }

        [HttpPost]
        //tao user
        public ActionResult Edit(work acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new workDao();

                var result = dao.update(acc);
                if (result)
                {
                    return RedirectToAction("Index", "Work");
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
            new userDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}