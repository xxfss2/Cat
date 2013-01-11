using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cat.Produce.Core.Service;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.CoreBase.Infrastructure;
using Xxf.Core;
using Common;

namespace ProduceManage.Pages.Produce
{
    public partial class Delivery_Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack && Request.QueryString["pptId"] != null)
            {
                this.SaveCurrURL(false);
                this.Post1.BackURL = this.GetCurrURL();
                string[] types = Enum.GetNames(typeof(DeliveryType));
                ddlType.DataSource = types;
                ddlType.DataBind();
                IProduce_ProductRepository produceRep = IoC.Resolve<IProduce_ProductRepository>();
                IProduce_Product produce = produceRep.GetById(Convert.ToInt32(Request.QueryString["pptId"]));
                lId.Text = produce.Produce.Number;
                lName.Text = produce.Product.Name;
                tbDate.Text = DateTime.Now.ToShortDateString();
            }
            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                this.SaveCurrURL(false);
                this.Post1.BackURL = this.GetCurrURL();
                string[] types = Enum.GetNames(typeof(DeliveryType));
                ddlType.DataSource = types;
                ddlType.DataBind();
                IDeliverysRepository deRep = IoC.Resolve<IDeliverysRepository>();
                IDeliverys dev = deRep.GetById(Convert.ToInt32(Request.QueryString["id"]));
                lId.Text = dev.Produce_ProductInfo.Produce.Number;
                lName.Text = dev.Produce_ProductInfo.Product.Name;
                tbAmount.Text = dev.Amount.ToString();
                tbDate.Text = dev.DDate.ToShortDateString();
                ddlType.SelectedValue = dev.Type.ToString();
                tbInvoice.Text = dev.Invoice;
                tbCode.Text = dev.HScode;
            }
        }
        protected void Addpost()
        {
            string id = lId.Text;
            int amount = Convert.ToInt32(tbAmount.Text.Trim());
            string invoice = tbInvoice.Text.Trim();
            DateTime dt = Convert.ToDateTime(tbDate.Text.Trim());
            string hsCode = tbCode.Text.Trim();
            DeliveryType type = (DeliveryType)Enum.Parse(typeof(DeliveryType), ddlType.Text);
            IDeliverysService deliverySer = IoC.Resolve<IDeliverysService>();
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    deliverySer.Edit(Convert.ToInt32(Request.QueryString["id"]), amount, dt, type, invoice, hsCode, _user.User.Id);
                    xxfalert.EditSucceed(this);
                }
                else
                {
                    deliverySer.Add(Convert.ToInt32(Request.QueryString["pptId"]),  amount, dt, type, invoice, hsCode, _user.User.Id);
                    xxfalert.Show(this, "添加成功！");
                }
            }
            catch (Exception e)
            {
                xxfalert.Show(this, e.Message);
            }
        }

        protected void Back()
        {
            Response.Redirect(this.GetCurrURL());
        }
    }
}
