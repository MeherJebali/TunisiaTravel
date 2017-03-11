using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Tunisia_Travel.Admin
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\TunisiaTravelBD.mdf;Integrated Security=True;User Instance=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            String type = txtTypePrm.Text;
            String rqt = ("INSERT INTO [TypePromotions] VALUES ('" + type + "')");
            SqlCommand command = new SqlCommand(rqt, connection);
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
