using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            // grab the username and password passed through the login control
            string userName = Login1.UserName;
            string pass = Login1.Password;

            // connection string
            string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\brand\\Desktop\\213Assignment4\\213Assignment4\\Assignment4\\App_Data\\KarateSchool.mdf;Integrated Security=True";
            //string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\karina\\OneDrive - North Dakota University System\\Desktop\\213\\213Assignment4\\213Assignment4\\Assignment4\\App_Data\\KarateSchool.mdf;Integrated Security=True"; 
            KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn);

            // search through the NetUsers db for a matching username
            var result = from x in dbcon.NetUsers
                         where x.UserName == userName
                         select x;

            // if a match is found, check for password match
            if (result.Count() > 0)
            {
                foreach (var x in result)
                {
                    if(x.UserPassword == pass)
                    {
                        // add respective usertypes' first and last name to the session
                        if(x.UserType == "Instructor")
                        {
                            Session.Add(x.UserID.ToString(), x.Instructor.InstructorFirstName + " " + x.Instructor.InstructorLastName);
                        }
                        else if(x.UserType == "Member")
                        {
                            Session.Add(x.UserID.ToString(), x.Member.MemberFirstName + " " + x.Member.MemberLastName);
                        }
                        else
                        {
                            // administrator account
                            Session.Add(x.UserID.ToString(), "Admin Account");
                        }
                        
                        // redirect to respective page for the usertype
                        FormsAuthentication.RedirectFromLoginPage(userName, true);
                        Response.Redirect("Authorized/" + x.UserType + "s/Home.aspx", true);
                    }
                }
            }
            else
                // if no matches are found, redirect to login page for retry
                Response.Redirect("Login.aspx", true);
        }
    }
}