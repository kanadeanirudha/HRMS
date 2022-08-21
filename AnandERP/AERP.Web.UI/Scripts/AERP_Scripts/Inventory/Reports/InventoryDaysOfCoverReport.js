//this class contain methods related to nationality functionality
var InventoryDaysOfCoverReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        InventoryDaysOfCoverReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnDaysOfCoverReportSubmit').on("click", function () {
            $("#IsPosted").val(true);
        });
    },

};