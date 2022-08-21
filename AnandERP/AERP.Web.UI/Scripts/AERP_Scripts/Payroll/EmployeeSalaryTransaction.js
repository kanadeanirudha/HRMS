//this class contain methods related to nationality functionality
var EmployeeSalaryTransaction = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeSalaryTransaction.constructor();
        //EmployeeSalaryTransaction.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#btnShowList").unbind("click").click(function () {
            if ($("#SelectedCentreCode").val() == "") {
                notify("Please select Center", "warning");
                return false;
            }
            if ($("#EmployeeSalarySpanID").val() == "" || $("#EmployeeSalarySpanID").val() == "0") {
                notify("Please select Span", "warning");
                return false;
            }
            EmployeeSalaryTransaction.LoadList();
        });

        $("#CreateEmployeeSalaryTransaction").click(function () {
            EmployeeSalaryTransaction.ActionName = "Create";
            EmployeeSalaryTransaction.GetXmlDataForSalaryTransaction();
            EmployeeSalaryTransaction.GetXmlDataForSalaryAccountVoucher();
            EmployeeSalaryTransaction.AjaxCallEmployeeSalaryTransaction();
        });

        $("#CreateSaleContractBulkSalaryTransaction").click(function () {
            EmployeeSalaryTransaction.ActionName = "BulkCreate";
            EmployeeSalaryTransaction.GetXmlDataForBulkSalaryTransaction();
            EmployeeSalaryTransaction.GetXmlDataForBulkSalaryAccountVoucher();
            EmployeeSalaryTransaction.AjaxCallEmployeeSalaryTransaction();
        });

        $("#CreateSaleContractSalaryDeduction").click(function () {
            EmployeeSalaryTransaction.ActionName = "AddDeduction";

            if ($("#HeadName").val() == "") {
                $("#displayErrorMessage p").text("Please select Deduction.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }

            EmployeeSalaryTransaction.AjaxCallEmployeeSalaryTransaction();
        });

        $("#SelectedCentreCode").change(function () {
          /*  var selectedItem = $(this).val();
            var $ddlDepartment = $("#SelectedDepartmentID");
            var $DepartmentProgress = $("#states-loading-progress");
            $DepartmentProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/PurchaseRequirementMaster/GetDepartmentByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
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
                $('#ListViewModel').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value="">----Select Department----</option>');
            }
            */
        });


       /* $("#SelectedDepartmentID").change(function () {
            $('#ListViewModel').empty();

        });*/

        InitAnimatedBorder();
        CloseAlert();
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",
            data: { "SelectedCentreCode": $("#SelectedCentreCode").val(),"EmployeeSalarySpanID":$("#EmployeeSalarySpanID").val() },
            dataType: "html",
            url: '/EmployeeSalaryTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },

    ReloadList: function (message, colorCode, actionMode) {

        $.ajax({
            cache: false,
            type: "POST",
            data: { "actionMode": actionMode, "SelectedCentreCode": $("#SelectedCentreCode").val(), "EmployeeSalarySpanID": $("#EmployeeSalarySpanID").val() },
            dataType: "html",
            url: '/EmployeeSalaryTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
                notify(message, colorCode);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeSalaryTransaction: function () {
        var EmployeeSalaryTransactionData = null;
        if (EmployeeSalaryTransaction.ActionName == "Create") {
            //$("#FormCreateEmployeeSalaryTransaction").validate();
            //if ($("#FormCreateEmployeeSalaryTransaction").valid()) {
            EmployeeSalaryTransactionData = null;
            EmployeeSalaryTransactionData = EmployeeSalaryTransaction.GetEmployeeSalaryTransaction();
            ajaxRequest.makeRequest("/EmployeeSalaryTransaction/GenerateSalary", "POST", EmployeeSalaryTransactionData, EmployeeSalaryTransaction.Success);
            //}
        } else if (EmployeeSalaryTransaction.ActionName == "BulkCreate") {
            //$("#FormCreateEmployeeSalaryTransaction").validate();
            //if ($("#FormCreateEmployeeSalaryTransaction").valid()) {
            EmployeeSalaryTransactionData = null;
            EmployeeSalaryTransactionData = EmployeeSalaryTransaction.GetEmployeeSalaryTransaction();
            ajaxRequest.makeRequest("/EmployeeSalaryTransaction/GenerateBulkSalary", "POST", EmployeeSalaryTransactionData, EmployeeSalaryTransaction.Success);
            //}
        } else if (EmployeeSalaryTransaction.ActionName == "AddDeduction") {
            
            EmployeeSalaryTransactionData = null;
            EmployeeSalaryTransactionData = EmployeeSalaryTransaction.GetEmployeeSalaryTransaction();
            ajaxRequest.makeRequest("/EmployeeSalaryTransaction/AddDeduction", "POST", EmployeeSalaryTransactionData, EmployeeSalaryTransaction.Success);
            
        }
        
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeSalaryTransaction: function () {
        var Data = {
        };
        if (EmployeeSalaryTransaction.ActionName == "Create") {
            Data.EmployeeSalarySpanID = $("#EmployeeSalarySpanID").val();
            Data.EmployeeMasterID = $("#EmployeeMasterID").val();
            Data.EmployeeSalaryRulesID = $("#EmployeeSalaryRulesID").val();
            Data.AdjustedBasicAmount = $("#AdjustedBasicAmount").val();
            Data.BasicAmount = $("#ActualBasicAmount").val();
            Data.TotalAmount = $("#ActualTotalAmount").val();
            Data.GrossAmount = $("#ActualGrossSalary").val();
            Data.TotalEarnings = $("#ActualTotalEarnings").val();
            Data.TotalDeduction = $("#ActualTotalDeduction").val();
            Data.NetPayable = $("#ActualNetPayable").val();
            Data.EmployerContributionTotal = $("#ActualEmployerContribution").val();
            Data.TotalSalary = $("#ActualTotalSalary").val();
            Data.AdjustedTotalSalary = $("#AdjustedTotalSalary").val();
            Data.AdjustedTotalDays = $("#AdjustedTotalAttendance").val();
            Data.IsRemoveForAdjustment = $("#IsRemoveForAdjustment").is(":checked") ? true : false;
            Data.XMLStringSalaryTransaction = EmployeeSalaryTransaction.XMLStringSalaryTransaction;
            Data.XMLstringForVouchar = EmployeeSalaryTransaction.XMLstringForVouchar;
        } else if (EmployeeSalaryTransaction.ActionName == "BulkCreate") {
            Data.EmployeeSalarySpanID = $("#EmployeeSalarySpanID").val();
            Data.SelectedCentreCode = $("#SelectedCentreCode").val();
            Data.DepartmentMasterID = $("#DepartmentMasterID").val();
            Data.XMLStringBulkSalaryTransactionEmployee = EmployeeSalaryTransaction.XMLStringBulkSalaryTransactionEmployee;
            Data.XMLStringBulkSalaryTransaction = EmployeeSalaryTransaction.XMLStringBulkSalaryTransaction;
            Data.XMLstringForVouchar = EmployeeSalaryTransaction.XMLstringForVouchar;
        } else if (EmployeeSalaryTransaction.ActionName == "AddDeduction") {
            Data.EmployeeMasterID = $("#EmployeeMasterID").val();
            Data.EmployeeSalaryRulesID = $("#EmployeeSalaryRulesID").val();
            Data.SaleContractBillingSpanID = $("#SaleContractBillingSpanID").val();
            Data.SaleContractMasterID = $("#SaleContractMasterID").val();
            Data.HeadName = $("#HeadName").val();
        }
        
        return Data;
    },
    GetXmlDataForSalaryTransaction: function () {

        var ParameterXml = "<rows>";
        $('.ActualTransAmount').each(function () {
            var ActualTransAmount = $(this).val();
            var ActualTransAllowanceID = $(this).next().val();
            var ActualTransDeductionID = $(this).next().next().val();
            var ActualTransIsAllowance = $(this).next().next().next().val();
            var AdjustedAmount = $(this).parent().next().children().val();

            ParameterXml = ParameterXml + "<row><Amount>" + ActualTransAmount + "</Amount><EmployeeSalaryRulesAllowanceID>" + ActualTransAllowanceID + "</EmployeeSalaryRulesAllowanceID><EmployeeSalaryRulesDeductionID>" + ActualTransDeductionID + "</EmployeeSalaryRulesDeductionID><IsAllowance>" + ActualTransIsAllowance + "</IsAllowance><AdjustedAmount>" + AdjustedAmount + "</AdjustedAmount></row>";
        });

        if (ParameterXml.length > 6)
            EmployeeSalaryTransaction.XMLStringSalaryTransaction = ParameterXml + "</rows>";
        else
            EmployeeSalaryTransaction.XMLStringSalaryTransaction = "";
    },
    GetXmlDataForSalaryAccountVoucher: function () {

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

        ParameterXml = ParameterXml + "<row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMBasic</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + $("#AdjustedBasicAmount").val() + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMDA</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + ($(".AdjustedAmountDA").length > 0 ? $(".AdjustedAmountDA").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMHRA</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + ($(".HRA").length > 0 ? $(".HRA").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMLWW</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + ($(".LWW").length > 0 ? $(".LWW").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMREI</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + ($(".AdjustedAmountAllowanceRIA").length > 0 ? $(".AdjustedAmountAllowanceRIA").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMOT</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + ($(".AdjustedAmountAllowanceOT").length > 0 ? $(".AdjustedAmountAllowanceOT").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEPF</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ($(".PF1").length > 0 ? $(".PF1").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSESIC</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ($(".ESIC1").length > 0 ? $(".ESIC1").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSPT</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ($(".AdjustedAmountDeductionPT").length > 0 ? $(".AdjustedAmountDeductionPT").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMP</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ($("#AdjustedSalaryWithAdditionalAllowance").length > 0 ? $("#AdjustedSalaryWithAdditionalAllowance").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEEPFAcc01</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ($(".PF2ACC01").length > 0 ? $(".PF2ACC01").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEEPFAcc10</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ($(".PF2ACC10").length > 0 ? $(".PF2ACC10").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEEPFAcc21</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ($(".PF2ACC21").length > 0 ? $(".PF2ACC21").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSECtoEPF</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + (parseFloat(($(".PF2ACC21").length > 0 ? $(".PF2ACC21").val() : 0)) + parseFloat(($(".PF2ACC10").length > 0 ? $(".PF2ACC10").val() : 0)) + parseFloat(($(".PF2ACC01").length > 0 ? $(".PF2ACC01").val() : 0))) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEEPFAcc22</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ($(".PF2ACC22").length > 0 ? $(".PF2ACC22").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEEPFAcc02</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ($(".PF2ACC02").length > 0 ? $(".PF2ACC02").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSACtoEPF</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + (parseFloat(($(".PF2ACC22").length > 0 ? $(".PF2ACC22").val() : 0)) + parseFloat(($(".PF2ACC02").length > 0 ? $(".PF2ACC02").val() : 0))) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEESIC</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ($(".ESIC2").length > 0 ? $(".ESIC2").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractBillingSpanID").val() + "-" + $("#SaleContractEmployeeMasterID").val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSECtoESIC</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + ($(".ESIC2").length > 0 ? $(".ESIC2").val() : 0) + "</Amount><PersonID>" + $('#SaleContractEmployeeMasterID').val() + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";


        // alert(ParameterXml)
        if (ParameterXml.length > 7) {
            EmployeeSalaryTransaction.XMLstringForVouchar = ParameterXml + "</rows>";
        }
        else {
            EmployeeSalaryTransaction.XMLstringForVouchar = "";
        }

    },
    GetXmlDataForBulkSalaryTransaction: function () {

        var ParameterXml = "<rows>";
        var ParameterXmlTrans = "<rows>";

        $(".EmployeeMasterID").each(function () {
            var EmployeeMasterID = $(this).val();
            var ManPowerItemID = $(this).next('.ManPowerItemID').val();
            var AdjustedTotalAttendance = $(this).parent().next().children('.AdjustedTotalAttendance').val();
            var ActualTotalAttendance = $(this).parent().next().children('.ActualTotalAttendance').val();
            var ActualBasicAmount = $(this).parent().next().next().next().children('.ActualBasicAmount').val();
            var AdjustedBasicAmount = $(this).parent().next().next().next().children('.AdjustedBasicAmount').val();
            var RemoveForAdjustment = $(this).parent().prev().children('.RemoveForAdjustment').is(':checked') ? true : false;
            var TotalAmount = $(this).closest("tr").find("td input.ActualTotalAmount").val();
            var GrossAmount = $(this).closest("tr").find("td input.ActualGrossSalary").val();
            var TotalEarnings = $(this).closest("tr").find("td input.ActualTotalEarnings").val();
            var TotalDeduction = $(this).closest("tr").find("td input.ActualTotalDeduction").val();
            var NetPayable = $(this).closest("tr").find("td input.ActualNetPayable").val();
            var AdjustedNetPayable = $(this).closest("tr").find("td input.AdjustedTotalAmountPayable").val();
            var EmployerContributionTotal = $(this).closest("tr").find("td input.ActualEmployerContribution").val();
            var TotalSalary = $(this).closest("tr").find("td input.ActualTotalSalary").val();
            var AdjustedTotalSalary = $(this).closest("tr").find("td input.AdjustedTotalSalary").val();

            var TotSalary = 0;
            if (AdjustedNetPayable > 0) {
                TotSalary = AdjustedNetPayable;
            }
            else
            {
                TotSalary = TotalSalary
            }

            ParameterXml = ParameterXml + "<row><EmployeeMasterID>" + EmployeeMasterID + "</EmployeeMasterID><ManPowerItemID>" + ManPowerItemID + "</ManPowerItemID><AdjustedTotalAttendance>" + AdjustedTotalAttendance + "</AdjustedTotalAttendance><ActualTotalAttendance>" + ActualTotalAttendance + "</ActualTotalAttendance><RemoveForAdjustment>" + RemoveForAdjustment + "</RemoveForAdjustment><BasicAmount>" + ActualBasicAmount + "</BasicAmount><TotalAmount>" + TotalAmount + "</TotalAmount><GrossAmount>" + GrossAmount + "</GrossAmount><TotalDeduction>" + TotalDeduction + "</TotalDeduction><NetPayable>" + NetPayable + "</NetPayable><AdjustedNetPayable>" + AdjustedNetPayable + "</AdjustedNetPayable><EmployerContributionTotal>" + EmployerContributionTotal + "</EmployerContributionTotal><TotalSalary>" + TotSalary + "</TotalSalary><AdjustedTotalSalary>" + AdjustedTotalSalary + "</AdjustedTotalSalary><AdjustedBasicAmount>" + AdjustedBasicAmount + "</AdjustedBasicAmount><TotalEarnings>" + TotalEarnings + "</TotalEarnings></row>";


            $(this).closest("tr").find('td input.ActualTransAmount').each(function () {
                var ActualTransAmount = $(this).val();
                var ActualTransAllowanceID = $(this).next().val();
                var ActualTransDeductionID = $(this).next().next().val();
                var ActualTransIsAllowance = $(this).next().next().next().val();
                var AdjustedAmount = $(this).next().next().next().next().val();

                ParameterXmlTrans = ParameterXmlTrans + "<row><EmployeeMasterID>" + EmployeeMasterID + "</EmployeeMasterID><Amount>" + ActualTransAmount + "</Amount><EmployeeSalaryRulesAllowanceID>" + ActualTransAllowanceID + "</EmployeeSalaryRulesAllowanceID><EmployeeSalaryRulesDeductionID>" + ActualTransDeductionID + "</EmployeeSalaryRulesDeductionID><IsAllowance>" + ActualTransIsAllowance + "</IsAllowance><AdjustedAmount>" + AdjustedAmount + "</AdjustedAmount><ManPowerItemID>" + ManPowerItemID + "</ManPowerItemID></row>";
            });
        });

        if (ParameterXml.length > 6)
            EmployeeSalaryTransaction.XMLStringBulkSalaryTransactionEmployee = ParameterXml + "</rows>";
        else
            EmployeeSalaryTransaction.XMLStringBulkSalaryTransactionEmployee = "";

        if (ParameterXmlTrans.length > 6)
            EmployeeSalaryTransaction.XMLStringBulkSalaryTransaction = ParameterXmlTrans + "</rows>";
        else
            EmployeeSalaryTransaction.XMLStringBulkSalaryTransaction = "";
    },
    GetXmlDataForBulkSalaryAccountVoucher: function () {

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

        $(".EmployeeMasterID").each(function () {

            if (!$(this).parent().prev().children('.RemoveForAdjustment').is(':checked')) {

                var EmployeeMasterID = $(this).val();
                var AdjustedBasicAmount = $(this).parent().next().next().next().children('.AdjustedBasicAmount').length > 0 ? $(this).parent().next().next().next().children('.AdjustedBasicAmount').val() : 0;
                var AdjustedAmountDA = $(this).closest("tr").find("td input.AdjustedAmountDA").length > 0 ? $(this).closest("tr").find("td input.AdjustedAmountDA").val() : 0;
                var HRA = $(this).closest("tr").find("td input.HRA").length > 0 ? $(this).closest("tr").find("td input.HRA").val() : 0;
                var LWW = $(this).closest("tr").find("td input.LWW").length > 0 ? $(this).closest("tr").find("td input.LWW").val() : 0;
                var AdjustedAmountAllowanceRIA = $(this).closest("tr").find("td input.AdjustedAmountAllowanceRIA").length > 0 ? $(this).closest("tr").find("td input.AdjustedAmountAllowanceRIA").val() : 0;
                var AdjustedAmountAllowanceOT = $(this).closest("tr").find("td input.AdjustedAmountAllowanceOT").length > 0 ? $(this).closest("tr").find("td input.AdjustedAmountAllowanceOT").val() : 0;
                var PF1 = $(this).closest("tr").find("td input.PF1").length > 0 ? $(this).closest("tr").find("td input.PF1").val() : 0;
                var ESIC1 = $(this).closest("tr").find("td input.ESIC1").length > 0 ? $(this).closest("tr").find("td input.ESIC1").val() : 0;
                var AdjustedAmountDeductionPT = $(this).closest("tr").find("td input.AdjustedAmountDeductionPT").length > 0 ? $(this).closest("tr").find("td input.AdjustedAmountDeductionPT").val() : 0;
                var AdjustedTotalAmountPayable = $(this).closest("tr").find("td input.AdjustedSalaryWithAdditionalAllowance").length > 0 ? $(this).closest("tr").find("td input.AdjustedSalaryWithAdditionalAllowance").val() : 0;
                var PF2ACC01 = $(this).closest("tr").find("td input.PF2ACC01").length > 0 ? $(this).closest("tr").find("td input.PF2ACC01").val() : 0;
                var PF2ACC10 = $(this).closest("tr").find("td input.PF2ACC10").length > 0 ? $(this).closest("tr").find("td input.PF2ACC10").val() : 0;
                var PF2ACC21 = $(this).closest("tr").find("td input.PF2ACC21").length > 0 ? $(this).closest("tr").find("td input.PF2ACC21").val() : 0;
                var PF2ACC22 = $(this).closest("tr").find("td input.PF2ACC22").length > 0 ? $(this).closest("tr").find("td input.PF2ACC22").val() : 0;
                var PF2ACC02 = $(this).closest("tr").find("td input.PF2ACC02").length > 0 ? $(this).closest("tr").find("td input.PF2ACC02").val() : 0;
                var ESIC2 = $(this).closest("tr").find("td input.ESIC2").length > 0 ? $(this).closest("tr").find("td input.ESIC2").val() : 0;

                ParameterXml = ParameterXml + "<row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMBasic</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + AdjustedBasicAmount + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMDA</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + AdjustedAmountDA + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMHRA</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + HRA + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMLWW</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + LWW + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMREI</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + AdjustedAmountAllowanceRIA + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMOT</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + AdjustedAmountAllowanceOT + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEPF</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + PF1 + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSESIC</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ESIC1 + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSPT</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + AdjustedAmountDeductionPT + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSSMP</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + AdjustedTotalAmountPayable + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEEPFAcc01</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + PF2ACC01 + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEEPFAcc10</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + PF2ACC10 + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEEPFAcc21</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + PF2ACC21 + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSECtoEPF</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + (parseFloat(PF2ACC21) + parseFloat(PF2ACC10) + parseFloat(PF2ACC01)) + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEEPFAcc22</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + PF2ACC22 + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEEPFAcc02</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + PF2ACC02 + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSACtoEPF</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + (parseFloat(PF2ACC22) + parseFloat(PF2ACC02)) + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSEESIC</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + ESIC2 + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $("#SaleContractMasterID").val() + "-" + $("#SaleContractBillingSpanID").val() + "-BulkPosting" + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSCSECtoESIC</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + ESIC2 + "</Amount><PersonID>" + EmployeeMasterID + "</PersonID><PersonType>T</PersonType><CreatedBy>" + $("#CreatedBy").val() + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
            }
        });
        // alert(ParameterXml)
        if (ParameterXml.length > 7) {
            EmployeeSalaryTransaction.XMLstringForVouchar = ParameterXml + "</rows>";
        }
        else {
            EmployeeSalaryTransaction.XMLstringForVouchar = "";
        }

    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        $.magnificPopup.close();
        if (splitData[1] == 'success') {
            EmployeeSalaryTransaction.ReloadList(splitData[0], splitData[1], splitData[2])
        }
        else {
            notify(splitData[0], splitData[1]);
        }

    },
};

