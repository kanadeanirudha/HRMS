//this class contain methods related to nationality functionality
var AdminRoleApplicableDetails = {
    //Member variables
    ActionName: null,
    SelectedIDs: null,
    AdditionalRoleFlag: 1,
    //Class intialisation method
    Initialize: function () {
        AdminRoleApplicableDetails.constructor();
    },
    //Attach all event of page
    constructor: function () {

        $("#SelectedCentreCode").change(function () {

            var selectedItem = $(this).val();
            var $ddlDepartments = $("#SelectedDepartmentID");
            var $departmentProgress = $("#states-loading-progress");
            $departmentProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AdminRoleApplicableDetails/GetDepartmentByCentreCode",
                    data: { "SelectedCentreCode": selectedItem },
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

            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>-----Select Department-----</option>');

            }
        });

        //$('#WorkFromDate').prop('readonly', true);

        //$("#WorkFromDate").datepicker({

        //    numberOfMonths: 1,
        //    dateFormat: 'd-M-yy',
        //    minDate: new Date(),
        //});

        $('#WorkFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //minDate: new Date(),
        });

        //$('.form-control_Internal_Row').prop('readonly', true);

        //$(".form-control_Internal_Row").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: "dd-mm-yyyy",
        //    minDate: new Date(),

        //});

        $('.form-control_Internal_Row').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            minDate: new Date(),
        });

        //$('.form-control_WorkToDate').prop('readonly', true);

        //$('.form-control_WorkToDate').datepicker({

        //    numberOfMonths: 1,
        //    dateFormat: "dd-mm-yyyy",
        //    minDate: new Date(),
        //});

        $('.form-control_WorkToDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            minDate: new Date(),
        });

        $('.form-control_Internal_Row').click(function (event) {
            var $this = $(this);
            var rowId = $this.closest("tr").attr("id");
            //  alert(rowId); //return false;              
            $("#WorkFromDate_" + rowId).val();

        });

        //$('.form-control_WorkToDate').click(function (event) {
        //   
        //    var $this=$(this);
        //    alert($this);
        //    var rowId=$this.closest("tr").attr("id");
        //    var arr=($this+'~'+rowId)+($this+'~'+rowId);
        //    alert($this+'~'+rowId);
        //    alert(arr);

        //} 

        //$('#AdminRegularList').on("change", function () {
        //  
        //    var AdminRoleMasterID = $(this).val();
        //    var centreCode = $('input[name=CentreCode]').val();
        //    var departmentId = $('input[name=DepartmentIdWithName]').val();
        //    var empName = $('#empName').val();
        //    var adminRoleCode = $('#AdminRegularList :selected').text();
        //    var workfromDate = $('#WorkFromDate').val();
        //    var empID = $('input[name=EmployeeID]').val();
        //    AdminRoleApplicableDetails.AdditionalRoleFlag = 1;

        //    AdminRoleApplicableDetails.LoadListByAdminRoleMasterID(AdminRoleMasterID, empID, empName, empName, empName, centreCode, departmentId,adminRoleCode);
        //});

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

        //$('#SelectedDepartmentID').on("change", function () {

        //    var valuCentreCode = $('#SelectedCentreCode :selected').val();
        //    var valuDepartmentID = $('#SelectedDepartmentID').val();
        //   // AdminRoleApplicableDetails.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
        //    $('#btnCreate').show();
        //});


        $("#btnShowList").unbind("click").on("click", function () {

            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuDepartmentID = $('#SelectedDepartmentID :selected').val();
            if (valuCentreCode != "" && valuDepartmentID != "") {
                AdminRoleApplicableDetails.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
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

        // Create new record
        $('#CreateAdminRoleApplicableDetailsRecord').on("click", function () {
            //debugger;
            //alert();
            AdminRoleApplicableDetails.ActionName = "Create";

            AdminRoleApplicableDetails.getDataFromDataTable();

            if (AdminRoleApplicableDetails.AdditionalRoleFlag == 0) {
                return false;
            }
            else {
                AdminRoleApplicableDetails.AjaxCallAdminRoleApplicableDetails();
            }
        });

        $('#EditAdminRoleApplicableDetailsRecord').on("click", function () {

            AdminRoleApplicableDetails.ActionName = "Edit";
            AdminRoleApplicableDetails.AjaxCallAdminRoleApplicableDetails();
        });

        $('#DeleteAdminRoleApplicableDetailsRecord').on("click", function () {

            AdminRoleApplicableDetails.ActionName = "Delete";
            AdminRoleApplicableDetails.AjaxCallAdminRoleApplicableDetails();
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        //$("#myCreateDataTable tbody tr td p input[class='CheckBox']").on('click', function () {           
        //    
        //    var $this = $(this);
        //    if ($this.is(":checked")) {
        //        $(this).closest("tr").find('td input[id="WorkFromDate"]').attr("disabled", false);
        //    }
        //    else {
        //        $(this).closest("tr").find('td input[id="WorkFromDate"]').prop('checked', false);
        //        $(this).closest("tr").find('td input[id="WorkFromDate"]').attr("disabled", true);
        //    }
        //    //var compulsaryFlag = $(this).closest("tr").find('td input[id="Compulsary"]').val();
        //    //var splitedCompulsaryFlag = compulsaryFlag.split('~');          
        //});

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
             url: '/AdminRoleApplicableDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
        var SelectedDepartmentID = $('#SelectedDepartmentID :selected').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "centerCode": SelectedCentreCode, "departmentID": SelectedDepartmentID, "actionMode": actionMode },
            url: '/AdminRoleApplicableDetails/List',
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

        var selectedText = $('#SelectedDepartmentID').text();
        var selectedVal = $('#SelectedDepartmentID').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, departmentID: selectedVal },

              dataType: "html",
              url: '/AdminRoleApplicableDetails/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    LoadListByAdminRoleMasterID: function (AdminRoleMasterID, empID, empName, empName, empName, centreCode, departmentId, adminRoleCode) {

        var param = AdminRoleMasterID + "~" + empID + "~" + empName + "~" + empName + "~" + empName + "~" + departmentId + "~" + centreCode + "~" + adminRoleCode;
        //var selectedText = $('#SelectedDepartmentID').text();
        //   var selectedVal = $('#SelectedDepartmentID').val();
        $.ajax(
          {
              cache: false,
              type: "GET",
              data: { ID: param },

              dataType: "html",
              url: '/AdminRoleApplicableDetails/Create',
              success: function (result) {
                  //Rebind Grid Data    

                  // alert(result);

                  $('#FormCreateAdminRoleApplicableDetailsReload').html(result);


              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallAdminRoleApplicableDetails: function () {
        var AdminRoleApplicableDetailsData = null;
        if (AdminRoleApplicableDetails.ActionName == "Create") {
            $("#FormCreateAdminRoleApplicableDetails").validate();
            if ($("#FormCreateAdminRoleApplicableDetails").valid()) {
                AdminRoleApplicableDetailsData = null;
                AdminRoleApplicableDetailsData = AdminRoleApplicableDetails.GetAdminRoleApplicableDetails();
                ajaxRequest.makeRequest("/AdminRoleApplicableDetails/Create", "POST", AdminRoleApplicableDetailsData, AdminRoleApplicableDetails.Success);
            }
        }
        else if (AdminRoleApplicableDetails.ActionName == "Edit") {
            $("#FormEditAdminRoleApplicableDetails").validate();
            if ($("#FormEditAdminRoleApplicableDetails").valid()) {
                AdminRoleApplicableDetailsData = null;
                AdminRoleApplicableDetailsData = AdminRoleApplicableDetails.GetAdminRoleApplicableDetails();
                ajaxRequest.makeRequest("/AdminRoleApplicableDetails/Edit", "POST", AdminRoleApplicableDetailsData, AdminRoleApplicableDetails.Success);
            }
        }
        else if (AdminRoleApplicableDetails.ActionName == "Delete") {
            AdminRoleApplicableDetailsData = null;
            //$("#FormCreateAdminRoleApplicableDetails").validate();
            AdminRoleApplicableDetailsData = AdminRoleApplicableDetails.GetAdminRoleApplicableDetails();
            ajaxRequest.makeRequest("/AdminRoleApplicableDetails/Delete", "POST", AdminRoleApplicableDetailsData, AdminRoleApplicableDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAdminRoleApplicableDetails: function () {
        var Data = {
        };
        if (AdminRoleApplicableDetails.ActionName == "Create") {
            
            // Data.ID = $('input[name=ID]').val();
            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.AdminRoleCode = $('#adminRoleCode').val();
            Data.RoleType = $('input[name=RoleType]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.CentreCodeWithName = $('input[name=CentreCodeWithName]').val();
            Data.SelectedIDs = AdminRoleApplicableDetails.SelectedIDs;
            Data.DepartmentIdWithName = $('input[name=SelectedDepartmentID]').val();
            Data.WorkFromDate = $('#WorkFromDate').val();
            Data.Reason = $('#Reason').val();
        }
        else if (AdminRoleApplicableDetails.ActionName == "Edit") {

            Data.ID = $('input[name=ID]').val();
            Data.CentreCode = $('input[name=SelectedCentreCode]').val();
            Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
            Data.DepartmentIdWithName = $('input[name=SelectedDepartmentID]').val();
            Data.DesignationIdWithName = $('#DesignationIdWithName').val();
            Data.NoOfPosts = $('#NoOfPosts').val();
            Data.IsActive = $('#IsActive').val();
            Data.PostType = $('input[name=PostType]').val();//$('#Posttype').val();
            Data.DesignationType = $('input[name=DesignationType]').val();//$('#Designationtype').val();

        }
        else if (AdminRoleApplicableDetails.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
            Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
            Data.DepartmentIdWithName = $('input[name=SelectedDepartmentID]').val();
        }
        return Data;
    },

    getDataFromDataTable: function () {
        ;
        var DataArray = [];
        var table = $('#myCreateDataTable').DataTable();
        var data = table.$('input').each(function () {
            DataArray.push($(this).val());
        });
        var DatatableData, TotalRecord, TotalRow;
        TotalRecord = DataArray.length;

        var CheckArray = []; var UnCheckArray = [];
        $('#myCreateDataTable input[type=checkbox]').each(function () {
            if (this.checked == true) {
                CheckArray.push($(this).val());
            }
            else if (this.checked == false) {
                UnCheckArray.push($(this).val());
            }
        });

        AdminRoleApplicableCombinationIDs = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 4) {
            var a = [];
            for (var j = 0; j < CheckArray.length; j++) {
                a = CheckArray[j].split('~');
                //  WeeklyData = DataArray[y].split('~');
                if (DataArray[i] == CheckArray[j]) {
                    if (a[0] == 0) {
                        if (a[1] == "Unchecked") {
                            //alert("checked");
                            if (DataArray[i + 1] == '' || DataArray[i + 3] == '') {
                                if (DataArray[i + 1] == '') {
                                    $("#myCreateDataTable tbody tr td p input[id='WorkFromDate_" + a[4] + "']").focus();
                                    AdminRoleApplicableDetails.AdditionalRoleFlag = 0;
                                }
                                if (DataArray[i + 3] == '') {
                                    $("#myCreateDataTable tbody tr td p input[id='Reason_" + a[4] + "']").focus();
                                    AdminRoleApplicableDetails.AdditionalRoleFlag = 0;
                                }
                            }
                            else {
                                if (DataArray[i + 2] == "") {
                                    AdminRoleApplicableCombinationIDs = AdminRoleApplicableCombinationIDs + "<row><ID>" + a[0] + "</ID><AdminRoleMasterID>" + a[4] + "</AdminRoleMasterID><AdminRoleCode>" + a[3] + "</AdminRoleCode><DesignationID>" + a[2] + "</DesignationID><WorkFromDate>" + DataArray[i + 1] + " 00:00:01" + "</WorkFromDate><WorkToDate> </WorkToDate><RoleType>Additional</RoleType><Reason>" + DataArray[i + 3] + "</Reason><IsActive>1</IsActive></row>";
                                }
                                else {
                                    AdminRoleApplicableCombinationIDs = AdminRoleApplicableCombinationIDs + "<row><ID>" + a[0] + "</ID><AdminRoleMasterID>" + a[4] + "</AdminRoleMasterID><AdminRoleCode>" + a[3] + "</AdminRoleCode><DesignationID>" + a[2] + "</DesignationID><WorkFromDate>" + DataArray[i + 1] + " 00:00:01" + "</WorkFromDate><WorkToDate>" + DataArray[i + 2] + " 00:00:01" + "</WorkToDate><RoleType>Additional</RoleType><Reason>" + DataArray[i + 3] + "</Reason><IsActive>1</IsActive></row>";
                                }
                                //alert(AdminRoleApplicableCombinationIDs);
                                AdminRoleApplicableDetails.AdditionalRoleFlag = 1;
                            }
                        }
                    }
                    if (a[0] != 0) {
                        if (a[1] == "checked") {
                            // AdminRoleApplicableCombinationIDs = AdminRoleApplicableCombinationIDs + "<row><ID>" + a[0] + "</ID><AdminRoleMasterID>" + a[4] + "</AdminRoleMasterID><AdminRoleCode>" + a[3] + "</AdminRoleCode><DesignationID>" + a[2] + "</DesignationID><WorkFromDate>" + DataArray[i + 1] + " 00:00:01" + "</WorkFromDate><WorkToDate>" + DataArray[i + 2] + " 00:00:01" + "</WorkToDate><RoleType>Additional</RoleType><Reason>" + DataArray[i + 3] + "</Reason><IsActive>1</IsActive></row>";
                            if (DataArray[i + 2] == "") {
                                AdminRoleApplicableCombinationIDs = AdminRoleApplicableCombinationIDs + "<row><ID>" + a[0] + "</ID><AdminRoleMasterID>" + a[4] + "</AdminRoleMasterID><AdminRoleCode>" + a[3] + "</AdminRoleCode><DesignationID>" + a[2] + "</DesignationID><WorkFromDate>" + DataArray[i + 1] + " 00:00:01" + "</WorkFromDate><WorkToDate> </WorkToDate><RoleType>Additional</RoleType><Reason>" + DataArray[i + 3] + "</Reason><IsActive>1</IsActive></row>";
                            }
                            else {
                                AdminRoleApplicableCombinationIDs = AdminRoleApplicableCombinationIDs + "<row><ID>" + a[0] + "</ID><AdminRoleMasterID>" + a[4] + "</AdminRoleMasterID><AdminRoleCode>" + a[3] + "</AdminRoleCode><DesignationID>" + a[2] + "</DesignationID><WorkFromDate>" + DataArray[i + 1] + " 00:00:01" + "</WorkFromDate><WorkToDate>" + DataArray[i + 2] + " 00:00:01" + "</WorkToDate><RoleType>Additional</RoleType><Reason>" + DataArray[i + 3] + "</Reason><IsActive>1</IsActive></row>";
                            }
                        }
                    }
                }
            }
            for (var j = 0; j < UnCheckArray.length; j++) {
                if (DataArray[i] == UnCheckArray[j]) {
                    var b = UnCheckArray[j].split('~');
                    if (b[0] != 0) {
                        if (b[1] == "checked") {
                            AdminRoleApplicableCombinationIDs = AdminRoleApplicableCombinationIDs + "<row><ID>" + b[0] + "</ID><AdminRoleMasterID>" + b[4] + "</AdminRoleMasterID><AdminRoleCode>" + b[3] + "</AdminRoleCode><DesignationID>" + b[2] + "</DesignationID><WorkFromDate>" + DataArray[i + 1] + " 00:00:01" + "</WorkFromDate><WorkToDate>" + DataArray[i + 2] + " 00:00:01" + "</WorkToDate><RoleType>Additional</RoleType><Reason>" + DataArray[i + 3] + "</Reason><IsActive>0</IsActive></row>";
                        }
                    }
                }
            }
        }

        var id = $('input[name=RoleApplicableID]').val();
        var ARMId = $('input[name=AdminRoleMasterID]').val();
        var ARC = $('#AdminRoleCode').val();
        var DesigId = $('input[name=DesignationID]').val();
        var WFDate = $('#WorkFromDate').val();
        var res = $('#Reason').val();
        //var IsAct = $('input[name=IsActive]:checked').val() ? true : false;
        var IsAct = $('input[id=IsActive]:checked').val() ? true : false;
        
        if (IsAct == false) {
            var IsActive = 0;
        }
        else {
            var IsActive = 1;
        }
        var regular = "<row><ID>" + id + "</ID><AdminRoleMasterID>" + ARMId + "</AdminRoleMasterID><AdminRoleCode>" + ARC + "</AdminRoleCode><DesignationID>" + DesigId + "</DesignationID><WorkFromDate>" + WFDate + " 00:00:01" + "</WorkFromDate><WorkToDate>" + "" + "</WorkToDate><RoleType>Regular</RoleType><Reason>" + res + "</Reason><IsActive>" + IsActive + "</IsActive></row>";

        AdminRoleApplicableDetails.SelectedIDs = AdminRoleApplicableCombinationIDs + regular + "</rows>";
        //  alert(AdminRoleApplicableDetails.SelectedIDs);
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            AdminRoleApplicableDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            AdminRoleApplicableDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

