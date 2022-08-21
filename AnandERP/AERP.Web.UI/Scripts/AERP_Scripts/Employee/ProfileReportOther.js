//this class contain methods related to nationality functionality
var ProfileReportOther = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ProfileReportOther.constructor();
        //ProfileReportOther.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

        });

        // Create new record
        $('#CreateProfileReportOtherRecord').on("click", function () {

            ProfileReportOther.ActionName = "Create";
            ProfileReportOther.AjaxCallProfileReportOther();
        });

        $('#EditProfileReportOtherRecord').on("click", function () {

            ProfileReportOther.ActionName = "Edit";
            ProfileReportOther.AjaxCallProfileReportOther();
        });

        $('#DeleteProfileReportOtherRecord').on("click", function () {

            ProfileReportOther.ActionName = "Delete";
            ProfileReportOther.AjaxCallProfileReportOther();
        });
        $('#Description').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
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
                $('#DepartmentList').find('option').remove().end().append('<option value>--Select Department--</option>');
                $('#EmployeeList').find('option').remove().end().append('<option value>--Select Employee--</option>');
                $('#ProfileReptOther').html('');
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

                            $ddlEmployees.append($('<option><a href="EmployeeProfileReport/ProfileReportOther/2005"></a></option>').val(option.id).html(option.name));
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
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>--Select Department--</option>');
                $('#EmployeeList').find('option').remove().end().append('<option value>--Select Employee--</option>');
                $('#ProfileReptOther').html('');

            }
        });

        $('#EmployeeList').on("change", function () {

            var valEmployeeID = $(this).val();
            if (valEmployeeID != "") {
                $.ajax({
                    cache: false,

                    data: { EmployeeID: valEmployeeID },

                    dataType: "html",
                    url: '/EmployeeProfileReport/ProfileReportOther',
                    success: function (result) {
                        //Rebind Grid Data     

                        $('#ProfileReptOther').html('');
                        $('#ProfileReptOther').html(result);

                    }
                });
            }
            else {
                $('#ProfileReptOther').html('');
            }
        });

        $('ul#ddlprofile li').click(function () {

            var EmpID = $(this).attr('id');
            var profileType = $(this).text();

            if (profileType == "Self") {
                $.ajax(
                 {
                     cache: false,
                     data: { EmployeeID: EmpID },
                     dataType: "html",
                     url: '/EmployeeProfileReport/ProfileReport',
                     success: function (result) {
                         //Rebind Grid Data     

                         $('#main-content').html('');
                         $('#main-content').html('<div class="container-fluid wrapper">' + result + '</div>');
                         //$('#hhh').removeClass('container-fluid');
                         // alert(result);
                     }
                 });
            }
        });


        $('#sidebarprofile').click(function () {

            var EmpID = $(this).attr('title');
            //var profileType = $(this).text();

            $.ajax(
             {
                 cache: false,
                 data: { EmployeeID: EmpID },
                 dataType: "html",
                 url: '/EmployeeProfileReport/ProfileReport',
                 success: function (result) {
                     //Rebind Grid Data     

                     $('#main-content').html('');
                     $('#main-content').html('<div class="container-fluid wrapper">' + result + '</div>');

                     //$('#hhh').removeClass('container-fluid');
                     // alert(result);
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
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/ProfileReportOther/List',
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
            url: '/ProfileReportOther/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
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
    AjaxCallProfileReportOther: function () {
        var ProfileReportOtherData = null;
        if (ProfileReportOther.ActionName == "Create") {
            $("#FormCreateProfileReportOther").validate();
            if ($("#FormCreateProfileReportOther").valid()) {
                ProfileReportOtherData = null;
                ProfileReportOtherData = ProfileReportOther.GetProfileReportOther();
                ajaxRequest.makeRequest("/ProfileReportOther/Create", "POST", ProfileReportOtherData, ProfileReportOther.Success);
            }
        }
        else if (ProfileReportOther.ActionName == "Edit") {
            $("#FormEditProfileReportOther").validate();
            if ($("#FormEditProfileReportOther").valid()) {
                ProfileReportOtherData = null;
                ProfileReportOtherData = ProfileReportOther.GetProfileReportOther();
                ajaxRequest.makeRequest("/ProfileReportOther/Edit", "POST", ProfileReportOtherData, ProfileReportOther.Success);
            }
        }
        else if (ProfileReportOther.ActionName == "Delete") {
            ProfileReportOtherData = null;
            $("#FormDeleteProfileReportOther").validate();
            ProfileReportOtherData = ProfileReportOther.GetProfileReportOther();
            ajaxRequest.makeRequest("/ProfileReportOther/Delete", "POST", ProfileReportOtherData, ProfileReportOther.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetProfileReportOther: function () {
        var Data = {
        };
        if (ProfileReportOther.ActionName == "Create" || ProfileReportOther.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.Description = $('#Description').val();

        }
        else if (ProfileReportOther.ActionName == "Delete") {
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
            ProfileReportOther.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            ProfileReportOther.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

