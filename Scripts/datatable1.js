var currGuy = {
    Id: 0,
    FirstName: "",
    LastName: "",
    Email: "",
    Gender: "",
    Age: "",
    Country: ""
};

const columns = [ //set it here so we can get col idx
    { data: 'LastName', title: 'Last Name', name: 'LastName' },
    { data: 'FirstName', title: 'First Name', name: 'FirstName' },
    { data: 'Email', title: 'Email', name: 'Email' },
    { data: 'Gender', title: 'Gender', name: 'Gender' },
    { data: 'Age', title: 'Age', name: 'Age' },
    { data: 'Country', title: 'Country', name: 'Country' },
]

var currSelRow; //<--working with this to modify dt

$(function () {
    //let dt = setUpTable();
    setUpTable(usersData);
    getRowData();
    modifyContainer1();
});


function setUpTable(usersData) {

    //if (DataTable.isDataTable('#all-users')) { //<--clears dt space in certain scenarios
    //    $('#all-users').DataTable().destroy();
    //}
    if (usersData) {
        var dt = $("#all-users").DataTable({
            data: usersData,
            columns: columns,
            select: 'single',
            error: function (err) {
                alert("DataTables ERROR: " + err);
                console.log("DataTables ERROR");
                console.log("Error", err.stack);
                console.log("Error", err.name);
                console.log("Error", err.message);
            },
            initComplete: function () { //<-remove if it's not working with getrowdata?
                console.log("dt setup complete");
            },
        });

    } else {
        console.log("user data not available");
    }
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
        currGuy['Email'] = table.row(this).data()['Email'];
        $('#gender-mod').val(table.row(this).data()['Gender']);
        currGuy['Gender'] = table.row(this).data()['Gender'];
        $('#age-mod').val((table.row(this).data()['Age']).toString());
        currGuy['Age'] = table.row(this).data()['Age'].toString();
        $('#country-mod').val(table.row(this).data()['Country']);
        currGuy['Country'] = table.row(this).data()['Country'];
        currSelRow = table.row(this).index();
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

function modifyUserInit() { //message for whether no modifications were made
                            //custom message to lay out some changes that were made
                            //figure out how to reload dt dynamically without error
    var modSweet = {
        SwalTitle: 'Modify User Confirmation',
        SwalType: 'warning'
    };
    Swal.fire({
        title: modSweet["SwalTitle"],
        text: 'Do you wish to commit to these changes to ' + currGuy["FirstName"] + ' ' + currGuy["LastName"] + '?' + ' They will be permanent!', //<--pass unmod-ed user f & l name
        icon: modSweet["SwalType"],
        //background: '#fff url(https://i.ibb.co/QHby8bp/floppy-disks-edit.png)',
        showCloseButton: true,
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Confirm modification'
    })
        .then((res) => {
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
    const modCheck = objComparison(currGuy, modifiedUser);
    if (modCheck.length === 1) { //poss return value of "[true]" OR "[false]"?
        Swal.fire({
            icon: 'error',
            title: 'What a world!',
            text: "You-sir error - literally you didn't modify anything...",
            footer: "#dobetter"
        });
    } else { //HOW TO GET ROW CLICKED + COLUMN CHANGED?
        $.ajax({ //this sees one change and runs a POST on the full row - could be more efficient? unless patching would
            type: "POST", //take longer; the only discriminating part is the dt selective cell data adjustment
            url: "ModifyUser.asmx/Modify_Commit",
            data: JSON.stringify({ jsUser: modifiedUser }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: () => {
                var dt = $('#all-users').DataTable();
                var colIndices = [];
                for (var i = 1; i < modCheck.length; i++) {
                    //column().name() getter setter column
                    //var currCol = dt.column(modCheck[i] + ':name').data();
                    let colIndex = dt
                        .columns()
                        .header()
                        .map(c => $(c).text())
                        .indexOf(modCheck[i]);
                    dt.cell(currSelRow, colIndex)
                        .data(modifiedUser[modCheck[i]])
                        .draw(false); //not modifiedUser[modCheck][i] because the index
                }                                                           //is the value of the modCheck at index i?? correct language?
                //colIndices = getColIndicesByName(dt);
                console.log("success");//<--bind to sweet alerts or toast
            },
            error: function (xhr, status, error) {
                console.log("Status: " + status);
                console.log("Response: " + xhr.responseText);
                console.log("Error: " + error);
            }
        });
    }
}

function deleteUserInit() {
    var modSweet = {
        SwalTitle: 'Delete User Confirmation',
        SwalType: 'warning'
    };
    Swal.fire({
        title: modSweet["SwalTitle"],
        text: 'Do you wish to delete User ' + currGuy["FirstName"] + ' ' + currGuy["LastName"] + '?' + ' This cannot be undone!', //<--pass unmod-ed user f & l name
        icon: modSweet["SwalType"],
        //background: '#fff url(https://i.ibb.co/QHby8bp/floppy-disks-edit.png)',
        showCloseButton: true,
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Permanently Delete'
    })
        .then((res) => {
            if (res.isConfirmed) {
                deleteUserCommit();
                Swal.fire(
                    'Deletion Complete',
                    "User " + currGuy['FirstName'] + " " + currGuy['LastName'] + " has been deleted!",
                    'success'
                );
                //$('#all-users').DataTable().ajax.reload(); //<-hoping to make this refresh the table after modifications-
                //will need to apply to delete as well
            }
        }); //<--now button press on this modal should commence the rest of modifyUser fxn

}

function deleteUserCommit() {
    var userId = {
        "Id": currGuy["Id"]
    };
    $.ajax({
        type: "DELETE",
        url: "DeleteUser.asmx/Delete_Commit",
        data: currGuy["Id"],
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: () => {
            var table = $('#all-users').DataTable();
            table.row($(this).parents('tr'))
                .remove()
                .draw();
            console.log("success"); //<--bind to sweet alerts or toast
        },
        error: function (xhr, status, error) {
            console.log("Status: " + status);
            console.log("Response: " + xhr.responseText);
            console.log("Error: " + error);
        }
    });
}

function objComparison(obj1, obj2) {
    const keys1 = Object.keys(obj1);
    const keys2 = Object.keys(obj2);
    var changes = [false];

    if (keys1.length !== keys2.length) {
        return [false];
    }

    for (let key of keys1) {
        if (obj1[key] !== obj2[key]) {
            changes.push(key);
        }
    }
    if (changes.length > 1) return changes;
    else return [true];
}

//function getColIndicesByName(dTable, nameList) {
//    var maxIdx = dTable.columns().count() - 1;
//    var 
//}