//this class contain methods related to nationality functionality
var GeneralShipperMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralShipperMaster.constructor();
        //GeneralShipperMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });



        // Create new record

        $('#CreateGeneralShipperMasterRecord').on("click", function () {

            GeneralShipperMaster.ActionName = "Create";
            GeneralShipperMaster.AjaxCallGeneralShipperMaster();
        });

        $('#EditGeneralShipperMasterRecord').on("click", function () {

            GeneralShipperMaster.ActionName = "Edit";
            GeneralShipperMaster.AjaxCallGeneralShipperMaster();
        });

        $('#DeleteGeneralShipperMasterRecord').on("click", function () {

            GeneralShipperMaster.ActionName = "Delete";
            GeneralShipperMaster.AjaxCallGeneralShipperMaster();
        });

        $('#MovementType').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MovementCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);

        });

        window.onkeydown = function (e) {
            debugger;
            if ($("#FormCreateGeneralShipperMaster").length > 0 && ((e.which === 27) || (e.which === 116))) {
               //     $('.mfpAjaxModal').magnificPopup('enableEscapeKey', false);
                return false;
            }

        };
      
     

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
             url: '/GeneralShipperMaster/List',
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
            url: '/GeneralShipperMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralShipperMaster: function () {
        var GeneralShipperMasterData = null;

        if (GeneralShipperMaster.ActionName == "Create") {

            $("#FormCreateGeneralShipperMaster").validate();
            if ($("#FormCreateGeneralShipperMaster").valid()) {
                GeneralShipperMasterData = null;
                GeneralShipperMasterData = GeneralShipperMaster.GetGeneralShipperMaster();
                ajaxRequest.makeRequest("/GeneralShipperMaster/Create", "POST", GeneralShipperMasterData, GeneralShipperMaster.Success, "CreateGeneralShipperMasterRecord");
            }
        }
        else if (GeneralShipperMaster.ActionName == "Edit") {
            $("#FormEditGeneralShipperMaster").validate();
            if ($("#FormEditGeneralShipperMaster").valid()) {
                GeneralShipperMasterData = null;
                GeneralShipperMasterData = GeneralShipperMaster.GetGeneralShipperMaster();
                ajaxRequest.makeRequest("/GeneralShipperMaster/Edit", "POST", GeneralShipperMasterData, GeneralShipperMaster.Success);
            }
        }
        else if (GeneralShipperMaster.ActionName == "Delete") {

            GeneralShipperMasterData = null;
            //$("#FormCreateGeneralShipperMaster").validate();
            GeneralShipperMasterData = GeneralShipperMaster.GetGeneralShipperMaster();
            ajaxRequest.makeRequest("/GeneralShipperMaster/Delete", "POST", GeneralShipperMasterData, GeneralShipperMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralShipperMaster: function () {
        var Data = {
        };

        if (GeneralShipperMaster.ActionName == "Create" || GeneralShipperMaster.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.CompanyName = $('#CompanyName').val();
            Data.Email = $('#Email').val();
            Data.PhoneNumber = $('#PhoneNumber').val();
            Data.MobileNumber = $('#MobileNumber').val();


            Data.IsActive = $("#IsActive").is(":checked") ? "true" : "false";
        }
        else if (GeneralShipperMaster.ActionName == "Delete") {

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
            GeneralShipperMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};