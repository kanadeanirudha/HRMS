//var LeaveShiftAllocateToCentre = {
//    variable: null,
//    Initialize: function () {
//        LeaveShiftAllocateToCentre.constructor();
//    },
//    constructor: function () {


//        $("#btnShowList").on("click", function () {
            
//            var SelectedCentreCode = $("#CentreCode").val();
//            var SelectedCentreName = $("#CentreCode :selected").text();
            
//            if (SelectedCentreCode != "" && SelectedCentreName != "") {
//                $.ajax(
//                     {
//                         cache: false,
//                         type: "GET",
//                         data: { "centerCode": SelectedCentreCode, "centreName": SelectedCentreName },
//                         dataType: "html",
//                         url: '/LeaveShiftAllocateToCentre/List',
//                         success: function (data) {
//                             //Rebind Grid Data
//                             $('#ListViewModel').html(data);
//                         }
//                     });
//            }

//            else if ((SelectedCentreCode == "" || SelectedCentreCode != null)) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//            }

//        });

//        $("#CentreCode").change(function () {
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

//        });

//        $('#CreateLeaveShiftAllocateToCentreRecord').on("click", function () {
            
//            LeaveShiftAllocateToCentre.ActionName = "Create";
//            LeaveShiftAllocateToCentre.AjaxCallLeaveShiftAllocateToCentre();
//        });
//        $('#EditLeaveShiftAllocateToCentreRecord').on("click", function () {
            
//            LeaveShiftAllocateToCentre.ActionName = "Edit";
//            LeaveShiftAllocateToCentre.AjaxCallLeaveShiftAllocateToCentre();
//        });
//        $('#closeBtn').on("click", function () {
//            parent.$.colorbox.close();
//        });
//        $("#UserSearch").on("keyup", function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });
//        $("#searchBtn").on("click", function () {
//            $("#UserSearch").focus();
//        });
//        $("#showrecord").on("change", function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });
//        $(".ajax").colorbox();
//    },
//    LoadList: function () {
//        $.ajax(
//        {
//            cache: false,
//            type: "GET",
//            dataType: "html",
//            url: '/LeaveShiftAllocateToCentre/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $('#ListViewModel').html(data);
//            }
//        });
//    },
//    ReloadList: function (message, colorCode, actionMode) {
        
//        var SelectedCentreCode = $('#CentreCode').val();
//        var SelectedCentreName = $('#CentreCode :selected').text();
//        $.ajax(
//       {
//           cache: false,
//           type: "POST",
//           data: { "centerCode": SelectedCentreCode, "centreName": SelectedCentreName, "actionMode": actionMode },
//           dataType: "html",
//           url: '/LeaveShiftAllocateToCentre/List',
//           success: function (data) {
//               //Rebind Grid Data
//               $("#ListViewModel").empty().append(data);
//               //twitter type notification
//               $('#SuccessMessage').html(message);
//               $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//           }
//       });
//    },

//    AjaxCallLeaveShiftAllocateToCentre: function () {
//        var LeaveShiftAllocateToCentreMasterData = null;
//        if (LeaveShiftAllocateToCentre.ActionName == "Create") {
//            $("#FormCreateLeaveShiftAllocateToCentre").validate();
//            if ($("#FormCreateLeaveShiftAllocateToCentre").valid()) {

//                LeaveShiftAllocateToCentreMasterData = LeaveShiftAllocateToCentre.GetLeaveShiftAllocateToCentreMaster();
//                ajaxRequest.makeRequest("/LeaveShiftAllocateToCentre/Create", "POST", LeaveShiftAllocateToCentreMasterData, LeaveShiftAllocateToCentre.Success);
//            }
//        }
//        else if (LeaveShiftAllocateToCentre.ActionName == "Edit") {
//            $("#FormEditLeaveShiftAllocateToCentre").validate();
//            if ($("#FormEditLeaveShiftAllocateToCentre").valid()) {
//                LeaveShiftAllocateToCentreMasterData = LeaveShiftAllocateToCentre.GetLeaveShiftAllocateToCentreMaster();
//                ajaxRequest.makeRequest("/LeaveShiftAllocateToCentre/Edit", "POST", LeaveShiftAllocateToCentreMasterData, LeaveShiftAllocateToCentre.Success);
//            }
//        }
//    },

//    GetLeaveShiftAllocateToCentreMaster: function () {
//        var Data = {};
//        Data.ID = $('input[name=ID]').val();
//        Data.ShiftID = $('input[name=ShiftID]').val();
//        Data.CentreCode = $('#CentreCode').val();
//        Data.CentreName = $('#CentreCode :selected').text();
//        Data.ShiftDesc = $('#ShiftDesc').val();
//        return Data;
//    },

