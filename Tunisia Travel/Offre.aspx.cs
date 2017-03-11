using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace Tunisia_Travel
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\TunisiaTravelBD.mdf;Integrated Security=True;User Instance=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            var btnJM = LoginView1.FindControl("btnJaime") as Button;
            String cnxStr = ConfigurationManager.ConnectionStrings["CnxOffres"].ConnectionString;
            String idOffre = Request.Params.Get("idOffre");
            String nomclient = User.Identity.Name.ToString();
            if (!IsPostBack)
            {
                if (idOffre != null)
                {
                    LoginView1.Visible = true;
                    SqlConnection cnx = new SqlConnection(cnxStr);
                    SqlCommand cmd = new SqlCommand("UPDATE Offres SET nbVisite = nbVisite+1 WHERE idOffre = @idOffre", cnx);
                    SqlCommand cmdRqt = new SqlCommand("SELECT COUNT(id) FROM Favoris WHERE Offre = @idOffre AND client = '" + nomclient + "' ", cnx);
                    cmd.Parameters.AddWithValue("@idOffre", idOffre);
                    cmdRqt.Parameters.AddWithValue("@idOffre", idOffre);
                    cnx.Open();
                    cmd.ExecuteScalar();
                    int nbRes = (int)cmdRqt.ExecuteScalar();
                    if (nomclient != "")
                    {
                        if (nbRes == 0)
                        {
                            btnJM.Text = "J'aime";
                        }
                        else if (nbRes == 1)
                        {
                            btnJM.Text = "Je N'aime Plus";
                        }
                        cnx.Close();
                    }
                }
                else
                {
                    LoginView1.Visible = false;
                    affich.Text = "Veuillez Vérifier l'offre SVP !!";
                }
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

        protected void btnJaime_Click(object sender, EventArgs e)
        {
            var button = LoginView1.FindControl("btnJaime") as Button;
            String idOffre = Request.Params.Get("idOffre");
            String nomUser = User.Identity.Name.ToString();
            if (button.Text == "J'aime")
            {

                SqlCommand rqt = new SqlCommand("UPDATE Offres SET nbLikes = nbLikes+1 WHERE idOffre = @idOffre", connection);
                rqt.Parameters.AddWithValue("@idOffre", idOffre);
                SqlCommand rqtadd = new SqlCommand("INSERT INTO [Favoris] VALUES('"+nomUser+"',"+idOffre+")",connection);
                try
                {
                    connection.Open();
                    rqt.ExecuteScalar();
                    rqtadd.ExecuteNonQuery();
                    connection.Close();
                    button.Text = "Je N'aime Plus";
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
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
                    button.Text = "J'aime";
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}