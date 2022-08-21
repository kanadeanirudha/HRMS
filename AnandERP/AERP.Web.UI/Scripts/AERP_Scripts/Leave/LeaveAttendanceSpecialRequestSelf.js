////this class contain methods related to nationality functionality
//var LeaveAttendanceSpecialRequestSelf = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        LeaveAttendanceSpecialRequestSelf.constructor();
//        //LeaveAttendanceSpecialRequestSelf.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#LeaveDescription').focus();
//            $('#LeaveType').val(" ");
//            return false;
//        });

//        $("#RequestedDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M yy',
//            minDate: '0',
//        });

//        $("#lateCommingDiv").hide();
//        $("#earlyGoingDiv").hide();

//        $('#CommingTime').timepicki();
//        $('#LeavingTime').timepicki();
//        $("#Late").on("change click", function () {
//            $("#lateCommingDiv").show();
//            $("#earlyGoingDiv").hide();
//            $("#CommingTime").prop("disabled", false);
//            $("#LeavingTime").val('00:00:00');
//            $("#CommingTime").val('');
//            $("#LeavingTime").prop("disabled", true);

//        });
//        $("#Early").on("change click", function () {
//            $("#lateCommingDiv").hide();
//            $("#earlyGoingDiv").show();
//            $("#CommingTime").prop("disabled", true);
//            $("#CommingTime").val('00:00:00');
//            $("#LeavingTime").val('');
//            $("#LeavingTime").prop("disabled", false);
//        });
//        $("#LeavingTime").on("keydown", function () {
//            return false;
//        });

//        $("#CommingTime").on("keydown", function () {
//            return false;
//        });

//        $("#ExemptionFromDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M yy',
//            minDate: '0',
//            onSelect: function (selected) {
//                $("#ExemptionUpToDate").datepicker("option", "minDate", selected)
//            }
//        });

//        if (parseInt($("#ID").val()) > 0) {
//            var date = $("#ExemptionFromDate").val();
//            $("#ExemptionUpToDate").datepicker({
//                numberOfMonths: 1,
//                dateFormat: 'd M yy',
//                minDate: date,
//            });
//        }
//        else {
//            $("#ExemptionUpToDate").datepicker({
//                numberOfMonths: 1,
//                dateFormat: 'd M yy',
//                minDate: '0',
//                onSelect: function (selected) {

//                    $("#ExemptionFromDate").datepicker("option", "maxDate", selected)

//                }
//            });
//        }


//        $("#ExemptionUpToDate_Clear").on("click", function () {
//            $("#ExemptionUpToDate").val('');
//        });
//        $("#centreDiv").text($("#CentreName").val());
//        if (parseInt($("#ID").val()) > 0) {
//            $("#EmployeeName").prop("disabled", true);
//            $("#ExemptionFromDate").prop("disabled", true);
//            $("#ExemptionUpToDate_Clear").hide();
//        }
//        else {
//            $("#EmployeeName").prop("disabled", false);
//            $("#ExemptionFromDate").prop("disabled", false);
//            $("#ExemptionUpToDate_Clear").show();
//        }

//        // Create new record
//        $('#CreateLeaveAttendanceSpecialRequestSelfRecord').on("click", function () {
//            if (parseInt($("#ID").val()) > 0) {

//                if ($("#ExemptionUpToDate").val() != '') {
//                    LeaveAttendanceSpecialRequestSelf.AjaxCallLeaveAttendanceSpecialRequestSelf();
//                }
//                else {
//                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_ExemptionUptoDate", "localFormMessage", "#FFCC80");
//                    //$('#localFormMessage').html("Please select Exemption Upto Date");
//                    //$('#localFormMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
//                }
//            }
//            else {
//                LeaveAttendanceSpecialRequestSelf.AjaxCallLeaveAttendanceSpecialRequestSelf();
//            }

//        });


//        //FOLLOWING FUNCTION IS SEARCHLIST OF item list
//        $("#EmployeeName").autocomplete({

//            source: function (request, response) {
//                $.ajax({
//                    url: "/LeaveAttendanceSpecialRequestSelf/GetEmployeeCentrewise",
//                    type: "POST",
//                    dataType: "json",
//                    data: { term: request.term, centreCode: $("#CentreCode").val() },
//                    success: function (data) {
//                        response($.map(data, function (item) {
//                            return { label: item.name, value: item.name, id: item.id };
//                        }))
//                    }
//                })
//            },
//            select: function (event, ui) {
//                $(this).val(ui.item.label);                                             // display the selected text
//                $("#EmployeeId").val(ui.item.id);
//            }
//        });

//        $('#LeaveDescription').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#Reason').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
        

