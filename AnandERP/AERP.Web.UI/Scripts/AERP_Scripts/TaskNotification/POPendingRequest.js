//this class contain methods related to nationality functionality
var POPendingRequest = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    XMLstring: null,
    Initialize: function () {
    POPendingRequest.constructor();
       
    },
    //Attach all event of page
    constructor: function () {
        // Create new record

        $('#CreateApprovedPurchaseOrderMaster').on("click", function () {
            POPendingRequest.ActionName = "Approved";
            POPendingRequest.AjaxCallPOPendingRequest();
        });
    },
    
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var TaskCode = 'PO';
        $.magnificPopup.close();
        notify(message, colorCode);
        $('#' + TaskCode).click();
    },


    //Fire ajax call to insert update and delete record
    AjaxCallPOPendingRequest: function () {
        var POPendingRequestData = null;
        if (POPendingRequest.ActionName == "Approved") {
            POPendingRequestData = null;
            POPendingRequestData = POPendingRequest.GetPOPendingRequest();
            ajaxRequest.makeRequest("/PurchaseOrderMasterAndDetails/PurchaseOrderApproval", "POST", POPendingRequestData, POPendingRequest.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetPOPendingRequest: function () {
        var Data = {
        };

        if (POPendingRequest.ActionName == "Approved" || POPendingRequest.ActionName == "Rejected") {
            Data.ID = $('#ID').val();
            Data.TaskCode = $('#TaskCode').val();
            Data.IsLastRecord = $('#IsLastRecord').val();
            Data.TaskNotificationMasterID = $('#TaskNotificationMasterID').val();
            Data.TaskNotificationDetailsID = $("#TaskNotificationDetailsID").val();
            Data.GeneralTaskReportingDetailsID = $("#GeneralTaskReportingDetailsID").val();
            Data.StageSequenceNumber = $("#StageSequenceNumber").val();
            Data.PersonID = $("#PersonID").val();
            Data.ApprovedStatus = $("#SelectedStatus").val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        POPendingRequest.ReloadList(splitData[0], splitData[1], splitData[2]);

    },

};

