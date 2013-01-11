using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cat.Produce.Core.Service;
using Cat.Produce.Core.DomainObjects ;
using Cat.Produce.Core.Repository;
using Jiuzh.CoreBase.Infrastructure;
using Common;
using Xxf.Core;

namespace ProduceManage.Pages.Factory
{
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                IFactoryRepository clientRep = IoC.Resolve<IFactoryRepository>();
                IFactory client = clientRep.GetById(Convert.ToInt32(Request.QueryString["id"]));
                this.TextBox1.Text = client.Contact ;
                this.tbName.Text = client.Name;
                this.tbPhone.Text = client.Phone;
                this.tbFax.Text = client.Fax;
                this.tbAddress.Text = client.Address;
                this.tbPhone2.Text = client.Phone2;
            }
        }

        protected void Addpost()
        {
            string name = tbName.Text.Trim();
            string contact = TextBox1.Text.Trim();
            string phone = tbPhone.Text.Trim();
            string address = tbAddress.Text.Trim();
            string fax = tbFax.Text.Trim();
            string phone2 = tbPhone2.Text.Trim();
            IFactoryService clintSer = IoC.Resolve<IFactoryService>();
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    clintSer.Edit(Convert.ToInt32(Request.QueryString["id"]), name, contact, phone, address, fax, phone2);
                    xxfalert.EditSucceed(this);
                }
                catch (Exception e)
                {
                    xxfalert.Show(this, e.Message);
                }
            }
            else
            {
                try
                {
                    clintSer.Add(name, contact, phone, address, fax, phone2);
                    xxfalert.Show(this, "添加成功！");
                }
                catch (Exception e)
                {
                    xxfalert.Show(this, e.Message);
                }
            }
        }

        protected void Back()
        {
            Response.Redirect("List.aspx");
        }
    }
}

