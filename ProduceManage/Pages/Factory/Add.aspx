<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ProduceManage.Pages.Factory.Add" %>
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
        <table class="style1">
            <tr>
                <td>名称：</td>
                <td><asp:TextBox ID="tbName" runat="server" MaxLength="25"></asp:TextBox></td>
                <td>联系人：</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>电话：</td>
                <td><asp:TextBox ID="tbPhone" runat="server" MaxLength="25"></asp:TextBox></td>
                <td>传真：</td>
                <td><asp:TextBox ID="tbFax" runat="server" MaxLength="25"></asp:TextBox></td>
            </tr>
            <tr>
                <td>手机：</td>
                <td><asp:TextBox ID="tbPhone2" runat="server" MaxLength="25"></asp:TextBox></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>地址：</td>
                <td colspan="3"><asp:TextBox ID="tbAddress" runat="server" MaxLength="50" 
                        Width="308px"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    <uc1:Post ID="Post1" runat="server" OnMyPostEvent ="Addpost" OnMyBackEvent ="Back" />
    </form>
</body>
</html>
