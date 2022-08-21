//this class contain methods related to nationality functionality
var AccountCentreOpeningBalance = {
    //Member variables
    ActionName: null,
    SelectedXmlData: null,
    SelectedXmlDataForIndividualBalance: null,
    //Class intialisation method
    Initialize: function () {
        AccountCentreOpeningBalance.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        //$('#CreateAccCentreOpeningBalanceRecord').hide();

        $('#CreateAccCentreOpeningBalanceRecord').on("click", function () {
            
            AccountCentreOpeningBalance.ActionName = "Create";
            AccountCentreOpeningBalance.getDataFromDataTable();
            if (AccountCentreOpeningBalance.SelectedXmlData != "<rows></rows>") {
                AccountCentreOpeningBalance.AjaxCallAccountCentreOpeningBalance();
            }
            else {
                notify("No record updated", "warning");
                //$('#SuccessMessage').html("No record updated");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
            }


        });

        $('#CreateAccIndividualOpeningBalanceRecord').on("click", function () {
            
            
            AccountCentreOpeningBalance.ActionName = "IndividualOpeningBalance";
            AccountCentreOpeningBalance.getDataFromDataTableForIndividualBalance();
            AccountCentreOpeningBalance.AjaxCallAccountCentreOpeningBalance();
        });



        InitAnimatedBorder();
        CloseAlert();
        

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#AccountName').focus();
            $('#SelectedAccountType').val("");
            $('#ControlHeadlist').val("");
            $('#ControlHeadlist').prop("disabled", true);
            $('#SurpDefFlagList').val("");
            $('#InterestModeList').val("");
            $('#InterestTypeList').val("");
            return false;
        });



        $('#btnShowList').on("click", function () {
            
            //debugger;

            var SelectedBalanceSheet = $("#selectedBalsheetID").val();
            var SelectedAccountType = $("#SelectedAccountType").val();
            var SessionID = $("#SessionID").val();

            //var SelectedAccountType = $('input[name=SelectedAccountType').val();

            if (SelectedBalanceSheet != "" && SelectedAccountType != "" && SessionID != 0) {
                AccountCentreOpeningBalance.LoadListByAccountTypeAndBalanceSheet(SelectedBalanceSheet, SelectedAccountType);

                if (SelectedAccountType == 0) {
                    $("#divSubmit").hide();

                }
                else {
                    $("#divSubmit").show();

                }
            }
            else if ((SessionID == 0)) {
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectSession", "SuccessMessage", "#FFCC80");
                $("#displayErrorMessage p").text('Session is not defined.').closest('div').fadeIn().closest('div').addClass('alert-warning');
                $("#divSubmit").hide();
            }
            else if (SelectedBalanceSheet == "") {
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectBalancesheet", "SuccessMessage", "#FFCC80");
                $("#displayErrorMessage p").text('Please select balancesheet.').closest('div').fadeIn().closest('div').addClass('alert-warning');
                $("#divSubmit").hide();
            }
            else if ((SelectedAccountType == "")) {
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectAccount", "SuccessMessage", "#FFCC80");
                //$("#displayErrorMessage p").text('Please select account type.').closest('div').fadeIn().closest('div').addClass('alert-warning');
                notify("Please select account type.", "warning");
                $("#divSubmit").hide();
            }


        });
        $('#SelectedAccountType').on("change", function () {
            $("#divSubmit").hide();
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });
        $('#BankLimitAmount').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#RateOfInterest').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });
        //$('#txtOpeningBal').on("keydown", function (e) {
        //    alert("Dsfsd");
        //    AERPValidation.AllowNumbersOnly(e);
        //});

        if ($("#SelectedAccountType").val() != 0) {
            $("#divSubmit").hide();

        }
        else {
            $("#divSubmit").show();

        }

    },



    getDataFromDataTable: function () {

        var DataArray = [];
        var table = $('#myDataTable').DataTable();
        var data = table.$('input,select,input tag').each(function () {
            DataArray.push($(this).val());
        });

        var xmlParamList = "<rows>";
        var aa = [];
        var x = 0;
        var Count = DataArray.length / 3;
        for (var i = 0; i < Count; i++) {

            aa = DataArray[x + 2].split('~');

            // String for Insert 
            if (aa[0] == 0 && DataArray[x] != parseInt(0)) {
                xmlParamList = xmlParamList + "<row><ID>" + aa[0] + "</ID><AccountID>" + aa[1] + "</AccountID><OpeningBalance>" + DataArray[x] + "</OpeningBalance><DebitCreateFlag>" + DataArray[x + 1] + "</DebitCreateFlag></row>";
            }
            // String for Update
            if (aa[0] > 0 && aa[2] != DataArray[x] || aa[0] > 0 && aa[3] != DataArray[x + 1]) {
                xmlParamList = xmlParamList + "<row><ID>" + aa[0] + "</ID><AccountID>" + aa[1] + "</AccountID><OpeningBalance>" + DataArray[x] + "</OpeningBalance><DebitCreateFlag>" + DataArray[x + 1] + "</DebitCreateFlag></row>";
            }
            x = x + 3;
        }

        xmlParamList = xmlParamList + "</rows>";
        AccountCentreOpeningBalance.SelectedXmlData = xmlParamList;

    },

    getDataFromDataTableForIndividualBalance: function () {

        var DataArray = [];
        var table = $('#aa').DataTable();
        var data = table.$('input,select,input tag').each(function () {
            DataArray.push($(this).val());
        });

        var xmlParamList = "<rows>";
        var aa = [];
        var x = 0;
        var Count = DataArray.length / 3;
        for (var i = 0; i < Count; i++) {

            aa = DataArray[x + 2].split('~');
            // String for Insert 
            if (aa[1] == 0 && DataArray[x] != "") {
                xmlParamList = xmlParamList + "<row><ID>" + aa[1] + "</ID><PersonID>" + aa[0] + "</PersonID><OpeningBalance>" + DataArray[x] + "</OpeningBalance><DebitCreateFlag>" + DataArray[x + 1] + "</DebitCreateFlag></row>";
            }
            // String for Update
            if (aa[1] > 0 && aa[2] != DataArray[x] || aa[1] > 0 && aa[3] != DataArray[x + 1]) {
                xmlParamList = xmlParamList + "<row><ID>" + aa[1] + "</ID><PersonID>" + aa[0] + "</PersonID><OpeningBalance>" + DataArray[x] + "</OpeningBalance><DebitCreateFlag>" + DataArray[x + 1] + "</DebitCreateFlag></row>";
            }
            x = x + 3;
        }

        xmlParamList = xmlParamList + "</rows>";

        AccountCentreOpeningBalance.SelectedXmlDataForIndividualBalance = xmlParamList;

    },

    //LoadList method is used to load List page
    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();

        if (Balancesheet != null) {
            $.ajax(
                {
                    cache: false,
                    type: "POST",
                    data: { selectedBalsheet: Balancesheet, AccountType: "" },
                    dataType: "html",
                    url: '/AccountCentreOpeningBalance/List',
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
    ReloadList: function (message) {
        var SelectedBalanceSheet = $('#SelectedBalanceSheet :selected').val();
        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { centreCode: SelectedCentreCode, BalanceSheetID: SelectedBalanceSheet },
            dataType: "html",

            url: '/AccountCentreOpeningBalance/List',
            success: function (data) {
                $('#ListViewModel').html(data);
                
            }
        });
    },
    //LoadList method is used to load List page
    LoadListByAccountTypeAndBalanceSheet: function (SelectedBalanceSheet, SelectedAccountType) {

        $.ajax(
         {
             cache: false,
             type: "GET",
             dataType: "html",
             data: { selectedBalsheet: SelectedBalanceSheet, AccountType: SelectedAccountType },
             url: '/AccountCentreOpeningBalance/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAccountCentreOpeningBalance: function () {
        var AccountCentreOpeningBalanceData = null;
        if (AccountCentreOpeningBalance.ActionName == "Create") {
            $("#FormCreateAccountCentreOpeningBalance").validate();

            AccountCentreOpeningBalanceData = null;
            AccountCentreOpeningBalanceData = AccountCentreOpeningBalance.GetAccountCentreOpeningBalance();
            ajaxRequest.makeRequest("/AccountCentreOpeningBalance/Create", "POST", AccountCentreOpeningBalanceData, AccountCentreOpeningBalance.createSuccess, "CreateAccCentreOpeningBalanceRecord");

        }
        else if (AccountCentreOpeningBalance.ActionName == "IndividualOpeningBalance") {
            //debugger;
            $("#FormCreateAccIndividualOpeningBalance").validate();

            AccountCentreOpeningBalanceData = null;
            AccountCentreOpeningBalanceData = AccountCentreOpeningBalance.GetAccountCentreOpeningBalance();
            ajaxRequest.makeRequest("/AccountCentreOpeningBalance/IndividualOpeningBalance", "POST", AccountCentreOpeningBalanceData, AccountCentreOpeningBalance.createSuccess, "CreateAccIndividualOpeningBalanceRecord");
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountCentreOpeningBalance: function () {
        var Data = {
        };
        
        if (AccountCentreOpeningBalance.ActionName == "Create") {

            Data.ID = $('input[name=ID]').val();
            Data.AccBalsheetMstID = $("#selectedBalsheetID").val();
            Data.SelectedXmlData = AccountCentreOpeningBalance.SelectedXmlData;
            Data.AccSessionID = $('#SessionID').val();


        }
        else if (AccountCentreOpeningBalance.ActionName == "IndividualOpeningBalance") {

            Data.ID = $('input[name=ID]').val();
            Data.AccBalsheetMstID = $('#AccBalsheetMstID').val();
            Data.AccountID = $('#AccountID').val();
            Data.PersonType = $('#PersonType').val();
            Data.AccSessionID = $('#SessionID').val();
            Data.SelectedXmlDataForIndividualBalance = AccountCentreOpeningBalance.SelectedXmlDataForIndividualBalance;

        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {
        
        var splitData = data.split(',');
        
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        ReloadAccountCentreOpeningBalance();

        //$('#SuccessMessage').html(splitData[0]);
        //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
        //notify(message, colorCode);

        notify(splitData[0], splitData[1], splitData[2]);

    },
   
};

