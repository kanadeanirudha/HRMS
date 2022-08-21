////this class contain methods related to nationality functionality
//var UserMainMenuMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        UserMainMenuMaster.constructor();
//        //generalCountryMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

      
//        $("#DisableDate").datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            yearRange: '1950:document.write(currentYear.getFullYear()',
//            //numberOfMonths: 1,
//            //dateFormat: 'dd/mm/yy',
//            //minDate: new Date(),
//        });

//        $("#DisableDate_Clear").click(function () {
//            $('#DisableDate').val("");
//        });
     
//        if ($('input[name=IsParent]').val() == "True") {
//            $('#ParentMenuNameID').hide();
//            $('#MenuLink').val('#');
//        }       

//        $('#IsParentYES').click(function () {            
//            $('#ParentMenuNameID').fadeOut();

//        });
//        $('#IsParentNO').click(function () {
//            $('#ParentMenuNameID').fadeIn();

//        });

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#DesignationIdWithName').focus();
//            //var dt = new Date();
//            // document.write("getYear() : " + dt.getYear());
//            $('#DesignationIdWithName').val('');
//            $('#Posttype').val(0);
//            $('#Designationtype').val(0);
//            $('#NoOfPosts').val('0');
//            $("#DisableDate").val('01/01/0001 12:00:00 AM');
//            return false;
//        });

//        // Create new record
//        $('#CreateUserMainMenuMasterRecord').on("click", function () {

//            UserMainMenuMaster.ActionName = "Create";
//            UserMainMenuMaster.AjaxCallUserMainMenuMaster();
//        });

//        $('#EditUserMainMenuMasterRecord').on("click", function () {
       
//            UserMainMenuMaster.ActionName = "Edit";
//            UserMainMenuMaster.AjaxCallUserMainMenuMaster();
//        });

//        $('#DeleteUserMainMenuMasterRecord').on("click", function () {

//            UserMainMenuMaster.ActionName = "Delete";
//            UserMainMenuMaster.AjaxCallUserMainMenuMaster();
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

//        $('#MenuInnerLevel').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#MenuName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
        
//        $('#MenuCode').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#MenuLink').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });
        
//        $('#RemarkAboutDisable').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);           
//        });        

