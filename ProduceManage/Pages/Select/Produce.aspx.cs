using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jiuzh.CoreBase.Infrastructure;
using Cat.Produce.Core.Repository;
using Cat .Produce .Core .DomainObjects;
using Cat.Produce.Core.Service;
using Xxf .Core ;
using Xxf.Web.UI.Control;
namespace ProduceManage.Pages.Select
{
    public partial class Produce : PageBase 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["btnSlect"] != null)
            {
                this.acProduct.TextChanged -= new AutoCompleteHandler(this.acProduct_TextChanged );
                this.SaveCurrURL(true);
            }
            if (!IsPostBack)
            {
            }

        }

        //private ICollection<View_PPtSelect > GetTableData()
        //{
        //    IProduce_ProductRepository pptRep = IoC.Resolve<IProduce_ProductRepository>();
        //    return pptRep.GetDetailList(PageBreak1.Break_Param, PageBreak1.Sort_Param);
        //}


        protected List<string> acProduct_TextChanged(object sender,EventArgs e)
        {
            IProductRepository productRep = IoC.Resolve<IProductRepository>();
            return productRep.GetsByNum(acProduct.Text).Select(s => s.Number).ToList();
        }

        protected void Repeater1_AsynBind(object sender, EventArgs e)
        {
            string num = acProduct.Text;
            IProduce_ProductRepository pptRep = IoC.Resolve<IProduce_ProductRepository>();
            Repeater1.DataSource = pptRep.GetDetailList(num, PageBreak1.Break_Param, PageBreak1.Sort_Param);
            Repeater1.DataBind(PageBreak1 .Break_Param .DataCount ); 
        }
    }
}
