//this class contain methods related to nationality functionality
var SalesCustomerReciept = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SalesCustomerReciept.constructor();
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
                SalesCustomerReciept.LoadList(TransactionFromDate, TransactionUptoDate);

            }


        });

        $("#btnShowList").unbind("click").on("click", function () {
            var CustomerMasterID = $('#CustomerMasterID').val();
            var CustomerBranchMasterID = $('#CustomerBranchMasterID').val();

            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { "CustomerMasterID": CustomerMasterID, "CustomerBranchMasterID": CustomerBranchMasterID },
                url: '/SalesCustomerReciept/GetCustomerWiseInvoiceDetailsForCustomerReciept',
                success: function (data) {
                    $("#tblDataInvoice tbody").html('');
                    $("#PaidAmount").prop("disabled", false);
                    $('#CreditAmount').val(data[0].CreditAmount)
                    $('#CreatedBy').val(data[0].CreatedBy)
                    TotalRecord = data.length;
                    for (var i = 0; i < TotalRecord; i++) {
                        if (data[i]['StatusFlag'] == 0) {
                            var statusflag = "<td><input  type='hidden' value='" + 0 + "'/><span class='btn btn-xs btn-warning statusFlag'>Pending</span></td>"
                        }
                        else if (data[i]['StatusFlag'] == 1) {
                            var statusflag = "<td><input type='hidden' value='" + 1 + "'/><span class='btn btn-xs btn-success statusFlag'>Complete</span></td>"
                        }
                        else if (data[i]['StatusFlag'] == 2) {
                            var statusflag = "<td><input type='hidden' value='" + 2 + "'/><span class='btn btn-xs btn-primary statusFlag'>Partially Paid</span></td>"
                        }

                        $("#tblDataInvoice tbody").append(

                            "<tr>" +
                                 "<td><input id='check_1' type='checkbox' class='check-user' name='checkbox12' ><i class='input-helper'></i></td>" +
                                 "<td><input id='InvoiceDate' type='hidden' value='" + data[i]['InvoiceDate'] + "'/>" + data[i]['InvoiceDate'] + "</td>" +
                                 "<td><input id='InvoiceNumber' type='hidden' value='" + data[i]['InvoiceNumber'] + "'/>" + data[i]['InvoiceNumber'] + "</td>" +
                                 "<td><input id='InvoiceAmount' type='hidden' class ='InvoiceAmount' value='" + data[i]['InvoiceAmount'] + "'/>" + data[i]['InvoiceAmount'] + "</td>" +
                                 "<td><input id='PaidInvoiceAmount' class='PaidInvoiceAmount' type='hidden' value=''/><span>" + 0 + "</span></td>" +
                                  statusflag +
                                  "<td style='display:none'><input id='SalesInvoiceMasterID' class='SalesInvoiceMasterID' type='hidden' value='" + data[i]['SalesInvoiceMasterID'] + "'/>" + data[i]['SalesInvoiceMasterID'] + "</td>" +
                                  

                            "</tr>");
                    }
                    CheckedSingle();
                }

            });
            //aJax call 
            //GetCustomerWiseContractDetailsForReciept
        });
        // Create new record
        $('#CreateSalesCustomerRecieptRecord').on("click", function () {

            SalesCustomerReciept.ActionName = "Create";
           
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

            SalesCustomerReciept.GetXmlData();
            if (SalesCustomerReciept.ParameterXml == "" || SalesCustomerReciept.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            } else {
                SalesCustomerReciept.GetXmlDataForAccountVoucher();
                SalesCustomerReciept.AjaxCallSalesCustomerReciept();
            }
        });


        $('#ExpectedBillingAmount').keydown(function (e) {
            AERPValidation.NotAllowSpaces(e);
            AERPValidation.AllowNumbersOnly(e);
        });

        //$("#Cash").on("change click", function () {
        //   
        //    $("#BankDetails").hide();
        //});
        //$("#Bank").on("change click", function () {
        //   
        //    $("#BankDetails").show();
        //});

        $('input:radio[name=payementmode]').on("click", function () {
            var payementmode = $('input:radio[name=payementmode]:checked').val()
            if (payementmode == "True") {
                $("#BankDetails").hide();
            }
            else {
                $("#BankDetails").show();
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

                    PaidAmount = parseFloat(parseFloat(PaidAmount) - parseFloat(InvoiceAmount)).toFixed(2);
                    $(this).val(InvoiceAmount);
                    $(this).next('span').text(InvoiceAmount);
                    $(this).parent().next().children('input').val(1);
                    if ($(this).parent().next().children('span').hasClass('btn-warning')) {
                        $(this).parent().next().children('span').removeClass('btn-warning');


                    }
                    if ($(this).parent().next().children('span').hasClass('btn-primary')) {
                        $(this).parent().next().children('span').removeClass('btn-primary');

                    }
                    $(this).parent().next().children('span').addClass('btn-success');
                    $(this).parent().next().children('span').text('Complete');
                    $(this).parent().prev().prev().prev().prev().children().prop("checked", true);
                }

                else {
                    $(this).val(PaidAmount);
                    $(this).next('span').text(PaidAmount);
                    if (PaidAmount == 0) {

                        if ($(this).parent().next().children('span').hasClass('btn-success')) {
                            $(this).parent().next().children('span').removeClass('btn-success');


                        }
                        if ($(this).parent().next().children('span').hasClass('btn-primary')) {
                            $(this).parent().next().children('span').removeClass('btn-primary');

                        }
                        $(this).parent().next().children('span').addClass('btn-warning');
                        $(this).parent().prev().prev().prev().prev().children().prop("checked", false);
                        $(this).parent().next().children('span').text('Pending');
                        $(this).parent().next().children('input').val(0);

                    }
                    else {
                        if ($(this).parent().next().children('span').hasClass('btn-success')) {
                            $(this).parent().next().children('span').removeClass('btn-success');

                        }
                        if ($(this).parent().next().children('span').hasClass('btn-warning')) {
                            $(this).parent().next().children('span').removeClass('btn-warning');


                        }
                        $(this).parent().next().children('span').addClass('btn-primary');
                        $(this).parent().next().children('span').text('Partial');
                        $(this).parent().next().children('input').val(2);
                        $(this).parent().prev().prev().prev().prev().children().prop("checked", true);

                    }
                    PaidAmount = 0;

                }
            });

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
             url: '/SalesCustomerReciept/List',
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
            url: '/SalesCustomerReciept/List',
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
                //    url: '/SalesCustomerReciept/Download',
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
         url: '/SalesCustomerReciept/List',
         success: function (result) {
             //Rebind Grid Data                
             $('#ListViewModel').html(result);
         }
     });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallSalesCustomerReciept: function () {
        var SalesCustomerRecieptData = null;
        if (SalesCustomerReciept.ActionName == "Create") {
           
            $("#FormCreateSalesCustomerRecieptMaster").validate();
            //if ($("#FormCreateSalesCustomerReciept").valid()) {
                SalesCustomerRecieptData = null;
                SalesCustomerRecieptData = SalesCustomerReciept.GetSalesCustomerReciept();
                ajaxRequest.makeRequest("/SalesCustomerReciept/Create", "POST", SalesCustomerRecieptData, SalesCustomerReciept.Success, "CreateSalesCustomerRecieptRecord");
            //}


        }
        else if (SalesCustomerReciept.ActionName == "Edit") {
            $("#FormEditSalesCustomerReciept").validate();
            if ($("#FormEditSalesCustomerReciept").valid()) {
                SalesCustomerRecieptData = null;

                SalesCustomerRecieptData = SalesCustomerReciept.GetSalesCustomerReciept();

                ajaxRequest.makeRequest("/SalesCustomerReciept/Edit", "POST", SalesCustomerRecieptData, SalesCustomerReciept.Success);

            }
        }
        else if (SalesCustomerReciept.ActionName == "Delete") {
            SalesCustomerRecieptData = null;
            //$("#FormCreateSalesCustomerReciept").validate();
            SalesCustomerRecieptData = SalesCustomerReciept.GetSalesCustomerReciept();
            ajaxRequest.makeRequest("/SalesCustomerReciept/Delete", "POST", SalesCustomerRecieptData, SalesCustomerReciept.Success);

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
        for (var i = 0; i < TotalRecord; i = i + 6) {
            if (DataArray[i + 4] != 0) {
                ParameterXml = ParameterXml + "<row><SaleInvoiceMasterID>" + DataArray[i + 5] + "</SaleInvoiceMasterID><SalesnvoiceNumber>" + DataArray[i + 1] + "</SalesnvoiceNumber><Amount>" + DataArray[i + 2] + "</Amount><PaidInvoiceAmount>" + DataArray[i + 3] + "</PaidInvoiceAmount><StatusFlag>" + DataArray[i + 4] + "</StatusFlag></row>";
            }

        }

        if (ParameterXml.length > 10)
            SalesCustomerReciept.ParameterXml = ParameterXml + "</rows>";

        else
            SalesCustomerReciept.ParameterXml = "";

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


        //alert(datetime)
        var Payementmode = $('#payementmode').val()
        if ($('#Cash').is(':checked')) {
            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#CustomerBranchMasterID').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtCRCash</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + $('#PaidAmount').val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
        }
        else {
            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#CustomerBranchMasterID').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtCRBank</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + $('#PaidAmount').val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
        }

        ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#CustomerBranchMasterID').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtCRReceivable</ControlName><DebitCreditStatus>0</DebitCreditStatus><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><Amount>-" + $('#PaidAmount').val() + "</Amount><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

        //  alert(ParameterXml)
        if (ParameterXml.length > 7) {
            SalesCustomerReciept.XMLstringForVouchar = ParameterXml + "</rows>";

        }
        else {
            SalesCustomerReciept.XMLstringForVouchar = "";
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetSalesCustomerReciept: function () {

        var Data = {
        };
        if (SalesCustomerReciept.ActionName == "Create") {

            Data.CustomerMasterID = $('#CustomerMasterID').val();
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            Data.XMLstring = SalesCustomerReciept.ParameterXml;
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
            Data.XMLstringForVouchar = SalesCustomerReciept.XMLstringForVouchar;
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
            SalesCustomerReciept.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

