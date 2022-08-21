////this class contain methods related to nationality functionality
//var LeaveRuleApplicableDetails = {
//    //Member variables
//    ActionName: null,
//    SelectedIDs: null,
//    RuleMasterID: null,
//    //Class intialisation method
//    Initialize: function () {
//        //LeaveRuleApplicableDetails.loadData();

//        LeaveRuleApplicableDetails.constructor();
//        //LeaveRuleApplicableDetails.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#LeaveRuleMasterID').focus();
//            //  $('#LeaveType').val(" ");
//            return false;
//        });

//        $("#SelectedCentreCode").change(function () {

//            var selectedItem = $(this).val();
//            var $ddlSession = $("#SelectedSessionID");
//            var $SessionProgress = $("#states-loading-progress");
//            $SessionProgress.show();
//            if ($("#SelectedCentreCode").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/Base/GetLeaveSessionByCentreCode",

//                    data: { "CentreCode": selectedItem },
//                    success: function (data) {
//                        $ddlSession.html('');
//                        $ddlSession.append('<option value="">--------Select Leave Session-------</option>');
//                        $.each(data, function (id, option) {

//                            $ddlSession.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $SessionProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve Leave Session.');
//                        $SessionProgress.hide();
//                    }
//                });
//            }
//        });

//        // Create new record
//        $('#CreateLeaveRuleApplicableDetailsRecord').on("click", function () {

//            LeaveRuleApplicableDetails.ActionName = "Create";
//            LeaveRuleApplicableDetails.getValueUsingParentTag_Check_UnCheck();
//            LeaveRuleApplicableDetails.AjaxCallLeaveRuleApplicableDetails();
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

//        InitAnimatedBorder();
//        CloseAlert();

//        $("#CentreList").change(function () {
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

//        });

//        $("#btnShowList").click(function () {

//            var SelectedCentreCode = $('#SelectedCentreCode').val();
//            var SelectedCentreName = $('#SelectedCentreCode :selected').text();
//            var SelectedSessionID = $('#SelectedSessionID').val();

//            if (SelectedCentreCode != "") {
//                if (SelectedSessionID != "") {
//                    $.ajax(
//                 {
//                     cache: false,
//                     type: "POST",
//                     data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName, SessionId: SelectedSessionID },

//                     dataType: "html",
//                     url: '/LeaveRuleApplicableDetails/List',
//                     success: function (result) {
//                         //Rebind Grid Data                
//                         $('#ListViewModel').html(result);

//                     }
//                 });
//                }
//                else {
//                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectSession", "SuccessMessage", "#FFCC80");
//                    notify("Please Select Session", "danger");
//                    //$('#SuccessMessage').html("Please Select Session");
//                    //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
//                }
//            }
//            else {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                notify("Please Select Centre", "danger");
//                //$('#SuccessMessage').html("Please Select Centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
//                //LeaveRuleApplicableDetails.ReloadList("Please select Session", "#FFCC80", null);
//                //   $('#Createbutton').hide();
//            }
//        });

//        $('#LeaveRuleDescription').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
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

//        $("#myDataTableCreate tbody tr td input[id='IsActive']").on('click', function () {

//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $(this).closest("tr").find('td input[id="IsCurrent"]').attr("disabled", false);
//            }
//            else {
//                $(this).closest("tr").find('td input[id="IsCurrent"]').prop('checked', false);
//                $(this).closest("tr").find('td input[id="IsCurrent"]').attr("disabled", true);
//            }
//        });


//        $("#btnLeaveRuleMasterDetails").click(function (e) {
//            if (false == $('#LeaveRuleMasterDetails').is(':visible')) {
//                var RuleMasterID = 0;
//                RuleMasterID = $('#LeaveRuleMasterID').val();
//                $.ajax(
//                {
//                    cache: false,
//                    type: "GET",
//                    data: { LeaveRuleMasterID: RuleMasterID },

//                    dataType: "html",
//                    url: '/LeaveRuleApplicableDetails/CreatePartialForm',
//                    success: function (result) {
//                        $('#LeaveRuleMasterDetails').show();
//                        $('#LeaveRuleMasterDetails').html(result);
//                        LeaveRuleApplicableDetails.RuleMasterID = 1;
//                    }
//                });
//            }
//            else {
//                $('#LeaveRuleMasterDetails').hide(250);
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
//             url: '/LeaveRuleApplicableDetails/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },

