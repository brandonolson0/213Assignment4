using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


            if (userName == "instructor1" && pass == "instructor1" || userName == "instructor2" && pass == "instructor2"
             || userName == "instructor3" && pass == "instructor3" || userName == "instructor4" && pass == "instructor4"
             || userName == "instructor5" && pass == "instructor5" || userName == "user2" && pass == "user2"
             || userName == "admin" && pass == "admin")
            {

                FormsAuthentication.RedirectFromLoginPage(userName, true);
                Response.Redirect("Instructor.aspx", false);

            }
            else if(userName == "user1" && pass == "user1" || userName == "user4" && pass == "user4"
                 || userName == "brandon" && pass == "brandon" || userName == "karina" && pass == "karina"
                 || userName == "user5" && pass == "user5" || userName == "user6" && pass == "user6"
                 || userName == "user7" && pass == "user7" || userName == "user8" && pass == "user8"
                 || userName == "user9" && pass == "user9" || userName == "user10" && pass == "user10"
                 || userName == "user11" && pass == "user11" || userName == "user12" && pass == "user12")
            {
               // FormsAuthentication.RedirectFromLoginPage(userName, true);
               // Response.Redirect("Member.aspx", false);
            }
            else
                Response.Redirect("Logon.aspx", true);

        }
    }
}