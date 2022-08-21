////this class contain methods related to nationality functionality
//var LeaveSession = {
//    //Member variables
//    ActionName: null,
//    SelectedIDs: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        LeaveSession.constructor();
//        //LeaveSession.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        // $("#myDataTableSessionDetails tbody tr td").disabled(true);

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#DocumentDescription').focus();
//            $('#CountryName').focus();
//            return false;
//        });

//        $('#LeaveSessionFromDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//          //  yearRange: '1950:document.write(currentYear.getFullYear()',
//            maxDate: "+1D +1M + 1Y",
//            onClose: function (selectedDate) {
//                $("#LeaveSessionUptoDate").datepicker("option", "minDate", selectedDate);
//            }
//        })

//        $('#LeaveSessionUptoDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//         //   yearRange: '1950:document.write(currentYear.getFullYear()',
//            //maxDate: "+1Y",
//            onClose: function (selectedDate) {
//                $("#LeaveSessionFromDate").datepicker("option", "maxDate", selectedDate);
//            }
//        })

//        // Create new record
//        $('#CreateLeaveSessionRecord').on("click", function () {

//            LeaveSession.ActionName = "Create";
//            LeaveSession.AjaxCallLeaveSession();
//        });

//        $('#EditLeaveSessionRecord').on("click", function () {

//            LeaveSession.ActionName = "Edit";
//            LeaveSession.AjaxCallLeaveSession();
//        });

//        $('#CreateLeaveSessionDetailsRecord').on("click", function () {

//            LeaveSession.ActionName = "CreateLeaveSessionDetails";
//            LeaveSession.getValueUsingParentTag_Check_UnCheck();
//            LeaveSession.AjaxCallLeaveSession();
//        });

//        $('#EditLeaveSessionDetailsRecord').on("click", function () {

//            LeaveSession.ActionName = "EditLeaveSessionDetails";
//            LeaveSession.AjaxCallLeaveSession();
//        });

//        $('#DocumentName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
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
//            var SelectedCentreCode = $('#CentreList').val();
//            var SelectedCentreName = $('#CentreList :selected').text();

//            if (SelectedCentreCode != "") {
//                $.ajax(
//             {
//                 cache: false,
//                 type: "POST",
//                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

//                 dataType: "html",
//                 url: '/LeaveSession/List',
//                 success: function (result) {
//                     //Rebind Grid Data                
//                     $('#ListViewModel').html(result);

//                 }
//             });
//            }
//            else {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //LeaveSession.ReloadList("Please select centre", "#FFCC80", null);
//                //   $('#Createbutton').hide();
//            }
//        });

//        $('#EmployeeShiftDescription').on("keydown", function (e) {
//            AMSValidation.AllowAlphaNumericOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        })

//        $('#BackShiftDetails').on("keydown", function (e) {

//        })

//    },
//    ////Load method is used to load *-Load-* page
//    LoadList: function () {

