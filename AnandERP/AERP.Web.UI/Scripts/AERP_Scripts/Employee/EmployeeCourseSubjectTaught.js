////this class contain methods related to nationality functionality
//var EmployeeCourseSubjectTaught = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeeCourseSubjectTaught.constructor();
//        //EmployeeCourseSubjectTaught.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#SubjectName').focus();
//            $('#SubjectName').val('');
//        });


//        // Create new record
//        $('#CreateEmployeeCourseSubjectTaughtRecord').on("click", function () {
//            EmployeeCourseSubjectTaught.ActionName = "Create";
//            EmployeeCourseSubjectTaught.AjaxCallEmployeeCourseSubjectTaught();
//        });

//        $('#EditEmployeeCourseSubjectTaughtRecord').on("click", function () {

//            EmployeeCourseSubjectTaught.ActionName = "Edit";
//            EmployeeCourseSubjectTaught.AjaxCallEmployeeCourseSubjectTaught();
//        });

//        $('#DeleteEmployeeCourseSubjectTaughtRecord').on("click", function () {

//            EmployeeCourseSubjectTaught.ActionName = "Delete";
//            EmployeeCourseSubjectTaught.AjaxCallEmployeeCourseSubjectTaught();
//        });
//        $('#Description').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $("#UserSearch").keyup(function () {
//            oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });

//        $('#SubjectName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
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
//             data: { "EmployeeID": EmployeeID },
        
//             url: '/EmployeeCourseSubjectTaught/List',

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
//            url: '/EmployeeCourseSubjectTaught/List',
//            data: { "actionMode": actionMode, "EmployeeID": EmployeeID },
       
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
//    AjaxCallEmployeeCourseSubjectTaught: function () {
//        var EmployeeCourseSubjectTaughtData = null;
//        if (EmployeeCourseSubjectTaught.ActionName == "Create") {

//            $("#FormCreateEmployeeCourseSubjectTaught").validate();
//            if ($("#FormCreateEmployeeCourseSubjectTaught").valid()) {
//                EmployeeCourseSubjectTaughtData = null;
//                EmployeeCourseSubjectTaughtData = EmployeeCourseSubjectTaught.GetEmployeeCourseSubjectTaught();
//                ajaxRequest.makeRequest("/EmployeeCourseSubjectTaught/Create", "POST", EmployeeCourseSubjectTaughtData, EmployeeCourseSubjectTaught.Success);
//            }
//        }
//        else if (EmployeeCourseSubjectTaught.ActionName == "Edit") {
//            $("#FormEditEmployeeCourseSubjectTaught").validate();
//            if ($("#FormEditEmployeeCourseSubjectTaught").valid()) {
//                EmployeeCourseSubjectTaughtData = null;
//                EmployeeCourseSubjectTaughtData = EmployeeCourseSubjectTaught.GetEmployeeCourseSubjectTaught();
//                ajaxRequest.makeRequest("/EmployeeCourseSubjectTaught/Edit", "POST", EmployeeCourseSubjectTaughtData, EmployeeCourseSubjectTaught.Success);
//            }
//        }
//        else if (EmployeeCourseSubjectTaught.ActionName == "Delete") {
//            EmployeeCourseSubjectTaughtData = null;
//            $("#FormDeleteEmployeeCourseSubjectTaught").validate();
//            EmployeeCourseSubjectTaughtData = EmployeeCourseSubjectTaught.GetEmployeeCourseSubjectTaught();
//            ajaxRequest.makeRequest("/EmployeeCourseSubjectTaught/Delete", "POST", EmployeeCourseSubjectTaughtData, EmployeeCourseSubjectTaught.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeeCourseSubjectTaught: function () {
//        var Data = {
//        };
//        if (EmployeeCourseSubjectTaught.ActionName == "Create" || EmployeeCourseSubjectTaught.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.EmployeeID = $("#EmployeeID").val()
//            Data.SubjectName = $('#SubjectName').val();
//            Data.SubjectCode = $('#SubjectCode').val();
//            Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;



