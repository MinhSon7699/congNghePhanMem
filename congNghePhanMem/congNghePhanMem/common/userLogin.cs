using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace congNghePhanMem.common
{
    [Serializable]
    public class userLogin
    {
        public int userID { get; set; }
        public string userName { get; set; }
    }
}