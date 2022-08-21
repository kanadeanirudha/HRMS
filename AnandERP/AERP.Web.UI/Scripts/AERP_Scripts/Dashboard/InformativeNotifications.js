//this class contain methods related to nationality functionality
var InformativeNotifications = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InformativeNotifications.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        
        $('#btnAllMarkAsRead').on("click", function () {
            InformativeNotifications.ActionName = "AllRead";
            InformativeNotifications.AjaxCallRequestApproval(0);
        });

        $('.markAsRead').unbind('click').click(function () {
            var selectedValue = $(this).prev('input').val();
            alert(selectedValue);
            InformativeNotifications.ActionName = "SingleRead";
            InformativeNotifications.AjaxCallRequestApproval(selectedValue);
            //$(this).prop('disabled',true);
        });
    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/RequestApproval/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $('#infoNotifications').click();
    },


    //Fire ajax call to insert update and delete record
    AjaxCallRequestApproval: function (selectedTransactionID) {
        var RequestApprovalData = null;
        if (InformativeNotifications.ActionName == "AllRead") {
            
            RequestApprovalData = null;
            var Data = {
            };
            Data.NotificationTransactionID = selectedTransactionID;
            RequestApprovalData = Data;
            ajaxRequest.makeRequest("/TaskNotification/InformativeNotifications", "POST", RequestApprovalData, InformativeNotifications.Success);
            
        }
        else if (InformativeNotifications.ActionName == "SingleRead") {
            RequestApprovalData = null;
            var Data = {
            };
            Data.NotificationTransactionID = selectedTransactionID;
            RequestApprovalData = Data;
            ajaxRequest.makeRequest("/TaskNotification/InformativeNotifications", "POST", RequestApprovalData, InformativeNotifications.SuccessSingle);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetRequestApproval: function () {
        var Data = {
        };
        if (InformativeNotifications.ActionName == "Create") {
            Data.GeneralRequestTransactionID = $('input[name=GeneralRequestTransactionID]').val();
            Data.Remark = $("#Remark").val();
            Data.RequestCode = $('#_TaskCode').val();
            if ($('#Approve').is(':checked')) {
                Data.ApprovalStatus = 1;
            }
            else if ($('#Reject').is(':checked')) {
                Data.ApprovalStatus = 0;
            }


        }


        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var splitData = data.split(',');
        InformativeNotifications.ReloadList();
        
    },
    
    SuccessSingle: function (data) {
       

    },
 
};

