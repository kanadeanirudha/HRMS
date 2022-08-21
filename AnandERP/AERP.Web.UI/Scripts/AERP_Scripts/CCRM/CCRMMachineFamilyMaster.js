//this class contain methods related to nationality functionality
var CCRMMachineFamilyMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMMachineFamilyMaster.constructor();
        //CCRMMachineFamilyMaster.initializeValidation();
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
        $('#CreateCCRMMachineFamilyMasterRecord').on("click", function () {
            CCRMMachineFamilyMaster.ActionName = "Create";
            CCRMMachineFamilyMaster.AjaxCallCCRMMachineFamilyMaster();
        });

        $('#EditCCRMMachineFamilyMasterRecord').on("click", function () {

            CCRMMachineFamilyMaster.ActionName = "Edit";
            CCRMMachineFamilyMaster.AjaxCallCCRMMachineFamilyMaster();
        });

        $('#DeleteCCRMMachineFamilyMasterRecord').on("click", function () {

            CCRMMachineFamilyMaster.ActionName = "Delete";
            CCRMMachineFamilyMaster.AjaxCallCCRMMachineFamilyMaster();
        });
        //$('#MachineFamilyName').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
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
            url: '/CCRMMachineFamilyMaster/List',
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
            url: '/CCRMMachineFamilyMaster/List',
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
    AjaxCallCCRMMachineFamilyMaster: function () {
        var CCRMMachineFamilyMasterData = null;
        if (CCRMMachineFamilyMaster.ActionName == "Create") {
            $("#FormCreateCCRMMachineFamilyMaster").validate();
            if ($("#FormCreateCCRMMachineFamilyMaster").valid()) {
                CCRMMachineFamilyMasterData = null;
                CCRMMachineFamilyMasterData = CCRMMachineFamilyMaster.GetCCRMMachineFamilyMaster();
                ajaxRequest.makeRequest("/CCRMMachineFamilyMaster/Create", "POST", CCRMMachineFamilyMasterData, CCRMMachineFamilyMaster.Success);
            }
        }
        else if (CCRMMachineFamilyMaster.ActionName == "Edit") {
            $("#FormEditCCRMMachineFamilyMaster").validate();
            if ($("#FormEditCCRMMachineFamilyMaster").valid()) {
                CCRMMachineFamilyMasterData = null;
                CCRMMachineFamilyMasterData = CCRMMachineFamilyMaster.GetCCRMMachineFamilyMaster();
                ajaxRequest.makeRequest("/CCRMMachineFamilyMaster/Edit", "POST", CCRMMachineFamilyMasterData, CCRMMachineFamilyMaster.Success);
            }
        }
        else if (CCRMMachineFamilyMaster.ActionName == "Delete") {
            CCRMMachineFamilyMasterData = null;
            //$("#FormCreateCCRMMachineFamilyMaster").validate();
            CCRMMachineFamilyMasterData = CCRMMachineFamilyMaster.GetCCRMMachineFamilyMaster();

            ajaxRequest.makeRequest("/CCRMMachineFamilyMaster/Delete", "POST", CCRMMachineFamilyMasterData, CCRMMachineFamilyMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMMachineFamilyMaster: function () {

        var Data = {
        };
        if (CCRMMachineFamilyMaster.ActionName == "Create" || CCRMMachineFamilyMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.MachineFamilyName = $('#MachineFamilyName').val();



        }
        else if (CCRMMachineFamilyMaster.ActionName == "Delete") {
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

            CCRMMachineFamilyMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMMachineFamilyMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMMachineFamilyMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMMachineFamilyMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