//    //Fire ajax call to insert update and delete record
//    AjaxCallLeaveRuleApplicableDetails: function () {

//        var LeaveRuleApplicableDetailsData = null;
//        if (LeaveRuleApplicableDetails.ActionName == "Create") {
//            $("#FormCreateLeaveRuleApplicableDetails").validate();
//            if ($("#FormCreateLeaveRuleApplicableDetails").valid()) {
//                LeaveRuleApplicableDetailsData = null;
//                LeaveRuleApplicableDetailsData = LeaveRuleApplicableDetails.GetLeaveRuleApplicableDetails();
//                ajaxRequest.makeRequest("/LeaveRuleApplicableDetails/Create", "POST", LeaveRuleApplicableDetailsData, LeaveRuleApplicableDetails.Success);
//            }
//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetLeaveRuleApplicableDetails: function () {

//        var Data = {
//        };
//        if (LeaveRuleApplicableDetails.ActionName == "Create") {
//            Data.LeaveRuleMasterID = $('#LeaveRuleMasterID').val();
//            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
//            Data.IDs = LeaveRuleApplicableDetails.SelectedIDs;
//            Data.LeaveRuleDescription = $('#LeaveRuleMasterID').text();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {

//        // LeaveRuleApplicableDetailsTable();
//        var splitData = data.split(',');
//        $('#SuccessMessageLeaveRuleApplicableDetails p').html(splitData[0]);
//        //$('#SuccessMessageLeaveRuleApplicableDetails').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
//        $('#SuccessMessageLeaveRuleApplicableDetails').delay(400).slideDown(400).delay(10000).slideUp(400).addClass('alert-warning');
//        //$("#SuccessMessageLeaveRuleApplicableDetails p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-warning');

//        $('#myDataTableCreate tr').hover(function () {
//            $(this).css('cursor', 'pointer');
//        });
//        //$("#CreateLeaveRuleApplicableDetails").hide(true);
//        $('#LeaveRuleMasterDetails').hide();
//        parent.$.colorbox.resize();
//    },

//    getValueUsingParentTag_Check_UnCheck: function () {

//        var sList = "";
//        var xmlParamList = "<rows>";
//        var DataArray = [];
//        var sArray = [];
//        var DatatableData, TotalRecord, TotalRow;
//        $('#myDataTableCreate input[type=checkbox]').each(function () {
//            if ($(this).val() != "on") {
//                var a = $(this).val();
//                //  var a = $(this).attr('id');
//                sArray = $(this).val().split("~");
//                if (this.checked == true) {
//                    //xmlInsert code here
//                    DataArray = DataArray + ',' + a + '~' + 'T';
//                }
//                else if (this.checked == false) {
//                    //xmlUpdate code here
//                    DataArray = DataArray + ',' + a + '~' + 'F';
//                }
//            }
//        });

//        sArray = DataArray.split(',');
//        // alert(sArray);
//        TotalRecord = sArray.length - 1;
//        var splitedArray = [];
//        var splitedArrayForActive = [];
//        var splitedArrayForCurrent = [];
//        var i = 1;

//        for (; i < TotalRecord ;) {
//            splitedArrayForActive = sArray[i].split('~');
//            splitedArrayForCurrent = sArray[i + 1].split('~');

