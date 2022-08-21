//this class contain methods related to nationality functionality
var GeneralTaxMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralTaxMaster.constructor();
        //GeneralTaxMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#TaxName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :radio').val("");
            $('input:radio').removeAttr('checked');
            $('#TaxName').focus();
            $('#IsOtherState').removeAttr('checked');

            return false;
        });

        // Create new record
        $('#CreateGeneralTaxMasterRecord').on("click", function () {
            GeneralTaxMaster.ActionName = "Create";
            GeneralTaxMaster.AjaxCallGeneralTaxMaster();
        });

        $('#EditGeneralTaxMasterRecord').on("click", function () {

            GeneralTaxMaster.ActionName = "Edit";
            GeneralTaxMaster.AjaxCallGeneralTaxMaster();
        });

        $('#DeleteGeneralTaxMasterRecord').on("click", function () {

            GeneralTaxMaster.ActionName = "Delete";
            GeneralTaxMaster.AjaxCallGeneralTaxMaster();
        });
        $('#TaxName').on("keydown", function (e) {
            AERPValidation.AllowAlphaNumericOnly(e);
        });
        $('#TaxRate').on("keydown keypress", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {

            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
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
             url: '/GeneralTaxMaster/List',
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
            url: '/GeneralTaxMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralTaxMaster: function () {
        var GeneralTaxMasterData = null;
        if (GeneralTaxMaster.ActionName == "Create") {
            $("#FormCreateGeneralTaxMaster").validate();
            if ($("#FormCreateGeneralTaxMaster").valid()) {
                GeneralTaxMasterData = null;
                GeneralTaxMasterData = GeneralTaxMaster.GetGeneralTaxMaster();
                ajaxRequest.makeRequest("/GeneralTaxMaster/Create", "POST", GeneralTaxMasterData, GeneralTaxMaster.Success);
            }
        }
        else if (GeneralTaxMaster.ActionName == "Edit") {
            $("#FormEditGeneralTaxMaster").validate();
            if ($("#FormEditGeneralTaxMaster").valid()) {
                GeneralTaxMasterData = null;
                GeneralTaxMasterData = GeneralTaxMaster.GetGeneralTaxMaster();
                ajaxRequest.makeRequest("/GeneralTaxMaster/Edit", "POST", GeneralTaxMasterData, GeneralTaxMaster.Success);
            }
        }
        else if (GeneralTaxMaster.ActionName == "Delete") {
            GeneralTaxMasterData = null;
            //$("#FormCreateGeneralTaxMaster").validate();
            GeneralTaxMasterData = GeneralTaxMaster.GetGeneralTaxMaster();
            ajaxRequest.makeRequest("/GeneralTaxMaster/Delete", "POST", GeneralTaxMasterData, GeneralTaxMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralTaxMaster: function () {
        var Data = {
        };
        if (GeneralTaxMaster.ActionName == "Create" || GeneralTaxMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.TaxName = $('#TaxName').val();
            Data.TaxRate = $('#TaxRate').val();

            //alert($('input[name=IsOtherState]:checked').val());
            Data.IsOtherState = $('input[id=IsOtherState]').is(":checked") ? "true" : "false";


            // Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
        }
        else if (GeneralTaxMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralTaxMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralTaxMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

