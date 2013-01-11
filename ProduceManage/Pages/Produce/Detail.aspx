<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="ProduceManage.Pages.Produce.Detail" %>
<%@ Register src="../Control/Post.ascx" tagname="Post" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace ="Cat.Produce.Core.DomainObjects" %>
<%@ Import Namespace ="Xxf.Helper" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link type ="text/css" href ="../_css/Common.css" rel ="Stylesheet"  />
    <script type ="text/javascript" src ="../_js/jquery.js"></script>
    <style type ="text/css" >
    div#main {
	width:800px;
	text-align :center ;
	background-color :#EEF2FB;
}

div.title
{
	font-size:16px;
	font-weight:600;
	height:25px;
	line-height :25px;
	vertical-align :middle ;
	border:solid 1px #C9C9C9;
	text-align :left ;
	text-indent :10px;
	background-color :White ;
}

div.non {
	height:10px;
}
div#form 
{
	text-align :center ;
}

div#form table
{
	width:790px;
    border:solid 1px #C9C9C9;
    border-collapse:collapse;
    background-color :White ;
}

div#form table tr td.tdleft
{
	height :25px;
	border:1px solid #C9C9C9;
	font-weight :bold;
	text-align :right;
}

div#form table tr td.tdright
{
	width :30%;
	height :25px;
	border:1px solid #C9C9C9;
	text-align :left ;
	text-indent :10px;
}

.sec1 {
	CURSOR: hand;
	COLOR: #000000;
	font-family: Arial, Helvetica, sans-serif;
	height :25px;
	line-height:25px;
	width:80px;
	border: 1px solid #B5D0D9;
	background-image: url('../images/right_smbg.jpg');
	background-repeat: repeat-x;
	float :left ;
}
.sec2 {
	FONT-WEIGHT: bold;
	CURSOR: hand;
	COLOR: #000000;
	font-family: Arial, Helvetica, sans-serif;
	height :25px;
	line-height:25px;
	width:80px;
	background-color: #e2e7ed;
	border: 1px solid #e2e7ed;
	float :left ;
}

div.tab
{
		border:solid 1px #C9C9C9; line-height :25px; text-align :left; background-color :White ;
		padding-left :30px;
		height :200px;
}
div.tab table tr td,th
{
		border-bottom:1px solid #C9C9C9;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
    <div class="title" >订单详细信息</div>
    <div class="non" ></div>
    <div id="form">
        <table  cellspacing ="0" cellpadding ="0" border ="0">
        <tr>
            <td class ="tdleft">订单编号：</td>
            <td class ="tdright">
                <asp:Literal ID="lId" runat="server"></asp:Literal>
            </td>
            <td class ="tdleft">客户：</td>
            <td class ="tdright">
                <asp:Literal ID="lCustom" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class ="tdleft">图纸：</td>
            <td class ="tdright">
                <asp:Literal ID="lDraw" runat="server"></asp:Literal>
            </td>
            <td class ="tdleft">材料：</td>
            <td class ="tdright">
                <asp:Literal ID="lMaterial" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class ="tdleft" colspan="4">
                &nbsp;</td>
        </tr>            
         <tr>
            <td class ="tdleft">下单日期：</td>
            <td class ="tdright">
                <asp:Literal ID="lDate" runat="server"></asp:Literal>
             </td>
            <td class ="tdleft">工厂下单日期：</td>
            <td class ="tdright">
                <asp:Literal ID="lProdate" runat="server"></asp:Literal>
             </td>
        </tr>
          <tr>
            <td class ="tdleft" style ="height :50px" >备注：</td>
            <td class ="tdright" colspan ="3" style ="height :50px" >
                <asp:Literal ID="lRemark" runat="server"></asp:Literal>
              </td>
        </tr>      
    </table>
    </div>
    <div class="non" ></div>
    <div style ="height :25px; background-color :White ;	border:1px solid #C9C9C9;">
    <div id ="show1" onclick ="show1()" class ="sec2" >交货信息</div>
    <div id="show2" onclick ="show2()" class ="sec1" >进度</div>
    </div>
        
    <div class ="tab" id="delivery"  >
                <asp:Repeater ID="Rproducts" runat="server">
                <HeaderTemplate ><table><tr ><th >产品名称</th><th >数量</th></tr></HeaderTemplate>
                <ItemTemplate ><tr><td></td><td></td></tr></ItemTemplate>
                <FooterTemplate ></table></FooterTemplate>
                </asp:Repeater>
        <asp:Repeater ID="rDelivery" runat="server">
        <HeaderTemplate ><table cellspacing ="0" cellpadding ="0" border ="0" width ="300px" ><tr ><th >日期</th><th >数量</th><th >发货方式</th></tr></HeaderTemplate>
        <ItemTemplate ><tr><td><%#this.Bind <IDeliverys >(_=>_.DDate.ToShortDateString ())%></td> 
          <td><%#this.Bind <IDeliverys >(_=>_.Amount)%>  </td>
          <td><%#this.Bind <IDeliverys >(_=>_.TypeName)%></td></tr></ItemTemplate>
        <FooterTemplate ></table></FooterTemplate>
        </asp:Repeater>
        </div>
    <div class ="tab" id="schedule" >
        <asp:Repeater ID="rSchedule" runat="server">
         <HeaderTemplate ><table cellspacing ="0" cellpadding ="0" border ="0" width ="300px" ><tr ><th >日期</th><th >描述</th></tr></HeaderTemplate>
        <ItemTemplate ><tr><td><%#this.Bind <IProSchedule >(_=>_.Date.ToShortDateString ())%> </td>
         <td><%#this.Bind <IProSchedule >(_=>_.Remark )%></td></tr></ItemTemplate>
        <FooterTemplate ></table></FooterTemplate>
        </asp:Repeater>
        </div>

        <uc1:Post ID="Post1" runat="server" HasPost="false" OnMyBackEvent="Back"  />
    </div>
    </form>
    
    <script type ="text/javascript" >
        function show1() {
            $("#delivery").show();
            $("#schedule").hide();
            $("#show1").attr("class", "sec2");
            $("#show2").attr("class", "sec1");
        }
        function show2() {
            $("#delivery").hide();
            $("#schedule").show();
            $("#show1").attr("class", "sec1");
            $("#show2").attr("class", "sec2");
        }

        show1();
    </script>
</body>
</html>
