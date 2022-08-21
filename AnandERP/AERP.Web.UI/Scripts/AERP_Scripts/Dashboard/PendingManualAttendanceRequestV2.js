//this class contain methods related to nationality functionality
var PendingManualAttendanceRequestV2 = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        PendingManualAttendanceRequestV2.constructor();
        //PendingManualAttendanceRequestV2.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnApprovedManual').on("click", function () {
            PendingManualAttendanceRequestV2.ActionName = "Approved";
            PendingManualAttendanceRequestV2.GetXmlData();
            PendingManualAttendanceRequestV2.AjaxCallPendingManualAttendanceRequest();
        });

        $('#btnRejectManual').on("click", function () {
            PendingManualAttendanceRequestV2.ActionName = "Rejected";
            PendingManualAttendanceRequestV2.GetXmlData();
            PendingManualAttendanceRequestV2.AjaxCallPendingManualAttendanceRequest();
        });


        $('#CreatePendingManualAttendanceRequestRecord').on("click", function () {
            PendingManualAttendanceRequestV2.ActionName = "Create";
            PendingManualAttendanceRequestV2.AjaxCallPendingManualAttendanceRequest();
        });

        $('#EditPendingManualAttendanceRequestRecord').on("click", function () {

            PendingManualAttendanceRequestV2.ActionName = "Edit";
            PendingManualAttendanceRequestV2.AjaxCallPendingManualAttendanceRequest();
        });

        $('#DeletePendingManualAttendanceRequestRecord').on("click", function () {

            PendingManualAttendanceRequestV2.ActionName = "Delete";
            PendingManualAttendanceRequestV2.AjaxCallPendingManualAttendanceRequest();
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

        //    $(".ajax").colorbox();

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
        var TaskCode = 'MA'
        notify(message, colorCode);
        $('#MA').click();
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
    AjaxCallPendingManualAttendanceRequest: function () {
        var PendingManualAttendanceRequestData = null;
        if (PendingManualAttendanceRequestV2.ActionName == "Create") {
            $("#FormCreatePendingManualAttendanceRequest").validate();
            if ($("#FormCreatePendingManualAttendanceRequest").valid()) {
                PendingManualAttendanceRequestData = null;
                PendingManualAttendanceRequestData = PendingManualAttendanceRequestV2.GetPendingManualAttendanceRequest();
                ajaxRequest.makeRequest("/PendingManualAttendanceRequest/Create", "POST", PendingManualAttendanceRequestData, PendingManualAttendanceRequestV2.Success);
            }
        }
        else if (PendingManualAttendanceRequestV2.ActionName == "Edit") {
            $("#FormEditPendingManualAttendanceRequest").validate();
            if ($("#FormEditPendingManualAttendanceRequest").valid()) {
                PendingManualAttendanceRequestData = null;
                PendingManualAttendanceRequestData = PendingManualAttendanceRequestV2.GetPendingManualAttendanceRequest();
                ajaxRequest.makeRequest("/PendingManualAttendanceRequest/Edit", "POST", PendingManualAttendanceRequestData, PendingManualAttendanceRequestV2.Success);
            }
        }
        else if (PendingManualAttendanceRequestV2.ActionName == "Delete") {
            PendingManualAttendanceRequestData = null;
            //$("#FormCreatePendingManualAttendanceRequest").validate();
            PendingManualAttendanceRequestData = PendingManualAttendanceRequestV2.GetPendingManualAttendanceRequest();
            ajaxRequest.makeRequest("/PendingManualAttendanceRequest/Delete", "POST", PendingManualAttendanceRequestData, PendingManualAttendanceRequestV2.Success);

        }
        else if (PendingManualAttendanceRequestV2.ActionName == "Approved" || PendingManualAttendanceRequestV2.ActionName == "Rejected") {
            debugger;
            PendingManualAttendanceRequestData = null;
            PendingManualAttendanceRequestData = PendingManualAttendanceRequestV2.GetPendingManualAttendanceRequest();
            ajaxRequest.makeRequest("/TaskNotification/ApproveAllMARequestV2", "POST", PendingManualAttendanceRequestData, PendingManualAttendanceRequestV2.Success);
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetPendingManualAttendanceRequest: function () {
        var Data = {
        };
        if (PendingManualAttendanceRequestV2.ActionName == "Create" || PendingManualAttendanceRequestV2.ActionName == "Edit") {
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
        else if (PendingManualAttendanceRequestV2.ActionName == "Approved" || PendingManualAttendanceRequestV2.ActionName == "Rejected") {
            Data.XMLString = PendingManualAttendanceRequestV2.XMLstring;
            debugger;


        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            // parent.$.colorbox.close();
            PendingManualAttendanceRequestV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //  parent.$.colorbox.close();
            PendingManualAttendanceRequestV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
    CheckedAll: function () {
        $("#MyDataTablePendingManualAttendanceRequest-MA thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#MyDataTablePendingManualAttendanceRequest-MA tbody tr td p input[class='check-user']").prop("checked", true);
                $("#btnApprovedManual").prop("disabled", false);
                $("#btnRejectManual").prop("disabled", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
            }
            else {
                $("#MyDataTablePendingManualAttendanceRequest-MA tbody tr td p input[class='check-user']").prop("checked", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
                $("#btnApprovedManual").prop("disabled", true);
                $("#btnRejectManual").prop("disabled", true);
            }
        });
    },

    CheckedSingle: function () {
        $("#MyDataTablePendingManualAttendanceRequest-MA tbody tr td p input[class='check-user']").on('click', function () {
            var CheckedArray = [];
            var table = $('#MyDataTablePendingManualAttendanceRequest-MA').DataTable();
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
                $("#btnApprovedManual").prop("disabled", false);
                $("#btnRejectManual").prop("disabled", false);
            }
            else {
                $("#btnApprovedManual").prop("disabled", true);
                $("#btnRejectManual").prop("disabled", true);
            }
        });
    },
    GetXmlData: function () {
        var DataArray = [];
        ParameterXml = "<rows>";
        var table = $('#MyDataTablePendingManualAttendanceRequest-MA').DataTable();
        var data = table.$("input[class='check-user']").each(function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                var checkboxVal = $this.val();
                var splitedVal = checkboxVal.split('~');
                var EmployeeID = (splitedVal[0].split('='))[1];

                //var TotalDay = parseFloat(splitedVal[12]) + parseFloat(splitedVal[13] / 2);
                if (PendingManualAttendanceRequestV2.ActionName == "Approved") {
                    //ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><LeaveApplicationID>" + splitedVal[9] + "</LeaveApplicationID><IsLast>" + splitedVal[4] + "</IsLast><TaskNotificationMasterID>" + splitedVal[1] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[0] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[2] + "</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><CentreCode>" + splitedVal[8] + "</CentreCode><LeaveMasterID>" + splitedVal[10] + "</LeaveMasterID><StageSequenceNumber>" + splitedVal[3] + "</StageSequenceNumber><TotalDay>" + TotalDay + "</TotalDay><TotalApprovedFullDay>" + splitedVal[12] + "</TotalApprovedFullDay><TotalApprovedHalfDay>" + splitedVal[13] + "</TotalApprovedHalfDay></row>";
                    ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><TaskCode>" + splitedVal[1] + "</TaskCode><IsLast>" + splitedVal[2] + "</IsLast><TaskNotificationMasterID>" + splitedVal[3] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[4] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[5] + "</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><StageSequenceNumber>" + splitedVal[7] + "</StageSequenceNumber><Reason>Approve All</Reason></row>";

                }
                else if (PendingManualAttendanceRequestV2.ActionName == "Rejected") {
                    ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><TaskCode>" + splitedVal[1] + "</TaskCode><IsLast>" + splitedVal[2] + "</IsLast><TaskNotificationMasterID>" + splitedVal[3] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[4] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[5] + "</GeneralTaskReportingDetailsID><ApprovalStatus>0</ApprovalStatus><StageSequenceNumber>" + splitedVal[7] + "</StageSequenceNumber><Reason>Reject All</Reason></row>";
                }
            }
        });

        PendingManualAttendanceRequestV2.XMLstring = ParameterXml + "</rows>";


    },

};

