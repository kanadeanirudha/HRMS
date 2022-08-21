//this class contain methods related to nationality functionality
var LeaveAvailed = {
    //Member variables
    ActionName: null,
    SelectedXmlData: null,
    TotalDays: 0,
    TotalApprovedDays: 0,
    TotalApprovedHalfDay: 0,
    TotalApprovedFullDay: 0,
    TotalRejectDays: 0,
    LeaveApplicationID: 0,
    CentreCode: 0,
    LeaveMasterID: 0,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveAvailed.constructor();
        //LeaveAvailed.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CountryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LeaveDescription').focus();
            $('#LeaveType').val(" ");
            return false;
        });


        // Create new record
        $('#CreateLeaveAvailedRecord').on("click", function () {
            LeaveAvailed.ActionName = "Create";

            LeaveAvailed.getDataFromDataTable();
            if (LeaveAvailed.SelectedXmlData != '') {
                if (LeaveAvailed.TotalRejectDays > 0 && $('#Remark').val() == "") {
                    $('#Remark').focus();
                    $('#CompulsoryRemark').show();
                }
                else {                
                    LeaveAvailed.AjaxCallLeaveAvailed();
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

        $(".ajax").colorbox();


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
        LeaveAvailed.TotalDays = 0;
        LeaveAvailed.TotalApprovedDays = 0;
        LeaveAvailed.TotalRejectDays = 0;
        table.$('tbody tr').each(function () {         
            if (DataArray[x] === undefined) {
                return false;
            }
            else {
                var a = $(this).find('td p').attr('id');
                aa = DataArray[x].split('~');
                $(this).removeClass('row_selected');
                if (aa[1] == a && aa[0] == '1') {
                    $(this).addClass('row_selected');
                    unselectedRowCount = unselectedRowCount + 1;
                }
                else {
                    // String for Insert                  
                    var bb = DataArray[y].split('~');
                    var splitedData = bb[1].split('/');
                    LeaveAvailed.LeaveApplicationID = splitedData[0];
                    LeaveAvailed.CentreCode = splitedData[1];
                    LeaveAvailed.LeaveMasterID = splitedData[2];
                    if (aa[0] == '2') {
                        xmlParamList = xmlParamList + "<row><LeaveApplicationTransactionID>" + aa[1] + "</LeaveApplicationTransactionID><Dates>" + DataArray[z] + "</Dates><HalfLeaveStatus>" + bb[0] + "</HalfLeaveStatus><ApprovalStatus>" + aa[0] + "</ApprovalStatus></row>";
                        if (bb[0] == 0) {
                            LeaveAvailed.TotalApprovedDays = LeaveAvailed.TotalApprovedDays + 1;
                            LeaveAvailed.TotalApprovedFullDay = LeaveAvailed.TotalApprovedFullDay + 1;
                        }
                        else {
                            LeaveAvailed.TotalApprovedDays = LeaveAvailed.TotalApprovedDays + 0.5;
                            LeaveAvailed.TotalApprovedHalfDay = LeaveAvailed.TotalApprovedHalfDay + 1;
                        }
                    }
                    else {
                        xmlParamList = xmlParamList + "<row><LeaveApplicationTransactionID>" + aa[1] + "</LeaveApplicationTransactionID><Dates>" + DataArray[z] + "</Dates><HalfLeaveStatus>" + bb[0] + "</HalfLeaveStatus><ApprovalStatus>" + aa[0] + "</ApprovalStatus></row>";
                        if (bb[0] == 0) {
                            LeaveAvailed.TotalRejectDays = LeaveAvailed.TotalRejectDays + 1;
                        }
                        else {
                            LeaveAvailed.TotalRejectDays = LeaveAvailed.TotalRejectDays + 0.5;
                        }
                    }
                }
                x = x + 3;
                y = y + 3;
                z = z + 3;
            }
        });
        var calDays = parseFloat(LeaveAvailed.TotalApprovedDays) + parseFloat(LeaveAvailed.TotalRejectDays)
        if (Count === Math.round(calDays)) {
            xmlParamList = xmlParamList + "</rows>";
            LeaveAvailed.SelectedXmlData = xmlParamList;
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
             url: '/LeaveAvailed/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var TaskCode = $('input[name=TaskCode]').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "TaskCode": TaskCode },
            url: '/Home/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallLeaveAvailed: function () {
        var LeaveAvailedData = null;
        if (LeaveAvailed.ActionName == "Create") {

            $("#FormLeaveAvailed").validate();
            if ($("#FormLeaveAvailed").valid()) {
                LeaveAvailedData = null;
                LeaveAvailedData = LeaveAvailed.GetLeaveAvailed();
                ajaxRequest.makeRequest("/LeaveAvailed/RequestApproval", "POST", LeaveAvailedData, LeaveAvailed.Success);
            }
        }
        else if (LeaveAvailed.ActionName == "Edit") {
            $("#FormEditLeaveAvailed").validate();
            if ($("#FormEditLeaveAvailed").valid()) {
                LeaveAvailedData = null;
                LeaveAvailedData = LeaveAvailed.GetLeaveAvailed();
                ajaxRequest.makeRequest("/LeaveAvailed/Edit", "POST", LeaveAvailedData, LeaveAvailed.Success);
            }
        }
        else if (LeaveAvailed.ActionName == "Delete") {
            LeaveAvailedData = null;
            //$("#FormCreateLeaveAvailed").validate();
            LeaveAvailedData = LeaveAvailed.GetLeaveAvailed();
            ajaxRequest.makeRequest("/LeaveAvailed/Delete", "POST", LeaveAvailedData, LeaveAvailed.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveAvailed: function () {
        var Data = {
        };
        if (LeaveAvailed.ActionName == "Create") {
            Data.PersonID = $('input[name=PersonID]').val();
            Data.LeaveApplicationID = LeaveAvailed.LeaveApplicationID;
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.IsActiveMember = $('input[name=IsActiveMember]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            if (LeaveAvailed.TotalApprovedDays > 0) {
                Data.ApprovalStatus = true;
            }
            else {
                Data.ApprovalStatus = false;
            }
            Data.CentreCode = LeaveAvailed.CentreCode;
            Data.LeaveMasterID = LeaveAvailed.LeaveMasterID;
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.Remark = $("#Remark").val();
            Data.SelectedIDs = LeaveAvailed.SelectedXmlData;
            Data.TotalDays = LeaveAvailed.TotalApprovedDays;
            Data.TotalApprovedHalfDay = LeaveAvailed.TotalApprovedHalfDay;
            Data.TotalApprovedFullDay = LeaveAvailed.TotalApprovedFullDay;
        }
        else if (LeaveAvailed.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            LeaveAvailed.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            LeaveAvailed.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {



    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        LeaveAvailed.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        LeaveAvailed.ReloadList("Record Deleted Sucessfully.");
    //      //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

