//this class contain methods related to nationality functionality
var AccountIndividualBalanceReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountIndividualBalanceReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnAccountIndividualBalanceReportSubmit').on("click", function () {
          
            $("#AccountName").val($("#AccountID :selected").text());
            $("#PersonTypeName").val($("#ControlHead :selected").text())
            $("#AccountBalsheetMstID").val($("#selectedBalsheetID").val());
            $("#IsPosted").val(true);
        });
     
        //$("#FromDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //});
        //$("#ToDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //});

        //$('#AccountSessionID').on("change", function () {
        //    $("#FromDate").datepicker('option', { minDate: new Date($('#AccountSessionID :selected').text().split('-')[0]), maxDate: new Date($('#AccountSessionID :selected').text().split('-')[1]) });
        //    $("#ToDate").datepicker('option', { minDate: new Date($('#AccountSessionID :selected').text().split('-')[0]), maxDate: new Date($('#AccountSessionID :selected').text().split('-')[1]) });
        //    $("#FromDate").val($('#AccountSessionID :selected').text().split('-')[0]);
        //    $("#ToDate").val($('#AccountSessionID :selected').text().split('-')[1]);
        //})

        $('#AccountSessionID').on("change", function () {

            var minDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[0]));
            minDate.setDate(minDate.getDate());
            var maxDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[1]));
            maxDate.setDate(maxDate.getDate());
            $('#FromDate').data("DateTimePicker").minDate(minDate);
            $('#ToDate').data("DateTimePicker").maxDate(maxDate);
            $("#FromDate").val($('#AccountSessionID :selected').text().split('-')[0]);
            $("#ToDate").val($('#AccountSessionID :selected').text().split('-')[1]);

        })

        $("#ControlHead").change(function () {
          
            //$("#IndividualAccountID").attr("disabled", true);
            //$("#IndividualAccountID").val("");
            var selectedItem = $(this).val();
            var $ddlAccountID = $("#AccountID");
            var $AccountIDProgress = $("#states-loading-progress");
            $AccountIDProgress.show();
            if ($("#ControlHead").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AccountIndividualBalanceReport/GetAccountByCashBankFlag",

                    data: { "PersonType": selectedItem },
                    success: function (data) {
                        $ddlAccountID.html('');
                        $ddlAccountID.append('<option value="">------Select Account Name-------</option>');
                        $.each(data, function (id, option) {

                            $ddlAccountID.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $AccountIDProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Account Name.');
                        $AccountIDProgress.hide();
                    }
                });
            }
        });

        //$("#AccountID").change(function () {
        //    debugger;
        //    $("#IndividualAccountID").attr("disabled", false);
        //    var selectedItem = $(this).val();
        //    var $ddlIndividualAccountID = $("#IndividualAccountID");
        //    var $IndividualAccountIDProgress = $("#states-loading-progress");
        //    $IndividualAccountIDProgress.show();
        //    if ($("#PersonType").val() != "" && selectedItem != "") {
        //        $.ajax({
        //            cache: false,
        //            type: "GET",
        //            url: "/AccountIndividualBalanceReport/GetPersonNameByPersonTypeAndAccountId",

        //            data: { "AccountID": selectedItem, "PersonType": $("#PersonType").val() },
        //            success: function (data) {
        //                $ddlIndividualAccountID.html('');
        //                $ddlIndividualAccountID.append('<option value="">------Select Person-------</option>');
        //                $.each(data, function (id, option) {

        //                    $ddlIndividualAccountID.append($('<option></option>').val(option.id).html(option.name));
        //                });
        //                $IndividualAccountIDProgress.hide();
        //            },
        //            error: function (xhr, ajaxOptions, thrownError) {
        //                alert('Failed to retrieve Person Name.');
        //                $IndividualAccountIDProgress.hide();
        //            }
        //        });
        //    }
        //});
    },

};