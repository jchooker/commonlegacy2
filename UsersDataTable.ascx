<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsersDataTable.ascx.cs" Inherits="CommonLegacy.UsersDataTable" %>
<table id="all-users" class="display table table-striped table-bordered" style="width:100%"></table>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <thead>
            <tr>
                <th>Last Name</th>
                <th>First Name</th>
                <th>Email</th>
                <th>Gender</th>
                <th>Age</th>
                <th>Country</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "LastName") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "FirstName") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Email") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Gender") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Age") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Country") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>--%>
<%--^^^^^^^^*****Bard-suggested ascx--%>

<script>
    $(document).ready(function () {
        setUpTable();
        getRowData();
        modifyContainer1();
    });

    function setUpTable() {
        var dt = $('#all-users').DataTable({
            ajax: {
                url: '/UsersDataTable.ascx/GetUsers',
                type: 'GET',
                datatype: 'json',
                contentType: "application/json; charset-utf-8",
                dataSrc: "",
                error: function (xhr, status, error) {
                    // Handle errors here
                    console.error(xhr.responseText);

                    // Make this error component visible!
                    $('#error-message').text('An error occurred: ' + error);
                }
            },
            columns: [
                { data: 'LastName', title: 'Last Name' },
                { data: 'FirstName', title: 'First Name' },
                { data: 'Email', title: 'Email' },
                { data: 'Gender', title: 'Gender' },
                { data: 'Age', title: 'Age' },
                { data: 'Country', title: 'Country' },
            ],
            select: 'single'
        });
    }

    function getRowData() {
        var table = $('#all-users').DataTable();
        $('#all-users tbody').on('click', 'tr', function () {
            $('#first-name-mod').val(table.row(this).data()['FirstName']);
            $('#last-name-mod').val(table.row(this).data()['LastName']);
            $('#email-mod').val(table.row(this).data()['Email']);
            $('#gender-mod').val(table.row(this).data()['Gender']);
            $('#age-mod').val((table.row(this).data()['Age']).toString());
            $('#country-mod').val(table.row(this).data()['Country']);
        })
    }

    function modifyContainer1() {
        $('#all-users').one('click', 'tr', function () {
            $('h1.pre-sel').hide();
            $('#toggle-header').removeClass('vis');
            $('#toggle-header').addClass('d-flex flex-column align-items-center');
            $('#hidden-body').removeClass('vis');
        });
    }
</script>