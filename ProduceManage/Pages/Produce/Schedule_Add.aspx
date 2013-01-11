<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schedule_Add.aspx.cs" Inherits="ProduceManage.Pages.Produce.Schedule_Add" %>
<%@ Register src="../Control/Post.ascx" tagname="Post" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
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
                <td>产品名称：</td>
                <td>
                    <asp:Literal ID="lName" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>日期：</td>
                <td><asp:TextBox ID="tbDate" runat="server" onClick="WdatePicker()" ></asp:TextBox></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>            
              <tr>
                <td>进度：</td>
                <td colspan ="3" ><asp:TextBox ID="tbRemark" runat="server"></asp:TextBox></td>
            </tr>      
        </table>
            <uc1:Post ID="Post1" runat="server" OnMyPostEvent ="Addpost" OnMyBackEvent ="Back"  />
    </div>
    </form>
</body>
</html>
