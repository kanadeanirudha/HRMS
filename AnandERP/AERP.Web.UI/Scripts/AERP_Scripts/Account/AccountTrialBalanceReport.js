//this class contain methods related to nationality functionality
var AccountTrialBalanceReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountTrialBalanceReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnAccountTrialBalanceReportSubmit').on("click", function () {
            $("#BalanceSheetMstID").val($("#selectedBalsheetID").val());
            ////$("#AccBalsheetName").val($("#BalanceSheetType").text());
            $('ul#balsheetList li').each(function (i) {
                var cls = $(this).closest("li").find("a i").attr("class");
                if (cls.split(' ')[1] == "zmdi-check-all") {
                    $("#AccBalsheetName").val($(this).closest("li").find("a").text().trim());
                }
            });
            $("#IsPosted").val(true);
        });

        //$("#SessionFromDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //});
        //$("#SessionUptoDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //});
        $("#SessionFromDate").datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });

        $("#SessionUptoDate").datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });
        $('#AccountSessionID').on("change", function () {

            //var minDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[0]));
            //minDate.setDate(minDate.getDate());
            //var maxDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[1]));
            //maxDate.setDate(maxDate.getDate());
            //$('#SessionUptoDate').data("DateTimePicker").minDate(minDate);
            //$('#SessionUptoDate').data("DateTimePicker").maxDate(maxDate);
            //$("#SessionFromDate").val($('#AccountSessionID :selected').text().split('-')[0]);
            //$("#SessionUptoDate").val($('#AccountSessionID :selected').text().split('-')[1]);

            var minDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[0]));
            minDate.setDate(minDate.getDate());
            var maxDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[1]));
            maxDate.setDate(maxDate.getDate());
            $('#SessionFromDate').data("DateTimePicker").minDate(minDate);
            $('#SessionUptoDate').data("DateTimePicker").maxDate(maxDate);
            $("#SessionFromDate").val($('#AccountSessionID :selected').text().split('-')[0]);
            $("#SessionUptoDate").val($('#AccountSessionID :selected').text().split('-')[1]);
        })

    },

};