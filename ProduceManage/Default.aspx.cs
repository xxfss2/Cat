using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.DomainObjects;
using Cat.Produce.EF;
using Jiuzh.CoreBase.Infrastructure;
using Xxf.Core;
using Common;
namespace ProduceManage
{
    public partial class _Default : System.Web.UI.Page
    {
        IUserRepository _userRep = IoC.Resolve<IUserRepository>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && Request .Form ["username"]!=null )
            {
                string loginname = Request.Form["username"];
                string password = Request.Form["password"];
                ICollection <IUser> users=_userRep.GetUser(loginname, password);
                if (users.Count == 1)
                {
                    UserCore usercore = new UserCore();
                    usercore.Login(users.First());
                    Response.Redirect("index.html");
                }
                else
                {
                    xxfalert.Show(this, "用户名或密码错误,请重新输入！");
                }
            }
        }
    }
}
