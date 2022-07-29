﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp_WebForm_RepeaterWithDb
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string query = "insert into Customer values(@name,@surname,@city,@salary)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@city", txtCity.Text);
            cmd.Parameters.Add("@salary", SqlDbType.Money).Value = Decimal.Parse(txtSalary.Text);
            Crud.AddDeleteUpdate(cmd, query);
            Response.Redirect("Index.aspx");
        }
    }
}