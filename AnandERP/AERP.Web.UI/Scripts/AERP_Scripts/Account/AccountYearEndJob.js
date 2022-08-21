


////////////new js////////////////////////


//this class contain methods related to nationality functionality
var AccountYearEndJob = {
    //Member variables
    SelectedBalncesheetIDs: null,
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountYearEndJob.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form

        
        $('#CreateAccountYearEndJobRecord').on("click", function () {
            debugger;
            AccountYearEndJob.ActionName = "Create";
            AccountYearEndJob.getValueUsingParentTag_Check_UnCheck();
            if (AccountYearEndJob.SelectedBalncesheetIDs != "" && AccountYearEndJob.SelectedBalncesheetIDs != null) {
                AccountYearEndJob.AjaxCallAccountYearEndJob();
            }
            else {
                //  ajaxRequest.ErrorMessageForJS("Message_RecordAlreadyExists", "DivSuccessMessage");
                $('#displayErrorMessage').html("Please select at least one Balance sheet.");
                $('#displayErrorMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
           
        });

        $('#EditAccountYearEndJobRecord').on("click", function () {

            AccountYearEndJob.ActionName = "Edit";
            AccountYearEndJob.AjaxCallAccountYearEndJob();
        });

        $('#DeleteAccountYearEndJobRecord').on("click", function () {

            AccountYearEndJob.ActionName = "Delete";
            AccountYearEndJob.AjaxCallAccountYearEndJob();
        });

        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input[name="IsActive"]').removeAttr('checked');
            $('#SessionStartDatetime').focus();
            $('#Account_System').val("Cash");
            //$('input:checkbox').removeAttr('checked');
            return false;
        });



    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/AccountYearEndJob/Index',
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
            url: '/AccountYearEndJob/Index',
            success: function (data) {
                //Rebind Grid Data
               // $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAccountYearEndJob: function () {
        var AccountYearEndJobData = null;
        if (AccountYearEndJob.ActionName == "Create") {
            $("#FormCreateAccountYearEndJob").validate();
            if ($("#FormCreateAccountYearEndJob").valid()) {
                AccountYearEndJobData = null;
                AccountYearEndJobData = AccountYearEndJob.GetAccountYearEndJob();
                ajaxRequest.makeRequest("/AccountYearEndJob/Create", "POST", AccountYearEndJobData, AccountYearEndJob.Success);
            }
        }
        else if (AccountYearEndJob.ActionName == "Edit") {
            $("#FormEditAccountYearEndJob").validate();
            if ($("#FormEditAccountYearEndJob").valid()) {
                AccountYearEndJobData = null;
                AccountYearEndJobData = AccountYearEndJob.GetAccountYearEndJob();
                ajaxRequest.makeRequest("/AccountYearEndJob/Edit", "POST", AccountYearEndJobData, AccountYearEndJob.Success);
            }
        }
        else if (AccountYearEndJob.ActionName == "Delete") {
            AccountYearEndJobData = null;
            AccountYearEndJobData = AccountYearEndJob.GetAccountYearEndJob();
            ajaxRequest.makeRequest("/AccountYearEndJob/Delete", "POST", AccountYearEndJobData, AccountYearEndJob.Success);
        }
    },

    getValueUsingParentTag_Check_UnCheck: function () {

        var sList = "";
        var BalanceSheetmasterID = 0;
        var xmlParamList = "<rows>"
        //alert();
        //$('#checkboxlist input[type=checkbox]').each(function () {
        $('#checkboxlist option').each(function () {

            if ($(this).val() != "on") {
                BalanceSheetmasterID = $(this).val();
                //sArray = $(this).val().split("~");
                if (this.selected == true) {

                    //xmlInsert code here
                    xmlParamList = xmlParamList + "<row>" + "<BalancesheetMstId>" + BalanceSheetmasterID + "</BalancesheetMstId></row>";
                }

            }
            if (xmlParamList.length > 6)
                AccountYearEndJob.SelectedBalncesheetIDs = xmlParamList + "</rows>";
            else
                AccountYearEndJob.SelectedBalncesheetIDs = "";
        });
        // alert(AccountYearEndJob.SelectedBalncesheetIDs);
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountYearEndJob: function () {
        var Data = {
        };

        if (AccountYearEndJob.ActionName == "Create" || AccountYearEndJob.ActionName == "Edit") {
            debugger;
            Data.CurrentYearSessionID = $('input[name=CurrentYearSessionID]').val();
            Data.CurrenntSessionYearFromDatetime = $('#CurrenntSessionYearFromDatetime').val();
            Data.CurrenntSessionYearUptoDatetime = $('#CurrenntSessionYearUptoDatetime').val();
            Data.NextYearSessionID = $('input[name=NextYearSessionID]').val();
            Data.NextSessionYearFromDatetime = $('#NextSessionYearFromDatetime').val();
            Data.NextSessionYearUptoDatetime = $('#NextSessionYearUptoDatetime').val();
            Data.OutPutFlag = $('#OutPutFlag').val();
            Data.IsCarryForward = $('#IsCarryForward').is(":checked") ? "true" : "false";
           
            Data.CentreListXML = AccountYearEndJob.SelectedBalncesheetIDs;
            //Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;


        }
        else if (AccountYearEndJob.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        // AccountYearEndJob.ReloadList(splitData[0], splitData[1], splitData[2]);
        notify(splitData[0], splitData[1]);
        setTimeout(function () { window.location.reload(); }, 3000);

        
    },
};