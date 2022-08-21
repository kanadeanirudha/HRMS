//this class contain methods related to nationality functionality
var CCRMServiceCallTypes = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMServiceCallTypes.constructor();
        //CCRMServiceCallTypes.initializeValidation();
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
        $('#CreateCCRMServiceCallTypesRecord').on("click", function () {
            CCRMServiceCallTypes.ActionName = "Create";
            CCRMServiceCallTypes.AjaxCallCCRMServiceCallTypes();
        });

        $('#EditCCRMServiceCallTypesRecord').on("click", function () {

            CCRMServiceCallTypes.ActionName = "Edit";
            CCRMServiceCallTypes.AjaxCallCCRMServiceCallTypes();
        });

        $('#DeleteCCRMServiceCallTypesRecord').on("click", function () {

            CCRMServiceCallTypes.ActionName = "Delete";
            CCRMServiceCallTypes.AjaxCallCCRMServiceCallTypes();
        });
        $('#CallTypeName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
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
            url: '/CCRMServiceCallTypes/List',
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
            url: '/CCRMServiceCallTypes/List',
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
    AjaxCallCCRMServiceCallTypes: function () {
        var CCRMServiceCallTypesData = null;
        if (CCRMServiceCallTypes.ActionName == "Create") {
            $("#FormCreateCCRMServiceCallTypes").validate();
            if ($("#FormCreateCCRMServiceCallTypes").valid()) {
                CCRMServiceCallTypesData = null;
                CCRMServiceCallTypesData = CCRMServiceCallTypes.GetCCRMServiceCallTypes();
                ajaxRequest.makeRequest("/CCRMServiceCallTypes/Create", "POST", CCRMServiceCallTypesData, CCRMServiceCallTypes.Success);
            }
        }
        else if (CCRMServiceCallTypes.ActionName == "Edit") {
            $("#FormEditCCRMServiceCallTypes").validate();
            if ($("#FormEditCCRMServiceCallTypes").valid()) {
                CCRMServiceCallTypesData = null;
                CCRMServiceCallTypesData = CCRMServiceCallTypes.GetCCRMServiceCallTypes();
                ajaxRequest.makeRequest("/CCRMServiceCallTypes/Edit", "POST", CCRMServiceCallTypesData, CCRMServiceCallTypes.Success);
            }
        }
        else if (CCRMServiceCallTypes.ActionName == "Delete") {
            CCRMServiceCallTypesData = null;
            //$("#FormCreateCCRMServiceCallTypes").validate();
            CCRMServiceCallTypesData = CCRMServiceCallTypes.GetCCRMServiceCallTypes();

            ajaxRequest.makeRequest("/CCRMServiceCallTypes/Delete", "POST", CCRMServiceCallTypesData, CCRMServiceCallTypes.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMServiceCallTypes: function () {

        var Data = {
        };
        if (CCRMServiceCallTypes.ActionName == "Create" || CCRMServiceCallTypes.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.CallTypeCode = $('#CallTypeCode').val();
            Data.CallTypeName = $('#CallTypeName').val();
            Data.ISCalculateResponceTime = $('input[id=CalculateResponceTime]:checked').val() ? true : false;
            Data.ISPMCall = $('input[id=PMCall]:checked').val() ? true : false;
            Data.ISServiceReportRequired = $('input[id=ServiceReportRequired]:checked').val() ? true : false;
        }
        else if (CCRMServiceCallTypes.ActionName == "Delete") {
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

            CCRMServiceCallTypes.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMServiceCallTypes.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMServiceCallTypes.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMServiceCallTypes.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

