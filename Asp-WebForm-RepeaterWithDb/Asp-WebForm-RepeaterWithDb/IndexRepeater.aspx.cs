using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp_WebForm_RepeaterWithDb
{
    public partial class IndexRepeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = Crud.ListSearch("select * from Customer");
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                var footer = e.Item.FindControl("lblCount") as Label;
                footer.Text = "Toplam " + (Repeater1.DataSource as DataTable).Rows.Count + " kayıt listelendi";
            }
        }
    }
}