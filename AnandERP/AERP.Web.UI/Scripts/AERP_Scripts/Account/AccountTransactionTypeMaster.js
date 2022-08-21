//this class contain methods related to nationality functionality
var AccountTransactionTypeMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AccountTransactionTypeMaster.constructor();
        //AccountTransactionTypeMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#Name').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#MarchandiseBaseCategoryName').focus();
            return false;
        });



        // Create new record

        $('#CreateAccountTransactionTypeMasterRecord').on("click", function () {
            debugger;
            AccountTransactionTypeMaster.ActionName = "Create";
            AccountTransactionTypeMaster.AjaxCallAccountTransactionTypeMaster();
        });

        $('#EditAccountTransactionTypeMasterRecord').on("click", function () {
            debugger;
            AccountTransactionTypeMaster.ActionName = "Edit";
            AccountTransactionTypeMaster.AjaxCallAccountTransactionTypeMaster();
        });

        $('#DeleteAccountTransactionTypeMasterRecord').on("click", function () {
            debugger;
            AccountTransactionTypeMaster.ActionName = "Delete";
            AccountTransactionTypeMaster.AjaxCallAccountTransactionTypeMaster();
        });

        $('#TransactionTypeName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#TransactionTypeCode').on("keydown", function (e) {
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
       // debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/AccountTransactionTypeMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
       // debugger;
        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: null },
            url: '/AccountTransactionTypeMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallAccountTransactionTypeMaster: function () {
        var AccountTransactionTypeMasterData = null;

        if (AccountTransactionTypeMaster.ActionName == "Create") {

            $("#FormCreateAccountTransactionTypeMaster").validate();
            if ($("#FormCreateAccountTransactionTypeMaster").valid()) {
                AccountTransactionTypeMasterData = null;
                AccountTransactionTypeMasterData = AccountTransactionTypeMaster.GetAccountTransactionTypeMaster();
                ajaxRequest.makeRequest("/AccountTransactionTypeMaster/Create", "POST", AccountTransactionTypeMasterData, AccountTransactionTypeMaster.Success, "CreateAccountTransactionTypeMasterRecord");
            }
        }
        else if (AccountTransactionTypeMaster.ActionName == "Edit") {
            debugger;
            $("#FormEditAccountTransactionTypeMaster").validate();
            if ($("#FormEditAccountTransactionTypeMaster").valid()) {
                AccountTransactionTypeMasterData = null;
                AccountTransactionTypeMasterData = AccountTransactionTypeMaster.GetAccountTransactionTypeMaster();
                ajaxRequest.makeRequest("/AccountTransactionTypeMaster/Edit", "POST", AccountTransactionTypeMasterData, AccountTransactionTypeMaster.Success);
            }
        }
        else if (AccountTransactionTypeMaster.ActionName == "Delete") {
            debugger;
            AccountTransactionTypeMasterData = null;
            //$("#FormCreateAccountTransactionTypeMaster").validate();
            AccountTransactionTypeMasterData = AccountTransactionTypeMaster.GetAccountTransactionTypeMaster();
            ajaxRequest.makeRequest("/AccountTransactionTypeMaster/Delete", "POST", AccountTransactionTypeMasterData, AccountTransactionTypeMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountTransactionTypeMaster: function () {
        //debugger;
        var Data = {
        };

        if (AccountTransactionTypeMaster.ActionName == "Create" || AccountTransactionTypeMaster.ActionName == "Edit") {
            debugger;
            Data.AccountTransactionTypeMasterID = $('#AccountTransactionTypeMasterID').val();
            Data.TransactionTypeName = $('#TransactionTypeName').val();
            Data.TransactionTypeCode = $('#TransactionTypeCode').val();
            Data.IsActive = $("#IsActive").val();

        }
        else if (AccountTransactionTypeMaster.ActionName == "Delete") {
            debugger;
            Data.AccountTransactionTypeMasterID = $('#AccountTransactionTypeMasterID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            AccountTransactionTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
            AccountTransactionTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};
