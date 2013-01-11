using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xxf.Web.UI;
using Jiuzh.CoreBase.Infrastructure;
using Cat.Produce.Core.Repository;
namespace ProduceManage.Pages.Produce
{
    public partial class ProduceProduct : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [SelectProperty(Key ="id",Source =PropertyValueSource.QueryString)]
        public int Id { get; set; }

        protected override void OnPreRender(EventArgs e)
        {
            IProduceInfoRepository pinfoRep = IoC.Resolve<IProduceInfoRepository>();
            Rproducts.DataSource = pinfoRep.GetById(Id).Products;
            Rproducts.DataBind();
            base.OnPreRender(e);
        }
    }
}