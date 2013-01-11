using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jiuzh.CoreBase;
using Common;
using Cat.Produce.Core.Repository;
using Cat .Produce .Core .DomainObjects ;
using Jiuzh.CoreBase.Infrastructure;

namespace ProduceManage.Pages.Produce
{
    public partial class HistroyList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private ICollection <View_Produce_Product > GetTableData()
        {
            IProduce_ProductRepository produce_productRep = IoC.Resolve<IProduce_ProductRepository>();
            return  produce_productRep.GetDetailList(true, null, null, PageBreak1.Break_Param, PageBreak1 .Sort_Param );;
        }


        protected void Repeater1_AsynBind(object sender, EventArgs e)
        {
            Repeater1.DataSource = GetTableData();
            Repeater1.DataBind(PageBreak1.Break_Param.DataCount);
        }
    }
}
