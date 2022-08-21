//this class contain methods related to nationality functionality
var CCRMMIFReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        CCRMMIFReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnCCRMMIFReportSubmit').on("click", function () {
            $("#IsPosted").val(true);
            $("#Status").val($("#Status :selected").val());
        });

    },

};