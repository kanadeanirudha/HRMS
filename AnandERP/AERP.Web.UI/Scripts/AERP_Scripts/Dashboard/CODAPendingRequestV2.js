//this class contain methods related to nationality functionality
var CODAPendingRequest = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    XMLstring: null,
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CODAPendingRequest.constructor();
        //CODAPendingRequest.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        // Create new record


        $('#btnApprovedCompensatory').on("click", function () {
            CODAPendingRequest.ActionName = "Approved";
            CODAPendingRequest.GetXmlData();
            CODAPendingRequest.AjaxCallCODAPendingRequest();
        });

        $('#btnRejectCompensatory').on("click", function () {
            CODAPendingRequest.ActionName = "Rejected";
            CODAPendingRequest.GetXmlData();
            CODAPendingRequest.AjaxCallCODAPendingRequest();
        });

        $('#CreateCODAPendingRequestRecord').on("click", function () {
            CODAPendingRequest.ActionName = "Create";
            CODAPendingRequest.AjaxCallCODAPendingRequest();
        });

        $('#EditCODAPendingRequestRecord').on("click", function () {

            CODAPendingRequest.ActionName = "Edit";
            CODAPendingRequest.AjaxCallCODAPendingRequest();
        });

        $('#DeleteCODAPendingRequestRecord').on("click", function () {

            CODAPendingRequest.ActionName = "Delete";
            CODAPendingRequest.AjaxCallCODAPendingRequest();
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
        var TaskCode = 'CODA'
        
        notify(message, colorCode);
        $('#CODA').click();
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
    AjaxCallCODAPendingRequest: function () {
        var CODAPendingRequestData = null;
        if (CODAPendingRequest.ActionName == "Create") {
            $("#FormCreateCODAPendingRequest").validate();
            if ($("#FormCreateCODAPendingRequest").valid()) {
                CODAPendingRequestData = null;
                CODAPendingRequestData = CODAPendingRequest.GetCODAPendingRequest();
                ajaxRequest.makeRequest("/CODAPendingRequest/Create", "POST", CODAPendingRequestData, CODAPendingRequest.Success);
            }
        }
        else if (CODAPendingRequest.ActionName == "Edit") {
            $("#FormEditCODAPendingRequest").validate();
            if ($("#FormEditCODAPendingRequest").valid()) {
                CODAPendingRequestData = null;
                CODAPendingRequestData = CODAPendingRequest.GetCODAPendingRequest();
                ajaxRequest.makeRequest("/CODAPendingRequest/Edit", "POST", CODAPendingRequestData, CODAPendingRequest.Success);
            }
        }
        else if (CODAPendingRequest.ActionName == "Delete") {
            CODAPendingRequestData = null;
            //$("#FormCreateCODAPendingRequest").validate();
            CODAPendingRequestData = CODAPendingRequest.GetCODAPendingRequest();
            ajaxRequest.makeRequest("/CODAPendingRequest/Delete", "POST", CODAPendingRequestData, CODAPendingRequest.Success);

        }

        else if (CODAPendingRequest.ActionName == "Approved" || CODAPendingRequest.ActionName == "Rejected") {
            CODAPendingRequestData = null;
            CODAPendingRequestData = CODAPendingRequest.GetCODAPendingRequest();
            ajaxRequest.makeRequest("/TaskNotification/ApproveAllCODARequestV2", "POST", CODAPendingRequest, CODAPendingRequest.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCODAPendingRequest: function () {
        var Data = {
        };
        if (CODAPendingRequest.ActionName == "Create" || CODAPendingRequest.ActionName == "Edit") {
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

        else if (CODAPendingRequest.ActionName == "Approved" || CODAPendingRequest.ActionName == "Rejected") {
            Data.XMLString = CODAPendingRequest.XMLstring;

        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            CODAPendingRequest.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            CODAPendingRequest.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },

    CheckedAll: function () {
        $("#MyDataTablePendingRequest-CODA thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#MyDataTablePendingRequest-CODA tbody tr td p input[class='check-user']").prop("checked", true);
                $("#btnApprovedCompensatory").prop("disabled", false);
                $("#btnRejectCompensatory").prop("disabled", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
            }
            else {
                $("#MyDataTablePendingRequest-CODA tbody tr td p input[class='check-user']").prop("checked", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
                $("#btnApprovedCompensatory").prop("disabled", true);
                $("#btnRejectCompensatory").prop("disabled", true);
            }
        });
    },

    CheckedSingle: function () {
        $("#MyDataTablePendingRequest-CODA tbody tr td p input[class='check-user']").on('click', function () {
            var CheckedArray = [];
            var table = $('#MyDataTablePendingRequest-CODA').DataTable();
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
                $("#btnApprovedCompensatory").prop("disabled", false);
                $("#btnRejectCompensatory").prop("disabled", false);
            }
            else {
                $("#btnApprovedCompensatory").prop("disabled", true);
                $("#btnRejectCompensatory").prop("disabled", true);
            }
        });
    },

    GetXmlData: function () {
        var DataArray = [];
        ParameterXml = "<rows>";
        var table = $('#MyDataTablePendingRequest-CODA').DataTable();
        var data = table.$("input[class='check-user']").each(function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                var checkboxVal = $this.val();
                var splitedVal = checkboxVal.split('~');
                var EmployeeID = (splitedVal[0].split('='))[1];
                //var TotalDay = parseFloat(splitedVal[12]) + parseFloat(splitedVal[13] / 2);

                if (CODAPendingRequest.ActionName == "Approved") {
                    //ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><LeaveApplicationID>" + splitedVal[9] + "</LeaveApplicationID><IsLast>" + splitedVal[4] + "</IsLast><TaskNotificationMasterID>" + splitedVal[1] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[0] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[2] + "</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><CentreCode>" + splitedVal[8] + "</CentreCode><LeaveMasterID>" + splitedVal[10] + "</LeaveMasterID><StageSequenceNumber>" + splitedVal[3] + "</StageSequenceNumber><TotalDay>" + TotalDay + "</TotalDay><TotalApprovedFullDay>" + splitedVal[12] + "</TotalApprovedFullDay><TotalApprovedHalfDay>" + splitedVal[13] + "</TotalApprovedHalfDay></row>";
                    ParameterXml = ParameterXml + "<row><ApplicationID>" + splitedVal[9] + "</ApplicationID><EmployeeID> " + EmployeeID + "</EmployeeID><TaskCode >" + splitedVal[8] + "</TaskCode ><IsLast>" + splitedVal[1] + "</IsLast><TaskNotificationMasterID>" + splitedVal[2] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[3] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[4] + "</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><CentreCode>" + splitedVal[6] + "</CentreCode><StageSequenceNumber>" + splitedVal[7] + "</StageSequenceNumber><LeaveSessionID>" + 2 + "</LeaveSessionID></row>";

                }
                else if (CODAPendingRequest.ActionName == "Rejected") {
                    ParameterXml = ParameterXml + "<row><ApplicationID> " + splitedVal[9] + "</ApplicationID><EmployeeID> " + EmployeeID + "</EmployeeID><TaskCode >" + splitedVal[8] + "</TaskCode ><IsLast>" + splitedVal[1] + "</IsLast><TaskNotificationMasterID>" + splitedVal[2] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[3] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[4] + "</GeneralTaskReportingDetailsID><ApprovalStatus>0</ApprovalStatus><CentreCode>" + splitedVal[6] + "</CentreCode><StageSequenceNumber>" + splitedVal[7] + "</StageSequenceNumber><LeaveSessionID>" + 2 + "</LeaveSessionID></row>";
                }
            }
        });

        CODAPendingRequest.XMLstring = ParameterXml + "</rows>";

    },

};

