using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tunisia_Travel
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecherche_Click(object sender, EventArgs e)
        {
            String type = rbList.SelectedValue;
            String dest = Destinations.SelectedValue;
            String them = Thematiques.SelectedValue;
            String url = "test.aspx?typeOffre=" + type + "&destination=" + dest + "&categorie=" + them;
            Response.Redirect("Resultat.aspx?typeOffre=" + type + "&destination=" + dest + "&categorie=" + them);
        }
    }
}
