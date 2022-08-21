//this class contain methods related to nationality functionality
var LeaveAttendanceExemption = {
    //Member variables
    ActionName: null,
    map: {},
    map2: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveAttendanceExemption.constructor();
        //LeaveAttendanceExemption.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {     

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LeaveDescription').focus();
            $('#LeaveType').val(" ");
            return false;
        });

        //$("#ExemptionFromDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    minDate: '0',
        //    onSelect: function (selected) {
        //        $("#ExemptionUpToDate").datepicker("option", "minDate", selected)
        //    }
        //});

        $('#ExemptionFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            maxDate: moment(),
        });

        $('#ExemptionFromDate').on('dp.change', function (e) {
            var minDate = new Date(e.date.valueOf());
            $('#ExemptionUpToDate').data("DateTimePicker").minDate(minDate);

        });

        if (parseInt($("#ID").val())>0) {
            var date = $("#ExemptionFromDate").val();

            //$("#ExemptionUpToDate").datepicker({
            //    numberOfMonths: 1,
            //    dateFormat: 'd M yy',
            //    minDate:  date,
            //});

            $('#ExemptionUpToDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
                minDate: moment(),
            });


        }
        else {

            //$("#ExemptionUpToDate").datepicker({
            //    numberOfMonths: 1,
            //    dateFormat: 'd M yy',
            //    minDate: '0',
            //    onSelect: function (selected) {
                    
            //            $("#ExemptionFromDate").datepicker("option", "maxDate", selected)
                   
            //    }
            //});

            $('#ExemptionUpToDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
                //maxDate: moment(),
            });

            $('#ExemptionUpToDate').on('dp.change', function (e) {
                var maxDate = new Date(e.date.valueOf());
                $('#ExemptionFromDate').data("DateTimePicker").maxDate(maxDate);

            });


        }


        $("#ExemptionUpToDate_Clear").on("click", function () {
            $("#ExemptionUpToDate").val('');
        });
        $("#centreDiv").text($("#CentreName").val());
        if (parseInt( $("#ID").val()) >0) {
            $("#EmployeeName").prop("disabled", true);
            $("#ExemptionFromDate").prop("disabled", true);
            $("#ExemptionUpToDate_Clear").hide();
        }
        else {
            $("#EmployeeName").prop("disabled", false);
            $("#ExemptionFromDate").prop("disabled", false);
            $("#ExemptionUpToDate_Clear").show();
        }

        // Create new record
        $('#CreateLeaveAttendanceExemptionRecord').on("click", function () {
            if (parseInt($("#ID").val()) > 0) {
               
                if ($("#ExemptionUpToDate").val() != '') {
                    LeaveAttendanceExemption.AjaxCallLeaveAttendanceExemption();
                }
                else {
                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_ExemptionUptoDate", "localFormMessage", "#FFCC80");
                    //$('#localFormMessage').html("Please select Exemption Upto Date");
                    //$('#localFormMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                }
            }
            else {
                LeaveAttendanceExemption.AjaxCallLeaveAttendanceExemption();
            }
            
        });


        //FOLLOWING FUNCTION IS SEARCHLIST OF item list
        //$("#EmployeeName").autocomplete({

        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/LeaveAttendanceExemption/GetEmployeeCentrewise",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, centreCode: $("#CentreCode").val() },
        //            success: function (data) {
        //                response($.map(data, function (item) {
        //                    return { label: item.name, value: item.name, id: item.id };
        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {
        //        $(this).val(ui.item.label);                                             // display the selected text
        //        $("#EmployeeId").val(ui.item.id);
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
                //var valuCentreCode = $('#SelectedCentreCode :selected').val();
                //var valuStudentType = $('#IsCurrentYearStudent').val();
                $.ajax({
                    url: "/LeaveAttendanceExemption/GetEmployeeCentrewise",
                    type: "POST",
                    data: { term: q, maxResults: 10, centreCode: $("#CentreCode").val()},
                    //data: { term: request.term, centreCode: $("#CentreCode").val() },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array

                        //alert(data);

                        $.each(data, function (i, response) {
                            //alert(response.id);
                            if (substrRegex.test(response.name)) {
                                LeaveAttendanceExemption.map[response.name] = response;
                                matches.push(response.name);

                            }
                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#EmployeeName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            //alert(LeaveAttendanceExemption.map[item].id);
            $("#EmployeeId").val(LeaveAttendanceExemption.map[item].id);

        });
        //end new search functionality

        $('#LeaveDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#LeaveCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
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
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$("#DivCreateNew").hide(true);
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            //$('#myDataTable_thead').attr('readonly', 'readonly');
            //$('#myDataTable_thead').attr("disabled", "disabled");
            $('#DisplayName_AddNew').hide(true);

        });

        $("#ShowList").click(function () {
            
            var SelectedCentreCode = $('#CentreCode').val();
            var SelectedCentreName = $('#CentreCode :selected').text();
            
            if (SelectedCentreCode != "") {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

                 dataType: "html",
                 url: '/LeaveAttendanceExemption/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                     $('#DisplayName_AddNew').show(true);
                 }
             });
            }
            else {
                //LeaveAttendanceExemption.ReloadList("Please select centre", "#FFCC80", null);
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
            }
        });

        $('#LeaveRuleDescription').on("keydown", function (e) {
           // AMSValidation.AllowCharacterOnly(e);
        });

        $('#NumberOfLeaves').on("keydown", function (e) {           
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MaxLeaveAtTime').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MinLeavesAtTime').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MaxLeaveEncash').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MinimumLeaveEncash').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MinServiceRequiredInMonth').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#AttendDaysRequired').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MaxLeaveAccumulated').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        
    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/LeaveAttendanceExemption/List',
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
       
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
            url: '/LeaveAttendanceExemption/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                $("#createDiv").show();
                $("#DisplayName_AddNew").show();
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallLeaveAttendanceExemption: function () {
        if ($("#FormCreateLeaveAttendanceExemption").valid()) {
            var LeaveAttendanceExemptionData = null;
            LeaveAttendanceExemptionData = null;
            LeaveAttendanceExemptionData = LeaveAttendanceExemption.GetLeaveAttendanceExemption();
            ajaxRequest.makeRequest("/LeaveAttendanceExemption/Action", "POST", LeaveAttendanceExemptionData, LeaveAttendanceExemption.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveAttendanceExemption: function () {
        var Data = {
        };
       
        Data.ID = $('input[name=ID]').val();
        Data.EmployeeId = $('input[name=EmployeeId]').val();
        Data.CentreCode = $('#CentreCode :selected').val();
        Data.ExemptionFromDate = $('#ExemptionFromDate').val();
        Data.ExemptionUpToDate = $('#ExemptionUpToDate').val();
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        LeaveAttendanceExemption.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
   
};

