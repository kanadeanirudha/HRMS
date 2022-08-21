//this class contain methods related to nationality functionality
var DiscountReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        DiscountReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnDiscountReportSubmit').on("click", function () {
            $("#IsPosted").val(true);
            $("#DiscountType").val($("#DiscountInPercent :selected").text());
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