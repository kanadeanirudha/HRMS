//this class contain methods related to nationality functionality
var EmployeePaperPresent = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeePaperPresent.constructor();
        //EmployeePaperPresent.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

      //  $('#CountryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
           // $('#CountryName').focus();
            return false;
        });


       // $('#PublishDate').attr("readonly", true);
        //$('#PublishDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //})

        $('#PublishDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#EmployeeConferenceDateFrom').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#EmployeeConferenceDateTo').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });
        
        $('#EmployeeConferenceDateFrom').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#EmployeeConferenceDateTo').data("DateTimePicker").minDate(minDate);
        });

        $('#EmployeeConferenceDateTo').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#EmployeeConferenceDateFrom').data("DateTimePicker").maxDate(maxDate);
        });

        //$("#EmployeeConferenceDateFrom").datepicker({
        //    dateFormat: 'd-M-yy',
        //    defaultDate: "+1w",
        //    changeMonth: true,
        //    changeYear: true,
        //    numberOfMonths: 1,
        //    onClose: function (selectedDate) {
        //        $("#EmployeeConferenceDateTo").datepicker("option", "minDate", selectedDate);
        //    }
        //});


        //$("#EmployeeConferenceDateTo").datepicker({
        //    dateFormat: 'd-M-yy',
        //    defaultDate: "+1w",
        //    changeMonth: true,
        //    changeYear: true,
        //    numberOfMonths: 1,
        //    onClose: function (selectedDate) {
        //        $("#EmployeeConferenceDateFrom").datepicker("option", "maxDate", selectedDate);
        //    }
        //});
       

        // Create new record
        $('#CreateEmployeePaperPresentRecord').on("click", function () {
          
            EmployeePaperPresent.ActionName = "Create";
            EmployeePaperPresent.AjaxCallEmployeePaperPresent();
        });

        $('#EditEmployeePaperPresentRecord').on("click", function () {
            debugger;
            EmployeePaperPresent.ActionName = "Edit";
            EmployeePaperPresent.AjaxCallEmployeePaperPresent();
        });

        $('#DeleteEmployeePaperPresentRecord').on("click", function () {

            EmployeePaperPresent.ActionName = "Delete";
            EmployeePaperPresent.AjaxCallEmployeePaperPresent();
        });
        $('#CountryName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#ContryCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        //$('#PaperTopic').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        //$('#JournalName').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        $('#JournalVolumeNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#JournalPageNumber').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersOnly(e);
        });

        //$('#EmployeeArticleReview').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        //$('#EmployeeBookReview').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        //$('#ConferenceName').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        //$('#EmployeeConferenceVenue').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        $('#EmployeeProceedingPageNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
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
             url: '/EmployeePaperPresent/List',
             data: { "EmployeeID": EmployeeID},
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
            data: {  "EmployeeID": EmployeeID,"actionMode": actionMode },
            url: '/EmployeePaperPresent/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message, 'success');
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeePaperPresent: function () {
        var EmployeePaperPresentData = null;
        if (EmployeePaperPresent.ActionName == "Create") {
            $("#FormCreateEmployeePaperPresent").validate();
            if ($("#FormCreateEmployeePaperPresent").valid()) {
                EmployeePaperPresentData = null;
                EmployeePaperPresentData = EmployeePaperPresent.GetEmployeePaperPresent();
                ajaxRequest.makeRequest("/EmployeePaperPresent/Create", "POST", EmployeePaperPresentData, EmployeePaperPresent.Success);
            }
        }
        else if (EmployeePaperPresent.ActionName == "Edit") {
            $("#FormEditEmployeePaperPresent").validate();
            if ($("#FormEditEmployeePaperPresent").valid()) {
                EmployeePaperPresentData = null;
                EmployeePaperPresentData = EmployeePaperPresent.GetEmployeePaperPresent();
                ajaxRequest.makeRequest("/EmployeePaperPresent/Edit", "POST", EmployeePaperPresentData, EmployeePaperPresent.Success);
            }
        }
        else if (EmployeePaperPresent.ActionName == "Delete") {
            EmployeePaperPresentData = null;
            //$("#FormCreateEmployeePaperPresent").validate();
            EmployeePaperPresentData = EmployeePaperPresent.GetEmployeePaperPresent();
            ajaxRequest.makeRequest("/EmployeePaperPresent/Delete", "POST", EmployeePaperPresentData, EmployeePaperPresent.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeePaperPresent: function () {
        
        var Data = {
        };
        if (EmployeePaperPresent.ActionName == "Create" || EmployeePaperPresent.ActionName == "Edit") {

            if (EmployeePaperPresent.ActionName == "Edit" && $('input[name=paperPresentID]').val() != 0) {
                var splitedID = $('#paperPresentID').val();
                Data.ID = splitedID;
            }
            else {
                Data.ID = $('#ID').val();
            }            
            Data.EmployeeID = $('input[name=EmployeeID]').val();          
            Data.PaperTopic = $('#PaperTopic').val();            
            Data.JournalName = $('#JournalName').val();
            Data.JournalVolumeNumber = $('#JournalVolumeNumber').val();               
            Data.JournalPageNumber = $('#JournalPageNumber').val();
            Data.EmployeeYear = $('#EmployeeYear').val();
            Data.PaperType = $('#PaperType').val();
            Data.GeneralLevelMasterIDForPprPresent = $('#GeneralLevelMasterIDForPprPresent').val();
            Data.EmployeeBookReview = $('#EmployeeBookReview').val();
            Data.EmployeeArticleReview = $('#EmployeeArticleReview').val();
            Data.PublishMedium = $('#PublishMedium').val();
            Data.EmployeeConferenceDateFrom = $('#EmployeeCoferenceDateFrom').val();
            Data.EmployeeConferenceDateTo = $('#EmployeeConferenceDateTo').val();
            Data.ConferenceName = $('#ConferenceName').val();
            Data.EmployeeConferenceVenue = $('#EmployeeConferenceVenue').val();
            Data.PublishDate = $('#PublishDate').val();
            Data.EmployeeProceedingPageNumber = $('#EmployeeProceedingPageNumber').val();
            Data.EmployeeConferenceProceeding = $('#EmployeeConferenceProceeding').val();  
            Data.EmployeePaperPresenterID = $('#EmployeePaperPresenterID').val();
            Data.EmployeeParticipationRole = $('#EmployeeParticipationRole').val();
            Data.SelfGroupPresenter = $('#SelfGroupPresenter').val();

            Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
            
        }
        else if (EmployeePaperPresent.ActionName == "Delete") {
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
            EmployeePaperPresent.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeePaperPresent.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {



    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        EmployeePaperPresent.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {


    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        EmployeePaperPresent.ReloadList("Record Deleted Sucessfully.");
    //      //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

