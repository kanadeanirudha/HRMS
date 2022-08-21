////this class contain methods related to nationality functionality
//var EmployeeElectionNomineeBody = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeeElectionNomineeBody.constructor();
//        //EmployeeElectionNomineeBody.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

     

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#GeneralBoardUniversityID').val("");
//            $('#GeneralBoardUniversityID').focus();
//            return false;
//        });



//        $('#FromDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#ToDate").datepicker("option", "minDate", selectedDate);
//            }
//        })

//        $('#ToDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#FromDate").datepicker("option", "maxDate", selectedDate);
//            }
//        })

//        // Create new record
//        $('#CreateEmployeeElectionNomineeBodyRecord').on("click", function () {
//            EmployeeElectionNomineeBody.ActionName = "Create";
//            EmployeeElectionNomineeBody.AjaxCallEmployeeElectionNomineeBody();
//        });

//        $('#EditEmployeeElectionNomineeBodyRecord').on("click", function () {

//            EmployeeElectionNomineeBody.ActionName = "Edit";
//            EmployeeElectionNomineeBody.AjaxCallEmployeeElectionNomineeBody();
//        });

//        $('#DeleteEmployeeElectionNomineeBodyRecord').on("click", function () {

//            EmployeeElectionNomineeBody.ActionName = "Delete";
//            EmployeeElectionNomineeBody.AjaxCallEmployeeElectionNomineeBody();
//        });
//        $('#NameOfBoardBody').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $('#PostHeld').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });


//        $('#Remarks').on("keydown", function (e) {
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
//             url: '/EmployeeElectionNomineeBody/List',
//             data: { "EmployeeID": EmployeeID},
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
//           // data: { "actionMode": actionMode },
//            url: '/EmployeeElectionNomineeBody/List',
//            data: { "EmployeeID": EmployeeID, "actionMode": actionMode ,},
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
//    AjaxCallEmployeeElectionNomineeBody: function () {
//        var EmployeeElectionNomineeBodyData = null;
//        if (EmployeeElectionNomineeBody.ActionName == "Create") {
//            $("#FormCreateEmployeeElectionNomineeBody").validate();
//            if ($("#FormCreateEmployeeElectionNomineeBody").valid()) {
//                EmployeeElectionNomineeBodyData = null;
//                EmployeeElectionNomineeBodyData = EmployeeElectionNomineeBody.GetEmployeeElectionNomineeBody();
//                ajaxRequest.makeRequest("/EmployeeElectionNomineeBody/Create", "POST", EmployeeElectionNomineeBodyData, EmployeeElectionNomineeBody.Success);
//            }
//        }
//        else if (EmployeeElectionNomineeBody.ActionName == "Edit") {
//            $("#FormEditEmployeeElectionNomineeBody").validate();
//            if ($("#FormEditEmployeeElectionNomineeBody").valid()) {
//                EmployeeElectionNomineeBodyData = null;
//                EmployeeElectionNomineeBodyData = EmployeeElectionNomineeBody.GetEmployeeElectionNomineeBody();
//                ajaxRequest.makeRequest("/EmployeeElectionNomineeBody/Edit", "POST", EmployeeElectionNomineeBodyData, EmployeeElectionNomineeBody.Success);
//            }
//        }
//        else if (EmployeeElectionNomineeBody.ActionName == "Delete") {
//            EmployeeElectionNomineeBodyData = null;
//            //$("#FormCreateEmployeeElectionNomineeBody").validate();
//            EmployeeElectionNomineeBodyData = EmployeeElectionNomineeBody.GetEmployeeElectionNomineeBody();
//            ajaxRequest.makeRequest("/EmployeeElectionNomineeBody/Delete", "POST", EmployeeElectionNomineeBodyData, EmployeeElectionNomineeBody.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeeElectionNomineeBody: function () {
//        var Data = {
//        };
//        if (EmployeeElectionNomineeBody.ActionName == "Create" || EmployeeElectionNomineeBody.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.EmployeeID = $('#EmployeeID').val();
//            Data.GeneralBoardUniversityID = $('#GeneralBoardUniversityID').val();
//            Data.NameOfBoardBody = $('#NameOfBoardBody').val();
//            Data.PostHeld = $('#PostHeld').val();
//            Data.Remarks = $('#Remarks').val();
//            Data.FromDate = $('#FromDate').val();
//            Data.ToDate = $('#ToDate').val();
//            //Data.InActiveReason = $('#InActiveReason').val();
//            //Data.InActiveDate = $('#InActiveDate').val();
//            Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
          
