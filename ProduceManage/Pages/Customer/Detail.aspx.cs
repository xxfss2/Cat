using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.CoreBase.Infrastructure;

namespace ProduceManage.Pages.Customer
{
    public partial class Detail : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SaveCurrURL(false);
                lbBack.NavigateUrl = GetCurrURL();
                if (Request.QueryString["id"] != null)
                {
                    IClientInfoRepository clientRep = IoC.Resolve<IClientInfoRepository>();
                    IClientInfo client = clientRep.GetById(Convert.ToInt32(Request.QueryString["id"]));
                    lName.Text = client.Name;
                    lcode.Text = client.Number;
                    lContact.Text = client.Contact;
                    lEmal.Text = client.Mail;
                    lPhone.Text = client.Phone;
                    lSite.Text = client.Site;
                    lAddress.Text = client.Address;
                }
            }
        }
    }
}
