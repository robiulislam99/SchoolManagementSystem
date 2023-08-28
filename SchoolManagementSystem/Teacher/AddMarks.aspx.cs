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
    public partial class AddMarks : System.Web.UI.Page
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
                string rollNo = txtRoll.Text.Trim();
                string obtainMarks = txtTotal.Text.Trim();
                string outOfmarks = txtOut.Text.Trim();
                DataTable dt = fn.Fetch("Select * from exam where classId='" + classId + "' and  subjectId='" + subjectId + "' and rollNo='" + rollNo + "' ");
                if (dt.Rows.Count == 0)
                {
                    string query = "Insert into exam values ('" + classId + "','" + subjectId + "'," +
                        "'" + rollNo + "','" + obtainMarks + "','" + outOfmarks + "')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted successfully!";
                    lblMsg.CssClass = "alert alert-success";
                    ddlClass.SelectedIndex = 0;
                    ddlSubject.SelectedIndex = 0;
                    txtRoll.Text = string.Empty;
                    txtTotal.Text = string.Empty;
                    txtOut.Text = string.Empty;
                    GetMarks();
                }
                else
                {
                    lblMsg.Text = "Entered roll <b>'" + rollNo + "'</b> already exist fo selected class! ";
                    lblMsg.CssClass = "alert alert-danger";
                }

            }


            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}