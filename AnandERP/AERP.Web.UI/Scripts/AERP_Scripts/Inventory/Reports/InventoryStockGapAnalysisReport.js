//this class contain methods related to nationality functionality
var InventoryStockGapAnalysisReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        InventoryStockGapAnalysisReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnStockGapAnalysisSubmit').on("click", function () {
           
            $("#IsPosted").val(true);
            $("#GeneralUnitsName").val($("#GeneralUnitsID :selected").text());
            $("#CentreName").val($("#CentreCode :selected").text());
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

        $("#CentreCode").change(function () {

            var selectedItem = $(this).val();
            var $ddlGeneralUnitsID = $("#GeneralUnitsID");
            var $GeneralUnitsIDProgress = $("#GeneralUnitsID-loading-progress");
            $GeneralUnitsIDProgress.show();
            if ($("#CentreCode").val() !== "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: '/RetailReports/GetUnitList',
                    data: { "centreCode": selectedItem },
                    success: function (data) {
                        $ddlGeneralUnitsID.html('');
                        $ddlGeneralUnitsID.append('<option value="">-------Select Unit------</option>');
                        $.each(data, function (id, option) {

                            $ddlGeneralUnitsID.append($('<option></option>').val(option.id).html(option.unitName));
                        });
                        $GeneralUnitsIDProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve GeneralUnitsID.');
                        $GeneralUnitsIDProgress.hide();
                    }
                });
            }
            else {
                $('#GeneralUnitsID').find('option').remove().end().append('<option value>-------Select General Unit------</option>');
            }

        });
    },


};