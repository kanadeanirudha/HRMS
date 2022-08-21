//this class contain methods related to nationality functionality
var SalesInvoiceMasterAndDetails = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SalesInvoiceMasterAndDetails.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#contactPerson").hide();
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        $('#PurchaseOrderDate').datetimepicker({
            format: 'DD MMMM YYYY'
        });

        $("#PurchaseOrderDate").on("keydown", function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode != 9) {
                return false;
            }
        })

        $("#InvoiceDeductionAmount").keyup(function () {
            SalesInvoiceMasterAndDetails.TotalAmountForDirectInvoice();
            SalesInvoiceMasterAndDetails.TotalBillAmountForDirectInvoice();
        })

        $("#btnShowList").unbind("click").on("click", function () {
            SalesInvoiceMasterAndDetails.LoadListByPurchaseOrderType($('#PurchaseOrderType :selected').val());
        });

        $('#showSaleInvoice').unbind('click').on("click", function () {
            SalesInvoiceMasterAndDetails.LoadList();
        });

        $('#showServiceInvoice').unbind('click').on("click", function () {
            SalesInvoiceMasterAndDetails.LoadServiceItemList('');
        });
        $("#Units").children().children("#SaleUomCode").change(function () {

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
                        if (data.length > 0) {
                            $("#Rate").val(data[0].Rate)
                        }
                        else {
                            $("#Rate").val(0);
                        }
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

        $('#btnAddCreateInvoice').on("click", function () {

            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                if ($(this).val() != "on") {
                    DataArray.push($(this).val());
                }
            });
            TotalRecord = DataArray.length;

            //to check duplication of item while adding the item(Restrict Duplication of Item)
            var i = 0;
            //for (var i = 0; i < TotalRecord; i = i + 5) {
            //    if (DataArray[i + 0] == $('#ItemNumber').val() && DataArray[i + 3] == $('#UOM').val()) {
            //        $("#displayErrorMessage ").text("You Cannot Enter the same item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");

            //        $("#ItemDescription").val("");
            //        $('#ItemDescription').typeahead('val', '');
            //        $("#ItemNumber").val(0);
            //        $("#Quantity").val(0);
            //        $("#UOM").val("");
            //        $("#ItemDescription").focus();
            //        return false
            //    }
            //}


            //End Of Code for Duplication of Item

            var i = 0;

            if ($("#ItemDescription").val() == null || $("#ItemDescription").val() == "" || $("#ItemNumber").val() == 0) {
                $("#displayErrorMessage ").text("Please Enter Item Description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#InvoiceQuantity").val() == 0 || $("#InvoiceQuantity").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#SaleUomCode").val() == null || $("#SaleUomCode").val() == "") {
                $("#displayErrorMessage ").text("Please Select UoM Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            var TaxAbleamount = parseFloat($("#Rate").val() * $("#InvoiceQuantity").val()).toFixed(2);
            var TaxAmount = 0;

            if ($("#IsTaxExempted").val() == "false") {
                TaxAmount = parseFloat((TaxAbleamount * $("#TaxRate").val()) / 100).toFixed(2);
            }
            var NetAmount = parseFloat(parseFloat(TaxAbleamount) + parseFloat(TaxAmount)).toFixed(2)

            if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null) {
                //Code For IsBase Uom Check box Ends


                var TaxList = $("#TaxList").val().replace(", ", ",").split(',');
                var TaxRateList = $("#TaxRateList").val().replace(', ', ',').split(',')
                var string =

                "<tr>" +
                            "<td style=display:none><input id='ItemNumber' type='hidden'  value='" + $('#ItemNumber').val() + "'  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                            "<td><input id='ItemDescription' type='text' value='" + $('#ItemDescription').val().replace(/ /g, "~") + "' style='display:none' />" + $('#ItemDescription').val() + "</td>" +
                             "<td>" + $('#BillingDispalyName').val() + "</td>" +
                            "<td ><input type='text' value='" + $('#SaleUomCode').val() + "' style='display:none' /> " + $('#SaleUomCode').val() + "</td>" +
                            "<td >" + $('#DisplayUOMCode').val() + "</td>" +
                            "<td><input id='InvoiceQuantity' type='text' value='" + $('#InvoiceQuantity').val() + "' style='display:none' />" + $('#InvoiceQuantity').val() + "</td>" +
                            "<td><input id='Rate' type='text' value='" + $('#Rate').val() + "' style='display:none' />" + $('#Rate').val() + "</td>" +
                            "<td>" + $('#DisplayRate').val() + "</td>" +
                            "<td ><input type='text' id='BatchNumber' value='" + $('#BatchNumber').val() + "' style='display:none' /> " + $('#BatchNumber').val() + "</td>" +
                            "<td ><input type='text' id='ExpiryDate' value='" + $('#ExpiryDate').val() + "' style='display:none' /> " + $('#ExpiryDate').val() + "</td>" +
                            "<td ><input type='text' value='" + TaxAbleamount + "' style='display:none'  id='TaxAbleAmount'/> " + TaxAbleamount + "</td>" +
                            "<td ><input type='text' value='" + TaxAmount + "' style='display:none'  id='TaxAmount'/> " + TaxAmount + "</td>" +
                            "<td ><input type='text' value='" + NetAmount + "' style='display:none'  id='NetAmount'/> " + NetAmount + "</td>" +
                            "<td> <i class='zmdi zmdi-delete zmdi-hc-fw ENQDetail' style='cursor:pointer'' title = Delete ><input id='GenTaxGroupMasterID' type='hidden'  value='" + $('#GenTaxGroupMasterID').val() + "'  style='display:none' /><input id='BillingDispalyName' type='hidden'  value='" + $('#BillingDispalyName').val().replace(/ /g, "~") + "'  style='display:none' /><input id='DisplayUOMCode' type='hidden'  value='" + $('#DisplayUOMCode').val() + "' style='display:none' /><input id='DisplayRate' type='hidden'  value='" + $('#DisplayRate').val() + "' style='display:none' /></td>" +
                            "<td style=display:none>";

                for (i = 0; i < TaxRateList.length; i++) {

                    var TaxName = TaxList[i].split(' ');

                    var IndTaxamount = 0;
                    if ($("#IsTaxExempted").val() == "false") {
                        IndTaxamount = ($('#InvoiceQuantity').val() * $('#Rate').val() * TaxRateList[i]) / 100;
                    }

                    string += "<span class='" + TaxName[0] + "'>" + IndTaxamount + "</span>";
                }
                string += "</td>" + "</tr>";

                $("#tblData tbody").append(string);

                $("#ItemDescription").val("");
                $('#ItemDescription').typeahead('val', '');
                $("#ItemNumber").val(0);
                $("#InvoiceQuantity").val(0);
                $("#BatchNumber").val("");
                $("#ExpiryDate").val("");
                $("#SaleUomCode").html('');
                $('#BatchNumber').typeahead('val', '');
                $('#Rate').val(0);
                $("#BillingDispalyName").val("");
                $("#DisplayUOMCode").val("");
                $("#DisplayRate").val(0);
                SalesInvoiceMasterAndDetails.TotalBillAmountForDirectInvoice();
                SalesInvoiceMasterAndDetails.TotalTaxAmountForDirectInvoice();
                SalesInvoiceMasterAndDetails.TotalAmountForDirectInvoice()

            }

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i.ENQDetail", function () {
                $(this).closest('tr').remove();
                SalesInvoiceMasterAndDetails.TotalBillAmountForDirectInvoice();
                SalesInvoiceMasterAndDetails.TotalTaxAmountForDirectInvoice();
                SalesInvoiceMasterAndDetails.TotalAmountForDirectInvoice()
            });

        });

        $('#btnAddCreateInvoiceService').on("click", function () {

            var DataArray = [];
            var data = $('#myDataTableCreate tbody tr td input').each(function () {
                if ($(this).val() != "on") {
                    DataArray.push($(this).val());
                }
            });
            TotalRecord = DataArray.length;

            //to check duplication of item while adding the item(Restrict Duplication of Item)
            var i = 0;
            //for (var i = 0; i < TotalRecord; i = i + 5) {
            //    if (DataArray[i + 0] == $('#ItemNumber').val() && DataArray[i + 3] == $('#UOM').val()) {
            //        $("#displayErrorMessage ").text("You Cannot Enter the same item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");

            //        $("#ItemDescription").val("");
            //        $('#ItemDescription').typeahead('val', '');
            //        $("#ItemNumber").val(0);
            //        $("#Quantity").val(0);
            //        $("#UOM").val("");
            //        $("#ItemDescription").focus();
            //        return false
            //    }
            //}


            //End Of Code for Duplication of Item

            var i = 0;

            if ($("#ItemDescription").val() == null || $("#ItemDescription").val() == "" || $("#ItemNumber").val() == 0) {
                $("#displayErrorMessage ").text("Please Enter Item Description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#InvoiceQuantity").val() == 0 || $("#InvoiceQuantity").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#SaleUomCode").val() == null || $("#SaleUomCode").val() == "") {
                $("#displayErrorMessage ").text("Please Select UoM Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            var TaxAbleamount = parseFloat($("#Rate").val() * $("#InvoiceQuantity").val()).toFixed(2);
            var TaxAmount = 0;

            if ($("#IsTaxExempted").val() == "false") {
                TaxAmount = parseFloat((TaxAbleamount * $("#TaxRate").val()) / 100).toFixed(2);
            }
            var NetAmount = parseFloat(parseFloat(TaxAbleamount) + parseFloat(TaxAmount)).toFixed(2)

            if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null) {
                //Code For IsBase Uom Check box Ends


                var TaxList = $("#TaxList").val().replace(", ", ",").split(',');
                var TaxRateList = $("#TaxRateList").val().replace(', ', ',').split(',')
                var string =

                "<tr>" +
                            "<td style=display:none><input id='ItemNumber' type='hidden' class='ItemNumber'  value='" + $('#ItemNumber').val() + "'  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                            "<td><input id='ItemDescription' type='text' value='" + $('#ItemDescription').val().replace(/ /g, "~") + "' style='display:none' />" + $('#ItemDescription').val() + "</td>" +
                             "<td>" + $('#BillingDispalyName').val() + "</td>" +
                             "<td><input id='InvoiceQuantity' type='text' value='" + $('#InvoiceQuantity').val() + "' style='display:none' />" + $('#InvoiceQuantity').val() + "</td>" +
                            "<td ><input type='text' value='" + $('#SaleUomCode').val() + "' style='display:none' /> " + $('#SaleUomCode').val() + "</td>" +
                            "<td >" + $('#DisplayUOMCode').val() + "</td>" +
                            "<td>" + $('#InvoiceQuantity').val() + "</td>" +
                            "<td><input id='Rate' type='text' value='" + $('#Rate').val() + "' style='display:none' />" + $('#Rate').val() + "</td>" +
                            "<td>" + $('#DisplayRate').val() + "</td>" +
                            "<td ></td>" +
                            "<td ><input type='text' value='" + $("#TaxRate").val() + "' style='display:none'  id='TaxRate'/> " + $("#TaxRate").val() + "</td>" +
                            "<td ><input type='text' value='" + TaxAbleamount + "' style='display:none'  id='TaxAbleAmount'/> " + TaxAbleamount + "</td>" +

                            "<td style='display:none;'><input type='text' value='" + TaxAmount + "' style='display:none'  id='TaxAmount'/> " + TaxAmount + "</td>" +
                            "<td> <i class='zmdi zmdi-delete zmdi-hc-fw ENQDetail' style='cursor:pointer'' title = Delete ></i><input id='GenTaxGroupMasterID' type='hidden'  value='" + $('#GenTaxGroupMasterID').val() + "'  style='display:none' /><input id='BillingDispalyName' type='hidden'  value='" + $('#BillingDispalyName').val().replace(/ /g, "~") + "'  style='display:none' /><input id='DisplayUOMCode' type='hidden'  value='" + $('#DisplayUOMCode').val() + "' style='display:none' /><input id='DisplayRate' type='hidden'  value='" + $('#DisplayRate').val() + "' style='display:none' /></td>" +
                            "<td style=display:none>";

                for (i = 0; i < TaxRateList.length; i++) {

                    var TaxName = TaxList[i].split(' ');

                    var IndTaxamount = 0;
                    if ($("#IsTaxExempted").val() == "false") {
                        IndTaxamount = ($('#InvoiceQuantity').val() * $('#Rate').val() * TaxRateList[i]) / 100;
                    }

                    string += "<input type='hidden' class='" + TaxName[0] + "' value='" + IndTaxamount + "' />";
                }
                string += "</td>" + "</tr>";

                $("#myDataTableCreate tbody").append(string);

                $("#ItemDescription").val("");
                $('#ItemDescription').typeahead('val', '');
                $("#ItemNumber").val(0);
                $("#InvoiceQuantity").val(0);
                $("#BatchNumber").val("");
                $("#ExpiryDate").val("");
                $("#SaleUomCode").html('');
                $('#BatchNumber').typeahead('val', '');
                $('#Rate').val(0);
                $("#BillingDispalyName").val("");
                $("#DisplayUOMCode").val("");
                $("#DisplayRate").val(0);
                SalesInvoiceMasterAndDetails.TotalTaxAmountForInvoiceService();
                SalesInvoiceMasterAndDetails.TotalAmountForInvoiceService()

            }

            //Delete record in table
            $("#myDataTableCreate tbody").on("click", "tr td i.ENQDetail", function () {
                $(this).closest('tr').remove();
                SalesInvoiceMasterAndDetails.TotalTaxAmountForInvoiceService();
                SalesInvoiceMasterAndDetails.TotalAmountForInvoiceService()
            });

        });
        // Create new record
        $('#CreateSalesInvoiceMasterAndDetailsRecord').on("click", function () {
            SalesInvoiceMasterAndDetails.ActionName = "Create";
            SalesInvoiceMasterAndDetails.GetXmlDataForDMNumber();
            SalesInvoiceMasterAndDetails.GetXmlDataFoInvoiceService();
            SalesInvoiceMasterAndDetails.GetXmlDataForAccountVoucher();
            SalesInvoiceMasterAndDetails.AjaxCallSalesInvoiceMasterAndDetails();
        });

        $('#CreateDirectSalesInvoiceRecord').on("click", function () {
            SalesInvoiceMasterAndDetails.ActionName = "CreateSalesInvoice";
            SalesInvoiceMasterAndDetails.GetXmlDataFoDirectInvoice();
            SalesInvoiceMasterAndDetails.GetXmlSalesInvoiceDataForAccountVoucher();
            SalesInvoiceMasterAndDetails.AjaxCallSalesInvoiceMasterAndDetails();
        });

        $('#CancelSalesInvoiceRecord').on("click", function () {
            SalesInvoiceMasterAndDetails.ActionName = "CancelSalesInvoice";
            SalesInvoiceMasterAndDetails.GetXmlCancelDataForAccountVoucher();
            SalesInvoiceMasterAndDetails.AjaxCallSalesInvoiceMasterAndDetails();
        });

        InitAnimatedBorder();

        CloseAlert();
    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/SalesInvoiceMasterAndDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //LoadList method is used to load List page
    LoadServiceItemList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/SalesInvoiceMasterAndDetails/ServiceInvoiceList',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        var PurchaseOrderType = $('#PurchaseOrderType :selected').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, PurchaseOrderType: PurchaseOrderType },
            url: '/SalesInvoiceMasterAndDetails/List',
            success: function (data) {
                //Rebind Grid Data            
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);


                //$.ajax(
                //{
                //    cache: false,
                //    type: "POST",
                //    dataType: "html",
                //    data: {ID:PurchaseOrderID},
                //    url: '/SalesInvoiceMasterAndDetails/Download',
                //});
            }
        });
    },
    TotalTaxAmountForDirectInvoice: function () {

        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalTaxAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=TaxAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        var deductionAmount = parseFloat($("#InvoiceDeductionAmount").val());

        if (deductionAmount > 0 && a > 0) {
            a = parseFloat(a) - parseFloat((deductionAmount * 18) / 100);
        }

        $("#TotalTaxAmount").val(a.toFixed(2));
        $("#TotalTaxAmount").text(a.toFixed(2));

    },
    TotalAmountForDirectInvoice: function () {

        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#Amount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=TaxAbleAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        var deductionAmount = parseFloat($("#InvoiceDeductionAmount").val());

        if (deductionAmount > 0 && a > 0) {
            a = parseFloat(a) - parseFloat(deductionAmount);
        }

        $("#Amount").val(a.toFixed(2));
        $("#Amount").text(a.toFixed(2));

    },
    TotalBillAmountForDirectInvoice: function () {

        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#BillAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=NetAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        var deductionAmount = parseFloat($("#InvoiceDeductionAmount").val());
        var IsTaxExempted = $("#IsTaxExempted").val();

        if (deductionAmount > 0 && a > 0) {
            a = parseFloat(a) - parseFloat(deductionAmount + (IsTaxExempted == "false" ? parseFloat((deductionAmount * 18) / 100) : 0));
        }

        $("#BillAmount").val(a.toFixed(2));
        $("#BillAmount").text(a.toFixed(2));

    },
    TotalTaxAmountForInvoiceService: function () {

        var length = $("#myDataTableCreate tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalTaxAmount").val(0);
        $("#myDataTableCreate tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=TaxAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalTaxAmount").val(a.toFixed(2));
        $("#TotalTaxAmount").text(a.toFixed(2));

    },
    TotalAmountForInvoiceService: function () {

        var length = $("#myDataTableCreate tbody tr").length;
        var a = 0; var x = 0;
        $("#Amount").val(0);
        $("#myDataTableCreate tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=TaxAbleAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#Amount").val(a.toFixed(2));
        $("#Amount").prev().text(a.toFixed(2));

    },
    LoadListByPurchaseOrderType: function (PurchaseOrderType) {

        $.ajax(
     {
         cache: false,
         type: "POST",
         data: { PurchaseOrderType: PurchaseOrderType },
         dataType: "html",
         url: '/SalesInvoiceMasterAndDetails/List',
         success: function (result) {
             //Rebind Grid Data                
             $('#ListViewModel').html(result);
         }
     });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallSalesInvoiceMasterAndDetails: function () {
        var SalesInvoiceMasterAndDetailsData = null;
        if (SalesInvoiceMasterAndDetails.ActionName == "Create") {
            $("#FormCreateSalesInvoiceMasterAndDetails").validate();
            if ($("#FormCreateSalesInvoiceMasterAndDetails").valid()) {
                SalesInvoiceMasterAndDetailsData = null;
                SalesInvoiceMasterAndDetailsData = SalesInvoiceMasterAndDetails.GetSalesInvoiceMasterAndDetails();
                ajaxRequest.makeRequest("/SalesInvoiceMasterAndDetails/Create", "POST", SalesInvoiceMasterAndDetailsData, SalesInvoiceMasterAndDetails.Success, "CreateSalesInvoiceMasterAndDetailsRecord");
            }


        }
        else if (SalesInvoiceMasterAndDetails.ActionName == "CreateSalesInvoice") {
            $("#FormCreateSalesInvoiceMasterAndDetailsDirectInvoice").validate();
            if ($("#FormCreateSalesInvoiceMasterAndDetailsDirectInvoice").valid()) {
                SalesInvoiceMasterAndDetailsData = null;
                SalesInvoiceMasterAndDetailsData = SalesInvoiceMasterAndDetails.GetSalesInvoiceMasterAndDetails();
                ajaxRequest.makeRequest("/SalesInvoiceMasterAndDetails/CreateSalesInvoice", "POST", SalesInvoiceMasterAndDetailsData, SalesInvoiceMasterAndDetails.Success);

            }
        }
        else if (SalesInvoiceMasterAndDetails.ActionName == "Edit") {
            $("#FormEditSalesInvoiceMasterAndDetails").validate();
            if ($("#FormEditSalesInvoiceMasterAndDetails").valid()) {
                SalesInvoiceMasterAndDetailsData = null;
                SalesInvoiceMasterAndDetailsData = SalesInvoiceMasterAndDetails.GetSalesInvoiceMasterAndDetails();
                ajaxRequest.makeRequest("/SalesInvoiceMasterAndDetails/Edit", "POST", SalesInvoiceMasterAndDetailsData, SalesInvoiceMasterAndDetails.Success);

            }
        } else if (SalesInvoiceMasterAndDetails.ActionName == "CancelSalesInvoice") {
            //$("#FormEditSalesInvoiceMasterAndDetails").validate();
            //if ($("#FormEditSalesInvoiceMasterAndDetails").valid()) {
            SalesInvoiceMasterAndDetailsData = null;
            SalesInvoiceMasterAndDetailsData = SalesInvoiceMasterAndDetails.GetSalesInvoiceMasterAndDetails();
            ajaxRequest.makeRequest("/SalesInvoiceMasterAndDetails/CancelSalesInvoice", "POST", SalesInvoiceMasterAndDetailsData, SalesInvoiceMasterAndDetails.Success);

            //}
        }
    },
    GetXmlDataForDMNumber: function () {

        var DataArray = [];

        $('#DMNumber Span input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
        var ParameterXmlForDM = "<rows>";
        //alert(DataArray)

        for (var i = 0; i < TotalRecord; i = i + 1) {
            ParameterXmlForDM = ParameterXmlForDM + "<row><DeliveryMemoNumber>" + DataArray[i + 0] + "</DeliveryMemoNumber></row>";
        }

        // alert(ParameterXmlForDM)
        if (ParameterXmlForDM.length > 7) {
            SalesInvoiceMasterAndDetails.XMLstring = ParameterXmlForDM + "</rows>";

        }
        else {
            SalesInvoiceMasterAndDetails.XMLstring = "";
        }

    },
    GetXmlDataFoDirectInvoice: function () {

        var DataArray = [];
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
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 14) {
            var taxamount = parseFloat(DataArray[i + 8]);
            var rate = parseFloat(DataArray[i + 4]);

            var deductionAmount = parseFloat($("#InvoiceDeductionAmount").val());

            if (deductionAmount > 0) {
                if (taxamount > 0) {
                    taxamount = parseFloat(parseFloat(taxamount) - parseFloat(deductionAmount * 18 / 100));
                }
                if (rate > 0) {
                    rate = parseFloat(parseFloat(rate) - parseFloat(deductionAmount));
                }
            }

            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemNumber>" + DataArray[i + 0] + "</ItemNumber><SalesUomCode>" + DataArray[i + 2] + "</SalesUomCode><Quantity>" + DataArray[i + 3] + "</Quantity><TaxAmount>" + taxamount + "</TaxAmount><GenTaxGroupMasterID>" + DataArray[i + 10] + "</GenTaxGroupMasterID><BatchNumber>" + DataArray[i + 5] + "</BatchNumber><ExpiryDate>" + DataArray[i + 6] + "</ExpiryDate><Rate>" + rate + "</Rate><BillingDispalyName>" + DataArray[i + 11].replace(/~/g, ' ') + "</BillingDispalyName><ItemDescription>" + DataArray[i + 1].replace(/~/g, ' ') + "</ItemDescription><DisplayUOMCode>" + DataArray[i + 12] + "</DisplayUOMCode><DisplayRate>" + DataArray[i + 13] + "</DisplayRate></row>";
        }

        if (ParameterXml.length > 10)
            SalesInvoiceMasterAndDetails.XMLstringForInvoice = ParameterXml + "</rows>";

        else
            SalesInvoiceMasterAndDetails.XMLstringForInvoice = "";
        //alert(SalesOrderDeliveryMasterAndDetails.ParameterXml)
    },
    GetXmlDataFoInvoiceService: function () {

        var ParameterXml = "<rows>";
        $('#myDataTableCreate tbody tr td input.ItemNumber').each(function () {
            var taxamount = $(this).closest('tr').children('td').eq(12).children('input').val();
            var rate = $(this).closest('tr').children('td').eq(7).children('input').val();
            var SaleUOMCode = $(this).closest('tr').children('td').eq(4).children('input').val();
            var Quantity = $(this).closest('tr').children('td').eq(3).children('input').val();
            var GenTaxGroupMasterID = $(this).closest('tr').children('td').eq(13).children('input').eq(0).val();
            var BillingDispalyName = $(this).closest('tr').children('td').eq(13).children('input').eq(1).val();
            var ItemDescription = $(this).closest('tr').children('td').eq(1).children('input').val();
            var DisplayUOMCode = $(this).closest('tr').children('td').eq(13).children('input').eq(2).val();
            var DisplayRate = $(this).closest('tr').children('td').eq(13).children('input').eq(3).val();

            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemNumber>" + $(this).val() + "</ItemNumber><SalesUomCode>" + SaleUOMCode + "</SalesUomCode><Quantity>" + Quantity + "</Quantity><TaxAmount>" + taxamount + "</TaxAmount><GenTaxGroupMasterID>" + GenTaxGroupMasterID + "</GenTaxGroupMasterID><BatchNumber></BatchNumber><ExpiryDate></ExpiryDate><Rate>" + rate + "</Rate><BillingDispalyName>" + BillingDispalyName.replace(/~/g, ' ') + "</BillingDispalyName><ItemDescription>" + ItemDescription.replace(/~/g, ' ') + "</ItemDescription><DisplayUOMCode>" + DisplayUOMCode + "</DisplayUOMCode><DisplayRate>" + DisplayRate + "</DisplayRate></row>";
        });

        if (ParameterXml.length > 10)
            SalesInvoiceMasterAndDetails.XMLstringForInvoice = ParameterXml + "</rows>";

        else
            SalesInvoiceMasterAndDetails.XMLstringForInvoice = "";
        //alert(SalesOrderDeliveryMasterAndDetails.ParameterXml)
    },
    GetXmlDataForAccountVoucher: function () {


        var DataArray = []; var CGST = 0; var SGST = 0; var IGST = 0;
        $('#DivAddRowTable1 input').each(function () {
            DataArray.push($(this).val());
        });
        $('.CGST').each(function () {
            CGST = parseFloat(parseFloat(CGST) + parseFloat($(this).val()));
        });
        $('.SGST').each(function () {
            SGST = parseFloat(parseFloat(SGST) + parseFloat($(this).val()));
        });
        $('.IGST').each(function () {
            IGST = parseFloat(parseFloat(IGST) + parseFloat($(this).val()));
        });

        var TotalRecord = DataArray.length;
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

        for (var i = 0; i < TotalRecord; i = i + 6) {
            ParameterXml = ParameterXml + "<row><GenericNumber>" + DataArray[i + 5] + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSISales</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + parseFloat((DataArray[i + 1]) - DataArray[i + 4]) + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + DataArray[i + 5] + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSIDiscount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + parseFloat(DataArray[i + 4]) + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + DataArray[i + 5] + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSIReceivable</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + parseFloat((DataArray[i + 1] - DataArray[i + 4]) + parseFloat(DataArray[i + 0])) + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + DataArray[i + 5] + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSICGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + CGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + DataArray[i + 5] + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSISGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + SGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + DataArray[i + 5] + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSIIGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + IGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
        }

        // alert(ParameterXml)
        if (ParameterXml.length > 7) {
            SalesInvoiceMasterAndDetails.XMLstringForVouchar = ParameterXml + "</rows>";

        }
        else {
            SalesInvoiceMasterAndDetails.XMLstringForVouchar = "";
        }

    },

    GetXmlSalesInvoiceDataForAccountVoucher: function () {


        var DataArray = []; var CGST = 0; var SGST = 0; var IGST = 0;

        $('#tblData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });

        $('.CGST').each(function () {
            CGST = parseFloat(parseFloat(CGST) + parseFloat($(this).text()));
        });
        $('.SGST').each(function () {
            SGST = parseFloat(parseFloat(SGST) + parseFloat($(this).text()));
        });
        $('.IGST').each(function () {
            IGST = parseFloat(parseFloat(IGST) + parseFloat($(this).text()));
        });

        var deductionAmount = parseFloat($("#InvoiceDeductionAmount").val());

        if (deductionAmount > 0) {
            if (CGST > 0) {
                CGST = parseFloat(parseFloat(CGST) - parseFloat(deductionAmount * 9 / 100));
            }
            if (SGST > 0) {
                SGST = parseFloat(parseFloat(SGST) - parseFloat(deductionAmount * 9 / 100));
            }
            if (IGST > 0) {
                IGST = parseFloat(parseFloat(IGST) - parseFloat(deductionAmount * 18 / 100));
            }
        }

        var TotalRecord = DataArray.length;
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

        var CretedBy = '3';
        {
            ParameterXml = ParameterXml + "<row><GenericNumber>DirectInvoice " + $("#CustomerBranchMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSISales</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + $("#Amount").val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>DirectInvoice " + $("#CustomerBranchMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSIDiscount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + 0 + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>DirectInvoice " + $("#CustomerBranchMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSIReceivable</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + $("#BillAmount").val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>DirectInvoice " + $("#CustomerBranchMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSICGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + CGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>DirectInvoice " + $("#CustomerBranchMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSISGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + SGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>DirectInvoice " + $("#CustomerBranchMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSIIGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + IGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
        }

        // alert(ParameterXml)
        if (ParameterXml.length > 7) {
            SalesInvoiceMasterAndDetails.XMLstringForVouchar = ParameterXml + "</rows>";

        }
        else {
            SalesInvoiceMasterAndDetails.XMLstringForVouchar = "";
        }

    },
    GetXmlCancelDataForAccountVoucher: function () {


        var DataArray = []; var CGST = 0; var SGST = 0; var IGST = 0;

        $('#tblData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });

        $('.CGST').each(function () {
            CGST = parseFloat(parseFloat(CGST) + parseFloat($(this).val()));
        });
        $('.SGST').each(function () {
            SGST = parseFloat(parseFloat(SGST) + parseFloat($(this).val()));
        });
        $('.IGST').each(function () {
            IGST = parseFloat(parseFloat(IGST) + parseFloat($(this).val()));
        });

        var deductionAmount = parseFloat($("#InvoiceDeductionAmount").val());

        if (deductionAmount > 0) {
            if (CGST > 0) {
                CGST = parseFloat(parseFloat(CGST) - parseFloat(deductionAmount * 9 / 100));
            }
            if (SGST > 0) {
                SGST = parseFloat(parseFloat(SGST) - parseFloat(deductionAmount * 9 / 100));
            }
            if (IGST > 0) {
                IGST = parseFloat(parseFloat(IGST) - parseFloat(deductionAmount * 18 / 100));
            }
        }

        var TotalRecord = DataArray.length;
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

        var CretedBy = '3';
        {
            ParameterXml = ParameterXml + "<row><GenericNumber>CancelInvoice " + $("#ID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSISales</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + $("#Amount").val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>CancelInvoice " + $("#ID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSIDiscount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + 0 + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>CancelInvoice " + $("#ID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSIReceivable</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + $("#BillAmount").val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>CancelInvoice " + $("#ID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSICGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + CGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>CancelInvoice " + $("#ID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSISGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + SGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>CancelInvoice " + $("#ID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSIIGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + IGST + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + CretedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
        }

        // alert(ParameterXml)
        if (ParameterXml.length > 7) {
            SalesInvoiceMasterAndDetails.XMLstringForVouchar = ParameterXml + "</rows>";

        }
        else {
            SalesInvoiceMasterAndDetails.XMLstringForVouchar = "";
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetSalesInvoiceMasterAndDetails: function () {

        var Data = {
        };
        if (SalesInvoiceMasterAndDetails.ActionName == "Create" || SalesInvoiceMasterAndDetails.ActionName == "CreateSalesInvoice") {

            Data.PurchaseRequisitionMasterID = $('input[name=PurchaseRequisitionMasterID]').val();
            Data.CustomerMasterID = $('input[name=CustomerMasterID]').val();
            Data.PurchaseOrderType = $('input[name=PurchaseOrderType]').val();
            Data.Freight = $('#Freight').val();
            Data.TotalTaxAmount = $('#TotalTaxAmount').val();
            Data.Discount = $('#Discount').val();
            Data.Amount = $('#Amount').val();
            Data.BillAmount = $('#BillAmount').val();
            Data.ShippingHandling = $('#ShippingHandling').val();
            Data.SalesOrderDeliveryMasterID = $('#SalesOrderDeliveryMasterID').val();
            Data.SalesOrderMasterID = $('input[name=SalesOrderMasterID]').val();
            Data.VendorInvoiceNo = $('#VendorInvoiceNo').val();
            Data.StorageLocationID = $('#StorageLocationID').val();
            Data.GeneralUnitsID = $('#GeneralUnitsID').val();
            Data.XMLstringForVouchar = SalesInvoiceMasterAndDetails.XMLstringForVouchar;
            Data.XMLstring = SalesInvoiceMasterAndDetails.XMLstring;
            Data.XMLstringForInvoice = SalesInvoiceMasterAndDetails.XMLstringForInvoice;
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            Data.IsServiceItem = $('#IsServiceItem').is(':checked') ? true : false;
            Data.PurchaseOrderNumber = $('#PurchaseOrderNumber').val();
            Data.PurchaseOrderDate = $('#PurchaseOrderDate').val();
            Data.InvoiceDeductionName = $('#InvoiceDeductionName').val();
            Data.InvoiceDeductionAmount = $('#InvoiceDeductionAmount').val();
            Data.BillingSpanEndDate = $('#BillingSpanEndDate').val();
        } else if (SalesInvoiceMasterAndDetails.ActionName == "CancelSalesInvoice") {
            Data.XMLstringForVouchar = SalesInvoiceMasterAndDetails.XMLstringForVouchar;
            Data.ID = $('#ID').val();
        }

        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            SalesInvoiceMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

