////this class contain methods related to nationality functionality
//var LeaveManualAttendanceSelf = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        LeaveManualAttendanceSelf.constructor();
//        //LeaveManualAttendanceSelf.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

//            return false;
//        });

//        $('#CheckInTime').timepicki();
//        $('#CheckOutTime').timepicki();

//        $("#AttendanceDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M y',
//            maxDate: 0,

//        });



//        // Create new record
//        $('#CreateLeaveManualAttendanceSelfRecord').on("click", function () {
//            if ($('#AttendanceDate').val() == "") {
//                ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectAttendanceDate");
//                // alert("Please select Attendance Date");
//                return false;
//            }
//            else if ($('#AttendenceFor').val() == "CIT" && $('#CheckInTime').val() == "") {
//                ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectCheckInTime");
//                //alert("Please select CheckIn Time");
//                return false;
//            }
//            else if ($('#AttendenceFor').val() == "COT" && $('#CheckOutTime').val() == "") {
//                ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectCheckOutTime");
//                //  alert("Please select CheckOut Time");
//                return false;
//            }
//            else if ($('#AttendenceFor').val() == "B") {

//                if ($('#CheckInTime').val() == "" && $('#CheckOutTime').val() == "") {
//                    ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectCheckInAndOutTime");
//                    // alert("Please select CheckOut Time and CheckOut Time");
//                    return false;
//                }
//                else if ($('#CheckInTime').val() == "") {
//                    ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectCheckInTime");
//                    // alert("Please select CheckIn Time");
//                    return false;
//                }
//                else if ($('#CheckOutTime').val() == "") {
//                    ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectCheckOutTime");
//                    // alert("Please select CheckOut Time");
//                    return false;
//                }

//            }
//            else if ($('#Reason').val() == "") {
//                ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_EnterReason");
//               // alert("Please enter reason");
//                return false;
//            }
//            LeaveManualAttendanceSelf.ActionName = "Create";
//            LeaveManualAttendanceSelf.AjaxCallLeaveManualAttendanceSelf();

//        });

//        $('#EditLeaveManualAttendanceSelfRecord').on("click", function () {
            
            
//            LeaveManualAttendanceSelf.ActionName = "Edit";
//            LeaveManualAttendanceSelf.AjaxCallLeaveManualAttendanceSelf();
//        });

//        //$('#DeleteLeaveManualAttendanceSelfRecord').on("click", function () {

//        //    LeaveManualAttendanceSelf.ActionName = "Delete";
//        //    LeaveManualAttendanceSelf.AjaxCallLeaveManualAttendanceSelf();
//        //});

//        //$('#LeaveDescription').on("keydown", function (e) {
//        //    AMSValidation.AllowCharacterOnly(e);
//        //});

//        //$('#LeaveCode').on("keydown", function (e) {
//        //    AMSValidation.AllowCharacterOnly(e);
//        //    AMSValidation.NotAllowSpaces(e);
//        //});

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });

//        $('#Reason').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
            
//        });

//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();

//        $("#AttendenceFor").change(function () {

//            if ($('#AttendenceFor').val() == "CIT") {
//                $('#Div_CheckInTime').show();
//                $('#Div_CheckOutTime').hide();
//                $('#CheckInTime').val("");
//                $('#CheckOutTime').val("");
//            }
//            else if ($('#AttendenceFor').val() == "COT") {
//                $('#Div_CheckInTime').hide();
//                $('#Div_CheckOutTime').show();
//                $('#CheckInTime').val("");
//                $('#CheckOutTime').val("");
//            }
//            else if ($('#AttendenceFor').val() == "B") {
//                $('#Div_CheckInTime').show();
//                $('#Div_CheckOutTime').show();
//                $('#CheckInTime').val("");
//                $('#CheckOutTime').val("");
//            }
//        });

//        //$("#CentreCode").change(function () {
//        //    $('#myDataTable').html("");
//        //    $('#myDataTable_info').text("No entries to show");
//        //    $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        //    $('#Createbutton').hide();
//        //});

//        //$("#ShowList").click(function () {
//        //    
//        //    var SelectedCentreCode = $('#CentreCode').val();
//        //    var SelectedCentreName = $('#CentreCode :selected').text();

