//this class contain methods related to nationality functionality
var SalaryAllowanceMaster = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SalaryAllowanceMaster.constructor();
        //SalaryAllowanceMaster.initializeValidation();
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
        $('#CreateSalaryAllowanceMasterRecord').on("click", function () {
            SalaryAllowanceMaster.ActionName = "Create";
            SalaryAllowanceMaster.AjaxCallSalaryAllowanceMaster();
        });

        $('#EditSalaryAllowanceMasterRecord').on("click", function () {

            SalaryAllowanceMaster.ActionName = "Edit";
            SalaryAllowanceMaster.AjaxCallSalaryAllowanceMaster();
        });

        $('#CreateSalaryAllowanceRulesRecord').on("click", function () {
            SalaryAllowanceMaster.getCalculateOnXML();
            SalaryAllowanceMaster.ActionName = "CreateRules";
            SalaryAllowanceMaster.AjaxCallSalaryAllowanceMaster();
        });

        $('#EditSalaryAllowanceRulesRecord').on("click", function () {
            SalaryAllowanceMaster.getCalculateOnXML();
            SalaryAllowanceMaster.ActionName = "EditRules";
            SalaryAllowanceMaster.AjaxCallSalaryAllowanceMaster();
        });

        $("#btnShowList").unbind('click').click(function () {
            var SelectedCentreCode = $("#SelectedCentreCode").val();
            if (SelectedCentreCode == "") {
                notify("Please select Centre", 'warning');
                return false;
            }
            SalaryAllowanceMaster.LoadList();
        });
        $("#SelectedCentreCode").unbind('change').change(function () {
            var SelectedCentreCode = $(this).val();
            if (SelectedCentreCode == "") {
                $("ul.actions").hide();
                return false;
            }
            var href = $("#btnCreateList").attr('href');
            href = '/SalaryAllowanceMaster/Create?CentreCode=' + SelectedCentreCode
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
            url: '/SalaryAllowanceMaster/List',
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
            url: '/SalaryAllowanceMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallSalaryAllowanceMaster: function () {
        var SalaryAllowanceMasterData = null;
        if (SalaryAllowanceMaster.ActionName == "Create") {
            $("#FormCreateSalaryAllowanceMaster").validate();
            if ($("#FormCreateSalaryAllowanceMaster").valid()) {
                SalaryAllowanceMasterData = null;
                SalaryAllowanceMasterData = SalaryAllowanceMaster.GetSalaryAllowanceMaster();
                ajaxRequest.makeRequest("/SalaryAllowanceMaster/Create", "POST", SalaryAllowanceMasterData, SalaryAllowanceMaster.Success);
            }
        }
        else if (SalaryAllowanceMaster.ActionName == "Edit") {
            $("#FormEditSalaryAllowanceMaster").validate();
            if ($("#FormEditSalaryAllowanceMaster").valid()) {
                SalaryAllowanceMasterData = null;
                SalaryAllowanceMasterData = SalaryAllowanceMaster.GetSalaryAllowanceMaster();
                ajaxRequest.makeRequest("/SalaryAllowanceMaster/Edit", "POST", SalaryAllowanceMasterData, SalaryAllowanceMaster.Success);
            }
        }
        else if (SalaryAllowanceMaster.ActionName == "Delete") {
            SalaryAllowanceMasterData = null;
            //$("#FormCreateSalaryAllowanceMaster").validate();
            SalaryAllowanceMasterData = SalaryAllowanceMaster.GetSalaryAllowanceMaster();
            ajaxRequest.makeRequest("/SalaryAllowanceMaster/Delete", "POST", SalaryAllowanceMasterData, SalaryAllowanceMaster.Success);

        }
        else if (SalaryAllowanceMaster.ActionName == "CreateRules") {
            SalaryAllowanceMasterData = null;
            //$("#FormCreateSalaryAllowanceMaster").validate();
            SalaryAllowanceMasterData = SalaryAllowanceMaster.GetSalaryAllowanceMaster();
            ajaxRequest.makeRequest("/SalaryAllowanceMaster/CreateSalaryAllowanceRules", "POST", SalaryAllowanceMasterData, SalaryAllowanceMaster.Success);

        }
        else if (SalaryAllowanceMaster.ActionName == "EditRules") {
            SalaryAllowanceMasterData = null;
            //$("#FormCreateSalaryAllowanceMaster").validate();
            SalaryAllowanceMasterData = SalaryAllowanceMaster.GetSalaryAllowanceMaster();
            ajaxRequest.makeRequest("/SalaryAllowanceMaster/EditSalaryAllowanceRules", "POST", SalaryAllowanceMasterData, SalaryAllowanceMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalaryAllowanceMaster: function () {
        var Data = {
        };
        if (SalaryAllowanceMaster.ActionName == "Create" || SalaryAllowanceMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.AllowanceHeadName = $('#AllowanceHeadName').val();
            Data.AllowanceType = $('#AllowanceType').val();
            Data.AllowanceSubType = $('#AllowanceSubType').val();
            Data.ComplianceType = $('#ComplianceType').val();
        }
        else if (SalaryAllowanceMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        else if (SalaryAllowanceMaster.ActionName == "CreateRules" || SalaryAllowanceMaster.ActionName == "EditRules") {
            Data.ID = $('#ID').val();
            Data.SalaryAllowanceRulesID = $("#SalaryAllowanceRulesID").val();
            Data.IsGenderSpecific = $('#IsGenderSpecific').is(":checked") ? true : false;
            Data.Gender = $('#Gender').val();
            Data.FixedAmount = $('#FixedAmount').val();
            Data.Percentage = $('#Percentage').val();
            Data.CalculateOn = $('#CalculateOn').val();
            Data.EffectedDate = $('#EffectedDate').val();
            Data.CloseDate = $('#CloseDate').val();
            Data.IsCurrent = $('#IsCurrent').is(":checked") ? true : false;
            Data.RangeFrom = $('#RangeFrom').val();
            Data.RangeUpto = $('#RangeUpto').val();
            Data.CalculateOnFixedAmount = $('#CalculateOnFixedAmount').val();
            Data.XMLStringForCalculateOn = SalaryAllowanceMaster.XMLStringForCalculateOn;
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
            SalaryAllowanceMaster.XMLStringForCalculateOn = xmlParamList + "</rows>";
        else
            SalaryAllowanceMaster.XMLStringForCalculateOn = "";
        // alert(GeneralTaxGroupMaster.SelectedTaxMaterIDs);
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SalaryAllowanceMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SalaryAllowanceMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

