//this class contain methods related to nationality functionality
var GeneralItemMissingExceptionReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        GeneralItemMissingExceptionReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnVendorMasterReportSubmit').on("click", function () {
            $("#ItemReportList").val();
            $("#IsPosted").val(true);
            $("#CentreName").val($("#CentreCode :selected").text());
        });
        $("#ItemReportList").on("change", function () {
            if ($(this).val() == "SaleDetails" || $(this).val() == "StoreDetails") {
                $("#CentreCodeList").show();
            } else {
                $("#CentreCodeList").hide();
            }
        });
    },

};