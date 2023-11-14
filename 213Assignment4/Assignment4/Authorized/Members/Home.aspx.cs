using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4.authorized.Members
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = -1;

            // Check for Session Items
            if (Session.Count != 0)
            {
                foreach(var item in Session.Keys)
                {
                    // Populate the label with the user's first and last name
                    lblName.Text = Session[item.ToString()].ToString();
                    id = int.Parse(item.ToString());
                }
            }

            // Connection string

            //string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\brand\\Desktop\\213Assignment4\\213Assignment4\\Assignment4\\App_Data\\KarateSchool.mdf;Integrated Security=True";
            string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\karina\\OneDrive - North Dakota University System\\Desktop\\213\\213Assignment4\\Assignment4\\App_Data\\KarateSchool.mdf\";Integrated Security=True"; 
            KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn);

            // Select section name, start date, instructor's first and last name and fee for the section
            var result = from x in dbcon.Sections
                         where x.Member_ID == id
                         select new {x.SectionName, x.SectionStartDate, x.Instructor.InstructorFirstName, x.Instructor.InstructorLastName, x.SectionFee};
            GridView1.DataSource = result;

            // Center the data in the gridview
            GridView1.RowStyle.HorizontalAlign = HorizontalAlign.Center;
            GridView1.RowStyle.VerticalAlign = VerticalAlign.Middle;

            // Bind the data to the gridview
            GridView1.DataBind();
            
            
        }
    }
}