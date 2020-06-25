using congNghePhanMem.common;
using congNghePhanMem.Models;
using congNghePhanMem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace congNghePhanMem.Areas.Admin.Controllers
{
    public class userController : baseController
    {
        // GET: Admin/user
        public ActionResult Index(string search,int page = 1, int pageSize = 10)
        {
            var dao = new userDao();
            var model = dao.listAllPaging(page,pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //tao user
        public ActionResult Create(register acc)
            {
            if(ModelState.IsValid)
            {
                var dao = new userDao();
                var encrypPass = encryptor.MD5Hash(acc.passWord);
                acc.passWord = encrypPass;
                int id = dao.Insert(acc);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
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
            var user = new userDao().viewDetail(id);
            return View(user);
        }

        [HttpPost]
        //tao user
        public ActionResult Edit(register acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDao();
                if(!string.IsNullOrEmpty(acc.passWord))
                {
                    var encrypPass = encryptor.MD5Hash(acc.passWord);
                    acc.passWord = encrypPass;
                }
                
                var result = dao.update(acc);
                if (result)
                {
                    return RedirectToAction("Index", "User");
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