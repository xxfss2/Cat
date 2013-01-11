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
    public partial class Schedule_Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["pptId"] != null)
            {
                this.SaveCurrURL(false);
                Post1.BackURL = GetCurrURL();
                IProduce_ProductRepository produceRep = IoC.Resolve<IProduce_ProductRepository>();
                IProduce_Product produce = produceRep.GetById(Convert.ToInt32(Request.QueryString["pptId"]));
                lId.Text = produce.Produce.Number;
                lName.Text = produce.Product.Name;
                tbDate.Text = DateTime.Now.ToShortDateString();
            }
        }
        protected void Addpost()
        {
            string id = lId.Text;
            DateTime dt = Convert.ToDateTime(tbDate.Text.Trim());
            string remark = tbRemark.Text.Trim();
            IProScheduleService clintSer = IoC.Resolve<IProScheduleService>();
            try
            {
                clintSer.Add(Convert.ToInt32(Request.QueryString["pptId"]), remark, dt, _user.User.Id);
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
