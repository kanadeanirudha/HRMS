//this class contain methods related to nationality functionality
var SalesOrderMasterAndDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        SalesOrderMasterAndDetails.constructor();
    },
    //Attach all event of page
    constructor: function () {

        $("#SalesOrderDate").datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
        });

        $("#btnShowListforSalesOrder").unbind('click').click(function () {
            var SelectedTransactionDate = $('#SalesOrderDate').val();
            if ($("#MonthName").val() == '' || $("#MonthYear").val() == '') {
                notify('Please select Transaction Span', 'warning');
                return false;
            }
            else {
                SalesOrderMasterAndDetails.LoadList();
            }
        });

        // Create new record
        $('#CreateSalesOrder').unbind("click").on("click", function () {
            
            SalesOrderMasterAndDetails.ActionName = "CreateSalesOrder";
            SalesOrderMasterAndDetails.GetXmlData();
            var CreatePR = $('#CreatePR').is(":checked") ? "true" : "false";
            if($('#GeneralUnitsID').val()=='' ||$('#GeneralUnitsID').val()==null||$('#GeneralUnitsID').val()==0)
            {
                $("#displayErrorMessage p").text("Plaese Select Store.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
           //else if ($('#PurchaseOrderNumberClient').val()==''||$('#PurchaseOrderNumberClient').val()==null)
           // {
           //     $("#displayErrorMessage p").text("Plaese Enter Purchase order Number.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
           //     return false;
           //}
           else if ($("#CustomerName").val() == "" && ($("#CustomerMasterID").val() == "" || $("#CustomerMasterID").val() == 0)) {
               $("#displayErrorMessage p").text("Plaese Select Customer Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
               return false;
           }
           else if ($("#ContactPersonName").val() == "" && ($("#ContactPersonName").val() == "" || $("#ContactPersonID").val() == 0)) {
               $("#displayErrorMessage p").text("Plaese Select Contact Person.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
               return false;
           }
           else if (CreatePR == "true" && ($("#SelectedDepartmentID").val() == "" || $("#SelectedDepartmentID").val() == null)) {
               $("#displayErrorMessage p").text("Plaese Select Department.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
               return false;
           }
           else if (SalesOrderMasterAndDetails.ParameterXml == "" || SalesOrderMasterAndDetails.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                SalesOrderMasterAndDetails.AjaxCallSalesOrderMasterAndDetails();
            }

        });
        $("#GeneralUnitsID").change(function () {
            
            //
            var selectedItem = $(this).val();
            var selectedCentreCode=[]
            selectedCentreCode = selectedItem.split('~')
           
            var $ddlDepartment = $("#SelectedDepartmentID");
            var $DepartmentProgress = $("#states-loading-progress");
            $DepartmentProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/SalesOrderMasterAndDetails/GetDepartmentByCentreCodeForSO",

                    data: { "SelectedCentreCode": selectedCentreCode[1] },
                    success: function (data) {
                        $ddlDepartment.html('');
                        $ddlDepartment.append('<option value="">----Select Department----</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartment.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $DepartmentProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Department.');
                        $DepartmentProgress.hide();
                    }
                });
            }
            else {
                $ddlDepartment.append('<option value="">----Select Department----</option>');
            }
        });
         
        $("#CreatePR").on("click", function () {
            var CreatePR = $('#CreatePR').is(":checked") ? "true" : "false";
            if (CreatePR == "false") {
                $("#selectedDeptID").hide();
            }
            else {
                $("#selectedDeptID").show();
            }
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
                    $("#ItemDescription").focus();
                    $('#Rate').val(0);
                    return false
                }
            }


            //End Of Code for Duplication of Item



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


            var Purchaseamount = parseFloat(($('#PurchasePrice').val() / $('#ConversionFactor').val()) * $('#Quantity').val()).toFixed(2)
            var PurchaseTaxAmount = parseFloat((Purchaseamount * $("#TaxRate").val()) / 100).toFixed(2);
            var PurchaseGrossAmount = parseFloat(parseFloat(Purchaseamount) + parseFloat(PurchaseTaxAmount)).toFixed(2)


            var CreatePR = $('#CreatePR').is(":checked") ? "true" : "false";
         
            //$('#IsCompletePO').is(":checked") ? "true" : "false";
            if (CreatePR=="true")
            {
                var re1 = "<td class='form-control'>"+ $('#Quantity').val() + "</td>";
            }
            else {
                var re1 = "<td class='form-control'>"+ 0 + "</td>"
            }
                    
            if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null) {
                //Code For IsBase Uom Check box Ends

                $("#tblData tbody").append(
                                      "<tr>" +
                                      "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                                      "<td><input id='ItemDescription' type='text' value=" + $('#ItemDescription').val() + " style='display:none' />" + $('#ItemDescription').val() + "</td>" +
                                      "<td><input id='Quantity' type='text' value=" + $('#Quantity').val() + " style='display:none' />" + $('#Quantity').val() + "</td>" +
                                      re1+
                                      "<td ><input type='text' value=" + $('#UOM').val() + " style='display:none' /> " + $('#UOM').val() + "</td>" +
                                      "<td ><input type='text' value=" + $('#Rate').val() + " style='display:none' /> " + parseFloat($('#Rate').val(), 3) + "</td>" +
                                     
                                      "<td ><input type='text' value=" + TaxAmount + " style='display:none'  id='TaxAmount'/> " + TaxAmount + "</td>" +
                                      "<td ><input type='text' value=" + TaxAbleamount + " style='display:none'  id='TaxAbleAmount'/> " + TaxAbleamount + "</td>" +

                                      "<td ><input type='text' value=" + NetAmount + " style='display:none'  id='NetAmount'/> " + NetAmount + "</td>" +
                                       "<td>" + ($('#PurchasePrice').val() / $('#ConversionFactor').val()) + "</td>" +
                                      "<td class='PurchaseAmount'>" + Purchaseamount + "</td>" +
                                      "<td class='PurchaseTaxAmount' style='display:none'>" + PurchaseTaxAmount + "</td>" +
                                      "<td class='PurchaseGrossAmount'style='display:none'>" + PurchaseGrossAmount + "</td>" +

                                      "<td style=display:none><input id='SalesQuotationDetailID' type='hidden'  value=0  style='display:none' />" + $('#SalesQuotationDetailID').val() + "</td>" +
                                      "<td style=display:none><input id='GeneralTaxGroupMasterID' type='hidden'  value=" + $('#GeneralTaxGroupMasterID').val() + "  style='display:none' />" + $('#GeneralTaxGroupMasterID').val() + "</td>" +
                                      "<td> <i class='zmdi zmdi-delete zmdi-hc-fw ENQDetail' style='cursor:pointer'' title = Delete ><input id='TaxRate' type='hidden'  value=" + $('#TaxRate').val() + "  style='display:none' /></td>" +
                                      "</tr>"
                                     );

                $("#ItemDescription").val("");
                $('#ItemDescription').typeahead('val', '');
                $("#ItemNumber").val(0);
                $("#Quantity").val(0);
                $("#UOM").val("");
                $("#Rate").val(0);

                SalesOrderMasterAndDetails.TotalBillAmount();
                SalesOrderMasterAndDetails.TotalTaxAmount();
                SalesOrderMasterAndDetails.TotalAmount();
                SalesOrderMasterAndDetails.TotalPurchaseAmount();
                SalesOrderMasterAndDetails.TotalPurchaseTaxAmount();
                SalesOrderMasterAndDetails.TotalPurchaseBillAmount();
                

            }

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i.ENQDetail", function () {
                $(this).closest('tr').remove();
                SalesOrderMasterAndDetails.TotalBillAmount();
                SalesOrderMasterAndDetails.TotalTaxAmount();
                SalesOrderMasterAndDetails.TotalAmount();
                SalesOrderMasterAndDetails.TotalPurchaseAmount();
                SalesOrderMasterAndDetails.TotalPurchaseTaxAmount();
                SalesOrderMasterAndDetails.TotalPurchaseBillAmount();
            });

        });

        $("#Units").children().children("#UOM").change(function () {
            
            var selectedItem = $(this).val();
            var ItemNumber = $("#ItemNumber").val();
            var selectedGeneralUnitsID = []
            selectedGeneralUnitsID = $("#GeneralUnitsID").val();
            var GeneralUnitsID = selectedGeneralUnitsID.split('~');
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { "ItemNumber": ItemNumber, "UOM": selectedItem, "GeneralUnitsID": GeneralUnitsID[0] },
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
        });
        InitAnimatedBorder();

        CloseAlert();
    },
    //LoadData method is used to load List of all Uom code where Order unit=1
    LoadData: function (GeneralUnitsID, SalesEnquiryMasterID) {
        
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             data: { GeneralUnitsID: GeneralUnitsID, SalesEnquiryMasterID: SalesEnquiryMasterID },
             url: '/SalesOrderMasterAndDetails/CreateSalesQuotationByEnquiry',
             success: function (data) {

                 $('#ListViewModel').html(data);

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
             url: '/SalesOrderMasterAndDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    TotalAmount: function () {

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
    TotalPurchaseAmount: function () {
        var a = 0; var x = 0;
        $("#TotalPurchaseAmount").val(0);
        $("#tblData tbody tr td.PurchaseAmount").each(function () {
                x = $(this).text();
                a += parseFloat(x);
        });

        $("#TotalPurchaseAmount").val(a.toFixed(2));
        $("#TotalPurchaseAmount").text(a.toFixed(2));

    },
    TotalPurchaseTaxAmount: function () {
        var a = 0; var x = 0;
        $("#TotalPurchaseTaxAmount").val(0);
        $("#tblData tbody tr td.PurchaseTaxAmount").each(function () {
            x = $(this).text();
            a += parseFloat(x);
        });

        $("#TotalPurchaseTaxAmount").val(a.toFixed(2));
        $("#TotalPurchaseTaxAmount").text(a.toFixed(2));

    },
    TotalPurchaseBillAmount: function () {
        var a = 0; var x = 0;
        $("#TotalPurchaseBillAmount").val(0);
        $("#tblData tbody tr td.PurchaseGrossAmount").each(function () {
            x = $(this).text();
            a += parseFloat(x);
        });

        $("#TotalPurchaseBillAmount").val(a.toFixed(2));
        $("#TotalPurchaseBillAmount").text(a.toFixed(2));

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
    TotalBillAmount: function () {
        
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
            url: '/SalesOrderMasterAndDetails/List',
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
        for (var i = 0; i < TotalRecord; i = i + 11) {
            ParameterXml = ParameterXml + "<row><QuotationDetailID>" + DataArray[i + 8] + "</QuotationDetailID><ItemNumber>" + DataArray[i + 0] + "</ItemNumber><Quantity>" + DataArray[i + 2] + "</Quantity><Rate>" + DataArray[i + 4] + "</Rate><UOM>" + DataArray[i + 3] + "</UOM><GeneralTaxGroupMasterID>" + DataArray[i + 9] + "</GeneralTaxGroupMasterID><TaxAmount>" + DataArray[i + 5] + "</TaxAmount><TaxableAmount>" + DataArray[i + 6] + "</TaxableAmount><NetAmount>" + DataArray[i + 7] + "</NetAmount><RequiredQuantity>" + DataArray[i + 2] + "</RequiredQuantity></row>";
        }
        if (ParameterXml.length > 10)
            SalesOrderMasterAndDetails.ParameterXml = ParameterXml + "</rows>";

        else
            SalesOrderMasterAndDetails.ParameterXml = "";
     
    },

    //Fire ajax call to insert update and delete record

    AjaxCallSalesOrderMasterAndDetails: function () {
        var SalesOrderMasterAndDetailsData = null;

        if (SalesOrderMasterAndDetails.ActionName == "CreateSalesOrder") {

            $("#FormCreateSalesOrder").validate();
            if ($("#FormCreateSalesOrder").valid()) {
                SalesOrderMasterAndDetailsData = null;
                SalesOrderMasterAndDetailsData = SalesOrderMasterAndDetails.GetSalesOrderMasterAndDetails();
                ajaxRequest.makeRequest("/SalesOrderMasterAndDetails/Create", "POST", SalesOrderMasterAndDetailsData, SalesOrderMasterAndDetails.Success, "CreateSalesOrder");
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalesOrderMasterAndDetails: function () {
        var Data = {
        };

        if (SalesOrderMasterAndDetails.ActionName == "CreateSalesOrder") {
            
            Data.CustomerMasterID = $('#CustomerMasterID').val();
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            Data.ContactPersonID = $('#ContactPersonID').val();
            Data.CreditPeriod = $('#CreditPeriod').val();
            Data.CreditPeriodUnit = $('#UnitMasterId').val();
            Data.TitleTo = $('#TitleTo').val();
            Data.TotalAmount = $('#TotalAmount').val();
            Data.SalesEnquiryMasterID = $('#SalesEnquiryMasterID').val();
            Data.TotalBillAmount = $('#TotalBillAmount').val();
            Data.RoundOffAmount = $('#RoundOffAmount').val();
            var selectedUnitsID = [];
            selectedUnitsID = $('#GeneralUnitsID').val().split('~')
            Data.GeneralUnitsID = selectedUnitsID[0];
            Data.SelectedDepartmentID = $('#SelectedDepartmentID').val();
            Data.SalesQuotationMasterID = $('#SalesQuotationMasterID').val();
            Data.PurchaseOrderNumberClient = $('#PurchaseOrderNumberClient').val();
            Data.CreatePR = $('#CreatePR').is(":checked") ? "true" : "false";
            Data.XmlString = SalesOrderMasterAndDetails.ParameterXml
            //Additional
            Data.Flag = 'Quotation Master';
            Data.PurchaseOrderNumberClient = $('#PurchaseOrderNumberClient').val();
            Data.TotalTaxAmount = $('#TotalTaxAmount').val();
            Data.Freight = $('#Freight').val();
            Data.ShippingHandling = $('#ShippingHandling').val();
            Data.Discount = $('#Discount').val();
            Data.TradeIn = $('#TradeIn').val();

        }

        else if (SalesOrderMasterAndDetails.ActionName == "Delete") {

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
            SalesOrderMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};