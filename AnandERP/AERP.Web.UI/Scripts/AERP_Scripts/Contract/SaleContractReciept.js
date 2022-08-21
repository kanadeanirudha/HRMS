//this class contain methods related to nationality functionality
var SaleContractReciept = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractReciept.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#contactPerson").hide();
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        //Show Button on List View
        $('#btnShowListforList').unbind('click').click(function () {

            var TransactionFromDate = $('#TransactionFromDate').val();
            var TransactionUptoDate = $('#TransactionUptoDate').val();
            if (TransactionUptoDate == " " || TransactionUptoDate == null) {
                notify("Please Transaction Upto Date", "danger");
            }
            else if (TransactionFromDate == "" || TransactionFromDate == null) {
                notify("Please Transaction From Date", "danger");
                // $('#DivCreateNew').hide(true);
            }
            else if (TransactionUptoDate != "" && TransactionFromDate != "") {
                SaleContractReciept.LoadList(TransactionFromDate, TransactionUptoDate);
            }
        });


        $("#btnShowList").unbind("click").on("click", function () {

            var CustomerMasterID = $('#CustomerMasterID').val();
            var CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            var ContractMasterID = $('#ContractMasterID').val();
            var SaleContractBillingSpanID = $('#SaleContractBillingSpanID').val();
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { "CustomerMasterID": CustomerMasterID, "CustomerBranchMasterID": CustomerBranchMasterID, "ContractMasterID": ContractMasterID, "SaleContractBillingSpanID": SaleContractBillingSpanID },
                url: '/SaleContractReciept/GetCustomerWiseContractDetailsForReciept',
                success: function (data) {
                    $("#PaidAmount").prop("disabled", false);
                    $('#CreditAmount').val(data[0].CreditAmount)
                    $('#CustomerMainBranchMasterID').val(data[0].CustomerMainBranchMasterID)
                    $('#CreatedBy').val(data[0].CreatedBy)
                    $('#tblDataInvoice tbody').html('')
                    TotalRecord = data.length;
                    for (var i = 0; i < TotalRecord; i++) {
                        if (data[i]['StatusFlag'] == 0) {
                            var statusflag = "<td><input  type='hidden' value='" + 10 + "'/><span class='btn btn-xs btn-warning statusFlag'>Pending</span></td>"
                        }
                        else if (data[i]['StatusFlag'] == 1) {
                            var statusflag = "<td><input type='hidden' value='" + 11 + "'/><span class='btn btn-xs btn-success statusFlag'>Complete</span></td>"
                        }
                        else if (data[i]['StatusFlag'] == 2) {
                            var statusflag = "<td><input type='hidden' value='" + 12 + "'/><span class='btn btn-xs btn-primary statusFlag'>Partially Paid</span></td>"
                        }

                        $("#tblDataInvoice tbody").append(

                            "<tr>" +
                                 "<td><input id='check_1' type='checkbox' class='check-user' name='checkbox12' ><i class='input-helper'></i></td>" +
                                 "<td>" + data[i]['InvoiceNumber'] + "</td>" +
                                 "<td><input id='ContractAmount' type='hidden' class ='InvoiceAmount' value='" + data[i]['ContractAmount'] + "'/>" + data[i]['ContractAmount'] + "</td>" +
                                 "<td><input id='PaidInvoiceAmount' class='PaidInvoiceAmount' type='hidden' value=''/><span>" + 0 + "</span></td>" +
                                 "<td><input id='TDS' class='TDS' type='text' value='0' class='form-control' /></td>" +
                                 "<td><input id='Deduction' class='Deduction' type='text' value='0' class='form-control' /></td>" +
                                  statusflag +
                                 "<td style='display:none'><input id='SaleContractMasterID' type='hidden' value='" + data[i]['SaleContractMasterID'] + "'/><input id='InvoiceNumber' type='hidden' value='" + data[i]['InvoiceNumber'] + "'/>" + data[i]['SaleContractMasterID'] + "</td>" +
                            "</tr>");
                    }
                    CheckedSingle();
                }

            });
            //aJax call 
            //GetCustomerWiseContractDetailsForReciept
        });
        // Create new record
        $('#CreateSaleContractRecieptRecord').on("click", function () {

            SaleContractReciept.ActionName = "Create";

            if ($("#CustomerName").val() == "" && ($("#CustomerMasterID").val() == "" || $("#CustomerMasterID").val() == 0)) {
                $("#displayErrorMessage p").text("Plaese Select Customer Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($("#CentreCode").val() == "" || $("#CentreCode").val() == null) {
                $("#displayErrorMessage p").text("Please Select Centre Code").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($("#PaidAmount").val() == "" || $("#PaidAmount").val() == null || $("#PaidAmount").val() == 0 || $("#PaidAmount").val() < 0) {
                $("#displayErrorMessage p").text("Please Enter Paid Amount").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            var payementmode = $('input:radio[name=payementmode]:checked').val()
            if (payementmode == "False") {
                if ($("#BankName").val() == "" || $("#BankName").val() == null) {
                    $("#displayErrorMessage p").text("Please Enter Bank Name").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
                else if ($("#IFSCCode").val() == "" || $("#IFSCCode").val() == null) {
                    $("#displayErrorMessage p").text("Please Enter IFSC Code").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
                else if ($("#ChequeNumber").val() == "" || $("#ChequeNumber").val() == null) {
                    $("#displayErrorMessage p").text("Please Enter Cheque Number").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
            }

            SaleContractReciept.GetXmlData();
            if (SaleContractReciept.ParameterXml == "" || SaleContractReciept.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            } else {
                SaleContractReciept.GetXmlDataForAccountVoucher();
                SaleContractReciept.AjaxCallSaleContractReciept();
            }
        });


        $('#ExpectedBillingAmount').keydown(function (e) {
            AERPValidation.NotAllowSpaces(e);
            AERPValidation.AllowNumbersOnly(e);
        });
        $('input:radio[name=payementmode]').on("click", function () {
            var payementmode = $('input:radio[name=payementmode]:checked').val()
            if (payementmode == "True") {
                $("#BankDetails").hide();
            }
            else {
                $("#BankDetails").show();
            }
        });
        $("#IsMainBranch").on("click", function () {
            var IsMainBranch = $("#IsMainBranch").is(":checked") ? "true" : "false";
            if (IsMainBranch == "false") {
                $('.PayementModeFlag').prop('disabled', false);
                $("#BankDetails").hide();
            }
            else {
                $('.PayementModeFlag').attr("disabled", "disabled");
                $("#BankDetails").hide();
            }
        });

        $("#PaidAmount").on("keyup", function () {

            var PaidAmount = $("#PaidAmount").val();
            if (PaidAmount == "") {
                PaidAmount = 0
            }
            $('#tblDataInvoice tbody tr td .PaidInvoiceAmount').each(function () {
                var InvoiceAmount = parseFloat($(this).parent().prev().children().val());
                if (parseFloat(PaidAmount) >= parseFloat(InvoiceAmount)) {
                   // PaidAmount = parseFloat(parseFloat(PaidAmount) - parseFloat(InvoiceAmount)).toFixed(2);
                    //$(this).val(InvoiceAmount);
                    //$(this).next('span').text(InvoiceAmount);

                    $(this).val(PaidAmount);
                    $(this).next('span').text(PaidAmount);

                    $(this).parent().next().next().next().children('input').val(1);
                    if ($(this).parent().next().next().next().children('span').hasClass('btn-warning')) {
                        $(this).parent().next().next().next().children('span').removeClass('btn-warning');

                    }
                    if ($(this).parent().next().next().next().children('span').hasClass('btn-primary')) {
                        $(this).parent().next().next().next().children('span').removeClass('btn-primary');

                    }
                    $(this).parent().next().next().next().children('span').addClass('btn-success');
                    $(this).parent().next().next().next().children('span').text('Complete');
                    $(this).parent().prev().prev().prev().prev().prev().children().prop("checked", true);
                }

                else {
                    $(this).val(PaidAmount);
                    $(this).next('span').text(PaidAmount);
                    if (PaidAmount == 0) {

                        if ($(this).parent().next().next().next().children('span').hasClass('btn-success')) {
                            $(this).parent().next().next().next().children('span').removeClass('btn-success');
                        }
                        if ($(this).parent().next().next().next().children('span').hasClass('btn-primary')) {
                            $(this).parent().next().next().next().children('span').removeClass('btn-primary');

                        }
                        $(this).parent().next().next().next().children('span').addClass('btn-warning');
                        $(this).parent().prev().prev().prev().prev().prev().children().prop("checked", false);
                        $(this).parent().next().next().next().children('span').text('Pending');
                        $(this).parent().next().next().next().children('input').val(0);

                    }
                    else {
                        if ($(this).parent().next().next().next().children('span').hasClass('btn-success')) {
                            $(this).parent().next().next().next().children('span').removeClass('btn-success');

                        }
                        if ($(this).parent().next().next().next().children('span').hasClass('btn-warning')) {
                            $(this).parent().next().next().next().children('span').removeClass('btn-warning');
                        }
                        $(this).parent().next().next().next().children('span').addClass('btn-primary');
                        $(this).parent().next().next().next().children('span').text('Partial');
                        $(this).parent().next().next().next().children('input').val(2);
                        $(this).parent().prev().prev().prev().prev().prev().children().prop("checked", true);

                    }
                    PaidAmount = 0;

                }
            });

        });
        $('#tblDataInvoice tbody').on("keyup", ".TDS", function () {

            var PaidInvoiceAmount = parseFloat($(this).parent().prev().children().val());
            var TDS = parseFloat($(this).val());

            if (isNaN(TDS) || TDS == "") {
                TDS = 0
                $(this).val(0)
            }

            var PaidAmount = parseFloat($(this).parent().prev().prev().children().val());
            if (PaidAmount == "") {
                PaidAmount = 0
            }
            var InvoiceAmount = parseFloat(PaidInvoiceAmount + TDS).toFixed(2);

            if (parseFloat(PaidAmount) == parseFloat(InvoiceAmount)) {
                $(this).parent().next().next().children('input').val(1);
                if ($(this).parent().next().next().children('span').hasClass('btn-warning')) {
                    $(this).parent().next().next().children('span').removeClass('btn-warning');


                }
                if ($(this).parent().next().next().children('span').hasClass('btn-primary')) {
                    $(this).parent().next().next().children('span').removeClass('btn-primary');

                }
                $(this).parent().next().next().children('span').addClass('btn-success');
                $(this).parent().next().next().children('span').text('Complete');
                $(this).parent().prev().prev().prev().prev().prev().children().prop("checked", true);
            }
            else if (parseFloat(PaidAmount) < parseFloat(InvoiceAmount)) {

                if ($(this).parent().next().next().children('span').hasClass('btn-success')) {
                    $(this).parent().next().next().children('span').removeClass('btn-success');


                }
                if ($(this).parent().next().next().children('span').hasClass('btn-primary')) {
                    $(this).parent().next().next().children('span').removeClass('btn-primary');

                }
                $(this).parent().next().next().children('span').addClass('btn-warning');
                $(this).parent().prev().prev().prev().prev().prev().children().prop("checked", false);
                $(this).parent().next().next().children('span').text('Pending');
                $(this).parent().next().next().children('input').val(0);

            }
            else if (parseFloat(PaidAmount) > parseFloat(InvoiceAmount)) {
                if ($(this).parent().next().next().children('span').hasClass('btn-success')) {
                    $(this).parent().next().next().children('span').removeClass('btn-success');

                }
                if ($(this).parent().next().next().children('span').hasClass('btn-warning')) {
                    $(this).parent().next().next().children('span').removeClass('btn-warning');
                }
                $(this).parent().next().next().children('span').addClass('btn-primary');
                $(this).parent().next().next().children('span').text('Partial');
                $(this).parent().next().next().children('input').val(2);
                $(this).parent().prev().prev().prev().prev().prev().children().prop("checked", true);
            }
            PaidAmount = 0;
        });
        $('#tblDataInvoice tbody').on("keyup", ".Deduction", function () {

            var PaidInvoiceAmount = parseFloat($(this).parent().prev().prev().children().val());
            var TDS = parseFloat($(this).parent().prev().children().val());
            var Deduction = parseFloat($(this).val());

            if (isNaN(Deduction) || Deduction == "") {
                Deduction = 0
            }
            var PaidAmount = parseFloat($(this).parent().prev().prev().prev().children().val());
            if (PaidAmount == "") {
                PaidAmount = 0
            }
            var InvoiceAmount = parseFloat(PaidInvoiceAmount + TDS + Deduction).toFixed(2);

            if (parseFloat(PaidAmount) == parseFloat(InvoiceAmount)) {
                $(this).parent().next().children('input').val(1);
                if ($(this).parent().next().children('span').hasClass('btn-warning')) {
                    $(this).parent().next().children('span').removeClass('btn-warning');


                }
                if ($(this).parent().next().children('span').hasClass('btn-primary')) {
                    $(this).parent().next().children('span').removeClass('btn-primary');

                }
                $(this).parent().next().children('span').addClass('btn-success');
                $(this).parent().next().children('span').text('Complete');
                $(this).parent().prev().prev().prev().prev().prev().children().prop("checked", true);
            }
            else if (parseFloat(PaidAmount) < parseFloat(InvoiceAmount)) {

                if ($(this).parent().next().children('span').hasClass('btn-success')) {
                    $(this).parent().next().children('span').removeClass('btn-success');


                }
                if ($(this).parent().next().children('span').hasClass('btn-primary')) {
                    $(this).parent().next().children('span').removeClass('btn-primary');

                }
                $(this).parent().next().children('span').addClass('btn-warning');
                $(this).parent().prev().prev().prev().prev().prev().children().prop("checked", false);
                $(this).parent().next().children('span').text('Pending');
                $(this).parent().next().children('input').val(0);

            }
            else if (parseFloat(PaidAmount) > parseFloat(InvoiceAmount)) {
                if ($(this).parent().next().children('span').hasClass('btn-success')) {
                    $(this).parent().next().children('span').removeClass('btn-success');

                }
                if ($(this).parent().next().children('span').hasClass('btn-warning')) {
                    $(this).parent().next().children('span').removeClass('btn-warning');
                }
                $(this).parent().next().children('span').addClass('btn-primary');
                $(this).parent().next().children('span').text('Partial');
                $(this).parent().next().children('input').val(2);
                $(this).parent().prev().prev().prev().prev().prev().children().prop("checked", true);
            }
            PaidAmount = 0;
        });

        InitAnimatedBorder();

        CloseAlert();

    },

    CheckedAll: function () {
        $("#tblDataInvoice thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#tblDataInvoice tbody tr td  input[class='check-user']").prop("checked", true);
            }
            else {
                $("#tblDataInvoice tbody tr td  input[class='check-user']").prop("checked", false);
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
             url: '/SaleContractReciept/List',
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
            url: '/SaleContractReciept/List',
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
                //    url: '/SaleContractReciept/Download',
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
         url: '/SaleContractReciept/List',
         success: function (result) {
             //Rebind Grid Data                
             $('#ListViewModel').html(result);
         }
     });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractReciept: function () {
        var SaleContractRecieptData = null;
        if (SaleContractReciept.ActionName == "Create") {

            $("#FormCreateSaleContractReciept").validate();
            //if ($("#FormCreateSaleContractReciept").valid()) {


            SaleContractRecieptData = null;
            SaleContractRecieptData = SaleContractReciept.GetSaleContractReciept();
            ajaxRequest.makeRequest("/SaleContractReciept/Create", "POST", SaleContractRecieptData, SaleContractReciept.Success, "CreateSaleContractRecieptRecord");
            //}


        }
        else if (SaleContractReciept.ActionName == "Edit") {
            $("#FormEditSaleContractReciept").validate();
            if ($("#FormEditSaleContractReciept").valid()) {
                SaleContractRecieptData = null;

                SaleContractRecieptData = SaleContractReciept.GetSaleContractReciept();

                ajaxRequest.makeRequest("/SaleContractReciept/Edit", "POST", SaleContractRecieptData, SaleContractReciept.Success);

            }
        }
        else if (SaleContractReciept.ActionName == "Delete") {
            SaleContractRecieptData = null;
            //$("#FormCreateSaleContractReciept").validate();
            SaleContractRecieptData = SaleContractReciept.GetSaleContractReciept();
            ajaxRequest.makeRequest("/SaleContractReciept/Delete", "POST", SaleContractRecieptData, SaleContractReciept.Success);

        }
    },
    GetXmlData: function () {

        var DataArray = [];
        //CustomerMaster.flag = true;

        $('#tblDataInvoice tbody tr td input').each(function () {
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
        for (var i = 0; i < TotalRecord; i = i + 7) {
            if (parseFloat(parseFloat(parseFloat(DataArray[i + 3]) + parseFloat(DataArray[i + 1]) + parseFloat(DataArray[i + 2]))).toFixed(2) > parseFloat(DataArray[i + 0]).toFixed(2)) {
                $("#displayErrorMessage").text("Please check TDS,Deduction and Paid Amount.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            if (DataArray[i + 4] != 0) {
                ParameterXml = ParameterXml + "<row><SaleContractMasterID>" + DataArray[i + 5] + "</SaleContractMasterID><InvoiceNumber>" + DataArray[i + 6] + "</InvoiceNumber><Amount>" + DataArray[i + 0] + "</Amount><PaidContactAmount>" + DataArray[i + 1] + "</PaidContactAmount><StatusFlag>" + DataArray[i + 4] + "</StatusFlag><SaleContractBillingSpanID>" + $("#SaleContractBillingSpanID").val() + "</SaleContractBillingSpanID><TDS>" + DataArray[i + 2] + "</TDS><Deduction>" + DataArray[i + 3] + "</Deduction></row>";
            }

        }
        if (ParameterXml.length > 10)
            SaleContractReciept.ParameterXml = ParameterXml + "</rows>";
        else
            SaleContractReciept.ParameterXml = "";
    },

    GetXmlDataForAccountVoucher: function () {

        var DataArray = [];
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

        var IsMainBranch = $('#IsMainBranch').is(":checked") ? "true" : "false";
        var TDS = 0; var Deduction = 0; var PaidInvoiceAmount = 0;
        $('.TDS').each(function () {
            TDS = parseFloat(parseFloat(TDS) + parseFloat($(this).val()));
        });
        $('.Deduction').each(function () {
            Deduction = parseFloat(parseFloat(Deduction) + parseFloat($(this).val()));
        });
        $('.PaidInvoiceAmount').each(function () {
            PaidInvoiceAmount = parseFloat(parseFloat(PaidInvoiceAmount) + parseFloat($(this).val()));
        });

        //alert(datetime)
        if (IsMainBranch == "false") {
            if ($('#Cash').is(':checked')) {
                ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#CustomerBranchMasterID').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCRCash</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + $('#PaidAmount').val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            }
            else {
                ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#CustomerBranchMasterID').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCRBank</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + $('#PaidAmount').val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
            }
        }
        else {

            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#CustomerBranchMasterID').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCRReceivable</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + $('#PaidAmount').val() + "</Amount><PersonID>" + $('#CustomerMainBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";


        }
        ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#CustomerBranchMasterID').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCRTDSDeducted</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + TDS + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

        ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#CustomerBranchMasterID').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCRDeduction</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + Deduction + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

        ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#CustomerBranchMasterID').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCRReceivable</ControlName><DebitCreditStatus>0</DebitCreditStatus><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><Amount>-" + parseFloat(parseFloat(PaidInvoiceAmount) + parseFloat(TDS) + parseFloat(Deduction)).toFixed(2) + "</Amount><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

        alert(ParameterXml)
        if (ParameterXml.length > 7) {
            SaleContractReciept.XMLstringForVouchar = ParameterXml + "</rows>";

        }
        else {
            SaleContractReciept.XMLstringForVouchar = "";
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractReciept: function () {

        var Data = {
        };
        if (SaleContractReciept.ActionName == "Create") {

            Data.CustomerMasterID = $('#CustomerMasterID').val();
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            Data.XMLstring = SaleContractReciept.ParameterXml;
            Data.payementmode = $('#payementmode').val();
            if ($('#Cash').is(':checked')) {
                Data.payementmode = "1";
            }
            else if ($('#Bank').is(':checked')) {
                Data.payementmode = "2";
            }
            Data.CentreCode = $('#CentreCode').val();
            Data.CreditAmount = $('#CreditAmount').val();
            Data.PaidAmount = $('#PaidAmount').val();
            Data.XMLstringForVouchar = SaleContractReciept.XMLstringForVouchar;
            Data.BankName = $('#BankName').val();
            Data.BranchName = $('#BranchName').val();
            Data.BankAddress = $('#BankAddress').val();
            Data.AccountNo = $('#AccountNo').val();
            Data.IFSCCode = $('#IFSCCode').val();
            Data.ChequeNumber = $('#ChequeNumber').val();
        }

        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            SaleContractReciept.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

