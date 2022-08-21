//this class contain methods related to nationality functionality
var CCRMFeedbackMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMFeedbackMaster.constructor();
        //CCRMFeedbackMaster.initializeValidation();
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
        $('#CreateCCRMFeedbackMasterRecord').on("click", function () {
            CCRMFeedbackMaster.ActionName = "Create";
            CCRMFeedbackMaster.AjaxCallCCRMFeedbackMaster();
        });

        $('#EditCCRMFeedbackMasterRecord').on("click", function () {

            CCRMFeedbackMaster.ActionName = "Edit";
            CCRMFeedbackMaster.AjaxCallCCRMFeedbackMaster();
        });

        $('#DeleteCCRMFeedbackMasterRecord').on("click", function () {

            CCRMFeedbackMaster.ActionName = "Delete";
            CCRMFeedbackMaster.AjaxCallCCRMFeedbackMaster();
        });
        $('#FeedbackName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
         $('#FeedbackPoints').on("keydown", function (e) {
             AERPValidation.AllowNumbersOnly(e);
        });
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
            url: '/CCRMFeedbackMaster/List',
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
            url: '/CCRMFeedbackMaster/List',
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
    AjaxCallCCRMFeedbackMaster: function () {
        var CCRMFeedbackMasterData = null;
        if (CCRMFeedbackMaster.ActionName == "Create") {
            $("#FormCreateCCRMFeedbackMaster").validate();
            if ($("#FormCreateCCRMFeedbackMaster").valid()) {
                CCRMFeedbackMasterData = null;
                CCRMFeedbackMasterData = CCRMFeedbackMaster.GetCCRMFeedbackMaster();
                ajaxRequest.makeRequest("/CCRMFeedbackMaster/Create", "POST", CCRMFeedbackMasterData, CCRMFeedbackMaster.Success);
            }
        }
        else if (CCRMFeedbackMaster.ActionName == "Edit") {
            $("#FormEditCCRMFeedbackMaster").validate();
            if ($("#FormEditCCRMFeedbackMaster").valid()) {
                CCRMFeedbackMasterData = null;
                CCRMFeedbackMasterData = CCRMFeedbackMaster.GetCCRMFeedbackMaster();
                ajaxRequest.makeRequest("/CCRMFeedbackMaster/Edit", "POST", CCRMFeedbackMasterData, CCRMFeedbackMaster.Success);
            }
        }
        else if (CCRMFeedbackMaster.ActionName == "Delete") {
            CCRMFeedbackMasterData = null;
            //$("#FormCreateCCRMFeedbackMaster").validate();
            CCRMFeedbackMasterData = CCRMFeedbackMaster.GetCCRMFeedbackMaster();

            ajaxRequest.makeRequest("/CCRMFeedbackMaster/Delete", "POST", CCRMFeedbackMasterData, CCRMFeedbackMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMFeedbackMaster: function () {

        var Data = {
        };
        if (CCRMFeedbackMaster.ActionName == "Create" || CCRMFeedbackMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.FeedbackName = $('#FeedbackName').val();
            Data.FeedbackPoints = $('#FeedbackPoints').val();


        }
        else if (CCRMFeedbackMaster.ActionName == "Delete") {
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

            CCRMFeedbackMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMFeedbackMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMFeedbackMaster.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {

    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        CCRMFeedbackMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

