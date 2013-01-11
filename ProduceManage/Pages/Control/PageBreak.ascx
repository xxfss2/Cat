<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageBreak.ascx.cs" Inherits="ProduceManage.Pages.Control.PageBreak" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="25%" height="29" nowrap="nowrap"><table width="342" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="44%">当前页：<span id ="<%=this.ScriptId %>_pageinfo" ><%=Break_Param.PageIndex + 1%>/<%=PageCount%></span>页 每页 
              <input  name="textfield2" type="text" style="height:14px; width:25px;" value="<%=Break_Param.PageSize %>" size="5" /></td>
            <td width="14%"><img src="../_images/sz.gif" width="43" height="20" onclick ="<%=this.ScriptId %>.setPageSize(this)" alt ="设置每页条数" /></td>
            <td id="<%=this.ScriptId %>_datacount" width="42%">总共 <%=Break_Param.DataCount%> 条记录</td>
          </tr>
        </table></td>
        <td width="75%" valign="top"><div align="right">
            <table class ="pageBreak2" width="352" height="20" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td width="50" ><img src="../_images/page_first_1.gif" alt ="首页" onclick ="<%=this.ScriptId %>.firstPage()" /></td>
                <td width="50" ><img src="../_images/page_back_1.gif" alt ="上一页" onclick ="<%=this.ScriptId %>.prevPage()" /></td>
                <td width="54" ><img src="../_images/page_next.gif" alt ="下一页" onclick ="<%=this.ScriptId %>.nextPage()" /></td>
                <td width="49" ><img src="../_images/page_last.gif" alt ="尾页" onclick ="<%=this.ScriptId %>.lastPage()"  /></td>
                <td width="59" >转到第</td>
                <td width="25" ><input name="textfield" type="text" style="height:10px; width:25px;" size="5" /></td>
                <td width="23" >页</td>
                <td width="30" ><img src="../_images/go.gif" onclick ="BKjump(this)" alt ="跳转至某页" /></td>
              </tr>
            </table>
        </div></td>
      </tr>
</table>

<script type ="text/javascript" >
//    function xxf_PageBreak(id,size,index,count,sizeCode,indexCode,sortfieldCode,sortruleCode,repeaterId){
//        this.pageSizeCode=sizeCode;
//        this.pageIndexCode=indexCode;
//        this.sortFieldCode=sortfieldCode;
//        this.sortRuleCode=sortruleCode;
//        this.clientId=id ;
//        this.pageSize=size ;
//        this.pageIndex=index ;
//        this.dataCount=count ;
//        this.pageCount = Math.ceil(this.dataCount / this.pageSize);
//        //排序URL
//        this.sortQuery = "";
//        //上一次排序的字段名称
//        this.currSortField = "";
//        //排序规格，降序OR升序
//        this.sortRule = 0;
//        this.repeaterId = repeaterId;
//        this.selectQuery = '';
//        
//        var wu_url=window.location.href;
//        var wu_nopar=wu_url.split("?")[0].split("/");
//        this.pageName=wu_nopar[wu_nopar.length-1]; 
//    }
//    xxf_PageBreak.prototype.dataBind = function(selectStr) {
//        this.selectQuery = selectStr;
//        var obj = this;
//        var url = this.pageName + "?xxf_action=ajax&" + this.pageSizeCode + "=" + this.pageSize + "&" + this.pageIndexCode + "=" + this.pageIndex + selectStr + this.sortQuery;
//        $.getJSON(url, false, function(data) {
//            $("#" + obj.repeaterId).html(data[0]);
//            obj.dataCount = data[1];
//            obj.pageCount = Math.ceil(obj.dataCount / obj.pageSize);
//            $("#" + obj.clientId + "_pageinfo").html((obj.pageIndex + 1) + "/" + obj.pageCount);
//            $("#" + obj.clientId + "_datacount").html("总共 " + obj.dataCount + " 条记录");
//            //隔行变色、鼠标移过变色
//            obj.tableInit();
//            obj.sortInit();
//        });
//        return false;
//    }
//    xxf_PageBreak.prototype.firstPage = function() {
//        if (this.pageIndex == 0)
//            return;
//        this.pageIndex = 0;
//        this.dataBind(this.selectQuery);
//    }
//    xxf_PageBreak.prototype.nextPage = function() {
//        if (this.pageIndex == (this.pageCount - 1))
//            return;
//        this.pageIndex++;
//        this.dataBind(this.selectQuery);
//    }
//    xxf_PageBreak.prototype.prevPage = function() {
//        if (this.pageIndex == 0)
//            return;
//        this.pageIndex--;
//        this.dataBind(this.selectQuery);
//    }
//    xxf_PageBreak.prototype.lastPage = function() {
//        if (this.pageIndex == (this.pageCount - 1))
//            return;
//        this.pageIndex = this.pageCount - 1;
//        this.dataBind(this.selectQuery);
//    }
//    xxf_PageBreak.prototype.setPageSize = function(obj) {
//        this.pageSize = $(obj).parent().prev().children().eq(1).val();
//        this.dataBind(this.selectQuery);
//    }
//    xxf_PageBreak.prototype.sort = function(field) {
//        if (field == this.currSortField) {
//            if (this.sortRule == 1)
//                this.sortRule = 0;
//            else
//                this.sortRule = 1;
//        }
//        this.sortQuery = "&"+this.sortFieldCode+"=" + field + "&"+this.sortRuleCode+"=" + this.sortRule;
//        this.currSortField = field;
//        this.dataBind(this.selectQuery);
//    }
//    
//     xxf_PageBreak.prototype.tableInit=function () {
//     var index = 1;
//     $("#"+this.repeaterId).find("tr").each(function() {
//         index++;
//         if (index % 2 == 0) {
//             $(this).attr("class", "gg").hover(function() {
//                 $(this).css({ 'background-color': '#E3FFC9' });
//             }, function() {
//                 $(this).css({ 'background-color': '#f3f3f3' });
//             }); ;
//         }
//         else {
//             $(this).attr("class", "wg").hover(function() {
//                 $(this).css({ 'background-color': '#E3FFC9' });
//             }, function() {
//                 $(this).css({ 'background-color': '#FFFFFF' });
//             });
//         }
//     });
// }
//    
//    xxf_PageBreak.prototype.sortInit=function () {
//        var control=$("#"+this.repeaterId).children().eq(0);
//        var obj=this;
//        if(control.length<=0)
//            return ;
//        var thRow = control.children().eq(0).find("th[field]");
//        thRow.each(function() {
//            var th=$(this);
//            th.css({ 'cursor': 'hand' });
//            var field=th.attr("field");
//            $(this).bind("click",function (){
//                obj.sort(field);
//            });
//        }); 
//    }

//    function BKjump(obj){
//        pageindex =$(obj ).parent().prev().prev().children().eq(0).val()-1;      
//    }

</script>