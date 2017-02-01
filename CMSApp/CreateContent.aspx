<%@ Page Language="C#" MasterPageFile="~/CMSsite.Master" AutoEventWireup="true" CodeBehind="CreateContent.aspx.cs" Inherits="CMSApp.CreateContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2>Create New Content</h2>
            </div>
        </div>      
            <div id="ProductType" class="form-group">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Create Producttype</h3> 
                    </div>                
                    <div class="col-xs-6">             
                        <asp:GridView ID="GridViewProductType" CssClass="table-striped table-bordered" runat="server">
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelProdType" runat="server" Text="Producttype"></asp:Label>
                        <asp:TextBox ID="TextBoxProductType" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-xs-6">
                        <asp:Button ID="ButtonCreateCategory" class="btn btn-primary" runat="server" OnClick="ButtonCreateCategory_Click" Text="Create Producttype" />                       
                        <asp:Label ID="LabelMessageProductType" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div id="Company" class="form-group">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Create Company</h3>
                    </div>
                    <div class="col-xs-6">
                        <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
                        <asp:TextBox ID="TextBoxName" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">   
                        <asp:Label ID="LabelLogo" runat="server" Text="Picture"></asp:Label> 
                        <asp:FileUpload id="FileUploadLogo" runat="server"></asp:FileUpload>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelWebSite" runat="server" Text="Website"></asp:Label>
                        <asp:TextBox ID="TextBoxWebsite" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Button ID="ButtonCreateCompany" class="btn btn-primary" runat="server" OnClick="ButtonCreateCompany_Click" Text="Create Company" />
                        <asp:Label ID="LabelMessageCompany" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div id="Product" class="form-group">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Create Product</h3>
                    </div>
                    <div class="col-xs-6"> 
                        <asp:Label ID="LabelHeadline" runat="server" Text="Headline"></asp:Label>
                        <asp:TextBox ID="TextBoxHeadline" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelDescription" runat="server" Text="Description"></asp:Label>
                        <asp:TextBox ID="TextBoxDescription" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelCategory" runat="server" Text="Category"></asp:Label>
                        <asp:TextBox ID="TextBoxCategory" class="form-control" runat="server"></asp:TextBox>
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
                        <asp:Label ID="LabelProductType" runat="server" Text="ProductType"></asp:Label>
                        <asp:DropDownList ID="DropDownListProductType" class="form-control" runat="server" OnSelectedIndexChanged="DropDownListProductType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">   
                        <asp:Label ID="LabelPicture" runat="server" Text="Picture"></asp:Label> 
                        <asp:FileUpload id="FileUploadPicture" runat="server"></asp:FileUpload>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Button ID="ButtonCreateProduct" class="btn btn-primary" runat="server" OnClick="ButtonCreateProduct_Click" Text="Create product" />
                        <asp:Label ID="LabelMessageProduct" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div id="Joke" class="form-group">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Create Joke</h3>
                    </div>
                    <div class="col-xs-6">
                        <asp:Label ID="LabelText" runat="server" Text="Text"></asp:Label>
                        <asp:TextBox ID="TextBoxText" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label ID="LabelType" runat="server" Text="Type"></asp:Label>
                        <asp:TextBox ID="TextBoxType" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Button ID="ButtonCreateJoke" class="btn btn-primary" runat="server" OnClick="ButtonCreateJoke_Click" Text="Create joke" />
                        <asp:Label ID="LabelMessageJoke" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>

