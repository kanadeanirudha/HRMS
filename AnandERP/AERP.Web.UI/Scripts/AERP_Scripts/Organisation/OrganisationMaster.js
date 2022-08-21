var OrganisationMaster = {
    variable: null,
    Initialize: function () {
        OrganisationMaster.constructor();
    },
    constructor: function () {

        $('#CreateOrganisationMasterRecord').on("click", function () {
            OrganisationMaster.ActionName = "Create";
            OrganisationMaster.AjaxCallOrganisationMaster();
        });
        $('#EditOrganisationMasterRecord').on("click", function () {

            OrganisationMaster.ActionName = "Edit";
            OrganisationMaster.AjaxCallOrganisationMaster();
        });
        $('#DeleteOrganisationMasterRecord').on("click", function () {
            OrganisationMaster.ActionName = "Delete";
            OrganisationMaster.AjaxCallOrganisationMaster();
        });
        $('#closeBtn').on("click", function () {
            parent.$.colorbox.close();
        });
        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });
        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });
        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $("#SelectedLocationID").val("");
            $('#Description').focus();
        });

        //$('#FoundationDatetime').prop('readonly', true);
        //$("#FoundationDatetime").datepicker({

        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1850:document.write(currentYear.getFullYear()',
        //});

        $('#FoundationDatetime').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#OrgName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#FounderMember').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
        //$('#FounderMember').on("keydown", function (e) {
        //    AERPValidation.NotAllowSpaces(e);
        //});
        //$('#PlotNumber').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        $('#Pincode').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });
        $('#Pincode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
        });
        $('#FaxNumber').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });
        $('#FaxNumber').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
        });
        $('#MobileNumber').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });
        $('#MobileNumber').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
        });
        ////$('#FaxNumber').on("keydown", function (e) {
        ////    AERPValidation.AllowNumbersOnly(e);
        ////});
        $('#OfficePhone1').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });
        $('#OfficePhone1').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
        });
        $('#OfficePhone2').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });
        $('#OfficePhone2').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
        });

        $('#EmailID').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
        });
        $('#Url').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
        });

    },
    LoadList: function () {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/OrganisationMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax(
       {

           cache: false,
           type: "POST",
           dataType: "html",
           data: { actionMode: actionMode },
           url: '/OrganisationMaster/List',
           success: function (data) {
               //Rebind Grid Data
               $("#ListViewModel").empty().append(data);
               //twitter type notification
               //$('#SuccessMessage').html(message);
               //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
               notify(message,colorCode);
           }
       });
    },

    AjaxCallOrganisationMaster: function () {

        var OrganisationMasterMasterData = null;
        if (OrganisationMaster.ActionName == "Create") {
            $("#FormCreateOrganisationMaster").validate();
            if ($("#FormCreateOrganisationMaster").valid()) {

                OrganisationMasterMasterData = OrganisationMaster.GetOrganisationMaster();
                ajaxRequest.makeRequest("/OrganisationMaster/Create", "POST", OrganisationMasterMasterData, OrganisationMaster.Success);
            }
        }
        else if (OrganisationMaster.ActionName == "Edit") {
            $("#FormEditOrganisationMaster").validate();
            if ($("#FormEditOrganisationMaster").valid()) {

                OrganisationMasterMasterData = OrganisationMaster.GetOrganisationMaster();
                ajaxRequest.makeRequest("/OrganisationMaster/Edit", "POST", OrganisationMasterMasterData, OrganisationMaster.Success);
            }
        }
        else if (OrganisationMaster.ActionName == "Delete") {

            OrganisationMasterMasterData = OrganisationMaster.GetOrganisationMaster();
            ajaxRequest.makeRequest("/OrganisationMaster/Delete", "POST", OrganisationMasterMasterData, OrganisationMaster.Success);
        }
    },

    GetOrganisationMaster: function () {

        var Data = {
        };
        if (OrganisationMaster.ActionName == "Create" || OrganisationMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.OrgName = $('#OrgName').val();
            Data.EstablishmentCode = $('#EstablishmentCode').val();
            Data.FounderMember = $('#FounderMember').val();
            Data.FoundationDatetime = $('#FoundationDatetime').val();
            Data.Address1 = $('#Address1').val();
            Data.Address2 = $('#Address2').val();
            Data.PlotNumber = $('#PlotNumber').val();
            Data.StreetNumber = $('#StreetNumber').val();
            Data.LocationID = $('#LocationID').val();
            Data.SelectedLocationID = $('#SelectedLocationID').val();
            Data.Pincode = $('#Pincode').val();
            Data.FaxNumber = $('#FaxNumber').val();
            Data.OfficePhone1 = $('#OfficePhone1').val();
            Data.MobileNumber = $('#MobileNumber').val();
            Data.OfficePhone2 = $('#OfficePhone2').val();
            Data.EmailID = $('#EmailID').val();
            Data.Url = $('#Url').val();
            Data.OfficeComment = $('#OfficeComment').val();
            Data.MissionStatement = $('#MissionStatement').val();
            Data.PFNumber = $('#PFNumber').val();
            Data.ESICNumber = $('#ESICNumber').val();
            Data.OrgShortCode = $('#OrgShortCode').val();


        }
        else if (OrganisationMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
            Data.DivisionDescription = $('#ID').val();
            Data.DivShortCode = $('#ID').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
   
};


