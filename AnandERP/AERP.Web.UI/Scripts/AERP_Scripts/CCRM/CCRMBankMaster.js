//this class contain methods related to nationality functionality
var CCRMBankMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMBankMaster.constructor();
        //CCRMBankMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SelectedRegionID').focus();
            $('#SelectedRegionID').val('');
        });

        // Create new record
        $('#CreateCCRMBankMasterRecord').on("click", function () {
            CCRMBankMaster.ActionName = "Create";
            CCRMBankMaster.AjaxCallCCRMBankMaster();
        });

        $('#EditCCRMBankMasterRecord').on("click", function () {

            CCRMBankMaster.ActionName = "Edit";
            CCRMBankMaster.AjaxCallCCRMBankMaster();
        });

        $('#DeleteCCRMBankMasterRecord').on("click", function () {

            CCRMBankMaster.ActionName = "Delete";
            CCRMBankMaster.AjaxCallCCRMBankMaster();
        });
        $('#SegementName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
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

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/CCRMBankMaster/List',
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
            url: '/CCRMBankMaster/List',
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
    AjaxCallCCRMBankMaster: function () {
        var CCRMBankMasterData = null;
        if (CCRMBankMaster.ActionName == "Create") {
            $("#FormCreateCCRMBankMaster").validate();
            if ($("#FormCreateCCRMBankMaster").valid()) {
                CCRMBankMasterData = null;
                CCRMBankMasterData = CCRMBankMaster.GetCCRMBankMaster();
                ajaxRequest.makeRequest("/CCRMBankMaster/Create", "POST", CCRMBankMasterData, CCRMBankMaster.Success);
            }
        }
        else if (CCRMBankMaster.ActionName == "Edit") {
            $("#FormEditCCRMBankMaster").validate();
            if ($("#FormEditCCRMBankMaster").valid()) {
                CCRMBankMasterData = null;
                CCRMBankMasterData = CCRMBankMaster.GetCCRMBankMaster();
                ajaxRequest.makeRequest("/CCRMBankMaster/Edit", "POST", CCRMBankMasterData, CCRMBankMaster.Success);
            }
        }
        else if (CCRMBankMaster.ActionName == "Delete") {
            CCRMBankMasterData = null;
            //$("#FormCreateCCRMBankMaster").validate();
            CCRMBankMasterData = CCRMBankMaster.GetCCRMBankMaster();

            ajaxRequest.makeRequest("/CCRMBankMaster/Delete", "POST", CCRMBankMasterData, CCRMBankMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMBankMaster: function () {

        var Data = {
        };
        if (CCRMBankMaster.ActionName == "Create" || CCRMBankMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
         
            Data.BankName = $('#BankName').val();
           
            

        }
        else if (CCRMBankMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMBankMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMBankMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMBankMaster.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {

    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        CCRMBankMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

