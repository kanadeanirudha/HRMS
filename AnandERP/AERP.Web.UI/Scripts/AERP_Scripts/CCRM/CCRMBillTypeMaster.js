//this class contain methods related to nationality functionality
var CCRMBillTypeMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMBillTypeMaster.constructor();
        //CCRMBillTypeMaster.initializeValidation();
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
        $('#CreateCCRMBillTypeMasterRecord').on("click", function () {
            CCRMBillTypeMaster.ActionName = "Create";
            CCRMBillTypeMaster.AjaxCallCCRMBillTypeMaster();
        });

        $('#EditCCRMBillTypeMasterRecord').on("click", function () {

            CCRMBillTypeMaster.ActionName = "Edit";
            CCRMBillTypeMaster.AjaxCallCCRMBillTypeMaster();
        });

        $('#DeleteCCRMBillTypeMasterRecord').on("click", function () {

            CCRMBillTypeMaster.ActionName = "Delete";
            CCRMBillTypeMaster.AjaxCallCCRMBillTypeMaster();
        });
        //$('#ActionTitle').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        //$('#FeedbackPoints').on("keydown", function (e) {
        //    AERPValidation.AllowNumbersOnly(e);
        //});
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
            url: '/CCRMBillTypeMaster/List',
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
            url: '/CCRMBillTypeMaster/List',
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
    AjaxCallCCRMBillTypeMaster: function () {
        var CCRMBillTypeMasterData = null;
        if (CCRMBillTypeMaster.ActionName == "Create") {
            $("#FormCreateCCRMBillTypeMaster").validate();
            if ($("#FormCreateCCRMBillTypeMaster").valid()) {
                CCRMBillTypeMasterData = null;
                CCRMBillTypeMasterData = CCRMBillTypeMaster.GetCCRMBillTypeMaster();
                ajaxRequest.makeRequest("/CCRMBillTypeMaster/Create", "POST", CCRMBillTypeMasterData, CCRMBillTypeMaster.Success);
            }
        }
        else if (CCRMBillTypeMaster.ActionName == "Edit") {
            $("#FormEditCCRMBillTypeMaster").validate();
            if ($("#FormEditCCRMBillTypeMaster").valid()) {
                CCRMBillTypeMasterData = null;
                CCRMBillTypeMasterData = CCRMBillTypeMaster.GetCCRMBillTypeMaster();
                ajaxRequest.makeRequest("/CCRMBillTypeMaster/Edit", "POST", CCRMBillTypeMasterData, CCRMBillTypeMaster.Success);
            }
        }
        else if (CCRMBillTypeMaster.ActionName == "Delete") {
            CCRMBillTypeMasterData = null;
            //$("#FormCreateCCRMBillTypeMaster").validate();
            CCRMBillTypeMasterData = CCRMBillTypeMaster.GetCCRMBillTypeMaster();

            ajaxRequest.makeRequest("/CCRMBillTypeMaster/Delete", "POST", CCRMBillTypeMasterData, CCRMBillTypeMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMBillTypeMaster: function () {

        var Data = {
        };
        if (CCRMBillTypeMaster.ActionName == "Create" || CCRMBillTypeMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.BillTypeName = $('#BillTypeName').val();
            Data.BillPrefix = $('#BillPrefix').val();
            Data.BillType = $('#BillType').val();


        }
        else if (CCRMBillTypeMaster.ActionName == "Delete") {
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

            CCRMBillTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMBillTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMBillTypeMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMBillTypeMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

