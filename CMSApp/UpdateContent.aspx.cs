using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Drawing;

namespace CMSApp
{
    public partial class UpdateContent : System.Web.UI.Page
    {
        // Database connection string from web.config
        private string dbconfig = ConfigurationManager.ConnectionStrings["CMSdb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;

            UpdateGridViewProductType();
            UpdateGridViewProduct();
            UpdateGridViewCompany();
            UpdateGridViewJoke();
            DropDownListFiles.AutoPostBack = true;
            UpdateDropDownFiles();
        }

        public void UpdateGridViewProductType()
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "SELECT IdProductType as [Producttype Id], Name FROM ProductType";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewProductType.DataSource = rdr;
                GridViewProductType.DataBind();
            }
            catch (Exception ex)
            {
                LabelMessageProductType.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateGridViewCompany()
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "SELECT IdCompany, Name, Logo, Website FROM Company";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewCompany.DataSource = rdr;
                GridViewCompany.DataBind();
            }
            catch (Exception ex)
            {
                LabelMessageCompany.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateGridViewProduct()
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "SELECT Product.IdProduct as [Product Id], Headline, Description, Category, Picture, Product.IdCompany as [Company Id], Company.Name as [Company name], Product.IdProductType as [Producttype Id], ProductType.Name as [Producttype] FROM Product, Company, ProductType WHERE Product.IdCompany = Company.IdCompany AND Product.IdProductType = ProductType.IdProductType";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewProduct.DataSource = rdr;
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

        public void UpdateGridViewJoke()
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "SELECT IdJoke as [Joke Id], Text, Type FROM Joke";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewJoke.DataSource = rdr;
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

        protected void GridViewProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cells[count] select is 0
            TextBoxIdProductType.Text = GridViewProductType.SelectedRow.Cells[1].Text;
            TextBoxProductTypeName.Text = GridViewProductType.SelectedRow.Cells[2].Text;

            LabelMessageProductType.Text = "You have chosen Producttype " + GridViewProductType.SelectedRow.Cells[2].Text;
        }

        protected void GridViewCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cells[count] select is 0
            TextBoxIdCompany.Text = GridViewCompany.SelectedRow.Cells[1].Text;
            TextBoxCompanyName.Text = GridViewCompany.SelectedRow.Cells[2].Text;
            TextBoxLogo.Text = GridViewCompany.SelectedRow.Cells[3].Text;
            TextBoxWebsite.Text = GridViewCompany.SelectedRow.Cells[4].Text;

