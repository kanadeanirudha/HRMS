//this class contain methods related to nationality functionality
var ItemPrice = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        ItemPrice.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnItemPriceSubmit').on("click", function () {
            $("#IsPosted").val(true);
            $("#CentreName").val($("#CentreCode :selected").text());
        });
      
    },


};