//        $.ajax(
//         {
//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/LeaveSession/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//                 $('#CreateButton').show();
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {

//        var SelectedCentreCode = $('#CentreList').val();
//        var SelectedCentreName = $('#CentreList :selected').text();
//        parent.$.colorbox.close();
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
//            url: '/LeaveSession/List',
//            success: function (data) {
//                //Rebind Grid Data

//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },

//    //ReloadList method is used to load List page
//    ReloadShiftMasterDetailsList: function (message, colorCode, actionMode) {

//        var SelectedCentreCode = $('#CentreList').val();
//        var SelectedCentreName = $('#CentreList :selected').text();
//        parent.$.colorbox.close();
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
//            url: '/LeaveSession/List',
//            success: function (data) {
//                //Rebind Grid Data

//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },

//    //Fire ajax call to insert update and delete record
//    AjaxCallLeaveSession: function () {
//        var LeaveSessionData = null;
//        if (LeaveSession.ActionName == "Create") {
//            $("#FormCreateLeaveSession").validate();
//            if ($("#FormCreateLeaveSession").valid()) {
//                LeaveSessionData = null;
//                LeaveSessionData = LeaveSession.GetLeaveSession();
//                ajaxRequest.makeRequest("/LeaveSession/Create", "POST", LeaveSessionData, LeaveSession.Success);
//            }
//        }
//        else if (LeaveSession.ActionName == "Edit") {
//            $("#FormEditLeaveSession").validate();
//            if ($("#FormEditLeaveSession").valid()) {
//                LeaveSessionData = null;
//                LeaveSessionData = LeaveSession.GetLeaveSession();
//                ajaxRequest.makeRequest("/LeaveSession/Edit", "POST", LeaveSessionData, LeaveSession.Success);
//            }
//        }
//        else if (LeaveSession.ActionName == "CreateLeaveSessionDetails") {
//            LeaveSessionData = null;
//            //$("#FormCreateLeaveSession").validate();
//            LeaveSessionData = LeaveSession.GetLeaveSession();
//            ajaxRequest.makeRequest("/LeaveSession/CreateLeaveSessionDetails", "POST", LeaveSessionData, LeaveSession.SuccessLeaveSessionDetails);

//        }

//    },
//    //Get properties data from the Create, Update and Delete page
//    GetLeaveSession: function () {
//        var Data = {
//        };

//        if (LeaveSession.ActionName == "Create" || LeaveSession.ActionName == "Edit") {
//            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
//            Data.LeaveSessionName = $('#LeaveSessionName').val();
//            Data.CentreCode = $('input[name=CentreCode]').val();
//            Data.IsCurrentLeaveSession = $('input[name=IsCurrentLeaveSession]:checked').val() ? true : false;
//            Data.LeaveSessionFromDate = $('#LeaveSessionFromDate').val();
//            Data.LeaveSessionUptoDate = $('#LeaveSessionUptoDate').val();
//        }
//        if (LeaveSession.ActionName == "CreateLeaveSessionDetails") {
//            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
//            Data.CentreCode = $('input[name=CentreCode]').val();
//            Data.SelectedIDs = LeaveSession.SelectedIDs;
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');

//        if (data != null) {
//            parent.$.colorbox.close();
//            LeaveSession.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            LeaveSession.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    SuccessLeaveSessionDetails: function (data) {
//        var splitData = data.split(',');

//        if (data != null) {
//            parent.$.colorbox.close();
//            LeaveSession.ReloadShiftMasterDetailsList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            LeaveSession.ReloadShiftMasterDetailsList(splitData[0], splitData[1], splitData[2]);
//        }
//    },

//    getValueUsingParentTag_Check_UnCheck: function () {

//        var sList = "";
//        var xmlParamList = "<rows>"
//        $('#checkboxlist input[type=checkbox]').each(function () {
//            if ($(this).val() != "on") {
//                var sArray = [];
//                sArray = $(this).val().split("~");
//                if (this.checked == true && parseInt(sArray[3]) == 0) {
//                    //xmlInsert code here
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[3] + "</ID>" + "<JobProfileID>" + sArray[1] + "</JobProfileID>" + "<JobStatusCode>" + sArray[2] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "</row>";
//                }
//                else if (this.checked == false && parseInt(sArray[3]) > 0) {
//                    //xmlUpdate code here
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[3] + "</ID>" + "<JobProfileID>" + sArray[1] + "</JobProfileID>" + "<JobStatusCode>" + sArray[2] + "</JobStatusCode>" + "<IsActive>0</IsActive>" + "</row>";

//                }
//            }
//            if (xmlParamList.length > 6)
//                LeaveSession.SelectedIDs = xmlParamList + "</rows>";
//            else
//                LeaveSession.SelectedIDs = "0";
//        });

//    },
//    //  @sIDs= <rows><row><ID>0</ID><UniversityID>1</UniversityID><IsActive>1</IsActive></row></rows>
//};



///////////////////////new js/////////////////////////////

//this class contain methods related to nationality functionality
var LeaveSession = {
    //Member variables
    ActionName: null,
    SelectedIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveSession.constructor();
        //LeaveSession.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        // $("#myDataTableSessionDetails tbody tr td").disabled(true);

        $("#ResetLeaveSessionRecord").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LeaveSessionName').focus();
            $('#LeaveSessionName').val();
            $('#LeaveSessionFromDate').val();
            $('#LeaveSessionUptoDate').val();
            return false;
        });

        //$('#LeaveSessionFromDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    maxDate: "+1D +1M + 1Y",
        //    onClose: function (selectedDate) {
        //        $("#LeaveSessionUptoDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})

       
        $('#LeaveSessionFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#LeaveSessionUptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,


        });

        $("#LeaveSessionFromDate").on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate()-1);
            var months = ["January", "February", "March", "April", "May", "June",
               "July", "August", "September", "October", "November", "December"];
            var selectedMonthName = months[minDate.getMonth()];
            var selectedDate = minDate.getDate();
            var selectedYear = minDate.getFullYear() + 1;
            var conDate = selectedDate + ' ' + selectedMonthName + ' ' + selectedYear;
            var conDateConvert = new Date(conDate);
            $('#LeaveSessionUptoDate').data("DateTimePicker").minDate(conDateConvert);
            $('#LeaveSessionUptoDate').val(conDate);

            //$('#LeaveSessionUptoDate').val(minDate);

        });
        //$('#LeaveSessionUptoDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    //   yearRange: '1950:document.write(currentYear.getFullYear()',
        //    //maxDate: "+1Y",
        //    onClose: function (selectedDate) {
        //        $("#LeaveSessionFromDate").datepicker("option", "maxDate", selectedDate);
        //    }
        //})


        $("#LeaveSessionUptoDate").on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#LeaveSessionFromDate').data("DateTimePicker").maxDate(maxDate);
        });

        // Create new record
        $('#CreateLeaveSessionRecord').on("click", function () {

            LeaveSession.ActionName = "Create";
            LeaveSession.AjaxCallLeaveSession();
        });

        $('#EditLeaveSessionRecord').on("click", function () {
   
            LeaveSession.ActionName = "Edit";
            LeaveSession.AjaxCallLeaveSession();
        });

        $('#CreateLeaveSessionDetailsRecord').on("click", function () {

            LeaveSession.ActionName = "CreateLeaveSessionDetails";
            LeaveSession.getValueUsingParentTag_Check_UnCheck();
            LeaveSession.AjaxCallLeaveSession();
        });

        $('#EditLeaveSessionDetailsRecord').on("click", function () {

            LeaveSession.ActionName = "EditLeaveSessionDetails";
            LeaveSession.AjaxCallLeaveSession();
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




        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $("#CentreList").change(function () {

            if (!$("#CentreList").val()) {
                $("#CreateLeaveSession").hide();
            }

            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            
            
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
            

        });

        $("#ShowList").unbind("click").click(function () {
            if (!$("#CentreList").val()) {
                $("#CreateLeaveSession").hide();
            }

            var SelectedCentreCode = $('#CentreList').val();
            var SelectedCentreName = $('#CentreList :selected').text();

            if (SelectedCentreCode != "") {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

                 dataType: "html",
                 url: '/LeaveSession/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);

                     if ($("#CentreList").val()) {
                         $("#CreateLeaveSession").show();
                     } else {
                         $("#CreateLeaveSession").hide();
                     }

                 }
             });
            }
            else {
                notify("Please select centre", "warning");
            }
        });

        $('#EmployeeShiftDescription').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
            AMSValidation.NotAllowSpaces(e);
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
             url: '/LeaveSession/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
                 $('#CreateButton').show();
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        var SelectedCentreCode = $('#CentreList').val();
        var SelectedCentreName = $('#CentreList :selected').text();
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
            url: '/LeaveSession/List',
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

        var SelectedCentreCode = $('#CentreList').val();
        var SelectedCentreName = $('#CentreList :selected').text();
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
            url: '/LeaveSession/List',
            success: function (data) {
                //Rebind Grid Data

                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, 'success');
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallLeaveSession: function () {
        debugger;
        var LeaveSessionData = null;
        if (LeaveSession.ActionName == "Create") {
            $("#FormCreateLeaveSession").validate();
            if ($("#FormCreateLeaveSession").valid()) {
                LeaveSessionData = null;
                LeaveSessionData = LeaveSession.GetLeaveSession();
                ajaxRequest.makeRequest("/LeaveSession/Create", "POST", LeaveSessionData, LeaveSession.Success);
            }
        }
        else if (LeaveSession.ActionName == "Edit") {
            
            $("#FormEditLeaveSession").validate();
            if ($("#FormEditLeaveSession").valid()) {
                LeaveSessionData = null;
                LeaveSessionData = LeaveSession.GetLeaveSession();
                ajaxRequest.makeRequest("/LeaveSession/Edit", "POST", LeaveSessionData, LeaveSession.Success);
            }
        }
        else if (LeaveSession.ActionName == "CreateLeaveSessionDetails") {
            LeaveSessionData = null;
            //$("#FormCreateLeaveSession").validate();
            LeaveSessionData = LeaveSession.GetLeaveSession();
            ajaxRequest.makeRequest("/LeaveSession/CreateLeaveSessionDetails", "POST", LeaveSessionData, LeaveSession.SuccessLeaveSessionDetails);

        }

    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveSession: function () {
        debugger;
        var Data = {
        };

        if (LeaveSession.ActionName == "Create" || LeaveSession.ActionName == "Edit") {
           
            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
            Data.LeaveSessionName = $('#LeaveSessionName').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
           // Data.IsCurrentLeaveSession = $('input[name=IsCurrentLeaveSession]:checked').val() ? true : false;
            Data.IsCurrentLeaveSession = $('#IsCurrentLeaveSession').is(":checked") ? "true" : "false";

            Data.LeaveSessionFromDate = $('#LeaveSessionFromDate').val();
            Data.LeaveSessionUptoDate = $('#LeaveSessionUptoDate').val();
        }
        if (LeaveSession.ActionName == "CreateLeaveSessionDetails") {
            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.SelectedIDs = LeaveSession.SelectedIDs;
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.split(',');

        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveSession.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveSession.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    //this is used to for showing successfully record creation message and reload the list view
    SuccessLeaveSessionDetails: function (data) {
        var splitData = data.split(',');

        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveSession.ReloadShiftMasterDetailsList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveSession.ReloadShiftMasterDetailsList(splitData[0], splitData[1], splitData[2]);
        }
    },

    getValueUsingParentTag_Check_UnCheck: function () {

        var sList = "";
        var xmlParamList = "<rows>"
        $('#checkboxlist input[type=checkbox]').each(function () {
            if ($(this).val() != "on") {
                var sArray = [];
                sArray = $(this).val().split("~");
                if (this.checked == true && parseInt(sArray[3]) == 0) {
                    //xmlInsert code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[3] + "</ID>" + "<JobProfileID>" + sArray[1] + "</JobProfileID>" + "<JobStatusCode>" + sArray[2] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "</row>";
                }
                else if (this.checked == false && parseInt(sArray[3]) > 0) {
                    //xmlUpdate code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[3] + "</ID>" + "<JobProfileID>" + sArray[1] + "</JobProfileID>" + "<JobStatusCode>" + sArray[2] + "</JobStatusCode>" + "<IsActive>0</IsActive>" + "</row>";

                }
            }
            if (xmlParamList.length > 6)
                LeaveSession.SelectedIDs = xmlParamList + "</rows>";
            else
                LeaveSession.SelectedIDs = "0";
        });

    },
    //  @sIDs= <rows><row><ID>0</ID><UniversityID>1</UniversityID><IsActive>1</IsActive></row></rows>
};

