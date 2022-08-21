//this class contain methods related to nationality functionality
var GeneralEducationTypeMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralEducationTypeMaster.constructor();
        //GeneralEducationTypeMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $("#Description").focus();
        });

        // Create new record
        $('#CreateGeneralEducationTypeMasterRecord').on("click", function () {
            GeneralEducationTypeMaster.ActionName = "Create";
            GeneralEducationTypeMaster.AjaxCallGeneralEducationTypeMaster();
        });

        $('#EditGeneralEducationTypeMasterRecord').on("click", function () {

            GeneralEducationTypeMaster.ActionName = "Edit";
            GeneralEducationTypeMaster.AjaxCallGeneralEducationTypeMaster();
        });

        $('#DeleteGeneralEducationTypeMasterRecord').on("click", function () {

            GeneralEducationTypeMaster.ActionName = "Delete";
            GeneralEducationTypeMaster.AjaxCallGeneralEducationTypeMaster();
        });
        $('#SeqNo').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
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

        $('#Description').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#EduSequenceNumber').on("keydown", function (e) {
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
             url: '/GeneralEducationTypeMaster/List',
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
            url: '/GeneralEducationTypeMaster/List',
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
    AjaxCallGeneralEducationTypeMaster: function () {
        var GeneralEducationTypeMasterData = null;
        if (GeneralEducationTypeMaster.ActionName == "Create") {
            $("#FormCreateGeneralEducationTypeMaster").validate();
            if ($("#FormCreateGeneralEducationTypeMaster").valid()) {
                GeneralEducationTypeMasterData = null;
                GeneralEducationTypeMasterData = GeneralEducationTypeMaster.GetGeneralEducationTypeMaster();
                ajaxRequest.makeRequest("/GeneralEducationTypeMaster/Create", "POST", GeneralEducationTypeMasterData, GeneralEducationTypeMaster.Success);
            }
        }
        else if (GeneralEducationTypeMaster.ActionName == "Edit") {
            $("#FormEditGeneralEducationTypeMaster").validate();
            if ($("#FormEditGeneralEducationTypeMaster").valid()) {
                GeneralEducationTypeMasterData = null;
                GeneralEducationTypeMasterData = GeneralEducationTypeMaster.GetGeneralEducationTypeMaster();
                ajaxRequest.makeRequest("/GeneralEducationTypeMaster/Edit", "POST", GeneralEducationTypeMasterData, GeneralEducationTypeMaster.Success);
            }
        }
        else if (GeneralEducationTypeMaster.ActionName == "Delete") {
            GeneralEducationTypeMasterData = null;
            //$("#FormCreateGeneralEducationTypeMaster").validate();
            GeneralEducationTypeMasterData = GeneralEducationTypeMaster.GetGeneralEducationTypeMaster();

            ajaxRequest.makeRequest("/GeneralEducationTypeMaster/Delete", "POST", GeneralEducationTypeMasterData, GeneralEducationTypeMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralEducationTypeMaster: function () {
        var Data = {
        };
        if (GeneralEducationTypeMaster.ActionName == "Create" || GeneralEducationTypeMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.Description = $('#Description').val();
            Data.EduSequenceNumber = $('#EduSequenceNumber').val();
        }
        else if (GeneralEducationTypeMaster.ActionName == "Delete") {
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
            GeneralEducationTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralEducationTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
 };

