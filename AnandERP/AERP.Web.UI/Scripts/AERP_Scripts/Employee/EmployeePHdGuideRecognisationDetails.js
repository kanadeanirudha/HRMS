////this class contain methods related to nationality functionality
//var EmployeePHdGuideRecognisationDetails = {
//    //Member variables
//    ActionName: null,
//    MasterID :null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeePHdGuideRecognisationDetails.constructor();
//        //EmployeePHdGuideRecognisationDetails.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $('#GeneralBoardUniversityID').focus();

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#CountryName').focus();
//        });

//        // Create new record
//        $('#btnCreateEmployeePHdGuideRecognisationDetails').on("click", function () {
//            EmployeePHdGuideRecognisationDetails.ActionName = "CreateEmployeePHdGuideRecognisationDetails";
//            EmployeePHdGuideRecognisationDetails.AjaxCallEmployeePHdGuideRecognisationDetails();
//        });

//        $('#btnEmployeePHdGuideStudentsDetails').on("click", function () {
//            if ($("#ID").val() > 0 || EmployeePHdGuideRecognisationDetails.MasterID > 0) {
//                EmployeePHdGuideRecognisationDetails.ActionName = "EmployeePHdGuideStudentsDetailsInsertUpdate";
//                EmployeePHdGuideRecognisationDetails.AjaxCallEmployeePHdGuideRecognisationDetails();
//            }
//            else {
//                parent.$.colorbox.close();
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_EmployeeFormStatus", "EmployeeFormStatusMessages", "#FFCC80");
//                //$('#EmployeeFormStatusMessages').html("User must add employee Ph.D guide details first");
//                //$('#EmployeeFormStatusMessages').delay(800).slideDown('slow').delay(10000).slideUp(2000).css('background-color', "#FFCC80");
//            }
//        });

//        $('#DeleteEmployeePHdGuideStudentsDetailsRecord').on("click", function () {
//            EmployeePHdGuideRecognisationDetails.ActionName = "DeleteEmployeePHdGuideRecognisationDetails";
//            EmployeePHdGuideRecognisationDetails.AjaxCallEmployeePHdGuideRecognisationDetails();
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

//        $('#ApprovalSubjectName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $('#Remarks').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#NumberOfCandidateRegistered').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#NoOfCandidateCompletedPHd').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });

//        $('#StudentName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#Synopsis').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
        
        
//        $('#UniversityApprovalDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//        })

//        $('#ApprovalFromDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#ApprovalUptoDate").datepicker("option", "minDate", selectedDate);
//            }
//        })

//        $('#ApprovalUptoDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#ApprovalFromDate").datepicker("option", "maxDate", selectedDate);
//            }
//        })

        
//        $('#ApprovalDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//        })

//        $('#PersuingFromDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#PersuingUptoDate").datepicker("option", "minDate", selectedDate);
//            }
//        })

//        $('#PersuingUptoDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#PersuingFromDate").datepicker("option", "maxDate", selectedDate);
//            }
//        })


//    },
//    //LoadList method is used to load List page
//    LoadList: function () {
//        var EmployeeID = $("#EmployeeID").val();
//        $.ajax(

//         {

