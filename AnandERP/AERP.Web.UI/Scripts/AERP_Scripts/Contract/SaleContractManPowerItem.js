//this class contain methods related to nationality functionality
var SaleContractManPowerItem = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractManPowerItem.constructor();
        //SaleContractManPowerItem.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#SelectedCentreCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        // Create new record
        $('#CreateSaleContractManPowerItemRecord').on("click", function () {

            if ($("#CustomerType").val() == "2" && $("#CustomerBranchMasterID").val() == "0") {
                $("#displayErrorMessage").text("Please select Branch.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }

            if ($("#ItemNumber").val() == "0" || $("#ItemNumber").val() == "") {
                $("#displayErrorMessage").text("Please select Item Description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }

            SaleContractManPowerItem.ActionName = "Create";
            SaleContractManPowerItem.AjaxCallSaleContractManPowerItem();
        });

        $('#EditSaleContractManPowerItemRecord').on("click", function () {

            SaleContractManPowerItem.ActionName = "Edit";
            SaleContractManPowerItem.AjaxCallSaleContractManPowerItem();
        });

        $('#CreateSaleContractManPowerItemRulesRecord').on("click", function () {
            var IsRuleSelected = false;
            $("#SelectedRules tbody tr td .SelectedRuleID").each(function () {
                IsRuleSelected = true;
            });
            if (IsRuleSelected == false) {
                $("#displayErrorMessage").text("Please select Rules.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            SaleContractManPowerItem.ActionName = "CreateRules";
            SaleContractManPowerItem.GetXmlDataForManPowerItemRules();
            SaleContractManPowerItem.getCalculateOnXML();
            SaleContractManPowerItem.AjaxCallSaleContractManPowerItem();
        });

        $('#EditsSaleContractManPowerItemRulesRecord').on("click", function () {
            var IsRuleSelected = false;
            $("#SelectedRules tbody tr td .SelectedRuleID").each(function () {
                IsRuleSelected = true;
            });
            if (IsRuleSelected == false) {
                $("#displayErrorMessage").text("Please select Rules.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            if ($("#BasicSalayAmount").val() == "" || $("#BasicSalayAmount").val() == "0") {
                $("#displayErrorMessage").text("Please enter Basic Amount.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            SaleContractManPowerItem.ActionName = "EditRules";
            SaleContractManPowerItem.GetXmlDataForManPowerItemRules();
            SaleContractManPowerItem.getCalculateOnXML();
            SaleContractManPowerItem.AjaxCallSaleContractManPowerItem();
        });

        $("#btnShowList").unbind('click').click(function () {
            var CustomerMasterID = $("#CustomerMasterID").val();
            var CustomerMasterName = $("#CustomerMasterName").val();
            if (CustomerMasterID == "" || CustomerMasterID == 0) {
                notify("Please select Customer", 'warning');
                return false;
            }
            var CustomerBranchMasterID = $("#CustomerBranchMasterID").val();
            var CustomerBranchMasterName = $("#CustomerBranchMasterName").val();
            if (CustomerBranchMasterID == "" || CustomerBranchMasterID == 0) {
                notify("Please select Branch", 'warning');
                return false;
            }

            $("#linkForCreate").show();
            $("#btnCreateList").attr("href", "SaleContractManPowerItem/Create?CustomerID=" + CustomerMasterID + "&CustomerName=" + CustomerMasterName + "&CustomerBranchID=" + CustomerBranchMasterID + "&CustomerBranchName=" + CustomerBranchMasterName);

            SaleContractManPowerItem.LoadList();
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
            url: '/SaleContractManPowerItem/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/SaleContractManPowerItem/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractManPowerItem: function () {
        var SaleContractManPowerItemData = null;
        if (SaleContractManPowerItem.ActionName == "Create") {
            $("#FormCreateSaleContractManPowerItem").validate();
            if ($("#FormCreateSaleContractManPowerItem").valid()) {
                SaleContractManPowerItemData = null;
                SaleContractManPowerItemData = SaleContractManPowerItem.GetSaleContractManPowerItem();
                ajaxRequest.makeRequest("/SaleContractManPowerItem/Create", "POST", SaleContractManPowerItemData, SaleContractManPowerItem.Success);
            }
        }
        else if (SaleContractManPowerItem.ActionName == "Edit") {
            $("#FormEditSaleContractManPowerItem").validate();
            if ($("#FormEditSaleContractManPowerItem").valid()) {
                SaleContractManPowerItemData = null;
                SaleContractManPowerItemData = SaleContractManPowerItem.GetSaleContractManPowerItem();
                ajaxRequest.makeRequest("/SaleContractManPowerItem/Edit", "POST", SaleContractManPowerItemData, SaleContractManPowerItem.Success);
            }
        }
        else if (SaleContractManPowerItem.ActionName == "Delete") {
            SaleContractManPowerItemData = null;
            //$("#FormCreateSaleContractManPowerItem").validate();
            SaleContractManPowerItemData = SaleContractManPowerItem.GetSaleContractManPowerItem();
            ajaxRequest.makeRequest("/SaleContractManPowerItem/Delete", "POST", SaleContractManPowerItemData, SaleContractManPowerItem.Success);

        } else if (SaleContractManPowerItem.ActionName == "CreateRules") {
            SaleContractManPowerItemData = null;

            SaleContractManPowerItemData = SaleContractManPowerItem.GetSaleContractManPowerItem();
            ajaxRequest.makeRequest("/SaleContractManPowerItem/CreateManPowerItemRules", "POST", SaleContractManPowerItemData, SaleContractManPowerItem.Success);

        } else if (SaleContractManPowerItem.ActionName == "EditRules") {
            SaleContractManPowerItemData = null;

            SaleContractManPowerItemData = SaleContractManPowerItem.GetSaleContractManPowerItem();
            ajaxRequest.makeRequest("/SaleContractManPowerItem/EditManPowerItemRules", "POST", SaleContractManPowerItemData, SaleContractManPowerItem.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractManPowerItem: function () {
        var Data = {
        };
        if (SaleContractManPowerItem.ActionName == "Create" || SaleContractManPowerItem.ActionName == "Edit") {
            Data.ID = $("#ID").val()
            Data.ItemNumber = $('#ItemNumber').val();
            Data.DesignationMasterID = $('#DesignationMasterID').val();
            Data.BasicSalayAmount = $('#BasicSalayAmount').val();
            Data.TotalAmount = $('#TotalAmount').val();
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            Data.CustomerMasterID = $("#CustomerMasterID").val();
            Data.CustomerMasterName = $('#CustomerMasterName').val();
            Data.ItemDescription = $('#ItemDescription').val();
            Data.DesignationMasterName = $("#DesignationMasterName").val();
            Data.FixedSalaryAmount = $("#FixedSalaryAmount").val();
            Data.BillingDisplayName = $("#BillingDisplayName").val() != "" ? $("#BillingDisplayName").val() : $("#DesignationMasterName").val();
        }
        else if (SaleContractManPowerItem.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        else if (SaleContractManPowerItem.ActionName == "CreateRules") {
            Data.ID = $('#ID').val();
            Data.TotalAmount = $('#TotalSalaryAmount').val();
            Data.GrossSalaryAmount = $('#GrossSalaryAmount').val();
            Data.NetSalaryAmount = $('#NetSalaryAmount').val();
            Data.XMLStringManPowerItemRules = SaleContractManPowerItem.XMLStringManPowerItemRules;
            Data.XMLStringForCalculateOn = SaleContractManPowerItem.XMLStringForCalculateOn;
        } else if (SaleContractManPowerItem.ActionName == "EditRules") {
            Data.ID = $('#ID').val();
            Data.TotalAmount = $('#TotalSalaryAmount').val();
            Data.GrossSalaryAmount = $('#GrossSalaryAmount').val();
            Data.NetSalaryAmount = $('#NetSalaryAmount').val();
            Data.BasicSalayAmount = $('#BasicSalayAmount').val();
            Data.FixedSalaryAmount = $('#FixedSalaryAmount').val();
            Data.GenerateSeperateInvoice = $("#GenerateSeperateInvoice").is(":checked") ? true : false;
            Data.CalculateArrears = $("#CalculateArrears").is(":checked") ? true : false;
            Data.WithEffectiveFromDate = $('#WithEffectiveFromDate').val();
            Data.WithEffectiveUptoDate = $('#WithEffectiveUptoDate').val();
            Data.XMLStringManPowerItemRules = SaleContractManPowerItem.XMLStringManPowerItemRules;
            Data.XMLStringForCalculateOn = SaleContractManPowerItem.XMLStringForCalculateOn;
        }
        return Data;
    },
    GetXmlDataForManPowerItemRules: function () {

        var DataArray = [];
        var data = $('#SelectedRules tbody tr td  input').each(function () {

            DataArray.push($(this).val());

        });
        var TotalRecord = DataArray.length;
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 10) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><RuleID>" + DataArray[i] + "</RuleID><RuleType>" + DataArray[i + 1] + "</RuleType><HeadID>" + DataArray[i + 2] + "</HeadID><FixedAmount>" + DataArray[i + 3] + "</FixedAmount><Percentage>" + DataArray[i + 4] + "</Percentage><CalculateOn>0</CalculateOn><CalculateOnFixedAmount>" + DataArray[i + 6] + "</CalculateOnFixedAmount><CalculatedAmount>" + DataArray[i + 8] + "</CalculatedAmount></row>";
        }
        if (ParameterXml.length > 6)
            SaleContractManPowerItem.XMLStringManPowerItemRules = ParameterXml + "</rows>";
        else
            SaleContractManPowerItem.XMLStringManPowerItemRules = "";
    },
    getCalculateOnXML: function () {
        debugger;
        var sList = "";
        var xmlParamList = "<rows>"
        $("#SelectedRules tbody tr td .SelectedCalcultedOn").each(function () {
            var SelectedCalcultedOn = $(this).val();

            if (SelectedCalcultedOn != null && SelectedCalcultedOn != '' && SelectedCalcultedOn != 'null') {
                var Percentage = $(this).parent().prev().children('input').val();
                var RuleID = $(this).parent().parent("tr").children("td:eq(0)").children('.SelectedRuleID').val();
                var RuleType = $(this).parent().parent("tr").children("td:eq(0)").children('.SelectedRuleType').val();

                var SplitSelectedCalcultedOn = SelectedCalcultedOn.split(',');
                for (i = 0; i < SplitSelectedCalcultedOn.length; i++) {
                    CalculateOn = SplitSelectedCalcultedOn[i].split('~');

                    xmlParamList = xmlParamList + "<row>" + "<ID>" + CalculateOn[2] + "</ID>" + "<ReferenceID>" + CalculateOn[0] + "</ReferenceID><AllowanceOrDeduction>" + CalculateOn[1] + "</AllowanceOrDeduction><Percentage>" + Percentage + "</Percentage><RuleID>" + RuleID + "</RuleID><RuleType>" + RuleType + "</RuleType></row>";

                }
            }
        });
        if (xmlParamList.length > 6)
            SaleContractManPowerItem.XMLStringForCalculateOn = xmlParamList + "</rows>";
        else
            SaleContractManPowerItem.XMLStringForCalculateOn = "";
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SaleContractManPowerItem.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SaleContractManPowerItem.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

