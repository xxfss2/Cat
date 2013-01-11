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

namespace ProduceManage.Pages.Customer
{
    public partial class Add : PageBase
    {
        UserCore _myUser = new UserCore();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SaveCurrURL(false);
                this.Post1.BackURL = GetCurrURL();
                if (Request.QueryString["id"] != null )
                {
                    IClientInfoRepository clientRep = IoC.Resolve<IClientInfoRepository>();
                    IClientInfo client = clientRep.GetById(Convert.ToInt32(Request.QueryString["id"]));
                    this.TextBox1.Text = client.Name;
                    this.TextBox2.Text = client.Number;
                    this.tbcontact.Text = client.Contact;
                    this.tbMail.Text = client.Mail;
                    this.tbphone.Text = client.Phone;
                    this.txtSite.Text = client.Site;
                }
            }
        }

        protected void Addpost()
        {
            string name = TextBox1.Text.Trim();
            string id = TextBox2.Text.Trim();
            string contact = tbcontact.Text.Trim();
            string mail = tbMail.Text.Trim();
            string phone = tbphone.Text.Trim();
            string address = tbAddress.Text.Trim();
            string site = txtSite.Text.Trim();
            IClientInfoService clintSer = IoC.Resolve<IClientInfoService>();
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    clintSer.Edit(Convert.ToInt32(Request.QueryString["id"]), id, name,contact ,mail ,phone ,address , _user.User.Id,site );
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
                    clintSer.Add(id, name,contact ,mail ,phone ,address , _myUser.User.Id,site);
                    xxfalert.Show(this, "添加成功！");
                }
                catch (Exception e)
                {
                    xxfalert.Show(this, e.Message);
                }
            }
        }

    }
}

