//this class contain methods related to AdminRoleMaster functionality
var AdminRoleMaster = {
    //Member variables
    ActionName: null,
    SelectedRightsIDs: null,
    IsDefaultRole: null,
    IsCopyForSame: null,
    valSelectedCentreRights: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AdminRoleMaster.constructor();
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
                    url: "/AdminRoleMaster/GetDepartmentByCentreCodeForRoleMaster",
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

        AdminRoleMaster.valSelectedCentreRights = $('#SelectedCentreCode').val();


        $("#btnShowList").unbind("click").on("click", function () {
            // 
            var valuCentreCode = $('#SelectedCentreCodeforRoleMaster :selected').val();
            var valuDepartmentID = $('#SelectedDepartmentIDforRoleMaster :selected').val();
            if (valuCentreCode != "" && valuDepartmentID != "") {
                AdminRoleMaster.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
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
            //  
            var centreCodeValue = $('#SelectedCentreCodeforRoleMaster').val();
            var departmentIDValue = $('#SelectedDepartmentIDforRoleMaster').val();
            var adminSnPostsID = $(this).val();
            AdminRoleMaster.LoadListByAdminSnPostsID(centreCodeValue, departmentIDValue, adminSnPostsID);
            $('#btnCreate').show();
        });

        $('#monitoringlevel').on("change", function () {
            //  
            var monitoringLevel = $('#monitoringlevel').val();
            if (monitoringLevel == "Self") {
                $("#divOtherCentreSelect").fadeOut();
                $("#divSelfCentre").fadeIn();
            }
            else if (monitoringLevel == "Other") {
                $("#divOtherCentreSelect").fadeIn();
                $("#divSelfCentre").fadeOut();
            }
        });

        $("#reset").click(function () {

            $("").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#monitoringlevel').focus();
            //var dt = new Date();
            // document.write("getYear() : " + dt.getYear());
            $('#DesignationIdWithName').val('--Select designation--');
            $('#Posttype').val(0);
            $('#Designationtype').val(0);
            $('#NoOfPosts').val('0');
            $('#monitoringlevel').val('Self');
            $(".ms-choice span").text('');
            $("#divOtherCentreSelect").fadeOut();
            $("#divSelfCentre").fadeIn();

            return false;
        });



        $('#SelectedDepartmentID').on("change", function () {
            //  
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuDepartmentID = $('#SelectedDepartmentID').val();
            AdminRoleMaster.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
        });


        // Create new record
        $('#CreateAdminRoleMasterRecord').on("click", function () {
            //  
            AdminRoleMaster.ActionName = "Create";
            var level = $("#monitoringlevel :selected").val();
            if (level == 'Other') {
                AdminRoleMaster.getValueUsingParentTag_Check_UnCheck();
            } else {
                AdminRoleMaster.getValueSelfMonitor();
            }
            // AdminRoleMaster.getValueofRadioButton();
            AdminRoleMaster.AjaxCallAdminRoleMaster();
        });

        $('#EditAdminRoleMasterRecord').on("click", function () {
            debugger;
            AdminRoleMaster.ActionName = "Edit";
            var level = $("#monitoringlevel :selected").val();
            if (level == 'Other') {
                AdminRoleMaster.getValueUsingParentTag_Check_UnCheck();
            } else {
                AdminRoleMaster.getValueSelfMonitor();
            }

            AdminRoleMaster.getValueofRadioButton();
            AdminRoleMaster.AjaxCallAdminRoleMaster();
        });

        $('#DeleteAdminRoleMasterRecord').on("click", function () {

            AdminRoleMaster.ActionName = "Delete";
            AdminRoleMaster.AjaxCallAdminRoleMaster();
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        //$("#showrecord").change(function () {
        //    var showRecord = $("#showrecord").val();
        //    $("select[name*='myDataTable_length']").val(showRecord);
        //    $("select[name*='myDataTable_length']").change();
        //});

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
             url: '/AdminRoleMaster/List',
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
            url: '/AdminRoleMaster/List',
            success: function (data) {
                //Rebind Grid Data

                $("#ListViewModel").empty();
                $('#ListViewModel').html(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    //ReloadList method is used to load List page
    LoadListByCentreCodeAndDepartmentID: function (SelectedCentreCode, SelectedDepartmentID) {
        // 
        var selectedText = $('#SelectedDepartmentIDforRoleMaster').text();
        var selectedVal = $('#SelectedDepartmentIDforRoleMaster').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, departmentID: selectedVal },

              dataType: "html",
              url: '/AdminRoleMaster/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallAdminRoleMaster: function () {
        var AdminRoleMasterData = null;
        if (AdminRoleMaster.ActionName == "Create") {
            $("#FormCreateAdminRoleMaster").validate();
            if ($("#FormCreateAdminRoleMaster").valid()) {
                AdminRoleMasterData = null;
                AdminRoleMasterData = AdminRoleMaster.GetAdminRoleMaster();
                ajaxRequest.makeRequest("/AdminRoleMaster/Create", "POST", AdminRoleMasterData, AdminRoleMaster.Success);
            }
        }
        else if (AdminRoleMaster.ActionName == "Edit") {
            $("#FormEditAdminRoleMaster").validate();
            if ($("#FormEditAdminRoleMaster").valid()) {
                AdminRoleMasterData = null;
                AdminRoleMasterData = AdminRoleMaster.GetAdminRoleMaster();
                ajaxRequest.makeRequest("/AdminRoleMaster/Edit", "POST", AdminRoleMasterData, AdminRoleMaster.Success);
            }
        }
        else if (AdminRoleMaster.ActionName == "Delete") {
            AdminRoleMasterData = null;
            //$("#FormCreateAdminRoleMaster").validate();
            AdminRoleMasterData = AdminRoleMaster.GetAdminRoleMaster();
            ajaxRequest.makeRequest("/AdminRoleMaster/Delete", "POST", AdminRoleMasterData, AdminRoleMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAdminRoleMaster: function () {

        var Data = {
        };
        if (AdminRoleMaster.ActionName == "Create") {
            // 
            Data.ID = $('input[name=ID]').val();
            Data.CentreCodeWithName = $("#CentreCodeWithName").val();
            Data.AdminSnPostsIDWithName = $("#AdminSnPostsIDWithName").val();
            Data.AdminSnPostID = $('input[name=AdminSnPostID]').val();
            Data.DepartmentIdWithName = $('input[name=DepartmentIdWithName]').val();
            Data.monitoringlevel = $('#monitoringlevel').val();
            //Data.IsSuperUser = $('#IsSuperUser:checked').val() ? true : false;
            //Data.IsFinMgr = $('#IsFinMgr:checked').val() ? true : false;
            //Data.IsEstMgr = $('#IsEstMgr:checked').val() ? true : false;
            //Data.IsAcadMgr = $('#IsAcadMgr:checked').val() ? true : false;
            //Data.IsAdmMgr = $('#IsAdmMgr:checked').val() ? true : false;
            if ($('input[name=DesignationType]').val() == "Active") {
                Data.IsLoginAllowFromOutside = $('input[id=IsLoginAllowFromOutside]:checked').val() ? true : false;
                Data.IsAttendaceAllowFromOutside = $('input[id=IsAttendaceAllowFromOutside]:checked').val() ? true : false;
            }
            else {
                Data.IsLoginAllowFromOutside = false;
                Data.IsAttendaceAllowFromOutside = false;
            }
            Data.CentreCode = $('#CentreCode').val();
            Data.selectItemRightsIDs = AdminRoleMaster.SelectedRightsIDs;
        }
        else if (AdminRoleMaster.ActionName == "Edit") {
            //   
            Data.ID = $('input[name=ID]').val();
            Data.CentreCodeWithName = $('#CentreCodeWithName').text();
            Data.SanctPostName = $('#SanctPostName').val();
            Data.AdminSnPostID = $('input[name=AdminSnPostID]').val();
            Data.DepartmentIdWithName = $('input[name=DepartmentIdWithName]').val();
            Data.monitoringlevel = $('#monitoringlevel').val();
            //if ($('#monitoringlevel').val() == "Self") {
            //    Data.IsSuperUser = $('#IsSuperUser:checked').val() ? true : false;
            //    Data.IsFinMgr = $('#IsFinMgr:checked').val() ? true : false;
            //    Data.IsEstMgr = $('#IsEstMgr:checked').val() ? true : false;
            //    Data.IsAcadMgr = $('#IsAcadMgr:checked').val() ? true : false;
            //    Data.IsAdmMgr = $('#IsAdmMgr:checked').val() ? true : false;
            //}
            //else {
            //    Data.IsSuperUser = false;
            //    Data.IsFinMgr = false;
            //    Data.IsEstMgr = false;
            //    Data.IsAcadMgr = false;
            //    Data.IsAdmMgr = false;
            //}
            Data.IsActive = $('#IsActive:checked').val() ? true : false;            // $('input[name=IsActive]').val();
            if ($('input[name=DesignationType]').val() == "Active") {
                //Data.IsLoginAllowFromOutside = $('input[name=IsLoginAllowFromOutside]:checked').val() ? true : false;
                Data.IsLoginAllowFromOutside = $('input[id=IsLoginAllowFromOutside]:checked').val() ? true : false;
                //Data.IsAttendaceAllowFromOutside = $('input[name=IsAttendaceAllowFromOutside]:checked').val() ? true : false;
                Data.IsAttendaceAllowFromOutside = $('input[id=IsAttendaceAllowFromOutside]:checked').val() ? true : false;
            }
            else {
                Data.IsLoginAllowFromOutside = false;
                Data.IsAttendaceAllowFromOutside = false;
            }
            Data.CentreCode = $('#CentreCode').val();
            Data.selectItemRightsIDs = AdminRoleMaster.SelectedRightsIDs;
        }
        else if (AdminRoleMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
            Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
            Data.DepartmentIdWithName = $('input[name=SelectedDepartmentID]').val();
        }
        return Data;
    },

    //getValueUsingParentTag: function () {
    //    // 
    //    alert("Selected values: " + $("select").multipleSelect("getSelects"));
    //    alert("fdsafa:" + $(".ms-choice").text);
    //    var chkArray = [];
    //    var SelectedRights = "<rows><row><ID>0</ID><CentreCode>"
    //    var SelectedRightsWithCentre = [];
    //    var Number_of_centre;
    //    var temp2 = null;
    //    var xmlParamList = "<rows>"
    //    /* look for all checkboes that have a parent id called 'checkboxlist' attached to it and check if it was checked */
    //    // <rows><row><ID>0</ID><CentreCode>1</CentreCode><IsSuperUser>0</IsSuperUser><IsAcadMgr>1</IsAcadMgr><IsEstMgr>1</IsEstMgr><IsFinMgr>1</IsFinMgr><IsAdmMgr>1</IsAdmMgr><IsActive>1</IsActive></row></rows>


    //    $("#checkboxlist input[type=checkbox]").each(function () {
    //        chkArray.push($(this).val());
    //    });
    //    for (var i = 0; i < chkArray.length; i++) {
    //        var a, e, s, f, ad = null;
    //        var e1 = chkArray[i];
    //        if (e1 != "on") {
    //            var temp = e1.split(":");
    //            if (temp2 != temp[0]) {
    //                if (temp[1] == "IsAcadMgr") {
    //                    var a = 1

    //                }
    //                else {
    //                    var a = 0;
    //                }
    //                if (temp[1] == "IsEstMgr") {
    //                    var e = 1

    //                }
    //                else {
    //                    var e = 0;
    //                }
    //                if (temp[1] == "IsSuperUser") {
    //                    var s = 1

    //                }
    //                else {
    //                    var s = 0;
    //                }
    //                if (temp[1] == "IsFinMgr") {
    //                    var f = 1

    //                }
    //                else {
    //                    var f = 0;
    //                }
    //                if (temp[1] == "IsAdmMgr") {
    //                    var ad = 1

    //                }
    //                else {
    //                    var ad = 0;
    //                }

    //                SelectedRights = SelectedRights + temp[0] + "</CentreCode><IsSuperUser>" + s + "</IsSuperUser><IsAcadMgr>" + a + "</IsAcadMgr><IsEstMgr>" + e + "</IsEstMgr><IsFinMgr>" + f + "</IsFinMgr><IsAdmMgr>" + ad + "</IsAdmMgr><IsActive>0</IsActive></row></rows>" + "," + temp[1];
    //            }
    //            else if (temp2 == temp[0]) {
    //                if (temp[1] == "IsAcadMgr") {
    //                    var a = 1

    //                }
    //                else if (temp[1] == "IsEstMgr") {
    //                    var e = 1

    //                }
    //                else if (temp[1] == "IsSuperUser") {
    //                    var s = 1

    //                }
    //                else if (temp[1] == "IsFinMgr") {
    //                    var f = 1

    //                }
    //                else if (temp[1] == "IsAdmMgr") {
    //                    var ad = 1

    //                }
    //                var d = "</CentreCode><IsSuperUser>" + s + "</IsSuperUser><IsAcadMgr>" + a + "</IsAcadMgr><IsEstMgr>" + e + "</IsEstMgr><IsFinMgr>" + f + "</IsFinMgr><IsAdmMgr>" + ad + "</IsAdmMgr><IsActive>1</IsActive></row>";
    //                //var d = a + e + s + f + ad;
    //                //SelectedRights = SelectedRights + ":" + temp[1];
    //                SelectedRights = d;

    //            }
    //            temp2 = temp[0];
    //        }
    //    }
    //    AdminRoleMaster.SelectedRightsIDs = SelectedRights;
    //},

    getValueSelfMonitor: function () {
        debugger
        AdminRoleMaster.SelectedRightsIDs = '<rows>';
        var DataArray = [];
        var data = $('.SelfRoleRights').each(function () {
            if ($(this).is(":checked")) {
                DataArray.push($(this).val());
                DataArray.push($(this).prev().val());
            }
        });
        var CentreCode = $("#CentreCode").val().split(':');
        
        for (var i = 0; i < DataArray.length; i = i + 2) {
            AdminRoleMaster.SelectedRightsIDs = AdminRoleMaster.SelectedRightsIDs + '<row><ID>' + DataArray[i + 1] + '</ID><CentreCode>' + CentreCode[0] + '</CentreCode><AdminRoleRightTypeID>' + DataArray[i] + '</AdminRoleRightTypeID><IsActive>1</IsActive></row>';
        }

        if (AdminRoleMaster.SelectedRightsIDs.length > 6) {
            AdminRoleMaster.SelectedRightsIDs = AdminRoleMaster.SelectedRightsIDs + "</rows>";
        } else {
            AdminRoleMaster.SelectedRightsIDs = null;
        }
    },

    getValueUsingParentTag_Check_UnCheck: function () {
        debugger
        var sList = "";
        var xmlParamList = "<rows>"
        var DataArray = [];
        var CentreCodeWithCentreName = [];
        var CentreCodeList = $('#SelectedCentreCode').val();
        var DatatableData, AllRecord, TotalRecord, TotalRow;
        AllRecord = CentreCodeList.length;
        //alert(AllRecord);
        //  var TotalRecord = AllRecord / 5;
        for (var i = 0; i < AllRecord;) {
            var CentreCode = CentreCodeList[i];
            var Centre = CentreCode.split('~');
            var found = $.inArray(Centre[0].trim() + ':' + Centre[3].trim() + ':' + Centre[2].trim(), CentreCodeWithCentreName) > -1;
            if (found == false) {
                CentreCodeWithCentreName.push(Centre[0].trim() + ':' + Centre[3].trim() + ':' + Centre[2].trim());
            }
            //alert(CentreCodeWithCentreName);            
            i = i + 1;
        }
        var ccod = [];
        var conStr = "";
        var temp = "";
        var finStr = [];
        var end = "n";
        var k = 0;
        var rec = CentreCodeList[0].split('~');
        var firstRec = rec[3] + '~' + rec[2];
        var allF = 0;
        for (var j = 0; j <= AllRecord;) {
            if (allF == 1) {
                end = "y";
            }
            if (j >= AllRecord) {
                spltStr[3] = 0;
                spltStr[2] = 0;
                spltStr[1] = 0;
                spltStr[0] = 0;
                end = "y";
            } else {
                var spltStr = CentreCodeList[j].split('~');
            }
            //ccod[j] = spltStr[3] + '~' + spltStr[2] + ':' + spltStr[1];
            if (temp == spltStr[3] + '~' + spltStr[2]) {
                //if (spltStr[1] == "IsAcadMgr") {
                //conStr = conStr + ',' + spltStr[1];
                conStr = conStr + ',' + spltStr[1];
                //} else if (spltStr[1] == "IsEstMgr") {
                //    conStr = conStr + ',' + "Esatblishment Manager";
                //} else if (spltStr[1] == "IsFinMgr") {
                //    conStr = conStr + ',' + "Finance Manager";
                //} else if (spltStr[1] == "IsSuperUser") {
                //    conStr = conStr + ',' + "Super User";
                //} else if (spltStr[1] == "IsAdmMgr") {
                //    conStr = conStr + ',' + "Admin  Manager";
                //}

                end = "y";
            } else {
                if (end == "y") {
                    finStr[k] = '[' + conStr + ']';
                    conStr = "";
                    end = "n";
                    k++;
                }
                //conStr = conStr + spltStr[3] + '~' + spltStr[2] + ':' + spltStr[1];
                //if (spltStr[1] == "IsAcadMgr") {
                conStr = conStr + spltStr[3] + '~' + spltStr[2] + ':' + spltStr[1];
                //} else if (spltStr[1] == "IsEstMgr") {
                //    conStr = conStr + spltStr[3] + '~' + spltStr[2] + ':' + "Esatblishment Manager";
                //} else if (spltStr[1] == "IsFinMgr") {
                //    conStr = conStr + spltStr[3] + '~' + spltStr[2] + ':' + "Finance Manager";
                //} else if (spltStr[1] == "IsSuperUser") {
                //    conStr = conStr + spltStr[3] + '~' + spltStr[2] + ':' + "Super User";
                //} else if (spltStr[1] == "IsAdmMgr") {
                //    conStr = conStr + spltStr[3] + '~' + spltStr[2] + ':' + "Admin  Manager";
                //}
                end = "y";
            }
            temp = spltStr[3] + '~' + spltStr[2];
            if (j == 0 && AllRecord > 1) {
                var tm = CentreCodeList[j + 1].split('~');
                var tmpr = tm[3] + '~' + tm[2];
                if (tmpr != temp) {
                    allF = 1;
                }

            }
            j++;
        }

        var final = "";
        for (k = 0; k < finStr.length;) {
            if (k == finStr.length - 1) {
                //final = final + '"' + finStr[k] + '"';
                final = final + finStr[k];
            } else {
                //final = final + '"' + finStr[k] + '"' + ',';
                final = final + finStr[k] + ',';
            }

            k++;
        }

        //     
        AdminRoleMaster.SelectedRightsIDs = '<rows>';
        //var textboxdata = $('.ms-choice').text();
        var textboxdata = final;
        //var textboxdata = "[Mahatma Gandhi Antarrashtriya Hindi VishwaVidyalaya~123]";
        //var textboxdata = "[Mahatma Gandhi Antarrashtriya Hindi VishwaVidyalaya~84:  Academic Manager,  Esatblishment Manager],[School of Language~86:  Academic Manager]";
        var splitedTextboxdata = [];
        splitedTextboxdata = textboxdata.split('],');
        splitedTextboxdataLength = splitedTextboxdata.length;
        var splitedCentre = [];
        for (var i = 0; i < splitedTextboxdataLength; i++) {
            if (splitedTextboxdata[i].indexOf(':') === -1) {
                splitedCentre = splitedTextboxdata[i].replace('[', '').replace(']', '').split('~');
                var CentreCode = '';
                var ID = '';
                //
                for (j = 0; j < splitedTextboxdataLength; j++) {
                    var splitedCentreCodeWithCentreName = CentreCodeWithCentreName[j].split(':');
                    if (splitedCentreCodeWithCentreName[1] == splitedCentre[0].trim()) {
                        CentreCode = splitedCentreCodeWithCentreName[0];
                        ID = splitedCentreCodeWithCentreName[2];

                    }
                }

                var splitedSelectedRoles = splitedCentre[1].split(':');
                RoleRightTypeID = splitedSelectedRoles[1].split(',');
                for (k = 0; k < RoleRightTypeID.length; k++) {
                    AdminRoleMaster.SelectedRightsIDs = AdminRoleMaster.SelectedRightsIDs + '<row><ID>' + splitedSelectedRoles[0] + '</ID><CentreCode>' + CentreCode + '</CentreCode><AdminRoleRightTypeID>' + RoleRightTypeID[k] + '</AdminRoleRightTypeID><IsActive>1</IsActive></row>';
                }
                // j = j + 1;
            }
            else {
                var SC = splitedTextboxdata[i].split(':');
                spiltedCentre = SC[0].replace('[', '').replace(']', '').split('~');
                splitedCentre = splitedTextboxdata[i].replace('[', '').replace(']', '').split('~');
                var CentreCode = '';
                var ID = '';
                var splitedSelectedRoles = splitedCentre[1].split(':');
                RoleRightTypeID = splitedSelectedRoles[1].split(',');
                //
                for (j = 0; j < splitedTextboxdataLength; j++) {
                    var splitedCentreCodeWithCentreName = CentreCodeWithCentreName[j].split(':');
                    if (splitedCentreCodeWithCentreName[1] == splitedCentre[0].trim()) {
                        CentreCode = splitedCentreCodeWithCentreName[0];
                        ID = splitedCentreCodeWithCentreName[2];

                    }
                }

                //var IsSuper = 0, IsAcad = 0, IsEst = 0, IsAdm = 0, IsFin = 0;
                //if (SC[1].indexOf('Super User') != -1) {
                //    IsSuper = 1;
                //}
                //if (SC[1].indexOf('Academic Manager') != -1) {
                //    IsAcad = 1;
                //}
                //if (SC[1].indexOf('Esatblishment Manager') != -1) {
                //    IsEst = 1;
                //}
                //if (SC[1].indexOf('Admin  Manager') != -1) {
                //    IsAdm = 1;
                //}
                //if (SC[1].indexOf('Finance Manager') != -1) {
                //    IsFin = 1;
                //}

                for (k = 0; k < RoleRightTypeID.length; k++) {
                    AdminRoleMaster.SelectedRightsIDs = AdminRoleMaster.SelectedRightsIDs + '<row><ID>' + splitedSelectedRoles[0] + '</ID><CentreCode>' + CentreCode + '</CentreCode><AdminRoleRightTypeID>' + RoleRightTypeID[k] + '</AdminRoleRightTypeID><IsActive>1</IsActive></row>';
                }
            }

            //i = i + 1;
        }

        // var count = $(".optgroup").length;
        //var SelectGrp = $('.group').children().length();
        //  alert("Selected values: " + $("#SelectedCentreCode").multipleSelect("getxmlSelects"))
        //var XMLstring = '';

        //  
        //------------------------------- block for removing all rights in case of update role---------------------------------------

        //if (AdminRoleMaster.ActionName == "Edit") {
        //    //  alert(AdminRoleMaster.valSelectedCentreRights);
        //    var a = AdminRoleMaster.valSelectedCentreRights;
        //    if (a != null) {
        //        var splitedvalSelectedCentreRights = [];
        //        splitedvalSelectedCentreRights = String(a).split(',');
        //        TotalRecord = splitedvalSelectedCentreRights.length;

        //        for (var k = 0; k < TotalRecord;) {
        //            if (splitedvalSelectedCentreRights[k].indexOf('~') != -1) {
        //                var splitedCentreCode = splitedvalSelectedCentreRights[k].split('~');
        //                var existingCentreCode = splitedCentreCode[2];
        //                if (AdminRoleMaster.SelectedRightsIDs.indexOf(splitedCentreCode[2]) === -1) {
        //                    var IsSuper = 0, IsAcad = 0, IsEst = 0, IsAdm = 0, IsFin = 0;
        //                    if (splitedvalSelectedCentreRights[k].indexOf('IsSuperUser') != -1) {
        //                        IsSuper = 1;
        //                    }
        //                    if (splitedvalSelectedCentreRights[k].indexOf('IsAcadMgr') != -1) {
        //                        IsAcad = 1;
        //                    }
        //                    if (splitedvalSelectedCentreRights[k].indexOf('IsEstMgr') != -1) {
        //                        IsEst = 1;
        //                    }
        //                    if (splitedvalSelectedCentreRights[k].indexOf('IsAdmMgr') != -1) {
        //                        IsAdm = 1;
        //                    }
        //                    if (splitedvalSelectedCentreRights[k].indexOf('IsFinMgr') != -1) {
        //                        IsFin = 1;
        //                    }
        //                    //
        //                    AdminRoleMaster.SelectedRightsIDs = AdminRoleMaster.SelectedRightsIDs + '<row><ID>' + splitedCentreCode[2] + '</ID><CentreCode>' + splitedCentreCode[0] + '</CentreCode><IsSuperUser>' + IsSuper + '</IsSuperUser><IsAcadMgr>' + IsAcad + '</IsAcadMgr><IsEstMgr>' + IsEst + '</IsEstMgr><IsFinMgr>' + IsFin + '</IsFinMgr><IsAdmMgr>' + IsAdm + '</IsAdmMgr><IsActive>0</IsActive></row>';
        //                }
        //            }
        //            k = k + 1;
        //        }
        //    }
        //    //XMLstring = $("#SelectedCentreCode").multipleSelect("getxmlSelects");
        //    // AdminRoleMaster.SelectedRightsIDs = AdminRoleMaster.SelectedRightsIDs + XMLstring;
        //}
        //var x = (XMLstring.toString()).replace(',', ' ');
        //var y = [];
        //y = x.split(",");     

        // AdminRoleMaster.SelectedRightsIDs = "<rows>" + y[0] + "</rows>";
        if (AdminRoleMaster.SelectedRightsIDs.length > 6) {
            AdminRoleMaster.SelectedRightsIDs = AdminRoleMaster.SelectedRightsIDs + "</rows>";
        } else {
            AdminRoleMaster.SelectedRightsIDs = null;
        }
        // alert(AdminRoleMaster.SelectedRightsIDs);
    },

    getValueofRadioButton: function () {
        //

        var IsDefaultVal = $("input[name=IsDefaultRole]:checked").val();

        if (IsDefaultVal == 'True') {
            AdminRoleMaster.IsDefaultRole = true;
            AdminRoleMaster.IsCopyForSame = false;
        }
        else if (IsDefaultVal == 'False') {
            AdminRoleMaster.IsDefaultRole = false;
            AdminRoleMaster.IsCopyForSame = true;
        }

    },

    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            AdminRoleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            AdminRoleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

