//this class contain methods related to nationality functionality
var LeaveCompensatoryWorkDayV2 = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveCompensatoryWorkDayV2.constructor();
        //LeaveCompensatoryWorkDayV2.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#WorkingDate').focus();
            $('#WorkingDate').val("");
            return false;
        });

        $('#CheckInTime').timepicki();
        $('#CheckOutTime').timepicki();

        //$("#WorkingDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd-M-yy',          
        //});


        // Create new record
        $('#CreateLeaveCompensatoryWorkDayRecord').on("click", function () {
            LeaveCompensatoryWorkDayV2.ActionName = "Create";
            LeaveCompensatoryWorkDayV2.AjaxCallLeaveCompensatoryWorkDay();
        });

        $('#EditLeaveCompensatoryWorkDayRecord').on("click", function () {

            LeaveCompensatoryWorkDayV2.ActionName = "Edit";
            LeaveCompensatoryWorkDayV2.AjaxCallLeaveCompensatoryWorkDay();
        });

        $('#DeleteLeaveCompensatoryWorkDayRecord').on("click", function () {

            LeaveCompensatoryWorkDayV2.ActionName = "Delete";
            LeaveCompensatoryWorkDayV2.AjaxCallLeaveCompensatoryWorkDay();
        });

        $('#ApproveLeaveCompensatoryWorkDayRecord').on("click", function () {

            LeaveCompensatoryWorkDayV2.ActionName = "Approved";
            LeaveCompensatoryWorkDayV2.AjaxCallLeaveCompensatoryWorkDay();
        });

        $('#RejectLeaveCompensatoryWorkDayRecord').on("click", function () {

            LeaveCompensatoryWorkDayV2.ActionName = "Reject";
            LeaveCompensatoryWorkDayV2.AjaxCallLeaveCompensatoryWorkDay();
        });

        $('#LeaveDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#LeaveCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
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



    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/LeaveCompensatoryWorkDay/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var TaskCode = $('input[name=TaskCode]').val();
        $.magnificPopup.close();
        notify(message, colorCode);
        $('#' + TaskCode).click();
        //$.ajax(
        //{
        //    cache: false,
        //    type: "POST",
        //    dataType: "html",
        //    data: { "actionMode": actionMode },
        //    url: '/Home/NotificationListV2',
        //    success: function (data) {
        //        //Rebind Grid Data
        //        $('#content').empty().html(data);
        //        notify(message, colorCode);
        //    }
        //});
    },

    ReloadListForApproval_Reject: function (message, colorCode, actionMode) {
        var TaskCode = $('input[name=TaskCode]').val();
        $.magnificPopup.close();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "TaskCode": TaskCode },
            url: '/Home/NotificationListV2',
            success: function (data) {
                //Rebind Grid Data
                $('#content').empty().html(data);
                notify(message, colorCode);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallLeaveCompensatoryWorkDay: function () {
        var LeaveCompensatoryWorkDayData = null;
        if (LeaveCompensatoryWorkDayV2.ActionName == "Create") {
            $("#FormCreateLeaveCompensatoryWorkDay").validate();
            if ($("#FormCreateLeaveCompensatoryWorkDay").valid()) {
                LeaveCompensatoryWorkDayData = null;
                LeaveCompensatoryWorkDayData = LeaveCompensatoryWorkDayV2.GetLeaveCompensatoryWorkDay();
                ajaxRequest.makeRequest("/LeaveCompensatoryWorkDay/Create", "POST", LeaveCompensatoryWorkDayData, LeaveCompensatoryWorkDayV2.Success);
            }
        }
        else if (LeaveCompensatoryWorkDayV2.ActionName == "Edit") {
            $("#FormEditLeaveCompensatoryWorkDay").validate();
            if ($("#FormEditLeaveCompensatoryWorkDay").valid()) {
                LeaveCompensatoryWorkDayData = null;
                LeaveCompensatoryWorkDayData = LeaveCompensatoryWorkDayV2.GetLeaveCompensatoryWorkDay();
                ajaxRequest.makeRequest("/LeaveCompensatoryWorkDay/Edit", "POST", LeaveCompensatoryWorkDayData, LeaveCompensatoryWorkDayV2.Success);
            }
        }
        else if (LeaveCompensatoryWorkDayV2.ActionName == "Delete") {
            LeaveCompensatoryWorkDayData = null;
            //$("#FormCreateLeaveCompensatoryWorkDay").validate();
            LeaveCompensatoryWorkDayData = LeaveCompensatoryWorkDayV2.GetLeaveCompensatoryWorkDay();
            ajaxRequest.makeRequest("/LeaveCompensatoryWorkDay/Delete", "POST", LeaveCompensatoryWorkDayData, LeaveCompensatoryWorkDayV2.Success);

        }
        else if (LeaveCompensatoryWorkDayV2.ActionName == "Approved") {
            LeaveCompensatoryWorkDayData = null;
            LeaveCompensatoryWorkDayData = LeaveCompensatoryWorkDayV2.GetLeaveCompensatoryWorkDay();
            ajaxRequest.makeRequest("/LeaveCompensatoryWorkDay/RequestApprovalV2", "POST", LeaveCompensatoryWorkDayData, LeaveCompensatoryWorkDayV2.SuccessForApproval_Reject);

        }
        else if (LeaveCompensatoryWorkDayV2.ActionName == "Reject") {
            LeaveCompensatoryWorkDayData = null;
            LeaveCompensatoryWorkDayData = LeaveCompensatoryWorkDayV2.GetLeaveCompensatoryWorkDay();
            ajaxRequest.makeRequest("/LeaveCompensatoryWorkDay/RequestApprovalV2", "POST", LeaveCompensatoryWorkDayData, LeaveCompensatoryWorkDayV2.SuccessForApproval_Reject);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveCompensatoryWorkDay: function () {
        var Data = {
        };
        if (LeaveCompensatoryWorkDayV2.ActionName == "Create" || LeaveCompensatoryWorkDayV2.ActionName == "Edit") {

            Data.ID = $('input[name=ID]').val();
            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.WorkingDate = $('#WorkingDate').val();
            Data.CheckInTime = LeaveCompensatoryWorkDayV2.hours_am_pm($("#CheckInTime").val());
            Data.CheckOutTime = LeaveCompensatoryWorkDayV2.hours_am_pm($("#CheckOutTime").val());
            Data.WorkingReason = $('#WorkingReason').val();
            Data.IsHalfDayUtilized = $('#IsHalfDayUtilized').is(":checked") ? "true" : "false";
        }
        else if (LeaveCompensatoryWorkDayV2.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        else if (LeaveCompensatoryWorkDayV2.ActionName == "Approved") {

            Data.ID = $("input[name=ID]").val();
            Data.TaskCode = $('input[name=TaskCode]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            Data.PersonID = $('input[name=PersonID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.ApplicationStatus = 'Approved';
            Data.ApprovalStatus = true;
            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.WorkingDate = $('#WorkingDate').val();
            Data.WorkingReason = $('#WorkingReason').val();
        }
        else if (LeaveCompensatoryWorkDayV2.ActionName == "Reject") {
            Data.ID = $("input[name=ID]").val();
            Data.TaskCode = $('input[name=TaskCode]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            Data.PersonID = $('input[name=PersonID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.ApplicationStatus = 'Reject';
            Data.ApprovalStatus = false;
            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.WorkingDate = $('#WorkingDate').val();
            Data.WorkingReason = $('#WorkingReason').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            LeaveCompensatoryWorkDayV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            LeaveCompensatoryWorkDayV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    SuccessForApproval_Reject: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            LeaveCompensatoryWorkDayV2.ReloadListForApproval_Reject(splitData[0], splitData[1], splitData[2]);
        } else {
            LeaveCompensatoryWorkDayV2.ReloadListForApproval_Reject(splitData[0], splitData[1], splitData[2]);
        }

    },


    hours_am_pm: function (time) {

        var time = (time).split(':');
        var hours = parseInt(time[0].trim());
        var minutes = parseInt(time[1].trim());
        var AMPM = time[2].trim();
        if (AMPM == "PM" && hours < 12 && hours != 00) hours = hours + 12;
        if (AMPM == "AM" && hours == 12 && hours != 00) hours = hours - 12;
        var sHours = hours.toString();
        var sMinutes = minutes.toString();
        if (hours < 10) sHours = "0" + sHours;
        if (minutes < 10) sMinutes = "0" + sMinutes;
        return (sHours + ":" + sMinutes + ":00");
    },

    hours_am_pm: function (time) {

        var hours = time[0] + time[1];
        var min = time[5] + time[6];
        var AmPm = "";
        if (hours < 12) {
            AmPm = time[10] + time[11];
            if (AmPm == "AM") {
                return hours + ':' + min + ':00';
                AmPm = '';
            }
            else {
                hours = parseInt(hours) + parseInt(12);
                return hours + ':' + min + ':00';
                AmPm = '';
            }
        } else {
            hours = hours - 12;
            hours = (hours.length < 10) ? '00' + hours : hours;
            return hours + ':' + min + ' 00';
        }
    }
};

