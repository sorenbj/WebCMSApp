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
    public partial class CreateContent : System.Web.UI.Page
    {
        // Database connection string from web.config
        private string dbconfig = ConfigurationManager.ConnectionStrings["CMSdb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (!Page.IsPostBack)
            {
                UpdateDropDownListCompany();
                UpdateDropDownListProductType();
            }

            DropDownListCompany.AutoPostBack = true;
            DropDownListProductType.AutoPostBack = true;
            UpdateGridViewProductType();
        }

        private void UpdateGridViewProductType()
        {
            // Create a db connection with configuration from web.config
            SqlConnection conn = new SqlConnection(dbconfig);

            //SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = CMSdb");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlread = "SELECT IdProductType as [Producttype ID], Name FROM ProductType";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlread, conn);

                rdr = cmd.ExecuteReader();

                GridViewProductType.DataSource = rdr;
                GridViewProductType.DataBind();
            }

            catch (Exception ex)
            {
                LabelProdType.Text = ex.Message;
            }

            finally
            {
                conn.Close();
            }
        }

        protected void UpdateDropDownListCompany()
        {
            // Create a db connection with configuration from web.config
            SqlConnection conn = new SqlConnection(dbconfig);

            //SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = CMSdb");
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
            // Create a db connection with configuration from web.config
            SqlConnection conn = new SqlConnection(dbconfig);

            //SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = CMSdb");
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

        protected void DropDownListCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCompany.SelectedIndex != 0)
            {
                ButtonCreateProduct.Enabled = true;
                LabelMessageProduct.Text = "";
            }
            else
            {
                LabelMessageProduct.Text = "Please select a company";
                ButtonCreateProduct.Enabled = false;
            }
        }

        protected void DropDownListProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListProductType.SelectedIndex != 0)
            {
                ButtonCreateProduct.Enabled = true;
                LabelMessageProduct.Text = "";
            }
            else
            {
                LabelMessageProduct.Text = "Please select a Producttype";
                ButtonCreateProduct.Enabled = false;
            }
        }

        protected void ButtonCreateCategory_Click(object sender, EventArgs e)
        {
            // Create a db connection with configuration from web.config
            SqlConnection conn = new SqlConnection(dbconfig);

            //SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = CMSdb");
            SqlCommand cmd = null;
            string sqlins = "INSERT INTO ProductType VALUES (@name)";

            if (TextBoxProductType.Text == "")
            {
                LabelMessageProductType.Text = "Please enter a producttype";
            }
            else
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand(sqlins, conn);

                    cmd.Parameters.Add("@name", SqlDbType.Text);
                    cmd.Parameters["@name"].Value = TextBoxProductType.Text;

                    cmd.ExecuteNonQuery();

                    LabelMessageProductType.Text = "Producttype has been created";

                    UpdateGridViewProductType();
                    UpdateDropDownListProductType();
                    TextBoxProductType.Text = "";
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
        }

        protected void ButtonCreateProduct_Click(object sender, EventArgs e)
        {
            // Create a db connection with configuration from web.config
            SqlConnection conn = new SqlConnection(dbconfig);

            //SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = CMSdb");
            SqlCommand cmd = null;
            string sqlins = "INSERT INTO Product(Headline, Description, Category, Picture, IdCompany, IdProductType) VALUES (@Headline, @Description, @Category, @Picture, @IdCompany, @IdProductType)";

            if ((TextBoxHeadline.Text == "") || (TextBoxDescription.Text == "") || (TextBoxCategory.Text == ""))
            {
                LabelMessageProduct.Text = "Please enter product information";
            }
            else
            {
                try
                {
                    UploadPicture();

                    conn.Open();

                    cmd = new SqlCommand(sqlins, conn);

                    cmd.Parameters.Add("@Headline", SqlDbType.Text);
                    cmd.Parameters["@Headline"].Value = TextBoxHeadline.Text;

                    cmd.Parameters.Add("@Description", SqlDbType.Text);
                    cmd.Parameters["@Description"].Value = TextBoxDescription.Text;

                    cmd.Parameters.Add("@Category", SqlDbType.Text);
                    cmd.Parameters["@Category"].Value = TextBoxCategory.Text;

                    cmd.Parameters.Add("@Picture", SqlDbType.Text);
                    cmd.Parameters["@Picture"].Value = FileUploadPicture.FileName.ToString();

                    cmd.Parameters.Add("@IdCompany", SqlDbType.Int);
                    cmd.Parameters["@IdCompany"].Value = Convert.ToInt32(DropDownListCompany.SelectedValue);

                    cmd.Parameters.Add("@IdProductType", SqlDbType.Int);
                    cmd.Parameters["@IdProductType"].Value = Convert.ToInt32(DropDownListProductType.SelectedValue);

                    cmd.ExecuteNonQuery();

                    LabelMessageProduct.Text = "Product has been created";

                    TextBoxHeadline.Text = "";
                    TextBoxDescription.Text = "";
                    TextBoxCategory.Text = "";
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
        }

        protected void ButtonCreateCompany_Click(object sender, EventArgs e)
        {
            // Create a db connection with configuration from web.config
            SqlConnection conn = new SqlConnection(dbconfig);

            //SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = CMSdb");
            SqlCommand cmd = null;
            string sqlins = "INSERT INTO Company(Name, Logo, Website) values (@Name, @Logo, @Website)";

            if ((TextBoxName.Text == "") || (TextBoxWebsite.Text == ""))
            {
                LabelMessageCompany.Text = "Please enter company information";
            }
            else
            {
                try
                {
                    UploadLogo();
                    conn.Open();

                    cmd = new SqlCommand(sqlins, conn);

                    cmd.Parameters.Add("@Name", SqlDbType.Text);
                    cmd.Parameters["@Name"].Value = TextBoxName.Text;

                    cmd.Parameters.Add("@Logo", SqlDbType.Text);
                    cmd.Parameters["@Logo"].Value = FileUploadLogo.FileName.ToString();

                    cmd.Parameters.Add("@Website", SqlDbType.Text);
                    cmd.Parameters["@Website"].Value = TextBoxWebsite.Text;

                    cmd.ExecuteNonQuery();

                    LabelMessageCompany.Text = "Company has been created";

                    TextBoxName.Text = "";
                    TextBoxWebsite.Text = "";

                    UpdateDropDownListCompany();
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
        }

        protected void ButtonCreateJoke_Click(object sender, EventArgs e)
        {
            // Create a db connection with configuration from web.config
            SqlConnection conn = new SqlConnection(dbconfig);

            //SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = CMSdb");
            SqlCommand cmd = null;
            string sqlins = "INSERT INTO Joke(Text, Type) VALUES (@Text, @Type)";

            if ((TextBoxText.Text == "") || (TextBoxType.Text == ""))
            {
                LabelMessageJoke.Text = "Please enter a text or joke type";
            }
            else
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand(sqlins, conn);

                    cmd.Parameters.Add("@Text", SqlDbType.Text);
                    cmd.Parameters["@Text"].Value = TextBoxText.Text;

                    cmd.Parameters.Add("@Type", SqlDbType.Text);
                    cmd.Parameters["@Type"].Value = TextBoxType.Text;

                    cmd.ExecuteNonQuery();

                    LabelMessageProductType.Text = "Joke has been created";

                    TextBoxText.Text = "";
                    TextBoxType.Text = "";

                    UpdateGridViewProductType();
                    UpdateDropDownListProductType();
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

        protected void UploadPicture()
        {
            // Specify the path
            String savePath = Server.MapPath("~/Pictures/");

            // Verify that the FileUpload control contains a file.
            if (FileUploadPicture.HasFile)
            {
                // Get the name of the file to upload.
                String fileName = FileUploadPicture.FileName;

                // Get the extension of the uploaded file.
                string extension = System.IO.Path.GetExtension(fileName);

                if ((extension == ".jpg") || (extension == ".png"))
                {
                    // Add the path to the name of the file to upload
                    savePath += fileName;

                    // Call the SaveAs method to save the uploaded file to the path.
                    FileUploadPicture.SaveAs(savePath);

                    LabelMessageProduct.Text = "The file was saved as " + fileName;
                }
                else
                {
                    LabelMessageProduct.Text = "The file was not uploaded because it does not have a .jpg or .png extension.";
                }
            }
            else
            {
                // Notify the user that a file was not uploaded.
                LabelMessageProduct.Text = "Please specify a file to upload.";
            }
        }

        protected void UploadLogo()
        {
            // Specify the path
            String savePath = Server.MapPath("~/Pictures/");

            // Verify that the FileUpload control contains a file.
            if (FileUploadLogo.HasFile)
            {
                // Get the name of the file to upload.
                String fileName = FileUploadLogo.FileName;

                // Get the extension of the uploaded file.
                string extension = System.IO.Path.GetExtension(fileName);

                if ((extension == ".jpg") || (extension == ".png"))
                {
                    // Add the path to the name of the file to upload
                    savePath += fileName;

                    // Call the SaveAs method to save the uploaded file to the path.
                    FileUploadLogo.SaveAs(savePath);

                    LabelMessageCompany.Text = "The file was saved as " + fileName;
                }
                else
                {
                    LabelMessageCompany.Text = "The file was not uploaded because it does not have a .jpg or .png extension.";
                }
            }
            else
            {
                // Notify the user that a file was not uploaded.
                LabelMessageCompany.Text = "Please specify a file to upload.";
            }
        }
    }
}
