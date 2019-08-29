using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Task
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
            }
        }


        public void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            Label9.Text = "";
            GridView1.EditRowStyle.BackColor = System.Drawing.Color.Orange;
        }
        public void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            Label9.Text = "";
        }

        public void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = GridView1.Rows[e.RowIndex].FindControl("Label8") as Label;
            TextBox name = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            TextBox dob = GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
            TextBox sex = GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
            TextBox bio = GridView1.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;
            String mycon = "Data Source=DESKTOP-NOTE7LA; Initial Catalog=industry; Integrated Security=True";
            String updatedata = "Update Rock set name='" + name.Text + "', dob='" + dob.Text + "',sex='" + sex.Text + "', bio='" + bio.Text + "' where id=" + id.Text;
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updatedata;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Label9.Text = "Row Data Has Been Updated Successfully";
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Label id = GridView1.Rows[e.RowIndex].FindControl("Label3") as Label;
            String mycon = "Data Source=DESKTOP-NOTE7LA; Initial Catalog=industry; Integrated Security=True";
            String updatedata = "delete from Rock where id=" + id.Text;
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updatedata;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Label9.Text = "Row Data Has Been Deleted Successfully";
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            TextBox id = GridView1.FooterRow.FindControl("TextBox5") as TextBox;
            TextBox name = GridView1.FooterRow.FindControl("TextBox6") as TextBox;
            TextBox dob = GridView1.FooterRow.FindControl("TextBox7") as TextBox;
            TextBox sex = GridView1.FooterRow.FindControl("TextBox8") as TextBox;
            TextBox bio= GridView1.FooterRow.FindControl("TextBox9") as TextBox;
            String query = "insert into Rock (name,dob,sex,bio) values('" + name.Text + "','" + dob.Text + "','" + sex.Text + "','" + bio.Text + "')";
            String mycon = "Data Source=DESKTOP-NOTE7LA; Initial Catalog=industry; Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Label9.Text = "New Row Inserted Successfully";
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();

        }
    }
}