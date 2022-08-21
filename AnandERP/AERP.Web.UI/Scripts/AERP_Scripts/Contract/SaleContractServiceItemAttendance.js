//this class contain methods related to nationality functionality
var SaleContractServiceItemAttendance = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractServiceItemAttendance.constructor();
        //SaleContractServiceItemAttendance.initializeValidation();
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
            SaleContractServiceItemAttendance.LoadList();
        });

        $("#SaveSaleContractServiceItemAttendance").click(function () {
            debugger
            SaleContractServiceItemAttendance.GetXmlData();

            SaleContractServiceItemAttendance.ActionName = "Create";
            SaleContractServiceItemAttendance.AjaxCallSaleContractServiceItemAttendance();
        });

        $("#btnRemoveMachine").click(function () {
            if ($('#MachineAssignUptoDate').val() == "") {
                $("#displayErrorMessage").text("Please select Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            SaleContractServiceItemAttendance.ActionName = "Remove";
            SaleContractServiceItemAttendance.AjaxCallSaleContractServiceItemAttendance();
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
            url: '/SaleContractServiceItemAttendance/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractServiceItemAttendance: function () {
        var SaleContractServiceItemAttendanceData = null;
        if (SaleContractServiceItemAttendance.ActionName == "Create") {
            //$("#FormCreateSaleContractServiceItemAttendance").validate();
            //if ($("#FormCreateSaleContractServiceItemAttendance").valid()) {
            SaleContractServiceItemAttendanceData = null;
            SaleContractServiceItemAttendanceData = SaleContractServiceItemAttendance.GetSaleContractServiceItemAttendance();
            ajaxRequest.makeRequest("/SaleContractServiceItemAttendance/Create", "POST", SaleContractServiceItemAttendanceData, SaleContractServiceItemAttendance.Success);
            //}
        } else if (SaleContractServiceItemAttendance.ActionName == "Remove") {
            //$("#FormCreateSaleContractServiceItemAttendance").validate();
            //if ($("#FormCreateSaleContractServiceItemAttendance").valid()) {
            SaleContractServiceItemAttendanceData = null;
            SaleContractServiceItemAttendanceData = SaleContractServiceItemAttendance.GetSaleContractServiceItemAttendance();
            ajaxRequest.makeRequest("/SaleContractServiceItemAttendance/RemoveMachine", "POST", SaleContractServiceItemAttendanceData, SaleContractServiceItemAttendance.Success);
            //}
        }
    },
    GetXmlData: function () {

        var DataArray = [];
        var data = $('#tblAttendanceData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });

        //alert(DataArray)
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 4) {

            ParameterXml = ParameterXml + "<row><ItemNumber>" + DataArray[i] + "</ItemNumber><SaleContractServiceItemAttendanceID>" + DataArray[i + 1] + "</SaleContractServiceItemAttendanceID><TotalDays>" + DataArray[i + 2] + "</TotalDays><TotalAttendance>" + DataArray[i + 3] + "</TotalAttendance></row>";

            if (ParameterXml.length > 6)
                SaleContractServiceItemAttendance.XMLstring = ParameterXml + "</rows>";
            else
                SaleContractServiceItemAttendance.XMLstring = "";
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractServiceItemAttendance: function () {
        var Data = {
        };
        if (SaleContractServiceItemAttendance.ActionName == "Create") {
            Data.SaleContractBillingSpanID = $("#GetSaleContractBillingSpanID").val();
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.XMLstringForAttendance = SaleContractServiceItemAttendance.XMLstring;
        } else if (SaleContractServiceItemAttendance.ActionName == "Remove") {
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.SaleContractMachineAssignID = $("#SaleContractMachineAssignID").val();
            Data.MachineAssignUptoDate = $("#MachineAssignUptoDate").val();
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

