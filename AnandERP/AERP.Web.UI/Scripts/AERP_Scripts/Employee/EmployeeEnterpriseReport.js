////this class contain methods related to nationality functionality
//var EmployeeEnterpriseReport = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeeEnterpriseReport.constructor();
//        //EmployeeEnterpriseReport.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');

//        });

      
//        $('#Description').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $("#UserSearch").keyup(function () {
//            oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();


//        $("#CentreCodeList").change(function () {
            
//            var selectedItem = $(this).val();
//            var $ddlDepartments = $("#DepartmentList");
//            var $departmentProgress = $("#states-loading-progress");
//            $departmentProgress.show();
//            if ($("#CentreCodeList").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/EmployeeProfileReport/GetDepartmentByCentreCode",
//                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
//                    data: { "CentreCode": selectedItem },
//                    success: function (data) {
//                        $ddlDepartments.html('');
//                        $ddlDepartments.append('<option value="">--Select Department--</option>');
//                        $.each(data, function (id, option) {

//                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $departmentProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve Departments.');
//                        $departmentProgress.hide();
//                    }
//                });
//                $('#btnCreate').hide();
//            }
//            else {
//                $('#myDataTable tbody').empty();
//                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>---Select Department---</option>');
//                $('#btnCreate').hide();
//            }
//        });

//        $("#DepartmentList").change(function () {
            
//            var selectedItem = $(this).val();
//            var SelectedCentreCode = $("#CentreCodeList").val();
//            //alert(SelectedCentreCode);
//            var $ddlEmployees = $("#EmployeeList");
//            var $employeeProgress = $("#states-loading-progress");
//            $employeeProgress.show();
//            if ($("#DepartmentList").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/EmployeeProfileReport/GetEmployeesByCentreCodeAndDeptID",
//                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
//                    data: { "CentreCode": SelectedCentreCode, "DepartmentID": selectedItem },
//                    success: function (data) {
//                        $ddlEmployees.html('');
//                        $ddlEmployees.append('<option value="">--Select Employee--</option>');
//                        $.each(data, function (id, option) {

//                            $ddlEmployees.append($('<option><a href="EmployeeProfileReport/EmployeeEnterpriseReport/2005"></a></option>').val(option.id).html(option.name));
//                        });
//                        $employeeProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve employee list.');
//                        $employeeProgress.hide();
//                    }
//                });
//                $('#btnCreate').hide();
//            }
//            else {
//                $('#myDataTable tbody').empty();
//                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>---Select Department---</option>');
//                $('#btnCreate').hide();
//            }
//        });

//        $('#EmployeeList').on("change", function () {

//            var valEmployeeID = $(this).val();
//            $.ajax(
//      {
//          cache: false,

//          data: { EmployeeID: valEmployeeID },

//          dataType: "html",
//          url: '/EmployeeProfileReport/EmployeeEnterpriseReport',
//          success: function (result) {
//              //Rebind Grid Data     
              
//              $('#ProfileReptOther').html('');
//              $('#ProfileReptOther').html(result);

//          }
//      });
//        });

      
      

//        $('#myDataTable tbody').on('click', 'tr td a', function () {
//            var aaa = $(this).attr("class");
            
//            //alert(aaa);
//            var splitData = aaa.split('~');
//            EmployeeEnterpriseReport.EmployeePerformanceMonitoringReport(splitData[1],splitData[0],0)
           
//        });

//        $('#myDataTable1 tbody').on('click', 'tr td a', function () {
//            var aaa = $(this).attr("class");
            
//           // alert(aaa);
//            var splitData = aaa.split('~');
//            EmployeeEnterpriseReport.EmployeePerformanceMonitoringReport(splitData[0], splitData[1], splitData[2])

//        });

//        $('#myDataTable2 tbody').on('click', 'tr td a', function () {
//            var EmpID = $(this).attr("class");
            
             
//          //var splitData = aaa.split('~');
//          //  EmployeeEnterpriseReport.EmployeePerformanceMonitoringReport(splitData[0], splitData[1], splitData[2])
//            $.ajax(
//                 {
//                     cache: false,
//                     data: { EmployeeID: EmpID },
//                     dataType: "html",
//                     url: '/EmployeeProfileReport/ProfileReport',
//                     success: function (result) {

