//this class contain methods related to nationality functionality
var InventoryPhysicalStockMasterAndTransaction = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryPhysicalStockMasterAndTransaction.constructor();
     
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
          
        $('#btnShowList').click(function () {
            var InventoryLocationMasterID = $('#InventoryLocationMasterID').val();
          
            if (InventoryLocationMasterID != "") {
                InventoryPhysicalStockMasterAndTransaction.LoadList();
                $("#divAddbtn").show();
            }
            else if (InventoryLocationMasterID == "") {
                notify("Please select Location", 'warning');
                $('#divAddbtn').hide(true);
            }
        });

        $("#ShrinkQuantity").on("keyup", function ()
            
        {
            var CurrentQuality = $("#CurrentQty").val();
            var shrinkQuality = $("#ShrinkQuantity").val();
            var DumpQty = $("#DumpQuantity").val();
     
            if (parseFloat(shrinkQuality) > parseFloat(CurrentQuality)) {
                $("#ShrinkQuantity").val(0);
                $("#PhysicalQty").val(0);
                $("#DumpQuantity").val(0);

            }
            if ((parseFloat($("#ShrinkQuantity").val()) + parseFloat($("#DumpQuantity").val())) > parseFloat(CurrentQuality)) {
                $("#ShrinkQuantity").val(0);
                notify("Total Quantity Should Not Be Greater Than Current Quantity", 'warning');

            }
            var abc = parseFloat(parseFloat($("#ShrinkQuantity").val()) + parseFloat($("#DumpQuantity").val())).toFixed(2);
            var abc1 = parseFloat(parseFloat(CurrentQuality) - parseFloat(abc)).toFixed(2);
            $("#PhysicalQty").val(abc1);
        });

        $('#ShrinkQuantity').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#DumpQuantity').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

      

        $("#DumpQuantity").on("keyup", function () {
            var CurrentQuality = $("#CurrentQty").val();
            var shrinkQuality = $("#ShrinkQuantity").val();
            var DumpQty = $("#DumpQuantity").val();
            if (parseFloat(DumpQty) > parseFloat(CurrentQuality)) {
                $("#DumpQuantity").val(0);
            }
            if ((parseFloat($("#ShrinkQuantity").val()) + parseFloat($("#DumpQuantity").val())) > parseFloat(CurrentQuality)) {
                $("#DumpQuantity").val(0);
                notify("Total Quantity Should Not Be Greater Than Current Quantity", 'warning');

            }
            var abc = parseFloat(parseFloat(shrinkQuality) + parseFloat($("#DumpQuantity").val())).toFixed(2);
            var abc1 = parseFloat(parseFloat(CurrentQuality) - parseFloat(abc)).toFixed(2);
            $("#PhysicalQty").val(abc1);
        });

        $('#btnAdd').on("click", function () {

            //code for repeat entry
            var Cq = parseFloat($("#CurrentQty").val());

            var shrinkQuality = $("#ShrinkQuantity").val();
            var currentQty = $("#DumpQuantity").val();
            var Ac = $("#PhysicalQty").val();
            var Rate = $("#Rate").val();
            var Unit = $("#Unit").val();
            var Remark = $("#Remark").val();
            var ItemDescription = $("#ItemDescription").val();


            var total = parseFloat(parseFloat(shrinkQuality) + parseFloat(currentQty) + parseFloat(Ac)).toFixed(2);


            //code to restrict repeated entries in datatable

            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 5) {
                if (DataArray[i] == $('#GeneralItemMasterID').val()) {
                    $("#displayErrorMessage p").text("You Cannot Enter Same Item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#ItemDescription").val("");
                    $("#Rate").val("");
                    $("#Unit").val("");
                    $("#DumpQuantity").val(0);
                    $("#ShrinkQuantity").val(0);
                    $("#CurrentQuantity").val(0);
                    $("#PhysicalQty").val(0);
                    $("#CurrentQty").val(0);
                    $("#Remark").val("");



                    return false
                }
            }


            if ($("#ShrinkQuantity").val() == 0 || $("#ShrinkQuantity").val() == "") {
                $("#displayErrorMessage p").text("Please Enter Shrink Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            }
            else if ($("#DumpQuantity").val() == 0 || $("#ShrinkQuantity").val() == "") {
                $("#displayErrorMessage p").text("Please Enter Dump Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            }
         

            if ($('#ItemDescription').val() != "" && $('#Rate').val() != "" && $('#ShrinkQuantity').val() != "" && $('#ShrinkQuantity').val() > 0 && $('#Unit').val() != "" && $('#DumpQuantity').val() != "" && $('#DumpQuantity').val() > 0 && $('#CurrentQty').val() != "" && $('#CurrentQty').val() > 0 && $('#PhysicalQty').val() != "" && $('#PhysicalQty').val() > 0) {
                $("#tblData tbody").append(
                          "<tr>" +
                          "<td ><input type='text' value=" + $('#GeneralItemMasterID').val() + " style='display:none' /> " + $('#ItemDescription').val() + "</td>" +
                           
                          "<td><input type='text' value=" + $('#Rate').val() + " style='display:none' /> " + $('#Rate').val() + "</td>" +
                          "<td><input type='text' value=" + $('#Unit').val() + " style='display:none' /> " + $('#Unit').val() + "</td>" +
                          //"<td>" + $('#Unit').val() + "</td>" +
                          "<td><input type='text' value=" + $('#ShrinkQuantity').val() + " style='display:none' /> " + $('#ShrinkQuantity').val() + "</td>" +
                           "<td><input type='text' value=" + $('#DumpQuantity').val() + " style='display:none' /> " + $('#DumpQuantity').val() + "</td>" +
                    //"<td><input  type='text' value=" + parseFloat($('#ShrinkQuantity').val() > 0 ? $('#ShrinkQuantity').val() : 0).toFixed(2) + "  disabled='disabled'/></td>" +
                        //"<td><input  type='text' value=" + parseFloat($('#Rate').val()).toFixed(2) * parseFloat(parseFloat($('#DumpQuantity').val() > 0 ? $('#DumpQuantity').val() : 0) + parseFloat($('#ShrinkQuantity').val() > 0 ? $('#ShrinkQuantity').val() : 0)).toFixed(2) + "'/></td>" +
                         //"<td>" + parseFloat($('#Rate').val()).toFixed(2) * parseFloat(parseFloat($('#Rate').val() > 0 ? $('#DumpQuantity').val() : 0) + parseFloat($('#ShrinkQuantity').val() > 0 ? $('#ShrinkQuantity').val() : 0)).toFixed(2) + "</td>" +
                         "<td>" + parseFloat(parseFloat($('#Rate').val()).toFixed(2) * parseFloat(parseFloat($('#DumpQuantity').val() > 0 ? $('#DumpQuantity').val() : 0) + parseFloat($('#ShrinkQuantity').val() > 0 ? $('#ShrinkQuantity').val() : 0)).toFixed(2)).toFixed(2) + "</td>" +
                         "<td><input type='text' value=" + $('#Remark').val().replace(/ /g, "~") + " style='display:none' /> " + $('#Remark').val() + "</td>" +
                        "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete><input type='hidden' id='ItemBarCodeId' value=" + $('#ItemBarCodeId').val() + "  /><input type='hidden' id='ItemNumber' value=" + $('#ItemNumber').val() + "  /></td>" +
                          "</tr>");


                $("#ItemDescription").val("");
                $("#Rate").val("");
                $("#ShrinkQuantity").val("");
                $("#DumpQuantity").val("");
                $("#Remark").val("");
                $("#Unit").val("");
                $("#CurrentQty").val("");
                $("#PhysicalQty").val("");

                InventoryPhysicalStockMasterAndTransaction.TotalItem();
                InventoryPhysicalStockMasterAndTransaction.TotalBillAmount();

               
            }
 
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
                InventoryPhysicalStockMasterAndTransaction.TotalItem();
                InventoryPhysicalStockMasterAndTransaction.TotalBillAmount();

            });

        });

        // Create new record

        $('#CreateInventoryPhysicalStockMasterAndTransactionRecord').on("click", function () {

            InventoryPhysicalStockMasterAndTransaction.ActionName = "Create";
           
            InventoryPhysicalStockMasterAndTransaction.GetXmlData();
            debugger;
            InventoryPhysicalStockMasterAndTransaction.AjaxCallInventoryPhysicalStockMasterAndTransaction();
        });

        $('#EditInventoryPhysicalStockMasterAndTransactionRecord').on("click", function () {

            InventoryPhysicalStockMasterAndTransaction.ActionName = "Edit";
            InventoryPhysicalStockMasterAndTransaction.AjaxCallInventoryPhysicalStockMasterAndTransaction();
        });

        $('#DeleteInventoryPhysicalStockMasterAndTransactionRecord').on("click", function () {

            InventoryPhysicalStockMasterAndTransaction.ActionName = "Delete";
            InventoryPhysicalStockMasterAndTransaction.AjaxCallInventoryPhysicalStockMasterAndTransaction();
        });

       
        $("#ItemDescription").on("keyup", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#ItemDescription").val("");
                $("#Rate").val(0);
                $("#Unit").val("");
                $("#DumpQuantity").val(0);
                $("#ShrinkQuantity").val(0);
                $("#CurrentQty").val(0);
                $("#PhysicalQty").val(0);
                $("#Remark").val("");
               
            }
        });
   
       
        InitAnimatedBorder();

        CloseAlert();

        

       

    },
    TotalBillAmount: function () {
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(5).text()).toFixed(2);
                a += parseFloat(x);
            }
        });
        $("#TotalAmount").val(a.toFixed(2));

    },

    TotalItem: function () {
        var length = $("#tblData tbody tr").length;
        $("#Count").val(length);
    },

    //LoadList method is used to load List page
    LoadList: function () {
       
        var Balancesheet = $("#selectedBalsheetID").val();
        var InventoryLocationMasterID = $("#InventoryLocationMasterID").val();
        $.ajax(
       {
           cache: false,
           type: "GET",
           data: { "selectedBalsheet": Balancesheet, "InventoryLocationMasterID": InventoryLocationMasterID },
           dataType: "html",
           url: '/InventoryPhysicalStockMasterAndTransaction/List',
           success: function (data) {
               //Rebind Grid Data
               $('#ListViewModel').html(data);
               if ($('#InventoryLocationMasterID :selected').val() == "") {

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
        debugger;
          var Balancesheet = $("#selectedBalsheetID").val();
        var InventoryLocationMasterID = $("#InventoryLocationMasterID").val();
        $.ajax(
        {

            cache: false,
            type: "GET",
            dataType: "html",
            data: { "selectedBalsheet": Balancesheet, "InventoryLocationMasterID": InventoryLocationMasterID, "actionMode": actionMode },
            url: '/InventoryPhysicalStockMasterAndTransaction/List',
            
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                if ($('#InventoryLocationMasterID :selected').val() == "") {

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
        //InventoryPhysicalStockMasterAndTransaction.flag = true;
        $('#DivAddRowTable input').each(function () {
            DataArray.push($(this).val());
        });
        var abc = 0;
        var abc1 = 0;
        var TotalRecord = DataArray.length;
       // alert(DataArray);
      //  alert(TotalRecord);
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 8) {
            if (DataArray[i + 2] != 0) {

                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemNumber>" + DataArray[i + 7] + "</ItemNumber><ItemBarCodeId>" + (DataArray[i + 6]) + "</ItemBarCodeId><DumpQuantity>" + parseFloat(DataArray[i + 4]).toFixed(2) + "</DumpQuantity><ShrinkQuantity>" + parseFloat(DataArray[i + 3]).toFixed(2) + "</ShrinkQuantity><Rate>" + (DataArray[i + 1]) + "</Rate><Remark>" + (DataArray[i + 5]).replace(/~/g,' ') + "</Remark></row>";
                //abc = parseFloat(parseFloat(abc) + parseFloat(DataArray[i + 6]));
                //abc1 = parseFloat(parseFloat(abc1) + parseFloat(DataArray[i + 7]));
            }
            else {
                $("#displayErrorMessage p").text("Please Enter Valid Data.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                break;
            }

          }
         // alert(ParameterXml);
        if (ParameterXml.length > 10)
            InventoryPhysicalStockMasterAndTransaction.ParameterXml = ParameterXml + "</rows>";
           
        else
            InventoryPhysicalStockMasterAndTransaction.ParameterXml = "";

       
    },

    //Fire ajax call to insert update and delete record

    AjaxCallInventoryPhysicalStockMasterAndTransaction: function () {
        var InventoryPhysicalStockMasterAndTransactionData = null;

        if (InventoryPhysicalStockMasterAndTransaction.ActionName == "Create") {
            
            $("#FormCreateInventoryPhysicalStockMasterAndTransaction").validate();
            if ($("#FormCreateInventoryPhysicalStockMasterAndTransaction").valid()) {
                
                InventoryPhysicalStockMasterAndTransactionData = null;
                InventoryPhysicalStockMasterAndTransactionData = InventoryPhysicalStockMasterAndTransaction.GetInventoryPhysicalStockMasterAndTransaction();
                ajaxRequest.makeRequest("/InventoryPhysicalStockMasterAndTransaction/Create", "POST", InventoryPhysicalStockMasterAndTransactionData, InventoryPhysicalStockMasterAndTransaction.Success, "CreateInventoryPhysicalStockMasterAndTransactionRecord");
            }
        }
        else if (InventoryPhysicalStockMasterAndTransaction.ActionName == "Edit") {
            $("#FormEditInventoryPhysicalStockMasterAndTransaction").validate();
            if ($("#FormEditInventoryPhysicalStockMasterAndTransaction").valid()) {
                InventoryPhysicalStockMasterAndTransactionData = null;
                InventoryPhysicalStockMasterAndTransactionData = InventoryPhysicalStockMasterAndTransaction.GetInventoryPhysicalStockMasterAndTransaction();
                ajaxRequest.makeRequest("/InventoryPhysicalStockMasterAndTransaction/Edit", "POST", InventoryPhysicalStockMasterAndTransactionData, InventoryPhysicalStockMasterAndTransaction.Success);
            }
        }
        else if (InventoryPhysicalStockMasterAndTransaction.ActionName == "Delete") {

            InventoryPhysicalStockMasterAndTransactionData = null;
            //$("#FormCreateInventoryPhysicalStockMasterAndTransaction").validate();
            InventoryPhysicalStockMasterAndTransactionData = InventoryPhysicalStockMasterAndTransaction.GetInventoryPhysicalStockMasterAndTransaction();
            ajaxRequest.makeRequest("/InventoryPhysicalStockMasterAndTransaction/Delete", "POST", InventoryPhysicalStockMasterAndTransactionData, InventoryPhysicalStockMasterAndTransaction.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryPhysicalStockMasterAndTransaction: function () {
        var Data = {
        };

        if (InventoryPhysicalStockMasterAndTransaction.ActionName == "Create" || InventoryPhysicalStockMasterAndTransaction.ActionName == "Edit") {
            
            Data.ID = $('#ID').val();
            Data.Balancesheet = $("#selectedBalsheetID").val();
            Data.InventoryLocationMasterID = $("#InventoryLocationMasterID").val();
            Data.TransactionDate = $("#TransactionDate").val();
            Data.VariationAmount = $("#TotalAmount").val();
            Data.ItemBarCodeId = $('#ItemBarCodeId').val();
            Data.ItemNumber = $('#ItemNumber').val();
            Data.GeneralItemMasterID = $('#GeneralItemMasterID').val();
            Data.ItemDescription = $('#ItemDescription').val();
            Data.UomCode = $('#Unit').val();
            Data.Rate = $('#Rate').val();
            Data.ParameterXml = InventoryPhysicalStockMasterAndTransaction.ParameterXml;
            Data.TotalAmount = $('#TotalAmount').val();
        }
        else if (InventoryPhysicalStockMasterAndTransaction.ActionName == "Delete") {

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
            InventoryPhysicalStockMasterAndTransaction.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

