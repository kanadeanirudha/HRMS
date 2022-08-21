////this class contain methods related to nationality functionality
//var EmployeeOtherCollegeSpecialLectureDetails = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeeOtherCollegeSpecialLectureDetails.constructor();
//        //EmployeeOtherCollegeSpecialLectureDetails.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {



//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');

//            $('#InstituteName').focus();
//            return false;
//        });



//        $("#DateOfLectureDelivered").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'dd-MM-yy',
//            changeMonth: true,
//            changeYear: true,
//            yearRange: '1950:document.write(currentYear.getFullYear()'
//        });

       
//        //$("#DateOfLectureDelivered").datepicker({
//        //    numberOfMonths: 1,
//        //    dateFormat: 'dd-MM-yy',
//        //    changeMonth: true,
//        //    changeYear: true,
//        //    yearRange: '1950:document.write(currentYear.getFullYear()'
//        //});


//        // Create new record
//        $('#CreateEmployeeOtherCollegeSpecialLectureDetailsRecord').on("click", function () {
//            EmployeeOtherCollegeSpecialLectureDetails.ActionName = "Create";
//            EmployeeOtherCollegeSpecialLectureDetails.AjaxCallEmployeeOtherCollegeSpecialLectureDetails();
//        });

//        $('#EditEmployeeOtherCollegeSpecialLectureDetailsRecord').on("click", function () {

//            EmployeeOtherCollegeSpecialLectureDetails.ActionName = "Edit";
//            EmployeeOtherCollegeSpecialLectureDetails.AjaxCallEmployeeOtherCollegeSpecialLectureDetails();
//        });

//        $('#DeleteEmployeeOtherCollegeSpecialLectureDetailsRecord').on("click", function () {

//            EmployeeOtherCollegeSpecialLectureDetails.ActionName = "Delete";
//            EmployeeOtherCollegeSpecialLectureDetails.AjaxCallEmployeeOtherCollegeSpecialLectureDetails();
//        });
//        $('#InstituteName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $('#InstituteAddress').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#TopicOfLecture').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#Remarks').on("keydown", function (e) {
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
//             url: '/EmployeeOtherCollegeSpecialLectureDetails/List',
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
//            url: '/EmployeeOtherCollegeSpecialLectureDetails/List',
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
//    AjaxCallEmployeeOtherCollegeSpecialLectureDetails: function () {
//        var EmployeeOtherCollegeSpecialLectureDetailsData = null;
//        if (EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Create") {
//            $("#FormCreateEmployeeOtherCollegeSpecialLectureDetails").validate();
//            if ($("#FormCreateEmployeeOtherCollegeSpecialLectureDetails").valid()) {
//                EmployeeOtherCollegeSpecialLectureDetailsData = null;
//                EmployeeOtherCollegeSpecialLectureDetailsData = EmployeeOtherCollegeSpecialLectureDetails.GetEmployeeOtherCollegeSpecialLectureDetails();
//                ajaxRequest.makeRequest("/EmployeeOtherCollegeSpecialLectureDetails/Create", "POST", EmployeeOtherCollegeSpecialLectureDetailsData, EmployeeOtherCollegeSpecialLectureDetails.Success);
//            }
//        }
//        else if (EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Edit") {
//            $("#FormEditEmployeeOtherCollegeSpecialLectureDetails").validate();
//            if ($("#FormEditEmployeeOtherCollegeSpecialLectureDetails").valid()) {
//                EmployeeOtherCollegeSpecialLectureDetailsData = null;
//                EmployeeOtherCollegeSpecialLectureDetailsData = EmployeeOtherCollegeSpecialLectureDetails.GetEmployeeOtherCollegeSpecialLectureDetails();
//                ajaxRequest.makeRequest("/EmployeeOtherCollegeSpecialLectureDetails/Edit", "POST", EmployeeOtherCollegeSpecialLectureDetailsData, EmployeeOtherCollegeSpecialLectureDetails.Success);
//            }
//        }
//        else if (EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Delete") {
//            EmployeeOtherCollegeSpecialLectureDetailsData = null;
//            //$("#FormCreateEmployeeOtherCollegeSpecialLectureDetails").validate();
//            EmployeeOtherCollegeSpecialLectureDetailsData = EmployeeOtherCollegeSpecialLectureDetails.GetEmployeeOtherCollegeSpecialLectureDetails();
//            ajaxRequest.makeRequest("/EmployeeOtherCollegeSpecialLectureDetails/Delete", "POST", EmployeeOtherCollegeSpecialLectureDetailsData, EmployeeOtherCollegeSpecialLectureDetails.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeeOtherCollegeSpecialLectureDetails: function () {
//        var Data = {
//        };
//        if (EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Create" || EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.EmployeeID = $('#EmployeeID').val();
//            Data.InstituteName = $('#InstituteName').val();
//            Data.InstituteAddress = $('#InstituteAddress').val();
//            Data.TopicOfLecture = $('#TopicOfLecture').val();
//            Data.Remarks = $('#Remarks').val();
//            Data.DateOfLectureDelivered = $('#DateOfLectureDelivered').val();
//        //    Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;

