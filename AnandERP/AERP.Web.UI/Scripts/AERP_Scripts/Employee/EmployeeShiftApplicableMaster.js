//this class contain methods related to nationality functionality
var EmployeeShiftApplicableMaster = {
    //Member variables
    ActionName: null,
    EmpShiftMasterID: null,
    SelectedXMLstring :null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeShiftApplicableMaster.constructor();
        //EmployeeShiftApplicableMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CountryName').focus();

        $("#reset").click(function () {
           
            $('#EmployeeShiftMasterID').focus();
            $('#EmployeeShiftMasterID').val("");
            $('#ShiftStartDate').val("");
            return false;
        });

        //$('#ShiftStartDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //    minDate: "0D",
        //    onClose: function (selectedDate) {
        //        $("#ShiftEndDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        //$('#ShiftEndDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',

        //})
       
          
        $(function(){

            $('#ShiftStartDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
                //defaultDate: new Date(),
            });

            $("#ShiftEndDate").datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
            })

            $('#ShiftStartDate').on('dp.hide', function (e) {
                var minDate = new Date(e.date.valueOf());
                minDate.setDate(minDate.getDate());
                $("#ShiftEndDate").data("DateTimePicker").minDate(minDate);

            })

            $('#EmployeeShistApplicableMasterFromDate').datetimepicker({
                format: 'DD MMM YYYY',
                minDate: moment(),
                ignoreReadonly: true,
            })
    
    
        });

        // Create new record
        $('#CreateEmployeeShiftApplicableMasterRecord').on("click", function () {           
            
            EmployeeShiftApplicableMaster.ActionName = "Create";
            switch (parseInt($("#WeeklyOffConsideration").val())) {
                case 0:
                    EmployeeShiftApplicableMaster.AjaxCallEmployeeShiftApplicableMaster();
                    break;
                case 1:
                    EmployeeShiftApplicableMaster.GetWeekDays();
                    if (EmployeeShiftApplicableMaster.SelectedXMLstring != null) {
                        EmployeeShiftApplicableMaster.AjaxCallEmployeeShiftApplicableMaster();
                    }
                    else {
                        ajaxRequest.ErrorMessageForJS("JsValidationMessages_Daysmustbeselected", "SuccessMessageShiftDetails", "#FFCC80");
                        //$('#SuccessMessageShiftDetails').html("Days must be selected");
                        //$('#SuccessMessageShiftDetails').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                    }
                    break;
                default:
                    return false;
            }
        });

        $('#EditEmployeeShiftApplicableMasterRecord').on("click", function () {
            EmployeeShiftApplicableMaster.ActionName = "Edit";
            switch (parseInt($("#WeeklyOffConsideration").val())) {
                case 0:
                    EmployeeShiftApplicableMaster.AjaxCallEmployeeShiftApplicableMaster();
                    break;
                case 1:
                    EmployeeShiftApplicableMaster.GetWeekDays();
                    if (EmployeeShiftApplicableMaster.SelectedXMLstring != null) {
                        EmployeeShiftApplicableMaster.AjaxCallEmployeeShiftApplicableMaster();
                    }
                    else {
                        ajaxRequest.ErrorMessageForJS("JsValidationMessages_Daysmustbeselected", "SuccessMessageShiftDetails", "#FFCC80");
                        //$('#SuccessMessageShiftDetails').html("Days must be selected");
                        //$('#SuccessMessageShiftDetails').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                    }
                    break;
                default:
                    return false;
            }
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

        $("#CentreCode").change(function () {
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            
        });

        $("#CentreCode").change(function () {
            debugger
            var selectedItem = $(this).val();
            var $ddlDepartments = $("#DepartmentID");
            var $departmentProgress = $("#states-loading-progress");
            $departmentProgress.show();
            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeShiftApplicableMaster/GetDepartmentByCentreCode",
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
                $('#DepartmentID').find('option').remove().end().append('<option value>---Select Department---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#ShowList").unbind("click").click(function () {
            debugger
            var SelectedCentreCode = $('#CentreCode').val();
            var SelectedCentreName = $('#CentreCode option:selected').text();
            var SelectedDepartmentID = $('#DepartmentID').val();
            var SelectedDepartmentName = $('#DepartmentID option:selected').text();

            if (SelectedCentreCode != "") {
                if (SelectedDepartmentID != "") {
                    $.ajax(
                 {
                     cache: false,
                     type: "POST",
                     data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName, departmentId: SelectedDepartmentID, departmentName: SelectedDepartmentName },

                     dataType: "html",
                     url: '/EmployeeShiftApplicableMaster/List',
                     success: function (result) {
                         //Rebind Grid Data                
                         $('#ListViewModel').html(result);
                         $('#CentreCode').val(SelectedCentreCode);
                         $('#DepartmentID').val($('input[name=SelectedDepartmentID]').val() + ":" + SelectedDepartmentName);
                         // $('#Createbutton').show();
                     }
                 });
                }
                else {
                    EmployeeShiftApplicableMaster.ReloadList("Please select Department Name", "warning", null);
                    //   $('#Createbutton').hide();
                }
            }
            else {
                EmployeeShiftApplicableMaster.ReloadList("Please select centre", "warning", null);
                //   $('#Createbutton').hide();
            }
        });

        $('#EmployeeShiftDescription').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
       
        $("#EmployeeShiftMasterID option").click(function (e) {
            var $target = $(e.target);
            if ($target.is('option')) {
                //alert($target.attr("id"));//Will alert id if it has id attribute
                //Will alert the text of the option
                EmployeeShiftApplicableMaster.EmpShiftMasterID = $target.val();//Will alert the value of the option              
            }
        });
       
        EmployeeShiftApplicableMaster.LoadShiftDetails();
        $("#EmployeeShiftMasterID").on("change", function () {
            ShiftMasterID = $('#EmployeeShiftMasterID').val();

            if (ShiftMasterID.split('~')[0] != 0 && ShiftMasterID != null) {
               
                $.ajax(
                {
                    cache: false,
                    type: "GET",
                    data: { EmployeeShiftMasterID: ShiftMasterID.split('~')[0] },

                    dataType: "html",
                    url: '/EmployeeShiftApplicableMaster/_ShiftDetails',
                    success: function (result) {
                        //Rebind Grid Data         

                        // document.getElementById("EmployeeShiftApplicableMasterBox").style.height = "680px";
                        $('#ShiftDetailsDataTable').show();
                        $('#ShiftDetailsDataTable').html(result);
                    }
                });
            }
        })
       
        if ($("#WeeklyOffConsideration").val() == 1) {
            $("#weekDaysList").show;
            $("#FromDate").css("display", "none");
            $("#EmployeeShiftMasterID").attr('disabled','disabled');
        }
        else {
            $("#weekDaysList").css("display", "none");
            $("#FromDate").show;
        }
        $("#WeeklyOffConsideration").on("change", function () {
            if ($(this).val() == 0) {
                $("#weekDaysList").css("display", "none");
                $("#EmployeeShiftMasterID").removeAttr('disabled');
                $("#FromDate").show();
            }
            else {
                $("#weekDaysList").show();
                $("#EmployeeShiftMasterID").attr('disabled', 'disabled');
                $("#FromDate").css("display", "none");
                $("#FromDate").val("");
            }
        })
    },

    LoadShiftDetails :function () {
        var ShiftMasterID=0;
        ShiftMasterID = $('#EmployeeShiftMasterID').val();
        if ( ShiftMasterID != null) {
         
            $.ajax(
            {
                cache: false,
                type: "GET",
                data: { EmployeeShiftMasterID: ShiftMasterID.split('~')[0] },

                dataType: "html",
                url: '/EmployeeShiftApplicableMaster/_ShiftDetails',
                success: function (result) {
                    //Rebind Grid Data         

                   // document.getElementById("EmployeeShiftApplicableMasterBox").style.height = "680px";
                    $('#ShiftDetailsDataTable').show();
                    $('#ShiftDetailsDataTable').html(result);
                }
            });
        }
    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/EmployeeShiftApplicableMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger
        var SelectedCentreCode = $('#CentreCode').val();       
        var SelectedCentreName = $('#CentreCode :selected').text();
        var SelectedDepartmentID = $('#DepartmentID').val();
        var SelectedDepartmentName = $('#DepartmentID :selected').text();
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, centerCode: SelectedCentreCode, centreName: SelectedCentreName, departmentId: SelectedDepartmentID, departmentName: SelectedDepartmentName },
            url: '/EmployeeShiftApplicableMaster/List',
            success: function (data) {
                //Rebind Grid Data
                debugger;
                $("#ListViewModel").empty().append(data);
                  $('#CentreCode').val(SelectedCentreCode);                    
                     
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                  notify(message, colorCode);
            }
        });
    },

    //ReloadList method is used to load List page
    ReloadShiftMasterDetailsList: function (message, colorCode, actionMode) {
      
        //$('#SuccessMessageShiftDetails').html(message);
        //$('#SuccessMessageShiftDetails').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
        notify(message, colorCode);
        //    }
        //});
    },

    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeShiftApplicableMaster: function () {
        var EmployeeShiftApplicableMasterData = null;
        if (EmployeeShiftApplicableMaster.ActionName == "Create") {
            $("#FormCreateEmployeeShiftApplicableMaster").validate();
            if ($("#FormCreateEmployeeShiftApplicableMaster").valid()) {
                EmployeeShiftApplicableMasterData = null;
                EmployeeShiftApplicableMasterData = EmployeeShiftApplicableMaster.GetEmployeeShiftApplicableMaster();                
                ajaxRequest.makeRequest("/EmployeeShiftApplicableMaster/Create", "POST", EmployeeShiftApplicableMasterData, EmployeeShiftApplicableMaster.Success);
            }
        }
        else if (EmployeeShiftApplicableMaster.ActionName == "Edit") {
            $("#FormEditEmployeeShiftApplicableMaster").validate();
            if ($("#FormEditEmployeeShiftApplicableMaster").valid()) {
                EmployeeShiftApplicableMasterData = null;
                EmployeeShiftApplicableMasterData = EmployeeShiftApplicableMaster.GetEmployeeShiftApplicableMaster();
                ajaxRequest.makeRequest("/EmployeeShiftApplicableMaster/Edit", "POST", EmployeeShiftApplicableMasterData, EmployeeShiftApplicableMaster.Success);
            }
        }
       
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeShiftApplicableMaster: function () {
        debugger;
        var Data = {
        };
        if (EmployeeShiftApplicableMaster.ActionName == "Create" || EmployeeShiftApplicableMaster.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.SelectedShiftAndCentreAllocationID = $('#EmployeeShiftMasterID').val();           
            Data.RotationDays = $('#RotationDays').val();
            if (EmployeeShiftApplicableMaster.ActionName == "Create") {
                Data.ShiftStartDate = $('#ShiftStartDate').val();
            }
            else  {
                Data.ShiftStartDate = '1975-01-01';
            }
            Data.ShiftEndDate = $('#ShiftEndDate').val();
            Data.WeeklyOffConsideration = $("#WeeklyOffConsideration").val();
            Data.EmployeeShistApplicableMasterFromDate = $("#EmployeeShistApplicableMasterFromDate").val();
            //Data.IsActive = $('#IsActive').is(":checked") ? "true" : "false";
            Data.XmlWeekDaysString = EmployeeShiftApplicableMaster.SelectedXMLstring;
        }  
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var splitData = data.split(',');

        if (data != null) {

            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeShiftApplicableMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {

            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeShiftApplicableMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //Method to create xml of Selected Criteria Param  
    GetWeekDays: function () {
        debugger;
        var xmlParamList = "<rows>"
        var selectedDays = $("select[name=genralWeekDay]").val().toString();
        if ($("#checkboxlist1").val() != null && $("#checkboxlist1").val() != "") {
            DataArray = selectedDays.split(',');
        }

        var TotalRecord = selectedDays.split(',').length;
      
        for (var i = 0; i < TotalRecord; i++) {
            debugger;
            //EmployeeEmailXML = EmployeeEmailXML + "<row><ID>0</ID><ToUserIDs>3</ToUserIDs><ToMailIDs>AA@test.com</ToMailIDs></row>";

            if (DataArray[i] != "") {
                xmlParamList = xmlParamList + "<row><GeneralWeekDayId>" + DataArray[i] + "</GeneralWeekDayId></row>";
            }
        }
        //$('#checkboxlistGeneralWeekDays input[type=checkbox]').each(function () {

        //    if ($(this).val() != "on") {
        //        if (this.checked == true) {
        //            xmlParamList = xmlParamList + "<row>" + "<GeneralWeekDayId>" + $(this).val() + "</GeneralWeekDayId>" + "</row>";
        //        }
        //    }
        //});
        if (xmlParamList.length > 6)
            EmployeeShiftApplicableMaster.SelectedXMLstring = xmlParamList + "</rows>";
        else
            EmployeeShiftApplicableMaster.SelectedXMLstring = null;
    },
    //this is used to for showing successfully record creation message and reload the list view
    SuccessEmployeeShiftApplicableMasterDetails: function (data) {

        var splitData = data.split(',');
      
        if (data != null) {
            //   parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeShiftApplicableMaster.ReloadShiftMasterDetailsList(splitData[0], splitData[1], splitData[2]);
        } else {

            // parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeShiftApplicableMaster.ReloadShiftMasterDetailsList(splitData[0], splitData[1], splitData[2]);
        }

    },

    hours_am_pm: function (time) {       
        var time = (time).split(':');
        var hours = parseInt(time[0].trim());
        var minutes = parseInt(time[1].trim());
        //newly added
        var splitAmpm = (time[1]).split(' ');
        var AMPM = splitAmpm[1];
        //end
        //var AMPM = time[2].trim();
        if (AMPM == "PM" && hours < 12 && hours != 00) hours = hours + 12;
        if (AMPM == "AM" && hours == 12 && hours != 00) hours = hours - 12;
        var sHours = hours.toString();
        var sMinutes = minutes.toString();
        if (hours < 10) sHours = "0" + sHours;
        if (minutes < 10) sMinutes = "0" + sMinutes;
        return (sHours + ":" + sMinutes + ":00");
    },


    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {



    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        EmployeeShiftApplicableMaster.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {


    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        EmployeeShiftApplicableMaster.ReloadList("Record Deleted Sucessfully.");
    //      //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

