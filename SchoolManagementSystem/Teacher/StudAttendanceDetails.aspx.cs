using SchoolManagementSystem.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Teacher
{
    public partial class StudAttendanceDetails : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["staff"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                GetClass();
                GetSubject();
            }
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(txtMonth.Text, out date))
            {
                DataTable dt = fn.Fetch(@"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS [Sr.No], s.name, sa.status, sa.Date
                         FROM studentAttendance sa
                         INNER JOIN student s ON s.rollNo = sa.rollNo
                         WHERE sa.classId = '" + ddlClass.SelectedValue + "' AND sa.rollNo = '" + txtRoll.Text.Trim() + "' " +
                         "AND DATEPART(yy, sa.Date) = '" + date.Year + "' AND DATEPART(M, sa.Date) = '" + date.Month + "' AND sa.status = 1");

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                lblMsg.Text = "error";
                lblMsg.CssClass = "alert alert-danger";
            }
        }
    }
}