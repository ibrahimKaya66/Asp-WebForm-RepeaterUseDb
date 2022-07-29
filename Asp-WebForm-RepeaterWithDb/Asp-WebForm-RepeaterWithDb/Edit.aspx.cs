using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp_WebForm_RepeaterWithDb
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["Id"]);
            txtId.Text = id.ToString();
            if(!IsPostBack)
                Crud.GetDb(txtName, txtSurname, txtCity, txtSalary, "select * from Customer where Id="+id);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "update Customer set FirstName = @name,LastName = @surname,City = @city,Salary = @salary where Id = '" + txtId.Text + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = txtName.Text;
            cmd.Parameters.Add("@surname", SqlDbType.VarChar).Value = txtSurname.Text;
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = txtCity.Text;
            cmd.Parameters.Add("@salary", SqlDbType.Money).Value = Decimal.Parse(txtSalary.Text);
            Crud.AddDeleteUpdate(cmd, query);
            Response.Redirect("IndexRepeater.aspx");
        }
    }
}