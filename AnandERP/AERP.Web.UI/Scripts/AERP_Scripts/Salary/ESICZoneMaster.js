//this class contain methods related to nationality functionality
var ESICZoneMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ESICZoneMaster.constructor();
        //ESICZoneMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });



        // Create new record

        $('#CreateESICZoneMasterRecord').on("click", function () {

            ESICZoneMaster.ActionName = "Create";
            ESICZoneMaster.AjaxCallESICZoneMaster();
        });

        $('#EditESICZoneMasterRecord').on("click", function () {

            ESICZoneMaster.ActionName = "Edit";
            ESICZoneMaster.AjaxCallESICZoneMaster();
        });

        $('#DeleteESICZoneMasterRecord').on("click", function () {

            ESICZoneMaster.ActionName = "Delete";
            ESICZoneMaster.AjaxCallESICZoneMaster();
        });

        $('#MovementType').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MovementCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);

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
             url: '/ESICZoneMaster/List',
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
            url: '/ESICZoneMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallESICZoneMaster: function () {
        var ESICZoneMasterData = null;

        if (ESICZoneMaster.ActionName == "Create") {

            $("#FormCreateESICZoneMaster").validate();
            if ($("#FormCreateESICZoneMaster").valid()) {
                ESICZoneMasterData = null;
                ESICZoneMasterData = ESICZoneMaster.GetESICZoneMaster();
                ajaxRequest.makeRequest("/ESICZoneMaster/Create", "POST", ESICZoneMasterData, ESICZoneMaster.Success, "CreateESICZoneMasterRecord");
            }
        }
        else if (ESICZoneMaster.ActionName == "Edit") {
            $("#FormEditESICZoneMaster").validate();
            if ($("#FormEditESICZoneMaster").valid()) {
                ESICZoneMasterData = null;
                ESICZoneMasterData = ESICZoneMaster.GetESICZoneMaster();
                ajaxRequest.makeRequest("/ESICZoneMaster/Edit", "POST", ESICZoneMasterData, ESICZoneMaster.Success);
            }
        }
        else if (ESICZoneMaster.ActionName == "Delete") {

            ESICZoneMasterData = null;
            //$("#FormCreateESICZoneMaster").validate();
            ESICZoneMasterData = ESICZoneMaster.GetESICZoneMaster();
            ajaxRequest.makeRequest("/ESICZoneMaster/Delete", "POST", ESICZoneMasterData, ESICZoneMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetESICZoneMaster: function () {
        var Data = {
        };

        if (ESICZoneMaster.ActionName == "Create" || ESICZoneMaster.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.ZoneName = $('#ZoneName').val();
            Data.ZoneCode = $('#ZoneCode').val();
            Data.IsDefault = $("#IsDefault").is(":checked") ? "true" : "false";

        }
        else if (ESICZoneMaster.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            ESICZoneMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};