<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produce.aspx.cs" Inherits="ProduceManage.Pages.Select.Produce" %>
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
<xxf:PageManager ID="SelectGroupManager1" runat="server" >  </xxf:PageManager>
    <span style ="display :none" > <xxf:TabRadio runat ="server" ID="Radio1" GroupName ="tab" DivId ="tab1" Checked ="true" /><label for ="Radio1">订单列表</label> </span>
    <div runat ="server" id ="tab1">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="30"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td>&nbsp;</td>
        <td style="padding-right:10px;"><div align="right">
          <table border="0" align="right" cellpadding="0" cellspacing="0">
            <tr>
              <td width="60"><input type="checkbox" name="checkbox62" value="checkbox" />全选</td>
              <td width="60"><a href ="Add.aspx" > <img src="../_images/001.gif" alt ="新增客户" />新增</a></td>
              <td width="60"><a href ="#" onclick ="goEdit('Add.aspx')" ><img alt ="" src="../_images/114.gif" />修改</a></td>
              <td width="52"><a href ="#" onclick ="goDel()" ><img alt ="" src="../_images/083.gif" />删除</a></td>
            </tr>
          </table>
        </div></td>
      </tr>
    </table></td>
  </tr>
       <tr>
  <td >
  <table >
  <tr >
  <td >
  <div runat ="server" id ="divSelect" >
    <table >
  <tr >
  <td >图纸编号：</td>
  <td ><xxf:AutoComplete ID="acProduct" runat="server"     ontextchanged="acProduct_TextChanged" MinStart="2"  ></xxf:AutoComplete></td>
      <td> 
          <xxf:SelectButton ID ="btnSelect" runat ="server" PageBreakControl ="PageBreak1" Text ="查询" ></xxf:SelectButton>
      </td>
  </tr>
  </table>
  </div>
  </td>
  </tr>
  </table>
   <asp:Button ID="btPrint" runat="server" Text="导出为EXCEL" />  
  </td>
  </tr>
  <tr>
    <td>
        <xxf:Repeater ID="Repeater1" runat="server" onasynbind="Repeater1_AsynBind">
        <HeaderTemplate > <table class="grid1" width="100%" id ="productTable" >
        <tr >
        <th style ="width :40%" >订单号</th><th >订单时间</th><th >客户价格</th><th >汇率</th><th >工厂价格</th></tr> </HeaderTemplate>
        <ItemTemplate >
        <tr>
        <td ><a href ="../Produce/Produce_Product_Detail.aspx?pptId=<%#this.Bind<View_PPtSelect>(_ => _.Id )%>" ><%#this.Bind<View_PPtSelect>(_ => _.ProduceNO )%></a>  </td>
        <td ><%#this.Bind<View_PPtSelect>(_ => _.OrderDate.ToShortDateString ())%> </td>
         <td ><%#this.Bind<View_PPtSelect>(_ => _.ClientPrice  )%> </td>
         <td ><%#this.Bind<View_PPtSelect>(_ => _.ExchangeRate )%> </td>
         <td ><%#this.Bind<View_PPtSelect>(_ => _.FactoryPrice  )%> </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate ></table></FooterTemplate>
        </xxf:Repeater>
</td>
  </tr>
  <tr>
    <td height="35">
        <xxf:PageBreak ID="PageBreak1" runat="server" TableControl ="Repeater1" />
    </td>
  </tr>
</table>
</div> 
    </form>
</body>
</html>
