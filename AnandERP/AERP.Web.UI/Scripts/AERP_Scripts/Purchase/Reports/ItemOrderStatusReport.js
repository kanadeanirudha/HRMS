//this class contain methods related to nationality functionality
var ItemOrderStatusReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        ItemOrderStatusReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnItemOrderStatusReportSubmit').on("click", function () {
            debugger;
            $("#GetItemOrderStatusReportList").val();
            $("#IsPosted").val(true);
            $("#CentreName").val($("#CentreCode :selected").text());
            $("#GeneralUnitsName").val($("#GeneralUnitsID :selected").text());
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
    },

};