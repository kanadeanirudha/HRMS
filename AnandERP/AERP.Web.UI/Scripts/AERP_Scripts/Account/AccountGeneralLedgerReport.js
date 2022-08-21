//this class contain methods related to nationality functionality
var AccountGeneralLedgerReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountGeneralLedgerReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form

        $('#btnAccountGeneralLedgerReportSubmit').on("click", function () {
            $("#AccountBalsheetMstID").val($("#selectedBalsheetID").val());
            $("#AccountName").val($("#AccountID :selected").text());
            $("#AccountID").val($("#AccountID :selected").val());
            $("#AccountSessionID").val($("#AccountSessionID").val());
            $("#ReportParameter").val($("#ReportParameter :selected").val())
            $("#IsPosted").val(true);
           
        });



        
        $("#FromDate").datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });

        $("#ToDate").datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });


        
        $('#AccountSessionID').on("change", function () {
          
            var minDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[0]));
            minDate.setDate(minDate.getDate());
            var maxDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[1]));
            maxDate.setDate(maxDate.getDate());
            $('#FromDate').data("DateTimePicker").minDate(minDate);
            $('#ToDate').data("DateTimePicker").maxDate(maxDate);
            $("#FromDate").val($('#AccountSessionID :selected').text().split('-')[0]);
            $("#ToDate").val($('#AccountSessionID :selected').text().split('-')[1]);

        })






        $("#AccountType").change(function () {
            
            var selectedItem = $(this).val();
            var $ddlAccountID = $("#AccountID");
            var $AccountIDProgress = $("#states-loading-progress");
            $AccountIDProgress.show();
            if ($("#AccountType").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AccountGeneralLedgerReport/GetAccountByCashBankFlag",

                    data: { "AccountType": selectedItem },
                    success: function (data) {
                        $ddlAccountID.html('');
                        $ddlAccountID.append('<option value="">------Select Account Name-------</option>');
                        $.each(data, function (id, option) {

                            $ddlAccountID.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $AccountIDProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Account Name.');
                        $AccountIDProgress.hide();
                    }
                });
            }
        });

    },
   
};