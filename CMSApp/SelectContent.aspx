<%@ Page Title="" Language="C#" MasterPageFile="~/CMSsite.Master" AutoEventWireup="true" CodeBehind="SelectContent.aspx.cs" Inherits="CMSApp.SelectContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2>Select Content to Frontpage</h2>
            </div>
        </div>
        <div class="row">                 
            <div id="Products" class="form-group">
                <div class="col-md-12">
                    <h3>Products</h3> 
                    <asp:GridView ID="GridViewProduct" CssClass="table-striped table-bordered" runat="server" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="IdProduct"  
                    PagerSettings-Mode="Numeric">
                        <Columns> 
                            <asp:TemplateField HeaderText="Select"> 
                                <ItemTemplate> 
                                    <asp:CheckBox ID="chkSelect" runat="server" /> 
                                </ItemTemplate> 
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Highlight"> 
                                <ItemTemplate> 
                                    <asp:CheckBox ID="chkHighlight" runat="server" /> 
                                </ItemTemplate> 
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Product ID" DataField="IdProduct" /> 
                            <asp:BoundField HeaderText="Headline" DataField="Headline" /> 
                            <asp:BoundField HeaderText="Description" DataField="Description" />
                            <asp:BoundField HeaderText="Category" DataField="Category" />
                            <asp:BoundField HeaderText="Picture" DataField="Picture" />
                            <asp:BoundField HeaderText="Company Id" DataField="IdCompany" />
                            <asp:BoundField HeaderText="Producttype" DataField="IdProductType" />
                        </Columns>  
                    </asp:GridView>
                </div>
                <div class="col-md-12">                    
                    <asp:Button ID="ButtonSelectProduct" CssClass="btn btn-primary" runat="server" Text="Save selected Data" OnClick="ButtonSelectProduct_Click" />
                    <asp:Label ID="LabelMessageProduct" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">                 
            <div id="Joke" class="form-group">
                <div class="col-md-12">
                    <h3>Jokes</h3> 
                    <asp:GridView ID="GridViewJoke" CssClass="table-striped table-bordered" runat="server" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="IdJoke"  
                    PagerSettings-Mode="Numeric">
                        <Columns> 
                            <asp:TemplateField HeaderText="Select"> 
                                <ItemTemplate> 
                                    <asp:CheckBox ID="chkSelect" runat="server" /> 
                                </ItemTemplate> 
                            </asp:TemplateField> 
                            <asp:BoundField HeaderText="Joke ID" DataField="IdJoke" /> 
                            <asp:BoundField HeaderText="Text" DataField="Text" /> 
                            <asp:BoundField HeaderText="Type" DataField="Type" />
                        </Columns>  
                    </asp:GridView>
                </div>
                <div class="col-md-12">                    
                    <asp:Button ID="ButtonSelectJoke" CssClass="btn btn-primary" runat="server" Text="Save selected Data" OnClick="ButtonSelectJoke_Click" />
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <asp:Label ID="LabelMessageJoke" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
