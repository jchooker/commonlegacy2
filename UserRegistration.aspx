<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="CommonLegacy.UserRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
            <%--^^change to "container-fluid"?--%>
        <div class="row">
            <div class="col-md-6 mx-auto mt-3">
                <div class="card border-secondary mb-3 text-center">
                    <div class="card-header">
                      <img src="https://i.ibb.co/tJDG3RR/Silhueta-png-cinzento-300x284.png" class="card-img-top profile-img align-self-center mt-3" alt="blank-user"/>
                        <h2 class="mt-2 font2">Register New User</h2>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="row gap-2 text-center mb-2 d-flex align-items-center">
                                    <div class="col-auto">
                                        <asp:Label ID="Label4" runat="server" Text="Label" for="TextBox4" CssClass="col-form-label font2">First Name:</asp:Label>
                                    </div>
                                    <div class="col-auto form-group">
                                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control font3"></asp:TextBox>
                                    </div>
                                    <div class="col-auto">
                                        <asp:Label ID="Label6" runat="server" Text="Label" for="TextBox6" CssClass="col-form-label font2">M.I.:</asp:Label>
                                    </div>
                                    <div class="col-2 form-group">
                                        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control font3"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row gap-2 text-center mb-2 d-flex align-items-center justify-content-between">
                                    <div class="col-auto">
                                        <asp:Label ID="Label5" runat="server" Text="Label" for="TextBox5" CssClass="col-form-label font2">Last Name:</asp:Label>
                                    </div>
                                    <div class="col-auto form-group">
                                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control font3"></asp:TextBox>
                                    </div>
                                    <div class="col-auto">
                                        <asp:Label ID="Label7" runat="server" Text="Label" for="dob-picker" CssClass="col-form-label font2">D.O.B.:</asp:Label>
                                    </div>
                                    <div class="col-3">
                                        <input type="date" id="dob-picker" name="dob-picker" class="form-control font3" onload="getDate()" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <div class="row gap-2 d-flex align-items-center">
                                    <div class="col-4">
                                        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="col-form-label font2" for="TextBox1">Username or Email: </asp:Label>
                                    </div>
                                    <div class="col-6 form-group">
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control font3"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row gap-2 mt-2 d-flex align-items-center">

                                    <div class="col-4">
                                        <asp:Label ID="Label2" runat="server" Text="Label" CssClass="col-form-label font2" for="TextBox2">Password: </asp:Label>
                                    </div>
                                    <div class="col-6 form-group">
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control font3">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="row gap-2 mt-2 d-flex align-items-center">

                                    <div class="col-4">
                                        <asp:Label ID="Label3" runat="server" Text="Label" CssClass="col-form-label font2" for="TextBox3">Confirm Password: </asp:Label>
                                    </div>
                                    <div class="col-6 form-group">
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control font3">
                                        </asp:TextBox>
                                    </div>
                                </div>


                            </div>
                        </div>
                        <div class="d-grid gap-2">
                            <button id="log-in" class="btn btn-success font2 mt-4 btn-lg" type="submit">Sign Up</button>
                                            <%--ADD ONCLICK FOR BOTH BUTTONS??--%>
                        </div>
                    </div>
                    <div class="card-footer d-flex justify-contents-start">
                        <a href="Homepage.aspx" class="ms-2 mb-2"> << &nbsp; &nbsp; Return Home </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
