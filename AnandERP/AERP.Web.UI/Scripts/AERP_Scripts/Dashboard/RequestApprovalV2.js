//this class contain methods related to nationality functionality
var RequestApprovalV2 = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        RequestApprovalV2.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#Approve').focus();

        // Create new record
        $('#CreateRequestApprovalRecord').on("click", function () {
            if ($('#Remark').val() != "" && $('#Remark').val() != null) {
                RequestApprovalV2.ActionName = "Create";
                RequestApprovalV2.AjaxCallRequestApproval();
            }
            else {
                $('#Remark').focus();
                $('#CompulsoryRemark').show();
            }
        });

        $('#EditRequestApprovalRecord').on("click", function () {
            RequestApprovalV2.ActionName = "Edit";
            RequestApprovalV2.AjaxCallRequestApproval();
        });

        $('#DeleteRequestApprovalRecord').on("click", function () {
            RequestApprovalV2.ActionName = "Delete";
            RequestApprovalV2.AjaxCallRequestApproval();
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
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
        var TaskCode = $('input[name=TaskCode]').val();
        $.magnificPopup.close();
        notify(message, colorCode);
        $('#'+TaskCode).click();
        //$.ajax(
        //{
        //    cache: false,
        //    type: "POST",
        //    dataType: "html",
        //    data: { "actionMode": actionMode, "TaskCode": TaskCode },
        //    url: '/Home/NotificationListV2',
        //    success: function (data) {
        //        //Rebind Grid Data
        //        $('#content').empty().html(data);
        //        notify(message, colorCode);
        //    }
        //});
    },


    //Fire ajax call to insert update and delete record
    AjaxCallRequestApproval: function () {
        var RequestApprovalData = null;
        if (RequestApprovalV2.ActionName == "Create") {
            //$("#FormCreateRequestApproval").validate();
            //if ($("#FormCreateRequestApproval").valid()) {
            RequestApprovalData = null;
            RequestApprovalData = RequestApprovalV2.GetRequestApproval();
            ajaxRequest.makeRequest("/TaskNotification/RequestApprovalV2", "POST", RequestApprovalData, RequestApprovalV2.Success);
            //}
        }
        else if (RequestApprovalV2.ActionName == "Edit") {
            $("#FormEditRequestApproval").validate();
            if ($("#FormEditRequestApproval").valid()) {
                RequestApprovalData = null;
                RequestApprovalData = RequestApprovalV2.GetRequestApproval();
                ajaxRequest.makeRequest("/Home/Edit", "POST", RequestApprovalData, RequestApprovalV2.Success);
            }
        }
        else if (RequestApprovalV2.ActionName == "Delete") {
            RequestApprovalData = null;
            //$("#FormCreateRequestApproval").validate();
            RequestApprovalData = RequestApprovalV2.GetRequestApproval();
            ajaxRequest.makeRequest("/RequestApprovalV2/Delete", "POST", RequestApprovalData, RequestApprovalV2.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetRequestApproval: function () {
        var Data = {
        };
        if (RequestApprovalV2.ActionName == "Create") {
            debugger;
            Data.PersonID = $('input[name=PersonID]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.Remark = $("#Remark").val();
            Data.TaskCode = $('#_TaskCode').val();
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
        debugger;
        var splitData = data.split(',');
        if (data != null) {
            RequestApprovalV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            RequestApprovalV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
 
};

