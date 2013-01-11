<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ProduceManage.Pages.Customer.Add" %>
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
                <td>客户编号：</td>
                <td><asp:TextBox ID="TextBox2" runat="server" MaxLength="4"></asp:TextBox></td>
                <td>客户名称：</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>联系人：</td>
                <td><asp:TextBox ID="tbcontact" runat="server" MaxLength="10"></asp:TextBox></td>
                <td>电话：</td>
                <td><asp:TextBox ID="tbphone" runat="server" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td>邮件地址：</td>
                <td><asp:TextBox ID="tbMail" runat="server" MaxLength="40"></asp:TextBox></td>
                <td>地址：</td>
                <td><asp:TextBox ID="tbAddress" runat="server" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td>网址：</td>
                <td colspan ="3"><asp:TextBox ID="txtSite" runat="server" MaxLength="40" 
                        Width="310px"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    <uc1:Post ID="Post1" runat="server" OnMyPostEvent ="Addpost" />
    </form>
</body>
</html>
