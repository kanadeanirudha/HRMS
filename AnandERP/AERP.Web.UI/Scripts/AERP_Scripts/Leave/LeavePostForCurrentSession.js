//this class contain methods related to nationality functionality
var LeavePostForCurrentSession = {
    //Member variables
    ActionName: null,
    SelectedIDs: "",
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeavePostForCurrentSession.constructor();
        //LeavePostForCurrentSession.initializeValidation();
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

        // Create new record
        $('#CreateLeavePostForCurrentSessionRecord').on("click", function () {
            LeavePostForCurrentSession.ActionName = "Create";
            LeavePostForCurrentSession.getValueUsingParentTag();
            if (LeavePostForCurrentSession.SelectedIDs != "<rows></rows>") {
                LeavePostForCurrentSession.AjaxCallLeavePostForCurrentSession();
            }
            else {
                $('#SuccessMessage').html("Please review your form");
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', '#f89406');
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

        $(".ajax").colorbox();

        $('.NumberOnly').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $("#CentreList").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            //$('#myDataTable_thead').attr('readonly', 'readonly');
            //      $('#myDataTable_thead').attr("disabled", "disabled");
        });

        $("#ShowList").click(function () {
            debugger;
            var SelectedCentreCode = $('#CentreCode').val();
            var SelectedCentreName = $('#CentreCode :selected').text();
         
            if (SelectedCentreCode != "") {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

                 dataType: "html",
                 url: '/LeavePostForCurrentSession/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                 }
             });
            }
            else {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                // LeaveSession.ReloadList("Please select centre", "#FFCC80", null);
                //   $('#Createbutton').hide();
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
             url: '/LeavePostForCurrentSession/List',
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
            url: '/LeavePostForCurrentSession/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallLeavePostForCurrentSession: function () {
        var LeavePostForCurrentSessionData = null;
        if (LeavePostForCurrentSession.ActionName == "Create") {
            $("#LeavePostForCurrentSessionAtOpening").validate();
            //if ($("#LeavePostForCurrentSessionAtOpening").valid()) {
                LeavePostForCurrentSessionData = null;
                LeavePostForCurrentSessionData = LeavePostForCurrentSession.GetLeavePostForCurrentSession();
                ajaxRequest.makeRequest("/LeavePostForCurrentSession/Create", "POST", LeavePostForCurrentSessionData, LeavePostForCurrentSession.Success);
         //   }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetLeavePostForCurrentSession: function () {
        var Data = {
        };
        if (LeavePostForCurrentSession.ActionName == "Create") {
            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            //  alert(LeavePostForCurrentSession.SelectedIDs);
            Data.SelectedIDs = LeavePostForCurrentSession.SelectedIDs;
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            LeavePostForCurrentSession.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            LeavePostForCurrentSession.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    getValueUsingParentTag: function () {
        //debugger;
        var sList = "";
        var xmlParamList = "<rows>";
        var DataArray = [];
        var sArray = [];

        var DatatableData, TotalRecord, TotalRow;
        $('#myDataTable input[type=text]').each(function () {
            var a = $(this).attr('id');
            var textboxNewVal = $(this).val();
            sArray = $(this).val().split("~");
            //xmlInsert code here
            DataArray = DataArray + ',' + a + '~' + textboxNewVal;
        });

        sArray = DataArray.split(',');
        TotalRecord = sArray.length;
        var splitedArray = [];
        var i = 1;
        for (; i < TotalRecord ;) {
            splitedArray = sArray[i].split('~');
            if (splitedArray[0] != "" && splitedArray[5] == 0) {
                if (splitedArray[6] != "") {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + 0 + "</ID>" + "<EmployeeID>" + splitedArray[0] + "</EmployeeID>" + "<LeaveMasterID>" + splitedArray[4] + "</LeaveMasterID>" + "<BalanceLeave>" + splitedArray[6] + "</BalanceLeave>" + "<LeaveRuleMasterId>" + splitedArray[3] + "</LeaveRuleMasterId>" + "<ReasonForInsertion>Leaves for particular session</ReasonForInsertion>" + "<BalanceCarryForwardStatus>ByOpening</BalanceCarryForwardStatus>" + "<SummaryIDBFFrom>0</SummaryIDBFFrom>" + "<SummeryIDCFTo>0</SummeryIDCFTo>" + "<CreditDays></CreditDays>" + "<LeaveSummaryID></LeaveSummaryID>" + "<Remark></Remark>" + "<TranscationType></TranscationType>" + "<CreditDetailIdBraughtForwardFrom></CreditDetailIdBraughtForwardFrom>" + "<CreditDetailIdCarryForwardTo></CreditDetailIdCarryForwardTo>" + "<LeaveAvailedID></LeaveAvailedID>" + "<LeaveCancelCreditID></LeaveCancelCreditID>" + "</row>";
                }
            }
            i = i + 1;
        }
        LeavePostForCurrentSession.SelectedIDs = xmlParamList + "</rows>";
        // alert(LeavePostForCurrentSession.SelectedIDs);
    },
};