//        $('#LeaveCode').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();

//        $("#CentreList").change(function () {
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//            //$('#myDataTable_thead').attr('readonly', 'readonly');
//            //      $('#myDataTable_thead').attr("disabled", "disabled");
//        });

//        $("#ShowList").click(function () {
           
//            var SelectedCentreCode = $('#CentreCode').val();
//            var SelectedCentreName = $('#CentreCode :selected').text();

//            if (SelectedCentreCode != "") {
//                $.ajax(
//             {
//                 cache: false,
//                 type: "POST",
//                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

//                 dataType: "html",
//                 url: '/LeaveAttendanceSpecialRequestSelf/List',
//                 success: function (result) {
//                     //Rebind Grid Data                
//                     $('#ListViewModel').html(result);
//                     $("#createDiv").show();
//                 }
//             });
//            }
//            else {
//                //LeaveAttendanceSpecialRequestSelf.ReloadList("Please select centre", "#FFCC80", null);
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
//            }
//        });

//        $('#LeaveRuleDescription').on("keydown", function (e) {
//            // AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#NumberOfLeaves').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#MaxLeaveAtTime').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#MinLeavesAtTime').on("keydown", function (e) {
//            AMSValidation.AllowNumbersWithDecimalOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#MaxLeaveEncash').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#MinimumLeaveEncash').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#MinServiceRequiredInMonth').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#AttendDaysRequired').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#MaxLeaveAccumulated').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//    },
//    ////Load method is used to load *-Load-* page
//    LoadList: function () {
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/LeaveAttendanceSpecialSelf/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
//        var SelectedCentreCode = $('#CentreCode').val();
//        var SelectedCentreName = $('#CentreCode :selected').text();

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { actionMode: actionMode, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
//            url: '/LeaveAttendanceSpecialSelf/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                $("#createDiv").show();
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallLeaveAttendanceSpecialRequestSelf: function () {
//        if ($("#FormCreateLeaveAttendanceSpecialRequestSelf").valid()) {
//            var LeaveAttendanceSpecialRequestSelfData = null;
//            LeaveAttendanceSpecialRequestSelfData = null;
//            LeaveAttendanceSpecialRequestSelfData = LeaveAttendanceSpecialRequestSelf.GetLeaveAttendanceSpecialRequestSelf();
//            ajaxRequest.makeRequest("/LeaveAttendanceSpecialSelf/Create", "POST", LeaveAttendanceSpecialRequestSelfData, LeaveAttendanceSpecialRequestSelf.Success);
//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetLeaveAttendanceSpecialRequestSelf: function () {
//        var Data = {
//        };
//        //$('input[name=radioName]:checked', '#myForm').val();
//        Data.StatusFlag = $('input[name=StatusFlag]:checked').val();
//        // Data.StatusFlag = $('input[name=StatusFlag]').val();
//        Data.RequestedDate = $('#RequestedDate').val();
//        Data.CentreCode = $('#CentreCode :selected').val();
//        Data.CommingTime = LeaveAttendanceSpecialRequestSelf.hours_am_pm($('#CommingTime').val());
//        Data.LeavingTime = LeaveAttendanceSpecialRequestSelf.hours_am_pm($('#LeavingTime').val());
//        Data.Reason = $('#Reason').val();
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        parent.$.colorbox.close();
//        LeaveAttendanceSpecialRequestSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
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

//////////////////////////new js/////////////////////////////////////////////


//this class contain methods related to nationality functionality
var LeaveAttendanceSpecialRequestSelf = {
    //Member variables
    ActionName: null,
    map: {},
    map2: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveAttendanceSpecialRequestSelf.constructor();
        //LeaveAttendanceSpecialRequestSelf.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LeaveDescription').focus();
            $('#LeaveType').val(" ");
            return false;
        });

        //$("#RequestedDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    minDate: '0',
        //});

        $('#RequestedDate').attr("readonly", true);

        $('#RequestedDate').datetimepicker({
            format: 'DD MMMM YYYY',
            minDate: moment(),
            ignoreReadonly: true,

        });

        //.on("selected", function () {
        //    alert();
        //})


        

        $("#lateCommingDiv").show();
        $("#earlyGoingDiv").hide();

        //$('#CommingTime').timepicki();
        //$('#LeavingTime').timepicki();
        
        $('#CommingTime').datetimepicker({
            //format: 'hh:mm:ss',
            format: 'LT',
            ignoreReadonly: true,
            
        });

        $('#LeavingTime').datetimepicker({
            //format: 'hh:mm:ss',
            format: 'LT',
            ignoreReadonly: true,
            
        });
        


        $("#Late").on("change click", function () {
            
            $("#lateCommingDiv").show();
            $("#earlyGoingDiv").hide();
            $("#CommingTime").prop("disabled", false);
            $("#LeavingTime").val('00:00:00');
            $("#CommingTime").val('');
            $("#LeavingTime").prop("disabled", true);

        });
        $("#Early").on("change click", function () {
            $("#lateCommingDiv").hide();
            $("#earlyGoingDiv").show();
            $("#CommingTime").prop("disabled", true);
            $("#CommingTime").val('00:00:00');
            $("#LeavingTime").val('');
            $("#LeavingTime").prop("disabled", false);
        });
        $("#LeavingTime").on("keydown", function () {
            return false;
        });

        $("#CommingTime").on("keydown", function () {
            return false;
        });

        //$("#ExemptionFromDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    minDate: '0',
        //    onSelect: function (selected) {
        //        $("#ExemptionUpToDate").datepicker("option", "minDate", selected)
        //    }
        //});

        //$('#ExemptionFromDate').attr("readonly", true);

        $('#ExemptionFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
            ignoreReadonly: true,
        });
        $('#ExemptionFromDate').on("dp.change", function (e) {
            //$("#ExemptionUpToDate").datetimepicker("option", "minDate", selected);
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#ExemptionUpToDate').data("DateTimePicker").minDate(minDate);

        });


        if (parseInt($("#ID").val()) > 0) {
            var date = $("#ExemptionFromDate").val();

            //$("#ExemptionUpToDate").datepicker({
            //    numberOfMonths: 1,
            //    dateFormat: 'd M yy',
            //    minDate: date,
            //});

            $('#ExemptionUpToDate').datetimepicker({
                format: 'DD MMMM YYYY',
                minDate: moment(),
                ignoreReadonly: true,

            });

        }
        else {
            //$("#ExemptionUpToDate").datepicker({
            //    numberOfMonths: 1,
            //    dateFormat: 'd M yy',
            //    minDate: '0',
            //    onSelect: function (selected) {

            //        $("#ExemptionFromDate").datepicker("option", "maxDate", selected)

            //    }
            //});

            $('#ExemptionUpToDate').datetimepicker({
                format: 'DD MMMM YYYY',
                minDate: moment(),
                ignoreReadonly: true,
            });
            $('#ExemptionUpToDate').on("dp.change", function (e) {

                //$("#ExemptionFromDate").datetimepicker("option", "maxDate", selected);
                var maxDate = new Date(e.date.valueOf());
                maxDate.setDate(maxDate.getDate());
                $('#ExemptionFromDate').data("DateTimePicker").maxDate(maxDate);
            });

        }


        $("#ExemptionUpToDate_Clear").on("click", function () {
            $("#ExemptionUpToDate").val('');
        });
        $("#centreDiv").text($("#CentreName").val());
        if (parseInt($("#ID").val()) > 0) {
            $("#EmployeeName").prop("disabled", true);
            $("#ExemptionFromDate").prop("disabled", true);
            $("#ExemptionUpToDate_Clear").hide();
        }
        else {
            $("#EmployeeName").prop("disabled", false);
            $("#ExemptionFromDate").prop("disabled", false);
            $("#ExemptionUpToDate_Clear").show();
        }

        // Create new record
        $('#CreateLeaveAttendanceSpecialRequestSelfRecord').on("click", function () {
            debugger;
            if (parseInt($("#ID").val()) > 0) {

                if ($("#ExemptionUpToDate").val() != '') {
                    LeaveAttendanceSpecialRequestSelf.AjaxCallLeaveAttendanceSpecialRequestSelf();
                }
                else {
                    //ajaxRequest.ErrorMessageForJS("JsValidationMessages_ExemptionUptoDate", "localFormMessage", "#FFCC80");
                    notify("Please select Exemption Upto Date","danger");
                    //$('#localFormMessage').html("Please select Exemption Upto Date");
                    //$('#localFormMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                }
            }
            else {
                LeaveAttendanceSpecialRequestSelf.AjaxCallLeaveAttendanceSpecialRequestSelf();
            }

        });


        //FOLLOWING FUNCTION IS SEARCHLIST OF item list
        //$("#EmployeeName").autocomplete({

        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/LeaveAttendanceSpecialRequestSelf/GetEmployeeCentrewise",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, centreCode: $("#CentreCode").val() },
        //            success: function (data) {
        //                response($.map(data, function (item) {
        //                    return { label: item.name, value: item.name, id: item.id };
        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {
        //        $(this).val(ui.item.label);                                             // display the selected text
        //        $("#EmployeeId").val(ui.item.id);
        //    }
        //});
        /////////////new search functionality///////////////////////////////////
        var getData = function () {
            return function findMatches(q, cb) {
                var matches, substringRegex;
                // an array that will be populated with substring matches
                matches = [];
                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var centerCodeID = $("#CentreCode").val();

                $.ajax({
                    url: "/LeaveAttendanceSpecialRequestSelf/GetEmployeeCentrewise",
                    type: "POST",
                    data: { term: q, StorageLocationID: centerCodeID },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.EmployeeFirstName)) {
                                LeaveAttendanceSpecialRequestSelf.map[response.EmployeeFirstName] = response;
                                matches.push(response.EmployeeFirstName);

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#EmployeeName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            $("#EmployeeId").val(LeaveAttendanceSpecialRequestSelf.map[item].id);
        });
        //end new search functionality

        $('#LeaveDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#Reason').on("keydown", function (e) {
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

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $("#CentreList").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            //$('#myDataTable_thead').attr('readonly', 'readonly');
            //      $('#myDataTable_thead').attr("disabled", "disabled");
        });

        $("#ShowList").click(function () {

            var SelectedCentreCode = $('#CentreCode').val();
            var SelectedCentreName = $('#CentreCode :selected').text();

            if (SelectedCentreCode != "") {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

                 dataType: "html",
                 url: '/LeaveAttendanceSpecialRequestSelf/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                     $("#createDiv").show();
                 }
             });
            }
            else {
                //LeaveAttendanceSpecialRequestSelf.ReloadList("Please select centre", "#FFCC80", null);
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                notify('Please select centre','success');
            }
        });

        $('#LeaveRuleDescription').on("keydown", function (e) {
            // AMSValidation.AllowCharacterOnly(e);
        });

        $('#NumberOfLeaves').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MaxLeaveAtTime').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MinLeavesAtTime').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MaxLeaveEncash').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MinimumLeaveEncash').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MinServiceRequiredInMonth').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#AttendDaysRequired').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MaxLeaveAccumulated').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/LeaveAttendanceSpecialSelf/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var SelectedCentreCode = $('#CentreCode').val();
        var SelectedCentreName = $('#CentreCode :selected').text();

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
            url: '/LeaveAttendanceSpecialSelf/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                $("#createDiv").show();
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,'success');
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallLeaveAttendanceSpecialRequestSelf: function () {
        if ($("#FormCreateLeaveAttendanceSpecialRequestSelf").valid()) {
            var LeaveAttendanceSpecialRequestSelfData = null;
            LeaveAttendanceSpecialRequestSelfData = null;
            LeaveAttendanceSpecialRequestSelfData = LeaveAttendanceSpecialRequestSelf.GetLeaveAttendanceSpecialRequestSelf();
            ajaxRequest.makeRequest("/LeaveAttendanceSpecialSelf/Create", "POST", LeaveAttendanceSpecialRequestSelfData, LeaveAttendanceSpecialRequestSelf.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveAttendanceSpecialRequestSelf: function () {
        debugger;
        var Data = {
        };
        //$('input[name=radioName]:checked', '#myForm').val();
        Data.StatusFlag = $('input[name=StatusFlag]:checked').val();
        // Data.StatusFlag = $('input[name=StatusFlag]').val();
        Data.RequestedDate = $('#RequestedDate').val();
        Data.CentreCode = $('#CentreCode :selected').val();
        Data.CommingTime = LeaveAttendanceSpecialRequestSelf.hours_am_pm($('#CommingTime').val());
        Data.LeavingTime = LeaveAttendanceSpecialRequestSelf.hours_am_pm($('#LeavingTime').val());
        Data.Reason = $('#Reason').val();
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        LeaveAttendanceSpecialRequestSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
    hours_am_pm: function (time) {
        
        var time = (time).split(':');
        if (time[0].trim() == '00' && time[1].trim() == '00') {
            var sHours = "00";
            var sMinutes = "00";
        } else {
            var hours = parseInt(time[0].trim());
            var minutes = parseInt(time[1].trim());
            var spsplit = time[1].split(' ');
            var AMPM = spsplit[1].trim();
            //var AMPM = time[2].trim();
            if (AMPM == "PM" && hours < 12 && hours != 00) hours = hours + 12;
            if (AMPM == "AM" && hours == 12 && hours != 00) hours = hours - 12;
            var sHours = hours.toString();
            var sMinutes = minutes.toString();
            if (hours < 10) sHours = "0" + sHours;
            if (minutes < 10) sMinutes = "0" + sMinutes;
        }
        
        return (sHours + ":" + sMinutes + ":00");
    },


};

