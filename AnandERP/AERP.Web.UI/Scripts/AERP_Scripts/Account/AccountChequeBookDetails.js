//this class contain methods related to nationality functionality
var AccountChequeBookDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AccountChequeBookDetails.constructor();
        //AccountChequeBookDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        // Create new record
        $('#CreateAccountChequeBookDetailsRecord').on("click", function () {
            AccountChequeBookDetails.ActionName = "Create";
            AccountChequeBookDetails.AjaxCallAccountChequeBookDetails();
        });

        $('#EditInfoAccountChequeBookDetailsRecord').on('click', function () {
            //alert('Here');
         
            try {
                if ($('#ChequeDescription').val() != "") {
                    AccountChequeBookDetails.ActionName = "Edit";
                    AccountChequeBookDetails.AjaxCallEditInfoAccountChequeBookDetails();
               
                    $('#ChequeNo').val('');
                    $('#ChequeDescription').val("");
                    $("#DivChequeRemark").hide(true);



                }
                else {
                    //ajaxRequest.ErrorMessageForJS("JsValidationMessages_PleaseEnterRemark", "SuccessMessageEditView", "#FFCC80");
                    $("#displayErrorMessage p").text('Please enter remark.').closest('div').fadeIn().closest('div').addClass('alert-warning');
                    
                }

            }
            catch (e) {

            }
            finally {


            }
        });


        //$('#EditAccountChequeBookDetailsRecord').on('click', function () {

        //    AccountChequeBookDetails.ActionName = "Edit";
        //    AccountChequeBookDetails.AjaxCallAccountChequeBookDetails();
        //});

        $('#DeleteAccountChequeBookDetailsRecord').on("click", function () {

            AccountChequeBookDetails.ActionName = "Delete";
            AccountChequeBookDetails.AjaxCallAccountChequeBookDetails();
          
        });





        InitAnimatedBorder();
        CloseAlert();


    },
    //LoadList method is used to load List page
    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        if (Balancesheet != null) {
            $.ajax(

             {
                 cache: false,
                 type: "POST",
                 dataType: "html",
                 data: { "selectedBalsheet": Balancesheet },
                 url: '/AccountChequeBookDetails/List',
                 success: function (data) {
                     //Rebind Grid Data
                     $('#ListViewModel').html(data);
                 }
             });
        }
        else {
            ajaxRequest.ErrorMessageForJS("JsValidationMessages_BalancsheetnotCreatednotSelected", "SuccessMessage", "#FFCC80");
            
        }
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, accountDetails) {
        
        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            data: { "accountDetailsWithactionMode": accountDetails + ":" + actionMode },
            url: '/AccountChequeBookDetails/Edit',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    AjaxCallEditInfoAccountChequeBookDetails: function () {
        //debugger;
        var AccountChequeBookDetailsData = null;
        
        if (AccountChequeBookDetails.ActionName == "Edit") {
            $("#FormEditInfoAccountChequeBookDetails").validate();
            if ($("#FormEditInfoAccountChequeBookDetails").valid()) {
                AccountChequeBookDetailsData = null;
                AccountChequeBookDetailsData = AccountChequeBookDetails.GetAccountChequeBookDetails();
                ajaxRequest.makeRequest("/AccountChequeBookDetails/CancelCheque", "POST", AccountChequeBookDetailsData, AccountChequeBookDetails.Success, "EditInfoAccountChequeBookDetailsRecord");
         
            }
        }

    },

    //Fire ajax call to insert update and delete record
    AjaxCallAccountChequeBookDetails: function (chequeNumber, chequeBookID, accountName, accountID) {
        var AccountChequeBookDetailsData = null;
        var Data = {
        };
        Data.ChequeNo = chequeNumber;
        Data.ChequeBookID = chequeBookID;
        Data.AccountName = accountName;
        Data.AccountID = accountID;
        AccountChequeBookDetailsData = Data;
        ajaxRequest.makeRequest("/AccountChequeBookDetails/Edit", "POST", AccountChequeBookDetailsData, AccountChequeBookDetails.Success);
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountChequeBookDetails: function () {
        
        var Data = {
        };
        if (AccountChequeBookDetails.ActionName == "Edit") {

            Data.ChequeNo = $('input[name=ChequeNo]').val();
            Data.ChequeDescription = $('input[id="ChequeDescription"]').val();
            Data.ChequeBookID = $('input[name=ChequeBookID]').val();
            Data.AccountName = $('input[name=AccountName]').val();
            Data.AccountID = $('input[name=AccountID]').val();


            //Data.ChequeDescription = ('#ChequeDescription').val();
        }

        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var oTable;
        var splitData = data.errorMessage.split(',');
        var accountID = data.AccountID;
        var accountName = data.AccountName;
        if (data != null) {

            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $("#displayErrorMessage p").text('Cheque has been cancelled successfully.').closest('div').fadeIn().closest('div').addClass('alert-warning');
            oTable = $('#chequeList_DataTable').dataTable();
       
            oTable.fnReloadAjax('AccountChequeBookDetails/AjaxHandlerForEditView');
            
        }
        

    },
    
};


