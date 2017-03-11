using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;


namespace Tunisia_Travel.Users
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\TunisiaTravelBD.mdf;Integrated Security=True;User Instance=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            String idOffre = Request.Params.Get("idOffre");
            if (idOffre != null)
            {
                SqlCommand rqt2 = new SqlCommand("UPDATE Offres SET nbLikes = nbLikes-1 WHERE idOffre = @idOffre", connection);
                rqt2.Parameters.AddWithValue("@idOffre", idOffre);
                SqlCommand rqtDel = new SqlCommand("DELETE FROM [Favoris] WHERE Offre = @idOffre", connection);
                rqtDel.Parameters.AddWithValue("@idOffre", idOffre);
                try
                {
                    connection.Open();
                    rqt2.ExecuteScalar();
                    rqtDel.ExecuteNonQuery();
                    connection.Close();
                    Response.Redirect("OffresFavoris.aspx");
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
            {
                //Response.Write("Vous n'avez pas le droit de se trouver ici");
                lblSup.Text = "Vous n'avez pas choisi un article à effacer";
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
    }
}
