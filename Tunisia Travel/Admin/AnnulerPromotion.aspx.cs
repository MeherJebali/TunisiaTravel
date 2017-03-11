using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Tunisia_Travel.Admin
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\TunisiaTravelBD.mdf;Integrated Security=True;User Instance=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Supprimer(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(DropDownList1.SelectedValue);
            String sqlquery = ("DELETE FROM Promotions where offre=" + id + "");
            String rqt = ("UPDATE Offres SET promo=\'False\' where idOffre=" + id + "");
            SqlCommand command1 = new SqlCommand(sqlquery, connection);
            SqlCommand command2 = new SqlCommand(rqt, connection);
            try
            {
                connection.Open();
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
