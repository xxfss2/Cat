<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaseButton.ascx.cs" Inherits="ProduceManage.Pages.Control.BaseButton" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>&nbsp;</td>
    <td style="padding-right:10px;"><div align="left">
      <table border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td width="60"><a href ="Add.aspx" > <img src="../_images/001.gif" alt ="新增" />新增</a></td>
          <td width="60"><a href ="#" onclick ="goEdit('<%=EditAspx %>')" ><img alt ="" src="../_images/114.gif" />修改</a></td>
          <td width="52"><a href ="#" onclick ="goDel()" ><img alt ="" src="../_images/083.gif" />删除</a></td>
        </tr>
      </table>
    </div></td>
  </tr>
</table>