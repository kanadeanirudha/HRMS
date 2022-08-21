//this class contain methods related to nationality functionality
var AccountDayBookReport = {
    //Member variables
    ActionName: null,
    SelectedTransactionTypes: null,
    SelectedAccounts: null,
    //Class intialisation method
    Initialize: function () {
        AccountDayBookReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form

        $('#btnDayBookSubmit').on("click", function () {
            //AccountDayBookReport.ActionName = "Create";
            //AccountDayBookReport.AjaxCallAccountDayBookReport();
            //Method to create xml of selected Balancesheet 
            debugger;

            AccountDayBookReport.GetTransactionType();
            AccountDayBookReport.GetSelectedAccounts();
            $("#AccBalsheetMstID").val($("#selectedBalsheetID").val());
            $("#AccSessionID").val($("#SelectedAccountSessionID").val());
            $("#IsPosted").val(true);


        });






        $('#EditAccountDayBookReportRecord').on("click", function () {

            AccountDayBookReport.ActionName = "Edit";
            AccountDayBookReport.AjaxCallAccountDayBookReport();
        });

        $('#DeleteAccountDayBookReportRecord').on("click", function () {

            AccountDayBookReport.ActionName = "Delete";
            AccountDayBookReport.AjaxCallAccountDayBookReport();
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

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Description').focus();
        });

        $('#SelectedHeadID').on("change", function () {
            var valu = $('#SelectedHeadID :selected').val();
            AccountDayBookReport.LoadListByCentreCode(valu);
        });




        //$("#SessionFromDate").datetimepicker({
        //    format: "DD MMMM YYYY",
        //    //numberOfMonths: 1,
        //    //dateFormat: 'd M yy',
        //});
        //$("#SessionUptoDate").datetimepicker({
        //    format: "DD MMMM YYYY",
        //    //numberOfMonths: 1,
        //    //dateFormat: 'd M yy',
        //});

        $('#SelectedAccountSessionID').on("change", function () {
            //$("#SessionFromDate").datepicker('option', { minDate: new Date($('#SelectedAccountSessionID :selected').text().split('-')[0]), maxDate: new Date($('#SelectedAccountSessionID :selected').text().split('-')[1]) });
            //$("#SessionUptoDate").datepicker('option', { minDate: new Date($('#SelectedAccountSessionID :selected').text().split('-')[0]), maxDate: new Date($('#SelectedAccountSessionID :selected').text().split('-')[1]) });
            //$("#SessionFromDate").val($('#SelectedAccountSessionID :selected').text().split('-')[0]);
            //$("#SessionUptoDate").val($('#SelectedAccountSessionID :selected').text().split('-')[1]);


            var minDate = new Date(new Date($('#SelectedAccountSessionID :selected').text().split('-')[0]));
            minDate.setDate(minDate.getDate());
            var maxDate = new Date(new Date($('#SelectedAccountSessionID :selected').text().split('-')[1]));
            maxDate.setDate(maxDate.getDate());
            $('#SessionFromDate').data("DateTimePicker").minDate(minDate);
            $('#SessionUptoDate').data("DateTimePicker").maxDate(maxDate);
            $("#SessionFromDate").val($('#SelectedAccountSessionID :selected').text().split('-')[0]);
            $("#SessionUptoDate").val($('#SelectedAccountSessionID :selected').text().split('-')[1]);



        })

        if ($("#Pattern").val() != "DETAILED") {

            $("#patternTypediv").show();
        }
        else {

            $("#patternTypediv").hide();
        }

        //$("#PatternType").prop("disabled", true);
        $("#Pattern").on("change", function () {
            //debugger;
            if ($(this).val().toLocaleUpperCase() == "DETAILED") {
                $("#PatternType").prop("disabled", true);
                //$("#PatternType").val("");
                $("#patternTypediv").hide();
            }
            else {
                $("#PatternType").prop("disabled", false);
                $("#patternTypediv").show();
            }
        });



    },

    //LoadList method is used to load List page
    LoadList: function () {
        //debugger;
        var selectedItem = $("#selectedBalsheetID").val();
        if (selectedItem > 0) {
            $.ajax(
             {
                 cache: false,
                 type: "GET",
                 dataType: "html",
                 data: { selectedBalsheetID: selectedItem },
                 url: '/AccountDayBookReport/List',
                 success: function (data) {
                     alert(data);
                     //Rebind Grid Data
                     $('#ListViewModel').html(data);
                 }
             });
        }
        else {

            //$('#SuccessMessage').html("Please select balancesheet first.");
            //$('#SuccessMessage').delay(400).slideDown(400).delay(2500).slideUp(400).css('background-color', "#FFCC80");
            notify('Please select balancesheet first.', 'warning');
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
            url: '/AccountDayBookReport/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
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
            url: '/AccountDayBookReport/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAccountDayBookReport: function () {
        var AccountDayBookReportData = null;
        if (AccountDayBookReport.ActionName == "Create") {
            $("#FormCreateAccountDayBookReport").validate();
            if ($("#FormCreateAccountDayBookReport").valid()) {
                AccountDayBookReportData = null;
                AccountDayBookReportData = AccountDayBookReport.GetAccountDayBookReport();
                ajaxRequest.makeRequest("/AccountDayBookReport/Create", "POST", AccountDayBookReportData, AccountDayBookReport.Success);
            }
        }
        else if (AccountDayBookReport.ActionName == "Edit") {
            $("#FormEditAccountDayBookReport").validate();
            if ($("#FormEditAccountDayBookReport").valid()) {
                AccountDayBookReportData = null;
                AccountDayBookReportData = AccountDayBookReport.GetAccountDayBookReport();
                ajaxRequest.makeRequest("/AccountDayBookReport/Edit", "POST", AccountDayBookReportData, AccountDayBookReport.Success);
            }
        }
        else if (AccountDayBookReport.ActionName == "Delete") {
            AccountDayBookReportData = null;
            AccountDayBookReportData = AccountDayBookReport.GetAccountDayBookReport();
            ajaxRequest.makeRequest("/AccountDayBookReport/Delete", "POST", AccountDayBookReportData, AccountDayBookReport.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountDayBookReport: function () {
        var Data = {
        };
        if (AccountDayBookReport.ActionName == "Create" || AccountDayBookReport.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.HeadID = $('#HeadID').val();
            Data.CategoryCode = $('#CategoryCode').val();
            Data.CategoryDescription = $('#CategoryDescription').val();
            Data.PrintingSequence = $('input[name=PrintingSequence]').val();
            Data.IsActive = $('input[name=IsActive]').val();
        }
        else if (AccountDayBookReport.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
            Data.CategoryCode = $('input[name=CategoryCode]').val();
            Data.CategoryDescription = $('input[name=CategoryDescription]').val();
        }
        return Data;
    },
    //Method to create xml of selected TransactionType 
    GetTransactionType: function () {
        var xmlParamList = "<rows>"
        var TransactionType = $('#checkboxlist2').val();
        for (i = 0; i < TransactionType.length; i++) {
            xmlParamList = xmlParamList + "<row>" + "<ID>" + TransactionType[i] + "</ID>" + "</row>";
        }
        if (xmlParamList.length > 6) {
            AccountDayBookReport.SelectedTransactionTypes = xmlParamList + "</rows>";
            $("#TransactionTypeXmlString").val(AccountDayBookReport.SelectedTransactionTypes);
        }
        else
            $("#TransactionTypeXmlString").val('');

    },

    //Method to create xml of Get Selected Accounts 
    GetSelectedAccounts: function () {

        var xmlParamList = "<rows>"
        var AccountMaster = $('#checkboxlist1').val();
        for (i = 0; i < AccountMaster.length; i++) {
            xmlParamList = xmlParamList + "<row>" + "<ID>" + AccountMaster[i] + "</ID>" + "</row>";
        }

        if (xmlParamList.length > 6) {
            AccountDayBookReport.SelectedAccounts = xmlParamList + "</rows>";
            $("#AccountIDsXmlString").val(AccountDayBookReport.SelectedAccounts);
        }
        else
            $("#AccountIDsXmlString").val('');
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        parent.$.colorbox.close();
        AccountDayBookReport.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    if (data == "True") {
    //        AccountDayBookReport.ReloadList("Record Updated Sucessfully.")
    //    }
    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    if (data == "True") {
    //        AccountDayBookReport.ReloadList("Record Deleted Sucessfully.")
    //    }
    //},
};