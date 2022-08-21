//this class contain methods related to nationality functionality
var AccountMaster = {
    //Member variables
    ActionName: null,
    SelectedAccBalsheetMstIDs:null,
    //Class intialisation method
    Initialize: function () {
        AccountMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
    

        $('#BankAccDiv').hide();
        $('#ControlHead').prop("disabled", true);

        $('#AccountType').change(function () {
           
            var selectedval = $(this).val();
            if (selectedval == "B") {
                $('#BankAccDiv').fadeIn("slow");
            }
            else {
                $('#BankAccDiv').fadeOut("slow");
            }
            if (selectedval == "L") {
                $('#ControlHead').prop("disabled", false);
            }
            else {
                $('#ControlHead').val("");
                $('#ControlHead').prop("disabled", true);
            }

        });

        $('#CreateAccountMasterRecord').on("click", function () {
            debugger;
            AccountMaster.ActionName = "Create";
            AccountMaster.GetSelectedBalancesheet();
            AccountMaster.AjaxCallAccountMaster();

            $('#AccBalsheetMstID').val(0);
            $('#AccountID').val(0);
            $("#TotalNoCheque").val("");
            $("#ChequeFromNo").val("");
            $("#ChequeToNo").val("");

        });

        $('#EditAccountMasterRecord').on("click", function () {
            //debugger;
            AccountMaster.ActionName = "Edit";
            AccountMaster.GetSelectedBalancesheet();
            AccountMaster.AjaxCallAccountMaster();
        });

        $('#DeleteAccountMasterRecord').on("click", function () {

            AccountMaster.ActionName = "Delete";
            AccountMaster.AjaxCallAccountMaster();
        });



        InitAnimatedBorder();
        CloseAlert();


        $("#DueDatetime_Clear").on("click", function () {

            $("#DueDatetime").val('');
        });

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#AccountName').focus();
            //$('#AccountType').val("");
            $('#ControlHead').val("");
            $('#ControlHead').prop("disabled", true);
            $('#SurpDefFlagList').val("");
            //$('#InterestModeList').val("");
            //$('#InterestTypeList').val("");
            return false;
        });

      

        $("#SelectedCentreCode").change(function () {
            //debugger;
            var selectedItem = $(this).val();
            var $ddlBalanceSheet = $("#SelectedBalanceSheet");
            var $BalanceSheetProgress = $("#states-loading-progress");
            $BalanceSheetProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AccountMaster/GetBalanceSheetByCentreCode",

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
            //debugger;
            var SelectedBalanceSheet = $('#SelectedBalanceSheet :selected').val();
            AccountMaster.LoadListByCentreAndBalanceSheet( SelectedBalanceSheet);
        });

        $('#BankLimitAmount').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#RateOfInterest').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e); 
        });

        $('#AccountName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#AccountCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#AccountInNameOf').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#BankBranchName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#BankAccountNumber').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#BankLimitAmount').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#RateOfInterest').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
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
               data: { "selectedBalsheet": Balancesheet },
               dataType: "html",
               url: '/AccountMaster/List',
               success: function (data) {
                   //Rebind Grid Data
                   $('#ListViewModel').html(data);
               }
           });
             
        }
        else {
            ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectBalancesheet", "SuccessMessage", "#FFCC80");
            //$('#SuccessMessage').html("Please select balancesheet"); 
            //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
        }
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var Balancesheet = $("#selectedBalsheetID").val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { "selectedBalsheet": Balancesheet, "actionMode": actionMode },
            dataType: "html",
            url: '/AccountMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                ////twitter type notification
                notify(message, colorCode);
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
             url: '/AccountMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //Method to create xml of selected Balancesheet 
    GetSelectedBalancesheet: function () {
        debugger;
        var xmlParamList = "<rows>"
        var selectedItem = $("select[id=checkboxlist1]").val();
        if (selectedItem != null) {
            for (var i = 0; i < selectedItem.length; i++) {
                //alert(selectedItem[i].split('~')[0]);
                if (parseInt(selectedItem[i].split(',')[0]) == 0) {
                    xmlParamList = xmlParamList + "<row>" + "<AccBalsheetMstID>" + selectedItem[i].split('~')[1] + "</AccBalsheetMstID>" + "</row>";
                }
            }
        }
        if (xmlParamList.length > 6)
            AccountMaster.SelectedAccBalsheetMstIDs = xmlParamList + "</rows>";
        else
            AccountMaster.SelectedAccBalsheetMstIDs = "0";

    },
    //Fire ajax call to insert update and delete record
    AjaxCallAccountMaster: function () {
        var AccountMasterData = null;
        if (AccountMaster.ActionName == "Create") {
            $("#FormCreateAccountMaster").validate();
            if ($("#FormCreateAccountMaster").valid()) {
                AccountMasterData = null;
                AccountMasterData = AccountMaster.GetAccountMaster();
                ajaxRequest.makeRequest("/AccountMaster/Create", "POST", AccountMasterData, AccountMaster.Success, "CreateAccountMasterRecord");
            }
        }
        else if (AccountMaster.ActionName == "Edit") {            
                AccountMasterData = null;
                AccountMasterData = AccountMaster.GetAccountMaster();
                ajaxRequest.makeRequest("/AccountMaster/Edit", "POST", AccountMasterData, AccountMaster.Success, "EditAccountMasterRecord");
            
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountMaster: function () {
        var Data = {
        };
        //debugger;
        if (AccountMaster.ActionName == "Create" || AccountMaster.ActionName == "Edit") {
            
            //debugger;
            Data.ID = $('input[name=ID]').val();            
            Data.AccBalsheetMstID = $('input[name=AccBalsheetMstID]').val();
            Data.AccBankDetailsID = $('input[name=AccBankDetailsID]').val();
            Data.GroupID = $("input[name=GroupID]").val();
            Data.AltGroupID = parseInt ($('#AlternateGroupList').val()) > 0? $('#AlternateGroupList').val() :0  ;
            Data.AccountCode = $("#AccountCode").val();
            Data.AccountName = $("#AccountName").val();
            Data.CashBankFlag = $("#AccountType").val();
            Data.PersonType = $('#ControlHead').val();
            Data.SurpDifiFlag = $('#SurpDefFlagList').val();
            Data.ExclusivelyForCentre = $("input[id=ExclusivelyForCentre]:checked").val();
            Data.BackDatetimedEntries = $('#BackDatetimedEntries').is(':checked');
            Data.DebitCreditFlag = $('input[name=DebitCreditFlag]:checked').val();
            Data.BankAccountNumber = $("#BankAccountNumber").val();
            Data.BankLimitAmount = $("#BankLimitAmount").val();
            Data.OpenDatetime = $('input[name=OpenDatetime]').val();            
            Data.DueDatetime = $('input[name=DueDatetime]').val();
            Data.AccountInNameOf = $('#AccountInNameOf').val();
            Data.BankBranchName = $("#BankBranchName").val();
            Data.InterestMode = $("#InterestModeList").val();
            Data.InterestType = $("#InterestTypeList").val();
            Data.RateOfInterest = $('#RateOfInterest').val();
            Data.SelectedXml = AccountMaster.SelectedAccBalsheetMstIDs;
        }
        return Data;
        return false;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var splitData = data.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        AccountMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
       
    },
};