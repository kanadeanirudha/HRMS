//this class contain methods related to nationality functionality
var InventoryProductionMasterAndTransaction = {
    //Member variables
    ActionName: null,
    CheckInfo: false,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryProductionMasterAndTransaction.constructor();
        //InventoryProductionMasterAndTransaction.initializeValidation();
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

        $('#TransactionDate').datetimepicker({
            format: 'DD MMMM YYYY'
        });


        $('#SelectedCentreCode').on("change", function () {
            $('#DivCreateNew').hide(true);
            $('#myDataTable').html("");
            // $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');


            if ($("#SelectedCentreCode").val() == "") {
                $("#divAddbtn").hide();
            }
            else {
              
                var centerCode = $('#SelectedCentreCode').val();
                var href = $("#divAddbtn").attr('href');
                href = '/InventoryProductionMasterAndTransaction/Create?centerCode=' + centerCode
                $("#centerCodeUrl").attr('href', href);
                $("#divAddbtn").show();

            }

        });

        $("#btnShowList").unbind("click").on("click", function () {
            debugger;
            var date = $('#TransactionDate').val();
            var centerCode = $('#SelectedCentreCode :selected').val();
            var StatusFlag = 0
            if (date != "" && centerCode != "") {
                InventoryProductionMasterAndTransaction.LoadList(date, StatusFlag, centerCode);
                $("#divAddbtn").show();
            }
            else if (date == "") {
                notify("Please select transaction date.", 'warning');
                $('#DivCreateNew').hide(true);
                $('#divAddbtn').hide(true);
            }
            else if (centerCode == "") {
                notify("Please select Centre", 'warning');
                $('#divAddbtn').hide(true);
            }
           
        });
        
        //$("#TransactionDate").on("keyup", function (e) {
        //    var date = $("#TransactionDate").val();
        //    if (date == "" || date == null)
        //    {
        //        $('#DivCreateNew').hide(true);
        //        $('#myDataTable').html("");
        //    }

        //});
        // Create new record

        $('#CreateInventoryProductionMasterAndTransactionRecord').on("click", function () {
            InventoryProductionMasterAndTransaction.ActionName = "Create";
            if ($('#tblData tr:not(:first)').length == 0) {

                $("#displayErrorMessage p").text("Please add row.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            InventoryProductionMasterAndTransaction.GetXmlData();
            InventoryProductionMasterAndTransaction.AjaxCallInventoryProductionMasterAndTransaction();
        });

        $('#EditInventoryProductionMasterAndTransactionRecord').on("click", function () {

            InventoryProductionMasterAndTransaction.ActionName = "Edit";
            InventoryProductionMasterAndTransaction.AjaxCallInventoryProductionMasterAndTransaction();
        });

        $('#DeleteInventoryProductionMasterAndTransactionRecord').on("click", function () {

            InventoryProductionMasterAndTransaction.ActionName = "Delete";
            InventoryProductionMasterAndTransaction.AjaxCallInventoryProductionMasterAndTransaction();
        });

        $("#ItemDescription").on("keyup", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#ItemDescription").val("");
                $("#Quantity").val("");
                $("#UoMCode").html("");
                $('#ItemDescription').typeahead('val', '');
            }
        });

        $('#ItemDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


        $('#Quantity').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#btnAdd').on("click", function () {

            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;

            for (var i = 0; i < TotalRecord; i = i + 6) {
                if (DataArray[i] == $('#ItemNumber').val() && DataArray[i + 4] == $('#GeneralUnitsID').val()) {
                    $("#displayErrorMessage p").text("You Cannot Enter Same Item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                    $("#ItemDescription").val("");
                    $("#Quantity").val("");
                    $("#UoMCode").val("");
                    return false
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
            else if ($("#UoMCode").val() == null || $("#UoMCode").val() == "") {
                $("#displayErrorMessage ").text("Please Select UoM Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#BaseUomCode").val() == null || $("#BaseUomCode").val() == "") {
                $("#displayErrorMessage ").text("Please add base uom for this article.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
           
            //var abc = $('#ItemNumber').val();

            if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null && $('#UoMCode').val() != "" && $('#UoMCode').val() != null) {
                //Code For IsBase Uom Check box Ends

                $("#tblData tbody").append(
                                     "<tr>" +
                                     "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                                     "<td><input id='Quantity' type='text' value=" + $('#ItemDescription').val() + " style='display:none' />" + $('#ItemDescription').val() + "</td>" +
                                    "<td><input id='Quantity' type='text' value=" + $('#Quantity').val() + " style='display:none' />" + $('#Quantity').val() + "</td>" +
                                     "<td ><input type='text' value=" + $('#UoMCode').val() + " style='display:none' /> " + $('#UoMCode').val() + "</td>" +
                                      "<td style=display:none><input id='GeneralUnitsID' type='hidden' value=" + $('#GeneralUnitsID').val() + " style='display:none' />" + $('#GeneralUnitsID').val() + "</td>" +
                                         "<td style=display:none><input id='SalePrice' type='hidden' value=" + $('#SalePrice').val() + " style='display:none' />" + $('#SalePrice').val() + "</td>" +
                                   "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                     "</tr>"
                                    );

                $("#ItemDescription").val("");
                $("#Quantity").val("0");
                $("#UoMCode").val("");
            }

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

        });

        InitAnimatedBorder();

        CloseAlert();

      


    },
    //LoadList method is used to load List page
    LoadList: function (TransactionDate, StatusFlag, centerCode) {
        debugger
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { TransactionDate: TransactionDate, StatusFlag: 0, centerCode: centerCode},
             dataType: "html",
             url: '/InventoryProductionMasterAndTransaction/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
                 if ($('#SelectedCentreCode :selected').val() == "") {

                     $("#divAddbtn").hide();
                 }
                 else {
                     $("#divAddbtn").show();
                 }
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var CheckInfo;
        debugger;
        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { TransactionDate: $("#TransactionDate").val(), actionMode: actionMode, CheckInfo: InventoryProductionMasterAndTransaction.CheckInfo, centerCode: $("#SelectedCentreCode :selected").val() },
            url: '/InventoryProductionMasterAndTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                if ($('#SelectedCentreCode :selected').val() == "") {

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

    GetXmlData: function () {

        var DataArray = [];
        //InventoryProductionMasterAndTransaction.flag = true;
        $('#tblData input').each(function () {
           // if ($(this).val() != "on") {
                DataArray.push($(this).val());
           // }
        });
      //  alert(DataArray);
        var TotalRecord = DataArray.length;

        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 6) {
            InventoryProductionMasterAndTransaction.CheckInfo = true;
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemNumber>" + DataArray[i] + "</ItemNumber><Quantity>" + parseFloat(DataArray[i + 2]).toFixed(2) + "</Quantity><UOMCode>" + (DataArray[i + 3]) + "</UOMCode><GeneralUnitsID>" + (DataArray[i + 4]) + "</GeneralUnitsID><SalePrice>" + (DataArray[i + 5]) + "</SalePrice></row>";
        }
        //alert(ParameterXml);
        if (ParameterXml.length > 10)
            InventoryProductionMasterAndTransaction.ParameterXml = ParameterXml + "</rows>";

        else
            InventoryProductionMasterAndTransaction.ParameterXml = "";
       // alert(InventoryProductionMasterAndTransaction.ParameterXml)
    },

    //Fire ajax call to insert update and delete record

    AjaxCallInventoryProductionMasterAndTransaction: function () {
        var InventoryProductionMasterAndTransactionData = null;

        if (InventoryProductionMasterAndTransaction.ActionName == "Create") {

            $("#FormCreateInventoryProductionMasterAndTransaction").validate();
            if ($("#FormCreateInventoryProductionMasterAndTransaction").valid()) {
                InventoryProductionMasterAndTransactionData = null;
                InventoryProductionMasterAndTransactionData = InventoryProductionMasterAndTransaction.GetInventoryProductionMasterAndTransaction();
                ajaxRequest.makeRequest("/InventoryProductionMasterAndTransaction/Create", "POST", InventoryProductionMasterAndTransactionData, InventoryProductionMasterAndTransaction.Success, "CreateInventoryProductionMasterAndTransactionRecord");
            }
        }
        else if (InventoryProductionMasterAndTransaction.ActionName == "Edit") {
            $("#FormEditInventoryProductionMasterAndTransaction").validate();
            if ($("#FormEditInventoryProductionMasterAndTransaction").valid()) {
                InventoryProductionMasterAndTransactionData = null;
                InventoryProductionMasterAndTransactionData = InventoryProductionMasterAndTransaction.GetInventoryProductionMasterAndTransaction();
                ajaxRequest.makeRequest("/InventoryProductionMasterAndTransaction/Edit", "POST", InventoryProductionMasterAndTransactionData, InventoryProductionMasterAndTransaction.Success);
            }
        }
        else if (InventoryProductionMasterAndTransaction.ActionName == "Delete") {
            debugger;
            InventoryProductionMasterAndTransactionData = null;
            $("#FormCreateInventoryProductionMasterAndTransaction").validate();
            InventoryProductionMasterAndTransactionData = InventoryProductionMasterAndTransaction.GetInventoryProductionMasterAndTransaction();
            ajaxRequest.makeRequest("/InventoryProductionMasterAndTransaction/Delete", "POST", InventoryProductionMasterAndTransactionData, InventoryProductionMasterAndTransaction.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryProductionMasterAndTransaction: function () {
        var Data = {
        };

        if (InventoryProductionMasterAndTransaction.ActionName == "Create" || InventoryProductionMasterAndTransaction.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.InventoryVariationMasterID = $('#InventoryVariationMasterID').val();
            Data.InventoryRecipeMasterID = $('#InventoryRecipeMasterID').val();
            Data.XMLstring = InventoryProductionMasterAndTransaction.ParameterXml;
            Data.ItemNumber = $('#ItemNumber').val();
            Data.GeneralItemMasterID = $('#GeneralItemMasterID').val();
            Data.GeneralUnitsID = $('#GeneralUnitsID').val();
            Data.TransactionDate = $('#TransactionDate').val();
            Data.CentreCode = $('#SelectedCentreCode :selected').val();
        }
        else if (InventoryProductionMasterAndTransaction.ActionName == "Delete") {

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


            InventoryProductionMasterAndTransaction.ReloadList(splitData[0], splitData[1], splitData[2]);
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
//       InventoryProductionMasterAndTransaction.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        InventoryProductionMasterAndTransaction.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


