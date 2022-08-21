//this class contain methods related to nationality functionality
var RetailSalesAndMarginDrillDownReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        RetailSalesAndMarginDrillDownReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
       
        $('#btnRetailSalesAndMarginDrillDownReportubmit').on("click", function () {
            $("#IsPosted").val(true);
            $("#CentreName").val($("#CentreCode :selected").text());
            $("#GeneralUnitsName").val($("#GeneralUnitsID :selected").text());
            $("#GranularityName").val($("#Granularity :selected").text());
        });


        $("#DateFrom").datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });
        $("#DateTo").datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });

        $("#DateFrom").on("dp.change", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#DateTo').data("DateTimePicker").minDate(minDate);

        });

        $("#DateTo").on("dp.change", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#DateFrom').data("DateTimePicker").maxDate(minDate);
        });

        //$("#CentreCode").change(function () {

        //    var selectedItem = $(this).val();
        //    var $ddlGeneralUnitsID = $("#GeneralUnitsID");
        //    var $GeneralUnitsIDProgress = $("#GeneralUnitsID-loading-progress");
        //    $GeneralUnitsIDProgress.show();
        //    if ($("#SelectedCentreCode").val() !== "") {
        //        $.ajax({
        //            cache: false,
        //            type: "GET",
        //            url: '/RetailSalesAndMarginDrillDownReport/GetUnitList',
        //            data: { "centreCode": selectedItem },
        //            success: function (data) {
        //                $ddlGeneralUnitsID.html('');
        //                $ddlGeneralUnitsID.append('<option value="">-------Select Sites------</option>');
        //                $.each(data, function (id, option) {

        //                    $ddlGeneralUnitsID.append($('<option></option>').val(option.id).html(option.unitName));
        //                });
        //                $GeneralUnitsIDProgress.hide();
        //            },
        //            error: function (xhr, ajaxOptions, thrownError) {
        //                alert('Failed to retrieve GeneralUnitsID.');
        //                $GeneralUnitsIDProgress.hide();
        //            }
        //        });
        //    }
        //    else {
        //        $('#GeneralUnitsID').find('option').remove().end().append('<option value>-------Select GeneralUnitsID------</option>');
        //    }

        //});


    },


};