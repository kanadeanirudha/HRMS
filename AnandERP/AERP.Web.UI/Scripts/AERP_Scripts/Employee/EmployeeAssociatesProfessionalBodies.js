////this class contain methods related to nationality functionality
//var EmployeeAssociatesProfessionalBodies = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeeAssociatesProfessionalBodies.constructor();
//        //EmployeeAssociatesProfessionalBodies.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#ActivityName').focus();
//            $('#ActivityName').val('');
//        });


//        $('#FromPeriod').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#UptoPeriod").datepicker("option", "minDate", selectedDate);
//            }
//        })

//        $('#UptoPeriod').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#FromPeriod").datepicker("option", "maxDate", selectedDate);
//            }
//        })

//        // Create new record
//        $('#CreateEmployeeAssociatesProfessionalBodiesRecord').on("click", function () {
//            EmployeeAssociatesProfessionalBodies.ActionName = "Create";
//            EmployeeAssociatesProfessionalBodies.AjaxCallEmployeeAssociatesProfessionalBodies();
//        });

//        $('#EditEmployeeAssociatesProfessionalBodiesRecord').on("click", function () {
            
//            EmployeeAssociatesProfessionalBodies.ActionName = "Edit";
//            EmployeeAssociatesProfessionalBodies.AjaxCallEmployeeAssociatesProfessionalBodies();
//        });

//        $('#DeleteEmployeeAssociatesProfessionalBodiesRecord').on("click", function () {

//            EmployeeAssociatesProfessionalBodies.ActionName = "Delete";
//            EmployeeAssociatesProfessionalBodies.AjaxCallEmployeeAssociatesProfessionalBodies();
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

//        $('#ActivityName').on("keydown", function (e) {
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
//             url: '/EmployeeAssociatesProfessionalBodies/List',
             
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
//            url: '/EmployeeAssociatesProfessionalBodies/List',
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
//    AjaxCallEmployeeAssociatesProfessionalBodies: function () {
//        var EmployeeAssociatesProfessionalBodiesData = null;
//        if (EmployeeAssociatesProfessionalBodies.ActionName == "Create") {
        
//            $("#FormCreateEmployeeAssociatesProfessionalBodies").validate();
//            if ($("#FormCreateEmployeeAssociatesProfessionalBodies").valid()) {
//                EmployeeAssociatesProfessionalBodiesData = null;
//                EmployeeAssociatesProfessionalBodiesData = EmployeeAssociatesProfessionalBodies.GetEmployeeAssociatesProfessionalBodies();
//                ajaxRequest.makeRequest("/EmployeeAssociatesProfessionalBodies/Create", "POST", EmployeeAssociatesProfessionalBodiesData, EmployeeAssociatesProfessionalBodies.Success);
//            }
//        }
//        else if (EmployeeAssociatesProfessionalBodies.ActionName == "Edit") {
//            $("#FormEditEmployeeAssociatesProfessionalBodies").validate();
//            if ($("#FormEditEmployeeAssociatesProfessionalBodies").valid()) {
//                EmployeeAssociatesProfessionalBodiesData = null;
//                EmployeeAssociatesProfessionalBodiesData = EmployeeAssociatesProfessionalBodies.GetEmployeeAssociatesProfessionalBodies();
//                ajaxRequest.makeRequest("/EmployeeAssociatesProfessionalBodies/Edit", "POST", EmployeeAssociatesProfessionalBodiesData, EmployeeAssociatesProfessionalBodies.Success);
//            }
//        }
//        else if (EmployeeAssociatesProfessionalBodies.ActionName == "Delete") {
//            EmployeeAssociatesProfessionalBodiesData = null;
//            $("#FormDeleteEmployeeAssociatesProfessionalBodies").validate();
//            EmployeeAssociatesProfessionalBodiesData = EmployeeAssociatesProfessionalBodies.GetEmployeeAssociatesProfessionalBodies();
//            ajaxRequest.makeRequest("/EmployeeAssociatesProfessionalBodies/Delete", "POST", EmployeeAssociatesProfessionalBodiesData, EmployeeAssociatesProfessionalBodies.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeeAssociatesProfessionalBodies: function () {
//        var Data = {
//        };
//        if (EmployeeAssociatesProfessionalBodies.ActionName == "Create" || EmployeeAssociatesProfessionalBodies.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.EmployeeID = $("#EmployeeID").val()
//            Data.ActivityName = $('#ActivityName').val();
//            Data.FromPeriod = $('#FromPeriod').val();
//            Data.UptoPeriod = $('#UptoPeriod').val();
          


//        }
//        else if (EmployeeAssociatesProfessionalBodies.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            EmployeeAssociatesProfessionalBodies.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            EmployeeAssociatesProfessionalBodies.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        EmployeeAssociatesProfessionalBodies.ReloadList("Record Updated Sucessfully.", actionMode);
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
//    //        EmployeeAssociatesProfessionalBodies.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

