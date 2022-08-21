//this class contain methods related to nationality functionality
var InventoryBillDetailReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        InventoryBillDetailReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnBillReportSubmit').on("click", function () {
            $("#IsPosted").val(true);

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