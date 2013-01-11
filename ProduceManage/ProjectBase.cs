using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Xxf.Core;
using System.Collections;


public class PageBase : System.Web.UI.Page
{
    protected UserCore _user = new UserCore();
    /// <summary>
    /// 网址发布到IIS上课删除以下此重写
    /// </summary>
    /// <param name="context"></param>
    public override void ProcessRequest(HttpContext context)
    {
        base.ProcessRequest(context);
        context.Request.InputStream.ReadByte();
    }

    protected override void OnPreInit(EventArgs e)
    {
        if (!_user.CheckLogin())
        {
            Response.Write("<script  language='javascript'>window.top.location.href='/Default.aspx';</script>");
            Response.End();
        }
        base.OnPreInit(e);
    }
    protected override void OnInit(EventArgs e)
    {
       // Session["prevURL"] = Request.Url.PathAndQuery;
    }

    protected void SaveCurrURL(bool first)
    {
        if (Session["prevURL"] == null)
            Session["prevURL"] = new string[3];
        string[] urls = (string[])Session["prevURL"];
        if (first)
        {
            urls[0] = Request.Url.PathAndQuery;
            urls[1] = null;
            urls[2] = null;
        }
        else
        {
            if (urls[1] == null)
                urls[1] = Request.Url.PathAndQuery;
            else if (urls[2] == null)
                urls[2] = Request.Url.PathAndQuery;
            else
                urls[2] = null;
        }
        Session["prevURL"] = urls;
    }
    /// <summary>
    /// 获取上次保存的URL
    /// </summary>
    /// <returns></returns>
    protected string  GetCurrURL()
    {
        string[] urls = (string[])Session["prevURL"];
        for (int i = 2; i >= 0; i--)
        {
            if (urls[i] != null)
            {
                string url = urls[i-1];
                Session["prevURL"] = urls;
                return url;
            }
        }
        throw new Exception("");
    }

    /// <summary>
    /// 判断是否异步提交
    /// </summary>
    protected bool IsAsynPost
    {
        get
        {
            if (Request.HttpMethod == "POST" && !IsPostBack )
                return true;
            return false;
        }
    }

}

