﻿//this class contain methods related to nationality functionality
var AccountProfitAndLossReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountProfitAndLossReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnAccountProfitAndLossReportSubmit').on("click", function () {
            debugger;
            var IsConsolidated = $('#IsConsolidated').is(":checked") ? "true" : "false";
            if (IsConsolidated == "true") {
                $("#AccBalsheetMstId").val(0);
            }
            else {
                $("#AccBalsheetMstId").val($("#selectedBalsheetID").val());
            }
            
            $('ul#balsheetList li').each(function (i) {
                var cls = $(this).closest("li").find("a i").attr("class");
                if (cls.split(' ')[1] == "zmdi-check-all") {
                    $("#AccBalsheetName").val($(this).closest("li").find("a").text().trim());
                }
            });
            $("#IsPosted").val(true);
            $("#IsConsolidated").val(IsConsolidated);
        });

        $("#SessionFromDate").datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });

        $("#SessionUptoDate").datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });

        $('#AccountSessionID').on("change", function () {
            var minDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[0]));
            minDate.setDate(minDate.getDate());
            var maxDate = new Date(new Date($('#AccountSessionID :selected').text().split('-')[1]));
            maxDate.setDate(maxDate.getDate());
            $('#SessionFromDate').data("DateTimePicker").minDate(minDate);
            $('#SessionUptoDate').data("DateTimePicker").maxDate(maxDate);
            $("#SessionFromDate").val($('#AccountSessionID :selected').text().split('-')[0]);
            $("#SessionUptoDate").val($('#AccountSessionID :selected').text().split('-')[1]);
        })
    },

};