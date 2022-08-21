////this class contain methods related to nationality functionality
//var EmployeePatentReceivedDetails = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeePatentReceivedDetails.constructor();
//        //EmployeePatentReceivedDetails.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#SubjectOfPatent').focus();
//            $('#SubjectOfPatent').val('');
//        });



//        $('#DateOfApplication').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#DateOfApproval").datepicker("option", "minDate", selectedDate);
//            }
//        })

//        $('#DateOfApproval').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#DateOfApplication").datepicker("option", "maxDate", selectedDate);
//            }
//        })

//        // Create new record
//        $('#CreateEmployeePatentReceivedDetailsRecord').on("click", function () {
//            EmployeePatentReceivedDetails.ActionName = "Create";
//            EmployeePatentReceivedDetails.AjaxCallEmployeePatentReceivedDetails();
//        });

//        $('#EditEmployeePatentReceivedDetailsRecord').on("click", function () {
            
//            EmployeePatentReceivedDetails.ActionName = "Edit";
//            EmployeePatentReceivedDetails.AjaxCallEmployeePatentReceivedDetails();
//        });

//        $('#DeleteEmployeePatentReceivedDetailsRecord').on("click", function () {

//            EmployeePatentReceivedDetails.ActionName = "Delete";
//            EmployeePatentReceivedDetails.AjaxCallEmployeePatentReceivedDetails();
//        });
       
//        $("#UserSearch").keyup(function () {
//            oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $('#SubjectOfPatent').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#Remarks').on("keydown", function (e) {
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
//             data: { "EmployeeID": EmployeeID },
//             dataType: "html",
//             url: '/EmployeePatentReceivedDetails/List',
             
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
//            url: '/EmployeePatentReceivedDetails/List',
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
//    AjaxCallEmployeePatentReceivedDetails: function () {
//        var EmployeePatentReceivedDetailsData = null;
//        if (EmployeePatentReceivedDetails.ActionName == "Create") {
        
//            $("#FormCreateEmployeePatentReceivedDetails").validate();
//            if ($("#FormCreateEmployeePatentReceivedDetails").valid()) {
//                EmployeePatentReceivedDetailsData = null;
//                EmployeePatentReceivedDetailsData = EmployeePatentReceivedDetails.GetEmployeePatentReceivedDetails();
//                ajaxRequest.makeRequest("/EmployeePatentReceivedDetails/Create", "POST", EmployeePatentReceivedDetailsData, EmployeePatentReceivedDetails.Success);
//            }
//        }
//        else if (EmployeePatentReceivedDetails.ActionName == "Edit") {
//            $("#FormEditEmployeePatentReceivedDetails").validate();
//            if ($("#FormEditEmployeePatentReceivedDetails").valid()) {
//                EmployeePatentReceivedDetailsData = null;
//                EmployeePatentReceivedDetailsData = EmployeePatentReceivedDetails.GetEmployeePatentReceivedDetails();
//                ajaxRequest.makeRequest("/EmployeePatentReceivedDetails/Edit", "POST", EmployeePatentReceivedDetailsData, EmployeePatentReceivedDetails.Success);
//            }
//        }
//        else if (EmployeePatentReceivedDetails.ActionName == "Delete") {
//            EmployeePatentReceivedDetailsData = null;
//            $("#FormDeleteEmployeePatentReceivedDetails").validate();
//            EmployeePatentReceivedDetailsData = EmployeePatentReceivedDetails.GetEmployeePatentReceivedDetails();
//            ajaxRequest.makeRequest("/EmployeePatentReceivedDetails/Delete", "POST", EmployeePatentReceivedDetailsData, EmployeePatentReceivedDetails.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeePatentReceivedDetails: function () {
//        var Data = {
//        };
//        if (EmployeePatentReceivedDetails.ActionName == "Create" || EmployeePatentReceivedDetails.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.EmployeeID = $("#EmployeeID").val()
//            Data.SubjectOfPatent = $('#SubjectOfPatent').val();
//            Data.DateOfApplication = $('#DateOfApplication').val();
//            Data.PatentApprovalStatus = $('#PatentApprovalStatus').val();
//            Data.DateOfApproval = $('#DateOfApproval').val();
//            Data.Remarks = $('#Remarks').val();
          


//        }
//        else if (EmployeePatentReceivedDetails.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            EmployeePatentReceivedDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            EmployeePatentReceivedDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        EmployeePatentReceivedDetails.ReloadList("Record Updated Sucessfully.", actionMode);
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
//    //        EmployeePatentReceivedDetails.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

