
//this class contain methods related to below indent level report functionality.

var ArticalMovementReport = {
    ActionName: null,
    SelectedLocationIDs: null,
    AllSelectedLocationIDs: null,

    Initialize: function () {
        ArticalMovementReport.constructor();
    },

    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $("#BelowIndentLevelReport").hide();

        $('#btnBelowIndentLevelReportSubmit').on("click", function () {
            if ($("#AccountBalsheetMstID").val() != null && $("#AccountBalsheetMstID").val() > 0) {

                ArticalMovementReport.GetSelectedLocationListXML();
                $("#AccountBalsheetMstID").val($("#selectedBalsheetID").val());
                $("#IsPosted").val(true);
            }
            else {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectBalancesheet", "SuccessMessage", "#FFCC80");
            }
        });
    },

    //Genrate XML for item list.
    GetSelectedLocationListXML: function () {

        var xmlParamList = "<rows>"
        $('#e5_f input[type=checkbox]').each(function () {

            if ($(this).val() != "on") {
                if (this.checked == true) {
                    xmlParamList = xmlParamList + "<row><ID>0</ID>" + "<LocationID>" + $(this).val() + "</LocationID>" + "</row>";
                }
            }
        });
        if (xmlParamList.length > 6) {
            ArticalMovementReport.SelectedLocationIDs = xmlParamList + "</rows>";
            $("#LocationNameListXml").val(ArticalMovementReport.SelectedLocationIDs);
        }
        else {
            $("#LocationNameListXml").val('');
        }
    },


};