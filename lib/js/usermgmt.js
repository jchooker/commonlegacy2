$(document).ready(function () {
    setUpTable();
    getRowData();
    modifyContainer1();
});

function setUpTable() {
    var dt = $('#all-users').DataTable({
        ajax: {
            url: '/api/users',
            type: 'GET',
            datatype: 'json',
            dataSrc: ""
        },
        columns: [
            {data: 'last_name', title: 'Last Name'},
            { data: 'first_name', title: 'First Name' },
            { data: 'email', title: 'Email' },
            { data: 'gender', title: 'Gender' },
            { data: 'age', title: 'Age' },
            { data: 'country', title: 'Country' },
        ],
        select: 'single'
    });
}

function getRowData() {
    var table = $('#all-users').DataTable();
    $('#all-users tbody').on('click', 'tr', function () {
        $('#first-name-mod').val(table.row(this).data()['first_name']);
        $('#last-name-mod').val(table.row(this).data()['last_name']);
        $('#email-mod').val(table.row(this).data()['email']);
        $('#gender-mod').val(table.row(this).data()['gender']);
        $('#age-mod').val((table.row(this).data()['age']).toString());
        $('#country-mod').val(table.row(this).data()['country']);
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
