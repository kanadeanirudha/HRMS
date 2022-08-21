//this class contain methods related to nationality functionality
var EmployeeDependents = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeDependents.constructor();
        //EmployeeDependents.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#ActivityName').focus();
            $('#ActivityName').val('');
        });


      

        // Create new record
        $('#CreateEmployeeDependentsRecord').on("click", function () {
            EmployeeDependents.ActionName = "Create";
            EmployeeDependents.AjaxCallEmployeeDependents();
        });

        $('#EditEmployeeDependentsRecord').on("click", function () {
            EmployeeDependents.ActionName = "Edit";
            EmployeeDependents.AjaxCallEmployeeDependents();
        });

        $('#DeleteEmployeeDependentsRecord').on("click", function () {

            EmployeeDependents.ActionName = "Delete";
            EmployeeDependents.AjaxCallEmployeeDependents();
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

        $('#NameTitle').change(function () {

            if ($(this).val() == "Mr") {
                document.getElementById('Male').checked = true;
                EmployeeInformation.GenderCode = 'M';
            }
            else if ($(this).val() == "Mrs" || $(this).val() == "Ms") {
                document.getElementById('Female').checked = true;
                EmployeeInformation.GenderCode = 'F';
            }

        });


        //$('#DateOfBirth').datepicker({
        //    onSelect: function (date) {
              
        //    },
        //    selectWeek: true,
        //    inline: true,
        //    startDate: '01/01/2000',
        //    firstDay: 1
        //});

        $('#DateOfBirth').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });

       

        //$('#MedalReceivedDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //});

        $('#MedalReceivedDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });

        //$('#ScholarshipStartDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ScholarshipUptoDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})


        $('#ScholarshipStartDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });

        $('#ScholarshipUptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });

        $('#ScholarshipStartDate').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#ScholarshipUptoDate').data("DateTimePicker").minDate(minDate);
        });

        $('#ScholarshipUptoDate').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#ScholarshipStartDate').data("DateTimePicker").maxDate(maxDate);
        });
        //$('#ScholarshipUptoDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ScholarshipStartDate").datepicker("option", "maxDate", selectedDate);
        //    }
        //})

        
        

        //$('#WeddingAnniversaryDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //})

        $('#WeddingAnniversaryDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });
        



        if ($("#GotAnyMedal").val() == 'true') {
            //$('#MedalDescription').show();
            
        }
        else {
            //$('#MedalDescription').hide();
            
        }
      
        $("#GotAnyMedal").click(function () {
          
            if (this.checked)
            {
                $("#Medal").fadeIn();
                $('#MedalDescription').val("");
                $('#MedalReceivedDate').val("");
            EmployeeDependents.GotAnyMedal = true;            
        }
        else 
            {
            $("#Medal").fadeOut();
            $('#MedalDescription').val("");
            $('#MedalReceivedDate').val("");
                EmployeeDependents.GotAnyMedal = false;              
            }
        });

      
        if ($("#IsScholarshipReceived").val() == 'true') {
            //$('#ScholarshipDescription').show();
        }
        else {
            //$('#ScholarshipDescription').hide();
        }
       
        $("#IsScholarshipReceived").click(function () {
          
            if (this.checked) {
                $("#Scholarship").fadeIn();
                $('#ScholarshipDescription').val("");
                $('#ScholarshipAmount').val(0.00);
                $('#ScholarshipStartDate').val("");
                $('#ScholarshipUptoDate').val("");
                EmployeeDependents.IsScholarshipReceived = true;
              
            }
            else {
                $("#Scholarship").fadeOut();
                $('#ScholarshipDescription').val("");
                $('#ScholarshipAmount').val(0.00);
                $('#ScholarshipStartDate').val("");
                $('#ScholarshipUptoDate').val("");
                EmployeeDependents.IsScholarshipReceived = false;
            }
        });


        $('#DependentName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


        $('#EmployeeDependentDesignation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MedalDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#PhoneNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#MobileNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#ScholarshipAmount').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
       
        $('#LanguageKnown').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
           
        });





        $('#ScholarshipDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


       
        

        $('#CurriculumActivity').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        
        $('#PlaceOfBirth').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $("#CategoryID").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlCasteDetails = $("#CasteID");
            var $CasteDetailsProgress = $("#states-loading-progress");
            $CasteDetailsProgress.show();
            if ($("#CategoryID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeDependents/GetCastByCategoryID",

                    data: { "SelectedCategoryID": selectedItem },
                    success: function (data) {
                        $ddlCasteDetails.html('');
                        $ddlCasteDetails.append('<option value="">--Select Caste--</option>');
                        $.each(data, function (id, option) {

                            $ddlCasteDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        //   $ddlCasteDetails.append('<option value="0">Other</option>');
                        $CasteDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Region.');
                        $CasteDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#RegionDetailID').find('option').remove().end().append('<option value>---Select Region---</option>');
                $('#btnCreate').hide();
            }
        });


        $("#CountryID").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlRegionDetails = $("#RegionID");
            var $RegionDetailsProgress = $("#states-loading-progress");
            $RegionDetailsProgress.show();
            if ($("#CountryID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeDependents/GetGeneralRegionDetailByCountryID",

                    data: { "SelectedCountryID": selectedItem },
                    success: function (data) {
                        $ddlRegionDetails.html('');
                        $ddlRegionDetails.append('<option value="">--Select Region--</option>');
                        $.each(data, function (id, option) {

                            $ddlRegionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                     //   $ddlRegionDetails.append('<option value="Other">Other</option>');
                        $RegionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Region.');
                        $RegionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#RegionDetailID').find('option').remove().end().append('<option value>---Select Region---</option>');
            }
        });

        //For City

        $("#RegionID").change(function () {
            debugger;
            var selectedItem = $(this).val();
            
            var $ddlCityDetails = $("#CityID");
            var $CityDetailsProgress = $("#states-loading-progress");
            $CityDetailsProgress.show();
            if ($("#RegionID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeDependents/GetGeneralCityByRegionID",

                    data: { "SelectedRegionID": selectedItem },
                    success: function (data) {
                        $ddlCityDetails.html('');
                        $ddlCityDetails.append('<option value="">--Select District --</option>');
                        $.each(data, function (id, option) {

                            $ddlCityDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                      //  $ddlCityDetails.append('<option value="Other">Other</option>');
                        $CityDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        //   alert('Failed to retrieve District.');
                        $CityDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#RegionDetailID').find('option').remove().end().append('<option value>---Select Region---</option>');
            }
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
             url: '/EmployeeDependents/List',

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
            url: '/EmployeeDependents/List',
            success: function (data) {
                //Rebind Grid Data
                $("#EmployeeFamily").html(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message, 'success');
            }
        });
    },



    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeDependents: function () {
        var EmployeeDependentsData = null;
        if (EmployeeDependents.ActionName == "Create") {

            $("#FormCreateEmployeeDependents").validate();
            if ($("#FormCreateEmployeeDependents").valid()) {
                EmployeeDependentsData = null;
                EmployeeDependentsData = EmployeeDependents.GetEmployeeDependents();
                ajaxRequest.makeRequest("/EmployeeDependents/Create", "POST", EmployeeDependentsData, EmployeeDependents.Success);
            }
        }
        else if (EmployeeDependents.ActionName == "Edit") {
           
            $("#FormEditEmployeeDependents").validate();
            if ($("#FormEditEmployeeDependents").valid()) {
                EmployeeDependentsData = null;
                EmployeeDependentsData = EmployeeDependents.GetEmployeeDependents();
                ajaxRequest.makeRequest("/EmployeeDependents/Edit", "POST", EmployeeDependentsData, EmployeeDependents.Success);
            }
        }
        else if (EmployeeDependents.ActionName == "Delete") {
            EmployeeDependentsData = null;
            $("#FormDeleteEmployeeDependents").validate();
            EmployeeDependentsData = EmployeeDependents.GetEmployeeDependents();
            ajaxRequest.makeRequest("/EmployeeDependents/Delete", "POST", EmployeeDependentsData, EmployeeDependents.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeDependents: function () {
        var Data = {
        };
        if (EmployeeDependents.ActionName == "Create" || EmployeeDependents.ActionName == "Edit") {
           
            Data.ID = $('#ID').val();
            Data.EmployeeID = $("#EmployeeID").val()
            Data.SequenceNumber = $('#SequenceNumber').val();
           
            Data.NameTitle = $('#NameTitle').val();
           
            if ($("#NameTitle").val() == "Mr") {
                Data.GenderCode = 'M';
            }
            else {
                Data.GenderCode = 'F';
            }
            Data.DependentName = $('#DependentName').val();
            //Data.CityID = $('#CityID').val();
           // Data.CountryID = $('#CountryID').val();
            //Data.RegionID = $('#RegionID').val();
            Data.PhoneNumber = $('#PhoneNumber').val();
            Data.MobileNumber = $('#MobileNumber').val();
            Data.EmployeeDependentQualification = $('#EmployeeDependentQualification').val();
            Data.EmployeeDependentDesignation = $('#EmployeeDependentDesignation').val();
            Data.GotAnyMedal = $('#GotAnyMedal:checked').val() ? true : false;
            Data.MedalReceivedDate = $('#MedalReceivedDate').val();
            Data.MedalDescription = $('#MedalDescription').val();

            Data.IsScholarshipReceived = $('#IsScholarshipReceived:checked').val() ? true : false;
            Data.IsNominee = $('#IsNominee:checked').val() ? true : false;
          

            Data.Address1 = $('#Address1').val();
            Data.Address2 = $('#Address2').val();
            Data.AdharCardNumber = $('#AdharCardNumber').val();
            Data.ScholarshipStartDate = $('#ScholarshipStartDate').val();
            Data.ScholarshipUptoDate = $('#ScholarshipUptoDate').val();
            Data.ScholarshipDescription = $('#ScholarshipDescription').val();
            Data.ScholarshipAmount = $('#ScholarshipAmount').val();
            
            Data.Hobbies = $('#Hobbies').val();
            Data.CurriculumActivity = $('#CurriculumActivity').val();
            Data.DateOfBirth = $('#DateOfBirth').val();
            Data.PlaceOfBirth = $('#PlaceOfBirth').val();
            Data.GeneralRelationshipTypeMasterID = $('#GeneralRelationshipTypeMasterID').val();
            Data.MotherTongueID = $('#MotherTongueID').val();
            Data.LanguageKnown = $('#LanguageKnown').val();
          //  Data.NationalityID = $('#NationalityID').val();
            Data.ReligionID = $('#ReligionID').val();
            Data.CasteID = $('#CasteID').val();
           // Data.CategoryID = $('#CategoryID').val();
            Data.WeddingAnniversaryDate = $('#WeddingAnniversaryDate').val();
        }
        else if (EmployeeDependents.ActionName == "Delete") {
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
            EmployeeDependents.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeDependents.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

