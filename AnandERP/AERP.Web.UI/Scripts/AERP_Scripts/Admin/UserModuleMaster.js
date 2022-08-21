﻿////this class contain methods related to nationality functionality
//var UserModuleMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        UserModuleMaster.constructor();
//        //UserModuleMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#ModuleName').focus();
//            $('#ModuleName').val('');
//            $('# ModuleCode').val('');
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#ModuleSeqNumber').val(0);
//            $('#ModuleRelatedWith').val('');
//            $('#ModuleTooltip').val('');
//            $('#ModuleIconName').val('');
//            $('#ModuleIconPath').val('');
//            $('#ModuleFormName').val('');         
            
//            return false;
//        });

//        // Create new record
//        $('#CreateUserModuleMasterRecord').on("click", function () {
            
//            UserModuleMaster.ActionName = "Create";
//            UserModuleMaster.AjaxCallUserModuleMaster();
//        });

//        $('#EditUserModuleMasterRecord').on("click", function () {
//            ;
//            UserModuleMaster.ActionName = "Edit";
//            UserModuleMaster.AjaxCallUserModuleMaster();
//        });

//        $('#DeleteUserModuleMasterRecord').on("click", function () {

//            UserModuleMaster.ActionName = "Delete";
//            UserModuleMaster.AjaxCallUserModuleMaster();
//        });
//        $('#SeqNo').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();

//        $('#ModuleName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#ModuleCode').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//    },
//    //LoadList method is used to load List page
//    LoadList: function () {
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/UserModuleMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { "actionMode": actionMode },
//            url: '/UserModuleMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallUserModuleMaster: function () {
//        var UserModuleMasterData = null;
//        if (UserModuleMaster.ActionName == "Create") {
//            $("#FormCreateUserModuleMaster").validate();
//            if ($("#FormCreateUserModuleMaster").valid()) {
//                UserModuleMasterData = null;
//                UserModuleMasterData = UserModuleMaster.GetUserModuleMaster();
//                ajaxRequest.makeRequest("/UserModuleMaster/Create", "POST", UserModuleMasterData, UserModuleMaster.Success);
//            }
//        }
//        else if (UserModuleMaster.ActionName == "Edit") {
//            $("#FormEditUserModuleMaster").validate();
//            if ($("#FormEditUserModuleMaster").valid()) {
//                UserModuleMasterData = null;
//                UserModuleMasterData = UserModuleMaster.GetUserModuleMaster();
//                ajaxRequest.makeRequest("/UserModuleMaster/Edit", "POST", UserModuleMasterData, UserModuleMaster.Success);
//            }
//        }
//        else if (UserModuleMaster.ActionName == "Delete") {
//            UserModuleMasterData = null;
//            //$("#FormCreateUserModuleMaster").validate();
//            UserModuleMasterData = UserModuleMaster.GetUserModuleMaster();
        
//            ajaxRequest.makeRequest("/UserModuleMaster/Delete", "POST", UserModuleMasterData, UserModuleMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetUserModuleMaster: function () {
        
//        var Data = {
//        };
//        if (UserModuleMaster.ActionName == "Create" || UserModuleMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.ModuleName = $('#ModuleName').val();
//            Data.ModuleCode = $('#ModuleCode').val();
//            Data.ModuleInstalledFlag = $('#ModuleInstalledFlag:checked').val() ? true : false;
//            Data.ModuleActiveFlag = $('#ModuleActiveFlag:checked').val() ? true : false;
//            Data.ModuleSeqNumber = $('#ModuleSeqNumber').val();
//            Data.ModuleRelatedWith = $('#ModuleRelatedWith').val();
//            Data.ModuleTooltip = $('#ModuleTooltip').val();
//            Data.ModuleIconName = $('#ModuleIconName').val();
//            Data.ModuleIconPath = $('#ModuleIconPath').val();
//            Data.ModuleFormName = $('#ModuleFormName').val();
//        }
//        else if (UserModuleMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            UserModuleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            UserModuleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        UserModuleMaster.ReloadList("Record Updated Sucessfully.");
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {

//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        UserModuleMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

////////////////new js////////////////////////

//this class contain methods related to nationality functionality
var UserModuleMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        UserModuleMaster.constructor();
        //UserModuleMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#ModuleName').focus();
            $('#ModuleName').val('');
            $('# ModuleCode').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#ModuleSeqNumber').val(0);
            $('#ModuleRelatedWith').val('');
            $('#ModuleTooltip').val('');
            $('#ModuleIconName').val('');
            $('#ModuleIconPath').val('');
            $('#ModuleFormName').val('');

            return false;
        });

        // Create new record
        $('#CreateUserModuleMasterRecord').on("click", function () {

            UserModuleMaster.ActionName = "Create";
            UserModuleMaster.AjaxCallUserModuleMaster();
        });

        $('#EditUserModuleMasterRecord').on("click", function () {
            ;
            UserModuleMaster.ActionName = "Edit";
            UserModuleMaster.AjaxCallUserModuleMaster();
        });

        $('#DeleteUserModuleMasterRecord').on("click", function () {

            UserModuleMaster.ActionName = "Delete";
            UserModuleMaster.AjaxCallUserModuleMaster();
        });
        $('#SeqNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
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

        $('#ModuleName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#ModuleCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/UserModuleMaster/List',
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
            url: '/UserModuleMaster/List',
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
    AjaxCallUserModuleMaster: function () {
        var UserModuleMasterData = null;
        if (UserModuleMaster.ActionName == "Create") {
            $("#FormCreateUserModuleMaster").validate();
            if ($("#FormCreateUserModuleMaster").valid()) {
                UserModuleMasterData = null;
                UserModuleMasterData = UserModuleMaster.GetUserModuleMaster();
                ajaxRequest.makeRequest("/UserModuleMaster/Create", "POST", UserModuleMasterData, UserModuleMaster.Success);
            }
        }
        else if (UserModuleMaster.ActionName == "Edit") {
            $("#FormEditUserModuleMaster").validate();
            if ($("#FormEditUserModuleMaster").valid()) {
                UserModuleMasterData = null;
                UserModuleMasterData = UserModuleMaster.GetUserModuleMaster();
                ajaxRequest.makeRequest("/UserModuleMaster/Edit", "POST", UserModuleMasterData, UserModuleMaster.Success);
            }
        }
        else if (UserModuleMaster.ActionName == "Delete") {
            UserModuleMasterData = null;
            //$("#FormCreateUserModuleMaster").validate();
            UserModuleMasterData = UserModuleMaster.GetUserModuleMaster();

            ajaxRequest.makeRequest("/UserModuleMaster/Delete", "POST", UserModuleMasterData, UserModuleMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetUserModuleMaster: function () {

        var Data = {
        };
        if (UserModuleMaster.ActionName == "Create" || UserModuleMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.ModuleName = $('#ModuleName').val();
            Data.ModuleCode = $('#ModuleCode').val();
            Data.ModuleInstalledFlag = $('#ModuleInstalledFlag:checked').val() ? true : false;
            Data.ModuleActiveFlag = $('#ModuleActiveFlag:checked').val() ? true : false;
            Data.ModuleSeqNumber = $('#ModuleSeqNumber').val();
            Data.ModuleRelatedWith = $('#ModuleRelatedWith').val();
            Data.ModuleTooltip = $('#ModuleTooltip').val();
            Data.ModuleIconName = $('#ModuleIconName').val();
            Data.ModuleIconPath = $('#ModuleIconPath').val();
            Data.ModuleFormName = $('#ModuleFormName').val();
        }
        else if (UserModuleMaster.ActionName == "Delete") {
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
            UserModuleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            UserModuleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

