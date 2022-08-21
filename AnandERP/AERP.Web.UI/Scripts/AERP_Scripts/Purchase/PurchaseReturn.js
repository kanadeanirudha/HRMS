//this class contain methods related to nationality functionality
var PurchaseReturn = {
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
        //PurchaseReturn.loadData();
        PurchaseReturn.constructor();
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

        $('#CreatePurchaseReturn').on("click", function () {
            var SelectedTransactionDate = $('#TransactionDate').val();
            var SelectedVendor = $('#vendor').val();
            var SelectedGeneralLocationList = $('#GeneralLocationList :selected').val();
            if (SelectedVendor == '') {
                $("#displayErrorMessage p").text("Please Select Vendor.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
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
            PurchaseReturn.ActionName = "Create";

            PurchaseReturn.GetPurchaseReturnXML();
            PurchaseReturn.PurchaseReturnVoucherXML();
            if (PurchaseReturn.ParameterXml != null && PurchaseReturn.ParameterXml != "" && PurchaseReturn.ParameterVoucherXml != null && PurchaseReturn.ParameterVoucherXml != "") {
                PurchaseReturn.AjaxCallPurchaseReturn();
            }
            else {
                $("#displayErrorMessage p").text("No data available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
        });

        $("#btnShowListforList").unbind('click').click(function () {
            var SelectedTransactionDate = $('#TransactionDate').val();
            var SelectedVendor = $('#vendor').val();
            var SelectedGeneralLocationList = $('#GeneralLocationList :selected').val();
            if (SelectedVendor == '') {
                notify('Please select Vendor', 'warning');
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
            PurchaseReturn.LoadList();
        });
        $("#TransactionDate").datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
        });

        var getDataVender = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');


                $.ajax({
                    url: "/PurchaseReturn/GetVendorSearchList",
                    type: "POST",
                    data: { SearchWord: q },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.vendor)) {
                                PurchaseReturn.map[response.vendor] = response;
                                matches.push(response.vendor);

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#vendor").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getDataVender()
        }).on("typeahead:selected", function (obj, item) {
            $("#VendorId").val(parseFloat(PurchaseReturn.map[item].VendorId));
            $("#vendor").val(parseFloat(PurchaseReturn.map[item].vendor));
            $("#VendorNumber").val(parseFloat(PurchaseReturn.map[item].VendorNumber));
        });
        $('#vendor').on("keydown", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $('#vendor').typeahead('val', '');
            }
        });
        //------------------------Item Number-------------------------------------
        var getDataItemNumber = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');


                var valuVendorNumber = $('#VendorNumber').val();
                var valuVendorId = $('#VendorId').val();
                if (VendorNumber != 0 && VendorNumber != null) {
                    $.ajax({
                        url: "/PurchaseReturn/GetItemNumberSearchList",
                        type: "POST",
                        data: { SearchWord: q, VendorNumber: valuVendorNumber },
                        dataType: "json",
                        success: function (data) {

                            // iterate through the pool of strings and for any string that
                            // contains the substring `q`, add it to the `matches` array
                            //alert(data);
                            //console.log(data);
                            $.each(data, function (i, response) {

                                if (substrRegex.test(response.ItemDescription)) {
                                    PurchaseReturn.map2[response.ItemDescription] = response;
                                    matches.push(response.ItemDescription);

                                }

                            });

                        },
                        async: false
                    })
                }
                cb(matches);
            };

        };
        $("#ItemDescription").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getDataItemNumber()
        }).on("typeahead:selected", function (obj, item) {
            $("#GeneralItemMasterID").val(parseFloat(PurchaseReturn.map2[item].GeneralItemMasterID));
            $("#ItemNumber").val(parseFloat(PurchaseReturn.map2[item].ItemNumber));
            $("#ItemDescription").val(parseFloat(PurchaseReturn.map2[item].ItemDescription));
            $("#GenTaxGroupMasterId").val(parseFloat(PurchaseReturn.map2[item].GenTaxGroupMasterId));
            $("#TaxInPercentage").val(parseFloat(PurchaseReturn.map2[item].TaxInPercentage));
            $("#SerialAndBatchManagedBy").val(parseFloat(PurchaseReturn.map2[item].SerialAndBatchManagedBy));
            debugger;
            if ($('#SerialAndBatchManagedBy').val() == 2) {
                $('#BatchNumber').attr("disabled", false);
            }
            else {
                $('#BatchNumber').attr("disabled", true);
            }

            //-------------From Item UOM Dropdown----------------------------
            var ItemNumberForUOM = $("#ItemNumber").val();
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { "ItemNumber": ItemNumberForUOM },
                url: '/PurchaseReturn/GetUoMCodeByItemNumber',
                success: function (data) {
                    var $ddlExam = $("#Units").children().children("#UnitCode");
                    $ddlExam.html('');
                    //  $ddlExam.append('<option value=""></option>');
                    if (data.length != 0) {
                        $.each(data, function (id, option) {
                            $ddlExam.append($('<option></option>').val(option.name).html(option.name));
                        });
                        $("#BaseUOMQuantity").val(data[0].BaseUOMQuantity);
                        //$("#Rate").val(data[0].Rate);
                    }
                    else {
                        $ddlExam.append('<option value="EA">EA</option>');

                    }
                }
            });
        });

        $('#ItemDescription').on("keydown", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $('#ItemDescription').typeahead('val', '');
                $('#PurchaseOrderNumber').typeahead('val', '');
                $('#PurchaseGrnNumber').typeahead('val', '');
                $("#Units").children().children("#UnitCode").val("");
                $('#Rate').val("");
                $('#BatchNumber').val("");
                //$('#OrderUomCode').val("");
                $('#Quantity').val("0");
                //$('.typeahead').typeahead('val', '');
            }
        });

        //-----------------------------------------PURCHASE ORDER-------------------------
        var getDataPurchaseOrder = function () {
            return function findMatches(q, cb) {
                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var valuVendorId = $('#VendorId').val();
                var valuItemNumber = $('#ItemNumber').val();
                var valuLocationID = $('#GeneralLocationList').val();
                $.ajax({
                    url: "/PurchaseReturn/GetPurchaseOrderSearchList",
                    type: "POST",
                    data: { SearchWord: q, VendorId: valuVendorId, ItemNumber: valuItemNumber, LocationID: valuLocationID },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.PurchaseOrderNumber)) {
                                PurchaseReturn.map3[response.PurchaseOrderNumber] = response;
                                matches.push(response.PurchaseOrderNumber);

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };
        $("#PurchaseOrderNumber").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getDataPurchaseOrder()
        }).on("typeahead:selected", function (obj, item) {
            //console.log(PurchaseReturn.map3[item])
            $("#PurchaseOrderMasterID").val(parseFloat(PurchaseReturn.map3[item].PurchaseOrderMasterID));
            $("#PurchaseOrderNumber").val(parseFloat(PurchaseReturn.map3[item].PurchaseOrderNumber));
            $("#Rate").val(parseFloat(PurchaseReturn.map3[item].Rate));
            $("#UnitCode").val(PurchaseReturn.map3[item].OrderUomCode);
            $("#BaseUOMQuantity").val(parseFloat(PurchaseReturn.map3[item].BaseUOMQuantity));
            $("#BaseUOMCode").val(PurchaseReturn.map3[item].BaseUOMCode);
            $("#GeneralItemCodeID").val(PurchaseReturn.map3[item].GeneralItemCodeID);
            $("#TaxRateList").val(PurchaseReturn.map3[item].TaxRateList);
            $("#TaxList").val(PurchaseReturn.map3[item].TaxList);



        });
        $('#PurchaseOrderNumber').on("keydown", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $('#PurchaseOrderNumber').typeahead('val', '');
                $('#PurchaseGrnNumber').typeahead('val', '');
                $('#UnitCode').val("");
                $("#Rate").val("");
                $('#Quantity').val("0");

            }
        });
        //------------------------------------PurchaseGRN---------------------------------
        var getDataPurchaseGRN = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var valuVendorId = $('#VendorId').val();
                var valuItemNumber = $('#ItemNumber').val();
                var valuLocationID = $('#GeneralLocationList').val();
                var valuPurchaseOrderMasterID = $('#PurchaseOrderMasterID').val();
                //if (valuVendorId != 0 && valuItemNumber!= 0 && valuLocationID!=0){

                $.ajax({
                    url: "/PurchaseReturn/GetPurchaseGRNSearchList",
                    type: "POST",
                    data: { SearchWord: q, VendorId: valuVendorId, ItemNumber: valuItemNumber, LocationID: valuLocationID, PurchaseOrderMasterID: valuPurchaseOrderMasterID },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);

                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.PurchaseGrnNumber)) {
                                PurchaseReturn.map4[response.PurchaseGrnNumber] = response;
                                matches.push(response.PurchaseGrnNumber);
                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };
        $("#PurchaseGrnNumber").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getDataPurchaseGRN()
        }).on("typeahead:selected", function (obj, item) {
            $("#PurchaseGRNMasterID").val(PurchaseReturn.map4[item].PurchaseGRNMasterID);
            $("#PurchaseGrnNumber").val(parseFloat(PurchaseReturn.map4[item].PurchaseGrnNumber));
            $("#ReceivedQuantity").val(PurchaseReturn.map4[item].ReceivedQuantity);
            $("#GenTaxGroupMasterId").val(parseFloat(PurchaseReturn.map4[item].GenTaxGroupMasterId));
            $("#TaxInPercentage").val(parseFloat(PurchaseReturn.map4[item].TaxInPercentage));
        });

        $('#PurchaseGrnNumber').on("keydown", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                //$("#PurchaseGrnNumber").val("");
                $('#PurchaseGrnNumber').typeahead('val', '');
            }
        });
        //-----------------------------------Batch NUmber-------------------------------
        var getDataBatchNumber = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var valuItemNumber = $('#ItemNumber').val();
                var valuPurchaseGRNMasterID = $('#PurchaseGRNMasterID').val();
                //if (valuVendorId != 0 && valuItemNumber!= 0 && valuLocationID!=0){

                $.ajax({
                    url: "/PurchaseReturn/GetBatchNUmberSearchList",
                    type: "POST",
                    data: { SearchWord: q, ItemNumber: valuItemNumber, PurchaseGRNMasterID: valuPurchaseGRNMasterID },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);

                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.BatchNumber)) {
                                PurchaseReturn.map5[response.BatchNumber] = response;
                                matches.push(response.BatchNumber);
                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };
        $("#BatchNumber").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getDataBatchNumber()
        }).on("typeahead:selected", function (obj, item) {
            $("#BatchID").val(PurchaseReturn.map5[item].BatchID);
            $("#BatchNumber").val(parseFloat(PurchaseReturn.map5[item].BatchNumber));
            $("#ExpiryDate").val(PurchaseReturn.map5[item].ExpiryDate);
        });

        $('#BatchNumber').on("keydown", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                //$("#PurchaseGrnNumber").val("");
                $('#BatchNumber').typeahead('val', '');
            }
        });

        //---------------------On UOM change Rate Cahnge-----------------------
        $("#Units").children().children("#UnitCode").change(function () {

            var selectedItem = $(this).val();
            var ItemNumber = $("#ItemNumber").val();
            var PurchaseOrderMasterID = $("#PurchaseOrderMasterID").val();
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { "ItemNumber": ItemNumber, "UoMCode": selectedItem, "PurchaseOrderMasterID": PurchaseOrderMasterID },
                url: '/PurchaseReturn/GetUoMCodeByForPurchasePrice',
                success: function (data) {
                    $('#BaseUOMQuantity').val(data[0].BaseUOMQuantity)
                    $("#Rate").val(data[0].UomPurchasePrice);

                    var conversion = ($("#Quantity").val() * $('#BaseUOMQuantity').val())

                    var abc = "(" + $('#Quantity').val() + "*" + $('#BaseUOMQuantity').val() + ")" + ' ' + "=" + ' ' + parseFloat(conversion).toFixed(2) + ' ' + $('#BaseUOMCode').val();

                    $("#Convertion").val(abc);

                }
            });



        });
        $('#addItem').on("click", function () {
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;

            for (var i = 0; i < TotalRecord; i = i + 17) {
                if (DataArray[i] == $('#ItemNumber').val() && DataArray[i + 4] == $("#PurchaseOrderNumber").val() && DataArray[i + 5] == $("#PurchaseGrnNumber").val()) {
                    $("#displayErrorMessage p").text("You Cannot Enter Same Item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#ItemDescription").val("");
                    $("#PurchaseOrderNumber").val("");
                    $("#PurchaseGrnNumber").val("");
                    $('#Rate').val("");
                    $('#OrderUomCode').val("");
                    $('#Quantity').val("");
                    return false
                }
            }
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
            else if ($("#PurchaseOrderNumber").val() == "" || $("#PurchaseOrderNumber").val() == null) {

                $("#displayErrorMessage p").text("Please select Purchase Order Number.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if ($("#PurchaseGrnNumber").val() == "" || $("#PurchaseGrnNumber").val() == 0 || $("#PurchaseGrnNumber").val() == '.') {

                $("#displayErrorMessage p").text("Please select Purchase GRN Number.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }

            else if (parseFloat($("#Quantity").val()) > parseFloat($("#ReceivedQuantity").val())) {

                $("#displayErrorMessage p").text("Please enter quantity less than recevied quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }

            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;
            var UnitCode = "<td>" + $("#Units").children().children("#UnitCode").val() + "</td>"
            var UnitCodeInput = $("#Units").children().children("#UnitCode").val();
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

            if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null && $('#PurchaseOrderNumber').val() != "" && $('#PurchaseOrderNumber').val() != null && $('#PurchaseGrnNumber').val() != null && $('#PurchaseGrnNumber').val() != "" && $('#Quantity').val() != null && $('#Quantity').val() != 0) {
                //Code For IsBase Uom Check box Ends



                var TaxList = $("#TaxList").val().replace(", ", ",").split(',');
                var TaxRateList = $("#TaxRateList").val().replace(', ', ',').split(',')

                var string =
                "<tr>" +
                  "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" +
                    $('#ItemNumber').val() + "</td>" +
                  "<td><input id='ItemDescription' type='text' value=" + $('#ItemDescription').val() + " style='display:none' />" + $('#ItemDescription').val() + "</                                     td>" +
                //"<td style=display:none><input id='TaxAmount' type='hidden' value=" + $('#TaxAmount').val() + " style='display:none' />" + $('#TaxAmount').val() + "</td>" +
                 "<td style=display:none><input id='GenTaxGroupMasterId' type='hidden' value=" + $('#GenTaxGroupMasterId').val() + " style='display:none' />" +
                  $('#GenTaxGroupMasterId').val() + "</td>" +
                 "<td style=display:none><input id='TaxInPercentage' type='hidden' value=" + $('#TaxInPercentage').val() + " style='display:none' />" + $('#TaxInPercentage').val() + "</td>" +
                 "<td><input id='PurchaseOrderNumber' type='text' value=" + $('#PurchaseOrderNumber').val() + "  style='display:none'/>" + $('#PurchaseOrderNumber').val() + "</td>" +
                 "<td><input id='PurchaseGrnNumber' type='text' value=" + $('#PurchaseGrnNumber').val() + " style='display:none' />" + $('#PurchaseGrnNumber').val() + "</td>" +
                 "<td><input id='OrderUomCode' type='text' value=" + UnitCodeInput + " style='display:none' />" + UnitCodeInput + "</td>" +
                 "<td><input id='Quantity' type='text' value=" + $('#Quantity').val() + " style='display:none' />" + $('#Quantity').val() + "</td>" +
                 "<td><input id='Rate' type='text' value=" + $('#Rate').val() + " style='display:none' />" + $('#Rate').val() + "</td>" +
                //"<td><input id='BatchNumber' type='text' value="+ $('#BatchNumber').val() +"  style='display:none' />" + $('#BatchNumber').val() + "</td>" +
                BatchNumber +
                "<td style=display:none><input id='ExpiryDate' type='hidden' value='" + $('#ExpiryDate').val() + "' style='display:none' />" + $('#ExpiryDate').val() + "</td>" +
                "<td style=display:none><input id='GeneralItemCodeID' type='hidden' value=" + $('#GeneralItemCodeID').val() + " style='display:none' />" + $('#GeneralItemCodeID').val() + "</td>" +
                "<td style=display:none><input id='BaseUOMQuantity' type='hidden' value=" + $('#BaseUOMQuantity').val() + " style='display:none' />" + $('#BaseUOMQuantity').val() + "</td>" +
                "<td style=display:none><input id='BaseUOMCode' type='hidden' value=" + $('#BaseUOMCode').val() + " style='display:none' />" + $('#BaseUOMCode').val() + "</td>" +
                "<td><input id='Amount' type='text' value=" + Amount + " style='display:none' />" + Amount + "</td>" +
                "<td style=display:none><input id='tax' type='hidden' value=" + tax + " style='display:none' />" + tax + "</td>" +
                "<td style=display:none><input id='totalamount' type='hidden' value=" + totalamount + " style='display:none' />" + totalamount + "</td><td style=display:none>";
                for (i = 0; i < TaxRateList.length; i++)
                {
                    
                    var TaxName = TaxList[i].split(' ');
                    var IndTaxamount = ($('#Quantity').val() * $('#Rate').val() * TaxRateList[i]) / 100;
                    string += "<span class='" + TaxName[0] + "'>" + IndTaxamount + "</span>";
                }
                string += "</td><td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer' title = 'Delete'></td>" +
            "</tr>";

                $("#tblData tbody").append(string);


                $("#ItemDescription").val("");
                $('#ItemDescription').typeahead('val', '');
                $("#PurchaseOrderNumber").val("");
                $('#PurchaseOrderNumber').typeahead('val', '');
                $("#PurchaseGrnNumber").val("");
                $('#PurchaseGrnNumber').typeahead('val', '');
                $("#Quantity").val("0");
                $("#Rate").val("0");
                $("#BaseUOMQuantity").val("");
                $("#BaseUOMCode").val("");
                $("#BatchNumber").val("");
                $("#Units").children().children("#UnitCode").val("");

            }
            if (!$('#vendor').attr("disabled")) {
                $('#vendor').attr("disabled", true);
                $('#GeneralLocationList').attr("disabled", true);
            }
            PurchaseReturn.TotalTaxAmount();
            PurchaseReturn.TotalNetAmount();
            PurchaseReturn.TotalGrossAmount();

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
                PurchaseReturn.TotalTaxAmount();
                PurchaseReturn.TotalNetAmount();
                PurchaseReturn.TotalGrossAmount();

                if ($("#tblData tbody").html().trim().length === 0) {
                    $('#vendor').attr("disabled", false);
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
             url: '/PurchaseReturn/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var SelectedTransactionDate = $('#TransactionDate').val();
        var SelectedVendor = $('#vendor').val();
        var SelectedGeneralLocationList = $('#GeneralLocationList :selected').val();
        if (SelectedTransactionDate != null && SelectedVendor > 0 && SelectedGeneralLocationList != null) {
            $.ajax(
            {
                cache: false,
                type: "POST",
                dataType: "html",
                data: { actionMode: actionMode },
                url: '/PurchaseReturn/List',
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
    AjaxCallPurchaseReturn: function () {
        var PurchaseReturnData = null;
        if (PurchaseReturn.ActionName == "Create") {
            $("#FormCreatePurchaseReturnMaster").validate();
            if ($("#FormCreatePurchaseReturnMaster").valid()) {
                PurchaseReturnData = null;
                PurchaseReturnData = PurchaseReturn.GetPurchaseReturn();
                ajaxRequest.makeRequest("/PurchaseReturn/Create", "POST", PurchaseReturnData, PurchaseReturn.Success, "CreatePurchaseReturn");
            }
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetPurchaseReturn: function () {
        var Data = {
        };
        if (PurchaseReturn.ActionName == "Create") {

            Data.VendorId = $('#VendorId').val();
            Data.TransactionDate = $('#TransactionDate').val();
            Data.LocationID = $('#GeneralLocationList').val();
            Data.TotalTaxAmount = $('#TotalTaxAmount').val();
            Data.RoundUpAmount = $('#TotalBillAmount').val();
            Data.PurchaseReturnAmount = $('#TotalGrossAmmount').val();
            Data.ParameterXml = PurchaseReturn.ParameterXml;
            Data.ParameterVoucherXml = PurchaseReturn.ParameterVoucherXml;
        }
        return Data;

    },

    GetPurchaseReturnXML: function () {
        var DataArray = [];
        //PurchaseReturn.flag = true;
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
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><PurchaseReturnMasterId>" + 0 + "</PurchaseReturnMasterId><ItemNumber>" + (DataArray[i]) + "</ItemNumber><TaxAmount>" + (DataArray[i + 15]) + "</TaxAmount><GenTaxGroupMasterID>" + (DataArray[i + 2]) + "</GenTaxGroupMasterID><TaxInPercentage>" + (DataArray[i + 3]) + "</TaxInPercentage><Quantity>" + (DataArray[i + 7]) + "</Quantity><Rate>" + (DataArray[i + 8]) + "</Rate><BatchNumber>" + (DataArray[i + 9]) + "</BatchNumber><ExpiryDate>" + (DataArray[i + 10]) + "</ExpiryDate><UOMCode>" + (DataArray[i + 6]) + "</UOMCode><GeneralItemCodeID>" + (DataArray[i + 11]) + "</GeneralItemCodeID><PurchaseOrderNumber>" + (DataArray[i + 4]) + "</PurchaseOrderNumber><PurchaseGrnNumber>" + (DataArray[i + 5]) + "</PurchaseGrnNumber><BaseUOMQuantity>" + (DataArray[i + 12]) + "</BaseUOMQuantity><BaseUOMCode>" + (DataArray[i + 13]) + "</BaseUOMCode></row>";
        }
        //alert(ParameterXml);
        if (ParameterXml.length > 10)
            PurchaseReturn.ParameterXml = ParameterXml + "</rows>";

        else
            PurchaseReturn.ParameterXml = "";
    },
    PurchaseReturnVoucherXML: function () {
        debugger;
        var DataArray = [];
        //PurchaseReturn.flag = true;
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

        ParameterVoucherXml = ParameterVoucherXml + "<row><GenericNumber>" + $('#VendorNumber').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPRPurchaseReturn</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalBillAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $('#VendorNumber').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPRVendorAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + Amount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
            
        ParameterVoucherXml = ParameterVoucherXml + "<row><GenericNumber>" + $('#VendorNumber').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPRCGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + CGST + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
            
        ParameterVoucherXml = ParameterVoucherXml + "<row><GenericNumber>" + $('#VendorNumber').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPRSGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + SGST + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
        
        ParameterVoucherXml = ParameterVoucherXml + "<row><GenericNumber>" + $('#VendorNumber').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPRIGST</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + IGST + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

        alert(ParameterVoucherXml);
        if (ParameterVoucherXml.length > 10)
            PurchaseReturn.ParameterVoucherXml = ParameterVoucherXml + "</rows>";

        else
            PurchaseReturn.ParameterVoucherXml = "";
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
        PurchaseReturn.RoundUpAmount1 = Math.round(a.toFixed(2)) - a.toFixed(2);
        $("#TotalGrossAmmount").val(a.toFixed(2));


    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            PurchaseReturn.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};



