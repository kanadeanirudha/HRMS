//this class contain methods related to nationality functionality
var PurchaseRequirementMaster = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    RequestFlag:true,
    //Class intialisation method
    Initialize: function () {
        PurchaseRequirementMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {

        $('#CreateApprovePurchaseRequirementMaster').on("click", function () {
            //alert("asdfasdfasdf");
            PurchaseRequirementMaster.ActionName = "ApprovePurchaseRequirement";
            PurchaseRequirementMaster.RequestFlag = true;
            PurchaseRequirementMaster.GetApprovedPurchaseRequirementXmlData();
            if (PurchaseRequirementMaster.RequestFlag == false)
            {
                $("#displayErrorMessage").text("Please Enter Quantity").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
               
            }
            if (PurchaseRequirementMaster.XMLstring != null && PurchaseRequirementMaster.XMLstring != "") {
                $('#CreateApprovePurchaseRequirement').attr("disabled", true);
                PurchaseRequirementMaster.AjaxCallPurchaseRequirementMaster();
            }
            else {
                swal("No data available in table", "", "warning");
            }
        });
        $('#Quantity').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $("#tblData tbody").on("keyup", "tr td input[id^=Quantity]", function () {
            var quantity = parseFloat($(this).closest('tr').find('td input[id^=Quantity]').val());
            if (parseFloat(quantity) == 0 || parseFloat(quantity) <= 0 || parseFloat(quantity) == "") {
                $("#displayErrorMessage").text("Please enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
        });
    },

    TotalItem: function () {sss
        var length = $("#tblData tbody tr").length;
        $("#TotalItem").val(length);
    },

    ////Load method is used to load *-Load-* page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/PurchaseRequirementMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        //var SelectedCentreCode = $('#CentreCode').val();
        //var SelectedCentreName = $('#CentreCode :selected').text();
        var CentreCode = $('#SelectedCentreCode').val();

        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            data: { "actionMode": actionMode, "centerCode": CentreCode },
            url: '/PurchaseRequirementMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },
    ReloadPendingRequestList: function (message, colorCode, actionMode) {
        notify(message, colorCode);
        $('#PR').click();
        //var TaskCode = "PR";
        //$.ajax(
        //{
        //    cache: false,
        //    type: "POST",
        //    dataType: "html",
        //    data: { "actionMode": actionMode, "TaskCode": TaskCode },
        //    url: '/Home/NotificationListV2',
        //    success: function (data) {
        //        $('#content').empty().html(data);
        //        //twitter type notification
        //        notify(message, colorCode);
        //    }
        //});
    },


    GetApprovedPurchaseRequirementXmlData: function () {

        var DataArray = []; var DataArray1 = [];
        var data = $('#tblData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });
        var data = $('#tblData tbody tr td select').each(function () {
            DataArray1.push($(this).val());
        });

        var TotalRecord = DataArray.length;
        var ParameterXml = "<rows>";
        var aa = []; var TotalReject = 0; var TotalAccepted = 0;
        var Count = DataArray1.length;

        var y = 0;
        for (var x = 0; x < Count; x++) {
            if (DataArray1[x] == "3") {//3 for Reject,//2 For Pending and 1 for Approved
                TotalReject = TotalReject + 1;
            }
            else {
                TotalAccepted = TotalAccepted + 1;
            }
        }
        var v = 0;
        for (var i = 0; i < TotalRecord; i = i + 7) {
            if(DataArray[i + 1] == "" || DataArray[i + 1] == 0)
            {
                PurchaseRequirementMaster.RequestFlag = false;
            }
            ParameterXml = ParameterXml + "<row><PurchaseRequirementDetailsID>" + DataArray[i + 6] + "</PurchaseRequirementDetailsID><ItemNumber>" + DataArray[i + 0] + "</ItemNumber><Quantity>" + DataArray[i + 1] + "</Quantity><ApprovedStatus>" + DataArray1[v] + "</ApprovedStatus></row>";
            v = v + 1;
        }
        //alert(ParameterXml);
        if (ParameterXml.length > 7) {
            PurchaseRequirementMaster.XMLstring = ParameterXml + "</rows>";
            if (TotalReject > 0) {
                PurchaseRequirementMaster.ApprovedStatus = false;
            }
            else {
                PurchaseRequirementMaster.ApprovedStatus = true;
            }
        }
        else
            PurchaseRequirementMaster.XMLstring = "";


        // alert(PurchaseRequirementMaster.XMLstring);
    },
    //Fire ajax call to insert update and delete record
    AjaxCallPurchaseRequirementMaster: function () {
        var PurchaseRequirementMasterData = null;

        if (PurchaseRequirementMaster.ActionName == "ApprovePurchaseRequirement") {
            PurchaseRequirementMasterData = null;
            PurchaseRequirementMasterData = PurchaseRequirementMaster.GetPurchaseRequirementMaster();
            ajaxRequest.makeRequest("/PurchaseRequirementMaster/PurchaseRequirementRequestApprovalV2", "POST", PurchaseRequirementMasterData, PurchaseRequirementMaster.SuccessRequestList);

        }

    },
    //Get properties data from the Create, Update and Delete page
    GetPurchaseRequirementMaster: function () {
        var Data = {
        };
        if (PurchaseRequirementMaster.ActionName == "Create" || PurchaseRequirementMaster.ActionName == "Edit" || PurchaseRequirementMaster.ActionName == "ApprovePurchaseRequirement") {

            Data.ID = $('#ID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.DepartmentID = $('#DepartmentID').val();
            Data.StorageLocationID = $('#StorageLocationID').val();
            Data.Quantity = $('#Quantity').val();
            Data.Rate = $('#Rate').val();
            Data.PriorityFlag = $('#PriorityFlag').val();
            Data.Remark = $('#Remark').val();
            Data.PurchaseRequirementNumber = $('#PurchaseRequirementNumber').val();
            Data.TransDate = $('#TransDate').val();
            Data.XMLstring = PurchaseRequirementMaster.XMLstring;
            Data.SelectedCentreCode = $('#SelectedCentreCode').val();
            Data.SelectedDepartmentID = $('#SelectedDepartmentID').val();

            Data.TaskCode = "PR";
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            Data.PersonID = $('input[name=PersonID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.BalanceSheetID = $("input[name=BalanceSheetID]").val();
            Data.LocationID = $("input[name=LocationID]").val();
            Data.ApprovedStatus = PurchaseRequirementMaster.ApprovedStatus;
        }
        else if (PurchaseRequirementMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');

        parent.$.colorbox.close();
        PurchaseRequirementMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    },

    SuccessRequestList: function (data) {
        var splitData = data.split(',');
        $.magnificPopup.close();
        //$('#CreateApproveDumpAndShrinkMasterAndDetails').attr("disabled", false);
        PurchaseRequirementMaster.ReloadPendingRequestList(splitData[0], splitData[1], splitData[2]);
    },

};
