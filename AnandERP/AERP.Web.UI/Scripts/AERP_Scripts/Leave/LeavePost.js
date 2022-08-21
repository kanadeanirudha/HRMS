//this class contain methods related to nationality functionality
var LeavePost = {
    //Member variables
    ActionName: null,
    SelectedIDs:"",
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeavePost.constructor();
        //LeavePost.initializeValidation();
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
        $('#CreateLeavePostRecord').on("click", function () {
            //debugger;
            LeavePost.ActionName = "Create";
            LeavePost.getValueUsingParentTag();
            
            if (LeavePost.SelectedIDs != "<rows></rows>") {
                
                LeavePost.AjaxCallLeavePost();
            }
            else {
                //$('#SuccessMessage').html("Please review your changes.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', '#f89406');
                notify("Please review your changes.", "danger");
            }
        });
        
        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").DataTable();
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


        $('.NumberOnly').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

        $("#CentreCode").change(function () {
            
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            ////$('#myDataTable_thead').attr('readonly', 'readonly');
            ////      $('#myDataTable_thead').attr("disabled", "disabled");
            //$('#CreateLeavePostRecord').hide();
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_thead').attr('readonly', 'readonly');
            $('#CreateLeavePostRecord').hide(true);
          
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
                 url: '/LeavePost/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                     $('#CreateLeavePostRecord').show(true);
                 }
             });
            }
            else {
                notify("Please select centre", "warning");
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
             url: '/LeavePost/List',
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
            url: '/LeavePost/List',
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
    AjaxCallLeavePost: function () {
        var LeavePostData = null;
        if (LeavePost.ActionName == "Create") {
            $("#LeavePostAtOpening").validate();
            if ($("#LeavePostAtOpening").valid()) {
                LeavePostData = null;
                LeavePostData = LeavePost.GetLeavePost();
                ajaxRequest.makeRequest("/LeavePost/Create", "POST", LeavePostData, LeavePost.Success);
            }
        }
     },
    //Get properties data from the Create, Update and Delete page
    GetLeavePost: function () {
        var Data = {
        };
        if (LeavePost.ActionName == "Create") {           
            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
          //  alert(LeavePost.SelectedIDs);
            Data.SelectedIDs = LeavePost.SelectedIDs;
        }       
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeavePost.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeavePost.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
   
    getValueUsingParentTag: function () {
      debugger
        var sList = "";
        var xmlParamList = "<rows>";
        var DataArray = [];
        var sArray = [];
        
        var DatatableData, TotalRecord, TotalRow;
        debugger
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
        LeavePost.SelectedIDs = xmlParamList + "</rows>";
       // alert(LeavePost.SelectedIDs);
    },
};

