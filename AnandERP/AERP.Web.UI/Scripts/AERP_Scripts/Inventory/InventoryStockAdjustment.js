//this class contain methods related to nationality functionality
var InventoryStockAdjustment = {
    //Member variables
    ActionName: null,
    XmlString: null,
    CurrentStockStatus: 0,

    //Class intialisation method
    Initialize: function () {
        InventoryStockAdjustment.constructor();
    },
    //Attach all event of page
    constructor: function () {

        $('#GroupDescription').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GroupDescription').focus();
            return false;
        });

        $("#CentreCode").change(function () {
            var selectedItem = [];
            var selectedItem = $(this).val();
            var abc = selectedItem.split(':');
            var selectedcentrecode = abc[0];
            var $ddlGeneralUnitsID = $("#GeneralUnitsID");
            var $GeneralUnitsIDProgress = $("#GeneralUnitsID-loading-progress");
            $GeneralUnitsIDProgress.show();
            if ($("#SelectedCentreCodeForSaleTab").val() !== "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: '/InventoryStockAdjustment/GetGeneralUnitsForItemmasterList',
                    data: { "centreCode": selectedcentrecode },
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
            }

        });

        //$("#CreateInventoryStockAdjustmentClear").on("click", function () {
        //    InventoryStockAdjustment.CurrentStockStatus = 0
        //    $("#tblData tr:not(:first)").remove();
        //});


        $("#Recipe").on("click", function () {
            debugger;
            if ($(this).is(":checked")) {
                window.location.href = '/InventoryStockAdjustment/RestaurantItemIndex';
            }
        });
        $("#Ingredient").on("click", function () {
            debugger;
            if ($(this).is(":checked")) {
                window.location.href = '/InventoryStockAdjustment/Index';
            }
        });
        $("#ItemName").on("keyup", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#ItemName").val("");
                $("#UOM").val("");
                $("#Quantity").val(0);
                $("#Convertion").val("");
                $("#TotalStock").val(0);
                $("#CorrectedStock").val(0);
                $("#UnrestrictedStock").val(0);
                $("#Action").val("");
                $("#LowerUom").val("");
                $('#ItemName').typeahead('val', '');
                $("#RecipeQuantity").val(0);
                $("#ActionStatus").val("");
                if ($("#Recipe :checked").val() == "true") {
                    $("#tblDataRecipe tr:not(:first)").remove();
                }
                $("#SerialAndBatchManagedBy").val(0);
                $(".checkall-user").prop("checked", false);
                $("#tblDataRecipe tr:not(:first)").remove();
            }
        });


        $("#Quantity").on("keyup", function () {

            // var conversion = ($("#Quantity").val() * $('#ConvFact').val())
            //var conversion = ($("#Quantity").val())

            //var abc1 = "(" + $('#Quantity').val() + "*" + $('#ConvFact').val() + ")" + ' ' + "=" + ' ' + parseFloat(conversion).toFixed(2) + ' ' + $('#LowerUom').val();

            //$("#Convertion").val(abc1);

            var TotalStock = $("#TotalStock").val();
            var Quantity = $("#Quantity").val();
            var Action = $("#Action :selected").val();

            if (Action == 4) {
                //var abc = parseFloat((parseFloat(TotalStock)) + (parseFloat(conversion))).toFixed(2);
                var abc = parseFloat((parseFloat(TotalStock)) + (parseFloat(Quantity))).toFixed(2);
                $("#UnrestrictedStock").val(abc);
                $("#CorrectedStock").val(parseFloat(Quantity).toFixed(2));// Change conversion to Qty
            }
            else {
                // var abc = parseFloat((parseFloat(TotalStock)) - (parseFloat(conversion))).toFixed(2);
                var abc = parseFloat((parseFloat(TotalStock)) - (parseFloat(Quantity))).toFixed(2);
                $("#UnrestrictedStock").val(abc);
                $("#CorrectedStock").val(parseFloat(-Quantity).toFixed(2));// Change conversion to Qty
            }
            if (Quantity == null || Quantity == "") {
                $("#UnrestrictedStock").val(0);
            }


        });

        $("#Action").on("change", function () {

            var conversion = ($("#Quantity").val() * $('#ConvFact').val())

            var TotalStock = $("#TotalStock").val();
            var Quantity = $("#Quantity").val();
            var Action = $("#Action :selected").val();
            if (Action == 4) {
                var abc = parseFloat((parseFloat(TotalStock)) + (parseFloat(Quantity))).toFixed(2);
                $("#UnrestrictedStock").val(abc);
                $("#CorrectedStock").val(parseFloat(Quantity).toFixed(2));
            }
            else {
                var abc = parseFloat((parseFloat(TotalStock)) - (parseFloat(Quantity))).toFixed(2);
                $("#UnrestrictedStock").val(abc);
                $("#CorrectedStock").val(parseFloat(-Quantity).toFixed(2));
            }

        });
        $('#Quantity').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#RecipeQuantity').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#GeneralUnitsID').on("change", function () {

            if (($(this).val())) {
                $('#ItemName').attr("disabled", false);
                $('#Quantity').attr("disabled", false);
                $('#Action').attr("disabled", false);

            }
            else {
                $('#ItemName').prop('disabled', true);
                $('#Quantity').attr("disabled", true);
                $('#Action').attr("disabled", true);
            }

            $('#ItemName').val("");
            $('#LowerUom').val("");
            $('#Quantity').val(0);
            $('#Action').val("");
            $('#TotalStock').val(0);
            $('#CorrectedStock').val(0);
            $('#UnrestrictedStock').val(0);
            $('#RecipeQuantity').val(0);
            $('#ActionStatus').val("");
            $("#tblData tr:not(:first)").remove();
            $(".checkall-user").prop("checked", false);
        });
        // Create new record
        //$('#RecipeQuantity').focusout(function () {
        $("#RecipeQuantity").on("change", function () {
            debugger;

            $('.IngridentQty').each(function () {

                var quantity = parseFloat($(this).prev().val());
                var RecipeQuantity = ($("#RecipeQuantity").val()) * quantity;
                var ConversionFactor = $(this).parent().next().next().next().next().next().next().children('input').val()
                var TotalStock = $(this).parent().next().next().children('input').val()
                $(this).val(parseFloat(RecipeQuantity));
                $(this).next('span').html(parseFloat(RecipeQuantity));
                var CorrectedStock = parseFloat(ConversionFactor) * parseFloat(RecipeQuantity);
                $(this).parent().next().next().next().next().children('span').html(-1 * CorrectedStock)
                $(this).parent().next().next().next().next().children().val(-1 * CorrectedStock)
                $(this).parent().next().next().next().next().next().children('input').val(TotalStock - CorrectedStock)
                $(this).parent().next().next().next().next().next().children('span').html(TotalStock - CorrectedStock)
            });
        });

        $('#CreateInventoryStockAdjustmentRecord').unbind("click").on("click", function () {
            debugger;

            InventoryStockAdjustment.ActionName = "Create";
            InventoryStockAdjustment.GetXmlData();
            InventoryStockAdjustment.StockAdjustmentForActionVoucherXML();
            if ($('#TransDate').val() == "" || $('#TransDate').val() ==null)
            {
                $("#displayErrorMessage p").text("Please enter Transaction Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;

            }
            if (InventoryStockAdjustment.XMLstring == "" || InventoryStockAdjustment.XMLstring == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                InventoryStockAdjustment.AjaxCallInventoryStockAdjustment();
                $('#GeneralUnitsID').val("");
                $('#CentreCode').val("");
                $('#CentreCode').attr("disabled", false);
                $('#GeneralUnitsID').attr("disabled", false);
                InventoryStockAdjustment.CurrentStockStatus= 0

            }
        });
        $('#CreateInventoryStockAdjustmentForRecipeItemRecord').unbind("click").on("click", function () {

            InventoryStockAdjustment.ActionName = "CreateRecipeItemRecord";
            InventoryStockAdjustment.GetXmlDataForRecipeItem();
            InventoryStockAdjustment.StockAdjustmentForActionVoucherXMLForRecipeItem();
            if (InventoryStockAdjustment.XMLstring == "" || InventoryStockAdjustment.XMLstring == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                InventoryStockAdjustment.AjaxCallInventoryStockAdjustment();
                $('#GeneralUnitsID').val("");
                $('#CentreCode').val("");
                $('#CentreCode').attr("disabled", false);
                $('#GeneralUnitsID').attr("disabled", false);
            }


        });
        $('#btnAdd').on("click", function () {

            InventoryStockAdjustment.ActionName = "CreatebtnAdd";

            var cnt = 0;
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 20) {
                if (DataArray[i + 2] == $('#ItemNumber').val() && DataArray[i + 10] == $('#Action :selected').val()) {
                    notify("You cannot enter same item.", "warning");
                    return false;
                }

            }

            if ($('#ItemName').val() == null || $('#ItemName').val() == "") {
                notify("Please Enter Item Description.", "warning")
                return false;
            }

            if ($('#Quantity').val() == 0 || $('#Quantity').val() == "" || $('#Quantity').val() == null) {
                notify("Please Enter Quantity.", "warning")
                return false;
            }
            else if ($('#Action').val() == "" || $('#Action').val() == null) {
                notify("Please Select Action.", "warning")
                return false;

            }
            else if ($('#SerialAndBatchManagedBy').val() == 2 && ($('#BatchNumber').val() == "" || $('#BatchNumber').val() == null)) {
                notify("Please Select Batch.", "warning")
                return false;

            }
            
              
            
            
            else {
                InventoryStockAdjustment.AjaxCallInventoryStockAdjustment();
            }

        });

        //$('#EditInventoryStockAdjustmentRecord').on("click", function () {

        //    InventoryStockAdjustment.ActionName = "Edit";
        //    InventoryStockAdjustment.AjaxCallInventoryStockAdjustment();
        //});




        $('#CounterCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);

        });
        $('#DeleteInventoryStockAdjustmentRecord').on("click", function () {

            InventoryStockAdjustment.ActionName = "Delete";
            InventoryStockAdjustment.AjaxCallInventoryStockAdjustment();
        });



        InitAnimatedBorder();

        CloseAlert();




    },
    CheckedAll: function () {
        $("#tblDataRecipe thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#tblDataRecipe tbody tr td  input[class='check-user']").prop("checked", true);
            }
            else {
                $("#tblDataRecipe tbody tr td  input[class='check-user']").prop("checked", false);
            }
        });
    },

    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/InventoryStockAdjustment/List',
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
            url: '/InventoryStockAdjustment/Index',
            success: function (data) {
                //Rebind Grid Data
                //$("#ListViewModel").empty().append(data);

                $("#tblData tr:not(:first)").remove();
                $("#tblDataRecipe tr:not(:first)").remove();

                $("#GeneralUnitsID").val("");
                $("#ItemName").val("");
                $("#RecipeQuantity").val("");
                $("#ActionStatus").val("");
                $("#ItemName").prop("disabled", true);
                $(".checkall-user").prop("checked", false);
                $('#ItemName').typeahead('val', '');
                InventoryStockAdjustment.ParameterVoucherXmlForActionSample = null,
                InventoryStockAdjustment.ParameterVoucherXmlForActionDamaged = null,
                InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForInsp = null,
                InventoryStockAdjustment.ParameterVoucherXmlForActionPIPostive = null,
                InventoryStockAdjustment.ParameterVoucherXmlForActionPINegative = null,
                InventoryStockAdjustment.ParameterVoucherXmlForActionWastage = null,
                InventoryStockAdjustment.ParameterVoucherXmlForActionShrinkage = null,
                InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForFreeBie = null,
                InventoryStockAdjustment.ParameterVoucherXmlForActionManualConsumption = null,
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    GetXmlData: function () {

        var DataArray = [];
        var data = $('#tblData tbody tr td  input').each(function () {
            DataArray.push($(this).val());
        });


        var TotalRecord = DataArray.length;
        var ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 20) {
            {
                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><InventoryPhysicalStockAdjustmentMasterID>" + DataArray[i] + "</InventoryPhysicalStockAdjustmentMasterID><InventoryPhysicalStockAdjustmentID>" + DataArray[i + 1] + "</InventoryPhysicalStockAdjustmentID><Itemnumber>" + (DataArray[i + 2]) + "</Itemnumber><Quantity>" + DataArray[i + 7] + "</Quantity><ActionStatus>" + DataArray[i + 10] + "</ActionStatus><TotalStock>" + DataArray[i + 13] + "</TotalStock><CorrectedStock>" + DataArray[i + 14] + "</CorrectedStock><UnRestrictedStock>" + DataArray[i + 15] + "</UnRestrictedStock><BaseUomQuantity>" + DataArray[i + 3] + "</BaseUomQuantity><BaseUoMCode>" + DataArray[i + 17] + "</BaseUoMCode><OrderingUomCode>" + DataArray[i + 18] + "</OrderingUomCode><IsCurrentStock>" + DataArray[i + 16] + "</IsCurrentStock><BatchMasterID>" + DataArray[i + 8] + "</BatchMasterID></row>";
            }


            if (ParameterXml.length > 15)
                InventoryStockAdjustment.XMLstring = ParameterXml + "</rows>";
            else
                InventoryStockAdjustment.XMLstring = "";

        }
    },
    GetXmlDataForRecipeItem: function () {
        debugger
        var DataArray = [];
        var data = $('#tblDataRecipe tbody tr td  input').each(function () {

            if ($(this).is(':checkbox')) {
                if (this.checked == true) {
                    DataArray.push(1);
                }
                else {
                    DataArray.push(0);
                }
            }
            else {
                DataArray.push($(this).val());
            }
        });


        var TotalRecord = DataArray.length;
        var Action = $('#ActionStatus').val();


        var ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 14) {
            {
                //ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemNumber>" + DataArray[i + 1] + "</ItemNumber><ItemBarCode>" + DataArray[i + 12] + "</ItemBarCode><Quantity>" + DataArray[i + 3] + "</Quantity><Rate>" + DataArray[i + 10] + "</Rate><ActionStatus>" + Action + "</ActionStatus><TotalStock>" + DataArray[i + 5] + "</TotalStock><CorrectedStock>" + DataArray[i + 7] + "</CorrectedStock><UnRestrictedStock>" + DataArray[i + 8] + "</UnRestrictedStock><BaseUomQuantity>0</BaseUomQuantity><BaseUoMCode>" + DataArray[i + 6] + "</BaseUoMCode><OrderingUomCode>" + DataArray[i + 11] + "</OrderingUomCode><IsCurrentStock>1</IsCurrentStock><InventoryPhysicalStockAdjustmentMasterID>0</InventoryPhysicalStockAdjustmentMasterID><ConversionFactor>" + DataArray[i + 9] + "</ConversionFactor><ConsumptionUoM>" + DataArray[i + 4] + "</ConsumptionUoM></row>";
                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemNumber>" + DataArray[i + 1] + "</ItemNumber><ItemBarCode>" + DataArray[i + 13] + "</ItemBarCode><Quantity>" + DataArray[i + 4] + "</Quantity><Rate>" + DataArray[i + 11] + "</Rate><ActionStatus>" + Action + "</ActionStatus><TotalStock>" + DataArray[i + 6] + "</TotalStock><CorrectedStock>" + DataArray[i + 8] + "</CorrectedStock><UnRestrictedStock>" + DataArray[i + 9] + "</UnRestrictedStock><BaseUomQuantity>0</BaseUomQuantity><BaseUoMCode>" + DataArray[i + 7] + "</BaseUoMCode><OrderingUomCode>" + DataArray[i + 12] + "</OrderingUomCode><IsCurrentStock>1</IsCurrentStock><InventoryPhysicalStockAdjustmentMasterID>0</InventoryPhysicalStockAdjustmentMasterID><ConversionFactor>" + DataArray[i + 10] + "</ConversionFactor><ConsumptionUoM>" + DataArray[i + 5] + "</ConsumptionUoM></row>";

            }


            if (ParameterXml.length > 12)
                InventoryStockAdjustment.XMLstring = ParameterXml + "</rows>";
            else
                InventoryStockAdjustment.XMLstring = "";

        }
    },

    //Fire ajax call to insert update and delete record

    AjaxCallInventoryStockAdjustment: function () {
        var InventoryStockAdjustmentData = null;

        if (InventoryStockAdjustment.ActionName == "Create") {

            $("#FormCreateInventoryStockAdjustment").validate();
            if ($("#FormCreateInventoryStockAdjustment").valid()) {
                InventoryStockAdjustmentData = null;
                InventoryStockAdjustmentData = InventoryStockAdjustment.GetInventoryStockAdjustment();
                ajaxRequest.makeRequest("/InventoryStockAdjustment/CreateBtnAdd", "POST", InventoryStockAdjustmentData, InventoryStockAdjustment.Success, "CreateInventoryStockAdjustmentRecord");
            }
        }
        else if (InventoryStockAdjustment.ActionName == "CreatebtnAdd") {

            $("#FormCreateInventoryStockAdjustment").validate();
            if ($("#FormCreateInventoryStockAdjustment").valid()) {
                InventoryStockAdjustmentData = null;
                InventoryStockAdjustmentData = InventoryStockAdjustment.GetInventoryStockAdjustment();
                ajaxRequest.makeRequest("/InventoryStockAdjustment/Create", "POST", InventoryStockAdjustmentData, InventoryStockAdjustment.SuccessDetails, "btnAdd");
            }
        }

        else if (InventoryStockAdjustment.ActionName == "CreateRecipeItemRecord") {
            $("#FormCreateInventoryStockAdjustmentForRecipeItem").validate();
            if ($("#FormCreateInventoryStockAdjustmentForRecipeItem").valid()) {
                InventoryStockAdjustmentData = null;
                InventoryStockAdjustmentData = InventoryStockAdjustment.GetInventoryStockAdjustment();
                ajaxRequest.makeRequest("/InventoryStockAdjustment/CreateRecipeItemStockAdjustment", "POST", InventoryStockAdjustmentData, InventoryStockAdjustment.Success);
            }
        }
        else if (InventoryStockAdjustment.ActionName == "Delete") {

            InventoryStockAdjustmentData = null;
            //$("#FormCreateInventoryStockAdjustment").validate();
            InventoryStockAdjustmentData = InventoryStockAdjustment.GetInventoryStockAdjustment();
            ajaxRequest.makeRequest("/InventoryStockAdjustment/Delete", "POST", InventoryStockAdjustmentData, InventoryStockAdjustment.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryStockAdjustment: function () {
        var Data = {
        };

        if (InventoryStockAdjustment.ActionName == "Create") {

            Data.ID = $('#ID').val();
            Data.GeneralUnitsID = $('#GeneralUnitsID :selected').val();
            Data.XMLstring = InventoryStockAdjustment.XMLstring;
            Data.ParameterVoucherXmlForActionSample = InventoryStockAdjustment.ParameterVoucherXmlForActionSample;
            Data.ParameterVoucherXmlForActionDamaged = InventoryStockAdjustment.ParameterVoucherXmlForActionDamaged;
            Data.ParameterVoucherXmlForActionBlockedForInsp = InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForInsp;
            Data.ParameterVoucherXmlForActionPIPostive = InventoryStockAdjustment.ParameterVoucherXmlForActionPIPostive;
            Data.ParameterVoucherXmlForActionPINegative = InventoryStockAdjustment.ParameterVoucherXmlForActionPINegative;
            Data.ParameterVoucherXmlForActionWastage = InventoryStockAdjustment.ParameterVoucherXmlForActionWastage;
            Data.ParameterVoucherXmlForActionShrinkage = InventoryStockAdjustment.ParameterVoucherXmlForActionShrinkage;
            Data.ParameterVoucherXmlForActionBlockedForFreeBie = InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForFreeBie;


            Data.TransDate = $('#TransDate').val();
        }
        else if (InventoryStockAdjustment.ActionName == "CreatebtnAdd") {

            Data.InventoryPhysicalStockAdjustmentID = $('#InventoryPhysicalStockAdjustmentID').val();
            Data.InventoryPhysicalStockAdjustmentMasterID = $('#InventoryPhysicalStockAdjustmentMasterID').val();
            Data.TransDate = $('#TransDate').val();
            Data.ConvFact = $('#ConvFact').val();
            Data.ItemNumber = $('#ItemNumber').val();
            Data.ItemName = $('#ItemName').val();
            Data.BarCode = $('#BarCode').val();
            Data.UOM = $('#UOM').val();
            Data.Rate = $('#Rate').val();
            Data.Quantity = $('#Quantity').val();
            Data.Action = $('#Action :selected').val();
            Data.IssueFromLocationID = $('#IssueFromLocationID').val();
            Data.UnrestrictedStock = $('#UnrestrictedStock').val();
            Data.BatchMasterID = $('#BatchNumber').val();
            Data.BatchNumber = $('#BatchNumber').text();
            Data.CurrentStockStatus = InventoryStockAdjustment.CurrentStockStatus;

        }

        else if (InventoryStockAdjustment.ActionName == "CreateRecipeItemRecord") {

            Data.ID = $('#ID').val();
            Data.GeneralUnitsID = $('#GeneralUnitsID :selected').val();
            Data.Action = $('#Action :selected').val();
            Data.XMLstring = InventoryStockAdjustment.XMLstring;
            Data.ParameterVoucherXmlForActionSample = InventoryStockAdjustment.ParameterVoucherXmlForActionSample;
            Data.ParameterVoucherXmlForActionDamaged = InventoryStockAdjustment.ParameterVoucherXmlForActionDamaged;
            Data.ParameterVoucherXmlForActionBlockedForInsp = InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForInsp;
            Data.ParameterVoucherXmlForActionPIPostive = InventoryStockAdjustment.ParameterVoucherXmlForActionPIPostive;
            Data.ParameterVoucherXmlForActionPINegative = InventoryStockAdjustment.ParameterVoucherXmlForActionPINegative;
            Data.ParameterVoucherXmlForActionWastage = InventoryStockAdjustment.ParameterVoucherXmlForActionWastage;
            Data.ParameterVoucherXmlForActionShrinkage = InventoryStockAdjustment.ParameterVoucherXmlForActionShrinkage;
            Data.ParameterVoucherXmlForActionBlockedForFreeBie = InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForFreeBie;


            Data.TransDate = $('#TransDate').val();


        }
        else if (InventoryStockAdjustment.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },
    StockAdjustmentForActionVoucherXML: function () {
       
        var DataArray = [];
        var TotalDamagedAmount = 0, TotalSampleAmount = 0, TotalBlockInspAmount = 0, TotalPIPostAmount = 0, TotalPINegAmount = 0, TotalWastegeAmount = 0, TotalShrinkageAmount = 0, TotalFreeBieAmount = 0;
        //PurchaseReturn.flag = true;
        $('#tblData input').each(function () {
            if ($(this).val() != "on") {
                DataArray.push($(this).val());
            }
        });

      
        var TotalRecord = DataArray.length;
        var CountDamaged = 0, CountSample = 0, CountPIPosti = 0, CountBInspection = 0, CountPINegative = 0, CountWastage = 0, CountShrinkage = 0, CountFreeBie = 0;
        for (var i = 0; i < TotalRecord; i = i + 20) {
            {
                if (DataArray[i + 10] == 1) {
                    TotalDamagedAmount = TotalDamagedAmount + (DataArray[i + 6] * DataArray[i + 7]);
                    CountDamaged = CountDamaged + 1;
                }
                if (DataArray[i + 10] == 2) {
                    TotalSampleAmount = TotalSampleAmount + (DataArray[i + 6] * DataArray[i + 7]);;
                    CountSample = CountSample + 1;
                }
                if (DataArray[i + 10] == 3) {
                    TotalBlockInspAmount = TotalBlockInspAmount + (DataArray[i + 6] * DataArray[i + 7]);
                    CountBInspection = CountBInspection + 1;
                }
                if (DataArray[i + 10] == 4) {
                    TotalPIPostAmount = TotalPIPostAmount + (DataArray[i + 6] * DataArray[i + 7]);
                    CountPIPosti = CountPIPosti + 1;
                }
                if (DataArray[i + 10] == 5) {
                    TotalPINegAmount = TotalPINegAmount + (DataArray[i + 6] * DataArray[i + 7]);
                    CountPINegative = CountPINegative + 1;
                }
                if (DataArray[i + 10] == 6) {
                    TotalWastegeAmount = TotalWastegeAmount + (DataArray[i + 6] * DataArray[i + 7]);
                    CountWastage = CountWastage + 1;
                }
                if (DataArray[i + 10] == 7) {
                    TotalShrinkageAmount = TotalShrinkageAmount + (DataArray[i + 6] * DataArray[i + 7]);
                    CountShrinkage = CountShrinkage + 1;
                }
                if (DataArray[i + 10] == 8) {
                    TotalFreeBieAmount = TotalFreeBieAmount + (DataArray[i + 6] * DataArray[i + 7]);
                    CountFreeBie = CountFreeBie + 1;
                }

            }
        }

        var currentdate = new Date();
        var datetime =
                         currentdate.getUTCFullYear() + "-"
                        + (currentdate.getUTCMonth() + 1) + "-"
                        + currentdate.getUTCDate() + " "
                        + currentdate.getUTCHours() + ":"
                        + currentdate.getUTCMinutes() + ":"
                        + currentdate.getUTCSeconds() + "."
                        + currentdate.getUTCMilliseconds();
        var CreatedBy = $('#CreatedBy').val();


        if (CountSample > 0) // Sample
        {
            var ParameterVoucherXmlForActionSample = "<rows>";
            ParameterVoucherXmlForActionSample = ParameterVoucherXmlForActionSample + "<row><GenericNumber>2-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSSPurchaseAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalSampleAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>2-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSSAdvertismentAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + TotalSampleAmount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            if (ParameterVoucherXmlForActionSample.length > 10)
                InventoryStockAdjustment.ParameterVoucherXmlForActionSample = ParameterVoucherXmlForActionSample + "</rows>";

            else
                InventoryStockAdjustment.ParameterVoucherXmlForActionSample = "";
            CountSample = 0;
        }
        if (CountDamaged > 0) //Damaged
        {
            var ParameterVoucherXmlForActionDamaged = "<rows>";
            ParameterVoucherXmlForActionDamaged = ParameterVoucherXmlForActionDamaged + "<row><GenericNumber>1-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSDPurchaseAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalDamagedAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>1-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSDDamagedAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + TotalDamagedAmount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            if (ParameterVoucherXmlForActionDamaged.length > 10)
                InventoryStockAdjustment.ParameterVoucherXmlForActionDamaged = ParameterVoucherXmlForActionDamaged + "</rows>";

            else
                InventoryStockAdjustment.ParameterVoucherXmlForActionDamaged = "";
            CountDamaged = 0;
        }
        if (CountBInspection > 0) //'Blocked For Inspection'
        {
            //var ParameterVoucherXmlForActionBlockedForInsp = "<rows>";
            //ParameterVoucherXmlForActionBlockedForInsp = ParameterVoucherXmlForActionBlockedForInsp + "<row><GenericNumber>3-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSBIPurchaseAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalBlockInspAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>3-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSBICashAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + TotalBlockInspAmount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            //if (ParameterVoucherXmlForActionBlockedForInsp.length > 10)
            //    InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForInsp = ParameterVoucherXmlForActionBlockedForInsp + "</rows>";

            //else
            InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForInsp = "";
            CountBInspection = 0;
        }
        if (CountPIPosti > 0) //'PI-Positive'
        {
            var ParameterVoucherXmlForActionPIPostive = "<rows>";
            ParameterVoucherXmlForActionPIPostive = ParameterVoucherXmlForActionPIPostive + "<row><GenericNumber>4-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSPPPurchaseAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>-" + TotalPIPostAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>4-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSPPIAdjustmentAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>" + TotalPIPostAmount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            if (ParameterVoucherXmlForActionPIPostive.length > 10)
                InventoryStockAdjustment.ParameterVoucherXmlForActionPIPostive = ParameterVoucherXmlForActionPIPostive + "</rows>";

            else
                InventoryStockAdjustment.ParameterVoucherXmlForActionPIPostive = "";
            CountPIPosti = 0;
        }
        if (CountPINegative > 0) //'PI-Negative'
        {
            var ParameterVoucherXmlForActionPINegative = "<rows>";
            ParameterVoucherXmlForActionPINegative = ParameterVoucherXmlForActionPINegative + "<row><GenericNumber>5-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSPNPurchaseAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalPINegAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>5-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSPNIAdjustmentAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + TotalPINegAmount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            if (ParameterVoucherXmlForActionPINegative.length > 10)
                InventoryStockAdjustment.ParameterVoucherXmlForActionPINegative = ParameterVoucherXmlForActionPINegative + "</rows>";

            else
                InventoryStockAdjustment.ParameterVoucherXmlForActionPINegative = "";
            CountPINegative = 0;
        }
        if (CountWastage > 0) //'Wastage'
        {
            var ParameterVoucherXmlForActionWastage = "<rows>";
            ParameterVoucherXmlForActionWastage = ParameterVoucherXmlForActionWastage + "<row><GenericNumber>6-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSWPurchaseAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalWastegeAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>6-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSWIAdjustmentAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + TotalWastegeAmount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            if (ParameterVoucherXmlForActionWastage.length > 10)
                InventoryStockAdjustment.ParameterVoucherXmlForActionWastage = ParameterVoucherXmlForActionWastage + "</rows>";

            else
                InventoryStockAdjustment.ParameterVoucherXmlForActionWastage = "";
            CountWastage = 0;
        }
        if (CountShrinkage > 0) //'Shrinkage'
        {
            var ParameterVoucherXmlForActionShrinkage = "<rows>";
            ParameterVoucherXmlForActionShrinkage = ParameterVoucherXmlForActionShrinkage + "<row><GenericNumber>7-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSSKPurchaseAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalShrinkageAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>7-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSSKIAdjustmentAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + TotalShrinkageAmount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            if (ParameterVoucherXmlForActionShrinkage.length > 10)
                InventoryStockAdjustment.ParameterVoucherXmlForActionShrinkage = ParameterVoucherXmlForActionShrinkage + "</rows>";

            else
                InventoryStockAdjustment.ParameterVoucherXmlForActionShrinkage = "";
            CountShrinkage = 0;
        }
        if (CountFreeBie > 0) //'FreeBie'
        {
            var ParameterVoucherXmlForActionBlockedForFreeBie = "<rows>";
            ParameterVoucherXmlForActionBlockedForFreeBie = ParameterVoucherXmlForActionBlockedForFreeBie + "<row><GenericNumber>8-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSFBPurchaseAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalFreeBieAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>8-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSFBAdvertiseAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + TotalFreeBieAmount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            if (ParameterVoucherXmlForActionBlockedForFreeBie.length > 10)
                InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForFreeBie = ParameterVoucherXmlForActionBlockedForFreeBie + "</rows>";

            else
                InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForFreeBie = "";
            CountFreeBie = 0;

        }


    },

    // accounting effects for Recipeitem 
    StockAdjustmentForActionVoucherXMLForRecipeItem: function () {
        debugger;
        var DataArray = [];
        var TotalWastegeAmount = 0, TotalManualConsumptionAmount = 0, TotalFreeBieAmount = 0;
        //PurchaseReturn.flag = true;
        var DataArray = [];
        var data = $('#tblDataRecipe tbody tr td  input').each(function () {

            if ($(this).is(':checkbox')) {
                if (this.checked == true) {
                    DataArray.push(1);
                }
                else {
                    DataArray.push(0);
                }
            }
            else {
                DataArray.push($(this).val());
            }
        });
        var Action = $('#ActionStatus').val();
        var TotalRecord = DataArray.length;
        var CountWastage = 0, CountManualConsumption = 0, CountFreeBie = 0;
        for (var i = 0; i < TotalRecord; i = i + 14) {
            {

                if (Action == 6) {
                    TotalWastegeAmount = TotalWastegeAmount + (DataArray[i + 4] * DataArray[i + 11]);
                    CountWastage = CountWastage + 1;
                }
                if (Action == 9) {
                    TotalManualConsumptionAmount = TotalManualConsumptionAmount + (DataArray[i + 4] * DataArray[i + 11]);
                    CountManualConsumption = CountManualConsumption + 1;
                }
                if (Action == 8) {
                    TotalFreeBieAmount = TotalFreeBieAmount + (DataArray[i + 4] * DataArray[i + 11]);
                    CountFreeBie = CountFreeBie + 1;
                }
            }
        }

        var currentdate = new Date();
        var datetime =
                         currentdate.getUTCFullYear() + "-"
                        + (currentdate.getUTCMonth() + 1) + "-"
                        + currentdate.getUTCDate() + " "
                        + currentdate.getUTCHours() + ":"
                        + currentdate.getUTCMinutes() + ":"
                        + currentdate.getUTCSeconds() + "."
                        + currentdate.getUTCMilliseconds();
        var CreatedBy = $('#CreatedBy').val();
        if (CountWastage > 0) //'Wastage'
        {
            var ParameterVoucherXmlForActionWastage = "<rows>";
            ParameterVoucherXmlForActionWastage = ParameterVoucherXmlForActionWastage + "<row><GenericNumber>6-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSWPurchaseAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalWastegeAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>6-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSWIAdjustmentAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + TotalWastegeAmount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            if (ParameterVoucherXmlForActionWastage.length > 10)
                InventoryStockAdjustment.ParameterVoucherXmlForActionWastage = ParameterVoucherXmlForActionWastage + "</rows>";

            else
                InventoryStockAdjustment.ParameterVoucherXmlForActionWastage = "";
            CountWastage = 0;
        }
        if (CountFreeBie > 0) //'FreeBie'
        {
            var ParameterVoucherXmlForActionBlockedForFreeBie = "<rows>";
            ParameterVoucherXmlForActionBlockedForFreeBie = ParameterVoucherXmlForActionBlockedForFreeBie + "<row><GenericNumber>8-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSFBPurchaseAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalFreeBieAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>8-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSFBAdvertiseAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + TotalFreeBieAmount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            if (ParameterVoucherXmlForActionBlockedForFreeBie.length > 10)
                InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForFreeBie = ParameterVoucherXmlForActionBlockedForFreeBie + "</rows>";

            else
                InventoryStockAdjustment.ParameterVoucherXmlForActionBlockedForFreeBie = "";
            CountFreeBie = 0;

        }
        if (CountManualConsumption > 0) //'ManualConsumption'
        {
            var ParameterVoucherXmlForActionManualConsumption = "<rows>";
            ParameterVoucherXmlForActionManualConsumption = ParameterVoucherXmlForActionManualConsumption + "<row><GenericNumber>6-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSWPurchaseAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + TotalWastegeAmount + "</Amount><PersonID></PersonID><PersonType>U</PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>6-" + datetime + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtSWIAdjustmentAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + TotalWastegeAmount + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + CreatedBy + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            if (ParameterVoucherXmlForActionManualConsumption.length > 10)
                InventoryStockAdjustment.ParameterVoucherXmlForActionManualConsumption = ParameterVoucherXmlForActionManualConsumption + "</rows>";

            else
                InventoryStockAdjustment.ParameterVoucherXmlForActionManualConsumption = "";
            CountManualConsumption = 0;
        }
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            //$.magnificPopup.close()
            InventoryStockAdjustment.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

    SuccessDetails: function (data) {

       

        var IsCurrentStock;
        var splitData = data.errorMessage.split(',');


        $("#InventoryPhysicalStockAdjustmentMasterID").val(data.ID);
        $("#InventoryPhysicalStockAdjustmentID").val(data.InventoryPhysicalStockAdjustmentID);
        $("#IsCurrentStock").val(data.IsCurrentStock);
        if ($("#IsCurrentStock").val() == 'true') {
            IsCurrentStock = 1;
        }
        else {
            IsCurrentStock = 0;
        }
        InventoryStockAdjustment.CurrentStockStatus = 1;
      

        if (splitData[1] == 'success') {
            // $.magnificPopup.close()
            if ($('#BatchNumber').val() == null || $('#BatchNumber').val() == "")
            {
                var batchnumber= "<td><input id='BatchNumber' type='text' value='0' style='display:none' />-</td>" 
                }
            else
            {
                var batchnumber="<td><input id='BatchNumber' type='text' value='" + $('#BatchNumber :selected').text() + "' style='display:none' />" + $('#BatchNumber :selected').text() + "</td>" 
            }
         
            $("#tblData tbody").append(
              "<tr>" +
              "<td style='display:none;'><input id='InventoryPhysicalStockAdjustmentMasterID' type='hidden' value='" + $('#InventoryPhysicalStockAdjustmentMasterID').val() + "' style='display:none' />" + parseFloat($('#InventoryPhysicalStockAdjustmentMasterID').val()).toFixed(2) + "</td>" +
              "<td style='display:none;'><input id='InventoryPhysicalStockAdjustmentID' type='hidden' value='" + $('#InventoryPhysicalStockAdjustmentID').val() + "' style='display:none' />" + parseFloat($('#InventoryPhysicalStockAdjustmentID').val()).toFixed(2) + "</td>" +
              "<td style='display:none;'><input id='ItemNumber' type='hidden' value='" + $('#ItemNumber').val() + "' style='display:none' />" + parseFloat($('#ItemNumber').val()).toFixed(2) + "</td>" +
              "<td style='display:none;'><input id='ConvFact' type='hidden' value='" + $('#ConvFact').val() + "' style='display:none' />" + parseFloat($('#ConvFact').val()).toFixed(2) + "</td>" +
              "<td><input id='ItemName' type='text' value='" + $('#ItemName').val() + "' style='display:none' />" + $('#ItemName').val() + "</td>" +
              "<td style='display:none;'><input id='BarCode' type='text' value='" + $('#BarCode').val() + "' style='display:none' />" + $('#BarCode').val() + "</td>" +
              "<td style='display:none;'><input id='Rate' type='hidden' value='" + $('#Rate').val() + "' style='display:none' />" + parseFloat($('#Rate').val()).toFixed(2) + "</td>" +
              "<td><input id='Quantity' type='hidden' value='" + $('#Quantity').val() + "' style='display:none' />" + parseFloat($('#Quantity').val()).toFixed(2) + "</td>" +
               "<td style='display:none;'><input id='BatchNumber' type='text' value='" + $('#BatchNumber :selected').val() + "' style='display:none' />" + $('#BatchNumber :selected').val() + "</td>" +
              batchnumber+

              "<td style='display:none;'><input id='Action' type='text' value='" + $('#Action :selected').val() + "' style='display:none' />" + $('#Action :selected').val() + "</td>" +
              "<td><input id='Action' type='text' value='" + $('#Action :selected').text() + "' style='display:none' />" + $('#Action :selected').text() + "</td>" +
              "<td style='display:none;'><input id='IssueFromLocationID' type='text' value='" + $('#IssueFromLocationID :selected').val() + "' style='display:none' />" + $('#IssueFromLocationID :selected').val() + "</td>" +
              "<td><input id='TotalStock' type='hidden' value='" + $('#TotalStock').val() + "' style='display:none' />" + parseFloat($('#TotalStock').val()).toFixed(2) + "</td>" +
              "<td><input id='CorrectedStock' type='hidden' value='" + $('#CorrectedStock').val() + "' style='display:none' />" + parseFloat($('#CorrectedStock').val()).toFixed(2) + "</td>" +
              "<td><input id='UnrestrictedStock' type='hidden' value='" + $('#UnrestrictedStock').val() + "' style='display:none' />" + parseFloat($('#UnrestrictedStock').val()).toFixed(2) + "</td>" +
              "<td style='display:none;'><input id='IsCurrentStock' type='hidden' value='" + IsCurrentStock + "' style='display:none' />" + IsCurrentStock + "</td>" +
              "<td style='display:none;'><input id='LowerUom' type='text' value='" + $('#LowerUom').val() + "' style='display:none' />" + $('#LowerUom').val() + "</td>" +
              "<td style='display:none;'><input id='UOM' type='text' value='" + $('#UOM').val() + "' style='display:none' />" + $('#UOM').val() + "</td>" +
                //  "<td><i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete><a href=\"javascript:void(0);\" data-toggle=\"tooltip\"  onclick=\"fancyBoxPopUpAjax('Delete Stock Details','Are you sure? want to delete this Details ?','error','btn-danger','Yes!','/InventoryStockAdjustment/Delete/" + $('#InventoryPhysicalStockAdjustmentID').val() + "','content','page-loader','InventoryStockAdjustment')\"></a></i></td>" +
             "<td style='display:none;'><i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete/><input type='hidden' id='InventoryPhysicalStockAdjustmentID' value=" + $('#InventoryPhysicalStockAdjustmentID').val() + "  /></td>" +
                  //<input type='hidden' id='InventoryPhysicalStockAdjustmentID' value=" + $('#InventoryPhysicalStockAdjustmentID').val() + "  />
"</tr>");
            $("#ItemName").val("");
            $('#ItemName').typeahead('val', '');
            $("#UOM").val("");
            $("#Quantity").val(0);
            $("#Convertion").val("");
            $("#TotalStock").val(0);
            $("#CorrectedStock").val(0);
            $("#UnrestrictedStock").val(0);
            $("#LowerUom").val("");
            $("#Action").val("");
            $("#BatchNumber").val("");
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);

            if (!$('#CentreCode').attr("disabled")) {
                $('#CentreCode').attr("disabled", true);
                $('#GeneralUnitsID').attr("disabled", true);
            }

            //Code for deleting record in table
            $("#tblData tbody").on("click", "tr td i", function () {

                var InventoryPhysicalStockAdjustmentID = $(this).closest('td').find('input[id="InventoryPhysicalStockAdjustmentID"]').val();
                $.ajax(
       {
           cache: false,
           type: "GET",
           dataType: "json",
           data: { "InventoryPhysicalStockAdjustmentID": InventoryPhysicalStockAdjustmentID },
           url: '/InventoryStockAdjustment/Delete',
           context: this,
           success: function (result) {
               var splitData = result.split(',');
               if (splitData[1] == 'success') {
                   $(this).closest('tr').remove();

                   InventoryStockAdjustment.CurrentStockStatus = 1;

                   if ($("#tblData tbody tr").length == 0) {
                       $('#InventoryPhysicalStockAdjustmentMasterID').val(0);
                       $('#InventoryPhysicalStockAdjustmentID').val(0);
                       InventoryStockAdjustment.CurrentStockStatus = 0;
                       $('#CentreCode').attr("disabled", false);
                       $('#GeneralUnitsID').attr("disabled", false);

                   }

               }
               $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
           }

       });

            });

        }

        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }

    },


};


