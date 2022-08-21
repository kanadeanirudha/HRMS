////this class contain methods related to nationality functionality
//var LeaveRuleMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        LeaveRuleMaster.constructor();
//        //LeaveRuleMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {     

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#LeaveRuleDescription').focus();
//            $('#NumberOfLeaves').val('');
//            $('#MaxLeaveAtTime').val("0");
//            $('#MinLeavesAtTime').val("0");
//            $('#MaxLeaveEncash').val("0");
//            $('#MinimumLeaveEncash').val("0");
//            $('#MinServiceRequiredInMonth').val("0");
//            $('#AttendDaysRequired').val("0");
//            $('#MaxLeaveAccumulated').val("0");
//            return false;
//        });


//        // Create new record
//        $('#CreateLeaveRuleMasterRecord').on("click", function () {
//            LeaveRuleMaster.ActionName = "Create";

//            if ($("#MaxLeaveAtTime").val() == "" || $("#MaxLeaveAtTime").val() > 0) {
//                notify("Please Enter Max Leave At Time.", "danger");
//                return false;
//            }
//            LeaveRuleMaster.AjaxCallLeaveRuleMaster();
//        });

//        $('#EditLeaveRuleMasterRecord').on("click", function () {
            
//            LeaveRuleMaster.ActionName = "Edit";
//            LeaveRuleMaster.AjaxCallLeaveRuleMaster();
//        });

//        $('#DeleteLeaveRuleMasterRecord').on("click", function () {

//            LeaveRuleMaster.ActionName = "Delete";
//            LeaveRuleMaster.AjaxCallLeaveRuleMaster();
//        });

//        $('#LeaveDescription').on("keydown", function (e) {
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
//                 url: '/LeaveRuleMaster/List',
//                 success: function (result) {
//                     //Rebind Grid Data                
//                     $('#ListViewModel').html(result);

//                 }
//             });
//            }
//            else {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//               // LeaveSession.ReloadList("Please select centre", "#FFCC80", null);
//                //   $('#Createbutton').hide();
//            }
//        });

//        $('#LeaveRuleDescription').on("keydown", function (e) {
//           // AMSValidation.AllowCharacterOnly(e);
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
//        $('#DaysBeforeApplicationSubmitted').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });
//        $('#LeaveApplicationSubmittedUptoDays').on("keydown", function (e) {
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
//             url: '/LeaveRuleMaster/List',
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
//            url: '/LeaveRuleMaster/List',
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
//    AjaxCallLeaveRuleMaster: function () {
//        var LeaveRuleMasterData = null;
//        if (LeaveRuleMaster.ActionName == "Create") {
//            $("#FormCreateLeaveRuleMaster").validate();
//            if ($("#FormCreateLeaveRuleMaster").valid()) {
//                LeaveRuleMasterData = null;
//                LeaveRuleMasterData = LeaveRuleMaster.GetLeaveRuleMaster();
//                ajaxRequest.makeRequest("/LeaveRuleMaster/Create", "POST", LeaveRuleMasterData, LeaveRuleMaster.Success);
//            }
//        }
//        else if (LeaveRuleMaster.ActionName == "Edit") {
//            $("#FormEditLeaveRuleMaster").validate();
//            if ($("#FormEditLeaveRuleMaster").valid()) {
//                LeaveRuleMasterData = null;
//                LeaveRuleMasterData = LeaveRuleMaster.GetLeaveRuleMaster();
//                ajaxRequest.makeRequest("/LeaveRuleMaster/Edit", "POST", LeaveRuleMasterData, LeaveRuleMaster.Success);
//            }
//        }
//        else if (LeaveRuleMaster.ActionName == "Delete") {
//            LeaveRuleMasterData = null;
//            //$("#FormCreateLeaveRuleMaster").validate();
//            LeaveRuleMasterData = LeaveRuleMaster.GetLeaveRuleMaster();
//            ajaxRequest.makeRequest("/LeaveRuleMaster/Delete", "POST", LeaveRuleMasterData, LeaveRuleMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetLeaveRuleMaster: function () {
//        var Data = {
//        };
//        if (LeaveRuleMaster.ActionName == "Create") {
//            Data.ID = $('input[name=ID]').val();
//            Data.LeaveMasterID = $('input[name=LeaveMasterID]').val();
//            Data.CentreCode = $('input[name=CentreCode]').val();
//            Data.LeaveRuleDescription = $('#LeaveRuleDescription').val();
//            Data.NumberOfLeaves = $('#NumberOfLeaves').val();
//            Data.MaxLeaveAtTime = $('#MaxLeaveAtTime').val();
//            Data.MinimumLeaveEncash = $("#MinimumLeaveEncash").val();
//            Data.MaxLeaveEncash = $("#MaxLeaveEncash").val();
//            Data.MaxLeaveAccumulated = $("#MaxLeaveAccumulated").val();
//            Data.MinServiceRequiredInMonth = $("#MinServiceRequiredInMonth").val();            
//            Data.AttendDaysRequired = $("#AttendDaysRequired").val();
//            Data.MinLeavesAtTime = $("#MinLeavesAtTime").val();
//            Data.DaysBeforeApplicationSubmitted = $("#DaysBeforeApplicationSubmitted").val(); 
//            Data.LeaveApplicationSubmittedUptoDays = $("#LeaveApplicationSubmittedUptoDays").val();
//            //Data.DayOfTheMonth = $("#DayOfTheMonth").val();
           