//    Success: function (data) {
        
//        var splitData = data.split(',');
//        parent.$.colorbox.close();
//        LeaveShiftAllocateToCentre.ReloadList(splitData[0], splitData[1], splitData[2]);
//    },

//};


///////////////////////////new js///////////////////////////////

var LeaveShiftAllocateToCentre = {
    variable: null,
    Initialize: function () {
        LeaveShiftAllocateToCentre.constructor();
    },
    constructor: function () {


        $("#btnShowList").on("click", function () {

            var SelectedCentreCode = $("#CentreCode").val();
            var SelectedCentreName = $("#CentreCode :selected").text();

            if (SelectedCentreCode != "" && SelectedCentreName != "") {
                $.ajax(
                     {
                         cache: false,
                         type: "GET",
                         data: { "centerCode": SelectedCentreCode, "centreName": SelectedCentreName },
                         dataType: "html",
                         url: '/LeaveShiftAllocateToCentre/List',
                         success: function (data) {
                             //Rebind Grid Data
                             $('#ListViewModel').html(data);
                         }
                     });
            }

            else if ((SelectedCentreCode == "" || SelectedCentreCode != null)) {
                notify("Please select centre", "warning");
            }

        });

        $("#CentreCode").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });

        $('#CreateLeaveShiftAllocateToCentreRecord').on("click", function () {

            LeaveShiftAllocateToCentre.ActionName = "Create";
            LeaveShiftAllocateToCentre.AjaxCallLeaveShiftAllocateToCentre();
        });
        $('#EditLeaveShiftAllocateToCentreRecord').on("click", function () {

            LeaveShiftAllocateToCentre.ActionName = "Edit";
            LeaveShiftAllocateToCentre.AjaxCallLeaveShiftAllocateToCentre();
        });
        $('#closeBtn').on("click", function () {
            parent.$.colorbox.close();
        });
        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });
        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

    },
    LoadList: function () {
        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            url: '/LeaveShiftAllocateToCentre/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    ReloadList: function (message, colorCode, actionMode) {

        var SelectedCentreCode = $('#CentreCode').val();
        var SelectedCentreName = $('#CentreCode :selected').text();
        $.ajax(
       {
           cache: false,
           type: "POST",
           data: { "centerCode": SelectedCentreCode, "centreName": SelectedCentreName, "actionMode": actionMode },
           dataType: "html",
           url: '/LeaveShiftAllocateToCentre/List',
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

    AjaxCallLeaveShiftAllocateToCentre: function () {
        var LeaveShiftAllocateToCentreMasterData = null;
        if (LeaveShiftAllocateToCentre.ActionName == "Create") {
            $("#FormCreateLeaveShiftAllocateToCentre").validate();
            if ($("#FormCreateLeaveShiftAllocateToCentre").valid()) {

                LeaveShiftAllocateToCentreMasterData = LeaveShiftAllocateToCentre.GetLeaveShiftAllocateToCentreMaster();
                ajaxRequest.makeRequest("/LeaveShiftAllocateToCentre/Create", "POST", LeaveShiftAllocateToCentreMasterData, LeaveShiftAllocateToCentre.Success);
            }
        }
        else if (LeaveShiftAllocateToCentre.ActionName == "Edit") {
            $("#FormEditLeaveShiftAllocateToCentre").validate();
            if ($("#FormEditLeaveShiftAllocateToCentre").valid()) {
                LeaveShiftAllocateToCentreMasterData = LeaveShiftAllocateToCentre.GetLeaveShiftAllocateToCentreMaster();
                ajaxRequest.makeRequest("/LeaveShiftAllocateToCentre/Edit", "POST", LeaveShiftAllocateToCentreMasterData, LeaveShiftAllocateToCentre.Success);
            }
        }
    },

    GetLeaveShiftAllocateToCentreMaster: function () {
        var Data = {};
        Data.ID = $('input[name=ID]').val();
        Data.ShiftID = $('input[name=ShiftID]').val();
        Data.CentreCode = $('#CentreCode').val();
        Data.CentreName = $('#CentreCode :selected').text();
        Data.ShiftDesc = $('#ShiftDesc').val();
        return Data;
    },

    Success: function (data) {

        var splitData = data.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        LeaveShiftAllocateToCentre.ReloadList(splitData[0], splitData[1], splitData[2]);
    },

};


