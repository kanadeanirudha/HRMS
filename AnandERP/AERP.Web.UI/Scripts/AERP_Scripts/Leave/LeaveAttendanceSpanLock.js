////this class contain methods related to nationality functionality
//var LeaveAttendanceSpanLock = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        LeaveAttendanceSpanLock.constructor();
//        //LeaveAttendanceSpanLock.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        //$("#reset").click(function () {

//        //    $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

//        //    return false;
//        //});

//        if ($("#SpanFromDate").val() != "" && $("#SpanFromDate").val() != null) {

//            $("#SpanFromDate").attr("disabled", true);
//        }
//        else {
//            $("#SpanFromDate").attr("disabled", false);
//        }
//        $("#SpanFromDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'dd/mm/yy',
//            //onSelect: function (selected) {
//            //    $("#SpanUptoDate").datepicker("option", "minDate", selected)
//            //}
//        });
//        $("#SpanUptoDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'dd/mm/yy',
//            onSelect: function (selected) {

//                var SpanFromDateArray = $("#SpanFromDate").val().split('/');
//                var SpanFromDate = new Date(SpanFromDateArray[2], SpanFromDateArray[1] - 1, SpanFromDateArray[0]); //Year, Month, Date

//                var SpanUptoDateArray = selected.split('/');
//                var SpanUptoDate = new Date(SpanUptoDateArray[2], SpanUptoDateArray[1] - 1, SpanUptoDateArray[0]); //Year, Month, Date

//                if (SpanFromDate >= SpanUptoDate) {
                   
//                    ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_UptoGreaterThanFromDate");
//                    //  alert("Please enter upto date is greather than from date.");
//                    $("#SpanUptoDate").val("")
//                }
//            }
//        });

//        // Create new record
//        $('#CreateLeaveAttendanceSpanLockRecord').on("click", function () {

//            LeaveAttendanceSpanLock.ActionName = "Create";
//            LeaveAttendanceSpanLock.AjaxCallLeaveAttendanceSpanLock();

//        });

//        $('#EditLeaveAttendanceSpanLockRecord').on("click", function () {
           
//            LeaveAttendanceSpanLock.ActionName = "Edit";
//            LeaveAttendanceSpanLock.AjaxCallLeaveAttendanceSpanLock();
//        });

//        $('#DeleteLeaveAttendanceSpanLockRecord').on("click", function () {

//            LeaveAttendanceSpanLock.ActionName = "Delete";
//            LeaveAttendanceSpanLock.AjaxCallLeaveAttendanceSpanLock();
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

//        $("#CentreCode").change(function () {
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//            $('#Createbutton').hide();
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
//                 url: '/LeaveAttendanceSpanLock/List',
//                 success: function (result) {
//                     //Rebind Grid Data                
//                     $('#ListViewModel').html(result);
//                     $('#Createbutton').show();

//                 }
//             });
//            }
//            else {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                // LeaveAttendanceSpanLock.ReloadList("Please select centre", "#FFCC80", null);
//                //   $('#Createbutton').hide();
//                $('#Createbutton').hide();
//            }
//        });


