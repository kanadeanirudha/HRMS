//this class contain methods related to nationality functionality
var TakeAwayVsFineDiningReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        TakeAwayVsFineDiningReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnTakeAwayVsFineDiningReportSubmit').on("click", function () {
            debugger;
            $("#CentreName").val($("#CentreCode :selected").text());
            $("#GranularityName").val($("#Granularity :selected").text());
            $("#IsPosted").val(true);
         
        });

    },

};