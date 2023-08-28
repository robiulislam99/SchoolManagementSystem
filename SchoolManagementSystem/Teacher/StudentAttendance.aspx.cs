using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Teacher
{
    public partial class StudentAttendance : System.Web.UI.Page
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
                btnMarkAttendance.Visible = false;
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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
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

        /*protected void ddlclass_SelectedIndexChanged(object sender,EventArgs e)
        {
            string classId = ddlClass.SelectedValue;
            DataTable dt = fn.Fetch("select * from subject where classId='" + classId + "'");
            ddlSubject.DataSource = dt;
            ddlSubject.DataTextField = "subjectName";
            ddlSubject.DataValueField = "subjectId";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, "Select subject");

        }*/

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = fn.Fetch(@"select studentId,rollNo,name,mobile from student where classId='" + ddlClass.SelectedValue + "'");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if(dt.Rows.Count>0)
            {
                btnMarkAttendance.Visible = true;
            }
            else
            {
                btnMarkAttendance.Visible = false;
            }
        }

        protected void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            bool istrue = false;
            foreach (GridViewRow row in GridView1.Rows)
            {
                string rollNo = row.Cells[2].Text.Trim();
                RadioButton rb1 = (row.Cells[0].FindControl("RadioButton1") as RadioButton);
                RadioButton rb2 = (row.Cells[0].FindControl("RadioButton2") as RadioButton);
                int status = 0;
                if (rb1.Checked)
                {
                    status = 1;
                }
                else if (rb2.Checked)
                {
                    status = 0;
                }

                fn.Query(@"Insert into studentAttendance values('" +ddlClass.SelectedValue+ "','" +ddlSubject.SelectedValue + "','" + rollNo + "','" + status + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')");
                 
                istrue = true;
            }
            if(istrue)
            {
                lblMsg.Text = "Inserted successfully!";
                lblMsg.CssClass = "alert alert-success";
            }
            else
            {
                lblMsg.Text = "Something is wrong!";
                lblMsg.CssClass = "alert alert-warning";
            }
        }
    }
}