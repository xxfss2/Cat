<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ProduceManage.Pages.Product.Add" %>
<%@ Register src="../Control/Post.ascx" tagname="Post" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link type ="text/css" href ="../_css/Common.css" rel ="Stylesheet"  />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td>产品编号：</td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                <td>产品名称：</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>工艺：</td>
                <td><asp:TextBox ID="txtProcess" runat="server"></asp:TextBox></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <uc1:Post ID="Post1" runat="server" OnMyPostEvent ="Addpost"  />
    </form>
</body>
</html>
