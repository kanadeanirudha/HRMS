//this class contain methods related to nationality functionality
var SaleContractJobWorkData = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractJobWorkData.constructor();
        //SaleContractJobWorkData.initializeValidation();
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
            SaleContractJobWorkData.LoadList();
        });

        $("#SaveSaleContractJobWorkData").click(function () {

            SaleContractJobWorkData.GetXmlData();

            SaleContractJobWorkData.ActionName = "Create";
            SaleContractJobWorkData.AjaxCallSaleContractJobWorkData();
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
            url: '/SaleContractJobWorkData/List',
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
    //        url: '/SaleContractJobWorkData/List',
    //        success: function (data) {
    //            //Rebind Grid Data
    //            $('#ListViewModel').html(data);
    //            notify(message, colorCode);
    //        }
    //    });
    //},
    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractJobWorkData: function () {
        var SaleContractJobWorkDataData = null;
        if (SaleContractJobWorkData.ActionName == "Create") {
            //$("#FormCreateSaleContractJobWorkData").validate();
            //if ($("#FormCreateSaleContractJobWorkData").valid()) {
            SaleContractJobWorkDataData = null;
            SaleContractJobWorkDataData = SaleContractJobWorkData.GetSaleContractJobWorkData();
            ajaxRequest.makeRequest("/SaleContractJobWorkData/AddJobWorkData", "POST", SaleContractJobWorkDataData, SaleContractJobWorkData.Success);
            //}
        }
    },
    GetXmlData: function () {

        var DataArray = [];
        var data = $('#tblJobWorkDataData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });

        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 3) {
            {
                ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><SaleContractJobWorkItemID>" + DataArray[i + 1] + "</SaleContractJobWorkItemID><Quantity>" + DataArray[i + 2] + "</Quantity></row>";
            }

            if (ParameterXml.length > 6)
                SaleContractJobWorkData.XMLstring = ParameterXml + "</rows>";
            else
                SaleContractJobWorkData.XMLstring = "";
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractJobWorkData: function () {
        var Data = {
        };
        if (SaleContractJobWorkData.ActionName == "Create") {
            Data.SaleContractBillingSpanID = $("#GetSaleContractBillingSpanID").val();
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.XMLstringForJobWorkData = SaleContractJobWorkData.XMLstring;
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

