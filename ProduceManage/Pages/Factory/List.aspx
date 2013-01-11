<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ProduceManage.Pages.Factory.List" EnableViewState ="false"  %>
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
    <xxf:PageManager ID="sgmFact" runat="server" >
    </xxf:PageManager>
       <span style ="display :none" > <xxf:TabRadio runat ="server" ID="Radio1" GroupName ="tab" DivId ="tab1" Checked ="true" /><label for ="Radio1">订单列表</label> </span>
           <div runat ="server" id ="tab1">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="30">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td>&nbsp;</td>
        <td style="padding-right:10px;"><div align="right">
          <table border="0" align="right" cellpadding="0" cellspacing="0">
            <tr>
              <td width="100"><a  href ="#" onclick ="AddContact()" > <img src="../_images/001.gif" alt ="新增联系人" />新增联系人</a></td>
              <td width="60"><a href ="Add.aspx" > <img src="../_images/001.gif" alt ="新增客户" />新增</a></td>
              <td width="60"><a href ="#" onclick ="goEdit('Add.aspx')" ><img alt ="" src="../_images/114.gif" />修改</a></td>
              <td width="52"><a href ="#" onclick ="goDel()" ><img alt ="" src="../_images/083.gif" />删除</a></td>
            </tr>
          </table>
        </div></td>
      </tr>
    </table>
       </td>
  </tr>
  <tr>
    <td>
        <xxf:Repeater ID="Repeater1" runat="server" onasynbind="Repeater1_AsynBind">
        <HeaderTemplate > <table class="grid1" width="100%" id ="factoryTable" >
        <tr ><th style ="width :22px"><input type ="checkbox" id ="cbCheckAll" onclick="checkAll(this)" /></th>
        <th >加工厂名称</th><th >联系人</th><th >手机</th><th >电话</th><th >地址</th><th >传真</th></tr> </HeaderTemplate>
        <ItemTemplate >
        <tr>
        <td ><input type ="checkbox" id ="cb<%#Container.ItemIndex%>" onclick="checkedItem('<%#this.Bind<IFactory>(_=>_.Id) %>','cb<%#Container.ItemIndex%>')" /></td>
        <td ><%#this.Bind <IFactory >(_=>_.Name ) %> </td>
        <td ><%#this.Bind <IFactory >(_=>_.Contact  ) %> </td>
        <td ><%#this.Bind <IFactory >(_=>_.Phone2  ) %> </td>
         <td ><%#this.Bind <IFactory >(_=>_.Phone  ) %> </td>
        <td ><%#this.Bind <IFactory >(_=>_.Address ) %> </td>
        <td ><%#this.Bind <IFactory >(_=>_.Fax ) %> </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate ></table></FooterTemplate>
        </xxf:Repeater>
</td>
  </tr>
  <tr>
    <td height="35"><xxf:PageBreak ID="PageBreak1" runat="server" TableControl ="Repeater1" /></td>
  </tr>
</table>
</div> 
    </form>
        <script type ="text/javascript" >
        function AddContact() {
            if (selList.length != 1) {
                alert("请选择一个加工厂！");
                return;
            }
            location.href = "../Contact/AddContact.aspx?id=" + selList[0] + "&type=<%=(int)CantactType.工厂联系人%>";
        }
    </script>
</body>
</html>