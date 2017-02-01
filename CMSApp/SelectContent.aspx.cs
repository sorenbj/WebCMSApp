using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace CMSApp
{
    public partial class SelectContent : System.Web.UI.Page
    {
        // Database connection string from web.config
        private string dbconfig = ConfigurationManager.ConnectionStrings["CMSdb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                this.UpdateGridViewProduct();
                this.UpdateGridViewJoke();
            }
        }

        private void UpdateSelectedProductRecord(int ProductId, DateTime timestamp, int highlight)
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqlins = "INSERT INTO SelectedProduct(Timestamp, Highlight, IdProduct) VALUES (@Timestamp, @Highlight, @IdProduct)";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlins, conn);

                cmd.Parameters.Add("@Timestamp", SqlDbType.DateTime);
                cmd.Parameters["@Timestamp"].Value = timestamp;

                cmd.Parameters.Add("@Highlight", SqlDbType.Int);
                cmd.Parameters["@Highlight"].Value = highlight;

                cmd.Parameters.Add("@IdProduct", SqlDbType.Int);
                cmd.Parameters["@IdProduct"].Value = Convert.ToInt32(ProductId);

                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                LabelMessageProduct.Text = ex.Message;
            }

            finally
            {
                conn.Close();
            }
        }

        private void UpdateSelectedJokeRecord(int jokeId, DateTime timestamp)
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqlins = "INSERT INTO SelectedJoke(Timestamp, IdJoke) VALUES (@Timestamp, @IdJoke)";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlins, conn);

                cmd.Parameters.Add("@Timestamp", SqlDbType.DateTime);
                cmd.Parameters["@Timestamp"].Value = timestamp;

                cmd.Parameters.Add("@IdJoke", SqlDbType.Int);
                cmd.Parameters["@IdJoke"].Value = Convert.ToInt32(jokeId);

                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                LabelMessageJoke.Text = ex.Message;
            }

            finally
            {
                conn.Close();
            }
        }

        private void UpdateGridViewProduct()
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            SqlDataAdapter sda = null;
            DataTable dt = null;
            string sqlsel = "SELECT* FROM Product";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);
                GridViewProduct.DataSource = dt;
                GridViewProduct.DataBind();
            }
            catch (Exception ex)
            {
                LabelMessageProduct.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateGridViewJoke()
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            SqlDataAdapter sda = null;
            DataTable dt = null;
            string sqlsel = "SELECT * FROM Joke";

            try
            {
                cmd = new SqlCommand(sqlsel, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);
                GridViewJoke.DataSource = dt;
                GridViewJoke.DataBind();
            }
            catch (Exception ex)
            {
                LabelMessageJoke.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonSelectProduct_Click(object sender, EventArgs e)
        {
            int selectCount = 0;
            int highlightCount = 0;
            bool highlightError = true;
            DateTime timestamp = DateTime.Now;
            int productId;
            int highlight = 0;

            // Check how many products are highlighted - only one allowed
            foreach (GridViewRow row in GridViewProduct.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkSel = (row.Cells[0].FindControl("chkSelect") as CheckBox);
                    CheckBox chkHigh = (row.Cells[0].FindControl("chkHighlight") as CheckBox);

                    //both select and highlight                  
                    if (chkSel.Checked)
                    {
                        if (chkHigh.Checked)
                        {
                            selectCount++;
                            highlightCount++;
                        }
                        selectCount++;                  
                    }
                    else
                    {
                        if (chkHigh.Checked)
                        {
                            highlightError = false;
                        }
                    }            
                }
            }

            // to many products are highlighted
            if ((highlightCount == 0) || highlightCount > 1 || (!highlightError))
            {
                LabelMessageProduct.Text = "Error in selection - please make a new selection";
                ClearCheckBoxProduct();
            }
            else
            {
                DeleteSelectedProduct();

                foreach (GridViewRow row in GridViewProduct.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkSel = (row.Cells[0].FindControl("chkSelect") as CheckBox);
                        CheckBox chkHigh = (row.Cells[0].FindControl("chkHighlight") as CheckBox);

                        //both select and highlight
                        if ((chkSel.Checked) && (chkHigh.Checked))
                        {
                            productId = Convert.ToInt32(row.Cells[2].Text);
                            highlight = 1;
                            UpdateSelectedProductRecord(productId, timestamp, highlight);
                        }
                        else if ((chkSel.Checked) && (!chkHigh.Checked))
                        {
                            productId = Convert.ToInt32(row.Cells[2].Text);
                            highlight = 0;
                            UpdateSelectedProductRecord(productId, timestamp, highlight);
                        }
                    }
                }
                LabelMessageProduct.Text = "Data saved";
                ClearCheckBoxProduct();
            }                 
        }

        protected void ButtonSelectJoke_Click(object sender, EventArgs e)
        {
            int jokeId;
            DateTime timestamp = DateTime.Now;

            DeleteSelectedJoke();

            foreach (GridViewRow row in GridViewJoke.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkSelect") as CheckBox);
                    if (chkRow.Checked)
                    {
                        jokeId = Convert.ToInt32(row.Cells[1].Text);
                        UpdateSelectedJokeRecord(jokeId, timestamp);
                    }
                }
            }
            LabelMessageJoke.Text = "Data saved";

            ClearCheckBoxJoke();
        }

        private void ClearCheckBoxProduct()
        {
            // Clear chechbox selection
            foreach (GridViewRow row in GridViewProduct.Rows)
            {
                var cbRowSel = row.FindControl("chkSelect") as CheckBox;
                if (cbRowSel != null)
                {
                    cbRowSel.Checked = false;
                }

                var cbRowHigh = row.FindControl("chkHighlight") as CheckBox;
                if (cbRowHigh != null)
                {
                    cbRowHigh.Checked = false;
                }
            }
        }

        private void ClearCheckBoxJoke()
        {
            // Clear chechbox selection
            foreach (GridViewRow row in GridViewJoke.Rows)
            {
                var cbRowSel = row.FindControl("chkSelect") as CheckBox;
                if (cbRowSel != null)
                {
                    cbRowSel.Checked = false;
                }
            }
        }

        protected void DeleteSelectedJoke()
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqlDel = "DELETE FROM SelectedJoke";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlDel, conn);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LabelMessageJoke.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void DeleteSelectedProduct()
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqlDel = "DELETE FROM SelectedProduct";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlDel, conn);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LabelMessageJoke.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    } 
}