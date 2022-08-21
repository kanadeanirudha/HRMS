//this class contain methods related to nationality functionality
var AccountTransactionMaster = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AccountTransactionMaster.constructor();
        //AccountTransactionMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        // Create new record


        $('#ApproveAccountVoucher').on("click", function () {
            AccountTransactionMaster.ActionName = "Approved";
            AccountTransactionMaster.GetXmlData();
            AccountTransactionMaster.AjaxCallAccountTransactionMaster();
        });

        $('#RejectAccountVoucher').on("click", function () {
            AccountTransactionMaster.ActionName = "Rejected";
            AccountTransactionMaster.GetXmlData();
            AccountTransactionMaster.AjaxCallAccountTransactionMaster();
        });




        $('ul#pending_Request li').click(function () {


            var TaskCode = $(this).attr('id');
            var RequestName = $(this).text();
            $.ajax(
                  {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: { "TaskCode": TaskCode },
                      url: '/Home/List',
                      success: function (result) {
                          $('#ListViewModel').html(result);
                      }
                  });
        });
    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/Home/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    ReloadListAfterApproval: function (meAVARge, colorCode, actionMode) {
        notify(meAVARge, colorCode);
        $('#AVAR').click();
    },


    //Fire ajax call to insert update and delete record
    AjaxCallAccountTransactionMaster: function () {
        var AccountTransactionMasterData = null;
        if (AccountTransactionMaster.ActionName == "Approved" || AccountTransactionMaster.ActionName == "Rejected") {
            AccountTransactionMasterData = null;
            AccountTransactionMasterData = AccountTransactionMaster.GetAccountTransactionMaster();
            ajaxRequest.makeRequest("/AccountTransactionMaster/AccountVoucherRequestApprovalV2", "POST", AccountTransactionMasterData, AccountTransactionMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountTransactionMaster: function () {
        var Data = {
        };
        if (AccountTransactionMaster.ActionName == "Approved" || AccountTransactionMaster.ActionName == "Rejected") {

            Data.XMLstring = AccountTransactionMaster.XMLstring
            Data.AccSessionID = $('input[name=AccSessionID]').val();
            Data.TransactionMainID = $('input[name=TransactionMainID]').val();
            Data.AccBalsheetMstID = $('input[name=AccBalsheetMstID]').val();
            Data.TransactionType = $('input[name=TransactionType]').val();
            Data.NarrationDescription = $('input[name=NarrationDescription]').val();
            Data.TransactionDate = $('input[name=TransactionDate]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.PersonID = $('input[name=PersonID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            Data.VoucherAmount = $('#tblVoucherDetails tbody tr:last').find('td').eq(1).find('b span').text();
            if (AccountTransactionMaster.ActionName == "Approved") {
                Data.RequestApprovedStatus = 1;
            }
            else {
                Data.RequestApprovedStatus = 0;
            }
        }
        return Data;
    },

    GetXmlData: function () {

        var DataArray = [];
        $('#tblVoucherDetails tbody tr td input[type="text"]').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
        var AccountTransactionMasterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 11) {
            if (DataArray[i] > 0) {
                AccountTransactionMasterXml = AccountTransactionMasterXml
                                    + "<row>"
               		                + "<TransactionSubID>" + DataArray[i] + "</TransactionSubID>"
               		                + "<AccountID>" + DataArray[i + 1] + "</AccountID>"
               		                + "<DebitCreditFlag>" + DataArray[i + 2] + "</DebitCreditFlag>"
               		                + "<TransactionAmount>" + DataArray[i + 3] + "</TransactionAmount>"
               		                + "<ChequeNo>" + DataArray[i + 4] + "</ChequeNo>"
               		                + "<ChequeDatetime>" + DataArray[i + 5] + "</ChequeDatetime>"
               		                + "<NarrationDescription>" + DataArray[i + 6] + "</NarrationDescription>"
               		                + "<BankName>" + DataArray[i + 7] + "</BankName>"
               		                + "<BranchName>" + DataArray[i + 8] + "</BranchName>"
               		                + "<PersonID>" + DataArray[i + 9] + "</PersonID>"
               		                + "<PersonType>" + DataArray[i + 10] + "</PersonType>"
               		                + "<IsActive>1</IsActive>"
               	                    + "</row>";
            }
        }
        if (AccountTransactionMasterXml.length > 6) {
            AccountTransactionMaster.XMLstring = AccountTransactionMasterXml + "</rows>";
        }
        else {
            AccountTransactionMaster.XMLstring = "";
        }
    },

    //this is used to for showing successfully record creation meAVARge and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        $.magnificPopup.close();
        AccountTransactionMaster.ReloadListAfterApproval(splitData[0], splitData[1], splitData[2]);

    },


};