//             cache: false,
//             type: "POST",
//             data: { "EmployeeID": EmployeeID },
//             dataType: "html",
//             url: '/EmployeePHdGuideRecognisationDetails/List',
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
//            data: { "actionMode": actionMode, "EmployeeID": EmployeeID },
//            url: '/EmployeePHdGuideRecognisationDetails/List',
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
//    AjaxCallEmployeePHdGuideRecognisationDetails: function () {
//        var EmployeePHdGuideRecognisationDetailsData = null;
//        if (EmployeePHdGuideRecognisationDetails.ActionName == "CreateEmployeePHdGuideRecognisationDetails") {
//            $("#FormCreateEmployeePHdGuideRecognisationDetails").validate();
//            if ($("#FormCreateEmployeePHdGuideRecognisationDetails").valid()) {
//                EmployeePHdGuideRecognisationDetailsData = null;
//                EmployeePHdGuideRecognisationDetailsData = EmployeePHdGuideRecognisationDetails.GetEmployeePHdGuideRecognisationDetails();
//                ajaxRequest.makeRequest("/EmployeePHdGuideRecognisationDetails/CreateEmployeePHdGuideRecognisationDetails", "POST", EmployeePHdGuideRecognisationDetailsData, EmployeePHdGuideRecognisationDetails.SuccessEmployeePHdGuideRecognisationDetails);
//            }
//        }
//        else if (EmployeePHdGuideRecognisationDetails.ActionName == "EmployeePHdGuideStudentsDetailsInsertUpdate") {
//            $("#FormEmployeePHdGuideStudentsDetails").validate();
//            if ($("#FormEmployeePHdGuideStudentsDetails").valid()) {
//                EmployeePHdGuideRecognisationDetailsData = null;
//                EmployeePHdGuideRecognisationDetailsData = EmployeePHdGuideRecognisationDetails.GetEmployeePHdGuideRecognisationDetails();
//                ajaxRequest.makeRequest("/EmployeePHdGuideRecognisationDetails/Create", "POST", EmployeePHdGuideRecognisationDetailsData, EmployeePHdGuideRecognisationDetails.SuccessEmployeePHdGuideStudentsDetails);
//            }
//        }
//        else if (EmployeePHdGuideRecognisationDetails.ActionName == "DeleteEmployeePHdGuideRecognisationDetails") {
//            $("#FormDeleteEmployeePHdGuideStudentsDetails").validate();
//            if ($("#FormDeleteEmployeePHdGuideStudentsDetails").valid()) {
//                EmployeePHdGuideRecognisationDetailsData = null;
//                EmployeePHdGuideRecognisationDetailsData = EmployeePHdGuideRecognisationDetails.GetEmployeePHdGuideRecognisationDetails();
//                ajaxRequest.makeRequest("/EmployeePHdGuideRecognisationDetails/Delete", "POST", EmployeePHdGuideRecognisationDetailsData, EmployeePHdGuideRecognisationDetails.SuccessEmployeePHdGuideStudentsDetails);
//            }
//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeePHdGuideRecognisationDetails: function () {
//        var Data = {
//        };
//        if (EmployeePHdGuideRecognisationDetails.ActionName == "CreateEmployeePHdGuideRecognisationDetails" ) {
//            if (EmployeePHdGuideRecognisationDetails.MasterID > 0) {
//                Data.ID = EmployeePHdGuideRecognisationDetails.MasterID;
//            }
//            else  {
//                Data.ID = $('#ID').val();
//            }
//            Data.GeneralBoardUniversityID = $('#GeneralBoardUniversityID').val();
//            Data.EmployeeID = $("#EmployeeID").val();
//            Data.ApprovalSubjectName = $('#ApprovalSubjectName').val();
//            Data.ApprovalFromDate = $('#ApprovalFromDate').val();
//            Data.ApprovalUptoDate = $('#ApprovalUptoDate').val();
//            Data.UniversityApprovalNumber = $('#UniversityApprovalNumber').val();
//            Data.UniversityApprovalDate = $('#UniversityApprovalDate').val();
//            Data.NumberOfCandidateRegistered = $('#NumberOfCandidateRegistered').val();
//            Data.NoOfCandidateCompletedPHd = $('#NoOfCandidateCompletedPHd').val();
//            Data.Remarks = $('#Remarks').val();
//        }
//        else if (EmployeePHdGuideRecognisationDetails.ActionName == "EmployeePHdGuideStudentsDetailsInsertUpdate") {

//            if (EmployeePHdGuideRecognisationDetails.MasterID > 0) {
//                Data.ID = EmployeePHdGuideRecognisationDetails.MasterID;
//            }
//            else {
//                Data.ID = $('#ID').val();
//            }
//            Data.EmployeePHdGuideStudentsDetailsID = $('#EmployeePHdGuideStudentsDetailsID').val();
//            Data.StudentName = $("#StudentName").val();
//            Data.PersuingFromDate = $('#PersuingFromDate').val();
//            Data.PersuingUptoDate = $('#PersuingUptoDate').val();
//            Data.ApprovalDate = $('#ApprovalDate').val();
//            Data.ApprovalStatus = $('#ApprovalStatus').val();
//            Data.Synopsis = $('#Synopsis').val();
//            Data.EmployeePHdGuideStudentsDetailsRemarks = $('#EmployeePHdGuideStudentsDetailsRemarks').val();
//        }
//        else if (EmployeePHdGuideRecognisationDetails.ActionName = "DeleteEmployeePHdGuideRecognisationDetails") {
//            Data.EmployeePHdGuideStudentsDetailsID = $('#EmployeePHdGuideStudentsDetailsID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    SuccessEmployeePHdGuideStudentsDetails: function (data) {
//        var splitData = data.split(',');
//        parent.$.colorbox.close();
//        EmployeePHdGuideRecognisationDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//    },
//    SuccessEmployeePHdGuideRecognisationDetails: function (data) {
//        var splitData = data.split('~');
//        var displayData = splitData[0].split(',');
//        EmployeePHdGuideRecognisationDetails.MasterID = splitData[1];
//        if (EmployeePHdGuideRecognisationDetails.MasterID != null || EmployeePHdGuideRecognisationDetails.MasterID != 0) {
//            $("#ID").val(EmployeePHdGuideRecognisationDetails.MasterID);
//        }
       
//        $('#EmployeeFormStatusMessages').html(displayData[0]);
//        $('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(600).slideUp(2000).css('background-color', displayData[1]);

//    },
//};

