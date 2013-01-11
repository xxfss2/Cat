<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ProduceManage.Pages.Product.List" EnableViewState ="false"  %>
<%@ Import Namespace ="Cat.Produce.Core.DomainObjects" %>
<%@ Import Namespace ="Xxf.Helper" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
<title > </title>
<link type ="text/css" href ="../_css/Common.css" rel ="Stylesheet"  />
<script type ="text/javascript" src ="../_js/jquery_1.3.2.js"></script>
<script type ="text/javascript" src ="../_js/xxf.js"></script>
</head>

<body>
    <form id="form1" runat="server">
<xxf:PageManager ID="SelectGroupManager1" runat="server" >
    </xxf:PageManager>
    <span style ="display :none" > <xxf:TabRadio runat ="server" ID="Radio1" GroupName ="tab" DivId ="tab1" Checked ="true" /><label for ="Radio1"></label> </span>
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
    <td>
        <xxf:Repeater ID="Repeater1" runat="server" onasynbind="Repeater1_AsynBind">
        <HeaderTemplate > <table class="grid1" width="100%" id ="productTable" >
        <tr ><th style ="width :22px"><input type ="checkbox" id ="cbCheckAll" onclick="checkAll(this)" /></th>
        <th style ="width :40%" >图纸编号</th><th >产品名称</th><th >工艺</th></tr> </HeaderTemplate>
        <ItemTemplate >
        <tr>
        <td ><input type ="checkbox" id ="cb<%#Container.ItemIndex%>" onclick="checkedItem('<%#this.Bind<IProduct>(_=>_.Id) %>','cb<%#Container.ItemIndex%>')" /></td>
        <td ><%#this.Bind <IProduct >(_=>_.Number ) %> </td>
        <td ><%#this.Bind <IProduct >(_=>_.Name ) %> </td>
              <td ><%#this.Bind <IProduct >(_=>_.Process ) %> </td>
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