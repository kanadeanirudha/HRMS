////this class contain methods related to nationality functionality
//var EmployeeOtherCollegeFinancialAssistanceDetails = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeeOtherCollegeFinancialAssistanceDetails.constructor();
//        //EmployeeOtherCollegeFinancialAssistanceDetails.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {



//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
       
//            $('#FundingAgency').focus();
//            return false;
//        });



//        $("#DateOfGrantReceived").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'dd-MM-yy',
//            changeMonth: true,
//            changeYear: true,
//            yearRange: '1950:document.write(currentYear.getFullYear()'
//        });



//        // Create new record
//        $('#CreateEmployeeOtherCollegeFinancialAssistanceDetailsRecord').on("click", function () {
//            EmployeeOtherCollegeFinancialAssistanceDetails.ActionName = "Create";
//            EmployeeOtherCollegeFinancialAssistanceDetails.AjaxCallEmployeeOtherCollegeFinancialAssistanceDetails();
//        });

//        $('#EditEmployeeOtherCollegeFinancialAssistanceDetailsRecord').on("click", function () {

//            EmployeeOtherCollegeFinancialAssistanceDetails.ActionName = "Edit";
//            EmployeeOtherCollegeFinancialAssistanceDetails.AjaxCallEmployeeOtherCollegeFinancialAssistanceDetails();
//        });

//        $('#DeleteEmployeeOtherCollegeFinancialAssistanceDetailsRecord').on("click", function () {

//            EmployeeOtherCollegeFinancialAssistanceDetails.ActionName = "Delete";
//            EmployeeOtherCollegeFinancialAssistanceDetails.AjaxCallEmployeeOtherCollegeFinancialAssistanceDetails();
//        });
//        $('#FundingAgency').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#PurposeOfGrant').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#AmountOfGrant').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });

//        $('#Remarks').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
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
//             url: '/EmployeeOtherCollegeFinancialAssistanceDetails/List',
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
//            data: { "actionMode": actionMode },
//            url: '/EmployeeOtherCollegeFinancialAssistanceDetails/List',
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
//    AjaxCallEmployeeOtherCollegeFinancialAssistanceDetails: function () {
//        var EmployeeOtherCollegeFinancialAssistanceDetailsData = null;
//        if (EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Create") {
//            $("#FormCreateEmployeeOtherCollegeFinancialAssistanceDetails").validate();
//            if ($("#FormCreateEmployeeOtherCollegeFinancialAssistanceDetails").valid()) {
//                EmployeeOtherCollegeFinancialAssistanceDetailsData = null;
//                EmployeeOtherCollegeFinancialAssistanceDetailsData = EmployeeOtherCollegeFinancialAssistanceDetails.GetEmployeeOtherCollegeFinancialAssistanceDetails();
//                ajaxRequest.makeRequest("/EmployeeOtherCollegeFinancialAssistanceDetails/Create", "POST", EmployeeOtherCollegeFinancialAssistanceDetailsData, EmployeeOtherCollegeFinancialAssistanceDetails.Success);
//            }
//        }
//        else if (EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Edit") {
//            $("#FormEditEmployeeOtherCollegeFinancialAssistanceDetails").validate();
//            if ($("#FormEditEmployeeOtherCollegeFinancialAssistanceDetails").valid()) {
//                EmployeeOtherCollegeFinancialAssistanceDetailsData = null;
//                EmployeeOtherCollegeFinancialAssistanceDetailsData = EmployeeOtherCollegeFinancialAssistanceDetails.GetEmployeeOtherCollegeFinancialAssistanceDetails();
//                ajaxRequest.makeRequest("/EmployeeOtherCollegeFinancialAssistanceDetails/Edit", "POST", EmployeeOtherCollegeFinancialAssistanceDetailsData, EmployeeOtherCollegeFinancialAssistanceDetails.Success);
//            }
//        }
//        else if (EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Delete") {
//            EmployeeOtherCollegeFinancialAssistanceDetailsData = null;
//            //$("#FormCreateEmployeeOtherCollegeFinancialAssistanceDetails").validate();
//            EmployeeOtherCollegeFinancialAssistanceDetailsData = EmployeeOtherCollegeFinancialAssistanceDetails.GetEmployeeOtherCollegeFinancialAssistanceDetails();
//            ajaxRequest.makeRequest("/EmployeeOtherCollegeFinancialAssistanceDetails/Delete", "POST", EmployeeOtherCollegeFinancialAssistanceDetailsData, EmployeeOtherCollegeFinancialAssistanceDetails.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeeOtherCollegeFinancialAssistanceDetails: function () {
//        var Data = {
//        };
//        if (EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Create" || EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.EmployeeID = $('#EmployeeID').val();
//            Data.FundingAgency = $('#FundingAgency').val();
//            Data.AmountOfGrant = $('#AmountOfGrant').val();
//            Data.PurposeOfGrant = $('#PurposeOfGrant').val();
//            Data.Remarks = $('#Remarks').val();
//            Data.DateOfGrantReceived = $('#DateOfGrantReceived').val();
//            Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;

