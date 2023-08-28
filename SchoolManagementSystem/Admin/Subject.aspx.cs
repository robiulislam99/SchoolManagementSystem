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
    public partial class Subject : System.Web.UI.Page
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

            }
        }

        private void GetClass()
        {
            DataTable dt = fn.Fetch("Select * from class");
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "className";
            ddlClass.DataValueField = "classId";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, "select class");
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string classVal = ddlClass.SelectedItem.Text;
                DataTable dt = fn.Fetch("Select * from subject where classId='" + ddlClass.SelectedItem.Value + "' and subjectName='"+txtSubject.Text.Trim()+"' ");
                if (dt.Rows.Count == 0)
                {
                    string query = "Insert into subject values('" + ddlClass.SelectedItem.Value + "','" + txtSubject.Text.Trim() + "')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted successfully!";
                    lblMsg.CssClass = "alert alert-success";
                    ddlClass.SelectedIndex = 0;
                    txtSubject.Text = string.Empty;
                    GetSubject();

                }
                else
                {
                    lblMsg.Text = "Inserted subject already exists for <b>'" + classVal + "'</b>";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        private void GetSubject()
        {
            DataTable dt = fn.Fetch(@"Select ROW_NUMBER() over(Order by (Select 1)) as [Sr.No],s.subjectId,s.classId,c.className,
                                        s.subjectName from subject s inner join class c on c.classId=s.classId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    }
}