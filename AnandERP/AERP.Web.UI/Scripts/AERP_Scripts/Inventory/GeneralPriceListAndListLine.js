//this class contain methods related to nationality functionality
var GeneralPriceListAndListLine = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralPriceListAndListLine.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });



        // Create new record
        $('#CreateGeneralPriceListAndListLineRecord').on("click", function () {
            debugger;

            GeneralPriceListAndListLine.ActionName = "Create";
            if ($('#PriceListName').val() == "" || $('#PriceListName').val() == null)
            {
                $("#displayErrorMessage p").text("Please enter Price List Name").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $('#PriceListName').focus();
                return false;
            }
             else if ($("#ValidFromDate").val() == "" || $("#ValidFromDate").val() == null) {
                 $("#displayErrorMessage p").text("Please select ValidFromDate").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                 $('#ValidFromDate').focus();
                return false;
            }
             else if ($("#ValidUptoDate").val() == "" || $("#ValidUptoDate").val() == null) {
                 $("#displayErrorMessage p").text("Please select ValidUptoDate").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                 $('#ValidUptoDate').focus();
                 return false;
             }

            debugger;
            var IsRoot = $("#IsRoot").is(":checked") ? "true" : "false";
            if (IsRoot == "true")
            {
                $('#BasePriseListID').val(0);
                $('#Factor').val(0);
                $('#PriceGroupId').val(0);
                $('#IsRounding').val("false");
                $('#RoundingMethod').val(0);
            }
            else
            {
                var abc = $('#Factor').val();
                if ($('#BasePriseListID').val() == 0 || $('#BasePriseListID').val()=="")
                {
                    $("#displayErrorMessage p").text("Please enter Base PriseListID").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $('#BasePriseListID').focus();
                    return false;
                }
                else if($('#PriceGroupId').val==0 || $('#PriceGroupId').val()=="")
                {
                    $("#displayErrorMessage p").text("Please select Price Group").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $('#PriceGroupId').focus();
                    return false;
                }

            }
            var IsRounding = $("#IsRounding").is(":checked") ? "true" : "false";
            if (IsRounding == "false")
            {
                $('#RoundingMethod').val(0);
            }
            else {
                if($('#RoundingMethod').val()==0)
                {
                    $("#displayErrorMessage p").text("Please select RoundingMethod").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $('#RoundingMethod').focus();
                    return false;
                }
            }
            

            GeneralPriceListAndListLine.AjaxCallGeneralPriceListAndListLine();
        });


        $('#EditGeneralPriceListAndListLineRecord').on("click", function () {
            GeneralPriceListAndListLine.ActionName = "Edit";

            GeneralPriceListAndListLine.AjaxCallGeneralPriceListAndListLine();
        });

        $('#DeleteGeneralPriceListAndListLineRecord').on("click", function () {

            GeneralPriceListAndListLine.ActionName = "Delete";
            GeneralPriceListAndListLine.AjaxCallGeneralPriceListAndListLine();
        });

        $("#Factor").on("keydown",function(e)
        {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });


        $("#PriceListName").on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        InitAnimatedBorder();

        CloseAlert();

    },



    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/GeneralPriceListAndListLine/List',
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
            url: '/GeneralPriceListAndListLine/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallGeneralPriceListAndListLine: function () {
        var GeneralPriceListAndListLineData = null;
        if (GeneralPriceListAndListLine.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralPriceListAndListLine").validate();
            if ($("#FormCreateGeneralPriceListAndListLine").valid()) {
                GeneralPriceListAndListLineData = null;
                GeneralPriceListAndListLineData = GeneralPriceListAndListLine.GetGeneralPriceListAndListLine();

                ajaxRequest.makeRequest("/GeneralPriceListAndListLine/Create", "POST", GeneralPriceListAndListLineData, GeneralPriceListAndListLine.SuccessDetails, "CreateGeneralPriceListAndListLineRecord");
            }


        }
        else if (GeneralPriceListAndListLine.ActionName == "Edit") {
            $("#FormEditGeneralPriceListAndListLine").validate();
            if ($("#FormEditGeneralPriceListAndListLine").valid()) {
                GeneralPriceListAndListLineData = null;

                GeneralPriceListAndListLineData = GeneralPriceListAndListLine.GetGeneralPriceListAndListLine();

                ajaxRequest.makeRequest("/GeneralPriceListAndListLine/Edit", "POST", GeneralPriceListAndListLineData, GeneralPriceListAndListLine.Success);

            }
        }
        else if (GeneralPriceListAndListLine.ActionName == "Delete") {
            GeneralPriceListAndListLineData = null;
            //$("#FormCreateGeneralPriceListAndListLine").validate();
            GeneralPriceListAndListLineData = GeneralPriceListAndListLine.GetGeneralPriceListAndListLine();
            ajaxRequest.makeRequest("/GeneralPriceListAndListLine/Delete", "POST", GeneralPriceListAndListLineData, GeneralPriceListAndListLine.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralPriceListAndListLine: function () {

        var Data = {
        };
        if (GeneralPriceListAndListLine.ActionName == "Create" || GeneralPriceListAndListLine.ActionName == "Edit") {
            debugger;
            debugger;
            Data.PriceListName = $('#PriceListName').val();
            Data.BasePriseListID = $('#BasePriseListID').val();
            Data.Factor = $('#Factor').val();
            Data.RoundingMethod = $('#RoundingMethod').val();
            Data.IsRoot = $("#IsRounding").is(":checked") ? "true" : "false";
            Data.IsRoot = $("#IsRoot").is(":checked") ? "true" : "false";
            Data.IsActive = $("#IsActive").is(":checked") ? "true" : "false";
            Data.ValidFromDate = $('#ValidFromDate').val();
            Data.ValidUptoDate = $('#ValidUptoDate').val();
            Data.PriceGroupId = $('#PriceGroupId').val();
            Data.IsUpdationAutomatic = $("#IsUpdationAutomatic").is(":checked") ? "true" : "false";
        }
        else if (GeneralPriceListAndListLine.ActionName == "Delete") {
            Data.GeneralPriceListAndListLineID = $('input[name=GeneralPriceListAndListLineID]').val();

        }
        return Data;
    },




    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            GeneralPriceListAndListLine.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
    SuccessDetails: function (data) {
        debugger;
        debugger;
        
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            // $.magnificPopup.close()
            var IsRoot = $("#IsRoot").is(":checked") ? "true" : "false";
            var IsRoot1;
            if (IsRoot1 == "true") {
                IsRoot1 = "<td> <input id='IsRoot' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
            }
            else {
                IsRoot1 = "<td> <input id='IsRoot' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
            }

            var IsActive = $("#IsActive").is(":checked") ? "true" : "false";
            var IsActive1;
            if (IsActive == "true") {
                IsActive1 = "<td> <input id='IsActive' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
            }
            else {
                IsActive1 = "<td> <input id='IsActive' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
            }

            var IsUpdationAutomatic = $("#IsUpdationAutomatic").is(":checked") ? "true" : "false";
            var IsUpdationAutomatic1;
            if (IsUpdationAutomatic == "true") {
                IsUpdationAutomatic1 = "<td> <input id='IsActive' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
            }
            else {
                IsUpdationAutomatic1 = "<td> <input id='IsActive' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
            }
            var IsUpdationAutomatic = $("#IsUpdationAutomatic").is(":checked") ? "true" : "false";
            var IsRounding1;
            if (IsRounding == "true") {
                IsRounding1 = "<td> <input id='IsActive' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
            }
            else {
                IsRounding1 = "<td> <input id='IsActive' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
            }
            $("#tblData tbody").append(
              "<tr>" +
             "<td><input id='PriceListName' type='hidden' value=" + $('#PriceListName').val() + "/>" + $('#PriceListName').val() + "</td>" +
              "<td><input id='BasePriseListID' type='hidden' value=" + $('#BasePriseListID').val() + "/>" + $('#BasePriseListID').text() + "</td>" +
              "<td><input id='Factor' type='hidden' value=" + $('#Factor').val() + "/>" + $('#Factor').val() + "</td>" +
              "<td><input id='PriceGroupId' type='hidden' value=" + $('#PriceGroupId').val() + "/>" + $('#PriceGroupId').text() + "</td>" +
              IsRoot1 +
              IsActive1+
              "<td><input id='ValidFromDate' type='hidden' value=" + $('#ValidFromDate').val() + "/>" + $('#ValidFromDate').val() + "</td>" +
              "<td><input id='ValidUptoDate' type='hidden' value=" + $('#ValidUptoDate').val() + "/>" + $('#ValidUptoDate').val() + "</td>" +
              IsRounding1 +
               "<td><input id='RoundingMethod' type='hidden' value=" + $('#RoundingMethod').val() + "/>" + $('#RoundingMethod').val() + "</td>" +
               IsUpdationAutomatic1+
    "</tr>");
            $("#PriceListName").val("");
            $("#BasePriseListID").val("");
            $("#PriceGroupId").val("");
            $("#Factor").val("");
            $("#RoundingMethod").val("");
            $("#ValidFromDate").val("");
            $("#ValidUptoDate").val("");
            $("#IsRoot").removeAttr('checked');
            $("#IsActive").removeAttr('checked');
            $("#IsUpdationAutomatic").removeAttr('checked');

            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            ListViewReload();
            
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};

