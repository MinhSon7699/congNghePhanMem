using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace congNghePhanMem.Areas.Admin.Data
{
    public class loginModel
    {
        [Required(ErrorMessage ="Mời nhập tài khoản")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string passWord { get; set; }
        public bool rememberMe { get; set; }
    }
}