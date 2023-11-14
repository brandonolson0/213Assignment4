using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4.authorized.Administrators
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check for Session Items
            if (Session.Count != 0)
            {
                foreach (var item in Session.Keys)
                {
                    // Populate the label with the user's first and last name
                    lblName.Text = Session[item.ToString()].ToString();
                }
            }

            // Connection String
            string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\brand\\Desktop\\213Assignment4\\213Assignment4\\Assignment4\\App_Data\\KarateSchool.mdf;Integrated Security=True";
            //string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\karina\\OneDrive - North Dakota University System\\Desktop\\213\\213Assignment4\\Assignment4\\App_Data\\KarateSchool.mdf\";Integrated Security=True";
            KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn);

            // Select the first and last name, phone number and date joined from all members
            var result = from x in dbcon.Members
                         select new { x.MemberFirstName, x.MemberLastName, x.MemberPhoneNumber, x.MemberDateJoined };
            GridView1.DataSource = result;
            
            // Center the data in the gridview
            GridView1.RowStyle.HorizontalAlign = HorizontalAlign.Center;
            GridView1.RowStyle.VerticalAlign = VerticalAlign.Middle;

            // Bind the data to the gridview
            GridView1.DataBind();

            // Select the first and last name from all instructors
            var result2 = from x in dbcon.Instructors
                         select new { x.InstructorFirstName, x.InstructorLastName };
            GridView2.DataSource = result2;

            // Center the data in the gridview
            GridView2.RowStyle.HorizontalAlign = HorizontalAlign.Center;
            GridView2.RowStyle.VerticalAlign = VerticalAlign.Middle;

            // Bind the data to the gridview
            GridView2.DataBind();


        }
    }
}