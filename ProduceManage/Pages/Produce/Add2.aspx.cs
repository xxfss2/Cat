using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cat.Produce.Core.Service;
using Cat.Produce.Core.Repository;
using Jiuzh.CoreBase.Infrastructure;
using Cat.Produce.Core.DomainObjects;
using Xxf.Core;
using Common;
using System.Web.Script.Serialization;

namespace ProduceManage.Pages.Produce
{
    public partial class Add2 : PageSelectBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IProductRepository productRep = IoC.Resolve<IProductRepository>();
                ddlProduct.DataSource = productRep.GetAll();
                ddlProduct.DataTextField = "name";
                ddlProduct.DataValueField = "id";
                ddlProduct.DataBind();
                IClientInfoRepository clientRep = IoC.Resolve<IClientInfoRepository>();
                ddlClient.DataSource = clientRep.GetByUser(_user.User.Id);
                ddlClient.DataTextField = "name";
                ddlClient.DataValueField = "id";
                ddlClient.DataBind();
                tbDate.Text = DateTime.Now.ToShortDateString();
                tbFactDate.Text = DateTime.Now.ToShortDateString();
            }
            if (Request.Form["Action"] == "1")
            {
                string id = Request.Form["id"];
                string materid = Request.Form["materid"];
                string drawingid = Request.Form["drawingid"];
                DateTime  date =Convert .ToDateTime( Request.Form["date"]);
                int clientId;
                if(!int.TryParse ( Request .Form ["clientid"],out clientId ))
                {
                    xxfalert.Show(this,"");
                    return;
                }
                DateTime factdate =Convert .ToDateTime ( Request.Form["factdate"]);
                string remark = Request.Form["remark"];
                JavaScriptSerializer serialize = new JavaScriptSerializer();
                Add_Produce_ProudctInfo[] items=serialize .Deserialize <Add_Produce_ProudctInfo []>(Request .Form ["proudcts"]);
                IProduceInfoService clintSer = IoC.Resolve<IProduceInfoService>();
                try
                {
                    clintSer.Add(id, date, clientId, items, materid, drawingid, factdate, remark, _user.User.Id);
                    xxfalert.Show(this, "添加成功！");
                }
                catch (Exception ex)
                {
                    xxfalert.Show(this, ex.Message);
                }

            }
        }
        protected void Addpost()
        {
            string number = tbId.Text.Trim();
            int clientId =Convert .ToInt32( ddlClient.SelectedValue);
            int productId =Convert.ToInt32( ddlProduct.SelectedValue);
            string materid = tbMaterial.Text.Trim();
            int amount =Convert .ToInt32( tbAmount.Text.Trim());
            string drawingId = tbDrawingId.Text.Trim();
            DateTime orderDate = Convert.ToDateTime(tbDate.Text.Trim());
            DateTime? proDate = Convert.ToDateTime(tbFactDate.Text.Trim());
            string remark = tbRemark.Text.Trim();
            IProduceInfoService clintSer = IoC.Resolve<IProduceInfoService>();
            try
            {
                clintSer.Add(number, orderDate, clientId, productId, materid, amount, drawingId, proDate, remark, _user.User.Id);
                xxfalert.Show(this, "添加成功！");
            }
            catch (Exception e)
            {
                xxfalert.Show(this, e.Message);
            }
        }

        protected void Back()
        {
            Response.Redirect("CurrList.aspx");
        }
    }
}
