//this class contain methods related to nationality functionality
var EmployeeQualification = {
    //Member variables
    ActionName: null,
    EducationID: 0,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeQualification.constructor();
        //EmployeeQualification.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        // Create new record       

        $('#CreateEmployeeQualificationRecord').on("click", function () {

            EmployeeQualification.ActionName = "Create";
            EmployeeQualification.AjaxCallEmployeeQualification();
        });

        $('#EditEmployeeQualificationRecord').on("click", function () {

            EmployeeQualification.ActionName = "Edit";
            EmployeeQualification.AjaxCallEmployeeQualification();
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
            var oTable = $("#myDataTableEmployeeQualification").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtnContactDetails").click(function () {
            $("#UserSearchContactDetails").focus();
        });

        $("#showrecordContactDetails").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTableEmployeeQualification_length']").val(showRecord);
            $("select[name*='myDataTableEmployeeQualification_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $("#EducationTypeID").change(function () {

            //  $('#CityID').find('option').remove().end().append('<option value>-------------Select City-----------------</option>');
            //  $("#CityID").prop("disabled", true);
            var selectedItem = $(this).val();
            if (selectedItem != "") {
                var $ddlEducation = $("#SelectedEducationID");
                var $EducationProgress = $("#states-loading-progress");
                $EducationProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeQualification/GetEducationNameByEducationTypeID",
                    data: { "SelectedEducationTypeID": selectedItem },
                    success: function (data) {
                        $ddlEducation.html('');
                        $('#SelectedEducationID').append('<option value>----------Select Education----------</option>');
                        $.each(data, function (id, option) {

                            $ddlEducation.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $EducationProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Education.');
                        $EducationProgress.hide();
                    }
                });
            }
            else {
                $('SelectedEducationID').find('option').remove().end().append('<option value>----------Select Education----------</option>');

            }
        });


        //-----------------------METHOD USED FOR ACCESSING COURSE PERIOD ACCODING TO EDUCATION----------------------//
        $("#SelectedEducationID").change(function () {

            var selectedItem = $(this).val();

            if (selectedItem != "") {
                var Period = selectedItem.split('~');
                $("#EducationYear").val(Period[1]);
                $("#Unit").val(Period[2]);
                EmployeeQualification.EducationID = Period[0];


            }
        });

        $("#FromYear").change(function () {

            //  $('#CityID').find('option').remove().end().append('<option value>-------------Select City-----------------</option>');
            //  $("#CityID").prop("disabled", true);
            var selectedItem = $(this).val();
            if (selectedItem != "") {
                var $ddlUptoYear = $("#UptoYear");
                var $ddlYearOfPassing = $("#YearOfPassing");
                var $UptoYearProgress = $("#states-loading-progress");
                $UptoYearProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeQualification/GetUptoYearList",
                    data: { "SelectedFromYear": selectedItem },
                    success: function (data) {

                        $ddlUptoYear.html('');
                        $ddlYearOfPassing.html('');
                        //$('#UptoYear').append('<option value>----------Select Upto Year----------</option>');
                        $.each(data, function (id, option) {

                            $ddlUptoYear.append($('<option></option>').val(option.id).html(option.name));
                            $ddlYearOfPassing.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $UptoYearProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Education.');
                        $UptoYearProgress.hide();
                    }
                });
            }
            else {
                $('SelectedEducationID').find('option').remove().end().append('<option value>----------Select Education----------</option>');

            }
        });

    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/EmployeeQualification/List',
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
             url: '/EmployeeQualification/EmployeeContactList',
             success: function (data) {
                 //Rebind Grid Data
                 $('#EmployeeQualification').html(data);
             }
         });
    },

    LoadPersonalDetailsList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/EmployeeQualification/EmployeePersonalList',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var ID = $('input[name=EmployeeID]').val();

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "EmployeeID": ID },
            url: '/EmployeeQualification/EmployeeQualificationList',
            success: function (data) {
                
                //Rebind Grid Data
                //$("#ListViewModel").empty().append(data);
                $('#EmployeeQualification').html(data);

                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeQualification: function () {

        var EmployeeQualificationData = null;
        if (EmployeeQualification.ActionName == "Create") {
            $("#FormCreateEmployeeQualification").validate();
            if ($("#FormCreateEmployeeQualification").valid()) {
                EmployeeQualificationData = null;
                EmployeeQualificationData = EmployeeQualification.GetEmployeeQualification();
                ajaxRequest.makeRequest("/EmployeeQualification/EmployeeQualificationCreate", "POST", EmployeeQualificationData, EmployeeQualification.Success);
            }
        }
        else if (EmployeeQualification.ActionName == "Edit") {
            $("#FormEditEmployeeQualification").validate();
            if ($("#FormEditEmployeeQualification").valid()) {
                EmployeeQualificationData = null;
                EmployeeQualificationData = EmployeeQualification.GetEmployeeQualification();
                ajaxRequest.makeRequest("/EmployeeQualification/EmployeeQualificationEdit", "POST", EmployeeQualificationData, EmployeeQualification.Success);
            }
        }


    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeQualification: function () {
        var Data = {
        };
        if (EmployeeQualification.ActionName == "Create" || EmployeeQualification.ActionName == "Edit") {

            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.EducationTypeID = $('#EducationTypeID').val();
            if (EmployeeQualification.EducationID == 0) {
                Data.EducationID = $('input[name=EducationID]').val();
            }
            else {
                Data.EducationID = EmployeeQualification.EducationID;
            }
            Data.EducationYear = $('#EducationYear').val();
            Data.Unit = $('#Unit').val();
            Data.SpecailisationIn = $('#SpecailisationIn').val();
            Data.FromYear = $('#FromYear').val();
            Data.UptoYear = $('#UptoYear').val();
            Data.YearOfPassing = $('#YearOfPassing').val();
            Data.NameOfInstitution = $('#NameOfInstitution').val();
            Data.BoardUniversityID = $('#BoardUniversityID').val();
            Data.PassingDivision = $('#PassingDivision').val();
            Data.NoOfAttempts = $('#NoOfAttempts').val();
            Data.AggregatePercentage = $('#AggregatePercentage').val();
            Data.FinalYearPercentage = $('#FinalYearPercentage').val();
            Data.Rank = $('#Rank').val();
            Data.Remark = $('#Remark').val();
            Data.ID = $('input[name=QualificationID]').val();

        }
        else if (EmployeeQualification.ActionName == "Delete") {
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
            EmployeeQualification.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeQualification.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};


