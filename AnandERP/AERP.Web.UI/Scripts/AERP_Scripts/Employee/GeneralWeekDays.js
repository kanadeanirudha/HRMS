//this class contain methods related to nationality functionality
var GeneralWeekDays = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralWeekDays.constructor();
        //GeneralWeekDays.initializeValidation();
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
        $('#CreateGeneralWeekDaysRecord').on("click", function () {
            
            GeneralWeekDays.ActionName = "Create";
            GeneralWeekDays.AjaxCallGeneralWeekDays();
        });

        $('#EditGeneralWeekDaysRecord').on("click", function () {
            
            GeneralWeekDays.ActionName = "Edit";
            GeneralWeekDays.AjaxCallGeneralWeekDays();
        });

        $('#DeleteGeneralWeekDaysRecord').on("click", function () {

            GeneralWeekDays.ActionName = "Delete";
            GeneralWeekDays.AjaxCallGeneralWeekDays();
        });
        $('#WeekDescription').on("keydown", function (e) {
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
             url: '/GeneralWeekDays/List',
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
            url: '/GeneralWeekDays/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, "success");
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralWeekDays: function () {
        var GeneralWeekDaysData = null;
        if (GeneralWeekDays.ActionName == "Create") {
            $("#FormCreateGeneralWeekDays").validate();
            if ($("#FormCreateGeneralWeekDays").valid()) {
                GeneralWeekDaysData = null;
                GeneralWeekDaysData = GeneralWeekDays.GetGeneralWeekDays();
                ajaxRequest.makeRequest("/GeneralWeekDays/Create", "POST", GeneralWeekDaysData, GeneralWeekDays.Success);
            }
        }
        else if (GeneralWeekDays.ActionName == "Edit") {
            $("#FormEditGeneralWeekDays").validate();
            if ($("#FormEditGeneralWeekDays").valid()) {
                GeneralWeekDaysData = null;
                GeneralWeekDaysData = GeneralWeekDays.GetGeneralWeekDays();
                ajaxRequest.makeRequest("/GeneralWeekDays/Edit", "POST", GeneralWeekDaysData, GeneralWeekDays.Success);
            }
        }
        else if (GeneralWeekDays.ActionName == "Delete") {
            GeneralWeekDaysData = null;
            $("#FormDeleteGeneralWeekDays").validate();
            GeneralWeekDaysData = GeneralWeekDays.GetGeneralWeekDays();
            ajaxRequest.makeRequest("/GeneralWeekDays/Delete", "POST", GeneralWeekDaysData, GeneralWeekDays.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralWeekDays: function () {
        var Data = {
        };
        if (GeneralWeekDays.ActionName == "Create" || GeneralWeekDays.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.WeekDescription = $('#WeekDescription').val();
         
      
        }
        else if (GeneralWeekDays.ActionName == "Delete") {
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
            GeneralWeekDays.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {

            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralWeekDays.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    
    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GeneralWeekDays.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        GeneralWeekDays.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

