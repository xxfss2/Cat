<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ProduceManage.Pages.Produce.Add" %>
<%@ Register src="../Control/Post.ascx" tagname="Post" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
        <link type ="text/css" href ="../_css/Common.css" rel ="Stylesheet"  />
        <script src="../_js/jquery_1.3.2.js" type="text/javascript"></script>
        <script language="javascript" type="text/javascript" src="../_DatePicker/WdatePicker.js"></script>
      <script src="../_js/xxf.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table class="mytable">
            <tr>
                <td class ="left" >订单编号：</td>
                <td><asp:TextBox ID="tbId" runat="server"></asp:TextBox></td>
                <td class ="left">客户编号：</td>
                <td><asp:DropDownList ID="ddlClient" runat="server"></asp:DropDownList></td>
            </tr>
              <tr>
                <td class ="left">备注：</td>
                <td colspan ="3" ><asp:TextBox ID="tbRemark" runat="server"></asp:TextBox></td>
            </tr>      
        </table>
            <uc1:Post ID="Post1" runat="server" OnMyPostEvent ="Addpost" />
    </div>
    </form>
</body>
</html>
