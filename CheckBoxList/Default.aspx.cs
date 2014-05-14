using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckBoxList
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            lblSelected.Text = String.Join("<br>", cbl.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Text).ToArray());
            pnlSelected.Visible = lblSelected.Text.Length > 0;

            lblNotSelected.Text = String.Join("<br>", cbl.Items.Cast<ListItem>().Where(i => !i.Selected).Select(i => i.Text).ToArray());
            pnlNotSelected.Visible = lblNotSelected.Text.Length > 0;
        }
    }
}