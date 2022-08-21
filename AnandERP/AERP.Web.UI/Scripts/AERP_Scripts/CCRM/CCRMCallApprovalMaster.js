//this class contain methods related to nationality functionality
var CCRMCallApprovalMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMCallApprovalMaster.constructor();
        //CCRMCallApprovalMaster.initializeValidation();
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
        $('#CreateCCRMCallApprovalMasterRecord').on("click", function () {
            CCRMCallApprovalMaster.ActionName = "Create";
            CCRMCallApprovalMaster.AjaxCallCCRMCallApprovalMaster();
        });

        $('#EditCCRMCallApprovalMasterRecord').on("click", function () {

            CCRMCallApprovalMaster.ActionName = "Edit";
            CCRMCallApprovalMaster.AjaxCallCCRMCallApprovalMaster();
        });

        $('#DeleteCCRMCallApprovalMasterRecord').on("click", function () {

            CCRMCallApprovalMaster.ActionName = "Delete";
            CCRMCallApprovalMaster.AjaxCallCCRMCallApprovalMaster();
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
            url: '/CCRMCallApprovalMaster/List',
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
            url: '/CCRMCallApprovalMaster/List',
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
    AjaxCallCCRMCallApprovalMaster: function () {
        var CCRMCallApprovalMasterData = null;
        if (CCRMCallApprovalMaster.ActionName == "Create") {
            $("#FormCreateCCRMCallApprovalMaster").validate();
            if ($("#FormCreateCCRMCallApprovalMaster").valid()) {
                CCRMCallApprovalMasterData = null;
                CCRMCallApprovalMasterData = CCRMCallApprovalMaster.GetCCRMCallApprovalMaster();
                ajaxRequest.makeRequest("/CCRMCallApprovalMaster/Create", "POST", CCRMCallApprovalMasterData, CCRMCallApprovalMaster.Success);
            }
        }
        else if (CCRMCallApprovalMaster.ActionName == "Edit") {
            $("#FormEditCCRMCallApprovalMaster").validate();
            if ($("#FormEditCCRMCallApprovalMaster").valid()) {
                CCRMCallApprovalMasterData = null;
                CCRMCallApprovalMasterData = CCRMCallApprovalMaster.GetCCRMCallApprovalMaster();
                ajaxRequest.makeRequest("/CCRMCallApprovalMaster/Edit", "POST", CCRMCallApprovalMasterData, CCRMCallApprovalMaster.Success);
            }
        }
        else if (CCRMCallApprovalMaster.ActionName == "Delete") {
            CCRMCallApprovalMasterData = null;
            //$("#FormCreateCCRMCallApprovalMaster").validate();
            CCRMCallApprovalMasterData = CCRMCallApprovalMaster.GetCCRMCallApprovalMaster();

            ajaxRequest.makeRequest("/CCRMCallApprovalMaster/Delete", "POST", CCRMCallApprovalMasterData, CCRMCallApprovalMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMCallApprovalMaster: function () {

        var Data = {
        };
        if (CCRMCallApprovalMaster.ActionName == "Create" || CCRMCallApprovalMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.CallTktNo = $('#CallTktNo').val();
            Data.CallDate = $('#CallDate').val();
            Data.SerialNo = $('#SerialNo').val();
            Data.ModelNo = $('#ModelNo').val();
            Data.CallType = $('#CallType').val();
            Data.MIFName = $('#MIFName').val();
            Data.CallCharges = $('#CallCharges').val();
            Data.CustApproval = $('input[id=CustApproval]:checked').val() ? true : false;
        }
        else if (CCRMCallApprovalMaster.ActionName == "Delete") {
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

            CCRMCallApprovalMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMCallApprovalMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMCallApprovalMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMCallApprovalMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

