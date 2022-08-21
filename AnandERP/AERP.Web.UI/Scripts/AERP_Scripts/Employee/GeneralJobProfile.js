//this class contain methods related to nationality functionality
var GeneralJobProfile = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralJobProfile.constructor();
        //GeneralJobProfile.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#JobProfileDescription').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        // Create new record
        $('#CreateGeneralJobProfileRecord').on("click", function () {
            GeneralJobProfile.ActionName = "Create";
            GeneralJobProfile.AjaxCallGeneralJobProfile();
        });

        $('#EditGeneralJobProfileRecord').on("click", function () {

            GeneralJobProfile.ActionName = "Edit";
            GeneralJobProfile.AjaxCallGeneralJobProfile();
        });

        $('#DeleteGeneralJobProfileRecord').on("click", function () {

            GeneralJobProfile.ActionName = "Delete";
            GeneralJobProfile.AjaxCallGeneralJobProfile();
        });
        $('#JobProfileDescription').on("keydown", function (e) {
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
             url: '/GeneralJobProfile/List',
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
            url: '/GeneralJobProfile/List',
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
    AjaxCallGeneralJobProfile: function () {
        var GeneralJobProfileData = null;
        if (GeneralJobProfile.ActionName == "Create") {
            $("#FormCreateGeneralJobProfile").validate();
            if ($("#FormCreateGeneralJobProfile").valid()) {
                GeneralJobProfileData = null;
                GeneralJobProfileData = GeneralJobProfile.GetGeneralJobProfile();
                ajaxRequest.makeRequest("/GeneralJobProfile/Create", "POST", GeneralJobProfileData, GeneralJobProfile.Success);
            }
        }
        else if (GeneralJobProfile.ActionName == "Edit") {
            $("#FormEditGeneralJobProfile").validate();
            if ($("#FormEditGeneralJobProfile").valid()) {
                GeneralJobProfileData = null;
                GeneralJobProfileData = GeneralJobProfile.GetGeneralJobProfile();
                ajaxRequest.makeRequest("/GeneralJobProfile/Edit", "POST", GeneralJobProfileData, GeneralJobProfile.Success);
            }
        }
        else if (GeneralJobProfile.ActionName == "Delete") {
            GeneralJobProfileData = null;
            //$("#FormCreateGeneralJobProfile").validate();
            GeneralJobProfileData = GeneralJobProfile.GetGeneralJobProfile();
            ajaxRequest.makeRequest("/GeneralJobProfile/Delete", "POST", GeneralJobProfileData, GeneralJobProfile.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralJobProfile: function () {
        var Data = {
        };

        if (GeneralJobProfile.ActionName == "Create" || GeneralJobProfile.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.JobProfileDescription = $('#JobProfileDescription').val();
        }
        else if (GeneralJobProfile.ActionName == "Delete") {
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
            GeneralJobProfile.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralJobProfile.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

};

