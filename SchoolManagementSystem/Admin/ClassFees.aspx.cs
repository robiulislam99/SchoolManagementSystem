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
    public partial class ClassFees : System.Web.UI.Page
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
                GetFees();

            }
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
                string classVal = ddlClass.SelectedItem.Text;
                DataTable dt = fn.Fetch("Select * from fees where classId='" + ddlClass.SelectedItem.Value + "' ");
                if (dt.Rows.Count == 0)
                {
                    string query = "Insert into fees values('"+ddlClass.SelectedItem.Value+"','"+txtFeeAmounts.Text.Trim()+"')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted successfully!";
                    lblMsg.CssClass = "alert alert-success";
                    ddlClass.SelectedIndex = 0;
                    txtFeeAmounts.Text = string.Empty;
                    GetFees();

                }
                else
                {
                    lblMsg.Text = "Inserted fees already exists for <b>'" + classVal + "'</b>";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        private void GetFees()
        {
            DataTable dt = fn.Fetch(@"Select ROW_NUMBER() over(order by (Select 1)) as [Sr.No],f.feeId,c.className,f.feeAmounts from fees f inner join class c on c.classId=f.classId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetFees();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetFees();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int feeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                fn.Query("Delete from fees where feeId='" + feeId + "'");
                lblMsg.Text = "Fees Deleted successfully!";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetFees();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GetFees();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int feeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string feeAmt = (row.FindControl("TextBox1") as TextBox).Text;
                fn.Query("Update fees set feeAmounts='" + feeAmt.Trim() + "' where feeId='" + feeId + "'");
                lblMsg.Text = "Fees updated successfully!";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetFees();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}