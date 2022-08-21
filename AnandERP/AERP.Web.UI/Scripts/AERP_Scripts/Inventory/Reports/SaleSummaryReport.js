//this class contain methods related to nationality functionality
var SaleSummaryReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        SaleSummaryReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnSalesSummarySubmit').on("click", function () {

            $("#IsPosted").val(true);
            $("#CentreName").val($("#CentreCode :selected").text());
        });

        $("#DateFrom").on("dp.change", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#DateTo').data("DateTimePicker").minDate(minDate);

        });

        $("#DateTo").on("dp.change", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#DateFrom').data("DateTimePicker").maxDate(minDate);
        });
    },


};