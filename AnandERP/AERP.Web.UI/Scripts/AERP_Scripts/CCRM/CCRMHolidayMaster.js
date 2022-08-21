//this class contain methods related to nationality functionality
var CCRMHolidayMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMHolidayMaster.constructor();
        //CCRMHolidayMaster.initializeValidation();
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
        $('#CreateCCRMHolidayMasterRecord').on("click", function () {
            CCRMHolidayMaster.ActionName = "Create";
            CCRMHolidayMaster.AjaxCallCCRMHolidayMaster();
        });

        $('#EditCCRMHolidayMasterRecord').on("click", function () {

            CCRMHolidayMaster.ActionName = "Edit";
            CCRMHolidayMaster.AjaxCallCCRMHolidayMaster();
        });

        $('#DeleteCCRMHolidayMasterRecord').on("click", function () {

            CCRMHolidayMaster.ActionName = "Delete";
            CCRMHolidayMaster.AjaxCallCCRMHolidayMaster();
        });
        $('#SegementName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
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
            url: '/CCRMHolidayMaster/List',
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
            url: '/CCRMHolidayMaster/List',
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
    AjaxCallCCRMHolidayMaster: function () {
        var CCRMHolidayMasterData = null;
        if (CCRMHolidayMaster.ActionName == "Create") {
            $("#FormCreateCCRMHolidayMaster").validate();
            if ($("#FormCreateCCRMHolidayMaster").valid()) {
                CCRMHolidayMasterData = null;
                CCRMHolidayMasterData = CCRMHolidayMaster.GetCCRMHolidayMaster();
                ajaxRequest.makeRequest("/CCRMHolidayMaster/Create", "POST", CCRMHolidayMasterData, CCRMHolidayMaster.Success);
            }
        }
        else if (CCRMHolidayMaster.ActionName == "Edit") {
            $("#FormEditCCRMHolidayMaster").validate();
            if ($("#FormEditCCRMHolidayMaster").valid()) {
                CCRMHolidayMasterData = null;
                CCRMHolidayMasterData = CCRMHolidayMaster.GetCCRMHolidayMaster();
                ajaxRequest.makeRequest("/CCRMHolidayMaster/Edit", "POST", CCRMHolidayMasterData, CCRMHolidayMaster.Success);
            }
        }
        else if (CCRMHolidayMaster.ActionName == "Delete") {
            CCRMHolidayMasterData = null;
            //$("#FormCreateCCRMHolidayMaster").validate();
            CCRMHolidayMasterData = CCRMHolidayMaster.GetCCRMHolidayMaster();

            ajaxRequest.makeRequest("/CCRMHolidayMaster/Delete", "POST", CCRMHolidayMasterData, CCRMHolidayMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMHolidayMaster: function () {

        var Data = {
        };
        if (CCRMHolidayMaster.ActionName == "Create" || CCRMHolidayMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.HolidayDesc = $('#HolidayDesc').val();



        }
        else if (CCRMHolidayMaster.ActionName == "Delete") {
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

            CCRMHolidayMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMHolidayMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMHolidayMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMHolidayMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

