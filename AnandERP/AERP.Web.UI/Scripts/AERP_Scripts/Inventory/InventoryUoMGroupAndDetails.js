//this class contain methods related to nationality functionality
var InventoryUoMGroupAndDetails = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryUoMGroupAndDetails.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });



        // Create new record
        $('#CreateCreateInventoryUoMGroupRecord').on("click", function () {
            debugger
            debugger;

            InventoryUoMGroupAndDetails.ActionName = "CreateGroup";
            InventoryUoMGroupAndDetails.AjaxCallInventoryUoMGroupAndDetails();


        });
        $('#CreateInventoryUoMGroupAndDetailsRecord').on("click", function () {
           
           
            InventoryUoMGroupAndDetails.ActionName = "CreateGroupDetails";
            if ($('#AlternativeUomName').val() == "" || $('#AlternativeUomName').val() == null) {
                $("#displayErrorMessage p").text("Please enter Alternative Uom Name").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $('#AlternativeUomName').focus();
                return false;
            }
            else if ($('#AlternativeUomCode').val() == "" || $('#AlternativeUomCode').val() == null) {
                $("#displayErrorMessage p").text("Please enter Alternative Uom Code").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $('#AlternativeUomCode').focus();
               
                return false;
            }
            else if ($("#AlternativeQuantity").val() == 0 || $("#AlternativeQuantity").val() == null) {
                $("#displayErrorMessage p").text("Please select Alternative Quantity").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $('#AlternativeQuantity').focus();
                return false;
            }
            else if ($("#BaseUoMQuantity").val() == 0 || $("#BaseUoMQuantity").val() == null) {
                $("#displayErrorMessage p").text("Please select Base UoM Quantity").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $('#BaseUoMQuantity').focus();
                return false;
            }
            else if ($('#UsedFor').val() == "" || $('#UsedFor').val() == null) {
                $("#displayErrorMessage p").text("Please enter Used For").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $('#UsedFor').focus();
                return false;
            }
            InventoryUoMGroupAndDetails.AjaxCallInventoryUoMGroupAndDetails();

            //InventoryUoMGroupAndDetailsData = null;
            //InventoryUoMGroupAndDetailsData = InventoryUoMGroupAndDetails.GetInventoryUoMGroupAndDetails();

            //ajaxRequest.makeRequest("/InventoryUoMGroupAndDetails/CreateGroupDetails", "POST", InventoryUoMGroupAndDetailsData, InventoryUoMGroupAndDetails.SuccessDetails, "CreateInventoryUoMGroupAndDetailsRecord");

        });

        $('#EditInventoryUoMGroupAndDetailsRecord').on("click", function () {
            InventoryUoMGroupAndDetails.ActionName = "Edit";
            InventoryUoMGroupAndDetails.AjaxCallInventoryUoMGroupAndDetails();
        });

        $('#DeleteInventoryUoMGroupAndDetailsRecord').on("click", function () {

            InventoryUoMGroupAndDetails.ActionName = "Delete";
            InventoryUoMGroupAndDetails.AjaxCallInventoryUoMGroupAndDetails();
        });


        $("#GroupDescription").on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        InitAnimatedBorder();

        CloseAlert();

    },



    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",
             //  data: { centerCode: SelectedCentreCode, departmentID: selectedVal },
             dataType: "html",
             url: '/InventoryUoMGroupAndDetails/List',
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
            url: '/InventoryUoMGroupAndDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    //ReloadList method is used to load List page
    ReloadList1: function (message, colorCode, actionMode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/InventoryUoMGroupAndDetails/List',
            success: function (data) {
                //Rebind Grid Data
               //s $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallInventoryUoMGroupAndDetails: function () {
        var InventoryUoMGroupAndDetailsData = null;
        if (InventoryUoMGroupAndDetails.ActionName == "CreateGroupDetails") {
            $("#FormCreateInventoryUoMGroupAndDetail").validate();
            if ($("#FormCreateInventoryUoMGroupAndDetail").valid()) {
                InventoryUoMGroupAndDetailsData = null;
                InventoryUoMGroupAndDetailsData = InventoryUoMGroupAndDetails.GetInventoryUoMGroupAndDetails();

                ajaxRequest.makeRequest("/InventoryUoMGroupAndDetails/CreateGroupDetails", "POST", InventoryUoMGroupAndDetailsData, InventoryUoMGroupAndDetails.SuccessDetails, "CreateInventoryUoMGroupAndDetailsRecord");
            }


        }
        else if (InventoryUoMGroupAndDetails.ActionName == "CreateGroup") {
            debugger;
            debugger;
            $("#FormCreateInventoryUoMGroup").validate();
            if ($("#FormCreateInventoryUoMGroup").valid()) {
                InventoryUoMGroupAndDetailsData = null;
                InventoryUoMGroupAndDetailsData = InventoryUoMGroupAndDetails.GetInventoryUoMGroupAndDetails();

                ajaxRequest.makeRequest("/InventoryUoMGroupAndDetails/CreateGroup", "POST", InventoryUoMGroupAndDetailsData, InventoryUoMGroupAndDetails.Success, "CreateCreateInventoryUoMGroupRecord");
            }


        }
        else if (InventoryUoMGroupAndDetails.ActionName == "Edit") {
            $("#FormCreateInventoryUoMGroupAndDetail").validate();
            if ($("#FormCreateInventoryUoMGroupAndDetail").valid()) {
                InventoryUoMGroupAndDetailsData = null;

                InventoryUoMGroupAndDetailsData = InventoryUoMGroupAndDetails.GetInventoryUoMGroupAndDetails();

                ajaxRequest.makeRequest("/InventoryUoMGroupAndDetails/Edit", "POST", InventoryUoMGroupAndDetailsData, InventoryUoMGroupAndDetails.Success);

            }
        }
        else if (InventoryUoMGroupAndDetails.ActionName == "Delete") {
            InventoryUoMGroupAndDetailsData = null;
            //$("#FormCreateInventoryUoMGroupAndDetails").validate();
            InventoryUoMGroupAndDetailsData = InventoryUoMGroupAndDetails.GetInventoryUoMGroupAndDetails();
            ajaxRequest.makeRequest("/InventoryUoMGroupAndDetails/Delete", "POST", InventoryUoMGroupAndDetailsData, InventoryUoMGroupAndDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryUoMGroupAndDetails: function () {

        var Data = {
        };
        if (InventoryUoMGroupAndDetails.ActionName == "Edit" || InventoryUoMGroupAndDetails.ActionName == "CreateGroup") {

            Data.GroupCode = $('#GroupCode').val();
            Data.GroupDescription = $('#GroupDescription').val();
            Data.BaseUomCode = $('#BaseUomCode').val();
        }
        else if (InventoryUoMGroupAndDetails.ActionName == "CreateGroupDetails") {

            debugger;
            debugger;
            Data.AlternativeUomName = $('#AlternativeUomName').val();
            Data.AlternativeUomCode = $('#AlternativeUomCode').val();
            Data.AlternativeQuantity = $('#AlternativeQuantity').val();
            Data.BaseUomCode = $('#BaseUomCode').val();
            Data.BaseUoMQuantity = $('#BaseUoMQuantity').val();
            Data.BasePriceReducedBy = $('#BasePriceReducedBy').val();
            Data.UsedFor = $('#UsedFor').val();
            Data.GroupCode = $('#GroupCode').val();
            Data.InventoryUoMGroupID = $('input[name=InventoryUoMGroupID]').val();

        }
        else if (InventoryUoMGroupAndDetails.ActionName == "Delete") {
            Data.InventoryUoMGroupAndDetailsID = $('input[name=InventoryUoMGroupAndDetailsID]').val();

        }
        return Data;
    },





    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            InventoryUoMGroupAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
    SuccessDetails: function (data) {
        debugger;
        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
           // $.magnificPopup.close()
            
            $("#tblData tbody").append(
              "<tr>" +
             //"<td><input id='AlternativeUomName' type='hidden' value=" + $('#AlternativeUomName').val() + "/>" + $('#AlternativeUomName').val() + "</td>" +
              "<td><input id='AlternativeQuantity' type='hidden' value=" + $('#AlternativeQuantity').val() + "/>" + parseFloat($('#AlternativeQuantity').val()).toFixed(2) + "</td>" +
              "<td><input id='AlternativeUomCode' type='hidden' value=" + $('#AlternativeUomCode').val() + "/>" + $('#AlternativeUomCode').val() + "</td>" +
              "<td> = </td>" +
             "<td><input id='BaseUoMQuantity' type='hidden' value=" + $('#BaseUoMQuantity').val() + "/>" + parseFloat($('#BaseUoMQuantity').val()).toFixed(2) + "</td>" +
              "<td><input id='BaseUomCode' type='hidden' value=" + $('#BaseUomCode').val() + "/>" + $('#BaseUomCode').val() + "</td>" +
              
              //"<td><input id='BasePriceReducedBy' type='hidden' value=" + $('#BasePriceReducedBy').val() + "/>" + $('#BasePriceReducedBy').val() + "</td>" +
              //"<td><input id='UsedFor' type='hidden' value=" + $('#UsedFor').val() + "/>" + $('#UsedFor').val() + "</td>" +
             
    "</tr>");
            $("#AlternativeUomName").val("");
            $("#AlternativeUomCode").val("");
            $("#AlternativeQuantity").val(0);
            $("#BaseUomCode").val("");
            $("#BaseUoMQuantity").val(0);
            $("#BasePriceReducedBy").val("");
            $("#UsedFor").val(" ");

            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            //InventoryUoMGroupAndDetails.ReloadList1(splitData[0], splitData[1], splitData[2]);
            //InventoryUoMGroupAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
            ListViewReload();
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};


