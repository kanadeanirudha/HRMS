//this class contain methods related to nationality functionality
var AccountBalancesheetTypeMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountBalancesheetTypeMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form

        $('#CreateAccountBalancesheetTypeMasterRecord').on("click", function () {
            
            AccountBalancesheetTypeMaster.ActionName = "Create";
            AccountBalancesheetTypeMaster.AjaxCallAccountBalancesheetTypeMaster();
        });

        $('#EditAccountBalancesheetTypeMasterRecord').on("click", function () {
            
            AccountBalancesheetTypeMaster.ActionName = "Edit";
            AccountBalancesheetTypeMaster.AjaxCallAccountBalancesheetTypeMaster();
        });

        $('#DeleteAccountBalancesheetTypeMasterRecord').on("click", function () {

            AccountBalancesheetTypeMaster.ActionName = "Delete";
            AccountBalancesheetTypeMaster.AjaxCallAccountBalancesheetTypeMaster();
        });

        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        //$("#searchBtn").on("click", function () {
        //    $("#UserSearch").focus();
        //});

        //$("#showrecord").on("change", function () {
        //    var showRecord = $("#showrecord").val();
        //    $("select[name*='myDataTable_length']").val(showRecord);
        //    $("select[name*='myDataTable_length']").change();
        //});

        InitAnimatedBorder();
        CloseAlert();
        


        $('#AccBalsheetTypeCode').keydown(function (e) {
            AERPValidation.NotAllowSpaces(e);
        });

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Description').focus();
            return false;
        });

        $('#AccBalsheetTypeDesc').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
       
    },
    //LoadList method is used to load List page
    LoadList: function () {
        
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/AccountBalancesheetTypeMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/AccountBalancesheetTypeMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
               // $('#SuccessMessage').html(message);
                // $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAccountBalancesheetTypeMaster: function () {
        var AccountBalancesheetTypeMasterData = null;
        if (AccountBalancesheetTypeMaster.ActionName == "Create") {
            $("#FormCreateAccountBalancesheetTypeMaster").validate();
            if ($("#FormCreateAccountBalancesheetTypeMaster").valid()) {
                AccountBalancesheetTypeMasterData = null;
                AccountBalancesheetTypeMasterData = AccountBalancesheetTypeMaster.GetAccountBalancesheetTypeMaster();
                ajaxRequest.makeRequest("/AccountBalancesheetTypeMaster/Create", "POST", AccountBalancesheetTypeMasterData, AccountBalancesheetTypeMaster.Success);
            }
        }
        else if (AccountBalancesheetTypeMaster.ActionName == "Edit") {
            
            $("#FormEditAccountBalancesheetTypeMaster").validate();
            if ($("#FormEditAccountBalancesheetTypeMaster").valid()) {
                AccountBalancesheetTypeMasterData = null;
                AccountBalancesheetTypeMasterData = AccountBalancesheetTypeMaster.GetAccountBalancesheetTypeMaster();
                ajaxRequest.makeRequest("/AccountBalancesheetTypeMaster/Edit", "POST", AccountBalancesheetTypeMasterData, AccountBalancesheetTypeMaster.Success, "EditAccountBalancesheetTypeMasterRecord");
            }
        }
        else if (AccountBalancesheetTypeMaster.ActionName == "Delete") {
            
            AccountBalancesheetTypeMasterData = null;
            AccountBalancesheetTypeMasterData = AccountBalancesheetTypeMaster.GetAccountBalancesheetTypeMaster();
            ajaxRequest.makeRequest("/AccountBalancesheetTypeMaster/Delete", "POST", AccountBalancesheetTypeMasterData, AccountBalancesheetTypeMaster.Success, "DeleteAccountBalancesheetTypeMasterRecord");
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountBalancesheetTypeMaster: function () {
        var Data = {
        };
        
        if (AccountBalancesheetTypeMaster.ActionName == "Create" || AccountBalancesheetTypeMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('input[name=ID]').val();
            Data.AccBalsheetTypeDesc = $('#AccBalsheetTypeDesc').val();
            Data.AccBalsheetTypeCode = $('#AccBalsheetTypeCode').val();
            Data.AccBalsheetType = $('#AccBalsheetType :selected').val();
            Data.IsActive = $("#IsActive").is(':checked');
        }
        else if (AccountBalancesheetTypeMaster.ActionName == "Delete") {
            
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        $.magnificPopup.close();
        AccountBalancesheetTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    if (data == "True") {
    //        ReloadAccountBalsheetTypeMaster();
    //    }
    //},
    //this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    if (data == "True") {
    //        ReloadAccountBalsheetTypeMaster();
    //    }
    //},
};