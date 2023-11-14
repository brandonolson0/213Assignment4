using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4.authorized.Instructors
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count != 0)
            {
                foreach (var item in Session.Keys)
                {
                    lblName.Text = Session[item.ToString()].ToString();
                }
            }
        }
    }
}