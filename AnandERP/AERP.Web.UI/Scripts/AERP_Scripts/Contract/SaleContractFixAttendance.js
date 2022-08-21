//this class contain methods related to nationality functionality
var SaleContractFixAttendance = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractFixAttendance.constructor();
        //SaleContractFixAttendance.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#btnShowList").unbind("click").click(function () {
            if ($("#SaleContractMasterID").val() == "0") {
                notify("Please select Contract", "warning");
                return false;
            }
            if ($("#SaleContractBillingSpanID").val() == "") {
                notify("Please select Span", "warning");
                return false;
            }
            SaleContractFixAttendance.LoadList();
        });

        $("#SaveSaleContractFixAttendance").click(function () {

            SaleContractFixAttendance.GetXmlData();

            SaleContractFixAttendance.ActionName = "Create";
            SaleContractFixAttendance.AjaxCallSaleContractFixAttendance();
        });

        InitAnimatedBorder();
        CloseAlert();
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",
            data: { "SaleContractMasterID": $("#SaleContractMasterID").val(), "SaleContractBillingSpanID": $("#SaleContractBillingSpanID").val() },
            dataType: "html",
            url: '/SaleContractFixAttendance/List',
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
    //        url: '/SaleContractFixAttendance/List',
    //        success: function (data) {
    //            //Rebind Grid Data
    //            $('#ListViewModel').html(data);
    //            notify(message, colorCode);
    //        }
    //    });
    //},
    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractFixAttendance: function () {
        var SaleContractFixAttendanceData = null;
        if (SaleContractFixAttendance.ActionName == "Create") {
            //$("#FormCreateSaleContractFixAttendance").validate();
            //if ($("#FormCreateSaleContractFixAttendance").valid()) {
            SaleContractFixAttendanceData = null;
            SaleContractFixAttendanceData = SaleContractFixAttendance.GetSaleContractFixAttendance();
            ajaxRequest.makeRequest("/SaleContractFixAttendance/AddFixItemData", "POST", SaleContractFixAttendanceData, SaleContractFixAttendance.Success);
            //}
        }
    },
    GetXmlData: function () {

        var DataArray = [];
        var data = $('#tblFixItemData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });

        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 9) {
            {
                ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><SaleContractFixItemID>" + DataArray[i + 1] + "</SaleContractFixItemID><TotalDays>" + DataArray[i + 2] + "</TotalDays><IsSalaryDaysOnWeeklyOff>" + DataArray[i + 3] + "</IsSalaryDaysOnWeeklyOff><WeeklyOffDays>" + DataArray[i + 4] + "</WeeklyOffDays><BillingDays>" + DataArray[i + 5] + "</BillingDays><IsBillingDaysOnWeeklyOff>" + DataArray[i + 6] + "</IsBillingDaysOnWeeklyOff><BillingWeeklyOffDays>" + DataArray[i + 7] + "</BillingWeeklyOffDays><TotalAttendance>" + DataArray[i + 8] + "</TotalAttendance></row>";
            }

            if (ParameterXml.length > 6)
                SaleContractFixAttendance.XMLstring = ParameterXml + "</rows>";
            else
                SaleContractFixAttendance.XMLstring = "";
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractFixAttendance: function () {
        var Data = {
        };
        if (SaleContractFixAttendance.ActionName == "Create") {
            Data.SaleContractBillingSpanID = $("#GetSaleContractBillingSpanID").val();
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.XMLstringForFixItemData = SaleContractFixAttendance.XMLstring;
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

