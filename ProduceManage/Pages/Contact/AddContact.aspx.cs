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
    public partial class AddContact : PageBase
    {
        UserCore _myUser = new UserCore();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SaveCurrURL(false);
                this.Post1.BackURL = GetCurrURL();
                if (Request.QueryString["id2"] != null )
                {
                    //IClientInfoRepository clientRep = IoC.Resolve<IClientInfoRepository>();
                    //IClientInfo client = clientRep.GetById(Convert.ToInt32(Request.QueryString["id"]));
                    //this.TextBox1.Text = client.Name;
                    //this.TextBox2.Text = client.Number;
                    //this.tbcontact.Text = client.Contact;
                    //this.tbMail.Text = client.Mail;
                    //this.tbphone.Text = client.Phone;
                }
            }
        }

        protected void Addpost()
        {
            string name = tbName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string mail = tbMail.Text.Trim();
            string address = tbAddress.Text.Trim();

           // IClientInfoService clintSer = IoC.Resolve<IClientInfoService>();
            IContactService contactSer = IoC.Resolve<IContactService>();
            if (Request.QueryString["id2"] != null)
            {
                try
                {
                    int id=Convert .ToInt32 (Request .QueryString ["id"]);
                    CantactType type = (CantactType)int.Parse(Request.QueryString["type"]);
                    contactSer.Add(id,type, name, phone, mail, address);
                    xxfalert.Show (this,"添加成功!");
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
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    CantactType type = (CantactType)int.Parse(Request.QueryString["type"]);
                    contactSer.Add(id,type, name, phone, mail, address);
                    xxfalert.Show(this, "添加成功!");
                }
                catch (Exception e)
                {
                    xxfalert.Show(this, e.Message);
                }
            }
        }

    }
}

