//this class contain methods related to nationality functionality
var SaleContractAttendance = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractAttendance.constructor();
        //SaleContractAttendance.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#btnShowList").unbind("click").click(function () {
            if ($("#SaleContractMasterID").val() == "0") {
                notify("Please select Contract", "warning");
                return false;
            }
            if ($("#Months").val() == "") {
                notify("Please select Month", "warning");
                return false;
            }
            SaleContractAttendance.LoadList();
        });

        $("#btnShowListMonthWise").unbind("click").click(function () {
            if ($("#SaleContractMasterID").val() == "0") {
                notify("Please select Contract", "warning");
                return false;
            }
            if ($("#SaleContractBillingSpanID").val() == "") {
                notify("Please select Span", "warning");
                return false;
            }
            SaleContractAttendance.LoadListMonthWise();
        });

        $("#SaveSaleContractAttendance").click(function () {
            debugger
            SaleContractAttendance.GetXmlData();

            SaleContractAttendance.ActionName = "Create";
            SaleContractAttendance.AjaxCallSaleContractAttendance();
        });

        $("#SaveSaleContractAttendanceMonthWise").click(function () {
            debugger
            SaleContractAttendance.GetXmlDataMonthWise();

            SaleContractAttendance.ActionName = "CreateMonthWise";
            SaleContractAttendance.AjaxCallSaleContractAttendance();
        });

        $("#btnCreateSalarySplitSpan").click(function () {

            if ($("#GetSaleContractBillingSpanID").val() == "") {
                $("#displayErrorMessage").text("Please select Span.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }

            if ($("#SplitFromDate").val() == "") {
                $("#displayErrorMessage").text("Please select Split From Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }

            SaleContractAttendance.ActionName = "SplitSpan";
            SaleContractAttendance.AjaxCallSaleContractAttendance();
        });

        $("#SaveSalaryForManPowerItem").click(function () {
            SaleContractAttendance.ActionName = "SaveSalaryForManPowerItem";
            SaleContractAttendance.AjaxCallSaleContractAttendance();
        });

        InitAnimatedBorder();
        CloseAlert();
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",
            data: { "SaleContractMasterID": $("#SaleContractMasterID").val(), "Months": $("#Months").val() },
            dataType: "html",
            url: '/SaleContractAttendance/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    LoadListMonthWise: function () {

        $.ajax({
            cache: false,
            type: "POST",
            data: { "SaleContractMasterID": $("#SaleContractMasterID").val(), "SaleContractBillingSpanID": $("#SaleContractBillingSpanID").val() },
            dataType: "html",
            url: '/SaleContractAttendance/ListMonthWise',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    //ReLoadList: function (message, colorCode, actionMode) {

    //    $.ajax({
    //        cache: false,
    //        type: "POST",
    //        data: { "actionMode": actionMode, "SaleContractMasterID": $("#SaleContractMasterID").val(), "Months": $("#Months").val() },
    //        dataType: "html",
    //        url: '/SaleContractAttendance/List',
    //        success: function (data) {
    //            //Rebind Grid Data
    //            $('#ListViewModel').html(data);
    //            notify(message, colorCode);
    //        }
    //    });
    //},
    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractAttendance: function () {
        var SaleContractAttendanceData = null;
        if (SaleContractAttendance.ActionName == "Create") {
            //$("#FormCreateSaleContractAttendance").validate();
            //if ($("#FormCreateSaleContractAttendance").valid()) {
            SaleContractAttendanceData = null;
            SaleContractAttendanceData = SaleContractAttendance.GetSaleContractAttendance();
            ajaxRequest.makeRequest("/SaleContractAttendance/AddAttendance", "POST", SaleContractAttendanceData, SaleContractAttendance.Success);
            //}
        } else if (SaleContractAttendance.ActionName == "CreateMonthWise") {
            //$("#FormCreateSaleContractAttendance").validate();
            //if ($("#FormCreateSaleContractAttendance").valid()) {
            SaleContractAttendanceData = null;
            SaleContractAttendanceData = SaleContractAttendance.GetSaleContractAttendance();
            ajaxRequest.makeRequest("/SaleContractAttendance/AddAttendanceMonthWise", "POST", SaleContractAttendanceData, SaleContractAttendance.Success);
            //}
        } else if (SaleContractAttendance.ActionName == "SplitSpan") {
            //$("#FormCreateSaleContractAttendance").validate();
            //if ($("#FormCreateSaleContractAttendance").valid()) {
            SaleContractAttendanceData = null;
            SaleContractAttendanceData = SaleContractAttendance.GetSaleContractAttendance();
            ajaxRequest.makeRequest("/SaleContractAttendance/SplitSalarySpan", "POST", SaleContractAttendanceData, SaleContractAttendance.Success);
            //}
        } else if (SaleContractAttendance.ActionName == "SaveSalaryForManPowerItem") {
            //$("#FormCreateSaleContractAttendance").validate();
            //if ($("#FormCreateSaleContractAttendance").valid()) {
            SaleContractAttendanceData = null;
            SaleContractAttendanceData = SaleContractAttendance.GetSaleContractAttendance();
            ajaxRequest.makeRequest("/SaleContractAttendance/AddSalaryForManPowerItem", "POST", SaleContractAttendanceData, SaleContractAttendance.Success);
            //}
        }
    },
    GetXmlData: function () {

        var DataArray = [];
        var data = $('#tblAttendanceData tbody tr td input').each(function () {
            if ($(this).attr('type') == 'checkbox' && $(this).hasClass('AttStatusFlag')) {
                DataArray.push($(this).is(":checked") ? 1 : ($("#IsWeeklyOff").is(":checked") ? 3 : ($("#IsHoliday").is(":checked") ? 4 : 2)));
            }
            else if ($(this).attr('type') == 'checkbox' && $(this).hasClass('HalfDayLeaveFlag')) {
                DataArray.push($(this).is(":checked") ? 1 : 0);
            }
            else {
                DataArray.push($(this).val());
            }
        });

        //alert(DataArray)
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 6) {
            {
                ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><SaleContractManPowerItemID>" + DataArray[i + 1] + "</SaleContractManPowerItemID><SaleContractEmployeeMasterID>" + DataArray[i + 2] + "</SaleContractEmployeeMasterID><AttendanceStatus>" + DataArray[i + 3] + "</AttendanceStatus><IsHalfDayLeave>" + DataArray[i + 4] + "</IsHalfDayLeave><OvertimeHours>" + DataArray[i + 5] + "</OvertimeHours></row>";
            }

            if (ParameterXml.length > 6)
                SaleContractAttendance.XMLstring = ParameterXml + "</rows>";
            else
                SaleContractAttendance.XMLstring = "";
        }
    },
    GetXmlDataMonthWise: function () {

        var DataArray = [];
        var data = $('#tblAttendanceData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });

        //alert(DataArray)
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 16) {

            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><SaleContractManPowerItemID>" + DataArray[i + 1] + "</SaleContractManPowerItemID><SaleContractEmployeeMasterID>" + DataArray[i + 2] + "</SaleContractEmployeeMasterID><TotalOverTimeSalaryDays>" + DataArray[i + 3] + "</TotalOverTimeSalaryDays><TotalDays>" + DataArray[i + 4] + "</TotalDays><TotalOverTimeBillingDays>" + DataArray[i + 5] + "</TotalOverTimeBillingDays><TotalBillingDays>" + DataArray[i + 6] + "</TotalBillingDays><IsSalaryDaysOnWeeklyOff>" + DataArray[i + 7] + "</IsSalaryDaysOnWeeklyOff><IsBillingDaysOnWeeklyOff>" + DataArray[i + 8] + "</IsBillingDaysOnWeeklyOff><IsOTDaysOnTotalOff>" + DataArray[i + 9] + "</IsOTDaysOnTotalOff><IsOTBillingDaysOnTotalOff>" + DataArray[i + 10] + "</IsOTBillingDaysOnTotalOff><TotalWeeklyOffDays>" + DataArray[i + 11] + "</TotalWeeklyOffDays><TotalWeeklyOffBillingDays>" + DataArray[i + 12] + "</TotalWeeklyOffBillingDays><TotalAttendance>" + DataArray[i + 13] + "</TotalAttendance><OvertimeHours>" + DataArray[i + 14] + "</OvertimeHours><SaleContractManPowerAssignID>" + DataArray[i + 15] + "</SaleContractManPowerAssignID></row>";


            if (ParameterXml.length > 6)
                SaleContractAttendance.XMLstring = ParameterXml + "</rows>";
            else
                SaleContractAttendance.XMLstring = "";
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractAttendance: function () {
        var Data = {
        };
        if (SaleContractAttendance.ActionName == "Create") {
            Data.AttendanceDate = $("#AttendanceDate").val();
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.XMLstringForAttendance = SaleContractAttendance.XMLstring;
        } else if (SaleContractAttendance.ActionName == "CreateMonthWise") {
            Data.SaleContractBillingSpanID = $("#GetSaleContractBillingSpanID").val();
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.XMLstringForAttendance = SaleContractAttendance.XMLstring;
        } else if (SaleContractAttendance.ActionName == "SplitSpan") {
            Data.SaleContractBillingSpanID = $("#GetSaleContractBillingSpanID").val();
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.SplitFromDate = $("#SplitFromDate").val();
        } else if (SaleContractAttendance.ActionName == "SaveSalaryForManPowerItem") {
            Data.ID = $("#ID").val();
            Data.SalaryForManPowerItemID = $("#SalaryForManPowerItemID").val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        $.magnificPopup.close();
        if (splitData[1] == 'success') {
            $("#btnShowList").click();
            notify(splitData[0], splitData[1]);
        }
        else {
            notify(splitData[0], splitData[1]);
        }

    },
};

