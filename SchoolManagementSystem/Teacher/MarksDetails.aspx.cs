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
    public partial class MarksDetails : System.Web.UI.Page
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
                GetMarks();
            }
        }

        private void GetMarks()
        {
            DataTable dt = fn.Fetch(@"Select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) as [Sr.No],e.examId,c.classId,c.className,e.subjectId,
                                        s.subjectName,e.rollNo,e.totalmarks,e.outOfmarks from exam e inner join class c on e.classId=c.classId
                                         inner join subject s on e.subjectId=s.subjectId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
                string rollNo = txtRoll.Text.Trim();
                DataTable dt = fn.Fetch(@"Select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) as [Sr.No],e.examId,e.classId,c.className,e.subjectId,
                                        s.subjectName,e.rollNo,e.totalmarks,e.outOfmarks from exam e inner join class c on e.classId=c.classId
                                         inner join subject s on e.subjectId=s.subjectId where e.classId='" + classId + "' and e.rollNo='" + rollNo + "'");
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