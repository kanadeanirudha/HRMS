//this class contain methods related to nationality functionality
var EmployeePersonalDetails = {
    //Member variables
    ActionName: null,
    //ContactLocationID: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeePersonalDetails.constructor();
        //EmployeePersonalDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        $('#FormDetailsEmployeeContactDetails :input').attr('readonly', 'readonly');


        $('#MobileNumber').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#TelephoneNumber').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        // Create new record
        $('#CreateEmployeePersonalDetailsRecord').on("click", function () {
            EmployeePersonalDetails.ActionName = "Create";
            EmployeePersonalDetails.AjaxCallEmployeePersonalDetails();
        });

        $('#CreateEmployeeContactDetails').on("click", function () {
            EmployeePersonalDetails.ActionName = "CreateContactDetails";
            EmployeePersonalDetails.AjaxCallEmployeePersonalDetails();
        });

        $('#EditEmployeeContactDetails').on("click", function () {
            EmployeePersonalDetails.ActionName = "EditContactDetails";
            EmployeePersonalDetails.AjaxCallEmployeePersonalDetails();
        });

        $('#EditEmployeePersonalDetailsRecord').on("click", function () {

            EmployeePersonalDetails.ActionName = "Edit";
            EmployeePersonalDetails.AjaxCallEmployeePersonalDetails();
        });

        $('#DeleteEmployeePersonalDetailsRecord').on("click", function () {

            EmployeePersonalDetails.ActionName = "Delete";
            EmployeePersonalDetails.AjaxCallEmployeePersonalDetails();
        });
        $('#CountryName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
        $('#ContryCode').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
        $("#UserSearchContactDetails").keyup(function () {
            var oTable = $("#myDataTableEmployeeContactDetails").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtnContactDetails").click(function () {
            $("#UserSearchContactDetails").focus();
        });

        $("#showrecordContactDetails").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTableEmployeeContactDetails_length']").val(showRecord);
            $("select[name*='myDataTableEmployeeContactDetails_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();


        $("#CountryID").change(function () {

            $('#CityID').find('option').remove().end().append('<option value>-------------Select City-----------------</option>');
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
                        $('#RegionID').append('<option value>----------Select Region----------</option>');
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
                $('RegionID').find('option').remove().end().append('<option value>----------Select Region----------</option>');
                $('#CityID').find('option').remove().end().append('<option value>-------------Select City-----------------</option>');
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
                        $('#CityID').append('<option value>-------------Select City-----------------</option>');
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
                $('#CityID').find('option').remove().end().append('<option value>-------------Select City-----------------</option>');
            }
        });

        $("#CityID").change(function () {

            var selectedItem = $(this).val();
            if (selectedItem != "") {
                $("#Location").prop("disabled", false);
                var $ddlLocation = $("#Location");
                var $LocationProgress = $("#states-loading-progress");
                $LocationProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/EmployeePersonalDetails/GetLocationByCityID",
                    data: { "SelectedCityID": selectedItem },
                    success: function (data) {
                        $ddlLocation.html('');
                        $('#Location').append('<option value>-------------Select Location-----------------</option>');
                        $.each(data, function (id, option) {

                            $ddlLocation.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $LocationProgress.hide();

                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve City.');
                        $LocationProgress.hide();
                    }
                });
            }
            else {
                $('#Location').find('option').remove().end().append('<option value>-------------Select Location-----------------</option>');
            }
        });


        //-----------------------METHOD USED FOR ACCESSING PIN CODE ACCODING TO LOCATION----------------------//
        $("#Location").change(function () {

            var selectedItem = $(this).val();

            if (selectedItem != "") {
                var pinCode = selectedItem.split('~');
                $("#Pincode").val(pinCode[1]);

                EmployeePersonalDetails.ContactLocationID = pinCode[0];
            }
            else {
                alert("No Pincode found");
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
             url: '/EmployeePersonalDetails/List',
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
             url: '/EmployeePersonalDetails/EmployeeContactList',
             success: function (data) {
                 //Rebind Grid Data
                 $('#EmployeeContactDetails').html(data);
             }
         });
    },

    LoadPersonalDetailsList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/EmployeePersonalDetails/EmployeePersonalList',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var ID = $('input[name=ID]').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "ID": ID },
            url: '/EmployeePersonalDetails/PersonalInformationHome',
            success: function (data) {
                //Rebind Grid Data
                //  $("#ListViewModel").empty().append(data);
                //alert('load');
                $("#EmployeeContactDetails").html(data);
               // $('#EmployeeQualification').html(data);
                //twitter type notification

                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //ReloadListContact method is used to load List page
    ReloadListContact: function (message, colorCode, actionMode) {
        var ID = $('input[name=ID]').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "ID": ID , "actionMode": actionMode },
            url: '/EmployeePersonalDetails/EmployeeContactList',
            success: function (data) {
                //Rebind Grid Data
                //alert();
                //twitter type notification
                //alert('load cobn');
                //$("#ListViewModel").empty().append(data);
                $('#EmployeeContactDetails').html(data);
                

                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeePersonalDetails: function () {
        var EmployeePersonalDetailsData = null;
        if (EmployeePersonalDetails.ActionName == "Create") {
            $("#FormCreateEmployeePersonalDetails").validate();
            if ($("#FormCreateEmployeePersonalDetails").valid()) {
                EmployeePersonalDetailsData = null;
                EmployeePersonalDetailsData = EmployeePersonalDetails.GetEmployeePersonalDetails();
                ajaxRequest.makeRequest("/EmployeePersonalDetails/Create", "POST", EmployeePersonalDetailsData, EmployeePersonalDetails.Success);
            }
        }
        else if (EmployeePersonalDetails.ActionName == "Edit") {
            $("#FormEditEmployeePersonalDetails").validate();
            if ($("#FormEditEmployeePersonalDetails").valid()) {
                EmployeePersonalDetailsData = null;
                EmployeePersonalDetailsData = EmployeePersonalDetails.GetEmployeePersonalDetails();
                ajaxRequest.makeRequest("/EmployeePersonalDetails/Edit", "POST", EmployeePersonalDetailsData, EmployeePersonalDetails.Success);
            }
        }
        else if (EmployeePersonalDetails.ActionName == "Delete") {
            EmployeePersonalDetailsData = null;
            //$("#FormCreateEmployeePersonalDetails").validate();
            EmployeePersonalDetailsData = EmployeePersonalDetails.GetEmployeePersonalDetails();
            ajaxRequest.makeRequest("/EmployeePersonalDetails/Delete", "POST", EmployeePersonalDetailsData, EmployeePersonalDetails.Success);

        }
        else if (EmployeePersonalDetails.ActionName == "CreateContactDetails") {
            EmployeePersonalDetailsData = null;
            $("#FormCreateEmployeeContactDetails").validate();
            if ($("#FormCreateEmployeeContactDetails").valid()) {
                EmployeePersonalDetailsData = EmployeePersonalDetails.GetEmployeePersonalDetails();
                ajaxRequest.makeRequest("/EmployeePersonalDetails/EmployeeContactDetailsCreate", "POST", EmployeePersonalDetailsData, EmployeePersonalDetails.SuccessContact);
            }
        }
        else if (EmployeePersonalDetails.ActionName == "EditContactDetails") {
            EmployeePersonalDetailsData = null;
            $("#FormEditEmployeeContactDetails").validate();
            if ($("#FormEditEmployeeContactDetails").valid()) {
                EmployeePersonalDetailsData = EmployeePersonalDetails.GetEmployeePersonalDetails();
                ajaxRequest.makeRequest("/EmployeePersonalDetails/EmployeeContactDetailsEdit", "POST", EmployeePersonalDetailsData, EmployeePersonalDetails.SuccessContact);
            }
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeePersonalDetails: function () {
        var Data = {
        };
        if (EmployeePersonalDetails.ActionName == "Create" || EmployeePersonalDetails.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.CountryName = $('#CountryName').val();
            Data.ContryCode = $('#ContryCode').val();
            Data.SeqNo = $('#SeqNo').val();
            Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
        }
        else if (EmployeePersonalDetails.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        else if (EmployeePersonalDetails.ActionName == "CreateContactDetails") {
            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.AddressType = $('#AddressType').val();
            Data.EmployeeAddress1 = $('#EmployeeAddress1').val();
            Data.EmployeeAddress2 = $('#EmployeeAddress2').val();
            Data.PlotNumber = $('#PlotNumber').val();
            Data.StreetName = $('#StreetName').val();
            Data.CountryID = $('#CountryID').val();
            Data.RegionID = $('#RegionID').val();
            Data.CityID = $('#CityID').val();
            var Location = $('#Location').val();
            if (Location != null || Location != "") {
                var splitData = Location.split('~');
                Data.ContactLocationID = splitData[0];
            }
            else {
                Data.ContactLocationID = 0;
            }
            Data.Pincode = $('#Pincode').val();
            Data.TelephoneNumber = $('#TelephoneNumber').val();
            Data.MobileNumber = $('#MobileNumber').val();
        }
        else if (EmployeePersonalDetails.ActionName == "EditContactDetails") {
            Data.ID = $('#ContactID').val();
            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.AddressType = $('#AddressType').val();
            Data.EmployeeAddress1 = $('#EmployeeAddress1').val();
            Data.EmployeeAddress2 = $('#EmployeeAddress2').val();
            Data.PlotNumber = $('#PlotNumber').val();
            Data.StreetName = $('#StreetName').val();
            Data.CountryID = $('#CountryID').val();
            Data.RegionID = $('#RegionID').val();
            Data.CityID = $('#CityID').val();
            var Location = $('#Location').val();
            if (Location != null || Location != "") {
                var splitData = Location.split('~');
                Data.ContactLocationID = splitData[0];
            }
            else {
                Data.ContactLocationID = 0;
            }
            Data.Pincode = $('#Pincode').val();
            Data.TelephoneNumber = $('#TelephoneNumber').val();
            Data.MobileNumber = $('#MobileNumber').val();
            Data.CurrentAddressFlag = $('input[name=CurrentAddressFlag]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeePersonalDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeePersonalDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    //this is used to for showing successfully record creation message and reload the list view
    SuccessContact: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeePersonalDetails.ReloadListContact(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeePersonalDetails.ReloadListContact(splitData[0], splitData[1], splitData[2]);
        }

    },

    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {



    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        EmployeePersonalDetails.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        EmployeePersonalDetails.ReloadList("Record Deleted Sucessfully.");
    //      //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

