//this class contain methods related to nationality functionality
var RetailReports = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        RetailReports.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnRetailReportSubmit').on("click", function () {
            debugger;
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
                        $ddlGeneralUnitsID.append('<option value="">-------Select Sites------</option>');
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
                $('#GeneralUnitsID').find('option').remove().end().append('<option value>-------Select Unit------</option>');               
            }

        });

        $('#AccountSessionID').on("change", function () {

            var minDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[0]));
            minDate.setDate(minDate.getDate());
            var maxDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[1]));
            maxDate.setDate(maxDate.getDate());
            $('#SessionUptoDate').data("DateTimePicker").minDate(minDate);
            $('#SessionUptoDate').data("DateTimePicker").maxDate(maxDate);
            $("#SessionFromDate").val($('#AccountSessionID :selected').text().split('-')[0]);
            $("#SessionUptoDate").val($('#AccountSessionID :selected').text().split('-')[1]);
        })

    },

};

