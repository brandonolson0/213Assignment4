using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName = Login1.UserName;
            string pass = Login1.Password;




            if (userName == "cat" && pass == "cat")
            {

                FormsAuthentication.RedirectFromLoginPage(userName, true);


            }
            else
                Response.Redirect("Logon.aspx", true);

        }
    }
}