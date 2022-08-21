//this class contain methods related to nationality functionality
var GeneralNationalityMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralNationalityMaster.constructor();
        //GeneralNationalityMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Description').focus();
            return false;
        });

        // Create new record
        $('#CreateGeneralNationalityMasterRecord').on("click", function () {
            GeneralNationalityMaster.ActionName = "Create";
            GeneralNationalityMaster.AjaxCallGeneralNationalityMaster();
        });

        $('#EditGeneralNationalityMasterRecord').on("click", function () {

            GeneralNationalityMaster.ActionName = "Edit";
            GeneralNationalityMaster.AjaxCallGeneralNationalityMaster();
        });

        $('#DeleteGeneralNationalityMasterRecord').on("click", function () {

            GeneralNationalityMaster.ActionName = "Delete";
            GeneralNationalityMaster.AjaxCallGeneralNationalityMaster();
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#Description').on("keydown", function (e) {
           AERPValidation.AllowCharacterOnly(e);
        });
    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralNationalityMaster/List',
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
            url: '/GeneralNationalityMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallGeneralNationalityMaster: function () {
        var GeneralNationalityMasterData = null;
        if (GeneralNationalityMaster.ActionName == "Create") {
            $("#FormCreateGeneralNationalityMaster").validate();
            if ($("#FormCreateGeneralNationalityMaster").valid()) {
                GeneralNationalityMasterData = null;
                GeneralNationalityMasterData = GeneralNationalityMaster.GetGeneralNationalityMaster();
                ajaxRequest.makeRequest("/GeneralNationalityMaster/Create", "POST", GeneralNationalityMasterData, GeneralNationalityMaster.Success);
            }
        }
        else if (GeneralNationalityMaster.ActionName == "Edit") {
            $("#FormEditGeneralNationalityMaster").validate();
            if ($("#FormEditGeneralNationalityMaster").valid()) {
                GeneralNationalityMasterData = null;
                GeneralNationalityMasterData = GeneralNationalityMaster.GetGeneralNationalityMaster();
                ajaxRequest.makeRequest("/GeneralNationalityMaster/Edit", "POST", GeneralNationalityMasterData, GeneralNationalityMaster.Success);
            }
        }
        else if (GeneralNationalityMaster.ActionName == "Delete") {
            GeneralNationalityMasterData = null;
            //$("#FormCreateGeneralNationalityMaster").validate();
            GeneralNationalityMasterData = GeneralNationalityMaster.GetGeneralNationalityMaster();

            ajaxRequest.makeRequest("/GeneralNationalityMaster/Delete", "POST", GeneralNationalityMasterData, GeneralNationalityMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralNationalityMaster: function () {

        var Data = {
        };
        if (GeneralNationalityMaster.ActionName == "Create" || GeneralNationalityMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.Description = $('#Description').val();
            Data.DefaultFlag = $('#DefaultFlag:checked').val() ? true : false;
        }
        else if (GeneralNationalityMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralNationalityMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralNationalityMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