//        //    if (SelectedCentreCode != "") {
//        //        $.ajax(
//        //     {
//        //         cache: false,
//        //         type: "POST",
//        //         data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

//        //         dataType: "html",
//        //         url: '/LeaveManualAttendanceSelf/List',
//        //         success: function (result) {
//        //             //Rebind Grid Data                
//        //             $('#ListViewModel').html(result);
//        //             $('#Createbutton').show();

//        //         }
//        //     });
//        //    }
//        //    else {
//        //        LeaveManualAttendanceSelf.ReloadList("Please select centre", "#FFCC80", null);
//        //        //   $('#Createbutton').hide();
//        //        $('#Createbutton').hide();
//        //    }
//        //});


//    },
//    ////Load method is used to load *-Load-* page
//    LoadList: function () {
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/LeaveManualAttendanceSelf/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
//        //var SelectedCentreCode = $('#CentreCode').val();
//        //var SelectedCentreName = $('#CentreCode :selected').text();

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            //data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
//            data: { actionMode: null },
//            url: '/LeaveManualAttendanceSelf/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallLeaveManualAttendanceSelf: function () {
//        var LeaveManualAttendanceSelfData = null;
//        if (LeaveManualAttendanceSelf.ActionName == "Create") {
//            //$("#FormCreateLeaveManualAttendanceSelf").validate();
//            //if ($("#FormCreateLeaveManualAttendanceSelf").valid()) {
//            LeaveManualAttendanceSelfData = null;
//            LeaveManualAttendanceSelfData = LeaveManualAttendanceSelf.GetLeaveManualAttendanceSelf();
//            ajaxRequest.makeRequest("/LeaveManualAttendanceSelf/Create", "POST", LeaveManualAttendanceSelfData, LeaveManualAttendanceSelf.Success);
//            //}
//        }
//        else if (LeaveManualAttendanceSelf.ActionName == "Edit") {
//            $("#FormEditLeaveManualAttendanceSelf").validate();
//            if ($("#FormEditLeaveManualAttendanceSelf").valid()) {
//                LeaveManualAttendanceSelfData = null;
//                LeaveManualAttendanceSelfData = LeaveManualAttendanceSelf.GetLeaveManualAttendanceSelf();
//                ajaxRequest.makeRequest("/LeaveManualAttendanceSelf/Edit", "POST", LeaveManualAttendanceSelfData, LeaveManualAttendanceSelf.Success);
//            }
//        }
//        //else if (LeaveManualAttendanceSelf.ActionName == "Delete") {
//        //    LeaveManualAttendanceSelfData = null;
//        //    //$("#FormCreateLeaveManualAttendanceSelf").validate();
//        //    LeaveManualAttendanceSelfData = LeaveManualAttendanceSelf.GetLeaveManualAttendanceSelf();
//        //    ajaxRequest.makeRequest("/LeaveManualAttendanceSelf/Delete", "POST", LeaveManualAttendanceSelfData, LeaveManualAttendanceSelf.Success);

//        //}
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetLeaveManualAttendanceSelf: function () {
//        var Data = {
//        };
        
//        if (LeaveManualAttendanceSelf.ActionName == "Create" || LeaveManualAttendanceSelf.ActionName == "Edit") {
//            Data.ID = $('input[name=ID]').val();
//            Data.AttendanceDate = $('#AttendanceDate').val();
//            if ($("#CheckInTime").val() != null && $("#CheckInTime").val() != "") {
//                Data.CheckInTime = LeaveManualAttendanceSelf.hours_am_pm($("#CheckInTime").val());
//            }
//            else {
//                Data.CheckInTime = "";
//            }
//            if ($("#CheckOutTime").val() != null && $("#CheckOutTime").val() != "") {
//                Data.CheckOutTime = LeaveManualAttendanceSelf.hours_am_pm($('#CheckOutTime').val());
//            }
//            else {
//                Data.CheckOutTime = "";
//            }
//            Data.AttendenceFor = $('#AttendenceFor').val();
//            Data.CentreCode = $('input[name=CentreCode]').val();
//            Data.Reason = $('#Reason').val();
//        }
//        //else if (LeaveManualAttendanceSelf.ActionName == "Delete") {
//        //    Data.ID = $('input[name=ID]').val();
//        //}
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            LeaveManualAttendanceSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            LeaveManualAttendanceSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },

