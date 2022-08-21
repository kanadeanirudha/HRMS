//this class contain methods related to nationality functionality
var SalePromotionActivityMasterAndDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    CheckDiscount: true,
    CheckSubActivity: true,
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SalePromotionActivityMasterAndDetails.constructor();
        //SalePromotionActivityMasterAndDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
    

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });
        $('#GeneralUnitsID').on("change", function () {
            $('#DivCreateNew').hide(true);
            $('#myDataTable').html("");
            // $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

            if ($("#GeneralUnitsID").val() == "") {
                $("#ulAddbtn").hide();
                //$("#divAddbtn").addClass("myclass");
            }
            else {
                var href = $("#ModalForAddingPromotionActivity").attr('href');
                href = '/SalePromotionActivityMasterAndDetails/Create?GeneralUnitsID=' + $("#GeneralUnitsID").val();
                $("#ModalForAddingPromotionActivity").attr('href', href);
                $("#ulAddbtn").show();
            }
        });
        $("#btnShowList").unbind("click").on("click", function () {
            var valuGeneralunits = $('#GeneralUnitsID :selected').val();
            var CentreCode = $('#CentreCode :selected').val();
            if (valuGeneralunits != "" && CentreCode != "") {
                SalePromotionActivityMasterAndDetails.LoadList(valuGeneralunits, CentreCode);
            }
            else if (CentreCode == "") {
                notify("Please select Centre Code", 'warning');
            }
            else if (valuGeneralunits == "") {
                notify("Please select Units", 'warning');
            }
            

        });
        $("#CentreCode").change(function () {
            var selectedItem = [];
            var selectedItem = $(this).val();
            var abc = selectedItem.split(':');
            var selectedcentrecode = abc[0];
            var $ddlGeneralUnitsID = $("#GeneralUnitsID");
            var $GeneralUnitsIDProgress = $("#GeneralUnitsID-loading-progress");
            $GeneralUnitsIDProgress.show();
            if ($("#CentreCode").val() !== "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: '/SalePromotionActivityMasterAndDetails/GetGeneralUnitsForItemmasterList',
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
        if ($('#GeneralUnitsID').val() == '') {
            $("#ulAddbtn").hide();
        } else {
            $("#ulAddbtn").show();
        }
       
        $("#PlanTypeCode").on("change", function () {

            var PTC = $('#PlanTypeCode :selected').val();
            if (PTC == "PriceDiscountOffPerItem") {
                $('#ItemPerDiscount').show();
                $('#ItemList').show();
                $('#FreeConcessionDiv').hide(true);
                $('#SelectedItemConcession').hide(true);
                $('#ForSameItem').hide(true);

            }
            else if (PTC == "PriceDiscountOnFixAmount") {
                //var content = $('#tblData tr').length;
                //if (content != 0)
                //{
                $("#tblData tr").remove();
                $('#ItemPerDiscount').hide(true);
                $('#ItemList').hide(true);
                $('#FreeConcessionDiv').hide(true);
                $('#SelectedItemConcession').hide(true);
                $('#ForSameItem').hide(true);
              

                //}
            }
            else if (PTC == "ProductConcessionFree")
            {
                $("#tblData tr").remove();
                $('#ItemPerDiscount').hide(true);
                $('#ItemList').hide(true);
                $('#FreeConcessionDiv').show();
            }
            else {
                $('#ItemPerDiscount').hide(true);
                $('#ItemList').hide(true);
                $('#FreeConcessionDiv').hide(true);
                $('#SelectedItemConcession').hide(true);
                $('#ForSameItem').hide(true);

            }

        });
        $('#DiscountInPercentage').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        // if Is percentage is checked 
        $("#IsPercentage").on("click", function () {
          
            if ($(this).is(":checked")) {
                $("#IsDiscountAmount").removeAttr('checked');
                $("#IsFreeItem").removeAttr('checked');

                $('#DiscountInPercentage').attr("disabled", false);

                $('#BillDiscountAmount').val('');
                $('#ItemDescription').val('');
                $('#Quantity').val('');
                $('#UOMCode').val('');

                
                $('#BillDiscountAmount').attr("disabled", true);
                $('#ItemDescription').attr("disabled", true);
                $('#Quantity').attr("disabled", true);
                $('#UOMCode').attr("disabled", true);
            }
        });

        // if Is percentage is checked 
        $("#IsDiscountAmount").on("click", function () {
          
            if ($(this).is(":checked")) {
                $("#IsPercentage").removeAttr('checked');
                $("#IsFreeItem").removeAttr('checked');

                $('#DiscountInPercentage').val('');
                $('#ItemDescription').val('');
                $('#Quantity').val('');
                $('#UOMCode').val('');

                $('#DiscountInPercentage').attr("disabled", true);
                $('#BillDiscountAmount').attr("disabled", false);
                $('#ItemDescription').attr("disabled", true);
                $('#Quantity').attr("disabled", true);
                $('#UOMCode').attr("disabled", true);
            }
        });

        // if Is percentage is checked 
        $("#IsFreeItem").on("click", function () {
            if ($(this).is(":checked")) {
                $("#IsPercentage").removeAttr('checked');
                $("#IsDiscountAmount").removeAttr('checked');

                $('#DiscountInPercentage').val('');
                $('#BillDiscountAmount').val('');

                $('#DiscountInPercentage').attr("disabled", true);
                $('#BillDiscountAmount').attr("disabled", true);
                $('#ItemDescription').attr("disabled", false);
                $('#Quantity').attr("disabled", false);
                $('#UOMCode').attr("disabled", false);
            }
        });
        //searchlist for Item description for concession
         
        var map = {};
        var getData1 = function () {
            return function findMatches(q, cb) {
                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var GeneralUnitsID = $("#GeneralUnitsID").val();
                $.ajax({
                    url: "/SalePromotionActivityMasterAndDetails/GetItemSearchListForConcessionFreeItems",
                    type: "POST",
                    dataType: "json",
                    data: { term: q, GeneralUnitsID: GeneralUnitsID },
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        $.each(data, function (i, response1) {
                            // if (substrRegex.test(response.name)) {
                            map[response1.name] = response1;
                            matches.push(response1.name);
                            // }
                        });
                    },
                    async: false
                })
                cb(matches);
            };
        };

        //COde Starts   
        $('#btnGiftVoucharAdd').on("click", function () {
            debugger; 
            var IsPercentage = $("#IsPercentage").is(":checked") ? "true" : "false";
            var IsDiscountAmount = $("#IsDiscountAmount").is(":checked") ? "true" : "false";
            var IsFreeItem = $("#IsFreeItem").is(":checked") ? "true" : "false";

            if ($('#BillRange').val() == "" || $('#BillRange').val() == null || $('#BillRange').val() == 0) {
                $("#displayErrorMessage ").text("Please select Bill Range.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;

            }
            if (IsPercentage == "false" && IsDiscountAmount == "false" && IsFreeItem == "false")
            {
                $("#displayErrorMessage ").text("Please checked atleast one check box for Selected bill range.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
                //Check box for Is Percentage 
            if ($('#BillRange').val() != "" || $('#BillRange').val() != null) {
                //Check box for Is Percentage
                
                // if Ispercentage checkbox is checked then $('#DiscountInPercentage').val()  is mandatory
                if (IsPercentage == "true" && ($('#DiscountInPercentage').val() == null || $('#DiscountInPercentage').val() == "" || $('#DiscountInPercentage').val() == 0)) {

                    $("#displayErrorMessage ").text("Please enter Discount In Percentage.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                    return false;
                }
                // if Ispercentage checkbox is False(unchecked) then $('#DiscountInPercentage').val()='-'
                if (IsPercentage == "false" && ($('#DiscountInPercentage').val() == null || $('#DiscountInPercentage').val() == "" || $('#DiscountInPercentage').val() == 0)) {

                    var DiscountInPercentage = "<td><input id='DiscountInPercentage' type='text' value='0' style='display:none' />"+" -"+ "</td>"
                }
                else {
                    var DiscountInPercentage = "<td><input id='DiscountInPercentage' type='text' value='" + $('#DiscountInPercentage').val() + "' style='display:none' />" + $('#DiscountInPercentage').val() + "</td>"
                }
                if (IsPercentage == "true") {
                    IsPercentage = "<td> <input id='IsPercentage' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
                    $("#IsPercentage").removeAttr('checked');
                    $("#IsPercentage").val("");
                }
                else {
                    IsPercentage = "<td> <input id='IsPercentage' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
                    $("#IsPercentage").removeAttr('checked');
                    $("#IsPercentage").val("");
                }
               
                //Check box for IsDiscountAmount 

                
                if (IsDiscountAmount == "true" && ($('#BillDiscountAmount').val() == null || $('#BillDiscountAmount').val() == "" || $('#BillDiscountAmount').val() == 0)) {

                    $("#displayErrorMessage ").text("Please enter Bill Discount Amount.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                    return false;
                }
                // if IsDiscountAmount checkbox is False(unchecked) then $('#BillDiscountAmount').val()='-'
                if (IsDiscountAmount == "false" && ($('#BillDiscountAmount').val() == null || $('#BillDiscountAmount').val() == "" || $('#BillDiscountAmount').val() == 0)) {

                    var BillDiscountAmount = "<td><input id='BillDiscountAmount' type='text' value='0' style='display:none' />" + " -" + "</td>"
                }
                else {
                    var BillDiscountAmount = "<td><input id='BillDiscountAmount' type='text' value='" + $('#BillDiscountAmount').val() + "' style='display:none' />" + $('#BillDiscountAmount').val() + "</td>"
                }
                if (IsDiscountAmount == "true") {
                    IsDiscountAmount = "<td> <input id='IsDiscountAmount' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
                    $("#IsDiscountAmount").removeAttr('checked');
                    $("#IsDiscountAmount").val("");
                }
                else {
                    IsDiscountAmount = "<td> <input id='IsDiscountAmount' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
                    $("#IsDiscountAmount").removeAttr('checked');
                    $("#IsDiscountAmount").val("");
                }

                if (IsDiscountAmount == "true" && ($('#BillDiscountAmount').val() == null || $('#BillDiscountAmount').val() == "" || $('#BillDiscountAmount').val() == 0)) {

                    $("#displayErrorMessage ").text("Please Enter Bill Discount Amount.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                    return false;
                }

                // Code for Is free Item check box

               
                if (IsFreeItem == "true") {
                    if ($("#ItemDescription").val() == null || $("#ItemDescription").val() == "") {
                        $("#displayErrorMessage ").text("Please enter item description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                        return false;
                    }
                    else if ($("#UOMCode").val() == null || $("#UOMCode").val() == "") {
                        $("#displayErrorMessage ").text("Please select UoM code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                        return false;
                    }
                    else if ($("#Quantity").val() == null || $("#Quantity").val() == "" || $("#Quantity").val() == 0) {
                        $("#displayErrorMessage ").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                        return false;
                    }
                }
                if (IsFreeItem == "false" && ($('#ItemDescription').val() == null || $('#ItemDescription').val() == "")) {

                    var ItemDescription = "<td><input id='ItemDescription' type='text' value='' style='display:none' />" + " -" + "</td>"
                    var  ItemNumber="<td style='display:none'><input id='ItemNumber' type='text' value= '0' style='display:none' />" + $('#ItemNumber').val() + "</td>" 
                    var VariationMasterID= "<td style='display:none'><input id='InventoryVariationMasterID' type='text' value='0' style='display:none' />" + $('#InventoryVariationMasterID').val() + "</td>" 
                }
                else {
                    var ItemDescription = "<td><input id='ItemDescription' type='text' value='" + $('#ItemDescription').val() + "' style='display:none' />" + $('#ItemDescription').val() + "</td>"
                    var ItemNumber = "<td style='display:none'><input id='ItemNumber' type='text' value=" + $('#ItemNumber').val() + " style='display:none' />" + $('#ItemNumber').val() + "</td>"
                    var VariationMasterID = "<td style='display:none'><input id='InventoryVariationMasterID' type='text' value=" + $('#InventoryVariationMasterID').val() + " style='display:none' />" + $('#InventoryVariationMasterID').val() + "</td>"
                }

                //UOM code
                if (IsFreeItem == "false" && ($('#UOMCode').val() == null || $('#UOMCode').val() == "")) {

                    var UOMCode = "<td><input id='UOMCode' type='text' value='' style='display:none' />" + " -" + "</td>"
                }
                else {
                    var UOMCode = "<td><input id='UOMCode' type='text' value='" + $('#UOMCode').val() + "' style='display:none' />" + $('#UOMCode').val() + "</td>"
                }
                // Quantity
                if (IsFreeItem == "false" && ($('#Quantity').val() == null || $('#Quantity').val() == "" || $('#Quantity').val() == 0)) {

                    var Quantity = "<td><input id='Quantity' type='text' value='0' style='display:none' />" + " -" + "</td>"
                }
                else {
                    var Quantity = "<td><input id='Quantity' type='text' value='" + $('#Quantity').val() + "' style='display:none' />" + $('#Quantity').val() + "</td>"
                }


                if (IsFreeItem == "true") {
                    IsFreeItem = "<td> <input id='IsFreeItem' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
                    $("#IsFreeItem").removeAttr('checked');
                    $("#IsFreeItem").val("");
                }
                else {
                    IsFreeItem = "<td> <input id='IsFreeItem' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
                    $("#IsFreeItem").removeAttr('checked');
                    $("#IsFreeItem").val("");
                }
               


                //Code For IsBase Uom Check box Ends

                $("#tblDataForGiftVouchar tbody").append( 
                                     "<tr>" +
                                     "<td><input id='BillRange' type='text' value=" + $('#BillRange').val() + " style='display:none' />" + $('#BillRange :selected').text() + "</td>" +
                                     IsPercentage+
                                     DiscountInPercentage+
                                     IsDiscountAmount +
                                     BillDiscountAmount+
                                     IsFreeItem+
                                     ItemNumber+
                                     VariationMasterID+
                                     ItemDescription+
                                     Quantity+
                                     UOMCode+
                                     "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                     "</tr>"
                                    );

                $("#ItemDescription").val("");
                $("#Quantity").val("0");
                $("#UOMCode").val("");
                $("#WastageInPercentage").val("0");
                $("#BillRange").val("");
                $("#ItemNumber").val("");
                $("#InventoryVariationMasterID").val("");
                $("#DiscountInPercentage").val("0");
                $("#BillDiscountAmount").val("0");
                
            }

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

        });

        //Code ends
        $('#ItemDescriptionForConcession').typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        },
        {

            source: getData1()
        }).on("typeahead:selected", function (obj, item) {
            $('#GeneralItemMasterID').val(map[item].id);
            $('#ItemDescriptionForConcession').val(map[item].name);
            $('#ItemNumber').val(map[item].ItemNumber);
            $('#UOMCode').val(map[item].BaseUOMCode);
            $('#InventoryVariationMasterID').val(map[item].InventoryVariationMasterID);
            $('#MenuDescription').val(map[item].MenuDescription);

            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { "ItemNumber": map[item].ItemNumber },
                url: '/SalePromotionActivityMasterAndDetails/GetUoMCodeByItemNumber',
                success: function (data) {
                    var $ddlExam = $("#UOMCodeForConcession");
                    $ddlExam.html('');
                    $ddlExam.append('<option value="">---Select UoM Code---</option>');
                    if (data.length != 0) {
                        $.each(data, function (id, option) {
                            $ddlExam.append($('<option></option>').val(option.name).html(option.name));
                        });
                    }
                    else {
                        $ddlExam.append('<option value="EA">EA</option>');
                    }


                }
            });

        });

        //////////////////////////////////////////////////
        $("#tblDataItemDetails tbody").on("keyup", "tr td input[id^=DiscountInPercentage1]", function () {
            var Discount = parseFloat($(this).closest('tr').find('td input[id^=DiscountInPercentage1]').val());
            if (parseFloat(Discount) > 100) {

                $("#displayErrorMessage ").text("Please Enter Discount Less than 100%.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if (parseFloat(Discount) == null || parseFloat(Discount) == 0)
            {
                $("#displayErrorMessage ").text("Please Enter Valid Discount.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }

        });
        
        $('input[id^=DiscountInPercentage1]').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        
        $('#btnAdd').on("click", function () {

            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;
            //alert(TotalRecord);
            //alert(DataArray);

            for (var i = 0; i < TotalRecord; i = i + 6) {
                
                
                if ((DataArray[i + 5] ==( $('#ItemNumber').val() + '~' + $('#InventoryVariationMasterID').val()))) {
                    $("#displayErrorMessage p").text("You cannot enter same item twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#ItemDescription").val("");
                    $("#DiscountInPercentage").val("0");
                    $("#UOMCode").val("");
                    return false;
                
                }
            }
            if ($("#ItemDescription").val() == null || $("#ItemDescription").val() == "") {
                $("#displayErrorMessage ").text("Please enter item description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#UOMCode").val() == null || $("#UOMCode").val() == "") {
                $("#displayErrorMessage ").text("Please select UoM code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#DiscountInPercentage").val() == "" || $("#DiscountInPercentage").val() == 0) {
                $("#displayErrorMessage ").text("Please enter valid discount.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#DiscountInPercentage").val() > 100) {
                $("#displayErrorMessage ").text("Please enter discount less than 100.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null && $('#UOMCode').val() != "" && $('#UOMCode').val() != null) {
                //Code For IsBase Uom Check box Ends

                $("#tblData tbody").append(
                                     "<tr>" +
                                     "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                                     "<td><input id='ItemDescription' type='hidden'  value=" + $('#ItemDescription').val() + "  style='display:none' />" + $('#ItemDescription').val() + "</td>" +
                                     "<td style=display:none><input id='InventoryVariationMasterID' type='hidden' value=" + $('#InventoryVariationMasterID').val() + " style='display:none' />" + $('#InventoryVariationMasterID').val() + "</td>" +
                                     "<td ><input type='text' value=" + $('#UOMCode').val() + " style='display:none' /> " + $('#UOMCode').val() + "</td>" +
                                     "<td ><input type='text' value=" + $('#DiscountInPercentage').val() + " style='display:none' /> " + $('#DiscountInPercentage').val() + "</td>" +
                                     "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete><input type='hidden' id='ItemNumberVariationID' value=" + $('#ItemNumber').val() + '~' + $('#InventoryVariationMasterID').val() + "  /></td>" +
                                     "</tr>"
                                    );

                $("#ItemDescription").val("");
                $("#DiscountInPercentage").val("0");
                $("#UOMCode").val("");

            }

            //Delete record in table 
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

        });
        $('#btnAddItemDetails').on("click", function () {
            var DataArray = [];
            var data = $('#tblDataItemDetails tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;
            

            for (var i = 0; i < TotalRecord; i = i + 11) {
                if ((DataArray[i + 10] ==( $('#ItemNumber').val() + '~' + $('#InventoryVariationMasterID').val()))) {
                    $("#displayErrorMessage p").text("You cannot enter same item twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#ItemDescription").val("");
                    $("#DiscountInPercentage").val("0");
                    $("#UOMCode").val("");
                    return false
                }
            }
            if ($("#ItemDescription").val() == null || $("#ItemDescription").val() == "") {
                $("#displayErrorMessage ").text("Please enter item description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#UOMCode").val() == null || $("#UOMCode").val() == "") {
                $("#displayErrorMessage ").text("Please select UoM code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
        
            if($("#PlanTypeCode").val() != "ProductConcessionFree")
            {
                if ($("#DiscountInPercentage").val() == "" || $("#DiscountInPercentage").val() == 0) {
                    $("#displayErrorMessage ").text("Please enter discount.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                    return false;
                }
                else if ($("#DiscountInPercentage").val() > 100) {
                    $("#displayErrorMessage ").text("Please enter discount less than 100.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                    return false;
                }
            }
           
            if ($("#PlanTypeCode").val() == "ProductConcessionFree") {
                if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null && $('#UOMCode').val() != "" && $('#UOMCode').val() != null) {
                    //Code For IsBase Uom Check box Ends

                    $("#tblDataItemDetails tbody").append(
                                         "<tr>" +
                                        "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                                          "<td style=display:none><input id='SalePromotionActivityDetailsID' type='hidden'  value=" + $('#SalePromotionActivityDetailsID').val() + "  style='display:none' />" + $('#SalePromotionActivityDetailsID').val() + "</td>" +
                                          "<td style=display:none><input id='PromotionActivityDiscounteItemListID' type='hidden'  value=" + $('#PromotionActivityDiscounteItemListID').val() + "  style='display:none' />" + $('#PromotionActivityDiscounteItemListID').val() + "</td>" +
                                           "<td style=display:none><input id='IsActive' type='hidden'  value=0  style='display:none' />" + $('#IsActive').val() + "</td>" +
                                       "<td style=display:none><input id='DiscountInPercentage' type='hidden'  value=0  style='display:none' />" + $('#DiscountInPercentage').val() + "</td>" +
                                     //DiscountInPercentage1 +
                                     "<td style=display:none><input id='InventoryVariationMasterID' type='hidden' value=" + $('#InventoryVariationMasterID').val() + " style='display:none' />" + $('#InventoryVariationMasterID').val() + "</td>" +
                                       "<td><input id='ItemDescription' type='text' value=" + $('#ItemDescription').val() + " style='display:none' />" + $('#ItemDescription').val() + "</td>" +
                                        "<td ><input type='text' value=" + $('#UOMCode').val() + " style='display:none' /> " + $('#UOMCode').val() + "</td>" +
                                        "<td style=display:none><input type='text' value=0 style='display:none' /> " + $('#DiscountInPercentage').val() + "</td>" +
                                       //DiscountInPercentage +
                                       "<td style=display:none><input id='PromotionActivityDiscounteItemListID' type='hidden'  value=0  style='display:none' />" + $('#PromotionActivityDiscounteItemListID').val() + "</td>" +
                                        "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete><input type='hidden' id='ItemNumberVariationID' value=" + $('#ItemNumber').val() + '~' + $('#InventoryVariationMasterID').val() + "  /></td>" +
                                        "</tr>"
                                        );

                    $("#ItemDescription").val("");
                    $("#DiscountInPercentage").val("0");
                    $("#UOMCode").val("");
                }
            }
            else {
                if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null && $('#UOMCode').val() != "" && $('#UOMCode').val() != null) {
                    //Code For IsBase Uom Check box Ends

                    $("#tblDataItemDetails tbody").append(
                                         "<tr>" +
                                        "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                                          "<td style=display:none><input id='SalePromotionActivityDetailsID' type='hidden'  value=" + $('#SalePromotionActivityDetailsID').val() + "  style='display:none' />" + $('#SalePromotionActivityDetailsID').val() + "</td>" +
                                          "<td style=display:none><input id='PromotionActivityDiscounteItemListID' type='hidden'  value=" + $('#PromotionActivityDiscounteItemListID').val() + "  style='display:none' />" + $('#PromotionActivityDiscounteItemListID').val() + "</td>" +
                                           "<td style=display:none><input id='IsActive' type='hidden'  value=0  style='display:none' />" + $('#IsActive').val() + "</td>" +
                                       "<td style=display:none><input id='DiscountInPercentage' type='hidden'  value=" + $('#DiscountInPercentage').val() + "  style='display:none' />" + $('#DiscountInPercentage').val() + "</td>" +
                                     //DiscountInPercentage1 +
                                     "<td style=display:none><input id='InventoryVariationMasterID' type='hidden' value=" + $('#InventoryVariationMasterID').val() + " style='display:none' />" + $('#InventoryVariationMasterID').val() + "</td>" +
                                       "<td><input id='ItemDescription' type='text' value=" + $('#ItemDescription').val() + " style='display:none' />" + $('#ItemDescription').val() + "</td>" +
                                        "<td ><input type='text' value=" + $('#UOMCode').val() + " style='display:none' /> " + $('#UOMCode').val() + "</td>" +
                                        "<td ><input type='text' value=" + $('#DiscountInPercentage').val() + " style='display:none' /> " + $('#DiscountInPercentage').val() + "</td>" +
                                       //DiscountInPercentage +
                                       "<td style=display:none><input id='PromotionActivityDiscounteItemListID' type='hidden'  value=0  style='display:none' />" + $('#PromotionActivityDiscounteItemListID').val() + "</td>" +
                                        "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete><input type='hidden' id='ItemNumberVariationID' value=" + $('#ItemNumber').val() + '~' + $('#InventoryVariationMasterID').val() + "  /></td>" +
                                        "</tr>"
                                        );

                    $("#ItemDescription").val("");
                    $("#DiscountInPercentage").val("0");
                    $("#UOMCode").val("");
                }
            }

            //Delete record in table
            $("#tblDataItemDetails tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

    });

//For Free Concession details

$('#btnAddConcessionActivity').on("click", function () {
    var DataArray = [];
    var data = $('#tblDataCocessionActivityDetails tbody tr td input').each(function () {
        DataArray.push($(this).val());
    });
    TotalRecord = DataArray.length;
    var i = 0;


    //for (var i = 0; i < TotalRecord; i = i + 11) {
    //    if ((DataArray[i + 10] == ($('#ItemNumber').val() + '~' + $('#InventoryVariationMasterID').val()))) {
    //        $("#displayErrorMessage p").text("You cannot enter same item twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
    //        $("#ItemDescription").val("");
    //        $("#DiscountInPercentage").val("0");
    //        $("#UOMCode").val("");
    //        return false
    //    }
    //}
    if ($("#ItemDescriptionForConcession").val() == null || $("#ItemDescriptionForConcession").val() == "") {
        $("#displayErrorMessage ").text("Please enter item description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
        return false;
    }
    else if ($("#UOMCodeForConcession").val() == null || $("#UOMCodeForConcession").val() == "") {
        $("#displayErrorMessage ").text("Please select UoM code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
        return false;
    }
           
    if ($('#ItemDescriptionForConcession').val() != "" && $('#ItemDescriptionForConcession').val() != null && $('#UOMCodeForConcession').val() != "" && $('#UOMCodeForConcession').val() != null) {
        //Code For IsBase Uom Check box Ends

        $("#tblDataCocessionActivityDetails tbody").append(
                             "<tr>" +
                            "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                            "<td><input id='ItemDescriptionForConcession' type='text' value=" + $('#ItemDescriptionForConcession').val() + " style='display:none' />" + $('#ItemDescriptionForConcession').val() + "</td>" +
                            "<td style=display:none><input id='InventoryVariationMasterID' type='hidden' value=" + $('#InventoryVariationMasterID').val() + " style='display:none' />" + $('#InventoryVariationMasterID').val() + "</td>" +
                             "<td ><input type='text' value=" + $('#UOMCodeForConcession').val() + " style='display:none' /> " + $('#UOMCodeForConcession').val() + "</td>" +
                             "<td style=display:none><input type='text' value=" + $('#DiscountInPercentage').val() + " style='display:none' /> " + 0 + "</td>" +
                            "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete><input type='hidden' id='ItemNumberVariationID' value=" + $('#ItemNumber').val() + '~' + $('#InventoryVariationMasterID').val() + "  /></td>" +
                             "</tr>"
                            );

        $("#ItemDescriptionForConcession").val("");
        $("#DiscountInPercentage").val("0");
        $("#UOMCodeForConcession").val("");
    }


    //Delete record in table
    $("#tblDataCocessionActivityDetails tbody").on("click", "tr td i", function () {
        $(this).closest('tr').remove();
    });

});
// Create new record

$('#CreateSalePromotionActivityMasterAndDetailsRecord').on("click", function () {
   
    SalePromotionActivityMasterAndDetails.ActionName = "Create";

    if ($("#PlanTypeCode").val() == "ProductConcessionFree" && $("#ProductConcessionFreeType").val() == "1" && ($("#tblDataCocessionActivityDetails tbody tr").length == 0)) {
        $("#displayErrorMessage").text("Please add item details.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
        return false;
    }
    if ($("#PlanTypeCode").val() == "ProductConcessionFree" && ($("#ProductConcessionFreeType").val() == null || $("#ProductConcessionFreeType").val() == "0"))
    {
        $("#displayErrorMessage").text("Please select product concession free type.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
        return false;
    }
    if ($("#PlanTypeCode").val() == "ProductConcessionFree" && $("#ProductConcessionFreeType").val() == "1" && ($("#PlanDescription").val() == "")) {
        $("#displayErrorMessage").text("Please select plan description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
        return false;
    }
    if ($("#PlanTypeCode").val() == "ProductConcessionFree" && $("#ProductConcessionFreeType").val() == 1)
    {
        SalePromotionActivityMasterAndDetails.GetXmlForfreeConcessionItems();
    }
    else if ($("#PlanTypeCode").val() == "ProductConcessionFree" && $("#ProductConcessionFreeType").val() == 2)
    {
        SalePromotionActivityMasterAndDetails.GetXmlForConcessionFreeType();
    }
    else
    {
        SalePromotionActivityMasterAndDetails.GetXmlData();
    }
    SalePromotionActivityMasterAndDetails.AjaxCallSalePromotionActivityMasterAndDetails();
});

//Button for Fixed Amount Div
$('#CreateSalePromotionActivityRecord').on("click", function () {
    SalePromotionActivityMasterAndDetails.ActionName = "CreateActivityDetailsForFixedAmount";
    SalePromotionActivityMasterAndDetails.CheckSubActivity = true;
    SalePromotionActivityMasterAndDetails.GetXmlForFixedAmountData();
    if (SalePromotionActivityMasterAndDetails.CheckSubActivity == false) {
        $("#displayErrorMessage ").text("Please enter sub activity name.").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "danger");
        return false;
    }
    SalePromotionActivityMasterAndDetails.AjaxCallSalePromotionActivityMasterAndDetails();
});
$('#CreateItemDetailsRecord').on("click", function () {
    SalePromotionActivityMasterAndDetails.ActionName = "CreateItemDetailsRecord";
    SalePromotionActivityMasterAndDetails.CheckDiscount = true;
    SalePromotionActivityMasterAndDetails.GetXmlForItemDetails();
    if (SalePromotionActivityMasterAndDetails.CheckDiscount == false) {
        $("#displayErrorMessage ").text("Please enter valid discount.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
        return false;
    }
    SalePromotionActivityMasterAndDetails.AjaxCallSalePromotionActivityMasterAndDetails();
});
$('#EditSalePromotionActivityMasterAndDetailsRecord').on("click", function () {

    SalePromotionActivityMasterAndDetails.ActionName = "Edit";
    SalePromotionActivityMasterAndDetails.AjaxCallSalePromotionActivityMasterAndDetails();
});

$('#CreateFreeConcessionDetailsRecord').on("click", function () {
    SalePromotionActivityMasterAndDetails.ActionName = "CreateFreeConcessionDetails";
    SalePromotionActivityMasterAndDetails.GetXmlForfreeConcessionItems();
    SalePromotionActivityMasterAndDetails.AjaxCallSalePromotionActivityMasterAndDetails();
});
$('#CreateGiftVoucherRecord').on("click", function () {
    debugger;
    SalePromotionActivityMasterAndDetails.ActionName = "CreateGiftVoucherDetails";
    SalePromotionActivityMasterAndDetails.GetXmlForGiftVocherItems();
    SalePromotionActivityMasterAndDetails.AjaxCallSalePromotionActivityMasterAndDetails();
});


$('#DeleteSalePromotionActivityMasterAndDetailsRecord').on("click", function () {

    SalePromotionActivityMasterAndDetails.ActionName = "Delete";
    SalePromotionActivityMasterAndDetails.AjaxCallSalePromotionActivityMasterAndDetails();
});
$('#CreateFreeTypeItemListRecord').on("click", function () {

    SalePromotionActivityMasterAndDetails.ActionName = "CreateFreeTypeItemList";
    SalePromotionActivityMasterAndDetails.GetXmlForFreeTypeItemList();
    SalePromotionActivityMasterAndDetails.AjaxCallSalePromotionActivityMasterAndDetails();
});
$('#CreateDeactivateActivityRecord').on("click", function () {

    SalePromotionActivityMasterAndDetails.ActionName = "Edit";
    //swal({

    //    title: 'Confirm Inactivate Activity',
    //    text: "This activity will not be activate after "+ $('#UptoDate').val() +".",
    //    //type: points[parseInt(settings.bulktype)]['type'],
    //    showCancelButton: true,
    //    confirmButtonClass: 'btn-success',
    //    confirmButtonText: "OK!"

    //}, function (isConfirm) {
    //    if (isConfirm) {
    SalePromotionActivityMasterAndDetails.AjaxCallSalePromotionActivityMasterAndDetails();
    //    }
    //});
          
});

InitAnimatedBorder();
CloseAlert();
},
//LoadList method is used to load List page
LoadList: function (GeneralUnitsID,CentreCode) {
    $.ajax(
     {
         cache: false,
         type: "POST",
         data: { GeneralUnitsID: GeneralUnitsID,CentreCode:CentreCode },
         dataType: "html",
         url: '/SalePromotionActivityMasterAndDetails/List',
         success: function (data) {
             //Rebind Grid Data
             $('#ListViewModel').html(data);

             if ($('#GeneralunitsID :selected').val() == "" || $('#GeneralunitsID :selected').val() == "undefined") {

                 $("#divAddbtn").hide();
                 // $("#divAddbtn").addClass("myclass");
             }
             else {
                 $("#divAddbtn").show();
                 // $("#divAddbtn").removeClass("myclass");
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
        data: { GeneralUnitsID: $("#GeneralUnitsID").val(), actionMode: actionMode },
        url: '/SalePromotionActivityMasterAndDetails/List',
        success: function (data) {
            //Rebind Grid Data
            $("#ListViewModel").empty().append(data);
            //twitter type notification
            if ($('#GeneralunitsID :selected').val() == "" || $('#GeneralunitsID :selected').val() == "undefined") {

                $("#divAddbtn").hide();
                //  $("#divAddbtn").addClass("myclass");
            }
            else {
                $("#divAddbtn").show();
                //  $("#divAddbtn").removeClass("myclass");
            }
            notify(message, colorCode);
        }
    });
},
CheckedAll: function () {
    $("#tblData thead tr th input[class='checkall-user']").on('click', function () {
        var $this = $(this);
        if ($this.is(":checked")) {
            $("#tblData tbody tr td  input[class='check-user']").prop("checked", true);
        }
        else {
            $("#tblData tbody tr td  input[class='check-user']").prop("checked", false);
        }
    });
},
CheckedAllForFreeTypeListItem: function () {
    $("#tblDataFreeTypeItemList thead tr th input[class='checkall-user']").on('click', function () {
        var $this = $(this);
        if ($this.is(":checked")) {
            $("#tblDataFreeTypeItemList tbody tr td  input[class='check-user']").prop("checked", true);
        }
        else {
            $("#tblDataFreeTypeItemList tbody tr td  input[class='check-user']").prop("checked", false);
        }
    });
},
CheckedAllForSameItem: function () {
    $("#tblDataForSelectedItemConcession thead tr th input[class='checkall-user']").on('click', function () {
        var $this = $(this);
        if ($this.is(":checked")) {
            $("#tblDataForSelectedItemConcession tbody tr td  input[class='check-user']").prop("checked", true);
        }
        else {
            $("#tblDataForSelectedItemConcession tbody tr td  input[class='check-user']").prop("checked", false);
        }
    });
},
GetXmlForFixedAmountData: function () {

    var DataArray = [];

    //$('#tblData1 input').each(function () {
    //    DataArray.push($(this).val());
    //});

    var data = $('#tblData tbody tr td  input').each(function () {
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
    //alert(TotalRecord);
    //alert(DataArray);

    var ParameterXmlForFixedData = "<rows>";
        
    for (var i = 0; i < TotalRecord; i = i + 11) {
        if (DataArray[i] == 1 && (DataArray[i + 4] == "" || DataArray[i + 4] == null)) {
            SalePromotionActivityMasterAndDetails.CheckSubActivity = false;
        }
        else {
            //if (DataArray[i] == 1) {
            ParameterXmlForFixedData = ParameterXmlForFixedData + "<row><ID>" + 0 + "</ID><SalePromotionPlanDetailsID>" + DataArray[i + 2] + "</SalePromotionPlanDetailsID><SalePromotionActivityMasterID>" + (DataArray[i + 1]) + "</SalePromotionActivityMasterID><SubActivityName>" + (DataArray[i + 4]) + "</SubActivityName><StatusFlag>" + (DataArray[i]) + "</StatusFlag><SalePromotionActivityDetailsID>" + (DataArray[i + 10]) + "</SalePromotionActivityDetailsID></row>";
            //}
        }
    }

    if (ParameterXmlForFixedData.length > 9)
        SalePromotionActivityMasterAndDetails.ParameterXmlForFixedData = ParameterXmlForFixedData + "</rows>";

    else
        SalePromotionActivityMasterAndDetails.ParameterXmlForFixedData = "";
    // alert(SalePromotionActivityMasterAndDetails.ParameterXmlForFixedData)
},

GetXmlData: function () {

    var DataArray = [];
    //BOMAndRecipeDetails.flag = true;
    $('#tblData input').each(function () {
        if ($(this).val() != "on") {
            DataArray.push($(this).val());
        }
    });
    var TotalRecord = DataArray.length;
    //alert(TotalRecord)
    //alert(DataArray)

    var ParameterXml = "<rows>";
    for (var i = 0; i < TotalRecord; i = i + 6 ) {
        ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemNumber>" + DataArray[i] + "</ItemNumber><InventoryVariationMasterID>" + (DataArray[i + 2]) + "</InventoryVariationMasterID><UOMCode>" + (DataArray[i + 3]) + "</UOMCode><DiscountInPercent>" + (DataArray[i + 4]) + "</DiscountInPercent></row>";
    }
    // alert(ParameterXml);
    if (ParameterXml.length > 10)
        SalePromotionActivityMasterAndDetails.ParameterXml = ParameterXml + "</rows>";

    else
        SalePromotionActivityMasterAndDetails.ParameterXml = "";
},

GetXmlForItemDetails: function () {

    var DataArray = [];
    //BOMAndRecipeDetails.flag = true;
    $('#tblDataItemDetails input').each(function () {

        DataArray.push($(this).val());

    });
    var TotalRecord = DataArray.length;
    // alert(TotalRecord)
    // alert(DataArray)

    var ParameterXmlForItemDetails = "<rows>";
    for (var i = 0; i < TotalRecord; i = i + 11) {
        if ($("#PlanTypeCode").val() == "PriceDiscountOffPerItem")
        {
            if (DataArray[i + 8] == 0 || DataArray[i + 8] == null || (DataArray[i + 8] > 100))
            {
                SalePromotionActivityMasterAndDetails.CheckDiscount = false;
            }
           
            else if ((DataArray[i + 4] != DataArray[i + 8] && DataArray[i + 3] == 1) || DataArray[i + 3] == 0) {
                ParameterXmlForItemDetails = ParameterXmlForItemDetails + "<row><ID>" + (DataArray[i + 9]) + "</ID><ItemNumber>" + DataArray[i] + "</ItemNumber><UOMCode>" + (DataArray[i + 7]) + "</UOMCode><InventoryVariationMasterID>" + (DataArray[i + 5]) + "</InventoryVariationMasterID><SalePromotionActivityDetailsID>" + (DataArray[i + 1]) + "</SalePromotionActivityDetailsID><DiscountInPercent>" + (DataArray[i + 8]) + "</DiscountInPercent><IsActive>" + (DataArray[i + 3]) + "</IsActive></row>";
            }
        }
        else if($("#PlanTypeCode").val() == "ProductConcessionFree")
        {
            ParameterXmlForItemDetails = ParameterXmlForItemDetails + "<row><ID>" + (DataArray[i + 9]) + "</ID><ItemNumber>" + DataArray[i] + "</ItemNumber><UOMCode>" + (DataArray[i + 7]) + "</UOMCode><InventoryVariationMasterID>" + (DataArray[i + 5]) + "</InventoryVariationMasterID><SalePromotionActivityDetailsID>" + (DataArray[i + 1]) + "</SalePromotionActivityDetailsID><DiscountInPercent>" + 0 + "</DiscountInPercent><IsActive>" + (DataArray[i + 3]) + "</IsActive></row>";
        }
    }
    // alert(ParameterXml);
    if (ParameterXmlForItemDetails.length > 10)
        SalePromotionActivityMasterAndDetails.ParameterXmlForItemDetails = ParameterXmlForItemDetails + "</rows>";

    else
        SalePromotionActivityMasterAndDetails.ParameterXmlForItemDetails = "";
    // alert(SalePromotionActivityMasterAndDetails.ParameterXmlForItemDetails)
},

GetXmlForfreeConcessionItems: function () {
    var DataArray = [];
    //BOMAndRecipeDetails.flag = true;
    $('#tblDataCocessionActivityDetails input').each(function () {

        DataArray.push($(this).val());

    });
    var TotalRecord = DataArray.length;
    // alert(TotalRecord)
    // alert(DataArray)

    var ParameterXmlForConcessionActivity = "<rows>";
    for (var i = 0; i < TotalRecord; i = i + 6) {
        ParameterXmlForConcessionActivity = ParameterXmlForConcessionActivity + "<row><ID>0</ID><ItemNumber>" + DataArray[i] + "</ItemNumber><UOMCode>" + (DataArray[i + 3]) + "</UOMCode><InventoryVariationMasterID>" + (DataArray[i + 2]) + "</InventoryVariationMasterID><DiscountInPercent>" + (DataArray[i + 4]) + "</DiscountInPercent></row>";
    }
    //  alert(ParameterXmlForConcessionActivity);
    if (ParameterXmlForConcessionActivity.length > 10)
        SalePromotionActivityMasterAndDetails.ParameterXmlForConcessionActivity = ParameterXmlForConcessionActivity + "</rows>";

    else
        SalePromotionActivityMasterAndDetails.ParameterXmlForConcessionActivity = "";
   // alert(SalePromotionActivityMasterAndDetails.ParameterXmlForConcessionActivity)
},

    //gift voucher


GetXmlForGiftVocherItems: function () {
    debugger;
    var DataArray = [];
    //BOMAndRecipeDetails.flag = true;
    $('#tblDataForGiftVouchar input').each(function () {

        DataArray.push($(this).val());

    });
    var TotalRecord = DataArray.length;
     var SalePromotionActivityDetailsID = $('#SalePromotionActivityDetailsID').val();

    var ParameterXmlForGiftVouchar = "<rows>";
    for (var i = 0; i < TotalRecord; i = i +11) {
        ParameterXmlForGiftVouchar = ParameterXmlForGiftVouchar + "<row><ID>0</ID><SalePromotionActivityDetailsID>" + SalePromotionActivityDetailsID + "</SalePromotionActivityDetailsID><SalePromotionPlanDetailsID>" + DataArray[i] + "</SalePromotionPlanDetailsID><Ispercentage>" + DataArray[i + 1] + "</Ispercentage><IsBillAmount>" + DataArray[i + 3] + "</IsBillAmount><IsfreeItem>" + DataArray[i + 5] + "</IsfreeItem><DiscountPercentage>" + DataArray[i + 2] + "</DiscountPercentage><GiftAmount>" + DataArray[i + 4] + "</GiftAmount><ItemNumber>" + DataArray[i + 6] + "</ItemNumber><UomCode>" + DataArray[i + 10] + "</UomCode><InventoryVariationMasterID>" + DataArray[i + 7] + "</InventoryVariationMasterID><IsActive>1</IsActive><PromotionApplicableTo></PromotionApplicableTo><Quantity>" + DataArray[i + 9] + "</Quantity></row>";
    }
   
    if (ParameterXmlForGiftVouchar.length > 10)
        SalePromotionActivityMasterAndDetails.ParameterXmlForGiftVouchar = ParameterXmlForGiftVouchar + "</rows>";

    else
        SalePromotionActivityMasterAndDetails.ParameterXmlForGiftVouchar = "";
    // alert(SalePromotionActivityMasterAndDetails.ParameterXmlForConcessionActivity)
},
    //code ends for gift voucher


GetXmlForConcessionFreeType: function () {
    var DataArray = [];
    $('#tblDataForSelectedItemConcession tbody tr td input').each(function () {

        if ($(this).attr('type') == 'checkbox') {
            DataArray.push($(this).is(":checked") ? 1 : 0);
        }
        else {
            DataArray.push($(this).val());
        }
    });
    var TotalRecord = DataArray.length;
    //alert(TotalRecord)
    //alert(DataArray)

    var ParameterXmlForFreeType = "<rows>";
    for (var i = 0; i < TotalRecord; i = i + 6) {
        if (DataArray[i] == 1) {
            ParameterXmlForFreeType = ParameterXmlForFreeType + "<row><ID>0</ID><ItemNumber>" + DataArray[i + 2] + "</ItemNumber><UOMCode>" + (DataArray[i + 4]) + "</UOMCode><InventoryVariationMasterID>" + (DataArray[i + 5]) + "</InventoryVariationMasterID><DiscountInPercent>" + 0 + "</DiscountInPercent></row>";
        }
    }
    //  alert(ParameterXmlForConcessionActivity);
    if (ParameterXmlForFreeType.length > 10)
        SalePromotionActivityMasterAndDetails.ParameterXmlForFreeType = ParameterXmlForFreeType + "</rows>";

    else
        SalePromotionActivityMasterAndDetails.ParameterXmlForFreeType = "";
    //alert(SalePromotionActivityMasterAndDetails.ParameterXmlForFreeType)
       
},
GetXmlForFreeTypeItemList: function () {
    var DataArray = [];
    $('#tblDataFreeTypeItemList  tbody tr td input').each(function () {

        if ($(this).attr('type') == 'checkbox') {
            DataArray.push($(this).is(":checked") ? 1 : 0);
        }
        else {
            DataArray.push($(this).val());
        }

    });
    var TotalRecord = DataArray.length;
    
     var ParameterXmlForFreeTypeItemList = "<rows>";
     for (var i = 0; i < TotalRecord; i = i + 12) {
         if((DataArray[i] == 1) ||((DataArray[i] == 0)&&(DataArray[i+3] > 0)))
         {  
             ParameterXmlForFreeTypeItemList = ParameterXmlForFreeTypeItemList + "<row><ID>" + (DataArray[i + 3]) + "</ID><ItemNumber>" + DataArray[i + 1] + "</ItemNumber><UOMCode>" + (DataArray[i + 8]) + "</UOMCode><InventoryVariationMasterID>" + (DataArray[i + 6]) + "</InventoryVariationMasterID><SalePromotionActivityDetailsID>" + (DataArray[i + 2]) + "</SalePromotionActivityDetailsID><DiscountInPercent>" + 0 + "</DiscountInPercent><IsActive>" + (DataArray[i]) + "</IsActive></row>";

     }
     }
     //alert(ParameterXmlForFreeTypeItemList);
    if (ParameterXmlForFreeTypeItemList.length > 11)
        SalePromotionActivityMasterAndDetails.ParameterXmlForFreeTypeItemList = ParameterXmlForFreeTypeItemList + "</rows>";

    else
        SalePromotionActivityMasterAndDetails.ParameterXmlForFreeTypeItemList = "";
     //alert(SalePromotionActivityMasterAndDetails.ParameterXmlForFreeTypeItemList)
},
//Fire ajax call to insert update and delete record

AjaxCallSalePromotionActivityMasterAndDetails: function () {
    var SalePromotionActivityMasterAndDetailsData = null;

    if (SalePromotionActivityMasterAndDetails.ActionName == "Create") {
        $("#FormCreateSalePromotionActivityMasterAndDetails").validate();
        if ($("#FormCreateSalePromotionActivityMasterAndDetails").valid()) {
            SalePromotionActivityMasterAndDetailsData = null;
            SalePromotionActivityMasterAndDetailsData = SalePromotionActivityMasterAndDetails.GetSalePromotionActivityMasterAndDetails();
            ajaxRequest.makeRequest("/SalePromotionActivityMasterAndDetails/Create", "POST", SalePromotionActivityMasterAndDetailsData, SalePromotionActivityMasterAndDetails.Success, "CreateSalePromotionActivityMasterAndDetailsRecord");
        }
    }
    else if (SalePromotionActivityMasterAndDetails.ActionName == "CreateActivityDetailsForFixedAmount") {
        $("#FormCreateSalePromotionActivity").validate();
        if ($("#FormCreateSalePromotionActivity").valid()) {
            SalePromotionActivityMasterAndDetailsData = null;
            SalePromotionActivityMasterAndDetailsData = SalePromotionActivityMasterAndDetails.GetSalePromotionActivityMasterAndDetails();
            ajaxRequest.makeRequest("/SalePromotionActivityMasterAndDetails/CreateSalePromotionActivity", "POST", SalePromotionActivityMasterAndDetailsData, SalePromotionActivityMasterAndDetails.Success, "CreateSalePromotionActivityRecord");
        }
    }
    else if (SalePromotionActivityMasterAndDetails.ActionName == "CreateFreeConcessionDetails") {
        $("#FormCreateSalePromotionActivity").validate();
        if ($("#FormCreateSalePromotionActivity").valid()) {
            SalePromotionActivityMasterAndDetailsData = null;
            SalePromotionActivityMasterAndDetailsData = SalePromotionActivityMasterAndDetails.GetSalePromotionActivityMasterAndDetails();
            ajaxRequest.makeRequest("/SalePromotionActivityMasterAndDetails/CreateSalePromotionActivity", "POST", SalePromotionActivityMasterAndDetailsData, SalePromotionActivityMasterAndDetails.Success, "CreateSalePromotionActivityRecord");
        }
    }
    else if (SalePromotionActivityMasterAndDetails.ActionName == "CreateItemDetailsRecord") {
        $("#FormCreateItemDetails").validate();
        if ($("#FormCreateItemDetails").valid()) {
            SalePromotionActivityMasterAndDetailsData = null;
            SalePromotionActivityMasterAndDetailsData = SalePromotionActivityMasterAndDetails.GetSalePromotionActivityMasterAndDetails();
            ajaxRequest.makeRequest("/SalePromotionActivityMasterAndDetails/CreateItemDetails", "POST", SalePromotionActivityMasterAndDetailsData, SalePromotionActivityMasterAndDetails.Success, "CreateItemDetailsRecord");
        }
    }
    else if (SalePromotionActivityMasterAndDetails.ActionName == "Edit") {
        $("#FormCreateDeactivateActivity").validate();
        if ($("#FormCreateDeactivateActivity").valid()) {
            SalePromotionActivityMasterAndDetailsData = null;
            SalePromotionActivityMasterAndDetailsData = SalePromotionActivityMasterAndDetails.GetSalePromotionActivityMasterAndDetails();
            ajaxRequest.makeRequest("/SalePromotionActivityMasterAndDetails/CreateDeActivateActivity", "POST", SalePromotionActivityMasterAndDetailsData, SalePromotionActivityMasterAndDetails.Success, "CreateDeactivateActivityRecord");
        }
    }
    else if (SalePromotionActivityMasterAndDetails.ActionName == "CreateFreeTypeItemList") {
        $("#FormCreateFreeTypeItemList").validate();
        if ($("#FormCreateFreeTypeItemList").valid()) {
            SalePromotionActivityMasterAndDetailsData = null;
            SalePromotionActivityMasterAndDetailsData = SalePromotionActivityMasterAndDetails.GetSalePromotionActivityMasterAndDetails();
            ajaxRequest.makeRequest("/SalePromotionActivityMasterAndDetails/CreateFreeTypeItemList", "POST", SalePromotionActivityMasterAndDetailsData, SalePromotionActivityMasterAndDetails.Success, "CreateFreeTypeItemListRecord");
        }
    }
    else if (SalePromotionActivityMasterAndDetails.ActionName == "CreateGiftVoucherDetails") {
        $("#FormCreateGiftVoucherDetails").validate();
        if ($("#FormCreateGiftVoucherDetails").valid()) {
            SalePromotionActivityMasterAndDetailsData = null;
            SalePromotionActivityMasterAndDetailsData = SalePromotionActivityMasterAndDetails.GetSalePromotionActivityMasterAndDetails();
            ajaxRequest.makeRequest("/SalePromotionActivityMasterAndDetails/CreateGiftVoucherDetails", "POST", SalePromotionActivityMasterAndDetailsData, SalePromotionActivityMasterAndDetails.Success, "CreateGiftVoucherRecord");
        }
    }

   
    else if (SalePromotionActivityMasterAndDetails.ActionName == "Delete") {

        SalePromotionActivityMasterAndDetailsData = null;
        //$("#FormCreateSalePromotionActivityMasterAndDetails").validate();
        SalePromotionActivityMasterAndDetailsData = SalePromotionActivityMasterAndDetails.GetSalePromotionActivityMasterAndDetails();
        ajaxRequest.makeRequest("/SalePromotionActivityMasterAndDetails/Delete", "POST", SalePromotionActivityMasterAndDetailsData, SalePromotionActivityMasterAndDetails.Success);

    }
},


//Get properties data from the Create, Update and Delete page
GetSalePromotionActivityMasterAndDetails: function () {
    var Data = {
    };

    if (SalePromotionActivityMasterAndDetails.ActionName == "Create" || SalePromotionActivityMasterAndDetails.ActionName == "Edit" || SalePromotionActivityMasterAndDetails.ActionName == "CreateActivityDetailsForFixedAmount" || SalePromotionActivityMasterAndDetails.ActionName == "CreateItemDetailsRecord") {
        Data.ID = $('#ID').val();
        Data.Name = $('#Name').val();
        Data.PlanTypeCode = $('#PlanTypeCode').val();
        Data.FromDate = $('#FromDate').val();
        Data.UptoDate = $('#UptoDate').val();
        Data.GeneralUnitsID = $('#GeneralUnitsID').val();
        Data.SalePromotionActivityDetailsID = $('#SalePromotionActivityDetailsID').val();
        Data.SalePromotionActivityMasterID = $('#SalePromotionActivityMasterID').val();
        Data.PlanDescription = $('#PlanDescription').val();
        Data.SalePromotionPlanDetailsID = $('#PlanDescription').val();

        Data.PromotionFor = $('#PromotionFor').val();
        Data.ExternalFlag = $('#ExternalFlag').val();
        Data.IsCoupanOrGiftVoucherApplicable = $('#IsCoupanOrGiftVoucherApplicable').is(":checked") ? "true" : "false";
        Data.IsCommon = $('#IsCommon').is(":checked") ? "true" : "false";

        if ($("#PlanTypeCode").val() == "PriceDiscountOffPerItem") {
            Data.XMLstring = SalePromotionActivityMasterAndDetails.ParameterXml;
        }
        else if ($("#PlanTypeCode").val() == "ProductConcessionFree" && $('#ProductConcessionFreeType').val() == "1")
        {
            Data.XMLstring = SalePromotionActivityMasterAndDetails.ParameterXmlForConcessionActivity;
        }
        else if ($("#PlanTypeCode").val() == "ProductConcessionFree" && $('#ProductConcessionFreeType').val() == "2") {
            Data.XMLstring = SalePromotionActivityMasterAndDetails.ParameterXmlForFreeType;
        }
        Data.ParameterXmlForFixedData = SalePromotionActivityMasterAndDetails.ParameterXmlForFixedData;
        Data.ParameterXmlForItemDetails = SalePromotionActivityMasterAndDetails.ParameterXmlForItemDetails;
        Data.ProductConcessionFreeType = $('#ProductConcessionFreeType').val();
           
    }
    else if (SalePromotionActivityMasterAndDetails.ActionName == "CreateFreeTypeItemList")
    {
            Data.ParameterXmlForItemDetails = SalePromotionActivityMasterAndDetails.ParameterXmlForFreeTypeItemList;
            Data.SalePromotionActivityDetailsID = $('#SalePromotionActivityDetailsID').val();
            Data.PlanTypeCode = $('#PlanTypeCode').val();
            Data.ProductConcessionFreeType = $('#ProductConcessionFreeType').val();
            Data.SalePromotionPlanDetailsID = $('#SalePromotionPlanDetailsID').val();
    }
    else if (SalePromotionActivityMasterAndDetails.ActionName == "CreateGiftVoucherDetails") {
        Data.ParameterXmlForGiftVouchar = SalePromotionActivityMasterAndDetails.ParameterXmlForGiftVouchar;
        Data.SalePromotionActivityDetailsID = $('#SalePromotionActivityDetailsID').val();
        Data.PlanTypeCode = $('#PlanTypeCode').val();
        Data.SalePromotionPlanDetailsID = $('#SalePromotionPlanDetailsID').val();
    }

    else if (SalePromotionActivityMasterAndDetails.ActionName == "Delete") {

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
        SalePromotionActivityMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
    }
    else {
        $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
    }
},
};

