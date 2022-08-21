//this class contain methods related to nationality functionality
var BOMAndRecipeDetails = {
    //Member variables
    ActionName: null,
    flag: true,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        BOMAndRecipeDetails.constructor();
        //BOMAndRecipeDetails.initializeValidation();
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



        // Create new record

        $('#CreateBOMAndRecipeDetailsRecord').on("click", function () {
            debugger;
            BOMAndRecipeDetails.ActionName = "Create";
            BOMAndRecipeDetails.flag = true;
            BOMAndRecipeDetails.GetXmlData();
            if (BOMAndRecipeDetails.flag == false) {
                $("#displayErrorMessage").text("Please enter quantity").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            BOMAndRecipeDetails.AjaxCallBOMAndRecipeDetails();
        });

        $('#EditBOMAndRecipeDetailsRecord').on("click", function () {

            BOMAndRecipeDetails.ActionName = "Edit";
            BOMAndRecipeDetails.AjaxCallBOMAndRecipeDetails();
        });

        $('#DeleteBOMAndRecipeDetailsRecord').on("click", function () {

            BOMAndRecipeDetails.ActionName = "Delete";
            BOMAndRecipeDetails.AjaxCallBOMAndRecipeDetails();
        });

        $("#ItemDescription").on("keyup", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#ItemDescription").val("");
                $("#Quantity").val("");
                $("#UoMCode").html("");
                $("#LowerLevelUomCode").val("");
                $('#ItemDescription').typeahead('val', '');
                $("#OrderUomCode").val("");
                $("#PurchasePrice").val("");
                $("#ConsumptionPrice").val("");
            }
        });

        $('#ItemDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#WastageInPercentage').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });
        $('input[id^=WastageInPercentage]').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('input[id^=Quantity]').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#Quantity').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#Quantity').on("keyup", function (e) {
            debugger;
            var quantity = $('#Quantity').val();
            var ConsumptionPrice = $('#ConsumptionPrice').val();
            var ConsumptionPrice1 = $('#ConsumptionPrice1').val();
            //alert(ConsumptionPrice)
            //alert(ConsumptionPrice1)
            var abc = quantity * ConsumptionPrice1;
        
            if (quantity == 1 || quantity == 0) {
                $('#ConsumptionPrice').val(ConsumptionPrice1);
            }
            else {
                $('#ConsumptionPrice').val(parseFloat(abc).toFixed(2));
            }
            
        });

        $('#btnAdd').on("click", function () {
            debugger;
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                if ($(this).val() != "on") {
                    DataArray.push($(this).val());
                }
            });
            TotalRecord = DataArray.length;
            var i = 0;
      
            for (var i = 0; i < TotalRecord; i = i + 7) {
                if (DataArray[i] == $('#ItemNumber').val()) {
                    $("#displayErrorMessage p").text("You Cannot Enter Same Item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                    $("#ItemDescription").val("");
                    $("#Quantity").val(0);
                    $("#UoMCode").val("");
                    $("#WastageInPercentage").val(0);
                    return false;
                }
            }


            if ($("#ItemDescription").val() == null || $("#ItemDescription").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Item Description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#Quantity").val() == 0 || $("#Quantity").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#UoMCode").val() == null || $("#UoMCode").val() == "")
            {
                $("#displayErrorMessage ").text("Please Select UoM Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#WastageInPercentage").val() > 100) {
                $("#displayErrorMessage ").text("Please enter wastage % less than 100.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#LowerLevelUomCode").val() == null || $("#LowerLevelUomCode").val() == "") {
                $("#displayErrorMessage ").text("Please add base uom for this article.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            var IsOptional = $("#IsOptional").is(":checked") ? "true" : "false";
            if (IsOptional == "true") {
                IsOptional = "<td> <input id='IsOptional' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
                $("#IsOptional").removeAttr('checked');
                $("#IsOptional").val("");
            }
            else {
                IsOptional = "<td> <input id='IsOptional' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
                $("#IsOptional").removeAttr('checked');
                $("#IsOptional").val("");
            }

            //var OrderUomCode = $('#OrderUomCode').val()
            //alert(OrderUomCode)

            //var abc2 = $('#IssueFromLocationID :selected').text();
            if ($("#OrderUomCode").val() == "" || $("#OrderUomCode").val() == null) {
                var OrderUomCode = "<td><input id='OrderUomCode' type='text' value='' style='display:none' />" + " -" + "</td>"
            }
            else {
                var OrderUomCode = "<td><input id='OrderUomCode' type='text' value='" + $('#OrderUomCode').val() + "' style='display:none' />" + $('#OrderUomCode').val() + "</td>"
            }
            //var abc = $('#ItemNumber').val();
           
            if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null && $('#UoMCode').val() != "" && $('#UoMCode').val() != null) {
                //Code For IsBase Uom Check box Ends
               
                $("#tblData tbody").append(
                                     "<tr>" +
                                     "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                                     "<td style=display:none><input id='InventoryRecipeFormulaDetailsID' type='hidden' value=0 style='display:none' />" + $('#InventoryRecipeFormulaDetailsID').val() + "</td>" +
                                     "<td><input id='Quantity' type='text' value=" + $('#ItemDescription').val() + " style='display:none' />" + $('#ItemDescription').val() + "</td>" +
                                    "<td><input id='Quantity' type='text' value=" + $('#Quantity').val() + " style='display:none' />" + $('#Quantity').val() + "</td>" +
                                     "<td><input id='WastageInPercentage' type='text' value=" + $('#WastageInPercentage').val() + " style='display:none' />" + $('#WastageInPercentage').val() + "</td>" +
                                    IsOptional +
                                     "<td ><input type='text' value=" + $('#UoMCode').val() + " style='display:none' /> " + $('#UoMCode').val() + "</td>" +
                                     "<td><input id='ConsumptionPrice'  value=" + parseFloat($('#ConsumptionPrice').val()).toFixed(4) + " style='display:none' />" + parseFloat($('#ConsumptionPrice').val()).toFixed(4) + "</td>" +
                                     OrderUomCode+
                                   //  "<td><input id='OrderUomCode'  value=" + $('#OrderUomCode').val() + " style='display:none' />" + $('#OrderUomCode').val() + "</td>" +
                                     "<td><input id='PurchasePrice'  value=" + $('#PurchasePrice').val() + " style='display:none' />" + $('#PurchasePrice').val() + "</td>" +
                                     "<td style=display:none><input id='BaseUomPrice' type='hidden'  value=" + $('#BaseUomPrice').val() + "  style='display:none' />" + $('#BaseUomPrice').val() + "</td>" +
                                     "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                     "</tr>"
                                    );

                $("#ItemDescription").val("");
                $("#Quantity").val("0");
                $("#UoMCode").val("");
                $("#WastageInPercentage").val("0");
                $("#ConsumptionPrice").val("0");
                $("#OrderUomCode").val("");
                $("#PurchasePrice").val("0");

            }
            
            //Delete record in table
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

        });

       // $("#STOUnits").change(function () {
        $('#UoMCode').on("change", function () {

            var selectedItem = $(this).val();
            var UomPurchasePrice;
            var ItemNumber = $("#ItemNumber").val();
            debugger;
            if (selectedItem !== "") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: { "ItemNumber": ItemNumber, "UoMCode": selectedItem },
                    url: '/BOMAndRecipeDetails/GetUoMCodeWisePurchasePrice',
                    success: function (data) {
                        if (data.length > 0)
                            {
                        $("#ConsumptionPrice").val((data[0].UomPurchasePrice) * $("#Quantity").val());
                        $("#ConsumptionPrice1").val((data[0].UomPurchasePrice));
                        }
                    }
                });
            }
            else
            {
                $("#ConsumptionPrice").val(0);
            }
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
        
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/BOMAndRecipeDetails/List',
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
            url: '/BOMAndRecipeDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    GetXmlData: function () {

        var DataArray = [];
        //BOMAndRecipeDetails.flag = true;
        $('#tblData tbody tr td input').each(function () {
            if ($(this).val() != "on") {
                if ($(this).attr('type') == 'checkbox') {
                    DataArray.push($(this).is(":checked") ? 1 : 0);
                }
                else {
                    DataArray.push($(this).val());
                }
            }
        });
        var TotalRecord = DataArray.length;
        //alert(DataArray);
        //alert(TotalRecord);
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 11) {
            if (DataArray[i + 3] == 0 || DataArray[i + 3] == "")
            {
                BOMAndRecipeDetails.flag = false;
            }
      else{
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><InventoryRecipeFormulaDetailsID>" + DataArray[i + 1] + "</InventoryRecipeFormulaDetailsID><ItemNumber>" + DataArray[i] + "</ItemNumber><Quantity>" + parseFloat(DataArray[i + 3]).toFixed(2) + "</Quantity><IsOptional>" + (DataArray[i + 5]) + "</IsOptional><UOMCode>" + (DataArray[i + 6]) + "</UOMCode><WastageInPercentage>" + (DataArray[i + 4]) + "</WastageInPercentage></row>";
    }    
    }
        //alert(ParameterXml);
        if (ParameterXml.length > 10)
            BOMAndRecipeDetails.ParameterXml = ParameterXml + "</rows>";

        else
            BOMAndRecipeDetails.ParameterXml = "";
        //alert(BOMAndRecipeDetails.ParameterXml)
    },

    //Fire ajax call to insert update and delete record

    AjaxCallBOMAndRecipeDetails: function () {
        var BOMAndRecipeDetailsData = null;

        if (BOMAndRecipeDetails.ActionName == "Create") {
       
            $("#FormCreateBOMAndRecipeDetails").validate();
            if ($("#FormCreateBOMAndRecipeDetails").valid()) {
                BOMAndRecipeDetailsData = null;
                BOMAndRecipeDetailsData = BOMAndRecipeDetails.GetBOMAndRecipeDetails();
                ajaxRequest.makeRequest("/BOMAndRecipeDetails/Create", "POST", BOMAndRecipeDetailsData, BOMAndRecipeDetails.Success, "CreateBOMAndRecipeDetailsRecord");
            }
        }
        else if (BOMAndRecipeDetails.ActionName == "Edit") {
            $("#FormEditBOMAndRecipeDetails").validate();
            if ($("#FormEditBOMAndRecipeDetails").valid()) {
                BOMAndRecipeDetailsData = null;
                BOMAndRecipeDetailsData = BOMAndRecipeDetails.GetBOMAndRecipeDetails();
                ajaxRequest.makeRequest("/BOMAndRecipeDetails/Edit", "POST", BOMAndRecipeDetailsData, BOMAndRecipeDetails.Success);
            }
        }
        else if (BOMAndRecipeDetails.ActionName == "Delete") {
            debugger;
            BOMAndRecipeDetailsData = null;
            $("#FormCreateBOMAndRecipeDetails").validate();
            BOMAndRecipeDetailsData = BOMAndRecipeDetails.GetBOMAndRecipeDetails();
            ajaxRequest.makeRequest("/BOMAndRecipeDetails/Delete", "POST", BOMAndRecipeDetailsData, BOMAndRecipeDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetBOMAndRecipeDetails: function () {
        var Data = {
        };

        if (BOMAndRecipeDetails.ActionName == "Create" || BOMAndRecipeDetails.ActionName == "Edit") {
    
            Data.ID = $('#ID').val();
            Data.InventoryVariationMasterID = $('#InventoryVariationMasterID').val();
            Data.InventoryRecipeMasterID = $('#InventoryRecipeMasterID').val();
            Data.XMLstring = BOMAndRecipeDetails.ParameterXml;
            Data.ItemNumber = $('#ItemNumber').val();
            Data.GeneralItemMasterID = $('#GeneralItemMasterID').val();
        }
        else if (BOMAndRecipeDetails.ActionName == "Delete") {
           
            Data.InventoryRecipeFormulaDetailsID = $('#InventoryRecipeFormulaDetailsID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
          
           
            BOMAndRecipeDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

//this is used to for showing successfully record updation message and reload the list view
// editSuccess: function (data) {



// if (data == "True") {

//        parent.$.colorbox.close();
//    var actionMode = "1";
//       BOMAndRecipeDetails.ReloadList("Record Updated Sucessfully.", actionMode);
//        //  alert("Record Created Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    }

//},
////this is used to for showing successfully record deletion message and reload the list view
//deleteSuccess: function (data) {


//    if (data == "True") {

//        parent.$.colorbox.close();
//        BOMAndRecipeDetails.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


