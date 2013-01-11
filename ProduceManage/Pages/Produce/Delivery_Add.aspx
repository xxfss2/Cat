<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delivery_Add.aspx.cs" Inherits="ProduceManage.Pages.Produce.Delivery_Add" %>
<%@ Register src="../Control/Post.ascx" tagname="Post" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link type ="text/css" href ="../_css/Common.css" rel ="Stylesheet"  />
    <script language="javascript" type="text/javascript" src="../_DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table>
            <tr>
                <td>订单编号：</td>
                <td>
                    <asp:Literal ID="lId" runat="server"></asp:Literal>
                </td>
                <td>产品：</td>
                <td>
                    <asp:Literal ID="lName" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>数量：</td>
                <td><asp:TextBox ID="tbAmount" runat="server"></asp:TextBox></td>
                <td>日期：</td>
                <td><asp:TextBox ID="tbDate" runat="server"  onClick="WdatePicker()" ></asp:TextBox></td>
            </tr>            
            <tr>
                <td>交货方式：</td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server">
                    </asp:DropDownList>
                </td>
                <td>发票：</td>
                <td><asp:TextBox ID="tbInvoice" runat="server"></asp:TextBox></td>
            </tr>            
              <tr>
                <td>HS编码：</td>
                <td ><asp:TextBox ID="tbCode" runat="server"></asp:TextBox></td>
                 <td>&nbsp;</td>
                <td >&nbsp;</td>
            </tr>      
        </table>
            <uc1:Post ID="Post1" runat="server" OnMyPostEvent ="Addpost" OnMyBackEvent="Back" />
    </div>
    </form>
</body>
</html>
