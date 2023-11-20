<%@ Page Title="" Language="C#" MasterPageFile="~/Authorized/Authorized.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Assignment4.authorized.Administrators.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Hello,
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </p>
    <p>
        <asp:GridView ID="GridView2" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </p>
    <p>
        <strong>Add new Member or Instructor</strong></p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 163px">User Name</td>
                <td style="width: 254px">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="userNameRequiredFieldValidator" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Please enter User Name" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 163px">User Password</td>
                <td style="width: 254px">
                    <asp:TextBox ID="txtUserPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="userPasswordRequiredFieldValidator" runat="server" ControlToValidate="txtUserPassword" Display="Dynamic" ErrorMessage="Please enter User Password" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 163px">User Type</td>
                <td style="width: 254px">
                    <asp:DropDownList ID="ddlUserType" runat="server">
                        <asp:ListItem Value="0">Instructor</asp:ListItem>
                        <asp:ListItem Value="1">Member</asp:ListItem>
                        <asp:ListItem Value="2">Administrator</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="userTypeRequiredFieldValidator" runat="server" ControlToValidate="ddlUserType" Display="Dynamic" ErrorMessage="Please chose User Type" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 163px; height: 30px;">First Name</td>
                <td style="width: 254px; height: 30px;">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
                <td style="height: 30px">
                    <asp:RequiredFieldValidator ID="firstNameRequiredFieldValidator" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please enter First Name" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 163px">Last Name</td>
                <td style="width: 254px">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="lastNameRequiredFieldValidator" runat="server" ControlToValidate="txtLastName" Display="Dynamic" ErrorMessage="Please enter Last Name" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 163px">Phone Number</td>
                <td style="width: 254px">
                    <asp:TextBox ID="txtPhoneNumber" runat="server" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="phoneNumberRequiredFieldValidator" runat="server" ControlToValidate="txtPhoneNumber" Display="Dynamic" ErrorMessage="Please enter Phone Number" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 163px">Email</td>
                <td style="width: 254px">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please enter Email" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="AddUser"/>
    </p>

    <p>
        <strong>Delete a Member or Instructor</strong></p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 160px">Member</td>
                <td style="width: 254px">
                    Instructor</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 160px; height: 68px;">
                    <asp:DropDownList ID="ddlMemberDelete" runat="server" DataSourceID="SqlDataSource1" DataTextField="Member_UserID" DataValueField="Member_UserID">
                    </asp:DropDownList>
                </td>
                <td style="width: 254px; height: 68px;">
                    <asp:DropDownList ID="ddlInstructorDelete" runat="server" DataSourceID="SqlDataSource2" DataTextField="InstructorID" DataValueField="InstructorID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString1 %>" SelectCommand="SELECT * FROM [Instructor]"></asp:SqlDataSource>
                </td>
                <td style="height: 68px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 160px">
                    <asp:Button ID="btnDeleteMember" runat="server" OnClick="btnDeleteMember_Click" Text="Delete Member" ValidationGroup="DeleteUser"/>
                </td>
                <td style="width: 254px">
                    <asp:Button ID="btnDeleteInstructor" runat="server" OnClick="btnDeleteInstructor_Click" Text="Delete Instructor" ValidationGroup="DeleteInstructor" />
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    </p>
    <p>
        <strong>Assign a Member to a Section</strong></p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 158px">Member ID</td>
                <td style="width: 256px">
                    <asp:DropDownList ID="ddlMemberToAssign" runat="server" DataSourceID="SqlDataSource1" DataTextField="Member_UserID" DataValueField="Member_UserID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString1 %>" SelectCommand="SELECT * FROM [Member]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="assignMemberRequiredFieldValidator" runat="server" ControlToValidate="ddlMemberToAssign" Display="Dynamic" ErrorMessage="Please chose Member ID" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 158px">Section</td>
                <td style="width: 256px">
                    <asp:DropDownList ID="ddlSection" runat="server">
                        <asp:ListItem>Karate Age-Uke</asp:ListItem>
                        <asp:ListItem>Karate Chudan-Uke </asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="sectionRequiredFieldValidator" runat="server" ControlToValidate="ddlSection" Display="Dynamic" ErrorMessage="Please chose Section" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="btnAssign" runat="server" OnClick="btnAssign_Click" Text="Assign" ValidationGroup="AssignUser"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
