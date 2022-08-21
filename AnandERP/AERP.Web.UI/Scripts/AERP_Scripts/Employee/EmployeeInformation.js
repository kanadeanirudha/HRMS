//this class contain methods related to nationality functionality
var EmployeeInformation = {
    //Member variables
    ActionName: null,
    GenderCode: null,
    IsNameChangedBefore_Yes: null,
    SelectedXmlDataForLanguageDetails: null,
    ReasonOfLeaving: null,
    DateOfLeaving: null,
    map: {},
    map2: {},
    //a : 0,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeInformation.constructor();
        //EmployeeInformation.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        // $('#ExperienceTypeDescription').focus();
        $("#Createbutton").hide();
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });
       


        $('#FormEditEmployeeServiceDetailsInfo :input').attr('readonly', 'readonly');


         $('#Birthdate').attr("readonly", true);
        //$('#Birthdate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1915:document.write(currentYear.getFullYear()',
        //    maxDate: '-6574',
        //})

        $('#Birthdate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });




        //$('#JoiningDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //    maxDate: "0D",
        //    onClose: function (selectedDate) {
        //        $("#AppointmentApprovalDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        //$('#JoiningDate').datetimepicker({
        //    format: 'DD MMMM YYYY',
        //    ignoreReadonly: true,
        //    //maxDate: moment(),
        //});

        //$("#JoiningDate").on("dp.hide", function (e) {

        //    var minDate = new Date(e.date.valueOf());
        //    $('#AppointmentApprovalDate').data("DateTimePicker").minDate(minDate);
        //});


        //$('#AppointmentApprovalDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //})

        //$('#AppointmentApprovalDate').datetimepicker({
        //    format: 'DD MMMM YYYY',
        //    ignoreReadonly: true,
        //    //maxDate: moment(),
        //});

        //$('#DateOfLeaving').attr("readonly", true);
        //$('#DateOfLeaving').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //})

        //$('#DateOfLeaving').datetimepicker({
        //    format: 'DD MMMM YYYY',
        //    ignoreReadonly: true,
        //    //maxDate: moment(),
        //});

        //$('#DateOfRetirment').attr("readonly", true);
        //$('#DateOfRetirment').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:2050'

        //})

        $('#DateOfRetirment').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#TerminationDate').attr("readonly", true);
        //$('#TerminationDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //})

        $('#TerminationDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#ProvidentFundApplicableDate').attr("readonly", true);
        //$('#ProvidentFundApplicableDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //})

        $('#TerminationDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#DrivingLicenceExpireDate').attr("readonly", true);
        //$('#DrivingLicenceExpireDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: "1950:20Y+1M +10D"

        //})

        $('#DrivingLicenceExpireDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        // Create new record
        $('#AddEmployeeRecord').on("click", function () {

            EmployeeInformation.ActionName = "AddEmployee";
            EmployeeInformation.AjaxCallEmployeeInformation();
        });

        $('#CreateEmployeeInformationRecord').on("click", function () {
            EmployeeInformation.ActionName = "Create";
            EmployeeInformation.AjaxCallEmployeeInformation();
        });

        $('#UpdatePersonalInformationHome').on("click", function () {
            //alert();
            //debugger;
            EmployeeInformation.ActionName = "EditPersonalInformation";
            EmployeeInformation.AjaxCallEmployeeInformation();
        });

        $('#UpdateEmployeeOfficeDetails').on("click", function () {
            //debugger;
            EmployeeInformation.ActionName = "EditEmployeeOfficeDetails";
            EmployeeInformation.AjaxCallEmployeeInformation();
        });

        $('#btnUpdateEmployeeLanguageDetails').on("click", function () {

            EmployeeInformation.ActionName = "EditEmployeeLanguageDetails";
            EmployeeInformation.getDataFromDataTableForLanguage();
            EmployeeInformation.AjaxCallEmployeeInformation();
        });

        $('#EditEmployeeInformationRecord').on("click", function () {

            EmployeeInformation.ActionName = "Edit";
            EmployeeInformation.AjaxCallEmployeeInformation();
        });

        $('#DeleteEmployeeInformationRecord').on("click", function () {

            EmployeeInformation.ActionName = "Delete";
            EmployeeInformation.AjaxCallEmployeeInformation();
        });
        $('#CreateChangePasswordRecord').on("click", function () {
            EmployeeInformation.ActionName = "ChangePassword";
            if ($('#CurrentPassword').val() == "" || ($('#CurrentPassword').val() == null))
            {
                $('#SuccessMessagediv').html("Please Enter Current Password.");
                //$('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
                //$('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                $('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).addClass('alert-' + 'warning');
                //$("#displayErrorMessage p").text('Please Enter Current Password.').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
                return false;
            }
            else if ($('#NewPassword').val() == "" || ($('#NewPassword').val() == null)) {
                $('#SuccessMessagediv').html("Please Enter New Password");
                //$('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
                $('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).addClass('alert-' + 'warning');
                return false;
            }
            else if (($('#NewPassword').val() != "") && (($("#NewPassword").val().length) < 6)) {
                $('#SuccessMessagediv').html("Please enter at least 6 characters.");
                //$('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
                $('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).addClass('alert-' + 'warning');
                return false;
            }

            else if ($('#ConfirmPassword').val() == "" || ($('#ConfirmPassword').val() == null)) {
                $('#SuccessMessagediv').html("please Enter Confirm Password");
                //$('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
                $('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).addClass('alert-' + 'warning');
                return false;
            }
           

            else if (($('#CurrentPassword').val()) != ($('input[name=Password]').val()))
            {
                $('#SuccessMessagediv').html("Current Password does not match with Password");
                //$('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
                $('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).addClass('alert-' + 'warning');
                return false;
            } 
           
            else if (($('#NewPassword').val()) != ($('#ConfirmPassword').val())) {
                $('#SuccessMessagediv').html("New Password does not match with Confirm Password");
                //$('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
                $('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).addClass('alert-' + 'warning');
                return false;
            }
            
            else
            {
                EmployeeInformation.AjaxCallEmployeeInformation();
            }
            
        });

        $('#CountryName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $("#UserSearchLanguageDetails").keyup(function () {
            var oTable = $("#myDataTableEmpLanguageDetails").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtnLanguageDetails").click(function () {
            $("#UserSearchLanguageDetails").focus();
        });

        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        $("#showrecordLanguageDetails").change(function () {
            var showRecord = $("#showrecordLanguageDetails").val();
            $("select[name*='myDataTableEmpLanguageDetails_length']").val(showRecord);
            $("select[name*='myDataTableEmpLanguageDetails_length']").change();
        });

        $("#UserSearchServiceDetails").keyup(function () {
            var oTable = $("#myDataTableEmpLanguageDetails").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtnServiceDetails").click(function () {
            $("#UserSearchLanguageDetails").focus();
        });

        $("#showrecordServiceDetails").change(function () {
            var showRecord = $("#showrecordServiceDetails").val();
            $("select[name*='myDataTableEmployeeServiceDetails_length']").val(showRecord);
            $("select[name*='myDataTableEmployeeServiceDetails_length']").change();
        });

        //FOLLOWING FUNCTION IS USED TO SHOW SEARCHLIST OF EMPLOYEE NAMES  
        //////////////////////////////////////////////////
        //temprory commented and code is written on profile sidebarv2 view page
        //var a = 0;
        //$("#BtnEmpSearchList").click(function () {

        //    alert('here');
        //    if (a == 0) {
                
        //        $('#EmployeeSearchList').show();
        //        $('#EmployeeFirstName').focus();

        //        a = 1;
        //    }
        //    else {
        //        $('#EmployeeSearchList').hide();

        //        a = 0;
        //    }
        //});
        /////////////////////////////////////////////////

        // $('#OrderDate').attr("readonly", true);
        //$('#OrderDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //    maxDate: "0D",
        //})

        $('#OrderDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        //  $('#PromotionDemotionDate').attr("readonly", true);
        //$('#PromotionDemotionDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //    maxDate: "0D",
        //})
        $('#PromotionDemotionDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        //$('#PreviousPromotionDemotionDate').attr("readonly", true);
        //$('#PreviousPromotionDemotionDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //    maxDate: "0D",
        //})

        $('#PreviousPromotionDemotionDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        //  $('#GrantedPromotionDate').attr("readonly", true);
        //$('#GrantedPromotionDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //    maxDate: "0D",
        //})

        $('#GrantedPromotionDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        //$('#CollegeApprovalDate').attr("readonly", true);
        //$('#CollegeApprovalDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    maxDate: "0D",
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //})

        $('#CollegeApprovalDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        // $('#ChargeTakingDate').attr("readonly", true);
        //$('#ChargeTakingDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //    maxDate: "0D",
        //})

        $('#ChargeTakingDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        // $('#UniversityApprovalDate').attr("readonly", true);
        //$('#UniversityApprovalDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //    maxDate: "0D",
        //})

        $('#UniversityApprovalDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#btnUpdateEmployeeServiceDetailsCreate').on("click", function () {
            debugger;
            EmployeeInformation.ActionName = "CreateEmployeeServiceDetails";
            EmployeeInformation.AjaxCallEmployeeInformation();
        });

        $('#btnUpdateEmployeeServiceDetailsEdit').on("click", function () {
            EmployeeInformation.ActionName = "EditEmployeeServiceDetails";
            EmployeeInformation.AjaxCallEmployeeInformation();
        });

        //$("#JoiningDate_Clear").click(function () {
        //    $('#JoiningDate').val("");
        //});

        //$("#TerminationDate_Clear").click(function () {
        //    $('#TerminationDate').val("");
        //});

        //$("#AppointmentApprovalDate_Clear").click(function () {
        //    $('#AppointmentApprovalDate').val("");
        //});

        //$("#ProvidentFundApplicableDate_Clear").click(function () {
        //    $('#ProvidentFundApplicableDate').val("");
        //});

        //$("#DrivingLicenceExpireDate_Clear").click(function () {
        //    $('#DrivingLicenceExpireDate').val("");
        //});

        //$("#DateOfLeaving_Clear").click(function () {
        //    $('#DateOfLeaving').val("");
        //});

        //$("#DateOfRetirment_Clear").click(function () {
        //    $('#DateOfRetirment').val("");
        //});

        //$("#OrderDate_Clear").click(function () {
        //    $('#OrderDate').val("");
        //});

        //$("#UniversityApprovalDate_Clear").click(function () {
        //    $('#UniversityApprovalDate').val("");
        //});

        //$("#CollegeApprovalDate_Clear").click(function () {
        //    $('#CollegeApprovalDate').val("");
        //});

        //$("#ChargeTakingDate_Clear").click(function () {
        //    $('#ChargeTakingDate').val("");
        //});

        //$("#PreviousPromotionDemotionDate_Clear").click(function () {
        //    $('#PreviousPromotionDemotionDate').val("");
        //});

        //$("#PromotionDemotionDate_Clear").click(function () {
        //    $('#PromotionDemotionDate').val("");
        //});

        //$("#GrantedPromotionDate_Clear").click(function () {
        //    $('#GrantedPromotionDate').val("");
        //});

        $('#AddEmp_EmployeeFirstName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        //$('#EmployeeFirstName').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});

        $('#EmployeeMiddleName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        //$('#EmployeeLastName').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});

        $('#EmpFirstName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MaidenFirstName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MaidenMiddleName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MaidenLastName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#PriorFirstName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#PriorMiddleName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#PriorLastName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $("#EmployeeFirstName").click(function () {
            $(this).val("");
        });

        $('#SalaryGradeCode').on("keydown", function (e) {
            AERPValidation.AllowAlphaNumericOnly(e);
        })

        $('#PayScaleMstID').on("keydown", function (e) {
           
            AERPValidation.NotAllowSpaces(e);
        })

        $('#BasicSalary').on("keydown", function (e) {
           
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        })

        $('#ProvidentFundNumber').on("keydown", function (e) {

            AERPValidation.NotAllowSpaces(e);
        })

        $('#ESINumber').on("keydown", function (e) {

            AERPValidation.AllowNumbersOnly(e);
            //  AERPValidation.NotAllowSpaces(e);
        })

        $('#PanNumber').on("keydown", function (e) {
            AERPValidation.AllowAlphaNumericOnly(e);
            AERPValidation.NotAllowSpaces(e);
            // $(this).val($(this).val().toUpperCase());
        })

        $('#BankACNumber').on("keydown", function (e) {
            AERPValidation.AllowAlphaNumericOnly(e);
            AERPValidation.NotAllowSpaces(e);
            // $(this).val($(this).val().toUpperCase());
        })

        $('#AdharCardNumber').on("keydown", function (e) {
            AERPValidation.AllowAlphaNumericOnly(e);
            AERPValidation.NotAllowSpaces(e);
        })

        $('#SSNNumber').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        })

        $('#SINNumber').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        })

        $('#DrivingLicenceNumber').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
        })

     
        //FOLLOWING FUNCTION IS SEARCHLIST OF EMPLOYEE NAMES      

        //$("#EmployeeFirstName").autocomplete({
        //    source: function (request, response) {

        //        $.ajax({
        //            url: "/EmployeeInformation/GetEmployees",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term },
        //            success: function (data) {

        //                response($.map(data, function (item) {
        //                    return { label: item.name, value: item.name, id: item.id };
        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {

        //        $(this).val(ui.item.label);                                             // display the selected text
        //        $("#EmployeeID").val(ui.item.id);                                       // save selected id to hidden input
        //        window.location.assign("/EmployeeInformation/PersonalInformationHome/" + ui.item.id);
        //    }
        //});

        /////////////new search functionality///////////////////////////////////
       
        //end new search functionality

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#EmployeeNameTitle').change(function () {

            if ($(this).val() == "Mr") {
                document.getElementById('Male').checked = true;
                EmployeeInformation.GenderCode = 'M';
                $("#divMaidenName").fadeOut();
            }
            else if ($(this).val() == "Mrs" || $(this).val() == "Ms") {
                document.getElementById('Female').checked = true;
                EmployeeInformation.GenderCode = 'F';
                if ($(this).val() == "Mrs") {
                    $("#divMaidenName").fadeIn();
                }
                if ($(this).val() == "Ms") {
                    $("#divMaidenName").fadeOut();
                }
            }
        });

        $('input[name=GenderCode]').change(function () {

            if ($(this).attr('id') == 'Male') {              
                //document.getElementById('Male').checked = true;
                EmployeeInformation.GenderCode = 'M';
                $("#divMaidenName").fadeOut();
                $('#EmployeeNameTitle').val('Mr');
            }
            else {
                document.getElementById('Female').checked = true;
                EmployeeInformation.GenderCode = 'F';
                $("#divMaidenName").fadeIn();
                $('#EmployeeNameTitle').val('Mrs');
            }
        });
       

        if ($("#IsNameChangedBefore_Yes").val() == 'true') {
            $('#PriorNameBeforeChanged').show();
        }
        else {
            $('#PriorNameBeforeChanged').hide();
        }
        $("#IsNameChangedBefore_Yes").click(function () {

            $("#PriorNameBeforeChanged").fadeIn();
            EmployeeInformation.IsNameChangedBefore_Yes = true;
        });

        $("#IsNameChangedBefore_No").click(function () {

            $('#PriorNameBeforeChanged').hide();
            $('#PriorFirstName').val("");
            $('#PriorMiddleName').val("");
            $('#PriorLastName').val("");
            EmployeeInformation.IsNameChangedBefore_Yes = false;

        });

        $("#CentreList").change(function () {          
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            
        });


        $("#ShowList").click(function () {
            debugger;
            var SelectedCentreCode = $('#CentreList').val();
            var SelectedCentreName = $('#CentreList :selected').text();
            var splitData = SelectedCentreCode.split(':');
           
            if (SelectedCentreCode != "") {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

                 dataType: "html",
                 url: '/EmployeeInformation/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                     $("#UploadFile").show(true);
                     $("#UploadFilelink").attr("href", "EmployeeInformationExcelUpload/DownloadExcel?CentreCode=" + splitData[0] + "&DepartmentID = 0")
                     $("#DownloadEmployeeMasterExcelLink").attr("href", "EmployeeInformationExcelUpload/DownloadEmployeeExcel?CentreCode=" + splitData[0])
                     
                     $("#UploadEmployeeFilelink").attr("href", "EmployeeInformation/UploadEmployeeExcel?CentreCode=" + splitData[0])
                    // $('#Createbutton').show();
                 }
             });
            }
            else {
                EmployeeInformation.ReloadList("Please select centre", "warning", null);
             //   $('#Createbutton').hide();
            }
        });

        $("#CentreCode").change(function () {
           
            var selectedItem = $(this).val();
            var $ddlDepartments = $("#CentrewiseDeptID");
            var $departmentProgress = $("#states-loading-progress");
            $departmentProgress.show();
            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeInformation/GetCentrewiseDepartmentByCentreCode",
                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlDepartments.html('');
                        $ddlDepartments.append('<option value="">--Select Department--</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $departmentProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                        $departmentProgress.hide();
                    }
                });
                $('#btnCreate').hide();
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>---Select Department---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#CentreCodeOfficeDetails").change(function () {

            var selectedItem = $(this).val();
            var $ddlDepartments = $("#DepartmentID");
            var $departmentProgress = $("#states-loading-progress");
            $departmentProgress.show();
            if ($("#CentreCodeForServiceDetails").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeInformation/GetDepartmentByCentreCode",
                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlDepartments.html('');
                        $ddlDepartments.append('<option value="">--Select Department-</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $departmentProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                        $departmentProgress.hide();
                    }
                });
                // $('#btnCreate').hide();
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>---Select Department---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#CentreCodeForServiceDetails").change(function () {

            var selectedItem = $(this).val();
            var $ddlDepartments = $("#DepartmentIDForServiceDetails");
            var $departmentProgress = $("#states-loading-progress");
            $departmentProgress.show();
            if ($("#CentreCodeForServiceDetails").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeeInformation/GetDepartmentByCentreCode",
                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlDepartments.html('');
                        $ddlDepartments.append('<option value="">--Select Department-</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $departmentProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                        $departmentProgress.hide();
                    }
                });
                // $('#btnCreate').hide();
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>---Select Department---</option>');
                $('#btnCreate').hide();
            }
        });

        if ($("#IsLeave").val() == 'true') {
            $('#MedalDescription').show();
        }
        else {
            $('#MedalDescription').hide();

        }

        $("#IsLeave").click(function () {

            if (this.checked) {
                $("#divLeavingReasonDate").fadeIn();
                $('#ReasonOfLeaving').val("");
                $('#DateOfLeaving').val("");
                EmployeeInformation.ReasonOfLeaving = $('#ReasonOfLeaving').val();
                EmployeeInformation.DateOfLeaving = $('#DateOfLeaving').val();
            }
            else {
                $("#divLeavingReasonDate").fadeOut();
                $('#ReasonOfLeaving').val("");
                $('#DateOfLeaving').val("");
                EmployeeInformation.ReasonOfLeaving = "";
                EmployeeInformation.DateOfLeaving = "";
            }
        });

    },


    //XML data for Employee language
    getDataFromDataTableForLanguage: function () {

        var DataArray = [];
        var table = $('#myDataTableEmpLanguageDetails').DataTable();
        var data = table.$('input,select,input tag').each(function () {
            DataArray.push($(this).val());
        });

        var CheckArray = []; var UnCheckArray = [];
        $('#myDataTableEmpLanguageDetails input[type=checkbox]').each(function () {
            if (this.checked == true) {
                CheckArray.push($(this).val());
            }
            else if (this.checked == false) {
                // UnCheckArray.push("0");
                UnCheckArray.push($(this).val());
            }
        });



        var xmlParamList = "<rows>";
        var read = [];
        var bb = [];
        var write = [];
        var speak = [];
        var a = 0;
        var x = 0;
        var y = 0;
        var Count = DataArray.length;
        var CheckArrayCount = CheckArray.length;

        for (var i = 0; i < Count; i++) {
            if (CheckArrayCount > y) {
                bb = CheckArray[y].split('~');
            }
            if (DataArray[x + 1] != null) {
                read = DataArray[x + 1].split('~');
                write = DataArray[x + 2].split('~');
                speak = DataArray[x + 3].split('~');
            }
            // String for Insert 
            if (bb[5] == 0 && DataArray[x] != "") {
                if (bb[0] == read[1]) {
                    xmlParamList = xmlParamList + "<row><ID>" + bb[4] + "</ID><LanguageID>" + bb[0] + "</LanguageID><CanRead>" + read[0] + "</CanRead><CanWrite>" + write[0] + "</CanWrite><CanSpeak>" + speak[0] + "</CanSpeak></row>";
                    a = 1;
                    bb = "";
                }
            }
            // String for Update
            if (bb[5] == 1 && bb[2] != DataArray[x] || bb[4] > 0 && bb[3] != DataArray[x + 1]) {
                xmlParamList = xmlParamList + "<row><ID>" + bb[4] + "</ID><LanguageID>" + bb[0] + "</LanguageID><CanRead>" + read[0] + "</CanRead><CanWrite>" + write[0] + "</CanWrite><CanSpeak>" + speak[0] + "</CanSpeak></row>"
                a = 1;
                bb = "";
            }
            x = x + 4;
            y = y + a;
        }

        xmlParamList = xmlParamList + "</rows>";

        EmployeeInformation.SelectedXmlDataForLanguageDetails = xmlParamList;

    },

    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: 'EmployeeInformation/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
       
      //  alert("ReloadList");
        var ID = $('input[name=ID]').val();
        var CentreCode = $('#CentreCode').val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            data: { "actionMode": actionMode, "centerCode": CentreCode },
            url: '/EmployeeInformation/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification

                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },



    //ReloadList method is used to load List page
    ReloadListOffice: function (message, colorCode, actionMode) {

        var ID = $('input[name=ID]').val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            data: { "ID": ID },
            url: '#',
            success: function (data) {

                //Rebind Grid Data
                // $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },

    //ReloadList method is used to load List page
    ReloadListPersonalInformationHome: function (message, colorCode, actionMode) {
       
        var ID = $('input[name=ID]').val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            data: { "ID": ID },
            url: '#',
            success: function (data) {

                //Rebind Grid Data
                // $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //ReloadList method is used to load List page for service
    ReloadListService: function (message, colorCode, actionMode) {

        var ID = $('input[name=ID]').val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            data: { "EmployeeID": ID },
            url: '/EmployeeInformation/EmployeeServiceDetails',
            success: function (data) {
                $('#EmployeeServiceDetails').html(data);
                //Rebind Grid Data
                // $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeInformation: function () {

        var EmployeeInformationData = null;
        if (EmployeeInformation.ActionName == "Create") {
            $("#FormCreateEmployeeInformation").validate();
            if ($("#FormCreateEmployeeInformation").valid()) {
                EmployeeInformationData = null;
                EmployeeInformationData = EmployeeInformation.GetEmployeeInformation();
                ajaxRequest.makeRequest("Employee/EmployeeInformation/Create", "POST", EmployeeInformationData, EmployeeInformation.Success);
            }
        }

        else if (EmployeeInformation.ActionName == "EditPersonalInformation") {
           
            $("#FormEditPersonalInformationHome").validate();
            if ($("#FormEditPersonalInformationHome").valid()) {
                EmployeeInformationData = null;
                EmployeePersonalInformationData = EmployeeInformation.GetEmployeePersonalInformation();

                ajaxRequest.makeRequest("/EmployeeInformation/PersonalInformationHome", "POST", EmployeePersonalInformationData, EmployeeInformation.SuccessPersonalInformationHome);
            }
        }
        else if (EmployeeInformation.ActionName == "EditEmployeeOfficeDetails") {
            $("#FormEditEmployeeOfficeDetails").validate();
            if ($("#FormEditEmployeeOfficeDetails").valid()) {
                EmployeeInformationData = null;
                EmployeePersonalInformationData = EmployeeInformation.GetEmployeeOfficeDetails();
                ajaxRequest.makeRequest("/EmployeeInformation/UpdateEmployeeOfficeDetails", "POST", EmployeePersonalInformationData, EmployeeInformation.SuccessOffice);
            }
        }
        else if (EmployeeInformation.ActionName == "EditEmployeeLanguageDetails") {
            $("#FormEditEmployeeLanguageDetails").validate();

            EmployeeInformationData = null;
            EmployeeLanguageDetailsData = EmployeeInformation.GetEmployeeLanguageDetails();
            ajaxRequest.makeRequest("/EmployeeInformation/EmpEmployeeLanguageDetails", "POST", EmployeeLanguageDetailsData, EmployeeInformation.Success);
        }
        else if (EmployeeInformation.ActionName == "CreateEmployeeServiceDetails") {
            $("#FormEditEmployeeServiceDetailsCreate").validate();
            if ($("#FormEditEmployeeServiceDetailsCreate").valid()) {
                EmployeeInformationData = null;
                EmployeeServiceDetailsData = EmployeeInformation.GetEmployeeServiceDetails();
                ajaxRequest.makeRequest("/EmployeeInformation/EmployeeServiceDetailsCreate", "POST", EmployeeServiceDetailsData, EmployeeInformation.SuccessService);
            }
        }
        else if (EmployeeInformation.ActionName == "EditEmployeeServiceDetails") {
            $("#FormEditEmployeeServiceDetailsEdit").validate();
            if ($("#FormEditEmployeeServiceDetailsEdit").valid()) {
                EmployeeInformationData = null;
                EmployeeServiceDetailsData = EmployeeInformation.GetEmployeeServiceDetails();
                ajaxRequest.makeRequest("/EmployeeInformation/EmployeeServiceDetailsEdit", "POST", EmployeeServiceDetailsData, EmployeeInformation.SuccessService);
            }
        }
        else if (EmployeeInformation.ActionName == "AddEmployee") {
            $("#FormAddEmployee").validate();
            if ($("#FormAddEmployee").valid()) {

                EmployeeInformationData = null;
                EmployeeServiceDetailsData = EmployeeInformation.GetAddEmployeeDetails();
                ajaxRequest.makeRequest("/EmployeeInformation/AddEmployee", "POST", EmployeeServiceDetailsData, EmployeeInformation.Success);
            }
        }
        else if (EmployeeInformation.ActionName == "ChangePassword") {
         
            //$("#FormChangePassword").validate();
            //if ($("#FormChangePassword").valid()) {
                EmployeeInformationData = null;
                EmployeeInformationData = EmployeeInformation.GetChangeemployeePassword();
                ajaxRequest.makeRequest("/EmployeeInformation/_ChangePassword", "POST", EmployeeInformationData, EmployeeInformation.Success);
            }
      //  }
    },
    //Get properties data from the Create, Update and Delete page
    GetChangeemployeePassword: function () {
        //debugger;
        var Data = {
        };

        if (EmployeeInformation.ActionName == "ChangePassword") {
            Data.ID = $('#ID').val();
            Data.NewPassword = $('#NewPassword').val();
           
        }
       
        return Data;
    },

    GetEmployeeInformation: function () {
        var Data = {
        };

        if (EmployeeInformation.ActionName == "Create" || EmployeeInformation.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.ExperienceTypeDescription = $('#ExperienceTypeDescription').val();
            Data.IsActive = $('#IsActive:checked').val() ? true : false;
        }
        else if (EmployeeInformation.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    GetAddEmployeeDetails: function () {
        var Data = {
        };
       
        if (EmployeeInformation.ActionName == "AddEmployee") {
          
            Data.NameTitle = $("#EmployeeNameTitle").val();
            if ($("#EmployeeNameTitle").val() == "Mr") {
                Data.GenderCode = 'M';
            }
            else {
                Data.GenderCode = 'F';
            }
            Data.EmployeeFirstName = $("#AddEmp_EmployeeFirstName").val();
            Data.EmployeeMiddleName = $("#EmployeeMiddleName").val();
            Data.EmployeeLastName = $("#EmployeeLastName").val();
            Data.EmailID = $("#EmailID").val();
            Data.CentreCode = $('#CentreCode').val();
            Data.CentrewiseDeptID = $('input[name=CentrewiseDeptID]').val();
            Data.Birthdate = $("#Birthdate").val();
            Data.EmployeeCode = $("#EmployeeCode").val();
            Data.EmployeeDesignationMasterID = $("#EmployeeDesignationMasterID").val();
        }
        return Data;
    },

    GetEmployeePersonalInformation: function () {
        var Data = {
        };

        if (EmployeeInformation.ActionName == "EditPersonalInformation") {
            //Data.ID = $('input[name=ID]').val();
            //Data.NameTitle = $("#EmployeeNameTitle").val();
            //Data.EmployeeCode = $("#EmployeeCode").val();
            //Data.EmailID = $("#EmailID").val();
            //Data.OtherEmailID = $("#OtherEmailID").val();
            //Data.EmployeeFirstName = $("#EmpFirstName").val();           
            //Data.EmployeeMiddleName = $("#EmployeeMiddleName").val();
            //Data.EmployeeLastName = $("#EmployeeLastName").val();
            //Data.NickName = $("#NickName").val();
            //Data.IsEmployeeSmoker = $('#IsEmployeeSmoker_Yes:checked').val() ? true : false;
            //Data.EthanicRaceCode = $('#EthanicRaceCode').val();
            //Data.Birthdate = $('#Birthdate').val();
            //Data.NationalityID = $('#EmployeeNationalityID').val();
            Data.ID = $('input[name=ID]').val();
            Data.NameTitle = $("#EmployeeNameTitle").val();
            Data.EmployeeCode = $("#EmployeeCode").val();
            Data.EmailID = $("#EmailID").val();
            Data.OtherEmailID = $("#OtherEmailID").val();
            Data.EmployeeFirstName = $("#EmpFirstName").val();
            Data.EmployeeMiddleName = $("#EmployeeMiddleName").val();
            Data.EmployeeLastName = $("#EmployeeLastName").val();
            Data.NickName = $("#NickName").val();
            Data.IsEmployeeSmoker = $('#IsEmployeeSmoker_Yes:checked').val() ? true : false;
            Data.EthanicRaceCode = $('#EthanicRaceCode').val();
            Data.Birthdate = $('#Birthdate').val();
            Data.NationalityID = $('#EmployeeNationalityID').val();
            if ($("#EmployeeNameTitle").val() == "Mr") {
                Data.GenderCode = 'M';
            }
            else {
                Data.GenderCode = 'F';
            }
            Data.MarritalStaus = $('#MarritalStaus').val();
            Data.EmployeeNameAsPerTC = $('#EmployeeNameAsPerTC').val();
            Data.MaidenFirstName = $('#MaidenFirstName').val();
            Data.MaidenMiddleName = $('#MaidenMiddleName').val();
            Data.MaidenLastName = $('#MaidenLastName').val();
            Data.IsNameChangedBefore = $('#IsNameChangedBefore_Yes:checked').val() ? true : false;
            Data.IMEI = $("#IMEI").val();
            //if (EmployeeInformation.IsNameChangedBefore_Yes == null) {
            //if (EmployeeInformation.IsNameChangedBefore_Yes == true) {
            //if ($("#IsNameChangedBefore").val() == true) {
            //if ($('input[id=IsNameChangedBefore_Yes]').val() == "True") {
            //    //Data.IsNameChangedBefore = $('input[name=IsNameChangedBefore]').val();
            //    Data.IsNameChangedBefore = $('input[id=IsNameChangedBefore_Yes]').val();
                
            //}
            //else {
            //    //Data.IsNameChangedBefore = EmployeeInformation.IsNameChangedBefore_Yes;
            //    Data.IsNameChangedBefore = $('input[id=IsNameChangedBefore_No]').val();
            //}
            Data.PriorFirstName = $("#PriorFirstName").val()
            Data.PriorMiddleName = $("#PriorMiddleName").val()
            Data.PriorLastName = $("#PriorLastName").val()
        }
        return Data;
    },


    //get office details for employee
    GetEmployeeOfficeDetails: function () {
        debugger;
        var Data = {
        };

        if (EmployeeInformation.ActionName == "EditEmployeeOfficeDetails") {
            Data.ID = $('input[name=ID]').val();
            Data.CentreCode = $('#CentreCodeOfficeDetails').val();
            Data.DepartmentID = $("#DepartmentID").val();
            Data.EmployeeDesignationMasterID = $("#EmployeeDesignationMasterID").val();
            Data.SalaryGradeCode = $("#SalaryGradeCode").val();
            Data.JobProfileID = $("#JobProfileID").val();
            Data.JobStatusID = $("#JobStatusID").val();
            Data.JobStatus = $("#JobStatusID Selected").text();
            Data.JoiningDate = $("#JoiningDate").val();
            Data.AppointmentApprovalDate = $("#AppointmentApprovalDate").val();
            //Data.ReasonOfLeaving = EmployeeInformation.ReasonOfLeaving;
            Data.ReasonOfLeaving = $("#ReasonOfLeaving").val();
            Data.IsLeave = $('#IsLeave:checked').val() ? true : false;
            //Data.DateOfLeaving = EmployeeInformation.DateOfLeaving;
            Data.DateOfLeaving = $("#DateOfLeaving").val();
            Data.DateOfRetirment = $('#DateOfRetirment').val();
            Data.TerminationDate = $('#TerminationDate').val();

            Data.EmployeeShiftApplicableMasterID = parseInt($('#EmployeeShiftApplicableMasterID').val());
            Data.PayScaleMstID = $('#PayScaleMstID').val();
            Data.BasicSalary = $('#BasicSalary').val();
            Data.ProvidentFundNumber = $('#ProvidentFundNumber').val();
            Data.ProvidentFundApplicableDate = $('#ProvidentFundApplicableDate').val();
            Data.PanNumber = $('#PanNumber').val();
            Data.BankACNumber = $('#BankACNumber').val();
            Data.IFSCCode = $('#IFSCCode').val();
            Data.AdharCardNumber = $("#AdharCardNumber").val();
            Data.SSNNumber = $("#SSNNumber").val();
            Data.SINNumber = $("#SINNumber").val();
            Data.DrivingLicenceNumber = $("#DrivingLicenceNumber").val();
            Data.DrivingLicenceExpireDate = $("#DrivingLicenceExpireDate").val();
            Data.PaymentMode = $("#PaymentMode").val();
            Data.ESINumber = $("#ESINumber").val();
            Data.UANNumber = $("#UANNumber").val();
        }
        return Data;
    },

    //get language details for employee
    GetEmployeeLanguageDetails: function () {

        var Data = {
        };

        if (EmployeeInformation.ActionName == "EditEmployeeLanguageDetails") {
            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.SelectedIDs = EmployeeInformation.SelectedXmlDataForLanguageDetails;
        }
        return Data;
    },

    //get Service details for employee
    GetEmployeeServiceDetails: function () {

        var Data = {
        };

        if (EmployeeInformation.ActionName == "CreateEmployeeServiceDetails" || EmployeeInformation.ActionName == "EditEmployeeServiceDetails") {

            // Data.ID = $('input[name=ID]').val();
            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.OldDepartmentID = $('input[name=OldDepartmentID]').val();
            Data.SequenceNumber = $('input[name=SequenceNumber]').val();
            Data.OrderNumber = $("#OrderNumber").val();
            Data.OrderDate = $("#OrderDate").val();
            Data.AcceptedByEmployee = $("#AcceptedByEmployee").val();
            Data.ApprovedBy = $("#ApprovedBy").val();
            Data.PromotionDemotionFlag = $("#PromotionDemotionFlag").val();
            Data.PromotionDemotionDate = $("#PromotionDemotionDate").val();
            Data.OldDesignationID = $("#EmployeeDesignationMasterID").val();
            Data.EmployeeDesignationMasterID = $("#GrantedPromotionDesignationID").val();
            Data.IsCurrentFlag = $('input[name=IsCurrentFlag]').val();
            Data.CentreCode = $("#CentreCodeForServiceDetails").val();
            Data.DepartmentID = $("#DepartmentIDForServiceDetails").val();
            Data.PreviousPromotionDemotionDate = $("#PreviousPromotionDemotionDate").val();
            Data.BasicAmount = $("#BasicAmount").val();
            Data.ChargeTakingDate = $("#ChargeTakingDate").val();
            Data.NatureOfAppointment = $("#NatureOfAppointment").val();
            Data.NatureOfDuty = $("#NatureOfDuty").val();
            Data.CollegeApprovalNumber = $("#CollegeApprovalNumber").val();
            Data.CollegeApprovalDate = $("#CollegeApprovalDate").val();
            Data.UniversityApprovalType = $("#UniversityApprovalType").val();
            Data.UniversityApprovalNumber = $("#UniversityApprovalNumber").val();
            Data.UniversityApprovalDate = $("#UniversityApprovalDate").val();
            Data.GeneralBoardUniversityID = $("#GeneralBoardUniversityID").val();
            Data.SubjectForApproval = $("#SubjectForApproval").val();
            Data.GrantedPromotionDate = $("#GrantedPromotionDate").val();
            Data.GrantedPromotionDesignationID = $("#GrantedPromotionDesignationID").val();
            Data.GrantedPromotionLevel = $("#GrantedPromotionLevel").val();
            Data.OldCentreCode = $('input[name=OldCentreCode]').val();
            Data.ID = $('input[name=CurrentID]').val();
            Data.IsActive = $('#IsActive:checked').val() ? true : false;

        }


        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeInformation.ReloadList(splitData[0], splitData[1], splitData[2]);

            //$('#EmployeeFormStatusMessages').html(message);
            //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeInformation.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {


    //this is used to for showing successfully record creation message and reload the list view
    SuccessOffice: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeInformation.ReloadListOffice(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeInformation.ReloadListOffice(splitData[0], splitData[1], splitData[2]);
        }
    },

    //this is used to for showing successfully record creation message and reload the list view
    SuccessPersonalInformationHome: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeInformation.ReloadListPersonalInformationHome(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeInformation.ReloadListPersonalInformationHome(splitData[0], splitData[1], splitData[2]);
        }
    },



    //this is used to for showing successfully record creation message and reload the list view
    SuccessService: function (data) {
       
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeInformation.ReloadListService(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeInformation.ReloadListService(splitData[0], splitData[1], splitData[2]);
        }
    },
};

