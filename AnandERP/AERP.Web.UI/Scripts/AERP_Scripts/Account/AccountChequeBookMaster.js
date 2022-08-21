//this class contain methods related to nationality functionality
var AccountChequeBookMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountChequeBookMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
      
        $("#TotalNoCheque").change(function () {
            debugger;
            var chkFromNo = $("#ChequeFromNo").val();
            var TotalNoCheque = $(this).val();
            var varSum = (parseInt(chkFromNo == "" ? 0 : parseInt(chkFromNo) + TotalNoCheque == "" ? 0 : parseInt(TotalNoCheque)) - 1);
            $("#ChequeToNo").val(varSum);

        });
      
        $("#ChequeFromNo").change(function () {
            var chkTotalNoCheque = $("#TotalNoCheque").val();
            var varSum = chkTotalNoCheque == "" ? 0 : parseInt(chkTotalNoCheque) + parseInt($(this).val()) - 1;
            $("#ChequeToNo").val(varSum);

            return false;
      

        });
        $('#ChequeFromNo').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });
        $('#TotalNoCheque').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);

        });
        $('#CreateAccountChequeBookMasterRecord').on("click", function () {
            
            AccountChequeBookMaster.ActionName = "Create";
            AccountChequeBookMaster.AjaxCallAccountChequeBookMaster();

            $('#AccBalsheetMstID').val(0);
            $('#AccountID').val(0);
            $("#TotalNoCheque").val("");
            $("#ChequeFromNo").val("");
            $("#ChequeToNo").val("");

        });

        $('#EditAccountChequeBookMasterRecord').on("click", function () {
           
            AccountChequeBookMaster.ActionName = "Edit";
            AccountChequeBookMaster.AjaxCallAccountChequeBookMaster();
        });

        $('#DeleteAccountChequeBookMasterRecord').on("click", function () {

            AccountChequeBookMaster.ActionName = "Delete";
            AccountChequeBookMaster.AjaxCallAccountChequeBookMaster();
        });

        InitAnimatedBorder();
        CloseAlert();

        
        $('#reset').on("click", function () {
            //$("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            //$('input:checkbox,input:radio').removeAttr('checked');
            if ($("#ChequeFromNo").attr('disabled') != 'disabled') {
                $('#ChequeFromNo').val('');
            }
            $("#TotalNoCheque").val('');
            $('#ChequeToNo').val('');
            $("#TotalNoCheque").focus();
            //$('#Description').focus();
            return false;
          
        });

        $("#SelectedCentreCode").change(function () {
            
            var selectedItem = $(this).val();
            var $ddlBalanceSheet = $("#SelectedBalanceSheet");
            var $BalanceSheetProgress = $("#states-loading-progress");
            $BalanceSheetProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AccountChequeBookMaster/GetBalanceSheetByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlBalanceSheet.html('');
                        $ddlBalanceSheet.append('<option value="">--Select BalanceSheet--</option>');
                        $.each(data, function (id, option) {

                            $ddlBalanceSheet.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $BalanceSheetProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve BalanceSheet.');
                        $BalanceSheetProgress.hide();
                    }
                });
            }
            else {
                //$('#myDataTable tbody').empty();
                $('#SelectedBalanceSheet').find('option').remove().end().append('<option value>---Select University---</option>');
                $('#btnCreate').hide();
            }
        });

        $('#SelectedBalanceSheet').on("change", function () {
            var SelectedBalanceSheet = $('#SelectedBalanceSheet :selected').val();
            AccountChequeBookMaster.LoadListByCentreAndBalanceSheet(SelectedBalanceSheet);
        });

        $('#TotalNoCheque').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#ChequeFromNo').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#ChequeToNo').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });


    },
    //LoadList method is used to load List page

    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();

        if (Balancesheet != null) {
            $.ajax(
                {
                    cache: false,
                    type: "POST",
                    data: { BalanceSheetID: Balancesheet },
                    dataType: "html",
                    url: '/AccountChequeBookMaster/List',
                    success: function (data) {
                        //Rebind Grid Data
                        $('#ListViewModel').html(data);
                    }
                });

        }
        else {
            ajaxRequest.ErrorMessageForJS("JsValidationMessages_BalancsheetnotCreatednotSelected", "SuccessMessage", "#FFCC80");
            
        }
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        var SelectedBalanceSheet = $('#selectedBalsheetID').val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { BalanceSheetID: SelectedBalanceSheet, actionMode: actionMode },
            dataType: "html",
            url: '/AccountChequeBookMaster/List',
            success: function (data) {
                //Rebind Grid Data
              
                $("#ListViewModel").empty().append(data);

                notify(message, colorCode);
                ////twitter type notification
                
            }
        });
    },
    //LoadList method is used to load List page
    LoadListByCentreAndBalanceSheet: function (SelectedBalanceSheet) {

        $.ajax(
         {
             cache: false,
             type: "GET",
             dataType: "html",
             data: { BalanceSheetID: SelectedBalanceSheet },
             url: '/AccountChequeBookMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallAccountChequeBookMaster: function () {
        var AccountChequeBookMasterData = null;
        if (AccountChequeBookMaster.ActionName == "Create") {
            debugger;
            $("#FormCreateAccountChequeBookMaster").validate();
            if ($("#FormCreateAccountChequeBookMaster").valid()) {
                AccountChequeBookMasterData = null;
                AccountChequeBookMasterData = AccountChequeBookMaster.GetAccountChequeBookMaster();
                ajaxRequest.makeRequest("/AccountChequeBookMaster/Create", "POST", AccountChequeBookMasterData, AccountChequeBookMaster.Success, "CreateAccountChequeBookMasterRecord");
            }
        }
        else if (AccountChequeBookMaster.ActionName == "Edit") {
            $("#FormEditAccountChequeBookMaster").validate();
            if ($("#FormEditAccountChequeBookMaster").valid()) {
                AccountChequeBookMasterData = null;
                AccountChequeBookMasterData = AccountChequeBookMaster.GetAccountChequeBookMaster();
                ajaxRequest.makeRequest("/AccountChequeBookMaster/Edit", "POST", AccountChequeBookMasterData, AccountChequeBookMaster.Success);
            }
        }
        else if (AccountChequeBookMaster.ActionName == "Delete") {
            //alert();
            AccountChequeBookMasterData = null;
            AccountChequeBookMasterData = AccountChequeBookMaster.GetAccountChequeBookMaster();
            ajaxRequest.makeRequest("/AccountChequeBookMaster/Delete", "POST", AccountChequeBookMasterData, AccountChequeBookMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountChequeBookMaster: function () {
        var Data = {
        };
        
        if (AccountChequeBookMaster.ActionName == "Create" || AccountChequeBookMaster.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.AccBalsheetMstID = $('#AccBalsheetMstID').val();
            Data.AccountID = $('#AccountID').val();
            Data.TotalNoCheque = $("#TotalNoCheque").val();
            Data.ChequeFromNo = $("#ChequeFromNo").val();
            Data.ChequeToNo = $("#ChequeToNo").val();
            Data.IsActive = $("input[id=IsActive]:checked").val();

        }
        else if (AccountChequeBookMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
            Data.AccountID = $('input[name=AccountID]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        AccountChequeBookMaster.ReloadList(splitData[0], splitData[1], splitData[2])
        $.magnificPopup.close();


        //$('#SuccessMessage').html(splitData[0]);
        //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', splitData[1]);
    },
    
};