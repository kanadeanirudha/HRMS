//this class contain methods related to nationality functionality
var LeaveMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveMaster.constructor();
        //LeaveMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CountryName').focus();
       
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LeaveDescription').focus();
            $('#LeaveType').val(" ");
            return false;
        });


        // Create new record
        $('#CreateLeaveMasterRecord').on("click", function () {
            LeaveMaster.ActionName = "Create";
            LeaveMaster.AjaxCallLeaveMaster();
        });

        $('#EditLeaveMasterRecord').on("click", function () {
         
            LeaveMaster.ActionName = "Edit";
            LeaveMaster.AjaxCallLeaveMaster();
        });

        $('#DeleteLeaveMasterRecord').on("click", function () {

            LeaveMaster.ActionName = "Delete";
            LeaveMaster.AjaxCallLeaveMaster();
        });

        $('#LeaveDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#LeaveCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });


        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
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
    ////Load method is used to load *-Load-* page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/LeaveMaster/List',
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
            data: { "actionMode": actionMode },
            url: '/LeaveMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallLeaveMaster: function () {
        var LeaveMasterData = null;
        if (LeaveMaster.ActionName == "Create") {
            $("#FormCreateLeaveMaster").validate();
            if ($("#FormCreateLeaveMaster").valid()) {
                LeaveMasterData = null;
                LeaveMasterData = LeaveMaster.GetLeaveMaster();
                ajaxRequest.makeRequest("/LeaveMaster/Create", "POST", LeaveMasterData, LeaveMaster.Success);
            }
        }
        else if (LeaveMaster.ActionName == "Edit") {
            $("#FormEditLeaveMaster").validate();
            if ($("#FormEditLeaveMaster").valid()) {
              
                LeaveMasterData = null;
                LeaveMasterData = LeaveMaster.GetLeaveMaster();
                ajaxRequest.makeRequest("/LeaveMaster/Edit", "POST", LeaveMasterData, LeaveMaster.Success);
            }
        }
        else if (LeaveMaster.ActionName == "Delete") {
            LeaveMasterData = null;
            //$("#FormCreateLeaveMaster").validate();
            LeaveMasterData = LeaveMaster.GetLeaveMaster();
            ajaxRequest.makeRequest("/LeaveMaster/Delete", "POST", LeaveMasterData, LeaveMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveMaster: function () {
        var Data = {
        };
        if (LeaveMaster.ActionName == "Create" || LeaveMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('input[name=ID]').val();
            Data.LeaveDescription = $('#LeaveDescription').val();
            Data.LeaveCode = $('#LeaveCode').val();            
            Data.LeaveType = $('#LeaveType').val();
            //Data.IsCarryForwardForNextYear = $("input[id=IsCarryForwardForNextYear]:checked").val();
            Data.IsCarryForwardForNextYear = $("input[id=IsCarryForwardForNextYear]:checked").val() ? true : false;
            Data.MinServiceRequire = $("input[id=MinServiceRequire]:checked").val() ? true : false;
            //Data.HalfDayFlag = $("input[id=HalfDayFlag]:checked").val() ? true: false;
            Data.DocumentsNeeded = $("input[id=DocumentsNeeded]:checked").val() ? true : false;
            //Data.AttendanceNeeded = $("input[id=AttendanceNeeded]:checked").val() ? true : false;
            Data.LossOfPay = $("input[id=LossOfPay]:checked").val() ? true : false;
            //Data.NoCredit = $("input[id=NoCredit]:checked").val() ? true : false;
            Data.IsEnCash = $("input[id=IsEnCash]:checked").val() ? true : false;
            //Data.OnDuty = $("input[id=OnDuty]:checked").val() ? true : false;
            Data.NeedToInformInAdvance = $("input[id=NeedToInformInAdvance]:checked").val() ? true : false;
            Data.IsPostedOnce = $("input[id=IsPostedOnce]:checked").val() ? true : false;

        }
        else if (LeaveMaster.ActionName == "Delete") {
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
            LeaveMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {



    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        LeaveMaster.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {


    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        LeaveMaster.ReloadList("Record Deleted Sucessfully.");
    //      //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

