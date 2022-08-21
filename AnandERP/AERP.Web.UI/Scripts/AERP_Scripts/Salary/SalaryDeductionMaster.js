//this class contain methods related to nationality functionality
var SalaryDeductionMaster = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SalaryDeductionMaster.constructor();
        //SalaryDeductionMaster.initializeValidation();
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
        $('#CreateSalaryDeductionMasterRecord').on("click", function () {
            SalaryDeductionMaster.ActionName = "Create";
            SalaryDeductionMaster.AjaxCallSalaryDeductionMaster();
        });

        $('#EditSalaryDeductionMasterRecord').on("click", function () {

            SalaryDeductionMaster.ActionName = "Edit";
            SalaryDeductionMaster.AjaxCallSalaryDeductionMaster();
        });

        $('#CreateSalaryDeductionRulesRecord').on("click", function () {
            SalaryDeductionMaster.getCalculateOnXML();
            SalaryDeductionMaster.ActionName = "CreateRules";
            SalaryDeductionMaster.AjaxCallSalaryDeductionMaster();
        });

        $('#EditSalaryDeductionRulesRecord').on("click", function () {
            SalaryDeductionMaster.getCalculateOnXML();
            SalaryDeductionMaster.ActionName = "EditRules";
            SalaryDeductionMaster.AjaxCallSalaryDeductionMaster();
        });

        $("#btnShowList").unbind('click').click(function () {
            var SelectedCentreCode = $("#SelectedCentreCode").val();
            if (SelectedCentreCode == "") {
                notify("Please select Centre", 'warning');
                return false;
            }
            SalaryDeductionMaster.LoadList();
        });
        $("#SelectedCentreCode").unbind('change').change(function () {
            var SelectedCentreCode = $(this).val();
            if (SelectedCentreCode == "") {
                $("ul.actions").hide();
                return false;
            }
            var href = $("#btnCreateList").attr('href');
            href = '/SalaryDeductionMaster/Create?CentreCode=' + SelectedCentreCode
            $("#btnCreateList").attr('href', href);
            $("ul.actions").show();

        });

        $('#EffectedDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //minDate: moment(),
            ignoreReadonly: true,
        })

        $('#CloseDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //minDate: moment(),
            ignoreReadonly: true,
        })

        InitAnimatedBorder();
        CloseAlert();
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",

            dataType: "html",
            url: '/SalaryDeductionMaster/List',
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
            url: '/SalaryDeductionMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallSalaryDeductionMaster: function () {
        var SalaryDeductionMasterData = null;
        if (SalaryDeductionMaster.ActionName == "Create") {
            $("#FormCreateSalaryDeductionMaster").validate();
            if ($("#FormCreateSalaryDeductionMaster").valid()) {
                SalaryDeductionMasterData = null;
                SalaryDeductionMasterData = SalaryDeductionMaster.GetSalaryDeductionMaster();
                ajaxRequest.makeRequest("/SalaryDeductionMaster/Create", "POST", SalaryDeductionMasterData, SalaryDeductionMaster.Success);
            }
        }
        else if (SalaryDeductionMaster.ActionName == "Edit") {
            $("#FormEditSalaryDeductionMaster").validate();
            if ($("#FormEditSalaryDeductionMaster").valid()) {
                SalaryDeductionMasterData = null;
                SalaryDeductionMasterData = SalaryDeductionMaster.GetSalaryDeductionMaster();
                ajaxRequest.makeRequest("/SalaryDeductionMaster/Edit", "POST", SalaryDeductionMasterData, SalaryDeductionMaster.Success);
            }
        }
        else if (SalaryDeductionMaster.ActionName == "Delete") {
            SalaryDeductionMasterData = null;
            //$("#FormCreateSalaryDeductionMaster").validate();
            SalaryDeductionMasterData = SalaryDeductionMaster.GetSalaryDeductionMaster();
            ajaxRequest.makeRequest("/SalaryDeductionMaster/Delete", "POST", SalaryDeductionMasterData, SalaryDeductionMaster.Success);

        }
        else if (SalaryDeductionMaster.ActionName == "CreateRules") {
            SalaryDeductionMasterData = null;
            //$("#FormCreateSalaryDeductionMaster").validate();
            SalaryDeductionMasterData = SalaryDeductionMaster.GetSalaryDeductionMaster();
            ajaxRequest.makeRequest("/SalaryDeductionMaster/CreateSalaryDeductionRules", "POST", SalaryDeductionMasterData, SalaryDeductionMaster.Success);

        }
        else if (SalaryDeductionMaster.ActionName == "EditRules") {
                SalaryDeductionMasterData = null;
            //$("#FormCreateSalaryDeductionMaster").validate();
                SalaryDeductionMasterData = SalaryDeductionMaster.GetSalaryDeductionMaster();
                ajaxRequest.makeRequest("/SalaryDeductionMaster/EditSalaryDeductionRules", "POST", SalaryDeductionMasterData, SalaryDeductionMaster.Success);

            } 
    },
    //Get properties data from the Create, Update and Delete page
    GetSalaryDeductionMaster: function () {
        var Data = {
        };
        if (SalaryDeductionMaster.ActionName == "Create" || SalaryDeductionMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.DeductionHeadName = $('#DeductionHeadName').val();
            Data.DeductionType = $('#DeductionType').val();
            Data.DeductionSubType = $('#DeductionSubType').val();
            Data.ComplianceType = $('#ComplianceType').val();
        }
        else if (SalaryDeductionMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        else if (SalaryDeductionMaster.ActionName == "CreateRules" || SalaryDeductionMaster.ActionName == "EditRules") {
            Data.ID = $('#ID').val();
            Data.SalaryDeductionRulesID = $("#SalaryDeductionRulesID").val();
            Data.IsGenderSpecific = $('#IsGenderSpecific').is(":checked") ? true : false;
            Data.Gender = $('#Gender').val();
            Data.FixedAmount = $('#FixedAmount').val();
            Data.Percentage = $('#Percentage').val();
            Data.CalculateOn = $('#CalculateOn').val();
            Data.EffectedDate = $('#EffectedDate').val();
            Data.CloseDate = $('#CloseDate').val();
            Data.IsCurrent = $('#IsCurrent').is(":checked") ? true : false;
            Data.ContributionType = $('#ContributionType').val();
            Data.RangeFrom = $('#RangeFrom').val();
            Data.RangeUpto = $('#RangeUpto').val();
            Data.CalculateOnFixedAmount = $('#CalculateOnFixedAmount').val();
       
            Data.XMLStringForCalculateOn = SalaryDeductionMaster.XMLStringForCalculateOn;
        }
        return Data;
    },
    getCalculateOnXML: function () {

        var sList = "";
        //var CalculateOn = 0;
        var xmlParamList = "<rows>"
        //alert();
        //$('#checkboxlist input[type=checkbox]').each(function () {
        $('#CalculateOn option').each(function () {

            if ($(this).val() != "on") {
                CalculateOn = $(this).val();
                //sArray = $(this).val().split("~");
                if (this.selected == true) {
                    //xmlInsert code here
                    var splitCal = CalculateOn.split('~');
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitCal[2] + "</ID>" + "<ReferenceID>" + splitCal[0] + "</ReferenceID><AllowanceOrDeduction>" + splitCal[1] + "</AllowanceOrDeduction><Percentage>" + $("#Percentage").val() + "</Percentage></row>";
                }
            }
        });
        if (xmlParamList.length > 6)
            SalaryDeductionMaster.XMLStringForCalculateOn = xmlParamList + "</rows>";
        else
            SalaryDeductionMaster.XMLStringForCalculateOn = "";
        // alert(GeneralTaxGroupMaster.SelectedTaxMaterIDs);
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SalaryDeductionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SalaryDeductionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