//    },
//    ////Load method is used to load *-Load-* page
//    LoadList: function () {
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/LeaveAttendanceSpanLock/List',
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
//            data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
//            url: '/LeaveAttendanceSpanLock/List',
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
//    AjaxCallLeaveAttendanceSpanLock: function () {
//        var LeaveAttendanceSpanLockData = null;
//        if (LeaveAttendanceSpanLock.ActionName == "Create") {
//            $("#FormCreateLeaveAttendanceSpanLock").validate();
//            if ($("#FormCreateLeaveAttendanceSpanLock").valid()) {
//                LeaveAttendanceSpanLockData = null;
//                LeaveAttendanceSpanLockData = LeaveAttendanceSpanLock.GetLeaveAttendanceSpanLock();
//                ajaxRequest.makeRequest("/LeaveAttendanceSpanLock/Create", "POST", LeaveAttendanceSpanLockData, LeaveAttendanceSpanLock.Success);
//            }
//        }
//        else if (LeaveAttendanceSpanLock.ActionName == "Edit") {
//            $("#FormEditLeaveAttendanceSpanLock").validate();
//            if ($("#FormEditLeaveAttendanceSpanLock").valid()) {
//                LeaveAttendanceSpanLockData = null;
//                LeaveAttendanceSpanLockData = LeaveAttendanceSpanLock.GetLeaveAttendanceSpanLock();
//                ajaxRequest.makeRequest("/LeaveAttendanceSpanLock/Edit", "POST", LeaveAttendanceSpanLockData, LeaveAttendanceSpanLock.Success);
//            }
//        }
//        else if (LeaveAttendanceSpanLock.ActionName == "Delete") {
//            LeaveAttendanceSpanLockData = null;
//            //$("#FormCreateLeaveAttendanceSpanLock").validate();
//            LeaveAttendanceSpanLockData = LeaveAttendanceSpanLock.GetLeaveAttendanceSpanLock();
//            ajaxRequest.makeRequest("/LeaveAttendanceSpanLock/Delete", "POST", LeaveAttendanceSpanLockData, LeaveAttendanceSpanLock.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetLeaveAttendanceSpanLock: function () {
//        var Data = {
//        };
//        if (LeaveAttendanceSpanLock.ActionName == "Create" || LeaveAttendanceSpanLock.ActionName == "Edit") {
//            Data.ID = $('input[name=ID]').val();
//            Data.SpanFromDate = $('input[name=SpanFromDate]').val();
//            Data.SpanUptoDate = $('#SpanUptoDate').val();
//            Data.CentreCode = $('input[name=CentreCode]').val();
//        }
//        else if (LeaveAttendanceSpanLock.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            LeaveAttendanceSpanLock.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            LeaveAttendanceSpanLock.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },

//};

//////////////////////new js////////////////////////////