//            if ((splitedArrayForActive[0] == 0) && (splitedArrayForActive[7] == "T")) {
//                if ((splitedArrayForCurrent[0] == 0) && (splitedArrayForCurrent[7] == "T")) {
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[0] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "<IsCurrentFlag>1</IsCurrentFlag>" + "</row>";
//                }
//                else {
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[0] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "<IsCurrentFlag>0</IsCurrentFlag>" + "</row>";
//                }
//            }
//            else if ((splitedArrayForActive[0] != 0) && (splitedArrayForActive[7] == "T")) {
//                if ((splitedArrayForCurrent[6] == "CF") && (splitedArrayForCurrent[7] == "T")) {
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[3] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "<IsCurrentFlag>1</IsCurrentFlag>" + "</row>";
//                }
//                else if ((splitedArrayForCurrent[6] == "CT") && (splitedArrayForCurrent[7] == "F")) {
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[3] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "<IsCurrentFlag>0</IsCurrentFlag>" + "</row>";
//                }
//                else if ((splitedArrayForCurrent[6] == "CF") && (splitedArrayForCurrent[7] == "F")) {
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[3] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "<IsCurrentFlag>0</IsCurrentFlag>" + "</row>";
//                }
//            }
//            else if ((splitedArrayForActive[0] != 0) && (splitedArrayForActive[7] == "F")) {
//                xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[3] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>0</IsActive>" + "<IsCurrentFlag>0</IsCurrentFlag>" + "</row>";
//            }
//            i = i + 2;
//        }
//        LeaveRuleApplicableDetails.SelectedIDs = xmlParamList + "</rows>";

//    },
//};






