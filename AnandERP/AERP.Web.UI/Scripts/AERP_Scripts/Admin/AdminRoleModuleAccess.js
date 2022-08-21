//this class contain methods related to AdminRoleModuleAccess functionality
var AdminRoleModuleAccess = {
    //Member variables
    ActionName: null,
    SelectedRightsIDs: null,
    selected: [],
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AdminRoleModuleAccess.constructor();
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
                    url: "/AdminRoleModuleAccess/GetDepartmentByCentreCodeForRoleMaster",
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

        $("#AccessibleCentreCode").change(function () {

            var selectedItem = $(this).val();
            var ADM_RM_ID = $('input[name=AdminRoleMasterID]').val();
            var splited_ADM_RM_ID = ADM_RM_ID.split(":");
            var AdminRoleMasterID = splited_ADM_RM_ID[3];
            var MonitoringLevel = $('input[name=MonitoringLevel]').val();
            var EntityType = $('input[name=EntityType]').val();
            var $ddlEntity = $("#EntityType");
            var $entityProgress = $("#entity-loading-progress");
            $entityProgress.show();
            if ($("#AccessibleCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AdminRoleModuleAccess/GetEntityByCentreCode",
                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
                    data: { "AdminRoleMasterID": AdminRoleMasterID, "AccessibleCentreCode": selectedItem, "MonitoringLevel": MonitoringLevel, "EntityType": EntityType },
                    success: function (data) {
                        $ddlEntity.html('');
                        $ddlEntity.append('<option value="">---Select Entity---</option>');
                        $.each(data, function (id, option) {

                            $ddlEntity.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $entityProgress.hide();

                    },

                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                        $entityProgress.hide();
                        $('#btnCreate').hide();
                    }
                });
                $('#btnCreate').hide();
            }
            else {
                $('#myDataTable tbody').empty();
                $('#EntityType').find('option').remove().end().append('<option value>---Select Entity---</option>');
                $('#btnCreate').hide();
            }
        });

        //$('#SelectedDepartmentIDforRoleMaster').on("change", function () {

        //    var valuCentreCode = $('#SelectedCentreCodeforRoleMaster :selected').val();
        //    var valuDepartmentID = $('#SelectedDepartmentIDforRoleMaster').val();
        //    AdminRoleModuleAccess.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
        //    $('#btnCreate').show();
        //});


        $("#btnShowList").unbind("click").on("click", function () {

            var valuCentreCode = $('#SelectedCentreCodeforRoleMaster :selected').val();
            var valuDepartmentID = $('#SelectedDepartmentIDforRoleMaster :selected').val();
            if (valuCentreCode != "" && valuDepartmentID != "") {
                AdminRoleModuleAccess.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
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
            AdminRoleModuleAccess.LoadListByAdminSnPostsID(centreCodeValue, departmentIDValue, adminSnPostsID);
            $('#btnCreate').show();
        });

        $('#monitoringlevel').on("change", function () {

            var monitoringLevel = $('#monitoringlevel').val();
            if (monitoringLevel == "Self") {
                $("#divOtherCentreSelect").hide();
            }
            else if (monitoringLevel == "Other") {
                $("#divOtherCentreSelect").show();
            }
        });

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#DesignationIdWithName').focus();

            $('#DesignationIdWithName').val('--Select designation--');
            $('#Posttype').val(0);
            $('#Designationtype').val(0);
            $('#NoOfPosts').val('0');
            return false;
        });


        $('#SelectedDepartmentID').on("change", function () {

            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuDepartmentID = $('#SelectedDepartmentID').val();
            AdminRoleModuleAccess.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
        });

        $('#EntityType').on("change", function () {

            var accessibleCentreCode = $('#AccessibleCentreCode').val();
            var accessibleCentreName = $('#AccessibleCentreCode :selected').text();
            var MonitoringLevel = $('input[name=MonitoringLevel]').val();
            var valEntityType = $('#EntityType option:selected').text();
            var valEntityTypeID = $('#EntityType').val();
            // var AdminRoleMasterID = $('input[name=AdminRoleMasterID]').val();
            var ADM_RM_ID = $('input[name=AdminRoleMasterID]').val();
            var splited_ADM_RM_ID = ADM_RM_ID.split(":");
            var AdminRoleMasterID = splited_ADM_RM_ID[3];
            AdminRoleModuleAccess.LoadListByEntityType(accessibleCentreCode, MonitoringLevel, valEntityTypeID, AdminRoleMasterID, accessibleCentreName);
            //$('#AccessibleCentreList option:selected') = accessibleCentreCode;
            //$('#AccessibleCentreList option:selected').text = accessibleCentreName;
        });

        $('#myCreateDataTable').on('click', 'checkbox', function () {

            var id = this.id;
            var index = $.inArray(id, AdminRoleModuleAccess.selected);

            if (index === -1) {
                AdminRoleModuleAccess.selected.push(id);
            } else {
                AdminRoleModuleAccess.selected.splice(index, 1);
            }

            $(this).toggleClass('selected');
            // alert(AdminRoleModuleAccess.selected);
        });


        // Create new record
        $('#CreateAdminRoleModuleAccessRecord').on("click", function () {
            debugger;
            AdminRoleModuleAccess.ActionName = "Create";
            //AdminRoleModuleAccess.getValueUsingParentTag_Check_UnCheck1();
            AdminRoleModuleAccess.getDataFromDataTable1();
            if (AdminRoleModuleAccess.SelectedRightsIDs != "<rows></rows>") {
                AdminRoleModuleAccess.AjaxCallAdminRoleModuleAccess();
            }
            else {

                if ($('#EntityType').val() == "BALSHEET") {
                    $('#update-message').html("Please select balancesheet");
                }
                else if ($('#EntityType').val() == "COURSEYEAR") {
                    $('#update-message').html("Please select course year");
                }
                else if ($('#EntityType').val() == "DEPARTMENT") {
                    $('#update-message').html("Please select department");
                }
                else if ($('#EntityType').val() == "SECTION") {
                    $('#update-message').html("Please select Section");
                }
                else if ($('#EntityType').val() == "STORE") {
                    $('#update-message').html("Please select store");
                }
                $('#update-message').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', '#f89406');
            }
        });

        $('#EditAdminRoleModuleAccessRecord').on("click", function () {

            AdminRoleModuleAccess.ActionName = "Edit";
            AdminRoleModuleAccess.AjaxCallAdminRoleModuleAccess();
        });

        $('#DeleteAdminRoleModuleAccessRecord').on("click", function () {

            AdminRoleModuleAccess.ActionName = "Delete";
            AdminRoleModuleAccess.AjaxCallAdminRoleModuleAccess();
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


        //$('#myCreateDataTable').on("click", ".chkStatus_TF", function (event) {

        //    var $this = $(this);
        //    if ($this.is(":checked")) {

        //        $this.closest("tr").find(":input.CheckBox1").attr("disabled", false);
        //        $this.closest("tr").find(":input.CheckBox2").attr("disabled", false);
        //        //$this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", false);
        //        //$this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", false);
        //    }
        //    else {
        //        $this.closest("tr").find(":input.CheckBox1").attr("disabled", true);
        //        $this.closest("tr").find(":input.CheckBox2").attr("disabled", true);

        //        $this.closest("tr").find(":input.CheckBox1").attr("checked", false);
        //        $this.closest("tr").find(":input.CheckBox2").attr("checked", false);
        //    }
        //});

    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/AdminRoleModuleAccess/List',
             success: function (result) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(result);

             }
         });

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
            url: '/AdminRoleModuleAccess/List',
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
              data: { centerCode: SelectedCentreCode, departmentID: SelectedDepartmentID },

              dataType: "html",
              url: '/AdminRoleModuleAccess/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    // method is used to load entity List on create page
    LoadListByEntityType: function (accessibleCentreCode, monitoringLevel, valEntityType, AdminRoleMasterID, accessibleCentreName) {

        $.ajax(
          {
              cache: false,
              type: "GET",

              data: { AdminRoleMasterID: accessibleCentreCode + ':' + monitoringLevel + ':' + valEntityType + ':' + AdminRoleMasterID },

              dataType: "html",
              // url: '/AdminRoleModuleAccess/GetAdminEntityIndividualList',
              url: '/AdminRoleModuleAccess/Create',
              success: function (result) {
                  //Rebind Grid Data  
                  //  alert(result);
                  $('#createSpecialRights').html(result);

                  //$('#AccessibleCentreList selected').text = accessibleCentreName;
              }
          });
    },



    //////////////  Load List by AdminSnPostID////////////////////
    //////////////This functionality is now scraped///////////////
    /*
    LoadListByAdminSnPostsID: function(SelectedCentreCode, SelectedDepartmentID, SelectedAdminSnPostsID) {
        var selectedText = $('#SelectedAdminSnPostsID').text();
        var selectedVal = $('#SelectedAdminSnPostsID').val();
        $.ajax(
            {
                cache: false,
                type: "POST",
                data: { centerCode: SelectedCentreCode, departmentID: SelectedDepartmentID, adminSnPostsID: SelectedAdminSnPostsID },

                dataType: "html",
                url: '/AdminRoleModuleAccess/List',
                success: function (data) {
                    //Rebind Grid Data
                    $('#ListViewModel').html(data);
                   // $('#btnCreate').show();
                   
                }
            });
    },*/

    //Fire ajax call to insert update and delete record
    AjaxCallAdminRoleModuleAccess: function () {

        var AdminRoleModuleAccessData = null;
        if (AdminRoleModuleAccess.ActionName == "Create") {

            $("#FormCreateAdminRoleModuleAccess").validate();
            if ($("#FormCreateAdminRoleModuleAccess").valid()) {
                AdminRoleModuleAccessData = null;
                AdminRoleModuleAccessData = AdminRoleModuleAccess.GetAdminRoleModuleAccess();
                ajaxRequest.makeRequest("/AdminRoleModuleAccess/Create", "POST", AdminRoleModuleAccessData, AdminRoleModuleAccess.Success);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAdminRoleModuleAccess: function () {

        var Data = {
        };
        if (AdminRoleModuleAccess.ActionName == "Create") {
            //debugger;
            //alert($('input[id=IsActive]').val());
            var ARMId = $('input[name=AdminRoleMasterID]').val();
            var splitedARMId = ARMId.split(':');
            Data.AdminRoleMasterID = splitedARMId[3];
            Data.AdminRoleCode = $('input[name=AdminRoleCode]').val();
            Data.IsActive = $('#IsActive:checked').val() ? true : false;
            //Data.IsActive = $('input[id=IsActive]').val() ? true : false;
            //Data.AccessibleCentreCode = $('input[name=AccessibleCentreCode]').val();
            Data.AccessibleCentreCode = $('#AccessibleCentreCode :selected').val();
            Data.EntityType = $('input[name=Entity]').val();
            Data.IDs = AdminRoleModuleAccess.SelectedRightsIDs;
            Data.CentreCode = $('#CentreCode').val();
            Data.CentreCodeWithName = $('input[name=CentreCodeWithName]').val();
            Data.DepartmentIdWithName = $('input[name=DepartmentIdWithName]').val();
        }
        //else if (AdminRoleModuleAccess.ActionName == "Edit") {

        //    Data.ID = $('input[name=ID]').val();
        //    Data.CentreCodeWithName = $('#CentreCodeWithName').text();
        //    Data.SanctPostName = $('#AdminSnPostsIDWithName').text();
        //    Data.AdminSnPostID = $('input[name=AdminSnPostID]').val();
        //    Data.DepartmentIdWithName = $('input[name=DepartmentIdWithName]').val();
        //    Data.monitoringlevel = $('#monitoringlevel').val();
        //    Data.IsSuperUser = $('#IsSuperUser:checked').val() ? true : false;
        //    Data.IsFinMgr = $('#IsFinMgr:checked').val() ? true : false;
        //    Data.IsEstMgr = $('#IsEstMgr:checked').val() ? true : false;
        //    Data.IsAcadMgr = $('#IsAcadMgr:checked').val() ? true : false;
        //    Data.IsAdmMgr = $('#IsAdmMgr:checked').val() ? true : false;
        //    Data.IsActive = $('input[name=IsActive]').val();
        //    Data.IsDefaultRole = $('#IsDefaultRole').val();
        //    Data.CentreCode = $('#CentreCode').val();
        //}
        //else if (AdminRoleModuleAccess.ActionName == "Delete") {
        //    Data.ID = $('input[name=ID]').val();
        //    Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
        //    Data.DepartmentIdWithName = $('input[name=SelectedDepartmentID]').val();
        //}
        return Data;
    },

    //this is used to for creating xml of record creation 
    getDataFromDataTable1: function () {

        var AdminRoleModuleAccessCombinationIDs = "<rows>";
        $('#myCreateDataTable input[class=chkStatus_TF]').each(function () {
            if (this.checked == true) {
                var aaa = [];
                aaa = $(this).val().split('~');

                AdminRoleModuleAccessCombinationIDs = AdminRoleModuleAccessCombinationIDs + "<row><SourceID>" + aaa[0] + "</SourceID><centreCode>" + aaa[2] + "</centreCode><AdminRoleDetailsID>" + aaa[1] + "</AdminRoleDetailsID></row>"
            }
        });

        if (AdminRoleModuleAccessCombinationIDs.length > 6)
            AdminRoleModuleAccess.SelectedRightsIDs = AdminRoleModuleAccessCombinationIDs + "</rows>";
        else
            AdminRoleModuleAccess.SelectedRightsIDs = "";
        
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            AdminRoleModuleAccess.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            AdminRoleModuleAccess.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

