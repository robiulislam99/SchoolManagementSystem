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
    public partial class Teacher : System.Web.UI.Page
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
                GetTeachers();
            }
        }

        private void GetTeachers()
        {
            DataTable dt = fn.Fetch(@"Select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) as [Sr.No],teacherId,[name],dob,gender,
                                        mobile,email,[address],[password] from teacher");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

         

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            try
            {
                if (ddlGender.SelectedValue != "0")
                {
                    string email = txtEmail.Text.Trim();
                    DataTable dt = fn.Fetch("Select * from teacher where email='" + email + "' ");
                    if (dt.Rows.Count == 0)
                    {
                        string query = "Insert into teacher values ('" + txtName.Text.Trim() + "','" + txtDoB.Text.Trim() + "','" + ddlGender.SelectedValue + "','" + txtMobile.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + txtPassword.Text.Trim() + "')";
                        fn.Query(query);
                        lblMsg.Text = "Inserted successfully!";
                        lblMsg.CssClass = "alert alert-success";
                        ddlGender.SelectedIndex = 0;
                        txtName.Text = string.Empty;
                        txtDoB.Text = string.Empty;
                        txtMobile.Text = string.Empty;
                        txtEmail.Text = string.Empty;
                        txtAddress.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                        GetTeachers();
                    }
                    else
                    {
                        lblMsg.Text = "Entered  <b>'" + email + "'</b> already exist! ";
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