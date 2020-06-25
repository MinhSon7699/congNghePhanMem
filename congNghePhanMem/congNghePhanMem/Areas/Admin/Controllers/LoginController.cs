using congNghePhanMem.Areas.Admin.Data;
using congNghePhanMem.common;
using congNghePhanMem.Controllers;
using congNghePhanMem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace congNghePhanMem.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        //
        public ActionResult Login(loginModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new userDao();
                var result = dao.Login(model.userName, encryptor.MD5Hash(model.passWord));
                if (result == 1)
                {
                    var user = dao.getById(model.userName);
                    var userSession = new userLogin();
                    userSession.userName = user.userName;
                    userSession.userID = user.Id;
                    Session.Add(commonConst.user_session,userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if(result == 0)
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