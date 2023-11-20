<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TileShuffle.aspx.cs" Inherits="CommonLegacy.TileShuffle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script type="importmap">
        {
            "imports": {
                "three": "https://unpkg.com/three@0.158.0/build/three.module.js",
                "three/addons/": "https://unpkg.com/three@0.158.0/examples/jsm/"
            }
        }
    </script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/three.js/0.158.0/three.min.js" integrity="sha512-/WaZCC76Yn6MLEoK6b9np9yiLBet/RngBS33X1P0SHuag6j2E0e5rT7jbA2CvXCydN6+FkDYNx8FBM+vkzsthw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdn.jsdelivr.net/npm/drag-controls@1.0.4/dist/drag-controls.min.js" integrity="sha256-BwQsWYJdW0ySIydV2OMDy10v6c0Mb/hckE5qqKAV3XE=" crossorigin="anonymous"></script>
    <script src="./lib/js/tileshuffle.js" language="javascript" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="/lib/css/tileshuffle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="threejscontainer">
    </div>
</asp:Content>
