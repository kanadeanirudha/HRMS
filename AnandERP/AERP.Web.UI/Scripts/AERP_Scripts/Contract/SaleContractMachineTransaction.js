//this class contain methods related to nationality functionality
var SaleContractMachineTransaction = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractMachineTransaction.constructor();
        //SaleContractMachineTransaction.initializeValidation();
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
            SaleContractMachineTransaction.LoadList();
        });

        $("#SaveSaleContractMachineTransaction").click(function () {
            SaleContractMachineTransaction.GetXmlData();

            SaleContractMachineTransaction.ActionName = "Create";
            SaleContractMachineTransaction.AjaxCallSaleContractMachineTransaction();
        });

        $("#AddSaleContractMachineRecord").click(function () {
            SaleContractMachineTransaction.GetXmlDataForNewMachine();

            SaleContractMachineTransaction.ActionName = "AddMachine";
            SaleContractMachineTransaction.AjaxCallSaleContractMachineTransaction();
        });

        $("#btnRemoveMachine").click(function () {
            if ($('#MachineAssignUptoDate').val() == "") {
                $("#displayErrorMessage").text("Please select Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            SaleContractMachineTransaction.ActionName = "Remove";
            SaleContractMachineTransaction.AjaxCallSaleContractMachineTransaction();
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
            url: '/SaleContractMachineTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractMachineTransaction: function () {
        var SaleContractMachineTransactionData = null;
        if (SaleContractMachineTransaction.ActionName == "Create") {
            //$("#FormCreateSaleContractMachineTransaction").validate();
            //if ($("#FormCreateSaleContractMachineTransaction").valid()) {
            SaleContractMachineTransactionData = null;
            SaleContractMachineTransactionData = SaleContractMachineTransaction.GetSaleContractMachineTransaction();
            ajaxRequest.makeRequest("/SaleContractMachineTransaction/Create", "POST", SaleContractMachineTransactionData, SaleContractMachineTransaction.Success);
            //}
        } else if (SaleContractMachineTransaction.ActionName == "Remove") {
            //$("#FormCreateSaleContractMachineTransaction").validate();
            //if ($("#FormCreateSaleContractMachineTransaction").valid()) {
            SaleContractMachineTransactionData = null;
            SaleContractMachineTransactionData = SaleContractMachineTransaction.GetSaleContractMachineTransaction();
            ajaxRequest.makeRequest("/SaleContractMachineTransaction/RemoveMachine", "POST", SaleContractMachineTransactionData, SaleContractMachineTransaction.Success);
            //}
        } else if (SaleContractMachineTransaction.ActionName == "AddMachine") {
            //$("#FormCreateSaleContractMachineTransaction").validate();
            //if ($("#FormCreateSaleContractMachineTransaction").valid()) {
            SaleContractMachineTransactionData = null;
            SaleContractMachineTransactionData = SaleContractMachineTransaction.GetSaleContractMachineTransaction();
            ajaxRequest.makeRequest("/SaleContractMachineTransaction/AddMachine", "POST", SaleContractMachineTransactionData, SaleContractMachineTransaction.Success);
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

            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><SaleContractMachineAttendanceID>" + DataArray[i + 1] + "</SaleContractMachineAttendanceID><TotalDays>" + DataArray[i + 2] + "</TotalDays><TotalAttendance>" + DataArray[i + 3] + "</TotalAttendance></row>";

            if (ParameterXml.length > 6)
                SaleContractMachineTransaction.XMLstring = ParameterXml + "</rows>";
            else
                SaleContractMachineTransaction.XMLstring = "";
        }
    },
    GetXmlDataForNewMachine: function () {

        var DataArray = [];
        var data = $('#tblModifyMachineMaster tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 5) {
            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><SaleContractMachineMasterID>" + DataArray[i + 1] + "</SaleContractMachineMasterID><SaleContractMachineMasterRequired>1</SaleContractMachineMasterRequired><Rate>" + DataArray[i + 3] + "</Rate><AssignFromDate>" + DataArray[i + 4] + "</AssignFromDate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMachineTransaction.XMLstringForMachine = ParameterXml + "</rows>";

        else
            SaleContractMachineTransaction.XMLstringForMachine = "";
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractMachineTransaction: function () {
        var Data = {
        };
        if (SaleContractMachineTransaction.ActionName == "Create") {
            Data.SaleContractBillingSpanID = $("#GetSaleContractBillingSpanID").val();
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.XMLstringForAttendance = SaleContractMachineTransaction.XMLstring;
        } else if (SaleContractMachineTransaction.ActionName == "Remove") {
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.SaleContractMachineAssignID = $("#SaleContractMachineAssignID").val();
            Data.MachineAssignUptoDate = $("#MachineAssignUptoDate").val();
        } else if (SaleContractMachineTransaction.ActionName == "AddMachine") {
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.XMLstringForAttendance = SaleContractMachineTransaction.XMLstringForMachine;
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

