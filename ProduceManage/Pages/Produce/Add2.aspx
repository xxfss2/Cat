<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add2.aspx.cs" Inherits="ProduceManage.Pages.Produce.Add2" %>
<%@ Register src="../Control/Post.ascx" tagname="Post" tagprefix="uc1" %>
<script src="../_js/jquery_1.3.2.js" type="text/javascript"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
        <link type ="text/css" href ="../_css/Common.css" rel ="Stylesheet"  />
        <script language="javascript" type="text/javascript" src="../_DatePicker/WdatePicker.js"></script>
      <script src="../_js/xxf.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
// <!CDATA[
        var count = 1;
        function Button1_onclick(obj) {
            var oldTr = $(obj).parent().parent();
            var newTr = oldTr.clone(); 
            var newTr2 = oldTr.next().clone();
            newTr.children().eq(3).children().eq(1).remove();
            newTr.children().eq(3).children().eq(1).remove();
            oldTr.next().after(newTr);
            newTr2.children().eq(3).children().eq(1).remove();
            newTr2.children().eq(3).children().eq(1).remove();
            newTr.after(newTr2);    
            count++;
        }

        function Button2_onclick(obj) {
            if (count == 1)
                return false;
            $(obj).parent().parent().next().remove();
            count--;
        }

        function PostProduce() {
            var id = $("#tbId").val();
            var clientId = $("#ddlClient").val();
            var date = $("#tbDate").val();
            var factDate = $("#tbFactDate").val();
            var remark = $("#tbRemark").val();
            var products = new Array();
            var currTr = $("#mytable").find("tr").eq(1);
            for (i = 0; i < count; i++) {
                var newProduct = new Object();
                newProduct.ProductId = currTr.find("select").eq(0).val();
                newProduct.Amount = currTr.find("input").eq(0).val();
                currTr = currTr.next();
                newProduct.Material = currTr.children().eq(1).children().eq(0).val();
                newProduct.DrawingId = currTr.children().eq(3).children().eq(0).val();
                products.push(newProduct);
                currTr = currTr.next();
            }
            $.post("Add.aspx", { Action: 1, id: id, clientid: clientId, date: date, factdate: factDate, remark: remark, proudcts: $.toJSON(products) }, function(data) {
            
            });
            return false;
        }
// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table id="mytable">
            <tr>
                <td>订单编号：</td>
                <td><asp:TextBox ID="tbId" runat="server"></asp:TextBox></td>
                <td>客户：</td>
                <td><asp:DropDownList ID="ddlClient" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>产品：</td>
                <td><asp:DropDownList ID="ddlProduct" runat="server"></asp:DropDownList></td>
                <td>数量：</td>
                <td>
                <asp:TextBox ID="tbAmount" runat="server"></asp:TextBox>
                    <input id="Button1" type="button" value="+" onclick="return Button1_onclick(this)" />
                    <input id="Button2"  type="button" value="-" onclick="return Button2_onclick(this)" />
                     </td>
            </tr>
            <tr>
                <td>材料：</td>
                <td><asp:TextBox ID="tbMaterial" runat="server"></asp:TextBox></td>
                <td>图纸：</td>
                <td><asp:TextBox ID="tbDrawingId" runat="server"></asp:TextBox></td>
            </tr>            
             <tr>
                <td>下单日期：</td>
                <td><asp:TextBox ID="tbDate" runat="server" onClick="WdatePicker()" ></asp:TextBox></td>
                <td>工厂下单日期：</td>
                <td><asp:TextBox ID="tbFactDate" runat="server" onClick="WdatePicker()" ></asp:TextBox></td>
            </tr>
              <tr>
                <td>备注：</td>
                <td colspan ="3" ><asp:TextBox ID="tbRemark" runat="server"></asp:TextBox></td>
            </tr>      
        </table>
            <uc1:Post ID="Post1" runat="server" OnMyPostEvent ="Addpost" OnMyBackEvent ="Back" PostClientFunc ="return PostProduce()" />
    </div>
    </form>
</body>
</html>
