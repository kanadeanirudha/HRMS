//this class contain methods related to nationality functionality
var CCRMMachineMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMMachineMaster.constructor();
        //CCRMMachineMaster.initializeValidation();
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
        $('#CreateCCRMMachineMasterRecord').on("click", function () {
            CCRMMachineMaster.ActionName = "Create";
            CCRMMachineMaster.AjaxCallCCRMMachineMaster();
        });

        $('#EditCCRMMachineMasterRecord').on("click", function () {

            CCRMMachineMaster.ActionName = "Edit";
            CCRMMachineMaster.AjaxCallCCRMMachineMaster();
        });

        //$('#DeleteCCRMMachineMasterRecord').on("click", function () {

        //    CCRMMachineMaster.ActionName = "Delete";
        //    CCRMMachineMaster.AjaxCallCCRMMachineMaster();
        //});
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
            url: '/CCRMMachineMaster/List',
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
            url: '/CCRMMachineMaster/List',
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
    AjaxCallCCRMMachineMaster: function () {
        var CCRMMachineMasterData = null;
        if (CCRMMachineMaster.ActionName == "Create") {
            $("#FormCreateCCRMMachineMaster").validate();
            if ($("#FormCreateCCRMMachineMaster").valid()) {
                CCRMMachineMasterData = null;
                CCRMMachineMasterData = CCRMMachineMaster.GetCCRMMachineMaster();
                ajaxRequest.makeRequest("/CCRMMachineMaster/Create", "POST", CCRMMachineMasterData, CCRMMachineMaster.Success);
            }
        }
        else if (CCRMMachineMaster.ActionName == "Edit") {
            $("#FormEditCCRMMachineMaster").validate();
            if ($("#FormEditCCRMMachineMaster").valid()) {
                CCRMMachineMasterData = null;
                CCRMMachineMasterData = CCRMMachineMaster.GetCCRMMachineMaster();
                ajaxRequest.makeRequest("/CCRMMachineMaster/Edit", "POST", CCRMMachineMasterData, CCRMMachineMaster.Success);
            }
        }
        else if (CCRMMachineMaster.ActionName == "Delete") {
            CCRMMachineMasterData = null;
            //$("#FormCreateCCRMMachineMaster").validate();
            CCRMMachineMasterData = CCRMMachineMaster.GetCCRMMachineMaster();

            ajaxRequest.makeRequest("/CCRMMachineMaster/Delete", "POST", CCRMMachineMasterData, CCRMMachineMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMMachineMaster: function () {

        var Data = {
        };
        if (CCRMMachineMaster.ActionName == "Create" || CCRMMachineMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
           
            Data.ItemNumber = $('#ItemNumber').val();
            debugger;
            Data.MachineFamilyMasterID = $('#MachineFamilyMasterID').val();
           
            Data.MachineType = $('#MachineType').val();
            Data.ColorMono = $('#ColorMono').val();
            Data.PaperSize = $('#PaperSize').val();
            Data.Warrenty = $('#Warrenty').val();
            Data.LifeInYears = $('#LifeInYears').val();
            Data.lifeInCopies = $('#lifeInCopies').val();
            Data.PMPeriods = $('#PMPeriods').val();
            Data.Isreturnable = $('#Isreturnable').is(":checked") ? "true" : "false";
            Data.Frequency = $('#Frequency').val();
        }
        else if (CCRMMachineMaster.ActionName == "Delete") {
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

            CCRMMachineMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMMachineMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMMachineMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMMachineMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

