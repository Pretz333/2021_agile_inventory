using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventory
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertNewCategory(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Inventory.mdf;Integrated Security=True;Connect Timeout=30";
            string categoryDescription = tbCategoryDescription.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO Category (Description) VALUES ('" + categoryDescription + "');";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}