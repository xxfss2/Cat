<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProduceProduct.ascx.cs" Inherits="ProduceManage.Pages.Produce.ProduceProduct" %>
<%@ Import Namespace ="Cat.Produce.Core.DomainObjects" %>
<%@ Import Namespace ="Jiuzh.CoreBase" %>
    <tr >
<td colspan ="7" style ="text-align :right " >
<asp:Repeater ID ="Rproducts" runat ="server" >
<HeaderTemplate ><table width ="900px" class="grid2" border="0" cellpadding="0" cellspacing="1" ><tr ><th>产品名称</th><th>材料</th><th>图纸</th><th>下单日期</th><th>生产工厂</th><th>工厂下单日期</th><th>订单数量</th><th>剩余数量</th><th>客户单价</th><th>工厂单价</th><th>操作</th></tr></HeaderTemplate>
<ItemTemplate ><tr>
<td><%#Container.Bind<IProduce_Product >(_=>_.Product .Name) %></td>
<td><%#Container.Bind<IProduce_Product >(_=>_.Material ) %> </td>
<td><%#Container.Bind<IProduce_Product >(_=>_.DrawingId) %> </td>
<td><%#Container.Bind<IProduce_Product >(_=>_.OrderDate .ToShortDateString ()) %> </td>
<td><%#Container.Bind<IProduce_Product >(_=>_.Factory .Name ) %> </td>
<td><%#Container.Bind<IProduce_Product >(_=>_.FactoryOrderDate .HasValue ? _.FactoryOrderDate.Value .ToShortDateString ():"") %> </td>
<td><%#Container.Bind<IProduce_Product >(_=>_.Amount) %> </td>
<td><%#Container.Bind<IProduce_Product >(_=>_.RemainAmount) %> </td>
<td><%#Container.Bind<IProduce_Product >(_=>_.ClientPrice ) %> </td>
<td><%#Container.Bind<IProduce_Product >(_=>_.FactoryPrice ) %> </td>
<td>
<a href ="Schedule_Add.aspx?pptId=<%#Container.Bind<IProduce_Product >(_=>_.Id) %>">进度</a>
<a href ="Delivery_Add.aspx?pptId=<%#Container.Bind<IProduce_Product >(_=>_.Id) %>">交货</a>
</td>
</tr></ItemTemplate>
<FooterTemplate ></table></FooterTemplate>
</asp:Repeater>
</td></tr>