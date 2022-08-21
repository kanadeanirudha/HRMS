////this class contain methods related to nationality functionality
//var EmployeePrizesWonDetails = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeePrizesWonDetails.constructor();
//        //EmployeePrizesWonDetails.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {



//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#GeneralLevelMasterID').val("");
//            $('#GeneralLevelMasterID').focus();
//            return false;
//        });



//        $("#PrizeReceivingDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'dd-MM-yy',
//            changeMonth: true,
//            changeYear: true,
//            yearRange: '1950:document.write(currentYear.getFullYear()'
//        });


//        // Create new record
//        $('#CreateEmployeePrizesWonDetailsRecord').on("click", function () {
//            EmployeePrizesWonDetails.ActionName = "Create";
//            EmployeePrizesWonDetails.AjaxCallEmployeePrizesWonDetails();
//        });

//        $('#EditEmployeePrizesWonDetailsRecord').on("click", function () {

//            EmployeePrizesWonDetails.ActionName = "Edit";
//            EmployeePrizesWonDetails.AjaxCallEmployeePrizesWonDetails();
//        });

//        $('#DeleteEmployeePrizesWonDetailsRecord').on("click", function () {

//            EmployeePrizesWonDetails.ActionName = "Delete";
//            EmployeePrizesWonDetails.AjaxCallEmployeePrizesWonDetails();
//        });
//        $('#NameOfBoardBody').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $('#PostHeld').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
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


//    },
//    //LoadList method is used to load List page
//    LoadList: function () {
//        var EmployeeID = $("#EmployeeID").val();
//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/EmployeePrizesWonDetails/List',
//             data: { "EmployeeID": EmployeeID },
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
//        var EmployeeID = $("#EmployeeID").val();
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            // data: { "actionMode": actionMode },
//            url: '/EmployeePrizesWonDetails/List',
//            data: { "EmployeeID": EmployeeID, "actionMode": actionMode, },
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#EmployeeFormStatusMessages').html(message);
//                $('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallEmployeePrizesWonDetails: function () {
//        var EmployeePrizesWonDetailsData = null;
//        if (EmployeePrizesWonDetails.ActionName == "Create") {
//            $("#FormCreateEmployeePrizesWonDetails").validate();
//            if ($("#FormCreateEmployeePrizesWonDetails").valid()) {
//                EmployeePrizesWonDetailsData = null;
//                EmployeePrizesWonDetailsData = EmployeePrizesWonDetails.GetEmployeePrizesWonDetails();
//                ajaxRequest.makeRequest("/EmployeePrizesWonDetails/Create", "POST", EmployeePrizesWonDetailsData, EmployeePrizesWonDetails.Success);
//            }
//        }
//        else if (EmployeePrizesWonDetails.ActionName == "Edit") {
//            $("#FormEditEmployeePrizesWonDetails").validate();
//            if ($("#FormEditEmployeePrizesWonDetails").valid()) {
//                EmployeePrizesWonDetailsData = null;
//                EmployeePrizesWonDetailsData = EmployeePrizesWonDetails.GetEmployeePrizesWonDetails();
//                ajaxRequest.makeRequest("/EmployeePrizesWonDetails/Edit", "POST", EmployeePrizesWonDetailsData, EmployeePrizesWonDetails.Success);
//            }
//        }
//        else if (EmployeePrizesWonDetails.ActionName == "Delete") {
//            EmployeePrizesWonDetailsData = null;
//            //$("#FormCreateEmployeePrizesWonDetails").validate();
//            EmployeePrizesWonDetailsData = EmployeePrizesWonDetails.GetEmployeePrizesWonDetails();
//            ajaxRequest.makeRequest("/EmployeePrizesWonDetails/Delete", "POST", EmployeePrizesWonDetailsData, EmployeePrizesWonDetails.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeePrizesWonDetails: function () {
//        var Data = {
//        };
//        if (EmployeePrizesWonDetails.ActionName == "Create" || EmployeePrizesWonDetails.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.EmployeeID = $('#EmployeeID').val();
//            Data.GeneralLevelMasterID = $('#GeneralLevelMasterID').val();
//            Data.PrizeName = $('#PrizeName').val();
//            Data.PrizeGivenBy = $('#PrizeGivenBy').val();
//            Data.Remark = $('#Remark').val();
//            Data.PrizeReceivingDate = $('#PrizeReceivingDate').val();
//            Data.PrizeIssuingAuthority = $('#PrizeIssuingAuthority').val();
         
