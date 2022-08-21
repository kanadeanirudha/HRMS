//this class contain methods related to nationality functionality
var EmpDesignationMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmpDesignationMaster.constructor();
        //EmpDesignationMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#Description').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :radio').val("");
            $('input:radio').removeAttr('checked');
            $('#Description').focus();
            return false;
        });


        // Create new record
        $('#CreateEmpDesignationMasterRecord').on("click", function () {
            EmpDesignationMaster.ActionName = "Create";
            EmpDesignationMaster.AjaxCallEmpDesignationMaster();
        });

        $('#EditEmpDesignationMasterRecord').on("click", function () {

            EmpDesignationMaster.ActionName = "Edit";
            EmpDesignationMaster.AjaxCallEmpDesignationMaster();
        });

        $('#DeleteEmpDesignationMasterRecord').on("click", function () {

            EmpDesignationMaster.ActionName = "Delete";
            EmpDesignationMaster.AjaxCallEmpDesignationMaster();
        });


        $('#DesignationLevel ').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);

        });
        $('#Grade').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);

        });
        $('#Description').on("keydown", function (e) {
            AERPValidation.AllowAlphaNumericOnly(e);

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
             url: '/EmpDesignationMaster/List',
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
            url: '/EmpDesignationMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmpDesignationMaster: function () {
        var EmpDesignationMasterData = null;
        if (EmpDesignationMaster.ActionName == "Create") {
            $("#FormCreateEmpDesignationMaster").validate();
            if ($("#FormCreateEmpDesignationMaster").valid()) {
                EmpDesignationMasterData = null;
                EmpDesignationMasterData = EmpDesignationMaster.GetEmpDesignationMaster();
                ajaxRequest.makeRequest("/EmpDesignationMaster/Create", "POST", EmpDesignationMasterData, EmpDesignationMaster.Success);
            }
        }
        else if (EmpDesignationMaster.ActionName == "Edit") {
            //debugger;
            $("#FormEditEmpDesignationMaster").validate();
            if ($("#FormEditEmpDesignationMaster").valid()) {
                EmpDesignationMasterData = null;
                EmpDesignationMasterData = EmpDesignationMaster.GetEmpDesignationMaster();
                ajaxRequest.makeRequest("/EmpDesignationMaster/Edit", "POST", EmpDesignationMasterData, EmpDesignationMaster.Success);
            }
        }
        else if (EmpDesignationMaster.ActionName == "Delete") {
            EmpDesignationMasterData = null;
            //$("#FormCreateEmpDesignationMaster").validate();
            EmpDesignationMasterData = EmpDesignationMaster.GetEmpDesignationMaster();
            ajaxRequest.makeRequest("/EmpDesignationMaster/Delete", "POST", EmpDesignationMasterData, EmpDesignationMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmpDesignationMaster: function () {
        var Data = {
        };
        if (EmpDesignationMaster.ActionName == "Create" || EmpDesignationMaster.ActionName == "Edit") {
            
            Data.ID = $('#ID').val();
            Data.Description = $('#Description').val();
            Data.DesignationLevel = $('#DesignationLevel').val();
            Data.Grade = $('#Grade').val();
            Data.ShortCode = $('#ShortCode').val();
            Data.EmpDesigType = $('#EmpDesignationType').val();
            Data.RelatedWith = $('#RelatedWith').val();
            //Data.IsActive = $("#IsActive:checked").val();
           // Data.IsActive = $('#IsActive:checked').val();
            //Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
            Data.IsActive = $('input[id=IsActive]:checked').val() ? true : false;

            // Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
            //Data.IsActive = $("input[id=IsActive]:checked").val();
        }
        else if (EmpDesignationMaster.ActionName == "Delete") {
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
            EmpDesignationMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },


};

