//this class contain methods related to nationality functionality
var VendorMasterReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        VendorMasterReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnVendorMasterReportSubmit').on("click", function () {
            $("#VendorReportList").val();
            $("#IsPosted").val(true);

        });

    },

};