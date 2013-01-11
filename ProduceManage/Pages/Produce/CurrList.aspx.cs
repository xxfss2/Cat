using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jiuzh.CoreBase;
using Common;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.Service;
using Jiuzh.CoreBase.Infrastructure;
using Cat.Produce.Core.DomainObjects;
using Xxf.Helper;

namespace ProduceManage.Pages.Produce
{
    public partial class CurrList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["hDelete"] != null)
            {
                int[] ids = Request.Form["hDelete"].Split(';').Select(s => Convert.ToInt32(s)).ToArray();
                IProduceInfoService clientSer = IoC.Resolve<IProduceInfoService>();
                try
                {
                    clientSer.Del(ids);
                    Common.xxfalert.DelSucceed(this);
                }
                catch (Exception ee)
                {
                    Common.xxfalert.Show(this, ee.Message);
                }
            }
            if (!IsAsynPost)
            {
                //Repeater1.DataSource = new List<object>();// GetTableData();
             //   Repeater1.DataBind();
            }
            else
            {
                this.SaveCurrURL(true);

            }

        }

        private ICollection<IProduce> GetTableData()
        {
            IProduceInfoRepository produceRep = IoC.Resolve<IProduceInfoRepository>();
            return produceRep.GetAllCurr(_user.User.Id, pb1.Break_Param);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null)
                return;
            //Repeater repater = e.Item.FindControl("Rproducts") as Repeater;
            //IProduce produce = (IProduce)e.Item.DataItem;
            //repater.DataSource = produce.Products;
            //repater.DataBind();
        }

        protected void Repeater1_AsynBind(object sender, EventArgs e)
        {
            Repeater1.DataSource = GetTableData();
            Repeater1.DataBind(pb1.Break_Param.DataCount);
        }

        protected void Repeater2_AsynBind(object sender, EventArgs e)
        {
            IProduce_ProductRepository produce_productRep = IoC.Resolve<IProduce_ProductRepository>();
            string orderid = tbOrderid.Text;
            string clientid = tbClientid.Text;
            Repeater2.DataSource = produce_productRep.GetDetailList(false, clientid, orderid, pb2.Break_Param, pb2.Sort_Param);
            Repeater2.DataBind(pb2 .Break_Param.DataCount);
        }

        protected void btPrint_Click(object sender, EventArgs e)
        {
            Xxf.Helper.PrintHelper printHelp = new Xxf.Helper.PrintHelper();
            IProduce_ProductRepository produce_productRep = IoC.Resolve<IProduce_ProductRepository>();
            string orderid = tbOrderid.Text;
            string clientid = tbClientid.Text;

            ICollection<View_Produce_Product> data = produce_productRep.GetDetailList(false, clientid, orderid, null, pb2.Sort_Param);
            var result = from p in data
                         select new
                         {
                             订单号 = p.ProduceNO,
                             产品名称 = p.ProductName,
                             产品编号 = p.ProudctNO,
                             下单日期 = p.OrderDate.ToShortDateString(),
                             客户交期 = p.CustDevliDate.HasValue ? p.CustDevliDate.Value.ToShortDateString() : "",
                             数量 = p.Amount,
                             剩余数量 = p.RemainAmount,
                             工厂下单日期 = p.FactoryOrderDate.HasValue ? p.FactoryOrderDate.Value.ToShortDateString() : "",
                             工厂交期 = p.FactDevliDate.HasValue ? p.FactDevliDate.Value.ToShortDateString() : "",
                             材料 = p.Material,
                             图纸 = p.ProudctNO,
                             加工厂 = p.FactoryName,
                             客户单价 = p.ClientPrice.HasValue ? p.ClientPrice.ToString() + p.Mark : "",
                             工厂单价 = p.FactoryPrice.HasValue ? p.FactoryPrice.ToString() + "￥" : "",
                             质量员 = p.Qualityer ?? "",
                         };
            printHelp.CreateExcel<object>(result.Cast<object>().ToList(), "订单产品列表", "订单产品列表", null);
        }
    }
}
