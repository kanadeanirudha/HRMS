//this class contain methods related to nationality functionality
var CCRMActionMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMActionMaster.constructor();
        //CCRMActionMaster.initializeValidation();
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
        $('#CreateCCRMActionMasterRecord').on("click", function () {
            CCRMActionMaster.ActionName = "Create";
            CCRMActionMaster.AjaxCallCCRMActionMaster();
        });

        $('#EditCCRMActionMasterRecord').on("click", function () {

            CCRMActionMaster.ActionName = "Edit";
            CCRMActionMaster.AjaxCallCCRMActionMaster();
        });

        $('#DeleteCCRMActionMasterRecord').on("click", function () {

            CCRMActionMaster.ActionName = "Delete";
            CCRMActionMaster.AjaxCallCCRMActionMaster();
        });
        //$('#ActionTitle').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        //$('#FeedbackPoints').on("keydown", function (e) {
        //    AERPValidation.AllowNumbersOnly(e);
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
            url: '/CCRMActionMaster/List',
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
            url: '/CCRMActionMaster/List',
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
    AjaxCallCCRMActionMaster: function () {
        var CCRMActionMasterData = null;
        if (CCRMActionMaster.ActionName == "Create") {
            $("#FormCreateCCRMActionMaster").validate();
            if ($("#FormCreateCCRMActionMaster").valid()) {
                CCRMActionMasterData = null;
                CCRMActionMasterData = CCRMActionMaster.GetCCRMActionMaster();
                ajaxRequest.makeRequest("/CCRMActionMaster/Create", "POST", CCRMActionMasterData, CCRMActionMaster.Success);
            }
        }
        else if (CCRMActionMaster.ActionName == "Edit") {
            $("#FormEditCCRMActionMaster").validate();
            if ($("#FormEditCCRMActionMaster").valid()) {
                CCRMActionMasterData = null;
                CCRMActionMasterData = CCRMActionMaster.GetCCRMActionMaster();
                ajaxRequest.makeRequest("/CCRMActionMaster/Edit", "POST", CCRMActionMasterData, CCRMActionMaster.Success);
            }
        }
        else if (CCRMActionMaster.ActionName == "Delete") {
            CCRMActionMasterData = null;
            //$("#FormCreateCCRMActionMaster").validate();
            CCRMActionMasterData = CCRMActionMaster.GetCCRMActionMaster();

            ajaxRequest.makeRequest("/CCRMActionMaster/Delete", "POST", CCRMActionMasterData, CCRMActionMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMActionMaster: function () {

        var Data = {
        };
        if (CCRMActionMaster.ActionName == "Create" || CCRMActionMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.ActionCode = $('#ActionCode').val();
            Data.ActionTitle = $('#ActionTitle').val();
            Data.ActionDesciption = $('#ActionDesciption').val();


        }
        else if (CCRMActionMaster.ActionName == "Delete") {
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

            CCRMActionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMActionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMActionMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMActionMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

