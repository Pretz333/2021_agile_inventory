using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;



namespace Inventory
{
    public partial class Connection_Test : System.Web.UI.Page

        //as the title of the file says, this is for making test to the database to ensure connectivity between the app and
        //the Database
    {

        protected void Retrieve_Dashboard(object sender, EventArgs e)
        {
            //Connection to the inventory table, and display it on the connection_test page
            string mycon = "server =localhost; Uid=root; password = root ; persistsecurityinfo = True; database =inventory_test; SslMode = none";
            MySqlConnection con = new MySqlConnection(mycon);
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from Inventory", con);
                con.Open();
                dt.Load(cmd.ExecuteReader());
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void Retrieve_Categories(object sender, EventArgs e)
        {
            //connection to the category table, and displays it on the page.
            string mycon = "server =localhost; Uid=root; password = root ; persistsecurityinfo = True; database =inventory_test; SslMode = none";
            MySqlConnection con = new MySqlConnection(mycon);
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from Category", con);
                con.Open();
                dt.Load(cmd.ExecuteReader());
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}