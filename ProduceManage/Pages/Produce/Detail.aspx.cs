using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cat.Produce.Core.Service;
using Cat.Produce.Core.Repository;
using Jiuzh.CoreBase.Infrastructure;
using Xxf.Core;
using Common;
using Cat.Produce.Core.DomainObjects;

namespace ProduceManage.Pages.Produce
{
    public partial class Detail : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request .QueryString ["id"]!=null )
            {
                IProduceInfoRepository productRep = IoC.Resolve<IProduceInfoRepository>();
                IProduce pro = productRep.GetById(Convert .ToInt32( Request.QueryString["id"]));
                lId.Text = pro.Number;
                lCustom.Text = pro.ClientInfo.Name;
                //lDate.Text = pro.OrderDate.ToShortDateString();
                //lProdate.Text = pro.FactoryOrderDate.HasValue ? pro.FactoryOrderDate.Value.ToShortDateString() : null;
                lRemark.Text = pro.Remark;
                Rproducts.DataSource = pro.Products;
                Rproducts.DataBind();
                //lDraw.Text = pro.DrawingId;
                //lMaterial.Text = pro.Material;

                //rDelivery.DataSource = pro.Deliverys;
                //rDelivery.DataBind();

                //rSchedule.DataSource = pro.Schedules;
                //rSchedule.DataBind();
            }
        }
        protected void Back()
        {
            Response.Redirect("CurrList.aspx");
        }
    }
}
