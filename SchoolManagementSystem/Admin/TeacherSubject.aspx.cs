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
            }
        }

        private void GetTeacher()
        {
            DataTable dt = fn.Fetch("Select * from teacher");
            ddlTeacher.DataSource = dt;
            ddlTeacher.DataTextField = "name";
            ddlTeacher.DataValueField = "teacherId";
            ddlTeacher.DataBind();
            ddlTeacher.Items.Insert(0, "Select teacher");
        }

        private void GetSubject()
        {
            DataTable dt = fn.Fetch("Select * from subject");
            ddlSubject.DataSource = dt;
            ddlSubject.DataTextField = "subjectName";
            ddlSubject.DataValueField = "subjectId";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, "Select subject");
        }

        private void GetClass()
        {
            DataTable dt = fn.Fetch("Select * from class");
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "className";
            ddlClass.DataValueField = "classId";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, "Select class");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string classId = ddlClass.SelectedValue;
                string subjectId = ddlSubject.SelectedValue;
                string teacherName = ddlTeacher.SelectedValue;
                DataTable dt = fn.Fetch(@"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS [Sr.No], ts.Id, ts.classId, c.className, ts.subjectId,
                        s.subjectName, ts.teacherId, t.name
                        FROM teacherSub ts
                        INNER JOIN class c ON ts.classId = c.classId
                        INNER JOIN subject s ON ts.subjectId = s.subjectId
                        INNER JOIN teacher t ON ts.teacherId = t.teacherId
                        WHERE c.className = '" + classId + "' AND t.name = '" + teacherName + "' AND s.subjectName = '" + subjectId + "'");
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}