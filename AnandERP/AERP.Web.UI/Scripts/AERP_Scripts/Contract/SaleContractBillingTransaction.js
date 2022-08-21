//this class contain methods related to nationality functionality
var SaleContractBillingTransaction = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractBillingTransaction.constructor();
        //SaleContractBillingTransaction.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#CreateSaleContractBillingTransaction").click(function () {

            if ($("#GeneralLocationList").val() == "") {
                $("#displayErrorMessage").text("Please select Location.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }

            SaleContractBillingTransaction.ActionName = "Create";
            SaleContractBillingTransaction.GetXmlDataForBillingTransaction();
            SaleContractBillingTransaction.GetXmlDataForAccountVoucher();
            SaleContractBillingTransaction.AjaxCallSaleContractBillingTransaction();
        });

        $("#CancelSalesInvoiceRecord").click(function () {
            SaleContractBillingTransaction.ActionName = "Cancel";
            SaleContractBillingTransaction.GetXmlDataForCancelAccountVoucher();
            SaleContractBillingTransaction.AjaxCallSaleContractBillingTransaction();
        }); 

        InitAnimatedBorder();
        CloseAlert();
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",
            //data: {  },
            dataType: "html",
            url: '/SaleContractBillingTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },

    ReLoadList: function (message, colorCode, actionMode) {

        $.ajax({
            cache: false,
            type: "POST",
            data: { "actionMode": actionMode },
            dataType: "html",
            url: '/SaleContractBillingTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
                notify(message, colorCode);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractBillingTransaction: function () {
        var SaleContractBillingTransactionData = null;
        if (SaleContractBillingTransaction.ActionName == "Create") {
            //$("#FormCreateSaleContractBillingTransaction").validate();
            //if ($("#FormCreateSaleContractBillingTransaction").valid()) {
            SaleContractBillingTransactionData = null;
            SaleContractBillingTransactionData = SaleContractBillingTransaction.GetSaleContractBillingTransaction();
            ajaxRequest.makeRequest("/SaleContractBillingTransaction/CreateInvoice", "POST", SaleContractBillingTransactionData, SaleContractBillingTransaction.Success);
            //}
        } else if (SaleContractBillingTransaction.ActionName == "Cancel") {
            //$("#FormCreateSaleContractBillingTransaction").validate();
            //if ($("#FormCreateSaleContractBillingTransaction").valid()) {
            SaleContractBillingTransactionData = null;
            SaleContractBillingTransactionData = SaleContractBillingTransaction.GetSaleContractBillingTransaction();
            ajaxRequest.makeRequest("/SaleContractBillingTransaction/CancelInvoice", "POST", SaleContractBillingTransactionData, SaleContractBillingTransaction.Success);
            //}
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractBillingTransaction: function () {
        var Data = {
        };
        if (SaleContractBillingTransaction.ActionName == "Create") {
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.SaleContractBillingSpanID = $("#SaleContractBillingSpanID").val();
            Data.TotalBillAmount = $("#TotalBillAmount").val();
            Data.TaxableAmount = $("#TotalTaxableAmount").val();
            Data.TaxAmount = $("#TotalTaxAmount").val();
            Data.LocationID = $("#GeneralLocationList").val();
            Data.RoundOffAmount = parseFloat($("#TotalBillAmount").val()) - parseFloat($("#TotalBillAmount").prev('span').text())
            Data.XMLStringBillingTransaction = SaleContractBillingTransaction.XMLStringBillingTransaction;
            Data.XMLstringForVouchar = SaleContractBillingTransaction.XMLstringForVouchar;
        } else if (SaleContractBillingTransaction.ActionName == "Cancel") {
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.SaleContractBillingSpanID = $("#SaleContractBillingSpanID").val();
            Data.XMLstringForVouchar = SaleContractBillingTransaction.XMLstringForVouchar;
        }
        return Data;
    },
    GetXmlDataForBillingTransaction: function () {

        var DataArray = [];
        $('#tblData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 15) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><SaleContractRequirementDetailsID>" + DataArray[i] + "</SaleContractRequirementDetailsID><ItemNumber>" + DataArray[i + 1] + "</ItemNumber><ItemDescription>" + DataArray[i + 2].replace(/&/g, "[and]") + "</ItemDescription><Quantity>" + DataArray[i + 3] + "</Quantity><DisplayUOMCode>" + DataArray[i + 4] + "</DisplayUOMCode><UOMCode>" + DataArray[i + 5] + "</UOMCode><Rate>" + DataArray[i + 6] + "</Rate><GeneralTaxGroupMasterID>" + DataArray[i + 8] + "</GeneralTaxGroupMasterID><TaxAmount>" + DataArray[i + 9] + "</TaxAmount><TaxableAmount>" + DataArray[i + 10] + "</TaxableAmount><NetAmount>" + DataArray[i + 11] + "</NetAmount><DeliveryMemoID>" + DataArray[i + 12] + "</DeliveryMemoID><VariationMasterID>" + DataArray[i + 13] + "</VariationMasterID><VariationMasterName>" + DataArray[i + 14].replace(/&/g, "[and]") + "</VariationMasterName></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractBillingTransaction.XMLStringBillingTransaction = ParameterXml + "</rows>";
        else
            SaleContractBillingTransaction.XMLStringBillingTransaction = "";
    },
    GetXmlDataForAccountVoucher: function () {
        debugger;
        var CGST = 0; var SGST = 0; var IGST = 0;

        $('span.CGST').each(function () {
            CGST = parseFloat(parseFloat(CGST) + parseFloat($(this).text()));
        });
        $('span.SGST').each(function () {
            SGST = parseFloat(parseFloat(SGST) + parseFloat($(this).text()));
        });
        $('span.IGST').each(function () {
            IGST = parseFloat(parseFloat(IGST) + parseFloat($(this).text()));
        });

        // alert(DataArray)
        // alert(TotalRecord)
        var ParameterXml = "<rows>";
        var currentdate = new Date();
        var datetime =
                         currentdate.getUTCFullYear() + "-"
                        + (currentdate.getUTCMonth() + 1) + "-"
                        + currentdate.getUTCDate() + " "
                        + currentdate.getUTCHours() + ":"
                        + currentdate.getUTCMinutes() + ":"
                        + currentdate.getUTCSeconds() + "."
                        + currentdate.getUTCMilliseconds();
        //alert(datetime)


        ParameterXml = ParameterXml + "<row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCISales</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + $("#TotalTaxableAmount").val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCIDiscount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + 0 + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCIReceivable</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + $("#TotalBillAmount").val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCICGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + CGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCISGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + SGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCIIGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + IGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";


        // alert(ParameterXml)
        if (ParameterXml.length > 7) {
            SaleContractBillingTransaction.XMLstringForVouchar = ParameterXml + "</rows>";

        }
        else {
            SaleContractBillingTransaction.XMLstringForVouchar = "";
        }

    },
    GetXmlDataForCancelAccountVoucher: function () {
        debugger;
        var CGST = 0; var SGST = 0; var IGST = 0;

        $('.CGST').each(function () {
            CGST = parseFloat(parseFloat(CGST) + parseFloat($(this).val()));
        });
        $('.SGST').each(function () {
            SGST = parseFloat(parseFloat(SGST) + parseFloat($(this).val()));
        });
        $('.IGST').each(function () {
            IGST = parseFloat(parseFloat(IGST) + parseFloat($(this).val()));
        });

        // alert(DataArray)
        // alert(TotalRecord)
        var ParameterXml = "<rows>";
        var currentdate = new Date();
        var datetime =
                         currentdate.getUTCFullYear() + "-"
                        + (currentdate.getUTCMonth() + 1) + "-"
                        + currentdate.getUTCDate() + " "
                        + currentdate.getUTCHours() + ":"
                        + currentdate.getUTCMinutes() + ":"
                        + currentdate.getUTCSeconds() + "."
                        + currentdate.getUTCMilliseconds();
        //alert(datetime)


        ParameterXml = ParameterXml + "<row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCISales</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + $("#TotalTaxableAmount").val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCIDiscount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>" + 0 + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCIReceivable</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + $("#TotalBillAmount").val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCICGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + CGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCISGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + SGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#ContractNumber").val() + "-" + $("#SaleContractBillingSpanID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCIIGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + IGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";


        // alert(ParameterXml)
        if (ParameterXml.length > 7) {
            SaleContractBillingTransaction.XMLstringForVouchar = ParameterXml + "</rows>";

        }
        else {
            SaleContractBillingTransaction.XMLstringForVouchar = "";
        }

    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        $.magnificPopup.close();
        if (splitData[1] == 'success') {
            SaleContractBillingTransaction.ReLoadList(splitData[0], splitData[1], splitData[2])
        }
        else {
            notify(splitData[0], splitData[1]);
        }

    },
};

