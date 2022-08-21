//this class contain methods related to nationality functionality
var LeavePostAtTheYearEnd = {
    //Member variables
    ActionName: null,
    SelectedIDs: "",
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeavePostAtTheYearEnd.constructor();
        //LeavePostAtTheYearEnd.initializeValidation();
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

        $("#CentreCode").change(function () {
            
            var selectedItem = $(this).val();
            var $ddlSessionFrom = $("#SelectedFromSessionID");
            var $ddlSessionTo = $("#SelectedToSessionID");
            var $SessionProgress = $("#states-loading-progress");
            $SessionProgress.show();
            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/Base/GetLeaveSessionByCentreCode",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlSessionFrom.html('');
                        $ddlSessionTo.html('');
                        $ddlSessionFrom.append('<option value="">--------Select Leave Session From-------</option>');
                        $ddlSessionTo.append('<option value="">--------Select Leave Session To-------</option>');
                        $.each(data, function (id, option) {
                          
                            $ddlSessionFrom.append($('<option></option>').val(option.id).html(option.name));
                            $('#myDataTable tbody tr').html('');
                            //   $ddlSessionTo.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $SessionProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Leave Session.');
                        $SessionProgress.hide();
                    }
                });
            }
            else {                
                $ddlSessionFrom.html('');
                $ddlSessionFrom.append('<option value="">--------Select Leave Session From-------</option>');

                $ddlSessionTo.html('');
                $ddlSessionTo.append('<option value="">--------Select Leave Session To-------</option>');
            }
        });

        $("#SelectedFromSessionID").change(function () {
            
            var selectedFromSessionID = $(this).val();
            var SelectedCentreCode = $("#CentreCode").val();
           
            var $ddlSessionTo = $("#SelectedToSessionID");
            var $SessionProgress = $("#states-loading-progress");
            $SessionProgress.show();
            if ($("#CentreCode").val() != "" && selectedFromSessionID != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/LeavePostAtTheYearEnd/GetToLeaveSessionByCentreCodeAndFromLeaveSession",
                    data: { "CentreCode": SelectedCentreCode, "FromLeaveSessionID": selectedFromSessionID },
                    success: function (data) {
                       

                        $ddlSessionTo.html('');
                        $ddlSessionTo.append('<option value="">--------Select Leave Session To-------</option>');
                        if (data.length > 0) {
                            $.each(data, function (id, option) {
                                $ddlSessionTo.append($('<option></option>').val(option.id).html(option.name));
                            });
                            $SessionProgress.hide();
                        }
                        else {
                            //$('#SuccessMessage').html("Next leave session not found.");
                            //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', '#f89406');
                            ajaxRequest.ErrorMessageForJS("JsValidationMessages_Nextleavesessionnotfound", "SuccessMessage", "#FFCC80");
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Leave Session.');
                        $SessionProgress.hide();
                    }
                });
            }
            else {
                if ($("#CentreCode").val() == "")
                {
                    var $ddlSessionFrom = $("#SelectedFromSessionID");
                    $ddlSessionFrom.html('');
                    $ddlSessionFrom.append('<option value="">--------Select Leave Session From-------</option>');
                }
                else
                {
                    $ddlSessionTo.html('');
                    $ddlSessionTo.append('<option value="">--------Select Leave Session To-------</option>');
                }
            }
        });

        // Create new record
        $('#CreateLeavePostAtTheYearEndRecord').on("click", function () {
            LeavePostAtTheYearEnd.ActionName = "Create";           
            LeavePostAtTheYearEnd.AjaxCallLeavePostAtTheYearEnd();
                
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
            var FromSessionID = $('#SelectedFromSessionID').val();
            var ToSessionID = $('#SelectedToSessionID').val();

            if (SelectedCentreCode != "" && FromSessionID != "" && ToSessionID != "") {
                if (FromSessionID != ToSessionID && FromSessionID < ToSessionID) {
                    $.ajax(
                 {
                     cache: false,
                     type: "POST",
                     data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName, SelectedFromSessionID: FromSessionID, SelectedToSessionID: ToSessionID },

                     dataType: "html",
                     url: '/LeavePostAtTheYearEnd/List',
                     success: function (result) {
                         //Rebind Grid Data  
                      
                             $('#divLeaveSummaryAtTheYearEnd').show();
                             $('#ListViewModel').html(result);
                        
                     }
                 });
                }
                else {
                    if (FromSessionID != ToSessionID) {
                        ajaxRequest.ErrorMessageForJS("JsValidationMessages_SessionShouldNotBeSame", "SuccessMessage", "#FFCC80");
                    }
                    else {
                        ajaxRequest.ErrorMessageForJS("JsValidationMessages_ToSessionWillBe", "SuccessMessage", "#FFCC80");
                    }
                }
            }
            else if (SelectedCentreCode == "")
            {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                
            }
            else if (FromSessionID == "") {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectSessionFrom", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select session from");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                
            }
            else if (ToSessionID == "") {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectSessionTo", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select session to");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
               
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
             url: '/LeavePostAtTheYearEnd/List',
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
            url: '/LeavePostAtTheYearEnd/List',
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
    AjaxCallLeavePostAtTheYearEnd: function () {
        var LeavePostAtTheYearEndData = null;
        if (LeavePostAtTheYearEnd.ActionName == "Create") {
            $("#FormLeavePostAtTheYearEnd").validate();
            if ($("#FormLeavePostAtTheYearEnd").valid()) {
                LeavePostAtTheYearEndData = null;
                LeavePostAtTheYearEndData = LeavePostAtTheYearEnd.GetLeavePostAtTheYearEnd();
                ajaxRequest.makeRequest("/LeavePostAtTheYearEnd/Create", "POST", LeavePostAtTheYearEndData, LeavePostAtTheYearEnd.Success);
            }
        }      
    },
    //Get properties data from the Create, Update and Delete page
    GetLeavePostAtTheYearEnd: function () {
        var Data = {
        };
        if (LeavePostAtTheYearEnd.ActionName == "Create") {           
            Data.CentreCode = $('#CentreCode').val();
            Data.SelectedFromSessionID = $('#SelectedFromSessionID').val();
            Data.SelectedToSessionID = $('#SelectedToSessionID').val();
        }      
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            LeavePostAtTheYearEnd.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            LeavePostAtTheYearEnd.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },

    getValueUsingParentTag: function () {
        
        var sList = "";
        var xmlParamList = "<rows>";
        var DataArray = [];
        var sArray = [];
        var DatatableData, TotalRecord, TotalRow;
        $('#myDataTable input[type=text]').each(function () {
            var a = $(this).attr('id');
            sArray = $(this).val().split("~");
            //xmlInsert code here
            DataArray = DataArray + ',' + a;
        });

        sArray = DataArray.split(',');
        TotalRecord = sArray.length;
        var splitedArray = [];
        var i = 1;
        for (; i < TotalRecord ;) {
            splitedArray = sArray[i].split('~');
            if (splitedArray[0] != "") {
                xmlParamList = xmlParamList + "<row>" + "<ID>" + 0 + "</ID>" + "<EmployeeID>" + splitedArray[0] + "</EmployeeID>" + "<LeaveMasterID>" + splitedArray[4] + "</LeaveMasterID>" + "<BalanceLeave>" + splitedArray[2] + "</BalanceLeave>" + "<LeaveRuleMasterId>" + splitedArray[3] + "</LeaveRuleMasterId>" + "<ReasonForInsertion>Leaves for particular session</ReasonForInsertion>" + "<BalanceCarryForwardStatus>ByOpening</BalanceCarryForwardStatus>" + "<SummaryIDBFFrom>0</SummaryIDBFFrom>" + "<SummeryIDCFTo>0</SummeryIDCFTo>" + "<CreditDays></CreditDays>" + "<LeaveSummaryID></LeaveSummaryID>" + "<Remark></Remark>" + "<TranscationType></TranscationType>" + "<CreditDetailIdBraughtForwardFrom></CreditDetailIdBraughtForwardFrom>" + "<CreditDetailIdCarryForwardTo></CreditDetailIdCarryForwardTo>" + "<LeaveAvailedID></LeaveAvailedID>" + "<LeaveCancelCreditID></LeaveCancelCreditID>" + "</row>";
            }
            i = i + 1;
        }
        LeavePostAtTheYearEnd.SelectedIDs = xmlParamList + "</rows>";
    },
};

