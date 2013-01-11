<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistroyList.aspx.cs" Inherits="ProduceManage.Pages.Produce.HistroyList" %>
<%@ Import Namespace ="Cat.Produce.Core.DomainObjects" %>
<%@ Import Namespace ="Xxf.Helper" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link type ="text/css" href ="../_css/Common.css" rel ="Stylesheet"  />
    <script type ="text/javascript" src ="../_js/jquery_1.3.2.js"></script>
    <script type ="text/javascript" src ="../_js/xxf.js"></script>
</head>
<body>
  <form id="form1" runat="server">
  <xxf:PageManager ID="SelectGroupManager1" runat="server" >
  </xxf:PageManager>
    <span style ="display :none" > <xxf:TabRadio runat ="server" ID="Radio1" GroupName ="tab" DivId ="tab1" Checked ="true" /><label for ="Radio1">订单列表</label> </span>
    <div runat ="server" id ="tab1">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="30"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td>&nbsp;</td>
        <td style="padding-right:10px;"></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td>
        <xxf:Repeater ID="Repeater1" runat="server" onasynbind="Repeater1_AsynBind"  >
        <HeaderTemplate > <table class="grid1" width="100%" id ="historyTable" >
        <tr ><th style ="width :22px"><input type ="checkbox" id ="cbCheckAll" onclick="checkAll(this)" /></th>
        <th >订单号</th><th >产品名称</th><th >图纸编号</th><th >下单日期</th><th >数量</th><th >加工厂</th><th >工厂下单日期</th><th >材料</th><th >图纸</th><th >客户单价</th><th >工厂单价</th></tr> </HeaderTemplate>
        <ItemTemplate >
        <tr >
        <td style ="width:22px" ><input type ="checkbox" id ="cb<%#Container.ItemIndex%>" onclick="checkedItem('<%#this.Bind<View_Produce_Product>(_=>_.Id) %>','cb<%#Container.ItemIndex%>')" /></td>
        <td ><%#this.Bind<View_Produce_Product>(_ => _.ProduceNO )%> </td>
        <td ><a href ="Produce_Product_Detail.aspx?pptId=<%#this.Bind <View_Produce_Product >(_=>_.Id) %>"><%#this.Bind<View_Produce_Product>(_ => _.ProductName )%></a> </td>
        <td ><%#this.Bind<View_Produce_Product>(_ => _.ProudctNO)%> </td>
        <td ><%#this.Bind<View_Produce_Product>(_ => _.OrderDate .ToShortDateString ())%> </td>
        <td ><%#this.Bind<View_Produce_Product>(_ => _.ActualAmount )%> </td> 
        <td ><%#this.Bind<View_Produce_Product>(_ => _.FactoryName  )%> </td> 
        <td ><%#this.Bind<View_Produce_Product>(_ => _.FactoryOrderDate.HasValue  ? _.FactoryOrderDate .Value .ToShortDateString ():""  )%> </td> 
        <td ><%#this.Bind<View_Produce_Product>(_ => _.Material  )%> </td> 
        <td ><%#this.Bind<View_Produce_Product>(_ => _.DrawingId  )%> </td> 
        <td ><%#this.Bind<View_Produce_Product>(_ => _.ClientPrice.HasValue ?_.ClientPrice .ToString ()+_.Mark:null )%> </td>
        <td ><%#this.Bind<View_Produce_Product>(_ => _.FactoryPrice.HasValue ? _.FactoryPrice .ToString ()+"￥":null)%> </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate ></table></FooterTemplate>
        </xxf:Repeater>
 </td>
  </tr>
  <tr>
    <td height="35">
            <xxf:pagebreak ID="PageBreak1" runat="server" TableControl ="Repeater1" />
    </td>
  </tr>
</table>
</div> 
    </form>
</body>
</html>