//    hours_am_pm: function (time) {
        
//        var time = (time).split(':');
//        var hours = parseInt(time[0].trim());
//        var minutes = parseInt(time[1].trim());
//        var AMPM = time[2].trim();
//        if (AMPM == "PM" && hours < 12 && hours != 00) hours = hours + 12;
//        if (AMPM == "AM" && hours == 12 && hours != 00) hours = hours - 12;
//        var sHours = hours.toString();
//        var sMinutes = minutes.toString();
//        if (hours < 10) sHours = "0" + sHours;
//        if (minutes < 10) sMinutes = "0" + sMinutes;
//        return (sHours + ":" + sMinutes + ":00");
//    },

//};

////////////////////////////////////new js/////////////////////////////



//this class contain methods related to nationality functionality
var LeaveManualAttendanceSelf = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveManualAttendanceSelf.constructor();
        //LeaveManualAttendanceSelf.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

            return false;
        });

        //$('#CheckInTime').timepicki();
        //$('#CheckOutTime').timepicki();

        //$("#AttendanceDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M y',
        //    maxDate: 0,

        //});

        $('#CheckInTime').datetimepicker({
            //format: 'hh:mm:ss',
            format: 'LT',
            ignoreReadonly: true,
        });

        $('#CheckOutTime').datetimepicker({
            //format: 'hh:mm:ss',
            format: 'LT',
            ignoreReadonly: true,
        });

        $('#AttendanceDate').attr("readonly", true);

        $('#AttendanceDate').datetimepicker({
            format: 'DD MMM YYYY',
            maxDate: moment(),
            ignoreReadonly: true,

        });

        // Create new record
        $('#CreateLeaveManualAttendanceSelfRecord').on("click", function () {


            if ($('#AttendanceDate').val() == "") {
                //ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectAttendanceDate");
                $("#displayErrorMessage p").text('Please select Attendance Date').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
                return false;
            }
            else if ($('#AttendenceFor').val() == "CIT" && $('#CheckInTime').val() == "") {
                //ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectCheckInTime");
                $("#displayErrorMessage p").text('Please select CheckIn time').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
                return false;
            }
            else if ($('#AttendenceFor').val() == "COT" && $('#CheckOutTime').val() == "") {
                //ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectCheckOutTime");
                $("#displayErrorMessage p").text('Please select CheckOut time').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
                return false;
            }
            else if ($('#AttendenceFor').val() == "B") {
                
                if ($('#CheckInTime').val() == "" && $('#CheckOutTime').val() == "") {
                    //ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectCheckInAndOutTime");
                    $("#displayErrorMessage p").text('Please select CheckIn and CheckOut time').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
                    return false;
                }
                else if ($('#CheckInTime').val() == "") {
                    //ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectCheckInTime");
                    $("#displayErrorMessage p").text('Please select CheckIn time').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
                    return false;
                }
                else if ($('#CheckOutTime').val() == "") {
                    //ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_SelectCheckOutTime");
                    $("#displayErrorMessage p").text('Please select CheckOut time').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
                    return false;
                } else if ($('#Reason').val() == "") {
                    //ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_EnterReason");
                    $("#displayErrorMessage p").text('Please write down the reason.').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
                    return false;
                }
                

            }
            //else if ($('#Reason').val() == "") {
                
            //    //ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_EnterReason");
            //    $("#displayErrorMessage p").text('Please select reason').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
            //    return false;
            //}
            
            LeaveManualAttendanceSelf.ActionName = "Create";
            LeaveManualAttendanceSelf.AjaxCallLeaveManualAttendanceSelf();

        });

        $('#EditLeaveManualAttendanceSelfRecord').on("click", function () {


            LeaveManualAttendanceSelf.ActionName = "Edit";
            LeaveManualAttendanceSelf.AjaxCallLeaveManualAttendanceSelf();
        });

        

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $('#Reason').on("keydown", function (e) {
           // AERPValidation.AllowCharacterOnly(e);

        });

        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $("#AttendenceFor").change(function () {

            if ($('#AttendenceFor').val() == "CIT") {
                $('#Div_CheckInTime').show();
                $('#Div_CheckOutTime').hide();
                $('#CheckInTime').val("");
                $('#CheckOutTime').val("");
            }
            else if ($('#AttendenceFor').val() == "COT") {
                $('#Div_CheckInTime').hide();
                $('#Div_CheckOutTime').show();
                $('#CheckInTime').val("");
                $('#CheckOutTime').val("");
            }
            else if ($('#AttendenceFor').val() == "B") {
                $('#Div_CheckInTime').show();
                $('#Div_CheckOutTime').show();
                $('#CheckInTime').val("");
                $('#CheckOutTime').val("");
            }
        });

        


    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/LeaveManualAttendanceSelf/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        //var SelectedCentreCode = $('#CentreCode').val();
        //var SelectedCentreName = $('#CentreCode :selected').text();

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            //data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
            data: { actionMode: null },
            url: '/LeaveManualAttendanceSelf/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', colorCode);
                notify(message,'success');
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallLeaveManualAttendanceSelf: function () {
        
        var LeaveManualAttendanceSelfData = null;
        if (LeaveManualAttendanceSelf.ActionName == "Create") {
            //$("#FormCreateLeaveManualAttendanceSelf").validate();
            //if ($("#FormCreateLeaveManualAttendanceSelf").valid()) {
            LeaveManualAttendanceSelfData = null;
            LeaveManualAttendanceSelfData = LeaveManualAttendanceSelf.GetLeaveManualAttendanceSelf();
            ajaxRequest.makeRequest("/LeaveManualAttendanceSelf/Create", "POST", LeaveManualAttendanceSelfData, LeaveManualAttendanceSelf.Success);
            //}
        }
        else if (LeaveManualAttendanceSelf.ActionName == "Edit") {
            $("#FormEditLeaveManualAttendanceSelf").validate();
            if ($("#FormEditLeaveManualAttendanceSelf").valid()) {
                LeaveManualAttendanceSelfData = null;
                LeaveManualAttendanceSelfData = LeaveManualAttendanceSelf.GetLeaveManualAttendanceSelf();
                ajaxRequest.makeRequest("/LeaveManualAttendanceSelf/Edit", "POST", LeaveManualAttendanceSelfData, LeaveManualAttendanceSelf.Success);
            }
        }
        
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveManualAttendanceSelf: function () {
        
        var Data = {
        };

        if (LeaveManualAttendanceSelf.ActionName == "Create" || LeaveManualAttendanceSelf.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.AttendanceDate = $('#AttendanceDate').val();
            
            if ($("#CheckInTime").val() != null && $("#CheckInTime").val() != "") {
                Data.CheckInTime = LeaveManualAttendanceSelf.hours_am_pm($("#CheckInTime").val());
            }
            else {
                Data.CheckInTime = "";
            }
            if ($("#CheckOutTime").val() != null && $("#CheckOutTime").val() != "") {
                Data.CheckOutTime = LeaveManualAttendanceSelf.hours_am_pm($('#CheckOutTime').val());
            }
            else {
                Data.CheckOutTime = "";
            }
            Data.AttendenceFor = $('#AttendenceFor').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.Reason = $('#Reason').val();
        }
        //else if (LeaveManualAttendanceSelf.ActionName == "Delete") {
        //    Data.ID = $('input[name=ID]').val();
        //}
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveManualAttendanceSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveManualAttendanceSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    hours_am_pm: function (time) {

        var time_array = (time).split(':');
        var hours = parseInt(time_array[0].trim());
        var minutes_array = (time_array[1]).split(' ');
        var minutes = parseInt(minutes_array[0].trim());
        var AMPM = minutes_array[1].trim();
        if (AMPM == "PM" && hours < 12 && hours != 00) hours = hours + 12;
        if (AMPM == "AM" && hours == 12 && hours != 00) hours = hours - 12;
        var sHours = hours.toString();
        var sMinutes = minutes.toString();
        if (hours < 10) sHours = "0" + sHours;
        if (minutes < 10) sMinutes = "0" + sMinutes;
        return (sHours + ":" + sMinutes + ":00");
    },

};

