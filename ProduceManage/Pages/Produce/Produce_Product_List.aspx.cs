using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.Service;
using Jiuzh.CoreBase.Infrastructure;
using Cat.Produce.Core.DomainObjects;
using Xxf.Helper;
using Common;

namespace ProduceManage.Pages.Produce
{
    public partial class Produce_Product_List : PageBase 
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsAsynPost)
            {
                this.SaveCurrURL(true);

            }
            if (Request.Form["Hdelete"] != null)
            {
                int id = int.Parse(Request.Form["Hdelete"]);
                IProduce_ProductService pptSer = IoC.Resolve<IProduce_ProductService>();
                try
                {
                    pptSer.Del(id);
                }
                catch(Exception ex)
                {
                    xxfalert.Show(this,ex.Message);
                }
            }
        }


        private ICollection<View_Produce_Product> GetTableData()
        {
            IProduce_ProductRepository produce_productRep = IoC.Resolve<IProduce_ProductRepository>();
            string orderid = tbOrderid.Text;
            string clientid = tbClientid.Text;
            return produce_productRep.GetDetailList(false , clientid, orderid, PageBreak1.Break_Param, PageBreak1.Sort_Param);
        }


        protected void btPrint_Click(object sender, EventArgs e)
        {
            Xxf.Helper.PrintHelper printHelp = new Xxf.Helper.PrintHelper();
            IProduce_ProductRepository produce_productRep = IoC.Resolve<IProduce_ProductRepository>();
            string orderid = tbOrderid.Text;
            string clientid = tbClientid.Text;

            ICollection<View_Produce_Product> data = produce_productRep.GetDetailList(false, clientid, orderid, null, PageBreak1.Sort_Param);
            var result = from p in data
                         select new
                             {
                                 订单号 = p.ProduceNO,
                                 产品名称 = p.ProductName,
                                 产品编号 = p.ProudctNO,
                                 下单日期 = p.OrderDate.ToShortDateString(),
                                 客户交期=p.CustDevliDate .HasValue ? p.CustDevliDate .Value .ToShortDateString ():"",
                                 数量 = p.Amount,
                                 剩余数量 = p.RemainAmount,
                                 工厂下单日期 = p.FactoryOrderDate.HasValue ? p.FactoryOrderDate.Value.ToShortDateString() : "",
                                 工厂交期=p.FactDevliDate .HasValue ?p.FactDevliDate .Value .ToShortDateString ():"",
                                 材料 = p.Material,
                                 图纸 = p.ProudctNO,
                                 加工厂 = p.FactoryName,
                                 客户单价 = p.ClientPrice.HasValue ? p.ClientPrice.ToString() + p.Mark : "",
                                 工厂单价 = p.FactoryPrice.HasValue ? p.FactoryPrice.ToString() + "￥" : "",
                                 质量员=p.Qualityer??"",
                             };
            printHelp.CreateExcel<object>(result.Cast<object>().ToList(), "订单产品列表", "订单产品列表", null);
        }

        protected void btEnd_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.Form["hdSelected"]);
            IProduce_ProductService pptSer = IoC.Resolve<IProduce_ProductService>();
            try
            {
                pptSer.End(id);
            }
            catch
            {

            }
        }

    }
}