//this class contain methods related to nationality functionality
var LeaveAttendanceSpanLock = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveAttendanceSpanLock.constructor();
        //LeaveAttendanceSpanLock.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        //$("#reset").click(function () {

        //    $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

        //    return false;
        //});

        if ($("#SpanFromDate").val() != "" && $("#SpanFromDate").val() != null) {

            $("#SpanFromDate").attr("disabled", true);
        }
        else {
            $("#SpanFromDate").attr("disabled", false);
        }
        //$("#SpanFromDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'dd/mm/yy',
            
        //});

        //$("#SpanUptoDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'dd/mm/yy',
        //    onSelect: function (selected) {

        //        var SpanFromDateArray = $("#SpanFromDate").val().split('/');
        //        var SpanFromDate = new Date(SpanFromDateArray[2], SpanFromDateArray[1] - 1, SpanFromDateArray[0]); //Year, Month, Date

        //        var SpanUptoDateArray = selected.split('/');
        //        var SpanUptoDate = new Date(SpanUptoDateArray[2], SpanUptoDateArray[1] - 1, SpanUptoDateArray[0]); //Year, Month, Date

        //        if (SpanFromDate >= SpanUptoDate) {

        //            ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_UptoGreaterThanFromDate");
        //              alert("Please enter upto date is greather than from date.");
        //            $("#SpanUptoDate").val("")
        //        }
        //    }
        //});


        $(function () {

            $('#SpanFromDate').datetimepicker({
                format: 'DD MMM YYYY',
                ignoreReadonly: true,
                
            });

            $('#SpanUptoDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,

            });

            $('#SpanUptoDate').on('dp.change', function (e) {

                
                var fromDate = new Date($("#SpanFromDate").val());
                fromDate.setDate(fromDate.getDate());

                var uptoDate = new Date(e.date.valueOf());
                uptoDate.setDate(uptoDate.getDate());
                
                
                //var SpanFromDateArray = $("#SpanFromDate").val().split('/');
                //var SpanFromDate = new Date(SpanFromDateArray[2], SpanFromDateArray[1] - 1, SpanFromDateArray[0]); //Year, Month, Date
                //var SpanUptoDateArray = selected.split('/');
                //var SpanUptoDate = new Date(SpanUptoDateArray[2], SpanUptoDateArray[1] - 1, SpanUptoDateArray[0]); //Year, Month, Date

                //if (SpanFromDate >= SpanUptoDate) {

                //    ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_UptoGreaterThanFromDate");
                //    //  alert("Please enter upto date is greather than from date.");
                //    $("#SpanUptoDate").val("")
                //}
                
                if (fromDate >= uptoDate) {
                    ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_UptoGreaterThanFromDate");
                    $("#SpanUptoDate").val("")
                }
                

            });


        });


        // Create new record
        $('#CreateLeaveAttendanceSpanLockRecord').on("click", function () {
            debugger;
            LeaveAttendanceSpanLock.ActionName = "Create";
            LeaveAttendanceSpanLock.AjaxCallLeaveAttendanceSpanLock();

        });

        $('#EditLeaveAttendanceSpanLockRecord').on("click", function () {

            LeaveAttendanceSpanLock.ActionName = "Edit";
            LeaveAttendanceSpanLock.AjaxCallLeaveAttendanceSpanLock();
        });

        $('#DeleteLeaveAttendanceSpanLockRecord').on("click", function () {

            LeaveAttendanceSpanLock.ActionName = "Delete";
            LeaveAttendanceSpanLock.AjaxCallLeaveAttendanceSpanLock();
        });


        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").DataTable();
        //    oTable.fnFilter(this.value);
        //});

        //$("#searchBtn").click(function () {
        //    $("#UserSearch").focus();
        //});


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();


        $("#CentreCode").change(function () {
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('#Createbutton').hide();
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
                 url: '/LeaveAttendanceSpanLock/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                     $('#Createbutton').show();

                 }
             });
            }
            else {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                // LeaveAttendanceSpanLock.ReloadList("Please select centre", "#FFCC80", null);
                //   $('#Createbutton').hide();
                $('#Createbutton').hide();
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
             url: '/LeaveAttendanceSpanLock/List',
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
            data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
            url: '/LeaveAttendanceSpanLock/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallLeaveAttendanceSpanLock: function () {
        var LeaveAttendanceSpanLockData = null;
        if (LeaveAttendanceSpanLock.ActionName == "Create") {
            $("#FormCreateLeaveAttendanceSpanLock").validate();
            if ($("#FormCreateLeaveAttendanceSpanLock").valid()) {
                LeaveAttendanceSpanLockData = null;
                LeaveAttendanceSpanLockData = LeaveAttendanceSpanLock.GetLeaveAttendanceSpanLock();
                ajaxRequest.makeRequest("/LeaveAttendanceSpanLock/Create", "POST", LeaveAttendanceSpanLockData, LeaveAttendanceSpanLock.Success);
            }
        }
        else if (LeaveAttendanceSpanLock.ActionName == "Edit") {
            $("#FormEditLeaveAttendanceSpanLock").validate();
            if ($("#FormEditLeaveAttendanceSpanLock").valid()) {
                LeaveAttendanceSpanLockData = null;
                LeaveAttendanceSpanLockData = LeaveAttendanceSpanLock.GetLeaveAttendanceSpanLock();
                ajaxRequest.makeRequest("/LeaveAttendanceSpanLock/Edit", "POST", LeaveAttendanceSpanLockData, LeaveAttendanceSpanLock.Success);
            }
        }
        else if (LeaveAttendanceSpanLock.ActionName == "Delete") {
            LeaveAttendanceSpanLockData = null;
            //$("#FormCreateLeaveAttendanceSpanLock").validate();
            LeaveAttendanceSpanLockData = LeaveAttendanceSpanLock.GetLeaveAttendanceSpanLock();
            ajaxRequest.makeRequest("/LeaveAttendanceSpanLock/Delete", "POST", LeaveAttendanceSpanLockData, LeaveAttendanceSpanLock.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveAttendanceSpanLock: function () {
        var Data = {
        };
        if (LeaveAttendanceSpanLock.ActionName == "Create" || LeaveAttendanceSpanLock.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.SpanFromDate = $('input[name=SpanFromDate]').val();
            Data.SpanUptoDate = $('#SpanUptoDate').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
        }
        else if (LeaveAttendanceSpanLock.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveAttendanceSpanLock.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveAttendanceSpanLock.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

