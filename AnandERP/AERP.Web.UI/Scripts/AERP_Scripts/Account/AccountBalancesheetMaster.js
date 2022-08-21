var AccountBalanceSheet = {
    variable: null,
    Initialize: function () {
        //organisationStudyCentre.loadData();
        AccountBalanceSheet.constructor();
        //AccountBalanceSheet.initializeValidation();
    },
    constructor: function () {

        $('#btnShowList').on("click", function () {
            var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
            //alert(SelectedCentreCode);
            if (SelectedCentreCode != "") {
                AccountBalanceSheet.LoadListByCentreCode(SelectedCentreCode);
            }
            else if ((SelectedCentreCode == "" || SelectedCentreCode != null)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                notify("Please select centre.", "warning");
            }

        });

        $("#SelectedCentreCode").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');          
        });

        $('#AccBalsheetCode').keydown(function (e) {
            AERPValidation.NotAllowSpaces(e);
        });

        $('#CreateAccountBalanceSheetRecord').on("click", function () {
           
            AccountBalanceSheet.ActionName = "Create";
            var nullvalue = AccountBalanceSheet.AjaxCallAccountBalanceSheet();
        });
        $('#EditAccountBalanceSheetRecord').on("click", function () {
            //alert('here');
            AccountBalanceSheet.ActionName = "Edit";
            var values = AccountBalanceSheet.AjaxCallAccountBalanceSheet();
        });
        $('#DeleteAccountBalanceSheetRecord').on("click", function () {
            AccountBalanceSheet.ActionName = "Delete";
            AccountBalanceSheet.AjaxCallAccountBalanceSheet();
        });
        $('#closeBtn').on("click", function () {
            parent.$.colorbox.close();
        });
        InitAnimatedBorder();
        CloseAlert();
        /////$(".ajax").colorbox();
        $('#reset').on("click", function () {
            //$("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            //$('input:checkbox,input:radio').removeAttr('checked');
            $('#AccBalsheetHeadDesc').val('');
            $('#AccBalsheetCode').val('');

            $('#AccBalsheetHeadDesc').focus();
            
            return false;
        });
    },
    LoadList: function () {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/AccountBalancesheetMaster/List',
            success: function (data) {
                //alert(data);
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },

    ReloadList: function (message, colorCode, actionMode, centreCode) {
        //var SelectedCentreCode = $("#SelectedCentreCode :selected").val();
        $.ajax(
       {
           cache: false,
           type: "POST",
           dataType: "html",
           data: { actionMode: actionMode, centerCode: centreCode },
           url: '/AccountBalancesheetMaster/List',
           success: function (data) {
               //Rebind Grid Data
               $("#ListViewModel").empty().append(data);
               //twitter type notification
               notify(message, colorCode);
           }
       });
    },
    LoadListByCentreCode: function (SelectedCentreCode) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            data: { centerCode: SelectedCentreCode },
            dataType: "html",
            url: '/AccountBalancesheetMaster/List',
            success: function (data) {
                //alert(data);
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },


    AjaxCallAccountBalanceSheet: function () {
        var AccountBalanceSheetMasterData = null;
        if (AccountBalanceSheet.ActionName == "Create") {
            $("#FormCreateAccountBalanceSheetMaster").validate();
            if ($("#FormCreateAccountBalanceSheetMaster").valid()) {
                AccountBalanceSheetMasterData = null;
                AccountBalanceSheetMasterData = AccountBalanceSheet.GetAccountBalanceSheetMaster();
                ajaxRequest.makeRequest("/AccountBalancesheetMaster/Create", "POST", AccountBalanceSheetMasterData, AccountBalanceSheet.Success, "CreateAccountBalanceSheetRecord");
            }
        }
        else if (AccountBalanceSheet.ActionName == "Edit") {
            //alert('here');
            $("#FormEditAccountBalanceSheetMaster").validate();
            if ($("#FormEditAccountBalanceSheetMaster").valid()) {
                AccountBalanceSheetMasterData = null;
                AccountBalanceSheetMasterData = AccountBalanceSheet.GetAccountBalanceSheetMaster();
                ajaxRequest.makeRequest("/AccountBalancesheetMaster/Edit", "POST", AccountBalanceSheetMasterData, AccountBalanceSheet.Success, "EditAccountBalanceSheetRecord");
            }
        }
        else if (AccountBalanceSheet.ActionName == "Delete") {
            AccountBalanceSheetMasterData = null;
            AccountBalanceSheetMasterData = AccountBalanceSheet.GetAccountBalanceSheetMaster();
            ajaxRequest.makeRequest("/AccountBalancesheetMaster/Delete", "POST", AccountBalanceSheetMasterData, AccountBalanceSheet.Success);
        }
    },

    GetAccountBalanceSheetMaster: function () {
        //debugger;
        var Data = {
        };
        if (AccountBalanceSheet.ActionName == "Create" || AccountBalanceSheet.ActionName == "Edit") { 
            Data.ID = $('#ID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.AccBalsheetTypeID = $('#AccBalsheetTypeID').val();
            Data.AccBalsheetHeadDesc = $('#AccBalsheetHeadDesc').val();
            Data.AccBalsheetCode = $('#AccBalsheetCode').val();
        }
        else if (AccountBalanceSheet.ActionName == "Delete") {
            //Data.ID = $('#ID').val();
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    Success: function (data) {

        var CentreCode = data.CentreCodeWithName;
        var splitData = data.errorMessage.split(',');
        
       
        
        if (splitData[1] == 'success') {
            
            $.magnificPopup.close()
            AccountBalanceSheet.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
        }
        else {
            //alert(data);
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
    //editSuccess: function (data) {
    //    parent.$.colorbox.close();
   
    //    ReloadAccountBalanceSheetMaster();
    //},
    //deleteSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    if (data == "True") {
    //        AccountBalanceSheet.ReloadList("Record Deleted Sucessfully.");
    //    }
    //},
};


