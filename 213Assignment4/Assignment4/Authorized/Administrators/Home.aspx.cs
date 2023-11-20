
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

            dbcon = new KarateSchoolDataContext(conn);
            ShowAllRecords();

        }

        // Connection String
        KarateSchoolDataContext dbcon;
        //string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\brand\\Desktop\\213Assignment4\\213Assignment4\\Assignment4\\App_Data\\KarateSchool.mdf;Integrated Security=True";
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\karina\\OneDrive - North Dakota University System\\Desktop\\213\\213Assignment4\\213Assignment4\\Assignment4\\App_Data\\KarateSchool.mdf;Integrated Security=True";

        public void ShowAllRecords()
        {

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


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //create new user
            NetUser myUser = new NetUser();
            myUser.UserName = txtUserName.Text;
            myUser.UserPassword = txtUserPassword.Text;
            myUser.UserType = ddlUserType.SelectedItem.Text;

            //save data into NetUser table
            dbcon.NetUsers.InsertOnSubmit(myUser);
            dbcon.SubmitChanges();

            if (myUser.UserType == "Member")
            {
                // Create a new member
                NetUser newUser = (from x in dbcon.NetUsers
                                   where x.UserName == txtUserName.Text
                                   select x).First();

                Member myMember = new Member();
                myMember.Member_UserID = newUser.UserID;
                myMember.MemberFirstName = txtFirstName.Text;
                myMember.MemberLastName = txtLastName.Text;
                myMember.MemberDateJoined = DateTime.Now;
                myMember.MemberPhoneNumber = txtPhoneNumber.Text;
                myMember.MemberEmail = txtEmail.Text;

                // Insert data into Member table
                dbcon.Members.InsertOnSubmit(myMember);
                dbcon.SubmitChanges();
            }
            else if (myUser.UserType == "Instructor")
            {
                // Create a new instructor
                NetUser newUser = (from x in dbcon.NetUsers
                                   where x.UserName == txtUserName.Text
                                   select x).First();

                Instructor myInstructor = new Instructor();
                myInstructor.InstructorID = newUser.UserID;
                myInstructor.InstructorFirstName = txtFirstName.Text;
                myInstructor.InstructorLastName = txtLastName.Text;
                myInstructor.InstructorPhoneNumber = txtPhoneNumber.Text;

                // Insert data into Instructor table
                dbcon.Instructors.InsertOnSubmit(myInstructor);
                dbcon.SubmitChanges();
            }
            ShowAllRecords();
        }

        // Delete a member based on the selected ID from ddlMemberDelete
        protected void btnDeleteMember_Click(object sender, EventArgs e)
        {
            int memberIdToDelete;

            if (int.TryParse(ddlMemberDelete.SelectedValue, out memberIdToDelete))
            {
                Member memberToDelete = null;
                foreach (var member in dbcon.Members)
                {
                    if (member.Member_UserID == memberIdToDelete)
                    {
                        memberToDelete = member;
                        break;
                    }
                }

                if (memberToDelete != null)
                {
                    dbcon.Members.DeleteOnSubmit(memberToDelete);
                    dbcon.SubmitChanges();
                    ShowAllRecords();
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Member with the specified ID was not found.";
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Invalid Member ID selected.";
            }
        }

        // Delete an instructor based on the selected ID from ddlInstructorDelete
        protected void btnDeleteInstructor_Click(object sender, EventArgs e)
        {
            int instructorIdToDelete;

            if (int.TryParse(ddlInstructorDelete.SelectedValue, out instructorIdToDelete))
            {
                Instructor instructorToDelete = null;

                foreach (var instructor in dbcon.Instructors)
                {
                    if (instructor.InstructorID == instructorIdToDelete)
                    {
                        instructorToDelete = instructor;
                        break;
                    }
                }

                if (instructorToDelete != null)
                {
                    dbcon.Instructors.DeleteOnSubmit(instructorToDelete);
                    dbcon.SubmitChanges();
                    ShowAllRecords();
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Instructor with the specified ID was not found.";
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Invalid Instructor ID selected.";
            }
        }
        
        // Assign a member to a cection based on the selected Member ID and ddlSection
        protected void btnAssign_Click(object sender, EventArgs e)
        {
            int memberIdToAssign;
            string sectionToAssign;

            if (int.TryParse(ddlMemberToAssign.SelectedValue, out memberIdToAssign) &&
                !string.IsNullOrEmpty(ddlSection.SelectedValue))
            {
                sectionToAssign = ddlSection.SelectedValue;

                Member memberToAssign = null;
                Section sectionToUpdate = null;

                foreach (var member in dbcon.Members)
                {
                    if (member.Member_UserID == memberIdToAssign)
                    {
                        memberToAssign = member;
                        break;
                    }
                }

                foreach (var section in dbcon.Sections)
                {
                    if (section.SectionName == sectionToAssign)
                    {
                        sectionToUpdate = section;
                        break;
                    }
                }

                if (memberToAssign != null && sectionToUpdate != null)
                {
                    sectionToUpdate.Member_ID = memberToAssign.Member_UserID;

                    try
                    {
                        dbcon.SubmitChanges();
                        ShowAllRecords();
                    }
                    catch (Exception ex)
                    {
                        Label2.Visible = true;
                        Label2.Text = "Error: " + ex.Message;
                    }
                }
                else
                {
                    Label2.Visible = true;
                    Label2.Text = "Member or Section not found.";
                }
            }
            else
            {
                Label2.Visible = true;
                Label2.Text = "Invalid Member or Section selected.";
            }


        }
    }
}
