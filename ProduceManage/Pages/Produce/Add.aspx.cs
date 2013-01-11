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
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SaveCurrURL(false);
                this.Post1.BackURL = GetCurrURL();
                IProductRepository productRep = IoC.Resolve<IProductRepository>();
                IClientInfoRepository clientRep = IoC.Resolve<IClientInfoRepository>();
                ddlClient.DataSource = clientRep.GetByUser(_user.User.Id);
                ddlClient.DataTextField = "Number";
                ddlClient.DataValueField = "id";
                ddlClient.DataBind();

            }
        }
        protected void Addpost()
        {
            string number = tbId.Text.Trim();
            int clientId =Convert .ToInt32( ddlClient.SelectedValue);
            string remark = tbRemark.Text.Trim();

            IProduceInfoService clintSer = IoC.Resolve<IProduceInfoService>();
            try
            {
                clintSer.Add(number, clientId, remark, _user.User.Id);
                xxfalert.Show(this, "添加成功！");
            }
            catch (Exception e)
            {
                xxfalert.Show(this, e.Message);
            }
        }

    }
}