////////////////////////new js//////////////////////////////

//this class contain methods related to nationality functionality
var EmployeePHdGuideRecognisationDetails = {
    //Member variables
    ActionName: null,
    MasterID: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeePHdGuideRecognisationDetails.constructor();
        //EmployeePHdGuideRecognisationDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#GeneralBoardUniversityID').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
        });

        // Create new record
        $('#btnCreateEmployeePHdGuideRecognisationDetails').on("click", function () {
            //alert();
            EmployeePHdGuideRecognisationDetails.ActionName = "CreateEmployeePHdGuideRecognisationDetails";
            EmployeePHdGuideRecognisationDetails.AjaxCallEmployeePHdGuideRecognisationDetails();
        });

        $('#btnEmployeePHdGuideStudentsDetails').on("click", function () {
            //debugger;
            if ($("#ID").val() > 0 || EmployeePHdGuideRecognisationDetails.MasterID > 0) {
                EmployeePHdGuideRecognisationDetails.ActionName = "EmployeePHdGuideStudentsDetailsInsertUpdate";
                EmployeePHdGuideRecognisationDetails.AjaxCallEmployeePHdGuideRecognisationDetails();
            }
            else {
                //parent.$.colorbox.close();
                $.magnificPopup.close();
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_EmployeeFormStatus", "EmployeeFormStatusMessages", "#FFCC80");
                //$('#EmployeeFormStatusMessages').html("User must add employee Ph.D guide details first");
                //$('#EmployeeFormStatusMessages').delay(800).slideDown('slow').delay(10000).slideUp(2000).css('background-color', "#FFCC80");
                notify("User must add employee Ph.D guide details first","danger");
            }
        });

        $('#DeleteEmployeePHdGuideStudentsDetailsRecord').on("click", function () {
            EmployeePHdGuideRecognisationDetails.ActionName = "DeleteEmployeePHdGuideRecognisationDetails";
            EmployeePHdGuideRecognisationDetails.AjaxCallEmployeePHdGuideRecognisationDetails();
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

        $('#ApprovalSubjectName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Remarks').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#NumberOfCandidateRegistered').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#NoOfCandidateCompletedPHd').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#StudentName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#Synopsis').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


        //$('#UniversityApprovalDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //})

        $('#UniversityApprovalDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        //$('#ApprovalFromDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ApprovalUptoDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        $('#ApprovalFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#ApprovalFromDate').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#ApprovalUptoDate').data("DateTimePicker").minDate(minDate);
        });


        //$('#ApprovalUptoDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ApprovalFromDate").datepicker("option", "maxDate", selectedDate);
        //    }
        //})

        $('#ApprovalUptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#ApprovalUptoDate').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#ApprovalFromDate').data("DateTimePicker").maxDate(maxDate);
        });

        //$('#ApprovalDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //})

        $('#ApprovalDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        //$('#PersuingFromDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#PersuingUptoDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        $('#PersuingFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#PersuingFromDate').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#PersuingUptoDate').data("DateTimePicker").minDate(minDate);
        });


        //$('#PersuingUptoDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#PersuingFromDate").datepicker("option", "maxDate", selectedDate);
        //    }
        //})

        $('#PersuingUptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#PersuingUptoDate').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#PersuingFromDate').data("DateTimePicker").maxDate(maxDate);
        });

    },
    //LoadList method is used to load List page
    LoadList: function () {
        var EmployeeID = $("#EmployeeID").val();
        $.ajax(

         {

             cache: false,
             type: "POST",
             data: { "EmployeeID": EmployeeID },
             dataType: "html",
             url: '/EmployeePHdGuideRecognisationDetails/List',
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
            data: { "actionMode": actionMode, "EmployeeID": EmployeeID },
            url: '/EmployeePHdGuideRecognisationDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeePHdGuideRecognisationDetails: function () {
        var EmployeePHdGuideRecognisationDetailsData = null;
        if (EmployeePHdGuideRecognisationDetails.ActionName == "CreateEmployeePHdGuideRecognisationDetails") {
            $("#FormCreateEmployeePHdGuideRecognisationDetails").validate();
            if ($("#FormCreateEmployeePHdGuideRecognisationDetails").valid()) {
                EmployeePHdGuideRecognisationDetailsData = null;
                EmployeePHdGuideRecognisationDetailsData = EmployeePHdGuideRecognisationDetails.GetEmployeePHdGuideRecognisationDetails();
                ajaxRequest.makeRequest("/EmployeePHdGuideRecognisationDetails/CreateEmployeePHdGuideRecognisationDetails", "POST", EmployeePHdGuideRecognisationDetailsData, EmployeePHdGuideRecognisationDetails.SuccessEmployeePHdGuideRecognisationDetails);
            }
        }
        else if (EmployeePHdGuideRecognisationDetails.ActionName == "EmployeePHdGuideStudentsDetailsInsertUpdate") {
            $("#FormEmployeePHdGuideStudentsDetails").validate();
            if ($("#FormEmployeePHdGuideStudentsDetails").valid()) {
                EmployeePHdGuideRecognisationDetailsData = null;
                EmployeePHdGuideRecognisationDetailsData = EmployeePHdGuideRecognisationDetails.GetEmployeePHdGuideRecognisationDetails();
                ajaxRequest.makeRequest("/EmployeePHdGuideRecognisationDetails/Create", "POST", EmployeePHdGuideRecognisationDetailsData, EmployeePHdGuideRecognisationDetails.SuccessEmployeePHdGuideStudentsDetails);
            }
        }
        else if (EmployeePHdGuideRecognisationDetails.ActionName == "DeleteEmployeePHdGuideRecognisationDetails") {
            $("#FormDeleteEmployeePHdGuideStudentsDetails").validate();
            if ($("#FormDeleteEmployeePHdGuideStudentsDetails").valid()) {
                EmployeePHdGuideRecognisationDetailsData = null;
                EmployeePHdGuideRecognisationDetailsData = EmployeePHdGuideRecognisationDetails.GetEmployeePHdGuideRecognisationDetails();
                ajaxRequest.makeRequest("/EmployeePHdGuideRecognisationDetails/Delete", "POST", EmployeePHdGuideRecognisationDetailsData, EmployeePHdGuideRecognisationDetails.SuccessEmployeePHdGuideStudentsDetails);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeePHdGuideRecognisationDetails: function () {
        var Data = {
        };
        if (EmployeePHdGuideRecognisationDetails.ActionName == "CreateEmployeePHdGuideRecognisationDetails") {
            if (EmployeePHdGuideRecognisationDetails.MasterID > 0) {
                Data.ID = EmployeePHdGuideRecognisationDetails.MasterID;
            }
            else {
                Data.ID = $('#ID').val();
            }
            Data.GeneralBoardUniversityID = $('#GeneralBoardUniversityID').val();
            Data.EmployeeID = $("#EmployeeID").val();
            Data.ApprovalSubjectName = $('#ApprovalSubjectName').val();
            Data.ApprovalFromDate = $('#ApprovalFromDate').val();
            Data.ApprovalUptoDate = $('#ApprovalUptoDate').val();
            Data.UniversityApprovalNumber = $('#UniversityApprovalNumber').val();
            Data.UniversityApprovalDate = $('#UniversityApprovalDate').val();
            Data.NumberOfCandidateRegistered = $('#NumberOfCandidateRegistered').val();
            Data.NoOfCandidateCompletedPHd = $('#NoOfCandidateCompletedPHd').val();
            Data.Remarks = $('#Remarks').val();
        }
        else if (EmployeePHdGuideRecognisationDetails.ActionName == "EmployeePHdGuideStudentsDetailsInsertUpdate") {

            if (EmployeePHdGuideRecognisationDetails.MasterID > 0) {
                Data.ID = EmployeePHdGuideRecognisationDetails.MasterID;
            }
            else {
                Data.ID = $('#ID').val();
            }
            Data.EmployeePHdGuideStudentsDetailsID = $('#EmployeePHdGuideStudentsDetailsID').val();
            Data.StudentName = $("#StudentName").val();
            Data.PersuingFromDate = $('#PersuingFromDate').val();
            Data.PersuingUptoDate = $('#PersuingUptoDate').val();
            Data.ApprovalDate = $('#ApprovalDate').val();
            Data.ApprovalStatus = $('#ApprovalStatus').val();
            Data.Synopsis = $('#Synopsis').val();
            Data.EmployeePHdGuideStudentsDetailsRemarks = $('#EmployeePHdGuideStudentsDetailsRemarks').val();
        }
        else if (EmployeePHdGuideRecognisationDetails.ActionName = "DeleteEmployeePHdGuideRecognisationDetails") {
            Data.EmployeePHdGuideStudentsDetailsID = $('#EmployeePHdGuideStudentsDetailsID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    SuccessEmployeePHdGuideStudentsDetails: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        EmployeePHdGuideRecognisationDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
    SuccessEmployeePHdGuideRecognisationDetails: function (data) {
        var splitData = data.split('~');
        var displayData = splitData[0].split(',');
        EmployeePHdGuideRecognisationDetails.MasterID = splitData[1];
        if (EmployeePHdGuideRecognisationDetails.MasterID != null || EmployeePHdGuideRecognisationDetails.MasterID != 0) {
            $("#ID").val(EmployeePHdGuideRecognisationDetails.MasterID);
        }
        
        //$('#EmployeeFormStatusMessages').html(displayData[0]);
        //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(600).slideUp(2000).css('background-color', displayData[1]);
        notify(displayData[0], displayData[1]);

    },
};

