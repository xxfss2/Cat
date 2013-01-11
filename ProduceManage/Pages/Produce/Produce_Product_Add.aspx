<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produce_Product_Add.aspx.cs" Inherits="ProduceManage.Pages.Produce.Produce_Product_Add" %>
<%@ Register src="../Control/Post.ascx" tagname="Post" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
       <link type ="text/css" href ="../_css/Common.css" rel ="Stylesheet"  />
      <script language="javascript" type="text/javascript" src="../_DatePicker/WdatePicker.js"></script>
      <script type ="text/javascript" src ="../_js/jquery_1.3.2.js"></script>
      <script type ="text/javascript" src ="../_js/xxf.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table class="mytable">
            <tr>
                <td>图纸编号：</td>
                <td>
                    <xxf:AutoComplete ID="acProduct" runat="server" 
                        ontextchanged="acProduct_TextChanged" MinStart="2"  ></xxf:AutoComplete>
                </td>
                <td>材料：</td>
                <td><asp:TextBox ID="tbMaterial" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>生产工厂：</td>
                <td>
                    <asp:DropDownList ID="ddlFactroy" runat="server">
                    </asp:DropDownList>
                </td>
                <td>汇率：</td>
                <td><asp:TextBox ID="tbExchange" runat="server"></asp:TextBox></td>
            </tr>            
            <tr>
                <td>数量：</td>
                <td><asp:TextBox ID="tbAmount" runat="server"></asp:TextBox></td>
                <td>图纸：</td>
                <td><asp:TextBox ID="tbDrawingId" runat="server"></asp:TextBox></td>
            </tr>            
             <tr>
                <td>下单日期：</td>
                <td><asp:TextBox ID="tbDate" runat="server" onClick="WdatePicker()"></asp:TextBox></td>
                <td>工厂下单日期：</td>
                <td><asp:TextBox ID="tbFactDate" runat="server" onClick="WdatePicker()"></asp:TextBox></td>
            </tr>
             <tr>
                <td>客户单价：</td>
                <td><asp:TextBox ID="tbClientPrice" runat="server" Width="55px" ></asp:TextBox>
                    <asp:DropDownList ID="ddlMoney" runat="server">
                    </asp:DropDownList>
                 </td>
                <td>工厂单价：</td>
                <td><asp:TextBox ID="tbFactoryPrice" runat="server" ></asp:TextBox></td>
            </tr>
             <tr>
                <td>客户交货日期：</td>
                <td><asp:TextBox ID="tbDateCust" runat="server" onClick="WdatePicker()"></asp:TextBox>
                 </td>
                <td>工厂交货日期：</td>
                <td><asp:TextBox ID="tbDateFact" runat="server" onClick="WdatePicker()"></asp:TextBox>
                 </td>
            </tr>
             <tr>
                <td>质量员：</td>
                <td><asp:TextBox ID="tbQualityer" runat="server" ></asp:TextBox>
                 </td>
                <td>模具费：</td>
                <td><asp:TextBox ID="tbModelPrice" runat="server" ></asp:TextBox>
                 </td>
            </tr>
              </table>
                <div class ="postdiv" >
        <asp:Button ID="Button1" CssClass ="postbt" runat="server" Text="提交" onclick="Button1_Click" />
        <asp:HyperLink ID="lbBack" runat="server">返回</asp:HyperLink>
    </div>
    </div>

    </form>
</body>
</html>
