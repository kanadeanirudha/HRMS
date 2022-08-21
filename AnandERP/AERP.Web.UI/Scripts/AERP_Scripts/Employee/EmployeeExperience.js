//this class contain methods related to nationality functionality
var EmployeeExperience = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeExperience.constructor();
        //EmployeeExperience.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });


        //$('#ExperienceFromYear').datepicker({
        //    dateFormat: 'd M yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ExperienceToYear").datepicker("option", "minDate", selectedDate);

        //        if ($("#ExperienceToYear").val() != "") {
        //            var ExperienceFromYear = new Date($("#ExperienceFromYear").val());


        //            var ExperienceToYear = new Date($("#ExperienceToYear").val());

        //            var months;
        //            months = (ExperienceToYear.getFullYear() - ExperienceFromYear.getFullYear()) * 12;
        //            months -= ExperienceFromYear.getMonth() + 1;
        //            months += ExperienceToYear.getMonth();
        //            if (months != "-1") {
        //                $("#ExperienceInMonth").val(months)
        //            }
        //            else {
        //                $("#ExperienceInMonth").val("0")

        //            }
        //        }
        //        else {

        //            $("#ExperienceInMonth").val("0")
        //        }
        //    }
        //})

        $(function () {

            $('#ExperienceFromYear').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
                //defaultDate: new Date(),
            });

            $('#ExperienceToYear').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
                //defaultDate: new Date(),
            });

            $('#ExperienceFromYear').on("dp.hide", function (e) {
                debugger;
                var minDate = new Date(e.date.valueOf());
                minDate.setDate(minDate.getDate());
                $('#ExperienceToYear').data("DateTimePicker").minDate(minDate);

                if ($("#ExperienceToYear").val() != "") {
                    var ExperienceFromYear = new Date($("#ExperienceFromYear").val());


                    var ExperienceToYear = new Date($("#ExperienceToYear").val());

                    var months;
                    months = (ExperienceToYear.getFullYear() - ExperienceFromYear.getFullYear()) * 12;
                    months = parseInt(months)- parseInt(ExperienceFromYear.getMonth() + 1);
                    months = parseInt(months) + parseInt(ExperienceToYear.getMonth());
                    if (months != "-1") {
                        $("#ExperienceInMonth").val(months)
                    }
                    else {
                        $("#ExperienceInMonth").val("0")

                    }
                }
                else {

                    $("#ExperienceInMonth").val("0")
                }


            })

            $('#ExperienceToYear').on('dp.hide', function (e) {
                debugger;
                var maxDate = new Date(e.date.valueOf());
                maxDate.setDate(maxDate.getDate());
                $('#ExperienceFromYear').data("DateTimePicker").maxDate(maxDate);
                if ($("#ExperienceFromYear").val() != "") {
                    var ExperienceFromYear = new Date($("#ExperienceFromYear").val());
                    var ExperienceToYear = new Date($("#ExperienceToYear").val());

                    var months;
                   
                    months = (ExperienceToYear.getFullYear() - ExperienceFromYear.getFullYear()) * 12;
                    months = parseInt(months) - parseInt(ExperienceFromYear.getMonth() + 1);
                    months = parseInt(months) + parseInt(ExperienceToYear.getMonth() );
                    if (months != "-1") {
                        $("#ExperienceInMonth").val(months)
                    }
                    else {
                        $("#ExperienceInMonth").val("0")

                    }
                }
                else {

                    $("#ExperienceInMonth").val("0")
                }



            })

            $('#AppointmentOrderDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
                //defaultDate: new Date(),
            });

            $('#UniversityApprovalDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
                //defaultDate: new Date(),
            });
            



        });

        //$('#ExperienceToYear').datepicker({
        //    dateFormat: 'd M yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ExperienceFromYear").datepicker("option", "maxDate", selectedDate);

        //        if ($("#ExperienceFromYear").val() != "") {
        //            var ExperienceFromYear = new Date($("#ExperienceFromYear").val());
        //            var ExperienceToYear = new Date($("#ExperienceToYear").val());

        //            var months;
        //            months = (ExperienceToYear.getFullYear() - ExperienceFromYear.getFullYear()) * 12;
        //            months -= ExperienceFromYear.getMonth() + 1;
        //            months += ExperienceToYear.getMonth();
        //            if (months != "-1") {
        //                $("#ExperienceInMonth").val(months)
        //            }
        //            else {
        //                $("#ExperienceInMonth").val("0")

        //            }
        //        }
        //        else {

        //            $("#ExperienceInMonth").val("0")
        //        }
        //    }
        //})






        //$('#AppointmentOrderDate').attr("readonly", true);
        //$('#AppointmentOrderDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //});

       

        //$('#UniversityApprovalDate').attr("readonly", true);
        //$('#UniversityApprovalDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',

        //})
        // $('#FormDetailsEmployeeExperience :input').attr('readonly', 'readonly');

        // Create new record       

        $('#CreateEmployeeExperienceRecord').on("click", function () {

            EmployeeExperience.ActionName = "Create";
            EmployeeExperience.AjaxCallEmployeeExperience();
        });

        $('#CreateEmployeeExperienceRecordChange').on("click", function () {

            EmployeeExperience.ActionName = "Create";
            EmployeeExperience.AjaxCallEmployeeExperience();
        });

        $('#EditEmployeeExperienceRecord').on("click", function () {

            EmployeeExperience.ActionName = "Edit";
            EmployeeExperience.AjaxCallEmployeeExperience();
        });

        $('#EducationYear').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#NoOfAttempts').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#AggregatePercentage').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#FinalYearPercentage').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#Rank').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });


        $("#UserSearchContactDetails").keyup(function () {
            var oTable = $("#myDataTableEmployeeExperience").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtnContactDetails").click(function () {
            $("#UserSearchContactDetails").focus();
        });

        $("#showrecordContactDetails").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTableEmployeeExperience_length']").val(showRecord);
            $("select[name*='myDataTableEmployeeExperience_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();



    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/EmployeeExperience/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },


    LoadContactDetailsList: function (EmployeeID) {
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { "EmployeeID": EmployeeID },
             dataType: "html",
             url: '/EmployeeExperience/EmployeeContactList',
             success: function (data) {
                 //Rebind Grid Data
                 $('#EmployeeExperience').html(data);
             }
         });
    },

    LoadPersonalDetailsList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/EmployeeExperience/EmployeePersonalList',
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
            url: '/EmployeeExperience/EmployeeExperienceList',
            success: function (data) {
                //Rebind Grid Data
                $('#EmployeeExperience').html(data);
                //$("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(600).slideUp(2000).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeExperience: function () {

        var EmployeeExperienceData = null;
        if (EmployeeExperience.ActionName == "Create") {
            $("#FormCreateEmployeeExperience").validate();
            if ($("#FormCreateEmployeeExperience").valid()) {
                EmployeeExperienceData = null;
                EmployeeExperienceData = EmployeeExperience.GetEmployeeExperience();
                ajaxRequest.makeRequest("/EmployeeExperience/EmployeeExperienceCreate", "POST", EmployeeExperienceData, EmployeeExperience.Success);
            }
        }
        else if (EmployeeExperience.ActionName == "Edit") {
            $("#FormEditEmployeeExperience").validate();
            if ($("#FormEditEmployeeExperience").valid()) {
                EmployeeExperienceData = null;
                EmployeeExperienceData = EmployeeExperience.GetEmployeeExperience();
                ajaxRequest.makeRequest("/EmployeeExperience/EmployeeExperienceEdit", "POST", EmployeeExperienceData, EmployeeExperience.Success);
            }
        }


    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeExperience: function () {
        var Data = {
        };
        if (EmployeeExperience.ActionName == "Create" || EmployeeExperience.ActionName == "Edit") {

            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.PreviousOrganisationName = $('#PreviousOrganisationName').val();
            Data.PreviousOrganisationAddress = $('#PreviousOrganisationAddress').val();
            Data.ExperienceFromYear = $('#ExperienceFromYear').val();
            Data.ExperienceToYear = $('#ExperienceToYear').val();
            Data.ExperienceInMonth = $('#ExperienceInMonth').val();
            Data.Designation = $('#Designation').val();
            Data.GeneralExperienceTypeMasterID = $('#GeneralExperienceTypeMasterID').val();
            Data.GeneralJobStatusID = $('#GeneralJobStatusID').val();
            Data.NatureOfAppointment = $('#NatureOfAppointment').val();
            Data.LastPayDrawnPayScale = $('#LastPayDrawnPayScale').val();
            Data.AppointmentOrderDate = $('#AppointmentOrderDate').val();
            Data.AppointmentOrderNumber = $('#AppointmentOrderNumber').val();
            Data.GeneralBoardUniversityID = $('#GeneralBoardUniversityID').val();
            Data.UniversityApprovalType = $('#UniversityApprovalType').val();
            Data.UniversityApprovalDate = $('#UniversityApprovalDate').val();
            Data.UniversityApprovalNumber = $('#UniversityApprovalNumber').val();
            Data.YearOfApproval = $('#YearOfApproval').val();
            Data.MonthOfApproval = $('#MonthOfApproval').val();
            Data.SubjectForApproval = $('#SubjectForApproval').val();
            Data.Remarks = $('#Remarks').val();
            if (EmployeeExperience.ActionName == "Create") {
                Data.ID = 0;
            }
            else if (EmployeeExperience.ActionName == "Edit") {
                Data.ID = $('input[name=ExperienceID]').val();
            }

        }
        else if (EmployeeExperience.ActionName == "Delete") {
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
            EmployeeExperience.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeExperience.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};



