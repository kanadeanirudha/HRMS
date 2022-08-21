//this class contain methods related to nationality functionality
var CCRMLocationTypeMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMLocationTypeMaster.constructor();
        //CCRMLocationTypeMaster.initializeValidation();
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
        $('#CreateCCRMLocationTypeMasterRecord').on("click", function () {
            CCRMLocationTypeMaster.ActionName = "Create";
            CCRMLocationTypeMaster.AjaxCallCCRMLocationTypeMaster();
        });

        $('#EditCCRMLocationTypeMasterRecord').on("click", function () {

            CCRMLocationTypeMaster.ActionName = "Edit";
            CCRMLocationTypeMaster.AjaxCallCCRMLocationTypeMaster();
        });

        $('#DeleteCCRMLocationTypeMasterRecord').on("click", function () {

            CCRMLocationTypeMaster.ActionName = "Delete";
            CCRMLocationTypeMaster.AjaxCallCCRMLocationTypeMaster();
        });
        //$('#FeedbackName').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        $('#LocationType').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
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
            url: '/CCRMLocationTypeMaster/List',
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
            url: '/CCRMLocationTypeMaster/List',
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
    AjaxCallCCRMLocationTypeMaster: function () {
        var CCRMLocationTypeMasterData = null;
        if (CCRMLocationTypeMaster.ActionName == "Create") {
            $("#FormCreateCCRMLocationTypeMaster").validate();
            if ($("#FormCreateCCRMLocationTypeMaster").valid()) {
                CCRMLocationTypeMasterData = null;
                CCRMLocationTypeMasterData = CCRMLocationTypeMaster.GetCCRMLocationTypeMaster();
                ajaxRequest.makeRequest("/CCRMLocationTypeMaster/Create", "POST", CCRMLocationTypeMasterData, CCRMLocationTypeMaster.Success);
            }
        }
        else if (CCRMLocationTypeMaster.ActionName == "Edit") {
            $("#FormEditCCRMLocationTypeMaster").validate();
            if ($("#FormEditCCRMLocationTypeMaster").valid()) {
                CCRMLocationTypeMasterData = null;
                CCRMLocationTypeMasterData = CCRMLocationTypeMaster.GetCCRMLocationTypeMaster();
                ajaxRequest.makeRequest("/CCRMLocationTypeMaster/Edit", "POST", CCRMLocationTypeMasterData, CCRMLocationTypeMaster.Success);
            }
        }
        else if (CCRMLocationTypeMaster.ActionName == "Delete") {
            CCRMLocationTypeMasterData = null;
            //$("#FormCreateCCRMLocationTypeMaster").validate();
            CCRMLocationTypeMasterData = CCRMLocationTypeMaster.GetCCRMLocationTypeMaster();

            ajaxRequest.makeRequest("/CCRMLocationTypeMaster/Delete", "POST", CCRMLocationTypeMasterData, CCRMLocationTypeMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMLocationTypeMaster: function () {

        var Data = {
        };
        if (CCRMLocationTypeMaster.ActionName == "Create" || CCRMLocationTypeMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.LocationTypeCode = $('#LocationTypeCode').val();
            Data.LocationType = $('#LocationType').val();
            Data.LocationTypeDesc = $('#LocationTypeDesc').val();
            Data.ResponseTime = $('#ResponseTime').val();
            Data.ResponseUnit = $('#ResponseUnit').val();
            Data.CallCharges = $('#CallCharges').val();
            Data.Distance = $('#Distance').val();
        }
        else if (CCRMLocationTypeMaster.ActionName == "Delete") {
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

            CCRMLocationTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMLocationTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMLocationTypeMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMLocationTypeMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