//                         //Rebind Grid Data     
                         
//                         $('#ListViewModel').html('');
//                         $('#ListViewModel').html('<div class="container-fluid wrapper">' + result + '</div>');
//                     }
//                 });
//        });
//    },


//    //ReloadList method is used to load List page
//    LoadListByCentreCodeAndDepartmentID: function (SelectedCentreCode, SelectedDepartmentID) {

//        var selectedText = $('#SelectedDepartmentID').text();
//        var selectedVal = $('#SelectedDepartmentID').val();
//        $.ajax(
//          {
//              cache: false,
//              type: "POST",
//              data: { centerCode: SelectedCentreCode, departmentID: selectedVal },

//              dataType: "html",
//              url: '/AdminSnPosts/List',
//              success: function (result) {
//                  //Rebind Grid Data                
//                  $('#ListViewModel').html(result);

//              }
//          });
//    },
//    //LoadList method is used to load List page
//    EmployeePerformanceMonitoringReport: function (Level,CentreCode,DeptID) {
//        debugger
//        $.ajax(
//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             data: { level: Level, centreCode: CentreCode, DepartmentID: DeptID },
//             url: '/EnterpriseReport/EmployeePerformanceMonitoringReport',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { actionMode: actionMode },
//            url: '/EmployeeEnterpriseReport/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },


//    //ReloadList method is used to load List page
//    LoadDeptListByCentreCode: function (CentreCode) {
        

//        //  var selectedText = $('#SelectedDepartmentIDforRoleMaster').text();
//        // var selectedVal = $('#SelectedDepartmentIDforRoleMaster').val();

//        $.ajax(
//          {
//              cache: false,
//              type: "GET",
//              data: {},

//              dataType: "html",
//              url: '/EmployeeProfileReport/GetDepartmentByCentreCode',
//              success: function (result) {
//                  //Rebind Grid Data   

//                  //$('#moduleName').html('<i class="nav-icon list"></i>' + ModuleName);
//                  //

//                  //$('#sidebar').html(result);
//                  //_Header.LoadBalsheetByRoleID(ModuleName);
//              }
//          });
//    },

//    //Fire ajax call to insert update and delete record
//    AjaxCallEmployeeEnterpriseReport: function () {
//        var EmployeeEnterpriseReportData = null;
//        if (EmployeeEnterpriseReport.ActionName == "Create") {
//            $("#FormCreateEmployeeEnterpriseReport").validate();
//            if ($("#FormCreateEmployeeEnterpriseReport").valid()) {
//                EmployeeEnterpriseReportData = null;
//                EmployeeEnterpriseReportData = EmployeeEnterpriseReport.GetEmployeeEnterpriseReport();
//                ajaxRequest.makeRequest("/EmployeeEnterpriseReport/Create", "POST", EmployeeEnterpriseReportData, EmployeeEnterpriseReport.Success);
//            }
//        }
//        else if (EmployeeEnterpriseReport.ActionName == "Edit") {
//            $("#FormEditEmployeeEnterpriseReport").validate();
//            if ($("#FormEditEmployeeEnterpriseReport").valid()) {
//                EmployeeEnterpriseReportData = null;
//                EmployeeEnterpriseReportData = EmployeeEnterpriseReport.GetEmployeeEnterpriseReport();
//                ajaxRequest.makeRequest("/EmployeeEnterpriseReport/Edit", "POST", EmployeeEnterpriseReportData, EmployeeEnterpriseReport.Success);
//            }
//        }
//        else if (EmployeeEnterpriseReport.ActionName == "Delete") {
//            EmployeeEnterpriseReportData = null;
//            $("#FormDeleteEmployeeEnterpriseReport").validate();
//            EmployeeEnterpriseReportData = EmployeeEnterpriseReport.GetEmployeeEnterpriseReport();
//            ajaxRequest.makeRequest("/EmployeeEnterpriseReport/Delete", "POST", EmployeeEnterpriseReportData, EmployeeEnterpriseReport.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeeEnterpriseReport: function () {
//        var Data = {
//        };
//        if (EmployeeEnterpriseReport.ActionName == "Create" || EmployeeEnterpriseReport.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.Description = $('#Description').val();

