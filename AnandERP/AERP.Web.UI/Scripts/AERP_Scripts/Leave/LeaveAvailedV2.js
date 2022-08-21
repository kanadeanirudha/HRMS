//this class contain methods related to nationality functionality
var LeaveAvailedV2 = {
    //Member variables
    ActionName: null,
    SelectedXmlData: null,
    TotalDays: 0,
    TotalApprovedDays: 0,
    TotalApprovedHalfDay: 0,
    TotalCancelledLeaves:0,
    TotalApprovedFullDay: 0,
    TotalRejectDays: 0,
    LeaveApplicationID: 0,
    CentreCode: 0,
    LeaveMasterID: 0,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveAvailedV2.constructor();
        //LeaveAvailedV2.initializeValidation();
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
        $('#CreateLeaveAvailedRecord').on("click", function () {
            LeaveAvailedV2.ActionName = "Create";

            LeaveAvailedV2.getDataFromDataTable();
            if (LeaveAvailedV2.SelectedXmlData != '') {
                if (LeaveAvailedV2.TotalRejectDays > 0 && $('#Remark').val() == "") {
                    $('#Remark').focus();
                    $('#CompulsoryRemark').show();
                }
                else {
                    LeaveAvailedV2.AjaxCallLeaveAvailed();
                }
            }
            else {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_NoRecordUpdated", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("No record updated");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
            }

            //  LeaveAvailed.AjaxCallLeaveAvailed();
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



    },

    getDataFromDataTable: function () {

        var DataArray = [];
        var table = $('#myDataTableForLeaveRequestApproval').DataTable();
        var data = table.$('input,select,input tag').each(function () {
            DataArray.push($(this).val());
        });

        var xmlParamList = "<rows>";
        var aa = [];
        var x = 2;
        var y = 1;
        var z = 0;
        var unselectedRowCount = 0;
        var Count = DataArray.length / 3;
        LeaveAvailedV2.TotalDays = 0;
        LeaveAvailedV2.TotalApprovedDays = 0;
        LeaveAvailedV2.TotalRejectDays = 0;
        LeaveAvailedV2.TotalCancelledLeaves = 0;
        table.$('tbody tr').each(function () {
            if (DataArray[x] === undefined) {
                return false;
            }
            else {
                var a = $(this).find('td p').attr('id');
                aa = DataArray[x].split('~');
                $(this).removeClass('row_selected');
               
                if (aa[1] == a && aa[0] == '4') {
                    LeaveAvailedV2.TotalCancelledLeaves = LeaveAvailedV2.TotalCancelledLeaves + 1;                   
                }
                else {
                    // String for Insert    
                   // alert('approve or reject')
                    var bb = DataArray[y].split('~');
                    var splitedData = bb[1].split('/');
                    LeaveAvailedV2.LeaveApplicationID = splitedData[0];
                    LeaveAvailedV2.CentreCode = splitedData[1];
                    LeaveAvailedV2.LeaveMasterID = splitedData[2];
                    if (aa[0] == '2') {
                        xmlParamList = xmlParamList + "<row><LeaveApplicationTransactionID>" + aa[1] + "</LeaveApplicationTransactionID><Dates>" + DataArray[z] + "</Dates><HalfLeaveStatus>" + bb[0] + "</HalfLeaveStatus><ApprovalStatus>" + aa[0] + "</ApprovalStatus></row>";
                        if (bb[0] == 0) {
                            LeaveAvailedV2.TotalApprovedDays = LeaveAvailedV2.TotalApprovedDays + 1;
                            LeaveAvailedV2.TotalApprovedFullDay = LeaveAvailedV2.TotalApprovedFullDay + 1;
                        }
                        else {
                            LeaveAvailedV2.TotalApprovedDays = LeaveAvailedV2.TotalApprovedDays + 0.5;
                            LeaveAvailedV2.TotalApprovedHalfDay = LeaveAvailedV2.TotalApprovedHalfDay + 1;
                        }
                    }
                    else {
                        xmlParamList = xmlParamList + "<row><LeaveApplicationTransactionID>" + aa[1] + "</LeaveApplicationTransactionID><Dates>" + DataArray[z] + "</Dates><HalfLeaveStatus>" + bb[0] + "</HalfLeaveStatus><ApprovalStatus>" + aa[0] + "</ApprovalStatus></row>";
                        if (bb[0] == 0) {
                            LeaveAvailedV2.TotalRejectDays = LeaveAvailedV2.TotalRejectDays + 1;
                        }
                        else {
                            LeaveAvailedV2.TotalRejectDays = LeaveAvailedV2.TotalRejectDays + 0.5;
                        }
                    }
                }
                x = x + 3;
                y = y + 3;
                z = z + 3;
            }
        });
        var calDays = parseFloat(LeaveAvailedV2.TotalApprovedDays) + parseFloat(LeaveAvailedV2.TotalRejectDays) + parseFloat(LeaveAvailedV2.TotalCancelledLeaves);       
        if (Count === Math.round(calDays)) {
            xmlParamList = xmlParamList + "</rows>";
            LeaveAvailedV2.SelectedXmlData = xmlParamList;
        }
        else {
            $('#update-message').removeClass('invisible');
            $('#update-message').show();
            ajaxRequest.ErrorMessageForJS("JsValidationMessages_GiveApprovalForEachDay", "update-message", "#FFCC80");
            //$('#update-message').html('Please give approval for each day');
            //$('#update-message').delay(400).slideDown(400).delay(1000).slideUp(200).css('background-color', '#da4f49');
            return false;
        }
    },

    ////Load method is used to load *-Load-* page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/LeaveAvailed/ListV2',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var TaskCode = $('input[name=TaskCode]').val();
        notify(message, colorCode);
        $('#' + TaskCode).click();
        //$.ajax(
        //{
        //    cache: false,
        //    type: "POST",
        //    dataType: "html",
        //    data: { "actionMode": actionMode, "TaskCode": TaskCode },
        //    url: '/Home/NotificationListV2',
        //    success: function (data) {
        //        //Rebind Grid Data
        //        $('#content').empty().html(data);
        //        //$("#ListViewModel").empty().append(data);
        //        //twitter type notification
        //        notify(message, colorCode);
        //        //$('#SuccessMessage').html(message);
        //        //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', colorCode);
        //    }
        //});
    },


    //Fire ajax call to insert update and delete record
    AjaxCallLeaveAvailed: function () {
        var LeaveAvailedData = null;
        if (LeaveAvailedV2.ActionName == "Create") {

            $("#FormLeaveAvailed").validate();
            if ($("#FormLeaveAvailed").valid()) {
                LeaveAvailedData = null;
                LeaveAvailedData = LeaveAvailedV2.GetLeaveAvailed();
                ajaxRequest.makeRequest("/LeaveAvailed/RequestApprovalV2", "POST", LeaveAvailedData, LeaveAvailedV2.Success, "CreateLeaveAvailedRecord");
            }
        }
        else if (LeaveAvailedV2.ActionName == "Edit") {
            $("#FormEditLeaveAvailed").validate();
            if ($("#FormEditLeaveAvailed").valid()) {
                LeaveAvailedData = null;
                LeaveAvailedData = LeaveAvailedV2.GetLeaveAvailed();
                ajaxRequest.makeRequest("/LeaveAvailed/Edit", "POST", LeaveAvailedData, LeaveAvailedV2.Success, "CreateLeaveAvailedRecord");
            }
        }
        else if (LeaveAvailedV2.ActionName == "Delete") {
            LeaveAvailedData = null;
            //$("#FormCreateLeaveAvailed").validate();
            LeaveAvailedData = LeaveAvailedV2.GetLeaveAvailed();
            ajaxRequest.makeRequest("/LeaveAvailed/Delete", "POST", LeaveAvailedData, LeaveAvailedV2.Success, "CreateLeaveAvailedRecord");

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveAvailed: function () {
        debugger;
        var Data = {
        };
        if (LeaveAvailedV2.ActionName == "Create") {
            Data.PersonID = $('input[name=PersonID]').val();
            Data.LeaveApplicationID = LeaveAvailedV2.LeaveApplicationID;
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.IsActiveMember = $('input[name=IsActiveMember]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            if (LeaveAvailedV2.TotalApprovedDays > 0) {
                Data.ApprovalStatus = 1;
            }
            else {
                Data.ApprovalStatus = 0;
            }
            Data.CentreCode = LeaveAvailedV2.CentreCode;
            Data.LeaveMasterID = LeaveAvailedV2.LeaveMasterID;
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.Remark = $("#Remark").val();
            //if (LeaveAvailedV2.SelectedXmlData==NULL) {
            //    Data.SelectedIDs = NULL;
            //   }
            //else{
            Data.SelectedIDs = LeaveAvailedV2.SelectedXmlData;
            //}
            Data.TotalDays = LeaveAvailedV2.TotalApprovedDays;
            Data.TotalApprovedHalfDay = LeaveAvailedV2.TotalApprovedHalfDay;
            Data.TotalApprovedFullDay = LeaveAvailedV2.TotalApprovedFullDay;
        }
        else if (LeaveAvailedV2.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            $.magnificPopup.close();
            LeaveAvailedV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            $.magnificPopup.close();
            LeaveAvailedV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