//        }
//        else if (EmployeeCourseSubjectTaught.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            EmployeeCourseSubjectTaught.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            EmployeeCourseSubjectTaught.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    debugger;
//    //    debugger;
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        EmployeeCourseSubjectTaught.ReloadList("Record Updated Sucessfully.", actionMode);
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {

//    //    debugger;
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        EmployeeCourseSubjectTaught.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

///////////////////////////new /////////////////////////////

//this class contain methods related to nationality functionality
var EmployeeCourseSubjectTaught = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeCourseSubjectTaught.constructor();
        //EmployeeCourseSubjectTaught.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SubjectName').focus();
            $('#SubjectName').val('');
        });


        // Create new record
        $('#CreateEmployeeCourseSubjectTaughtRecord').on("click", function () {
            debugger;
            EmployeeCourseSubjectTaught.ActionName = "Create";
            EmployeeCourseSubjectTaught.AjaxCallEmployeeCourseSubjectTaught();
        });

        $('#EditEmployeeCourseSubjectTaughtRecord').on("click", function () {

            EmployeeCourseSubjectTaught.ActionName = "Edit";
            EmployeeCourseSubjectTaught.AjaxCallEmployeeCourseSubjectTaught();
        });

        $('#DeleteEmployeeCourseSubjectTaughtRecord').on("click", function () {

            EmployeeCourseSubjectTaught.ActionName = "Delete";
            EmployeeCourseSubjectTaught.AjaxCallEmployeeCourseSubjectTaught();
        });
        $('#Description').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $('#SubjectName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
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
             data: { "EmployeeID": EmployeeID },

             url: '/EmployeeCourseSubjectTaught/List',

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
            url: '/EmployeeCourseSubjectTaught/List',
            data: { "actionMode": actionMode, "EmployeeID": EmployeeID },

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
    AjaxCallEmployeeCourseSubjectTaught: function () {
        var EmployeeCourseSubjectTaughtData = null;
        if (EmployeeCourseSubjectTaught.ActionName == "Create") {
            debugger;
            $("#FormCreateEmployeeCourseSubjectTaught").validate();
            if ($("#FormCreateEmployeeCourseSubjectTaught").valid()) {
                EmployeeCourseSubjectTaughtData = null;
                EmployeeCourseSubjectTaughtData = EmployeeCourseSubjectTaught.GetEmployeeCourseSubjectTaught();
                ajaxRequest.makeRequest("/EmployeeCourseSubjectTaught/Create", "POST", EmployeeCourseSubjectTaughtData, EmployeeCourseSubjectTaught.Success);

            }
        }
        else if (EmployeeCourseSubjectTaught.ActionName == "Edit") {
            $("#FormEditEmployeeCourseSubjectTaught").validate();
            if ($("#FormEditEmployeeCourseSubjectTaught").valid()) {
                EmployeeCourseSubjectTaughtData = null;
                EmployeeCourseSubjectTaughtData = EmployeeCourseSubjectTaught.GetEmployeeCourseSubjectTaught();
                ajaxRequest.makeRequest("/EmployeeCourseSubjectTaught/Edit", "POST", EmployeeCourseSubjectTaughtData, EmployeeCourseSubjectTaught.Success);
            }
        }
        else if (EmployeeCourseSubjectTaught.ActionName == "Delete") {
            EmployeeCourseSubjectTaughtData = null;
            $("#FormDeleteEmployeeCourseSubjectTaught").validate();
            EmployeeCourseSubjectTaughtData = EmployeeCourseSubjectTaught.GetEmployeeCourseSubjectTaught();
            ajaxRequest.makeRequest("/EmployeeCourseSubjectTaught/Delete", "POST", EmployeeCourseSubjectTaughtData, EmployeeCourseSubjectTaught.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeCourseSubjectTaught: function () {
        var Data = {
        };
        if (EmployeeCourseSubjectTaught.ActionName == "Create" || EmployeeCourseSubjectTaught.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.EmployeeID = $("#EmployeeID").val()
            Data.SubjectName = $('#SubjectName').val();
            Data.SubjectCode = $('#SubjectCode').val();
            Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;



        }
        else if (EmployeeCourseSubjectTaught.ActionName == "Delete") {
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
            EmployeeCourseSubjectTaught.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeCourseSubjectTaught.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

