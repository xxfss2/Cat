using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Xxf.Core
{
    public class UserCore
    {
        public class CurrUser : IUserCore
        {
            public int Id
            {
                get { return Convert.ToInt32(HttpContext.Current.Session[SUSERID]); }
            }
            public string LoginName
            {
                get { return HttpContext.Current.Session[SLOGINNAME].ToString(); }
            }
            public string PassWord
            {
                get { return HttpContext.Current.Session[SPASWORD].ToString(); }
            }
            public string Name
            {
                get { return HttpContext.Current.Session[SUSERNAME].ToString(); }
            }
        }

        private const string SLOGINNAME = "loginName";
        private const string SPASWORD = "password";
        private const string SUSERID = "userid";
        private const string SUSERNAME = "username";

        public CurrUser User
        {
            get
            {
                CurrUser _curruser = new CurrUser();
                return _curruser;
            }
        }

        public bool IsLogin()
        {
            return HttpContext.Current.Session[SUSERID] != null ? true : false;
        }

        public void Login(IUserCore loginuser)
        {
            IUserCore user = loginuser;
            HttpContext.Current.Session[SLOGINNAME] = user.LoginName;
            HttpContext.Current.Session[SPASWORD] = user .PassWord ;
            HttpContext.Current.Session[SUSERID] = user.Id;
            HttpContext.Current.Session[SUSERNAME] = user.Name ;
        }

        public bool CheckLogin()
        {
            if (HttpContext.Current.Session[SLOGINNAME] == null || HttpContext.Current.Session[SUSERID] == null || HttpContext.Current.Session[SUSERNAME] == null)
                return false;
            return true;
        }
    }
}
