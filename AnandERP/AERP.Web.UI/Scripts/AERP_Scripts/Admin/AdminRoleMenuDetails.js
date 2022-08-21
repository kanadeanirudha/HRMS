//this class contain methods related to AdminRoleMenuDetails functionality
var AdminRoleMenuDetails = {
    //Member variables
    ActionName: null,
    SelectedTreeViewIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AdminRoleMenuDetails.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#SelectedCentreCodeforRoleMaster").change(function () {

            var selectedItem = $(this).val();
            var $ddlDepartments = $("#SelectedDepartmentIDforRoleMaster");
            var $departmentProgress = $("#states-loading-progress");
            $departmentProgress.show();
            if ($("#SelectedCentreCodeforRoleMaster").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AdminRoleMenuDetails/GetDepartmentByCentreCodeForRoleMaster",
                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
                    data: { "SelectedCentreCodeforRoleMaster": selectedItem },
                    success: function (data) {
                        $ddlDepartments.html('');
                        $ddlDepartments.append('<option value="">-----Select Department-----</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $departmentProgress.hide();

                    },

                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                        $departmentProgress.hide();
                        $('#btnCreate').hide();
                    }
                });
                $('#btnCreate').hide();
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentIDforRoleMaster').find('option').remove().end().append('<option value>-----Select Department-----</option>');
                $('#btnCreate').hide();
            }
        });
        $("#ModuleID").change(function () {
            //alert('ok');
            var selectedItem = $(this).val();
            var AdminRoleMasterID = $('input[name=AdminRoleMasterID]').val();
            // var $ddlModuleID = $("#ModuleID");

            if ($("#ModuleID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AdminRoleMenuDetails/GetListAdminMenuDetails1",

                    data: { ModuleID: selectedItem, AdminRoleMasterID: AdminRoleMasterID },
                    success: function (data) {
                        $('#aaa').html(data);
                        //  $ddlSubElectiveGrpID.html('');
                        // $ddlSubElectiveGrpID.append('<option value="">--Select Sub Elective Group--</option>');
                        // $.each(data, function (id, option) {

                        //    $ddlSubElectiveGrpID.append($('<option></option>').val(option.id).html(option.name));
                        //});
                        // $ddlSubElectiveGrpProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Menu.');
                        // $ddlSubElectiveGrpProgress.hide();
                    }
                });
            }
            else {
                //$('#myDataTable tbody').empty();
                //$('#OrgSubElectiveGrpID').find('option').remove().end().append('<option value>--Sub Elective Group--</option>');
                //$('#btnCreate').hide();
            }
        });
        //$('#SelectedDepartmentIDforRoleMaster').on("change", function () {

        //    var valuCentreCode = $('#SelectedCentreCodeforRoleMaster :selected').val();
        //    var valuDepartmentID = $('#SelectedDepartmentIDforRoleMaster').val();
        //    AdminRoleMenuDetails.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
        //    $('#btnCreate').show();
        //});

        $("#btnShowList").unbind("click").on("click", function () {

            var valuCentreCode = $('#SelectedCentreCodeforRoleMaster :selected').val();
            var valuDepartmentID = $('#SelectedDepartmentIDforRoleMaster :selected').val();
            if (valuCentreCode != "" && valuDepartmentID != "") {
                AdminRoleMenuDetails.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
            }
            else if (valuCentreCode != "" && valuDepartmentID <= 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectDepartment", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select department");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }
            else if ((valuCentreCode == "" && valuDepartmentID <= 0)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }
        });


        $('#SelectedAdminSnPostsID').on("change", function () {

            var centreCodeValue = $('#SelectedCentreCodeforRoleMaster').val();
            var departmentIDValue = $('#SelectedDepartmentIDforRoleMaster').val();
            var adminSnPostsID = $(this).val();
            AdminRoleMenuDetails.LoadListByAdminSnPostsID(centreCodeValue, departmentIDValue, adminSnPostsID);
            $('#btnCreate').show();
        });

        $("#reset").click(function () {

            // $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#ModuleID').focus();
            $('#ModuleID').val("");
            return false;
        });


        $('#SelectedDepartmentID').on("change", function () {
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuDepartmentID = $('#SelectedDepartmentID').val();
            AdminRoleMenuDetails.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
        });


        // Create new record
        $('#CreateAdminRoleMenuDetailsRecord').on("click", function () {

            AdminRoleMenuDetails.ActionName = "Create";
            AdminRoleMenuDetails.getValueUsingParentTag_Check_UnCheck();
            AdminRoleMenuDetails.AjaxCallAdminRoleMenuDetails();
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

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/AdminRoleMenuDetails/List',
             success: function (result) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(result);
                 //$('#btnCreate').hide();
             }
         });
        //  $('#btnCreate').hide();
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        var SelectedCentreCode = $('#SelectedCentreCodeforRoleMaster :selected').val();
        var SelectedDepartmentID = $('#SelectedDepartmentIDforRoleMaster :selected').val();

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "centerCode": SelectedCentreCode, "departmentID": SelectedDepartmentID, "actionMode": actionMode },
            url: '/AdminRoleMenuDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    //ReloadList method is used to load List page
    LoadListByCentreCodeAndDepartmentID: function (SelectedCentreCode, SelectedDepartmentID) {

        var selectedText = $('#SelectedDepartmentIDforRoleMaster').text();
        var selectedVal = $('#SelectedDepartmentIDforRoleMaster').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, departmentID: selectedVal },

              dataType: "html",
              url: '/AdminRoleMenuDetails/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallAdminRoleMenuDetails: function () {
        var AdminRoleMenuDetailsData = null;

        if (AdminRoleMenuDetails.ActionName == "Create") {
            $("#FormCreateAdminRoleMenuDetails").validate();
            if ($("#FormCreateAdminRoleMenuDetails").valid()) {
                AdminRoleMenuDetailsData = null;
                AdminRoleMenuDetailsData = AdminRoleMenuDetails.GetAdminRoleMenuDetails();
                ajaxRequest.makeRequest("/AdminRoleMenuDetails/Create", "POST", AdminRoleMenuDetailsData, AdminRoleMenuDetails.Success);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAdminRoleMenuDetails: function () {

        var Data = {
        };
        if (AdminRoleMenuDetails.ActionName == "Create") {

            Data.ID = $('input[name=ID]').val();
            Data.AdminRoleMasterID = $('input[name=AdminRoleMasterID]').val();
            Data.AdminRoleCode = $('input[name=AdminRoleCode]').val();
            Data.SelectedTreeViewIDs = AdminRoleMenuDetails.SelectedTreeViewIDs;
        }
        return Data;
    },

    getValueUsingParentTag_Check_UnCheck: function () {

        var sList = "";
        var xmlParamList = "<rows>"
        $('#checkboxlist input[type=checkbox]').each(function () {
            if ($(this).val() != "on") {
                var sArray = [];
                sArray = $(this).val().split("~");
                if (this.checked == true && parseInt(sArray[0]) == 0) {
                    //xmlInsert code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[0] + "</ID>" + "<MenuCode>" + sArray[2] + "</MenuCode>" + "<IsActive>1</IsActive>" + "</row>";
                }
                else if (this.checked == false && parseInt(sArray[0]) > 0) {
                    //xmlUpdate code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[0] + "</ID>" + "<MenuCode>" + sArray[2] + "</MenuCode>" + "<IsActive>0</IsActive>" + "</row>";
                }
            }
            AdminRoleMenuDetails.SelectedTreeViewIDs = xmlParamList + "</rows>";
        });
    },
    //this is used to for showing successfully record creation message and reload the list view

    Success: function (data) {

        var splitData = data.split(',');
        if (splitData[1] == "success") {

            $('#Success_Message').html(splitData[0]);
            $('#Success_Message').delay(400).slideDown(400).delay(2500).slideUp(400).css('background-color', '#4CAF50');

        } else if (splitData[1] == "warning") {

            $('#Success_Message').html(splitData[0]);
            $('#Success_Message').delay(400).slideDown(400).delay(2500).slideUp(400).css('background-color', '#FFC107');

        } else if (splitData[1] == "danger") {

            $('#Success_Message').html(splitData[0]);
            $('#Success_Message').delay(400).slideDown(400).delay(2500).slideUp(400).css('background-color', '#F44336');
        }
        
        //$.magnificPopup.close();
        //notify(splitData[0], splitData[1]);
        //parent.$.colorbox.close().delay(400);
    },
};

