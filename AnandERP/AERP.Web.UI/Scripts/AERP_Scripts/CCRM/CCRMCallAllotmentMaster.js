//this class contain methods related to nationality functionality
var CCRMCallAllotmentMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMCallAllotmentMaster.constructor();
        //CCRMCallAllotmentMaster.initializeValidation();
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
        $('#CreateCCRMCallAllotmentMasterRecord').on("click", function () {
            CCRMCallAllotmentMaster.ActionName = "Create";
            CCRMCallAllotmentMaster.AjaxCallCCRMCallAllotmentMaster();
        });

        $('#EditCCRMCallAllotmentMasterRecord').on("click", function () {

            CCRMCallAllotmentMaster.ActionName = "Edit";
            CCRMCallAllotmentMaster.AjaxCallCCRMCallAllotmentMaster();
        });

        $('#DeleteCCRMCallAllotmentMasterRecord').on("click", function () {

            CCRMCallAllotmentMaster.ActionName = "Delete";
            CCRMCallAllotmentMaster.AjaxCallCCRMCallAllotmentMaster();
        });
        //$('#ActionTitle').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        //$('#FeedbackPoints').on("keydown", function (e) {
        //    AERPValidation.AllowNumbersOnly(e);
        //});

        $('#AllotDate').datetimepicker({
            format: 'DD MMM YYYY hh:mm',
            //allowInputToggle: true
            // maxDate: moment(),
           // inline: true,
            // sideBySide: true
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
            url: '/CCRMCallAllotmentMaster/List',
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
            url: '/CCRMCallAllotmentMaster/List',
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
    AjaxCallCCRMCallAllotmentMaster: function () {
        var CCRMCallAllotmentMasterData = null;
        if (CCRMCallAllotmentMaster.ActionName == "Create") {
            $("#FormCreateCCRMCallAllotmentMaster").validate();
            if ($("#FormCreateCCRMCallAllotmentMaster").valid()) {
                CCRMCallAllotmentMasterData = null;
                CCRMCallAllotmentMasterData = CCRMCallAllotmentMaster.GetCCRMCallAllotmentMaster();
                ajaxRequest.makeRequest("/CCRMCallAllotmentMaster/Create", "POST", CCRMCallAllotmentMasterData, CCRMCallAllotmentMaster.Success);
            }
        }
        else if (CCRMCallAllotmentMaster.ActionName == "Edit") {
            $("#FormEditCCRMCallAllotmentMaster").validate();
            if ($("#FormEditCCRMCallAllotmentMaster").valid()) {
                CCRMCallAllotmentMasterData = null;
                CCRMCallAllotmentMasterData = CCRMCallAllotmentMaster.GetCCRMCallAllotmentMaster();
                ajaxRequest.makeRequest("/CCRMCallAllotmentMaster/Edit", "POST", CCRMCallAllotmentMasterData, CCRMCallAllotmentMaster.Success);
            }
        }
        else if (CCRMCallAllotmentMaster.ActionName == "Delete") {
            CCRMCallAllotmentMasterData = null;
            //$("#FormCreateCCRMCallAllotmentMaster").validate();
            CCRMCallAllotmentMasterData = CCRMCallAllotmentMaster.GetCCRMCallAllotmentMaster();

            ajaxRequest.makeRequest("/CCRMCallAllotmentMaster/Delete", "POST", CCRMCallAllotmentMasterData, CCRMCallAllotmentMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMCallAllotmentMaster: function () {

        var Data = {
        };
        if (CCRMCallAllotmentMaster.ActionName == "Create" || CCRMCallAllotmentMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();

            Data.CallTktNo = $('#CallTktNo').val();
            Data.CallDate = $('#CallDate').val();
            Data.SerialNo = $('#SerialNo').val();
            Data.ModelNo = $('#ModelNo').val();        
            Data.MIFName = $('#MIFName').val();
            Data.ItemDescription = $('#ItemDescription').val();
            //Data.CustApproval = $('input[id=CustApproval]:checked').val() ? true : false;
            Data.eMail = $('#eMail').val();
            Data.CallerName = $('#CallerName').val();
            Data.CallerPh = $('#CallerPh').val();
            Data.ComPlaint = $('#ComPlaint').val();
            Data.SerEnggName = $('#EmployeeName').val();
            Data.EnggMobNo = $('#EnggMobNo').val();
            Data.CallType = $('#CallType').val();
            Data.CallTypeID = $('#CallTypeID').val();
            Data.SymptomTitle = $('#SymptomTitle').val();
            Data.Priority = $('#Priority').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.AdminRoleMasterID = $('#AdminRoleMasterID').val();
            Data.RightName = $('#RightName').val();
            Data.EmployeeID = $('#EmployeeID').val();
            Data.EmployeeCode = $('#EmployeeCode').val();
            Data.EmployeeName = $('#EmployeeName').val();
            Data.Allotment = $('input[id=Allotment]:checked').val() ? true : false;
            Data.AllotPeriod = $('#AllotPeriod').val();
            Data.CallStatus = $('#CallStatus').val();
            Data.AllotEnggName = $('#EmployeeName').val();
            Data.UserName = $('#UserName').val();
            Data.UserID = $('#UserID').val();
            Data.AllotDate = $('#AllotDate').val();
            Data.EngineerID = $('#EngineerID').val();
        }
        else if (CCRMCallAllotmentMaster.ActionName == "Delete") {
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

            CCRMCallAllotmentMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMCallAllotmentMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMCallAllotmentMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMCallAllotmentMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