//        }
//        else if (EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
       
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            EmployeeOtherCollegeSpecialLectureDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            EmployeeOtherCollegeSpecialLectureDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {



//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        EmployeeOtherCollegeSpecialLectureDetails.ReloadList("Record Updated Sucessfully.", actionMode);
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
//    //        EmployeeOtherCollegeSpecialLectureDetails.ReloadList("Record Deleted Sucessfully.");
//    //      //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

//////////////////////////////////////new js////////////////////////

//this class contain methods related to nationality functionality
var EmployeeOtherCollegeSpecialLectureDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeOtherCollegeSpecialLectureDetails.constructor();
        //EmployeeOtherCollegeSpecialLectureDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            $('#InstituteName').focus();
            return false;
        });



        //$("#DateOfLectureDelivered").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'dd-MM-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()'
        //});

        $('#DateOfLectureDelivered').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });


        //$("#DateOfLectureDelivered").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'dd-MM-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()'
        //});


        // Create new record
        $('#CreateEmployeeOtherCollegeSpecialLectureDetailsRecord').on("click", function () {
            EmployeeOtherCollegeSpecialLectureDetails.ActionName = "Create";
            EmployeeOtherCollegeSpecialLectureDetails.AjaxCallEmployeeOtherCollegeSpecialLectureDetails();
        });

        $('#EditEmployeeOtherCollegeSpecialLectureDetailsRecord').on("click", function () {

            EmployeeOtherCollegeSpecialLectureDetails.ActionName = "Edit";
            EmployeeOtherCollegeSpecialLectureDetails.AjaxCallEmployeeOtherCollegeSpecialLectureDetails();
        });

        $('#DeleteEmployeeOtherCollegeSpecialLectureDetailsRecord').on("click", function () {

            EmployeeOtherCollegeSpecialLectureDetails.ActionName = "Delete";
            EmployeeOtherCollegeSpecialLectureDetails.AjaxCallEmployeeOtherCollegeSpecialLectureDetails();
        });
        $('#InstituteName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#InstituteAddress').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#TopicOfLecture').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#Remarks').on("keydown", function (e) {
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
             url: '/EmployeeOtherCollegeSpecialLectureDetails/List',
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
            url: '/EmployeeOtherCollegeSpecialLectureDetails/List',
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
    AjaxCallEmployeeOtherCollegeSpecialLectureDetails: function () {
        var EmployeeOtherCollegeSpecialLectureDetailsData = null;
        if (EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Create") {
            $("#FormCreateEmployeeOtherCollegeSpecialLectureDetails").validate();
            if ($("#FormCreateEmployeeOtherCollegeSpecialLectureDetails").valid()) {
                EmployeeOtherCollegeSpecialLectureDetailsData = null;
                EmployeeOtherCollegeSpecialLectureDetailsData = EmployeeOtherCollegeSpecialLectureDetails.GetEmployeeOtherCollegeSpecialLectureDetails();
                ajaxRequest.makeRequest("/EmployeeOtherCollegeSpecialLectureDetails/Create", "POST", EmployeeOtherCollegeSpecialLectureDetailsData, EmployeeOtherCollegeSpecialLectureDetails.Success);
            }
        }
        else if (EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Edit") {
            $("#FormEditEmployeeOtherCollegeSpecialLectureDetails").validate();
            if ($("#FormEditEmployeeOtherCollegeSpecialLectureDetails").valid()) {
                EmployeeOtherCollegeSpecialLectureDetailsData = null;
                EmployeeOtherCollegeSpecialLectureDetailsData = EmployeeOtherCollegeSpecialLectureDetails.GetEmployeeOtherCollegeSpecialLectureDetails();
                ajaxRequest.makeRequest("/EmployeeOtherCollegeSpecialLectureDetails/Edit", "POST", EmployeeOtherCollegeSpecialLectureDetailsData, EmployeeOtherCollegeSpecialLectureDetails.Success);
            }
        }
        else if (EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Delete") {
            EmployeeOtherCollegeSpecialLectureDetailsData = null;
            //$("#FormCreateEmployeeOtherCollegeSpecialLectureDetails").validate();
            EmployeeOtherCollegeSpecialLectureDetailsData = EmployeeOtherCollegeSpecialLectureDetails.GetEmployeeOtherCollegeSpecialLectureDetails();
            ajaxRequest.makeRequest("/EmployeeOtherCollegeSpecialLectureDetails/Delete", "POST", EmployeeOtherCollegeSpecialLectureDetailsData, EmployeeOtherCollegeSpecialLectureDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeOtherCollegeSpecialLectureDetails: function () {
        var Data = {
        };
        if (EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Create" || EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.EmployeeID = $('#EmployeeID').val();
            Data.InstituteName = $('#InstituteName').val();
            Data.InstituteAddress = $('#InstituteAddress').val();
            Data.TopicOfLecture = $('#TopicOfLecture').val();
            Data.Remarks = $('#Remarks').val();
            Data.DateOfLectureDelivered = $('#DateOfLectureDelivered').val();
            //    Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;

        }
        else if (EmployeeOtherCollegeSpecialLectureDetails.ActionName == "Delete") {
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
            EmployeeOtherCollegeSpecialLectureDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeOtherCollegeSpecialLectureDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

