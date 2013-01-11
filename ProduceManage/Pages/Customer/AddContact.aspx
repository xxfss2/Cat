<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddContact.aspx.cs" Inherits="ProduceManage.Pages.Customer.AddContact" %>
<%@ Register src="../Control/Post.ascx" tagname="Post" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link type ="text/css" href ="../_css/Common.css" rel ="Stylesheet"  />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>名称：</td>
                <td><asp:TextBox ID="tbName" runat="server" MaxLength="4"></asp:TextBox></td>
                <td>电话：</td>
                <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>E-Mail：</td>
                <td><asp:TextBox ID="tbMail" runat="server" MaxLength="10"></asp:TextBox></td>
                <td>地址：</td>
                <td><asp:TextBox ID="tbAddress" runat="server" MaxLength="20"></asp:TextBox></td>
            </tr>
            </table>
    </div>
    <uc1:Post ID="Post1" runat="server" OnMyPostEvent ="Addpost" />
    </form>
</body>
</html>
