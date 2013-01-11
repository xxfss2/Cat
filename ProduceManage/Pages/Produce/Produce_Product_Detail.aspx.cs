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
    public partial class Produce_Product_Detail : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request .QueryString ["pptId"]!=null )
            {
                this.SaveCurrURL(false);
                this.Post1.BackURL = this.GetCurrURL();
                IProduce_ProductRepository productRep = IoC.Resolve<IProduce_ProductRepository>();
                IProduce_Product pro = productRep.GetById(Convert.ToInt32(Request.QueryString["pptId"]));
                lId.Text = pro.Produce.Number;
                lCustom.Text = pro.Produce .ClientInfo.Name;
                lProductName.Text = pro.Product.Name;
                lAmount.Text = pro.RemainAmount + "/" + pro.Amount;
                lDraw.Text = pro.DrawingId;
                lMaterial.Text = pro.Material;
                lDate.Text = pro.OrderDate.ToShortDateString();
                lProdate.Text = pro.FactoryOrderDate.HasValue ? pro.FactoryOrderDate.Value.ToShortDateString() : null;

                lCustPrice.Text = pro.ClientPrice.ToString();
                lFactPrice.Text = pro.FactoryPrice.ToString();
                lCustDeliv.Text = pro.DelivDateCust.HasValue ? pro.DelivDateCust.Value.ToShortDateString() : null;
                lFactDeliv.Text = pro.DelivDateFact.HasValue ? pro.DelivDateFact.Value.ToShortDateString() : null;
                lQualityer.Text = pro.Qualityer;
                lModelPrice.Text = pro.ModelPrice.ToString();
                lExchange.Text = pro.ExchangeRate.ToString();

                rDelivery.DataSource = pro.Deliverys ;
                rDelivery.DataBind();

                rSchedule.DataSource = pro.Schedules ;
                rSchedule.DataBind();
            }
        }
        protected void Back()
        {
            Response.Redirect(this.GetCurrURL () );
        }
    }
}
