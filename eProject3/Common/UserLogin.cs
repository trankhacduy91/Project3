using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProject3
{
    [Serializable]
    public class UserLogin
    {
        public int UserId { set; get; }
        public string UserName { set; get; }
    }
}