//        }
//        else if (EmployeePrizesWonDetails.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            EmployeePrizesWonDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            EmployeePrizesWonDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {



//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        EmployeePrizesWonDetails.ReloadList("Record Updated Sucessfully.", actionMode);
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {


//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        EmployeePrizesWonDetails.ReloadList("Record Deleted Sucessfully.");
//    //      //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

///////////////////////////////new js/////////////////////////////////


//this class contain methods related to nationality functionality
var EmployeePrizesWonDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeePrizesWonDetails.constructor();
        //EmployeePrizesWonDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GeneralLevelMasterID').val("");
            $('#GeneralLevelMasterID').focus();
            return false;
        });



        //$("#PrizeReceivingDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'dd-MM-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()'
        //});

        $('#PrizeReceivingDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });


        // Create new record
        $('#CreateEmployeePrizesWonDetailsRecord').on("click", function () {
            EmployeePrizesWonDetails.ActionName = "Create";
            EmployeePrizesWonDetails.AjaxCallEmployeePrizesWonDetails();
        });

        $('#EditEmployeePrizesWonDetailsRecord').on("click", function () {

            EmployeePrizesWonDetails.ActionName = "Edit";
            EmployeePrizesWonDetails.AjaxCallEmployeePrizesWonDetails();
        });

        $('#DeleteEmployeePrizesWonDetailsRecord').on("click", function () {

            EmployeePrizesWonDetails.ActionName = "Delete";
            EmployeePrizesWonDetails.AjaxCallEmployeePrizesWonDetails();
        });
        $('#NameOfBoardBody').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#PostHeld').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
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
    //LoadList method is used to load List page
    LoadList: function () {
        var EmployeeID = $("#EmployeeID").val();
        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/EmployeePrizesWonDetails/List',
             data: { "EmployeeID": EmployeeID },
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var EmployeeID = $("#EmployeeID").val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            // data: { "actionMode": actionMode },
            url: '/EmployeePrizesWonDetails/List',
            data: { "EmployeeID": EmployeeID, "actionMode": actionMode, },
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeePrizesWonDetails: function () {
        var EmployeePrizesWonDetailsData = null;
        if (EmployeePrizesWonDetails.ActionName == "Create") {
            $("#FormCreateEmployeePrizesWonDetails").validate();
            if ($("#FormCreateEmployeePrizesWonDetails").valid()) {
                EmployeePrizesWonDetailsData = null;
                EmployeePrizesWonDetailsData = EmployeePrizesWonDetails.GetEmployeePrizesWonDetails();
                ajaxRequest.makeRequest("/EmployeePrizesWonDetails/Create", "POST", EmployeePrizesWonDetailsData, EmployeePrizesWonDetails.Success);
            }
        }
        else if (EmployeePrizesWonDetails.ActionName == "Edit") {
            $("#FormEditEmployeePrizesWonDetails").validate();
            if ($("#FormEditEmployeePrizesWonDetails").valid()) {
                EmployeePrizesWonDetailsData = null;
                EmployeePrizesWonDetailsData = EmployeePrizesWonDetails.GetEmployeePrizesWonDetails();
                ajaxRequest.makeRequest("/EmployeePrizesWonDetails/Edit", "POST", EmployeePrizesWonDetailsData, EmployeePrizesWonDetails.Success);
            }
        }
        else if (EmployeePrizesWonDetails.ActionName == "Delete") {
            EmployeePrizesWonDetailsData = null;
            //$("#FormCreateEmployeePrizesWonDetails").validate();
            EmployeePrizesWonDetailsData = EmployeePrizesWonDetails.GetEmployeePrizesWonDetails();
            ajaxRequest.makeRequest("/EmployeePrizesWonDetails/Delete", "POST", EmployeePrizesWonDetailsData, EmployeePrizesWonDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeePrizesWonDetails: function () {
        var Data = {
        };
        if (EmployeePrizesWonDetails.ActionName == "Create" || EmployeePrizesWonDetails.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.EmployeeID = $('#EmployeeID').val();
            Data.GeneralLevelMasterID = $('#GeneralLevelMasterID').val();
            Data.PrizeName = $('#PrizeName').val();
            Data.PrizeGivenBy = $('#PrizeGivenBy').val();
            Data.Remark = $('#Remark').val();
            Data.PrizeReceivingDate = $('#PrizeReceivingDate').val();
            Data.PrizeIssuingAuthority = $('#PrizeIssuingAuthority').val();

        }
        else if (EmployeePrizesWonDetails.ActionName == "Delete") {
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
            EmployeePrizesWonDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeePrizesWonDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

