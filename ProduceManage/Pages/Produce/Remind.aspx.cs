using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.Service;
using Jiuzh.CoreBase.Infrastructure;
using Cat.Produce.Core.DomainObjects;
using Xxf.Helper;

namespace ProduceManage.Pages.Produce
{
    public partial class Remind: PageBase 
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack )
            {
                Repeater1.DataSource = GetTableData();
                Repeater1.DataBind();
            }
        }


        private ICollection<View_Produce_Product> GetTableData()
        {
            IProduce_ProductRepository produce_productRep = IoC.Resolve<IProduce_ProductRepository>();
            return produce_productRep.DeliveryRemindList();
        }
    }
}
