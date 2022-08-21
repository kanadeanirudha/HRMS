//this class contain methods related to nationality functionality
var SalePromotionPlanAndDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SalePromotionPlanAndDetails.constructor();
        //SalePromotionPlanAndDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GroupDescription').focus();
            return false;
        });
        // Create new record

        $('#CreateSalePromotionPlanAndDetailsRecord').on("click", function () {
            debugger
            SalePromotionPlanAndDetails.ActionName = "Create";
            SalePromotionPlanAndDetails.AjaxCallSalePromotionPlanAndDetails();
        });
        $('#CreateSalePromotionPlanAndDetailsRulesRecord').on("click", function () {
            debugger
            SalePromotionPlanAndDetails.ActionName = "CreateSalePromotionPlanAndDetails";
            if ($('#PlanTypeCode').val() == 'PriceDiscountOnFixAmount')
            {
                if (parseFloat($("#BillAmountRangeFrom").val()) > parseFloat($("#BillAmountRangeUpto").val()))
                {
                    $("#displayErrorMessage123").text("Please Enter Greater Upto Range Amount Than From Range.").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                    $("#displayErrorMessage123").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }
                else if (parseFloat($("#BillDiscountAmount").val()) > 100) {
                    $("#displayErrorMessage123").text("Please Enter Discount Amount Less Than 100.").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                    $("#displayErrorMessage123").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }
                else if (parseFloat($("#BillAmountRangeFrom").val()) == 0 || $("#BillAmountRangeFrom").val() == null) {
                    $("#displayErrorMessage123").text("Please Enter Range From Amount.").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                    $("#displayErrorMessage123").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }
                else if (parseFloat($("#BillAmountRangeUpto").val()) == 0 || $("#BillAmountRangeUpto").val() == null) {
                    $("#displayErrorMessage123").text("Please Enter Range Upto Amount.").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                    $("#displayErrorMessage123").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }
                else if (parseFloat($("#BillDiscountAmount").val()) == 0 || parseFloat($("#BillDiscountAmount").val()) == null) {
                    $("#displayErrorMessage123").text("Please Enter Bill Discount Amount.").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                    $("#displayErrorMessage123").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }
            }
            if ($('#PlanTypeCode').val() == 'ProductConcessionFree') {
                debugger
                if (parseFloat($("#HowManyQtyToBuy").val()) == 0) {
                    $("#displayErrorMessage123").text("Please Enter How Many Quantity To Buy.").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                    $("#displayErrorMessage123").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }
                else if (parseFloat($("#GiftItemQty").val()) == 0) {
                    $("#displayErrorMessage123").text("Please Enter Gift Item Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                    $("#displayErrorMessage123").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }
            
            SalePromotionPlanAndDetails.AjaxCallSalePromotionPlanAndDetails();
            }
            else {
               
                SalePromotionPlanAndDetails.AjaxCallSalePromotionPlanAndDetails();
        }

        });

        $('#EditSalePromotionPlanAndDetailsRecord').on("click", function () {

            SalePromotionPlanAndDetails.ActionName = "Edit";
            SalePromotionPlanAndDetails.AjaxCallSalePromotionPlanAndDetails();
        });
        $('#DeleteSalePromotionPlanAndDetailsRecord').on("click", function () {

            SalePromotionPlanAndDetails.ActionName = "Delete";
            SalePromotionPlanAndDetails.AjaxCallSalePromotionPlanAndDetails();
        });

        $('#BillDiscountAmount').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#BillAmountRangeUpto').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#BillAmountRangeFrom').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#HowManyQtyToBuy').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#GiftItemQty').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#HowManyQtyToBuy').on("keyup", function (e) {
            var a = $("#HowManyQtyToBuy").val();
            var b = $("#GiftItemQty").val();
            var textA = "Buy " + a + " Get " + b + " Free";
            $("#PlanDescription").val(textA);
        });
        $('#GiftItemQty').on("keyup", function (e) {
            var a = $("#HowManyQtyToBuy").val();
            var b = $("#GiftItemQty").val();
            var textA = "Buy " + a + " Get " + b + " Free";
            $("#PlanDescription").val(textA);
        });
        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AMSValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AMSValidation.AllowCharacterOnly(e);
        //  if (e.keyCode == 32) {
        //       return false;
        // }
        // });
        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").dataTable();
        //    oTable.fnFilter(this.value);
        //});

        //$("#searchBtn").click(function () {
        //    $("#UserSearch").focus();
        //});


        //$("#showrecord").change(function () {
        //    var showRecord = $("#showrecord").val();
        //    $("select[name*='myDataTable_length']").val(showRecord);
        //    $("select[name*='myDataTable_length']").change();
        //});

        // $(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function () {
        debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/SalePromotionPlanAndDetails/List',
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
            url: '/SalePromotionPlanAndDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallSalePromotionPlanAndDetails: function () {
        var SalePromotionPlanAndDetailsData = null;

        if (SalePromotionPlanAndDetails.ActionName == "Create") {
            debugger;
            $("#FormCreateSalePromotionPlanAndDetails").validate();
            if ($("#FormCreateSalePromotionPlanAndDetails").valid()) {
                SalePromotionPlanAndDetailsData = null;
                SalePromotionPlanAndDetailsData = SalePromotionPlanAndDetails.GetSalePromotionPlanAndDetails();
                ajaxRequest.makeRequest("/SalePromotionPlanAndDetails/Create", "POST", SalePromotionPlanAndDetailsData, SalePromotionPlanAndDetails.Success, "CreateSalePromotionPlanAndDetailsRecord");
            }
        }
        else if (SalePromotionPlanAndDetails.ActionName == "CreateSalePromotionPlanAndDetails") {
            debugger;
            debugger;
            $("#FormCreateSalePromotionPlanAndDetails").validate();
            if ($("#FormCreateSalePromotionPlanAndDetails").valid()) {
                SalePromotionPlanAndDetailsData = null;
                SalePromotionPlanAndDetailsData = SalePromotionPlanAndDetails.GetSalePromotionPlanAndDetails();
                ajaxRequest.makeRequest("/SalePromotionPlanAndDetails/CreateSalePromotionAndDetails", "POST", SalePromotionPlanAndDetailsData, SalePromotionPlanAndDetails.PlanDetailSuccess, "CreateSalePromotionPlanAndDetailsRulesRecord");
            }
        }
        else if (SalePromotionPlanAndDetails.ActionName == "Edit") {
            $("#FormEditSalePromotionPlanAndDetails").validate();
            if ($("#FormEditSalePromotionPlanAndDetails").valid()) {
                SalePromotionPlanAndDetailsData = null;
                SalePromotionPlanAndDetailsData = SalePromotionPlanAndDetails.GetSalePromotionPlanAndDetails();
                ajaxRequest.makeRequest("/SalePromotionPlanAndDetails/Edit", "POST", SalePromotionPlanAndDetailsData, SalePromotionPlanAndDetails.Success, "EditSalePromotionPlanAndDetailsRecord");
            }
        }
        else if (SalePromotionPlanAndDetails.ActionName == "Delete") {

            SalePromotionPlanAndDetailsData = null;
            //$("#FormCreateSalePromotionPlanAndDetails").validate();
            SalePromotionPlanAndDetailsData = SalePromotionPlanAndDetails.GetSalePromotionPlanAndDetails();
            ajaxRequest.makeRequest("/SalePromotionPlanAndDetails/Delete", "POST", SalePromotionPlanAndDetailsData, SalePromotionPlanAndDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalePromotionPlanAndDetails: function () {
        var Data = {
        };

        if (SalePromotionPlanAndDetails.ActionName == "Create" || SalePromotionPlanAndDetails.ActionName == "Edit" || SalePromotionPlanAndDetails.ActionName =="CreateSalePromotionPlanAndDetails") {
            Data.ID = $('#ID').val();
            Data.SalePromotionPlanID = $('#SalePromotionPlanID').val();
            Data.PlanTypeName = $('#PlanTypeName').val();
            Data.PlanTypeCode = $('#PlanTypeCode').val();
            Data.HowManyQtyToBuy = $('#HowManyQtyToBuy').val();
            Data.GiftItemQty = $('#GiftItemQty').val();
            Data.DiscountInPercent = $('#DiscountInPercent').val();
            Data.IsSampling = $('#IsSampling').is(":checked") ? "true" : "false";
            Data.BillAmountRangeFrom = $('#BillAmountRangeFrom').val();
            Data.BillAmountRangeUpto = $('#BillAmountRangeUpto').val();
            Data.BillDiscountAmount = $('#BillDiscountAmount').val();
            Data.IsPercentage = $('#IsPercentage').is(":checked") ? "true" : "false";
            Data.IsItemWiseDiscountExclude = $('#IsItemWiseDiscountExclude').is(":checked") ? "true" : "false";
            Data.PlanDescription = $('#PlanDescription').val();
        }
        else if (SalePromotionPlanAndDetails.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            SalePromotionPlanAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
    //this is used to for showing successfully record creation message and reload the list view
    PlanDetailSuccess: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            SalePromotionPlanAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage123 p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

