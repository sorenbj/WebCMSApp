<%@ Page Title="" Language="C#" MasterPageFile="~/CMSsite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CMSApp.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Frontpage</h1>
                <h4>Template with selected products and jokes</h4>
            </div>
        </div>
        <!-- Display selected products -->
        <div class="row">
            <div class="col-md-12">
                <h2>Products</h2>
            </div>
            <asp:Repeater ID="RepeaterSelectedProducts" runat="server">
                <ItemTemplate>

                    <div class="col-md-3 line <%# ((int)Eval("Highlight") == 1) ? "highlight" : "" %>">
                        <div class="SelectedProducts">
                            <h3 class="text-center"><%# Eval("Headline") %></h3>
                            <img src="Pictures/<%# Eval("Picture") %>" alt="<%# Eval("Headline") %>" class="img-responsive" />
                            <p><strong><%# Eval("Description") %></strong></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- Display selected jokes -->
        <div class="row">
            <div class="col-md-12">
                <h2>Jokes</h2>
            </div>
            <asp:Repeater ID="RepeaterSelectedJokes" runat="server">
                <ItemTemplate>
                    <div class="col-md-12">
                        <div class="SelectedJokes">
                            <blockquote>
                                <h3><%# Eval("Text") %></h3>
                            </blockquote>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
