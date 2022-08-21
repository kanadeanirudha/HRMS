//this class contain methods related to nationality functionality
var SalesQuotationMasterAndDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SalesQuotationMasterAndDetails.constructor();
        //SalesQuotationMasterAndDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });



        // Create new record
        //Create Quotation with Enquiry raised by customer

        $('#CreateQuotationByEnquiry').unbind("click").on("click", function () {

            SalesQuotationMasterAndDetails.ActionName = "CreateQuotationByEnquiry";

            SalesQuotationMasterAndDetails.GetXmlData();
           if (SalesQuotationMasterAndDetails.ParameterXml == "" || SalesQuotationMasterAndDetails.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                SalesQuotationMasterAndDetails.AjaxCallSalesQuotationMasterAndDetails();
            }

        });
        $('#CreateSalesOrderByEnquiry').unbind("click").on("click", function () {

            SalesQuotationMasterAndDetails.ActionName = "CreateSalesOrderByEnquiry";
            SalesQuotationMasterAndDetails.GetXmlData();
            if (SalesQuotationMasterAndDetails.ParameterXml == "" || SalesQuotationMasterAndDetails.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                SalesQuotationMasterAndDetails.AjaxCallSalesQuotationMasterAndDetails();
            }
        });




        //Create Quotation without Enquiry
        $('#CreateQuotationWithoutEnquiry').unbind("click").on("click", function () {

            SalesQuotationMasterAndDetails.ActionName = "CreateQuotationWithoutEnquiry";
            SalesQuotationMasterAndDetails.GetXmlData();
            if ($('#GeneralUnitsID').val() == "" || $('#GeneralUnitsID').val() == null || $('#GeneralUnitsID').val() == 0) {
                $("#displayErrorMessage p").text("Please Select Store.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
             else if ($('#CustomerName').val() == "" || $('#CustomerName').val() == null) {
                $("#displayErrorMessage p").text("Please Select Customer Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#ContactPersonName').val() == "" || $('#ContactPersonName').val() == null) {
                $("#displayErrorMessage p").text("Please Select Customer Contact Person.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if (SalesQuotationMasterAndDetails.ParameterXml == "" || SalesQuotationMasterAndDetails.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                SalesQuotationMasterAndDetails.AjaxCallSalesQuotationMasterAndDetails();
            }

        });
        $('#CreateSalesOrderWithoutQuotation').unbind("click").on("click", function () {

            SalesQuotationMasterAndDetails.ActionName = "CreateSalesOrderWithoutQuotation";
            SalesQuotationMasterAndDetails.GetXmlData();
            if ($('#GeneralUnitsID').val() == "" || $('#GeneralUnitsID').val() == null || $('#GeneralUnitsID').val() == 0) {
                $("#displayErrorMessage p").text("Please Select Store.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#CustomerName').val() == "" || $('#CustomerName').val() == null) {
                $("#displayErrorMessage p").text("Please Select Customer Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#ContactPersonName').val() == "" || $('#ContactPersonName').val() == null) {
                $("#displayErrorMessage p").text("Please Select Customer Contact Person.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if (SalesQuotationMasterAndDetails.ParameterXml == "" || SalesQuotationMasterAndDetails.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                SalesQuotationMasterAndDetails.AjaxCallSalesQuotationMasterAndDetails();
            }
        });

        //Edit Quotation and Sales Order with enquiry or without Enquiry
        $('#EditQuotationDetails').unbind("click").on("click", function () {

            SalesQuotationMasterAndDetails.ActionName = "EditQuotationDetails";
            SalesQuotationMasterAndDetails.GetXmlData();
            if (SalesQuotationMasterAndDetails.ParameterXml == "" || SalesQuotationMasterAndDetails.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                SalesQuotationMasterAndDetails.AjaxCallSalesQuotationMasterAndDetails();
            }

        });
        $('#EditSalesOrderDetails').on("click", function () {

            SalesQuotationMasterAndDetails.ActionName = "EditSalesOrderDetails";
            SalesQuotationMasterAndDetails.GetXmlData();
            if (SalesQuotationMasterAndDetails.ParameterXml == "" || SalesQuotationMasterAndDetails.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                SalesQuotationMasterAndDetails.AjaxCallSalesQuotationMasterAndDetails();
            }
        });


        $('#Quantity').on("keydown keypress", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        //Used in Sale TAB For Store Wise Sale Uom code.
        $("#btnShowList").on("click", function () {
            debugger;
            var GeneralUnitsID = $('#GeneralUnitsID :selected').val();
            var SalesEnquiryMasterID = $('#SalesEnquiryMasterID').val();
            if (GeneralUnitsID != "" && SalesEnquiryMasterID != "") {
                SalesQuotationMasterAndDetails.LoadData(GeneralUnitsID, SalesEnquiryMasterID);
                $('#CreateQuotationByEnquiry').prop('disabled', false);
                $('#CreateSalesOrderByEnquiry').prop('disabled', false);
            }
            else if (GeneralUnitsID == "") {
                notify("Please select Store.", 'warning');
            }

        });
        $('#btnAdd').on("click", function () {
            debugger;
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                if ($(this).val() != "on") {
                    DataArray.push($(this).val());
                }
            });

            //to check duplication of item while adding the item(Restrict Duplication of Item)
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });

            TotalRecord = DataArray.length;

            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 11) {
                if (DataArray[i + 0] == $('#ItemNumber').val() && DataArray[i + 3] == $('#UOM').val()) {
                    $("#displayErrorMessage ").text("You Cannot Enter the same item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");

                    $("#ItemDescription").val("");
                    $('#ItemDescription').typeahead('val', '');
                    $("#ItemNumber").val(0);
                    $("#Quantity").val(0);
                    $("#UOM").val("");
                    $("#Rate").val(0);
                    $("#ItemDescription").focus();
                    return false
                }
            }


            //End Of Code for Duplication of Item
            TotalRecord = DataArray.length;
            var i = 0;

            if ($("#ItemDescription").val() == null || $("#ItemDescription").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Item Description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#Quantity").val() == 0 || $("#Quantity").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#UOM").val() == null || $("#UOM").val() == "") {
                $("#displayErrorMessage ").text("Please Select UoM Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }

            var TaxAbleamount = parseFloat($("#Rate").val() * $("#Quantity").val()).toFixed(2);
            var TaxAmount = parseFloat((TaxAbleamount * $("#TaxRate").val()) / 100).toFixed(2);
            var NetAmount = parseFloat(parseFloat(TaxAbleamount) + parseFloat(TaxAmount)).toFixed(2)

            if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null) {
                //Code For IsBase Uom Check box Ends

                $("#tblData tbody").append(
                                      "<tr>" +
                                      "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                                      "<td><input id='ItemDescription' type='text' value=" + $('#ItemDescription').val() + " style='display:none' />" + $('#ItemDescription').val() + "</td>" +
                                      "<td><input id='Quantity' type='text' value=" + $('#Quantity').val() + " style='display:none' />" + $('#Quantity').val() + "</td>" +
                                      "<td ><input type='text' value=" + $('#UOM').val() + " style='display:none' /> " + $('#UOM').val() + "</td>" +
                                      "<td ><input type='text' value=" + $('#Rate').val() + " style='display:none' /> " + parseFloat($('#Rate').val(), 3) + "</td>" +
                                      "<td ><input type='text' value=" + TaxAmount + " style='display:none'  id='TaxAmount'/> " + TaxAmount + "</td>" +
                                      "<td ><input type='text' value=" + TaxAbleamount + " style='display:none'  id='TaxAbleAmount'/> " + TaxAbleamount + "</td>" +
                                      "<td ><input type='text' value=" + NetAmount + " style='display:none'  id='NetAmount'/> " + NetAmount + "</td>" +
                                      "<td style=display:none><input id='SalesQuotationDetailID' type='hidden'  value=0  style='display:none' />" + $('#SalesQuotationDetailID').val() + "</td>" +
                                      "<td style=display:none><input id='GeneralTaxGroupMasterID' type='hidden'  value=" + $('#GeneralTaxGroupMasterID').val() + "  style='display:none' />" + $('#GeneralTaxGroupMasterID').val() + "</td>" +
                                      "<td> <i class='zmdi zmdi-delete zmdi-hc-fw ENQDetail' style='cursor:pointer'' title = Delete ><input id='TaxRate' type='hidden'  value=" + $('#TaxRate').val() + "  style='display:none' /></td>" +
                                      "</tr>"
                                     );

                $("#ItemDescription").val("");
                $("#ItemNumber").val(0);
                $("#Quantity").val(0);
                $("#UOM").val("");
                $("#Rate").val(0);

                SalesQuotationMasterAndDetails.TotalBillAmount();
                SalesQuotationMasterAndDetails.TotalTaxAmount();
                SalesQuotationMasterAndDetails.TotalAmount();

            }

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i.ENQDetail", function () {
                $(this).closest('tr').remove();
                SalesQuotationMasterAndDetails.TotalBillAmount();
                SalesQuotationMasterAndDetails.TotalTaxAmount();
                SalesQuotationMasterAndDetails.TotalAmount();
            });

        });

        $("#Units").children().children("#UOM").change(function () {
            debugger;
            var selectedItem = $(this).val();
            var ItemNumber = $("#ItemNumber").val();
            var GeneralUnitsID = $("#GeneralUnitsID").val();
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { "ItemNumber": ItemNumber, "UOM": selectedItem, "GeneralUnitsID": GeneralUnitsID },
                url: '/SalesQuotationMasterAndDetails/GetSalePriceByUOMCode',
                success: function (data) {
                    $("#Rate").val(data[0].Rate)
                }
            });
        });

        $("#UnitsForQuotation").children().children("#UOM").change(function () {
            debugger;
            var selectedItem = $(this).val();
            var ItemNumber = $("#ItemNumber").val();
            var GeneralUnitsID = $("#GeneralUnitsID").val();

            if (GeneralUnitsID != "" && ItemNumber != "") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: { "ItemNumber": ItemNumber, "UOM": selectedItem, "GeneralUnitsID": GeneralUnitsID },
                    url: '/SalesQuotationMasterAndDetails/GetSalePriceByUOMCode',
                    success: function (data) {
                        $("#Rate").val(data[0].Rate)
                    }
                });
            }
            else if (ItemNumber == "") {
                notify("Please select Item Description.", 'warning');

            }
            else if (GeneralUnitsID == "" || GeneralUnitsID == 0) {
                notify("Please select Store.", 'warning');
            }

           
        });


        InitAnimatedBorder();

        CloseAlert();




    },
    //LoadData method is used to load List of all Uom code where Order unit=1
    LoadData: function (GeneralUnitsID, SalesEnquiryMasterID) {
        debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             data: { GeneralUnitsID: GeneralUnitsID, SalesEnquiryMasterID: SalesEnquiryMasterID },
             url: '/SalesQuotationMasterAndDetails/CreateSalesQuotationByEnquiry',
             success: function (data) {

                 $('#ListViewModel1').html(data);

             }
         });
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/SalesQuotationMasterAndDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    TotalAmount: function () {
        debugger;
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(6).find('input[id^=TaxAbleAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalAmount").val(a.toFixed(2));
        $("#TotalAmount").text(a.toFixed(2));

    },
    TotalTaxAmount: function () {
        debugger;
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalTaxAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=TaxAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalTaxAmount").val(a.toFixed(2));
        $("#TotalTaxAmount").text(a.toFixed(2));

    },
    TotalBillAmount: function () {
        debugger;
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalBillAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=NetAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalBillAmount").val(a.toFixed(2));
        $("#TotalBillAmount").text(a.toFixed(2));

    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/SalesQuotationMasterAndDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    GetXmlData: function () {

        var DataArray = [];
        debugger;
        $('#tblData tbody tr td input').each(function () {
            if ($(this).val() != "on") {
                if ($(this).attr('type') == 'checkbox') {
                    DataArray.push($(this).is(":checked") ? 1 : 0);
                }
                else {
                    DataArray.push($(this).val());
                }
            }
        });
        var TotalRecord = DataArray.length;
        debugger;
        //alert(DataArray);
        //alert(TotalRecord);
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 11) {
            ParameterXml = ParameterXml + "<row><QuotationDetailID>" + DataArray[i + 8] + "</QuotationDetailID><ItemNumber>" + DataArray[i + 0] + "</ItemNumber><Quantity>" + DataArray[i + 2] + "</Quantity><Rate>" + DataArray[i + 4] + "</Rate><UOM>" + DataArray[i + 3] + "</UOM><GeneralTaxGroupMasterID>" + DataArray[i + 9] + "</GeneralTaxGroupMasterID><TaxAmount>" + DataArray[i + 5] + "</TaxAmount><TaxableAmount>" + DataArray[i + 6] + "</TaxableAmount><NetAmount>" + DataArray[i + 7] + "</NetAmount></row>";
        }
        if (ParameterXml.length > 10)
            SalesQuotationMasterAndDetails.ParameterXml = ParameterXml + "</rows>";

        else
            SalesQuotationMasterAndDetails.ParameterXml = "";
        //alert(SalesQuotationMasterAndDetails.ParameterXml)
    },

    //Fire ajax call to insert update and delete record

    AjaxCallSalesQuotationMasterAndDetails: function () {
        var SalesQuotationMasterAndDetailsData = null;

        if (SalesQuotationMasterAndDetails.ActionName == "CreateQuotationByEnquiry") {

            $("#FormCreateSalesQuotationwithEnquiry").validate();
            if ($("#FormCreateSalesQuotationwithEnquiry").valid()) {
                SalesQuotationMasterAndDetailsData = null;
                SalesQuotationMasterAndDetailsData = SalesQuotationMasterAndDetails.GetSalesQuotationMasterAndDetails();
                ajaxRequest.makeRequest("/SalesQuotationMasterAndDetails/CreateQuotation", "POST", SalesQuotationMasterAndDetailsData, SalesQuotationMasterAndDetails.Success, "CreateSalesQuotationMasterAndDetailsRecord");
            }
        }
        else if (SalesQuotationMasterAndDetails.ActionName == "CreateSalesOrderByEnquiry") {
            $("#FormCreateSalesQuotationwithEnquiry").validate();
            if ($("#FormCreateSalesQuotationwithEnquiry").valid()) {
                SalesQuotationMasterAndDetailsData = null;
                SalesQuotationMasterAndDetailsData = SalesQuotationMasterAndDetails.GetSalesQuotationMasterAndDetails();
                ajaxRequest.makeRequest("/SalesQuotationMasterAndDetails/CreateQuotation", "POST", SalesQuotationMasterAndDetailsData, SalesQuotationMasterAndDetails.Success);
            }
        }

            //Without Enquiry
        else if (SalesQuotationMasterAndDetails.ActionName == "CreateQuotationWithoutEnquiry") {
            $("#FormCreateSalesQuotationwithoutEnquiry").validate();
            if ($("#FormCreateSalesQuotationwithoutEnquiry").valid()) {
                SalesQuotationMasterAndDetailsData = null;
                SalesQuotationMasterAndDetailsData = SalesQuotationMasterAndDetails.GetSalesQuotationMasterAndDetails();
                ajaxRequest.makeRequest("/SalesQuotationMasterAndDetails/CreateQuotation", "POST", SalesQuotationMasterAndDetailsData, SalesQuotationMasterAndDetails.Success);
            }
        }
        else if (SalesQuotationMasterAndDetails.ActionName == "CreateSalesOrderWithoutQuotation") {
            $("#FormCreateSalesQuotationwithoutEnquiry").validate();
            if ($("#FormCreateSalesQuotationwithoutEnquiry").valid()) {
                SalesQuotationMasterAndDetailsData = null;
                SalesQuotationMasterAndDetailsData = SalesQuotationMasterAndDetails.GetSalesQuotationMasterAndDetails();
                ajaxRequest.makeRequest("/SalesQuotationMasterAndDetails/CreateQuotation", "POST", SalesQuotationMasterAndDetailsData, SalesQuotationMasterAndDetails.Success);
            }
        }
            //Edit Enquiry
        else if (SalesQuotationMasterAndDetails.ActionName == "EditQuotationDetails") {//Edit Quotation
            $("#FormEditSalesQuotation").validate();
            if ($("#FormEditSalesQuotation").valid()) {
                SalesQuotationMasterAndDetailsData = null;
                SalesQuotationMasterAndDetailsData = SalesQuotationMasterAndDetails.GetSalesQuotationMasterAndDetails();
                ajaxRequest.makeRequest("/SalesQuotationMasterAndDetails/CreateQuotation", "POST", SalesQuotationMasterAndDetailsData, SalesQuotationMasterAndDetails.Success);
            }
        }
        else if (SalesQuotationMasterAndDetails.ActionName == "EditSalesOrderDetails") {//Edit Sales order
            $("#FormEditSalesQuotation").validate();
            if ($("#FormEditSalesQuotation").valid()) {
                SalesQuotationMasterAndDetailsData = null;
                SalesQuotationMasterAndDetailsData = SalesQuotationMasterAndDetails.GetSalesQuotationMasterAndDetails();
                ajaxRequest.makeRequest("/SalesQuotationMasterAndDetails/CreateQuotation", "POST", SalesQuotationMasterAndDetailsData, SalesQuotationMasterAndDetails.Success);
            }
        }




       
    },
    //Get properties data from the Create, Update and Delete page
    GetSalesQuotationMasterAndDetails: function () {
        var Data = {
        };

        if (SalesQuotationMasterAndDetails.ActionName == "CreateQuotationByEnquiry" || SalesQuotationMasterAndDetails.ActionName == "CreateQuotationWithoutEnquiry" || SalesQuotationMasterAndDetails.ActionName == "EditQuotationDetails") {
            debugger;
            Data.CustomerMasterID = $('#CustomerMasterID').val();
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            Data.ContactPersonID = $('#ContactPersonID').val();
            Data.CreditPeriod           = $('#CreditPeriod').val();
            Data.UnitMasterId           = $('#UnitMasterId').val();
            Data.TitleTo                = $('#TitleTo').val();
            Data.TotalAmount            = $('#TotalAmount').val();
            Data.SalesEnquiryMasterID   = $('#SalesEnquiryMasterID').val();
            Data.TotalBillAmount        = $('#TotalBillAmount').val();
            Data.RoundOffAmount         = $('#RoundOffAmount').val();
            Data.GeneralUnitsID         = $('#GeneralUnitsID').val();
            Data.SalesQuotationMasterID = $('#SalesQuotationMasterID').val();
            Data.XmlString              = SalesQuotationMasterAndDetails.ParameterXml
            //Additional
            Data.Flag                   = 'Quotation Master';
            Data.PurchaseOrderNumberClient = '101';
            Data.TotalTaxAmount         = $('#TotalTaxAmount').val();
            Data.Freight                = $('#Freight').val();
            Data.ShippingHandling       = $('#ShippingHandling').val();
            Data.Discount               = $('#Discount').val();
            Data.TradeIn                = $('#TradeIn').val();

        }
        else if (SalesQuotationMasterAndDetails.ActionName == "EditSalesOrderDetails" || SalesQuotationMasterAndDetails.ActionName == "CreateSalesOrderByEnquiry" || SalesQuotationMasterAndDetails.ActionName == "CreateSalesOrderWithoutQuotation") {
            debugger;
            Data.CustomerMasterID = $('#CustomerMasterID').val();
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            Data.ContactPersonID = $('#ContactPersonID').val();


            Data.CreditPeriod = $('#CreditPeriod').val();
            Data.UnitMasterId = $('#UnitMasterId').val();
            Data.TitleTo = $('#TitleTo').val();
            Data.TotalAmount = $('#TotalAmount').val();
            Data.SalesEnquiryMasterID = $('#SalesEnquiryMasterID').val();
            Data.TotalBillAmount = $('#TotalBillAmount').val();
            Data.RoundOffAmount = $('#RoundOffAmount').val();
            Data.GeneralUnitsID = $('#GeneralUnitsID').val();
            Data.SalesQuotationMasterID = $('#SalesQuotationMasterID').val();
            Data.XmlString = SalesQuotationMasterAndDetails.ParameterXml
            //Additional
            Data.Flag = 'Sales order';
            Data.PurchaseOrderNumberClient = '101';
            Data.TotalTaxAmount = $('#TotalTaxAmount').val();
            Data.Freight = $('#Freight').val();
            Data.ShippingHandling = $('#ShippingHandling').val();
            Data.Discount = $('#Discount').val();
            Data.TradeIn = $('#TradeIn').val();

        }
        else if (SalesQuotationMasterAndDetails.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            SalesQuotationMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};