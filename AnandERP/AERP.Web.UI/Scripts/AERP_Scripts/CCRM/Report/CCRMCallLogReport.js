//this class contain methods related to nationality functionality
var CCRMCallLogReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        CCRMCallLogReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnCCRMCallLogReportSubmit').on("click", function () {
            $("#IsPosted").val(true);
            //$("#Status").val($("#Status :selected").val());
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