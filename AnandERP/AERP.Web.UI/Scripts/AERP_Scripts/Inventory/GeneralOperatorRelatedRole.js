//this class contain methods related to nationality functionality
var GeneralOperatorRelatedRole = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        var selectCentreCode = null;
        GeneralOperatorRelatedRole.constructor();
        //GeneralOperatorRelatedRole.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $('#InventoryLocationMasterID').on("change", function () {
            $('#DivCreateNew').hide(true);
            $('#myDataTable').html("");
            // $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

           
            if ($("#InventoryLocationMasterID").val() == "") {
                $("#divAddbtn").hide();
            }
            else {
               // $("#divAddbtn").show();
            }

        });
        // Create new record
        $('#CreateGeneralOperatorRelatedRoleRecord').on("click", function () {
            GeneralOperatorRelatedRole.ActionName = "Create";
            GeneralOperatorRelatedRole.AjaxCallGeneralOperatorRelatedRole();
        });

        $('#EditGeneralOperatorRelatedRoleRecord').on("click", function () {

            GeneralOperatorRelatedRole.ActionName = "Edit";
            GeneralOperatorRelatedRole.AjaxCallGeneralOperatorRelatedRole();
        });

        $("#btnShowList").on("click", function () {

            var valuCentreCode = $('#InventoryLocationMasterID :selected').val();

            if (valuCentreCode != "") {
                GeneralOperatorRelatedRole.LoadList(valuCentreCode);
                $("#divAddbtn").show();
            }
            else if (valuCentreCode == "") {
                notify("Please select Centre", 'warning');
                $('#divAddbtn').hide(true);
            }

        });
        InitAnimatedBorder();

        CloseAlert();


    },
    //LoadList method is used to load List page
    LoadList: function (SelectedCentreCode) {
        debugger
        $.ajax(

         {

             cache: false,
             type: "Get",
             data: { centerCode: SelectedCentreCode },
             dataType: "html",
             url: '/GeneralOperatorRelatedRole/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

                 if ($('#InventoryLocationMasterID :selected').val() == "") {

                     $("#divAddbtn").hide();
                 }
                 else {
                     $("#divAddbtn").show();
                 }

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
            data: { centerCode: $("#InventoryLocationMasterID").val(), actionMode: actionMode },
            url: '/GeneralOperatorRelatedRole/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                if ($('#InventoryLocationMasterID :selected').val() == "") {

                    $("#divAddbtn").hide();
                }
                else {
                    $("#divAddbtn").show();
                }
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralOperatorRelatedRole: function () {
        var GeneralOperatorRelatedRoleData = null;

        if (GeneralOperatorRelatedRole.ActionName == "Create") {
            $("#FormCreateGeneralOperatorRelatedRole").validate();
            if ($("#FormCreateGeneralOperatorRelatedRole").valid()) {
                GeneralOperatorRelatedRoleData = null;
                GeneralOperatorRelatedRoleData = GeneralOperatorRelatedRole.GetGeneralOperatorRelatedRole();
                ajaxRequest.makeRequest("/GeneralOperatorRelatedRole/Create", "POST", GeneralOperatorRelatedRoleData, GeneralOperatorRelatedRole.Success, "CreateGeneralOperatorRelatedRoleRecord");
            }
        }
        else if (GeneralOperatorRelatedRole.ActionName == "Edit") {
            $("#FormEditGeneralOperatorRelatedRole").validate();
            if ($("#FormEditGeneralOperatorRelatedRole").valid()) {
                GeneralOperatorRelatedRoleData = null;
                GeneralOperatorRelatedRoleData = GeneralOperatorRelatedRole.GetGeneralOperatorRelatedRole();
                ajaxRequest.makeRequest("/GeneralOperatorRelatedRole/Edit", "POST", GeneralOperatorRelatedRoleData, GeneralOperatorRelatedRole.Success);
            }
        }      
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralOperatorRelatedRole: function () {
        var Data = {
        };
        if (GeneralOperatorRelatedRole.ActionName == "Create") {
            Data.AdminRoleMasterID = $('#AdminRoleMasterID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.IsActive = $('#IsActive').val();
            selectCentreCode = $("#InventoryLocationMasterID").val();
        }
        else if (GeneralOperatorRelatedRole.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            GeneralOperatorRelatedRole.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};

