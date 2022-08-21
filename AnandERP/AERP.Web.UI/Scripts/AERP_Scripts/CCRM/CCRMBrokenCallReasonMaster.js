//this class contain methods related to nationality functionality
var CCRMBrokenCallReasonMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMBrokenCallReasonMaster.constructor();
        //CCRMBrokenCallReasonMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SelectedRegionID').focus();
            $('#SelectedRegionID').val('');
        });

        // Create new record
        $('#CreateCCRMBrokenCallReasonMasterRecord').on("click", function () {
            CCRMBrokenCallReasonMaster.ActionName = "Create";
            CCRMBrokenCallReasonMaster.AjaxCallCCRMBrokenCallReasonMaster();
        });

        $('#EditCCRMBrokenCallReasonMasterRecord').on("click", function () {

            CCRMBrokenCallReasonMaster.ActionName = "Edit";
            CCRMBrokenCallReasonMaster.AjaxCallCCRMBrokenCallReasonMaster();
        });

        $('#DeleteCCRMBrokenCallReasonMasterRecord').on("click", function () {

            CCRMBrokenCallReasonMaster.ActionName = "Delete";
            CCRMBrokenCallReasonMaster.AjaxCallCCRMBrokenCallReasonMaster();
        });
        //$('#ReasonCode').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        //$('#ReasonDescription').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
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

    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/CCRMBrokenCallReasonMaster/List',
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
            url: '/CCRMBrokenCallReasonMaster/List',
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
    AjaxCallCCRMBrokenCallReasonMaster: function () {
        var CCRMBrokenCallReasonMasterData = null;
        if (CCRMBrokenCallReasonMaster.ActionName == "Create") {
            $("#FormCreateCCRMBrokenCallReasonMaster").validate();
            if ($("#FormCreateCCRMBrokenCallReasonMaster").valid()) {
                CCRMBrokenCallReasonMasterData = null;
                CCRMBrokenCallReasonMasterData = CCRMBrokenCallReasonMaster.GetCCRMBrokenCallReasonMaster();
                ajaxRequest.makeRequest("/CCRMBrokenCallReasonMaster/Create", "POST", CCRMBrokenCallReasonMasterData, CCRMBrokenCallReasonMaster.Success);
            }
        }
        else if (CCRMBrokenCallReasonMaster.ActionName == "Edit") {
            $("#FormEditCCRMBrokenCallReasonMaster").validate();
            if ($("#FormEditCCRMBrokenCallReasonMaster").valid()) {
                CCRMBrokenCallReasonMasterData = null;
                CCRMBrokenCallReasonMasterData = CCRMBrokenCallReasonMaster.GetCCRMBrokenCallReasonMaster();
                ajaxRequest.makeRequest("/CCRMBrokenCallReasonMaster/Edit", "POST", CCRMBrokenCallReasonMasterData, CCRMBrokenCallReasonMaster.Success);
            }
        }
        else if (CCRMBrokenCallReasonMaster.ActionName == "Delete") {
            CCRMBrokenCallReasonMasterData = null;
            //$("#FormCreateCCRMBrokenCallReasonMaster").validate();
            CCRMBrokenCallReasonMasterData = CCRMBrokenCallReasonMaster.GetCCRMBrokenCallReasonMaster();

            ajaxRequest.makeRequest("/CCRMBrokenCallReasonMaster/Delete", "POST", CCRMBrokenCallReasonMasterData, CCRMBrokenCallReasonMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMBrokenCallReasonMaster: function () {

        var Data = {
        };
        if (CCRMBrokenCallReasonMaster.ActionName == "Create" || CCRMBrokenCallReasonMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.ReasonCode = $('#ReasonCode').val();
            Data.ReasonDescription = $('#ReasonDescription').val();


        }
        else if (CCRMBrokenCallReasonMaster.ActionName == "Delete") {
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

            CCRMBrokenCallReasonMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMBrokenCallReasonMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
   
};

