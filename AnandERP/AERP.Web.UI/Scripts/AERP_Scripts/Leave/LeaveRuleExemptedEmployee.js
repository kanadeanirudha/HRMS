////this class contain methods related to nationality functionality
//var LeaveRuleExemptedEmployee = {
//    //Member variables
//    ActionName: null,
//    xmlParameterListCount: null,
//    LeaveRuleIDs: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        LeaveRuleExemptedEmployee.constructor();
//        //generalCountryMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $('#LateMarkRuleName').focus();

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#LateMarkRuleName').focus();
//            $('#LateMarkCount').val("1");

//            return false;
//        });

//        $("#FromDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M yy',
//            onSelect: function (selected) {
//                $("#UptoDate").datepicker("option", "minDate", selected)
//            }
//        });
//        $("#UptoDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M yy',
//            onSelect: function (selected) {
//                $("#FromDate").datepicker("option", "maxDate", selected)
//            }
//        });
//        $("#UptoDate_Clear").click(function () {
//            $('#UptoDate').val("");
//        });

//        // Create new record
//        $('#CreateLeaveRuleExemptedEmployeeRecord').on("click", function () {
//            LeaveRuleExemptedEmployee.getValueUsingParentTag_Check_UnCheck();
//            if ($('#EmployeeFullName').val() == "") {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectEmployee", "update-message", "#FFCC80");
//                //$('#update-message').html('Please select employee.');
//                //$('#update-message').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//                return false;
//            }
//            else if (LeaveRuleExemptedEmployee.LeaveRuleIDs.length <= 6) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectAtLeastOneLeaveRule", "update-message", "#FFCC80");
//                //$('#update-message').html('Please select at least one leave rule.');
//                //$('#update-message').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//                return false;
//            }
//            else if ($('#FromDate').val() == "") {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_FromDateNotBlank", "update-message", "#FFCC80");
//                //$('#update-message').html('Please select from date.');
//                //$('#update-message').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//                return false;
//            }
//            //else if ($('#UptoDate').val() == "") {
//            //    $('#update-message').html('Please select upto date.');
//            //    $('#update-message').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//            //    return false;
//            //}
//            LeaveRuleExemptedEmployee.ActionName = "Create";
//            LeaveRuleExemptedEmployee.AjaxCallLeaveRuleExemptedEmployee();


//        });

//        $('#EditLeaveRuleExemptedEmployeeRecord').on("click", function () {

//            LeaveRuleExemptedEmployee.ActionName = "Edit";
//            LeaveRuleExemptedEmployee.AjaxCallLeaveRuleExemptedEmployee();
//        });

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });
//        $("#closeBtn").click(function () {
//            parent.$.colorbox.close();
//        });
      
//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();

//        $("#CentreList").change(function () {
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//            $('#DisplayName_AddNew').hide(true);
//        });


//        //FOLLOWING FUNCTION IS SEARCHLIST OF Employee Name list
//        $("#EmployeeFullName").autocomplete({

//            source: function (request, response) {
//                $.ajax({
//                    url: "/LeaveRuleExemptedEmployee/GetEmployeeCentrewise",
//                    type: "POST",
//                    dataType: "json",
//                    data: { term: request.term, centreCode: $("#CentreList").val() },
//                    success: function (data) {
//                        response($.map(data, function (item) {
                            
//                            return { label: item.name, value: item.name, id: item.id };
//                        }))
//                    }
//                })
//            },
//            select: function (event, ui) {
//                $(this).val(ui.item.label);                                             // display the selected text
//                $("#EmployeeID").val(ui.item.id);

//                var employeeID = ui.item.id;

//                var $ddlLeaveRule = $("#LeaveRuleMasterID");
//                var $LeaveRuleProgress = $("#states-loading-progress");
//                $LeaveRuleProgress.show();
              
//                if (employeeID != "" && $("#CentreCode").val() !="") {
//                    $.ajax({
//                        cache: false,
//                        type: "GET",
//                        url: "/LeaveRuleExemptedEmployee/GetLeaveRuleByEmployeeID",

//                        data: { "EmployeeID": employeeID, "CentreCode": $("#CentreCode").val() },
//                        success: function (data) {
//                            $('#DivDropdownlist').html(data);
//                         //   $ddlLeaveRule.html('');
//                         //   debugger;
//                         ////   $ddlLeaveRule.append('<option value="">--------Select Leave Rule-------</option>');
//                         //   $.each(data, function (id, option) {
                              
