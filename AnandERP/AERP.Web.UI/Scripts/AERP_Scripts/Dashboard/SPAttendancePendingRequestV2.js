//this class contain methods related to nationality functionality
var SPAttendancePendingRequestV2 = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    XMLstring: null,
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SPAttendancePendingRequestV2.constructor();
        //SPAttendancePendingRequest.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        // Create new record
        $('#btnApprovedSpecialRequest').on("click", function () {
            debugger;
            SPAttendancePendingRequestV2.ActionName = "Approved";
            SPAttendancePendingRequestV2.GetXmlData();
            SPAttendancePendingRequestV2.AjaxCallSPAttendancePendingRequest();
        });

        $('#btnRejectSpecialRequest').on("click", function () {
            SPAttendancePendingRequestV2.ActionName = "Rejected";
            SPAttendancePendingRequestV2.GetXmlData();
            SPAttendancePendingRequestV2.AjaxCallSPAttendancePendingRequest();
        });

        $('#CreateSPAttendancePendingRequestRecord').on("click", function () {
            SPAttendancePendingRequestV2.ActionName = "Create";
            SPAttendancePendingRequestV2.AjaxCallSPAttendancePendingRequest();
        });

        $('#EditSPAttendancePendingRequestRecord').on("click", function () {

            SPAttendancePendingRequestV2.ActionName = "Edit";
            SPAttendancePendingRequestV2.AjaxCallSPAttendancePendingRequest();
        });

        $('#DeleteSPAttendancePendingRequestRecord').on("click", function () {

            SPAttendancePendingRequestV2.ActionName = "Delete";
            SPAttendancePendingRequestV2.AjaxCallSPAttendancePendingRequest();
        });

        $('#LeaveDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#LeaveCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#MyDataTablePendingLeaveRequest").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='MyDataTablePendingLeaveRequest_length']").val(showRecord);
            $("select[name*='MyDataTablePendingLeaveRequest_length']").change();
        });

     

        $('ul#pending_Request li').click(function () {
            debugger;

            var TaskCode = $(this).attr('id');
            var RequestName = $(this).text();
            $.ajax(
                  {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: { "TaskCode": TaskCode },
                      url: '/Home/List',
                      success: function (result) {
                          $('#ListViewModel').html(result);
                      }
                  });
        });


        //$('#MyDataTablePendingLeaveRequest').checkall - user

    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/Home/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var TaskCode = 'ASA'
        notify(message, colorCode);
        $('#ASA').click();
        //$.ajax(
        //{
        //    cache: false,
        //    type: "POST",
        //    dataType: "html",
        //    data: { "actionMode": actionMode, "TaskCode": TaskCode },
        //    url: '/Home/NotificationListV2',
        //    success: function (data) {
        //        $('#content').empty().html(data);
        //        notify(message, colorCode);
        //    }
        //});
    },


    //Fire ajax call to insert update and delete record
    AjaxCallSPAttendancePendingRequest: function () {
        var SPAttendancePendingRequestData = null;
        if (SPAttendancePendingRequestV2.ActionName == "Create") {
            $("#FormCreateSPAttendancePendingRequest").validate();
            if ($("#FormCreateSPAttendancePendingRequest").valid()) {
                SPAttendancePendingRequestData = null;
                SPAttendancePendingRequestData = SPAttendancePendingRequestV2.GetSPAttendancePendingRequest();
                ajaxRequest.makeRequest("/SPAttendancePendingRequest/Create", "POST", SPAttendancePendingRequestData, SPAttendancePendingRequestV2.Success);
            }
        }
        else if (SPAttendancePendingRequestV2.ActionName == "Edit") {
            $("#FormEditSPAttendancePendingRequest").validate();
            if ($("#FormEditSPAttendancePendingRequest").valid()) {
                SPAttendancePendingRequestData = null;
                SPAttendancePendingRequestData = SPAttendancePendingRequestV2.GetSPAttendancePendingRequest();
                ajaxRequest.makeRequest("/SPAttendancePendingRequest/Edit", "POST", SPAttendancePendingRequestData, SPAttendancePendingRequestV2.Success);
            }
        }
        else if (SPAttendancePendingRequestV2.ActionName == "Delete") {
            SPAttendancePendingRequestData = null;
            //$("#FormCreateSPAttendancePendingRequest").validate();
            SPAttendancePendingRequestData = SPAttendancePendingRequestV2.GetSPAttendancePendingRequest();
            ajaxRequest.makeRequest("/SPAttendancePendingRequest/Delete", "POST", SPAttendancePendingRequestData, SPAttendancePendingRequestV2.Success);

        }
        else if (SPAttendancePendingRequestV2.ActionName == "Approved" || SPAttendancePendingRequestV2.ActionName == "Rejected") {
            debugger;
            SPAttendancePendingRequestData = null;

            SPAttendancePendingRequestData = SPAttendancePendingRequestV2.GetSPAttendancePendingRequest();
            ajaxRequest.makeRequest("/TaskNotification/ApproveAllSPARequestV2", "POST", SPAttendancePendingRequestData, SPAttendancePendingRequestV2.Success);
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetSPAttendancePendingRequest: function () {
        var Data = {
        };
        if (SPAttendancePendingRequestV2.ActionName == "Create" || SPAttendancePendingRequestV2.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.LeaveDescription = $('#LeaveDescription').val();
            Data.LeaveCode = $('#LeaveCode').val();
            Data.LeaveType = $('#LeaveType').val();
            Data.IsCarryForwardForNextYear = $("input[id=IsCarryForwardForNextYear]:checked").val();
            Data.MinServiceRequire = $("input[id=MinServiceRequire]:checked").val();
            Data.HalfDayFlag = $("input[id=HalfDayFlag]:checked").val();
            Data.DocumentsNeeded = $("input[id=DocumentsNeeded]:checked").val();
            Data.AttendanceNeeded = $("input[id=AttendanceNeeded]:checked").val();
            Data.LossOfPay = $("input[id=LossOfPay]:checked").val();
            Data.NoCredit = $("input[id=NoCredit]:checked").val();
            Data.IsEnCash = $("input[id=IsEnCash]:checked").val();
            Data.OnDuty = $("input[id=OnDuty]:checked").val();
        }
        else if (SPAttendancePendingRequestV2.ActionName == "Approved" || SPAttendancePendingRequestV2.ActionName == "Rejected") {
            Data.XMLString = SPAttendancePendingRequestV2.XMLstring;
        }

        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            SPAttendancePendingRequestV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            SPAttendancePendingRequestV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
    CheckedAll: function () {
        $("#MyDataTablePendingRequest-ASA thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#MyDataTablePendingRequest-ASA tbody tr td p input[class='check-user']").prop("checked", true);
                $("#btnApprovedSpecialRequest").prop("disabled", false);
                $("#btnRejectSpecialRequest").prop("disabled", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
            }
            else {
                $("#MyDataTablePendingRequest-ASA tbody tr td p input[class='check-user']").prop("checked", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
                $("#btnApprovedSpecialRequest").prop("disabled", true);
                $("#btnRejectSpecialRequest").prop("disabled", true);
            }
        });
    },

    CheckedSingle: function () {
        $("#MyDataTablePendingRequest-ASA tbody tr td p input[class='check-user']").on('click', function () {
            var CheckedArray = [];
            var table = $('#MyDataTablePendingRequest-ASA').DataTable();
            var TotalCheckedRecord;
            var data = table.$("input[class='check-user']").each(function () {
                CheckedArray.push($(this).val());
                var $this = $(this);
                if ($this.is(":checked")) {
                    CheckedArray.push($(this).val());
                    TotalCheckedRecord = CheckedArray.length;
                }
            });
            if (TotalCheckedRecord > 0) {
                $("#btnApprovedSpecialRequest").prop("disabled", false);
                $("#btnRejectSpecialRequest").prop("disabled", false);
            }
            else {
                $("#btnApprovedSpecialRequest").prop("disabled", true);
                $("#btnRejectSpecialRequest").prop("disabled", true);
            }
        });
    },
    GetXmlData: function () {
        var DataArray = [];
        ParameterXml = "<rows>";
        var table = $('#MyDataTablePendingRequest-ASA').DataTable();
        var data = table.$("input[class='check-user']").each(function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                var checkboxVal = $this.val();
                var splitedVal = checkboxVal.split('~');
                var EmployeeID = (splitedVal[0].split('='))[1];

                //var TotalDay = parseFloat(splitedVal[12]) + parseFloat(splitedVal[13] / 2);
                if (SPAttendancePendingRequestV2.ActionName == "Approved") {
                    //ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><LeaveApplicationID>" + splitedVal[9] + "</LeaveApplicationID><IsLast>" + splitedVal[4] + "</IsLast><TaskNotificationMasterID>" + splitedVal[1] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[0] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[2] + "</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><CentreCode>" + splitedVal[8] + "</CentreCode><LeaveMasterID>" + splitedVal[10] + "</LeaveMasterID><StageSequenceNumber>" + splitedVal[3] + "</StageSequenceNumber><TotalDay>" + TotalDay + "</TotalDay><TotalApprovedFullDay>" + splitedVal[12] + "</TotalApprovedFullDay><TotalApprovedHalfDay>" + splitedVal[13] + "</TotalApprovedHalfDay></row>";
                    ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><TaskCode >" + splitedVal[1] + "</TaskCode><IsLast>" + splitedVal[2] + "</IsLast><TaskNotificationMasterID>" + splitedVal[3] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[4] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[5] + "</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><StageSequenceNumber>" + splitedVal[7] + "</StageSequenceNumber><Reason>Approve All</Reason></row>";

                }
                else if (SPAttendancePendingRequestV2.ActionName == "Rejected") {
                    ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><TaskCode >" + splitedVal[1] + "</TaskCode><IsLast>" + splitedVal[2] + "</IsLast><TaskNotificationMasterID>" + splitedVal[3] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[4] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[5] + "</GeneralTaskReportingDetailsID><ApprovalStatus>0</ApprovalStatus><StageSequenceNumber>" + splitedVal[7] + "</StageSequenceNumber><Reason>Reject All</Reason></row>";
                }
            }
        });

        SPAttendancePendingRequestV2.XMLstring = ParameterXml + "</rows>";

    },

};

