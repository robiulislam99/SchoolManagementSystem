using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Admin
{
    public partial class Student : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        private object ex;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                GetClass();
                GetStudents();
            }
        }

        private void GetStudents()
        {
            DataTable dt = fn.Fetch(@"Select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) as [Sr.No],s.studentId,s.[name],s.dob,gender,
                                        s.mobile,s.rollNo,s.[address],c.classId,c.className from student s inner join class c on c.classId=s.classId");
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

                    if (ddlGender.SelectedValue != "0")
                    {
                        string rollNo = txtRoll.Text.Trim();
                        DataTable dt = fn.Fetch("Select * from student where classId='" + ddlClass.SelectedValue + "' and rollNo='" + rollNo + "' ");
                        if (dt.Rows.Count == 0)
                        {
                            string query = "Insert into student values ('" + txtName.Text.Trim() + "','" + txtDoB.Text.Trim() + "'," +
                                "'" + ddlGender.SelectedValue + "','" + txtMobile.Text.Trim() + "','" + txtRoll.Text.Trim() + "'," +
                                "'" + txtAddress.Text.Trim() + "','" + ddlClass.SelectedValue + "')";
                            fn.Query(query);
                            lblMsg.Text = "Inserted successfully!";
                            lblMsg.CssClass = "alert alert-success";
                            ddlGender.SelectedIndex = 0;
                            txtName.Text = string.Empty;
                            txtDoB.Text = string.Empty;
                            txtMobile.Text = string.Empty;
                            txtRoll.Text = string.Empty;
                            txtAddress.Text = string.Empty;
                            ddlClass.SelectedIndex = 0;
                            GetStudents();
                        }
                        else
                        {
                            lblMsg.Text = "Entered roll <b>'" + rollNo + "'</b> already exist fo selected class! ";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Gender is required!";
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