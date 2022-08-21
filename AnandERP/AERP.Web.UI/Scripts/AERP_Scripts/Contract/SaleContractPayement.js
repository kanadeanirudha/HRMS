//this class contain methods related to nationality functionality
var SaleContractPayement = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractPayement.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#contactPerson").hide();
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        $("#btnShowList").unbind("click").on("click", function () {



            var SaleContractBillingSpanID = $('#SaleContractBillingSpanID').val();
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { "SaleContractBillingSpanID": SaleContractBillingSpanID },
                url: '/SaleContractPayement/GetSaleContractEmployeeByBillingSpanForPayement',
                success: function (data) {
                    $("#tblDataInvoice tbody").html('');
                    $('#PaidAmount').val(0);
                    if (data.length > 0) {
                        var PaidAmount = 0;
                        $('#CreatedBy').val(data[0].CreatedBy);
                        TotalRecord = data.length;
                        for (var i = 0; i < TotalRecord; i++) {
                            
                            if ((data[i]['BankAccountFlag']) == 'CashAccount') {
                                var Flag = "<td><input id='check_1' type='checkbox' class='check-user' name='checkbox12' checked><i class='input-helper'></i></td>"
                                PaidAmount = parseFloat(parseFloat(PaidAmount) + parseFloat(data[i]['NetPayable'])).toFixed(2);
                            }
                            else {
                                var Flag = "<td><input id='check_1' type='checkbox' class='check-user' name='checkbox12'><i class='input-helper'></i></td>"
                            }
                            $("#tblDataInvoice tbody").append(
                                "<tr>" +
                                     Flag +
                                     "<td><input id='ContractEmployeeName' type='hidden' value='" + data[i]['SaleContractEmployeeMasterID'] + "'/>" + data[i]['ContractEmployeeName'] + "</td>" +
                                     "<td><input id='NetPayable' type='hidden' value='" + data[i]['NetPayable'] + "'/>" + data[i]['NetPayable'] + "</td>" +
                                     "<td  style='display:none' class='AccountFlag'><span>" + data[i]['BankAccountFlag'] + "</span></td>" +
                                "</tr>");
                        }
                        $('#PaidAmount').val(PaidAmount);
                        CheckedSingle();
                    }
                    else {

                        notify("Attendance is not Entered for this selected span", "warning");
                    }
                }


            });
            //aJax call 
            //GetCustomerWiseContractDetailsForReciept
        });
        // Create new record
        $('#CreateSaleContractPayementRecord').on("click", function () {

            SaleContractPayement.ActionName = "Create";

            if ($("#CustomerName").val() == "" && ($("#CustomerMasterID").val() == "" || $("#CustomerMasterID").val() == 0)) {
                $("#displayErrorMessage p").text("Plaese Select Customer Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
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

            SaleContractPayement.GetXmlData();
            if (SaleContractPayement.ParameterXml == "" || SaleContractPayement.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            } else {
                SaleContractPayement.GetXmlDataForAccountVoucher();
                SaleContractPayement.AjaxCallSaleContractPayement();
            }
        });


        $('#ExpectedBillingAmount').keydown(function (e) {
            AERPValidation.NotAllowSpaces(e);
            AERPValidation.AllowNumbersOnly(e);
        });


        $('input:radio[name=payementmode]').on("click", function () {
            
            var payementmode = $('input:radio[name=payementmode]:checked').val()
            var Paidamount = 0;
            if (payementmode == "True") {// cash
                
                $("#BankDetails").hide();
                $("#tblDataInvoice tbody tr td.AccountFlag").each(function () {
                    var BankAccountFlag = $(this).text();
                    var NetPayableAmount = parseFloat($(this).prev().children().val());
                    if (BankAccountFlag == 'CashAccount')
                        {
                        $(this).prev().prev().prev().children().prop("checked", true);
                        Paidamount = Paidamount + NetPayableAmount;
                        $('#PaidAmount').val(Paidamount);
                    }
                    else
                    {
                        $(this).prev().prev().prev().children().prop("checked", false);
                    }
                   
                });

            }
            else {
                
                $("#BankDetails").show();
                $("#tblDataInvoice tbody tr td.AccountFlag").each(function () {
                    var BankAccountFlag = $(this).text();
                    var NetPayableAmount = parseFloat($(this).prev().children().val());

                    if (BankAccountFlag == 'CashAccount') {
                        $(this).prev().prev().prev().children().prop("checked", false);
                    }
                    else {
                        
                        Paidamount = Paidamount + NetPayableAmount;
                        $('#PaidAmount').val(Paidamount);
                        $(this).prev().prev().prev().children().prop("checked", true);
                    }

                });
            }
        });


        function CheckedSingle() {
            var totalpaidamount;
            $("#tblDataInvoice tbody tr td  input[class='check-user']").on('click', function () {

                var CheckedArray = [];
                var PaidAmount = 0;
                $("input[class='check-user']").each(function () {

                    CheckedArray.push($(this).val());
                    var $this = $(this);
                    if ($this.is(":checked")) {
                        var PayableAmount = parseFloat($(this).parent().next().next().children().val());
                        PaidAmount = parseFloat(parseFloat(PaidAmount) + parseFloat(PayableAmount)).toFixed(2);
                    }

                });
                $("#PaidAmount").val(PaidAmount)


            });
        }

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
             url: '/SaleContractPayement/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {


        notify(message, colorCode);
        window.location.reload();
    },

    LoadListByPurchaseOrderType: function (PurchaseOrderType) {

        $.ajax(
     {
         cache: false,
         type: "POST",
         data: { PurchaseOrderType: PurchaseOrderType },
         dataType: "html",
         url: '/SaleContractPayement/List',
         success: function (result) {
             //Rebind Grid Data                
             $('#ListViewModel').html(result);
         }
     });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractPayement: function () {
        var SaleContractPayementData = null;
        if (SaleContractPayement.ActionName == "Create") {

            $("#FormCreateSaleContractPayement").validate();
            //  if ($("#FormCreateSaleContractPayement").valid()) 
            {
                SaleContractPayementData = null;
                SaleContractPayementData = SaleContractPayement.GetSaleContractPayement();
                ajaxRequest.makeRequest("/SaleContractPayement/Create", "POST", SaleContractPayementData, SaleContractPayement.Success, "CreateSaleContractPayementRecord");
            }


        }
        else if (SaleContractPayement.ActionName == "Edit") {
            $("#FormEditSaleContractPayement").validate();
            if ($("#FormEditSaleContractPayement").valid()) {
                SaleContractPayementData = null;

                SaleContractPayementData = SaleContractPayement.GetSaleContractPayement();

                ajaxRequest.makeRequest("/SaleContractPayement/Edit", "POST", SaleContractPayementData, SaleContractPayement.Success);

            }
        }
        else if (SaleContractPayement.ActionName == "Delete") {
            SaleContractPayementData = null;
            //$("#FormCreateSaleContractPayement").validate();
            SaleContractPayementData = SaleContractPayement.GetSaleContractPayement();
            ajaxRequest.makeRequest("/SaleContractPayement/Delete", "POST", SaleContractPayementData, SaleContractPayement.Success);

        }
    },
    GetXmlData: function () {


        var ParameterXml = "<rows>";
        var CheckedArray = [];
        var SaleContractEmpID; var StatusFlag; var PayableAmount;
        $("input[class='check-user']").each(function () {

            CheckedArray.push($(this).val());
            var $this = $(this);
            if ($this.is(":checked")) {
                StatusFlag = 1;
                SaleContractEmpID = $(this).parent().next().children().val();
                PayableAmount = parseFloat($(this).parent().next().next().children().val());

                ParameterXml = ParameterXml + "<row><ContractEmployeeMasterID>" + SaleContractEmpID + "</ContractEmployeeMasterID><Payement>" + PayableAmount + "</Payement><StatusFlag>" + StatusFlag + "</StatusFlag></row>";

            }

        });


        if (ParameterXml.length > 10)
            SaleContractPayement.ParameterXml = ParameterXml + "</rows>";

        else
            SaleContractPayement.ParameterXml = "";

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
        if ($('#Cash').is(':checked')) {
            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#ContractMasterID').val() + "-" + $('#SaleContractBillingSpanID').val() + "-BulkPayment" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCPCash</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + $('#PaidAmount').val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate><BankName></BankName></row>";
        }
        else {
            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#ContractMasterID').val() + "-" + $('#SaleContractBillingSpanID').val() + "-BulkPayment" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCPBank</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + $('#PaidAmount').val() + "</Amount><PersonID>" + $('#CustomerBranchMasterID').val() + "</PersonID><PersonType>B</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate><BankName>" + $("#BankName").val() + "</BankName></row>";
        }


        $("input[class='check-user']").each(function () {

          
            var $this = $(this);
            if ($this.is(":checked")) {
                StatusFlag = 1;
                SaleContractEmpID = $(this).parent().next().children().val();
                PayableAmount = parseFloat($(this).parent().next().next().children().val());

                ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#ContractMasterID').val() + "-" + $('#SaleContractBillingSpanID').val() +"-BulkPayment"+ "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCPSalaryPayable</ControlName><DebitCreditStatus>1</DebitCreditStatus><PersonID>" + SaleContractEmpID + "</PersonID><PersonType>T</PersonType><Amount>" + PayableAmount + "</Amount><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate><BankName></BankName></row>";

            }

        });



       

        //  alert(ParameterXml)
        if (ParameterXml.length > 7) {
            SaleContractPayement.XMLstringForVouchar = ParameterXml + "</rows>";

        }
        else {
            SaleContractPayement.XMLstringForVouchar = "";
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractPayement: function () {

        var Data = {
        };
        if (SaleContractPayement.ActionName == "Create") {

            Data.CustomerMasterID = $('#CustomerMasterID').val();
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            Data.ContractNumber = $('#ContractNumber').val();
            Data.SaleContractBillingSpanID = $('#SaleContractBillingSpanID').val();
            Data.ContractMasterID = $('#ContractMasterID').val();

            Data.XMLstring = SaleContractPayement.ParameterXml;
            Data.payementmode = $('#payementmode').val();
            if ($('#Cash').is(':checked')) {
                Data.payementmode = "1";
            }
            else if ($('#Bank').is(':checked')) {
                Data.payementmode = "2";
            }
            Data.PaidAmount = $('#PaidAmount').val();
            Data.XMLstringForVouchar = SaleContractPayement.XMLstringForVouchar;
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
            SaleContractPayement.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

