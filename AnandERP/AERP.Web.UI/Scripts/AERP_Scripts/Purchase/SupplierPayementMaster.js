//this class contain methods related to nationality functionality
var SupplierPayementMaster = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SupplierPayementMaster.constructor();
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



            SupplierPayementMaster.LoadListByPurchaseOrderType($('#PurchaseOrderType :selected').val());

        });
        // Create new record
        $('#CreateSupplierPayementMasterRecord').on("click", function () {

            SupplierPayementMaster.ActionName = "Create";

            if ($("#vendor").val() == "" || $("#vendor").val() == null || $("VendorId").val() == 0) {
                notify("Please Select Vendor", "warning");
                return false;
            }
            else if ($("#CentreCode").val() == "" || $("#CentreCode").val() == null) {
                notify("Please Select Centre Code", "warning");
                return false;
            }
            else if ($("#PaidAmount").val() == "" || $("#PaidAmount").val() == null || $("#PaidAmount").val() == 0 || $("#PaidAmount").val() < 0) {
                notify("Please Select Paid Amonnt", "warning");
                return false;
            }
            if ($('#Bank').is(':checked')) {
                if ($("#BankName").val() == "" || $("#BankName").val() == null) {
                    notify("Please Enter Bank Name", "warning");
                    return false;
                }
                else if ($("#IFSCCode").val() == "" || $("#IFSCCode").val() == null) {
                    notify("Please Enter IFSC Code", "warning");
                    return false;
                }
                else if ($("#ChequeNumber").val() == "" || $("#ChequeNumber").val() == null) {
                    notify("Please Enter Cheque Number", "warning");
                    return false;
                }
            }

            SupplierPayementMaster.GetXmlData();
            if (SupplierPayementMaster.ParameterXml == "" || SupplierPayementMaster.ParameterXml == null) {
                notify("No Data Available in table", "warning");
                return false;
            } else {
                SupplierPayementMaster.GetXmlDataForAccountVoucher();
                SupplierPayementMaster.AjaxCallSupplierPayementMaster();
            }
        });


        $('#PaidAmount').keydown(function (e) {
            AERPValidation.NotAllowSpaces(e);
            AERPValidation.AllowNumbersWithDecimalOnly(e);
        });

        $("#Cash").on("change click", function () {
            $("#BankDetails").hide();
        });
        $("#Bank").on("change click", function () {
            $("#BankDetails").show();
        });
        $("#PaidAmount").on("keyup", function () {
            var PaidAmount = $("#PaidAmount").val();
            if (PaidAmount == "") {
                PaidAmount = 0;
                return false;
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


    //CheckedAll: function () {
    //    $("#tblDataInvoice thead tr th input[class='checkall-user']").on('click', function () {
    //        var $this = $(this);
    //        if ($this.is(":checked")) {
    //            $("#tblDataInvoice tbody tr td  input[class='check-user']").prop("checked", true);
    //        }
    //        else {
    //            $("#tblDataInvoice tbody tr td  input[class='check-user']").prop("checked", false);
    //        }
    //    });
    //},
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/SupplierPayementMaster/List',
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
         url: '/SupplierPayementMaster/List',
         success: function (result) {
             //Rebind Grid Data                
             $('#ListViewModel').html(result);
         }
     });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallSupplierPayementMaster: function () {
        var SupplierPayementMasterData = null;
        if (SupplierPayementMaster.ActionName == "Create") {

            $("#FormCreateSupplierPayementMaster").validate();
            //if ($("#FormCreateSupplierPayementMaster").valid()) {
            SupplierPayementMasterData = null;
            SupplierPayementMasterData = SupplierPayementMaster.GetSupplierPayementMaster();
            ajaxRequest.makeRequest("/SupplierPayementMaster/Create", "POST", SupplierPayementMasterData, SupplierPayementMaster.Success, "CreateSupplierPayementMasterRecord");
            //}


        }
        else if (SupplierPayementMaster.ActionName == "Edit") {
            $("#FormEditSupplierPayementMaster").validate();
            if ($("#FormEditSupplierPayementMaster").valid()) {
                SupplierPayementMasterData = null;

                SupplierPayementMasterData = SupplierPayementMaster.GetSupplierPayementMaster();

                ajaxRequest.makeRequest("/SupplierPayementMaster/Edit", "POST", SupplierPayementMasterData, SupplierPayementMaster.Success);

            }
        }
        else if (SupplierPayementMaster.ActionName == "Delete") {
            SupplierPayementMasterData = null;
            //$("#FormCreateSupplierPayementMaster").validate();
            SupplierPayementMasterData = SupplierPayementMaster.GetSupplierPayementMaster();
            ajaxRequest.makeRequest("/SupplierPayementMaster/Delete", "POST", SupplierPayementMasterData, SupplierPayementMaster.Success);

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
                ParameterXml = ParameterXml + "<row><PurchaseInvoiceMasterID>" + DataArray[i + 5] + "</PurchaseInvoiceMasterID><InvoiceNumber>" + DataArray[i + 0] + "</InvoiceNumber><Amount>" + DataArray[i + 2] + "</Amount><PaidInvoiceAmount>" + DataArray[i + 3] + "</PaidInvoiceAmount><StatusFlag>" + DataArray[i + 4] + "</StatusFlag></row>";
            }

        }

        if (ParameterXml.length > 10)
            SupplierPayementMaster.ParameterXml = ParameterXml + "</rows>";

        else
            SupplierPayementMaster.ParameterXml = "";

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
            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorId').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSPCash</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + $('#PaidAmount').val() + "</Amount><PersonID>" + $('#VendorId').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate><BankName></BankName></row>";
        }
        else {
            ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorId').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSPBank</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + $('#PaidAmount').val() + "</Amount><PersonID>" + $('#VendorId').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate><BankName>" + $('#BankName').val() + "</BankName></row>";
        }

        ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorId').val() + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSpVendorAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><PersonID>" + $('#VendorId').val() + "</PersonID><PersonType>U</PersonType><Amount>" + $('#PaidAmount').val() + "</Amount><CreatedBy>" + $('#CreatedBy').val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate><BankName></BankName></row>";

        //  alert(ParameterXml)
        if (ParameterXml.length > 7) {
            SupplierPayementMaster.XMLstringForVouchar = ParameterXml + "</rows>";

        }
        else {
            SupplierPayementMaster.XMLstringForVouchar = "";
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetSupplierPayementMaster: function () {

        var Data = {
        };
        if (SupplierPayementMaster.ActionName == "Create") {
            Data.VendorId = $('#VendorId').val();
            Data.XMLstring = SupplierPayementMaster.ParameterXml;
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
            Data.XMLstringForVouchar = SupplierPayementMaster.XMLstringForVouchar;
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
            SupplierPayementMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

