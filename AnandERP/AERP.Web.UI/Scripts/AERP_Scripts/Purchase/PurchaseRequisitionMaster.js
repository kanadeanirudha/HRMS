////////////////////////////new js//////////////////////////////

//this class contain methods related to nationality functionality
var PurchaseRequisitionMaster = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    flag: true,
    map: {},
    map2: {},
    map3: {},
    BlockForProcurement: 1,//false
    DivAbcd: false,
    //Class intialisation method
    Initialize: function () {
        PurchaseRequisitionMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {

        $('#TransDate').datetimepicker({
            format: 'DD MMM YYYY',
            maxDate: moment(),
            ignoreReadonly: true,
        })

        $('#ExpectedDeliveryDate').datetimepicker({
            format: 'DD MMM YYYY',
            minDate: moment(),
            ignoreReadonly: true,
        })

        //$('#ExpectedDeliveryDate').datepicker({
        //    dateFormat: 'd M yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //    minDate: 0,
        //})
        //$("#TransDate").datepicker({
        //    changeMonth: true,
        //    changeYear: true,
        //    maxDate: '0',
        //    todayHighlight: true,
        //    numberOfMonths: 1,
        //    dateFormat: 'dd M yy',

        //});
        //Icon on Index View to call List View
        $('#IconShowList').click(function () {

            $('#IconShowList').hide();
            $('#IconShowPurchaseRequisition').show();
            $.ajax(
           {
               cache: false,
               type: "Get",
               // data: { "selectedBalsheet": Balancesheet },
               dataType: "html",
               url: '/PurchaseRequisitionMaster/List',
               success: function (data) {
                   //Rebind Grid Data
                   $('#divContent').empty();
                   $('#divContent').html(data);
                   $('#divContent').fadeIn();
               }
           });
        });
        //


        //Show Button on List View
        $('#btnShowListforList').unbind('click').click(function () {

            var ReplishmentCode = $('#ReplishmentCode').val();
            var valuPurchaseRequisitionType = $('#PurchaseRequisitionType :selected').val();
            var ValuTransDate = $('#TransDate').val();
            var AdminRoleID = $('#AdminRoleID').val();
            var MonthName = $('#MonthName').val();
            var MonthYear = $('#MonthYear').val();
            var StatusFlag = 1

            if (valuPurchaseRequisitionType == " " || valuPurchaseRequisitionType == null) {

                notify("Please select Purchase Requisition Type", "danger");

                $('#DivCreateNew').hide(true);
            }

            else if ((ValuTransDate == "" || ValuTransDate == null) && (MonthName == "" && MonthYear == "")) {

                notify("Please select Transaction Date", "danger");
                // $('#DivCreateNew').hide(true);

            }
            else if (valuPurchaseRequisitionType != "" && ValuTransDate != "") {
                PurchaseRequisitionMaster.LoadList(valuPurchaseRequisitionType, ValuTransDate, MonthName, MonthYear, StatusFlag, ReplishmentCode, AdminRoleID);

            }


        });

        $("#Quantity").on("change keyup", function () {

            var amount = parseFloat($("#Rate").val() * $("#Quantity").val()).toFixed(2);
            $("#Amount").val(amount);

            var tax = ((parseFloat($("#Rate").val() * $("#Quantity").val()) * $("#taxpercentage").val()) / 100);
            //var tax1 = $("#taxpercentage").val();
            $("#TaxRate").val(tax);

            var totalamounttax = (amount + tax);
            //    $("#TotalAmmount").val(totalamounttax);

            var conversion = ($("#Quantity").val() * $('#BaseUOMQuantity').val())

            var abc = "(" + $('#Quantity').val() + "*" + $('#BaseUOMQuantity').val() + ")" + ' ' + "=" + ' ' + parseFloat(conversion).toFixed(2) + ' ' + $('#BaseUOMCode').val();

            $("#Convertion").val(abc);


        });

        $("#discount").on("keyup", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $('#discount').val(0);
                var abc = $("#Amount1").val()

                $("#Amount").val(abc);
            }
        });
        // Create new record
        $('#addItem').on("click", function () {

            $("#abcd").show;
            $("#PurchaseRequisationForManual").show(true);
            $("#DivAddRowTable3").show(true);
            $("#abcd").show(true);
            $("#buttonId").show(true);
            var selectedItemID1 = $("select[id=checkboxlist1]").val();

            if ($("#PurchaseRequisitionType").val() != 5 && $("#SerialAndBatchManagedBy").val() == 2) {
                if (parseFloat($("#Quantity").val()) > parseFloat($("#BatchQuantity").val())) {
                    notify("Please enter quantity less than batch quantity", "danger");
                    return false;
                }
            }

            if ($("#ItemName").val() == "") {

                notify("Please Enter Item Name", "danger");
                $("#ItemName").focus();
                return false;
            }

            //else if (selectedItemID1 == 3) {
            //if (parseFloat($("#MinimumOrderquantity").val()) > parseFloat($("#Quantity").val())) {
            //    notify("Please Enter Quantity Greater Than Minimum order qunatity.", "danger");
            //    return false;
            //}

            //}

            //to check duplication of item while adding the item(Restrict Duplication of Item)
            var DataArray = [];
            var data = $('#DivAddRowTable3 input').each(function () {
                DataArray.push($(this).val());
            });

            TotalRecord = DataArray.length;

            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 23) {
                if (DataArray[i] == $('#ItemNumber').val() && DataArray[i + 6] == $('#StorageLocationID').val()) {

                    notify("You Cannot Enter the same item Twice", "danger");
                    $("#ItemName").val("");
                    $("#ItemID").val(0);
                    $("#Quantity").val("");
                    $("#ExpectedDeliveryDate").val("");
                    $("#PriorityFlag").val("");
                    $("#Rate").val("");
                    $("#StorageLocationID").val("");
                    $("#Convertion").val("");
                    $("#ItemName").focus();
                    return false
                }
            }


            //End Of Code for Duplication of Item
            //******************* CODE FOR CALENDER********************//
            if ($("#ExpectedDeliveryDate").val() == null || $("#ExpectedDeliveryDate").val() == "" || $("#ExpectedDeliveryDate").val() == "Invalid Date") {
                //$('#msgDiv').html("Please Enter Expected Delivery Date.");
                //$('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                notify("Please Enter Expected Delivery Date", "danger");
                $("#ExpectedDeliveryDate").focus();
                return false;
            }

            var d = new Date($("#ExpectedDeliveryDate").val());


            //var today = new Date();
            //var time = (today.getUTCHours() + ":" + today.getUTCMinutes() + ":" + today.getUTCSeconds() + ":" + today.getUTCMilliseconds())


            var curr_date = d.getDate();
            var curr_month = d.getMonth() + 1; //Months are zero based
            var curr_year = d.getFullYear();

            if (curr_month == 10 || curr_month == 11 || curr_month == 12) {
                curr_month = curr_month;
            }
            else {
                curr_month = "0" + curr_month;
            }
            if (curr_date == 1 || curr_date == 2 || curr_date == 3 || curr_date == 4 || curr_date == 5 || curr_date == 6 || curr_date == 7 || curr_date == 8 || curr_date == 9) {
                curr_date = "0" + curr_date;
            }
            var ExpectedDate = (curr_year + "-" + curr_month + "-" + curr_date);

            var date = new Date(ExpectedDate).toDateString("yyyy-MM-dd");

            if (date == null || date == "" || date == "Invalid Date") {
                var ExpectedDate = "";
            }
            else {
                var ExpectedDate = (curr_year + "-" + curr_month + "-" + curr_date);

            }
            if (d == "" || d == null) {

                var aaaa = "<td ><input type='text' style='display:none'  value= '0' >" + "-" + "</td>"


            }
            else {
                var aaaa = "<td ><input type='text' style='display:none' value='" + ExpectedDate + " '> " + $('#ExpectedDeliveryDate').val() + "</td>"

            }

            //******************* CODE FOR CALENDER ENDS********************//
            //******************* CODE FOR  Priority Flag DROPDOWN ********************//
            var Priority = $("#PriorityFlag").val()
            if (Priority == 1) {
                var Pr1 = "High";
            }
            else if (Priority == 2) {
                var Pr1 = "Medium";
            }
            else if (Priority == 3) {
                var Pr1 = "Low";
            }

            var Priority1 = "<td style='display:none'><input type='text' style='display:none'  value='" + $("#PriorityFlag").val() + "' />" + Pr1 + "</td>"
            //var Priority2 = "<td ><input type='text' style='display:none'  value=" + $("#PriorityFlag").text() + "/>" + $("#PriorityFlag").text() + "</td>"


            //******************* CODE FOR  Priority Flag DROPDOWN ENDS ********************//


            if ($('#PurchaseRequisitionType').val() == 5) {
                StorageLocationID = $('#StorageLocationID').val();
                var abc1 = $('#StorageLocationID :selected').text();
                if ($("#StorageLocationID").val() == "" || $("#StorageLocationID").val() == 0 || $("#StorageLocationID").val() == null) {

                    notify("Please Select Location", "danger");
                    $("#StorageLocationID").focus();
                    return false;
                }
            }
            else {
                StorageLocationID = $('select[name=STO]').val();
                var abc1 = $('select[name=STO] :selected').text();
                $('#StorageLocationID').val(StorageLocationID);

                if ($('select[name = STO]').val() == "" || $('select[name = STO]').val() == 0 || $('select[name = STO]').val() == null) {

                    notify("Please Select Location", "danger");
                    $("#StorageLocationID").focus();
                    return false;
                }
            }
            var IssueFromLocationID = $('#IssueFromLocationID').val();

            //var abc2 = $('#IssueFromLocationID :selected').text();
            if ($("#IssueFromLocationID").val() == "" || $("#IssueFromLocationID").val() == 0 || $("#IssueFromLocationID").val() == null) {
                var IssueFromLocationID = "<td><input id='IssueFromLocationID' type='hidden' value=0 /></td>"
            }
            else {
                var IssueFromLocationID = "<td><input id='IssueFromLocationID' type='hidden' value=" + $('#IssueFromLocationID').val() + " /></td>"
            }
            //if ($("#DepartmentName").val() == null || $("#DepartmentName").val() == "" || $("#DepartmentID").val() == 0) {

            //    notify("Please Select Location", "danger");
            //    $("#DepartmentName").focus();
            //    return false;
            //}

            if ($('#PurchaseRequisitionType :selected').val() == 3) {
                var UnitCode = "<td>" + $("#STOUnits").children().children("#UnitCode").val() + "</td>" //xyzabd
                var UnitCodeInput = $("#STOUnits").children().children("#UnitCode").val();
            }
            else {
                var UnitCode = "<td>" + $('#UnitCode').val() + "</td>"
                var UnitCodeInput = $('#UnitCode').val()
            }


            var amount = parseFloat($("#Rate").val() * $("#Quantity").val()).toFixed(2);
            $("#Amount").val(amount);
            var tax = ((parseFloat($("#Rate").val() * $("#Quantity").val()) * $("#taxpercentage").val()) / 100);

            var totalamount = parseFloat(parseFloat(amount) + ((parseFloat($("#Rate").val() * $("#Quantity").val()) * $("#taxpercentage").val()) / 100)).toFixed(2);

            var StorageLocationID;

            if ($('#PurchaseRequisitionType').val() == 5) {
                StorageLocationID = $('select[name=SR]').val();
            }
            else {
                StorageLocationID = $('select[name=STO]').val();
            }
            var ItemName = $('#ItemName').val();
            var ItemNumber = $('#ItemNumber').val();
            var data = new FormData();
            data.append("ItemNumber", ItemNumber);
            data.append("StorageLocationID", StorageLocationID);
            $.ajax({
                url: "/PurchaseRequirementMaster/CheckForBlockForProcurement",
                type: "POST",
                processData: false,
                contentType: false,
                data: data,               //Q => Question
                dataType: 'json',
                success: function (data) {
                    if (data == 'True') {

                        PurchaseRequisitionMaster.BlockForProcurement = 0;
                        notify('Can Not Add ' + ItemName + ' Item as ProcurmentBlock is Checked.', 'danger')
                        $("#ItemName").val("");
                        $("#ItemNumber").val("");
                        $("#BarCode").val("");
                        $("#GeneralItemCodeID").val(0);
                        $("#Quantity").val("");
                        $("#ExpectedDate").val("");
                        $("#PriorityFlag").val("1");
                        $("#Rate").val("");
                        $("#Remark").val("");
                        $("#StorageLocationID").val("");
                        $('#UnitCode').val("");
                        $("#Convertion").val("");
                        $("#ExpectedDeliveryDate").val("");
                        $(".abc").val("");

                    }
                },
                async: false,
                error: function (er) {

                    // alert(er);
                }
            });

            if (PurchaseRequisitionMaster.BlockForProcurement == 1) {
                if ($('#ItemName').val() != "" && $("#GeneralItemCodeID").val() > 0 && parseFloat($("#Quantity").val()) > 0) {
                    $("#tblData tbody").append(
                        "<tr>" +
                               "<td ><input type='text' value=" + $('#ItemNumber').val() + " style='display:none;' /> " + $('#ItemName').val() + "</td>" +
                                "<td><input id='quantity' class='form-control' style='height:20px;' maxlength='8' type='text' value=" + parseFloat($('#Quantity').val()).toFixed(3) + " style=''/></td>" +
                                UnitCode +
                                "<td ><input type='text' value=" + $('#Rate').val() + " style='display:none' /> " + $('#Rate').val() + "</td>" +
                                aaaa +
                                Priority1 +
                                "<td style='display:none'> <input id='GenTaxGroupMasterID' type='text' value=" + $('#GenTaxGroupMasterID').val() + " /></td>" +
                                "<td style='display:none'> " + tax + " </td>" +
                                "<td  style=''>" + amount + "</td>" +
                                "<td ><input type='text' value=" + StorageLocationID + " style='display:none' /> " + abc1 + "</td>" +
                                "<td style='display:none' ><input type='hidden' value=" + $('#IssueFromLocationID').val() + "/> " + 0 + "</td>" +
                                "<td  style='display:none'><input type='text' value=" + $('#DepartmentID').val() + " style='display:none' /> " + $('#DepartmentName').val() + "</       td>" +
                                "<td>" + $('#TaxGroupName').val() + "</td>" +
                                "<td id='TaxAmountForDisplay'>" + parseFloat(tax).toFixed(2) + "</td>" +
                                "<td  style=''>" + totalamount + "</td>" +
                                "<td id='taxTD' style='display:none'> <input id='taxamt' type='text' value=" + tax + " /></td>" +
                                "<td  style=''><i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete><input type='hidden' id='itemname' value=" + $('#ItemName').val().replace(/ /g, "~") + "  /><input type='hidden' id='Locationname' value=" + abc1.replace(/ /g, "~") + "  /><input type='hidden'      id='LocationAndItemId' value=" + $('#GeneralItemCodeID').val() + '~' + StorageLocationID + "  /><input id='taxPercentage' type='hidden' value=" + $("#taxpercentage").val() + " /><input id='Priority2' type='hidden' value=" + $("#PriorityFlag").text() + "/><input id='GeneralItemCodeID'         type='hidden' value=" + $('#GeneralItemCodeID').val() + " /><input id='BarCode' type='hidden' value='" + $('#BarCode').val() + "' /><input      id='OrderUomCode' type='hidden' value='" + UnitCodeInput + "'/><input id='BaseUOMQuantity' type='hidden' value=" + $('#BaseUOMQuantity').val() + " /><input id='BaseUOMCode' type='hidden' value=" + $('#BaseUOMCode').val() + " /></td>" +
                              "<td  style='display:none'>" + IssueFromLocationID + "</td>" +
                        "</tr>");


                    $("#ItemName").val("");
                    $("#GeneralItemCodeID").val(0);
                    $("#Quantity").val("");
                    $("#Convertion").val("");
                    $("#ExpectedDeliveryDate").val("");
                    $("#PriorityFlag").val("1");
                    $("#Rate").val("");
                    $("#StorageLocationID").val("");
                    $("#IssueFromLocationID").val("");
                    $("#DepartmentName").val("");
                    $('#UnitCode').val("");
                    $("#TaxRate").val("");
                    $('select[name=STO]').val("");
                    $('select[name=IssueFromLocationID]').val("");
                    $(".abc").val("");
                    $("#STOUnits").children().children("#UnitCode").val("");

                    $('input[id^=quantity]').on("keydown", function (e) {
                        AERPValidation.AllowNumbersWithDecimalOnly(e);
                        AERPValidation.NotAllowSpaces(e);
                    });
                    $('input[id^=quantity]').on("keyup", function (e) {
                        // var selectedItemID2 = $("select[id=checkboxlist1]").val();
                        // var quantity = $(this).closest('tr').find('td input[id^=quantity]').val();
                        parseFloat($(this).val()).toFixed(2);

                        //if (selectedItemID2 == 3) {
                        //    if (parseFloat($("#MinimumOrderquantity").val()) > parseFloat(quantity)) {
                        //        notify("Please Enter Quantity Greater Than Minimum order qunatity.", "danger");
                        //        return false;
                        //    }
                        //}
                    });

                }

                else if ($("#GeneralItemCodeID").val() == 0) {

                    notify("Invalid item selected", "danger");
                }

                else if ($("#Quantity").val() == "" || $("#Quantity").val() == 0 || $("#Quantity").val() == '.') {

                    notify("Please Enter Quantity.", "danger");
                    $("#Quantity").focus();
                    return false;
                }
            }
            PurchaseRequisitionMaster.BlockForProcurement = 1;
            PurchaseRequisitionMaster.TotalItem();
            PurchaseRequisitionMaster.TotalBillAmount();
            PurchaseRequisitionMaster.TotalTaxAmount();
            PurchaseRequisitionMaster.TotalGrossAmmount();

            //Delete record in table
            $("#DivAddRowTable3 tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
                PurchaseRequisitionMaster.TotalItem1();
                PurchaseRequisitionMaster.TotalBillAmount();
                PurchaseRequisitionMaster.TotalTaxAmount();
                PurchaseRequisitionMaster.TotalGrossAmmount();
            });


        });
        //On Dump Quantity Change
        $("#tblData tbody").on("keyup", "tr td input[id^=quantity]", function () {
            var quantity = parseFloat($(this).closest('tr').find('td input[id^=quantity]').val());
            var rate = parseFloat($(this).closest('tr').find('td').eq(3).text());
            if (parseFloat(quantity) == 0 || parseFloat(quantity) <= 0) {

                notify("Please enter Quantity", "danger");


            }
            var totalamount = ((quantity * rate).toFixed(2));
            var taxRate = parseFloat($(this).closest('tr').find('td input[id^=taxPercentage]').val());
            var taxamount = ((totalamount * taxRate) / 100).toFixed(2);
            $(this).closest('tr').find('td').eq(7).text((((parseFloat(quantity * rate).toFixed(2)) * taxRate) / 100).toFixed(2));

            $(this).closest('tr').find('td').eq(8).text(parseFloat(quantity * rate).toFixed(2));
            parseFloat($(this).closest('tr').find('td input[id^=taxamt]').val(taxamount));
            parseFloat($(this).closest('tr').find('td[id^=TaxAmountForDisplay]').text(taxamount));
            // $(this).closest('tr').find('td').eq(taxID).text(parseFloat(taxamount).toFixed(2));
            $(this).closest('tr').find('td input[id=taxTD]').val((((parseFloat(quantity * rate).toFixed(2)) * taxRate) / 100).toFixed(2));
            $(this).closest('tr').find('td').eq(14).text(parseFloat((parseFloat(taxamount)) + (parseFloat(totalamount))).toFixed(2));
            // $(this).closest('tr').find('td').eq(13).text((((parseFloat(quantity * rate).toFixed(2)) * taxRate) / 100).toFixed(2));

            PurchaseRequisitionMaster.TotalBillAmount();
            PurchaseRequisitionMaster.TotalTaxAmount();
            PurchaseRequisitionMaster.TotalGrossAmmount();
        });

        //On Dump Quantity Change
        $("#tblDataa tbody").on("keyup", "tr td input[id^=Quantity]", function () {

            var quantity = parseFloat($(this).closest('tr').find('td input[id^=Quantity]').val());
            var rate = parseFloat($(this).closest('tr').find('td input[id^=Rate]').val());
            if (parseFloat(quantity) == 0 || parseFloat(quantity) <= 0) {

                notify("Please enter Quantity", "danger");

            }
            var totalamount = ((quantity * rate).toFixed(2));
            var taxrate = parseFloat($(this).closest('tr').find('td input[id^=TaxRate]').val());
            // alert(totalamount)
            $(this).closest('tr').find('td').eq(7).text((((parseFloat(quantity * rate).toFixed(2)) * taxrate) / 100).toFixed(2));
            var taxamount = ((totalamount * taxrate) / 100).toFixed(2);
            // alert(taxamount);

            parseFloat($(this).closest('tr').find('td input[id^=taxAmount]').val(taxamount));
            $(this).closest('tr').find('td').eq(taxAmount).text(parseFloat(taxamount).toFixed(2));

        });

        // Create new record
        $('#CreatePurchaseRequisitionMaster').on("click", function () {

            PurchaseRequisitionMaster.ActionName = "Create";
            var selectedRequisitionType = $('#PurchaseRequisitionType').val();
            var selectedVendorID = $('#VendorID').val();
            if (selectedRequisitionType == " " || selectedRequisitionType == null) {

                notify("Please select Purchase Requisition Type", "danger");
                return false;
            }
            else if (selectedRequisitionType != 3 && (selectedVendorID == " " || selectedVendorID == null || selectedVendorID == "0")) {

                notify("Please select Vendor", "danger");
                return false;
            }
            else {
                PurchaseRequisitionMaster.GetXmlData();
                if (PurchaseRequisitionMaster.XMLstring != null && PurchaseRequisitionMaster.XMLstring != "") {
                    $('#CreatePurchaseRequisitionMaster').attr("disabled", true);
                    PurchaseRequisitionMaster.AjaxCallPurchaseRequisitionMaster();
                }
                else {

                    notify("No data available in table", "danger");
                }
                $('#DivAddRowTable1').remove();
                $('#DivAddRowTable2').remove();
                $('#DivAddRowTable3').remove();
                $("#tblDataa tbody tr").remove();
                //   $('#ListViewModel').remove();
                //$('#PurchaseRequisitionType').val(" ");
                //$('#Vendor').val("");
                //$('input:checkbox,input:radio').removeAttr('checked');
                //$(".ms-choice span").text('');
            }
        });

        $('#EditPurchaseRequisitionMaster').on("click", function () {

            PurchaseRequisitionMaster.ActionName = "Edit";
            PurchaseRequisitionMaster.flag = true;
            PurchaseRequisitionMaster.GetXmlDataEditRequisation();
            if (PurchaseRequisitionMaster.flag == false) {
                $("#displayErrorMessage").text("Please Enter Quantity").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            PurchaseRequisitionMaster.AjaxCallPurchaseRequisitionMaster();
        });
        $('#CreatePurchaseOrderByRequisition').on("click", function () {
            PurchaseRequisitionMaster.ActionName = "CreatePO";
            PurchaseRequisitionMaster.flag = true;
            PurchaseRequisitionMaster.GetXmlDataEditRequisation();
            if (PurchaseRequisitionMaster.flag == false) {
                $("#displayErrorMessage").text("Please Enter Quantity").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            PurchaseRequisitionMaster.AjaxCallPurchaseRequisitionMaster();
        });
        $('#DepartmentName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
        $("#ItemName").on("keyup", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#ItemName").val("");
                $("#Quantity").val("");
                $("#Convertion").val("");
                $("#UnitCode").val("");
                $("#UnitCode").text("");
                $("#Rate").val("");
                $(".abc").val("");
                $("#ExpectedDeliveryDate").val("");
                $("#PriorityFlag").val("1");
                $("#TaxRate").val("");
                $("#StorageLocationID").val("");
                //$("#StorageLocationID").text("");
                $("#DepartmentName").val("");
                $("#IssueFromLocationID").val("");
                $('#ItemName').typeahead('val', '');
                $('select[name=STO]').val("");
                $("#BatchQuantity").val(0);
                $("#SerialAndBatchManagedBy").val(0);
                return false;
            }
        });
        //when we add Manual Requisition To Final submit.
        //Append the Complete data of Div DivAddRowTable3 to Div constantTbody.

        $('#AddManual').on("click", function () {

            //PurchaseRequisitionMaster.GetXmlDataForManualRequisistion();
            var DataArray = []; var DataArray1 = []; var k = 0; var DataArray2 = [];
            $('#DivAddRowTable3 input').each(function () {
                DataArray.push($(this).val());
            });

            $('#constantTbody input').each(function () {
                DataArray1.push($(this).val());
            });
            //validation for quantity ....
            if ((DataArray[1]) == "" || (DataArray[1]) == 0 || (DataArray[1]) == null) {

                notify("Please Enter Quantity", "danger");
                return false;
            }
            // var selectedItemID1 = $("select[id=checkboxlist1]").val();
            var TotalRecord = DataArray.length;
            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 21) {
                var CheckedArray = [];

                $.each($("input[name='checkbox12']:checked"), function () {
                    CheckedArray.push($(this).val())

                });
                //if (selectedItemID1 == 3) {
                //    if (parseFloat($("#MinimumOrderquantity").val()) > DataArray[i + 1]) {
                //        notify("Please Enter Quantity Greater Than Minimum order qunatity.", "danger");
                //        return false;
                //    }
                //}

                //to remove "on" when we checked all checkbox.
                //for (var j = CheckedArray.length - 1; j--;) {
                //if (CheckedArray[j] === "on") CheckedArray.splice(j, 1);
                //}
                //alert(DataArray1.length)
                // alert(DataArray1[k])
                // alert(DataArray[i+12])
                //if (DataArray1.length >= 1 && DataArray1[k] == DataArray[i + 12]) {

                //    notify("Do not Add the Item Previously Added for Item" + DataArray[i + 10].replace(/~/g, ' ') + " and location " + DataArray[i + 11] + "","danger");
                //    return false;
                //}

                if (DataArray1[i + 13] == DataArray[i + 11] && DataArray1[i + 4] == DataArray[i]) {

                    //notify("Do not Add the Item Previously Added for Item" + DataArray[i + 10].replace(/~/g, ' ') + " and location " + DataArray[i + 11] + "","danger");
                    notify("Do not Add the Item Previously Added for Item", "danger");
                    return false;
                }

                else {
                    $('#constantTbody').append(

                    '<tr><td style=display:none><input type="hidden" id="storagelocation+Itemnumber" value=' + DataArray[i + 12] + '></td>' +
                    '<td id="itemname"> ' + DataArray[i + 10].replace(/~/g, ' ') + '</td>' +
                    //'<td id="itemID" style=display:none>' +DataArray[i +0]+ '</td>'+
                    '<td><input type="text" id="Quantity" class="form-control" disabled=disabled style="width: 80px; padding-left: 5px;height:20px;"  value=' + DataArray[i + 1] + '> </td>' +
                    '<td id="Rate">' + DataArray[i + 2] + '</td>' +
                    '<td id="ExcpectedDate">' + DataArray[i + 3] + '</td>' +
                    '<td id="Priority" style="display:none">' + DataArray[i + 14] + '</td>' +
                    '<td id="TaxAmount" style="display:none">' + DataArray[i + 9] + '</td>' +
                    '<td id="Location">' + DataArray[i + 11].replace(/~/g, ' ') + '</td>' +
                    '<td ><i class="zmdi zmdi-delete zmdi-hc-fw" style="cursor:pointer" title = "Delete">' +
                    '<td  style="display:none">' +
                        '<input type="hidden" id="storagelocandItemID" value=' + DataArray[i + 12] + '>' +
                        '<input type="hidden" id="ItemName" value=' + DataArray[i + 10] + '>' +
                        '<input type="hidden" id="ItemNumber" value=' + DataArray[i + 0] + '>' +
                        '<input type="hidden" id="Qty" value=' + DataArray[i + 1] + '>' +
                        '<input type="hidden" id="Rate" value=' + DataArray[i + 2] + '>' +
                        '<input type="hidden" id="ExpectedDate" value=' + DataArray[i + 3].replace(/ /g, "~") + '>' +
                        '<input type="hidden" id="Priority" value=' + DataArray[i + 4] + '>' +
                        '<input type="hidden" id="taxAmount" value=' + DataArray[i + 9] + '>' +
                        '<input type="hidden" id="TaxRate" value=' + DataArray[i + 13] + '>' +
                        '<input type="hidden" id="Amount" value=0>' +
                        '<input type="hidden" id="StorageLocnID" value=' + DataArray[i + 6] + '>' +
                        '<input type="hidden" id="LocAddress" value=' + DataArray[i + 11].replace(/~/g, ' ') + '>' +
                        '<input type="hidden" id="RequirementdetailId" value=0>' +
                        '<input type="hidden" id="RequirementNumber" value=0>' +
                        '<input type="hidden" id="DepartmentID" value=' + DataArray[i + 8] + '>' +
                        '<input type="hidden" id="IssueFromLocID" value=' + DataArray[i + 20] + '>' +
                        '<input type="hidden" id="GeneralItemCodeID" value=' + DataArray[i + 15] + '>' +
                        '<input type="hidden" id="BarCode" value=' + DataArray[i + 16] + '>' +
                        '<input type="hidden" id="BaseUOMQuantity" value=' + DataArray[i + 18] + '>' +
                        '<input type="hidden" id="BaseUOMCode" value=' + DataArray[i + 19] + '>' +
                        '<input type="hidden" id="OrderUoMCode" value=' + DataArray[i + 17] + '>' +
                      '</td>' +
                    '</td>' +
                    '</tr>'
                    )
                    //$('#DivAddRowTable3').remove();
                    // $('#DivAddRowTable3').html("");
                    $('#tblData tbody').html("");
                    $("#PurchaseRequisationForManual").hide(true);
                    $("#abcd").hide(true);
                    $("#buttonId").hide(true);
                    k++;
                }
            }
        });

        $('#Quantity').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
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

        //  FOLLOWING FUNCTION IS SEARCHLIST OF item list


        /////////////new search functionality///////////////////////////////////
        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;
                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var valuStorageLocationID = $("#StorageLocationID").val();
                var GeneralVendorID = $("#VendorID").val();
                var CentreCode = $("#SelectedCentreCode :selected").val();
                var PurchaseRequisitionType = $("#PurchaseRequisitionType :selected").val();
                $.ajax({
                    url: "/PurchaseRequisitionMaster/GetItemSearchList",
                    type: "POST",
                    data: { term: q, GeneralVendorID: GeneralVendorID, CentreCode: CentreCode, PurchaseRequisitionType: PurchaseRequisitionType },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.itemDescription)) {
                                PurchaseRequisitionMaster.map[response.itemDescription] = response;
                                matches.push(response.itemDescription);

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#ItemName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            $("#ItemNumber").val(parseFloat(PurchaseRequisitionMaster.map[item].itemNumber));
            $("#BarCode").val(PurchaseRequisitionMaster.map[item].barCode);

            $("#GenTaxGroupMasterID").val(PurchaseRequisitionMaster.map[item].GenTaxGroupMasterID);
            // $("#Rate").val(PurchaseRequisitionMaster.map[item].lastPurchasePrice);
            $("#GeneralItemCodeID").val(PurchaseRequisitionMaster.map[item].generalItemCodeID);
            $("#TaxGroupName").val(PurchaseRequisitionMaster.map[item].TaxGroupName);
            $("#taxpercentage").val(PurchaseRequisitionMaster.map[item].taxpercentage);

            $("#BaseUOMCode").val(PurchaseRequisitionMaster.map[item].baseUOMCode);
            $("#PurchaseGroupCode").val(PurchaseRequisitionMaster.map[item].PurchaseGroupCode);
            $(".abc").val(parseFloat(PurchaseRequisitionMaster.map[item].lastPurchasePrice).toFixed(2));
            $("#Rate").val($(".abc").val());
            $("#MinimumOrderquantity").val(PurchaseRequisitionMaster.map[item].MinimumOrderquantity);
            $("#SerialAndBatchManagedBy").val(PurchaseRequisitionMaster.map[item].SerialAndBatchManagedBy);

            var ItemNumberForSTO = $("#ItemNumber").val();
            if ($("#PurchaseRequisitionType").val() == '3') {
                $("#STOUnits").show();
                $("#SRUnits").hide(true);
                $("#STOUnits").children().children("#UnitCode").attr("disabled", false);
                $.ajax({
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: { "ItemNumber": ItemNumberForSTO },
                    url: '/PurchaseRequisitionMaster/GetUoMCodeByItemNumber',
                    success: function (data) {
                        var $ddlExam = $("#STOUnits").children().children("#UnitCode");
                        $ddlExam.html('');
                        //  $ddlExam.append('<option value=""></option>');
                        if (data.length != 0) {
                            $.each(data, function (id, option) {
                                $ddlExam.append($('<option></option>').val(option.name).html(option.name));
                            });
                            $("#BaseUOMQuantity").val(data[0].BaseUOMQuantity);
                            $("#Rate").val(data[0].Rate);


                        }
                        else {
                            $ddlExam.append('<option value="EA">EA</option>');

                        }

                    }
                });



            }
            else {
                $("#UnitCode").val(PurchaseRequisitionMaster.map[item].uomCode);
                $("#BaseUOMQuantity").val(PurchaseRequisitionMaster.map[item].baseUOMQuantity);

                $.ajax({
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: { "CentreCode": $("#SelectedCentreCode :selected").val() },
                    url: '/PurchaseRequisitionMaster/GetGeneralUnitsLocationListByCentreCode',
                    success: function (data) {
                        var $ddlExam = $("#divStdRequisitionLocation").children().children("#StorageLocationID");
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">------Select Sub Location-----</option>'); // Location replaced by Sub Location
                        if (data.length != 0) {
                            $.each(data, function (id, option) {
                                $ddlExam.append($('<option></option>').val(option.id).html(option.name));
                                $("#StorageLocationID").val(data[0].name);
                            });
                        }
                        else {
                            // $ddlExam.append('<option value="EA">EA</option>');
                        }

                    }
                });

            }
        });
        //end new search functionality

        //  FOLLOWING FUNCTION IS SEARCHLIST OF Vendor 


        /////////////new search functionality///////////////////////////////////
        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');


                $.ajax({
                    url: "/PurchaseRequisitionMaster/GetVendorSearchList",
                    type: "POST",
                    data: { term: q },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.name)) {
                                PurchaseRequisitionMaster.map2[response.name] = response;
                                matches.push(response.name);

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#Vendor").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            $("#VendorID").val(parseFloat(PurchaseRequisitionMaster.map2[item].id));
        });
        //end new search functionality

        //  FOLLOWING FUNCTION IS SEARCHLIST OF DepartmentName 


        /////////////new search functionality///////////////////////////////////
        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');


                $.ajax({
                    url: "/PurchaseRequisitionMaster/GetDepartmentNameSearchList",
                    type: "POST",
                    data: { term: q },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.name)) {
                                PurchaseRequisitionMaster.map3[response.name] = response;
                                matches.push(response.name);

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#DepartmentName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            $("#DepartmentID").val(parseFloat(PurchaseRequisitionMaster.map3[item].id));
        });
        //end new search functionality


        $('#Vendor').on("keydown", function (e) {
            AERPValidation.AllowAlphaNumericOnly(e);
            if (e.keyCode == 8 || e.keyCode == 46) {
                // $('#PurchaseRequisitionType').val(" ");
                $(".ms-choice span").text('');
                $('#Vendor').val("");
                $('input:checkbox,input:radio').removeAttr('checked');
                $("#tblDataPRQ tbody tr").remove();
                $("#DivAddRowTable1").hide(true);
                $("#AddRequisitionDiv").hide(true);
                $('#Vendor').typeahead('val', '');
                $('#ItemName').val("");
                $('#Quantity').val("");
                $('#Convertion').val("");
                $('#UnitCode').val("");
                $('#Rate').val("");
                $('#ExpectedDeliveryDate').val("");
                $('#StorageLocationID').val("");
                $('#VendorID').val("0");
            }
            //$(".ms-choice span").text('');
            //$('#Vendor').val("")
            //$('input:checkbox,input:radio').removeAttr('checked');
            //$("#tblDataPRQ tbody tr").remove();
            //$("#DivAddRowTable1").hide(true);
            //$("#AddRequisitionDiv").hide(true);
        });

        $("#SelectedCentreCode").change(function () {
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { "CentreCode": $("#SelectedCentreCode :selected").val() },
                url: '/PurchaseRequisitionMaster/GetGeneralUnitsLocationListByCentreCode',
                success: function (data) {
                    var $ddlExam = $("#divStdRequisitionLocation").children().children("#StorageLocationID");
                    $ddlExam.html('');
                    $ddlExam.append('<option value="">------Select Sub Location-----</option>'); // Location replaced by Sub Location
                    if (data.length != 0) {
                        $.each(data, function (id, option) {
                            $ddlExam.append($('<option></option>').val(option.id).html(option.name));
                            $("#StorageLocationID").val(data[0].name);
                        });
                    }
                    else {
                        // $ddlExam.append('<option value="EA">EA</option>');
                    }

                }

            });

        });
        $("#PurchaseRequisitionType").change(function () {
            var selectedItem = $(this).val();
            if (selectedItem == '3') {

                $("#VenderList").hide(true);
                $("#SelectedCentreCode").hide(true);
                // $("#VendorID").val("");
                $("#Vendor").val("");
                $(".ms-choice span").text('');
                $('input:checkbox,input:radio').removeAttr('checked');
                $("#divIssueFromLocationID").show();
                $("#STOForLocationID").show();
                $("#IssueFromLocationID").val("");
                $("#divStdRequisitionLocation").hide(true);
                //  $("#StorageLocationID").val("");
                $("#ItemName").val("");
                $("#Quantity").val("");
                $("#Convertion").val("");
                $("#UnitCode").val("");
                $("#Rate").val("");
                $("#ExpectedDeliveryDate").val("");
                $('select[name=STO]').val("");
                $("#STOUnits").show();
                $("#SRUnits").hide(true);
                $("#SRUnits").children().children("#UnitCode").val("");
                $("#SelectedCentreCode").val("");
                $("#Vendor").val("");
                $("#VendorID").val(0);
                $('#Vendor').typeahead('val', '');
            }
            else {
                $("#VenderList").show(true);
                $("#SelectedCentreCode").show(true);
                $("#Vendor").prop('disabled', false);
                $(".ms-choice span").text('');
                $('input:checkbox,input:radio').removeAttr('checked');
                $("#divIssueFromLocationID").hide();
                // $("#IssueFromLocationID").val(0);
                $("#STOForLocationID").hide();
                $("#divStdRequisitionLocation").show();
                $("#ItemName").val("");
                $("#Quantity").val("");
                $("#Convertion").val("");
                $("#UnitCode").val("");
                $("#Rate").val("");
                $("#ExpectedDeliveryDate").val("");
                $('select[name=SR]').val("");
                $("#STOUnits").hide(true);
                $("#SRUnits").show();
                $("#STOUnits").children().children("#UnitCode").val("");
                $("#STOUnits").children().children("#UnitCode").attr("disabled", true);
            }
        });

        $('select[name=STO]').change(function () {
            if ($("#PurchaseRequisitionType").val() == 3) {
                var ItemNumber = $("#ItemNumber").val();
                var InventoryLocationMasterID = $('select[name=STO]').val();

                $.ajax({
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: { "ItemNumber": ItemNumber, "InventoryLocationMasterID": InventoryLocationMasterID },
                    url: '/PurchaseRequisitionMaster/GetBatchQuantityByItemNumber',
                    success: function (data) {
                        if (data == "" || data == null) {

                            $('#BatchQuantity').val(0);
                        }
                        else {;
                            $('#BatchQuantity').val(data[0].BatchQuantity);
                        }
                    }
                });
            }
        });

        $("#STOUnits").children().children("#UnitCode").change(function () {

            var selectedItem = $(this).val();
            var ItemNumber = $("#ItemNumber").val();
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { "ItemNumber": ItemNumber, "UoMCode": selectedItem },
                url: '/PurchaseRequisitionMaster/GetUoMCodeByItemNumberForPurchasePrice',
                success: function (data) {
                    $('#BaseUOMQuantity').val(data[0].BaseUOMQuantity)
                    $("#Rate").val(data[0].UomPurchasePrice);

                    var conversion = ($("#Quantity").val() * $('#BaseUOMQuantity').val())

                    var abc = "(" + $('#Quantity').val() + "*" + $('#BaseUOMQuantity').val() + ")" + ' ' + "=" + ' ' + parseFloat(conversion).toFixed(2) + ' ' + $('#BaseUOMCode').val();

                    $("#Convertion").val(abc);

                }
            });



        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $("#tblDataPRQ tbody").on("click", "tr td i[class=icon-trash]", function () {
            $(this).closest('tr').remove();
        });

        $("#tblDataa tbody").on("click", "tr td i", function () {
            $(this).closest('tr').remove();
        });
        $("#CreatePurchaseRequisitionMasterClear").click(function () {
            $("#tblDataa tr:not(:first)").remove();
            var selectedRequisitionType = $('#PurchaseRequisitionType :selected').val();
            var selectedVendorID = $('#VendorID').val();
            var RequsitionBy = $("select[id=checkboxlist1]").val();
            var CentreCode = $("#SelectedCentreCode :selected").val();
            var FromDate = $("#FromDate").val();
            var UptoDate = $("#UptoDate").val();
            $("#PurchaseRequisationForManual").hide();
            $('#tblData tr').remove();
            $("#buttonId").hide();
            $("#TotalItem").val(0);
            $("#TotalTaxAmount").val('0');
            $("#TotalBillAmount").val('0');
            $("#TotalGrossAmmount").val('0');
            $("#DivAddRowTable3").show(true);
            $('select[name=STO]').val("");
            $('select[name=IssueFromLocationID]').val("");
            PurchaseRequisitionMaster.LoadDiv(selectedRequisitionType, selectedVendorID, RequsitionBy, CentreCode, FromDate, UptoDate);



        });
        //Show list Button on Index View .Show the list According to VendorID and Requsition By(Parameters)
        $("#btnShowList").click(function () {

            var selectedRequisitionType = $('#PurchaseRequisitionType').val();
            var selectedVendorID = $('#VendorID').val();
            var CentreCode = $('#SelectedCentreCode :selected').val();
            var FromDate = $("#FromDate").val();
            var UptoDate = $("#UptoDate").val();
            $("#PurchaseRequisationForManual").hide(true);
            $("#DivAddRowTable3").hide(true);
            $("#abcd").hide(true);
            $("#buttonId").hide(true);

            PurchaseRequisitionMaster.getValueUsingParentTag_Check_UnCheck();
            var SelectedRequirementByIDs = PurchaseRequisitionMaster.SelectedRequirementByIDs;
            var selected = new Array();
            //$('#checkboxlist input[type=checkbox]:checked').each(function () {
            //    selected.push($(this).val());
            //    alert($(this).val());
            //});

            var selectedItemID = $("select[id=checkboxlist1]").val();
            //alert(selectedItemID[0]);
            if (selectedItemID != null) {
                for (var i = 0; i < selectedItemID.length; i++) {

                    selected.push(selectedItemID[i]);
                }

            }

            //alert(selected);

            if ((selected.length) >= 2) {
                var RequsitionBy = '0';
            }
            else {
                var RequsitionBy = selected[0];
            }
            if (selectedRequisitionType == " " || selectedRequisitionType == null) {

                notify("Please select Purchase Requisition Type", "danger");
            }
            else if (selectedRequisitionType != 3 && selectedVendorID == " " || selectedRequisitionType != 3 && selectedVendorID == null || selectedRequisitionType != 3 && selectedVendorID == "0") {

                notify("Please select Vendor", "danger");
            }

            else if (PurchaseRequisitionMaster.SelectedRequirementByIDs == "" || PurchaseRequisitionMaster.SelectedRequirementByIDs == null) {

                notify("Please select requirement by", "danger");
            }
            if (CentreCode == " " || CentreCode == null) {

                notify("Please select centre", "danger");
            }
            else {
                PurchaseRequisitionMaster.LoadDiv(selectedRequisitionType, selectedVendorID, RequsitionBy, CentreCode, FromDate, UptoDate);
                PurchaseRequisitionMaster.TotalItem();

            }
        });

        $("#ManualRequisitionList").click(function () {

            $("#PurchaseRequisationForManual").show(true);
            $("#belowStockSafetyLevelList").hide(true);
            $("#abcd").show(true);
            $("#buttonId").show(true);
            $("#purchaseList").hide(true);
            $("#ItemName").val("");
            $("#Rate").val("");
            $("#StorageLocationID").val("");
            $(".ms-choice span").text('');
            $('input:checkbox,input:radio').removeAttr('checked');
            $("#UnitCode").val("");
            $("#Convertion").val("");
            $("#Quantity").val("");
            $("#ExpectedDeliveryDate").val("");
            $(".abc").val("");
            $("#TotalItem").val(0);

        });

    },

    TotalItem: function () {
        var length = $("#tblDataPRQ tbody tr").length;
        $("#TotalItem").val(length);
    },
    TotalItem1: function () {
        var length = $("#DivAddRowTable3 tbody tr").length;
        $("#TotalItem").val(length);
    },
    TotalItem: function () {
        var length = $("#tblData tbody tr").length;
        $("#TotalItem").val(length);
    },
    TotalTaxAmount: function () {
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalTaxAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(7).text()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalTaxAmount").val(a.toFixed(2));

    },
    TotalBillAmount: function () {
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalBillAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(8).text()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalBillAmount").val(a.toFixed(2));

    },

    TotalGrossAmmount: function () {
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalGrossAmmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(14).text()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalGrossAmmount").val(a.toFixed(2));

    },
    TotalTaxAmountt: function () {
        var length = $("#tblDataPRQ tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalTaxAmountt").val(0);
        $("#tblDataPRQ tbody tr").each(function (i) {
            if (i < length) {
                // x = parseFloat($(this).find('td').eq(8).text()).toFixed(2);
                x = parseFloat($(this).find('td input[id=TaxAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalTaxAmountt").val(a.toFixed(2));

    },
    TotalBillAmountt: function () {
        var length = $("#tblDataPRQ tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalBillAmountt").val(0);
        $("#tblDataPRQ tbody tr").each(function (i) {
            if (i < length) {
                //x = parseFloat($(this).find('td').eq(10).text()).toFixed(2);
                x = parseFloat($(this).find('td input[id=Amount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalBillAmountt").val(a.toFixed(2));

    },
    TotalGrossAmmountt: function () {
        var length = $("#tblDataPRQ tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalGrossAmmountt").val(0);
        $("#tblDataPRQ tbody tr").each(function (i) {
            if (i < length) {
                //x = parseFloat($(this).find('td').eq(17).text()).toFixed(2);
                x = parseFloat($(this).find('td input[id=GrossAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalGrossAmmountt").val(a.toFixed(2));

    },
    //for edit view of requisition
    TotalTaxAmounttt: function () {
        var length = $("#tblDataEdit tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalTaxAmount").val(0);
        $("#tblDataEdit tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(17).find('input[id^=ItemWiseTaxAmount]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalTaxAmount").val(a.toFixed(2));
        $("#TotalTaxAmount").text(a.toFixed(2));
        //alert($("#TotalTaxAmount").val());
        //alert($("#TotalTaxAmount").text());

    },
    TotalGrossAmmounttt: function () {
        var length = $("#tblDataEdit tbody tr").length;
        var a = 0; var x = 0;
        $("#Amount").val(0);
        $("#tblDataEdit tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(16).find('input[id^=amt]').val()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#Amount").val(a.toFixed(2));
        $("#Amount").text(a.toFixed(2));
        //alert($("#Amount").val());
        //alert($("#Amount").text());
        //alert(a)

    },
    TotalBillAmountForEdit: function () {
        var length = $("#tblDataEdit tbody tr").length;
        var a = 0; var x = 0;
        $("#BillAmount").val(0);
        $("#tblDataEdit tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td[id^=GrossAmount]').text()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#BillAmount").val(a.toFixed(2));
        $("#BillAmount").text(a.toFixed(2));
    },

    //end code
    ////Load method is used to load *-Load-* page

    LoadList: function (PurchaseRequisitionType, TransDate, MonthName, MonthYear, StatusFlag, AdminRoleID) {
        debugger
        ReplishmentCode = $("#ReplishmentCode").val();

        $.ajax(
         {
             cache: false,
             type: "Get",
             data: { PurchaseRequisitionType: PurchaseRequisitionType, TransDate: TransDate,MonthName: MonthName, MonthYear: MonthYear , StatusFlag: 1, ReplishmentCode: ReplishmentCode, AdminRoleID: AdminRoleID },
             dataType: "html",
             url: '/PurchaseRequisitionMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#divContent').html(data);
                 $("#createDiv").show();
             }
         });
    },
    //// load Div according to Vendor Id and Requisition By
    LoadDiv: function (selectedRequisitionType, selectedVendorID, RequsitionBy, CentreCode, FromDate, UptoDate) {
        debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { PurchaseRequisitionType: selectedRequisitionType, VendorID: selectedVendorID, PurchaseRequisitionBy: RequsitionBy, CentreCode: CentreCode, FromDate: FromDate, UptoDate: UptoDate },
             dataType: "html",
             url: '/PurchaseRequisitionMaster/DataList',

             success: function (data) {
                 //Rebind Grid Data
                 debugger;
                 $('#ListViewModel').html(data);
                 var selectedItemID = $("select[id=checkboxlist1]").val();
                 if (selectedItemID == "3" )
                 {
                     $("#requirmentButtonDiv").show();
                 }

                 
                 PurchaseRequisitionMaster.TotalItem();
             }
         })
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var PurchaseRequisitionType = $('#PurchaseRequisitionType').val();
        var VendorID = $('#VendorID').val();
        var TransDate = $('#TransDate').val();
        var AdminRoleID = $('#AdminRoleID').val();
        if (actionMode == 0) {
            $.ajax(
            {
                cache: false,
                type: "GET",
                dataType: "html",
                data: { "actionMode": actionMode },
                url: '/PurchaseRequisitionMaster/Index',
                success: function (data) {
                    //$('#divContent').html(data);
                    notify(message, colorCode);
                }
            });
        }
        else {
            $.ajax(
                   {
                       cache: false,
                       type: "GET",
                       dataType: "html",
                       data: { "actionMode": actionMode, "PurchaseRequisitionType": PurchaseRequisitionType, "TransDate": TransDate, "AdminRoleID": AdminRoleID },
                       url: '/PurchaseRequisitionMaster/List',
                       success: function (data) {
                           // PurchaseRequisitionMaster.LoadList(data);
                           $('#divContent').html(data);
                           notify(message, colorCode);
                       }
                   });
        }
    },

    //Checked All checkbox if parent Checkbox is checked.
    CheckedAll: function () {
        $("#tblDataPRQ thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#tblDataPRQ tbody tr td  input[class='check-user']").prop("checked", true);
            }
            else {
                $("#tblDataPRQ tbody tr td  input[class='check-user']").prop("checked", false);
            }
        });
    },


    //Xml For Checked Checkbox.
    getValueUsingParentTag_Check_UnCheck: function () {
        var sList = "";
        var RequirementByID = 0;
        var xmlParamList = "<rows>"
        //$('#checkboxlist input[type=checkbox]').each(function () {
        //    if ($(this).val() != "on") {
        //        RequirementByID = $(this).val();
        //        //sArray = $(this).val().split("~");
        //        if (this.checked == true) {
        //            //xmlInsert code here
        //            xmlParamList = xmlParamList + "<row>" + "<ID>" + 0 + "</ID>" + "<RequirementBy>" + RequirementByID + "</RequirementBy></row>";
        //        }

        //    }
        //    if (xmlParamList.length > 6)
        //        PurchaseRequisitionMaster.SelectedRequirementByIDs = xmlParamList + "</rows>";
        //    else
        //        PurchaseRequisitionMaster.SelectedRequirementByIDs = "";
        //});
        //alert(PurchaseRequisitionMaster.SelectedTaxMaterIDs);

        //new
        //var selectedItemIDForXml = $("select[id=checkboxlist1]").val();
        var count = 0;
        $("select[id=checkboxlist1]").each(function () {

            if ($(this).val() != "on") {

                if ($(this).val()) {
                    RequirementByID = $(this).val()[count];
                    //xmlInsert code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + 0 + "</ID>" + "<RequirementBy>" + RequirementByID + "</RequirementBy></row>";
                }

            }
            if (xmlParamList.length > 6) {
                PurchaseRequisitionMaster.SelectedRequirementByIDs = xmlParamList + "</rows>";
            }
            else {
                PurchaseRequisitionMaster.SelectedRequirementByIDs = "";
            }
            count++;


        });
        /////////////////


    },

    //Method to create xml
    // This Xml used For Insert the data
    GetXmlData: function () {
        var DataArray = [];
        $('#DivAddRowTable4 input').each(function () {
            DataArray.push($(this).val());
        });

        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 23) {
            if (DataArray[i + 17] == 'undefined' && (DataArray[i + 7] == null || DataArray[i + 7] == "")) {
                ParameterXml = ParameterXml + "<row><ID>0</ID><PurchaseRequirementDetailsID>" + DataArray[i + 14] + "</PurchaseRequirementDetailsID><ItemNumber>" + DataArray[i + 4] + "</ItemNumber><Rate>" + DataArray[i + 6] + "</Rate><Quantity>" + DataArray[i + 5] + "</Quantity><DepartmentID>" + DataArray[i + 16] + "</DepartmentID><StorageLocationID>" + DataArray[i + 12] + "</StorageLocationID><IssueFromLocationID></IssueFromLocationID><ExpectedDeliveryDate></ExpectedDeliveryDate><PriorityFlag>" + DataArray[i + 8] + "</PriorityFlag><IsOpenForPO>0</IsOpenForPO><PurchaseGroupCode></PurchaseGroupCode><Tax>" + DataArray[i + 9] + "</Tax><GeneralItemCodeID>" + DataArray[i + 18] + "</GeneralItemCodeID><BarCode>" + DataArray[i + 19] + "</BarCode><OrderUomCode>" + DataArray[i + 22] + "</OrderUomCode><BaseUOMQuantity>" + DataArray[i + 20] + "</BaseUOMQuantity><BaseUOMCode>" + DataArray[i + 21] + "</BaseUOMCode></row>";
            }
            else if (DataArray[i + 17] == 'undefined') {
                ParameterXml = ParameterXml + "<row><ID>0</ID><PurchaseRequirementDetailsID>" + DataArray[i + 14] + "</PurchaseRequirementDetailsID><ItemNumber>" + DataArray[i + 4] + "</ItemNumber><Rate>" + DataArray[i + 6] + "</Rate><Quantity>" + DataArray[i + 5] + "</Quantity><DepartmentID>" + DataArray[i + 16] + "</DepartmentID><StorageLocationID>" + DataArray[i + 12] + "</StorageLocationID><IssueFromLocationID></IssueFromLocationID><ExpectedDeliveryDate>" + DataArray[i + 7].replace(/~/g, ' ') + "</ExpectedDeliveryDate><PriorityFlag>" + DataArray[i + 8] + "</PriorityFlag><IsOpenForPO>0</IsOpenForPO><PurchaseGroupCode></PurchaseGroupCode><Tax>" + DataArray[i + 9] + "</Tax><GeneralItemCodeID>" + DataArray[i + 18] + "</GeneralItemCodeID><BarCode>" + DataArray[i + 19] + "</BarCode><OrderUomCode>" + DataArray[i + 22] + "</OrderUomCode><BaseUOMQuantity>" + DataArray[i + 20] + "</BaseUOMQuantity><BaseUOMCode>" + DataArray[i + 21] + "</BaseUOMCode></row>";
            }
            else if ((DataArray[i + 7] == null || DataArray[i + 7] == "")) {
                ParameterXml = ParameterXml + "<row><ID>0</ID><PurchaseRequirementDetailsID>" + DataArray[i + 14] + "</PurchaseRequirementDetailsID><ItemNumber>" + DataArray[i + 4] + "</ItemNumber><Rate>" + DataArray[i + 6] + "</Rate><Quantity>" + DataArray[i + 5] + "</Quantity><DepartmentID>" + DataArray[i + 16] + "</DepartmentID><StorageLocationID>" + DataArray[i + 12] + "</StorageLocationID><IssueFromLocationID>" + DataArray[i + 17] + "</IssueFromLocationID><ExpectedDeliveryDate></ExpectedDeliveryDate><PriorityFlag>" + DataArray[i + 8] + "</PriorityFlag><IsOpenForPO>0</IsOpenForPO><PurchaseGroupCode></PurchaseGroupCode><Tax>" + DataArray[i + 9] + "</Tax><GeneralItemCodeID>" + DataArray[i + 18] + "</GeneralItemCodeID><BarCode>" + DataArray[i + 19] + "</BarCode><OrderUomCode>" + DataArray[i + 22] + "</OrderUomCode><BaseUOMQuantity>" + DataArray[i + 20] + "</BaseUOMQuantity><BaseUOMCode>" + DataArray[i + 21] + "</BaseUOMCode></row>";
            }
            else {
                ParameterXml = ParameterXml + "<row><ID>0</ID><PurchaseRequirementDetailsID>" + DataArray[i + 14] + "</PurchaseRequirementDetailsID><ItemNumber>" + DataArray[i + 4] + "</ItemNumber><Rate>" + DataArray[i + 6] + "</Rate><Quantity>" + DataArray[i + 5] + "</Quantity><DepartmentID>" + DataArray[i + 16] + "</DepartmentID><StorageLocationID>" + DataArray[i + 12] + "</StorageLocationID><IssueFromLocationID>" + DataArray[i + 17] + "</IssueFromLocationID><ExpectedDeliveryDate>" + DataArray[i + 7].replace(/~/g, ' ') + "</ExpectedDeliveryDate><PriorityFlag>" + DataArray[i + 8] + "</PriorityFlag><IsOpenForPO>0</IsOpenForPO><PurchaseGroupCode></PurchaseGroupCode><Tax>" + DataArray[i + 9] + "</Tax><GeneralItemCodeID>" + DataArray[i + 18] + "</GeneralItemCodeID><BarCode>" + DataArray[i + 19] + "</BarCode><OrderUomCode>" + DataArray[i + 22] + "</OrderUomCode><BaseUOMQuantity>" + DataArray[i + 20] + "</BaseUOMQuantity><BaseUOMCode>" + DataArray[i + 21] + "</BaseUOMCode></row>";
            }

        }
        //alert(ParameterXml)
        if (ParameterXml.length > 24)
            PurchaseRequisitionMaster.XMLstring = ParameterXml + "</rows>";

        else
            PurchaseRequisitionMaster.XMLstring = "";
    },



    GetXmlDataEditRequisation: function () {

        var DataArray = [];
        $('#DivAddRowTableForEdit input').each(function () {
            DataArray.push($(this).val());
        });

        var TotalRecord = DataArray.length;
        // alert(TotalRecord)
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 12) {
            if (DataArray[i + 1] == 0 || DataArray[i + 1] == "") {
                PurchaseRequisitionMaster.flag = false;
            }
            else {
                ParameterXml = ParameterXml + "<row><ID>0</ID><Itemnumber>" + DataArray[i] + "</Itemnumber><Rate>" + DataArray[i + 2] + "</Rate><Quantity>" + DataArray[i + 1] + "</Quantity><Tax>" + DataArray[i + 11] + "</Tax></row>";
            }
        }
        if (ParameterXml.length > 14)
            PurchaseRequisitionMaster.XMLstring = ParameterXml + "</rows>";

        else
            PurchaseRequisitionMaster.XMLstring = "";

    },
    //Method to create xml
    //This Xml is used to Insert Manual Requisition in another Div
    GetXmlDataForManualRequisistion: function () {
        var DataArray = [];
        $('#DivAddRowTable3 input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 8) {

            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemName>" + DataArray[i + 6].replace(/~/g, ' ') + "</ItemName><ItemID>" + DataArray[i + 0] + "</ItemID><Quantity>" + parseFloat(DataArray[i + 1]).toFixed(2) + "</Quantity><Rate>" + DataArray[i + 2] + "</Rate><ExcepectedDelivarydate>" + DataArray[i + 3] + "</ExcepectedDelivarydate><Priority>" + DataArray[i + 4] + "</Priority><LocationID>" + DataArray[i + 5] + "</LocationID><LocationName>" + DataArray[i + 7] + "</LocationName></row>";
        }

        if (ParameterXml.length > 10)
            PurchaseRequisitionMaster.XMLstring = ParameterXml + "</rows>";

        else
            PurchaseRequisitionMaster.XMLstring = "";
    },
    //Fire ajax call to insert update and delete record
    AjaxCallPurchaseRequisitionMaster: function () {
        var PurchaseRequisitionMasterData = null;
        if (PurchaseRequisitionMaster.ActionName == "Create") {
            $("#FormCreatePurchaseRequisitionMaster").validate();
            if ($("#FormCreatePurchaseRequisitionMaster").valid()) {
                PurchaseRequisitionMasterData = null;
                PurchaseRequisitionMasterData = PurchaseRequisitionMaster.GetPurchaseRequisitionMaster();
                ajaxRequest.makeRequest("/PurchaseRequisitionMaster/Create", "POST", PurchaseRequisitionMasterData, PurchaseRequisitionMaster.POSuccess);
            }
        }
        else if (PurchaseRequisitionMaster.ActionName == "Edit") {

            $("#FormEditPurchaseRequisitionMaster").validate();
            if ($("#FormEditPurchaseRequisitionMaster").valid()) {
                PurchaseRequisitionMasterData = null;
                PurchaseRequisitionMasterData = PurchaseRequisitionMaster.GetPurchaseRequisitionMaster();
                ajaxRequest.makeRequest("/PurchaseRequisitionMaster/Edit", "POST", PurchaseRequisitionMasterData, PurchaseRequisitionMaster.Success);
            }
        }
        else if (PurchaseRequisitionMaster.ActionName == "CreatePO") {

            $("#FormEditPurchaseRequisitionMaster").validate();
            if ($("#FormEditPurchaseRequisitionMaster").valid()) {
                PurchaseRequisitionMasterData = null;
                PurchaseRequisitionMasterData = PurchaseRequisitionMaster.GetPurchaseRequisitionMaster();
                ajaxRequest.makeRequest("/PurchaseRequisitionMaster/Edit", "POST", PurchaseRequisitionMasterData, PurchaseRequisitionMaster.POSuccess);
            }
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetPurchaseRequisitionMaster: function () {
        var Data = {
        };
        if (PurchaseRequisitionMaster.ActionName == "Create" || PurchaseRequisitionMaster.ActionName == "Edit" || PurchaseRequisitionMaster.ActionName == "CreatePO") {

            Data.ID = $('#ID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.DepartmentID = $('#DepartmentID').val();
            Data.StorageLocationID = $('#StorageLocationID').val();
            Data.Quantity = $('#Quantity').val();
            Data.Rate = $('#Rate').val();
            Data.PriorityFlag = $('#PriorityFlag').val();
            Data.PurchaseRequisitionType = $('#PurchaseRequisitionType').val();
            Data.PurchaseRequirementNumber = $('#PurchaseRequirementNumber').val();
            Data.TransDate = $('#TransDate').val();
            Data.XMLstring = PurchaseRequisitionMaster.XMLstring;
            Data.Vendor = $('#Vendor').val();
            Data.VendorID = $('#VendorID').val();
            Data.IsOpenForPO = "false"
            Data.Freight = $('#Freight').val();
            Data.ShippingHandling = $('#ShippingHandling').val();
            Data.Discount = $('#discount').val();
            Data.TaxAmount = $('#TotalTaxAmount').val();
            Data.AmmountIncludingTax = $('#Amount').val();
            Data.ReplishmentCode = $('#ReplishmentCode').val();
            Data.CenterCode = $('#CenterCode').val();
            Data.PurchaseRequisitionBy = $("select[id=checkboxlist1]").val();
        }
        if (PurchaseRequisitionMaster.ActionName == "CreatePO") {

            Data.ID = $('#ID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.DepartmentID = $('#DepartmentID').val();
            Data.StorageLocationID = $('#StorageLocationID').val();
            Data.Quantity = $('#Quantity').val();
            Data.Rate = $('#Rate').val();
            Data.PriorityFlag = $('#PriorityFlag').val();
            Data.PurchaseRequisitionType = $('#PurchaseRequisitionType').val();
            Data.PurchaseRequirementNumber = $('#PurchaseRequirementNumber').val();
            Data.TransDate = $('#TransDate').val();
            Data.XMLstring = PurchaseRequisitionMaster.XMLstring;
            Data.Vendor = $('#Vendor').val();
            Data.VendorID = $('#VendorID').val();
            Data.IsOpenForPO = "true"
            Data.Freight = $('#Freight').val();
            Data.ShippingHandling = $('#ShippingHandling').val();
            Data.Discount = $('#discount').val();
            Data.TaxAmount = $('#TotalTaxAmount').val();
            Data.AmmountIncludingTax = $('#Amount').val();
            Data.ReplishmentCode = $('#ReplishmentCode').val();
            Data.CenterCode = $('#CenterCode').val();
            Data.PurchaseRequisitionBy = $("select[id=checkboxlist1]").val();
        }


        else if (PurchaseRequisitionMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        //    alert(splitData)
        // if (splitData[3] == null || splitData[3] == "") {
        $('#CreatePurchaseRequisitionMaster').attr("disabled", false);
        $.magnificPopup.close();
        PurchaseRequisitionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        //  }

        //else
        //{
        //    window.location.href = '/Replenishment';
        //}
    },
    POSuccess: function (data) {
        var splitData = data.split(',');
        if (splitData[3] == null || splitData[3] == "") {
            $('#CreatePurchaseOrderByRequisition').attr("disabled", false);
            $('#CreatePurchaseRequisitionMaster').attr("disabled", false);
            $.magnificPopup.close();
            PurchaseRequisitionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {

            //window.location.href = '/Replenishment?CentreCode=' + $("#SelectedCentreCode :selected").val() + '&GeneralUnitsID=' + $("#GeneralUnitsID").val();
            window.location.href = '/Replenishment?CentreCode=' + $("#CenterCode").val() + '&GeneralUnitsID=' + $("#GeneralUnitsID").val();
        }
    },
};
