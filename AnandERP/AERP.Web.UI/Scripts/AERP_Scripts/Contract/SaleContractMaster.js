//this class contain methods related to nationality functionality
var SaleContractMaster = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractMaster.constructor();
        //SaleContractMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        //$('#BillingCycleInDays').on("keydown", function (e) {
        //    AERPValidation.AllowNumbersOnly(e);
        //    AERPValidation.NotAllowSpaces(e);
        //});
        $('#MaterialSupplyDay').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#RenewCallBeforeDays').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#MaterialSupplyFixAmount').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        //$('#SalarySpanStartDay').on("keydown", function (e) {
        //    AERPValidation.AllowNumbersOnly(e);
        //    AERPValidation.NotAllowSpaces(e);
        //});

        //$('#SalarySpanStartDay').on("keyup", function (e) {
        //    if ($("#ContractStartDate").val() == "") {
        //        notify('Please select Contract Start Date and End Date', 'warning');
        //        return false;
        //    }
        //    var now = new Date($("#ContractStartDate").val());
        //    alert(now)
        //    var StartDate = new Date(now.getYear(), now.getMonth() + 1, $(this).val());
        //    alert(StartDate)
        //    //var UptoDate = new Date(StartDate.setMonth(StartDate.getMonth + 1));
        //    //alert(UptoDate)
        //    $('#SalarySpanUptoDay').val(StartDate.getDate());
        //});

        //$('#SalarySpanUptoDay').on("keydown", function (e) {
        //    AERPValidation.AllowNumbersOnly(e);
        //    AERPValidation.NotAllowSpaces(e);
        //});
        $('#SaleContractManPowerItemRequired').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#Quantity').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#Rate').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#SaleContractMachineMasterRequired').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#SaleContractMachineMasterRate').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#SaleContractJobWorkItemRate').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#SaleContractFixItemRate').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#SaleContractFixItemQuantity').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $("#btnCreateList").unbind("click").click(function () {
            SaleContractMaster.LoadSaleContractDetailsHome();
        });
        $("#BackSaleContractMasterRecord").unbind("click").click(function () {
            SaleContractMaster.LoadList();
        });
        $('#ServiceChargesPercentage').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#ServiceChargesFixAmount').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#FixedAmountForInvoice').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#FixedAmountForSalaryCompliance').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#SaleContractServiceItemRate').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

        $('#ModifySaleContractMasterRecord').unbind("click").on("click", function () {

            SaleContractMaster.ActionName = "Modify";

            var TaskCode = $('#TaskCode').val();
            if (TaskCode == 'GeneralModifyContract') {

                SaleContractMaster.GetXmlDataForModifyManPowerServiceCharge();
                SaleContractMaster.GetXmlDataForModifyOverTime();
                SaleContractMaster.GetXmlDataForModifyOverTimeFix();
                SaleContractMaster.GetXmlDataForModifyManPowerItem();
                SaleContractMaster.GetXmlDataForModifyMachine();
                SaleContractMaster.GetXmlDataForModifyJobWorkItem();
                SaleContractMaster.GetXmlDataForModifyFixItem();
                SaleContractMaster.GetXmlDataForModifyServiceItem();

                if (SaleContractMaster.AreAllEmployeeAssigned == 0) {
                    notify("Please assign Contract Employee with Required Number", "warning");
                    return false;
                }
                //else if ($("#EmployeeMasterID").val() == "" || $("#EmployeeMasterID").val() == "0") {
                //    notify("Please select Contract Operational Manager", "warning");
                //    return false;
                //}
            }

            SaleContractMaster.AjaxCallSaleContractMaster();
        });

        $('#ExtendSaleContractMasterRecord').unbind("click").on("click", function () {

            SaleContractMaster.ActionName = "Extend";

            var TaskCode = $('#TaskCode').val();
            if (TaskCode == 'GeneralExtendContract') {

                if ($("#ContractEndDate") == "") {
                    notify("Please Select Contract End Date.", "warning");
                    return false;
                }
            }

            SaleContractMaster.AjaxCallSaleContractMaster();
        });

        $('#ShiftSaleContractMasterEmployee').unbind("click").on("click", function () {

            SaleContractMaster.ActionName = "Shift";

            var TaskCode = $('#TaskCode').val();
            if (TaskCode == 'GeneralShiftEmployee') {

                var IsAllDataPresent = true;
                var IsDataRepeated = false;
                $(".IsReplaceEmployee").each(function () {
                    if ($(this).is(":checked")) {
                        var ReplaceEmpID = $(this).parent().next().children(".ReplaceContractEmployeeID").val();
                        var AssignFromDate = $(this).parent().next().next().children(".ManPowerAssignFromDate").val();
                        var OriginalEmpID = $(this).parent().prev().prev().children(".SaleContractEmployeeMasterID").val();

                        if ((ReplaceEmpID == "0" || ReplaceEmpID == "") || AssignFromDate == "") {
                            IsAllDataPresent = false;
                            return false;
                        }

                        $(".IsReplaceEmployee").each(function () {
                            if ($(this).is(":checked")) {
                                var NewReplaceEmpID = $(this).parent().next().children(".ReplaceContractEmployeeID").val();
                                var CheckOriginalEmpID = $(this).parent().prev().prev().children(".SaleContractEmployeeMasterID").val();
                                if (ReplaceEmpID == NewReplaceEmpID && OriginalEmpID != CheckOriginalEmpID) {
                                    IsDataRepeated = true;
                                    return false;
                                }
                            }
                        })
                    }
                });
                if (IsAllDataPresent == false) {
                    notify("Please select Employee or From Date for the Replacement.", "warning");
                    return false;
                }
                if (IsDataRepeated == true) {
                    notify("Selected Employees are repeated.", "warning");
                    return false;
                }
                SaleContractMaster.GetXMLstringForShiftingEmployee();
            }

            SaleContractMaster.AjaxCallSaleContractMaster();
        });

        $('#RenewSaleContractMasterRecord').unbind("click").on("click", function () {
            SaleContractMaster.ActionName = "Renew";

            var TaskCode = $('#TaskCode').val();
            if (TaskCode == 'GeneralRenewContract') {

                SaleContractMaster.GetXmlDataForContractMaterial();
                SaleContractMaster.GetXmlDataForModifyManPowerItem();
                SaleContractMaster.GetXmlDataForModifyMachine();
                SaleContractMaster.GetXmlDataForModifyJobWorkItem();
                SaleContractMaster.GetXmlDataForModifyFixItem();
                SaleContractMaster.GetXmlDataForManPowerServiceCharge();
                SaleContractMaster.GetXmlDataForManPowerServiceChargeForHead();
                SaleContractMaster.GetXmlDataForOverTime();
                SaleContractMaster.GetXmlDataForOverTimeFix();
                SaleContractMaster.GetXmlDataForModifyServiceItem();

                if ($("#ContractStartDate").val() == "") {
                    notify("Please select Contract Start Date", "warning");
                    return false;
                }
                    //else if ($("#EmployeeMasterID").val() == "" || $("#EmployeeMasterID").val() == "0") {
                    //    notify("Please select Contract Operational Manager", "warning");
                    //    return false;
                    //}
                else if ($("#ContractEndDate").val() == "") {
                    notify("Please select Contract End Date", "warning");
                    return false;
                }
                else if ($("#BillingType").val() == "2" && $("#FixedBillingType").val() == "1" && ($("#BillingFixedAmount").val() == "" || $("#BillingFixedAmount").val() == "0")) {
                    notify("Please Enter Billing Fixed Amount", "warning");
                    return false;
                }
                else if (SaleContractMaster.XMLstringForManPowerItem == "" && SaleContractMaster.XMLstringForAssignedEmployee == "" && SaleContractMaster.XMLstringForMachine == "" && SaleContractMaster.XMLstringForJobWorkItem == "" && SaleContractMaster.XMLstringForServiceItem == "") {
                    notify("Please select Man Power Item or Contract Material or Machine or Job Work Item or Service Item for the Contract", "warning");
                    return false;
                } else if (SaleContractMaster.XMLstringForManPowerItem != "" && SaleContractMaster.XMLstringForAssignedEmployee == "") {
                    notify("Please assign Contract Employee for selected Post", "warning");
                    return false;
                } else if (SaleContractMaster.AreAllEmployeeAssigned == 0) {
                    notify("Please assign Contract Employee with Required Number", "warning");
                    return false;
                }
                    //else if ($("#BillingType").val() == "2" && SaleContractMaster.XMLstringForFixItem == "") {
                    //    notify("Please select Fix Item for Billing Type Fixed Amount", "warning");
                    //    return false;
                    //}
                else if ($("#BillingType").val() == "3" && SaleContractMaster.XMLstringForJobWorkItem == "") {
                    notify("Please select Job Work Item for Billing Type Job Work", "warning");
                    return false;
                } else if ($("#ServiceChargesDependOn").val() == "2" && SaleContractMaster.XMLstringForManPowerServiceCharge == "") {
                    notify("Please enter Service Charge for Man Power Item", "warning");
                    return false;
                } else if ($("#ServiceChargesDependOn").val() == "1" && $("#ServiceChargesPercentage").val() == "") {
                    notify("Please enter Service Charge Percentage", "warning");
                    return false;
                } else if ($("#OverTimeDependOn").val() == "2" && SaleContractMaster.XMLstringForOverTime == "") {
                    notify("Please select Allowances for Over Time", "warning");
                    return false;
                }
            }

            SaleContractMaster.AjaxCallSaleContractMaster();
        });

        InitAnimatedBorder();
        CloseAlert();
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",

            dataType: "html",
            url: '/SaleContractMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    LoadSaleContractDetailsHome: function (SaleContractMasterID, ContractNumber) {

        $.ajax({
            cache: false,
            type: "POST",
            data: { "SaleContractMasterID": SaleContractMasterID, "ContractNumber": ContractNumber },
            dataType: "html",
            url: '/SaleContractMaster/SaleContractDetailsHome',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    //ReloadList method is used to load List page
    ReloadSaleContractDetailsHome: function (message, colorCode, actionMode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/SaleContractMaster/SaleContractDetailsHome',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                notify(message, colorCode);
            }
        });
    },
    Create: function () {
        $('#CreateSaleContractMasterRecord').on("click", function () {

            SaleContractMaster.ActionName = "Create";

            var TaskCode = $('#TaskCode').val();
            if (TaskCode == 'GeneralContractDetails') {

                SaleContractMaster.GetXmlDataForManPowerItem();
                SaleContractMaster.GetXmlDataForContractMaterial();
                SaleContractMaster.GetXmlDataForMachine();
                SaleContractMaster.GetXmlDataForJobWorkItem();
                SaleContractMaster.GetXmlDataForFixItem();
                SaleContractMaster.GetXmlDataForManPowerServiceCharge();
                SaleContractMaster.GetXmlDataForManPowerServiceChargeForHead();
                SaleContractMaster.GetXmlDataForOverTime();
                SaleContractMaster.GetXmlDataForOverTimeFix();
                SaleContractMaster.GetXmlDataForServiceItem();

                if ($("#CentreCode").val() == "") {
                    notify("Please select Centre", "warning");
                    return false;
                }
                else if (($("#CustomerBranchMasterID").val() == "" || $("#CustomerBranchMasterID").val() == "0") && $("#CustomerType").val() == "2") {
                    notify("Please select Customer Branch", "warning");
                    return false;
                }
                else if ($("#CustomerMasterID").val() == "" || $("#CustomerMasterID").val() == "0") {
                    notify("Please select Customer", "warning");
                    return false;
                } else if ($("#CustomerContactPersonID").val() == "" || $("#CustomerContactPersonID").val() == "0") {
                    notify("Please select Contact Person", "warning");
                    return false;
                }
                else if ($("#ContractStartDate").val() == "") {
                    notify("Please select Contract Start Date", "warning");
                    return false;
                }
                else if ($("#ContractEndDate").val() == "") {
                    notify("Please select Contract End Date", "warning");
                    return false;
                }
                else if ($("#BillingType").val() == "2" && $("#FixedBillingType").val() == "1" && ($("#BillingFixedAmount").val() == "" || $("#BillingFixedAmount").val() == "0")) {
                    notify("Please Enter Billing Fixed Amount", "warning");
                    return false;
                }
                else if (SaleContractMaster.XMLstringForManPowerItem == "" && SaleContractMaster.XMLstringForAssignedEmployee == "" && SaleContractMaster.XMLstringForContractMaterial == "" && SaleContractMaster.XMLstringForMachine == "" && SaleContractMaster.XMLstringForJobWorkItem == "" && SaleContractMaster.XMLstringForServiceItem == "") {
                    notify("Please select Man Power Item or Contract Material or Machine or Job Work Item or Service Item for the Contract", "warning");
                    return false;
                } else if (SaleContractMaster.XMLstringForManPowerItem != "" && SaleContractMaster.XMLstringForAssignedEmployee == "") {
                    notify("Please assign Contract Employee for selected Post", "warning");
                    return false;
                } else if (SaleContractMaster.AreAllEmployeeAssigned == 0) {
                    notify("Please assign Contract Employee with Required Number", "warning");
                    return false;
                }
                    //else if ($("#BillingType").val() == "2" && SaleContractMaster.XMLstringForFixItem == "") {
                    //    notify("Please select Fix Item for Billing Type Fixed Amount", "warning");
                    //    return false;
                    //}
                else if ($("#BillingType").val() == "3" && SaleContractMaster.XMLstringForJobWorkItem == "") {
                    notify("Please select Job Work Item for Billing Type Job Work", "warning");
                    return false;
                } else if ($("#ServiceChargesDependOn").val() == "2" && SaleContractMaster.XMLstringForManPowerServiceCharge == "") {
                    notify("Please enter Service Charge for Man Power Item", "warning");
                    return false;
                } else if ($("#ServiceChargesDependOn").val() == "1" && $("#ServiceChargesPercentage").val() == "") {
                    notify("Please enter Service Charge Percentage", "warning");
                    return false;
                } else if ($("#OverTimeDependOn").val() == "2" && SaleContractMaster.XMLstringForOverTime == "") {
                    notify("Please select Allowances for Over Time", "warning");
                    return false;
                }
            }

            SaleContractMaster.AjaxCallSaleContractMaster();
        });
    },
    Save: function () {

        $('#SaveSaleContractMasterRecord').on("click", function () {

            SaleContractMaster.ActionName = "Save";
            var TaskCode = $('#TaskCode').val();

            if (TaskCode == 'GeneralContractDetails') {

                SaleContractMaster.GetXmlDataForManPowerItem();
                SaleContractMaster.GetXmlDataForContractMaterial();
                SaleContractMaster.GetXmlDataForMachine();
                SaleContractMaster.GetXmlDataForJobWorkItem();
                SaleContractMaster.GetXmlDataForFixItem();
                SaleContractMaster.GetXmlDataForManPowerServiceCharge();
                SaleContractMaster.GetXmlDataForManPowerServiceChargeForHead();
                SaleContractMaster.GetXmlDataForOverTime();
                SaleContractMaster.GetXmlDataForOverTimeFix();
                SaleContractMaster.GetXmlDataForServiceItem();

                if ($("#CentreCode").val() == "") {
                    notify("Please select Centre", "warning");
                    return false;
                }
                else if (($("#CustomerBranchMasterID").val() == "" || $("#CustomerBranchMasterID").val() == "0") && $("#CustomerType").val() == "2") {
                    notify("Please select Customer Branch", "warning");
                    return false;
                }
                else if ($("#CustomerMasterID").val() == "" || $("#CustomerMasterID").val() == "0") {
                    notify("Please select Customer", "warning");
                    return false;
                } else if ($("#CustomerContactPersonID").val() == "" || $("#CustomerContactPersonID").val() == "0") {
                    notify("Please select Contact Person", "warning");
                    return false;
                }
                else if ($("#ContractStartDate").val() == "") {
                    notify("Please select Contract Start Date", "warning");
                    return false;
                }
                else if ($("#ContractEndDate").val() == "") {
                    notify("Please select Contract End Date", "warning");
                    return false;
                }
                else if ($("#BillingType").val() == "2" && $("#FixedBillingType").val() == "1" && ($("#BillingFixedAmount").val() == "" || $("#BillingFixedAmount").val() == "0")) {
                    notify("Please Enter Billing Fixed Amount", "warning");
                    return false;
                }
                else if (SaleContractMaster.XMLstringForManPowerItem == "" && SaleContractMaster.XMLstringForAssignedEmployee == "" && SaleContractMaster.XMLstringForContractMaterial == "" && SaleContractMaster.XMLstringForMachine == "" && SaleContractMaster.XMLstringForJobWorkItem == "" && SaleContractMaster.XMLstringForServiceItem == "") {
                    notify("Please select Man Power Item or Contract Material or Machine or Job Work Item or Service Item for the Contract", "warning");
                    return false;
                } else if (SaleContractMaster.XMLstringForManPowerItem != "" && SaleContractMaster.XMLstringForAssignedEmployee == "") {
                    notify("Please assign Contract Employee for selected Post", "warning");
                    return false;
                } else if (SaleContractMaster.AreAllEmployeeAssigned == 0) {
                    notify("Please assign Contract Employee with Required Number", "warning");
                    return false;
                }
                    //else if ($("#BillingType").val() == "2" && SaleContractMaster.XMLstringForFixItem == "") {
                    //    notify("Please select Fix Item for Billing Type Fixed Amount", "warning");
                    //    return false;
                    //}
                else if ($("#BillingType").val() == "3" && SaleContractMaster.XMLstringForJobWorkItem == "") {
                    notify("Please select Job Work Item for Billing Type Job Work", "warning");
                    return false;
                } else if ($("#ServiceChargesDependOn").val() == "2" && SaleContractMaster.XMLstringForManPowerServiceCharge == "") {
                    notify("Please enter Service Charge for Man Power Item", "warning");
                    return false;
                } else if ($("#ServiceChargesDependOn").val() == "1" && $("#ServiceChargesPercentage").val() == "") {
                    notify("Please enter Service Charge Percentage", "warning");
                    return false;
                } else if ($("#OverTimeDependOn").val() == "2" && SaleContractMaster.XMLstringForOverTime == "") {
                    notify("Please select Allowances for Over Time", "warning");
                    return false;
                }
            }

            SaleContractMaster.AjaxCallSaleContractMaster();

        });
    },
    CreateTab: function () {
        $('ul#TaskList li').click(function () {

            if ($("#ID").val() == "0" && $("#ContractNumber").val() == "") {
                return false;
            }

            var Newurl = '';
            var TaskCode = $(this).attr('id');
            var SaleContractMasterID = $('input[name=ID]').val();

            if (TaskCode == "GeneralContractDetails") {
                Newurl = '/SaleContractMaster/CreateGeneralContractDetails';
            }
            else if (TaskCode == "GeneralModifyContract") {
                Newurl = '/SaleContractMaster/CreateGeneralModifyContract';
            }
            else if (TaskCode == "GeneralShiftEmployee") {
                Newurl = '/SaleContractMaster/CreateGeneralShiftEmployee';
            }
            else if (TaskCode == "GeneralExtendContract") {
                Newurl = '/SaleContractMaster/CreateGeneralExtendContract';
            }
            else if (TaskCode == "GeneralRenewContract") {
                Newurl = '/SaleContractMaster/CreateGeneralRenewContract';
            }
            else if (TaskCode == "GeneralCancelContract") {
                Newurl = '/SaleContractMaster/CreateGeneralCancelContract';
            }
            else if (TaskCode == "GeneralUpdateAttendance") {
                Newurl = '/SaleContractMaster/CreateGeneralUpdateAttendance';
            }
            $.ajax(
                  {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: { "TaskCode": TaskCode, "SaleContractMasterID": SaleContractMasterID },
                      url: Newurl,
                      success: function (result) {
                          //alert(result);
                          $('.tab-content').html(result);
                      }
                  });

        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractMaster: function () {
        var SaleContractMasterData = null;
        if (SaleContractMaster.ActionName == "Create") {
            $("#FormCreateSaleContractMaster").validate();
            if ($("#FormCreateSaleContractMaster").valid()) {
                SaleContractMasterData = null;
                SaleContractMasterData = SaleContractMaster.GetSaleContractMaster();
                ajaxRequest.makeRequest("/SaleContractMaster/Create", "POST", SaleContractMasterData, SaleContractMaster.Success);
            }
        } else if (SaleContractMaster.ActionName == "Save") {
            $("#FormCreateSaleContractMaster").validate();
            if ($("#FormCreateSaleContractMaster").valid()) {
                SaleContractMasterData = null;
                SaleContractMasterData = SaleContractMaster.GetSaleContractMaster();
                ajaxRequest.makeRequest("/SaleContractMaster/Create", "POST", SaleContractMasterData, SaleContractMaster.SaveSuccess, "SaveSaleContractMasterRecord");

            }
        } else if (SaleContractMaster.ActionName == "Modify") {
            $("#FormCreateSaleContractMaster").validate();
            if ($("#FormCreateSaleContractMaster").valid()) {
                SaleContractMasterData = null;
                SaleContractMasterData = SaleContractMaster.GetSaleContractMaster();
                ajaxRequest.makeRequest("/SaleContractMaster/Modify", "POST", SaleContractMasterData, SaleContractMaster.SaveSuccess, "ModifySaleContractMasterRecord");

            }
        } else if (SaleContractMaster.ActionName == "Extend") {
            $("#FormCreateSaleContractMaster").validate();
            if ($("#FormCreateSaleContractMaster").valid()) {
                SaleContractMasterData = null;
                SaleContractMasterData = SaleContractMaster.GetSaleContractMaster();
                ajaxRequest.makeRequest("/SaleContractMaster/Extend", "POST", SaleContractMasterData, SaleContractMaster.SaveSuccess, "ExtendSaleContractMasterRecord");

            }
        } else if (SaleContractMaster.ActionName == "Shift") {
            $("#FormCreateSaleContractMaster").validate();
            if ($("#FormCreateSaleContractMaster").valid()) {
                SaleContractMasterData = null;
                SaleContractMasterData = SaleContractMaster.GetSaleContractMaster();
                ajaxRequest.makeRequest("/SaleContractMaster/ShiftEmployee", "POST", SaleContractMasterData, SaleContractMaster.SaveSuccess, "ShiftSaleContractMasterEmployee");

            }
        } else if (SaleContractMaster.ActionName == "Renew") {
            $("#FormCreateSaleContractMaster").validate();
            if ($("#FormCreateSaleContractMaster").valid()) {
                SaleContractMasterData = null;
                SaleContractMasterData = SaleContractMaster.GetSaleContractMaster();
                ajaxRequest.makeRequest("/SaleContractMaster/Renew", "POST", SaleContractMasterData, SaleContractMaster.SaveSuccess, "RenewSaleContractMasterRecord");

            }
        }

    },
    GetXmlDataForManPowerItem: function () {

        var DataArray = [];
        var data = $('#tblManPowerItem tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 12) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><SaleContractManPowerItemID>" + DataArray[i] + "</SaleContractManPowerItemID><SaleContractManPowerItemRequired>" + DataArray[i + 1] + "</SaleContractManPowerItemRequired><Gender>" + DataArray[i + 2] + "</Gender><IsSalaryDaysCountFix>" + DataArray[i + 3] + "</IsSalaryDaysCountFix><FixedDays>" + DataArray[i + 4] + "</FixedDays><IsSalaryDaysOnWeeklyOff>" + DataArray[i + 5] + "</IsSalaryDaysOnWeeklyOff><IsBillingDaysFixed>" + DataArray[i + 6] + "</IsBillingDaysFixed><FixedBillingDays>" + DataArray[i + 7] + "</FixedBillingDays><IsBillingDaysOnWeeklyOff>" + DataArray[i + 8] + "</IsBillingDaysOnWeeklyOff><FixedRate>" + DataArray[i + 11] + "</FixedRate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForManPowerItem = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForManPowerItem = "";

        var DataArray1 = [];
        var data = $('#tblAssignContractEmployee tbody tr td  input').each(function () {
            DataArray1.push($(this).val());
        });
        var TotalRecord1 = DataArray1.length;

        var ParameterXml1 = "<rows>";
        for (var i = 0; i < TotalRecord1; i = i + 4) {
            //var splitManPower = DataArray1[i].split('~');
            ParameterXml1 = ParameterXml1 + "<row><ID>" + 0 + "</ID><SelectedSaleContractManPowerItemID>" + DataArray1[i] + "</SelectedSaleContractManPowerItemID><SelectedGender>0</SelectedGender><SaleContractEmployeeMasterID>" + DataArray1[i + 1] + "</SaleContractEmployeeMasterID><EmployeeShiftMasterID>" + DataArray1[i + 2] + "</EmployeeShiftMasterID><SaleContractEmployeeAdditionalAmount>" + DataArray1[i + 3] + "</SaleContractEmployeeAdditionalAmount></row>";
        }
        if (ParameterXml1.length > 6)
            SaleContractMaster.XMLstringForAssignedEmployee = ParameterXml1 + "</rows>";
        else
            SaleContractMaster.XMLstringForAssignedEmployee = "";


        for (var i = 0; i < TotalRecord; i = i + 12) {
            var count = 0;
            for (var j = 0; j < TotalRecord1; j = j + 4) {
                //var splitManPower = DataArray1[j].split('~');
                if (DataArray[i] == DataArray1[j]) {
                    count++
                }
            }
            if (DataArray[i + 1] != count) {
                SaleContractMaster.AreAllEmployeeAssigned = 0;
                return false;
            } else {
                SaleContractMaster.AreAllEmployeeAssigned = 1;
            }
        }

    },
    GetXmlDataForModifyManPowerItem: function () {
        debugger
        var DataArray = [];
        var data = $('#tblManPowerItem tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 13) {
            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><SaleContractManPowerItemID>" + DataArray[i + 1] + "</SaleContractManPowerItemID><SaleContractManPowerItemRequired>" + DataArray[i + 2] + "</SaleContractManPowerItemRequired><Gender>" + DataArray[i + 3] + "</Gender><IsSalaryDaysCountFix>" + DataArray[i + 4] + "</IsSalaryDaysCountFix><FixedDays>" + DataArray[i + 5] + "</FixedDays><IsSalaryDaysOnWeeklyOff>" + DataArray[i + 6] + "</IsSalaryDaysOnWeeklyOff><IsBillingDaysFixed>" + DataArray[i + 7] + "</IsBillingDaysFixed><FixedBillingDays>" + DataArray[i + 8] + "</FixedBillingDays><IsBillingDaysOnWeeklyOff>" + DataArray[i + 9] + "</IsBillingDaysOnWeeklyOff><FixedRate>" + DataArray[i + 12] + "</FixedRate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForManPowerItem = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForManPowerItem = "";

        var DataArray1 = [];
        var data = $('#tblAssignContractEmployee tbody tr td  input').each(function () {
            DataArray1.push($(this).val());
        });
        var TotalRecord1 = DataArray1.length;

        var ParameterXml1 = "<rows>";
        for (var i = 0; i < TotalRecord1; i = i + 6) {
            //var splitManPower = DataArray1[i + 1].split('~');
            ParameterXml1 = ParameterXml1 + "<row><ID>" + DataArray1[i] + "</ID><SelectedSaleContractManPowerItemID>" + DataArray1[i + 1] + "</SelectedSaleContractManPowerItemID><SelectedGender>0</SelectedGender><SaleContractEmployeeMasterID>" + DataArray1[i + 2] + "</SaleContractEmployeeMasterID><AssignFromDate>" + DataArray1[i + 3] + "</AssignFromDate><EmployeeShiftMasterID>" + DataArray1[i + 4] + "</EmployeeShiftMasterID><SaleContractEmployeeAdditionalAmount>" + DataArray1[i + 5] + "</SaleContractEmployeeAdditionalAmount></row>";
        }
        if (ParameterXml1.length > 6)
            SaleContractMaster.XMLstringForAssignedEmployee = ParameterXml1 + "</rows>";
        else
            SaleContractMaster.XMLstringForAssignedEmployee = "";


        for (var i = 0; i < TotalRecord; i = i + 13) {
            var count = 0;
            for (var j = 0; j < TotalRecord1; j = j + 6) {
                //var splitManPower = DataArray1[j + 1].split('~');
                if (DataArray[i + 1] == DataArray1[j + 1]) {
                    count++
                }
            }
            if (DataArray[i + 2] != count) {
                SaleContractMaster.AreAllEmployeeAssigned = 0;
                return false;
            } else {
                SaleContractMaster.AreAllEmployeeAssigned = 1;
            }
        }

    },
    GetXmlDataForContractMaterial: function () {

        var DataArray = [];
        var data = $('#tblAddContractMaterial tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 4) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemNumber>" + DataArray[i] + "</ItemNumber><UOMCode>" + DataArray[i + 1] + "</UOMCode><Quantity>" + DataArray[i + 2] + "</Quantity><Rate>" + DataArray[i + 3] + "</Rate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForContractMaterial = ParameterXml + "</rows>";

        else
            SaleContractMaster.XMLstringForContractMaterial = "";
    },
    GetXmlDataForMachine: function () {

        var DataArray = [];
        var data = $('#tblAssignMachineMaster tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 3) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><SaleContractMachineMasterID>" + DataArray[i] + "</SaleContractMachineMasterID><SaleContractMachineMasterRequired>1</SaleContractMachineMasterRequired><Rate>" + DataArray[i + 2] + "</Rate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForMachine = ParameterXml + "</rows>";

        else
            SaleContractMaster.XMLstringForMachine = "";
    },
    GetXmlDataForModifyMachine: function () {

        var DataArray = [];
        var data = $('#tblModifyMachineMaster tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 5) {
            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><SaleContractMachineMasterID>" + DataArray[i + 1] + "</SaleContractMachineMasterID><SaleContractMachineMasterRequired>1</SaleContractMachineMasterRequired><Rate>" + DataArray[i + 3] + "</Rate><AssignFromDate>" + DataArray[i + 4] + "</AssignFromDate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForMachine = ParameterXml + "</rows>";

        else
            SaleContractMaster.XMLstringForMachine = "";
    },
    GetXmlDataForJobWorkItem: function () {

        var DataArray = [];
        var data = $('#tblAddJobWorkItem tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 2) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><SaleContractJobWorkItemID>" + DataArray[i] + "</SaleContractJobWorkItemID><Rate>" + DataArray[i + 1] + "</Rate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForJobWorkItem = ParameterXml + "</rows>";

        else
            SaleContractMaster.XMLstringForJobWorkItem = "";
    },
    GetXmlDataForModifyJobWorkItem: function () {

        var DataArray = [];
        var data = $('#tblModifyJobWorkItem tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 3) {
            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><SaleContractJobWorkItemID>" + DataArray[i + 1] + "</SaleContractJobWorkItemID><Rate>" + DataArray[i + 2] + "</Rate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForJobWorkItem = ParameterXml + "</rows>";

        else
            SaleContractMaster.XMLstringForJobWorkItem = "";
    },
    GetXmlDataForFixItem: function () {

        var DataArray = [];
        var data = $('#tblAddFixItem tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 1) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><SaleContractFixItemID>" + DataArray[i] + "</SaleContractFixItemID><Quantity>1</Quantity><Rate>1</Rate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForFixItem = ParameterXml + "</rows>";

        else
            SaleContractMaster.XMLstringForFixItem = "";
    },
    GetXmlDataForModifyFixItem: function () {

        var DataArray = [];
        var data = $('#tblModifyFixItem tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 2) {
            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><SaleContractFixItemID>" + DataArray[i + 1] + "</SaleContractFixItemID><Quantity>1</Quantity><Rate>1</Rate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForFixItem = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForFixItem = "";
    },
    GetXMLstringForShiftingEmployee: function () {

        var ParameterXml = "<rows>";
        $(".IsReplaceEmployee").each(function () {
            if ($(this).is(":checked")) {
                var RequirementDetailsID = $(this).parent().prev().prev().children(".SaleContractRequirementDetailsID").val();
                var ManPowerAssignID = $(this).parent().prev().prev().children(".SaleContractManPowerAssignID").val();
                var EmployeeMasterID = $(this).parent().prev().prev().children(".SaleContractEmployeeMasterID").val();
                var ManPowerItemID = $(this).parent().prev().children("input").val();
                var ReplaceEmployeeMasterID = $(this).parent().next().children(".ReplaceContractEmployeeID").val();
                var FromDate = $(this).parent().next().next().children(".ManPowerAssignFromDate").val();

                ParameterXml = ParameterXml + "<row><RequirementDetailsID>" + RequirementDetailsID + "</RequirementDetailsID><ManPowerAssignID>" + ManPowerAssignID + "</ManPowerAssignID><EmployeeMasterID>" + EmployeeMasterID + "</EmployeeMasterID><ManPowerItemID>" + ManPowerItemID + "</ManPowerItemID><ReplaceEmployeeMasterID>" + ReplaceEmployeeMasterID + "</ReplaceEmployeeMasterID><FromDate>" + FromDate + "</FromDate></row>";
            }
        });

        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForShiftingEmployee = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForShiftingEmployee = "";
    },
    GetXmlDataForManPowerServiceCharge: function () {

        var DataArray = [];
        var data = $('#tblServiceCharges tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 4) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ServiceChargeManPowerItemID>" + DataArray[i] + "</ServiceChargeManPowerItemID><ServiceChargesFixAmount>" + DataArray[i + 1] + "</ServiceChargesFixAmount><ServiceChargesFromDate>" + DataArray[i + 2] + "</ServiceChargesFromDate><ServiceChargesUptoDate>" + DataArray[i + 3] + "</ServiceChargesUptoDate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForManPowerServiceCharge = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForManPowerServiceCharge = "";
    },
    GetXmlDataForModifyManPowerServiceCharge: function () {

        var DataArray = [];
        var data = $('#tblModifyServiceCharges tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 5) {
            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><ServiceChargeManPowerItemID>" + DataArray[i + 1] + "</ServiceChargeManPowerItemID><ServiceChargesFixAmount>" + DataArray[i + 2] + "</ServiceChargesFixAmount><ServiceChargesFromDate>" + DataArray[i + 3] + "</ServiceChargesFromDate><ServiceChargesUptoDate>" + DataArray[i + 4] + "</ServiceChargesUptoDate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForManPowerServiceCharge = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForManPowerServiceCharge = "";
    },
    GetXmlDataForManPowerServiceChargeForHead: function () {

        var ParameterXml = "<rows>";
        $('#ServiceChargeCalculateOnSalaryHeads option').each(function () {

            if ($(this).val() != "on") {
                CalculateOn = $(this).val();
                //sArray = $(this).val().split("~");
                if (this.selected == true) {
                    //xmlInsert code here
                    var splitCal = CalculateOn.split('~');
                    ParameterXml = ParameterXml + "<row>" + "<ID>" + splitCal[2] + "</ID>" + "<ReferenceID>" + splitCal[0] + "</ReferenceID><AllowanceOrDeduction>" + splitCal[1] + "</AllowanceOrDeduction></row>";
                }
            }
        });

        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForManPowerServiceChargeForHead = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForManPowerServiceChargeForHead = "";
    },
    GetXmlDataForOverTime: function () {

        var DataArray = [];
        var data = $('#tblOverTimeDetails tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 6) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><OverTimeAllowanceManPowerItemID>" + DataArray[i] + "</OverTimeAllowanceManPowerItemID><SalaryAllowanceMasterID>" + DataArray[i + 1] + "</SalaryAllowanceMasterID><BasicOrAllowance>" + DataArray[i + 2] + "</BasicOrAllowance><ForInvoiceOrSalaryCompliance>" + DataArray[i + 3] + "</ForInvoiceOrSalaryCompliance><OverTimeFromDate>" + DataArray[i + 4] + "</OverTimeFromDate><OverTimeUptoDate>" + DataArray[i + 5] + "</OverTimeUptoDate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForOverTime = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForOverTime = "";
    },
    GetXmlDataForOverTimeFix: function () {

        var DataArray = [];
        var data = $('#tblOverTimeDetailsFix tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 10) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><OverTimeFixManPowerItemID>" + DataArray[i] + "</OverTimeFixManPowerItemID><FixedAmountForInvoice>" + DataArray[i + 1] + "</FixedAmountForInvoice><FixedAmountForSalaryCompliance>" + DataArray[i + 2] + "</FixedAmountForSalaryCompliance><IsOverTimeDaysFix>" + DataArray[i + 3] + "</IsOverTimeDaysFix><FixedDays>" + DataArray[i + 4] + "</FixedDays><IsOTDaysOnTotalOff>" + DataArray[i + 5] + "</IsOTDaysOnTotalOff><IsOverTimeBillingDaysFix>" + DataArray[i + 6] + "</IsOverTimeBillingDaysFix><OTBillingFixedDays>" + DataArray[i + 7] + "</OTBillingFixedDays><IsOTBillingDaysOnTotalOff>" + DataArray[i + 8] + "</IsOTBillingDaysOnTotalOff><OverTimeDisplayFormat>" + DataArray[i + 9] + "</OverTimeDisplayFormat></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForOverTimeFix = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForOverTimeFix = "";
    },
    GetXmlDataForModifyOverTime: function () {

        var DataArray = [];
        var data = $('#tblModifyOverTimeDetails tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 7) {
            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><OverTimeAllowanceManPowerItemID>" + DataArray[i + 1] + "</OverTimeAllowanceManPowerItemID><SalaryAllowanceMasterID>" + DataArray[i + 2] + "</SalaryAllowanceMasterID><BasicOrAllowance>" + DataArray[i + 3] + "</BasicOrAllowance><ForInvoiceOrSalaryCompliance>" + DataArray[i + 4] + "</ForInvoiceOrSalaryCompliance><OverTimeFromDate>" + DataArray[i + 5] + "</OverTimeFromDate><OverTimeUptoDate>" + DataArray[i + 6] + "</OverTimeUptoDate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForOverTime = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForOverTime = "";
    },
    GetXmlDataForModifyOverTimeFix: function () {

        var DataArray = [];
        var data = $('#tblModifyOverTimeDetailsFix tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 11) {
            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><OverTimeFixManPowerItemID>" + DataArray[i + 1] + "</OverTimeFixManPowerItemID><FixedAmountForInvoice>" + DataArray[i + 2] + "</FixedAmountForInvoice><FixedAmountForSalaryCompliance>" + DataArray[i + 3] + "</FixedAmountForSalaryCompliance><IsOverTimeDaysFix>" + DataArray[i + 4] + "</IsOverTimeDaysFix><FixedDays>" + DataArray[i + 5] + "</FixedDays><IsOTDaysOnTotalOff>" + DataArray[i + 6] + "</IsOTDaysOnTotalOff><IsOverTimeBillingDaysFix>" + DataArray[i + 7] + "</IsOverTimeBillingDaysFix><OTBillingFixedDays>" + DataArray[i + 8] + "</OTBillingFixedDays><IsOTBillingDaysOnTotalOff>" + DataArray[i + 9] + "</IsOTBillingDaysOnTotalOff><OverTimeDisplayFormat>" + DataArray[i + 10] + "</OverTimeDisplayFormat></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForOverTimeFix = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForOverTimeFix = "";
    },
    GetXmlDataForServiceItem: function () {

        var DataArray = [];
        var data = $('#tblAddServiceItem tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 2) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><SaleContractServiceItemNumber>" + DataArray[i] + "</SaleContractServiceItemNumber><SaleContractServiceItemRate>" + DataArray[i + 1] + "</SaleContractServiceItemRate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForServiceItem = ParameterXml + "</rows>";

        else
            SaleContractMaster.XMLstringForServiceItem = "";
    },
    GetXmlDataForModifyServiceItem: function () {

        var DataArray = [];
        var data = $('#tblModifyServiceItem tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 3) {
            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><SaleContractServiceItemNumber>" + DataArray[i + 1] + "</SaleContractServiceItemNumber><SaleContractServiceItemRate>" + DataArray[i + 2] + "</SaleContractServiceItemRate></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractMaster.XMLstringForServiceItem = ParameterXml + "</rows>";
        else
            SaleContractMaster.XMLstringForServiceItem = "";
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractMaster: function () {
        var Data = {
        };
        debugger
        if (SaleContractMaster.ActionName == "Create" || SaleContractMaster.ActionName == "Save") {
            Data.TaskCode = $("#TaskCode").val();
            Data.ID = $("#ID").val();
            Data.CentreCode = $("#CentreCode").val();
            Data.Narration = $("#Narration").val();
            Data.EmployeeMasterID = $("#EmployeeMasterID").val();
            Data.IsConfidential = $("#IsConfidential").is(":checked") ? true : false;
            Data.CustomerMasterID = $("#CustomerMasterID").val();
            Data.CustomerBranchMasterID = $("#CustomerBranchMasterID").val();
            Data.CustomerContactPersonID = $("#CustomerContactPersonID").val();
            Data.PurchaseOrderNumber = $("#PurchaseOrderNumber").val();
            Data.PurchaseOrderDate = $("#PurchaseOrderDate").val();
            Data.IsDisplayPurchaseDetails = $("#IsDisplayPurchaseDetails").is(":checked") ? true : false;
            Data.ContractStartDate = $("#ContractStartDate").val();
            Data.ContractEndDate = $("#ContractEndDate").val();
            Data.BillingType = $("#BillingType").val();
            Data.BillingFixedAmount = $("#BillingFixedAmount").val();
            Data.FixedBillingType = $("#FixedBillingType").val();
            Data.FixedBillingForManPowerItemID = $("#FixedBillingForManPowerItemID").val();
            Data.ShortExtraPostingRateAccTo = $("#ShortExtraPostingRateAccTo").val();
            Data.IsIncludeAllPostingForShortExtraRate = $("#IsIncludeAllPostingForShortExtraRate").is(":checked") ? true : false;
            Data.AdditionalAllowancePaidBy = $("#AdditionalAllowancePaidBy").val();
            Data.MaterialSupplyDay = $("#MaterialSupplyDay").val();
            Data.RenewCallBeforeDays = $("#RenewCallBeforeDays").val();
            Data.MaterialSupplyFixAmount = $("#MaterialSupplyFixAmount").val();
            Data.SalaryEffectiveFromDate = $("#SalaryEffectiveFromDate").val() == "" ? $("#ContractStartDate").val() : $("#SalaryEffectiveFromDate").val();
            Data.SalaryEffectiveUptoDate = $("#SalaryEffectiveUptoDate").val() == "" ? $("#ContractEndDate").val() : $("#SalaryEffectiveUptoDate").val();
            Data.ServiceChargesDependOn = $("#ServiceChargesDependOn").val();
            Data.ServiceChargesCalculateOn = $("#ServiceChargesCalculateOn").val();
            Data.IsInclusiveServiceCharges = $("#IsInclusiveServiceCharges").is(":checked") ? true : false;
            Data.IsServiceChargesAppliedToAddAmount = $("#IsServiceChargesAppliedToAddAmount").is(":checked") ? true : false;
            Data.IsServiceChargesAppliedToServiceItem = $("#IsServiceChargesAppliedToServiceItem").is(":checked") ? true : false;
            Data.IsServiceChargesAppliedToOverTime = $("#IsServiceChargesAppliedToOverTime").is(":checked") ? true : false;
            Data.IsRateFixedForRateContract = $("#IsRateFixedForRateContract").is(":checked") ? true : false;
            Data.ServiceChargesPercentage = $("#ServiceChargesPercentage").val();
            Data.OverTimeDependOn = $("#OverTimeDependOn").val();
            //Data.OverTimeDisplayFormat = $("#OverTimeDisplayFormat").val();
            //Data.FixedAmountForInvoice = $("#FixedAmountForInvoice").val();
            //Data.FixedAmountForSalaryCompliance = $("#FixedAmountForSalaryCompliance").val();
            Data.XMLstringForOverTime = SaleContractMaster.XMLstringForOverTime;
            Data.XMLstringForOverTimeFix = SaleContractMaster.XMLstringForOverTimeFix;
            Data.XMLstringForManPowerServiceCharge = SaleContractMaster.XMLstringForManPowerServiceCharge;
            Data.XMLstringForManPowerServiceChargeForHead = SaleContractMaster.XMLstringForManPowerServiceChargeForHead;
            Data.XMLstringForManPowerItem = SaleContractMaster.XMLstringForManPowerItem;
            Data.XMLstringForAssignedEmployee = SaleContractMaster.XMLstringForAssignedEmployee;
            Data.XMLstringForContractMaterial = SaleContractMaster.XMLstringForContractMaterial;
            Data.XMLstringForMachine = SaleContractMaster.XMLstringForMachine;
            Data.XMLstringForJobWorkItem = SaleContractMaster.XMLstringForJobWorkItem;
            Data.XMLstringForFixItem = SaleContractMaster.XMLstringForFixItem;
            Data.XMLstringForServiceItem = SaleContractMaster.XMLstringForServiceItem;
        } else if (SaleContractMaster.ActionName == "Modify") {
            Data.TaskCode = $("#TaskCode").val();
            Data.ID = $('input[name=ID]').val();
            Data.Narration = $("#Narration").val();
            Data.EmployeeMasterID = $("#EmployeeMasterID").val();
            Data.PurchaseOrderNumber = $("#PurchaseOrderNumber").val();
            Data.PurchaseOrderDate = $("#PurchaseOrderDate").val();
            Data.IsDisplayPurchaseDetails = $("#IsDisplayPurchaseDetails").is(":checked") ? true : false;
            Data.XMLstringForManPowerServiceCharge = SaleContractMaster.XMLstringForManPowerServiceCharge;
            Data.XMLstringForOverTime = SaleContractMaster.XMLstringForOverTime;
            Data.XMLstringForOverTimeFix = SaleContractMaster.XMLstringForOverTimeFix;
            Data.XMLstringForManPowerItem = SaleContractMaster.XMLstringForManPowerItem;
            Data.XMLstringForAssignedEmployee = SaleContractMaster.XMLstringForAssignedEmployee;
            Data.XMLstringForMachine = SaleContractMaster.XMLstringForMachine;
            Data.XMLstringForJobWorkItem = SaleContractMaster.XMLstringForJobWorkItem;
            Data.XMLstringForFixItem = SaleContractMaster.XMLstringForFixItem;
            Data.XMLstringForServiceItem = SaleContractMaster.XMLstringForServiceItem;
        } else if (SaleContractMaster.ActionName == "Extend") {
            Data.TaskCode = $("#TaskCode").val();
            Data.ID = $('input[name=ID]').val();
            Data.ContractEndDate = $("#ContractEndDate").val();
            Data.SalaryEffectiveUptoDate = $("#SalaryEffectiveUptoDate").val() == "" ? $("#ContractEndDate").val() : $("#SalaryEffectiveUptoDate").val();
        } else if (SaleContractMaster.ActionName == "Shift") {
            Data.TaskCode = $("#TaskCode").val();
            Data.ID = $('input[name=ID]').val();
            Data.XMLstringForShiftingEmployee = SaleContractMaster.XMLstringForShiftingEmployee;
        } else if (SaleContractMaster.ActionName == "Renew") {
            Data.TaskCode = $("#TaskCode").val();
            Data.ID = $('input[name=ID]').val();
            Data.Narration = $("#Narration").val();
            Data.PurchaseOrderNumber = $("#PurchaseOrderNumber").val();
            Data.PurchaseOrderDate = $("#PurchaseOrderDate").val();
            Data.IsDisplayPurchaseDetails = $("#IsDisplayPurchaseDetails").is(":checked") ? true : false;
            Data.EmployeeMasterID = $("#EmployeeMasterID").val();
            Data.ContractStartDate = $("#ContractStartDate").val();
            Data.ContractEndDate = $("#ContractEndDate").val();
            Data.BillingType = $("#BillingType").val();
            Data.BillingFixedAmount = $("#BillingFixedAmount").val();
            Data.FixedBillingType = $("#FixedBillingType").val();
            Data.FixedBillingForManPowerItemID = $("#FixedBillingForManPowerItemID").val();
            Data.ShortExtraPostingRateAccTo = $("#ShortExtraPostingRateAccTo").val();
            Data.IsIncludeAllPostingForShortExtraRate = $("#IsIncludeAllPostingForShortExtraRate").is(":checked") ? true : false;
            Data.AdditionalAllowancePaidBy = $("#AdditionalAllowancePaidBy").val();
            Data.MaterialSupplyDay = $("#MaterialSupplyDay").val();
            Data.RenewCallBeforeDays = $("#RenewCallBeforeDays").val();
            Data.MaterialSupplyFixAmount = $("#MaterialSupplyFixAmount").val();
            Data.SalaryEffectiveFromDate = $("#SalaryEffectiveFromDate").val() == "" ? $("#ContractStartDate").val() : $("#SalaryEffectiveFromDate").val();
            Data.SalaryEffectiveUptoDate = $("#SalaryEffectiveUptoDate").val() == "" ? $("#ContractEndDate").val() : $("#SalaryEffectiveUptoDate").val();
            Data.ServiceChargesDependOn = $("#ServiceChargesDependOn").val();
            Data.ServiceChargesCalculateOn = $("#ServiceChargesCalculateOn").val();
            Data.IsInclusiveServiceCharges = $("#IsInclusiveServiceCharges").is(":checked") ? true : false;
            Data.IsServiceChargesAppliedToAddAmount = $("#IsServiceChargesAppliedToAddAmount").is(":checked") ? true : false;
            Data.IsServiceChargesAppliedToServiceItem = $("#IsServiceChargesAppliedToServiceItem").is(":checked") ? true : false;
            Data.IsServiceChargesAppliedToOverTime = $("#IsServiceChargesAppliedToOverTime").is(":checked") ? true : false;
            Data.IsRateFixedForRateContract = $("#IsRateFixedForRateContract").is(":checked") ? true : false;
            Data.ServiceChargesPercentage = $("#ServiceChargesPercentage").val();
            Data.OverTimeDependOn = $("#OverTimeDependOn").val();
            //Data.OverTimeDisplayFormat = $("#OverTimeDisplayFormat").val();
            //Data.FixedAmountForInvoice = $("#FixedAmountForInvoice").val();
            //Data.FixedAmountForSalaryCompliance = $("#FixedAmountForSalaryCompliance").val();
            Data.XMLstringForOverTime = SaleContractMaster.XMLstringForOverTime;
            Data.XMLstringForOverTimeFix = SaleContractMaster.XMLstringForOverTimeFix;
            Data.XMLstringForManPowerServiceCharge = SaleContractMaster.XMLstringForManPowerServiceCharge;
            Data.XMLstringForManPowerServiceChargeForHead = SaleContractMaster.XMLstringForManPowerServiceChargeForHead;
            Data.XMLstringForManPowerItem = SaleContractMaster.XMLstringForManPowerItem;
            Data.XMLstringForAssignedEmployee = SaleContractMaster.XMLstringForAssignedEmployee;
            Data.XMLstringForContractMaterial = SaleContractMaster.XMLstringForContractMaterial;
            Data.XMLstringForMachine = SaleContractMaster.XMLstringForMachine;
            Data.XMLstringForJobWorkItem = SaleContractMaster.XMLstringForJobWorkItem;
            Data.XMLstringForFixItem = SaleContractMaster.XMLstringForFixItem;
            Data.XMLstringForServiceItem = SaleContractMaster.XMLstringForServiceItem;
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.errorMessage.split(',');
        if (splitData[1] == 'success') {
            SaleContractMaster.ReloadSaleContractDetailsHome(splitData[0], splitData[1], splitData[2]);
        }
        else {
            notify(splitData[0], splitData[1]);
        }

    },
    SaveSuccess: function (data) {
        var splitData = data.errorMessage.split(',');

        if (splitData[1] == 'success') {
            var TaskCode = data.TaskCode;
            if (TaskCode == "GeneralRenewContract" || TaskCode == "GeneralContractDetails") {
                $("#ID").val(data.ID);
                $("#ContractNumber").val(data.ContractNumber);
            }

            notify(splitData[0], splitData[1]);

            if (TaskCode == "GeneralRenewContract") {
                $("#GeneralContractDetails").click();
                $("#GeneralContractDetails").addClass('active');
                $("#GeneralRenewContract").removeClass('active');
            } else {
                $("#" + TaskCode).click();
            }
        }
        else {
            notify(splitData[0], splitData[1]);
        }
    },
};

