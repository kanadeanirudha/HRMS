//this class contain methods related to nationality functionality
var AccountMasterReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountMasterReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form

        $('#CreateAccountMasterReportRecord').on("click", function () {
            AccountMasterReport.ActionName = "Create";
            AccountMasterReport.AjaxCallAccountMasterReport();
        });

        $('#EditAccountMasterReportRecord').on("click", function () {

            AccountMasterReport.ActionName = "Edit";
            AccountMasterReport.AjaxCallAccountMasterReport();
        });

        $('#DeleteAccountMasterReportRecord').on("click", function () {

            AccountMasterReport.ActionName = "Delete";
            AccountMasterReport.AjaxCallAccountMasterReport();
        });

        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        $(".ajax").colorbox();

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Description').focus();
        });

        $('#SelectedHeadID').on("change", function () {
            var valu = $('#SelectedHeadID :selected').val();
            AccountMasterReport.LoadListByCentreCode(valu);
        });


    },
    //LoadList method is used to load List page
    LoadList: function () {
        debugger;
        var selectedItem = $("#selectedBalsheetID").val();
        if (selectedItem > 0) {
            $.ajax(
             {
                 cache: false,
                 type: "GET",
                 dataType: "html",
                 data: { selectedBalsheetID: selectedItem },
                 url: '/AccountMasterReport/List',
                 success: function (data) {
                     alert(data);
                     //Rebind Grid Data
                     $('#ListViewModel').html(data);
                 }
             });
        }
        else {
            
            $('#SuccessMessage').html("Please select balancesheet first.");
            $('#SuccessMessage').delay(400).slideDown(400).delay(2500).slideUp(400).css('background-color', "#FFCC80");
        }

    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/AccountMasterReport/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
            }
        });
    },
    //ReloadList method is used to load List page
    LoadListByCentreCode: function (SelectedHeadID) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/AccountMasterReport/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAccountMasterReport: function () {
        var AccountMasterReportData = null;
        if (AccountMasterReport.ActionName == "Create") {
            $("#FormCreateAccountMasterReport").validate();
            if ($("#FormCreateAccountMasterReport").valid()) {
                AccountMasterReportData = null;
                AccountMasterReportData = AccountMasterReport.GetAccountMasterReport();
                ajaxRequest.makeRequest("/AccountMasterReport/Create", "POST", AccountMasterReportData, AccountMasterReport.Success);
            }
        }
        else if (AccountMasterReport.ActionName == "Edit") {
            $("#FormEditAccountMasterReport").validate();
            if ($("#FormEditAccountMasterReport").valid()) {
                AccountMasterReportData = null;
                AccountMasterReportData = AccountMasterReport.GetAccountMasterReport();
                ajaxRequest.makeRequest("/AccountMasterReport/Edit", "POST", AccountMasterReportData, AccountMasterReport.Success);
            }
        }
        else if (AccountMasterReport.ActionName == "Delete") {
            AccountMasterReportData = null;
            AccountMasterReportData = AccountMasterReport.GetAccountMasterReport();
            ajaxRequest.makeRequest("/AccountMasterReport/Delete", "POST", AccountMasterReportData, AccountMasterReport.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountMasterReport: function () {
        var Data = {
        };
        if (AccountMasterReport.ActionName == "Create" || AccountMasterReport.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.HeadID = $('#HeadID').val();
            Data.CategoryCode = $('#CategoryCode').val();
            Data.CategoryDescription = $('#CategoryDescription').val();
            Data.PrintingSequence = $('input[name=PrintingSequence]').val();
            Data.IsActive = $('input[name=IsActive]').val();
        }
        else if (AccountMasterReport.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
            Data.CategoryCode = $('input[name=CategoryCode]').val();
            Data.CategoryDescription = $('input[name=CategoryDescription]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        parent.$.colorbox.close();
        AccountMasterReport.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
};