//        $('#MenuToolTip').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//    },
//    //LoadList method is used to load List page
//    LoadList: function () {
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/UserMainMenuMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//                 $('#btnCreate').hide();
//             }
//         });
//        $('#btnCreate').hide();
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { "actionMode": actionMode },
//            url: '/UserMainMenuMaster/List',
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
//    AjaxCallUserMainMenuMaster: function () {
//        var UserMainMenuMasterData = null;
//        if (UserMainMenuMaster.ActionName == "Create") {
//            $("#FormCreateUserMainMenuMaster").validate();
//            if ($("#FormCreateUserMainMenuMaster").valid()) {
//                UserMainMenuMasterData = null;
//                UserMainMenuMasterData = UserMainMenuMaster.GetUserMainMenuMaster();
//                ajaxRequest.makeRequest("/UserMainMenuMaster/Create", "POST", UserMainMenuMasterData, UserMainMenuMaster.Success);
//            }
//        }
//        else if (UserMainMenuMaster.ActionName == "Edit") {
//            $("#FormEditUserMainMenuMaster").validate();
//            if ($("#FormEditUserMainMenuMaster").valid()) {
//                UserMainMenuMasterData = null;
//                UserMainMenuMasterData = UserMainMenuMaster.GetUserMainMenuMaster();
//                ajaxRequest.makeRequest("/UserMainMenuMaster/Edit", "POST", UserMainMenuMasterData, UserMainMenuMaster.Success);
//            }
//        }
//        else if (UserMainMenuMaster.ActionName == "Delete") {
//            UserMainMenuMasterData = null;
//            //$("#FormCreateUserMainMenuMaster").validate();
//            UserMainMenuMasterData = UserMainMenuMaster.GetUserMainMenuMaster();
//            ajaxRequest.makeRequest("/UserMainMenuMaster/Delete", "POST", UserMainMenuMasterData, UserMainMenuMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetUserMainMenuMaster: function () {
//        var Data = {
//        };
//        if (UserMainMenuMaster.ActionName == "Create") {
//            Data.ID = $('input[name=ID]').val();
//            Data.ModuleID = $('input[name=ModuleID]').val();
//            Data.ModuleCode = $('input[name=ModuleCode]').val();
//            Data.MenuName = $('#MenuName').val();
//            Data.MenuCode = $('#MenuCode').val();
//            Data.MenuInnerLevel = $('#MenuInnerLevel').val();
//            if ($('#IsParentNO').is(':checked')) {
//                Data.ParentMenuID = $('#UserParentMenuList :selected').val();
//                Data.ParentMenuName = $('#UserParentMenuList :selected').text();
//                Data.IsParent = 0;
//            }
//            else if ($('#IsParentYES').is(':checked')) {
//                Data.ParentMenuID = 0;
//                Data.ParentMenuName = $('#MenuName').val();
//                Data.IsParent = 1;
//            }
//            Data.MenuLink = $('#MenuLink').val();
//            Data.IsEnable = $('#IsEnable:checked').val() ? true : false;
//            Data.DisableDate = $('#DisableDate').val();
//            Data.RemarkAboutDisable = $('#RemarkAboutDisable').val();
//            Data.MenuToolTip = $('#MenuToolTip').val();
//            Data.MenuIconName = $('#MenuIconName').val();
//        }
//        else if (UserMainMenuMaster.ActionName == "Edit") {
//            Data.ID = $('input[name=ID]').val();
//            Data.ModuleID = $('input[name=ModuleID]').val();
//            Data.ModuleCode = $('input[name=ModuleCode]').val();
//            Data.MenuName = $('#MenuName').val();
//            Data.MenuCode = $('#MenuCode').val();
//            Data.MenuInnerLevel = $('#MenuInnerLevel').val();
//            if ($('#IsParentNO').is(':checked')) {
//                Data.ParentMenuID = $('#UserParentMenuList :selected').val();
//                Data.ParentMenuName = $('#UserParentMenuList :selected').text();
//                Data.IsParent = 0;
//            }
//            else if ($('#IsParentYES').is(':checked')) {
//                Data.ParentMenuID = 0;
//                Data.ParentMenuName = $('#MenuName').val();
//                Data.IsParent = 1;
//            }
//            Data.MenuLink = $('#MenuLink').val();
//            Data.IsEnable = $('#IsEnable:checked').val() ? true : false;
//            Data.DisableDate = $('#DisableDate').val();
//            Data.RemarkAboutDisable = $('#RemarkAboutDisable').val();
//            Data.MenuToolTip = $('#MenuToolTip').val();
//            Data.MenuIconName = $('#MenuIconName').val();
//        }
//        else if (UserMainMenuMaster.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();
//            //Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
//            //Data.DepartmentIdWithName = $('input[name=SelectedDepartmentID]').val();
//        }
//        return Data;
//    },
//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            UserMainMenuMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            UserMainMenuMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        UserMainMenuMaster.ReloadList("Record Updated Sucessfully.");
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
//    //        UserMainMenuMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

///////////////////////new js////////////////////////////


