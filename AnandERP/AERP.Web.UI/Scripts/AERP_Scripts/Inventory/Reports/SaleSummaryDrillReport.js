//this class contain methods related to nationality functionality
var SaleSummaryDrillReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        SaleSummaryDrillReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnSalesDrillSummarySubmit').on("click", function () {
            debugger;
            $("#IsPosted").val(true);
            $("#CentreName").val($("#CentreCode :selected").text());
        });

    },

};