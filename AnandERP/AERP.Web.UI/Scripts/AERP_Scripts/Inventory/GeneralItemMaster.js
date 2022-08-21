//this class contain methods related to nationality functionality
var GeneralItemMaster = {
    //Member variables
    ActionName: null,
    ImageName: null,
    map: {},
    ParameterXml: null,
    ResetGeneralUnitsID: null,
    CheckInfo: false,
    CheckSale: false,
    CheckBase: false,
    CheckOrder:false,
    NotificationAccepted: false,
    CheckPrice: true,
    S1: false,
    CheckBarcode: true,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralItemMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page 
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });


        //Used in Sale TAB For Store Wise Sale Uom code.
        $("#btnShowList").on("click", function () {

            var GeneralUnitsID = $('#GeneralUnitsID :selected').val();
            var ItemNumber = $('#ItemNumber').val();
            var TaskCode = $('#TaskCode').val();
            var SelectedCentreCodeForSaleTab = $('#SelectedCentreCodeForSaleTab').val();
            if (GeneralUnitsID != "" && ItemNumber != "") {
                GeneralItemMaster.LoadData(TaskCode, ItemNumber, GeneralUnitsID, SelectedCentreCodeForSaleTab);
            }
            else if (ItemNumber == "") {
                notify("Please select Item Description.", 'warning');

            }
            else if (GeneralUnitsID == "") {
                notify("Please select Store.", 'warning');
            }


        });
        $("#SelectedCentreCodeForSaleTab").change(function () {
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
                    url: '/GeneralItemMaster/GetGeneralUnitsForItemmasterList',
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
        
        $("#Restaurant").on("click", function () {
            var Restaurant = $("#Restaurant").is(":checked") ? "true" : "false";
            if (Restaurant == "false") {
                var TaskCode = 'GeneralItemGeneralData';
                $("li#" + TaskCode).click();
                $('ul#TaskList li').removeClass("active");
                $('ul#TaskList li:eq(0)').addClass("active");
            }
            else {
                var TaskCode = 'GeneralItemRestaurantData';
                $("li#" + TaskCode).click();
                $('ul#TaskList li').removeClass("active");
                $('ul#TaskList li:eq(6)').addClass("active");
            }
        });

        $("#IsServiceItem").on("click", function () {
            var IsServiceItem = $("#IsServiceItem").is(":checked") ? "true" : "false";
            if (IsServiceItem == "false") {
                var TaskCode = 'GeneralItemGeneralData';
                $("li#" + TaskCode).click();
                $('ul#TaskList li').removeClass("active");
                $('ul#TaskList li:eq(0)').addClass("active");
            }
            else {
                var TaskCode = 'GeneralItemServiceData';
                $("li#" + TaskCode).click();
                $('ul#TaskList li').removeClass("active");
                $('ul#TaskList li:eq(8)').addClass("active");
            }
        });
            
        $('#CreateMultipleVendorRecord').on("click", function () {
            GeneralItemMaster.ActionName = "CreateMultipleVendor";
            if ($("#VendorName").val() == "" || $("#VendorName").val() == null)
            {
                $("#displayErrorMessage1 p").text("Please Enter Vendor Name").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            if ($("#VendorNumber").val() == 0 || $("#VendorNumber").val() == "") {
                $("#displayErrorMessage1 p").text("Please Enter Valid Vendor Name").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            if ($("#LeadTime").val() == "" || $("#LeadTime").val() == 0) {
                $("#displayErrorMessage1 p").text("Please select Lead Time for Vendor").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            GeneralItemMaster.AjaxCallGeneralItemMaster();
        });

        //Validation for tab display
        $("#r7").on("click", function (e) {
            if (($('#RetailSale').val() == "true" || $("#RetailSale").is(":checked")) && $('#BOM').val() == "false" && ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked"))) {

                return true;
            }
            else if (($('#RetailSale').val() == "true" || $("#RetailSale").is(":checked")) && $('#BOM').val() == "false") {

                return false;
            }
            else if (($('#RetailSale').val() == "true" || $("#RetailSale").is(":checked")) && ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked"))) {

                return true;
            }

            else if (($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked")) || $('#RetailSale').val() == "false" || $('#BOM').val() == "false") {
                return true;
            }
            else if ($('#RetailSale').val() == "true" || $("#RetailSale").is(":checked"))
            {
                return false;
            }
        });
        $("#r8").on("click", function (e) {
            if (($('#RetailSale').val() == "true" || ($('#RetailSale').is(":checked"))) && $('#BOM').val() == "true") {

                return False;
            }
            else if (($('#RetailSale').val() == "true" || ($('#RetailSale').is(":checked"))) && ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked"))) {

                return true;
            }
            else if ($('#BOM').val() == "true" || ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked")) || ($('#IsServiceItem').val() == "true" || $("#IsServiceItem").is(":checked"))) {
                //return false;
                return false;
            }

        });

        $("#r1").on("click", function (e) {
            if (($('#RetailSale').val() == "true" || ($('#RetailSale').is(":checked"))) && $('#BOM').val() == "true") {

                return false;
            }
            else if (($('#RetailSale').val() == "true" ||($('#RetailSale').is(":checked")))  && ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked"))) {

                return true;
            }
            else if ($('#BOM').val() == "true" || ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked")) || ($('#IsServiceItem').val() == "true" || $("#IsServiceItem").is(":checked"))) {
                //return false;
                return false;
            }

        });
        $("#r9").on("click", function (e) {
            if ($('#IsEComItem').val() == "true" || ($('#IsEComItem').is(":checked"))) {

                return true;
            }
            else
            {
                return false;
            }
           

        });
        $("#r2").on("click", function (e) {
            debugger;
            if (($('#RetailSale').val() == "true" || ($('#RetailSale').is(":checked")))) {

                return False;
            }
            else if (($('#RetailSale').val() == "true" || ($('#RetailSale').is(":checked"))) && ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked")) || $('#BOM').val() == "true") {

                return true;
            }
            else if (($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked"))) {
                //return false;
                return false;
            }

        });
        $("#r3").on("click", function (e) {
            if (($('#RetailSale').val() == "true" || ($('#RetailSale').is(":checked"))) && $('#BOM').val() == "true") {

                return true;
            }
            else if (($('#RetailSale').val() == "true" || ($('#RetailSale').is(":checked"))) && ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked"))) {

                return true;
            }
            else if ($('#BOM').val() == "true" || ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked")) || ($('#IsServiceItem').val() == "true" || $("#IsServiceItem").is(":checked"))) {
                return false;
            }

        });
        $("#r4").on("click", function (e) {
            if ($('#RetailSale').val() == "true" && $('#BOM').val() == "true") {

                return true;
            }
            else if ($('#RetailSale').val() == "true" && ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked"))) {

                return true;
            }
            else if ($('#BOM').val() == "true" || ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked"))) {
                return false;
            }

        });
        $("#r5").on("click", function (e) {
            if (($('#RetailSale').val() == "true" || ($('#RetailSale').is(":checked"))) && $('#BOM').val() == "true") {

                return true;
            }
            else if (($('#RetailSale').val() == "true" || ($('#RetailSale').is(":checked"))) && ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked"))) {

                return true;
            }
            else if ($('#BOM').val() == "true" || ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked"))) {
                //return false;
                return true;
            }
            else if (($('#IsServiceItem').val() == "true" || $("#IsServiceItem").is(":checked")))
            {
                return false;
            }

        });
        $("#r6").on("click", function (e) {
            if (($('#RetailSale').val() == "true" || ($('#RetailSale').is(":checked"))) && $('#BOM').val() == "true") {

                return true;
            }
            else if (($('#RetailSale').val() == "true" || ($('#RetailSale').is(":checked"))) && ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked"))) {

                return true;
            }
            else if ($('#BOM').val() == "true" || ($('#Restaurant').val() == "true" || $("#Restaurant").is(":checked")) || ($('#IsServiceItem').val() == "true" || $("#IsServiceItem").is(":checked"))) {
                return false;
            }

        });
        $("#r10").on("click", function (e) {
            if ($('#IsServiceItem').val() == "true" || ($('#IsServiceItem').is(":checked"))) {

                return true;
            }
            else {
                return false;
            }


        });
        //On change events on height,width and length field

        $("#tblData tbody").on("click", "tr td input[id=OrderingUnitcheckbox]", function () {
            //alert($(this).is(":checked"));
            $('tbody tr td input[id=OrderingUnitcheckbox]').each(function () {
                $(this).prop('checked', false);
            });
            $(this).prop('checked', true);
            $('#OrderingUnitcheckboxFlag').val(1);

        });


        $("#tblData tbody").on("keyup", "tr td input[id^=Length1]", function () {
            var l = $(this).closest('tr').find('td input[id^=Length1]').val();
            var w = $(this).closest('tr').find('td input[id^=WidthOfItem1]').val();
            var h = $(this).closest('tr').find('td input[id^=HeightOfItem1]').val();

            var Volume1 = l * w * h;
            $(this).closest('tr').find('td input[id=Volume1]').val(parseFloat(Volume1).toFixed(2));
        });
        $("#tblData tbody").on("keyup", "tr td input[id^=WidthOfItem1]", function () {
            var l = $(this).closest('tr').find('td input[id^=Length1]').val();
            var w = $(this).closest('tr').find('td input[id^=WidthOfItem1]').val();
            var h = $(this).closest('tr').find('td input[id^=HeightOfItem1]').val();

            var Volume2 = l * w * h;
            $(this).closest('tr').find('td input[id=Volume1]').val(parseFloat(Volume2).toFixed(2));
        });
        $("#tblData tbody").on("keyup", "tr td input[id^=HeightOfItem1]", function () {
            var l = $(this).closest('tr').find('td input[id^=Length1]').val();
            var w = $(this).closest('tr').find('td input[id^=WidthOfItem1]').val();
            var h = $(this).closest('tr').find('td input[id^=HeightOfItem1]').val();

            var Volume3 = l * w * h;
            $(this).closest('tr').find('td input[id=Volume1]').val(parseFloat(Volume3).toFixed(2));
        });
        //Code used For Radio Button in Restaurant TAB 
        //If Yes:varients can be created on menu Item

        $("#Yes").on("change click", function () {
           $("#DefineVarients").show();
            $("#DefineVarientsAppend").show();
            $('#Price_div').hide();

        });
        $("#No").on("change click", function () {
            $("#DefineVarients").hide();
            $("#DefineVarientsAppend").hide();
            $('#Price_div').show();

        });

        //Supply source on change
        $('#SupplySourceCode').on("change", function () {
            var code = $('#SupplySourceCode :selected').val();
            if ((code) == 'External Vendor') {
                $('#LeadTimeForStore').attr("disabled", "disabled");
                }
                else {
                $('#LeadTimeForStore').prop('disabled', false);
                }
        });

        //On click of Centre code drop down Store (Units) are listed.
        //Centres are also Role wise
        //$('#btnShowListForStoreData').click(function () {
        //    $('#SaleUomTab').show();
        //    var CentreCode = $('#SelectedCentreCode').val()
        //    var GeneralItemMasterID = $('input[name=GeneralItemMasterID]').val();
        //    var ItemNumber = $('#ItemNumber').val();
        //    var ItemDescription = $('#ItemDescription').val();
        //    var GeneralUnitsID = $('#GeneralUnitsID').val();
        //    var ItemCategoryCode_Param = $('#ItemCategoryCode_Param').val();
        //    var GeneralVendorID = $('#GeneralVendorID').val();
        //    var TaskCode = $('#TaskCode').val();
        //    $.ajax(
        //   {
        //       cache: false,
        //       type: "Get",
        //       data: { "TaskCode": TaskCode, "ItemNumber": ItemNumber, "GeneralItemMasterID": GeneralItemMasterID, "GeneralUnitsID": GeneralUnitsID, "GeneralVendorID": GeneralVendorID, "ItemCategoryCode_Param": ItemCategoryCode_Param, "CentreCode": CentreCode },
        //       dataType: "html",
        //       url: '/GeneralItemMaster/CreateGeneralItemStoreData',
        //       success: function (data) {
        //           //Rebind Grid Data
        //           $('.tab-content').html(data);
                  
                 
        //       }
        //   });
        //});
        //
       

        ////Rp Type DropDown on Change
        //$('#RPType').on("change", function () {
        //    var RPType = $('#RPType :selected').val();
        //    if ((RPType) == '1') {


        //        $('#SafetyStockDriven').attr("disabled", "disabled");
        //        $('#ReorderPoint').prop('disabled', false);
        //        $("#SafetyStockDriven").val(0);
        //    }
        //    else {
        //        $('#SafetyStockDriven').prop('disabled', false);
        //        $('#ReorderPoint').attr("disabled", "disabled");
        //        $("#ReorderPoint").val(0);
        //    }
        //});
        //Get lead time on supplier name selection
        //$('#VendorName').focusout(function () {
        //    
        //    
        //    var GeneralVendorID = $("#GeneralVendorID").val();

        //    var ItemNumber = $("#ItemNumber").val();

        //    if (ItemNumber > 0 && GeneralVendorID > 0)
        //    {
        //        $.ajax({
        //            cache: false,
        //            type: "POST",
        //            dataType: "html",
        //            data: { "ItemNumber": ItemNumber, "GeneralVendorID": GeneralVendorID },
        //            url: '/GeneralItemMaster/GetLeadTimeByVendorID',
        //            success: function (data) {

        //                ($("#LeadTime").val(data.replace(/"/g, "")));
        //                //$("#CurrencyCode").val(data);
        //            }
        //        });
        //    }
        //});
      
       
        // To delete rows when user deselect store 
        $('#GeneralUnitsID').on("change", function () {
            var GeneralUnitsID = $('#GeneralUnitsID').val();
            if (GeneralUnitsID == "") {
                //used to remove all rows with header
                //$("#SaleUoMDetailstblData tr").remove();

                $("#SaleUoMDetailstblData tr:not(:first)").remove();
            }
        });
        $("#ExcelFile").change(function () {

            ////  var filename = "OptionImageFile";
            //var MyFileType = $('#MyFile')[0].files[0].type;
            //var Extension = MyFileType.split('/');
            //MyFileFileName = $('#MyFile')[0].files[0].name;
            var file = $('#ExcelFile')[0].files[0];
            var MyFileFileName = file.name;
            var Extension = '.' + MyFileFileName.split('.').pop();
            if (MyFileFileName != "" && MyFileFileName != "undefined") {

                if (Extension == ".xls" || Extension == ".xlsx") {
                    var a = "";
                }
                else {
                    $("#displayErrorMessagee p").text("Option excel only allows file types of xls and xlsx.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#ExcelFile").replaceWith($("#ExcelFile").val('').clone(true));
                    return false;
                }
            }
            else {
                alert();
                $("#displayErrorMessagee p").text("The selected file does not appear to be an excel file.").closest('div').fadeIn().closest('div').addClass('alert-' + "success");

                $("#ExcelFile").replaceWith($("#ExcelFile").val('').clone(true));

            }
        });

        // Create new record
        $('#CreateGeneralItemMasterRecordExcel').on("click", function () {

            GeneralItemMaster.ActionName = "UploadExcel";
            GeneralItemMaster.AjaxCallGeneralItemMaster();
        });
        $('#EditGeneralItemMasterRecord').on("click", function () {
            GeneralItemMaster.ActionName = "Edit";
            GeneralItemMaster.AjaxCallGeneralItemMaster();
        });
        $('#CreateStoreSpecificInformation').on("click", function () {

            GeneralItemMaster.ActionName = "CreateStoreSpecificInformation";
            GeneralItemMaster.AjaxCallGeneralItemMaster();
        });
        $('#DeleteGeneralItemMasterRecord').on("click", function () {
            GeneralItemMaster.ActionName = "Delete";
            GeneralItemMaster.AjaxCallGeneralItemMaster();
        });
        //Validation
        $('#ItemCategoryDescription').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#BaseQty').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });


        $('#PriceForRecipe').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#MinimumOrderquantity').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#LastPurchasePrice').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#Price').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#PurchaseOrganization').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MaxStock').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#Cost').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#Length').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#WidthOfItem').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#HeightOfItem').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

        $('#Facing').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('input[id^=Length1]').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('input[id^=WidthOfItem1]').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('input[id^=HeightOfItem1]').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('input[id^=PriceForVariation]').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('input[id^=Price]').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('input[id^=Convertion]').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        //Validation Ends
        //To check whether the same bar code is already exist in Db or not.s
        $('#BarCode').focusout(function () {

            var selectedbarcodeName = $('#BarCode').val();
            var data = new FormData();
            data.append("selectedbarcodeName", selectedbarcodeName);
            $.ajax({
                url: "/GeneralItemMaster/CheckFocusOnAction",
                type: "POST",
                processData: false,
                contentType: false,
                data: data,               //Q => Question
                dataType: 'json',
                success: function (data) {
                    if (data == 'True') {

                        //notify('Barcode Already Exist,Please Enter New One.', 'warning')
                        $("#displayErrorMessage p").text("Barcode Already Exist,Please Enter New One").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                        $("#BarCode").val("");
                        return false;

                    }

                },
                error: function (er) {
                    alert(er);
                }
            });
        });

        InitAnimatedBorder();

        CloseAlert();
        $("#displayErrorMessage1 button[class=close]").on("click", function () {
            $("#displayErrorMessage1").hide();
        });

        //Tabs
        
        //Append data on attribute tab

        $('#btnAttribute').on("click", function () {
            if ($('#AttributeName :selected').val() == "")
            {
                notify("Please Select Attribute Name.","warning");
                return false;
            }
           // alert($('#AttributeName :selected').val())
          
            var DataArray = [];
            var data = $('#tblDataAttr tbody tr td  input').each(function () {
                DataArray.push($(this).val());
            });
            var TotalRecord = DataArray.length;
            
            for (var i = 0; i < TotalRecord; i = i + 5) {
             
                if (DataArray[i + 3] == $('#AttributeName :selected').val()) {
                    $("#displayErrorMessage p").text("You Cannot Enter the Same Attribute Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#AttributeName").val("");
                    return false;
                }

            }


            $("#tblDataAttr tbody").append(
                                       "<tr>" +
                                        "<td style=display:none><input id='GeneralItemAttributeDataID' type='hidden' value=0 style='display:none' />" + $('#GeneralItemAttributeDataID').val() + "</td>" +
                                       
                                       "<td style=display:none><input id='GeneralItemMasterID' type='hidden' value=" + $('#GeneralItemMasterID').val() + " style='display:none' />" + $('#GeneralItemMasterID').val() + "</td>" +
                                       "<td style=display:none><input id='ItemNumber' type='hidden' value=" + $('#ItemNumber').val() + " style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                                       "<td style=display:none><input id='InventoryAttributeMasterID' type='hidden' value=" + $('#AttributeName :selected').val() + " style='display:none' />" + $('#AttributeName :selected').val() + "</td>" +
                                       "<td><input id='AttributeName' type='text' value=" + $('#AttributeName :selected').text() + " style='display:none' />" + $('#AttributeName :selected').text() + "</td>" +
                                       "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                       "</tr>"
                                      );

            $("#tblDataAttr tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

        });
        //Code for add BaseUom And Its Alt Uom(Artical Level) in Uom Details Tab
        $('#btnAdd').unbind("click").on("click", function () {
            GeneralItemMaster.S1 = $("#IsSaleUnit").is(":checked") ? "true" : "false";
            //if (GeneralItemMaster.S1 == "true") {
            //    if ($("#BarCode").val() == "" || $("#BarCode").val() == null) {
            //        $("#displayErrorMessage p").text("Please Enter BarCode").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //        return false;

            //    }
            //    else if ($("#BarCode").val().length < 8) {
            //        $("#displayErrorMessage p").text("Please Enter More Than 8 Digit BarCode").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //        return false;
            //    }
            //}
            if ($("#UomCode").val() == "" || $("#UomCode").val() == null) {
                $("#displayErrorMessage p").text("Please Select UoM Code").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($("#BaseQty").val() == "" || $("#BaseQty").val() == 0 || $("#BaseQty").val() == '.') {
                $("#displayErrorMessage p").text("Please Enter Conversion").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($("#BaseUoMcode").val() == "" || $("#BaseUoMcode").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Lower Level UoM").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }

            //else if ($("#Length").val() == null || $("#Length").val() == "" || $("#Length").val() == 0) {
            //    $("#displayErrorMessage p").text("Please Enter Length.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    return false;
            //}
            //else if ($("#WidthOfItem").val() == null || $("#WidthOfItem").val() == "" || $("#WidthOfItem").val() == 0) {
            //    $("#displayErrorMessage p").text("Please Enter Width.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    return false;
            //}
            //else if ($("#HeightOfItem").val() == null || $("#HeightOfItem").val() == "" || $("#HeightOfItem").val() == 0) {
            //    $("#displayErrorMessage p").text("Please Enter Height.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    return false;
            //}


            //to check duplication of item while adding the item
            var cnt = 0;
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            var IsOrder = $("#IsOrderUnit").is(":checked") ? "true" : "false";
            var IsBase = $("#IsBaseUom").is(":checked") ? "true" : "false";
            var IsIssue = $("#IsIssueUnit").is(":checked") ? "true" : "false";
            var Issale = $("#IsSaleUnit").is(":checked") ? "true" : "false";
           
            TotalRecord = DataArray.length;
            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 13) {

               
                if (DataArray[i + 1] == $('#UomCode').val()) {
                    $("#displayErrorMessage p").text("You Cannot Enter the Same UOM Twice").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#UomCode").val("");
                    $("#BaseQty").val("");
                    $("#BaseUoMcode").val("");
                    $("#BarCode").val("");
                    $('#UomCode').focus();
                    $("#IsBaseUom").removeAttr('checked');
                    return false;
                }
                
                else if (DataArray[i + 3] != $('#BaseUoMcode').val()) {

                    $("#displayErrorMessage p").text("Please select correct Lower UOM").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
                    else if (DataArray[i + 5] == 1 && IsOrder == "true") {

                        $("#displayErrorMessage p").text("There should be only one Order Unit code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                        return false;
                    }
                else if (DataArray[i + 2] == $('#BaseQty').val()) {

                    $("#displayErrorMessage p").text("Conversion value already exists.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
                else if ((IsOrder == "false") && (IsBase == "false") && (IsIssue == "false") && (Issale == "false")) {

                    $("#displayErrorMessage p").text("Please Check At least one UOM Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
                else {
                    var IsBaseUom = $("#IsBaseUom").is(":checked") ? "true" : "false";

                    if (IsBaseUom == "true" && DataArray[i + 4] == 'on') {

                        $("#displayErrorMessage p").text("There should be only one Base UOM code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                        return false;
                    }
                }
            }
            //End Of Code



            //Volume Calculation

            var Volume = parseFloat($('#Length').val() * $('#WidthOfItem').val() * $('#HeightOfItem').val());

            $("#Volume").val(Volume);
            //$("#Volume1").val(Volume);


            if ($('#UomCode').val() != "" && $('#UomCode').val() != null) {
                //Code For IsBase Uom Check box
                var IsBaseUom = $("#IsBaseUom").is(":checked") ? "true" : "false";
                var IsBaseUom1;
                if (IsBaseUom == "true") {
                    IsBaseUom1 = "<td> <input id='IsBaseUom1' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
                    $("#IsBaseUom").removeAttr('checked');
                    $("#IsBaseUom").val("");
                }


                else {
                    IsBaseUom1 = "<td> <input id='IsBaseUom1' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
                    $("#IsBaseUom").removeAttr('checked');
                    $("#IsBaseUom").val("");
                }
                //Code For IsBase Uom Check box Ends
                //Code For IsBase Uom Check box
                var IsOrderUnit = $("#IsOrderUnit").is(":checked") ? "true" : "false";
                var IsOrderUnit1;
                if (IsOrderUnit == "true") {
                    IsOrderUnit1 = "<td> <input id='IsOrderUnit1' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
                    $("#IsOrderUnit").removeAttr('checked');
                    $("#IsOrderUnit").val("");
                }
                else {
                    IsOrderUnit1 = "<td> <input id='IsOrderUnit1' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
                    $("#IsOrderUnit").removeAttr('checked');
                    $("#IsOrderUnit").val("");
                }
                //Code For IsBase Uom Check box Ends
                //Code For IsBase Uom Check box
                var IsIssueUnit = $("#IsIssueUnit").is(":checked") ? "true" : "false";
                var IsIssueUnit1;
                if (IsIssueUnit == "true") {
                    IsIssueUnit1 = "<td> <input id='IsIssueUnit1' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
                    $("#IsIssueUnit").removeAttr('checked');
                    $("#IsIssueUnit").val("");
                }
                else {
                    IsIssueUnit1 = "<td> <input id='IsIssueUnit1' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
                    $("#IsIssueUnit").removeAttr('checked');
                    $("#IsIssueUnit").val("");
                }
                //Code For IsBase Uom Check box Ends
                //Code For IsBase Uom Check box
                var IsSaleUnit = $("#IsSaleUnit").is(":checked") ? "true" : "false";
                var IsSaleUnit1;
                if (IsSaleUnit == "true") {
                    IsSaleUnit1 = "<td> <input id='IsSaleUnit1' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
                    $("#IsSaleUnit").removeAttr('checked');
                    $("#IsSaleUnit").val("");
                }
                else {
                    IsSaleUnit1 = "<td> <input id='IsSaleUnit1' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
                    $("#IsSaleUnit").removeAttr('checked');
                    $("#IsSaleUnit").val("");
                }


                //Code For IsBase Uom Check box Ends
                //if (s1 == "true" && $('#BarCode').val() != "")
                $("#tblData tbody").append(
                                     "<tr>" +
                                     "<td style=display:none><input id='UomCode' type='hidden' value=0 style='display:none' />" + $('#GeneralItemCodeID').val() + "</td>" +
                                     "<td><input id='UomCode' type='text' value=" + $('#UomCode').val() + " style='display:none' />" + $('#UomCode').val() + "</td>" +
                                     "<td ><input type='text' value=" + $('#BaseQty').val() + " style='display:none' /> " + $('#BaseQty').val() + "</td>" +
                                     "<td><input id='AltQty' type='text' value=" + $('#BaseUoMcode').val() + " style='display:none'  />" + $('#BaseUoMcode').val() + "</td>" +
                                     IsBaseUom1 +
                                     IsOrderUnit1 +
                                     IsIssueUnit1 +
                                     IsSaleUnit1 +
                                      "<td><input id='BarCode' class='form-control' type='text' value='" + $('#BarCode').val() + "' style=''/></td>" +
                                        "<td><input id='Length1' class='form-control' type='text' value=" + parseFloat($('#Length').val()) + " style=''/></td>" +
                                       "<td><input id='WidthOfItem1' class='form-control' type='text' value=" + parseFloat($('#WidthOfItem').val()) + " style=''/></td>" +
                                     "<td><input id='HeightOfItem1' class='form-control' type='text' value=" + parseFloat($('#HeightOfItem').val()) + " style=''/></td>" +
                                     "<td><input id='Volume1' class='form-control' type='text' value=" + Volume + " style='' /></td>" +
                                    //"<td><input id='Volume' type='text' value=" + Volume + " style='display:none' /> " + (Volume).toFixed(2) + "</td>" +
                                     "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                     "</tr>"
                                    );


                $("#UomCode").val("");
                $("#BaseQty").val("");
                $("#BaseUoMcode").val("");
                $("#BarCode").val("");
                $("#Length").val(0);
                $("#WidthOfItem").val(0);
                $("#HeightOfItem").val(0);
                $('#UomCode').focus();
                $("#IsBaseUom").removeAttr('checked');
                aaa = "";

            }
            //Delete record in table
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

        });
        //Code for add Varients in Uom Restaurant Menu Tab
        $('#btnAdd2').on("click", function () {
            if ($('#RecipeVariationTitle').val() != "" && $('#RecipeVariationTitle').val() != null) {
                $("#tblDataForDefineVarient tbody").append(
                                     "<tr>" +
                                     "<td style=display:none><input id='InventoryRecipeMasterID' type='hidden' value=0 style='display:none' />" + $('#InventoryRecipeMasterID').val() + "</td>" +
                                     "<td><input id='RecipeVariationTitle' type='text' value=" + $('#RecipeVariationTitle').val().replace(/ /g, "~") + " style='display:none' />" + $('#RecipeVariationTitle').val() + "</td>" +
                                     "<td ><input type='text' value=" + $('#MenuDescription').val().replace(/ /g, "~") + " style='display:none' /> " + $('#MenuDescription').val() + "</td>" +
                                     "<td><input id='IsActive' type='checkbox' checked disabled='disabled' /></td>" +
                                     "<td><input id='Cost' type='text' class='form-control' value=" + parseFloat($('#Cost').val()).toFixed(2) + " style='' /></td>" +
                                     "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                     "</tr>"
                                    );

                $("#RecipeVariationTitle").val("");
                $("#MenuDescription").val("");
                $("#Cost").val("");

                $('#RecipeVariationTitle ').focus();


            }
            //Delete record in table
            $("#tblDataForDefineVarient tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

        });

        $('#DeleteItem').unbind('click').on('click', function () {
            var ItemNumber = $('#ItemNumber').val();
            if (ItemNumber == '' || ItemNumber == 0) {
                notify('Please select Item', 'warning');
                return false;
            }
            $.ajax(
            {
                cache: false,
                type: "GET",
                dataType: "json",
                data: { "ItemNumber": ItemNumber },
                url: '/GeneralItemMaster/Delete',
                success: function (result) {
                    var splitData = result.split(',');
                    
                    if (splitData[1] == 'success') {
                        
                        $("#ItemDescription").val("");
                        $("#ItemNumber").val("0");

                        $("#ItemCategoryCode").val("");
                        $('#ManufacturCatalogNumber').val("");
                        $('#UoMGroupCode').val("");
                        $('#BaseUoMcode').val("");
                        $('#Price').val("");
                        $('#BaseBarCode').val("");
                        $('#GeneralCurrencyListItems').val("");
                        $('#BasePriceListID').val(" ");
                        $('#InventoryPurchaseGroupMasterId').val("");
                        $('#Temprature').val("");
                        //$('#TempratureUpto').val("");
                        $('#IsFixedAssetItem').removeAttr('checked');
                        $('#IsSalesItem').removeAttr('checked');
                        $('#IsPurchaseItem').removeAttr('checked');
                        $('#IsInventoryItem').removeAttr('checked');
                        $('#RetailSale').removeAttr('checked');
                        $('#BOM').removeAttr('checked');
                        $('#Restaurant').removeAttr('checked');
                        $('#IsMultipleVendor').removeAttr('checked');
                        $('#IsEComItem').removeAttr('checked');
                        $('#IsServiceItem').removeAttr('checked');
                        

                        $('#VendorName').val("");
                        $('#GenTaxGroupMasterID').val("");
                        $('#GeneralItemSupliersDataID').val("");
                        $('#GeneralPurchaseGroupMasterID').val("");
                        $('#PurchaseUoMCode').val("");
                        $('#PackageType').val("");
                        $('#GeneralItemMasterID').val(0);
                        $('#GeneralItemCodeID').val("");

                        $('#NetContentPerPiece').val("");
                        $('#NetContentUOM').val("");
                        $('#NetWeightPerPiece').val("");
                        $('#SpecialFeature').val("");
                        $('#ShortDescription').val("");
                        $('#BrandName').val("");

                        $("#GeneralItemGeneralData").click();
                    }
                    notify(splitData[0], splitData[1]);
                }
            });                                                             
        });
    },

    CheckedAll: function () {
        $("#StoreDatatblData thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#StoreDatatblData tbody tr td  input[class='check-user']").prop("checked", true);
            }
            else {
                $("#StoreDatatblData tbody tr td  input[class='check-user']").prop("checked", false);
            }
        });
    },


    //insert record
    Create: function () {
        $('#CreateGeneralItemMasterRecord').on("click", function () {
            
            var val = $('#ItemDescription').val();
            if (!/^[a-zA-Z0-9_&',-.%+/() ]+$/.test(val)) {
                $('#DataValidationMessageForItemName').text("Please enter alpha-numeric text.").css("color", "red");
                return false;
            }
            $('#DataValidationMessageForItemName').text("");
            GeneralItemMaster.ActionName = "Create";
            var TaskCode = $('#TaskCode').val();
            if (TaskCode == 'GeneralItemUoMData') {
                GeneralItemMaster.GetXmlData();
            }
            else if (TaskCode == 'GeneralItemSalesData') {


                if ($('#SaleUoMDetailstblData tr').length == 0 && $('#GeneralUnitsID :selected').val() != "") {

                    $("#displayErrorMessage p").text("Please Select Uom Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
                else if ($('#SaleUoMDetailstblData tr').length == 0 && $('#GeneralUnitsID :selected').val() == "") {

                    $("#displayErrorMessage p").text("Please Select Uom Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
                GeneralItemMaster.GetXmlDataForSaleUoMCode();

            }
            else if (TaskCode == 'GeneralItemstoreData') {

                GeneralItemMaster.GetXmlDataForStoreData();

            }
            else if (TaskCode == 'GeneralItemRestaurantData') {
                //GeneralItemMaster.GetRecipeImage('CreateGeneralItemMasterRecord');
                //if ($('#PriceForRecipe').val() <= 0 || $('#PriceForRecipe').val() <= "") {
                //    $("#displayErrorMessage p").text("Please Enter Price").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                //    return false;
                //}
                GeneralItemMaster.GetXmlDataForRestuarantData();
            }
            else if (TaskCode == 'GeneralItemSupliersData') {

                if ($('#PurchaseUoMCode :selected').val() == "") {
                    $("#displayErrorMessage p").text("Please Select Purchase Uom Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
                else if ($('#GeneralPurchaseGroupMasterID :selected').val() == "") {
                    $("#displayErrorMessage p").text("Please Select Purchase Group.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }

            }
            else if (TaskCode == 'GeneralItemAttributeData') {
                GeneralItemMaster.GetXmlDataForAttributeData();
            }

            else if (TaskCode == 'GeneralItemEcommerceData') { //----------------------------------------nj---------------
                GeneralItemMaster.GetXmlDataForMultipleImageUpload();
            }
            GeneralItemMaster.AjaxCallGeneralItemMaster();
        });
    },
    Save: function () {
        
        $('#SaveGeneralItemMasterRecord').on("click", function () {
            //for Check box validation
            debugger
            var RS = $('#RetailSale').is(":checked") ? "true" : "false";
            var BOM = $('#BOM').is(":checked") ? "true" : "false";
            var FA = $('#IsFixedAssetItem').is(":checked") ? "true" : "false";
            var RT = $('#Restaurant').is(":checked") ? "true" : "false";
            var SI = $('#IsServiceItem').is(":checked") ? "true" : "false";
            var CI = $('#IsConsumable').is(":checked") ? "true" : "false";
            var MI = $('#IsMachine').is(":checked") ? "true" : "false";
            var TI = $('#IsToner').is(":checked") ? "true" : "false";

            var val = $('#ItemDescription').val();
            if (!/^[a-zA-Z0-9_&',-.+%/() ]+$/.test(val)) {
                $('#DataValidationMessageForItemName').text("Please enter alpha-numeric text.").css("color", "red");
                return false;
            }
            $('#DataValidationMessageForItemName').text("");
            GeneralItemMaster.ActionName = "Save";
            var TaskCode = $('#TaskCode').val();

            if (TaskCode == 'GeneralItemUoMData') {
              
                //$('#tblData BarCode').each(function () {
                //    var BarcodeLen = $(this).val();
                //    alert(BarcodeLen)
                //    if (BarcodeLen.length < 8)
                //    notify("Please Add Barcode greater than 8 digits.", "danger");
                //    return false;

                //});

                if ($('#tblData tbody tr').length == 0) {
                    notify("Please Add at least one uom.", "danger");
                    return false;
                }
                GeneralItemMaster.CheckBarcode = true;
                GeneralItemMaster.GetXmlData();
               
                //if (GeneralItemMaster.CheckBarcode == false) {
                //    notify("Please Enter Barcode.", "danger");
                //    return false;
                //}else 
                if ((RS == "false") && (BOM == "false") && (FA == "false") && (RT == "false") && (SI == "false") && (MI == "false")) {
                    notify("Please Select Item Type", "warning");
                    return false;
                }

                if ((GeneralItemMaster.CheckBase == false || GeneralItemMaster.CheckOrder == false || GeneralItemMaster.CheckSale == false) && GeneralItemMaster.NotificationAccepted == false) {
                    //swal({
                    //    title: 'Required UOM Details',
                    //    text: "Please Check Baseunit, orderunit and sale unit.",
                    //    //type: points[parseInt(settings.bulktype)]['type'],
                    //    //showCancelButton: true,
                    //    confirmButtonClass: 'btn-success',
                    //    confirmButtonText: "Ok!"
                    //}, function (isConfirm) {
                    //    if (isConfirm) {
                    //        GeneralItemMaster.NotificationAccepted == true;
                    //    }
                    //});
                    GeneralItemMaster.NotificationAccepted == true;
                   // notify("Please Check Baseunit, orderunit and sale unit.", "warning", {});
                    $.growl({
                        message: "Please Check Baseunit, Orderunit."
                    }, {
                        type: "warning",
                        allow_dismiss: false,
                        label: 'Cancel',
                        className: 'btn-xs btn-inverse',
                        placement: {
                            from: 'bottom',
                            align: 'right'
                        },
                        delay: 2500,
                        animate: {
                            enter: 'animated fadeIn',
                            exit: 'animated fadeOut'
                        },
                        offset: {
                            x: 20,
                            y: 85
                        }
                    });
                }

            }
            else if (TaskCode == 'GeneralItemSalesData') {
                if ($('#SaleUoMDetailstblData tr').length == 0 && $('#GeneralUnitsID :selected').val() != "") {

                    $("#displayErrorMessage p").text("Please Select Store.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }
                //else if ($('#SaleUoMDetailstblData tr').length == 0 && $('#GeneralUnitsID :selected').val() == "") {

                //    $("#displayErrorMessage p").text("Please Select Uom Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                //    return false;
                //}
               
                else if ((RS == "false") && (BOM == "false") && (FA == "false") && (RT == "false") &&(SI=="false")) {
                    notify("Please Select Item Type", "warning");
                    return false;
                }
                GeneralItemMaster.CheckPrice = true;
                GeneralItemMaster.GetXmlDataForSaleUoMCode();
                //if (GeneralItemMaster.CheckPrice == false) {
                //    notify("Please Enter Price.", "warning");
                //    //  return false;
                //}

            }
            else if (TaskCode == 'GeneralItemstoreData') {
               
                GeneralItemMaster.GetXmlDataForStoreData();

                if (GeneralItemMaster.CheckInfo == false) {
                    notify("Please Select At least one Store Before Saving Information.", "danger");
                    return false;
                }
                else if ((RS == "false") && (BOM == "false") && (FA == "false") && (RT == "false") && (SI == "false")) {
                    notify("Please Select Item Type", "warning");
                    return false;
                }

            }
            else if (TaskCode == 'GeneralItemRestaurantData') {
                
                //   GeneralItemMaster.GetRecipeImage('GeneralItemRestaurantData');
                if (BOM == "false")
                {
                if ($('#RecipeMenuCategoryID :selected').val() == "") {
                    notify("Please Select Recipe Menu Category.", "danger");
                    return false;
                }
            }
            else if ($('#BillingItemName').val() == "" || $('#BillingItemName').val() == null) {
                notify("Please Enter Billing Item Name.", "danger");
                return false;
            }
            else if ($('#InventoryRecipeMasterTitle').val() == "" || $('#InventoryRecipeMasterTitle').val() == null) {
                notify("Please Enter Main Menu Item.", "danger");
                return false;
            }
            else if ((RS == "false") && (BOM == "false") && (FA == "false") && (RT == "false") && (SI=="false")) {
                notify("Please Select Item Type", "warning");
                return false;
            }
                if ($('#No').is(':checked'))
                {
                    if (BOM == "false")
                   {
                 if ($('#PriceForRecipe').val() == "" || $('#PriceForRecipe').val() == null || $('#PriceForRecipe').val() == 0) {
                        notify("Please Enter Price.", "danger");
                        return false;
                    }
                }
                }
                else {
                    GeneralItemMaster.GetXmlDataForRestuarantData();
                }
            }
            else if (TaskCode == 'GeneralItemSupliersData') {
                
                debugger;
                if ($('#PurchaseUoMCode').val() == "" || ($('#PurchaseUoMCode').val() == null)) {
                    notify("Please Select Purchase Uom Code.", "warning");
                    return false;
                }
                else if ($('#VendorName').val() == "") {
                    notify("Please Enter Vendor Name.", "warning");
                    return false;
                }
                else if ($('#LeadTime').val()=="" ||$('#LeadTime').val()==null ||$('#LeadTime').val() == 0)
                {
                    notify("Please Enter LeadTime For Selected Vendor.", "warning");
                    return false;
                }
                
                else if (($('#GeneralPurchaseGroupMasterID').val() == "")||($('#GeneralPurchaseGroupMasterID').val() == null)) {
                    notify("Please Select Purchase Group.", "warning");
                    return false;
                }
                else if ($('#LastPurchasePrice').val() == "") {
                    notify("Please Enter Cost.", "warning");
                    return false;
                }
                else if ($('#MinimumOrderquantity').val() == 0 || $('#MinimumOrderquantity').val() == "") {
                    notify("Please Enter Minimum Order Quantity.", "warning");
                    return false;
                }
                else if ((RS == "false") && (BOM == "false") && (FA == "false") && (RT == "false") && (SI == "false")) {
                    notify("Please Select Item Type", "warning");
                    return false;
                }
                
                

            }
            else if (TaskCode == 'GeneralItemGeneralData') {
                
                

                $('#ItemCategoryCode_Param').val($('#ItemCategoryCode').val());
                if ($('#ItemCategoryCode :selected').val() == "") {
                    notify("Please Select Item Category Code.", "warning")
                    return false;
                }
                else if ($('#GenTaxGroupMasterID :selected').val() == "") {
                    notify("Please Select Tax Group.", "warning")
                    return false;
                }
               else if ($('#HSNCode').val() == "") {
                    notify("Please Enter HSN Code.", "warning")
                    return false;
                }
                //else if ($('#Temprature :selected').val() == "") {
                //    notify("Please Select Temperature.", "warning")
                //    return false;
                //}
                else if ((RS == "false") && (BOM == "false") && (FA == "false") && (RT == "false") && (SI == "false"))
                {
                    notify("Please Select Item Type", "warning");
                    return false;
                }

            }
            else if (TaskCode == 'GeneralItemServiceData') {



                if ($('#GenTaxGroupMasterID :selected').val() == "") {
                    notify("Please Select Tax Group.", "warning")
                    return false;
                }
                else if ($('#HSNCode').val() == "") {
                    notify("Please Enter HSN Code.", "warning")
                    return false;
                }
                
                else if ((RS == "false") && (BOM == "false") && (FA == "false") && (RT == "false") && (SI == "false")) {
                    notify("Please Select Item Type", "warning");
                    return false;
                }

            }
            else if (TaskCode == 'GeneralItemAttributeData') {
                
                if ((RS == "false") && (BOM == "false") && (FA == "false") && (RT == "false") && (SI == "false")) {
                    notify("Please Select Item Type", "warning");
                    return false;
                }
                GeneralItemMaster.GetXmlDataForAttributeData();
            }
            else if (TaskCode == 'GeneralItemEcommerceData') { 
                GeneralItemMaster.GetXmlDataForMultipleImageUpload();
            }
            if (TaskCode == 'GeneralItemSupliersData' && $('#LastPurchasePrice').val() == 0)
            {
                $(".sweet-overlay").css('z-index', 1043)
                swal({

                    title: 'Confirm Purchase Price',
                    text: "Purchase Price Of "+$('#ItemDescription').val() +" is 0",
                    //type: points[parseInt(settings.bulktype)]['type'],
                    showCancelButton: true,
                    confirmButtonClass: 'btn-success',
                    confirmButtonText: "OK!"

                }, function (isConfirm) {
                    if (isConfirm) {
                        GeneralItemMaster.AjaxCallGeneralItemMaster();

                    }
                    else {
            
                        $('#SaveGeneralItemMasterRecord').attr("disabled", false);
                        return false
                    }
                });
            
            }
            else
                {
                GeneralItemMaster.AjaxCallGeneralItemMaster();
            }
        });
    },
    CreateTab: function () {
        $('ul#TaskList li').click(function () {
            
            var Newurl = '';
            var TaskCode = $(this).attr('id');
            var GeneralItemMasterID = $('input[name=GeneralItemMasterID]').val();
            var ItemNumber = $('#ItemNumber').val();
            var ItemDescription = $('#ItemDescription').val();
            var GeneralUnitsID = $('#GeneralUnitsID').val();
            var ItemCategoryCode_Param = $('#ItemCategoryCode_Param').val();
            
            var GeneralVendorID = $('#GeneralVendorID').val();
            var IsMultipleVendor = $('#IsMultipleVendor').is(":checked") ? "true" : "false";
            var SelectedCentreCodeForSaleTab = $('#SelectedCentreCodeForSaleTab').val();
            var CentreCode = $('#SelectedCentreCode').val();

            if (TaskCode == "GeneralItemSupliersData") {
                Newurl = '/GeneralItemMaster/CreateGeneralItemSuppliersData';
            }
            else if (TaskCode == "GeneralItemGeneralData") {
                Newurl = '/GeneralItemMaster/CreateGeneralItemGeneralData';
            }
            else if (TaskCode == "GeneralItemSalesData") {
                Newurl = '/GeneralItemMaster/SaleUomCodeData';
            }
            else if (TaskCode == "GeneralItemStockData") {
                Newurl = '/GeneralItemMaster/CreateGeneralItemStockData';
            }
            else if (TaskCode == "GeneralItemUoMData") {
                Newurl = '/GeneralItemMaster/GeneralItemUoMData';
            }
            else if (TaskCode == "GeneralItemWarehouseData") {
                Newurl = '/GeneralItemMaster/CreateGeneralItemWarehouseData';
            }
            else if (TaskCode == "GeneralItemstoreData") {
                Newurl = '/GeneralItemMaster/CreateGeneralItemStoreData';
            }
            else if (TaskCode == "GeneralItemRestaurantData") {

                Newurl = '/GeneralItemMaster/CreateGeneralItemRestaurantData';
            }
            else if (TaskCode == "GeneralItemAttributeData") {

                Newurl = '/GeneralItemMaster/CreateGeneralItemAttributeData';
            }
            else if (TaskCode == "GeneralItemEcommerceData") {

                Newurl = '/GeneralItemMaster/CreateGeneralItemEcommerceData';
            }
            else if (TaskCode == "GeneralItemServiceData") {

                Newurl = '/GeneralItemMaster/CreateGeneralItemServiceData';
            }
            $.ajax(
                  {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: { "TaskCode": TaskCode, "ItemNumber": ItemNumber, "GeneralItemMasterID": GeneralItemMasterID, "GeneralVendorID": GeneralVendorID, "ItemCategoryCode_Param": ItemCategoryCode_Param, "IsMultipleVendor": IsMultipleVendor, "ItemDescription": ItemDescription, "CentreCode": CentreCode, "SelectedCentreCodeForSaleTab": SelectedCentreCodeForSaleTab, "GeneralUnitsID": GeneralUnitsID },
                      url: Newurl,
                      success: function (result) {
                          //alert(result);
                          $('.tab-content').html(result);
                      }
                  });

        });
    },
    //Code For Receipe Image
    GetRecipeImage: function (eventClick) {

        var imgValue = new FormData();
        var files = $("#MenuPhotoFile").get(0).files;
        if (files.length > 0 && (GeneralItemMaster.ImageName == null || GeneralItemMaster.ImageName == "")) {
            imgValue.append("MyImages", files[0]);

            $.ajax({
                url: "/GeneralItemMaster/UploadFile",
                type: "POST",
                processData: false,
                contentType: false,
                data: imgValue,
                dataType: 'json',
                success: function (imgValue) {
                    //code after success                       
                    $("#displayErrorMessage p").text("Uploading visiting card...").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    GeneralItemMaster.ImageName = imgValue;
                    setTimeout(function () { $('#' + eventClick).click(); }, 3000);
                },
                error: function (er) {
                    alert(er);
                }
            });
        }
    },

    //LoadData method is used to load List of all Uom code where Order unit=1
    LoadData: function (TaskCode,ItemNumber,GeneralUnitsID,CentreCode) {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             data: { TaskCode: TaskCode, ItemNumber: ItemNumber, GeneralUnitsID: GeneralUnitsID, SelectedCentreCodeForSaleTab: CentreCode },
             url: '/GeneralItemMaster/SaleUomCodeData',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel1').html(data);

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
             url: '/GeneralItemMaster/List',
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
            url: '/GeneralItemMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    //Method to create xml
    GetXmlData: function () {
        
        var DataArray = [];
        var data = $('#tblData tbody tr td  input').each(function () {
            if ($(this).attr('type') == 'checkbox') {
                DataArray.push($(this).is(":checked") ? 1 : 0);
            }
            else {
                DataArray.push($(this).val());
            }
        });

        //alert(DataArray)
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 13) {
            {
                if ((DataArray[i + 8] == null || DataArray[i + 8] == "") && DataArray[i + 7] == 1) {
                    GeneralItemMaster.CheckBarcode = false;
                }
                if(DataArray[i + 4] == 1)
                {
                    GeneralItemMaster.CheckBase = true;
                }
                if (DataArray[i + 5] == 1) {
                    GeneralItemMaster.CheckOrder = true;
                }
                if (DataArray[i + 7] == 1) {
                    GeneralItemMaster.CheckSale = true;
                }
                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><GeneralItemCodeID>" + DataArray[i] + "</GeneralItemCodeID><UomCode>" + DataArray[i + 1] + "</UomCode><ConversionFactor>" + (DataArray[i + 2]) + "</ConversionFactor><LowerLevelUomCode>" + DataArray[i + 3] + "</LowerLevelUomCode><IsBaseUom>" + DataArray[i + 4] + "</IsBaseUom><IsOrderingUnit>" + DataArray[i + 5] + "</IsOrderingUnit><IsSaleUnit>" + DataArray[i + 7] + "</IsSaleUnit><IsIssueUnit>" + DataArray[i + 6] + "</IsIssueUnit><BarCode>" + DataArray[i + 8] + "</BarCode><Price>0</Price><Length>" + DataArray[i + 9] + "</Length><Width>" + DataArray[i + 10] + "</Width><Height>" + DataArray[i + 11] + "</Height><Volume>" + DataArray[i + 12] + "</Volume></row>";
            }

            if (ParameterXml.length > 11)
                GeneralItemMaster.XMLstring = ParameterXml + "</rows>";
            else
                GeneralItemMaster.XMLstring = "";

        }

        //alert(GeneralItemMaster.XMLstring)

    },
    GetXmlDataForSaleUoMCode: function () {
        debugger;
        var DataArray = [];
        var data = $('#SaleUoMDetailstblData tbody tr td  input').each(function () {
            if ($(this).attr('type') == 'checkbox') {
                DataArray.push($(this).is(":checked") ? 1 : 0);
            }
            else {
                DataArray.push($(this).val());
            }
        });
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 10) {
            if (DataArray[i + 8] == 0) {
                GeneralItemMaster.CheckPrice = false;
            }
            else {
                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><InventoryItemCodeUnitLevelSpecificInfoID>" + DataArray[i] + "</InventoryItemCodeUnitLevelSpecificInfoID><GeneralItemCodeID>" + DataArray[i + 1] + "</GeneralItemCodeID><ItemNumber>" + DataArray[i + 2] + "</ItemNumber><IsBaseUom>" + DataArray[i + 3] + "</IsBaseUom><LowerLevelUomCode>" + DataArray[i + 4] + "</LowerLevelUomCode><ConversionFactor>" + DataArray[i + 5] + "</ConversionFactor><SaleUoMCode>" + DataArray[i + 6] + "</SaleUoMCode><BarCode>" + DataArray[i + 7] + "</BarCode><Price>" + (DataArray[i + 8]) + "</Price><GeneralUnitsID>" + (DataArray[i + 9]) + "</GeneralUnitsID></row>";
            }
            }

        if (ParameterXml.length > 10)
            GeneralItemMaster.XMLstringForSaleUomcode = ParameterXml + "</rows>";
        else
            GeneralItemMaster.XMLstringForSaleUomcode = "";


    },
    GetXmlDataForStoreData: function () {
        
        
        var DataArray = [];

        var DataArray1 = [];
        var data = $('#StoreDatatblData tbody tr td  input').each(function () {


            if ($(this).is(':checkbox')) {
                if (this.checked == true) {
                    GeneralItemMaster.CheckInfo = true;
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

        //alert(DataArray)

        var TotalRecord = DataArray.length;
         //alert(TotalRecord)


        var ParameterXml = "<rows>";

        var $this = $(this);

        for (var i = 0; i < TotalRecord; i = i + 8) {
            if (DataArray[i] == 1) {
                if (DataArray[i + 6] == "" || DataArray[i + 6] == null) {
                    ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><InventoryItemStoreSpecificInfoID>" + DataArray[i + 1] + "</InventoryItemStoreSpecificInfoID><GeneralUnitsID>" + DataArray[i + 4] + "</GeneralUnitsID><ListingDate></ListingDate><DeListingDate>" + DataArray[i + 7] + "</DeListingDate><StatusFlag>1</StatusFlag></row>";
                }
                else if (DataArray[i + 7] == "" || DataArray[i + 7] == null) {
                    ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><InventoryItemStoreSpecificInfoID>" + DataArray[i + 1] + "</InventoryItemStoreSpecificInfoID><GeneralUnitsID>" + DataArray[i + 4] + "</GeneralUnitsID><ListingDate>" + DataArray[i + 6] + "</ListingDate><DeListingDate></DeListingDate><StatusFlag>1</StatusFlag></row>";
                }
                else {
                    ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><InventoryItemStoreSpecificInfoID>" + DataArray[i + 1] + "</InventoryItemStoreSpecificInfoID><GeneralUnitsID>" + DataArray[i + 4] + "</GeneralUnitsID><ListingDate>" + DataArray[i + 6] + "</ListingDate><DeListingDate>" + DataArray[i + 7] + "</DeListingDate><StatusFlag>1</StatusFlag></row>";
                }
            }
           
        }


        if (ParameterXml.length > 8)
            GeneralItemMaster.GeneralItemStoreSpecificDetailsXml = ParameterXml + "</rows>";
        else
            GeneralItemMaster.GeneralItemStoreSpecificDetailsXml = "";
       // alert(GeneralItemMaster.GeneralItemStoreSpecificDetailsXml)

    },
    GetXmlDataForRestuarantData: function () {

        var DataArray = [];
        var data = $('#tblDataForDefineVarient tbody tr td  input').each(function () {

            // DataArray.push($(this).val());
            if ($(this).attr('type') == 'checkbox') {
                DataArray.push($(this).is(":checked") ? 1 : 0);
            }
            else {
                DataArray.push($(this).val());
            }
          
        });
        var TotalRecord = DataArray.length;
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 5) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><InventoryVariationMasterID>" + DataArray[i] + "</InventoryVariationMasterID><RecipeVariationTitle>" + DataArray[i + 1].replace(/~/g, ' ') + "</RecipeVariationTitle><RecipeVariationDescription>" + DataArray[i + 2].replace(/~/g, ' ') + "</RecipeVariationDescription><IsActive>" + DataArray[i + 3] + "</IsActive><Price>" + DataArray[i + 4] + "</Price></row>";
        }
        if (ParameterXml.length > 6)
            GeneralItemMaster.XMLstringForRestuarent = ParameterXml + "</rows>";

        else
            GeneralItemMaster.XMLstringForRestuarent = "";
        
    },
    GetXmlDataForAttributeData: function () {

        var DataArray = [];
        var data = $('#tblDataAttr tbody tr td  input').each(function () {

            DataArray.push($(this).val());

        });
        var TotalRecord = DataArray.length;
        //alert(DataArray)
       // alert(TotalRecord)
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 5) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><GeneralItemAttributeDataID>" + DataArray[i] + "</GeneralItemAttributeDataID><GeneralItemMasterID>" + DataArray[i + 1] + "</GeneralItemMasterID><ItemNumber>" + DataArray[i + 2] + "</ItemNumber><InventoryAttributeMasterID>" + DataArray[i + 3] + "</InventoryAttributeMasterID></row>";
        }
        if (ParameterXml.length > 6)
            GeneralItemMaster.XMLstringForAttribute = ParameterXml + "</rows>";

        else
            GeneralItemMaster.XMLstringForAttribute = "";
       // alert(GeneralItemMaster.XMLstringForAttribute)

    },
    //------------------------------for EComMultipleImage----------------
    GetXmlDataForMultipleImageUpload: function () {
        debugger
        var DataArray = [];
        var TotalRecord = 0;
        var ImageString = $('#EComCroppedImagePath').val();
        if (ImageString != "") {
            var splitData = ImageString.split(',');
            TotalRecord = splitData.length;
        }
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 1) {
            ParameterXml = ParameterXml + "<row><ImageName>" + splitData[i] + "</ImageName></row>";
        }
        if (ParameterXml.length > 1)
            
            GeneralItemMaster.XMLstringForMultipleImageUpload = ParameterXml + "</rows>";

        else
            GeneralItemMaster.XMLstringForMultipleImageUpload = "";
    },
    //Fire ajax call to insert update and delete record
    AjaxCallGeneralItemMaster: function () {
        var GeneralItemMasterData = null;
        if (GeneralItemMaster.ActionName == "Create") {

            $("#FormCreateGeneralItemMaster").validate();
            if ($("#FormCreateGeneralItemMaster").valid()) {
                GeneralItemMasterData = null;
                GeneralItemMasterData = GeneralItemMaster.GetGeneralItemMaster();

                ajaxRequest.makeRequest("/GeneralItemMaster/Create", "POST", GeneralItemMasterData, GeneralItemMaster.Success, "CreateGeneralItemMasterRecord");
            }


        }
        else if (GeneralItemMaster.ActionName == "Save") {
            $("#FormCreateGeneralItemMaster").validate();
            if ($("#FormCreateGeneralItemMaster").valid()) {
                GeneralItemMasterData = null;
                GeneralItemMasterData = GeneralItemMaster.GetGeneralItemMaster();
                ajaxRequest.makeRequest("/GeneralItemMaster/Create", "POST", GeneralItemMasterData, GeneralItemMaster.SaveSuccess, "SaveGeneralItemMasterRecord");

            }
        }
        else if (GeneralItemMaster.ActionName == "CreateMultipleVendor") {
            $("#FormCreateMultipleVendor").validate();
            if ($("#FormCreateMultipleVendor").valid()) {
                GeneralItemMasterData = null;
                GeneralItemMasterData = GeneralItemMaster.GetGeneralItemMaster();
                ajaxRequest.makeRequest("/GeneralItemMaster/MultipleVendor", "POST", GeneralItemMasterData, GeneralItemMaster.MultipleVendorSuccess, "CreateMultipleVendorRecord");

            }
        }
        else if (GeneralItemMaster.ActionName == "UploadExcel") {

            $("#FormCreateGeneralItemMasterExcel").validate();
            if ($("#FormCreateGeneralItemMasterExcel").valid()) {
                GeneralItemMaster = null;
                GeneralItemMaster = GeneralItemMaster.GetExcelDetails();

                ajaxRequest.makeRequest("/GeneralItemMaster/UploadExcel", "POST", GeneralItemMasterData, GeneralItemMaster.SaveSuccess, "CreateGeneralItemMasterRecordExcel");

            }
        }
        else if (GeneralItemMaster.ActionName == "CreateStoreSpecificInformation") {

            $("#FormCreateStoreSpecificInformation").validate();
            if ($("#FormCreateStoreSpecificInformation").valid()) {
                GeneralItemMasterData = null;
                $('#CreateStoreSpecificInformation').prop("disabled", true);
                GeneralItemMasterData = GeneralItemMaster.GetGeneralItemMaster();

                ajaxRequest.makeRequest("/GeneralItemMaster/CreateStoreSpecificInformation", "POST", GeneralItemMasterData, GeneralItemMaster.StoreSpecificInformationSuccess, "CreateStoreSpecificInformation");

            }
        }
        else if (GeneralItemMaster.ActionName == "Edit") {
            $("#FormEditGeneralItemMaster").validate();
            if ($("#FormEditGeneralItemMaster").valid()) {
                GeneralItemMasterData = null;

                GeneralItemMasterData = GeneralItemMaster.GetGeneralItemMaster();

                ajaxRequest.makeRequest("/GeneralItemMaster/Edit", "POST", GeneralItemMasterData, GeneralItemMaster.Success);

            }
        }
        else if (GeneralItemMaster.ActionName == "Delete") {
            GeneralItemMasterData = null;
            //$("#FormCreateGeneralItemMaster").validate();
            GeneralItemMasterData = GeneralItemMaster.GetGeneralItemMaster();
            ajaxRequest.makeRequest("/GeneralItemMaster/Delete", "POST", GeneralItemMasterData, GeneralItemMaster.Success);

        }
       
    },

    GetExcelDetails: function () {
        var Data = {
        };
        if (GeneralItemMaster.ActionName == "UploadExcel") {


            var data = new FormData();
            var files = $("#ExcelFile").get(0).files;
            if (files.length > 0) {
                data.append("ExcelFile", files[0]);
                $.ajax({
                    url: "/GeneralItemMaster/UploadExcelFile",
                    type: "POST",
                    processData: false,
                    contentType: false,
                    data: data,               //Q => Question
                    dataType: 'json',
                    success: function (data) {
                        //  CRMCallEnquiryDetails.XMLstringParam = $.parseXML(data);
                        // Data.XMLstring = data;
                        //  alert(CRMCallEnquiryDetails.XMLstring);
                    },
                    error: function (er) {
                        alert(er.error);

                    }

                });

            }

            // Data.XMLstring = CRMCallEnquiryDetails.XMLstringParam;
            //  alert(CRMCallEnquiryDetails.XMLstringParam);
        }

        return Data;
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralItemMaster: function () {

        var Data = {
        };
        //For Image
        //var MenuPhotoFileSize = null;
        //var MenuPhotoType = null;
        //var MenuPhotoFilename = null;
        //var MenuPhotoFileWidth = null;
        //var MenuPhotoFileHeight = null;
        //
        //var img = document.getElementById('previewMenuPhoto');
        //if ($("#MenuPhotoFile").val() != "") {
        //    if (typeof ($("#MenuPhotoFile")[0].files) != "undefined") {
        //        MenuPhotoFileSize = $("#MenuPhotoFile")[0].files[0].size;
        //        MenuPhotoType = $('#MenuPhotoFile')[0].files[0].type;
        //        MenuPhotoFilename = $('#MenuPhotoFile')[0].files[0].name;
        //        MenuPhotoFileWidth = img.width;
        //        MenuPhotoFileHeight = img.height;
        //    }

        //    
        //    if (MenuPhotoType == "image/jpeg") {
        //        Data.MenuPhoto = $('#previewMenuPhoto').attr('src').replace(/data:image\/jpeg;base64,/g, '');
        //    }
        //    else if (MenuPhotoType == "image/png") {
        //        Data.MenuPhoto = $('#previewMenuPhoto').attr('src').replace(/data:image\/png;base64,/g, '');
        //    }
        //    else if (MenuPhotoType == "image/gif") {
        //        Data.MenuPhoto = $('#previewMenuPhoto').attr('src').replace(/data:image\/gif;base64,/g, '');
        //    }
        //    else if (MenuPhotoType == "image/jpg") {
        //        Data.MenuPhoto = $('#previewMenuPhoto').attr('src').replace(/data:image\/jpg;base64,/g, '');
        //    }
        //    else if (MenuPhotoType == "image/bmp") {
        //        Data.MenuPhoto = $('#previewMenuPhoto').attr('src').replace(/data:image\/bmp;base64,/g, '');
        //    }

        //    Data.MenuPhotoType = MenuPhotoType;
        //    Data.MenuPhotoFilename = MenuPhotoFilename;
        //    Data.MenuPhotoFileWidth = MenuPhotoFileWidth;
        //    Data.MenuPhotoFileHeight = MenuPhotoFileHeight;
        //    Data.MenuPhotoFileSize = MenuPhotoFileSize;
        //}
        if (GeneralItemMaster.ActionName == "Create" || GeneralItemMaster.ActionName == "Edit" || GeneralItemMaster.ActionName == "Save") {
            Data.GeneralItemMasterID = $('input[name=GeneralItemMasterID]').val();
            Data.ItemNumber = $('#ItemNumber').val();
            Data.ItemDescription = $('#ItemDescription').val();
            Data.ItemCode = $('#ItemCode').val();

            Data.ItemType = $('#ItemType').val();
            Data.InventoryPurchaseGroupMasterId = $('#InventoryPurchaseGroupMasterId').val();
            Data.UoMGroupCode = $('#UoMGroupCode').val();
            Data.BaseUoMcode = $('#BaseUoMcode').val();
            Data.BasePriceListID = $('#BasePriceListID').val();
            Data.BaseBarCode = $('#BaseBarCode').val();
            Data.LastPurchasePrice = $('#Price').val();
            Data.IsInventoryItem = $("#IsInventoryItem").is(":checked") ? "true" : "false";
            Data.IsSalesItem = $("#IsSalesItem").is(":checked") ? "true" : "false";
            Data.IsPurchaseItem = $("#IsPurchaseItem").is(":checked") ? "true" : "false";
            Data.CurrencyCode = $('#GeneralCurrencyListItems').val();
            Data.IsFixedAssetItem = $('#IsFixedAssetItem').is(":checked") ? "true" : "false";
            Data.RetailSale = $('#RetailSale').is(":checked") ? "true" : "false";
            Data.BOM = $('#BOM').is(":checked") ? "true" : "false";
            Data.Restaurant = $('#Restaurant').is(":checked") ? "true" : "false";
            Data.IsMultipleVendor = $('#IsMultipleVendor').is(":checked") ? "true" : "false";
            Data.IsEComItem = $('#IsEComItem').is(":checked") ? "true" : "false";
            Data.TaskCode = $('#TaskCode').val();
            Data.IsConsumable = $('#IsConsumable').is(":checked") ? "true" : "false";
            Data.IsMachine = $('#IsMachine').is(":checked") ? "true" : "false";
            Data.IsToner = $('#IsToner').is(":checked") ? "true" : "false";
           
            //ItemCode
            Data.GeneralItemCodeID = $('input[name=GeneralItemCodeID]').val();
            Data.Price = $('#Price').val();
            Data.IsDefault = $('#IsDefault').is(":checked") ? "true" : "false";
            Data.IsBaseUom = $('#IsBaseUom').is(":checked") ? "true" : "false";
            Data.IsServiceItem = $('#IsServiceItem').is(":checked") ? "true" : "false";
            Data.UomCode = $('#UomCode').val();


            if (Data.TaskCode == 'GeneralItemSupliersData') {
                //GeneralItemSupliersData
                Data.GeneralItemSupliersDataID = $('input[name=GeneralItemSupliersDataID]').val();
                Data.GeneralVendorID = $('#GeneralVendorID').val();
                Data.ManufacturCatalogNumber = $('#ManufacturCatalogNumber').val();
                Data.PurchaseUoMCode = $('#PurchaseUoMCode').val();
                Data.GeneralPurchaseGroupMasterID = $('#GeneralPurchaseGroupMasterID').val();
                Data.LastPurchasePrice = $('#LastPurchasePrice').val();
                Data.PackageType = $('#PackageType').val();
                Data.PurchaseOrganization = $('#PurchaseOrganization').val();
                Data.MinimumOrderquantity = $('#MinimumOrderquantity').val();
                Data.LeadTime = $('#LeadTime').val();
                Data.ShelfLife = $('#ShelfLife').val();
                Data.CountryOfOrigin = $('#CountryOfOrigin').val();
                Data.HSCode = $('#HSCode').val();
                Data.CurrencyCode = $('#CurrencyCode').val();
                Data.VendorNumber = $('#VendorNumber').val();
                Data.RemainingShelfLife = $('#RemainingShelfLife').val();
                Data.ManufacturerName = $('#ManufacturerName').val();
                Data.IsDefaultVendor = $('#IsDefaultVendor').is(":checked") ? "true" : "false";

            }
            else if (Data.TaskCode == 'GeneralItemEcommerceData') {
                //GeneralItemEcommerceData
                Data.DisplayName = $('#DisplayName').val();
                Data.EComCroppedImagePath = $('#EComCroppedImagePath').val();
                Data.XMLstringForMultipleImageUpload = GeneralItemMaster.XMLstringForMultipleImageUpload;
            }
            else if (Data.TaskCode == 'GeneralItemUoMData') {

                Data.GeneralItemMasterID = $('input[name=GeneralItemMasterID]').val();
                Data.OrderingUnitcheckboxFlag = $('#OrderingUnitcheckboxFlag').val();
                Data.XMLstring = GeneralItemMaster.XMLstring;
            }

            else if (Data.TaskCode == 'GeneralItemGeneralData' || Data.TaskCode == '' || Data.TaskCode == null) {
                //GeneralItemGeneralData
                //  alert("hii")
                Data.GeneralItemGeneralDataID = $('input[name=GeneralItemGeneralDataID]').val();
                Data.ManufacturerID = $('#ManufacturerID').val();
                Data.ShippingTypeId = $('#ShippingTypeId').val();
                Data.SerialAndBatchManagedBy = $('#SerialAndBatchManagedBy :selected').val();
                //alert($('#SerialAndBatchManagedBy :selected').val())
                //alert(Data.SerialAndBatchManagedBy)
                Data.ManagementMethod = $('#ManagementMethod').val();
                Data.IssueMethod = $('#IssueMethod').val();
                Data.ItemCategoryCode = $('#ItemCategoryCode').val();
                //Data.TempratureFrom = $('#TempratureFrom').val();
                Data.Temprature = $('#Temprature :selected').val();
                //Data.TempratureUpto = $('#TempratureUpto').val();
                Data.GenTaxGroupMasterID = $('#GenTaxGroupMasterID').val();
                Data.HSNCode = $('#HSNCode').val();
                Data.NetContentPerPiece = $('#NetContentPerPiece').val();
                Data.NetWeightPerPiece = $('#NetWeightPerPiece').val();
                // Data.NetContentUOM = $('#NetContentUOM').val();
                Data.NetContentUOM = $('#NetContentUOM').val();
                // alert(Data.NetContentUOM)
                Data.SpecialFeature = $('#SpecialFeature').val();
                Data.ShortDescription = $('#ShortDescription').val();
                Data.ArabicTransalation = $('#ArabicTransalation').val();
                Data.BrandName = $('#BrandName :selected').val();
            }
            else if (Data.TaskCode == 'GeneralItemSalesData') {
                //GeneralItemSalesData
                Data.GeneralItemSalesDataID = $('input[name=GeneralItemSalesDataID]').val();
                Data.GeneralUnitsID = $('#GeneralUnitsID').val();
                Data.XMLstringForSaleUomcode = GeneralItemMaster.XMLstringForSaleUomcode;

            }
            else if (Data.TaskCode == 'GeneralItemstoreData') {
                //GeneralItemStoreData

                Data.GeneralItemSalesDataID = $('input[name=GeneralItemSalesDataID]').val();
                Data.GeneralUnitsID = $('#GeneralUnitsID').val();
                Data.CentreCode = $('#SelectedCentreCode').val();
                Data.GeneralItemStoreSpecificDetailsXml = GeneralItemMaster.GeneralItemStoreSpecificDetailsXml;
            }
            else if (Data.TaskCode == 'GeneralItemAttributeData') {
                //GeneralItemStoreData
                ;
                Data.XMLstringForAttribute = GeneralItemMaster.XMLstringForAttribute;
            }
            else if (Data.TaskCode == 'GeneralItemRestaurantData') {


                Data.InventoryRecipeMasterID = $('#InventoryRecipeMasterID').val();
                Data.GeneralItemCodeID = $('input[name=GeneralItemCodeID]').val();
                Data.Description = $('#Description').val();
                Data.InventoryRecipeMasterTitle = $('#InventoryRecipeMasterTitle').val();
                Data.BillingItemName = $('#BillingItemName').val();
                Data.PriceForRecipe = $('#PriceForRecipe').val();
                Data.XMLstringForRestuarent = GeneralItemMaster.XMLstringForRestuarent;
                Data.InventoryRecipeMenuMasterID = $('#InventoryRecipeMenuMasterID').val();
                Data.RecipeMenuCategoryID = $('#RecipeMenuCategoryID').val();
                Data.RecipeMenuCategory = $('#RecipeMenuCategory').val();
                Data.ArabicTransalationForMainMenu = $('#ArabicTransalationForMainMenu').val();
                Data.IsRelatedWithCafe = $('#IsRelatedWithCafe').val();
                Data.CroppedImagePath = $('#CroppedImagePath').val();

                if ($('#IsActive').is(':checked')) {
                    Data.IsActive = "1";
                }
                else
                {
                    Data.IsActive = "0";
                }
                

                if ($('#Yes').is(':checked')) {
                    Data.DefineVariants = "1";
                }
                else if ($('#No').is(':checked')) {
                    Data.DefineVariants = "0";
                }


                if ($('#BOMRelevantYes').is(':checked')) {
                    Data.BOMRelevant = "1";
                }
                else if ($('#BOMRelevantNo').is(':checked')) {
                    Data.BOMRelevant = "0";
                }

            }
            else if (Data.TaskCode == "GeneralItemServiceData") {
                Data.HSNCode = $('#HSNCode').val();
                Data.GenTaxGroupMasterID = $('#GenTaxGroupMasterID').val();
                Data.ItemNumber = $('#ItemNumber').val();
            }
            //else if (Data.TaskCode == 'GeneralItemDimensionData') {
            //    //GeneralItemStoreData

            //    Data.Height = $('#Height').val();
            //    Data.Width = $('#Width').val();
            //    Data.Length = $('#Length').val();
            //    Data.Volume = $('#Volume').val();
            //}
        }
        else if (GeneralItemMaster.ActionName == "CreateStoreSpecificInformation") {

            Data.UnitName = $('#UnitName').val();
            Data.GeneralItemMasterID = $('input[name=GeneralItemMasterID]').val();
            Data.InventoryItemCodeCentreLevelSpecificInfoID = $('input[name=InventoryItemCodeCentreLevelSpecificInfoID]').val();
            Data.GeneralUnitsID = $('input[name=GeneralUnitsID]').val();
            Data.RPType = $('#RPType').val();
            Data.MaxStock = $('#MaxStock').val();
            Data.RoundingProfile = $('#RoundingProfile').val();
            Data.PlannerCode = $('#PlannerCode').val();
            Data.OrderingDay = $('#OrderingDay').val();
            Data.DeliveryDay = $('#DeliveryDay').val();
            Data.LeadTimeForStore = $('#LeadTimeForStore').val();
            Data.GRProccessingTime = $('#GRProccessingTime').val();
            Data.SupplySource = $('#SupplySourceCode').val();
            Data.BlockforProcurutment = $('#BlockforProcurutment').is(":checked") ? "true" : "false";
            Data.ReorderPoint = $('#ReorderPoint').val();
            Data.SafetyStockDriven = $('#SafetyStockDriven').val();
            Data.Facing = $('#Facing').val();
            Data.ShelfNumber = $('#ShelfNumber').val();
        }

        else if (GeneralItemMaster.ActionName == "Delete") {
            Data.ID = $('input[name=GeneralItemMasterID]').val();

        }
        else if (GeneralItemMaster.ActionName == "CreateMultipleVendor") {
            Data.GeneralItemSupliersDataID = $('input[name=GeneralItemSupliersDataID]').val();
            Data.GeneralVendorID = $('#GeneralVendorID').val();
            Data.VendorNumber = $('#VendorNumber').val();
            Data.ItemNumber = $('#ItemNumber').val();
            Data.IsDefaultVendor = $('#IsDefaultVendor').is(":checked") ? "true" : "false";
        }
        

        return Data;

    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.errorMessage.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()

            GeneralItemMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
    SaveSuccess: function (data) {
        var splitData = data.errorMessage.split(',');

        if (data.GeneralItemMasterID == 0) {
            $("#ItemNumber").val(data.ItemNumber);
            $("#GeneralItemMasterID").val(data.ID);
            //$('#ItemCategoryCode_Param').val(data.ItemCategoryCode);

        }
        
        if (splitData[1] == 'success') {
            notify(splitData[0], splitData[1]);
            var TaskCode = data.TaskCode;
            if (TaskCode == 'GeneralItemSalesData') {
                GeneralItemMaster.ResetGeneralUnitsID = data.GeneralUnitsID;
            }
            //else if (TaskCode == 'GeneralItemEcommerceData') {
            //    $("#" + TaskCode).click();
            //}
            //alert(TaskCode)
            $("#" + TaskCode).click();
            


            if ($('#OrderingUnitcheckboxFlag').val() == 1) {
                $('ul#TaskList li:eq(2)').removeClass("active");
                $('ul#TaskList li:eq(3)').addClass("active");
                TaskCode = 'GeneralItemSupliersData'
                swal({
                    title: 'Edit Purchase Details',
                    text: "Please Update Purchase Detail with Ordering UoM and Cost.",
                    //type: points[parseInt(settings.bulktype)]['type'],
                    //showCancelButton: true,
                    confirmButtonClass: 'btn-success',
                    confirmButtonText: "Ok"
                }, function (isConfirm) {
                    if (isConfirm) {
                        $("#" + TaskCode).click();
                        $('#OrderingUnitcheckboxFlag').val(0);
                    }
                });

            }

        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            notify(splitData[0], splitData[1]);
        }
    },
    StoreSpecificInformationSuccess: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            notify(splitData[0], splitData[1]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
    MultipleVendorSuccess: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            notify(splitData[0], splitData[1]);
            var TaskCode = 'GeneralItemSupliersData'
            $("#" + TaskCode).click();
        }
        else {
            $("#displayErrorMessage1 p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            
        }
    },

};


