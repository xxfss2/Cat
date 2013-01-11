/*
*扩展模块
*/

Array.prototype.find = function (ele) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] == ele)
            return true;
    }
    return false;
}

Array.prototype.remove = function (ele) {
    for (i = 0; i < this.length; i++) {
        if (this[i] == ele) {
            this.splice(i, 1);
        }
    }
}


/*
*Xxf模块，该模块以JQUERY为基础
*/
var Xxf;
if (Xxf) { throw new Error('Xxf命名空间与全局变量冲突'); }
//Xxf顶级命名空间
Xxf = {};



//Xxf.Common命名空间，保存一些公共的工具对象和函数
Xxf.Common = {};
//StringBuilder类
Xxf.Common.StringBuilder = function () {
    this._strings = new Array();
}
Xxf.Common.StringBuilder.prototype.append = function (str) {
    this._strings.push(str);
}
Xxf.Common.StringBuilder.prototype.toString = function () {
    return this._strings.join("");
};



//Xxf.ListPage命名空间，保存用于在列表页面中用到的变量和常用函数
Xxf.ListPage = {};
//保存选中的行的主键（Id）
Xxf.ListPage.selectedIds = new Array();
//保存最近选中的控件的对象
Xxf.ListPage.currChk;
//用于Radio的单选
Xxf.ListPage.singleCheck = function (id, cbId) {
    var cb = $("#" + cbId);
    if (cb.attr("checked") == true) {
        Xxf.ListPage.selectedIds = id;
        Xxf.ListPage.currChk = cb;
    }
}

 Xxf.Checks = function(tbId) {
     this.chks = [];
     this.tb = $("#" + tbId);
     this.currChk = null;
 }
 Xxf.Checks.prototype.multiCheck = function(id, cbId) {
     var cb = $("#" + cbId);
     if (cb.attr("checked") == true) {
         this.chks.push(id);
         this.currChk = cb;
     }
     else {
         for (i = 0; i < this.chks.length; i++) {
             if (this.chks[i] == id) {
                 this.chks.splice(i, 1);
             }
         }
     }
 }
 //全选　全不选
 Xxf.Checks.prototype.checkAll = function(chk) {
    var ddl = $(chk);
     if (ddl.attr("checked") == true) {
         $('input:checkbox').each(function() {
             if ($(this).attr("checked") == false) {
                 $(this).click();
             }
         });
     }
     else {
         $('input:checkbox[checked]').attr("checked", false);
         this.chks.length = 0;
     }
 }


 Xxf.Tab = function(div) {
     this.isLoaded = false;
     this.divObj = $("#" + div);
     //
     this.fns = [];
     this.fnObjs = [];
 }
 Xxf.Tab.CurrDiv = null;
 Xxf.Tab.prototype = {
     show: function() {
         if (this.divObj.is(":visible") == true)
             return;
         this.divObj.show();
         if (Xxf.Tab.CurrDiv != null) {
             Xxf.Tab.CurrDiv.hide();
         }
         Xxf.Tab.CurrDiv = this.divObj;
         if (this.isLoaded == false) {
             this.update();
             this.isLoaded = true;
         }

     },
     subscribe: function(fn, obj) {
         this.fns.push(fn);
         this.fnObjs.push(obj);
     },
     update: function(o, thisObj) {
         var scope = thisObj || window;
         for (var i = 0; i < this.fns.length; i++) {
             this.fns[i].call(this.fnObjs[i], o);
         }
     }
 }


 Xxf.PageBreak = function (id, size, index, count, repeaterId) {
     this.pageSizeCode = "xxf_pagesize";
     this.pageIndexCode = "xxf_pageindex";
     this.sortFieldCode = "xxf_sortfield";
     this.sortRuleCode = "xxf_sortrule";
     this.clientId = id;
     this.pageSize = size;
     this.pageIndex = index;
     this.dataCount = count;
     this.pageCount = Math.ceil(this.dataCount / this.pageSize);
     //排序URL
     this.sortQuery = "";
     //上一次排序的字段名称
     this.currSortField = "";
     //排序规格，降序OR升序
     this.sortRule = 0;
     this.repeaterId = repeaterId;
     this.pageName = window.location.href;
     this.param = {};
     this.param["__EVENTTARGET"] = this.repeaterId;
     this.param[this.repeaterId] = "";
 }

 Xxf.PageBreak.prototype.dataBind = function() {
     var obj = this;
     this.param[this.pageSizeCode] = this.pageSize;
     this.param[this.pageIndexCode] = this.pageIndex;
     this.param[this.sortFieldCode] = this.currSortField;
     this.param[this.sortRuleCode] = this.sortRule;
     $.ajax({
         type: "POST",
         url: obj.pageName,
         dataType: "json",
         cache: false,
         data: obj.param,
         success: function(data) {
             $("#" + obj.repeaterId).html(data[0]);
             obj.dataCount = data[1];
             obj.pageCount = Math.ceil(obj.dataCount / obj.pageSize);
             $("#" + obj.clientId + "_currpage").val(1 + obj.pageIndex);
             $("#" + obj.clientId + "_pagesize").val(obj.pageSize);
             $("#" + obj.clientId + "_datacount").html(obj.dataCount);
             $("#" + obj.clientId + "_pagecount").html(obj.pageCount);
             //隔行变色、鼠标移过变色
             obj.tableInit();
             obj.sortInit();
         },
         error: function(XMLHttpRequest, textStatus, errorThrown) { alert(XMLHttpRequest); }
     });
     return false;
 }
 Xxf.PageBreak.prototype.firstPage = function () {
     if (this.pageIndex == 0)
         return;
     this.pageIndex = 0;
     this.dataBind(this.selectQuery);
 }
 Xxf.PageBreak.prototype.nextPage = function () {
     if (this.pageIndex == (this.pageCount - 1))
         return;
     this.pageIndex++;
     this.dataBind();
 }
 Xxf.PageBreak.prototype.prevPage = function () {
     if (this.pageIndex == 0)
         return;
     this.pageIndex--;
     this.dataBind();
 }
 Xxf.PageBreak.prototype.lastPage = function () {
     if (this.pageIndex == (this.pageCount - 1))
         return;
     this.pageIndex = this.pageCount - 1;
     this.dataBind();
 }
 Xxf.PageBreak.prototype.setPageSize = function (obj) {
     this.pageSize = $("#" + this.clientId + "_pagesize").val();
     this.dataBind();
 }
 Xxf.PageBreak.prototype.setPageIndex = function() {
 this.pageIndex = parseInt($("#" + this.clientId + "_currpage").val()) - 1;
     this.dataBind();
 }
 Xxf.PageBreak.prototype.sort = function (field) {
     if (field == this.currSortField) {
         if (this.sortRule == 1)
             this.sortRule = 0;
         else
             this.sortRule = 1;
     }
     this.currSortField = field;
     this.dataBind();
 }

 Xxf.PageBreak.prototype.tableInit = function () {
     var index = 0;
     $("#" + this.repeaterId).find("tr").each(function () {
         index++;
         if (index == 1)
             return true;
         var cls = "in2";
         if (index % 2 == 0)
             cls = "in3";
         $(this).attr("class", cls).hover(function () {
             $(this).addClass('JZhr');
         }, function () {
             $(this).removeClass('JZhr');
         }); ;
     });
 }

 Xxf.PageBreak.prototype.sortInit = function () {
     var control = $("#" + this.repeaterId).children().eq(0);
     var obj = this;
     if (control.length <= 0)
         return;
     var thRow = control.children().eq(0).find("th[field]");
     thRow.each(function () {
         var th = $(this);
         th.css({ 'cursor': 'hand' });
         var field = th.attr("field");
         $(this).bind("click", function () {
             obj.sort(field);
         });
     });
 }

 function showPage(src) {
     var de = document.documentElement;
     var w = window.innerWidth || self.innerWidth || (de && de.clientWidth) || document.body.clientWidth;
     var h = window.innerHeight || self.innerHeight || (de && de.clientHeight) || document.body.clientHeight;
     var BacterSche = document.getElementById('Bacter');
     var bgcontent = document.getElementById('bgcontent');
     var iframeBacter = document.getElementById('iframeBacter');
     iframeBacter.src = src;
     if (bgcontent.style.display == '') {
         BacterSche.style.display = 'none';
         bgcontent.style.display = 'none';
     } else {
         bgcontent.style.width = w + 'px';
         bgcontent.style.height = h + 'px';
         //BacterSche.style.left = (w - 820) / 2 + 'px';
         BacterSche.style.left = '5px';
         BacterSche.style.top = '42px';
         BacterSche.style.display = '';
         bgcontent.style.display = '';
     }
 }


 function AutoComplate(obj, len, param) {
     var ctl = $(obj);
     var val = ctl.val();
     var ctlId = ctl.attr("id");
     if (val.length == 0) {
         $("#" + ctlId + "_Auto").hide();
         return;
     }
     if (val.length < len)
         return;
     var div = $("#" + ctlId + "_Auto");
     if (div.length == 0) {
         div = $("<div id=\"" + ctlId + "_Auto\" style =\"position:absolute; display:none; border:1px solid #817f82; background-color:#ffffff; width:200px\"></div>");
         $('body').append(div);
     }
     param["__EVENTTARGET"] = ctlId;
     param[ctlId] = val;
     var wu_nopar = window.location.href.split("?")[0].split("/");
     var pageName = wu_nopar[wu_nopar.length - 1];
     $.post(pageName + "?action=list", param, function (data) {
         var result = eval(data);
         if (result.length > 0) {
             div.html("");
             var table = $("<table style='width:100%' ><tbody></tbody></table>");
             for (var i = 0; i < result.length; i++) {
                 var tr = $("<tr><td >" + result[i] + "</td></tr>");
                 tr.mouseover(function () {
                     $(this).addClass('JZac');
                 });
                 tr.mouseout(function () {
                     $(this).removeClass('JZac');
                 });
                 tr.click(function () {
                     $(obj).val($(this).children().eq(0).html());
                     div.hide();
                 });
                 table.append(tr);
             }
             div.append(table);
             var of = $(obj).offset();
             var top = of.top + $(obj).height();
             div.css("top", top + 5);
             div.css("left", of.left);
             div.width($(obj).width());
             div.show();
         }
         else
             div.hide();
     });
 }
