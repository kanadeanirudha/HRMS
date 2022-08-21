//this class contain methods related to nationality functionality
var CCRMCauseMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMCauseMaster.constructor();
        //CCRMEngineersGroupMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });



        // Create new record

        $('#CreateCCRMCauseTypeRecord').on("click", function () {

            CCRMCauseMaster.ActionName = "Create";
            CCRMCauseMaster.AjaxCallCCRMCauseMaster();
        });

        $('#CreateCCRMCauseMasterRecord').on("click", function () {

            CCRMCauseMaster.ActionName = "CreateMaster";
            CCRMCauseMaster.AjaxCallCCRMCauseMaster();
        });


        $('#EditCCRMCauseTypeRecord').on("click", function () {

            CCRMCauseMaster.ActionName = "Edit";
            CCRMCauseMaster.AjaxCallCCRMCauseMaster();
        });

        $('#DeleteCCRMCauseMasterRecord').on("click", function () {

            CCRMCauseMaster.ActionName = "Delete";
            CCRMCauseMaster.AjaxCallCCRMCauseMaster();
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
             url: '/CCRMCauseMaster/List',
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
            url: '/CCRMCauseMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallCCRMCauseMaster: function () {
        var CCRMCauseMasterData = null;

        if (CCRMCauseMaster.ActionName == "Create") {

            $("#FormCreateCCRMCauseType").validate();
            if ($("#FormCreateCCRMCauseType").valid()) {
                CCRMCauseMasterData = null;
                CCRMCauseMasterData = CCRMCauseMaster.GetCCRMCauseMaster();
                ajaxRequest.makeRequest("/CCRMCauseMaster/Create", "POST", CCRMCauseMasterData, CCRMCauseMaster.Success, "CreateCCRMSymptomTypeRecord");
            }
        }
        else if (CCRMCauseMaster.ActionName == "CreateMaster") {
            $("#FormCreateCCRMCauseMaster").validate();
            if ($("#FormCreateCCRMCauseMaster").valid()) {
                CCRMCauseMasterData = null;
                CCRMCauseMasterData = CCRMCauseMaster.GetCCRMCauseMaster();
                ajaxRequest.makeRequest("/CCRMCauseMaster/CreateCCRMCauseMaster", "POST", CCRMCauseMasterData, CCRMCauseMaster.Success);
            }
        }

        else if (CCRMCauseMaster.ActionName == "Edit") {
            $("#FormEditCCRMCauseType").validate();
            if ($("#FormEditCCRMCauseType").valid()) {
                CCRMCauseMasterData = null;
                CCRMCauseMasterData = CCRMCauseMaster.GetCCRMCauseMaster();
                ajaxRequest.makeRequest("/CCRMCauseMaster/Edit", "POST", CCRMCauseMasterData, CCRMCauseMaster.Success);
            }
        }
        else if (CCRMCauseMaster.ActionName == "Delete") {

            CCRMCauseMasterData = null;
            //$("#FormCreateCCRMEngineersGroupMaster").validate();
            CCRMCauseMasterData = CCRMCauseMaster.GetCCRMCauseMaster();
            ajaxRequest.makeRequest("/CCRMCauseMaster/Delete", "POST", CCRMCauseMasterData, CCRMCauseMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMCauseMaster: function () {
        var Data = {
        };

        if (CCRMCauseMaster.ActionName == "Create" || CCRMCauseMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.CauseTypeTitle = $('#CauseTypeTitle').val();
            Data.CauseTypeCode = $('#CauseTypeCode').val();
            Data.CauseTypeDescription = $('#CauseTypeDescription').val();

        }
        else if (CCRMCauseMaster.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        else if (CCRMCauseMaster.ActionName == "CreateMaster" || CCRMCauseMaster.ActionName == "EditMaster") {
            Data.ID = $('#ID').val();
            Data.CauseTitle = $('#CauseTitle').val();
            Data.CauseCode = $('#CauseCode').val();
            Data.CauseDescription = $('#CauseDescription').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CCRMCauseMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};