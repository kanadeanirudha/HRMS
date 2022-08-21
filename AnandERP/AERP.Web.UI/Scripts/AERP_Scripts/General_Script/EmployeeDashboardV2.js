//this class contain methods related to nationality functionality
var EmployeeDashboardV2 = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeDashboardV2.constructor();
        //EmployeeDashboard.initializeValidation();
    },
    //Attach all event of page-
    constructor: function () {

        
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LeaveDescription').focus();
            $('#LeaveType').val(" ");
            return false;
        });

        // Create new record

        $('#btnApproved').on("click", function () {
            debugger;
            EmployeeDashboardV2.ActionName = "Approved";
            EmployeeDashboardV2.GetXmlData();
            EmployeeDashboardV2.AjaxCallEmployeeDashboard();
        });

        $('#btnReject').on("click", function () {
            EmployeeDashboardV2.ActionName = "Rejected";
            EmployeeDashboardV2.GetXmlData();
            EmployeeDashboardV2.AjaxCallEmployeeDashboard();
        });
        $('#CreateEmployeeDashboardRecord').on("click", function () {
            EmployeeDashboardV2.ActionName = "Create";
            EmployeeDashboardV2.AjaxCallEmployeeDashboard();
        });

        $('#EditEmployeeDashboardRecord').on("click", function () {

            EmployeeDashboardV2.ActionName = "Edit";
            EmployeeDashboardV2.AjaxCallEmployeeDashboard();
        });

        $('#DeleteEmployeeDashboardRecord').on("click", function () {

            EmployeeDashboardV2.ActionName = "Delete";
            EmployeeDashboardV2.AjaxCallEmployeeDashboard();
        });

        //$('#LeaveDescription').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        //$('#LeaveCode').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //    AMSValidation.NotAllowSpaces(e);
        //});

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


            var TaskCode = $(this).attr('id');
            var RequestName = $(this).text();
            $.ajax(
                  {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: { "TaskCode": TaskCode },
                      url: '/Home/ListV2',
                      success: function (result) {
                          $('#ListViewModel').html(result);
                      }
                  });
        });


        $('ul#TaskList li').click(function () {
          
            var Newurl = '';
            var TaskCode = $(this).attr('id');
            
            if (TaskCode == "MA") {
                Newurl = '/Home/PendingManualAttendanceRequestV2';
            }
            else if (TaskCode == "LA") {
                Newurl = '/Home/PendingLeaveRequestV2';
            }
            else if (TaskCode == "ASA") {
                Newurl = '/Home/SPAttendancePendingRequestV2';
            }
            else if (TaskCode == "CODA") {
                Newurl = '/Home/CODAPendingRequestV2';
            }
            else if (TaskCode == "DAST") {
                Newurl = '/Home/DASTPendingRequest';
            }
            else if (TaskCode == "INWARD") {
                Newurl = '/Home/INWARDPendingRequest';
            }
            else if (TaskCode == "FSAA") {
                Newurl = '/Home/FSAAPendingRequestV2';
            }
            else if (TaskCode == "SRAA") {
                Newurl = '/StudentRegistrationAcademicApproval/ListV2';
            }
            else if (TaskCode == "PR") {
                Newurl = '/Home/PurchaseRequirementPendingRequestV2';
            }
            else if (TaskCode == "PRQA") {
                Newurl = '/Home/PurchaseRequsitionPendingRequest';
            }
            else if (TaskCode == "SSA") {
                Newurl = '/Home/SSAPendingRequestV2';
            }
            else if (TaskCode == "AVAR")
            {
                Newurl = '/Home/AVARPendingRequestV2';
            }
            else if (TaskCode == "ATRA") {
                Newurl = '/Home/ATRAPendingRequest';
            }
            else if (TaskCode == "RequestsTab") {
                Newurl = '/Home/GeneralRequest';
            }
            else if (TaskCode == "infoNotifications") {
                Newurl = '/Home/InformativeNotifications';
            }
            else if (TaskCode == "PO") {
                Newurl = '/Home/PurchaseOrderPendingRequest';
            }
            $.ajax(
                  {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: { "TaskCode": TaskCode },
                      url: Newurl,
                      success: function (result) {
                          //alert(result);
                          $('.tab-content').html(result);
                      }
                  });
        });



        //$('#MyDataTablePendingLeaveRequest').checkall - user

    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/Home/ListV2',
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
        $('#'+TaskCode).click();

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
        //        notify(message, colorCode);
        //    }
        //});
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeDashboard: function () {
        var EmployeeDashboardData = null;
        if (EmployeeDashboardV2.ActionName == "Create") {
            $("#FormCreateEmployeeDashboard").validate();
            if ($("#FormCreateEmployeeDashboard").valid()) {
                EmployeeDashboardData = null;
                EmployeeDashboardData = EmployeeDashboardV2.GetEmployeeDashboard();
                ajaxRequest.makeRequest("/EmployeeDashboard/Create", "POST", EmployeeDashboardData, EmployeeDashboardV2.Success);
            }
        }
        else if (EmployeeDashboardV2.ActionName == "Edit") {
            $("#FormEditEmployeeDashboard").validate();
            if ($("#FormEditEmployeeDashboard").valid()) {
                EmployeeDashboardData = null;
                EmployeeDashboardData = EmployeeDashboardV2.GetEmployeeDashboard();
                ajaxRequest.makeRequest("/EmployeeDashboard/Edit", "POST", EmployeeDashboardData, EmployeeDashboardV2.Success);
            }
        }
        else if (EmployeeDashboardV2.ActionName == "Delete") {
            EmployeeDashboardData = null;
            //$("#FormCreateEmployeeDashboard").validate();
            EmployeeDashboardData = EmployeeDashboardV2.GetEmployeeDashboard();
            ajaxRequest.makeRequest("/EmployeeDashboard/Delete", "POST", EmployeeDashboardData, EmployeeDashboardV2.Success);

        }
        else if (EmployeeDashboardV2.ActionName == "Approved" || EmployeeDashboardV2.ActionName == "Rejected") {
            EmployeeDashboardData = null;
            EmployeeDashboardData = EmployeeDashboardV2.GetEmployeeDashboard();
            ajaxRequest.makeRequest("/Home/ApproveAllV2", "POST", EmployeeDashboardData, EmployeeDashboardV2.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeDashboard: function () {
        var Data = {
        };
        if (EmployeeDashboardV2.ActionName == "Create" || EmployeeDashboardV2.ActionName == "Edit") {
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
        else if (EmployeeDashboardV2.ActionName == "Approved" || EmployeeDashboardV2.ActionName == "Rejected") {
            Data.XMLString = EmployeeDashboardV2.XMLstring;
        }
        return Data;
    },
   
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            debugger;
         //   parent.$.colorbox.close();
            EmployeeDashboardV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
          //  parent.$.colorbox.close();
            EmployeeDashboardV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },

    CheckedAll: function () {
        debugger;
        $("#MyDataTablePendingLeaveRequest thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#MyDataTablePendingLeaveRequest tbody tr td p input[class='check-user']").prop("checked", true);
                $("#btnApproved").prop("disabled", false);
                $("#btnReject").prop("disabled", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
            }
            else {
                $("#MyDataTablePendingLeaveRequest tbody tr td p input[class='check-user']").prop("checked", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
                $("#btnApproved").prop("disabled", true);
                $("#btnReject").prop("disabled", true);
            }
        });
    },

    CheckedSingle: function () {
        debugger;
        $("#MyDataTablePendingLeaveRequest tbody tr td p input[class='check-user']").on('click', function () {
            var CheckedArray = [];
            var table = $('#MyDataTablePendingLeaveRequest').DataTable();
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
                $("#btnApproved").prop("disabled", false);
                $("#btnReject").prop("disabled", false);
            }
            else {
                $("#btnApproved").prop("disabled", true);
                $("#btnReject").prop("disabled", true);
            }
        });
    },

    GetXmlData: function () {
        debugger;
        var DataArray = [];
        ParameterXml = "<rows>";
        var table = $('#MyDataTablePendingLeaveRequest').DataTable();
        var data = table.$("input[class='check-user']").each(function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                var checkboxVal = $this.val();
                var splitedVal = checkboxVal.split('~');
                var EmployeeID = (splitedVal[5].split('='))[1];
                var TotalDay = parseFloat(splitedVal[12]) + parseFloat(splitedVal[13] / 2);

                if (EmployeeDashboardV2.ActionName == "Approved") {
                    ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><LeaveApplicationID>" + splitedVal[9] + "</LeaveApplicationID><IsLast>" + splitedVal[4] + "</IsLast><TaskNotificationMasterID>" + splitedVal[1] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[0] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[2] + "</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><CentreCode>" + splitedVal[8] + "</CentreCode><LeaveMasterID>" + splitedVal[10] + "</LeaveMasterID><StageSequenceNumber>" + splitedVal[3] + "</StageSequenceNumber><TotalDay>" + TotalDay + "</TotalDay><TotalApprovedFullDay>" + splitedVal[12] + "</TotalApprovedFullDay><TotalApprovedHalfDay>" + splitedVal[13] + "</TotalApprovedHalfDay></row>";
                }
                else if (EmployeeDashboardV2.ActionName == "Rejected") {
                    ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><LeaveApplicationID>" + splitedVal[9] + "</LeaveApplicationID><IsLast>" + splitedVal[4] + "</IsLast><TaskNotificationMasterID>" + splitedVal[1] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[0] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[2] + "</GeneralTaskReportingDetailsID><ApprovalStatus>0</ApprovalStatus><CentreCode>" + splitedVal[8] + "</CentreCode><LeaveMasterID>" + splitedVal[10] + "</LeaveMasterID><StageSequenceNumber>" + splitedVal[3] + "</StageSequenceNumber><TotalDay>" + TotalDay + "</TotalDay><TotalApprovedFullDay>" + splitedVal[12] + "</TotalApprovedFullDay><TotalApprovedHalfDay>" + splitedVal[13] + "</TotalApprovedHalfDay></row>";
                }
            }
        });
        EmployeeDashboardV2.XMLstring = ParameterXml + "</rows>";

    },
};

