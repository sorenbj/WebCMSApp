<%@ Page Language="C#" MasterPageFile="~/CMSsite.Master" AutoEventWireup="true" CodeBehind="UpdateContent.aspx.cs" Inherits="CMSApp.UpdateContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2>Update and Delete Content</h2>
            </div>
        </div>      
             <div id="ProductType" class="form-group">
                <div class="row">                 
                    <div class="col-xs-12">
                    <h3>Update Producttype</h3> 
                        <asp:GridView ID="GridViewProductType" CssClass="table-striped table-bordered" runat="server" OnSelectedIndexChanged="GridViewProductType_SelectedIndexChanged" AutoGenerateColumns="True">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="LabelMessageProductType" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelIdProductType" runat="server" Text="Producttype Id"></asp:Label>       
                        <asp:TextBox ID="TextBoxIdProductType" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div> 
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelProductTypeName" runat="server" Text="Name"></asp:Label>       
                        <asp:TextBox ID="TextBoxProductTypeName" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                </div>  
                 <div class="row">
                    <div class="col-xs-3">
                        <asp:Button ID="ButtonUpdateProductType" class="btn btn-success" runat="server" OnClick="ButtonUpdateProductType_Click" Text="Update" />
                    </div>
                    <div class="col-xs-3">
                        <asp:Button ID="ButtonDeleteProductType" class="btn btn-danger" runat="server" OnClick="ButtonDeleteProductType_Click" Text="Delete" />
                    </div>
                </div>
             </div>
             <div id="Company" class="form-group">
                <div class="row">                 
                    <div class="col-xs-12">
                    <h3>Update Company</h3> 
                        <asp:GridView ID="GridViewCompany" CssClass="table-striped table-bordered" runat="server" OnSelectedIndexChanged="GridViewCompany_SelectedIndexChanged" AutoGenerateColumns="True">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="LabelMessageCompany" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelIdCompany" runat="server" Text="Company Id"></asp:Label>       
                        <asp:TextBox ID="TextBoxIdCompany" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div> 
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelCompanyName" runat="server" Text="Name"></asp:Label>       
                        <asp:TextBox ID="TextBoxCompanyName" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                </div>  
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelLogo" runat="server" Text="Logo"></asp:Label>       
                        <asp:TextBox ID="TextBoxLogo" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                </div>  
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelWebsite" runat="server" Text="Website"></asp:Label>       
                        <asp:TextBox ID="TextBoxWebsite" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                </div> 
                <div class="row">
                    <div class="col-xs-3">
                        <asp:Button ID="ButtonUpdateCompany" class="btn btn-success" runat="server" OnClick="ButtonUpdateCompany_Click" Text="Update" />
                    </div>
                    <div class="col-xs-3">
                        <asp:Button ID="ButtonDeleteCompany" class="btn btn-danger" runat="server" OnClick="ButtonDeleteCompany_Click" Text="Delete" />
                    </div>
                </div>
            </div>
            <div id="Product" class="form-group">
                <div class="row">                 
                    <div class="col-xs-12">
                    <h3>Update Product</h3> 
                        <asp:GridView ID="GridViewProduct" CssClass="table-striped table-bordered" runat="server" OnSelectedIndexChanged="GridViewProduct_SelectedIndexChanged" AutoGenerateColumns="True">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="LabelMessageProduct" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelIdProduct" runat="server" Text="Product Id"></asp:Label>       
                        <asp:TextBox ID="TextBoxIdProduct" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div> 
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelHeadline" runat="server" Text="Headline"></asp:Label>       
                        <asp:TextBox ID="TextBoxHeadline" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                </div>  
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelDescription" runat="server" Text="Description"></asp:Label>       
                        <asp:TextBox ID="TextBoxDescription" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                </div>  
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelCategory" runat="server" Text="Category"></asp:Label>       
                        <asp:TextBox ID="TextBoxCategory" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                </div> 
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelPicture" runat="server" Text="Picture"></asp:Label>       
                        <asp:TextBox ID="TextBoxPicture" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                </div>   
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelCompany" runat="server" Text="Company"></asp:Label>  
                        <asp:DropDownList ID="DropDownListCompany" class="form-control" runat="server" OnSelectedIndexChanged="DropDownListCompany_SelectedIndexChanged">
                        </asp:DropDownList>     
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelProductType" runat="server" Text="Producttype"></asp:Label>  
                        <asp:DropDownList ID="DropDownListProductType" class="form-control" runat="server" OnSelectedIndexChanged="DropDownListProductType_SelectedIndexChanged">
                        </asp:DropDownList>     
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-3">
                        <asp:Button ID="ButtonUpdateProduct" class="btn btn-success" runat="server" OnClick="ButtonUpdateProduct_Click" Text="Update" />
                    </div>
                    <div class="col-xs-3">
                        <asp:Button ID="ButtonDeleteProduct" class="btn btn-danger" runat="server" OnClick="ButtonDeleteProduct_Click" Text="Delete" />
                    </div>
                </div>                  
            </div>  
            <div id="Joke" class="form-group">
                <div class="row">                 
                    <div class="col-xs-12">
                    <h3>Update Jokes</h3> 
                        <asp:GridView ID="GridViewJoke" CssClass="table-striped table-bordered" runat="server" OnSelectedIndexChanged="GridViewJoke_SelectedIndexChanged" AutoGenerateColumns="True">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="LabelMessageJoke" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelIdJoke" runat="server" Text="Joke Id"></asp:Label>       
                        <asp:TextBox ID="TextBoxIdJoke" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div> 
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelText" runat="server" Text="Text"></asp:Label>       
                        <asp:TextBox ID="TextBoxText" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                </div>  
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelType" runat="server" Text="Type"></asp:Label>       
                        <asp:TextBox ID="TextBoxType" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                </div>  
                <div class="row">
                    <div class="col-xs-3">
                        <asp:Button ID="ButtonUpdateJoke" class="btn btn-success" runat="server" OnClick="ButtonUpdateJoke_Click" Text="Update" />
                    </div>
                    <div class="col-xs-3">
                        <asp:Button ID="ButtonDeleteJoke" class="btn btn-danger" runat="server" OnClick="ButtonDeleteJoke_Click" Text="Delete" />
                    </div>
                </div>  
            </div>  
            <div id="File" class="form-group">
                <div class="row">                 
                    <div class="col-xs-6">
                    <h3>Delete Files</h3> 
                        <asp:Label ID="LabelFile" runat="server" Text="Select File"></asp:Label>  
                        <asp:DropDownList ID="DropDownListFiles" class="form-control" runat="server">
                        </asp:DropDownList>
                        <asp:Label ID="LabelMessageFiles" runat="server"></asp:Label>
                        <asp:Button ID="ButtonDeleteFile" class="btn btn-danger" runat="server" Text="Delete" OnClick="ButtonDeleteFile_Click" />
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
