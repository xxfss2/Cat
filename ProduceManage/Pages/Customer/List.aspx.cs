using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jiuzh.CoreBase.Infrastructure;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.Service;
using Cat.Produce.Core.DomainObjects;
using Xxf .Core ;

namespace ProduceManage.Pages.Customer
{
    public partial class List : PageBase
    {
        IClientInfoRepository _clientRep = IoC.Resolve<IClientInfoRepository>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["hDelete"] != null)
            {
                int[] ids=Request .Form ["hDelete"].Split (';').Select (s=>Convert .ToInt32 (s)).ToArray ();
                IClientInfoService clientSer = IoC.Resolve<IClientInfoService>();
                try
                {
                    clientSer.Del(ids);
                    Common.xxfalert.DelSucceed(this);
                }
                catch(Exception ee)
                {
                    Common .xxfalert .Show (this ,ee.Message) ;
                }
            }
        }

        private ICollection<IClientInfo> GetTableData()
        {
            return _clientRep.GetByUser(_user.User.Id);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null)
                return;
            Repeater repater = e.Item.FindControl("Rcontacts") as Repeater;
            IClientInfo produce = (IClientInfo)e.Item.DataItem;
            repater.DataSource = produce.Contacts ;
            repater.DataBind();
        }

        protected void Repeater1_AsynBind(object sender, EventArgs e)
        {
            Repeater1.DataSource = GetTableData();
            Repeater1.DataBind(PageBreak1.Break_Param.DataCount);
        }
    }
}
