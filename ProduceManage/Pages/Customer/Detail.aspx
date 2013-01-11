<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="ProduceManage.Pages.Customer.Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>  
      <link type ="text/css" href ="../_css/Common.css" rel ="Stylesheet"  />
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table class="mytable">
            <tr>
                <td>客户编号：</td>
                <td>
                    <asp:Literal ID="lcode" runat="server"></asp:Literal>
                </td>
                <td>客户名称：</td>
                <td>
                    <asp:Literal ID="lName" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>联系人：</td>
                <td>
                    <asp:Literal ID="lContact" runat="server"></asp:Literal>
                </td>
                <td>电话：</td>
                <td>
                    <asp:Literal ID="lPhone" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>邮件地址：</td>
                <td>
                    <asp:Literal ID="lEmal" runat="server"></asp:Literal>
                </td>
                <td>地址：</td>
                <td>
                    <asp:Literal ID="lAddress" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>网址：</td>
                <td colspan ="3">
                    <asp:Literal ID="lSite" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
            <div class ="postdiv" >
        <asp:HyperLink ID="lbBack" runat="server">返回</asp:HyperLink>
        </div> 
    </div>
    </form>
</body>
</html>
