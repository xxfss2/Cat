using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI ;
using System.Web;
using System.Web.Script.Serialization;

namespace Xxf.Helper
{
    public static class UIHelper
    {
        public static object Bind<IView>(this Page page, Func<IView, object> func)
        {
            return func((IView)page.GetDataItem());
        }
        public static List <int> SplitInt(this string str, char parameter)
        {
            return str.Split(parameter).Select(s => Convert.ToInt32(s)).ToList();
        }

        //public static void DataBind(this Control control, int datacount)
        //{
        //    control.DataBind();
        //    HttpContext.Current .Response.Clear();
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    System.IO.StringWriter tw = new System.IO.StringWriter(sb);
        //    HtmlTextWriter htw = new HtmlTextWriter(tw);

        //    control.RenderControl(htw);
        //    string[] result = new string[2];
        //    result[0] = sb.ToString();
        //    result[1] = datacount.ToString ();
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    string resultStr = serializer.Serialize(result);
        //    HttpContext.Current.Response.ContentType = "application/json;charset=UTF-8";
        //    HttpContext.Current.Response.Write(resultStr);
        //    HttpContext.Current.Response.End();
        //}
    }
}
