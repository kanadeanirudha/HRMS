//////////////////////////////////////////////////////////////////////
////////////////-- Page load --//////////////////
//////////////////////////////////////////////////////////////////////
$(function () {
    LoadList();
});

//////////////////////////////////////////////////////////////////////
////////////////-- Load List by Get() method --//////////////////
//////////////////////////////////////////////////////////////////////
function LoadList() {

    $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/AccountTreeView/DemoTree',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
}

//////////////////////////////////////////////////////////////////////
//////////////-- Reload List by Ajax--//////////////////////////////
//////////////////////////////////////////////////////////////////////

function ReloadList(message) {
    $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/AccountTreeView/DemoTree',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#commonMessage').html(message).css('color', '#FFFFFF');
                $('#commonMessage').delay(400).slideDown(400).delay(3000).slideUp(400).css('background-color', '#5C8AE6');
            }
        });
}

//////////////////////////////////////////////////////////////////////
//////-- Show Success Message after Add New Record --//////
//////////////////////////////////////////////////////////////////////

function createCategorySuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#dailogPopUp').dialog('close');

        //Reload List
        ReloadList("Account Category Created Sucessfully.");

    } else {
        $("#update-message").show();
    }
}
function createGroupSuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#dailogPopUp').dialog('close');

        //Reload List
        ReloadList("Account Category Created Sucessfully.");

    } else {
        $("#update-message").show();
    }
}
function createAccountSuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#dailogPopUp').dialog('close');

        //Reload List
        ReloadList("Account Category Created Sucessfully.");

    } else {
        $("#update-message").show();
    }
}

//////////////////////////////////////////////////////////////////////
//////-- Show Success Message after Edit Record --///////////
//////////////////////////////////////////////////////////////////////
function editCategorySuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#dialog-edit').dialog('close');

        //Reload List
        ReloadList("Category Updated Sucessfully.");

    } else {
        $("#update-message").show();
    }
}


function editGroupSuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#dialog-edit').dialog('close');

        //Reload List
        ReloadList("Group Updated Sucessfully.");

    } else {
        $("#update-message").show();
    }
}

////////////////////////////////////////////////////////////////////////
////////-- Show Success Message after Delete Record --///////////
////////////////////////////////////////////////////////////////////////

function deleteCategorySuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#delete-dialog').dialog('close');

        //Reload List
        ReloadList("Admin Role Deleted Sucessfully.");

    } else {
        $("#update-message").show();
    }
}
function deleteGroupSuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#delete-dialog').dialog('close');

        //Reload List
        ReloadList("Admin Role Deleted Sucessfully.");

    } else {
        $("#update-message").show();
    }
}
function deleteAccountSuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#delete-dialog').dialog('close');

        //Reload List
        ReloadList("Admin Role Deleted Sucessfully.");

    } else {
        $("#update-message").show();
    }
}