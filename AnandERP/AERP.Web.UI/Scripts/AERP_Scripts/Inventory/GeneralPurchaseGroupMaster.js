//this class contain methods related to nationality functionality
var GeneralPurchaseGroupMaster = {

    ActionName: null,

    Initialize: function () {
        GeneralPurchaseGroupMaster.constructor();
    },

    constructor: function () {

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        // Create new record
        $('#CreateGeneralPurchaseGroupMasterRecord').on("click", function () {
            debugger;
            debugger;
            GeneralPurchaseGroupMaster.ActionName = "Create";
            GeneralPurchaseGroupMaster.AjaxCallGeneralPurchaseGroupMaster();
        });

        //$('#DeleteGeneralPurchaseGroupMasterRecord').on("click", function () {
        //    debugger;
        //    GeneralPurchaseGroupMaster.ActionName = "Delete";
        //    GeneralPurchaseGroupMaster.AjaxCallGeneralPurchaseGroupMaster();
        //});


        $('#PurchaseGroupName').on("keydown",function(e)
        {
            AERPValidation.AllowCharacterOnly(e);
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
             url: '/GeneralPurchaseGroupMaster/List',
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
            url: '/GeneralPurchaseGroupMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallGeneralPurchaseGroupMaster: function () {

        var GeneralPurchaseGroupMasterData = null;
        if (GeneralPurchaseGroupMaster.ActionName == "Create") {
            $("#FormCreateGeneralPurchaseGroupMaster").validate();
            if ($("#FormCreateGeneralPurchaseGroupMaster").valid()) {
                GeneralPurchaseGroupMasterData = null;
                GeneralPurchaseGroupMasterData = GeneralPurchaseGroupMaster.GetGeneralPurchaseGroupMaster();
                ajaxRequest.makeRequest("/GeneralPurchaseGroupMaster/Create", "POST", GeneralPurchaseGroupMasterData, GeneralPurchaseGroupMaster.Success, "CreateGeneralPurchaseGroupMasterRecord");
            }


        }
        //else if (GeneralPurchaseGroupMaster.ActionName == "Delete") {
        //    GeneralPurchaseGroupMasterData = null;
        //    GeneralPurchaseGroupMasterData = GeneralPurchaseGroupMaster.GetGeneralPurchaseGroupMaster();
        //    ajaxRequest.makeRequest("/GeneralPurchaseGroupMaster/Delete", "POST", GeneralPurchaseGroupMasterData);

        //}        
    },

    //Get properties data from the Create, Update and Delete page
    GetGeneralPurchaseGroupMaster : function () {
        debugger;
        var Data = {
        };
        if (GeneralPurchaseGroupMaster.ActionName == "Create") {
            debugger;
            debugger;
            Data.PurchaseGroupName = $("#PurchaseGroupName").val();
            Data.PurchaseGroupCode = $('#PurchaseGroupCode').val();
        }
        //else if (GeneralPurchaseGroupMaster.ActionName == "Delete") {
        //    Data.ID = $("#ID").val();

        //}
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {        
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            GeneralPurchaseGroupMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },


};