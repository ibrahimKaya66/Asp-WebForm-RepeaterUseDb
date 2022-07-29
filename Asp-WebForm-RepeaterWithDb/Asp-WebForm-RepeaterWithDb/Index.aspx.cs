using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp_WebForm_RepeaterWithDb
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            GridFill("");
        }

        private void GridFill(string param)
        {
            //Ctrl+R+M = New Methot
            GridView1.DataSource = Crud.ListSearch("Select * from Customer "+param);//Select Id as ID,FirstName as Adı,... from Customer
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GridFill("where FirstName like '%" + txtSearch.Text + "%' or LastName like '%" + txtSearch.Text + "%'");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int choose_id = GridView1.SelectedIndex;
            GridViewRow row = GridView1.Rows[choose_id];
            string query = "delete from Customer where Id= '" + row.Cells[1].Text + "'";
            SqlCommand cmd = new SqlCommand();
            Crud.AddDeleteUpdate(cmd, query);
            GridFill("");
        }
    }
}