//        }
//        else if (EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
      
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            EmployeeOtherCollegeFinancialAssistanceDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            EmployeeOtherCollegeFinancialAssistanceDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {



//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        EmployeeOtherCollegeFinancialAssistanceDetails.ReloadList("Record Updated Sucessfully.", actionMode);
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
//    //        EmployeeOtherCollegeFinancialAssistanceDetails.ReloadList("Record Deleted Sucessfully.");
//    //      //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};


////////////////////////////new js///////////////////////////////

//this class contain methods related to nationality functionality
var EmployeeOtherCollegeFinancialAssistanceDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeOtherCollegeFinancialAssistanceDetails.constructor();
        //EmployeeOtherCollegeFinancialAssistanceDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            $('#FundingAgency').focus();
            return false;
        });



        //$("#DateOfGrantReceived").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'dd-MM-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()'
        //});

        $('#DateOfGrantReceived').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        // Create new record
        $('#CreateEmployeeOtherCollegeFinancialAssistanceDetailsRecord').on("click", function () {
            EmployeeOtherCollegeFinancialAssistanceDetails.ActionName = "Create";
            EmployeeOtherCollegeFinancialAssistanceDetails.AjaxCallEmployeeOtherCollegeFinancialAssistanceDetails();
        });

        $('#EditEmployeeOtherCollegeFinancialAssistanceDetailsRecord').on("click", function () {
            debugger;
            EmployeeOtherCollegeFinancialAssistanceDetails.ActionName = "Edit";
            EmployeeOtherCollegeFinancialAssistanceDetails.AjaxCallEmployeeOtherCollegeFinancialAssistanceDetails();
        });

        $('#DeleteEmployeeOtherCollegeFinancialAssistanceDetailsRecord').on("click", function () {

            EmployeeOtherCollegeFinancialAssistanceDetails.ActionName = "Delete";
            EmployeeOtherCollegeFinancialAssistanceDetails.AjaxCallEmployeeOtherCollegeFinancialAssistanceDetails();
        });
        $('#FundingAgency').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#PurposeOfGrant').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#AmountOfGrant').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Remarks').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
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
             url: '/EmployeeOtherCollegeFinancialAssistanceDetails/List',
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
            data: { "actionMode": actionMode },
            url: '/EmployeeOtherCollegeFinancialAssistanceDetails/List',
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
    AjaxCallEmployeeOtherCollegeFinancialAssistanceDetails: function () {
        var EmployeeOtherCollegeFinancialAssistanceDetailsData = null;
        if (EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Create") {
            $("#FormCreateEmployeeOtherCollegeFinancialAssistanceDetails").validate();
            if ($("#FormCreateEmployeeOtherCollegeFinancialAssistanceDetails").valid()) {
                EmployeeOtherCollegeFinancialAssistanceDetailsData = null;
                EmployeeOtherCollegeFinancialAssistanceDetailsData = EmployeeOtherCollegeFinancialAssistanceDetails.GetEmployeeOtherCollegeFinancialAssistanceDetails();
                ajaxRequest.makeRequest("/EmployeeOtherCollegeFinancialAssistanceDetails/Create", "POST", EmployeeOtherCollegeFinancialAssistanceDetailsData, EmployeeOtherCollegeFinancialAssistanceDetails.Success);
            }
        }
        else if (EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Edit") {
            $("#FormEditEmployeeOtherCollegeFinancialAssistanceDetails").validate();
            if ($("#FormEditEmployeeOtherCollegeFinancialAssistanceDetails").valid()) {
                EmployeeOtherCollegeFinancialAssistanceDetailsData = null;
                EmployeeOtherCollegeFinancialAssistanceDetailsData = EmployeeOtherCollegeFinancialAssistanceDetails.GetEmployeeOtherCollegeFinancialAssistanceDetails();
                ajaxRequest.makeRequest("/EmployeeOtherCollegeFinancialAssistanceDetails/Edit", "POST", EmployeeOtherCollegeFinancialAssistanceDetailsData, EmployeeOtherCollegeFinancialAssistanceDetails.Success);
            }
        }
        else if (EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Delete") {
            EmployeeOtherCollegeFinancialAssistanceDetailsData = null;
            //$("#FormCreateEmployeeOtherCollegeFinancialAssistanceDetails").validate();
            EmployeeOtherCollegeFinancialAssistanceDetailsData = EmployeeOtherCollegeFinancialAssistanceDetails.GetEmployeeOtherCollegeFinancialAssistanceDetails();
            ajaxRequest.makeRequest("/EmployeeOtherCollegeFinancialAssistanceDetails/Delete", "POST", EmployeeOtherCollegeFinancialAssistanceDetailsData, EmployeeOtherCollegeFinancialAssistanceDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeOtherCollegeFinancialAssistanceDetails: function () {
        var Data = {
        };
        if (EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Create" || EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.EmployeeID = $('#EmployeeID').val();
            Data.FundingAgency = $('#FundingAgency').val();
            Data.AmountOfGrant = $('#AmountOfGrant').val();
            Data.PurposeOfGrant = $('#PurposeOfGrant').val();
            Data.Remarks = $('#Remarks').val();
            Data.DateOfGrantReceived = $('#DateOfGrantReceived').val();
            Data.IsActive = $('input[id=IsActive]:checked').val() ? true : false;

        }
        else if (EmployeeOtherCollegeFinancialAssistanceDetails.ActionName == "Delete") {
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
            EmployeeOtherCollegeFinancialAssistanceDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeOtherCollegeFinancialAssistanceDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};


