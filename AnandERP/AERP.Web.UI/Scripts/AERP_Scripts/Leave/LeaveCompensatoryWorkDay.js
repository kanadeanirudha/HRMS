//this class contain methods related to nationality functionality
var LeaveCompensatoryWorkDay = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveCompensatoryWorkDay.constructor();
        //LeaveCompensatoryWorkDay.initializeValidation();
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

        //$('#CheckInTime').timepicki();
        //$('#CheckOutTime').timepicki();

        $('#CheckInTime').datetimepicker({
            format: 'LT',
            ignoreReadonly: true,
        });

        $('#CheckOutTime').datetimepicker({
            format: 'LT',
            ignoreReadonly: true,
        });

        // Create new record
        $('#CreateLeaveCompensatoryWorkDayRecord').on("click", function () {
            debugger;
            LeaveCompensatoryWorkDay.ActionName = "Create";
            LeaveCompensatoryWorkDay.AjaxCallLeaveCompensatoryWorkDay();
        });

        $('#EditLeaveCompensatoryWorkDayRecord').on("click", function () {
   
            LeaveCompensatoryWorkDay.ActionName = "Edit";
            LeaveCompensatoryWorkDay.AjaxCallLeaveCompensatoryWorkDay();
        });

        $('#DeleteLeaveCompensatoryWorkDayRecord').on("click", function () {

            LeaveCompensatoryWorkDay.ActionName = "Delete";
            LeaveCompensatoryWorkDay.AjaxCallLeaveCompensatoryWorkDay();
        });

        $('#ApproveLeaveCompensatoryWorkDayRecord').on("click", function () {
           
            LeaveCompensatoryWorkDay.ActionName = "Approved";
            LeaveCompensatoryWorkDay.AjaxCallLeaveCompensatoryWorkDay();
        });

        $('#RejectLeaveCompensatoryWorkDayRecord').on("click", function () {

            LeaveCompensatoryWorkDay.ActionName = "Reject";
            LeaveCompensatoryWorkDay.AjaxCallLeaveCompensatoryWorkDay();
        });

        $('#LeaveDescription').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#LeaveCode').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
            AERPValidation.NotAllowSpaces(e);
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

        $("#WorkingDate").change(function () {
            debugger;
            var selectedItem = $(this).val();
            if (selectedItem == "") {
                $("#CheckInTime").val("");
                $("#CheckOutTime").val("");
            }
            if ($("#WorkingDate").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/LeaveCompensatoryWorkDay/GetPunchTime",

                    data: { "Date": selectedItem },
                    success: function (data)
                    {
                        debugger;
                        //$("#CheckInTime").val($.datepicker.formatDate('dd M yy', data[0].CheckInTime));
                       // $.each(data, function (CheckInTime, CheckOutTime)
                        //{
                        $("#CheckInTime").val(LeaveCompensatoryWorkDay.Convert_hours_am_pm(data[0].CheckInTime));
                        $("#CheckOutTime").val(LeaveCompensatoryWorkDay.Convert_hours_am_pm(data[0].CheckOutTime));
                        //}
                       
                       
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Time.');
                      
                    }
                });
            }
            else {
              //  $('#ListViewModel').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value="">----Select Department----</option>');
            }

        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();


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

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/LeaveCompensatoryWorkDay/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,'success');
            }
        });
    },

    ReloadListForApproval_Reject: function (message, colorCode, actionMode) {
        var TaskCode = $('input[name=TaskCode]').val();

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "TaskCode": TaskCode },
            url: '/Home/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,'success');
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallLeaveCompensatoryWorkDay: function () {
        var LeaveCompensatoryWorkDayData = null;
        if (LeaveCompensatoryWorkDay.ActionName == "Create") {
            debugger;
            $("#FormCreateLeaveCompensatoryWorkDay").validate();
            if ($("#FormCreateLeaveCompensatoryWorkDay").valid()) {
                LeaveCompensatoryWorkDayData = null;
                LeaveCompensatoryWorkDayData = LeaveCompensatoryWorkDay.GetLeaveCompensatoryWorkDay();
                ajaxRequest.makeRequest("/LeaveCompensatoryWorkDay/Create", "POST", LeaveCompensatoryWorkDayData, LeaveCompensatoryWorkDay.Success);
            }
        }
        else if (LeaveCompensatoryWorkDay.ActionName == "Edit") {
            $("#FormEditLeaveCompensatoryWorkDay").validate();
            if ($("#FormEditLeaveCompensatoryWorkDay").valid()) {
                LeaveCompensatoryWorkDayData = null;
                LeaveCompensatoryWorkDayData = LeaveCompensatoryWorkDay.GetLeaveCompensatoryWorkDay();
                ajaxRequest.makeRequest("/LeaveCompensatoryWorkDay/Edit", "POST", LeaveCompensatoryWorkDayData, LeaveCompensatoryWorkDay.Success);
            }
        }
        else if (LeaveCompensatoryWorkDay.ActionName == "Delete") {
            LeaveCompensatoryWorkDayData = null;
            //$("#FormCreateLeaveCompensatoryWorkDay").validate();
            LeaveCompensatoryWorkDayData = LeaveCompensatoryWorkDay.GetLeaveCompensatoryWorkDay();
            ajaxRequest.makeRequest("/LeaveCompensatoryWorkDay/Delete", "POST", LeaveCompensatoryWorkDayData, LeaveCompensatoryWorkDay.Success);

        }
        else if (LeaveCompensatoryWorkDay.ActionName == "Approved") {
            
            alert(LeaveCompensatoryWorkDayData);
            LeaveCompensatoryWorkDayData = null;          
            LeaveCompensatoryWorkDayData = LeaveCompensatoryWorkDay.GetLeaveCompensatoryWorkDay();
            ajaxRequest.makeRequest("/LeaveCompensatoryWorkDay/RequestApproval", "POST", LeaveCompensatoryWorkDayData, LeaveCompensatoryWorkDay.SuccessForApproval_Reject);

        }
        else if (LeaveCompensatoryWorkDay.ActionName == "Reject") {
            
            alert(LeaveCompensatoryWorkDayData);
            LeaveCompensatoryWorkDayData = null;          
            LeaveCompensatoryWorkDayData = LeaveCompensatoryWorkDay.GetLeaveCompensatoryWorkDay();
            ajaxRequest.makeRequest("/LeaveCompensatoryWorkDay/RequestApproval", "POST", LeaveCompensatoryWorkDayData, LeaveCompensatoryWorkDay.SuccessForApproval_Reject);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveCompensatoryWorkDay: function () {
        var Data = {
        };
        if (LeaveCompensatoryWorkDay.ActionName == "Create" || LeaveCompensatoryWorkDay.ActionName == "Edit") {
   
            Data.ID = $('input[name=ID]').val();
            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.WorkingDate = $('#WorkingDate').val();
            Data.CheckInTime = LeaveCompensatoryWorkDay.hours_am_pm($("#CheckInTime").val());
            Data.CheckOutTime = LeaveCompensatoryWorkDay.hours_am_pm($("#CheckOutTime").val());
            //Data.CheckInTime = $("#CheckInTime").val();
            //Data.CheckOutTime = $("#CheckOutTime").val();
            Data.WorkingReason = $('#WorkingReason').val();
            Data.IsHalfDayUtilized = $('#IsHalfDayUtilized').is(":checked") ? "true" : "false";
            //return false;
        }
        else if (LeaveCompensatoryWorkDay.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        else if (LeaveCompensatoryWorkDay.ActionName == "Approved") {
            
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
        else if (LeaveCompensatoryWorkDay.ActionName == "Reject") {
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
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveCompensatoryWorkDay.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveCompensatoryWorkDay.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    SuccessForApproval_Reject: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveCompensatoryWorkDay.ReloadListForApproval_Reject(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveCompensatoryWorkDay.ReloadListForApproval_Reject(splitData[0], splitData[1], splitData[2]);
        }

    },
    

    //hours_am_pm: function (time) {
       
    //    debugger;
    //    var time = (time).split(':');
    //    var hours = parseInt(time[0].trim());
    //    var minutes = parseInt(time[1].trim());
    //    var AMPM = time[2].trim();
    //    if (AMPM == "PM" && hours < 12 && hours != 00) hours = hours + 12;
    //    if (AMPM == "AM" && hours == 12 && hours != 00) hours = hours - 12;
    //    var sHours = hours.toString();
    //    var sMinutes = minutes.toString();
    //    if (hours < 10) sHours = "0" + sHours;
    //    if (minutes < 10) sMinutes = "0" + sMinutes;
    //    return (sHours + ":" + sMinutes + ":00");
    //},

    hours_am_pm: function (time) {

        debugger;
        var time = (time).split(':');
        var hours = parseInt(time[0].trim());
        var minutes = parseInt(time[1].trim());
        //var AMPM = time[2].trim();
        var AMPMSP = time[1].split(' ');
        var AMPM = AMPMSP[1].split();
        if (AMPM == "PM" && hours < 12 && hours != 00) hours = hours + 12;
        if (AMPM == "AM" && hours == 12 && hours != 00) hours = hours - 12;
        var sHours = hours.toString();
        var sMinutes = minutes.toString();
        if (hours < 10) sHours = "0" + sHours;
        if (minutes < 10) sMinutes = "0" + sMinutes;
        return (sHours + ":" + sMinutes + ":00");
    },
    Convert_hours_am_pm: function (time) {

        debugger;
        var time = (time).split(':');
        var hours = parseInt(time[0].trim());
        var minutes = parseInt(time[1].trim());
        var tempHours = hours;
        if(hours > 12)
            tempHours = hours - 12;

        if (tempHours > 12) {
            if (minutes > 9)
            {
                return tempHours + ":" + minutes + " PM";
            }
            else
            {
                return tempHours + ":0" + minutes + " PM";
            }
        }
        else {
            if (minutes > 9) {
                if (hours > 12)
                {
                    if (tempHours > 9)
                    {
                        return tempHours + ":" + minutes + " PM";
                    }
                    else
                    {
                        return "0" + tempHours + ":" + minutes + " PM";
                    }
                }
                else
                {
                    if (tempHours > 9) {
                        return tempHours + ":" + minutes + " AM";
                    }
                    else {
                        return "0" + tempHours + ":" + minutes + " AM";
                    }
                }
            }
            else {
                if (tempHours > 9) {
                    return tempHours + ":" + minutes + " AM";
                }
                else {
                    return "0" + tempHours + ":" + minutes + " AM";
                }
            }
        }
    }

    //hours_am_pm: function (time) {
       
    //var hours = time[0] + time[1];
    //var min = time[5] + time[6];
    //var AmPm = "";
    //if (hours < 12) {
    //    AmPm = time[10] + time[11];
    //        if (AmPm == "AM") {
    //            return hours + ':' + min + ':00';
    //            AmPm = '';
    //        }
    //        else {
    //            hours = parseInt(hours) + parseInt(12);
    //            return hours + ':' + min + ':00';
    //           AmPm = '';
    //        }
    //} else
    //{
    //    hours = hours - 12;
    //    hours = (hours.length < 10) ? '00' + hours : hours;
    //    return hours + ':' + min + ' 00';
    //   }
    //}
};