//////////////////////////////new js///////////////////////////////////

//this class contain methods related to nationality functionality
var EmployeePatentReceivedDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeePatentReceivedDetails.constructor();
        //EmployeePatentReceivedDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SubjectOfPatent').focus();
            $('#SubjectOfPatent').val('');
        });



        //$('#DateOfApplication').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#DateOfApproval").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        $('#DateOfApplication').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#DateOfApplication').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#DateOfApproval').data("DateTimePicker").minDate(minDate);
        });

        //$('#DateOfApproval').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#DateOfApplication").datepicker("option", "maxDate", selectedDate);
        //    }
        //})

        $('#DateOfApproval').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#DateOfApproval').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#DateOfApplication').data("DateTimePicker").maxDate(maxDate);
        });

        // Create new record
        $('#CreateEmployeePatentReceivedDetailsRecord').on("click", function () {
            EmployeePatentReceivedDetails.ActionName = "Create";
            EmployeePatentReceivedDetails.AjaxCallEmployeePatentReceivedDetails();
        });

        $('#EditEmployeePatentReceivedDetailsRecord').on("click", function () {

            EmployeePatentReceivedDetails.ActionName = "Edit";
            EmployeePatentReceivedDetails.AjaxCallEmployeePatentReceivedDetails();
        });

        $('#DeleteEmployeePatentReceivedDetailsRecord').on("click", function () {

            EmployeePatentReceivedDetails.ActionName = "Delete";
            EmployeePatentReceivedDetails.AjaxCallEmployeePatentReceivedDetails();
        });

        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $('#SubjectOfPatent').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#Remarks').on("keydown", function (e) {
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
             data: { "EmployeeID": EmployeeID },
             dataType: "html",
             url: '/EmployeePatentReceivedDetails/List',

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
            url: '/EmployeePatentReceivedDetails/List',
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
    AjaxCallEmployeePatentReceivedDetails: function () {
        var EmployeePatentReceivedDetailsData = null;
        if (EmployeePatentReceivedDetails.ActionName == "Create") {

            $("#FormCreateEmployeePatentReceivedDetails").validate();
            if ($("#FormCreateEmployeePatentReceivedDetails").valid()) {
                EmployeePatentReceivedDetailsData = null;
                EmployeePatentReceivedDetailsData = EmployeePatentReceivedDetails.GetEmployeePatentReceivedDetails();
                ajaxRequest.makeRequest("/EmployeePatentReceivedDetails/Create", "POST", EmployeePatentReceivedDetailsData, EmployeePatentReceivedDetails.Success);
            }
        }
        else if (EmployeePatentReceivedDetails.ActionName == "Edit") {
            $("#FormEditEmployeePatentReceivedDetails").validate();
            if ($("#FormEditEmployeePatentReceivedDetails").valid()) {
                EmployeePatentReceivedDetailsData = null;
                EmployeePatentReceivedDetailsData = EmployeePatentReceivedDetails.GetEmployeePatentReceivedDetails();
                ajaxRequest.makeRequest("/EmployeePatentReceivedDetails/Edit", "POST", EmployeePatentReceivedDetailsData, EmployeePatentReceivedDetails.Success);
            }
        }
        else if (EmployeePatentReceivedDetails.ActionName == "Delete") {
            EmployeePatentReceivedDetailsData = null;
            $("#FormDeleteEmployeePatentReceivedDetails").validate();
            EmployeePatentReceivedDetailsData = EmployeePatentReceivedDetails.GetEmployeePatentReceivedDetails();
            ajaxRequest.makeRequest("/EmployeePatentReceivedDetails/Delete", "POST", EmployeePatentReceivedDetailsData, EmployeePatentReceivedDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeePatentReceivedDetails: function () {
        var Data = {
        };
        if (EmployeePatentReceivedDetails.ActionName == "Create" || EmployeePatentReceivedDetails.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.EmployeeID = $("#EmployeeID").val()
            Data.SubjectOfPatent = $('#SubjectOfPatent').val();
            Data.DateOfApplication = $('#DateOfApplication').val();
            Data.PatentApprovalStatus = $('#PatentApprovalStatus').val();
            Data.DateOfApproval = $('#DateOfApproval').val();
            Data.Remarks = $('#Remarks').val();



        }
        else if (EmployeePatentReceivedDetails.ActionName == "Delete") {
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
            EmployeePatentReceivedDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeePatentReceivedDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

