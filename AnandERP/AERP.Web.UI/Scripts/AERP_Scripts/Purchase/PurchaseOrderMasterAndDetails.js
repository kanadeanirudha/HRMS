//this class contain methods related to nationality functionality
var PurchaseOrderMasterAndDetails = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        PurchaseOrderMasterAndDetails.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#contactPerson").hide();
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        $('#PurchaseOrderDate').datetimepicker({
            format: 'DD MMMM YYYY'
        });

        $("#PurchaseOrderDate").on("keydown", function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode != 9) {
                return false;
            }
        })
        $("#btnShowList").unbind("click").on("click", function () {
            PurchaseOrderMasterAndDetails.LoadListByPurchaseOrderType($('#PurchaseOrderType :selected').val(), $('#PurchaseOrderDate').val());
        });
        // Create new record
        $('#CreatePurchaseOrderMasterAndDetailsRecord').on("click", function () {
            if ($('input[name=PurchaseRequisitionMasterID]').val() != 0) {               
                PurchaseOrderMasterAndDetails.ActionName = "Create";
                PurchaseOrderMasterAndDetails.AjaxCallPurchaseOrderMasterAndDetails();
            }
        });


        $('#ExpectedBillingAmount').keydown(function (e) {
            AERPValidation.NotAllowSpaces(e);
            AERPValidation.AllowNumbersOnly(e);
        });

        $("#AccountName").on("change", function (e) {
            
            if ($(this).val() != "") {
                $("#contactPerson").show();
            }
            else {
                $("#contactPerson").hide();
            }
        });

        //$("#AccountName").on("keydown keyup", function (e) {
        //    
        //    var inputKeyCode = e.keyCode ? e.keyCode : e.which;
        //    alert(inputKeyCode);
        //});

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
             url: '/PurchaseOrderMasterAndDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {        
        var PurchaseOrderType = $('#PurchaseOrderType :selected').val();        
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, PurchaseOrderType: PurchaseOrderType },
            url: '/PurchaseOrderMasterAndDetails/List',
            success: function (data) {
                //Rebind Grid Data            
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
               

               //$.ajax(
               //{
               //    cache: false,
               //    type: "POST",
               //    dataType: "html",
               //    data: {ID:PurchaseOrderID},
               //    url: '/PurchaseOrderMasterAndDetails/Download',
               //});
            }
        });
    },

    LoadListByPurchaseOrderType: function (PurchaseOrderType, PurchaseOrderDate) {
        debugger;
             $.ajax(
          {
              cache: false,
              type: "POST",
              data: { PurchaseOrderType: PurchaseOrderType, PurchaseOrderDate: PurchaseOrderDate },
              dataType: "html",
              url: '/PurchaseOrderMasterAndDetails/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
              }
          });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallPurchaseOrderMasterAndDetails: function () {
        var PurchaseOrderMasterAndDetailsData = null;
        if (PurchaseOrderMasterAndDetails.ActionName == "Create") {
            
            $("#FormCreatePurchaseOrderMasterAndDetails").validate();
            if ($("#FormCreatePurchaseOrderMasterAndDetails").valid()) {
                PurchaseOrderMasterAndDetailsData = null;
                PurchaseOrderMasterAndDetailsData = PurchaseOrderMasterAndDetails.GetPurchaseOrderMasterAndDetails();
                ajaxRequest.makeRequest("/PurchaseOrderMasterAndDetails/Create", "POST", PurchaseOrderMasterAndDetailsData, PurchaseOrderMasterAndDetails.Success, "CreatePurchaseOrderMasterAndDetailsRecord");
            }


        }
        else if (PurchaseOrderMasterAndDetails.ActionName == "Edit") {
            $("#FormEditPurchaseOrderMasterAndDetails").validate();
            if ($("#FormEditPurchaseOrderMasterAndDetails").valid()) {
                PurchaseOrderMasterAndDetailsData = null;

                PurchaseOrderMasterAndDetailsData = PurchaseOrderMasterAndDetails.GetPurchaseOrderMasterAndDetails();

                ajaxRequest.makeRequest("/PurchaseOrderMasterAndDetails/Edit", "POST", PurchaseOrderMasterAndDetailsData, PurchaseOrderMasterAndDetails.Success);

            }
        }
        else if (PurchaseOrderMasterAndDetails.ActionName == "Delete") {
            PurchaseOrderMasterAndDetailsData = null;
            //$("#FormCreatePurchaseOrderMasterAndDetails").validate();
            PurchaseOrderMasterAndDetailsData = PurchaseOrderMasterAndDetails.GetPurchaseOrderMasterAndDetails();
            ajaxRequest.makeRequest("/PurchaseOrderMasterAndDetails/Delete", "POST", PurchaseOrderMasterAndDetailsData, PurchaseOrderMasterAndDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetPurchaseOrderMasterAndDetails: function () {

        var Data = {
        };
        if (PurchaseOrderMasterAndDetails.ActionName == "Create") {
            Data.PurchaseRequisitionMasterID = $('input[name=PurchaseRequisitionMasterID]').val();
            Data.VendorID = $('input[name=VendorID]').val();
            Data.PurchaseOrderType = $('input[name=PurchaseOrderType]').val();
            Data.Freight = $('#Freight').val();
            Data.TotalTaxAmount = $('#TotalTaxAmount').val();
            Data.Discount = $('#Discount').val();
            Data.ShippingHandling = $('#ShippingHandling').val();
        }
       
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {       
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            
            window.location = "PurchaseOrderMasterAndDetails/Download/" + splitData[3];
            PurchaseOrderMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

