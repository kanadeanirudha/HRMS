//this class contain methods related to nationality functionality
var CCRMServiceMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMServiceMaster.constructor();
        //CCRMServiceMaster.initializeValidation();
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
        $('#CreateCCRMServiceMasterRecord').on("click", function () {
            CCRMServiceMaster.ActionName = "Create";
            CCRMServiceMaster.AjaxCallCCRMServiceMaster();
        });

        $('#EditCCRMServiceMasterRecord').on("click", function () {

            CCRMServiceMaster.ActionName = "Edit";
            CCRMServiceMaster.AjaxCallCCRMServiceMaster();
        });

        $('#DeleteCCRMServiceMasterRecord').on("click", function () {

            CCRMServiceMaster.ActionName = "Delete";
            CCRMServiceMaster.AjaxCallCCRMServiceMaster();
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
            url: '/CCRMServiceMaster/List',
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
            url: '/CCRMServiceMaster/List',
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
    AjaxCallCCRMServiceMaster: function () {
        var CCRMServiceMasterData = null;
        if (CCRMServiceMaster.ActionName == "Create") {
            $("#FormCreateCCRMServiceMaster").validate();
            if ($("#FormCreateCCRMServiceMaster").valid()) {
                CCRMServiceMasterData = null;
                CCRMServiceMasterData = CCRMServiceMaster.GetCCRMServiceMaster();
                ajaxRequest.makeRequest("/CCRMServiceMaster/Create", "POST", CCRMServiceMasterData, CCRMServiceMaster.Success);
            }
        }
        else if (CCRMServiceMaster.ActionName == "Edit") {
            $("#FormEditCCRMServiceMaster").validate();
            if ($("#FormEditCCRMServiceMaster").valid()) {
                CCRMServiceMasterData = null;
                CCRMServiceMasterData = CCRMServiceMaster.GetCCRMServiceMaster();
                ajaxRequest.makeRequest("/CCRMServiceMaster/Edit", "POST", CCRMServiceMasterData, CCRMServiceMaster.Success);
            }
        }
        else if (CCRMServiceMaster.ActionName == "Delete") {
            CCRMServiceMasterData = null;
            //$("#FormCreateCCRMServiceMaster").validate();
            CCRMServiceMasterData = CCRMServiceMaster.GetCCRMServiceMaster();

            ajaxRequest.makeRequest("/CCRMServiceMaster/Delete", "POST", CCRMServiceMasterData, CCRMServiceMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMServiceMaster: function () {

        var Data = {
        };
        if (CCRMServiceMaster.ActionName == "Create" || CCRMServiceMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.ServiceDetails = $('#ServiceDetails').val();
            Data.ServiceDescription = $('#ServiceDescription').val();
            Data.CallCharges = $('#CallCharges').val();
            Data.ServiceType = $('#ServiceType').val();

        }
        else if (CCRMServiceMaster.ActionName == "Delete") {
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

            CCRMServiceMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMServiceMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMServiceMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMServiceMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

