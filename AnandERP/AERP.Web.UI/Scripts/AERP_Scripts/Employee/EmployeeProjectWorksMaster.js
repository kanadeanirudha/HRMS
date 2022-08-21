////this class contain methods related to nationality functionality
//var EmployeeProjectWorksMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeeProjectWorksMaster.constructor();
//        //EmployeeProjectWorksMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $('#CountryName').focus();

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#CountryName').focus();
//            return false;
//        });

//        // Create new record
//        $('#btnCreateEmployeeProjectWorksMaster').on("click", function () {
//            EmployeeProjectWorksMaster.ActionName = "Create";
//            EmployeeProjectWorksMaster.AjaxCallEmployeeProjectWorksMaster();
//        });

//        $('#btnEditEmployeeProjectWorksMaster').on("click", function () {

//            EmployeeProjectWorksMaster.ActionName = "Edit";
//            EmployeeProjectWorksMaster.AjaxCallEmployeeProjectWorksMaster();
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

//        $('#ProjectWorkName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $('#FundingAgency').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $('#EmployeeRemark').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $('#WorkAsDesignation').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        }); 

//        $('#ProjectCost').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#Duration').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });

//        $('#ProjectCost').on("keyup", function (e) {
//            parseFloat(this.value).toFixed(2);
//        });


//        $('#ProjectWorkDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//        })

//        $('#AssignmentFromDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#AssignmentToDate").datepicker("option", "minDate", selectedDate);
//            }
//        })

//        $('#AssignmentToDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#AssignmentFromDate").datepicker("option", "maxDate", selectedDate);
//            }
//        })

//        $('#ProjectWorkFromDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#ProjectWorkToDate").datepicker("option", "minDate", selectedDate);
//            }
//        })
//        $('#ProjectWorkToDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#ProjectWorkFromDate").datepicker("option", "maxDate", selectedDate);
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
//             url: '/EmployeeProjectWorksMaster/List',
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
//            url: '/EmployeeProjectWorksMaster/List',
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
//    AjaxCallEmployeeProjectWorksMaster: function () {
//        var EmployeeProjectWorksMasterData = null;
//        if (EmployeeProjectWorksMaster.ActionName == "Create") {
//            $("#FormCreateEmployeeProjectWorksMaster").validate();
//            if ($("#FormCreateEmployeeProjectWorksMaster").valid()) {
//                EmployeeProjectWorksMasterData = null;
//                EmployeeProjectWorksMasterData = EmployeeProjectWorksMaster.GetEmployeeProjectWorksMaster();
//                ajaxRequest.makeRequest("/EmployeeProjectWorksMaster/Create", "POST", EmployeeProjectWorksMasterData, EmployeeProjectWorksMaster.Success);
//            }
//        }
//        else if (EmployeeProjectWorksMaster.ActionName == "Edit") {
//            $("#FormEditEmployeeProjectWorksMaster").validate();
//            if ($("#FormEditEmployeeProjectWorksMaster").valid()) {
//                EmployeeProjectWorksMasterData = null;
//                EmployeeProjectWorksMasterData = EmployeeProjectWorksMaster.GetEmployeeProjectWorksMaster();
//                ajaxRequest.makeRequest("/EmployeeProjectWorksMaster/Edit", "POST", EmployeeProjectWorksMasterData, EmployeeProjectWorksMaster.Success);
//            }
//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeeProjectWorksMaster: function () {
//        var Data = {
//        };
//        if (EmployeeProjectWorksMaster.ActionName == "Create" || EmployeeProjectWorksMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.CentreCode = $('#CentreCode').val();
//            Data.EmployeeID = $("#EmployeeID").val()
//            Data.ProjectWorkName = $('#ProjectWorkName').val();
//            Data.ProjectWorkDate = $('#ProjectWorkDate').val();
//            Data.ProjectCost = $('#ProjectCost').val();
//            Data.FundingAgency = $('#FundingAgency').val();
//            Data.ProjectWorkFromDate = $('#ProjectWorkFromDate').val();
//            Data.ProjectWorkToDate = $('#ProjectWorkToDate').val();
//            Data.AssignmentFromDate = $('#AssignmentFromDate').val();
//            Data.AssignmentToDate = $('#AssignmentToDate').val();
//            Data.WorkAsDesignation = $('#WorkAsDesignation').val();
//            Data.EmployeeRemark = $('#EmployeeRemark').val();
//            Data.Duration = $('#Duration').val();
//            Data.DurationUnit = $('#DurationUnit').val();
//            if ($('#ProjectStatus').val() == 1 ) {
//                Data.ProjectStatus = true;
//            }
//            else {
//                Data.ProjectStatus = false;
//            }
//            if ($('#IndividualProjectStatus').val() == 1) {
//                Data.IndividualProjectStatus = true;
//            }
//            else {
//                Data.IndividualProjectStatus = false;
//            }
//            Data.EmployeeProjectWorksDetailsID = $('#EmployeeProjectWorksDetailsID').val();
//            Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
//        }

//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {

//        var splitData = data.split(',');

//        parent.$.colorbox.close();
//        EmployeeProjectWorksMaster.ReloadList(splitData[0], splitData[1], splitData[2]);


//    },

//};

/////////////////////////////////new js////////////////////////////

