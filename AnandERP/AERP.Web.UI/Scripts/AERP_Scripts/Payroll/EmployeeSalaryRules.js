//this class contain methods related to nationality functionality
var EmployeeSalaryRules = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeSalaryRules.constructor();
        //EmployeeSalaryRules.initializeValidation();
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
        
        $('#CreateEmployeeSalaryRulesRecord').on("click", function () {
            var IsRuleSelected = false;
            $("#SelectedRules tbody tr td .SelectedRuleID").each(function () {
                IsRuleSelected = true;
            });
            if (IsRuleSelected == false) {
                $("#displayErrorMessage").text("Please select Rules.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            EmployeeSalaryRules.ActionName = "CreateRules";
            EmployeeSalaryRules.GetXmlDataForManPowerItemRules();
            EmployeeSalaryRules.getCalculateOnXML();
            EmployeeSalaryRules.AjaxCallEmployeeSalaryRules();
        });

        $('#EditEmployeeSalaryRulesRecord').on("click", function () {
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
            EmployeeSalaryRules.ActionName = "EditRules";
            EmployeeSalaryRules.GetXmlDataForManPowerItemRules();
            EmployeeSalaryRules.getCalculateOnXML();
            EmployeeSalaryRules.AjaxCallEmployeeSalaryRules();
        });

        $("#btnShowList").unbind('click').click(function () {
            var SelectedCentreCode = $("#SelectedCentreCode").val();
            var SelectedDepartmentID = $("#SelectedDepartmentID").val();
            if (SelectedCentreCode == "" || SelectedCentreCode == 0) {
                notify("Please select Center", 'warning');
                return false;
            }

            if (SelectedDepartmentID == "" || SelectedDepartmentID == 0) {
                notify("Please select Department", 'warning');
                return false;
            }

            EmployeeSalaryRules.LoadList();
        });

        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();
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

        });


        $("#SelectedDepartmentID").change(function () {
            $('#ListViewModel').empty();

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
            url: '/EmployeeSalaryRules/List',
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
            url: '/EmployeeSalaryRules/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeSalaryRules: function () {
        var EmployeeSalaryRulesData = null;
        if (EmployeeSalaryRules.ActionName == "CreateRules") {
            EmployeeSalaryRulesData = null;

            EmployeeSalaryRulesData = EmployeeSalaryRules.GetEmployeeSalaryRules();
            ajaxRequest.makeRequest("/EmployeeSalaryRules/Create", "POST", EmployeeSalaryRulesData, EmployeeSalaryRules.Success);

        } else if (EmployeeSalaryRules.ActionName == "EditRules") {
            EmployeeSalaryRulesData = null;

            EmployeeSalaryRulesData = EmployeeSalaryRules.GetEmployeeSalaryRules();
            ajaxRequest.makeRequest("/EmployeeSalaryRules/Edit", "POST", EmployeeSalaryRulesData, EmployeeSalaryRules.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeSalaryRules: function () {
        var Data = {
        };
        if (EmployeeSalaryRules.ActionName == "CreateRules") {
            Data.EmployeeMasterID = $('#EmployeeMasterID').val();
            Data.TotalAmount = $('#TotalSalaryAmount').val();
            Data.GrossSalaryAmount = $('#GrossSalaryAmount').val();
            Data.NetSalaryAmount = $('#NetSalaryAmount').val();
            Data.BasicSalayAmount = $('#BasicSalayAmount').val();
            Data.XMLStringManPowerItemRules = EmployeeSalaryRules.XMLStringManPowerItemRules;
            Data.XMLStringForCalculateOn = EmployeeSalaryRules.XMLStringForCalculateOn;
        } else if (EmployeeSalaryRules.ActionName == "EditRules")
        {
            Data.EmployeeSalaryRulesID = $('#EmployeeSalaryRulesID').val();
            Data.TotalAmount = $('#TotalSalaryAmount').val();
            Data.GrossSalaryAmount = $('#GrossSalaryAmount').val();
            Data.NetSalaryAmount = $('#NetSalaryAmount').val();
            Data.BasicSalayAmount = $('#BasicSalayAmount').val();
            Data.FromEmployeeSalarySpanID = $('#FromEmployeeSalarySpanID').val();
            Data.XMLStringManPowerItemRules = EmployeeSalaryRules.XMLStringManPowerItemRules;
            Data.XMLStringForCalculateOn = EmployeeSalaryRules.XMLStringForCalculateOn;
        }
        return Data;
    },
    GetXmlDataForManPowerItemRules: function () {

        var DataArray = [];
        var data = $('#SelectedRules tbody tr td  input').each(function () {

            DataArray.push($(this).val());

        });
        debugger;
        var TotalRecord = DataArray.length;
      
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 10) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><RuleID>" + DataArray[i] + "</RuleID><RuleType>" + DataArray[i + 1] + "</RuleType><HeadID>" + DataArray[i + 2] + "</HeadID><FixedAmount>" + DataArray[i + 3] + "</FixedAmount><Percentage>" + DataArray[i + 4] + "</Percentage><CalculateOn>0</CalculateOn><CalculateOnFixedAmount>" + DataArray[i + 6] + "</CalculateOnFixedAmount><CalculatedAmount>" + DataArray[i + 8] + "</CalculatedAmount></row>";
        }
        if (ParameterXml.length > 6)
            EmployeeSalaryRules.XMLStringManPowerItemRules = ParameterXml + "</rows>";
        else
            EmployeeSalaryRules.XMLStringManPowerItemRules = "";
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
            EmployeeSalaryRules.XMLStringForCalculateOn = xmlParamList + "</rows>";
        else
            EmployeeSalaryRules.XMLStringForCalculateOn = "";
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeSalaryRules.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeSalaryRules.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