//        }
//        else if (EmployeeEnterpriseReport.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            EmployeeEnterpriseReport.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            EmployeeEnterpriseReport.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        EmployeeEnterpriseReport.ReloadList("Record Updated Sucessfully.", actionMode);
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {

//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        EmployeeEnterpriseReport.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

////////new js///////////////////////////////


//this class contain methods related to nationality functionality
var EmployeeEnterpriseReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeEnterpriseReport.constructor();
        //EmployeeEnterpriseReport.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

        });


        $('#Description').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
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


        $("#CentreCodeList").change(function () {

            var selectedItem = $(this).val();
            var $ddlDepartments = $("#DepartmentList");
            var $departmentProgress = $("#states-loading-progress");
            $departmentProgress.show();
            if ($("#CentreCodeList").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeProfileReport/GetDepartmentByCentreCode",
                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlDepartments.html('');
                        $ddlDepartments.append('<option value="">--Select Department--</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $departmentProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                        $departmentProgress.hide();
                    }
                });
                $('#btnCreate').hide();
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>---Select Department---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#DepartmentList").change(function () {

            var selectedItem = $(this).val();
            var SelectedCentreCode = $("#CentreCodeList").val();
            //alert(SelectedCentreCode);
            var $ddlEmployees = $("#EmployeeList");
            var $employeeProgress = $("#states-loading-progress");
            $employeeProgress.show();
            if ($("#DepartmentList").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeProfileReport/GetEmployeesByCentreCodeAndDeptID",
                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
                    data: { "CentreCode": SelectedCentreCode, "DepartmentID": selectedItem },
                    success: function (data) {
                        $ddlEmployees.html('');
                        $ddlEmployees.append('<option value="">--Select Employee--</option>');
                        $.each(data, function (id, option) {

                            $ddlEmployees.append($('<option><a href="EmployeeProfileReport/EmployeeEnterpriseReport/2005"></a></option>').val(option.id).html(option.name));
                        });
                        $employeeProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve employee list.');
                        $employeeProgress.hide();
                    }
                });
                $('#btnCreate').hide();
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>---Select Department---</option>');
                $('#btnCreate').hide();
            }
        });

        $('#EmployeeList').on("change", function () {

            var valEmployeeID = $(this).val();
            $.ajax(
      {
          cache: false,

          data: { EmployeeID: valEmployeeID },

          dataType: "html",
          url: '/EmployeeProfileReport/EmployeeEnterpriseReport',
          success: function (result) {
              //Rebind Grid Data     

              $('#ProfileReptOther').html('');
              $('#ProfileReptOther').html(result);

          }
      });
        });




        $('#myDataTable tbody').on('click', 'tr td a', function () {
            var aaa = $(this).attr("class");

            //alert(aaa);
            var splitData = aaa.split('~');
            EmployeeEnterpriseReport.EmployeePerformanceMonitoringReport(splitData[1], splitData[0], 0)

        });

        $('#myDataTable1 tbody').on('click', 'tr td a', function () {
            var aaa = $(this).attr("class");

            // alert(aaa);
            var splitData = aaa.split('~');
            EmployeeEnterpriseReport.EmployeePerformanceMonitoringReport(splitData[0], splitData[1], splitData[2])

        });

        $('#myDataTable2 tbody').on('click', 'tr td a', function () {
            var EmpID = $(this).attr("class");


            //var splitData = aaa.split('~');
            //  EmployeeEnterpriseReport.EmployeePerformanceMonitoringReport(splitData[0], splitData[1], splitData[2])
            $.ajax(
                 {
                     cache: false,
                     data: { EmployeeID: EmpID },
                     dataType: "html",
                     url: '/EmployeeProfileReport/ProfileReport',
                     success: function (result) {

                         //Rebind Grid Data     

                         $('#ListViewModel').html('');
                         $('#ListViewModel').html('<div class="container-fluid wrapper">' + result + '</div>');
                     }
                 });
        });
    },


    //ReloadList method is used to load List page
    LoadListByCentreCodeAndDepartmentID: function (SelectedCentreCode, SelectedDepartmentID) {

        var selectedText = $('#SelectedDepartmentID').text();
        var selectedVal = $('#SelectedDepartmentID').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, departmentID: selectedVal },

              dataType: "html",
              url: '/AdminSnPosts/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },
    //LoadList method is used to load List page
    EmployeePerformanceMonitoringReport: function (Level, CentreCode, DeptID) {
        debugger
        $.ajax(
         {

             cache: false,
             type: "POST",

             dataType: "html",
             data: { level: Level, centreCode: CentreCode, DepartmentID: DeptID },
             url: '/EnterpriseReport/EmployeePerformanceMonitoringReport',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/EmployeeEnterpriseReport/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //ReloadList method is used to load List page
    LoadDeptListByCentreCode: function (CentreCode) {


        //  var selectedText = $('#SelectedDepartmentIDforRoleMaster').text();
        // var selectedVal = $('#SelectedDepartmentIDforRoleMaster').val();

        $.ajax(
          {
              cache: false,
              type: "GET",
              data: {},

              dataType: "html",
              url: '/EmployeeProfileReport/GetDepartmentByCentreCode',
              success: function (result) {
                  //Rebind Grid Data   

                  //$('#moduleName').html('<i class="nav-icon list"></i>' + ModuleName);
                  //

                  //$('#sidebar').html(result);
                  //_Header.LoadBalsheetByRoleID(ModuleName);
              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeEnterpriseReport: function () {
        var EmployeeEnterpriseReportData = null;
        if (EmployeeEnterpriseReport.ActionName == "Create") {
            $("#FormCreateEmployeeEnterpriseReport").validate();
            if ($("#FormCreateEmployeeEnterpriseReport").valid()) {
                EmployeeEnterpriseReportData = null;
                EmployeeEnterpriseReportData = EmployeeEnterpriseReport.GetEmployeeEnterpriseReport();
                ajaxRequest.makeRequest("/EmployeeEnterpriseReport/Create", "POST", EmployeeEnterpriseReportData, EmployeeEnterpriseReport.Success);
            }
        }
        else if (EmployeeEnterpriseReport.ActionName == "Edit") {
            $("#FormEditEmployeeEnterpriseReport").validate();
            if ($("#FormEditEmployeeEnterpriseReport").valid()) {
                EmployeeEnterpriseReportData = null;
                EmployeeEnterpriseReportData = EmployeeEnterpriseReport.GetEmployeeEnterpriseReport();
                ajaxRequest.makeRequest("/EmployeeEnterpriseReport/Edit", "POST", EmployeeEnterpriseReportData, EmployeeEnterpriseReport.Success);
            }
        }
        else if (EmployeeEnterpriseReport.ActionName == "Delete") {
            EmployeeEnterpriseReportData = null;
            $("#FormDeleteEmployeeEnterpriseReport").validate();
            EmployeeEnterpriseReportData = EmployeeEnterpriseReport.GetEmployeeEnterpriseReport();
            ajaxRequest.makeRequest("/EmployeeEnterpriseReport/Delete", "POST", EmployeeEnterpriseReportData, EmployeeEnterpriseReport.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeEnterpriseReport: function () {
        var Data = {
        };
        if (EmployeeEnterpriseReport.ActionName == "Create" || EmployeeEnterpriseReport.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.Description = $('#Description').val();

        }
        else if (EmployeeEnterpriseReport.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeEnterpriseReport.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeEnterpriseReport.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    
    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        EmployeeEnterpriseReport.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {

    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        EmployeeEnterpriseReport.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

