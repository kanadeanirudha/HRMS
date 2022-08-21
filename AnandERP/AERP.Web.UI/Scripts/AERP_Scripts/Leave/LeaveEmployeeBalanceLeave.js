
////this class contain methods related to employee balance leave functionality.
//var LeaveEmployeeBalanceLeave = {

//    //Member variables
//    ActionName: null,

//    Initialize: function () {
//        LeaveEmployeeBalanceLeave.constructor();
//    },

//    //Attach all event of page
//    constructor: function () {

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });


//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });

//        $(".ajax").colorbox();

//        $("#ShowList").click(function () {
           
//            var centreCode = $('#CentreCode').val();
//            var centreName = $('#CentreCode :selected').text();
//            var departmentName = $('#DepartmentID :selected').text();
           
//            if ($('#DepartmentID').val() == "") {
//                var Dept = [];
//                $('#DepartmentID option').each(function () {
//                    if ($(this).attr('value') != "") {
//                        Dept.push($(this).attr('value'));
//                    }
//                });
//                var deparmentID = Dept.toString();
//            }
//            else
//            {
//                var deparmentID = $('#DepartmentID').val();
//            }            
//            if (centreCode != null && centreCode != "") {
//                $.ajax({
//                    cache: false,
//                    type: "POST",
//                    data: { actionMode: null, centerCode: centreCode, centreName: centreName, deparmentID: deparmentID, departmentName: departmentName },
//                    dataType: "html",
//                    url: '/LeaveEmployeeBalanceLeave/List',
//                    success: function (result) {
//                        //Rebind Grid Data                
//                        $('#ListViewModel').html(result);
//                    }
//                });
//            }
//            else {
//                $('#SuccessMessage').html("Please select centre name.");
//                $('#SuccessMessage').delay(400).slideDown(400).delay(1000).slideUp(200).css('background-color', "#FFCC80");
//            }
//        });


//        $("#CentreCode").change(function () {
//            $('#myDataTable').html("");
//            $('#myDataTable').html("");
//            $('#myDataTable').append(' <tr><td>No data available in table</td></tr>');
//            var selectedItem = $(this).val();
//            var $ddlDepartments = $("#DepartmentID");
//            if ($("#CentreCode").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/LeaveEmployeeBalanceLeave/GetDepartmentByCentreCode",
//                    data: { "CentreCode": selectedItem },
//                    success: function (data) {
                        
//                        //var Dept = [];
//                        //$.each(data, function (id, option) {
//                        //    Dept.push(option.id);
//                        //});                        
//                        $ddlDepartments.html('');
//                        //$ddlDepartments.append('<option value="' + Dept.toString()+ '">All</option>');
//                        $ddlDepartments.append('<option value="">All</option>');

//                        $.each(data, function (id, option) {
//                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));

//                        });
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve Departments.');
//                    }
//                });
              
//            }
//            else {
//                //$("#DepartmentDd").hide();
//                $('#DepartmentID').find('option').remove().end().append('<option value>All</option>');
//                $("#DepartmentID").val("");
//                $("#DepartmentName").val("");
//            }
//        });

//        $("#DepartmentID").change(function () {
//            $('#myDataTable').html("");
//            $('#myDataTable').append(' <tr><td>No data available in table</td></tr>');
           
//            //var $ddlDepartments = $("#DepartmentID");
//            //$ddlDepartments.html('');
//            //$ddlDepartments.append('<option value="">All</option>');
//        });
//    },
//    ////Load method is used to load *-Load-* page
//    LoadList: function () {
       
//        $.ajax({
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { actionMode: null, centerCode: null, centreName: null, deparmentID: 0, deparmentName: null },
//            url: '/LeaveEmployeeBalanceLeave/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $('#ListViewModel').html(data);
//            }
//        });
//    }

//}
//////////////////////////new js////////////////////////////



//this class contain methods related to employee balance leave functionality.
var LeaveEmployeeBalanceLeave = {

    //Member variables
    ActionName: null,

    Initialize: function () {
        LeaveEmployeeBalanceLeave.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });


        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();


        $("#ShowList").click(function () {

            var centreCode = $('#CentreCode').val();
            var centreName = $('#CentreCode :selected').text();
            var departmentName = $('#DepartmentID :selected').text();

            if ($('#DepartmentID').val() == "") {
                var Dept = [];
                $('#DepartmentID option').each(function () {
                    if ($(this).attr('value') != "") {
                        Dept.push($(this).attr('value'));
                    }
                });
                var deparmentID = Dept.toString();
            }
            else {
                var deparmentID = $('#DepartmentID').val();
            }
            if (centreCode != null && centreCode != "") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    data: { actionMode: null, centerCode: centreCode, centreName: centreName, deparmentID: deparmentID, departmentName: departmentName },
                    dataType: "html",
                    url: '/LeaveEmployeeBalanceLeave/List',
                    success: function (result) {
                        //Rebind Grid Data                
                        $('#ListViewModel').html(result);
                    }
                });
            }
            else {
                //$('#SuccessMessage').html("Please select centre name.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1000).slideUp(200).css('background-color', "#FFCC80");
                notify("Please select centre name.", "warning");
            }
        });


        $("#CentreCode").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable').html("");
            $('#myDataTable').append('<tr> <td class="active"> No data available in table. </td> </tr>');
            var selectedItem = $(this).val();
            var $ddlDepartments = $("#DepartmentID");
            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/LeaveEmployeeBalanceLeave/GetDepartmentByCentreCode",
                    data: { "CentreCode": selectedItem },
                    success: function (data) {

                        //var Dept = [];
                        //$.each(data, function (id, option) {
                        //    Dept.push(option.id);
                        //});                        
                        $ddlDepartments.html('');
                        //$ddlDepartments.append('<option value="' + Dept.toString()+ '">All</option>');
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
                //$("#DepartmentDd").hide();
                $('#DepartmentID').find('option').remove().end().append('<option value>All</option>');
                $("#DepartmentID").val("");
                $("#DepartmentName").val("");
            }
        });

        $("#DepartmentID").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable').append('<tr> <td class="active"> No data available in table. </td> </tr>');

            //var $ddlDepartments = $("#DepartmentID");
            //$ddlDepartments.html('');
            //$ddlDepartments.append('<option value="">All</option>');
        });
    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: null, centerCode: null, centreName: null, deparmentID: 0, deparmentName: null },
            url: '/LeaveEmployeeBalanceLeave/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    }

}



