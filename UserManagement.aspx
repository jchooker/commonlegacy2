<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="CommonLegacy.UserManagement" %>
<%@ Register TagPrefix="uc" TagName="UsersDataTable" Src="UsersDataTable.ascx"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/lib/css/usermgmt.css" />
    <script src="./Scripts/datatable1.js" language="javascript" type="text/javascript"></script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card mt-3">
                    <div id="toggle-header" class="card-header vis">
                        <img src="https://i.ibb.co/tJDG3RR/Silhueta-png-cinzento-300x284.png" class="card-img-top profile-img align-self-center mt-3" alt="blank-user"/>
                        <h2 class="mt-2 font2">User Data</h2>
                    </div>
                    <div class="card-body">
                        <h1 class="pre-sel">Select a user to modify or delete</h1>
                        <div id="hidden-body" class="vis">
                            <div class="row">
                                <div class="input-group col-md-5">
                                    <div class="row d-flex justify-contents-between w-100 mb-2">
                                        <div class="col-2">
                                            <label class="col-form-label" for="first-name-mod">First Name: &nbsp;</label>
                                        </div>
                                        <div class="col-4">
                                            <input id="first-name-mod" name="first-name-mod" class="form-control font3" />
                                        </div>
                                        <div class="col-2">
                                            <label class="col-form-label" for="last-name-mod">Last Name: &nbsp;</label>
                                        </div>
                                        <div class="col-4">
                                            <input id="last-name-mod" name="last-name-mod" class="form-control font3" />
                                        </div>
                                    </div>
                                </div>                            
                                <div class="input-group col-md-5">
                                    <div class="row d-flex justify-contents-between w-100 mb-2">
                                        <div class="col-2">
                                            <label class="col-form-label" for="email-mod">Email: &nbsp;</label>
                                        </div>
                                        <div class="col-4">
                                            <input id="email-mod" name="email-mod" class="form-control font3" type="email" />
                                        </div>                                            
                                        <div class="col-2">
                                            <label class="col-form-label" for="gender-mod">Gender: &nbsp;</label>
                                        </div>
                                        <div class="col-4">
                                            <input id="gender-mod" name="gender-mod" class="form-control font3" />
                                        </div>
                                    </div>
                                </div>
                                <div class="input-group col-md-5">
                                    <div class="row d-flex justify-contents-between w-100 mb-2">
                                        <div class="col-2">
                                            <label class="col-form-label" for="age-mod">Age: &nbsp;</label>
                                        </div>
                                        <div class="col-4">
                                            <input id="age-mod" name="age-mod" class="form-control font3" type="number" />
                                        </div>                                            
                                        <div class="col-2">
                                            <label class="col-form-label" for="country-mod">Country: &nbsp;</label>
                                        </div>
                                        <div class="col-4">
                                            <input id="country-mod" name="country-mod" class="form-control font3" />
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="d-grid gap-2">
                                <button class="btn btn-success btn-lg font2 mt-4" type="button" onclick="modifyUserInit();">Submit Modifications</button>
                                <button class="btn btn-danger btn-lg font2" type="button">DELETE USER</button>
                                <button class="btn btn-secondary btn-lg font2" type="button">Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            <div class="col-md-7">
                <div class="card mt-3">
                    <div class="card-body">
                        <uc:UsersDataTable id="UserDataTableControl1" runat="server" namespace="CommonLegacy"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
