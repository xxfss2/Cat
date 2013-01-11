using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProduceManage.Pages.Control
{
    public partial class Post : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PostClientFunc != null)
                this.Button1.Attributes.Add("onclick", PostClientFunc);
        }

        public bool HasPost
        {
            get
            {
                return Button1.Visible;
            }
            set
            {
                Button1 .Visible=value ;
            }
        }
        public string PostClientFunc{ get; set; }

        public event Action MyPostEvent;
        public Action MyPost { get; set; }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MyPostEvent();
           // MyPost();
        }

        public string BackURL
        {
            get
            {
                return lbBack.NavigateUrl ;
            }
            set
            {
                lbBack.NavigateUrl = value;
            }
        }
    }
}