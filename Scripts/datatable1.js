﻿var currGuy = {
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
    loadCountryOptions();
    modifyContainer1();
});

///////////////////////////////TO ADD: CORRECT HANDLING OF COUNTRY CHANGE - STILL GETTING THE "YOU DIDN'T CHANGE ANYTHING MESSAGE", FOR ONE THING
//////////////////THE INDEXOF FORMULA FROM DT IS CORRECT, BUT IT USES THE DISPLAY NAME (WITH THE SPACE) - THE -1 THAT IT RETURNS OTHERWISE IS LAST IDX
//////PERHAPS YOU CAN MOD THE ONE FORMULA TO GET DISPLAY NAME INSTEAD OF THE NAME NAME
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
        //$('#country-mod').val(table.row(this).data()['Country']);
        currGuy['Country'] = table.row(this).data()['Country'];
        changeWhichCountrySelected();
        //loadCountrySelect();
        currSelRow = table.row(this).index();
        console.log(table
            .columns()
            .header()
            .map(c => $(c).text())
            .indexOf("First Name"));
        //alert(currSelRow);
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
        }
    }); //<--now button press on this modal should commence the rest of modifyUser fxn
   
}

function modifyUserCommit() {
    let fn = $('#first-name-mod').val();
    let ln = $('#last-name-mod').val();
    let em = $('#email-mod').val();
    let gn = $('#gender-mod').val();
    let age = $('#age-mod').val();
    let cn;
    //if ($('#country-mod option:selected').attr('value') === 0) cn = currGuy["Country"]; //does this clash with the initiation or nature of a select element?
    //else cn = $('#country-mod').val();
    cn = ($('#country-mod option:selected').attr('value') === 0) ? currGuy["Country"] : $('#country-mod').val(); //ternary works with mixed in jQ?
    let modifiedUser = {
        Id: currGuy['Id'],
        FirstName: fn,
        LastName: ln,
        Email: em,
        Gender: gn,
        Age: age,
        Country: cn
    };
    var modCheck = objComparison(currGuy, modifiedUser);
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
                //dt.columns.adjust().draw(false);
                //var colIndices = [];
                for (var i = 1; i < modCheck.length; i++) {
                    //column().name() getter setter column
                    //var currCol = dt.column(modCheck[i] + ':name').data();
                    console.log(modCheck[i]); //<--it is collecting the right column names, don't know why it's applying stuff to the wrong cells
                    let colIndex = dt
                        .columns()
                        .header()
                        .map(c => $(c).text())
                        .indexOf(modCheck[i]);
                    console.log(colIndex);
                    dt.cell(currSelRow, colIndex)
                        .data(modifiedUser[modCheck[i]]); //10.20.2023 - somehow the country is being changed to the last name mod
                    dt.row(currSelRow)
                        .draw(false); //not modifiedUser[modCheck][i] because the index
                }                                                           //is the value of the modCheck at index i?? correct language?
                //colIndices = getColIndicesByName(dt);
                Swal.fire( //this only needs to happen if an actual mod occurs
                    'Modification Complete',
                    "User " + currGuy['FirstName'] + " " + currGuy['LastName'] + " changed!",
                    'success'
                );
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
            }
        }); //<--now button press on this modal should commence the rest of modifyUser fxn

}

function deleteUserCommit() {
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
function loadCountryOptions() {
    var sel = $('#country-mod');
    var firstFew = 0;
    $.getJSON('./json/countries.json', function (data) {
        $.each(data, function (idx, country) {
            if (firstFew < 5) console.log(country.Code + " " + country.Name);
            var currOption = $('<option value="' + country.Code + '">' + country.Name + '</option>');
            sel.append(currOption);
            firstFew++;
        })
    });
}

function changeWhichCountrySelected() { //remove 'select' attr then assign it to correct option
    var sel = '#country-mod';
    $(sel + ' option:selected').removeAttr('selected'); //<--resets selected with first click and every additional one
    $(sel + 'option[value=0]').attr('selected', 'selected'); //sets to 'Select country' option in case neither of the conditions are met;
                                        //this could be done as an "else", but that could involve switching back and forth b/w options
    $(sel + ' option').each(function (idx, country) { //check for exact match & "contains" match have to happen separately
        //var regText = '^' + country.text;
        const regex = new RegExp("(?<!.)" + currGuy["Country"], "g"); //check needs to be getting country names from json data that is populating dt
        if (country.text.match(regex)) {
            $(sel + ' option:selected').removeAttr('selected');
            $(this).attr('selected', 'selected'); //"China" issue: confirm what '$(this)' is -- UPDATE: IT WAS the next $.each overwriting the "China" result
            console.log('1st condition: ' + country.text); //*****AND 'Russian Federation' works with 'Russia' because I only have look AHEADS*/
            return false; //<--
        }
        else if (country.text.includes(currGuy['Country'])) {
            $(sel + ' option:selected').removeAttr('selected');
            $(this).attr('selected', 'selected');
            console.log('2nd condition: ' + country.text);
            return false;
        }
    });
    //$(sel + ' option').each(function (idx, country) {
    //    if (country.text.includes( currGuy['Country'] )) $(this).attr('selected', 'selected');
    //});

}