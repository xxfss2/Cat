using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jiuzh.CoreBase.Infrastructure;
using Cat.Produce.Core.DomainObjects;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.Service;
using Xxf .Core ;

namespace ProduceManage.Pages.Factory
{
    public partial class List : PageBase
    {
        IFactoryRepository _clientRep = IoC.Resolve<IFactoryRepository>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["hDelete"] != null)
            {
                int[] ids = Request.Form["hDelete"].Split(';').Select(s => Convert.ToInt32(s)).ToArray();
                IFactoryService clientSer = IoC.Resolve<IFactoryService>();
                try
                {
                    clientSer.Del(ids);
                    Common.xxfalert.DelSucceed(this);
                }
                catch (Exception ee)
                {
                    Common.xxfalert.Show(this, ee.Message);
                }
            }
        }

        private ICollection<IFactory> GetTableData()   
        {
            return _clientRep.GetAll(); 
        }

        protected void Repeater1_AsynBind(object sender, EventArgs e)
        {
            Repeater1.DataSource = GetTableData();
            Repeater1.DataBind(PageBreak1.Break_Param.DataCount);
        }
    }
}
