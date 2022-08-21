//this class contain methods related to nationality functionality
var PurchaseInvoice = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        PurchaseInvoice.constructor();
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
        $("#btnShowList").unbind("click").on("click", function () {

            PurchaseInvoice.LoadListByPurchaseOrderType($('#PurchaseOrderType :selected').val());
            $("#directPurchaseorder").show();

        });
        // Create new record
        $('#CreatePurchaseInvoiceRecord').on("click", function () {
            PurchaseInvoice.ActionName = "Create";
            PurchaseInvoice.GetXmlDataForAccountVoucher();
            PurchaseInvoice.AjaxCallPurchaseInvoice();
        });
        $('#CreateDirectPurchaseInvoiceRecord').on("click", function () {
            
            PurchaseInvoice.ActionName = "CreateManualInvoice";
            PurchaseInvoice.GetPurchaseInvoiceXML();
            PurchaseInvoice.GetXmlDataForManualInvoiceAccountVoucher();
            if (PurchaseInvoice.PurchaseInvoiceXML != null && PurchaseInvoice.PurchaseInvoiceXML != "" && PurchaseInvoice.XmlStringForDirectinvoiceVoucher != null && PurchaseInvoice.XmlStringForDirectinvoiceVoucher != "") {
                PurchaseInvoice.AjaxCallPurchaseInvoice();
            }
            else {
                $("#displayErrorMessage p").text("No data available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
        });

        $("#Quantity").on("change keyup", function () {

            var conversion = ($("#Quantity").val() * $('#BaseUOMQuantity').val())
            var abc = "(" + $('#Quantity').val() + "*" + $('#BaseUOMQuantity').val() + ")" + ' ' + "=" + ' ' + parseFloat(conversion).toFixed(2) + ' ' + $('#BaseUOMCode').val();
            $("#Convertion").val(abc);
        });
        $('#addItem').on("click", function () {
           
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;


            if ($("#Quantity").val() == "" || $("#Quantity").val() == 0 || $("#Quantity").val() == '.') {

                $("#displayErrorMessage p").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if ($("#ItemName").val() == "" || $("#ItemName").val() == null) {

                $("#displayErrorMessage p").text("Please select Item Description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
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

            var TaxAbleamount = parseFloat($("#Rate").val() * $("#Quantity").val()).toFixed(2);
            var TaxAmount = parseFloat((TaxAbleamount * $("#TaxRate").val()) / 100).toFixed(2);
            var NetAmount = parseFloat(parseFloat(TaxAbleamount) + parseFloat(TaxAmount)).toFixed(2)


            if (($('#ItemDescription').val() != "" || $('#ItemDescription').val() != null) && ($('#Quantity').val() != null || $('#Quantity').val() != 0)) {
                //Code For IsBase Uom Check box Ends

                var TaxList = $("#TaxList").val().replace(", ", ",").split(',');
                var TaxRateList = $("#TaxRateList").val().replace(', ', ',').split(',')

                var string =

                 "<tr>" +
                             "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                             "<td><input id='ItemName' type='text' value=" + $('#ItemName').val() + " style='display:none' />" + $('#ItemName').val() + "</td>" +
                             "<td ><input type='text' value=" + UnitCodeInput + " style='display:none' /> " + UnitCodeInput + "</td>" +
                             "<td><input id='Quantity' type='text' value=" + $('#Quantity').val() + " style='display:none' />" + $('#Quantity').val() + "</td>" +
                             "<td><input id='Rate' type='text' value=" + $('#Rate').val() + " style='display:none' />" + $('#Rate').val() + "</td>" +
                             "<td ><input type='text' value=" + TaxAbleamount + " style='display:none'  id='TaxAbleAmount'/> " + TaxAbleamount + "</td>" +
                             "<td ><input type='text' value=" + TaxAmount + " style='display:none'  id='TaxAmount'/> " + TaxAmount + "</td>" +
                             "<td ><input type='text' value=" + NetAmount + " style='display:none'  id='NetAmount'/> " + NetAmount + "</td>" +
                             "<td> <i class='zmdi zmdi-delete zmdi-hc-fw ENQDetail' style='cursor:pointer'' title = Delete ><input id='GenTaxGroupMasterID' type='hidden'  value='" + $('#GenTaxGroupMasterID').val() + "'  style='display:none' /></td>" +

                             "<td style=display:none>";

                for (i = 0; i < TaxRateList.length; i++) {

                    var TaxName = TaxList[i].split(' ');
                    var IndTaxamount = ($('#Quantity').val() * $('#Rate').val() * TaxRateList[i]) / 100;
                    string += "<span class='" + TaxName[0] + "'>" + IndTaxamount + "</span>";
                }
                string += "</td>" + "</tr>";

                $("#tblData tbody").append(string);

                $("#ItemName").val("");
                $('#ItemName').typeahead('val', '');
                $("#Quantity").val("0");
                $("#Rate").val("0");
                $("#BaseUOMQuantity").val("");
                $("#BaseUOMCode").val("");
                $("#BatchNumber").val("");
                $("#Convertion").val("");
                $("#Units").children().children("#UnitCode").val("");

            }
            PurchaseInvoice.TotalTaxAmount();
            PurchaseInvoice.TotalNetAmount();
            PurchaseInvoice.TotalGrossAmount();

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
                PurchaseInvoice.TotalTaxAmount();
                PurchaseInvoice.TotalNetAmount();
                PurchaseInvoice.TotalGrossAmount();

                if ($("#tblData tbody").html().trim().length === 0) {
                    $('#vendor').attr("disabled", false);
                    $('#GeneralLocationList').attr("disabled", false);
                }
            });

        });
        $("#GeneralUnitsID").change(function () {
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { "CentreCode": $("#SelectedCentreCode :selected").val(), "GeneralUnitsID": $("#GeneralUnitsID :selected").val() },
                url: '/PurchaseInvoice/GetInventoryStorageLocationMasterListByCentreCodeandUnitsID',
                success: function (data) {
                    var $ddlExam = $("#divStdRequisitionLocation").children().children("#StorageLocationID");
                    $ddlExam.html('');
                    $ddlExam.append('<option value="">--------Select Location-------</option>'); // Location replaced by Sub Location
                    if (data.length != 0) {
                        $.each(data, function (id, option) {
                            $ddlExam.append($('<option></option>').val(option.id).html(option.name));
                            //$("#StorageLocationID").val(data[0].name);
                        });
                    }
                    else {
                        // $ddlExam.append('<option value="EA">EA</option>');
                    }

                }

            });

        });
        //  FOLLOWING FUNCTION IS SEARCHLIST OF Vendor 


        /////////////new search functionality///////////////////////////////////
        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');


                $.ajax({
                    url: "/PurchaseRequisitionMaster/GetVendorSearchList",
                    type: "POST",
                    data: { term: q },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.name)) {
                                PurchaseInvoice.map[response.name] = response;
                                matches.push(response.name);

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#VendorName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            $("#VendorID").val(parseFloat(PurchaseInvoice.map[item].id));
        });
        //end new search functionality

        $('#ExpectedBillingAmount').keydown(function (e) {
            AERPValidation.NotAllowSpaces(e);
            AERPValidation.AllowNumbersOnly(e);
        });
        $('#ExpectedDeliveryDate').datetimepicker({
            format: 'DD MMM YYYY',
            minDate: moment(),
            ignoreReadonly: true,
        })

        $("#AccountName").on("change", function (e) {

            if ($(this).val() != "") {
                $("#contactPerson").show();
            }
            else {
                $("#contactPerson").hide();
            }
        });

        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;
                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var valuStorageLocationID = $("#StorageLocationID").val();
                var GeneralVendorID = $("#VendorID").val();
                var CentreCode = $("#SelectedCentreCode :selected").val();
                var PurchaseRequisitionType = "5";
                $.ajax({
                    url: "/PurchaseRequisitionMaster/GetItemSearchListWithCompoundTax",
                    type: "POST",
                    data: { term: q, GeneralVendorID: GeneralVendorID, CentreCode: CentreCode, PurchaseRequisitionType: PurchaseRequisitionType },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.itemDescription)) {
                                PurchaseInvoice.map[response.itemDescription] = response;
                                matches.push(response.itemDescription);

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#ItemName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            $("#ItemNumber").val(parseFloat(PurchaseInvoice.map[item].itemNumber));
            $("#BarCode").val(PurchaseInvoice.map[item].barCode);
            
            $("#GenTaxGroupMasterID").val(PurchaseInvoice.map[item].genTaxGroupMasterID);
            // $("#Rate").val(PurchaseInvoice.map[item].lastPurchasePrice);
            $("#GeneralItemCodeID").val(PurchaseInvoice.map[item].generalItemCodeID);
            $("#TaxGroupName").val(PurchaseInvoice.map[item].TaxGroupName);
            $("#TaxRateList").val(PurchaseInvoice.map[item].TaxRateList);
            $("#TaxList").val(PurchaseInvoice.map[item].TaxList);
            $("#TaxRate").val(PurchaseInvoice.map[item].taxpercentage);

            $("#BaseUOMCode").val(PurchaseInvoice.map[item].baseUOMCode);
            $("#PurchaseGroupCode").val(PurchaseInvoice.map[item].PurchaseGroupCode);
            $(".abc").val(parseFloat(PurchaseInvoice.map[item].lastPurchasePrice).toFixed(2));
            $("#Rate").val($(".abc").val());
            $("#MinimumOrderquantity").val(PurchaseInvoice.map[item].MinimumOrderquantity);
            $("#SerialAndBatchManagedBy").val(PurchaseInvoice.map[item].SerialAndBatchManagedBy);
            $("#UnitCode").val(PurchaseInvoice.map[item].uomCode);
            $("#BaseUOMQuantity").val(PurchaseInvoice.map[item].baseUOMQuantity);

        });

        $('#ItemName').on("keydown", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $('#ItemName').val("");
                $('#ItemName').typeahead('val', '');
                $("#ItemNumber").val(0);
                $("#Quantity").val(0);
                $("#UnitCode").val("");
                $("#Rate").val(0);
                $("#Convertion").val("");

            }
            if ($("#StorageLocationID").val() == "" || $("#StorageLocationID").val() == 0) {
                $("#displayErrorMessage").text("Please Select Location.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if ($("#VendorName").val() == "" && ($("#VendorID").val() == "" || $("#VendorID").val() == 0)) {
                $("#displayErrorMessage").text("Please Select Vendor.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
        });
        //end new search functionality

        InitAnimatedBorder();

        CloseAlert();

    },

    TotalTaxAmount: function () {
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
    TotalNetAmount: function () {
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#Amount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=TaxAbleAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });
        $("#Amount").val(a.toFixed(2));
        $("#Amount").text(a.toFixed(2));

    },
    TotalGrossAmount: function () {
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalInvoiceAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').find('input[id^=NetAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });
        $("#TotalInvoiceAmount").val(a.toFixed(2));
        $("#TotalInvoiceAmount").text(a.toFixed(2));

    },

    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/PurchaseInvoice/List',
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
            url: '/PurchaseInvoice/List',
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
                //    url: '/PurchaseInvoice/Download',
                //});
            }
        });
    },

    LoadListByPurchaseOrderType: function (PurchaseOrderType) {

        $.ajax(
     {
         cache: false,
         type: "POST",
         data: { PurchaseOrderType: PurchaseOrderType },
         dataType: "html",
         url: '/PurchaseInvoice/List',
         success: function (result) {
             //Rebind Grid Data                
             $('#ListViewModel').html(result);
         }
     });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallPurchaseInvoice: function () {
        
        var PurchaseInvoiceData = null;
        if (PurchaseInvoice.ActionName == "Create") {
            $("#FormCreatePurchaseInvoice").validate();
            if ($("#FormCreatePurchaseInvoice").valid()) {
                PurchaseInvoiceData = null;
                PurchaseInvoiceData = PurchaseInvoice.GetPurchaseInvoice();
                ajaxRequest.makeRequest("/PurchaseInvoice/Create", "POST", PurchaseInvoiceData, PurchaseInvoice.Success, "CreatePurchaseInvoiceRecord");
            }
        }
        else if (PurchaseInvoice.ActionName == "Edit") {
            $("#FormEditPurchaseInvoice").validate();
            if ($("#FormEditPurchaseInvoice").valid()) {
                PurchaseInvoiceData = null;
                PurchaseInvoiceData = PurchaseInvoice.GetPurchaseInvoice();
                ajaxRequest.makeRequest("/PurchaseInvoice/Edit", "POST", PurchaseInvoiceData, PurchaseInvoice.Success);
            }
        } else if (PurchaseInvoice.ActionName == "CreateManualInvoice") {
            $("#FormCreateManualPurchaseInvoice").validate();
            if ($("#FormCreateManualPurchaseInvoice").valid()) {
                PurchaseInvoiceData = null;
                PurchaseInvoiceData = PurchaseInvoice.GetPurchaseInvoice();
                ajaxRequest.makeRequest("/PurchaseInvoice/CreateManualInvoice", "POST", PurchaseInvoiceData, PurchaseInvoice.Success);
            }
        }
        else if (PurchaseInvoice.ActionName == "Delete") {
            PurchaseInvoiceData = null;
            //$("#FormCreatePurchaseInvoice").validate();
            PurchaseInvoiceData = PurchaseInvoice.GetPurchaseInvoice();
            ajaxRequest.makeRequest("/PurchaseInvoice/Delete", "POST", PurchaseInvoiceData, PurchaseInvoice.Success);

        }
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
        // alert(DataArray);

        var TotalRecord = DataArray.length;

        //alert(TotalRecord)
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

        for (var i = 0; i < TotalRecord; i = i + 5) {
            
            var grossAmount = parseFloat((parseFloat(DataArray[i + 0])) + (parseFloat(DataArray[i + 1])) + (parseFloat($('#TotalTaxAmount').val())));

            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIVendorAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + grossAmount + "</Amount><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIPurchase</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + parseFloat(parseFloat(DataArray[i + 0]) - parseFloat(DataArray[i + 1])).toFixed(2) + "</Amount><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIFreight</ControlName><DebitCreditStatus>1</DebitCreditStatus><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><Amount>" + DataArray[i + 1] + "</Amount><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIDiscount</ControlName><DebitCreditStatus>0</DebitCreditStatus><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><Amount>-" + DataArray[i + 4] + "</Amount><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPICGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + CGST + "</Amount><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPISGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + SGST + "</Amount><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIIGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + IGST + "</Amount><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            //}

        }

        // alert(ParameterXml)
        if (ParameterXml.length > 7) {
            PurchaseInvoice.XMLstringForVouchar = ParameterXml + "</rows>";

        }
        else {
            PurchaseInvoice.XMLstringForVouchar = "";
        }

    },
    GetXmlDataForManualInvoiceAccountVoucher: function () {

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
            {

                ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorID').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIVendorAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + $('#TotalInvoiceAmount').val() + "</Amount><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

                ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorID').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIPurchase</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + $('#Amount').val() + "</Amount><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

                ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorID').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIFreight</ControlName><DebitCreditStatus>1</DebitCreditStatus><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><Amount>" + 0 + "</Amount><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

                ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorID').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIDiscount</ControlName><DebitCreditStatus>0</DebitCreditStatus><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><Amount>-" + 0 + "</Amount><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

                ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorID').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPICGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + CGST + "</Amount><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $('#VendorID').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPISGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + SGST + "</Amount><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $('#VendorID').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIIGST</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + IGST + "</Amount><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
        }
        if (ParameterXml.length > 7) {
            PurchaseInvoice.XmlStringForDirectinvoiceVoucher = ParameterXml + "</rows>";
        }
        else {
            PurchaseInvoice.XmlStringForDirectinvoiceVoucher = "";
        }
    },

    GetPurchaseInvoiceXML: function () {
        var DataArray = [];
        
        //PurchaseReturn.flag = true;
        $('#tblData input').each(function () {
            if ($(this).val() != "on") {
                DataArray.push($(this).val());
            }
        });
        var TotalRecord = DataArray.length;
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 9) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemNumber>" + DataArray[i] + "</ItemNumber><UomCode>" + (DataArray[i + 2]) + "</UomCode><PurchaseUomCode>" + (DataArray[i + 2]) + "</PurchaseUomCode><Quantity>" + (DataArray[i + 3]) + "</Quantity><TaxAmount>" + (DataArray[i + 6]) + "</TaxAmount><GenTaxGroupMasterID>" + (DataArray[i + 8]) + "</GenTaxGroupMasterID><Rate>" + (DataArray[i + 4]) + "</Rate></row>";
        }

        if (ParameterXml.length > 10)
            PurchaseInvoice.PurchaseInvoiceXML = ParameterXml + "</rows>";

        else
            PurchaseInvoice.PurchaseInvoiceXML = "";
    },
    //Get properties data from the Create, Update and Delete page
    GetPurchaseInvoice: function () {

        var Data = {
        };
        if (PurchaseInvoice.ActionName == "Create") {

            Data.PurchaseRequisitionMasterID = $('input[name=PurchaseRequisitionMasterID]').val();
            Data.VendorID = $('input[name=VendorID]').val();
            Data.PurchaseOrderType = $('input[name=PurchaseOrderType]').val();
            Data.Freight = $('#Freight').val();
            Data.TotalTaxAmount = $('#TotalTaxAmount').val();
            Data.Discount = $('#Discount').val();
            Data.Amount = $('#Amount').val();
            Data.ShippingHandling = $('#ShippingHandling').val();
            Data.PurchaseGRNMasterID = $('input[name=PurchaseGRNMasterID]').val();
            Data.PurchaseOrderMasterID = $('input[name=PurchaseOrderMasterID]').val();
            Data.VendorInvoiceNo = $('#VendorInvoiceNo').val();
            Data.StorageLocationID = $('#StorageLocationID').val();
            Data.XMLstringForVouchar = PurchaseInvoice.XMLstringForVouchar;
        }
        else if (PurchaseInvoice.ActionName == "CreateManualInvoice") {
            Data.VendorID = $('input[name=VendorID]').val();
            Data.StorageLocationID = $('#StorageLocationID').val();
            Data.Freight = $('#Freight').val();
            Data.ShippingHandling = $('#ShippingHandling').val();
            Data.Discount = $('#Discount').val();
            Data.TotalTaxAmount = $('#TotalTaxAmount').val();
            Data.Amount = $('#Amount').val(); // net Amount
            Data.TotalInvoiceAmount = $('#TotalInvoiceAmount').val(); // net Amount
            Data.PurchaseDetailsXML = PurchaseInvoice.PurchaseInvoiceXML;
            Data.XmlStringForDirectinvoiceVoucher = PurchaseInvoice.XmlStringForDirectinvoiceVoucher;
        }

        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            PurchaseInvoice.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

