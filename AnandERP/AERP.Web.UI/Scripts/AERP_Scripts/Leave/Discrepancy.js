//this class contain methods related to nationality functionality
var Discrepancy = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        Discrepancy.constructor();
        //Discrepancy.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        //$("#reset").click(function () {

        //    $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

        //    return false;
        //});

        $("#CentreCode").focus();
     
        if ($("#SpanFromDate").val() != "" && $("#SpanFromDate").val() != null) {

            $("#SpanFromDate").attr("disabled", true);
        }
        else {
            $("#SpanFromDate").attr("disabled", false);
        }
        $("#SpanFromDate").datepicker({
            numberOfMonths: 1,
            dateFormat: 'dd/mm/yy',
            //onSelect: function (selected) {
            //    $("#SpanUptoDate").datepicker("option", "minDate", selected)
            //}
        });
        $("#SpanUptoDate").datepicker({
            numberOfMonths: 1,
            dateFormat: 'dd/mm/yy',
            onSelect: function (selected) {

                var SpanFromDateArray = $("#SpanFromDate").val().split('/');
                var SpanFromDate = new Date(SpanFromDateArray[2], SpanFromDateArray[1] - 1, SpanFromDateArray[0]); //Year, Month, Date

                var SpanUptoDateArray = selected.split('/');
                var SpanUptoDate = new Date(SpanUptoDateArray[2], SpanUptoDateArray[1] - 1, SpanUptoDateArray[0]); //Year, Month, Date

                if (SpanFromDate >= SpanUptoDate) {
                    var message = ajaxRequest.GeneralMessageForJS("JsAlertMessages_UptoGreaterThanFromDate");
                    alert(message);
                    //alert("Please enter upto date is greater than from date.");
                    $("#SpanUptoDate").val("")
                }
            }
        });

        // Create new record
        $('#CreateDiscrepancyRecord').on("click", function () {

            Discrepancy.ActionName = "Create";
            Discrepancy.AjaxCallDiscrepancy();

        });

        $('#EditDiscrepancyRecord').on("click", function () {
            
            Discrepancy.ActionName = "Edit";
            Discrepancy.AjaxCallDiscrepancy();
        });

        $('#DeleteDiscrepancyRecord').on("click", function () {

            Discrepancy.ActionName = "Delete";
            Discrepancy.AjaxCallDiscrepancy();
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

        $(".ajax").colorbox();

        //$("#CentreCode").change(function () {
        //    $('#myDataTable').html("");
        //    $('#myDataTable_info').text("No entries to show");
        //    $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        //    $('#Createbutton').hide();
        //});

        $("#CentreCode").change(function () {
            var selectedItem = $(this).val();
            var $ddlDepartments = $("#DepartmentID");
            var $departmentProgress = $("#states-loading-progress");

            var $ddlSalarySpan = $("#SalarySpanID");
            var $SalarySpanProgress = $("#states-loading-progress");

            $departmentProgress.show();
            $SalarySpanProgress.show();
            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/Discrepancy/GetDepartmentByCentreCode",
                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
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
                        alert('Failed to retrieve departments.');
                        $departmentProgress.hide();
                    }
                });

                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/Discrepancy/GetSalarySpanByCentreCode",
                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlSalarySpan.html('');
                        $ddlSalarySpan.append('<option value="">-----Select Salary Span-----</option>');
                        $.each(data, function (id, option) {

                            $ddlSalarySpan.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $SalarySpanProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve salary span.');
                        $SalarySpanProgress.hide();
                    }
                });
                $('#btnCreate').hide();
            }
            else {
                $('#myDataTable tbody').empty();
                $('#DepartmentID').find('option').remove().end().append('<option value>-----Select Department-----</option>');
                $('#SalarySpanID').find('option').remove().end().append('<option value>-----Select Salary Span-----</option>');
                $('#btnCreate').hide();
            }
        });

        $("#btnShowList").click(function () {
          
            var SelectedCentreCode = $('#CentreCode').val();
            var SelectedCentreName = $('#CentreCode :selected').text();
            var SelectedDepartmentID = $('#DepartmentID :selected').val();
            var SelectedSalarySpanID = $('#SalarySpanID :selected').val();
            if (SelectedCentreCode != "" && SelectedDepartmentID > 0 && SelectedSalarySpanID > 0) {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName,departmentID: SelectedDepartmentID,salarySpanID:SelectedSalarySpanID },

                 dataType: "html",
                 url: '/Discrepancy/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                     $('#Createbutton').show();

                 }
             });
            }
            else if (SelectedCentreCode != "" && SelectedDepartmentID == "" && SelectedSalarySpanID == "") {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectDepartmentAndSalarySpan", "SuccessMessage", "#FFCC80"); 
                $('#DivCreateNew').hide(true);
            }
            else if (SelectedCentreCode != "" && SelectedDepartmentID != "" && SelectedSalarySpanID == "") {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectSalarySpan", "SuccessMessage", "#FFCC80"); 
                $('#DivCreateNew').hide(true);
            }
            else if (SelectedCentreCode != "" && SelectedDepartmentID == "" && SelectedSalarySpanID != "") {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectDepartment", "SuccessMessage", "#FFCC80"); 
                $('#DivCreateNew').hide(true);
            }
            else if ((SelectedCentreCode == "" && SelectedDepartmentID == "" && SelectedSalarySpanID == "")) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80"); 
                $('#DivCreateNew').hide(true);
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
             url: '/Discrepancy/List',
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
            data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
            url: '/Discrepancy/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallDiscrepancy: function () {
        var DiscrepancyData = null;
        if (Discrepancy.ActionName == "Create") {
            $("#FormCreateDiscrepancy").validate();
            if ($("#FormCreateDiscrepancy").valid()) {
                DiscrepancyData = null;
                DiscrepancyData = Discrepancy.GetDiscrepancy();
                ajaxRequest.makeRequest("/Discrepancy/Create", "POST", DiscrepancyData, Discrepancy.Success);
            }
        }
        else if (Discrepancy.ActionName == "Edit") {
            $("#FormEditDiscrepancy").validate();
            if ($("#FormEditDiscrepancy").valid()) {
                DiscrepancyData = null;
                DiscrepancyData = Discrepancy.GetDiscrepancy();
                ajaxRequest.makeRequest("/Discrepancy/Edit", "POST", DiscrepancyData, Discrepancy.Success);
            }
        }
        else if (Discrepancy.ActionName == "Delete") {
            DiscrepancyData = null;
            //$("#FormCreateDiscrepancy").validate();
            DiscrepancyData = Discrepancy.GetDiscrepancy();
            ajaxRequest.makeRequest("/Discrepancy/Delete", "POST", DiscrepancyData, Discrepancy.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetDiscrepancy: function () {
        var Data = {
        };
        if (Discrepancy.ActionName == "Create" || Discrepancy.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.SpanFromDate = $('input[name=SpanFromDate]').val();
            Data.SpanUptoDate = $('#SpanUptoDate').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
        }
        else if (Discrepancy.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            Discrepancy.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            Discrepancy.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

