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
            // connection string

            string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\brand\\Desktop\\213Assignment4\\213Assignment4\\Assignment4\\App_Data\\KarateSchool.mdf;Integrated Security=True";
            //string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\karina\\OneDrive - North Dakota University System\\Desktop\\213\\213Assignment4\\213Assignment4\\Assignment4\\App_Data\\KarateSchool.mdf;Integrated Security=True";
            int id = -1;

            if (Session.Count != 0)
            {
                foreach (var item in Session.Keys)
                {
                    lblName.Text = Session[item.ToString()].ToString();
                    id = int.Parse(item.ToString());
                }
            }
            
            KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn);

            // Select section name, start date, instructor's first and last name and fee for the section
            var result = from x in dbcon.Sections
                         where x.Instructor_ID == id
                         select new { x.SectionName, x.Member.MemberFirstName, x.Member.MemberLastName };
            GridView1.DataSource = result;

            // Center the data in the gridview
            GridView1.RowStyle.HorizontalAlign = HorizontalAlign.Center;
            GridView1.RowStyle.VerticalAlign = VerticalAlign.Middle;

            // Bind the data to the gridview
            GridView1.DataBind();
        }
    }
}