//this class contain methods related to nationality functionality
var EmployeeProjectWorksMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeProjectWorksMaster.constructor();
        //EmployeeProjectWorksMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CountryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        // Create new record
        $('#btnCreateEmployeeProjectWorksMaster').on("click", function () {
            EmployeeProjectWorksMaster.ActionName = "Create";
            EmployeeProjectWorksMaster.AjaxCallEmployeeProjectWorksMaster();
        });

        $('#btnEditEmployeeProjectWorksMaster').on("click", function () {

            EmployeeProjectWorksMaster.ActionName = "Edit";
            EmployeeProjectWorksMaster.AjaxCallEmployeeProjectWorksMaster();
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

        $('#ProjectWorkName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#FundingAgency').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#EmployeeRemark').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#WorkAsDesignation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#ProjectCost').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#Duration').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#ProjectCost').on("keyup", function (e) {
            parseFloat(this.value).toFixed(2);
        });


        //$('#ProjectWorkDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //})

        $('#ProjectWorkDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        //$('#AssignmentFromDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#AssignmentToDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        $('#AssignmentFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#AssignmentFromDate').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#AssignmentToDate').data("DateTimePicker").minDate(minDate);
        });

        //$('#AssignmentToDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#AssignmentFromDate").datepicker("option", "maxDate", selectedDate);
        //    }
        //})

        $('#AssignmentToDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#AssignmentToDate').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#AssignmentFromDate').data("DateTimePicker").maxDate(maxDate);
        });

        //$('#ProjectWorkFromDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ProjectWorkToDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        $('#ProjectWorkFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#ProjectWorkFromDate').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#ProjectWorkToDate').data("DateTimePicker").minDate(minDate);
        });

        //$('#ProjectWorkToDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ProjectWorkFromDate").datepicker("option", "maxDate", selectedDate);
        //    }
        //})
        $('#ProjectWorkToDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        });

        $('#ProjectWorkToDate').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#ProjectWorkFromDate').data("DateTimePicker").maxDate(maxDate);
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
             url: '/EmployeeProjectWorksMaster/List',
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
            url: '/EmployeeProjectWorksMaster/List',
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
    AjaxCallEmployeeProjectWorksMaster: function () {
        var EmployeeProjectWorksMasterData = null;
        if (EmployeeProjectWorksMaster.ActionName == "Create") {
            $("#FormCreateEmployeeProjectWorksMaster").validate();
            if ($("#FormCreateEmployeeProjectWorksMaster").valid()) {
                EmployeeProjectWorksMasterData = null;
                EmployeeProjectWorksMasterData = EmployeeProjectWorksMaster.GetEmployeeProjectWorksMaster();
                ajaxRequest.makeRequest("/EmployeeProjectWorksMaster/Create", "POST", EmployeeProjectWorksMasterData, EmployeeProjectWorksMaster.Success);
            }
        }
        else if (EmployeeProjectWorksMaster.ActionName == "Edit") {
            $("#FormEditEmployeeProjectWorksMaster").validate();
            if ($("#FormEditEmployeeProjectWorksMaster").valid()) {
                EmployeeProjectWorksMasterData = null;
                EmployeeProjectWorksMasterData = EmployeeProjectWorksMaster.GetEmployeeProjectWorksMaster();
                ajaxRequest.makeRequest("/EmployeeProjectWorksMaster/Edit", "POST", EmployeeProjectWorksMasterData, EmployeeProjectWorksMaster.Success);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeProjectWorksMaster: function () {
        var Data = {
        };
        if (EmployeeProjectWorksMaster.ActionName == "Create" || EmployeeProjectWorksMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.EmployeeID = $("#EmployeeID").val()
            Data.ProjectWorkName = $('#ProjectWorkName').val();
            Data.ProjectWorkDate = $('#ProjectWorkDate').val();
            Data.ProjectCost = $('#ProjectCost').val();
            Data.FundingAgency = $('#FundingAgency').val();
            Data.ProjectWorkFromDate = $('#ProjectWorkFromDate').val();
            Data.ProjectWorkToDate = $('#ProjectWorkToDate').val();
            Data.AssignmentFromDate = $('#AssignmentFromDate').val();
            Data.AssignmentToDate = $('#AssignmentToDate').val();
            Data.WorkAsDesignation = $('#WorkAsDesignation').val();
            Data.EmployeeRemark = $('#EmployeeRemark').val();
            Data.Duration = $('#Duration').val();
            Data.DurationUnit = $('#DurationUnit').val();
            if ($('#ProjectStatus').val() == 1) {
                Data.ProjectStatus = true;
            }
            else {
                Data.ProjectStatus = false;
            }
            if ($('#IndividualProjectStatus').val() == 1) {
                Data.IndividualProjectStatus = true;
            }
            else {
                Data.IndividualProjectStatus = false;
            }
            Data.EmployeeProjectWorksDetailsID = $('#EmployeeProjectWorksDetailsID').val();
            Data.IsActive = $('input[id=IsActive]:checked').val() ? true : false;
        }

        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');

        //parent.$.colorbox.close();
        $.magnificPopup.close();
        EmployeeProjectWorksMaster.ReloadList(splitData[0], splitData[1], splitData[2]);


    },

};