//        }
//        else if (LeaveRuleMaster.ActionName == "Edit") {
//            Data.ID = $('input[name=ID]').val();
//            Data.LeaveMasterID = $('input[name=LeaveMasterID]').val();
//            Data.CentreCode = $('input[name=CentreCode]').val();
//            Data.LeaveRuleDescription = $('#LeaveRuleDescription').val();
//            Data.NumberOfLeaves = $('#NumberOfLeaves').val();
//            Data.MaxLeaveAtTime = $('#MaxLeaveAtTime').val();
//            Data.MinimumLeaveEncash = $("#MinimumLeaveEncash").val();
//            Data.MaxLeaveEncash = $("#MaxLeaveEncash").val();
//            Data.MaxLeaveAccumulated = $("#MaxLeaveAccumulated").val();
//            Data.MinServiceRequiredInMonth = $("#MinServiceRequiredInMonth").val();
//            Data.AttendDaysRequired = $("#AttendDaysRequired").val();
//            Data.MinLeavesAtTime = $("#MinLeavesAtTime").val();
//            Data.DaysBeforeApplicationSubmitted = $("#DaysBeforeApplicationSubmitted").val();
//            Data.LeaveApplicationSubmittedUptoDays = $("#LeaveApplicationSubmittedUptoDays").val();
//            Data.IsActive = $('#IsActive:checked').val() ? true : false;
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            LeaveRuleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            LeaveRuleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {



//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        LeaveRuleMaster.ReloadList("Record Updated Sucessfully.", actionMode);
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {


//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        LeaveRuleMaster.ReloadList("Record Deleted Sucessfully.");
//    //      //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

//////////new////////////////////////////////////////////////////////////////////////////////////////

//this class contain methods related to nationality functionality
var LeaveRuleMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveRuleMaster.constructor();
        //LeaveRuleMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function ()
        {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LeaveRuleDescription').focus();
            $('#NumberOfLeaves').val("0");
            $('#MaxLeaveAtTime').val("0");
            $('#MinLeavesAtTime').val("0");
            $('#MaxLeaveEncash').val("0");
            $('#MinimumLeaveEncash').val("0");
            $('#MinServiceRequiredInMonth').val("0");
            $('#AttendDaysRequired').val("0");
            $('#MaxLeaveAccumulated').val("0");
            $('#AccumulationMethod').val("--Select--");
            return false;
        });

        $("#IsLeaveAccumulatePeriodically").on("click", function ()
        {
            var IsLeaveAccumulatePeriodically = $('#IsLeaveAccumulatePeriodically').is(":checked") ? "true" : "false";
            if (IsLeaveAccumulatePeriodically == 'true')
            {
                $("#Numberofleave").show(true);
            }
            else
            {
                $("#Numberofleave").hide(true);
                $("#NumberOfMonths").val('0');
                $("#NumberOfAccumulatedLeaves").val('0');
            }
        });

        $("#AccumulationMethod").change(function ()
        {
            var data = $("#AccumulationMethod").val();
            if (data == 2) {
                $("#Numberofleave").show(true);
            }
            else
            {
                $("#Numberofleave").hide(true);
                $("#NumberOfMonths").val('0');
                $("#NumberOfAccumulatedLeaves").val('0');
            }
        });


        // Create new record
        $('#CreateLeaveRuleMasterRecord').on("click", function ()
        {
            debugger;
            if (parseInt($('#MaxLeaveAtTime').val()) > parseInt($('#NumberOfLeaves').val()))
            {
                    $("#displayErrorMessage").text("Maximum Leave At Time can not be greater than Number of Leave.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");

                   
            }
            else if (parseInt($('#MinLeavesAtTime').val()) > parseInt($('#NumberOfLeaves').val()))
            {
                    $("#displayErrorMessage").text("Minimum Leave At Time can not be greater than Number of Leave.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");

                    
            }
            else if (parseInt($('#MaxLeaveEncash').val()) > parseInt($('#NumberOfLeaves').val()))
            {
                    $("#displayErrorMessage").text("Maximum Leave Encash can not be greater than Number of Leave.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");

                    
            }
            else if (parseInt($('#MinimumLeaveEncash').val()) > parseInt($('#NumberOfLeaves').val()))
            {
                    $("#displayErrorMessage").text("Mimimum Leave Encash can not be greater than Number of Leave.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
            }
            else if (parseInt($('#MaxLeaveAccumulated').val()) > parseInt($('#NumberOfLeaves').val()))
            {
                    $("#displayErrorMessage").text("Maximum Leave Accumulated can not be greater than Number of Leave.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
             }
                //else if (($('#MaxLeaveAtTime').val() == 0)) {
                //    $("#displayErrorMessage").text("Maximum Leave Accumulated should not be Zero.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                //}
                //else if (($('#MinLeavesAtTime').val() == 0)) {
                //    $("#displayErrorMessage").text("Maximum Leave Accumulated should not be Zero.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                //}
                //else if (($('#MaxLeaveEncash').val() == 0)) {
                //    $("#displayErrorMessage").text("Maximum Leave Encash should not be Zero.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                //}
                //else if (($('#MinimumLeaveEncash').val() == 0)) {
                //    $("#displayErrorMessage").text("Minimum Leave Encash should not be Zero.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                //}
                //else if (($('#MinServiceRequiredInMonth').val() == 0)) {
                //    $("#displayErrorMessage").text("Minimum Service Required In Month should not be Zero.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                //}
                //else if (($('#AttendDaysRequired').val() == 0)) {
                //    $("#displayErrorMessage").text("Attend Days Required should not be Zero.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                //}
                //else if (($('#MaxLeaveAccumulated').val() == 0)) {
                //    $("#displayErrorMessage").text("Maximum Leave Accumulated should not be Zero.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                //}
                //else if (($('#DaysBeforeApplicationSubmitted').val() == 0)) {
                //    $("#displayErrorMessage").text("Days Before Application Submitted should not be Zero.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                //}
                //else if (($('#LeaveApplicationSubmittedUptoDays').val() == 0)) {
                //    $("#displayErrorMessage").text("Leave Application Submitted Upto Days should not be Zero.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                //}
            else
            {
                    LeaveRuleMaster.ActionName = "Create";
                    LeaveRuleMaster.AjaxCallLeaveRuleMaster();
            }
        });

        $('#EditLeaveRuleMasterRecord').on("click", function () {
            debugger;
            LeaveRuleMaster.ActionName = "Edit";
            LeaveRuleMaster.AjaxCallLeaveRuleMaster();
        });

        $('#DeleteLeaveRuleMasterRecord').on("click", function () {

            LeaveRuleMaster.ActionName = "Delete";
            LeaveRuleMaster.AjaxCallLeaveRuleMaster();
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

        InitAnimatedBorder();
        CloseAlert();

        $("#CentreCode").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
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
                 url: '/LeaveRuleMaster/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);

                 }
             });
            }
            else {
                notify("Please select centre", "warning");
            }
        });

        $('#LeaveRuleDescription').on("keydown", function (e) {
            // AMSValidation.AllowCharacterOnly(e);
        });

        $('#NumberOfLeaves').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

        $('#MaxLeaveAtTime').on("keydown", function (e)
        {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

        $('#MinLeavesAtTime').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

        $('#MaxLeaveEncash').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

        $('#MinimumLeaveEncash').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

        $('#MinServiceRequiredInMonth').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

        $('#AttendDaysRequired').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

        $('#MaxLeaveAccumulated').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#DaysBeforeApplicationSubmitted').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#LeaveApplicationSubmittedUptoDays').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/LeaveRuleMaster/List',
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
            url: '/LeaveRuleMaster/List',
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


    //Fire ajax call to insert update and delete record
    AjaxCallLeaveRuleMaster: function () {
        debugger
        var LeaveRuleMasterData = null;
        if (LeaveRuleMaster.ActionName == "Create") {
            debugger
            $("#FormCreateLeaveRuleMaster").validate();
            if ($("#FormCreateLeaveRuleMaster").valid()) {
                LeaveRuleMasterData = null;
                LeaveRuleMasterData = LeaveRuleMaster.GetLeaveRuleMaster();
                ajaxRequest.makeRequest("/LeaveRuleMaster/Create", "POST", LeaveRuleMasterData, LeaveRuleMaster.Success);
            }
        }
        else if (LeaveRuleMaster.ActionName == "Edit") {
            $("#FormEditLeaveRuleMaster").validate();
            if ($("#FormEditLeaveRuleMaster").valid()) {
                LeaveRuleMasterData = null;
                LeaveRuleMasterData = LeaveRuleMaster.GetLeaveRuleMaster();
                ajaxRequest.makeRequest("/LeaveRuleMaster/Edit", "POST", LeaveRuleMasterData, LeaveRuleMaster.Success);
            }
        }
        else if (LeaveRuleMaster.ActionName == "Delete") {
            LeaveRuleMasterData = null;
            //$("#FormCreateLeaveRuleMaster").validate();
            LeaveRuleMasterData = LeaveRuleMaster.GetLeaveRuleMaster();
            ajaxRequest.makeRequest("/LeaveRuleMaster/Delete", "POST", LeaveRuleMasterData, LeaveRuleMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveRuleMaster: function () {
        var Data = {
        };
        if (LeaveRuleMaster.ActionName == "Create")
        {
            Data.ID = $('input[name=ID]').val();
            Data.LeaveMasterID = $('input[name=LeaveMasterID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.LeaveRuleDescription = $('#LeaveRuleDescription').val();
            Data.NumberOfLeaves = $('#NumberOfLeaves').val();
            Data.MaxLeaveAtTime = $('#MaxLeaveAtTime').val();
            //Data.MinimumLeaveEncash = $("#MinimumLeaveEncash").val();
            Data.MaxLeaveEncash = $("#MaxLeaveEncash").val();
            Data.MaxLeaveAccumulated = $("#MaxLeaveAccumulated").val();
            Data.MinServiceRequiredInMonth = $("#MinServiceRequiredInMonth").val();
            //Data.AttendDaysRequired = $("#AttendDaysRequired").val();
            Data.MinLeavesAtTime = $("#MinLeavesAtTime").val();
            Data.DaysBeforeApplicationSubmitted = $("#DaysBeforeApplicationSubmitted").val(); 
            Data.DaysAfterApplicationSubmitted = $("#DaysAfterApplicationSubmitted").val();
            Data.LeaveApplicationSubmittedUptoDays = $("#LeaveApplicationSubmittedUptoDays").val();
            //Data.IsLeaveAccumulatePeriodically = $('#IsLeaveAccumulatePeriodically:checked').val() ? true : false;
            Data.NumberOfMonths = $("#NumberOfMonths").val();
            Data.NumberOfAccumulatedLeaves = $("#NumberOfAccumulatedLeaves").val();
            //Data.DayOfTheMonth = $("#DayOfTheMonth").val();
            Data.LeaveMonthRatio = $("#LeaveMonthRatio").val();
            Data.LeaveEncashFormula = $("#LeaveEncashFormula").val();
            Data.AccumulationMethod = $("#AccumulationMethod").val();
        }
        else if (LeaveRuleMaster.ActionName == "Edit")
        {
            Data.ID = $('input[name=ID]').val();
            Data.LeaveMasterID = $('input[name=LeaveMasterID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.LeaveRuleDescription = $('#LeaveRuleDescription').val();
            Data.NumberOfLeaves = $('#NumberOfLeaves').val();
            Data.MaxLeaveAtTime = $('#MaxLeaveAtTime').val();
            ///Data.MinimumLeaveEncash = $("#MinimumLeaveEncash").val();
            Data.MaxLeaveEncash = $("#MaxLeaveEncash").val();
            Data.MaxLeaveAccumulated = $("#MaxLeaveAccumulated").val();
            Data.MinServiceRequiredInMonth = $("#MinServiceRequiredInMonth").val();
            //Data.AttendDaysRequired = $("#AttendDaysRequired").val();
            Data.MinLeavesAtTime = $("#MinLeavesAtTime").val();
            Data.DaysBeforeApplicationSubmitted = $("#DaysBeforeApplicationSubmitted").val();
            Data.DaysAfterApplicationSubmitted = $("#DaysAfterApplicationSubmitted").val();
            Data.LeaveApplicationSubmittedUptoDays = $("#LeaveApplicationSubmittedUptoDays").val();
            Data.IsActive = $('#IsActive:checked').val() ? true : false;
            //Data.IsLeaveAccumulatePeriodically = $('#IsLeaveAccumulatePeriodically:checked').val() ? true : false;
            Data.NumberOfMonths = $("#NumberOfMonths").val();
            Data.NumberOfAccumulatedLeaves = $("#NumberOfAccumulatedLeaves").val();
            Data.LeaveMonthRatio = $("#LeaveMonthRatio").val();
            Data.LeaveEncashFormula = $("#LeaveEncashFormula").val();
            Data.AccumulationMethod = $("#AccumulationMethod").val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveRuleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveRuleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {



    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        LeaveRuleMaster.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {


    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        LeaveRuleMaster.ReloadList("Record Deleted Sucessfully.");
    //      //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

