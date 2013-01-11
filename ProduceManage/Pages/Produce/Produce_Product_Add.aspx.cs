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
using Xxf.Web.UI.Control;

namespace ProduceManage.Pages.Produce
{
    public partial class Produce_Product_Add : PageBase
    {
        private IProductRepository productRep = IoC.Resolve<IProductRepository>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["Button1"] != null)
            {
                this.acProduct.TextChanged -= new AutoCompleteHandler(this.acProduct_TextChanged);
            }
            if (!IsPostBack)
            {
                this.SaveCurrURL(false);
                lbBack.NavigateUrl = GetCurrURL();
                IFactoryRepository factRep = IoC.Resolve<IFactoryRepository>();
                IProductRepository productRep = IoC.Resolve<IProductRepository>();

                ddlFactroy.DataSource = factRep.GetAll();
                ddlFactroy.DataTextField = "Name";
                ddlFactroy.DataValueField = "id";
                ddlFactroy.DataBind();

                IMoneyRepository moenyRep = IoC.Resolve<IMoneyRepository>();
                ddlMoney.DataSource = moenyRep.GetAll();
                ddlMoney.DataTextField = "Name";
                ddlMoney.DataValueField = "Id";
                ddlMoney.DataBind();
                ddlMoney.Items.Insert(0, "");


                IProduce_Product p = null;
                IProduce_ProductRepository pRep = IoC.Resolve<IProduce_ProductRepository>();
                if (Request.QueryString["pptId"] != null)
                {
                    p = pRep.GetById(Convert.ToInt32(Request.QueryString["pptId"]));
                    tbAmount.Enabled = false;
                }
                else
                {
                    p = pRep.GetLastByProduceId(int.Parse(Request.QueryString["id"])); 
                }
                ddlFactroy.SelectedValue = p.Factory.Id.ToString();
                acProduct.Text = p.Product.Number;
                //ddlProduct.SelectedValue = p.ProductId.ToString ();
                //ddlProduct.Enabled = false;

                tbAmount.Text = p.Amount.ToString();
                tbClientPrice.Text = p.ClientPrice.ToString();
                tbFactoryPrice.Text = p.FactoryPrice.ToString();
                tbMaterial.Text = p.Material.Trim();
                tbDrawingId.Text = p.DrawingId.Trim ();
                tbDate.Text = p.OrderDate.ToShortDateString();
                tbFactDate.Text = p.FactoryOrderDate.HasValue ? p.FactoryOrderDate.Value.ToShortDateString() : null;
                tbDateFact.Text = p.DelivDateFact.HasValue ? p.DelivDateFact.Value.ToShortDateString() : null;
                tbDateCust.Text = p.DelivDateCust.HasValue ? p.DelivDateCust.Value.ToShortDateString() : null;
                tbQualityer.Text = p.Qualityer;
                tbModelPrice.Text = p.ModelPrice.ToString();
                tbExchange.Text = p.ExchangeRate.ToString();
                if (p.ClientPriceMoney.HasValue)
                {
                    ddlMoney.SelectedValue = p.ClientPriceMoney.ToString();
                }

            }

        }


        protected void Back()
        {
            Response.Redirect(this.GetCurrURL());
        }

        protected List<string> acProduct_TextChanged(object sender,EventArgs e)
        {
            return productRep.GetsByNum(acProduct.Text).Select(s => s.Number).ToList();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IProduct product = productRep.GetByNum(acProduct.Text);
            //int prodcutId = Convert.ToInt32(ddlProduct.SelectedValue);
            int factoryId = Convert.ToInt32(ddlFactroy.SelectedValue);
            string drawingId = tbDrawingId.Text;
            string materid = tbMaterial.Text;
            int amount = Convert.ToInt32(tbAmount.Text);
            DateTime orderDate = Convert.ToDateTime(tbDate.Text);
            DateTime factdate = Convert.ToDateTime(tbFactDate.Text);
            string qualityer = tbQualityer.Text.Trim();
            decimal modelPrice = 0,exchange=0;
            try
            {
                exchange = decimal.Parse(tbExchange.Text.Trim());
            }
            catch
            {
            }
            try
            {
                modelPrice = decimal.Parse(tbModelPrice.Text.Trim());
            }
            catch
            {
            }
            decimal? clientPrice = null, factoryPrice = null;
            try
            {
                clientPrice = Convert.ToDecimal(tbClientPrice.Text.Trim());
            }
            catch { }
            try
            {
                factoryPrice = Convert.ToDecimal(tbFactoryPrice.Text.Trim());
            }
            catch { }
            DateTime? delivDateFact = null,delivDateCust=null ;
            try
            {
                delivDateFact = Convert.ToDateTime(tbDateFact.Text);
            }
            catch { }
            try
            {
                delivDateCust = Convert.ToDateTime(tbDateCust.Text);
            }
            catch { }
            IProduce_ProductService pser = IoC.Resolve<IProduce_ProductService>();
            int? money = null;
            if (ddlMoney.SelectedIndex > 0)
                money = Convert.ToInt32(ddlMoney.SelectedValue);
            try
            {
                if (Request.QueryString["pptId"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["pptId"]);
                    pser.Edit(id, factoryId, amount, materid, drawingId, orderDate, factdate, clientPrice, factoryPrice, money, delivDateFact, delivDateCust, qualityer, modelPrice, product, exchange);
                    xxfalert.Show(this, "修改成功！");
                }
                else
                {
                    int prodcueId = Convert.ToInt32(Request.QueryString["id"]);
                    pser.Add(product.Id, prodcueId, factoryId, amount, materid, drawingId, orderDate, factdate, clientPrice, factoryPrice, money, delivDateFact, delivDateCust, qualityer, modelPrice, exchange);
                    xxfalert.Show(this, "添加成功！");
                }
            }
            catch (Exception ex)
            {
                xxfalert.Show(this, ex.Message);
            }
        } 
    }
}
