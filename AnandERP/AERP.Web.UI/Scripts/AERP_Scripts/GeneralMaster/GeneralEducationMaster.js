//this class contain methods related to nationality functionality
var GeneralEducationMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralEducationMaster.constructor();
        //GeneralEducationMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#EducationTypeID').val('');
            $('#Unit').val('');
            $('#EducationTypeID').focus();
            return false;
        });

        // Create new record
        $('#CreateGeneralEducationMasterRecord').on("click", function () {
            GeneralEducationMaster.ActionName = "Create";
            GeneralEducationMaster.AjaxCallGeneralEducationMaster();
        });

        $('#EditGeneralEducationMasterRecord').on("click", function () {

            GeneralEducationMaster.ActionName = "Edit";
            GeneralEducationMaster.AjaxCallGeneralEducationMaster();
        });

        $('#DeleteGeneralEducationMasterRecord').on("click", function () {

            GeneralEducationMaster.ActionName = "Delete";
            GeneralEducationMaster.AjaxCallGeneralEducationMaster();
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

        InitAnimatedBorder();
        CloseAlert();


        $('#NumberOfYears').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralEducationMaster/List',
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
            data: { actionMode: actionMode },
            url: '/GeneralEducationMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralEducationMaster: function () {
        var GeneralEducationMasterData = null;
        if (GeneralEducationMaster.ActionName == "Create") {
            $("#FormCreateGeneralEducationMaster").validate();
            if ($("#FormCreateGeneralEducationMaster").valid()) {
                GeneralEducationMasterData = null;
                GeneralEducationMasterData = GeneralEducationMaster.GetGeneralEducationMaster();
                ajaxRequest.makeRequest("/GeneralEducationMaster/Create", "POST", GeneralEducationMasterData, GeneralEducationMaster.Success);
            }
        }
        else if (GeneralEducationMaster.ActionName == "Edit") {
            $("#FormEditGeneralEducationMaster").validate();
            if ($("#FormEditGeneralEducationMaster").valid()) {
                GeneralEducationMasterData = null;
                GeneralEducationMasterData = GeneralEducationMaster.GetGeneralEducationMaster();
                ajaxRequest.makeRequest("/GeneralEducationMaster/Edit", "POST", GeneralEducationMasterData, GeneralEducationMaster.Success);
            }
        }
        else if (GeneralEducationMaster.ActionName == "Delete") {
            GeneralEducationMasterData = null;
            //$("#FormCreateGeneralEducationMaster").validate();
            GeneralEducationMasterData = GeneralEducationMaster.GetGeneralEducationMaster();

            ajaxRequest.makeRequest("/GeneralEducationMaster/Delete", "POST", GeneralEducationMasterData, GeneralEducationMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralEducationMaster: function () {
        var Data = {
        };
        if (GeneralEducationMaster.ActionName == "Create" || GeneralEducationMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.Description = $('#Description').val();
            Data.NumberOfYears = $('#NumberOfYears').val();
            Data.EducationTypeID = $('#EducationTypeID').val();
            Data.SelectedEducationTypeID = $('#SelectedEducationTypeID').val();
            Data.Unit = $('#Unit').val();
        }
        else if (GeneralEducationMaster.ActionName == "Delete") {
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
            GeneralEducationMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralEducationMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

