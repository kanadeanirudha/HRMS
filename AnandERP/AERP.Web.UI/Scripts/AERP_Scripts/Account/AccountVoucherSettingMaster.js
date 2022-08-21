//this class contain methods related to nationality functionality
var AccountVoucherSettingMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AccountVoucherSettingMaster.constructor();
        //AccountVoucherSettingMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#MarchandiseBaseCategoryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#MarchandiseBaseCategoryName').focus();
            return false;
        });

        $('#btnShowList').click(function () {
            debugger;
            var AccSessionID = $('#AccSessionID').val();

            if (AccSessionID != "") {
                AccountVoucherSettingMaster.LoadList();
                $("#divAddbtn").show();
            }
            else if (AccSessionID == "") {
                notify("Please Select Account Session", 'warning');
                $('#divAddbtn').hide(true);
            }
        });
        $('#AccSessionID').on("change", function () {
            $('#DivCreateNew').hide(true);
            $('#myDataTable').html("");
            if ($("#AccSessionID").val() == "") {
                $("#divAddbtn").hide();
            }
            else {
                $("#divAddbtn").show();
            }
        });
        // Create new record

        $('#CreateAccountVoucherSettingMasterRecord').on("click", function () {
            debugger;
            AccountVoucherSettingMaster.ActionName = "Create";
            AccountVoucherSettingMaster.AjaxCallAccountVoucherSettingMaster();
        });

        $('#EditAccountVoucherSettingMasterRecord').on("click", function () {

            AccountVoucherSettingMaster.ActionName = "Edit";
            AccountVoucherSettingMaster.AjaxCallAccountVoucherSettingMaster();
        });

        $('#DeleteAccountVoucherSettingMasterRecord').on("click", function () {

            AccountVoucherSettingMaster.ActionName = "Delete";
            AccountVoucherSettingMaster.AjaxCallAccountVoucherSettingMaster();
        });

        $('#VoucherNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        //$('#MarchandiseBaseCategoryCode').on("keydown", function (e) {
        //    AMSValidation.NotAllowSpaces(e);

        //});

        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AMSValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AMSValidation.AllowCharacterOnly(e);
        //  if (e.keyCode == 32) {
        //       return false;
        // }
        // });
        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").dataTable();
        //    oTable.fnFilter(this.value);
        //});

        //$("#searchBtn").click(function () {
        //    $("#UserSearch").focus();
        //});


        //$("#showrecord").change(function () {
        //    var showRecord = $("#showrecord").val();
        //    $("select[name*='myDataTable_length']").val(showRecord);
        //    $("select[name*='myDataTable_length']").change();
        //});

        // $(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function () {

        var AccBalsheetMstID = $("#selectedBalsheetID").val();
        var AccSessionID = $("#AccSessionID").val();
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { "selectedBalsheet": AccBalsheetMstID, "AccSessionID": AccSessionID },
             dataType: "html",
             url: '/AccountVoucherSettingMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
                 if ($('#AccSessionID :selected').val() == "") {

                     $("#divAddbtn").hide();
                 }
                 else {
                     $("#divAddbtn").show();
                 }

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        var AccBalsheetMstID = $("#selectedBalsheetID").val();
        var AccSessionID = $("#AccSessionID").val();
        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { "selectedBalsheet": AccBalsheetMstID, "AccSessionID": AccSessionID, "actionMode": actionMode },
            url: '/AccountVoucherSettingMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                if ($('#AccSessionID :selected').val() == "") {

                    $("#divAddbtn").hide();
                }
                else {
                    $("#divAddbtn").show();
                }
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallAccountVoucherSettingMaster: function () {
        var AccountVoucherSettingMasterData = null;

        if (AccountVoucherSettingMaster.ActionName == "Create") {

            $("#FormCreateAccountVoucherSettingMaster").validate();
            if ($("#FormCreateAccountVoucherSettingMaster").valid()) {
                AccountVoucherSettingMasterData = null;
                AccountVoucherSettingMasterData = AccountVoucherSettingMaster.GetAccountVoucherSettingMaster();
                ajaxRequest.makeRequest("/AccountVoucherSettingMaster/Create", "POST", AccountVoucherSettingMasterData, AccountVoucherSettingMaster.Success, "CreateAccountVoucherSettingMasterRecord");
            }
        }
        else if (AccountVoucherSettingMaster.ActionName == "Edit") {
            $("#FormEditAccountVoucherSettingMaster").validate();
            if ($("#FormEditAccountVoucherSettingMaster").valid()) {
                AccountVoucherSettingMasterData = null;
                AccountVoucherSettingMasterData = AccountVoucherSettingMaster.GetAccountVoucherSettingMaster();
                ajaxRequest.makeRequest("/AccountVoucherSettingMaster/Edit", "POST", AccountVoucherSettingMasterData, AccountVoucherSettingMaster.Success, "EditAccountVoucherSettingMasterRecord");
            }
        }
        else if (AccountVoucherSettingMaster.ActionName == "Delete") {

            AccountVoucherSettingMasterData = null;
            //$("#FormCreateAccountVoucherSettingMaster").validate();
            AccountVoucherSettingMasterData = AccountVoucherSettingMaster.GetAccountVoucherSettingMaster();
            ajaxRequest.makeRequest("/AccountVoucherSettingMaster/Delete", "POST", AccountVoucherSettingMasterData, AccountVoucherSettingMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountVoucherSettingMaster: function () {
        var Data = {
        };

        if (AccountVoucherSettingMaster.ActionName == "Create" || AccountVoucherSettingMaster.ActionName == "Edit") {
            Data.ID = $('input[name=AccVoucherSettingMasterID]').val();
            Data.AccSessionID = $('#AccSessionID :selected').val();
            Data.AccBalsheetMstID = $('#AccBalsheetMstID').val();
            Data.TransactionType = $('#TransactionType :selected').val();
            Data.TransactionTypeCode = $('#TransactionTypeCode').val();
            Data.VoucherNumber = $('#VoucherNumber').val();

        }
        else if (AccountVoucherSettingMaster.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;

        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            AccountVoucherSettingMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

//this is used to for showing successfully record updation message and reload the list view
// editSuccess: function (data) {



// if (data == "True") {

//        parent.$.colorbox.close();
//    var actionMode = "1";
//       AccountVoucherSettingMaster.ReloadList("Record Updated Sucessfully.", actionMode);
//        //  alert("Record Created Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    }

//},
////this is used to for showing successfully record deletion message and reload the list view
//deleteSuccess: function (data) {


//    if (data == "True") {

//        parent.$.colorbox.close();
//        AccountVoucherSettingMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