            LabelMessageCompany.Text = "You have chosen company " + GridViewCompany.SelectedRow.Cells[2].Text;
        }

        protected void GridViewProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cells[count] select is 0
            TextBoxIdProduct.Text = GridViewProduct.SelectedRow.Cells[1].Text;
            TextBoxHeadline.Text = GridViewProduct.SelectedRow.Cells[2].Text;
            TextBoxDescription.Text = GridViewProduct.SelectedRow.Cells[3].Text;
            TextBoxCategory.Text = GridViewProduct.SelectedRow.Cells[4].Text;
            TextBoxPicture.Text = GridViewProduct.SelectedRow.Cells[5].Text;

            LabelMessageProduct.Text = "You have chosen Product number " + GridViewProduct.SelectedRow.Cells[1].Text;

            UpdateDropDownListCompany();
            UpdateDropDownListProductType();
        }

        protected void GridViewJoke_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cells[count] select is 0
            TextBoxIdJoke.Text = GridViewJoke.SelectedRow.Cells[1].Text;
            TextBoxText.Text = GridViewJoke.SelectedRow.Cells[2].Text;
            TextBoxType.Text = GridViewJoke.SelectedRow.Cells[3].Text;

            LabelMessageJoke.Text = "You have chosen Joke " + GridViewJoke.SelectedRow.Cells[1].Text;
        }

        protected void ButtonUpdateProductType_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqludp = "UPDATE ProductType SET Name = @Name WHERE IdProductType = @IdProductType";
            // remember where : else every row will have new data

            if (TextBoxIdProductType.Text == "")
            {
                LabelMessageProductType.Text = "Please select Producttype to update";
            }
            else
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand(sqludp, conn);

                    // add parameters and value to the SQL statement
                    cmd.Parameters.Add("@IdProductType", SqlDbType.Int);
                    cmd.Parameters.Add("@Name", SqlDbType.Text);

                    cmd.Parameters["@IdProductType"].Value = Convert.ToInt32(TextBoxIdProductType.Text);
                    cmd.Parameters["@Name"].Value = TextBoxProductTypeName.Text;

                    // execute SQL statement
                    cmd.ExecuteNonQuery();

                    // message to user
                    LabelMessageProductType.Text = "Producttype " + TextBoxProductTypeName.Text + " has been updated";

                    // clear textbox
                    TextBoxIdProductType.Text = "";
                    TextBoxProductTypeName.Text = "";
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
            UpdateGridViewProductType();
        }

        protected void ButtonUpdateCompany_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqludp = "UPDATE Company SET Name = @Name, Logo = @Logo, Website = @Website WHERE IdCompany = @IdCompany";
            // remember where : else every row will have new data

            if (TextBoxIdCompany.Text == "")
            {
                LabelMessageCompany.Text = "Please select Company to update";
            }
            else
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand(sqludp, conn);

                    // add parameters and value to the SQL statement
                    cmd.Parameters.Add("@IdCompany", SqlDbType.Int);
                    cmd.Parameters.Add("@Name", SqlDbType.Text);
                    cmd.Parameters.Add("@Logo", SqlDbType.Text);
                    cmd.Parameters.Add("@Website", SqlDbType.Text);

                    cmd.Parameters["@IdCompany"].Value = TextBoxIdCompany.Text;
                    cmd.Parameters["@Name"].Value = TextBoxCompanyName.Text;
                    cmd.Parameters["@Logo"].Value = TextBoxLogo.Text;
                    cmd.Parameters["@Website"].Value = TextBoxWebsite.Text;

                    // execute SQL statement
                    cmd.ExecuteNonQuery();

                    // message to user
                    LabelMessageCompany.Text = "Company " + TextBoxCompanyName.Text + " has been updated";

                    // clear textbox
                    TextBoxIdCompany.Text = "";
                    TextBoxCompanyName.Text = "";
                    TextBoxLogo.Text = "";
                    TextBoxWebsite.Text = "";
                }
                catch (Exception ex)
                {
                    LabelMessageCompany.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            UpdateGridViewCompany();
        }

        protected void ButtonUpdateProduct_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqludp = "UPDATE Product SET Headline = @Headline, Description = @Description, Category = @Category, Picture = @Picture, IdCompany = @IdCompany, IdProductType = @IdProductType WHERE IdProduct = @IdProduct";
            // remember where : else every row will have new data

            if ((DropDownListCompany.SelectedIndex != 0) && (DropDownListProductType.SelectedIndex != 0))
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand(sqludp, conn);

                    // add parameters and value to the SQL statement
                    cmd.Parameters.Add("@IdProduct", SqlDbType.Int);
                    cmd.Parameters.Add("@Headline", SqlDbType.Text);
                    cmd.Parameters.Add("@Description", SqlDbType.Text);
                    cmd.Parameters.Add("@Category", SqlDbType.Text);
                    cmd.Parameters.Add("@Picture", SqlDbType.Text);
                    cmd.Parameters.Add("@IdCompany", SqlDbType.Int);
                    cmd.Parameters.Add("@IdProductType", SqlDbType.Int);

                    cmd.Parameters["@IdProduct"].Value = Convert.ToInt32(TextBoxIdProduct.Text);
                    cmd.Parameters["@Headline"].Value = TextBoxHeadline.Text;
                    cmd.Parameters["@Description"].Value = TextBoxDescription.Text;
                    cmd.Parameters["@Category"].Value = TextBoxCategory.Text;
                    cmd.Parameters["@Picture"].Value = TextBoxPicture.Text;
                    cmd.Parameters["@IdCompany"].Value = Convert.ToInt32(DropDownListCompany.SelectedValue);
                    cmd.Parameters["@IdProductType"].Value = Convert.ToInt32(DropDownListProductType.SelectedValue);

                    // execute SQL statement
                    cmd.ExecuteNonQuery();

                    // message to user
                    LabelMessageProduct.Text = "Product has been updated";

                    // clear textbox
                    TextBoxIdProduct.Text = "";
                    TextBoxHeadline.Text = "";
                    TextBoxDescription.Text = "";
                    TextBoxCategory.Text = "";
                    TextBoxPicture.Text = "";
                }
                catch (Exception ex)
                {
                    LabelMessageProduct.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
                }

                UpdateGridViewProduct();
            }
            else
            {
                LabelMessageProduct.Text = "Please select Company and Producttype from dropdownlists";
            }

        }

        protected void ButtonUpdateJoke_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqludp = "UPDATE Joke SET Text = @Text, Type = @Type WHERE IdJoke = @IdJoke";
            // remember where : else every row will have new data

            if (TextBoxIdJoke.Text == "")
            {
                LabelMessageJoke.Text = "Please select Joke to update";
            }
            else
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand(sqludp, conn);

                    // add parameters and value to the SQL statement
                    cmd.Parameters.Add("@IdJoke", SqlDbType.Int);
                    cmd.Parameters.Add("@Text", SqlDbType.Text);
                    cmd.Parameters.Add("@Type", SqlDbType.Text);

                    cmd.Parameters["@IdJoke"].Value = Convert.ToInt32(TextBoxIdJoke.Text);
                    cmd.Parameters["@Text"].Value = TextBoxText.Text;
                    cmd.Parameters["@Type"].Value = TextBoxType.Text;

                    // execute SQL statement
                    cmd.ExecuteNonQuery();

                    // message to user
                    LabelMessageJoke.Text = "Joke has been updated";

                    // clear textbox
                    TextBoxIdJoke.Text = "";
                    TextBoxText.Text = "";
                    TextBoxType.Text = "";
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

            UpdateGridViewJoke();
        }

        protected void ButtonDeleteProductType_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqlDel = "DELETE FROM ProductType WHERE IdProductType = @IdProductType";

            if (TextBoxIdProductType.Text == "")
            {
                LabelMessageProductType.Text = "Please select Producttype to delete";
            }
            else
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand(sqlDel, conn);
                    // add parameters and value to the SQL statement
                    cmd.Parameters.Add("@IdProductType", SqlDbType.Int);

                    cmd.Parameters["@IdProductType"].Value = TextBoxIdProductType.Text;

                    // execute SQL statement
                    cmd.ExecuteNonQuery();

                    // message to user
                    ButtonDeleteProductType.Enabled = false;
                    LabelMessageProductType.Text = "The Producttype " + TextBoxProductTypeName.Text + " has been deleted";

                    // clear textbox
                    TextBoxIdProductType.Text = "";
                    TextBoxProductTypeName.Text = "";
                }
                catch (Exception ex)
                {
                    LabelMessageProductType.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
            UpdateGridViewProductType();
        }

        protected void ButtonDeleteCompany_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqlDel = "DELETE FROM Company WHERE IdCompany = @IdCompany";

            if (TextBoxIdCompany.Text == "")
            {
                LabelMessageCompany.Text = "Please select Company to delete";
            }
            else
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand(sqlDel, conn);
                    // add parameters and value to the SQL statement
                    cmd.Parameters.Add("@IdCompany", SqlDbType.Int);

                    cmd.Parameters["@IdCompany"].Value = TextBoxIdCompany.Text;

                    // execute SQL statement
                    cmd.ExecuteNonQuery();

                    // message to user
                    LabelMessageCompany.Text = "The company " + TextBoxCompanyName.Text + " has been deleted";

                    // clear textbox
                    TextBoxIdCompany.Text = "";
                    TextBoxCompanyName.Text = "";
                    TextBoxLogo.Text = "";
                    TextBoxWebsite.Text = "";
                }
                catch (Exception ex)
                {
                    LabelMessageCompany.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            UpdateGridViewCompany();
        }

        protected void ButtonDeleteProduct_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqlDel = "DELETE FROM Product WHERE IdProduct = @IdProduct";

            if (TextBoxIdProduct.Text == "")
            {
                LabelMessageProduct.Text = "Please select Product to delete";
            }
            else
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand(sqlDel, conn);
                    cmd.Parameters.Add("@IdProduct", SqlDbType.Int);

                    cmd.Parameters["@IdProduct"].Value = TextBoxIdProduct.Text;

                    cmd.ExecuteNonQuery();

                    LabelMessageProduct.Text = "The product " + TextBoxIdProduct.Text + " has been deleted";

                    // clear textbox
                    TextBoxIdProduct.Text = "";
                    TextBoxHeadline.Text = "";
                    TextBoxDescription.Text = "";
                    TextBoxCategory.Text = "";
                    TextBoxPicture.Text = "";
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

            UpdateGridViewProduct();
        }

        protected void ButtonDeleteJoke_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlCommand cmd = null;
            string sqlDel = "DELETE FROM Joke WHERE IdJoke = @IdJoke";

            if (TextBoxIdJoke.Text == "")
            {
                LabelMessageJoke.Text = "Please select Joke to delete";
            }
            else
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand(sqlDel, conn);
                    cmd.Parameters.Add("@IdJoke", SqlDbType.Int);

                    cmd.Parameters["@IdJoke"].Value = TextBoxIdJoke.Text;

                    cmd.ExecuteNonQuery();

                    LabelMessageJoke.Text = "The joke has been deleted";

                    // clear textbox
                    TextBoxIdJoke.Text = "";
                    TextBoxText.Text = "";
                    TextBoxType.Text = "";
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

            UpdateGridViewJoke();
        }

        protected void ButtonDeleteFile_Click(object sender, EventArgs e)
        {
            string file_name = DropDownListFiles.SelectedItem.Text;
            string path = Server.MapPath("~/Pictures/" + file_name);
            FileInfo file = new FileInfo(path);

            //check file exsit or not
            if (file.Exists)
            {
                file.Delete();
                LabelMessageFiles.Text = file_name + " file deleted successfully";
                LabelMessageFiles.ForeColor = Color.Green;
                UpdateDropDownFiles();
            }
            else
            {
                LabelMessageFiles.Text = file_name + " This file does not exists ";
                LabelMessageFiles.ForeColor = Color.Red;
            }
        }

        protected void UpdateDropDownListCompany()
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "SELECT IdCompany, Name FROM Company";

            try
            {
                // conn.Open();  SqlDataAdapter open the connection by itself
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "Company");

                dt = ds.Tables["Company"];

                // populate the dropdownlist
                DropDownListCompany.Items.Clear();
                DropDownListCompany.DataSource = dt;
                DropDownListCompany.DataTextField = "Name";
                DropDownListCompany.DataValueField = "IdCompany";
                DropDownListCompany.DataBind();
                DropDownListCompany.Items.Insert(0, "Select a company");

                //Select the Company of the selected product             
                string company = GridViewProduct.SelectedRow.Cells[6].Text;
                DropDownListCompany.Items.FindByValue(company).Selected = true;
            }
            catch (Exception ex)
            {
                LabelMessageProduct.Text = ex.Message;
            }
            finally
            {
                // SqlDataAdapter closes the connection by itself, but can fail in case of errors
                conn.Close();
            }
        }

        protected void UpdateDropDownListProductType()
        {
            SqlConnection conn = new SqlConnection(dbconfig);
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "SELECT IdProductType, Name FROM ProductType";

            try
            {
                // conn.Open();  SqlDataAdapter open the connection by itself
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "ProductType");

                dt = ds.Tables["ProductType"];

                // populate the dropdownlist
                DropDownListProductType.Items.Clear();
                DropDownListProductType.DataSource = dt;
                DropDownListProductType.DataTextField = "Name";
                DropDownListProductType.DataValueField = "IdProductType";
                DropDownListProductType.DataBind();
                DropDownListProductType.Items.Insert(0, "Select a Producttype");

                //Select the Company of the selected product             
                string productType = GridViewProduct.SelectedRow.Cells[8].Text;
                DropDownListProductType.Items.FindByValue(productType).Selected = true;
            }
            catch (Exception ex)
            {
                LabelMessageProduct.Text = ex.Message;
            }
            finally
            {
                // SqlDataAdapter closes the connection by itself, but can fail in case of errors
                conn.Close();
            }
        }

        private void UpdateDropDownFiles()
        {
            // remember selected item during postback
            string oldselection = DropDownListFiles.SelectedValue;

            DropDownListFiles.Items.Clear();
            string filename;
            string[] allmyfiles = Directory.GetFiles(Server.MapPath("~/Pictures/"));
            DropDownListFiles.Items.Insert(0, "Select a file to delete");
            for (int i = 0; i < allmyfiles.Length; i++)
            {
                filename = new FileInfo(allmyfiles[i]).Name;
                DropDownListFiles.Items.Add(filename);
                if (filename == oldselection) DropDownListFiles.SelectedIndex = i;
            }
        }

        protected void DropDownListCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCompany.SelectedIndex != 0)
            {
                ButtonUpdateProduct.Enabled = true;
                LabelMessageProduct.Text = "";
            }
            else
            {
                LabelMessageProduct.Text = "Please select a company";
            }
        }

        protected void DropDownListProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListProductType.SelectedIndex != 0)
            {
                LabelMessageProduct.Text = "";
            }
            else
            {
                LabelMessageProduct.Text = "Please select a Producttype";
            }
        }
    }
}