//this class contain methods related to nationality functionality
var AccountGroupMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountGroupMaster.attachEvents();
    },

    //Attach all event of page
    attachEvents: function () {

        //Reset button click event function to reset all controls of form

        $('#CreateAccountGroupMasterRecord').on("click", function () {
            
            AccountGroupMaster.ActionName = "Create";
            AccountGroupMaster.AjaxCallAccountGroupMaster();
        });

        $('#EditAccountGroupMasterRecord').on("click", function () {
            
            AccountGroupMaster.ActionName = "Edit";
            AccountGroupMaster.AjaxCallAccountGroupMaster();
        });

        $('#DeleteAccountGroupMasterRecord').on("click", function () {
            
            AccountGroupMaster.ActionName = "Delete";
            AccountGroupMaster.AjaxCallAccountGroupMaster();
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
        //$(".ajax").colorbox();

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button').val("");
            //$('input:checkbox,input:radio').removeAttr('checked');
            $('#CategoryID').focus();
            $('#CategoryID').val("");
            //return true;
        });
        $('#GroupCode').keydown(function (e) {
            AERPValidation.NotAllowSpaces(e);
        });

    },
    //LoadList method is used to load List page
    LoadList: function () {
        
        $.ajax(
         {
             cache: false,
             type: "GET",
             dataType: "html",
             url: '/AccountGroupMaster/List',
             success: function (data) { 
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/AccountGroupMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAccountGroupMaster: function () {
        var AccountGroupMasterData = null;
        if (AccountGroupMaster.ActionName == "Create") {
            $("#FormCreateAccountGroupMaster").validate();
            if ($("#FormCreateAccountGroupMaster").valid()) {
                AccountGroupMasterData = null;
                AccountGroupMasterData = AccountGroupMaster.GetAccountGroupMaster();
                ajaxRequest.makeRequest("/AccountGroupMaster/Create", "POST", AccountGroupMasterData, AccountGroupMaster.Success);
            }
        }
        else if (AccountGroupMaster.ActionName == "Edit") {
            $("#FormEditAccountGroupMaster").validate();
            if ($("#FormEditAccountGroupMaster").valid()) {
                AccountGroupMasterData = null;
                AccountGroupMasterData = AccountGroupMaster.GetAccountGroupMaster();
                ajaxRequest.makeRequest("/AccountGroupMaster/Edit", "POST", AccountGroupMasterData, AccountGroupMaster.Success);
            }
        }
        else if (AccountGroupMaster.ActionName == "Delete") {
            AccountGroupMasterData = null;
            AccountGroupMasterData = AccountGroupMaster.GetAccountGroupMaster();
            ajaxRequest.makeRequest("/AccountGroupMaster/Delete", "POST", AccountGroupMasterData, AccountGroupMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountGroupMaster: function () {
        var Data = {
        };
        if (AccountGroupMaster.ActionName == "Create" || AccountGroupMaster.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.IsActive = $('input[name=IsActive]').val();
            Data.CategoryID = $('#CategoryID').val();
            Data.GroupDescription = $('input[name=GroupDescription]').val();
            Data.GroupCode = $('input[name=GroupCode]').val();
            Data.PrintingSequence = $('input[name=PrintingSequence]').val();
        }
        else if (AccountGroupMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
            Data.GroupCode = $('input[name=GroupCode]').val();
            Data.GroupDescription = $('input[name=GroupDescription]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
  
        var splitData = data.split(',');
        $.magnificPopup.close();
        AccountGroupMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
};