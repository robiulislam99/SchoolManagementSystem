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
    public partial class EmpAttendanceDetails : System.Web.UI.Page
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(txtMonth.Text, out date))
            {
                DataTable dt = fn.Fetch(@"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS [Sr.No], t.name, ta.status, ta.Date
                             FROM teacherAttendance ta
                             INNER JOIN teacher t ON t.teacherId = ta.teacherId
                             WHERE DATEPART(yy, Date) = '" + date.Year + "' AND DATEPART(M, Date) = '" + date.Month + "' AND ta.status = 1 AND " +
                                         "ta.teacherId = '" + ddlTeacher.SelectedValue + "'");
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