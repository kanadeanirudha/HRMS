//this class contain methods related to nationality functionality
var CCRMSymptomMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMSymptomMaster.constructor();
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

        $('#CreateCCRMSymptomTypeRecord').on("click", function () {
          
            CCRMSymptomMaster.ActionName = "Create";
            CCRMSymptomMaster.AjaxCallCCRMSymptomMaster();
        });

        $('#CreateCCRMSymptomMasterRecord').on("click", function () {
            
            CCRMSymptomMaster.ActionName = "CreateMaster";
            CCRMSymptomMaster.AjaxCallCCRMSymptomMaster();
        });


        $('#EditCCRMSymptomTypeRecord').on("click", function () {

            CCRMSymptomMaster.ActionName = "Edit";
            CCRMSymptomMaster.AjaxCallCCRMSymptomMaster();
        });

        $('#DeleteCCRMSymptomMasterRecord').on("click", function () {

            CCRMSymptomMaster.ActionName = "Delete";
            CCRMSymptomMaster.AjaxCallCCRMSymptomMaster();
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
             url: '/CCRMSymptomMaster/List',
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
            url: '/CCRMSymptomMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallCCRMSymptomMaster: function () {
        var CCRMSymptomMasterData = null;

        if (CCRMSymptomMaster.ActionName == "Create") {

            $("#FormCreateCCRMSymptomType").validate();
            if ($("#FormCreateCCRMSymptomType").valid()) {
                CCRMSymptomMasterData = null;
                CCRMSymptomMasterData = CCRMSymptomMaster.GetCCRMSymptomMaster();
                ajaxRequest.makeRequest("/CCRMSymptomMaster/Create", "POST", CCRMSymptomMasterData, CCRMSymptomMaster.Success, "CreateCCRMSymptomTypeRecord");
            }
        }
        else if (CCRMSymptomMaster.ActionName == "CreateMaster") {
            $("#FormCreateCCRMSymptomMaster").validate();
            if ($("#FormCreateCCRMSymptomMaster").valid()) {
                CCRMSymptomMasterData = null;
                CCRMSymptomMasterData = CCRMSymptomMaster.GetCCRMSymptomMaster();
                ajaxRequest.makeRequest("/CCRMSymptomMaster/CreateCCRMSymptomMaster", "POST", CCRMSymptomMasterData, CCRMSymptomMaster.Success);
            }
        }

        else if (CCRMSymptomMaster.ActionName == "Edit") {
            $("#FormEditCCRMSymptomType").validate();
            if ($("#FormEditCCRMSymptomType").valid()) {
                CCRMSymptomMasterData = null;
                CCRMSymptomMasterData = CCRMSymptomMaster.GetCCRMSymptomMaster();
                ajaxRequest.makeRequest("/CCRMSymptomMaster/Edit", "POST", CCRMSymptomMasterData, CCRMSymptomMaster.Success);
            }
        }
        else if (CCRMSymptomMaster.ActionName == "Delete") {

            CCRMSymptomMasterData = null;
            //$("#FormCreateCCRMEngineersGroupMaster").validate();
            CCRMSymptomMasterData = CCRMSymptomMaster.GetCCRMSymptomMaster();
            ajaxRequest.makeRequest("/CCRMSymptomMaster/Delete", "POST", CCRMSymptomMasterData, CCRMSymptomMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMSymptomMaster: function () {
        var Data = {
        };

        if (CCRMSymptomMaster.ActionName == "Create" || CCRMSymptomMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.SymptomTypeTitle = $('#SymptomTypeTitle').val();
            Data.SymptomTypeCode = $('#SymptomTypeCode').val();
            Data.SymptomTypeDescription = $('#SymptomTypeDescription').val();
            
        }
        else if (CCRMSymptomMaster.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        else if (CCRMSymptomMaster.ActionName == "CreateMaster" || CCRMSymptomMaster.ActionName == "EditMaster") {
            Data.ID = $('#ID').val();
            Data.SymptomTitle = $('#SymptomTitle').val();
            Data.SymptomCode = $('#SymptomCode').val();
            Data.SymptomDescription = $('#SymptomDescription').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CCRMSymptomMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};