//        }
//        else if (EmployeeElectionNomineeBody.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
      
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            EmployeeElectionNomineeBody.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            EmployeeElectionNomineeBody.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {



//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        EmployeeElectionNomineeBody.ReloadList("Record Updated Sucessfully.", actionMode);
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
//    //        EmployeeElectionNomineeBody.ReloadList("Record Deleted Sucessfully.");
//    //      //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

///////////////////////////new js////////////////////////////

//this class contain methods related to nationality functionality
var EmployeeElectionNomineeBody = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeElectionNomineeBody.constructor();
        //EmployeeElectionNomineeBody.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GeneralBoardUniversityID').val("");
            $('#GeneralBoardUniversityID').focus();
            return false;
        });



        //$('#FromDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ToDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        $('#FromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#FromDate').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#ToDate').data("DateTimePicker").minDate(minDate);
        });


        //$('#ToDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#FromDate").datepicker("option", "maxDate", selectedDate);
        //    }
        //})

        $('#ToDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });
        $('#ToDate').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#FromDate').data("DateTimePicker").maxDate(maxDate);
        });

        // Create new record
        $('#CreateEmployeeElectionNomineeBodyRecord').on("click", function () {
            EmployeeElectionNomineeBody.ActionName = "Create";
            EmployeeElectionNomineeBody.AjaxCallEmployeeElectionNomineeBody();
        });

        $('#EditEmployeeElectionNomineeBodyRecord').on("click", function () {
            //alert();
            debugger;
            EmployeeElectionNomineeBody.ActionName = "Edit";
            EmployeeElectionNomineeBody.AjaxCallEmployeeElectionNomineeBody();
        });

        $('#DeleteEmployeeElectionNomineeBodyRecord').on("click", function () {

            EmployeeElectionNomineeBody.ActionName = "Delete";
            EmployeeElectionNomineeBody.AjaxCallEmployeeElectionNomineeBody();
        });
        $('#NameOfBoardBody').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#PostHeld').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


        $('#Remarks').on("keydown", function (e) {
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
             url: '/EmployeeElectionNomineeBody/List',
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
            url: '/EmployeeElectionNomineeBody/List',
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
    AjaxCallEmployeeElectionNomineeBody: function () {
        var EmployeeElectionNomineeBodyData = null;
        if (EmployeeElectionNomineeBody.ActionName == "Create") {
            $("#FormCreateEmployeeElectionNomineeBody").validate();
            if ($("#FormCreateEmployeeElectionNomineeBody").valid()) {
                EmployeeElectionNomineeBodyData = null;
                EmployeeElectionNomineeBodyData = EmployeeElectionNomineeBody.GetEmployeeElectionNomineeBody();
                ajaxRequest.makeRequest("/EmployeeElectionNomineeBody/Create", "POST", EmployeeElectionNomineeBodyData, EmployeeElectionNomineeBody.Success);
            }
        }
        else if (EmployeeElectionNomineeBody.ActionName == "Edit") {
            $("#FormEditEmployeeElectionNomineeBody").validate();
            if ($("#FormEditEmployeeElectionNomineeBody").valid()) {
                EmployeeElectionNomineeBodyData = null;
                EmployeeElectionNomineeBodyData = EmployeeElectionNomineeBody.GetEmployeeElectionNomineeBody();
                ajaxRequest.makeRequest("/EmployeeElectionNomineeBody/Edit", "POST", EmployeeElectionNomineeBodyData, EmployeeElectionNomineeBody.Success);
            }
        }
        else if (EmployeeElectionNomineeBody.ActionName == "Delete") {
            EmployeeElectionNomineeBodyData = null;
            //$("#FormCreateEmployeeElectionNomineeBody").validate();
            EmployeeElectionNomineeBodyData = EmployeeElectionNomineeBody.GetEmployeeElectionNomineeBody();
            ajaxRequest.makeRequest("/EmployeeElectionNomineeBody/Delete", "POST", EmployeeElectionNomineeBodyData, EmployeeElectionNomineeBody.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeElectionNomineeBody: function () {
        var Data = {
        };
        if (EmployeeElectionNomineeBody.ActionName == "Create" || EmployeeElectionNomineeBody.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.EmployeeID = $('#EmployeeID').val();
            Data.GeneralBoardUniversityID = $('#GeneralBoardUniversityID').val();
            Data.NameOfBoardBody = $('#NameOfBoardBody').val();
            Data.PostHeld = $('#PostHeld').val();
            Data.Remarks = $('#Remarks').val();
            Data.FromDate = $('#FromDate').val();
            Data.ToDate = $('#ToDate').val();
            //Data.InActiveReason = $('#InActiveReason').val();
            //Data.InActiveDate = $('#InActiveDate').val();
            Data.IsActive = $('input[id=IsActive]:checked').val() ? true : false;

        }
        else if (EmployeeElectionNomineeBody.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            $.magnificPopup.close();
            EmployeeElectionNomineeBody.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            $.magnificPopup.close();
            EmployeeElectionNomineeBody.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
   
};

