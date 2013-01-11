<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Remind.aspx.cs" Inherits="ProduceManage.Pages.Produce.Remind" EnableViewState ="false" %>

<%@ Import Namespace ="Cat.Produce.Core.DomainObjects" %>
<%@ Import Namespace ="Xxf.Helper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1">
    <title></title>
    <link type ="text/css" href ="../_css/Common.css" rel ="Stylesheet"  />
    <script type ="text/javascript" src ="../_js/jquery_1.3.2.js"></script>
    <script type ="text/javascript" src ="../_js/xxf.js"></script>
</head>
<body>
  <form id="form1" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>  
    <td>
    <xxf:Repeater ID="Repeater1" runat="server" EnableTheming ="false" >
    <HeaderTemplate > <table id="table1" class="grid1" width="100%" >
<tr >
<th field="ProduceNO" style ="width :80px" >订单号</th ><xxf:XxfTh ID="XxfTh1" runat="server" FieldClientCode="产品名称"  FieldSortCode="ProductName"></xxf:XxfTh>
    <th >产品编号</th><th field ="OrderDate" >下单日期</th><th >数量</th><th field ="RemainAmount" >剩余数量</th><th >工厂下单日期</th><th >加工厂</th><th >工厂交货期</th><th >客户交货期</th><th >操作</th></tr> </HeaderTemplate>
<ItemTemplate >
<tr >
<td ><%#this.Bind<View_Produce_Product>(_ => _.ProduceNO )%> </td>
<td ><a href ="Produce_Product_Detail.aspx?pptId=<%#this.Bind <View_Produce_Product >(_=>_.Id) %>"><%#this.Bind<View_Produce_Product>(_ => _.ProductName )%></a> </td>
<td ><%#this.Bind<View_Produce_Product>(_ => _.ProudctNO)%> </td>
<td ><%#this.Bind<View_Produce_Product>(_ => _.OrderDate .ToShortDateString ())%> </td>
<td ><%#this.Bind<View_Produce_Product>(_ => _.Amount )%> </td> 
<td ><%#this.Bind<View_Produce_Product>(_ => _.RemainAmount )%> </td> 
<td ><%#this.Bind<View_Produce_Product>(_ => _.FactoryOrderDate.HasValue  ? _.FactoryOrderDate .Value .ToShortDateString ():""  )%> </td> 
<td ><%#this.Bind<View_Produce_Product>(_ => _.FactoryName  )%> </td> 
<td ><%#this.Bind<View_Produce_Product>(_ => _.FactDevliDate .HasValue ?_.FactDevliDate.Value .ToShortDateString ():null  )%> </td>
<td ><%#this.Bind<View_Produce_Product>(_ => _.CustDevliDate.HasValue ? _.CustDevliDate.Value.ToShortDateString() : null)%> </td>
<td class ="action">
<a href ="Schedule_Add.aspx?pptId=<%#this.Bind <View_Produce_Product >(_=>_.Id) %>">进度</a>
<a href ="Delivery_Add.aspx?pptId=<%#this.Bind <View_Produce_Product >(_=>_.Id) %>">交货</a>
</tr>
</ItemTemplate>
<FooterTemplate ></table></FooterTemplate>
  </xxf:Repeater>
 </td>
  </tr>
</table>
    <input id="hdSelected" name ="hdSelected" type="hidden" />
   </form>

   <script type ="text/javascript" >
       function endInit() {
           if (selList.length != 1) {
               alert('请猫猫选择一条记录');
               return false;
           }
           $("#hdSelected").val(selList[0]);
           return true;
       }

       function goEdit(src) {
           if (selList.length != 1) {
               alert("请选择一条要修改的信息！");
               return;
           }
           location.href = src + "?pptId=" + selList[0];
       }
   </script>
  </body>
</html>