////////////////////////////////////new js//////////////////////////////////////////////
//this class contain methods related to nationality functionality
var LeaveRuleApplicableDetails = {
    //Member variables
    ActionName: null,
    SelectedIDs: null,
    RuleMasterID: null,
    //Class intialisation method
    Initialize: function () {
        //LeaveRuleApplicableDetails.loadData();

        LeaveRuleApplicableDetails.constructor();
        //LeaveRuleApplicableDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            //$('.IsActiveFlag').attr('disable', true);
            $('.IsActiveFlag').val("");
            $('#LeaveRuleMasterID').val("");
            return false;
        });

        $("#SelectedCentreCode").change(function () {
          
            var selectedItem = $(this).val();
            var $ddlSession = $("#SelectedSessionID");
            var $SessionProgress = $("#states-loading-progress");
            $SessionProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/Base/GetLeaveSessionByCentreCode",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlSession.html('');
                        $ddlSession.append('<option value="">--------Select Leave Session-------</option>');
                        $.each(data, function (id, option) {

                            $ddlSession.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $SessionProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Leave Session.');
                        $SessionProgress.hide();
                    }
                });
            }
        });

        // Create new record
        $('#CreateLeaveRuleApplicableDetailsRecord').on("click", function () {
          
          

                var LeaveRuleMasterName = $('#LeaveRuleMasterID option:selected').text();
                var IsSingleChecked = false;
                $('.IsActiveFlag').each(function () {
                    if ($(this).prop("checked") == true) {
                        $(this).parent().parent().next().next().text(LeaveRuleMasterName);
                        IsSingleChecked = true;
                    }
                });
               
                    LeaveRuleApplicableDetails.ActionName = "Create";
                    //LeaveRuleApplicableDetails.getValueUsingParentTag_Check_UnCheck();
                    LeaveRuleApplicableDetails.AjaxCallLeaveRuleApplicableDetails();
        });
        $('#EditLeaveRuleApplicableDetails').on("click", function () {

            LeaveRuleApplicableDetails.ActionName = "Delete";
            LeaveRuleApplicableDetails.AjaxCallLeaveRuleApplicableDetails();
        });

        $('#LeaveDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#LeaveCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTableCreate").DataTable();
        //    oTable.fnFilter(this.value);
        //});

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

        $("#CentreList").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });

        $("#btnShowList").unbind('click').click(function () {
            debugger;
            var SelectedCentreCode = $('#SelectedCentreCode').val();
            var SelectedCentreName = $('#SelectedCentreCode :selected').text();
            var SelectedSessionID = $('#SelectedSessionID').val();

            if (SelectedCentreCode != "") {
                if (SelectedSessionID != "") {
                    $.ajax(
                 {
                     cache: false,
                     type: "POST",
                     data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName, SessionId: SelectedSessionID },

                     dataType: "html",
                     url: '/LeaveRuleApplicableDetails/List',
                     success: function (result) {
                         //Rebind Grid Data                
                         $('#ListViewModel').html(result);

                     }
                 });
                }
                else {
                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectSession", "SuccessMessage", "#FFCC80");
                    notify("Please select session.","warning");
                    //$('#SuccessMessage').html("Please Select Session");
                    //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                }
            }
            else {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                notify("Please select centre", "warning");
                //$('#SuccessMessage').html("Please Select Centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                //LeaveRuleApplicableDetails.ReloadList("Please select Session", "#FFCC80", null);
                //   $('#Createbutton').hide();
            }
        });

        $('#LeaveRuleDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
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

        $("#myDataTableCreate tbody tr td input[id='IsActive']").on('click', function () {
          
            var $this = $(this);
            if ($this.is(":checked")) {
                $(this).closest("tr").find('td input[id="IsCurrent"]').attr("disabled", false);
            }
            else {
                $(this).closest("tr").find('td input[id="IsCurrent"]').prop('checked', false);
                $(this).closest("tr").find('td input[id="IsCurrent"]').attr("disabled", true);
            }
        });


        $("#btnLeaveRuleMasterDetails").click(function (e) {
            if ($('#LeaveRuleMasterID').val()) {
            if (false == $('#LeaveRuleMasterDetails').is(':visible')) {
                var RuleMasterID = 0;
                RuleMasterID = $('#LeaveRuleMasterID').val();
                $.ajax(
                {
                    cache: false,
                    type: "GET",
                    data: { LeaveRuleMasterID: RuleMasterID },

                    dataType: "html",
                    url: '/LeaveRuleApplicableDetails/CreatePartialForm',
                    success: function (result) {                       
                        $('#LeaveRuleMasterDetails').show();
                        $('#LeaveRuleMasterDetails').html(result);
                        LeaveRuleApplicableDetails.RuleMasterID = 1;
                    }
                });
            }
            else {
                $('#LeaveRuleMasterDetails').hide(250);
            }
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
             url: '/LeaveRuleApplicableDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        var SelectedCentreCode = $('#CentreCode').val();
        var SelectedCentreName = $('#CentreCode :selected').text();
        var SelectedSessionID = $('#SelectedSessionID').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName, SessionId: SelectedSessionID },
            url: '/LeaveRuleApplicableDetails/List',
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
    AjaxCallLeaveRuleApplicableDetails: function () {

        var LeaveRuleApplicableDetailsData = null;
        if (LeaveRuleApplicableDetails.ActionName == "Create") {
            $("#FormCreateLeaveRuleApplicableDetails").validate();
            if ($("#FormCreateLeaveRuleApplicableDetails").valid()) {
                LeaveRuleApplicableDetailsData = null;
                LeaveRuleApplicableDetailsData = LeaveRuleApplicableDetails.GetLeaveRuleApplicableDetails();
                ajaxRequest.makeRequest("/LeaveRuleApplicableDetails/Create", "POST", LeaveRuleApplicableDetailsData, LeaveRuleApplicableDetails.Success);
            }
        }
        else if (LeaveRuleApplicableDetails.ActionName == "Edit") {
            LeaveRuleApplicableDetailsData = null;
            LeaveRuleApplicableDetailsData = LeaveRuleApplicableDetails.GetLeaveRuleApplicableDetails();
            ajaxRequest.makeRequest("/LeaveRuleApplicableDetails/Edit", "POST", LeaveRuleApplicableDetailsData, LeaveRuleApplicableDetails.Success);
            }
        
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveRuleApplicableDetails: function () {
        debugger;
        var Data = {
        };
        if (LeaveRuleApplicableDetails.ActionName == "Create") {
            Data.LeaveRuleMasterID = $('#LeaveRuleMasterID').val();
            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
            //Data.IDs = LeaveRuleApplicableDetails.SelectedIDs;
            Data.LeaveRuleDescription = $('#LeaveRuleMasterID').text();
            Data.JobProfileID = $('input[name=JobProfileID]').val();
            Data.JobStatusID = $('input[name=JobStatusID]').val();
         
        }
        else if (LeaveRuleApplicableDetails.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            //  Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

       //// LeaveRuleApplicableDetailsTable();
       // var splitData = data.split(',');
       // $('#SuccessMessageLeaveRuleApplicableDetails p').html(splitData[0]);
       // //$('#SuccessMessageLeaveRuleApplicableDetails').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
       // $('#SuccessMessageLeaveRuleApplicableDetails').delay(400).slideDown(400).delay(10000).slideUp(400).addClass('alert-warning');
       // //$("#SuccessMessageLeaveRuleApplicableDetails p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-warning');
        
       // $('#myDataTableCreate tr').hover(function () {
       //     $(this).css('cursor', 'pointer');
       // });
       // //$("#CreateLeaveRuleApplicableDetails").hide(true);
       // $('#LeaveRuleMasterDetails').hide();
       // //parent.$.colorbox.resize();


            var splitData = data.split(',');
            if (data != null) {
                //parent.$.colorbox.close();
                $.magnificPopup.close();
                LeaveRuleApplicableDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
            } else {
                //parent.$.colorbox.close();
                $.magnificPopup.close();
                LeaveRuleApplicableDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
            }
    },

    //getValueUsingParentTag_Check_UnCheck: function () {
    //    debugger;
    //    var sList = "";
    //    var xmlParamList = "<rows>";
    //    var DataArray = [];
    //    var sArray = [];
    //    var DatatableData, TotalRecord, TotalRow;
    //    $('#myDataTableCreate input[type=checkbox]').each(function () {
    //        if ($(this).val() != "on") {
    //            var a = $(this).val();
    //            //  var a = $(this).attr('id');
    //            sArray = $(this).val().split("~");
    //            if (this.checked == true) {
    //                //xmlInsert code here
    //                DataArray = DataArray + ',' + a + '~' + 'T';
    //            }
    //            else if (this.checked == false) {
    //                //xmlUpdate code here
    //                DataArray = DataArray + ',' + a + '~' + 'F';
    //            }
    //        }
    //    });

    //    sArray = DataArray.split(',');
    //    // alert(sArray);
    //    TotalRecord = sArray.length - 1;
    //    var splitedArray = [];
    //    var splitedArrayForActive = [];
    //    var splitedArrayForCurrent = [];
    //    var i = 1;

    //    for (; i < TotalRecord ;) {
    //        splitedArrayForActive = sArray[i].split('~');
    //        splitedArrayForCurrent = sArray[i + 1].split('~');

    //        if ((splitedArrayForActive[0] == 0) && (splitedArrayForActive[7] == "T")) {
    //            if ((splitedArrayForCurrent[0] == 0) && (splitedArrayForCurrent[7] == "T")) {
    //                xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[0] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "<IsCurrentFlag>1</IsCurrentFlag>" + "</row>";
    //            }
    //            else {
    //                xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[0] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "<IsCurrentFlag>0</IsCurrentFlag>" + "</row>";
    //            }
    //        }
    //        else if ((splitedArrayForActive[0] != 0) && (splitedArrayForActive[7] == "T")) {
    //            if ((splitedArrayForCurrent[6] == "CF") && (splitedArrayForCurrent[7] == "T")) {
    //                xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[3] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "<IsCurrentFlag>1</IsCurrentFlag>" + "</row>";
    //            }
    //            else if ((splitedArrayForCurrent[6] == "CT") && (splitedArrayForCurrent[7] == "F")) {
    //                xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[3] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "<IsCurrentFlag>0</IsCurrentFlag>" + "</row>";
    //            }
    //            else if ((splitedArrayForCurrent[6] == "CF") && (splitedArrayForCurrent[7] == "F")) {
    //                xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[3] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>1</IsActive>" + "<IsCurrentFlag>0</IsCurrentFlag>" + "</row>";
    //            }
    //        }
    //        else if ((splitedArrayForActive[0] != 0) && (splitedArrayForActive[7] == "F")) {
    //            xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForActive[3] + "</ID>" + "<JobProfileID>" + splitedArrayForCurrent[1] + "</JobProfileID>" + "<JobStatusID>" + splitedArrayForCurrent[2] + "</JobStatusID>" + "<JobStatusCode>" + splitedArrayForCurrent[5] + "</JobStatusCode>" + "<IsActive>0</IsActive>" + "<IsCurrentFlag>0</IsCurrentFlag>" + "</row>";
    //        }
    //        i = i + 2;
    //    }
    //    LeaveRuleApplicableDetails.SelectedIDs = xmlParamList + "</rows>";

    //},
};