////////////////////new js//////////////////////////

//this class contain methods related to nationality functionality
var EmployeeAssociatesProfessionalBodies = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeAssociatesProfessionalBodies.constructor();
        //EmployeeAssociatesProfessionalBodies.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#ActivityName').focus();
            $('#ActivityName').val('');
        });


        //$('#FromPeriod').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#UptoPeriod").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        $('#FromPeriod').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#FromPeriod').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#UptoPeriod').data("DateTimePicker").minDate(minDate);
        });


        //$('#UptoPeriod').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#FromPeriod").datepicker("option", "maxDate", selectedDate);
        //    }
        //})

        $('#UptoPeriod').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });
        $('#UptoPeriod').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#FromPeriod').data("DateTimePicker").maxDate(maxDate);
        });
        // Create new record
        $('#CreateEmployeeAssociatesProfessionalBodiesRecord').on("click", function () {
            EmployeeAssociatesProfessionalBodies.ActionName = "Create";
            EmployeeAssociatesProfessionalBodies.AjaxCallEmployeeAssociatesProfessionalBodies();
        });

        $('#EditEmployeeAssociatesProfessionalBodiesRecord').on("click", function () {

            EmployeeAssociatesProfessionalBodies.ActionName = "Edit";
            EmployeeAssociatesProfessionalBodies.AjaxCallEmployeeAssociatesProfessionalBodies();
        });

        $('#DeleteEmployeeAssociatesProfessionalBodiesRecord').on("click", function () {

            EmployeeAssociatesProfessionalBodies.ActionName = "Delete";
            EmployeeAssociatesProfessionalBodies.AjaxCallEmployeeAssociatesProfessionalBodies();
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

        $('#ActivityName').on("keydown", function (e) {
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
             url: '/EmployeeAssociatesProfessionalBodies/List',

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
            url: '/EmployeeAssociatesProfessionalBodies/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },



    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeAssociatesProfessionalBodies: function () {
        var EmployeeAssociatesProfessionalBodiesData = null;
        if (EmployeeAssociatesProfessionalBodies.ActionName == "Create") {

            $("#FormCreateEmployeeAssociatesProfessionalBodies").validate();
            if ($("#FormCreateEmployeeAssociatesProfessionalBodies").valid()) {
                EmployeeAssociatesProfessionalBodiesData = null;
                EmployeeAssociatesProfessionalBodiesData = EmployeeAssociatesProfessionalBodies.GetEmployeeAssociatesProfessionalBodies();
                ajaxRequest.makeRequest("/EmployeeAssociatesProfessionalBodies/Create", "POST", EmployeeAssociatesProfessionalBodiesData, EmployeeAssociatesProfessionalBodies.Success);
            }
        }
        else if (EmployeeAssociatesProfessionalBodies.ActionName == "Edit") {
            $("#FormEditEmployeeAssociatesProfessionalBodies").validate();
            if ($("#FormEditEmployeeAssociatesProfessionalBodies").valid()) {
                EmployeeAssociatesProfessionalBodiesData = null;
                EmployeeAssociatesProfessionalBodiesData = EmployeeAssociatesProfessionalBodies.GetEmployeeAssociatesProfessionalBodies();
                ajaxRequest.makeRequest("/EmployeeAssociatesProfessionalBodies/Edit", "POST", EmployeeAssociatesProfessionalBodiesData, EmployeeAssociatesProfessionalBodies.Success);
            }
        }
        else if (EmployeeAssociatesProfessionalBodies.ActionName == "Delete") {
            EmployeeAssociatesProfessionalBodiesData = null;
            $("#FormDeleteEmployeeAssociatesProfessionalBodies").validate();
            EmployeeAssociatesProfessionalBodiesData = EmployeeAssociatesProfessionalBodies.GetEmployeeAssociatesProfessionalBodies();
            ajaxRequest.makeRequest("/EmployeeAssociatesProfessionalBodies/Delete", "POST", EmployeeAssociatesProfessionalBodiesData, EmployeeAssociatesProfessionalBodies.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeAssociatesProfessionalBodies: function () {
        var Data = {
        };
        if (EmployeeAssociatesProfessionalBodies.ActionName == "Create" || EmployeeAssociatesProfessionalBodies.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.EmployeeID = $("#EmployeeID").val()
            Data.ActivityName = $('#ActivityName').val();
            Data.FromPeriod = $('#FromPeriod').val();
            Data.UptoPeriod = $('#UptoPeriod').val();



        }
        else if (EmployeeAssociatesProfessionalBodies.ActionName == "Delete") {
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
            EmployeeAssociatesProfessionalBodies.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeAssociatesProfessionalBodies.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

