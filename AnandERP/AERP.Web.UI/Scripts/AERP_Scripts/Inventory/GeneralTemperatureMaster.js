//this class contain methods related to nationality functionality
var GeneralTemperatureMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralTemperatureMaster.constructor();
        //GeneralTemperatureMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#MarchandiseBaseCategoryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#MarchandiseBaseCategoryName').focus();
            return false;
        });



        // Create new record

        $('#CreateGeneralTemperatureMasterRecord').on("click", function () {
            debugger;
            GeneralTemperatureMaster.ActionName = "Create";
            GeneralTemperatureMaster.AjaxCallGeneralTemperatureMaster();
        });

        $('#EditGeneralTemperatureMasterRecord').on("click", function () {

            GeneralTemperatureMaster.ActionName = "Edit";
            GeneralTemperatureMaster.AjaxCallGeneralTemperatureMaster();
        });

        $('#DeleteGeneralTemperatureMasterRecord').on("click", function () {

            GeneralTemperatureMaster.ActionName = "Delete";
            GeneralTemperatureMaster.AjaxCallGeneralTemperatureMaster();
        });

        //$('#MarchandiseBaseCategoryName').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});

        //$('#MarchandiseBaseCategoryCode').on("keydown", function (e) {
        //    AERPValidation.NotAllowSpaces(e);

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
             url: '/GeneralTemperatureMaster/List',
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
            url: '/GeneralTemperatureMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralTemperatureMaster: function () {
        var GeneralTemperatureMasterData = null;

        if (GeneralTemperatureMaster.ActionName == "Create") {

            $("#FormCreateGeneralTemperatureMaster").validate();
            if ($("#FormCreateGeneralTemperatureMaster").valid()) {
                GeneralTemperatureMasterData = null;
                GeneralTemperatureMasterData = GeneralTemperatureMaster.GetGeneralTemperatureMaster();
                ajaxRequest.makeRequest("/GeneralTemperatureMaster/Create", "POST", GeneralTemperatureMasterData, GeneralTemperatureMaster.Success, "CreateGeneralTemperatureMasterRecord");
            }
        }
        else if (GeneralTemperatureMaster.ActionName == "Edit") {
            $("#FormEditGeneralTemperatureMaster").validate();
            if ($("#FormEditGeneralTemperatureMaster").valid()) {
                GeneralTemperatureMasterData = null;
                GeneralTemperatureMasterData = GeneralTemperatureMaster.GetGeneralTemperatureMaster();
                ajaxRequest.makeRequest("/GeneralTemperatureMaster/Edit", "POST", GeneralTemperatureMasterData, GeneralTemperatureMaster.Success, "EditGeneralTemperatureMasterRecord");
            }
        }
        else if (GeneralTemperatureMaster.ActionName == "Delete") {

            GeneralTemperatureMasterData = null;
            //$("#FormCreateGeneralTemperatureMaster").validate();
            GeneralTemperatureMasterData = GeneralTemperatureMaster.GetGeneralTemperatureMaster();
            ajaxRequest.makeRequest("/GeneralTemperatureMaster/Delete", "POST", GeneralTemperatureMasterData, GeneralTemperatureMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralTemperatureMaster: function () {
        var Data = {
        };

        if (GeneralTemperatureMaster.ActionName == "Create" || GeneralTemperatureMaster.ActionName == "Edit") {

            Data.GeneralTemperatureMasterID = $('input[name=GeneralTemperatureMasterID]').val();
            Data.TemperatureType = $('#TemperatureType').val();
            Data.TemperatureFrom = $('#TemperatureFrom').val();
            Data.TemperatureUpto = $('#TemperatureUpto').val();

        }
        else if (GeneralTemperatureMaster.ActionName == "Delete") {

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
            GeneralTemperatureMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};