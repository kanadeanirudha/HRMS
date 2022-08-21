//this class contain methods related to nationality functionality
var SaleContractEmployeeMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractEmployeeMaster.constructor();
        //SaleContractEmployeeMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#Title').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        // Create new record
        $('#CreateSaleContractEmployeeMasterRecord').on("click", function () {
            SaleContractEmployeeMaster.ActionName = "Create";
            SaleContractEmployeeMaster.AjaxCallSaleContractEmployeeMaster();
        });

        $('#EditSaleContractEmployeeMasterRecord').on("click", function () {

            if ($("#IsLeft").is(":checked") && $("#LastLeftDate").val() == "") {
                $("#displayErrorMessage").text("Please Enter Left Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            SaleContractEmployeeMaster.GetLogo('EditSaleContractEmployeeMasterRecord');
            SaleContractEmployeeMaster.ActionName = "Edit";
            SaleContractEmployeeMaster.AjaxCallSaleContractEmployeeMaster();
        });

        $('#DeleteSaleContractEmployeeMasterRecord').on("click", function () {

            SaleContractEmployeeMaster.ActionName = "Delete";
            SaleContractEmployeeMaster.AjaxCallSaleContractEmployeeMaster();
        });
        
        $('#FirstJoiningDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            //ignoreReadonly: true,
        })

        $('#LastLeftDate').datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
            ignoreReadonly: true,
        })

        $('#BirthDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        })

        $('#DrivingLicenceExpireDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        })

        $('#ProvidentFundApplicableDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,
        })

        $('#MobileNumber').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#EmergencyContactNumber1').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#EmergencyContactNumber2').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#Pincode').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });
        $("#ShowList").unbind('click').click(function () {

            var SelectedCentreCode = $('#CentreCode').val();
            var SelectedCentreName = $('#CentreCode :selected').text();

            if (SelectedCentreCode != "") {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

                 dataType: "html",
                 url: '/SaleContractEmployeeMaster/List',
                 success: function (result) {
                     debugger;
                     //Rebind Grid Data    
                     $("#CreateView").attr("href", "SaleContractEmployeeMaster/Create?CentreCode=" + SelectedCentreCode)
                     $('#CreateButton').show(true);
                     $('#ListViewModel').html(result);
                     
                 }
             });
            }
            else {
                notify('Please select Transaction Date', 'warning');
                return false;
            }
        });

        InitAnimatedBorder();
        CloseAlert();

        $("#IsLeft").on("change", function () {
            if (!$(this).is(":checked")) {
                $("#LastLeftDate").val("");
            }
        })


        $("#CountryID").change(function () {

            $('#CityID').find('option').remove().end().append('<option value>----Select City----</option>');
            //  $("#CityID").prop("disabled", true);
            var selectedItem = $(this).val();
            if (selectedItem != "") {
                var $ddlRegion = $("#RegionID");
                var $RegionProgress = $("#states-loading-progress");
                $RegionProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralLocationMaster/GetRegionByCountryID",
                    data: { "SelectedCountryID": selectedItem },
                    success: function (data) {
                        $ddlRegion.html('');
                        $('#RegionID').append('<option value>----Select Region----</option>');
                        $.each(data, function (id, option) {

                            $ddlRegion.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $RegionProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Region.');
                        $RegionProgress.hide();
                    }
                });
            }
            else {
                $('RegionID').find('option').remove().end().append('<option value>----Select Region----</option>');
                $('#CityID').find('option').remove().end().append('<option value>----Select City----</option>');
            }
        });

        $("#RegionID").change(function () {

            var selectedItem = $(this).val();
            if (selectedItem != "") {
                //    $("CityID").prop("disabled", false);
                var $ddlCity = $("#CityID");
                var $CityProgress = $("#states-loading-progress");
                $CityProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralLocationMaster/GetCityByRegionID",
                    data: { "SelectedRegionID": selectedItem },
                    success: function (data) {

                        $ddlCity.html('');
                        $('#CityID').append('<option value>----Select City----</option>');
                        $.each(data, function (id, option) {

                            $ddlCity.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $CityProgress.hide();

                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve City.');
                        $CityProgress.hide();
                    }
                });
            }
            else {
                $('#CityID').find('option').remove().end().append('<option value>----Select City----</option>');
            }
        });

    },
    GetLogo: function (eventClick) {
        var imgValue = new FormData();
        var files = $("#CroppedImagePath").get(0).files;
        if (files.length > 0 && (SaleContractEmployeeMaster.LogoPathName == null || SaleContractEmployeeMaster.LogoPathName == "")) {
            imgValue.append("MyImages", files[0]);

            $.ajax({
                url: "/SaleContractEmployeeMaster/UploadFile",
                type: "POST",
                processData: false,
                contentType: false,
                data: imgValue,
                dataType: 'json',
                async: false,
                success: function (imgValue) {
                    $("#displayErrorMessage p").text("Uploading Logo...").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    SaleContractEmployeeMaster.LogoPathName = imgValue;
                },
                error: function (er) {
                    alert(er);
                }
            });
        }
    },

    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/SaleContractEmployeeMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var CentreCode = $('#CentreCode').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "centerCode": CentreCode },
           
            url: '/SaleContractEmployeeMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractEmployeeMaster: function () {
        var SaleContractEmployeeMasterData = null;
        if (SaleContractEmployeeMaster.ActionName == "Create") {
            $("#FormCreateSaleContractEmployeeMaster").validate();
            if ($("#FormCreateSaleContractEmployeeMaster").valid()) {
                SaleContractEmployeeMasterData = null;
                SaleContractEmployeeMasterData = SaleContractEmployeeMaster.GetSaleContractEmployeeMaster();
                ajaxRequest.makeRequest("/SaleContractEmployeeMaster/Create", "POST", SaleContractEmployeeMasterData, SaleContractEmployeeMaster.Success);
            }
        }
        else if (SaleContractEmployeeMaster.ActionName == "Edit") {
            $("#FormEditSaleContractEmployeeMaster").validate();
            if ($("#FormEditSaleContractEmployeeMaster").valid()) {
                SaleContractEmployeeMasterData = null;
                SaleContractEmployeeMasterData = SaleContractEmployeeMaster.GetSaleContractEmployeeMaster();
                ajaxRequest.makeRequest("/SaleContractEmployeeMaster/Edit", "POST", SaleContractEmployeeMasterData, SaleContractEmployeeMaster.Success);
            }
        }
        else if (SaleContractEmployeeMaster.ActionName == "Delete") {
            SaleContractEmployeeMasterData = null;
            //$("#FormCreateSaleContractEmployeeMaster").validate();
            SaleContractEmployeeMasterData = SaleContractEmployeeMaster.GetSaleContractEmployeeMaster();
            ajaxRequest.makeRequest("/SaleContractEmployeeMaster/Delete", "POST", SaleContractEmployeeMasterData, SaleContractEmployeeMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractEmployeeMaster: function () {
        var Data = {
        };
        if (SaleContractEmployeeMaster.ActionName == "Create") {
            Data.ID = $('#ID').val();
            Data.Title = $('#Title').val();
            Data.FirstName = $('#FirstName').val();
            Data.MiddleName = $('#MiddleName').val();
            Data.LastName = $('#LastName').val();
            Data.FirstJoiningDate = $('#FirstJoiningDate').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.EmployeeCode = $('#EmployeeCode').val();
        }
        else if (SaleContractEmployeeMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.Title = $('#Title').val();
            Data.FirstName = $('#FirstName').val();
            Data.MiddleName = $('#MiddleName').val();
            Data.LastName = $('#LastName').val();
            Data.FirstJoiningDate = $('#FirstJoiningDate').val();
            Data.IsLeft = $('#IsLeft').is(":checked") ? true : false;
            Data.LastLeftDate = $('#LastLeftDate').val();
            Data.BirthDate = $('#BirthDate').val();
            Data.NationalityID = $('#NationalityID').val();
            var GenCode = $('input[name="GenderCode"]:checked').val();
            if(GenCode == "True")
                Data.GenderCode = "M";
            else
                Data.GenderCode = "F";
            Data.MarritalStaus = $('#MarritalStaus').val();
            Data.MobileNumber = $('#MobileNumber').val();
            Data.EmailID = $('#EmailID').val();
            Data.OtherEmailID= $('#OtherEmailID').val();
            Data.EmergencyContactNumber1 = $('#EmergencyContactNumber1').val();
            Data.EmergencyContactNumber2 = $('#EmergencyContactNumber2').val();
            Data.Address1 = $('#Address1').val();
            Data.Address2 = $('#Address2').val();
            Data.CityID = $('#CityID').val();
            Data.Pincode = $('#Pincode').val();
            Data.SSNNumber= $('#SSNNumber').val();
            Data.SINNumber = $('#SINNumber').val();
            Data.DrivingLicenceNumber = $('#DrivingLicenceNumber').val();
            Data.DrivingLicenceExpireDate = $('#DrivingLicenceExpireDate').val();
            Data.PanNumber = $('#PanNumber').val();
            Data.ESINumber = $('#ESINumber').val();
            Data.ProvidentFundNumber = $('#ProvidentFundNumber').val();
            Data.ProvidentFundApplicableDate = $('#ProvidentFundApplicableDate').val();
            Data.BankMasterID = $('#BankMasterID').val();
            Data.BankName = $('#BankName').val();
            Data.BankACNumber = $('#BankACNumber').val();
            Data.BankIFSICode = $('#BankIFSICode').val();
            Data.MiddleFullName = $('#MiddleFullName').val();
            Data.UANNumber = $('#UANNumber').val();
            Data.CurrentESICZoneID = $('#CurrentESICZoneID').val();
            Data.BloodGroup = $('#BloodGroup').val();
            Data.IsPoliceVerificationComplete = $('input[id=IsPoliceVerificationComplete]').is(":checked") ? "true" : "false";
            Data.IsESICCardIssued = $('input[id=IsESICCardIssued]').is(":checked") ? "true" : "false";
            Data.CroppedImagePath = SaleContractEmployeeMaster.LogoPathName;
            Data.CentreCode = $('#CentreCode').val();
            Data.ReasonForLeft = $('#ReasonForLeft').val();
        }
        else if (SaleContractEmployeeMaster.ActionName == "Delete") {
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
            SaleContractEmployeeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SaleContractEmployeeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

