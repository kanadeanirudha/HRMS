//this class contain methods related to nationality functionality
var AccountCategoryMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountCategoryMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form

        $('#CreateAccountCategoryMasterRecord').on("click", function () {
            AccountCategoryMaster.ActionName = "Create";
            AccountCategoryMaster.AjaxCallAccountCategoryMaster();
        });

        $('#EditAccountCategoryMasterRecord').on("click", function () {
            //alert('here');
            AccountCategoryMaster.ActionName = "Edit";
            AccountCategoryMaster.AjaxCallAccountCategoryMaster();
        });

        $('#DeleteAccountCategoryMasterRecord').on("click", function () {
            
            AccountCategoryMaster.ActionName = "Delete";
            AccountCategoryMaster.AjaxCallAccountCategoryMaster();
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
            $('#HeadID').focus();
            $('#HeadID').val("");

       });

        $('#CategoryCode').keydown(function (e) {
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
             url: '/AccountCategoryMaster/List',
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
            data: { actionMode: actionMode},
            url: '/AccountCategoryMaster/List',
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
    //ReloadList method is used to load List page
    LoadListByCentreCode: function (SelectedHeadID) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/AccountCategoryMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAccountCategoryMaster: function () {
        var AccountCategoryMasterData = null;
        if (AccountCategoryMaster.ActionName == "Create") {
            $("#FormCreateAccountCategoryMaster").validate();
            if ($("#FormCreateAccountCategoryMaster").valid()) {
                AccountCategoryMasterData = null;
                AccountCategoryMasterData = AccountCategoryMaster.GetAccountCategoryMaster();
                ajaxRequest.makeRequest("/AccountCategoryMaster/Create", "POST", AccountCategoryMasterData, AccountCategoryMaster.Success, "CreateAccountCategoryMasterRecord");
            }
        }
        else if (AccountCategoryMaster.ActionName == "Edit") {
            
            $("#FormEditAccountCategoryMaster").validate();
            if ($("#FormEditAccountCategoryMaster").valid()) { //alert('here');
                AccountCategoryMasterData = null;
                AccountCategoryMasterData = AccountCategoryMaster.GetAccountCategoryMaster();
                ajaxRequest.makeRequest("/AccountCategoryMaster/Edit", "POST", AccountCategoryMasterData, AccountCategoryMaster.Success, "EditAccountCategoryMasterRecord");
            }
        }
        else if (AccountCategoryMaster.ActionName == "Delete") {
            AccountCategoryMasterData = null;
            AccountCategoryMasterData = AccountCategoryMaster.GetAccountCategoryMaster();
            ajaxRequest.makeRequest("/AccountCategoryMaster/Delete", "POST", AccountCategoryMasterData, AccountCategoryMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountCategoryMaster: function () {
        var Data = {
        };
        if (AccountCategoryMaster.ActionName == "Create" || AccountCategoryMaster.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.HeadID = $('#HeadID').val();
            Data.CategoryCode = $('#CategoryCode').val();
            Data.CategoryDescription = $('#CategoryDescription').val();
            //Data.PrintingSequence = $('input[name=PrintingSequence]').val();
            Data.IsActive = $('input[name=IsActive]').val();
        }
        else if (AccountCategoryMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
            Data.CategoryCode = $('input[name=CategoryCode]').val();
            Data.CategoryDescription = $('input[name=CategoryDescription]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        $.magnificPopup.close();
        AccountCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    if (data == "True") {
    //        AccountCategoryMaster.ReloadList("Record Updated Sucessfully.")
    //    }
    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    if (data == "True") {
    //        AccountCategoryMaster.ReloadList("Record Deleted Sucessfully.")
    //    }
    //},
};