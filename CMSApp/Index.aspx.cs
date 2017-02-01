using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CMSApp
{
    public partial class Index : System.Web.UI.Page
    {
        // Database connection string from web.config
        private string dbconfig = ConfigurationManager.ConnectionStrings["CMSdb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowSelectedJokes();
            ShowSelectedProducts();
        }

        public void ShowSelectedProducts()
        {
            SqlConnection conn = new SqlConnection(dbconfig);

            //string sqlsel = "SELECT Joke.Text, SelectedJoke.IdJoke FROM Joke, SelectedJoke WHERE SelectedJoke.IdJoke = Joke.IdJoke";
            //string sqlsel = "SELECT TOP 2 Joke.Text, SelectedJoke.Timestamp FROM Joke LEFT JOIN SelectedJoke ON Joke.IdJoke = SelectedJoke.IdJoke ORDER BY SelectedJoke.Timestamp DESC";
            string sqlsel = "SELECT * FROM Product, SelectedProduct WHERE SelectedProduct.IdProduct = Product.IdProduct";
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sqlsel, conn);
                da.Fill(dt);
                RepeaterSelectedProducts.DataSource = dt;
                RepeaterSelectedProducts.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

        }

        public void ShowSelectedJokes()
        {
            SqlConnection conn = new SqlConnection(dbconfig);

            string sqlsel = "SELECT Joke.Text, SelectedJoke.IdJoke FROM Joke, SelectedJoke WHERE SelectedJoke.IdJoke = Joke.IdJoke";
            //string sqlsel = "SELECT TOP 2 Joke.Text, SelectedJoke.Timestamp FROM Joke LEFT JOIN SelectedJoke ON Joke.IdJoke = SelectedJoke.IdJoke ORDER BY SelectedJoke.Timestamp DESC";
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sqlsel, conn);
                da.Fill(dt);
                RepeaterSelectedJokes.DataSource = dt;
                RepeaterSelectedJokes.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

    }
}