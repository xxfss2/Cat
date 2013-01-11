using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xxf.Core;
using Common;
using Cat.Produce.Core.Repository;
using Jiuzh.CoreBase.Infrastructure;
using Cat.Produce.Core.DomainObjects;
using Xxf.Helper;

namespace ProduceManage
{
    public partial class Right : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IProduce_ProductRepository pptRep = IoC.Resolve<IProduce_ProductRepository>();
                int count = pptRep.DeliveryRemind();
                if (count > 0)
                {
                    hlkRemind.Text = "猫猫，有 "+count +" 批货快到交货期了";
                }
            }
        }
    }
}
