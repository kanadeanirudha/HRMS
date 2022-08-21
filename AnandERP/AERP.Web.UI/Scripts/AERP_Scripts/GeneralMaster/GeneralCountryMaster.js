//this class contain methods related to nationality functionality
var GeneralCountryMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralCountryMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CountryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        // Create new record
        $('#CreateGeneralCountryMasterRecord').on("click", function () {
            GeneralCountryMaster.ActionName = "Create";
            GeneralCountryMaster.AjaxCallGeneralCountryMaster();
        });

        $('#EditGeneralCountryMasterRecord').on("click", function () {

            GeneralCountryMaster.ActionName = "Edit";
            GeneralCountryMaster.AjaxCallGeneralCountryMaster();
        });

        $('#DeleteGeneralCountryMasterRecord').on("click", function () {

            GeneralCountryMaster.ActionName = "Delete";
            GeneralCountryMaster.AjaxCallGeneralCountryMaster();
        });
        $('#CountryName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
        $('#ContryCode').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
            if (e.keyCode == 32) {
                return false;
            }
        });
        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
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



    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralCountryMaster/List',
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
            data: { "actionMode": actionMode },
            url: '/GeneralCountryMaster/List',
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
    AjaxCallGeneralCountryMaster: function () {
        var GeneralCountryMasterData = null;
        if (GeneralCountryMaster.ActionName == "Create") {
            $("#FormCreateGeneralCountryMaster").validate();
            if ($("#FormCreateGeneralCountryMaster").valid()) {
                GeneralCountryMasterData = null;
                GeneralCountryMasterData = GeneralCountryMaster.GetGeneralCountryMaster();
                ajaxRequest.makeRequest("/GeneralCountryMaster/Create", "POST", GeneralCountryMasterData, GeneralCountryMaster.Success);
            }
        }
        else if (GeneralCountryMaster.ActionName == "Edit") {
            $("#FormEditGeneralCountryMaster").validate();
            if ($("#FormEditGeneralCountryMaster").valid()) {
                GeneralCountryMasterData = null;
                GeneralCountryMasterData = GeneralCountryMaster.GetGeneralCountryMaster();
                ajaxRequest.makeRequest("/GeneralCountryMaster/Edit", "POST", GeneralCountryMasterData, GeneralCountryMaster.Success);
            }
        }
        else if (GeneralCountryMaster.ActionName == "Delete") {
            GeneralCountryMasterData = null;
            //$("#FormCreateGeneralCountryMaster").validate();
            GeneralCountryMasterData = GeneralCountryMaster.GetGeneralCountryMaster();
            ajaxRequest.makeRequest("/GeneralCountryMaster/Delete", "POST", GeneralCountryMasterData, GeneralCountryMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralCountryMaster: function () {
        var Data = {
        };
        if (GeneralCountryMaster.ActionName == "Create" || GeneralCountryMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.CountryName = $('#CountryName').val();
            Data.ContryCode = $('#ContryCode').val();
            Data.SeqNo = $('#SeqNo').val();
            //Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
            Data.DefaultFlag = $('#DefaultFlag:checked').val() ? true : false;
            //Data.DefaultFlag = ischecked;
            //alert($('input[id=DefaultFlag').val());
        }
        else if (GeneralCountryMaster.ActionName == "Delete") {
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
            GeneralCountryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralCountryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {



    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GeneralCountryMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        GeneralCountryMaster.ReloadList("Record Deleted Sucessfully.");
    //      //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

