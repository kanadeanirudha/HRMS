//this class contain methods related to nationality functionality
var GeneralTransactionMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralTransactionMaster.constructor();
        //GeneralTransactionMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

       

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });



        // Create new record

        $('#CreateGeneralTransactionMasterRecord').on("click", function () {

            GeneralTransactionMaster.ActionName = "Create";
            GeneralTransactionMaster.AjaxCallGeneralTransactionMaster();
        });

        $('#EditGeneralTransactionMasterRecord').on("click", function () {

            GeneralTransactionMaster.ActionName = "Edit";
            GeneralTransactionMaster.AjaxCallGeneralTransactionMaster();
        });

        $('#DeleteGeneralTransactionMasterRecord').on("click", function () {

            GeneralTransactionMaster.ActionName = "Delete";
            GeneralTransactionMaster.AjaxCallGeneralTransactionMaster();
        });

        $('#MovementType').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MovementCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);

        });

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
             url: '/GeneralTransactionMaster/List',
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
            url: '/GeneralTransactionMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralTransactionMaster: function () {
        var GeneralTransactionMasterData = null;

        if (GeneralTransactionMaster.ActionName == "Create") {
            
            $("#FormCreateGeneralTransactionMaster").validate();
            if ($("#FormCreateGeneralTransactionMaster").valid()) {
                GeneralTransactionMasterData = null;
                GeneralTransactionMasterData = GeneralTransactionMaster.GetGeneralTransactionMaster();
                ajaxRequest.makeRequest("/GeneralTransactionMaster/Create", "POST", GeneralTransactionMasterData, GeneralTransactionMaster.Success, "CreateGeneralTransactionMasterRecord");
            }
        }
        else if (GeneralTransactionMaster.ActionName == "Edit") {
            $("#FormEditGeneralTransactionMaster").validate();
            if ($("#FormEditGeneralTransactionMaster").valid()) {
                GeneralTransactionMasterData = null;
                GeneralTransactionMasterData = GeneralTransactionMaster.GetGeneralTransactionMaster();
                ajaxRequest.makeRequest("/GeneralTransactionMaster/Edit", "POST", GeneralTransactionMasterData, GeneralTransactionMaster.Success);
            }
        }
        else if (GeneralTransactionMaster.ActionName == "Delete") {

            GeneralTransactionMasterData = null;
            //$("#FormCreateGeneralTransactionMaster").validate();
            GeneralTransactionMasterData = GeneralTransactionMaster.GetGeneralTransactionMaster();
            ajaxRequest.makeRequest("/GeneralTransactionMaster/Delete", "POST", GeneralTransactionMasterData, GeneralTransactionMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralTransactionMaster: function () {
        var Data = {
        };

        if (GeneralTransactionMaster.ActionName == "Create" || GeneralTransactionMaster.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.TransactionType = $('#TransactionType').val();
           
            Data.IsActive = $("#IsActive").is(":checked") ? "true" : "false";
        }
        else if (GeneralTransactionMaster.ActionName == "Delete") {

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
            GeneralTransactionMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};