//                         //       $ddlLeaveRule.append($('<option></option>').val(option.id).html(option.name));
//                         //   });
//                         //   $LeaveRuleProgress.hide();
//                        },
//                        error: function (xhr, ajaxOptions, thrownError) {
//                            alert('Failed to retrieve Leave Rule.');
//                            $LeaveRuleProgress.hide();
//                        }
//                    });
//                }
//                else {
//                    $('#LeaveRuleMasterID').find('option').remove().end().append('<option value></option>');
//                }


//            }
//        });

    
//        $("#ShowList").click(function () {
//            var SelectedCentreCode = $('#CentreList').val();
//            var SelectedCentreName = $('#CentreList :selected').text();

//            if (SelectedCentreCode != "") {
//                $.ajax(
//             {
//                 cache: false,
//                 type: "POST",
//                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

//                 dataType: "html",
//                 url: '/LeaveRuleExemptedEmployee/List',
//                 success: function (result) {
//                     //Rebind Grid Data                
//                     $('#ListViewModel').html(result);
//                     $('#DisplayName_AddNew').show(true);

//                 }
//             });
//            }
//            else {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//               // LeaveRuleExemptedEmployee.ReloadList("Please select centre", "#FFCC80", null);
//                //   $('#Createbutton').hide();
//                $('#DisplayName_AddNew').hide(true);
//            }
//        });


//    },



//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/LeaveRuleExemptedEmployee/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
        
