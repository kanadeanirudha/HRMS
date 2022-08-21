//this class contain methods related to nationality functionality
var EmployeeAttendanceReport = {

    ActionName: null,
    Initialize: function () {
        EmployeeAttendanceReport.constructor();
    },
    //Attach all event of page
    constructor: function () {

        $('#btnEmployeeAttendanceReportSubmit').on("click", function () {
            
            if ($("#CentreCode").val() != "") {
                if ($("#FromDate").val() != "") {
                    if ($("#UptoDate").val() != "") {
                    
                    $("#IsPosted").val(true);
                    EmployeeAttendanceReport.ActionName = "Report";
                    EmployeeAttendanceReport.AjaxCallEmployeeAttendanceReport();
                    }
                    else {
                        $('#SuccessMessage').html("Please select upto date.");
                        $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    }
                }
                else {
                    $('#SuccessMessage').html("Please select from date.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
            }
            else {
                $('#SuccessMessage').html("Please select center.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
        });

        $('#FromDate').keypress(function (e) {
            return false;
        });
        $("#FromDate").datepicker({
            numberOfMonths: 1,
            dateFormat: 'd M yy'
        });

        $('#UptoDate').keypress(function (e) {
            return false;
        });
        $("#UptoDate").datepicker({
            numberOfMonths: 1,
            dateFormat: 'd M yy'
        });

        $("#CentreCode").change(function () {
            
            var selectedCentreCode = $(this).val();
            var $ddlDepartments = $("#DepartmentID");
            var $ddlEmployee = $("#EmployeeID");
            $ddlEmployee.html('');
            $ddlEmployee.append('<option value="">All</option>');
            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeAttendanceReport/GetDepartmentByCentreCode",
                    data: { "centreCode": selectedCentreCode },
                    success: function (data) {
                        
                        $ddlDepartments.html('');
                        $ddlDepartments.append('<option value="">All</option>');
                        $.each(data, function (id, option) {
                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));

                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                    }
                });
            }
            else {
                $('#printablediv').html("");
                //$('#printablediv').append(' <tr><td>No data available in table</td></tr>');
                //$('#print').hide();
                $('#DepartmentID').find('option').remove().end().append('<option value>All</option>');
                $("#DepartmentID").val("");
                $("#DepartmentName").val("");
                $('#FromDate').val("");
                $('#UptoDate').val("");

                $.ajax({
                    url: "/EmployeeAttendanceReport/List",
                    type: "POST",
                    dataType: "html",
                    data: { centreCode: "", departmentID: "", employeeID: 0, fromDate: "", uptoDate: "" },
                    success: function (data) {
                        
                        //alert(data);
                        //Rebind Grid Data
                        $('#printablediv').find('option').remove().end().append(' <tr><td></td></tr>');
                        $('#printablediv').html(data);
                    }
                })
            }
        });

        $("#DepartmentID").change(function () {
            
            var selectedCentreCode = $("#CentreCode").val();
            var selectedDepartment = $("#DepartmentID").val();

            var $ddlEmployee = $("#EmployeeID");
            if ($("#CentreCode").val() != "" && $("#DepartmentID").val() != "") {

                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeAttendanceReport/GetEmployeeByCentreCodeAndDept",
                    data: { "CentreCode": selectedCentreCode, "DepartmentID": selectedDepartment },

                    success: function (data) {
                        
                        $ddlEmployee.html('');
                        $ddlEmployee.append('<option value="">All</option>');
                        $.each(data, function (id, option) {
                            $ddlEmployee.append($('<option></option>').val(option.id).html(option.name));
                        });
                    },
                });
            }
            else {
                $('#EmployeeID').find('option').remove().end().append('<option value>All</option>');
                $("#EmployeeID").val("");
                $("#EmployeeName").val("");
                $('#FromDate').val("");
                $('#UptoDate').val("");
            }
        });

       
    },

    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeAttendanceReport: function () {
               
        var EmployeeAttendanceReportData = null;
        if (EmployeeAttendanceReport.ActionName == "Report") {
            $("#FormEmployeeAttendanceReport").validate();
            //if ($("#FormEmployeeAttendanceReport").valid()) {
                EmployeeAttendanceReportData = null;
                EmployeeAttendanceReportData = EmployeeAttendanceReport.GetEmployeeAttendanceReport();
                //ajaxRequest.makeRequest("/EmployeeAttendanceReport/List", "POST", EmployeeAttendanceReportData);
                
                $.ajax({
                    url: "/EmployeeAttendanceReport/List",
                    type: "POST",
                    dataType: "html",
                    data: { centreCode: EmployeeAttendanceReportData.CentreCode, departmentID: EmployeeAttendanceReportData.DepartmentID, employeeID: EmployeeAttendanceReportData.EmployeeID, fromDate: EmployeeAttendanceReportData.FromDate, uptoDate: EmployeeAttendanceReportData.UptoDate },
                    success: function (data) {
                        
                        //alert(data);
                        //Rebind Grid Data
                        $('#printablediv').html(data);
                    }
                })           
            //}
       }
    },

    //Get properties data from the Report.
    GetEmployeeAttendanceReport: function () {
        
        var Data = {
        };
        if (EmployeeAttendanceReport.ActionName == "Report")
        {
            Data.CentreCode = $('#CentreCode').val();

            //Get Department ID
            if ($('#DepartmentID').val() == "") {
                var Dept = [];
                $('#DepartmentID option').each(function () {
                    if ($(this).attr('value') != "") {
                        Dept.push($(this).attr('value'));
                    }
                });
                Data.DepartmentID = Dept.toString();
            }
            else {
                Data.DepartmentID = $('#DepartmentID').val();
            }

            //Get Employee ID.
            if ($('#EmployeeID').val() == "") {
                //var Emp = [];
                //$('#EmployeeID option').each(function () {
                //    if ($(this).attr('value') != "") {
                //        Emp.push($(this).attr('value'));
                //    }
                //});
                //if (Emp.toString() != "") {
                //    Data.EmployeeID = Emp.toString();
                //}else
                //{
                    Data.EmployeeID = "0";
                //}
            }
            else {
                Data.EmployeeID = $('#EmployeeID').val();
            }

            Data.FromDate = $('#FromDate').val();
            Data.UptoDate = $('#UptoDate').val();
        }
        return Data;
    },
}