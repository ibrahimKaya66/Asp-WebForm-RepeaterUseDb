using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Asp_WebForm_RepeaterWithDb
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["Id"]);
            SqlCommand cmd = new SqlCommand();
            Crud.AddDeleteUpdate(cmd, "Delete from Customer where Id = " + id);
            //Response.Redirect("IndexRepeater.aspx");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "3;url=IndexRepeater.aspx";//süre ve url belirtilir
            this.Page.Controls.Add(meta);
            Label1.Text = "3 sn sonra anasayfaya yönlendirileceksiniz.";
        }
    }
}