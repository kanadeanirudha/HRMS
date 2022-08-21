//this class contain methods related to nationality functionality
var TillReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        TillReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnShowCreateForm').unbind("click").on("click", function () {
            var TransactionDate = $("#TransactionDate").val();
            if (TransactionDate == null || TransactionDate == "") {
                notify("Please select Date", "warning");
                return false;
            }
            var CounterId = $("#CounterId").val();
            if (CounterId == null || CounterId == "") {
                notify("Please select Counter", "warning");
                return false;
            }
            $.ajax({
                cache: false,
                type: "GET",
                data: { "TransactionDate": TransactionDate, "CounterId": CounterId },
                dataType: "html",
                url: '/TillReport/Create',
                success: function (data) {
                    $('#ListViewModel').empty().html(data);
                }
            });
        });
        $('#btnShowList').unbind("click").on("click", function () {
            var TransactionDate = $("#TransactionDate").val();
            if (TransactionDate == null || TransactionDate == "") {
                notify("Please select Date", "warning");
                return false;
            }
            var CounterId = $("#CounterId").val();
            if (CounterId == null || CounterId == "") {
                notify("Please select Counter", "warning");
                return false;
            }
            $("#ListViewModel").empty().html("This is Till Report Counter");
        });
        $("#CounterId").unbind("change").on("change", function () {
            $("#ListViewModel").empty();
        });

        $('#CreateTillReport').on("click", function () {
            TillReport.ActionName = "Create";
            TillReport.AjaxCallTillReport();
        });

        $('#CashReceived').on("keyup", function () {
            var CashReceived = $(this).val();
            if (CashReceived == "") {
                CashReceived = 0;
            }
            var TotalCash = $('#TotalCashPayment').text();
            var descripancy = parseFloat(TotalCash) - parseFloat(CashReceived);
            $("#DescripancyInCash").val(descripancy.toFixed(2));
        });

        $("#CentreCode").unbind("change").on("change", function () {
            $("#ListViewModel").empty();
            var selectedItem = $(this).val();
            var $ddlGeneralUnitsID = $("#CounterId");
            var $GeneralUnitsIDProgress = $("#GeneralUnitsID-loading-progress");
            $GeneralUnitsIDProgress.show();
            if ($("#CentreCode").val() !== "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: '/TillReport/GetCounterList',
                    data: { "centreCode": selectedItem },
                    success: function (data) {
                        $ddlGeneralUnitsID.html('');
                        $ddlGeneralUnitsID.append('<option value="">-------Select Counter------</option>');
                        $.each(data, function (id, option) {

                            $ddlGeneralUnitsID.append($('<option></option>').val(option.id).html(option.counterName));
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
                $('#CounterId').find('option').remove().end().append('<option value>-------Select Counter------</option>');
            }
        })
    },

    AjaxCallTillReport: function () {
        var TillReportData = null;

        if (TillReport.ActionName == "Create") {
            TillReportData = null;
            TillReportData = TillReport.GetTillReport();
            ajaxRequest.makeRequest("/TillReport/Create", "POST", TillReportData, TillReport.Success, "CreateTillReport");
        }

    },

    GetTillReport: function () {
        var Data = {
        };

        if (TillReport.ActionName == "Create") {
            Data.CashReceived = $('#CashReceived').val();
            Data.DescripancyInCash = $('#DescripancyInCash').val();
            Data.TransactionDate = $('#TransactionDate').val();
            Data.CounterId = $('#CounterId').val();
            Data.TotalCashPayment = $('#TotalCashPayment').text();
            Data.TotalCardPayment = $('#TotalCardPayment').text();
        }
        return Data;
    },

    Success: function (data) {

        var splitData = data.split(',');
        notify(splitData[0], splitData[1]);

    },
};