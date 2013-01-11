<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produce_Product_List.aspx.cs" Inherits="ProduceManage.Pages.Produce.Produce_Product_List" EnableViewState ="false" %>

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
  <xxf:PageManager ID="sgmGroup1" runat="server" >
  </xxf:PageManager>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="30">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>&nbsp;</td>
    <td style="padding-right:10px;"><div align="left">
      <table border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td>&nbsp;</td>
        <td ><asp:Button ID="btEnd" runat="server" Text="结束" onclick="btEnd_Click" OnClientClick ="return endInit()" /></td>

          <td width="60"><a href ="Add.aspx" > <img src="../_images/001.gif" alt ="新增" />新增</a></td>
          <td width="60"><a href ="#" onclick ="goEdit('Produce_Product_Add.aspx')" ><img alt ="" src="../_images/114.gif" />修改</a></td>
          <td width="52"><a href ="#" onclick ="goDel()" ><img alt ="" src="../_images/083.gif" />删除
              </a></td>
          
        </tr>
      </table>
    </div></td>
  </tr>
</table>
    </td>
  </tr> 
   <tr>
  <td >
      <input id="Radio1" name ="radion1" type="radio" onclick ="window.location='CurrList.aspx'" /><label for ="Radio1">订单列表</label> 
      <input id="Radio2" name ="radion1" type="radio" checked ="checked"  /><label for ="Radio2">产品列表</label> 
  </td>
  </tr>
  <tr>
  <td >
  <table >
  <tr >
  <td >客户编号：</td>
  <td ><xxf:TextBox ID="tbClientid" runat="server"></xxf:TextBox></td><td >订单编号:</td>
      <td ><xxf:TextBox ID="tbOrderid" runat="server"></xxf:TextBox></td>
      <td ><xxf:SelectButton ID="button1" runat="server" Text="查询"  /></td>
      <td > <asp:Button ID="btPrint" runat="server" Text="导出为EXCEL" onclick="btPrint_Click" />   </td>
 
  </tr>
  </table>
  </td>
  </tr>
  <tr>  
    <td>
    <xxf:Repeater ID="Repeater1" runat="server" EnableTheming ="false" >
    <HeaderTemplate > <table id="table1" class="grid1" width="100%" >
<tr ><th style ="width :22px"><input type ="checkbox" id ="cbCheckAll" onclick="checkAll(this)" /></th>
<th field="ProduceNO" style ="width :80px" >订单号</th >
<th field ="OrderDate" >下单日期</th>
<th field ="OrderDate" >客户交期</th>
<xxf:XxfTh ID="XxfTh1" runat="server" FieldClientCode="产品名称"  FieldSortCode="ProductName"></xxf:XxfTh>
    <th >图纸</th>
    <th >数量</th>
    <th field ="RemainAmount" >剩余数量</th>
    <th >工厂交期</th>
    <th >加工厂</th>
<th >质量员</th>
    <th >操作</th></tr> </HeaderTemplate>
<ItemTemplate >
<tr >
<td style ="width:22px" ><input type ="checkbox" id ="cb<%#Container.ItemIndex%>" onclick="checkedItem('<%#this.Bind<View_Produce_Product>(_=>_.Id) %>','cb<%#Container.ItemIndex%>')" /></td>
<td ><%#this.Bind<View_Produce_Product>(_ => _.ProduceNO )%> </td>
<td ><%#this.Bind<View_Produce_Product>(_ => _.OrderDate .ToShortDateString ())%> </td>
<td ><%#this.Bind<View_Produce_Product>(_ => _.CustDevliDate.HasValue ? _.CustDevliDate.Value .ToShortDateString ():"")%> </td>
<td ><a href ="Produce_Product_Detail.aspx?pptId=<%#this.Bind <View_Produce_Product >(_=>_.Id) %>"><%#this.Bind<View_Produce_Product>(_ => _.ProductName )%></a> </td>
<td ><%#this.Bind<View_Produce_Product>(_ => _.ProudctNO    )%> </td> 
<td ><%#this.Bind<View_Produce_Product>(_ => _.Amount )%> </td> 
<td ><%#this.Bind<View_Produce_Product>(_ => _.RemainAmount )%> </td> 
<td ><%#this.Bind<View_Produce_Product>(_ => _.FactDevliDate.HasValue  ? _.FactDevliDate .Value .ToShortDateString ():""  )%> </td> 
<td ><%#this.Bind<View_Produce_Product>(_ => _.FactoryName  )%> </td> 
<td> </td>
<td class ="action">
<a href ="Schedule_Add.aspx?pptId=<%#this.Bind <View_Produce_Product >(_=>_.Id) %>">进度</a>
<a href ="Delivery_Add.aspx?pptId=<%#this.Bind <View_Produce_Product >(_=>_.Id) %>">交货</a>
</tr>
</ItemTemplate>
<FooterTemplate ></table></FooterTemplate>
  </xxf:Repeater>
 </td>
  </tr>
  <tr>
    <td height="35">
        <xxf:PageBreak ID="PageBreak1" runat="server" />
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

