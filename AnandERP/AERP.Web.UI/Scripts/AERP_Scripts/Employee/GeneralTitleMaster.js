//this class contain methods related to nationality functionality
var GeneralTitleMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralTitleMaster.constructor();
        //GeneralTitleMaster.initializeValidation();
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
        $('#CreateGeneralTitleMasterRecord').on("click", function () {
           
            GeneralTitleMaster.ActionName = "Create";
            GeneralTitleMaster.AjaxCallGeneralTitleMaster();
        });

        $('#EditGeneralTitleMasterRecord').on("click", function () {
           
            GeneralTitleMaster.ActionName = "Edit";
            GeneralTitleMaster.AjaxCallGeneralTitleMaster();
        });

        $('#DeleteGeneralTitleMasterRecord').on("click", function () {

            GeneralTitleMaster.ActionName = "Delete";
            GeneralTitleMaster.AjaxCallGeneralTitleMaster();
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


        $('#NameTitle').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
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
             url: '/GeneralTitleMaster/List',
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
            url: '/GeneralTitleMaster/List',
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
    AjaxCallGeneralTitleMaster: function () {
        var GeneralTitleMasterData = null;
        if (GeneralTitleMaster.ActionName == "Create") {
            $("#FormCreateGeneralTitleMaster").validate();
            if ($("#FormCreateGeneralTitleMaster").valid()) {
                GeneralTitleMasterData = null;
                GeneralTitleMasterData = GeneralTitleMaster.GetGeneralTitleMaster();
                ajaxRequest.makeRequest("/GeneralTitleMaster/Create", "POST", GeneralTitleMasterData, GeneralTitleMaster.Success);
            }
        }
        else if (GeneralTitleMaster.ActionName == "Edit") {
            $("#FormEditGeneralTitleMaster").validate();
            if ($("#FormEditGeneralTitleMaster").valid()) {
                GeneralTitleMasterData = null;
                GeneralTitleMasterData = GeneralTitleMaster.GetGeneralTitleMaster();
                ajaxRequest.makeRequest("/GeneralTitleMaster/Edit", "POST", GeneralTitleMasterData, GeneralTitleMaster.Success);
            }
        }
        else if (GeneralTitleMaster.ActionName == "Delete") {
            GeneralTitleMasterData = null;
            $("#FormDeleteGeneralTitleMaster").validate();
            GeneralTitleMasterData = GeneralTitleMaster.GetGeneralTitleMaster();
            ajaxRequest.makeRequest("/GeneralTitleMaster/Delete", "POST", GeneralTitleMasterData, GeneralTitleMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralTitleMaster: function () {
        var Data = {
        };
        if (GeneralTitleMaster.ActionName == "Create" || GeneralTitleMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.NameTitle = $('#NameTitle').val();
            Data.Description = $('#Description').val();

            Data.Male = $('#Male').val();

            if ($('#Male').is(':checked')) {
                Data.Gender = "M";
            }
            else if ($('#Female').is(':checked')) {
                Data.Gender = "F";
            }
          

        }
        else if (GeneralTitleMaster.ActionName == "Delete") {
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
            GeneralTitleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralTitleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //   
    //   
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GeneralTitleMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        GeneralTitleMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

