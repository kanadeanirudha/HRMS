//this class contain methods related to nationality functionality
var InventorySalesAndPurchaseReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        InventorySalesAndPurchaseReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnInventorySalesAndPurchaseReportSubmit').on("click", function () {
            $("#IsPosted").val(true);
        });

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
        //$("#DateFrom").on("dp.change", function (e) {
        //    var minDate = new Date(e.date.valueOf());
        //    minDate.setDate(minDate.getDate());
        //    $('#DateTo').data("DateTimePicker").minDate(minDate);

        //});
    },

};