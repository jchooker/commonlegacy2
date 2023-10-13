$(function () {
    //setUpTable();
    getRowData();
    modifyContainer1();
});

let currGuy = {
    Id: 0,
    FirstName: '',
    LastName: ''
};

function setUpTable(data) {

    var dt = $('#all-users').DataTable({
        data: data,
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
        currGuy['Id'] = table.row(this).data()['Id'];
        currGuy['FirstName'] = table.row(this).data()['FirstName'];
        currGuy['LastName'] = table.row(this).data()['LastName'];
        $('#first-name-mod').val(currGuy['FirstName']);
        $('#last-name-mod').val(currGuy['LastName']);
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

function modifyUserInit() {
    var modSweet = {
        SwalTitle: 'Modify User Confirmation',
        SwalType: 'warning'
    };
    fireSweety(modSweet).then((res) => {
        if (res.isConfirmed) {
            modifyUserCommit();
            Swal.fire(
                'Modification Complete',
                "User " + currGuy['FirstName'] + " " + currGuy['LastName'] + " changed!",
                'success'
            )
        }
    }); //<--now button press on this modal should commence the rest of modifyUser fxn
   
}

function modifyUserCommit() {
    var fn = $('#first-name-mod').val();
    var ln = $('#last-name-mod').val();
    var em = $('#email-mod').val();
    var gn = $('#gender-mod').val();
    var age = $('#age-mod').val();
    var cn = $('#country-mod').val();
    var modifiedUser = {
        Id: currGuy['Id'],
        FirstName: fn,
        LastName: ln,
        Email: em,
        Gender: gn,
        Age: age,
        Country: cn
    };

    $.ajax({
        type: "POST",
        url: "UsersDataTable.ascx/ModifyUser",
        data: JSON.stringify(modifiedUser),
        contentType: "application/json; charset=utf-8",
        dataType: "JSON",
        success: console.log("success"), //<--bind to sweet alerts or toast
        error: console.log("failure")
    })
}

function fireSweety(type) { //<--'type' becomes obj with swal vals?
    Swal.fire({
        title: type["SwalTitle"],
        text: 'Do you wish to commit to these changes to ' + currGuy["FirstName"] + ' ' + currGuy["LastName"] + '?' + ' They will be permanent!', //<--pass unmod-ed user f & l name
        icon: type["SwalType"],
        showCloseButton: true,
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Confirm modification'
    })
}