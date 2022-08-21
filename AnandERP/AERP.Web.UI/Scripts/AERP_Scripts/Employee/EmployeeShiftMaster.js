//this class contain methods related to nationality functionality
var EmployeeShiftMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeShiftMaster.constructor();
        //EmployeeShiftMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CountryName').focus();

        $("#ResetEmployeeShiftMasterRecord").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#EmployeeShiftDescription').focus();
           
            return false;
        });
        $("#ResetEmployeeShiftMasterDetailsRecord").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#WeeklyOffStatus').val("N");
            $('#ShiftTimeFrom').val();
            $('#ShiftTimeUpto').val();
            $('#ShiftTimeMargin').val();
            $('#ShiftEndBuffer').val();
            $('#LunchTimeFrom').val();
            $('#LunchTimeUpto').val();
            $('#FirstHalfUpto').val();
            $('#SecondHalfFrom').val();
            $('#ConsiderLateMarkUpto').val();
            $('#WeeklyOffType').val("Not Applicable");
            $('#WeeklyOffType').attr('disabled', true);

            return false;
        });

        //$('#ShiftTimeFrom').timepicki();
        $('#ShiftTimeFrom').datetimepicker({
            format: 'LT',
            ignoreReadonly: true,
        });

        //$('#ShiftTimeUpto').timepicki();
        $('#ShiftTimeUpto').datetimepicker({
            format: 'LT',
            ignoreReadonly: true,
        });
        //$('#LunchTimeFrom').timepicki();
        $('#LunchTimeFrom').datetimepicker({
            format: 'LT',
            ignoreReadonly: true,
        });
        //$('#LunchTimeUpto').timepicki();
        $('#LunchTimeUpto').datetimepicker({
            format: 'LT',
            ignoreReadonly: true,
        });
        //$('#FirstHalfUpto').timepicki();
        $('#FirstHalfUpto').datetimepicker({
            format: 'LT',
            ignoreReadonly: true,
        });
        //$('#SecondHalfFrom').timepicki();
        $('#SecondHalfFrom').datetimepicker({
            format: 'LT',
            ignoreReadonly: true,
        });
        //$('#ConsiderLateMarkUpto').timepicki();
        $('#ConsiderLateMarkUpto').datetimepicker({
            format: 'LT',
            ignoreReadonly: true,
        });


        // Create new record
        $('#CreateEmployeeShiftMasterRecord').on("click", function () {
         

            EmployeeShiftMaster.ActionName = "Create";
            EmployeeShiftMaster.AjaxCallEmployeeShiftMaster();
        });

        $('#EditEmployeeShiftMasterRecord').on("click", function () {

            EmployeeShiftMaster.ActionName = "Edit";
            EmployeeShiftMaster.AjaxCallEmployeeShiftMaster();
        });

        $('#CreateEmployeeShiftMasterDetailsRecord').on("click", function () {

            EmployeeShiftMaster.ActionName = "CreateEmployeeShiftMasterDetails";
            EmployeeShiftMaster.AjaxCallEmployeeShiftMaster();
        });

        $('#EditEmployeeShiftMasterDetailsRecord').on("click", function () {
           
       
          
            if ($("#ShiftTimeFrom").val() == "" || $("#ShiftTimeFrom").val() == null) {
                $("#displayErrorMessage p").text("Please Select Shift Time From.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false
            }
            else if ($("#ShiftTimeUpto").val() == "" || $("#ShiftTimeUpto").val() == null) {
                $("#displayErrorMessage p").text("Please Select Shift Time Upto.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false
           }
            else if ($("#ShiftTimeMargin").val() == "" || $("#ShiftTimeMargin").val() == null) {
                $("#displayErrorMessage p").text("Please Select Shift Time Margin.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
               return false
           }
            else if ($("#ShiftEndBuffer").val() == "" || $("#ShiftEndBuffer").val() == null) {
                $("#displayErrorMessage p").text("Please Select Shift End Buffer.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
               return false
           }
            else if ($("#LunchTimeFrom").val() == "" || $("#LunchTimeFrom").val() == null) {
                $("#displayErrorMessage p").text("Please Select Lunch Time From.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
               return false
           }
            else if ($("#LunchTimeUpto").val() == "" || $("#LunchTimeUpto").val() == null) {
                $("#displayErrorMessage p").text("Please Select Lunch Time Upto.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
               return false
           }
            else if ($("#FirstHalfUpto").val() == "" || $("#FirstHalfUpto").val() == null) {
                $("#displayErrorMessage p").text("Please Select First Half Upto.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
               return false
            }
            else if ($("#SecondHalfFrom").val() == "" || $("#SecondHalfFrom").val() == null) {
                $("#displayErrorMessage p").text("Please Select Second Half From.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false
            }
            else if ($("#ConsiderLateMarkUpto").val() == "" || $("#ConsiderLateMarkUpto").val() == null) {
                $("#displayErrorMessage p").text("Please Select Consider Late Mark Upto.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false
            }

            EmployeeShiftMaster.ActionName = "EditEmployeeShiftMasterDetails";
            EmployeeShiftMaster.AjaxCallEmployeeShiftMaster();
        });

        $('#DocumentName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $('#WeeklyOffStatus').on("change", function () {
            if ($('#WeeklyOffStatus').val() == 'Y') {
             
                $('#ShiftTimeFrom').val("00:00 AM");
                $('#ShiftTimeUpto').val("00:00 AM");
                $('#LunchTimeFrom').val("00:00 AM");
                $('#LunchTimeUpto').val("00:00 AM");
                $('#FirstHalfUpto').val("00:00 AM");
                $('#SecondHalfFrom').val("00:00 AM");
                $('#ConsiderLateMarkUpto').val("00:00 AM");

                $('#ShiftTimeFrom').prop('disabled', true);
                $('#ShiftTimeUpto').prop('disabled', true);
                $('#ShiftTimeMargin').prop('disabled', true);
                $('#ShiftEndBuffer').prop('disabled', true);
                $('#LunchTimeFrom').prop('disabled', true);
                $('#LunchTimeUpto').prop('disabled', true);
                $('#FirstHalfUpto').prop('disabled', true);
                $('#SecondHalfFrom').prop('disabled', true);
                $('#ConsiderLateMarkUpto').prop('disabled', true);
                $('#EmployeeServiceDetails_WeeklyOffType').prop('disabled', false);
                $('#WeeklyOffType').prop('disabled', false);
                $('#EmployeeServiceDetails_WeeklyOffType').val("ALL");
                $('#WeeklyOffType').val("ALL");
               
       
            }
            else {
                $('#EmployeeServiceDetails_WeeklyOffType').prop('disabled', true);
                $('#EmployeeServiceDetails_WeeklyOffType').val("Not Applicable");
                $('#WeeklyOffType').prop('disabled', true);
                $('#WeeklyOffType').val("Not Applicable");
                $('#ShiftTimeFrom').prop('disabled', false);
                $('#ShiftTimeUpto').prop('disabled', false);
                $('#ShiftTimeMargin').prop('disabled', false);
                $('#ShiftEndBuffer').prop('disabled', false);
                $('#LunchTimeFrom').prop('disabled', false);
                $('#LunchTimeUpto').prop('disabled', false);
                $('#FirstHalfUpto').prop('disabled', false);
                $('#SecondHalfFrom').prop('disabled', false);
                $('#ConsiderLateMarkUpto').prop('disabled', false);
                
            }
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#EmployeeShiftDescription').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
         
        })

        $('#BackShiftDetails').on("keydown", function (e) {

        })

    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/EmployeeShiftMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        var CentreCode = $('#CentreList :selected').val();
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "centerCode": CentreCode },
            url: '/EmployeeShiftMaster/List',
            success: function (data) {
                //Rebind Grid Data

                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },

    //ReloadList method is used to load List page
    ReloadShiftMasterDetailsList: function (message, colorCode, actionMode) {

        //$('#SuccessMessageShiftDetails').html(message);
        //$('#SuccessMessageShiftDetails').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
        notify(message,"success");
        
    },

    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeShiftMaster: function () {
        var EmployeeShiftMasterData = null;
        if (EmployeeShiftMaster.ActionName == "Create") {
            $("#FormCreateEmployeeShiftMaster").validate();
            if ($("#FormCreateEmployeeShiftMaster").valid()) {
                EmployeeShiftMasterData = null;
                EmployeeShiftMasterData = EmployeeShiftMaster.GetEmployeeShiftMaster();

                ajaxRequest.makeRequest("/EmployeeShiftMaster/CreateShift", "POST", EmployeeShiftMasterData, EmployeeShiftMaster.Success);
            }
        }
        else if (EmployeeShiftMaster.ActionName == "Edit") {
            debugger;
            $("#FormEditEmployeeShiftMaster").validate();
            if ($("#FormEditEmployeeShiftMaster").valid()) {
                EmployeeShiftMasterData = null;
                EmployeeShiftMasterData = EmployeeShiftMaster.GetEmployeeShiftMaster();
                ajaxRequest.makeRequest("/EmployeeShiftMaster/EditShift", "POST", EmployeeShiftMasterData, EmployeeShiftMaster.Success);
            }
        }
        else if (EmployeeShiftMaster.ActionName == "CreateEmployeeShiftMasterDetails") {
            EmployeeShiftMasterData = null;
            //$("#FormCreateEmployeeShiftMaster").validate();
            EmployeeShiftMasterData = EmployeeShiftMaster.GetEmployeeShiftMaster();
            ajaxRequest.makeRequest("/EmployeeShiftMaster/CreateEmployeeShiftMasterDetails", "POST", EmployeeShiftMasterData, EmployeeShiftMaster.SuccessEmployeeShiftMasterDetails);

        }
        else if (EmployeeShiftMaster.ActionName == "EditEmployeeShiftMasterDetails") {
            EmployeeShiftMasterData = null;
            //$("#FormCreateEmployeeShiftMaster").validate();
            EmployeeShiftMasterData = EmployeeShiftMaster.GetEmployeeShiftMaster();
            ajaxRequest.makeRequest("/EmployeeShiftMaster/EditEmployeeShiftMasterDetails", "POST", EmployeeShiftMasterData, EmployeeShiftMaster.SuccessEmployeeShiftMasterDetails);

        }

    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeShiftMaster: function () {
        var Data = {
        };

        if (EmployeeShiftMaster.ActionName == "Create" || EmployeeShiftMaster.ActionName == "Edit") {
            Data.EmployeeShiftMasterID = $('input[name=EmployeeShiftMasterID]').val();
            Data.EmployeeShiftDescription = $('#EmployeeShiftDescription').val();
        }
        if (EmployeeShiftMaster.ActionName == "CreateEmployeeShiftMasterDetails") {
            Data.EmployeeShiftMasterID = $('input[name=EmployeeShiftMasterID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.GeneralWeekDaysID = $('#GeneralWeekDaysID').val();
            Data.WeeklyOffStatus = $('#WeeklyOffStatus').val();
            Data.WeeklyOffType = $('#WeeklyOffType').val();
            Data.ShiftTimeFrom = EmployeeShiftMaster.hours_am_pm($("#ShiftTimeFrom").val());
            Data.ShiftTimeUpto = EmployeeShiftMaster.hours_am_pm($('#ShiftTimeUpto').val());
            Data.ShiftTimeMargin = $('#ShiftTimeMargin').val();
            Data.ShiftEndBuffer = $('#ShiftEndBuffer').val();
            Data.LunchTimeFrom = EmployeeShiftMaster.hours_am_pm($('#LunchTimeFrom').val());
            Data.LunchTimeUpto = EmployeeShiftMaster.hours_am_pm($('#LunchTimeUpto').val());
            Data.FirstHalfUpto = EmployeeShiftMaster.hours_am_pm($('#FirstHalfUpto').val());
            Data.SecondHalfFrom = EmployeeShiftMaster.hours_am_pm($('#SecondHalfFrom').val());
            Data.ConsiderLateMarkUpto = EmployeeShiftMaster.hours_am_pm($('#ConsiderLateMarkUpto').val());
        }
        if (EmployeeShiftMaster.ActionName == "EditEmployeeShiftMasterDetails") {
            Data.EmployeeShiftMasterDetailsID = $('input[name=EmployeeShiftMasterDetailsID]').val();
            Data.EmployeeShiftMasterID = $('input[name=EmployeeShiftMasterID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.GeneralWeekDaysID = $('#GeneralWeekDaysID').val();
            Data.WeeklyOffStatus = $('#WeeklyOffStatus').val();
            Data.WeeklyOffType = $('#EmployeeServiceDetails_WeeklyOffType').val();
            Data.ShiftTimeFrom = EmployeeShiftMaster.hours_am_pm($("#ShiftTimeFrom").val());
            Data.ShiftTimeUpto = EmployeeShiftMaster.hours_am_pm($('#ShiftTimeUpto').val());
            Data.ShiftTimeMargin = $('#ShiftTimeMargin').val();
            Data.ShiftEndBuffer = $('#ShiftEndBuffer').val();
            Data.LunchTimeFrom = EmployeeShiftMaster.hours_am_pm($('#LunchTimeFrom').val());
            Data.LunchTimeUpto = EmployeeShiftMaster.hours_am_pm($('#LunchTimeUpto').val());
            Data.FirstHalfUpto = EmployeeShiftMaster.hours_am_pm($('#FirstHalfUpto').val());
            Data.SecondHalfFrom = EmployeeShiftMaster.hours_am_pm($('#SecondHalfFrom').val());
            Data.ConsiderLateMarkUpto = EmployeeShiftMaster.hours_am_pm($('#ConsiderLateMarkUpto').val());
        }
        else if (EmployeeShiftMaster.ActionName == "Delete") {
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
            EmployeeShiftMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {

            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeShiftMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    //this is used to for showing successfully record creation message and reload the list view
    SuccessEmployeeShiftMasterDetails: function (data) {
        var splitData = data.split(',');

        if (data != null) {
            var ShiftMasterID = $('input[name=EmployeeShiftMasterID]').val();
            $.magnificPopup.close();
            $("#ShiftMasterID_" + ShiftMasterID).click();
            //   parent.$.colorbox.close();
            EmployeeShiftMaster.ReloadShiftMasterDetailsList(splitData[0], splitData[1], splitData[2]);
        } else {
            $.magnificPopup.close();
            // parent.$.colorbox.close();
            EmployeeShiftMaster.ReloadShiftMasterDetailsList(splitData[0], splitData[1], splitData[2]);
        }

    },

    hours_am_pm: function (time) {
        debugger;
        var time = (time).split(':');
        var hours = parseInt(time[0].trim());
        var minutes = parseInt(time[1].trim());
        var ampmstr=time[1].split(' ');
        //var AMPM = time[2].trim();
        var AMPM = ampmstr[1].trim();
        if (AMPM == "PM" && hours < 12 && hours != 00) hours = hours + 12;
        if (AMPM == "AM" && hours == 12 && hours != 00) hours = hours - 12;
        var sHours = hours.toString();
        var sMinutes = minutes.toString();
        if (hours < 10) sHours = "0" + sHours;
        if (minutes < 10) sMinutes = "0" + sMinutes;
        return (sHours + ":" + sMinutes + ":00");
    },


    
};

