using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Tunisia_Travel.Admin
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\TunisiaTravelBD.mdf;Integrated Security=True;User Instance=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(DropDownList1.SelectedValue);
            int type = int.Parse(DropDownList2.SelectedValue);
            String detls = txtDetails.Text;
            String rqt1 = ("INSERT INTO [Promotions] VALUES (" + id + "," + type + ",'" + detls + "')");
            String rqt2 = ("UPDATE Offres set promo=\'True\' WHERE idOffre="+id+"");
            SqlCommand command1 = new SqlCommand(rqt1, connection);
            SqlCommand command2 = new SqlCommand(rqt2, connection);
            try
            {
                connection.Open();
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();

                Response.Redirect("Administration.aspx");
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }

        }
    }
}
