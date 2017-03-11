using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Tunisia_Travel.Users
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Preinit(object sender, EventArgs e)
        {
            Page.Theme = "Orange";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] themes = Directory.GetDirectories(Server.MapPath("~/App_Themes"));
                foreach (string t in themes)
                {
                    lstthemes.Items.Add(Path.GetFileName(t));
                }
            }
        }

        protected void btnRecherche_Click(object sender, EventArgs e)
        {
            String type = rbList.SelectedValue;
            String dest = Destinations.SelectedValue;
            String them = Thematiques.SelectedValue;
            String url = "test.aspx?typeOffre=" + type + "&destination=" + dest + "&categorie=" + them;
            Response.Redirect("../Resultat.aspx?typeOffre=" + type + "&destination=" + dest + "&categorie=" + them);
   
        }

        protected void lstthemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["theme"] = lstthemes.SelectedValue;
            //Server.Transfer(Request.FilePath);
        }
    }
}
