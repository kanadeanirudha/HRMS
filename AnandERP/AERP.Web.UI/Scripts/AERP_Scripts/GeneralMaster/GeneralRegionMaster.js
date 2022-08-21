//this class contain methods related to nationality functionality
var GeneralRegionMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralRegionMaster.constructor();
        //GeneralRegionMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SelectedCountryID').focusin();
            var dt = new Date();
            // document.write("getYear() : " + dt.getYear());
            $('#SelectedCountryID').val("");
            $('#RegionName').val("");
            $('#ShortName').val("");
        });

        // Create new record
        $('#CreateGeneralRegionMasterRecord').on("click", function () {
            GeneralRegionMaster.ActionName = "Create";
            GeneralRegionMaster.AjaxCallGeneralRegionMaster();
        });

        $('#EditGeneralRegionMasterRecord').on("click", function () {
            GeneralRegionMaster.ActionName = "Edit";
            GeneralRegionMaster.AjaxCallGeneralRegionMaster();
        });

        $('#DeleteGeneralRegionMasterRecord').on("click", function () {

            GeneralRegionMaster.ActionName = "Delete";
            GeneralRegionMaster.AjaxCallGeneralRegionMaster();
        });
        $('#SeqNo').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#ShortName').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);

        });
        $("#UserSearch").keyup(function () {
            //var oTable = $("#myDataTable").dataTable();
            //oTable.fnFilter(this.value);
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

        $('#RegionName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#ShortName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralRegionMaster/List',
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
            url: '/GeneralRegionMaster/List',
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
    AjaxCallGeneralRegionMaster: function () {
        var GeneralRegionMasterData = null;
        if (GeneralRegionMaster.ActionName == "Create") {
            $("#FormCreateGeneralRegionMaster").validate();
            if ($("#FormCreateGeneralRegionMaster").valid()) {
                GeneralRegionMasterData = null;
                GeneralRegionMasterData = GeneralRegionMaster.GetGeneralRegionMaster();
                ajaxRequest.makeRequest("/GeneralRegionMaster/Create", "POST", GeneralRegionMasterData, GeneralRegionMaster.Success);
            }
        }
        else if (GeneralRegionMaster.ActionName == "Edit") {
            $("#FormEditGeneralRegionMaster").validate();
            if ($("#FormEditGeneralRegionMaster").valid()) {
                GeneralRegionMasterData = null;
                GeneralRegionMasterData = GeneralRegionMaster.GetGeneralRegionMaster();
                ajaxRequest.makeRequest("/GeneralRegionMaster/Edit", "POST", GeneralRegionMasterData, GeneralRegionMaster.Success);
            }
        }
        else if (GeneralRegionMaster.ActionName == "Delete") {
            GeneralRegionMasterData = null;
            //$("#FormCreateGeneralRegionMaster").validate();
            GeneralRegionMasterData = GeneralRegionMaster.GetGeneralRegionMaster();

            ajaxRequest.makeRequest("/GeneralRegionMaster/Delete", "POST", GeneralRegionMasterData, GeneralRegionMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralRegionMaster: function () {

        var Data = {
        };
        if (GeneralRegionMaster.ActionName == "Create" || GeneralRegionMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            var splitData = $('#SelectedCountryID').val().split('~');
            Data.SelectedCountryID = splitData[0];
            Data.CountryCode = splitData[1];
            Data.RegionName = $('#RegionName').val();
            Data.TinNumber = $('#TinNumber').val();
            Data.ShortName = $('#ShortName').val();
            //Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
            //Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
            Data.DefaultFlag = $('input[id=DefaultFlag]:checked').val() ? true : false;
        }
        else if (GeneralRegionMaster.ActionName == "Delete") {
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
            GeneralRegionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralRegionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {



    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GeneralRegionMaster.ReloadList("Record Updated Sucessfully.",actionMode );
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
    //        GeneralRegionMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

