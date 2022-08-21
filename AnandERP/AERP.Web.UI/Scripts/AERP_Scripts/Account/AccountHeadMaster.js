//this class contain methods related to nationality functionality
var AccountHeadMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AccountHeadMaster.constructor();
        //AccountHeadMaster.initializeValidation();
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



        // Create new record

        $('#CreateAccountHeadMasterRecord').on("click", function () {
            debugger;
            AccountHeadMaster.ActionName = "Create";
            AccountHeadMaster.AjaxCallAccountHeadMaster();
        });

        $('#EditAccountHeadMasterRecord').on("click", function () {

            AccountHeadMaster.ActionName = "Edit";
            AccountHeadMaster.AjaxCallAccountHeadMaster();
        });

        $('#DeleteAccountHeadMasterRecord').on("click", function () {

            AccountHeadMaster.ActionName = "Delete";
            AccountHeadMaster.AjaxCallAccountHeadMaster();
        });

        $('#HeadName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#HeadCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
            AERPValidation.AllowCharacterOnly(e);
        });

        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AERPValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AERPValidation.AllowCharacterOnly(e);
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

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/AccountHeadMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/AccountHeadMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallAccountHeadMaster: function () {
        var AccountHeadMasterData = null;

        if (AccountHeadMaster.ActionName == "Create") {

            $("#FormCreateAccountHeadMaster").validate();
            if ($("#FormCreateAccountHeadMaster").valid()) {
                AccountHeadMasterData = null;
                AccountHeadMasterData = AccountHeadMaster.GetAccountHeadMaster();
                ajaxRequest.makeRequest("/AccountHeadMaster/Create", "POST", AccountHeadMasterData, AccountHeadMaster.Success, "CreateAccountHeadMasterRecord");
            }
        }
        else if (AccountHeadMaster.ActionName == "Edit") {
            $("#FormEditAccountHeadMaster").validate();
            if ($("#FormEditAccountHeadMaster").valid()) {
                AccountHeadMasterData = null;
                AccountHeadMasterData = AccountHeadMaster.GetAccountHeadMaster();
                ajaxRequest.makeRequest("/AccountHeadMaster/Edit", "POST", AccountHeadMasterData, AccountHeadMaster.Success, "EditAccountHeadMasterRecord");
            }
        }
        else if (AccountHeadMaster.ActionName == "Delete") {

            AccountHeadMasterData = null;
            //$("#FormCreateAccountHeadMaster").validate();
            AccountHeadMasterData = AccountHeadMaster.GetAccountHeadMaster();
            ajaxRequest.makeRequest("/AccountHeadMaster/Delete", "POST", AccountHeadMasterData, AccountHeadMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountHeadMaster: function () {
        var Data = {
        };

        if (AccountHeadMaster.ActionName == "Create" || AccountHeadMaster.ActionName == "Edit") {

            Data.ID = $('input[name=ID]').val();
            Data.HeadName = $('#HeadName').val();
            Data.HeadCode = $('#HeadCode').val();
            Data.PrintingSequence = $('#PrintingSequence :selected').val();
            Data.CreditDebitFlag = $('#CreditDebitFlag :selected').val();
        }
        else if (AccountHeadMaster.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            AccountHeadMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
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
//       AccountHeadMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        AccountHeadMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


