using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cat.Produce.Core.Service;
using Jiuzh.CoreBase.Infrastructure;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.DomainObjects;
using Common;
using Xxf.Core;

namespace ProduceManage.Pages.Product
{
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SaveCurrURL(false);
                this.Post1.BackURL = GetCurrURL();
                if (Request.QueryString["id"] != null)
                {
                    IProductRepository productRep = IoC.Resolve<IProductRepository>();
                    IProduct product = productRep.GetById(Convert.ToInt32(Request.QueryString["id"]));
                    TextBox1.Text = product.Name;
                    TextBox2.Text = product.Number.Trim();
                    txtProcess.Text = product.Process;
                }
            }
        }

        protected void Addpost()
        {
            string name = TextBox1.Text.Trim();
            string id = TextBox2.Text.Trim();
            string process = txtProcess.Text.Trim();
            IProductService clintSer = IoC.Resolve<IProductService>();
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    clintSer .Edit (Convert .ToInt32 ( Request .QueryString ["id"]),id ,name ,_user .User .Id,process  );
                    xxfalert .EditSucceed (this);
                }
                catch(Exception e)
                {
                    xxfalert.Show(this, e.Message);
                }
            }
            else
            {
                try
                {
                    clintSer.Add(id, name, _user.User.Id,process );
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
