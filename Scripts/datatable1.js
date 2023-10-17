var currGuy = {
    Id: 0,
    FirstName: "",
    LastName: "",
    Email: "",
    Gender: "",
    Age: "",
    Country: ""
};
$(function () {
    //let dt = setUpTable();
    setUpTable(usersData);
        //.then(function () {
        //    modifyContainer1();
        //});
    console.log("only run 1?");
    //getRowData();
    console.log("only run 2?");
});


function setUpTable(usersData) {

    //if (DataTable.isDataTable('#all-users')) { //<--clears dt space in certain scenarios
    //    $('#all-users').DataTable().destroy();
    //}
    if (usersData) {
        var dt = $("#all-users").DataTable({
            data: usersData,
            columns: [
                { data: 'LastName', title: 'Last Name' },
                { data: 'FirstName', title: 'First Name' },
                { data: 'Email', title: 'Email' },
                { data: 'Gender', title: 'Gender' },
                { data: 'Age', title: 'Age' },
                { data: 'Country', title: 'Country' },
            ],
            select: 'single',
            error: function (err) {
                alert("DataTables ERROR: " + err);
                console.log("DataTables ERROR");
                console.log("Error", err.stack);
                console.log("Error", err.name);
                console.log("Error", err.message);
            },
            initComplete: function () {
                console.log("dt setup complete");
                getRowData(dt);
            },
        });

    } else {
        console.log("user data not available");
    }
    //$.ajax({
    //    url: "/UsersDataTable.ascx/GetUsers",
    //    method: 'GET',
    //    dataType: 'json',
    //    contentType: "application/json; charset=utf-8",
    //    dataSrc: "",
    //    success: function (data) {
    //        dt = $("#all-users").DataTable({
    //            serverSide: true,
    //            data: data,
    //            columns: [
    //                { data: 'LastName', title: 'Last Name' },
    //                { data: 'FirstName', title: 'First Name' },
    //                { data: 'Email', title: 'Email' },
    //                { data: 'Gender', title: 'Gender' },
    //                { data: 'Age', title: 'Age' },
    //                { data: 'Country', title: 'Country' },
    //            ],
    //            select: 'single',
    //            error: function (err) {
    //                alert("DataTables ERROR #2: " + err);
    //                console.log("DataTables ERROR #2");
    //                console.log("Error", err.stack);
    //                console.log("Error", err.name);
    //                console.log("Error", err.message);
    //            },
    //            initComplete: function () {
    //                console.log("dt setup complete");
    //                getRowData(dt);
    //            },
    //        });
    //    },
    //    error: function (err) {
    //        alert("DataTables ERROR #1: " + err);
    //        console.log("DataTables ERROR #1");
    //        console.log("Error", err.stack);
    //        console.log("Error", err.name);
    //        console.log("Error", err.message);
    //    },
    //})

    //var dt = $("#all-users").DataTable({
    //    ajax: {
    //        url: "UsersDataTable.ascx/GetUsers",
    //        crossDomain: true,
    //        type: "GET",
    //        dataType: "json",
    //        contentType: "application/json; charset=utf-8",
    //        dataSrc: "",
    //    },
    //    columns: [
    //        { data: 'LastName', title: 'Last Name' },
    //        { data: 'FirstName', title: 'First Name' },
    //        { data: 'Email', title: 'Email' },
    //        { data: 'Gender', title: 'Gender' },
    //        { data: 'Age', title: 'Age' },
    //        { data: 'Country', title: 'Country' },
    //    ],
    //    select: 'single',
    //    initComplete: function () {
    //        console.log("dt setup complete");
    //        getRowData(dt);
    //    }
    //});


    //return dt;
}

function getRowData(table) {
    //var table = $('#all-users').DataTable();
    $('#all-users tbody').on('click', 'tr', function () {
        currGuy['Id'] = table.row(this).data()['Id'];
        currGuy['FirstName'] = table.row(this).data()['FirstName'];
        currGuy['LastName'] = table.row(this).data()['LastName'];
        $('#first-name-mod').val(currGuy['FirstName']);
        $('#last-name-mod').val(currGuy['LastName']);
        $('#email-mod').val(table.row(this).data()['Email']);
        currGuy['Email'] = table.row(this).data()['Email'];
        $('#gender-mod').val(table.row(this).data()['Gender']);
        currGuy['Gender'] = table.row(this).data()['Gender'];
        $('#age-mod').val((table.row(this).data()['Age']).toString());
        currGuy['Age'] = table.row(this).data()['Age'].toString();
        $('#country-mod').val(table.row(this).data()['Country']);
        currGuy['Country'] = table.row(this).data()['Country'];
    });
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
            );
            //$('#all-users').DataTable().ajax.reload(); //<-hoping to make this refresh the table after modifications-
            //will need to apply to delete as well
        }
    }); //<--now button press on this modal should commence the rest of modifyUser fxn
   
}

function modifyUserCommit() {
    let fn = $('#first-name-mod').val();
    let ln = $('#last-name-mod').val();
    let em = $('#email-mod').val();
    let gn = $('#gender-mod').val();
    let age = $('#age-mod').val();
    let cn = $('#country-mod').val();
    let modifiedUser = {
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
        url: "UsersDataTable.ascx/Modify_Commit",
        data: JSON.stringify(modifiedUser),
        contentType: "application/json; charset=utf-8",
        dataType: "JSON",
        success: console.log("success"), //<--bind to sweet alerts or toast
        error: console.log("failure")
    });
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
    });
}