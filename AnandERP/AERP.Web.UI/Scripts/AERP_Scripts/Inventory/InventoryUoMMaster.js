//this class contain methods related to nationality functionality
var InventoryUoMMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryUoMMaster.constructor();
        //InventoryUoMMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#UomCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#UomCode').focus();
            return false;
        });



        // Create new record

        $('#CreateInventoryUoMMasterRecord').on("click", function () {
            debugger;
            InventoryUoMMaster.ActionName = "Create";

            InventoryUoMMaster.AjaxCallInventoryUoMMaster();
        });

        $('#EditInventoryUoMMasterRecord').on("click", function () {

            InventoryUoMMaster.ActionName = "Edit";
            InventoryUoMMaster.AjaxCallInventoryUoMMaster();
        });

        $('#DeleteInventoryUoMMasterRecord').on("click", function () {

            InventoryUoMMaster.ActionName = "Delete";
            InventoryUoMMaster.AjaxCallInventoryUoMMaster();
        });

        $('#UoMDescription').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#CommercialDescription').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#UomCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
        });

        $('#DecimalPlacesUpto').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e)
        });

        $('#DecimalRounding').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e)
        });
        //});

        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AERPValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AERPValidation.AllowCharacterOnly(e);
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
             url: '/InventoryUoMMaster/List',
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
            url: '/InventoryUoMMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallInventoryUoMMaster: function () {
        var InventoryUoMMasterData = null;

        if (InventoryUoMMaster.ActionName == "Create") {

            $("#FormCreateInventoryUoMMaster").validate();
            if ($("#FormCreateInventoryUoMMaster").valid()) {
                InventoryUoMMasterData = null;
                InventoryUoMMasterData = InventoryUoMMaster.GetInventoryUoMMaster();
                ajaxRequest.makeRequest("/InventoryUoMMaster/Create", "POST", InventoryUoMMasterData, InventoryUoMMaster.Success, "CreateInventoryUoMMasterRecord");
            }
        }
        else if (InventoryUoMMaster.ActionName == "Edit") {
            $("#FormEditInventoryUoMMaster").validate();
            if ($("#FormEditInventoryUoMMaster").valid()) {
                InventoryUoMMasterData = null;
                InventoryUoMMasterData = InventoryUoMMaster.GetInventoryUoMMaster();
                ajaxRequest.makeRequest("/InventoryUoMMaster/Edit", "POST", InventoryUoMMasterData, InventoryUoMMaster.Success);
            }
        }
        else if (InventoryUoMMaster.ActionName == "Delete") {

            InventoryUoMMasterData = null;
            //$("#FormCreateInventoryUoMMaster").validate();
            InventoryUoMMasterData = InventoryUoMMaster.GetInventoryUoMMaster();
            ajaxRequest.makeRequest("/InventoryUoMMaster/Delete", "POST", InventoryUoMMasterData, InventoryUoMMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryUoMMaster: function () {
        var Data = {
        };

        if (InventoryUoMMaster.ActionName == "Create" || InventoryUoMMaster.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.DimensionCode = $('#DimensionCode').val();
            Data.DimensionDescription = $('#DimensionDescription').val();
            Data.UomCode = $('#UomCode').val();
            Data.UoMDescription = $('#UoMDescription').val();
            Data.CommercialDescription = $('#CommercialDescription').val();
            Data.InventoryDimentionUnitMasterID = $('#InventoryDimentionUnitMasterID').val();

            Data.ConvertionFactor = $('#ConvertionFactor').val();
            Data.AdditiveConstant = $('#AdditiveConstant').val();
            Data.DecimalPlacesUpto = $('#DecimalPlacesUpto').val();
            Data.DecimalRounding = $('#DecimalRounding').val();
            // Data.IsAlternativeUom = $('#IsAlternativeUom').val();
            Data.IsAlternativeUom = $("#IsAlternativeUom").is(":checked") ? "true" : "false";



        }
        else if (InventoryUoMMaster.ActionName == "Delete") {


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
            InventoryUoMMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};