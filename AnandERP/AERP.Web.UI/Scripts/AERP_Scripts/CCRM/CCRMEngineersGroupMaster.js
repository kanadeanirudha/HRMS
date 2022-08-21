//this class contain methods related to nationality functionality
var CCRMEngineersGroupMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMEngineersGroupMaster.constructor();
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

        $('#CreateCCRMEngineersGroupMasterRecord').on("click", function () {

            CCRMEngineersGroupMaster.ActionName = "Create";
            CCRMEngineersGroupMaster.AjaxCallCCRMEngineersGroupMaster();
        });

        $('#CreateCCRMEngineersGroupDetailsRecord').on("click", function () {

            CCRMEngineersGroupMaster.ActionName = "CreateGroup";
            CCRMEngineersGroupMaster.AjaxCallCCRMEngineersGroupMaster();
        });
        

        $('#EditCCRMEngineersGroupMasterRecord').on("click", function () {

            CCRMEngineersGroupMaster.ActionName = "Edit";
            CCRMEngineersGroupMaster.AjaxCallCCRMEngineersGroupMaster();
        });

        $('#DeleteCCRMEngineersGroupMasterRecord').on("click", function () {

            CCRMEngineersGroupMaster.ActionName = "Delete";
            CCRMEngineersGroupMaster.AjaxCallCCRMEngineersGroupMaster();
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
             url: '/CCRMEngineersGroupMaster/List',
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
            url: '/CCRMEngineersGroupMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallCCRMEngineersGroupMaster: function () {
        var CCRMEngineersGroupMasterData = null;

        if (CCRMEngineersGroupMaster.ActionName == "Create") {

            $("#FormCreateCCRMEngineersGroupMaster").validate();
            if ($("#FormCreateCCRMEngineersGroupMaster").valid()) {
                CCRMEngineersGroupMasterData = null;
                CCRMEngineersGroupMasterData = CCRMEngineersGroupMaster.GetCCRMEngineersGroupMaster();
                ajaxRequest.makeRequest("/CCRMEngineersGroupMaster/Create", "POST", CCRMEngineersGroupMasterData, CCRMEngineersGroupMaster.Success, "CreateCCRMEngineersGroupMasterRecord");
            }
        }
        else if (CCRMEngineersGroupMaster.ActionName == "CreateGroup") {
            $("#FormCreateCCRMEngineersDetailsMaster").validate();
            if ($("#FormCreateCCRMEngineersDetailsMaster").valid()) {
                CCRMEngineersGroupMasterData = null;
                CCRMEngineersGroupMasterData = CCRMEngineersGroupMaster.GetCCRMEngineersGroupMaster();
                ajaxRequest.makeRequest("/CCRMEngineersGroupMaster/CreateGroup", "POST", CCRMEngineersGroupMasterData, CCRMEngineersGroupMaster.Success);
            }
        }
        
        else if (CCRMEngineersGroupMaster.ActionName == "Edit") {
            $("#FormEditCCRMEngineersGroupMaster").validate();
            if ($("#FormEditCCRMEngineersGroupMaster").valid()) {
                CCRMEngineersGroupMasterData = null;
                CCRMEngineersGroupMasterData = CCRMEngineersGroupMaster.GetCCRMEngineersGroupMaster();
                ajaxRequest.makeRequest("/CCRMEngineersGroupMaster/Edit", "POST", CCRMEngineersGroupMasterData, CCRMEngineersGroupMaster.Success);
            }
        }
        else if (CCRMEngineersGroupMaster.ActionName == "Delete") {

            CCRMEngineersGroupMasterData = null;
            //$("#FormCreateCCRMEngineersGroupMaster").validate();
            CCRMEngineersGroupMasterData = CCRMEngineersGroupMaster.GetCCRMEngineersGroupMaster();
            ajaxRequest.makeRequest("/CCRMEngineersGroupMaster/Delete", "POST", CCRMEngineersGroupMasterData, CCRMEngineersGroupMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMEngineersGroupMaster: function () {
        var Data = {
        };

        if (CCRMEngineersGroupMaster.ActionName == "Create" || CCRMEngineersGroupMaster.ActionName == "CreateGroup" || CCRMEngineersGroupMaster.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.GroupName = $('#GroupName').val();
            Data.EmployeeMasterID = $('#EmployeeMasterID').val();
            Data.EmployeeName = $('#EmployeeName').val();

        }
        else if (CCRMEngineersGroupMaster.ActionName == "Delete") {

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
            CCRMEngineersGroupMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};