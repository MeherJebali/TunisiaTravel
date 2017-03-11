using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Tunisia_Travel.Users
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var txt = DataList1.FindControl("txtID") as TextBox;
            String nomUser = (String) User.Identity.Name.ToString();
            MesPreferes.SelectCommand = "SELECT Offres.idOffre,Offres.photo,Offres.prix,Offres.titreOffre FROM Offres,Favoris WHERE Favoris.client like '%" + nomUser + "%' AND Offres.idOffre = Favoris.Offre ";

        }

        protected void btnRecherche_Click(object sender, EventArgs e)
        {
            String type = rbList.SelectedValue;
            String dest = Destinations.SelectedValue;
            String them = Thematiques.SelectedValue;
            String url = "test.aspx?typeOffre=" + type + "&destination=" + dest + "&categorie=" + them;
            Response.Redirect("../Resultat.aspx?typeOffre=" + type + "&destination=" + dest + "&categorie=" + them);
        }
    }
}
