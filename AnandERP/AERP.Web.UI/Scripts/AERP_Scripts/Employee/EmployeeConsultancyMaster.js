//this class contain methods related to nationality functionality
var EmployeeConsultancyMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeConsultancyMaster.constructor();
        //EmployeeConsultancyMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CountryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#ConsultancyName').focus();
            return false;
        });






        // Create new record
        $('#btnCreateEmployeeConsultancyMaster').on("click", function () {
            EmployeeConsultancyMaster.ActionName = "Create";
            EmployeeConsultancyMaster.AjaxCallEmployeeConsultancyMaster();
        });

        $('#btnEditEmployeeConsultancyMaster').on("click", function () {
            //debugger;
            EmployeeConsultancyMaster.ActionName = "Edit";
            EmployeeConsultancyMaster.AjaxCallEmployeeConsultancyMaster();
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


        $('#ConsultancyName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#TitleOfAssignment').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#EmployeeRemark').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        
        $('#ConsultancyCost').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#EmployeeShare').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#ConsultancyCost').on("keyup", function (e) {
            parseFloat(this.value).toFixed(2);
        });
        $('#EmployeeShare').on("keyup", function (e) {
            parseFloat(this.value).toFixed(2);
        });

        //$('#ConsultancyDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //})

        $('#ConsultancyDate').datetimepicker({
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

        //$('#AssignmentToDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#AssignmentFromDate").datepicker("option", "maxDate", selectedDate);
        //    }
        //})

        //$('#ConsultingFromDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ConsultingToDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        $('#ConsultingFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });

        $('#ConsultingToDate').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#ConsultingToDate').data("DateTimePicker").minDate(minDate);
        });

        //$('#ConsultingToDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ConsultingFromDate").datepicker("option", "maxDate", selectedDate);
        //    }
        //})
        $('#ConsultingToDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });

        $('#ConsultingToDate').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#ConsultingFromDate').data("DateTimePicker").maxDate(maxDate);
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
             url: '/EmployeeConsultancyMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 //console.log("on load list-"+data);
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
            data: { "actionMode": actionMode ,"EmployeeID": EmployeeID  },
            url: '/EmployeeConsultancyMaster/List',
            success: function (data) {
                //Rebind Grid Data
                console.log("reload-"+data);
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeConsultancyMaster: function () {
        var EmployeeConsultancyMasterData = null;
        if (EmployeeConsultancyMaster.ActionName == "Create") {
            $("#FormCreateEmployeeConsultancyMaster").validate();
           
            if ($("#FormCreateEmployeeConsultancyMaster").valid()) {
                EmployeeConsultancyMasterData = null;
                EmployeeConsultancyMasterData = EmployeeConsultancyMaster.GetEmployeeConsultancyMaster();
                ajaxRequest.makeRequest("/EmployeeConsultancyMaster/Create", "POST", EmployeeConsultancyMasterData, EmployeeConsultancyMaster.Success);
            }
        }
        else if (EmployeeConsultancyMaster.ActionName == "Edit") {
            $("#FormEditEmployeeConsultancyMaster").validate();
            if ($("#FormEditEmployeeConsultancyMaster").valid()) {
                EmployeeConsultancyMasterData = null;
                EmployeeConsultancyMasterData = EmployeeConsultancyMaster.GetEmployeeConsultancyMaster();
                ajaxRequest.makeRequest("/EmployeeConsultancyMaster/Edit", "POST", EmployeeConsultancyMasterData, EmployeeConsultancyMaster.Success);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeConsultancyMaster: function () {
        var Data = {
        };
        if (EmployeeConsultancyMaster.ActionName == "Create" || EmployeeConsultancyMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.EmployeeID = $("#EmployeeID").val()
            Data.ConsultancyName = $('#ConsultancyName').val();
            Data.TitleOfAssignment = $('#TitleOfAssignment').val();
            Data.ConsultancyDate = $('#ConsultancyDate').val();
            Data.ConsultancyCost = $('#ConsultancyCost').val();
            Data.EmployeeShare = $('#EmployeeShare').val();
            Data.AssignmentFromDate = $('#AssignmentFromDate').val();
            Data.AssignmentToDate = $('#AssignmentToDate').val();
            Data.ConsultingFromDate = $('#ConsultingFromDate').val();
            Data.ConsultingToDate = $('#ConsultingToDate').val();
            Data.EmployeeRemark = $('#EmployeeRemark').val();
            Data.EmpConsultancyDetID = $('#EmpConsultancyDetID').val();
            Data.IsActive =  $('input[name=IsActive]:checked').val() ? true : false;
        }
       
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeConsultancyMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeConsultancyMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
   
};

