using congNghePhanMem.Areas.Admin.Controllers;
using congNghePhanMem.common;
using congNghePhanMem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace congNghePhanMem.Controllers
{
    public class loginEmployeeController : Controller
    {
        // GET: loginEmployee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(loginEmlpoyeeModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDao();
                var result = dao.Login(model.userName, encryptor.MD5Hash(model.passWord));
                if (result == 1)
                {
                    var user = dao.getById(model.userName);
                    var userSession = new userLogin();
                    userSession.userName = user.userName;
                    userSession.userID = user.Id;
                    Session.Add(commonConst.user_session, userSession);
                    return RedirectToAction("About", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại !");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa !");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng !");
                }
            }
            return View("Index");
        }
    }
}