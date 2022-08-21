//this class contain methods related to nationality functionality
var GeneralCityMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralCityMaster.constructor();
        //GeneralCityMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SelectedRegionID').focus();
            $('#SelectedRegionID').val('');
        });

        // Create new record
        $('#CreateGeneralCityMasterRecord').on("click", function () {
            GeneralCityMaster.ActionName = "Create";
            GeneralCityMaster.AjaxCallGeneralCityMaster();
        });

        $('#EditGeneralCityMasterRecord').on("click", function () {

            GeneralCityMaster.ActionName = "Edit";
            GeneralCityMaster.AjaxCallGeneralCityMaster();
        });

        $('#DeleteGeneralCityMasterRecord').on("click", function () {

            GeneralCityMaster.ActionName = "Delete";
            GeneralCityMaster.AjaxCallGeneralCityMaster();
        });
        $('#Description').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        //Cascading DropDown List
        $("#SelectedCountryID").change(function () {

            // $('#SelectedCityID').find('option').remove().end().append('<option value>-------------Select City-----------------</option>');
            // $("#SelectedCityID").prop("disabled", true);
            var selectedItem = $(this).val();
            if (selectedItem != "") {
                var $ddlRegion = $("#SelectedRegionID");
                var $RegionProgress = $("#states-loading-progress");
                $RegionProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralCityMaster/GetRegionByCountryID",
                    data: { "SelectedCountryID": selectedItem },
                    success: function (data) {
                        $ddlRegion.html('');
                        $('#SelectedRegionID').append('<option value>----------Select Region----------</option>');
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
                $('#SelectedRegionID').find('option').remove().end().append('<option value>----------Select Region----------</option>');
                // $('#SelectedCityID').find('option').remove().end().append('<option value>-------------Select City-----------------</option>');
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
             url: '/GeneralCityMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/GeneralCityMaster/List',
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


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralCityMaster: function () {
        var GeneralCityMasterData = null;
        if (GeneralCityMaster.ActionName == "Create") {
            $("#FormCreateGeneralCityMaster").validate();
            if ($("#FormCreateGeneralCityMaster").valid()) {
                GeneralCityMasterData = null;
                GeneralCityMasterData = GeneralCityMaster.GetGeneralCityMaster();
                ajaxRequest.makeRequest("/GeneralCityMaster/Create", "POST", GeneralCityMasterData, GeneralCityMaster.Success);
            }
        }
        else if (GeneralCityMaster.ActionName == "Edit") {
            $("#FormEditGeneralCityMaster").validate();
            if ($("#FormEditGeneralCityMaster").valid()) {
                GeneralCityMasterData = null;
                GeneralCityMasterData = GeneralCityMaster.GetGeneralCityMaster();
                ajaxRequest.makeRequest("/GeneralCityMaster/Edit", "POST", GeneralCityMasterData, GeneralCityMaster.Success);
            }
        }
        else if (GeneralCityMaster.ActionName == "Delete") {
            GeneralCityMasterData = null;
            //$("#FormCreateGeneralCityMaster").validate();
            GeneralCityMasterData = GeneralCityMaster.GetGeneralCityMaster();

            ajaxRequest.makeRequest("/GeneralCityMaster/Delete", "POST", GeneralCityMasterData, GeneralCityMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralCityMaster: function () {

        var Data = {
        };
        if (GeneralCityMaster.ActionName == "Create" || GeneralCityMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            // Data.RegionID = $('#RegionID').val();
            Data.Description = $('#Description').val();
            //alert('#RegionName');
            var splitData = $('#SelectedRegionID').val().split('~');
            Data.SelectedRegionID = splitData[0];
            Data.RegionCode = splitData[1];
            //Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
            Data.DefaultFlag = $('input[id=DefaultFlag]:checked').val() ? true : false;

            Data.SelectedCountryID = $('#SelectedCountryID').val();
            //Data.SelectedRegionID = $('#SelectedRegionID').val();

        }
        else if (GeneralCityMaster.ActionName == "Delete") {
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

            GeneralCityMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            GeneralCityMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GeneralCityMaster.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {

    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        GeneralCityMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

