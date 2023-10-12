$(document).ready(function () {
    setUpTable();
    getRowData();
    modifyContainer1();
});

async function setUpTable(data) {

    var dt = $('#all-users').DataTable({
        //serverSide: true,
        data: data,
        //ajax: {
        //    url: 'UsersDataTable.ascx/GetData',
        //    type: 'GET',
        //    datatype: 'json',
        //    contentType: "application/json",
        //    data: function (d) {
        //        return d;
        //    },
        //    dataSrc: function (json) {
        //        json.draw = json.d.draw;
        //        json.recordsTotal = json.d.recordsFiltered;
        //        json.data = json.d.data;
        //        var return_data = json;
        //        return return_data.data;
        //    },
        //    error: function (xhr, status, error) {
        //        // Handle errors here
        //        console.error(xhr.responseText);

        //        // Make this error component visible!
        //        $('#error-message').text('An error occurred: ' + error);
        //    }
        //},
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