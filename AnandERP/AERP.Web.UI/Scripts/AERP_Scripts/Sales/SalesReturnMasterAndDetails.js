//this class contain methods related to nationality functionality
var SalesReturnMasterAndDetails = {
    //Member variables
    map: {},
    map2: {},
    map3: {},
    map4: {},
    map5: {},
    ActionName: null,
    RoundUpAmount1: 0,
    //Class intialisation method
    Initialize: function () {
        //SalesReturnMasterAndDetails.loadData();
        SalesReturnMasterAndDetails.constructor();
        //OrganisationBuildingWings.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });
        // Create new record

        $('#CreateSalesReturnMasterAndDetails').on("click", function () {
            var SelectedTransactionDate = $('#TransactionDate').val();
            var SelectedCustomerMaster = $('#CustomerMaster').val();
            var SelectedGeneralLocationList = $('#GeneralLocationList :selected').val();
            if (SelectedCustomerMaster == '') {
                $("#displayErrorMessage p").text("Please Select CustomerMaster.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            if (SelectedTransactionDate == '') {
                $("#displayErrorMessage p").text("Please Select Transaction Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            if (SelectedGeneralLocationList == '') {
                $("#displayErrorMessage p").text("Please Select Location.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            SalesReturnMasterAndDetails.ActionName = "Create";

            SalesReturnMasterAndDetails.GetSalesReturnMasterAndDetailsXML();
            SalesReturnMasterAndDetails.SalesReturnMasterAndDetailsVoucherXML();
            if (SalesReturnMasterAndDetails.ParameterXml != null && SalesReturnMasterAndDetails.ParameterXml != "" && SalesReturnMasterAndDetails.ParameterVoucherXml != null && SalesReturnMasterAndDetails.ParameterVoucherXml != "") {
                SalesReturnMasterAndDetails.AjaxCallSalesReturnMasterAndDetails();
            }
            else {
                $("#displayErrorMessage p").text("No data available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
        });

        $("#btnShowListforList").unbind('click').click(function () {
            var SelectedTransactionDate = $('#TransactionDate').val();
            var SelectedCustomerMaster = $('#CustomerMaster').val();
            var SelectedGeneralLocationList = $('#GeneralLocationList :selected').val();
            if (SelectedCustomerMaster == '') {
                notify('Please select CustomerMaster', 'warning');
                return false;
            }
            if (SelectedTransactionDate == '') {
                notify('Please select Transaction Date', 'warning');
                return false;
            }
            if (SelectedGeneralLocationList == '') {
                notify('Please select Location', 'warning');
                return false;
            }
            SalesReturnMasterAndDetails.LoadList();
        });
        $("#TransactionDate").datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
        });

        var getDataCustomer = function () {
            debugger;
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');


                $.ajax({
                    url: "/CustomerMaster/GetCustomerMasterSearchList",
                    type: "POST",
                    data: { term: q },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.CustomerMasterName)) {
                                SalesReturnMasterAndDetails.map[response.CustomerMasterName] = response;
                                matches.push(response.CustomerMasterName);

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#CustomerName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getDataCustomer()
        }).on("typeahead:selected", function (obj, item) {
            $("#CustomerMasterID").val(SalesReturnMasterAndDetails.map[item].CustomerMasterID);
            $("#CustomerName").val(SalesReturnMasterAndDetails.map[item].CustomerMasterName);
            $("#CustomerType").val(SalesReturnMasterAndDetails.map[item].CustomerType);
            if ($("#CustomerType").val() == 1) {
                $('#CustomerBranchMasterName').prop('disabled', true);
                $('#CustomerBranchMasterName').val("");
            }
            else {
                $('#CustomerBranchMasterName').prop('disabled', false);
                $('#CustomerBranchMasterName').val("");
            }
        });


        //Code for Branch Starts
        var getDataCustomerBranch = function () {
            debugger;
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');


                $.ajax({
                    url: "/CustomerMaster/GetCustomerBranchMasterSearchList",
                    type: "POST",
                    data: { term: q, CustomerMasterID: $("#CustomerMasterID").val() },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {
                            if (substrRegex.test(response.CustomerBranchMasterName)) {
                                SalesReturnMasterAndDetails.map2[response.CustomerBranchMasterName] = response;
                                matches.push(response.CustomerBranchMasterName);

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#CustomerBranchMasterName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getDataCustomerBranch()
        }).on("typeahead:selected", function (obj, item) {
            $("#CustomerBranchMasterID").val(SalesReturnMasterAndDetails.map2[item].CustomerBranchMasterID);
            $("#CustomerBranchMasterName").val(SalesReturnMasterAndDetails.map2[item].CustomerBranchMasterName);
        });

        $('#CustomerName').on("keydown", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $('#CustomerName').typeahead('val', '');
                $('#CustomerName').val("");
                $('#CustomerBranchMasterName').prop('disabled', false);
                $('#CustomerBranchMasterName').val("");
                $("#CustomerMasterID").val("");
                $('#CustomerBranchMasterID').val('0');
                $('#CustomerMasterID').val('0');

            }
        });
        $("#CustomerBranchMasterName").on("keydown", function (e) {
            if ($("#CustomerName").val() == "" && ($("#CustomerMasterID").val() == "" || $("#CustomerMasterID").val() == 0)) {
                $("#displayErrorMessage").text("Please Select Customer.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                $('#CustomerBranchMasterName').typeahead('val', '');
                return false;
            }
            if (e.keyCode == 8 || e.keyCode == 46) {
                $('#CustomerBranchMasterName').val("");
                $('#CustomerBranchMasterName').typeahead('val', '');
                $('#CustomerBranchMasterID').val('0');
            }
        });

        $("#Units").children().children("#UOMCode").change(function () {
            debugger;
            var selectedItem = $(this).val();
            var ItemNumber = $("#ItemNumber").val();
            var GeneralUnitsID = $("#GeneralUnitsID").val();

            if (GeneralUnitsID != "" && ItemNumber != "") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: { "ItemNumber": ItemNumber, "UOM": selectedItem, "GeneralUnitsID": 1 },
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

        //Add Item 
        $('#addItem').on("click", function () {
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;

            //for (var i = 0; i < TotalRecord; i = i + 17) {
            //    if (DataArray[i] == $('#ItemNumber').val() && DataArray[i + 4] == $("#PurchaseOrderNumber").val() && DataArray[i + 5] == $("#PurchaseGrnNumber").val()) {
            //        $("#displayErrorMessage p").text("You Cannot Enter Same Item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //        $("#ItemDescription").val("");
            //        $("#PurchaseOrderNumber").val("");
            //        $("#PurchaseGrnNumber").val("");
            //        $('#Rate').val("");
            //        $('#OrderUomCode').val("");
            //        $('#Quantity').val("");
            //        return false
            //    }
            //}
            debugger;

            if ($("#Quantity").val() == "" || $("#Quantity").val() == 0 || $("#Quantity").val() == '.') {

                $("#displayErrorMessage p").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if ($("#ItemDescription").val() == "" || $("#ItemDescription").val() == null) {

                $("#displayErrorMessage p").text("Please select Item Description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if ($("#SalesInvoiceNumber").val() == "" || $("#SalesInvoiceNumber").val() == null) {

                $("#displayErrorMessage p").text("Please select Sales Invoice Number.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            //else if (parseFloat($("#Quantity").val()) > parseFloat($("#ReceivedQuantity").val())) {

            //    $("#displayErrorMessage p").text("Please enter quantity less than recevied quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
            //    return false;
            //}

            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;
            var UnitCode = "<td>" + $("#Units").children().children("#UOMCode").val() + "</td>"
            var UnitCodeInput = $("#Units").children().children("#UOMCode").val();
            var Amount = parseFloat((parseFloat($('#Quantity').val()).toFixed(2) * $('#Rate').val()).toFixed(2)).toFixed(2);
            $("#Amount").val(Amount);
            var tax = ((parseFloat($("#Rate").val() * $("#Quantity").val()) * $("#TaxInPercentage").val()) / 100);
            var totalamount = parseFloat(parseFloat(Amount) + ((parseFloat($("#Rate").val() * $("#Quantity").val()) * $("#TaxInPercentage").val()) / 100)).toFixed(2);

            if (($("#BatchNumber").val() == "" || $("#BatchNumber").val() == null) && $("#SerialAndBatchManagedBy").val() != 2) {
                var BatchNumber = "<td><input id='BatchNumber' type='text' value='' style='display:none' />" + " -" + "</td>"
            }
            else if (($("#BatchNumber").val() == "" || $("#BatchNumber").val() == null) && $("#SerialAndBatchManagedBy").val() == 2) {
                $("#displayErrorMessage p").text("Please enter batch.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else {
                var BatchNumber = "<td><input id='BatchNumber' type='text' value='" + $('#BatchNumber').val() + "' style='display:none' />" + $('#BatchNumber').val() + "</td>"
            }

            if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null && $('#SalesInvoiceNumber').val() != "" && $('#SalesInvoiceNumber').val() != null && $('#Quantity').val() != null && $('#Quantity').val() != 0) {
                //Code For IsBase Uom Check box Ends



                var TaxList = $("#TaxList").val().replace(", ", ",").split(',');
                var TaxRateList = $("#TaxRateList").val().replace(', ', ',').split(',')

                var string =
                "<tr>" +
                  "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" +
                    $('#ItemNumber').val() + "</td>" +
                  "<td><input id='ItemDescription' type='text' value=" + $('#ItemDescription').val() + " style='display:none' />" + $('#ItemDescription').val() + "</                                     td>" +
                 "<td style=display:none><input id='GenTaxGroupMasterId' type='hidden' value=" + $('#GenTaxGroupMasterId').val() + " style='display:none' />" +
                  $('#GenTaxGroupMasterId').val() + "</td>" +
                 "<td style=display:none><input id='TaxInPercentage' type='hidden' value=" + $('#TaxInPercentage').val() + " style='display:none' />" + $('#TaxInPercentage').val() + "</td>" +
                 "<td><input id='SalesInvoiceNumber' type='text' value=" + $('#SalesInvoiceNumber').val() + "  style='display:none'/>" + $('#SalesInvoiceNumber').val() + "</td>" +
                 "<td><input id='OrderUomCode' type='text' value=" + UnitCodeInput + " style='display:none' />" + UnitCodeInput + "</td>" +
                 "<td><input id='Quantity' type='text' value=" + $('#Quantity').val() + " style='display:none' />" + $('#Quantity').val() + "</td>" +
                 "<td><input id='Rate' type='text' value=" + $('#Rate').val() + " style='display:none' />" + $('#Rate').val() + "</td>" +
                BatchNumber +
                "<td style=display:none><input id='ExpiryDate' type='hidden' value='" + $('#ExpiryDate').val() + "' style='display:none' />" + $('#ExpiryDate').val() + "</td>" +
                "<td style=display:none><input id='BaseUOMQuantity' type='hidden' value=" + $('#BaseUOMQuantity').val() + " style='display:none' />" + $('#BaseUOMQuantity').val() + "</td>" +
                "<td style=display:none><input id='BaseUOMCode' type='hidden' value=" + $('#BaseUOMCode').val() + " style='display:none' />" + $('#BaseUOMCode').val() + "</td>" +
                "<td><input id='Amount' type='text' value=" + Amount + " style='display:none' />" + Amount + "</td>" +
                "<td style=display:none><input id='tax' type='hidden' value=" + tax + " style='display:none' />" + tax + "</td>" +
                "<td style=display:none><input id='totalamount' type='hidden' value=" + totalamount + " style='display:none' />" + totalamount + "</td><td style=display:none>";
                for (i = 0; i < TaxRateList.length; i++) {

                    var TaxName = TaxList[i].split(' ');
                    var IndTaxamount = ($('#Quantity').val() * $('#Rate').val() * TaxRateList[i]) / 100;
                    string += "<span class='" + TaxName[0] + "'>" + IndTaxamount + "</span>";
                }
                string += "</td><td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer' title = 'Delete'></td>" +
            "</tr>";

                $("#tblData tbody").append(string);


                $("#ItemDescription").val("");
                $('#ItemDescription').typeahead('val', '');
                $("#SalesInvoiceNumber").val("");
                $('#SalesInvoiceNumber').typeahead('val', '');
                $("#Quantity").val("0");
                $("#Rate").val("0");
                $("#BaseUOMQuantity").val("");
                $("#BaseUOMCode").val("");
                $("#BatchNumber").val("");
                $("#Units").children().children("#UOMCode").val("");

            }
            if (!$('#CustomerMaster').attr("disabled")) {
                $('#CustomerMaster').attr("disabled", true);
                $('#GeneralLocationList').attr("disabled", true);
            }
            SalesReturnMasterAndDetails.TotalTaxAmount();
            SalesReturnMasterAndDetails.TotalNetAmount();
            SalesReturnMasterAndDetails.TotalGrossAmount();

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
                SalesReturnMasterAndDetails.TotalTaxAmount();
                SalesReturnMasterAndDetails.TotalNetAmount();
                SalesReturnMasterAndDetails.TotalGrossAmount();

                if ($("#tblData tbody").html().trim().length === 0) {
                    $('#CustomerMaster').attr("disabled", false);
                    $('#GeneralLocationList').attr("disabled", false);
                }
            });

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
             data: {},
             dataType: "html",
             url: '/SalesReturnMasterAndDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var SelectedTransactionDate = $('#TransactionDate').val();
        var SelectedCustomerMaster = $('#CustomerMaster').val();
        var SelectedGeneralLocationList = $('#GeneralLocationList :selected').val();
        if (SelectedTransactionDate != null && SelectedCustomerMaster > 0 && SelectedGeneralLocationList != null) {
            $.ajax(
            {
                cache: false,
                type: "POST",
                dataType: "html",
                data: { actionMode: actionMode },
                url: '/SalesReturnMasterAndDetails/List',
                success: function (data) {
                    //Rebind Grid Data
                    $("#ListViewModel").empty().append(data);
                    //twitter type notification
                    notify(message, colorCode);
                }
            });
        }
        notify(message, colorCode);
    },


    //Fire ajax call to insert update and delete record
    AjaxCallSalesReturnMasterAndDetails: function () {
        var SalesReturnMasterAndDetailsData = null;
        if (SalesReturnMasterAndDetails.ActionName == "Create") {
            $("#FormCreateSalesReturnMasterAndDetailsMaster").validate();
            if ($("#FormCreateSalesReturnMasterAndDetailsMaster").valid()) {
                SalesReturnMasterAndDetailsData = null;
                SalesReturnMasterAndDetailsData = SalesReturnMasterAndDetails.GetSalesReturnMasterAndDetails();
                ajaxRequest.makeRequest("/SalesReturnMasterAndDetails/Create", "POST", SalesReturnMasterAndDetailsData, SalesReturnMasterAndDetails.Success, "CreateSalesReturnMasterAndDetails");
            }
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetSalesReturnMasterAndDetails: function () {
        var Data = {
        };
        if (SalesReturnMasterAndDetails.ActionName == "Create") {

            Data.CustomerMasterId = $('#CustomerMasterId').val();
            Data.TransactionDate = $('#TransactionDate').val();
            Data.LocationID = $('#GeneralLocationList').val();
            Data.TotalTaxAmount = $('#TotalTaxAmount').val();
            Data.RoundUpAmount = $('#TotalBillAmount').val();
            Data.SalesReturnMasterAndDetailsAmount = $('#TotalGrossAmmount').val();
            Data.ParameterXml = SalesReturnMasterAndDetails.ParameterXml;
            Data.ParameterVoucherXml = SalesReturnMasterAndDetails.ParameterVoucherXml;
        }
        return Data;

    },

    GetSalesReturnMasterAndDetailsXML: function () {
        var DataArray = [];
        //SalesReturnMasterAndDetails.flag = true;
        $('#tblData input').each(function () {
            if ($(this).val() != "on") {
                DataArray.push($(this).val());
            }
        });
        var TotalRecord = DataArray.length;
        //alert(TotalRecord)
        //alert(DataArray)
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 17) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><SalesReturnMasterAndDetailsMasterId>" + 0 + "</SalesReturnMasterAndDetailsMasterId><ItemNumber>" + (DataArray[i]) + "</ItemNumber><TaxAmount>" + (DataArray[i + 15]) + "</TaxAmount><GenTaxGroupMasterID>" + (DataArray[i + 2]) + "</GenTaxGroupMasterID><TaxInPercentage>" + (DataArray[i + 3]) + "</TaxInPercentage><Quantity>" + (DataArray[i + 7]) + "</Quantity><Rate>" + (DataArray[i + 8]) + "</Rate><BatchNumber>" + (DataArray[i + 9]) + "</BatchNumber><ExpiryDate>" + (DataArray[i + 10]) + "</ExpiryDate><UOMCode>" + (DataArray[i + 6]) + "</UOMCode><GeneralItemCodeID>" + (DataArray[i + 11]) + "</GeneralItemCodeID><PurchaseOrderNumber>" + (DataArray[i + 4]) + "</PurchaseOrderNumber><PurchaseGrnNumber>" + (DataArray[i + 5]) + "</PurchaseGrnNumber><BaseUOMQuantity>" + (DataArray[i + 12]) + "</BaseUOMQuantity><BaseUOMCode>" + (DataArray[i + 13]) + "</BaseUOMCode></row>";
        }
        //alert(ParameterXml);
        if (ParameterXml.length > 10)
            SalesReturnMasterAndDetails.ParameterXml = ParameterXml + "</rows>";

        else
            SalesReturnMasterAndDetails.ParameterXml = "";
    },
    SalesReturnMasterAndDetailsVoucherXML: function () {
        debugger;
        var DataArray = [];
        //SalesReturnMasterAndDetails.flag = true;
        $('#tblData input').each(function () {
            if ($(this).val() != "on") {
                DataArray.push($(this).val());
            }
        });

        var CGST = 0; var SGST = 0; var IGST = 0;
        $('.CGST').each(function () {
            CGST = parseFloat(parseFloat(CGST) + parseFloat($(this).text()));
        });
        $('.SGST').each(function () {
            SGST = parseFloat(parseFloat(SGST) + parseFloat($(this).text()));
        });
        $('.IGST').each(function () {
            IGST = parseFloat(parseFloat(IGST) + parseFloat($(this).text()));
        });


        var TotalRecord = DataArray.length;
        var ParameterVoucherXml = "<rows>";
        var currentdate = new Date();
        var datetime =
                         currentdate.getUTCFullYear() + "-"
                        + (currentdate.getUTCMonth() + 1) + "-"
                        + currentdate.getUTCDate() + " "
                        + currentdate.getUTCHours() + ":"
                        + currentdate.getUTCMinutes() + ":"
                        + currentdate.getUTCSeconds() + "."
                        + currentdate.getUTCMilliseconds();

        var Amount = $('#TotalGrossAmmount').val();
        var TotalBillAmount = $('#TotalBillAmount').val();
        var CreatedBy = $('#CreatedBy').val();

        ParameterVoucherXml = ParameterVoucherXml + "<row><GenericNumber>" + $('#CustomerMasterNumber').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPRSalesReturnMasterAndDetails</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalBillAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $('#CustomerMasterNumber').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPRCustomerMasterAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + Amount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

        ParameterVoucherXml = ParameterVoucherXml + "<row><GenericNumber>" + $('#CustomerMasterNumber').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPRCGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + CGST + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

        ParameterVoucherXml = ParameterVoucherXml + "<row><GenericNumber>" + $('#CustomerMasterNumber').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPRSGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + SGST + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

        ParameterVoucherXml = ParameterVoucherXml + "<row><GenericNumber>" + $('#CustomerMasterNumber').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPRIGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + IGST + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

        alert(ParameterVoucherXml);
        if (ParameterVoucherXml.length > 10)
            SalesReturnMasterAndDetails.ParameterVoucherXml = ParameterVoucherXml + "</rows>";

        else
            SalesReturnMasterAndDetails.ParameterVoucherXml = "";
    },
    TotalTaxAmount: function () {
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalTaxAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(15).text()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalTaxAmount").val(a.toFixed(2));

    },
    TotalNetAmount: function () {
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalBillAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(14).text()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalBillAmount").val(a.toFixed(2));

    },
    TotalGrossAmount: function () {
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalGrossAmmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(16).text()).toFixed(2);
                a += parseFloat(x);
            }
        });
        SalesReturnMasterAndDetails.RoundUpAmount1 = Math.round(a.toFixed(2)) - a.toFixed(2);
        $("#TotalGrossAmmount").val(a.toFixed(2));


    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            SalesReturnMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};