//this class contain methods related to nationality functionality
var UserMainMenuMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        UserMainMenuMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {


        //$("#DisableDate").datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //    //numberOfMonths: 1,
        //    //dateFormat: 'dd/mm/yy',
        //    //minDate: new Date(),
        //});

        $('#DisableDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });


        $("#DisableDate_Clear").click(function () {
            $('#DisableDate').val("");
        });

        if ($('input[name=IsParent]').val() == "True") {
            $('#ParentMenuNameID').hide();
            $('#MenuLink').val('#');
        }

        $('#IsParentYES').click(function () {
            $('#ParentMenuNameID').fadeOut();

        });
        $('#IsParentNO').click(function () {
            $('#ParentMenuNameID').fadeIn();

        });

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#DesignationIdWithName').focus();
            //var dt = new Date();
            // document.write("getYear() : " + dt.getYear());
            $('#DesignationIdWithName').val('');
            $('#Posttype').val(0);
            $('#Designationtype').val(0);
            $('#NoOfPosts').val('0');
            //$("#DisableDate").val('01/01/0001 12:00:00 AM');
            $("#DisableDate").val('01 January 0001');
            return false;
        });

        // Create new record
        $('#CreateUserMainMenuMasterRecord').on("click", function () {

            UserMainMenuMaster.ActionName = "Create";
            UserMainMenuMaster.AjaxCallUserMainMenuMaster();
        });

        $('#EditUserMainMenuMasterRecord').on("click", function () {

            UserMainMenuMaster.ActionName = "Edit";
            UserMainMenuMaster.AjaxCallUserMainMenuMaster();
        });

        $('#DeleteUserMainMenuMasterRecord').on("click", function () {

            UserMainMenuMaster.ActionName = "Delete";
            UserMainMenuMaster.AjaxCallUserMainMenuMaster();
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

        $('#MenuInnerLevel').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MenuName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MenuCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#MenuLink').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#RemarkAboutDisable').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MenuToolTip').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/UserMainMenuMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
                 $('#btnCreate').hide();
             }
         });
        $('#btnCreate').hide();
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/UserMainMenuMaster/List',
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
    AjaxCallUserMainMenuMaster: function () {
        var UserMainMenuMasterData = null;
        if (UserMainMenuMaster.ActionName == "Create") {
            $("#FormCreateUserMainMenuMaster").validate();
            if ($("#FormCreateUserMainMenuMaster").valid()) {
                UserMainMenuMasterData = null;
                UserMainMenuMasterData = UserMainMenuMaster.GetUserMainMenuMaster();
                ajaxRequest.makeRequest("/UserMainMenuMaster/Create", "POST", UserMainMenuMasterData, UserMainMenuMaster.Success);
            }
        }
        else if (UserMainMenuMaster.ActionName == "Edit") {
            $("#FormEditUserMainMenuMaster").validate();
            if ($("#FormEditUserMainMenuMaster").valid()) {
                UserMainMenuMasterData = null;
                UserMainMenuMasterData = UserMainMenuMaster.GetUserMainMenuMaster();
                ajaxRequest.makeRequest("/UserMainMenuMaster/Edit", "POST", UserMainMenuMasterData, UserMainMenuMaster.Success);
            }
        }
        else if (UserMainMenuMaster.ActionName == "Delete") {
            UserMainMenuMasterData = null;
            //$("#FormCreateUserMainMenuMaster").validate();
            UserMainMenuMasterData = UserMainMenuMaster.GetUserMainMenuMaster();
            ajaxRequest.makeRequest("/UserMainMenuMaster/Delete", "POST", UserMainMenuMasterData, UserMainMenuMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetUserMainMenuMaster: function () {
        var Data = {
        };
        if (UserMainMenuMaster.ActionName == "Create") {
            Data.ID = $('input[name=ID]').val();
            Data.ModuleID = $('input[name=ModuleID]').val();
            Data.ModuleCode = $('input[name=ModuleCode]').val();
            Data.MenuName = $('#MenuName').val();
            Data.MenuCode = $('#MenuCode').val();
            Data.MenuInnerLevel = $('#MenuInnerLevel').val();
            if ($('#IsParentNO').is(':checked')) {
                //Data.ParentMenuID = $('#UserParentMenuList :selected').val();
                Data.ParentMenuID = $('#ParentMenuID').val();
                Data.ParentMenuName = $('#UserParentMenuList :selected').text();
                Data.IsParent = 0;
            }
            else if ($('#IsParentYES').is(':checked')) {
                Data.ParentMenuID = 0;
                Data.ParentMenuName = $('#MenuName').val();
                Data.IsParent = 1;
            }
            Data.MenuLink = $('#MenuLink').val();
            Data.IsEnable = $('#IsEnable:checked').val() ? true : false;
            Data.DisableDate = $('#DisableDate').val();
            Data.RemarkAboutDisable = $('#RemarkAboutDisable').val();
            Data.MenuToolTip = $('#MenuToolTip').val();
            Data.MenuIconName = $('#MenuIconName').val();
            Data.MenuDisplaySeqNo = $('#MenuDisplaySeqNo').val();
        }
        else if (UserMainMenuMaster.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.ModuleID = $('input[name=ModuleID]').val();
            Data.ModuleCode = $('input[name=ModuleCode]').val();
            Data.MenuName = $('#MenuName').val();
            Data.MenuCode = $('#MenuCode').val();
            Data.MenuInnerLevel = $('#MenuInnerLevel').val();
            if ($('#IsParentNO').is(':checked')) {
                //Data.ParentMenuID = $('#UserParentMenuList :selected').val();
                Data.ParentMenuID = $('#ParentMenuID').val();
                Data.ParentMenuName = $('#UserParentMenuList :selected').text();
                Data.IsParent = 0;
            }
            else if ($('#IsParentYES').is(':checked')) {
                Data.ParentMenuID = 0;
                Data.ParentMenuName = $('#MenuName').val();
                Data.IsParent = 1;
            }
            Data.MenuLink = $('#MenuLink').val();
            Data.IsEnable = $('#IsEnable:checked').val() ? true : false;
            Data.DisableDate = $('#DisableDate').val();
            Data.RemarkAboutDisable = $('#RemarkAboutDisable').val();
            Data.MenuToolTip = $('#MenuToolTip').val();
            Data.MenuIconName = $('#MenuIconName').val();
        }
        else if (UserMainMenuMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
            //Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
            //Data.DepartmentIdWithName = $('input[name=SelectedDepartmentID]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            UserMainMenuMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            UserMainMenuMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

