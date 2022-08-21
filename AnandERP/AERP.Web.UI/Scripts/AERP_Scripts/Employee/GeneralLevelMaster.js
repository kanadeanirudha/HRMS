//this class contain methods related to nationality functionality
var GeneralLevelMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralLevelMaster.constructor();
        //GeneralLevelMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#RegionID').focus();
            $('#RegionID').val('');
        });

        // Create new record
        $('#CreateGeneralLevelMasterRecord').on("click", function () {
            
            GeneralLevelMaster.ActionName = "Create";
            GeneralLevelMaster.AjaxCallGeneralLevelMaster();
        });

        $('#EditGeneralLevelMasterRecord').on("click", function () {
            
            GeneralLevelMaster.ActionName = "Edit";
            GeneralLevelMaster.AjaxCallGeneralLevelMaster();
        });

        $('#DeleteGeneralLevelMasterRecord').on("click", function () {

            GeneralLevelMaster.ActionName = "Delete";
            GeneralLevelMaster.AjaxCallGeneralLevelMaster();
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


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralLevelMaster/List',
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
            url: '/GeneralLevelMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralLevelMaster: function () {
        var GeneralLevelMasterData = null;
        if (GeneralLevelMaster.ActionName == "Create") {
            $("#FormCreateGeneralLevelMaster").validate();
            if ($("#FormCreateGeneralLevelMaster").valid()) {
                GeneralLevelMasterData = null;
                GeneralLevelMasterData = GeneralLevelMaster.GetGeneralLevelMaster();
                ajaxRequest.makeRequest("/GeneralLevelMaster/Create", "POST", GeneralLevelMasterData, GeneralLevelMaster.Success);
            }
        }
        else if (GeneralLevelMaster.ActionName == "Edit") {
            $("#FormEditGeneralLevelMaster").validate();
            if ($("#FormEditGeneralLevelMaster").valid()) {
                GeneralLevelMasterData = null;
                GeneralLevelMasterData = GeneralLevelMaster.GetGeneralLevelMaster();
                ajaxRequest.makeRequest("/GeneralLevelMaster/Edit", "POST", GeneralLevelMasterData, GeneralLevelMaster.Success);
            }
        }
        else if (GeneralLevelMaster.ActionName == "Delete") {
            GeneralLevelMasterData = null;
            $("#FormDeleteGeneralLevelMaster").validate();
            GeneralLevelMasterData = GeneralLevelMaster.GetGeneralLevelMaster();
            ajaxRequest.makeRequest("/GeneralLevelMaster/Delete", "POST", GeneralLevelMasterData, GeneralLevelMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralLevelMaster: function () {
        var Data = {
        };
        if (GeneralLevelMaster.ActionName == "Create" || GeneralLevelMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.Description = $('#Description').val();

        }
        else if (GeneralLevelMaster.ActionName == "Delete") {
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
            GeneralLevelMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralLevelMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    
    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GeneralLevelMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        GeneralLevelMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

