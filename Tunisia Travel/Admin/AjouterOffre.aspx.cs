using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;


namespace Tunisia_Travel.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\TunisiaTravelBD.mdf;Integrated Security=True;User Instance=True");
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {

            String typeOf = rbTypes.SelectedValue;
            String titre = txtTitre.Text;
            int dest = int.Parse(Dests.SelectedValue);
            int them = int.Parse(Thematiques.SelectedValue);
            DateTime datev = DateV.SelectedDate;
            int nbjours = int.Parse(nbrJours.Text);
            String chminphoto = "";
            if (photo.HasFile)
            {
                photo.SaveAs(Server.MapPath("~\\img\\ImgOffres\\") + photo.FileName);
                chminphoto = "../img/ImgOffres/" + photo.PostedFile.FileName.ToString();
            }
            String descr = txtDes.Text;
            float prix = float.Parse(txtPrix.Text);
            int nbv = 0;
            String promo = "False";
            int nblike = 0;
            String sqlquery = ("INSERT INTO [Offres] VALUES ('" + typeOf + "'," + them + ", '" + titre + "', " + dest + ", '" + datev + "', " + nbjours + ", " + prix + ", '" + chminphoto + "', '" + descr + "'," + nbv + ",'" + promo + "'," + nblike + ")");
            SqlCommand command = new SqlCommand(sqlquery, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Response.Redirect("Administration.aspx");
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message); 
            }
        }
    }
}
