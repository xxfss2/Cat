using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jiuzh.CoreBase.Infrastructure;
using Cat.Produce.Core.Repository;
using Cat .Produce .Core .DomainObjects;
using Cat.Produce.Core.Service;
using Jiuzh .CoreBase;

namespace ProduceManage.Pages.Product
{
    public partial class List : PageBase 
    {
        IProductRepository _clientRep = IoC.Resolve<IProductRepository>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SaveCurrURL(true);
            if (Request.Form["hDelete"] != null)
            {
                int[] ids = Request.Form["hDelete"].Split(';').Select(s => Convert.ToInt32(s)).ToArray();
                IProductService productSer = IoC.Resolve<IProductService>();
                try
                {
                    productSer.Del(ids);
                    Common.xxfalert.DelSucceed(this);
                }
                catch (Exception ee)
                {
                    Common.xxfalert.Show(this, ee.Message);
                }
            }
        }

        private ICollection<IProduct > GetTableData()
        {
            return _clientRep.GetAll(PageBreak1.Break_Param);
        }

        protected void Repeater1_AsynBind(object sender, EventArgs e)
        {
            Repeater1.DataSource = GetTableData();
            Repeater1.DataBind(PageBreak1.Break_Param.DataCount);
        }
    }
}
