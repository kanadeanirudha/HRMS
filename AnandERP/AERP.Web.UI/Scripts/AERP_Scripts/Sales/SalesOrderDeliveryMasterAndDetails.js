//this class contain methods related to nationality functionality
var SalesOrderDeliveryMasterAndDetails = {
    //Member variables
    ActionName: null,
    testBatch: true,
    testExpiry: true,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SalesOrderDeliveryMasterAndDetails.constructor();
        //SalesOrderDeliveryMasterAndDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });



        // Create new record

        $('#CreateSalesOrderDeliveryMasterAndDetailsRecord').on("click", function () {
            SalesOrderDeliveryMasterAndDetails.ActionName = "Create";
            var CurrentStockFlag = true;
            var ItemDescription = "";
            $('#TableData tbody tr td span.CurrentStockQty').each(function () {
                
                var CurrentStockQty = parseFloat($(this).text());
                
                var DispatchedQty = parseFloat($(this).parent().next().children('.DisptchedQTY').val());
                var ConversionFactor = $(this).closest('tr').find('td input[id=ConversionFactor]').val();
                var BaseUoMReceivedQuantity = parseFloat(DispatchedQty * ConversionFactor);
                ItemDescription = $(this).next().next().text();
                if (DispatchedQty == 0) {
                    CurrentStockFlag = true;
                }
                else if ((CurrentStockQty < BaseUoMReceivedQuantity)) {
                    CurrentStockFlag = false;
                    return false
                }

            });
            if (CurrentStockFlag == false) {
                $("#displayErrorMessage p").text("Current stock Qty of Item " + ItemDescription + " is less than Dispatched Qty.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            var IsComplete = true;
            $('#TableData tbody tr td .SOQTY').each(function () {
                
                var DispatchedQTY = parseFloat($(this).parent().next().next().children('.DisptchedQTY').val());
                var SOQTY = parseFloat($(this).val());
                if (DispatchedQTY < SOQTY) {
                    IsComplete = false;
                }
            });
            if (IsComplete == true && !$('#IsComplete').is(':checked')) {
                $(".sweet-overlay").css('z-index', 1043)
                swal({

                    title: 'Confirm Delivery Memo',
                    text: "Please Check checkbox to complete Delivery Memo",
                    //type: points[parseInt(settings.bulktype)]['type'],
                    showCancelButton: false,
                    confirmButtonClass: 'btn-success',
                    confirmButtonText: "OK"

                }, function (isConfirm) {
                    if (isConfirm) {
                        return false;
                    }
                });
                return false;
            }

            SalesOrderDeliveryMasterAndDetails.testBatch = true;
            SalesOrderDeliveryMasterAndDetails.testExpiry = true;
            SalesOrderDeliveryMasterAndDetails.GetXmlData();


            if (SalesOrderDeliveryMasterAndDetails.testBatch == false) {
                $("#displayErrorMessage").text("Please enter batch.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            if (SalesOrderDeliveryMasterAndDetails.testExpiry == false) {
                $("#displayErrorMessage").text("Please enter expiry date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }

            if (SalesOrderDeliveryMasterAndDetails.ParameterXml == "" || SalesOrderDeliveryMasterAndDetails.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }

            SalesOrderDeliveryMasterAndDetails.AjaxCallSalesOrderDeliveryMasterAndDetails();
        });



        $('#EditSalesOrderDeliveryMasterAndDetailsRecord').on("click", function () {

            SalesOrderDeliveryMasterAndDetails.ActionName = "Edit";
            SalesOrderDeliveryMasterAndDetails.AjaxCallSalesOrderDeliveryMasterAndDetails();
        });
        $('#CreateSalesOrderDeliveryMasterDirectDMRecord').on("click", function () {

            SalesOrderDeliveryMasterAndDetails.ActionName = "CreateDirectDM";

            if ($('#GeneralUnitsID').val() == '' || $('#GeneralUnitsID').val() == null || $('#GeneralUnitsID').val() == 0) {
                $("#displayErrorMessage p").text("Plaese Select Store.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($("#CustomerName").val() == "" && ($("#CustomerMasterID").val() == "" || $("#CustomerMasterID").val() == 0)) {
                $("#displayErrorMessage p").text("Plaese Select Customer Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($("#CustomerType").val() == 2 && ($("#CustomerBranchMasterID").val() == "" || $("#CustomerBranchMasterID").val() == 0)) {
                $("#displayErrorMessage p").text("Plaese Select Branch.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($("#ContactPersonName").val() == "" && ($("#ContactPersonName").val() == "" || $("#ContactPersonID").val() == 0)) {
                $("#displayErrorMessage p").text("Plaese Select Contact Person.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#ShipToStateID').val() == '' || $('#ShipToStateID').val() == null || $('#ShipToStateID').val() == 0) {
                $("#displayErrorMessage p").text("Please Enter State.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }


            SalesOrderDeliveryMasterAndDetails.GetXmlDataForDirectDM();
            if (SalesOrderDeliveryMasterAndDetails.ParameterXml == "" || SalesOrderDeliveryMasterAndDetails.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            SalesOrderDeliveryMasterAndDetails.AjaxCallSalesOrderDeliveryMasterAndDetails();
        });


        $('#DeleteSalesOrderDeliveryMasterAndDetailsRecord').on("click", function () {

            SalesOrderDeliveryMasterAndDetails.ActionName = "Delete";
            SalesOrderDeliveryMasterAndDetails.AjaxCallSalesOrderDeliveryMasterAndDetails();
        });


        $('#btnAdd').on("click", function () {
            
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

            if ($("#ItemDescription").val() == null || $("#ItemDescription").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Item Description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#DispatchedQuantity").val() == 0 || $("#DispatchedQuantity").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#SalesUomCode").val() == null || $("#SalesUomCode").val() == "") {
                $("#displayErrorMessage ").text("Please Select UoM Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            var TaxAbleamount = parseFloat($("#Rate").val() * $("#DispatchedQuantity").val()).toFixed(2);
            var TaxAmount = parseFloat((TaxAbleamount * $("#TaxRate").val()) / 100).toFixed(2);
            var NetAmount = parseFloat(parseFloat(TaxAbleamount) + parseFloat(TaxAmount)).toFixed(2)

            if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null) {
                //Code For IsBase Uom Check box Ends

                $("#tblData tbody").append(
                                     "<tr>" +
                            "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                            "<td><input id='ItemDescription' type='text' value=" + $('#ItemDescription').val() + " style='display:none' />" + $('#ItemDescription').val() + "</td>" +
                            "<td ><input type='text' value=" + $('#SalesUomCode').val() + " style='display:none' /> " + $('#SalesUomCode').val() + "</td>" +
                            "<td><input id='DispatchedQuantity' type='text' value=" + $('#DispatchedQuantity').val() + " style='display:none' />" + $('#DispatchedQuantity').val() + "</td>" +
                            "<td><input id='Rate' type='text' value=" + $('#Rate').val() + " style='display:none' />" + $('#Rate').val() + "</td>" +
                            "<td ><input type='text' id='BatchNumber' value='" + $('#BatchNumber').val() + "' style='display:none' /> " + $('#BatchNumber').val() + "</td>" +
                            "<td ><input type='text' id='ExpiryDate' value='" + $('#ExpiryDate').val() + "' style='display:none' /> " + $('#ExpiryDate').val() + "</td>" +
                            "<td ><input type='text' value=" + TaxAbleamount + " style='display:none'  id='TaxAbleAmount'/> " + TaxAbleamount + "</td>" +
                            "<td ><input type='text' value=" + TaxAmount + " style='display:none'  id='TaxAmount'/> " + TaxAmount + "</td>" +
                            "<td ><input type='text' value=" + NetAmount + " style='display:none'  id='NetAmount'/> " + NetAmount + "</td>" +
                            "<td> <i class='zmdi zmdi-delete zmdi-hc-fw ENQDetail' style='cursor:pointer'' title = Delete ><input id='GenTaxGroupMasterID' type='hidden'  value=" + $('#GenTaxGroupMasterID').val() + "  style='display:none' /></td>" +
                                     "</tr>"
                                    );

                $("#ItemDescription").val("");
                $('#ItemDescription').typeahead('val', '');
                $("#ItemNumber").val(0);
                $("#DispatchedQuantity").val(0);
                $("#BatchNumber").val("");
                $("#ExpiryDate").val("");
                $("#Rate").val(0);
                $("#SalesUomCode").html('');
                $('#BatchNumber').typeahead('val', '');

                SalesOrderDeliveryMasterAndDetails.TotalBillAmountForDirectDM();
                SalesOrderDeliveryMasterAndDetails.TotalTaxAmountForDirectDM();
                SalesOrderDeliveryMasterAndDetails.TotalAmountForDirectDM()

            }

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i.ENQDetail", function () {
                $(this).closest('tr').remove();
                SalesOrderDeliveryMasterAndDetails.TotalBillAmountForDirectDM();
                SalesOrderDeliveryMasterAndDetails.TotalTaxAmountForDirectDM();
                SalesOrderDeliveryMasterAndDetails.TotalAmountForDirectDM()
            });

        });

        $("#Units").children().children("#SalesUomCode").change(function () {
            
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
                            $("#Rate").val(0)
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


        $('#BatchNumber').on("keydown", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#BatchNumber").val("0");
                $("#ExpiryDate").val("");
                $('#BatchNumber').typeahead('val', '');
                $("#ExpiryDate").prop("disabled", false);

            }
        });
        $("#ShipToCountryID").change(function () {
            
            $('#ShipToCityID').find('option').remove().end().append('<option value>----Select City----</option>');
            $("#ShipToCityID").prop("disabled", true);
            var selectedItem = $(this).val();
            if (selectedItem != "") {
                var $ddlRegion = $("#ShipToStateID");
                var $RegionProgress = $("#states-loading-progress");
                $RegionProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralLocationMaster/GetRegionByCountryID",
                    data: { "SelectedCountryID": selectedItem },
                    success: function (data) {
                        $ddlRegion.html('');
                        $('#ShipToStateID').append('<option value>----Select State----</option>');
                        $.each(data, function (id, option) {

                            $ddlRegion.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $RegionProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Region.');
                        $RegionProgress.hide();
                    }
                });
            }
            else {
                $('#ShipToStateID').find('option').remove().end().append('<option value>----Select State----</option>');
                $('#ShipToCityID').find('option').remove().end().append('<option value>----Select City----</option>');
            }
        });


        $("#ShipToStateID").change(function () {

            var selectedItem = $(this).val();
            if (selectedItem != "") {
                $("#ShipToCityID").prop("disabled", false);
                var $ddlCity = $("#ShipToCityID");
                var $CityProgress = $("#states-loading-progress");
                $CityProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralLocationMaster/GetCityByRegionID",
                    data: { "SelectedRegionID": selectedItem },
                    success: function (data) {
                        $ddlCity.html('');
                        $('#ShipToCityID').append('<option value>----Select City----</option>');
                        $.each(data, function (id, option) {

                            $ddlCity.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $CityProgress.hide();

                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve City.');
                        $CityProgress.hide();
                    }
                });
            }
            else {
                $('#ShipToCityID').find('option').remove().end().append('<option value>----Select City----</option>');
            }
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
             url: '/SalesOrderDeliveryMasterAndDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    TotalAmount: function () {
        
        var length = $("#TableData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalAmount").val(0);
        $("#TableData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=TaxAbleAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalAmount").val(a.toFixed(2));
        $("#TotalAmount").text(a.toFixed(2));

    },
    TotalAmountForDirectDM: function () {
        
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=TaxAbleAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalAmount").val(a.toFixed(2));
        $("#TotalAmount").text(a.toFixed(2));

    },
    TotalTaxAmount: function () {
        
        var length = $("#TableData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalTaxAmount").val(0);
        $("#TableData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=TaxAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalTaxAmount").val(a.toFixed(2));
        $("#TotalTaxAmount").text(a.toFixed(2));

    },
    TotalTaxAmountForDirectDM: function () {
        
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
        
        var length = $("#TableData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalBillAmount").val(0);
        $("#TableData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=NetAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalBillAmount").val(a.toFixed(2));
        $("#TotalBillAmount").text(a.toFixed(2));

    },

    TotalBillAmountForDirectDM: function () {
        
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
    TotalPurchaseAmount: function () {
        
        var a = 0; var x = 0;
        $("#TotalPurchaseAmount").val(0);
        $("#TableData tbody tr td span.PurchaseNetAmount").each(function () {
            x = $(this).text();
            a += parseFloat(x);
        });

        $("#TotalPurchaseAmount").val(a.toFixed(2));
        $("#TotalPurchaseAmount").text(a.toFixed(2));

    },
    TotalPurchaseTaxAmount: function () {
        var a = 0; var x = 0;
        $("#TotalPurchaseTaxAmount").val(0);
        $("#TableData tbody tr td span.PurchaseTaxableAmount").each(function () {
            x = $(this).text();
            a += parseFloat(x);
        });

        $("#TotalPurchaseTaxAmount").val(a.toFixed(2));
        $("#TotalPurchaseTaxAmount").text(a.toFixed(2));

    },
    TotalPurchaseBillAmount: function () {
        var a = 0; var x = 0;
        $("#TotalPurchaseBillAmount").val(0);
        $("#TableData tbody tr td span.PurchaseGrossAmount").each(function () {
            x = $(this).text();
            a += parseFloat(x);
        });

        $("#TotalPurchaseBillAmount").val(a.toFixed(2));
        $("#TotalPurchaseBillAmount").text(a.toFixed(2));

    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/SalesOrderDeliveryMasterAndDetails/List',
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
        //CustomerMaster.flag = true;
        
        $('#TableData tbody tr td input').each(function () {
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
        //alert(DataArray)
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 24) {
            if (DataArray[i + 3] > 0) {
                if ((DataArray[i + 7] == "" || DataArray[i + 7] == null) && DataArray[i + 22] == 2) {
                    SalesOrderDeliveryMasterAndDetails.testBatch = false;
                }
                else if 
                ((DataArray[i + 9] == "" || DataArray[i + 9] == null) && DataArray[i + 22] == 2) {
                    SalesOrderDeliveryMasterAndDetails.testBatch = false;
                }

            }

            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemNumber>" + DataArray[i + 0] + "</ItemNumber><GeneralItemCodeID>" + DataArray[i + 14] + "</GeneralItemCodeID><BarCode>" + DataArray[i + 12] + "</BarCode><UomCode>" + DataArray[i + 1] + "</UomCode><SalesUomCode>" + DataArray[i + 1] + "</SalesUomCode><BaseUOMQuantity>" + DataArray[i + 11] + "</BaseUOMQuantity><BaseUOMCode>" + DataArray[i + 10] + "</BaseUOMCode><DispatchedQuantity>" + DataArray[i + 3] + "</DispatchedQuantity><TaxAmount>" + DataArray[i + 16] + "</TaxAmount><GenTaxGroupMasterID>" + DataArray[i + 20] + "</GenTaxGroupMasterID><BatchNumber>" + DataArray[i + 7] + "</BatchNumber><ExpiryDate>" + DataArray[i + 9] + "</ExpiryDate></row>";
        }
        // alert(ParameterXml);
        if (ParameterXml.length > 10)
            SalesOrderDeliveryMasterAndDetails.ParameterXml = ParameterXml + "</rows>";

        else
            SalesOrderDeliveryMasterAndDetails.ParameterXml = "";
        // alert(CustomerMaster.ParameterXml)
    },
    GetXmlDataForDirectDM: function () {

        var DataArray = [];
        //CustomerMaster.flag = true;
        
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
        //alert(DataArray)
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 11) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemNumber>" + DataArray[i + 0] + "</ItemNumber><UomCode>" + DataArray[i + 2] + "</UomCode><SalesUomCode>" + DataArray[i + 2] + "</SalesUomCode><DispatchedQuantity>" + DataArray[i + 3] + "</DispatchedQuantity><TaxAmount>" + DataArray[i + 8] + "</TaxAmount><GenTaxGroupMasterID>" + DataArray[i + 10] + "</GenTaxGroupMasterID><BatchNumber>" + DataArray[i + 5] + "</BatchNumber><ExpiryDate>" + DataArray[i + 6] + "</ExpiryDate><Rate>" + DataArray[i + 4] + "</Rate></row>";
        }
        // alert(ParameterXml);
        if (ParameterXml.length > 10)
            SalesOrderDeliveryMasterAndDetails.ParameterXml = ParameterXml + "</rows>";

        else
            SalesOrderDeliveryMasterAndDetails.ParameterXml = "";
        //alert(SalesOrderDeliveryMasterAndDetails.ParameterXml)
    },

    //Fire ajax call to insert update and delete record

    AjaxCallSalesOrderDeliveryMasterAndDetails: function () {
        
        var SalesOrderDeliveryMasterAndDetailsData = null;

        if (SalesOrderDeliveryMasterAndDetails.ActionName == "Create") {

            $("#FormCreateSalesOrderDeliveryMasterAndDetails").validate();
            if ($("#FormCreateSalesOrderDeliveryMasterAndDetails").valid()) {
                SalesOrderDeliveryMasterAndDetailsData = null;
                SalesOrderDeliveryMasterAndDetailsData = SalesOrderDeliveryMasterAndDetails.GetSalesOrderDeliveryMasterAndDetails();
                ajaxRequest.makeRequest("/SalesOrderDeliveryMasterAndDetails/Create", "POST", SalesOrderDeliveryMasterAndDetailsData, SalesOrderDeliveryMasterAndDetails.Success, "CreateSalesOrderDeliveryMasterAndDetailsRecord");
            }
        }
        else if (SalesOrderDeliveryMasterAndDetails.ActionName == "CreateDirectDM") {
            $("#FormCreateSalesOrderDeliveryMasterAndDetailsDirectDM").validate();
            if ($("#FormCreateSalesOrderDeliveryMasterAndDetailsDirectDM").valid()) {
                SalesOrderDeliveryMasterAndDetailsData = null;
                SalesOrderDeliveryMasterAndDetailsData = SalesOrderDeliveryMasterAndDetails.GetSalesOrderDeliveryMasterAndDetails();
                ajaxRequest.makeRequest("/SalesOrderDeliveryMasterAndDetails/CreateDirectDM", "POST", SalesOrderDeliveryMasterAndDetailsData, SalesOrderDeliveryMasterAndDetails.Success);
            }
        }
        else if (SalesOrderDeliveryMasterAndDetails.ActionName == "Edit") {
            $("#FormEditSalesOrderDeliveryMasterAndDetails").validate();
            if ($("#FormEditSalesOrderDeliveryMasterAndDetails").valid()) {
                SalesOrderDeliveryMasterAndDetailsData = null;
                SalesOrderDeliveryMasterAndDetailsData = SalesOrderDeliveryMasterAndDetails.GetSalesOrderDeliveryMasterAndDetails();
                ajaxRequest.makeRequest("/SalesOrderDeliveryMasterAndDetails/Edit", "POST", SalesOrderDeliveryMasterAndDetailsData, SalesOrderDeliveryMasterAndDetails.Success);
            }
        }
        else if (SalesOrderDeliveryMasterAndDetails.ActionName == "Delete") {

            SalesOrderDeliveryMasterAndDetailsData = null;
            //$("#FormCreateSalesOrderDeliveryMasterAndDetails").validate();
            SalesOrderDeliveryMasterAndDetailsData = SalesOrderDeliveryMasterAndDetails.GetSalesOrderDeliveryMasterAndDetails();
            ajaxRequest.makeRequest("/SalesOrderDeliveryMasterAndDetails/Delete", "POST", SalesOrderDeliveryMasterAndDetailsData, SalesOrderDeliveryMasterAndDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalesOrderDeliveryMasterAndDetails: function () {
        var Data = {
        };

        if (SalesOrderDeliveryMasterAndDetails.ActionName == "Create" || SalesOrderDeliveryMasterAndDetails.ActionName == "Edit" || SalesOrderDeliveryMasterAndDetails.ActionName == "CreateDirectDM") {
            Data.SalesOrderMasterID = $('#SalesOrderMasterID').val();

            Data.VehicalNumber = $('#VehicalNumber').val();
            Data.GeneralShipperID = $('#GeneralShipperID').val();
            Data.ShipToCountryID = $('#ShipToCountryID').val();
            Data.ShipToStateID = $('#ShipToStateID').val();
            Data.ShipToCityID = $('#ShipToCityID').val();
            Data.ShipToAddress = $('#ShipToAddress').val();
            Data.DeliveryTransDate = $('#DeliveryTransDate').val();
            Data.GeneralUnitsID = $('#GeneralUnitsID').val();
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            Data.ContactPersonID = $('#ContactPersonID').val();
            Data.CustomerMasterID = $('#CustomerMasterID').val();

            Data.TransportationMode = $('#TransportationMode').val();

            Data.IsLocked = $("#IsComplete").is(":checked") ? "true" : "false";
            Data.Frieght = 0;//$('#Frieght').val();
            Data.XmlString = SalesOrderDeliveryMasterAndDetails.ParameterXml
            Data.TotalTaxAmount = $("#TotalTaxAmount").val();
            Data.TotalAmount = $("#TotalAmount").val();
            Data.TotalBillAmount = $("#TotalBillAmount").val();


        }
        else if (SalesOrderDeliveryMasterAndDetails.ActionName == "Delete") {

            Data.SalesOrderDeliveryMasterID = $('#SalesOrderDeliveryMasterID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            SalesOrderDeliveryMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};