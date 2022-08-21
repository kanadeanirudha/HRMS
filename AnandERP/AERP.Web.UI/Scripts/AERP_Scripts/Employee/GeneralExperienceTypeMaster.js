//this class contain methods related to nationality functionality
var GeneralExperienceTypeMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralExperienceTypeMaster.constructor();
        //GeneralExperienceTypeMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#ExperienceTypeDescription').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        // Create new record
        $('#CreateGeneralExperienceTypeMasterRecord').on("click", function () {
            GeneralExperienceTypeMaster.ActionName = "Create";
            GeneralExperienceTypeMaster.AjaxCallGeneralExperienceTypeMaster();
        });

        $('#EditGeneralExperienceTypeMasterRecord').on("click", function () {

            GeneralExperienceTypeMaster.ActionName = "Edit";
            GeneralExperienceTypeMaster.AjaxCallGeneralExperienceTypeMaster();
        });

        $('#DeleteGeneralExperienceTypeMasterRecord').on("click", function () {

            GeneralExperienceTypeMaster.ActionName = "Delete";
            GeneralExperienceTypeMaster.AjaxCallGeneralExperienceTypeMaster();
        });
        $('#ExperienceTypeDescription').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $("#UserSearch").keyup(function () {
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
             url: '/GeneralExperienceTypeMaster/List',
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
            url: '/GeneralExperienceTypeMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralExperienceTypeMaster: function () {
        var GeneralExperienceTypeMasterData = null;
        if (GeneralExperienceTypeMaster.ActionName == "Create") {
            $("#FormCreateGeneralExperienceTypeMaster").validate();
            if ($("#FormCreateGeneralExperienceTypeMaster").valid()) {
                GeneralExperienceTypeMasterData = null;
                GeneralExperienceTypeMasterData = GeneralExperienceTypeMaster.GetGeneralExperienceTypeMaster();
                ajaxRequest.makeRequest("/GeneralExperienceTypeMaster/Create", "POST", GeneralExperienceTypeMasterData, GeneralExperienceTypeMaster.Success);
            }
        }
        else if (GeneralExperienceTypeMaster.ActionName == "Edit") {
            $("#FormEditGeneralExperienceTypeMaster").validate();
            if ($("#FormEditGeneralExperienceTypeMaster").valid()) {
                GeneralExperienceTypeMasterData = null;
                GeneralExperienceTypeMasterData = GeneralExperienceTypeMaster.GetGeneralExperienceTypeMaster();
                ajaxRequest.makeRequest("/GeneralExperienceTypeMaster/Edit", "POST", GeneralExperienceTypeMasterData, GeneralExperienceTypeMaster.Success);
            }
        }
        else if (GeneralExperienceTypeMaster.ActionName == "Delete") {
            GeneralExperienceTypeMasterData = null;
            //$("#FormCreateGeneralExperienceTypeMaster").validate();
            GeneralExperienceTypeMasterData = GeneralExperienceTypeMaster.GetGeneralExperienceTypeMaster();
            ajaxRequest.makeRequest("/GeneralExperienceTypeMaster/Delete", "POST", GeneralExperienceTypeMasterData, GeneralExperienceTypeMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralExperienceTypeMaster: function () {
        var Data = {
        };

        if (GeneralExperienceTypeMaster.ActionName == "Create" || GeneralExperienceTypeMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.ExperienceTypeDescription = $('#ExperienceTypeDescription').val();

        }
        else if (GeneralExperienceTypeMaster.ActionName == "Delete") {
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
            GeneralExperienceTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralExperienceTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

};

