//this class contain methods related to nationality functionality
var GeneralUnits = {
    //Member variables
    ActionName: null,
    LogoPathName: null,
    SelectedDomainIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralUnits.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        

        // Create new record
        $('#CreateGeneralUnitsRecord').on("click", function () {
            GeneralUnits.ActionName = "Create";
            if ($('#InventoryLocationMasterID').val() > 0)
            {
                GeneralUnits.getValueUsingParentTag_Check_UnCheck();
                GeneralUnits.AjaxCallGeneralUnits();
            }
            else
            {
                $("#displayErrorMessage p").text("Please select Location.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            }
        });


        $('#EditGeneralUnitsRecord').unbind("click").on("click", function () {
            GeneralUnits.GetLogo('EditGeneralUnitsRecord');
            GeneralUnits.ActionName = "UnitDetails";
            GeneralUnits.AjaxCallGeneralUnits();
        });

        $('#DeleteGeneralUnitsRecord').on("click", function () {

            GeneralUnits.ActionName = "Delete";
            GeneralUnits.AjaxCallGeneralUnits();
        });
        //$("#SelectedCentreCode").change(function () {
        //    var selectedItem = $(this).val();
        //    var $ddlDepartment = $("#SelectedDepartmentID");
        // //   var $DepartmentProgress = $("#states-loading-progress");
        //   // $DepartmentProgress.show();
        //    if ($("#SelectedCentreCode").val() != "") {
        //        $.ajax({
        //            cache: false,
        //            type: "GET",
        //            url: "/GeneralUnits/GetDepartmentByCentreCode",

        //            data: { "SelectedCentreCode": selectedItem },
        //            success: function (data) {
        //                $ddlDepartment.html('');
        //                $ddlDepartment.append('<option value="">----Select Department----</option>');
        //                $.each(data, function (id, option) {

        //                    $ddlDepartment.append($('<option></option>').val(option.id).html(option.name));
        //                });
        //               // $DepartmentProgress.hide();
        //            },
        //            error: function (xhr, ajaxOptions, thrownError) {
        //                alert('Failed to retrieve Department.');
        //              //  $DepartmentProgress.hide();
        //            }
        //        });
        //    }
        //    else {
        //        $('#myDataTable tbody').empty();
        //        $('#SelectedDepartmentID').find('option').remove().end().append('<option value>All</option>');
        //    }
        //    $('#myDataTable').html("");
        //    //$('#myDataTable_info').text("No entries to show");
        //    //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        //});

       // $("#SelectedCentreCode").change(function () {
         //   $('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        //});
        //$("#btnShowList").on("click", function () {
            $('#btnShowList').unbind('click').click(function () {
            
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
           // var valuDepartmentID = $('#SelectedDepartmentID :selected').val();

            if (valuCentreCode == "") {

                notify("Please select Centre", 'warning');
            }
            //else if (valuDepartmentID == "") {
            //    notify("Please select Department", 'warning');
            //}
            else {
                GeneralUnits.LoadList(valuCentreCode);
                //GeneralUnits.LoadList(valuCentreCode, valuDepartmentID);
            }

        });
        $('#UnitName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#Pincode').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        InitAnimatedBorder();

        CloseAlert();

    },

    GetLogo: function (eventClick) {
        var imgValue = new FormData();
        var files = $("#LogoPath").get(0).files;
        if (files.length > 0 && (GeneralUnits.LogoPathName == null || GeneralUnits.LogoPathName == "")) {
            imgValue.append("MyImages", files[0]);

            $.ajax({
                url: "/GeneralUnits/UploadFile",
                type: "POST",
                processData: false,
                contentType: false,
                data: imgValue,
                dataType: 'json',
                async : false,
                success: function (imgValue) {
                    $("#displayErrorMessage p").text("Uploading Logo...").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    GeneralUnits.LogoPathName = imgValue;
                },
                error: function (er) {
                    alert(er);
                }
            });
        }
    },


    //LoadList method is used to load List page
    //LoadList: function (SelectedCentreCode, SelectedDepartmentID) {
        LoadList: function (SelectedCentreCode) {
        var selectedText = $('#SelectedDepartmentID').text();
        var selectedVal = $('#SelectedDepartmentID').val();
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { centerCode: SelectedCentreCode },
            // data: { centerCode: SelectedCentreCode, departmentID: selectedVal },
             dataType: "html",
             url: '/GeneralUnits/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
       // var SelectedDepartmentID = $('#SelectedDepartmentID :selected').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "centerCode": SelectedCentreCode, "actionMode": actionMode },
            //data: { "centerCode": SelectedCentreCode, "departmentID": SelectedDepartmentID, "actionMode": actionMode },
            url: '/GeneralUnits/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallGeneralUnits: function () {
        var GeneralUnitsData = null;
        if (GeneralUnits.ActionName == "Create") {
            $("#FormCreateGeneralUnits").validate();
            if ($("#FormCreateGeneralUnits").valid()) {
                GeneralUnitsData = null;
                GeneralUnitsData = GeneralUnits.GetGeneralUnits();

                ajaxRequest.makeRequest("/GeneralUnits/Create", "POST", GeneralUnitsData, GeneralUnits.Success, "CreateGeneralUnitsRecord");
            }


        }
        else if (GeneralUnits.ActionName == "UnitDetails") {
            $("#FormEditGeneralUnits").validate();
            if ($("#FormEditGeneralUnits").valid()) {
                GeneralUnitsData = null;

                GeneralUnitsData = GeneralUnits.GetGeneralUnits();

                ajaxRequest.makeRequest("/GeneralUnits/UnitDetails", "POST", GeneralUnitsData, GeneralUnits.Success);

            }
        }
        else if (GeneralUnits.ActionName == "Delete") {
            GeneralUnitsData = null;
            //$("#FormCreateGeneralUnits").validate();
            GeneralUnitsData = GeneralUnits.GetGeneralUnits();
            ajaxRequest.makeRequest("/GeneralUnits/Delete", "POST", GeneralUnitsData, GeneralUnits.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralUnits: function () {

        var Data = {
        };
        if (GeneralUnits.ActionName == "Create" || GeneralUnits.ActionName == "UnitDetails") {
            
            Data.ID = $('#ID').val();
            Data.GeneralUnitTypeID = $('input[name=GeneralUnitTypeID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.DepartmentID = $('input[name=DepartmentID]').val();
            Data.UnitName = $('#UnitName').val();
            Data.LocationAddress = $('#LocationAddress').val();
            Data.CityId = $('#CityId').val();
            Data.GeneralUnitsStorageLocationID = $('input[name=GeneralUnitsStorageLocationID]').val();
            Data.InventoryLocationMasterID = $('input[name =InventoryLocationMasterID]').val();
            Data.IsDefaultUnit = $('#IsDefaultUnit').is(":checked") ? "true" : "false";
            Data.LogoPathName = GeneralUnits.LogoPathName;

            if (Data.CityId == "" || Data.CityId == null || Data.CityId == 0) {
                Data.IsCityName = 'false';
            }
            else {
                Data.IsCityName = 'true';
            }

            if (Data.LocationAddress == "" || Data.LocationAddress == null) {
                Data.IsAddress = 'false';
            }
            else {
                Data.IsAddress = 'true';
            }

            Data.Footer = $('#Footer').val();
            if (Data.Footer == "" || Data.Footer == null) {
                Data.IsFooter = 'false';
            }
            else {
                Data.IsFooter = 'true';
            }
            Data.LogoPath = $('#LogoPath').val();
            if (Data.LogoPath == "" || Data.LogoPath == null) {
                Data.IsLogoPath = 'false';
            }
            else {
                Data.IsLogoPath = 'true';
            }
            Data.Pincode = $('#Pincode').val();
            if (Data.Pincode == "" || Data.Pincode == null) {
                Data.IsPincode = 'false';
            }
            else {
                Data.IsPincode = 'true';
            }
            Data.TelephoneNumber = $('#TelephoneNumber').val();
            if (Data.TelephoneNumber == "" || Data.TelephoneNumber == null) {
                Data.IsTelephoneNumber = 'false';
            }
            else {
                Data.IsTelephoneNumber = 'true';
            }
            Data.FaxNumber = $('#FaxNumber').val();
            if (Data.FaxNumber == "" || Data.FaxNumber == null) {
                Data.IsFaxNumber = 'false';
            }
            else {
                Data.IsFaxNumber = 'true';
            }
            Data.EmailID = $('#EmailID').val();
            if (Data.EmailID == "" || Data.EmailID == null) {
                Data.IsEmailID = 'false';
            }
            else {
                Data.IsEmailID = 'true';
            }

            Data.Url = $('#Url').val();
            if (Data.Url == "" || Data.Url == null) {
                Data.IsUrl = 'false';
            }
            else {
                Data.IsUrl = 'true';
            }
            Data.DisplayIcon = $('#DisplayIcon').val();
            Data.Greeting = $('#Greeting').val();
            if (Data.Greeting == "" || Data.Greeting == null) {
                Data.IsGreeting = 'false';
            }
            else {
                Data.IsGreeting = 'true';
            }
            Data.SelectedDomainIDs = GeneralUnits.SelectedDomainIDs;
        }
        else if (GeneralUnits.ActionName == "Delete") {
            Data.GeneralUnitsID = $('input[name=GeneralUnitsID]').val();

        }
        return Data;
    },

    getValueUsingParentTag_Check_UnCheck: function () {
        
        var sList = "";
        var xmlParamList = "<rows>"
        //alert();
        //$('#checkboxlist input[type=checkbox]').each(function () {
        $('#checkboxlist option').each(function () {

            if ($(this).val() != "on") {
                //AdminRoleDomainID = $(this).val();
                AdminRoleDomainID = $(this).val().split("~");
                if (this.selected == true) {

                    //xmlInsert code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + AdminRoleDomainID[0] + "</ID>" + "<AdminRoleDomainID>" + AdminRoleDomainID[1] + "</AdminRoleDomainID></row>";
                }

            }
            if (xmlParamList.length > 6)
                GeneralUnits.SelectedDomainIDs = xmlParamList + "</rows>";
            else
                GeneralUnits.SelectedDomainIDs = "";
        });
        // alert(GeneralTaxGroupMaster.SelectedTaxMaterIDs);
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            GeneralUnits.LogoPathName = null;
            GeneralUnits.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

