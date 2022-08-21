//this class contain methods related to nationality functionality
var PurchaseReplenishment = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        PurchaseReplenishment.constructor();
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

        $('#btnShowList').unbind('click').click(function () {
            debugger;
            var valuGeneralUnitsID = $('#GeneralUnitsID :selected').val();
            var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
            if (SelectedCentreCode == "") {
                notify("Please select centre", 'warning');
            }
            else if (valuGeneralUnitsID == "") {

                notify("Please select store", 'warning');
            }
            else {
                PurchaseReplenishment.LoadList(valuGeneralUnitsID);
            }

        });

        //$("#GeneralUnitsID").change(function () {
        //    debugger;
        //    PurchaseReplenishment.LoadList();

        //});
        $("#GeneralUnitsID").change(function () {
            var GeneralUnitsId = $("#GeneralUnitsID").val();
            if (GeneralUnitsId == "")
            {
                $("#abc").hide();
            }
        });
        $("#SelectedCentreCode").change(function () {
            debugger;
            var selectedItem = [];
            var selectedItem = $(this).val();
            var abc = selectedItem.split(':');
            var selectedcentrecode = abc[0];
            var $ddlGeneralUnitsID = $("#GeneralUnitsID");
            var $GeneralUnitsIDProgress = $("#GeneralUnitsID-loading-progress");
            $GeneralUnitsIDProgress.show();
            if ($("#SelectedCentreCode").val() !== "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: '/Replenishment/GetGeneralUnitsForItemmasterList',
                    data: { "CentreCode": selectedcentrecode },
                    success: function (data) {
                        $ddlGeneralUnitsID.html('');
                        $ddlGeneralUnitsID.append('<option value="">-------Select Unit------</option>');
                        $.each(data, function (id, option) {

                            $ddlGeneralUnitsID.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $GeneralUnitsIDProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve GeneralUnitsID.');
                        $GeneralUnitsIDProgress.hide();
                    }
                });
            }
            else {
                $('#GeneralUnitsID').find('option').remove().end().append('<option value>-------Select General Unit------</option>');
                $("#abc").hide();
            }

        });


        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });


        // Create new record
        $('#CreatePurchaseReplenishmentRecord').on("click", function () {

            PurchaseReplenishment.ActionName = "Create";
            PurchaseReplenishment.AjaxCallPurchaseReplenishment();
        });


        $('#EditPurchaseReplenishmentRecord').on("click", function () {
            PurchaseReplenishment.ActionName = "Edit";
            PurchaseReplenishment.AjaxCallPurchaseReplenishment();
        });

        $('#DeletePurchaseReplenishmentRecord').on("click", function () {

            PurchaseReplenishment.ActionName = "Delete";
            PurchaseReplenishment.AjaxCallPurchaseReplenishment();
        });


        $('#LocationName').on("keydown", function (e) {
            AERPValidation.AlphaNumericOnly(e);

        });


        InitAnimatedBorder();

        CloseAlert();

    },

    //LoadList method is used to load List page
    LoadList: function (GeneralUnitsID) {
        var GeneralUnitsID = $('#GeneralUnitsID').val();
        $.ajax(

         {
             cache: false,
             type: "Get",
             data: { GeneralUnitsID: GeneralUnitsID },
             dataType: "html",
             url: '/Replenishment/List',
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
            url: '/Replenishment/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallPurchaseReplenishment: function () {
        var PurchaseReplenishmentData = null;
        if (PurchaseReplenishment.ActionName == "Create") {
            $("#FormCreatePurchaseReplenishment").validate();
            if ($("#FormCreatePurchaseReplenishment").valid()) {
                PurchaseReplenishmentData = null;
                PurchaseReplenishmentData = PurchaseReplenishment.GetPurchaseReplenishment();

                ajaxRequest.makeRequest("/PurchaseReplenishment/Create", "POST", PurchaseReplenishmentData, PurchaseReplenishment.Success, "CreatePurchaseReplenishmentRecord");
            }


        }
        else if (PurchaseReplenishment.ActionName == "Edit") {
            $("#FormEditPurchaseReplenishment").validate();
            if ($("#FormEditPurchaseReplenishment").valid()) {
                PurchaseReplenishmentData = null;

                PurchaseReplenishmentData = PurchaseReplenishment.GetPurchaseReplenishment();

                ajaxRequest.makeRequest("/PurchaseReplenishment/Edit", "POST", PurchaseReplenishmentData, PurchaseReplenishment.Success);

            }
        }
        else if (PurchaseReplenishment.ActionName == "Delete") {
            PurchaseReplenishmentData = null;
            //$("#FormCreatePurchaseReplenishment").validate();
            PurchaseReplenishmentData = PurchaseReplenishment.GetPurchaseReplenishment();
            ajaxRequest.makeRequest("/PurchaseReplenishment/Delete", "POST", PurchaseReplenishmentData, PurchaseReplenishment.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetPurchaseReplenishment: function () {

        var Data = {
        };
        if (PurchaseReplenishment.ActionName == "Create" || PurchaseReplenishment.ActionName == "Edit") {

            Data.ID = $("input[id=ID]").val();
            Data.LocationName = $('#LocationName').val();
            Data.SelectedCentreCode = $("#InventoryLocationMasterID :selected").val();
        }
        else if (PurchaseReplenishment.ActionName == "Delete") {
            Data.PurchaseReplenishmentID = $('input[name=PurchaseReplenishmentID]').val();

        }
        return Data;
    },




    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            PurchaseReplenishment.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};
