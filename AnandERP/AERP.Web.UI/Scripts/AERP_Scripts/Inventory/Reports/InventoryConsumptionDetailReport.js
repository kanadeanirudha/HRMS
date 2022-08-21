//this class contain methods related to nationality functionality
var InventoryConsumptionDetailReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        InventoryConsumptionDetailReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnCafeConsumptionAndWastageReportSubmit').on("click", function () {
            debugger
            $("#GeneralUnitsName").val($("#GeneralUnitsID :selected").text());
            $("#GranularityName").val($("#Granularity :selected").text());
            $("#IsPosted").val(true);
        });

        //$("#DateFrom").on("dp.change", function (e) {
        //    var minDate = new Date(e.date.valueOf());
        //    minDate.setDate(minDate.getDate());
        //    $('#DateTo').data("DateTimePicker").minDate(minDate);

        //});

        //$("#DateTo").on("dp.change", function (e) {
        //    var minDate = new Date(e.date.valueOf());
        //    minDate.setDate(minDate.getDate());
        //    $('#DateFrom').data("DateTimePicker").maxDate(minDate);
        //});
    },

};