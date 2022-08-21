//this class contain methods related to nationality functionality
var InventoryVariationMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryVariationMaster.constructor();
        //InventoryVariationMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

      

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GroupDescription').focus();
            return false;
        });



        // Create new record

        $('#CreateInventoryVariationMasterRecord').on("click", function () {
            debugger;
            InventoryVariationMaster.ActionName = "Create";
            InventoryVariationMaster.AjaxCallInventoryVariationMaster();
        });

        $('#EditInventoryVariationMasterRecord').on("click", function () {

            InventoryVariationMaster.ActionName = "Edit";
            InventoryVariationMaster.AjaxCallInventoryVariationMaster();
        });

        $('#DeleteInventoryVariationMasterRecord').on("click", function () {

            InventoryVariationMaster.ActionName = "Delete";
            InventoryVariationMaster.AjaxCallInventoryVariationMaster();
        });

        $('#RecipeVariationTitle').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

       
        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AMSValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AMSValidation.AllowCharacterOnly(e);
        //  if (e.keyCode == 32) {
        //       return false;
        // }
        // });
        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").dataTable();
        //    oTable.fnFilter(this.value);
        //});

        //$("#searchBtn").click(function () {
        //    $("#UserSearch").focus();
        //});


        //$("#showrecord").change(function () {
        //    var showRecord = $("#showrecord").val();
        //    $("select[name*='myDataTable_length']").val(showRecord);
        //    $("select[name*='myDataTable_length']").change();
        //});

        // $(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/InventoryVariationMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger
        $.ajax(
        {
           
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/InventoryVariationMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallInventoryVariationMaster: function () {
        var InventoryVariationMasterData = null;

        if (InventoryVariationMaster.ActionName == "Create") {
            debugger;
            $("#FormCreateInventoryVariationMaster").validate();
            if ($("#FormCreateInventoryVariationMaster").valid()) {
                InventoryVariationMasterData = null;
                InventoryVariationMasterData = InventoryVariationMaster.GetInventoryVariationMaster();
                ajaxRequest.makeRequest("/InventoryVariationMaster/Create", "POST", InventoryVariationMasterData, InventoryVariationMaster.Success, "CreateInventoryVariationMasterRecord");
            }
        }
        else if (InventoryVariationMaster.ActionName == "Edit") {
            $("#FormEditInventoryVariationMaster").validate();
            if ($("#FormEditInventoryVariationMaster").valid()) {
                InventoryVariationMasterData = null;
                InventoryVariationMasterData = InventoryVariationMaster.GetInventoryVariationMaster();
                ajaxRequest.makeRequest("/InventoryVariationMaster/Edit", "POST", InventoryVariationMasterData, InventoryVariationMaster.Success);
            }
        }
        else if (InventoryVariationMaster.ActionName == "Delete") {

            InventoryVariationMasterData = null;
            //$("#FormCreateInventoryVariationMaster").validate();
            InventoryVariationMasterData = InventoryVariationMaster.GetInventoryVariationMaster();
            ajaxRequest.makeRequest("/InventoryVariationMaster/Delete", "POST", InventoryVariationMasterData, InventoryVariationMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryVariationMaster: function () {
        var Data = {
        };

        if (InventoryVariationMaster.ActionName == "Create" || InventoryVariationMaster.ActionName == "Edit") {
           
            Data.ID = $('#ID').val();
            Data.RecipeVariationTitle = $('#RecipeVariationTitle').val();
            Data.InventoryRecipeMasterId = $('#RecipeTitle').val();
            Data.Title = $('#Title').val();
            Data.Description = $('#Description').val();
            

        }
        else if (InventoryVariationMaster.ActionName == "Delete") {

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
            InventoryVariationMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