//        var SelectedCentreCode = $('#CentreList').val();
//        var SelectedCentreName = $('#CentreList :selected').text();
//        parent.$.colorbox.close();
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { actionMode: actionMode, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
//            url: '/LeaveRuleExemptedEmployee/List',
//            success: function (data) {
//                //Rebind Grid Data

//                $("#ListViewModel").empty().append(data);
//                $('#DisplayName_AddNew').show(true);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },



//    //Fire ajax call to insert update and delete record
//    AjaxCallLeaveRuleExemptedEmployee: function () {
//        var LeaveRuleExemptedEmployeeData = null;
//        if (LeaveRuleExemptedEmployee.ActionName == "Create") {
//            $("#FormCreateLeaveRuleExemptedEmployee").validate();
//            if ($("#FormCreateLeaveRuleExemptedEmployee").valid()) {
//                LeaveRuleExemptedEmployeeData = null;
//                LeaveRuleExemptedEmployeeData = LeaveRuleExemptedEmployee.GetLeaveRuleExemptedEmployee();
//                ajaxRequest.makeRequest("/LeaveRuleExemptedEmployee/Create", "POST", LeaveRuleExemptedEmployeeData, LeaveRuleExemptedEmployee.Success);
//            }
//        }
//        else if (LeaveRuleExemptedEmployee.ActionName == "Edit") {
//            //$("#FormEditLeaveRuleExemptedEmployee").validate();
//            //if ($("#FormEditLeaveRuleExemptedEmployee").valid()) {
//                LeaveRuleExemptedEmployeeData = null;
//                LeaveRuleExemptedEmployeeData = LeaveRuleExemptedEmployee.GetLeaveRuleExemptedEmployee();
//                ajaxRequest.makeRequest("/LeaveRuleExemptedEmployee/Edit", "POST", LeaveRuleExemptedEmployeeData, LeaveRuleExemptedEmployee.Success);
//            //}
//        }
//        else if (LeaveRuleExemptedEmployee.ActionName == "Delete") {
//            LeaveRuleExemptedEmployeeData = null;
//            //$("#FormCreateLeaveRuleExemptedEmployee").validate();
//            LeaveRuleExemptedEmployeeData = LeaveRuleExemptedEmployee.GetLeaveRuleExemptedEmployee();
//            ajaxRequest.makeRequest("/LeaveRuleExemptedEmployee/Delete", "POST", LeaveRuleExemptedEmployeeData, LeaveRuleExemptedEmployee.Success);

//        }
//    },
//    getValueUsingParentTag_Check_UnCheck: function () {
        
//        var sList = "";
//        var xmlParamList = "<rows>"
//        $('#checkboxlist input[type=checkbox]').each(function () {
//            if ($(this).val() != "on") {
//                var sArray = [];
//                sArray = $(this).val().split("~");
//                if (this.checked == true) {
//                    xmlParamList = xmlParamList + "<row><LeaveRuleID>" + sArray[0] + "</LeaveRuleID><LeaveMasterID>" + sArray[1] + "</LeaveMasterID></row>"
//                }
//            }
//        });

//        if (xmlParamList.length > 6)
//            LeaveRuleExemptedEmployee.LeaveRuleIDs = xmlParamList + "</rows>";
//        else
//            LeaveRuleExemptedEmployee.LeaveRuleIDs = "0";
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetLeaveRuleExemptedEmployee: function () {
//        var Data = {
//        };
//        if (LeaveRuleExemptedEmployee.ActionName == "Create") {
//            Data.ID = $('#ID').val();
//            Data.EmployeeID = $('#EmployeeID').val();
//            Data.FromDate = $('#FromDate').val();
//            Data.UptoDate = $('#UptoDate').val();
//            Data.CentreCode = $('#CentreList').val();
//            Data.LeaveRuleIDs = LeaveRuleExemptedEmployee.LeaveRuleIDs;
//        }
//        else if (LeaveRuleExemptedEmployee.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//          //  Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
//        }
//        else if (LeaveRuleExemptedEmployee.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            LeaveRuleExemptedEmployee.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            LeaveRuleExemptedEmployee.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },

//};

//////////////////////////////new js//////////////////////////


//this class contain methods related to nationality functionality
var LeaveRuleExemptedEmployee = {
    //Member variables
    ActionName: null,
    xmlParameterListCount: null,
    LeaveRuleIDs: null,
    map: {},
    map2: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveRuleExemptedEmployee.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#LateMarkRuleName').focus();

        $("#ResetLeaveRuleExemptedEmployeeRecord").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#EmployeeFullName').val();
            $('#FromDate').val();
            $('#UptoDate').val();
            $('#DivDropdownlist').find('p div button span').remove().end().append('<span> </span>');
            $('#DivDropdownlist').find('p div div ul li a span').remove().end().append('<span></span>');
            return false;
        });

        //$("#FromDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    onSelect: function (selected) {
        //        $("#UptoDate").datepicker("option", "minDate", selected)
        //    }
        //});
        //$("#UptoDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    onSelect: function (selected) {
        //        $("#FromDate").datepicker("option", "maxDate", selected)
        //    }
        //});

        $('#FromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });

        $('#UptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });

        //used dp.hide instead of dp.change
        $('#FromDate').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate()); 
            $('#UptoDate').data("DateTimePicker").minDate(minDate);
        });

        //used dp.hide instead of dp.change
        $("#UptoDate").on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#FromDate').data("DateTimePicker").maxDate(maxDate);
        });

        $("#UptoDate_Clear").click(function () {
            $('#UptoDate').val("");
        });

        // Create new record
        $('#CreateLeaveRuleExemptedEmployeeRecord').on("click", function () {
         
            LeaveRuleExemptedEmployee.getValueUsingParentTag_Check_UnCheck();
            if ($('#EmployeeFullName').val() == "") {
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectEmployee", "displayErrorMessage", "#FFCC80");
                $("#displayErrorMessage p").text('Please select employee.').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
                //$('#update-message').html('Please select employee.');
                //$('#update-message').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
                
                return false;
            }
            else if (LeaveRuleExemptedEmployee.LeaveRuleIDs.length <= 6) {
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectAtLeastOneLeaveRule", "update-message", "#FFCC80");
                $("#displayErrorMessage p").text('Please select at least one leave rule.').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
                //$('#update-message').html('Please select at least one leave rule.');
                //$('#update-message').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
                return false;
            }
            else if ($('#FromDate').val() == "") {
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_FromDateNotBlank", "update-message", "#FFCC80");
                $("#displayErrorMessage p").text('Please select from date.').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
                //$('#update-message').html('Please select from date.');
                //$('#update-message').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
                return false;
            }
            //else if ($('#UptoDate').val() == "") {
            //    $('#update-message').html('Please select upto date.');
            //    $('#update-message').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
            //    return false;
            //}
            LeaveRuleExemptedEmployee.ActionName = "Create";
            LeaveRuleExemptedEmployee.AjaxCallLeaveRuleExemptedEmployee();


        });

        $('#EditLeaveRuleExemptedEmployeeRecord').on("click", function () {

            LeaveRuleExemptedEmployee.ActionName = "Edit";
            LeaveRuleExemptedEmployee.AjaxCallLeaveRuleExemptedEmployee();
        });

        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").DataTable();
        //    oTable.fnFilter(this.value);
        //});

        //$("#searchBtn").click(function () {
        //    $("#UserSearch").focus();
        //});
        $("#closeBtn").click(function () {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
        });

        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();


        $("#CentreList").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('#DisplayName_AddNew').hide(true);
        });


        ////FOLLOWING FUNCTION IS SEARCHLIST OF Employee Name list
        //$("#EmployeeFullName").autocomplete({

        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/LeaveRuleExemptedEmployee/GetEmployeeCentrewise",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, centreCode: $("#CentreList").val() },
        //            success: function (data) {
        //                response($.map(data, function (item) {

        //                    return { label: item.name, value: item.name, id: item.id };
        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {
        //        $(this).val(ui.item.label);                                             // display the selected text
        //        $("#EmployeeID").val(ui.item.id);

        //        var employeeID = ui.item.id;

        //        var $ddlLeaveRule = $("#LeaveRuleMasterID");
        //        var $LeaveRuleProgress = $("#states-loading-progress");
        //        $LeaveRuleProgress.show();

        //        if (employeeID != "" && $("#CentreCode").val() != "") {
        //            $.ajax({
        //                cache: false,
        //                type: "GET",
        //                url: "/LeaveRuleExemptedEmployee/GetLeaveRuleByEmployeeID",

        //                data: { "EmployeeID": employeeID, "CentreCode": $("#CentreCode").val() },
        //                success: function (data) {
        //                    $('#DivDropdownlist').html(data);
        //                },
        //                error: function (xhr, ajaxOptions, thrownError) {
        //                    alert('Failed to retrieve Leave Rule.');
        //                    $LeaveRuleProgress.hide();
        //                }
        //            });
        //        }
        //        else {
        //            $('#LeaveRuleMasterID').find('option').remove().end().append('<option value></option>');
        //        }


        //    }
        //});

        /////////////new search functionality///////////////////////////////////
        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var centerCodeID = $("#CentreList").val();

                $.ajax({
                    url: "/LeaveRuleExemptedEmployee/GetEmployeeCentrewise",
                    type: "POST",
                    data: { term: q, centreCode: centerCodeID },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        
                        $.each(data, function (i, response) {

                            //console.log(data);
                            if (substrRegex.test(response.name)) {
                                LeaveRuleExemptedEmployee.map[response.name] = response;
                                matches.push(response.name);
                                
                                //EmployeeFirstName
                                

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#EmployeeFullName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            //$("#ItemID").val(PurchaseRequirementMaster.map[item].id);
            //$("#ItemNumber").val(parseFloat(PurchaseRequirementMaster.map[item].itemNumber));

            //$(this).val(ui.item.label);
            $("#EmployeeID").val(LeaveRuleExemptedEmployee.map[item].id);

            var employeeID = LeaveRuleExemptedEmployee.map[item].id; //alert(employeeID);
            var $ddlLeaveRule = $("#LeaveRuleMasterID");
            var $LeaveRuleProgress = $("#states-loading-progress");
            $LeaveRuleProgress.show();

            if (employeeID != "" && $("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/LeaveRuleExemptedEmployee/GetLeaveRuleByEmployeeID",

                    data: { "EmployeeID": employeeID, "CentreCode": $("#CentreCode").val() },
                    success: function (data) {
                        $('#DivDropdownlist').html(data);
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Leave Rule.');
                        $LeaveRuleProgress.hide();
                    }
                });
            }
            else {
                $('#LeaveRuleMasterID').find('option').remove().end().append('<option value></option>');
            }
            
        });
        //end new search functionality


        $("#ShowList").unbind('click').click(function () {
            debugger;
            var SelectedCentreCode = $('#CentreList').val();
            var SelectedCentreName = $('#CentreList :selected').text();

            if (SelectedCentreCode != "") {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

                 dataType: "html",
                 url: '/LeaveRuleExemptedEmployee/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                     $('#DisplayName_AddNew').show(true);

                 }
             });
            }
            else {
                notify("Please select centre", "warning");
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
             url: '/LeaveRuleExemptedEmployee/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger
        var SelectedCentreCode = $('#CentreList').val();
        var SelectedCentreName = $('#CentreList :selected').text();
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
            url: '/LeaveRuleExemptedEmployee/List',
            success: function (data) {
                //Rebind Grid Data

                $("#ListViewModel").empty().append(data);
                $('#DisplayName_AddNew').show(true);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },



    //Fire ajax call to insert update and delete record
    AjaxCallLeaveRuleExemptedEmployee: function () {
        var LeaveRuleExemptedEmployeeData = null;
        if (LeaveRuleExemptedEmployee.ActionName == "Create") {
            $("#FormCreateLeaveRuleExemptedEmployee").validate();
            if ($("#FormCreateLeaveRuleExemptedEmployee").valid()) {
                LeaveRuleExemptedEmployeeData = null;
                LeaveRuleExemptedEmployeeData = LeaveRuleExemptedEmployee.GetLeaveRuleExemptedEmployee();
                ajaxRequest.makeRequest("/LeaveRuleExemptedEmployee/Create", "POST", LeaveRuleExemptedEmployeeData, LeaveRuleExemptedEmployee.Success);
            }
        }
        else if (LeaveRuleExemptedEmployee.ActionName == "Edit") {
            //$("#FormEditLeaveRuleExemptedEmployee").validate();
            //if ($("#FormEditLeaveRuleExemptedEmployee").valid()) {
            LeaveRuleExemptedEmployeeData = null;
            LeaveRuleExemptedEmployeeData = LeaveRuleExemptedEmployee.GetLeaveRuleExemptedEmployee();
            ajaxRequest.makeRequest("/LeaveRuleExemptedEmployee/Edit", "POST", LeaveRuleExemptedEmployeeData, LeaveRuleExemptedEmployee.Success);
            //}
        }
        else if (LeaveRuleExemptedEmployee.ActionName == "Delete") {
            LeaveRuleExemptedEmployeeData = null;
            //$("#FormCreateLeaveRuleExemptedEmployee").validate();
            LeaveRuleExemptedEmployeeData = LeaveRuleExemptedEmployee.GetLeaveRuleExemptedEmployee();
            ajaxRequest.makeRequest("/LeaveRuleExemptedEmployee/Delete", "POST", LeaveRuleExemptedEmployeeData, LeaveRuleExemptedEmployee.Success);

        }
    },
    getValueUsingParentTag_Check_UnCheck: function () {

        /////////////new
        var sList = "";
        var xmlParamList = "<rows>"
        var selectedItemID = $("select[id=checkboxlist1]").val();
        
        if (selectedItemID!=null) {
            for (var i = 0; i < selectedItemID.length; i++) {

                var sArray = [];
                sArray = selectedItemID[i].split("~");
                xmlParamList = xmlParamList + "<row><LeaveRuleID>" + sArray[0] + "</LeaveRuleID><LeaveMasterID>" + sArray[1] + "</LeaveMasterID></row>"
                
            }
        }

        /////////old

        //var sList = "";
        //var xmlParamList = "<rows>"
        //$('#checkboxlist input[type=checkbox]').each(function () {
        //    if ($(this).val() != "on") {
        //        var sArray = [];
        //        sArray = $(this).val().split("~");
        //        if (this.checked == true) {
        //            xmlParamList = xmlParamList + "<row><LeaveRuleID>" + sArray[0] + "</LeaveRuleID><LeaveMasterID>" + sArray[1] + "</LeaveMasterID></row>"
        //        }
        //    }
        //});

        

        if (xmlParamList.length > 6)
            LeaveRuleExemptedEmployee.LeaveRuleIDs = xmlParamList + "</rows>";
        else
            LeaveRuleExemptedEmployee.LeaveRuleIDs = "0";
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveRuleExemptedEmployee: function () {
        var Data = {
        };
        if (LeaveRuleExemptedEmployee.ActionName == "Create") {
            Data.ID = $('#ID').val();
            Data.EmployeeID = $('#EmployeeID').val();
            Data.FromDate = $('#FromDate').val();
            Data.UptoDate = $('#UptoDate').val();
            Data.CentreCode = $('#CentreList').val();
            Data.LeaveRuleIDs = LeaveRuleExemptedEmployee.LeaveRuleIDs;
        }
        else if (LeaveRuleExemptedEmployee.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            //  Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
        }
        else if (LeaveRuleExemptedEmployee.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            LeaveRuleExemptedEmployee.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $.magnificPopup.close();
            LeaveRuleExemptedEmployee.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },

};

