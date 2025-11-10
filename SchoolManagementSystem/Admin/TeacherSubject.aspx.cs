using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Admin
{
    public partial class TeacherSubject : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                GetClass();
                GetSubject();
                GetTeacher();
                GetTeacherSubjects();
            }
        }

        private void GetTeacher()
        {
            DataTable dt = fn.Fetch("Select * from Teacher");
            ddlTeacher.DataSource = dt;
            ddlTeacher.DataTextField = "Name";
            ddlTeacher.DataValueField = "TeacherId";
            ddlTeacher.DataBind();
            ddlTeacher.Items.Insert(0, "Select teacher");
        }

        private void GetSubject()
        {
            DataTable dt = fn.Fetch("Select * from Subject");
            ddlSubject.DataSource = dt;
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataValueField = "SubjectId";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, "Select subject");
        }

        private void GetClass()
        {
            DataTable dt = fn.Fetch("Select * from Class");
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassId";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, "Select class");
        }

        private void GetTeacherSubjects()
        {
            DataTable dt = fn.Fetch("SELECT ROW_NUMBER() OVER(ORDER BY ts.Id) AS [Sr.No], ts.Id, ts.ClassId, c.ClassName, ts.SubjectId, s.SubjectName, ts.TeacherId, t.Name FROM TeacherSubject ts INNER JOIN Class c ON ts.ClassId = c.ClassId INNER JOIN Subject s ON ts.SubjectId = s.SubjectId INNER JOIN Teacher t ON ts.TeacherId = t.TeacherId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlClass.SelectedValue == "Select class" || ddlSubject.SelectedValue == "Select subject" || ddlTeacher.SelectedValue == "Select teacher")
                {
                    lblMsg.Text = "Please select all fields!";
                    lblMsg.CssClass = "alert alert-warning";
                    return;
                }

                string classId = ddlClass.SelectedValue;
                string subjectId = ddlSubject.SelectedValue;
                string teacherId = ddlTeacher.SelectedValue;

                DataTable checkDt = fn.Fetch("SELECT * FROM TeacherSubject WHERE ClassId = '" + classId + "' AND SubjectId = '" + subjectId + "' AND TeacherId = '" + teacherId + "'");

                if (checkDt.Rows.Count > 0)
                {
                    lblMsg.Text = "This teacher is already assigned to this subject for this class!";
                    lblMsg.CssClass = "alert alert-danger";
                    return;
                }

                string query = "INSERT INTO TeacherSubject (ClassId, SubjectId, TeacherId) VALUES ('" + classId + "', '" + subjectId + "', '" + teacherId + "')";
                fn.Query(query);

                lblMsg.Text = "Teacher-Subject assignment added successfully!";
                lblMsg.CssClass = "alert alert-success";

                GetTeacherSubjects();

                ddlClass.SelectedIndex = 0;
                ddlSubject.SelectedIndex = 0;
                ddlTeacher.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
        }
    }
}