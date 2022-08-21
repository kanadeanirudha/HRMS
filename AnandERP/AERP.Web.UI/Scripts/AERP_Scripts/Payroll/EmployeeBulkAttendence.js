var EmployeeBulkAttendence = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function ()
    {
        EmployeeBulkAttendence.constructor();
    },
    //Attach all event of page
    constructor: function ()
    {
        $('#CreateEmployeeAttendenceRecord').on("click", function () {
            EmployeeBulkAttendence.ActionName = "Create";
            EmployeeBulkAttendence.AjaxCallEmployeeAttendence();
        });
        $('#EditEmployeeAttendenceRecord').on("click", function ()
        {
            EmployeeBulkAttendence.ActionName = "Edit";
            EmployeeBulkAttendence.AjaxCallEmployeeAttendence();
        });

        $("#ShowList").click(function ()
        {
            var SelectedCentreCode = $('#CentreCode').val().split(':')[0];
           // var SelectedDepartmentCode = $('#SelectedDepartmentID').val();
            var SelectedSpanID = $('#SpanID').val();


            if (SelectedCentreCode != "" && SelectedSpanID != "")
            {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { centerCode: SelectedCentreCode,SpanID:SelectedSpanID, actionMode: null },

                 dataType: "html",
                 url: '/EmployeeBulkAttendence/List',
                 success: function (result)
                 {
                     $('#btnDownload').show(true);
                     $('#DownloadFilelink').attr("href", "EmployeeBulkAttendence/Download?CentreCode=" + SelectedCentreCode + "&SpanID=" + SelectedSpanID);
                     $('#UploadFilelink').attr("href", "EmployeeBulkAttendence/UploadExcel?SpanID=" + SelectedSpanID);
                     
                     $('#ListViewModel').html(result);
                 }
             });
            }
            else if (SelectedCentreCode == "")
            {
                notify('Please select Center', 'warning');
                return false;
            }
           /* else if (SelectedDepartmentCode == "") {
                notify('Please select Department', 'warning');
                return false;
            }*/
            else if (SelectedSpanID == "") {
                notify('Please select Span', 'warning');
                return false;
            }
        });

        $("#SelectedDepartmentID").change(function ()
        {
            $('#btnDownload').hide();
        });

        $("#CentreCode").change(function ()
        {
             $('#btnDownload').hide();
            /* var selectedItem = $(this).val();
            var $ddlDepartment = $("#SelectedDepartmentID");
            var $DepartmentProgress = $("#states-loading-progress");
            $DepartmentProgress.show();
            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeBulkAttendence/GetDepartmentByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlDepartment.html('');
                        $ddlDepartment.append('<option value="">--Select Department--</option>');
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
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');*/

        });
        InitAnimatedBorder();
        CloseAlert();
    },
    //LoadList method is used to load List page
    LoadList: function ()
    {
        
        $.ajax({
            cache: false,
            type: "POST",
            data: { },
            dataType: "html",
            url: '/EmployeeBulkAttendence/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            //  data: { actionMode: actionMode },
            url: '/EmployeeBulkAttendence/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    AjaxCallEmployeeAttendence: function ()
    {
        var EmployeeAttendenceData = null;
        if (EmployeeBulkAttendence.ActionName == "Create") {
            $("#FormCreateEmployeeAttendence").validate();
            if ($("#FormCreateEmployeeAttendence").valid()) {
                EmployeeAttendenceData = null;
                EmployeeAttendenceData = EmployeeBulkAttendence.GetEmployeeAttendence();
                ajaxRequest.makeRequest("/EmployeeBulkAttendence/Create", "POST", EmployeeAttendenceData, EmployeeBulkAttendence.Success);
            }
        }
        if (EmployeeBulkAttendence.ActionName == "Edit")
        {
            $("#FormEditEmployeeAttendence").validate();
            if ($("#FormEditEmployeeAttendence").valid())
            {
                EmployeeAttendenceData = null;
                EmployeeAttendenceData = EmployeeBulkAttendence.GetEmployeeAttendence();
                ajaxRequest.makeRequest("/EmployeeBulkAttendence/Edit", "POST", EmployeeAttendenceData, EmployeeBulkAttendence.Success);
            }
        }

    },
    GetEmployeeAttendence: function ()
    {
        var Data =
        {
        };
        if (EmployeeBulkAttendence.ActionName == "Create") {
            debugger;
            Data.ID = $('#ID').val();
            Data.SpanID = $('#SpanID').val();
            Data.EmployeeID = $('#EmployeeID').val();
            Data.TotalAttendence = $("#TotalAttendence").val();
            Data.TotalOvertime = $("#TotalOvertime").val();
        }
        if (EmployeeBulkAttendence.ActionName == "Edit")
        {
            Data.ID = $('#ID').val();
            Data.TotalAttendence = $("#TotalAttendence").val();
            Data.TotalOvertime = $("#TotalOvertime").val();
        }

        return Data;
    },

    Success: function (data) {
        var splitData = data.split(',');

        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            EmployeeBulkAttendence.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
}