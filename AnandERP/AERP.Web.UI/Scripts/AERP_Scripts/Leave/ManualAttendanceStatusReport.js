var ManualAttendanceStatusReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        ManualAttendanceStatusReport.constructor();
        //ManualAttendanceStatusReport.initializeValidation();
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


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
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
            //defaultDate: new Date(),
        });

        $('#UptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //defaultDate: new Date(),
        });

        $('#FromDate').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#UptoDate').data("DateTimePicker").minDate(minDate);
        });

        $('#UptoDate').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#FromDate').data("DateTimePicker").maxDate(maxDate);
        });


        InitAnimatedBorder();
        CloseAlert();

        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();
            var $ddlDepartment = $("#SelectedDepartmentID");
            var $DepartmentProgress = $("#states-loading-progress");
            $DepartmentProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/ManualAttendanceStatusReport/GetDepartmentByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlDepartment.html('');
                        $ddlDepartment.append('<option value="">All</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartment.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $DepartmentProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Department.');
                        $DepartmentProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>All</option>');
            }

            //temprorily commented

            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');


        });

        $("#SelectedDepartmentID").change(function () {

            //temprorily commented

            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $("#btnShowList").click(function () {
            debugger;

            var SelectedDepartmentID = $('#SelectedDepartmentID').val();
            var DataArray = [];
            if (SelectedDepartmentID == "") {
                var ddlvalues = $('#SelectedDepartmentID option').map(function () {
                    DataArray.push($(this).val());
                });
                SelectedDepartmentID = DataArray;
            }
            else
                SelectedDepartmentID = "," + SelectedDepartmentID;


            var SelectedCentreCode = $('#SelectedCentreCode').val();
            var SelectedApprovalStatus = $('#ApprovalStatus').val();
            var SelectedFromDate = $('#FromDate').val();
            var SelectedUptoDate = $('#UptoDate').val();
            if (SelectedCentreCode != "" && SelectedFromDate != "" && SelectedUptoDate != "" && SelectedDepartmentID.length > 1) {
                $.ajax(
                {
                    cache: false,
                    type: "POST",
                    data: { actionMode: null, centreCode: SelectedCentreCode, departmentIDs: "" + SelectedDepartmentID + "", approvalStatus: SelectedApprovalStatus, fromDate: SelectedFromDate, uptoDate: SelectedUptoDate },
                    dataType: "html",
                    url: '/ManualAttendanceStatusReport/List',
                    success: function (result) {
                        //Rebind Grid Data                
                        $('#ListViewModel').html(result);
                        $("#createDiv").show();
                    }
                });
            }

            else if (SelectedCentreCode == "") {
                //ManualAttendanceStatusReport.ReloadList("Please select centre", "#FFCC80", null);
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                notify("Please select centre", "danger");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if (SelectedDepartmentID.length <= 1) {
                //ManualAttendanceStatusReport.ReloadList("Please select centre", "#FFCC80", null);
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_DepartmentNotAllotedToCentre", "SuccessMessage", "#FFCC80");
                notify("Department not alloted to centre", "danger");
                //$('#SuccessMessage').html("Department not alloted to centre.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if (SelectedFromDate == "") {
                //ManualAttendanceStatusReport.ReloadList("Please select centre", "#FFCC80", null);
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_FromDateNotBlank", "SuccessMessage", "#FFCC80");
                notify("Please select from date", "danger");

                //$('#SuccessMessage').html("Please select from date");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if (SelectedUptoDate == "") {
                //ManualAttendanceStatusReport.ReloadList("Please select centre", "#FFCC80", null);
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_UptoDateNotBlank", "SuccessMessage", "#FFCC80");
                notify("Please select upto date", "danger");
                //$('#SuccessMessage').html("Please select upto date");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
        });



    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/ManualAttendanceStatusReport/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var SelectedCentreCode = $('#CentreCode').val();
        var SelectedCentreName = $('#CentreCode :selected').text();

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
            url: '/ManualAttendanceStatusReport/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                $("#createDiv").show();
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, "success");
            }
        });
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        ManualAttendanceStatusReport.ReloadList(splitData[0], splitData[1], splitData[2]);
    },

};