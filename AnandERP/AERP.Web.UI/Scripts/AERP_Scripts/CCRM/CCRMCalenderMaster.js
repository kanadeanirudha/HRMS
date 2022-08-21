//this class contain methods related to nationality functionality
var CCRMCalenderMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMCalenderMaster.constructor();
        //CCRMCalenderMaster.initializeValidation();
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
        $('#CreateCCRMCalenderMasterRecord').on("click", function () {
            CCRMCalenderMaster.ActionName = "Create";
            CCRMCalenderMaster.AjaxCallCCRMCalenderMaster();
        });

        $('#EditCCRMCalenderMasterRecord').on("click", function () {

            CCRMCalenderMaster.ActionName = "Edit";
            CCRMCalenderMaster.AjaxCallCCRMCalenderMaster();
        });

        $('#DeleteCCRMCalenderMasterRecord').on("click", function () {

            CCRMCalenderMaster.ActionName = "Delete";
            CCRMCalenderMaster.AjaxCallCCRMCalenderMaster();
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
        $('#Date').datetimepicker({
            format: 'DD MMM YYYY',
            // maxDate: moment(),

        });
        $('#CalenderYear').datetimepicker({
            format: 'DD MMM YYYY',
            // maxDate: moment(),

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
            url: '/CCRMCalenderMaster/List',
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
            url: '/CCRMCalenderMaster/List',
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
    AjaxCallCCRMCalenderMaster: function () {
        var CCRMCalenderMasterData = null;
        if (CCRMCalenderMaster.ActionName == "Create") {
            $("#FormCreateCCRMCalenderMaster").validate();
            if ($("#FormCreateCCRMCalenderMaster").valid()) {
                CCRMCalenderMasterData = null;
                CCRMCalenderMasterData = CCRMCalenderMaster.GetCCRMCalenderMaster();
                ajaxRequest.makeRequest("/CCRMCalenderMaster/Create", "POST", CCRMCalenderMasterData, CCRMCalenderMaster.Success);
            }
        }
        else if (CCRMCalenderMaster.ActionName == "Edit") {
            $("#FormEditCCRMCalenderMaster").validate();
            if ($("#FormEditCCRMCalenderMaster").valid()) {
                CCRMCalenderMasterData = null;
                CCRMCalenderMasterData = CCRMCalenderMaster.GetCCRMCalenderMaster();
                ajaxRequest.makeRequest("/CCRMCalenderMaster/Edit", "POST", CCRMCalenderMasterData, CCRMCalenderMaster.Success);
            }
        }
        else if (CCRMCalenderMaster.ActionName == "Delete") {
            CCRMCalenderMasterData = null;
            //$("#FormCreateCCRMCalenderMaster").validate();
            CCRMCalenderMasterData = CCRMCalenderMaster.GetCCRMCalenderMaster();

            ajaxRequest.makeRequest("/CCRMCalenderMaster/Delete", "POST", CCRMCalenderMasterData, CCRMCalenderMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMCalenderMaster: function () {

        var Data = {
        };
        if (CCRMCalenderMaster.ActionName == "Create" || CCRMCalenderMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.Date = $('#Date').val();
            Data.HolidayDesc = $('#HolidayDesc').val();
            Data.CalenderYear = $('#CalenderYear').val();
            Data.AllSundays = $('input[id=AllSundays]:checked').val() ? true : false;
            Data.AllSaturday = $('input[id=AllSaturday]:checked').val() ? true : false;
        }
        else if (CCRMCalenderMaster.ActionName == "Delete") {
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

            CCRMCalenderMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMCalenderMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMCalenderMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMCalenderMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

