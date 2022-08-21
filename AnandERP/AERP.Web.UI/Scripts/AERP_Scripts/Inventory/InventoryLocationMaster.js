//this class contain methods related to nationality functionality
var InventoryLocationMaster = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryLocationMaster.constructor();
        //generalCountryMaster.initializeValidation();
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
                $("#divAddbtn").show();
            }

          


        });

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        $("#btnShowList").on("click", function () {
           
            var valuCentreCode = $('#InventoryLocationMasterID :selected').val();
           
            if (valuCentreCode != "") {
                InventoryLocationMaster.LoadList(valuCentreCode);
                $("#divAddbtn").show();
            }
            else if (valuCentreCode == "") {
                notify("Please select Centre", 'warning');
                $('#divAddbtn').hide(true);
            }

        });
        
       
        // Create new record
        $('#CreateInventoryLocationMasterRecord').on("click", function () {
          
            InventoryLocationMaster.ActionName = "Create";
            InventoryLocationMaster.AjaxCallInventoryLocationMaster();
        });


        $('#EditInventoryLocationMasterRecord').on("click", function () {
            InventoryLocationMaster.ActionName = "Edit";
            InventoryLocationMaster.AjaxCallInventoryLocationMaster();
        });

        $('#DeleteInventoryLocationMasterRecord').on("click", function () {

            InventoryLocationMaster.ActionName = "Delete";
            InventoryLocationMaster.AjaxCallInventoryLocationMaster();
        });


        $('#LocationName').on("keydown", function (e) {
            AERPValidation.AlphaNumericOnly(e);

        });


        InitAnimatedBorder();

        CloseAlert();

    },



    
    //LoadList method is used to load List page
    LoadList: function (SelectedCentreCode) {
        $.ajax(

         {

             cache: false,
             type: "Get",
             data: { centerCode: SelectedCentreCode },
             dataType: "html",
             url: '/InventoryLocationMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

                 if ($('#InventoryLocationMasterID :selected').val() == "") {
                   
                     $("#divAddbtn").hide();
                 }
                 else {
                     $("#divAddbtn").show();
                 }

                 //$("#divAddbtn").show();
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
            url: '/InventoryLocationMaster/List',
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
    AjaxCallInventoryLocationMaster: function () {
        var InventoryLocationMasterData = null;
        if (InventoryLocationMaster.ActionName == "Create") {
            $("#FormCreateInventoryLocationMaster").validate();
            if ($("#FormCreateInventoryLocationMaster").valid()) {
                InventoryLocationMasterData = null;
                InventoryLocationMasterData = InventoryLocationMaster.GetInventoryLocationMaster();

                ajaxRequest.makeRequest("/InventoryLocationMaster/Create", "POST", InventoryLocationMasterData, InventoryLocationMaster.Success, "CreateInventoryLocationMasterRecord");
            }


        }
        else if (InventoryLocationMaster.ActionName == "Edit") {
            $("#FormEditInventoryLocationMaster").validate();
            if ($("#FormEditInventoryLocationMaster").valid()) {
                InventoryLocationMasterData = null;

                InventoryLocationMasterData = InventoryLocationMaster.GetInventoryLocationMaster();

                ajaxRequest.makeRequest("/InventoryLocationMaster/Edit", "POST", InventoryLocationMasterData, InventoryLocationMaster.Success);

            }
        }
        else if (InventoryLocationMaster.ActionName == "Delete") {
            InventoryLocationMasterData = null;
            //$("#FormCreateInventoryLocationMaster").validate();
            InventoryLocationMasterData = InventoryLocationMaster.GetInventoryLocationMaster();
            ajaxRequest.makeRequest("/InventoryLocationMaster/Delete", "POST", InventoryLocationMasterData, InventoryLocationMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryLocationMaster: function () {

        var Data = {
        };
        if (InventoryLocationMaster.ActionName == "Create" || InventoryLocationMaster.ActionName == "Edit") {

            Data.ID = $("input[id=ID]").val();
            Data.LocationName = $('#LocationName').val();
            Data.SelectedCentreCode = $("#InventoryLocationMasterID :selected").val();
        }
        else if (InventoryLocationMaster.ActionName == "Delete") {
            Data.InventoryLocationMasterID = $('input[name=InventoryLocationMasterID]').val();

        }
        return Data;
    },




    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
      
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            InventoryLocationMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};
