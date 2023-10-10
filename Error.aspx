<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="CommonLegacy.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="color: red; font-family: 'Raleway', sans-serif">
        <i>Error: <%= Request.QueryString["message"] %></i>
    </h1>
    <h3 style="color: red; font-family: 'Raleway', sans-serif">
        <i>Error: <%= Request.QueryString["stack"] %></i>
    </h3>
    <h5 style="color: red; font-family: 'Raleway', sans-serif">
        <i>Error: <%= Request.QueryString["info"] %></i>
    </h5>
</asp:Content>
