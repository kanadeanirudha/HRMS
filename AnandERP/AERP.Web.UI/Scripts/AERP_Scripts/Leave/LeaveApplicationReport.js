
//this class contain methods related to nationality functionality
var LeaveApplicationReport = {
    //Member variables
    ActionName: null,
    totHalfday: null,
    HiddenBalanceLeave: 0,
    HiddenLeaveSessionID: 0,
    totalfullDaysLeave: 0,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveApplicationReport.constructor();
        //LeaveApplicationReport.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#LeaveMasterID').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LeaveMasterID').focus();
            return false;
        });



        // Create new record
        $('#CreateLeaveApplicationReportRecord').on("click", function () {
            ;
            
            var start = $("#FromDate").val();
            var end = $("#UptoDate").val();
            var leaveRuleMasterID = $('input[name=LeaveRuleMasterID]').val();
            var SelectedLeaveMasterID = $('#LeaveMasterID').val();
            var SelectedLeaveDescription = $('#LeaveMasterID :selected').text();



            if (start != null && start != "" && end != null && end != "" && leaveRuleMasterID != 0 && SelectedLeaveMasterID != 0) {
                LeaveApplicationReport.ActionName = "Create";
                LeaveApplicationReport.AjaxCallLeaveApplicationReport();
            }
            else if (SelectedLeaveMasterID == "") {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectLeaveType", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please Select Leave Type.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
            else if (leaveRuleMasterID == 0) {
                ajaxRequest.ErrorMessageWithOtherDateForJS("JsValidationMessages_NotAllotedToYou", "SuccessMessage", "#FFCC80", SelectedLeaveDescription, "right");
                //$('#SuccessMessage').html(SelectedLeaveDescription + " Not Alloted To You.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
            else if (start == null || start == "") {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_FromDateNotBlank", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("From Date should not be blank..");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
            else if (end == null || end == "") {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_UptoDateNotBlank", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Upto Date should not be blank..");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }

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

        // $(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();
        $(function () {
            $('#FromDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
                //defaultDate: new Date(),
            });

            $('#UptoDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
            });
            //used dp.hide instead of dp.change
            $('#FromDate').on("dp.hide", function (e) {
                var minDate = new Date(e.date.valueOf());
                minDate.setDate(minDate.getDate()); //alert(minDate);
                $('#UptoDate').data("DateTimePicker").minDate(minDate);
                var start = $("#FromDate").val();
                var end = $("#UptoDate").val();

                var checkFlag = document.getElementById("IsSecondHalf").checked;
                if (checkFlag == true) {
                    if (start == end) {
                        $('#IsFirstHalf').prop('checked', false);
                        $('#IsSecondHalf').prop('checked', false);
                    }
                }
                LeaveApplicationSelf.MyFunction();
                $("#IsFirstHalf").removeAttr("disabled");
                $("#UptoDate").removeAttr("disabled");
            });


            //used dp.hide instead of dp.change
            $("#UptoDate").on("dp.hide", function (e) {
                var maxDate = new Date(e.date.valueOf());
                maxDate.setDate(maxDate.getDate());
                $('#FromDate').data("DateTimePicker").maxDate(maxDate);

                var start = $("#FromDate").val();
                var end = $("#UptoDate").val();

                var checkFlag = document.getElementById("IsSecondHalf").checked;
                if (checkFlag == true) {
                    if (start == end) {
                        $('#IsFirstHalf').prop('checked', false);
                        $('#IsSecondHalf').prop('checked', false);
                    }
                }

                LeaveApplicationSelf.MyFunction();

                $("#IsSecondHalf").removeAttr("disabled");

            });
        });

        //$('#FromDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    onSelect: function (dateStr) {
        //        var min = $(this).datepicker('getDate'); // Get selected date
        //        $("#UptoDate").datepicker('option', 'minDate', min || '0'); // Set other min, default to today

        //        var start = $("#FromDate").val();
        //        var end = $("#UptoDate").val();

        //        var checkFlag = document.getElementById("IsSecondHalf").checked;
        //        if (checkFlag == true) {
        //            if (start == end) {
        //                $('#IsFirstHalf').prop('checked', false);
        //                $('#IsSecondHalf').prop('checked', false);
        //            }
        //        }

        //        LeaveApplicationReport.MyFunction();

        //        $("#IsFirstHalf").removeAttr("disabled");
        //        $("#UptoDate").removeAttr("disabled");
        //    },
        //    buttonImage: "/Content/images/calendar.gif",
        //});

        //$('#UptoDate').datepicker({

        //    dateFormat: 'd-M-yy',
        //    onSelect: function (dateStr) {
        //        ;
        //        var max = $(this).datepicker('getDate'); // Get selected date
        //        $('#FromDate').datepicker('option', 'maxDate', max || '+1Y+6M'); // Set other max, default to +18 months

        //        var start = $("#FromDate").val();
        //        var end = $("#UptoDate").val();

        //        var checkFlag = document.getElementById("IsSecondHalf").checked;
        //        if (checkFlag == true) {
        //            if (start == end) {
        //                $('#IsFirstHalf').prop('checked', false);
        //                $('#IsSecondHalf').prop('checked', false);
        //            }
        //        }

        //        LeaveApplicationReport.MyFunction();

        //        $("#IsSecondHalf").removeAttr("disabled");
        //    },
        //    buttonImage: "/Content/images/calendar.gif",
        //});


        $("#LeaveMasterID").change(function () {

            var SelectedLeaveMasterID = $('#LeaveMasterID').val();
            var SelectedLeaveDescription = $('#LeaveMasterID :selected').text();
            var EmployeeID = $('input[name=EmployeeID]').val();
            var LeaveSessionID = $('input[name=LeaveSessionID]').val();

            //Clear Data
            LeaveReason

            $("#FromDate").val("");
            $("#UptoDate").val("");
            $("#LeaveReason").val("");

            $('#IsFirstHalf').prop('checked', false);
            $('#IsSecondHalf').prop('checked', false);

            $("#UptoDate").attr("disabled", "disabled");
            $("#IsFirstHalf").attr("disabled", "disabled");
            $("#IsSecondHalf").attr("disabled", "disabled");

            $('#totalLeaves').val("0");

            if (SelectedLeaveMasterID != "") {
                $.ajax(
             {
                 cache: false,
                 type: "GET",
                 data: { LeaveMasterID: SelectedLeaveMasterID, EmployeeID: EmployeeID, LeaveSessionID: LeaveSessionID },

                 dataType: "html",
                 url: '/LeaveApplicationReport/GetLeaveDetailsByLeaveMaster_Employee_LeaveSessionID',
                 success: function (result) {
                     var aaa = result.replace('[', '');
                     aaa = aaa.replace(']', '');
                     var splitData = aaa.split(',');
                     //Rebind Grid Data   
                     $('#NumberOfLeaves').val(splitData[0]);
                     $('#MaxLeaveAtTime').val(splitData[1]);
                     $('#BalanceLeave').val(splitData[2]);
                     LeaveApplicationReport.HiddenBalanceLeave = splitData[2];
                     if (splitData.length == 4) {
                         $('input[name=LeaveRuleMasterID]').val(splitData[3]);
                         $('#Div_DatesAndRemark').fadeIn();
                     }
                     else if (splitData.length == 3) {
                         $('input[name=LeaveRuleMasterID]').val(0);
                         $('#Div_DatesAndRemark').fadeOut();
                         ajaxRequest.ErrorMessageForJS("JsValidationMessages_UptoDateNotBlank", "SuccessMessage", "#FFCC80");
                         //$('#SuccessMessage').html(SelectedLeaveDescription + " Not Alloted To You.");
                         //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                     }


                 }

             });
            }
            //else {
            //    LeaveApplicationReport.ReloadList("Please select leave type", "#FFCC80", null);
            //    $('#Div_DatesAndRemark').fadeOut();

            //}
        });

        $("#IsFirstHalf").click(function () {

            var start = $("#FromDate").val();
            var end = $("#UptoDate").val();

            var checkFlag = document.getElementById("IsFirstHalf").checked;
            if (checkFlag == true) {
                if (start == end) {
                    $('#IsSecondHalf').prop('checked', false);
                }
            }
            LeaveApplicationReport.MyFunction();

        });

        $("#IsSecondHalf").click(function () {

            var start = $("#FromDate").val();
            var end = $("#UptoDate").val();

            var checkFlag = document.getElementById("IsSecondHalf").checked;
            if (checkFlag == true) {
                if (start == end) {
                    $('#IsFirstHalf').prop('checked', false);

                }
            }
            LeaveApplicationReport.MyFunction();

        });

    },

    MyFunction: function () {

        var start = $("#FromDate").val();
        var end = $("#UptoDate").val();

        var checkFlag = document.getElementById("IsSecondHalf").checked;
        if (checkFlag == true) {
            if (start == end) {
                $('#IsFirstHalf').prop('checked', false);
            }
        }

        var checkValueFirstHalf = 0, checkValueSecondHalf = 0;
        var days = 1, balanceLeave = 0, totalLeaves = 0;
        //-------------------------------------------------------------------
        var checkFlagIsFirstHalf = document.getElementById("IsFirstHalf").checked;
        var checkFlagIsSecondHalf = document.getElementById("IsSecondHalf").checked;
        //-------------------------------------------------------------------

        LeaveApplicationReport.totHalfday = 0;
        if (checkFlagIsFirstHalf == true) {
            checkValueFirstHalf = 0.5;
            LeaveApplicationReport.totHalfday = LeaveApplicationReport.totHalfday + 1;
        }
        else {
            checkValueFirstHalf = 0;
            LeaveApplicationReport.totHalfday = LeaveApplicationReport.totHalfday + 0;
        }
        if (checkFlagIsSecondHalf == true) {
            checkValueSecondHalf = 0.5;
            LeaveApplicationReport.totHalfday = LeaveApplicationReport.totHalfday + 1;
        }
        else {
            checkValueSecondHalf = 0;
            LeaveApplicationReport.totHalfday = LeaveApplicationReport.totHalfday + 0;
        }


        var start = $("#FromDate").datepicker("getDate");
        var end = $("#UptoDate").datepicker("getDate");

        if (end != null && end != "") {
            days = (end - start) / (1000 * 60 * 60 * 24);
            if (start != end) {
                days = days + 1;
            }
        }

        totalLeaves = days - checkValueFirstHalf - checkValueSecondHalf;
        balanceLeave = LeaveApplicationReport.HiddenBalanceLeave - totalLeaves;
        LeaveApplicationReport.totalfullDaysLeave = totalLeaves - checkValueFirstHalf - checkValueSecondHalf;

        if (balanceLeave < 0) {
            var leaveWithoutPay = totalLeaves - LeaveApplicationReport.HiddenBalanceLeave;
            $('#BalanceLeave').val(0)
            $('#LeaveWithoutPay').val(leaveWithoutPay)

        }
        else {
            $('#BalanceLeave').val(balanceLeave)
            $('#LeaveWithoutPay').val(0)
        }


        $('#totalLeaves').val(totalLeaves)




    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        
        var EmployeeID = $('input[name=EmployeeID]').val();
        var LeaveSessionID = $('input[name=LeaveSessionID]').val();
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             data: { "actionMode": null, EmployeeID: EmployeeID, LeaveSessionID: LeaveSessionID },
             dataType: "html",
             url: '/LeaveApplicationReport/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var EmployeeID = $('input[name=EmployeeID]').val();
        var LeaveSessionID = $('input[name=LeaveSessionID]').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": null, EmployeeID: EmployeeID, LeaveSessionID: LeaveSessionID },
            url: '/LeaveApplicationReport/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(600).slideDown(400).delay(1000).slideUp(2000).css('background-color', colorCode);
            }
        });
    },



    //Fire ajax call to insert update and delete record
    AjaxCallLeaveApplicationReport: function () {
        var LeaveApplicationReportData = null;
        if (LeaveApplicationReport.ActionName == "Create") {
            $("#FormCreateLeaveApplicationReport").validate();
            if ($("#FormCreateLeaveApplicationReport").valid()) {
                LeaveApplicationReportData = null;
                LeaveApplicationReportData = LeaveApplicationReport.GetLeaveApplicationReport();
                ;
                ajaxRequest.makeRequest("/LeaveApplicationReport/Create", "POST", LeaveApplicationReportData, LeaveApplicationReport.Success);
            }
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveApplicationReport: function () {
        ;
        
        var Data = {
        };
        if (LeaveApplicationReport.ActionName == "Create") {
            debugger;
            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.LeaveMasterID = $('#LeaveMasterID').val();
            Data.FromDate = $('#FromDate').val();
            Data.UptoDate = $('#UptoDate').val();
            Data.TotalHalfDayLeave = LeaveApplicationReport.totHalfday;
            Data.TotalfullDaysLeave = LeaveApplicationReport.totalfullDaysLeave;

            Data.IsFirstHalf = document.getElementById("IsFirstHalf").checked;
            Data.IsSecondHalf = document.getElementById("IsSecondHalf").checked;


            //  Data.HalfLeaveStatus = LeaveApplicationReport.HalfLeaveStatus;
            Data.LeaveReason = $('#LeaveReason').val();
            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.LeaveRuleMasterID = $('input[name=LeaveRuleMasterID]').val();
        }

        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        ;
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            LeaveApplicationReport.ReloadList(splitData[0], splitData[1], splitData[2]);
            LeaveApplicationReport.Reset();
        } else {
            parent.$.colorbox.close();
            LeaveApplicationReport.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    Reset: function () {

        $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
        $('input:checkbox,input:radio').removeAttr('checked');
        $('#LeaveMasterID').focus();
        $('#LeaveMasterID').val("");
        $('#NumberOfLeaves').val(0);
        $('#MaxLeaveAtTime').val(0);
        $('#totalLeaves').val(0);
        $('#BalanceLeave').val(0);
        $('#LeaveWithoutPay').val(0);
        $('#Div_DatesAndRemark').fadeOut('slow');

    }

    //TotalHalfDay: function () {
    //    ;
    //    if (document.getElementById("IsFirstHalf").checked == true) {
    //        LeaveApplicationReport.totHalfday = 1;
    //        LeaveApplicationReport.HalfLeaveStatus = 'SH'
    //    }
    //    else if (document.getElementById("IsSecondHalf").checked == true) {
    //        LeaveApplicationReport.totHalfday = 1;
    //        LeaveApplicationReport.HalfLeaveStatus = 'FH'
    //    }
    //}

};

