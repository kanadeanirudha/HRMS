var EmployeeSalarySpan = {

    ActionName: null,
    //Class intialisation method

    Initialize: function () {
        EmployeeSalarySpan.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#FromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });

        $('#CompletionDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });
        
        $('#IsSalaryGenerated').constructor(function()
        {
            if ($("#IsSalaryGenerated").is(":checked"))
            {
                $("#CompletionDate").prop('disabled', false)
            }
            else
            {
                $("#CompletionDate").prop('disabled', true);
                $("#CompletionDate").val("");
            }
        });

        $('#CreateEmployeeSalarySpanRecord').on("click", function () {
            EmployeeSalarySpan.ActionName = "Create";
            EmployeeSalarySpan.AjaxCallEmployeeSalarySpan();
        });

        $('#EditEmployeeSalarySpanRecord').on("click", function () {
            EmployeeSalarySpan.ActionName = "Edit";
            EmployeeSalarySpan.AjaxCallEmployeeSalarySpan();
        });

        $('#UptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });

        $("#FromDate").on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
           /* minDate.setDate(minDate.getDate() - 1);
            var months = ["January", "February", "March", "April", "May", "June",
               "July", "August", "September", "October", "November", "December"];
            var selectedMonthName = null;
            var selectedYear = minDate.getFullYear();
            if (minDate.getMonth() == 11)
            {
                selectedMonthName = months[0];
                selectedYear = minDate.getFullYear() + 1;
            }
            else
            {
                selectedMonthName = months[minDate.getMonth()+1];
                selectedYear = minDate.getFullYear();
            }

            var selectedDate = minDate.getDate();
            var conDate = selectedDate + ' ' + selectedMonthName + ' ' + selectedYear;
            var conDateConvert = new Date(conDate);*/
            $('#UptoDate').data("DateTimePicker").minDate(minDate);

        });

        $("#UptoDate").on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#FromDate').data("DateTimePicker").maxDate(maxDate);
        });

        $("#IsSalaryGenerated").on("click", function (e)
        {
            if ($("#IsSalaryGenerated").is(":checked"))
            {
                $("#CompletionDate").prop('disabled', false)
            }
            else
            {
                $("#CompletionDate").prop('disabled', true);
                $("#CompletionDate").val(null);
            }
        });

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
             url: '/EmployeeSalarySpan/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            //  data: { actionMode: actionMode },
            url: '/EmployeeSalarySpan/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    AjaxCallEmployeeSalarySpan: function () {
        var EmployeeSalarySpanData = null;
        if (EmployeeSalarySpan.ActionName == "Create") {
            $("#FormCreateEmployeeSalarySpan").validate();
            if ($("#FormCreateEmployeeSalarySpan").valid()) {
                EmployeeSalarySpanData = null;
                EmployeeSalarySpanData = EmployeeSalarySpan.GetEmployeeSalarySpan();
                ajaxRequest.makeRequest("/EmployeeSalarySpan/Create", "POST", EmployeeSalarySpanData, EmployeeSalarySpan.Success, "CreateEmployeeSalarySpanRecord");
            }
        }
        else if (EmployeeSalarySpan.ActionName == "Edit") {
            $("#FormEditEmployeeSalarySpan").validate();
            if ($("#FormEditEmployeeSalarySpan").valid()) {
                EmployeeSalarySpanData = null;
                EmployeeSalarySpanData = EmployeeSalarySpan.GetEmployeeSalarySpan();
                ajaxRequest.makeRequest("/EmployeeSalarySpan/Edit", "POST", EmployeeSalarySpanData, EmployeeSalarySpan.Success);
            }
        }
    },
    GetEmployeeSalarySpan: function () {
        var Data =
        {
        };

        if (EmployeeSalarySpan.ActionName == "Create")
        {
            Data.ID = $('#ID').val();
            Data.FromDate = $('#FromDate').val();
            Data.UptoDate = $('#UptoDate').val();
        }
        else if (EmployeeSalarySpan.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.IsActive = $("#IsActive").is(":checked") ? "true" : "false";
            Data.IsSalaryGenerated = $("#IsSalaryGenerated").is(":checked") ? "true" : "false";
            Data.CompletionDate = $('#CompletionDate').val();
        }

        return Data;
    },

    Success: function (data) {
        var splitData = data.split(',');

        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            EmployeeSalarySpan.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

}