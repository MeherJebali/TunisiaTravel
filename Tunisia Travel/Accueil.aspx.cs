using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tunisia_Travel
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Tri.SelectedValue == "Prix")
            {
                LesOffres.SelectCommand = "SELECT [photo], [prix],[Date], [titreOffre], [idOffre] FROM [Offres] ORDER BY [prix]";
            }
            else if (Tri.SelectedValue == "Date")
            {
                LesOffres.SelectCommand = "SELECT [photo], [prix],[Date], [titreOffre], [idOffre] FROM [Offres] ORDER BY [Date]";
            }
        }

        protected void btnRecherche_Click(object sender, EventArgs e)
        {
            String type = rbList.SelectedValue;
            String dest = Destinations.SelectedValue;
            String them = Thematiques.SelectedValue;
            String url = "test.aspx?typeOffre=" + type + "&destination=" + dest + "&categorie=" + them;
            Response.Redirect("Resultat.aspx?typeOffre=" + type + "&destination=" + dest + "&categorie=" + them);
        }

        protected void Tri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tri.SelectedValue == "Prix")
            {
                LesOffres.SelectCommand = "SELECT [photo], [prix], [titreOffre], [idOffre] FROM [Offres] ORDER BY [prix]";
            }
            else if (Tri.SelectedValue == "Date")
            {
                LesOffres.SelectCommand = "SELECT [photo], [prix], [titreOffre], [idOffre] FROM [Offres] ORDER BY [Date]";
            }
        }
    }
}
