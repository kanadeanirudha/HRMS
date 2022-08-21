var GeneralLocationMaster = {
    variable: null,
    Initialize: function () {
        GeneralLocationMaster.constructor();
    },
    constructor: function () {

        $("#reset").on("click", function () {
            $("input,textarea,select").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Description').focus();
            return false;
        });

        $('#CreateGeneralLocationMasterRecord').on("click", function () {

            GeneralLocationMaster.ActionName = "Create";
            GeneralLocationMaster.AjaxCallGeneralLocationMaster();
        });

        $('#EditGeneralLocationMasterRecord').on("click", function () {

            GeneralLocationMaster.ActionName = "Edit";
            GeneralLocationMaster.AjaxCallGeneralLocationMaster();
        });

        $('#DeleteGeneralLocationMasterRecord').on("click", function () {

            GeneralLocationMaster.ActionName = "Delete";
            GeneralLocationMaster.AjaxCallGeneralLocationMaster();
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



        $("#SelectedCountryID").change(function () {

            $('#SelectedCityID').find('option').remove().end().append('<option value>----Select City----</option>');
            $("#SelectedCityID").prop("disabled", true);
            var selectedItem = $(this).val();
            if (selectedItem != "") {
                var $ddlRegion = $("#SelectedRegionID");
                var $RegionProgress = $("#states-loading-progress");
                $RegionProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralLocationMaster/GetRegionByCountryID",
                    data: { "SelectedCountryID": selectedItem },
                    success: function (data) {
                        $ddlRegion.html('');
                        $('#SelectedRegionID').append('<option value>----Select State----</option>');
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
                $('#SelectedRegionID').find('option').remove().end().append('<option value>----Select State----</option>');
                $('#SelectedCityID').find('option').remove().end().append('<option value>----Select City----</option>');
            }
        });

        $("#SelectedRegionID").change(function () {

            var selectedItem = $(this).val();
            if (selectedItem != "") {
                $("#SelectedCityID").prop("disabled", false);
                var $ddlCity = $("#SelectedCityID");
                var $CityProgress = $("#states-loading-progress");
                $CityProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralLocationMaster/GetCityByRegionID",
                    data: { "SelectedRegionID": selectedItem },
                    success: function (data) {
                        $ddlCity.html('');
                        $('#SelectedCityID').append('<option value>----Select City----</option>');
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
                $('#SelectedCityID').find('option').remove().end().append('<option value>----Select City----</option>');
            }
        });
    },
    LoadList: function () {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/GeneralLocationMaster/List',
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
           url: '/GeneralLocationMaster/List',
           success: function (data) {
               //Rebind Grid Data
               $("#ListViewModel").empty().append(data);
               //twitter type notification
               //$('#SuccessMessage').html(message)
               //$('#SuccessMessage').delay(400).slideDown(400).delay(3000).slideUp(400).css('background-color', colorCode);
               notify(message,colorCode);
           }
       });
    },

    AjaxCallGeneralLocationMaster: function () {
        var GeneralLocationMasterMasterData = null;
        if (GeneralLocationMaster.ActionName == "Create") {
            $("#FormCreateGeneralLocationMaster").validate();
            if ($("#FormCreateGeneralLocationMaster").valid()) {

                GeneralLocationMasterMasterData = GeneralLocationMaster.GetGeneralLocationMasterMaster();
                ajaxRequest.makeRequest("/GeneralLocationMaster/Create", "POST", GeneralLocationMasterMasterData, GeneralLocationMaster.Success);
            }
        }
        else if (GeneralLocationMaster.ActionName == "Edit") {
            $("#FormEditGeneralLocationMaster").validate();
            if ($("#FormEditGeneralLocationMaster").valid()) {

                GeneralLocationMasterMasterData = GeneralLocationMaster.GetGeneralLocationMasterMaster();
                ajaxRequest.makeRequest("/GeneralLocationMaster/Edit", "POST", GeneralLocationMasterMasterData, GeneralLocationMaster.Success);
            }
        }
        else if (GeneralLocationMaster.ActionName == "Delete") {

            GeneralLocationMasterMasterData = GeneralLocationMaster.GetGeneralLocationMasterMaster();
            ajaxRequest.makeRequest("/GeneralLocationMaster/Delete", "POST", GeneralLocationMasterMasterData, GeneralLocationMaster.Success);
        }
    },

    GetGeneralLocationMasterMaster: function () {
        var Data = {
        };
        if (GeneralLocationMaster.ActionName == "Create" || GeneralLocationMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.SelectedCountryID = $('#SelectedCountryID').val();
            Data.SelectedRegionID = $('#SelectedRegionID').val();
            Data.SelectedCityID = $('#SelectedCityID').val();
            Data.CityID = $('#CityID').val();
            Data.LocationAddress = $('#LocationAddress').val();
            Data.PostCode = $('#PostCode').val();
            Data.Latitude = $('#Latitude').val();
            Data.Longitude = $('#Longitude').val();
            //Data.DefaultFlag = $('input[id=DefaultFlag]:checked').val();
            Data.DefaultFlag = $('#DefaultFlag:checked').val() ? true : false;
            //Data.DefaultFlag = ischecked;
        }
        else if (GeneralLocationMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralLocationMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralLocationMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};


