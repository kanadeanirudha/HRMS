//this class contain methods related to nationality functionality
var AccountHeadMasterReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountHeadMasterReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form

        $('#CreateAccountHeadMasterReportRecord').on("click", function () {
            AccountHeadMasterReport.ActionName = "Create";
            AccountHeadMasterReport.AjaxCallAccountHeadMasterReport();
        });

        $('#EditAccountHeadMasterReportRecord').on("click", function () {

            AccountHeadMasterReport.ActionName = "Edit";
            AccountHeadMasterReport.AjaxCallAccountHeadMasterReport();
        });

        $('#DeleteAccountHeadMasterReportRecord').on("click", function () {

            AccountHeadMasterReport.ActionName = "Delete";
            AccountHeadMasterReport.AjaxCallAccountHeadMasterReport();
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
            AccountHeadMasterReport.LoadListByCentreCode(valu);
        });

        $("#btnPrint").on("click", function () {
            $.ajax(
         {
             cache: false,
             type: "GET",
             dataType: "html",
             data:{format :"pdf"},
             url: '/AccountHeadMasterReport/Report',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });


        });


    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "GET",
             dataType: "html",
             url: '/AccountHeadMasterReport/List',
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
            url: '/AccountHeadMasterReport/List',
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
            url: '/AccountHeadMasterReport/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAccountHeadMasterReport: function () {
        var AccountHeadMasterReportData = null;
        if (AccountHeadMasterReport.ActionName == "Create") {
            $("#FormCreateAccountHeadMasterReport").validate();
            if ($("#FormCreateAccountHeadMasterReport").valid()) {
                AccountHeadMasterReportData = null;
                AccountHeadMasterReportData = AccountHeadMasterReport.GetAccountHeadMasterReport();
                ajaxRequest.makeRequest("/AccountHeadMasterReport/Create", "POST", AccountHeadMasterReportData, AccountHeadMasterReport.Success);
            }
        }
        else if (AccountHeadMasterReport.ActionName == "Edit") {
            $("#FormEditAccountHeadMasterReport").validate();
            if ($("#FormEditAccountHeadMasterReport").valid()) {
                AccountHeadMasterReportData = null;
                AccountHeadMasterReportData = AccountHeadMasterReport.GetAccountHeadMasterReport();
                ajaxRequest.makeRequest("/AccountHeadMasterReport/Edit", "POST", AccountHeadMasterReportData, AccountHeadMasterReport.Success);
            }
        }
        else if (AccountHeadMasterReport.ActionName == "Delete") {
            AccountHeadMasterReportData = null;
            AccountHeadMasterReportData = AccountHeadMasterReport.GetAccountHeadMasterReport();
            ajaxRequest.makeRequest("/AccountHeadMasterReport/Delete", "POST", AccountHeadMasterReportData, AccountHeadMasterReport.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountHeadMasterReport: function () {
        var Data = {
        };
        if (AccountHeadMasterReport.ActionName == "Create" || AccountHeadMasterReport.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.HeadID = $('#HeadID').val();
            Data.CategoryCode = $('#CategoryCode').val();
            Data.CategoryDescription = $('#CategoryDescription').val();
            Data.PrintingSequence = $('input[name=PrintingSequence]').val();
            Data.IsActive = $('input[name=IsActive]').val();
        }
        else if (AccountHeadMasterReport.ActionName == "Delete") {
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
        AccountHeadMasterReport.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
};