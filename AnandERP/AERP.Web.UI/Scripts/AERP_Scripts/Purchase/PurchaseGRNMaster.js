//this class contain methods related to nationality functionality
var PurchaseGRNMaster = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    XMLstringForVouchar:null,
    Islocked: 0,
    ItemID: 0,
    DataAppend: null,
    DataApproved: null,
    testBatch: true,
    testExpiry: true,
     map : {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        PurchaseGRNMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

      

        // Create new record
        $('#CreatePurchaseGRNMasterRecord').on("click", function () {
            debugger;
            PurchaseGRNMaster.ActionName = "Create";
            PurchaseGRNMaster.testBatch = true;
            PurchaseGRNMaster.testExpiry = true;
            PurchaseGRNMaster.GetXmlData();
            
            if (PurchaseGRNMaster.testBatch == false && $('#PurchaseOrderType').val()!=3)
            {
                $("#displayErrorMessage").text("Please enter batch.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            if (PurchaseGRNMaster.testExpiry == false)
            {
                $("#displayErrorMessage").text("Please enter expiry date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
         
            if (PurchaseGRNMaster.XMLstring == "" || PurchaseGRNMaster.XMLstring == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                $('#CreatePurchaseGRNMasterRecord').attr("disabled", true);
                //PurchaseGRNMaster.GetXmlDataForAccountVoucher();
                if ((PurchaseGRNMaster.DataAppend != "" || PurchaseGRNMaster.DataAppend != null) && PurchaseGRNMaster.DataApproved == 1) {
                    // return false;
                    $(".sweet-overlay").css('z-index',1043)
                    swal({
                        
                        title: 'Confirm GRN Details',
                        text: "Expiry date of this item "+PurchaseGRNMaster.DataAppend + " exceeds remaining shelf life.",
                        //type: points[parseInt(settings.bulktype)]['type'],
                        showCancelButton: true,
                        confirmButtonClass: 'btn-success',
                        confirmButtonText: "OK!"

                    }, function (isConfirm) {
                        if (isConfirm) {
                            PurchaseGRNMaster.AjaxCallPurchaseGRNMaster();
                            PurchaseGRNMaster.DataAppend = " ";

                        }
                        else
                        {
                            $('#CreatePurchaseGRNMasterRecord').attr("disabled", false);
                        }
                    });
                }
                else{
                    PurchaseGRNMaster.AjaxCallPurchaseGRNMaster();
                }
            }
        
            //PurchaseGRNMaster.AjaxCallPurchaseGRNMaster();
         
            
           
        });


        $('#EditPurchaseGRNMasterRecord').on("click", function () {
            PurchaseGRNMaster.ActionName = "Edit";
            PurchaseGRNMaster.CountValueUsingParentTag();
            PurchaseGRNMaster.getValueUsingParentTag_Check_UnCheck();
            PurchaseGRNMaster.AjaxCallPurchaseGRNMaster();
        });

        $('#DeletePurchaseGRNMasterRecord').on("click", function () {

            PurchaseGRNMaster.ActionName = "Delete";
            PurchaseGRNMaster.AjaxCallPurchaseGRNMaster();
        });

        $('#BatchNumber').on("keydown", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#BatchNumber").val("0");
                $("#ExpiryDate").val("");
                $('#BatchNumber').typeahead('val', '');
                $("#ExpiryDate").prop("disabled", false);
                
            }
        });
        $("#BatchNumber").focusout(function () {
            var data = $("#BatchNumber").val() + '~' + $("#ItemID").val();
           
            PurchaseGRNMaster.FocusOut("BatchNumber", data);
           
        });
        $("#ReceivedQuantity").on("keyup", function (e) {
            if($("#ReceivedQuantity").val() == "" || $("#ReceivedQuantity").val() == null)
            {
                $("#ReceivedQuantity").val(0);
             var abc = parseFloat($("#Quantity").val() - $("#ReceivedQuantity").val()).toFixed(2);
             $("#RemainingQty").val(abc);
            }
            
                //$("#ExpiryDate").prop("disabled", false);
            });

        
        InitAnimatedBorder();

        CloseAlert();

    },


  //  Check On Focus Out.
    FocusOut: function (actionOn, data) {

        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionOn": actionOn, "data": data },
            url: '/PurchaseGRNMaster/CheckFocusOnAction',
            success: function (data) {

                //Rebind Grid Data
                if (actionOn == "BatchNumber") {
                    //$("#BatchID").val(data);
                    var abc = data.split('~');
                    $("#BatchID").val(abc[0].replace('"', ''));
                    $("#ExpiryDate").val(abc[1].replace('"', ''));
                    
                //   //$("#ExpiryDate").prop("disabled", true);
                //    if ($("#ExpiryDate").val() == "" || $("#ExpiryDate").val() == null) {
                //        $(".abc").show(true)
                //    }
                //    else {
                //        $(".abc").hide(true)
                //    }
                }
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
             url: '/PurchaseGRNMaster/List',
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
            url: '/PurchaseGRNMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    CheckedAll: function () {
        $("#myDataTable thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#myDataTable tbody tr td  input[class='check-user']").prop("checked", true);
            }
            else {
                $("#myDataTable tbody tr td  input[class='check-user']").prop("checked", false);
            }
        });
    },
    
    GetXmlData: function () {
        debugger
        debugger
        var DataArray = [];
        $('#DivAddRowTable input').each(function () {
            if ($(this).attr('type') == 'checkbox' && $(this).attr('id') == 'check_1') {
                DataArray.push($(this).is(":checked") ? 1 : 0);
            }
            else {
                DataArray.push($(this).val());
            }
        });
      
        //alert(DataArray)
        //alert('1 st step')
       
        for (var i = DataArray.length - 1; i--;) {
            if (DataArray[i] === "on") DataArray.splice(i, 1);
        }
        var TotalRecord = DataArray.length;
               
        var ParameterXml = "<rows>";
        var aa = []; var TotalIslocked = 0; TotalLocked = 0;
        var Count = DataArray.length;
        var y = 0;
        for (var x = 0; x < Count; x = x + 28) {

            if (DataArray[x + 8] == "false") {
                TotalIslocked = TotalIslocked + 1;
            }

        }
        debugger;
        for (var i = 0; i < TotalRecord; i = i + 28) {
            var TodaysDate = new Date();
            var ExpiryDate = new Date(DataArray[i + 14])

            if (ExpiryDate > TodaysDate) {

                // The number of milliseconds in one day
                var ONE_DAY = 1000 * 60 * 60 * 24

                // Convert both dates to milliseconds
                var date1_ms = TodaysDate.getTime()
                var date2_ms = ExpiryDate.getTime()


                // Calculate the difference in milliseconds
                var difference_ms = Math.abs(date2_ms - date1_ms)

                // Convert back to days and return
                var DifferenceBetndates = Math.round(difference_ms / ONE_DAY)

            }
            else if (DataArray[i + 22] == 2 && (ExpiryDate < TodaysDate)) {
                $("#displayErrorMessage").text("Expiry date is alreday expired.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;

            }

            //if (DataArray[i + 3] == null || DataArray[i + 3] == "" || DataArray[i + 3] == 0) {
            //    $("#displayErrorMessage").text("Please Enter Received Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
            //    return false;

            //}


            //   else if (DataArray[i + 20] == 2 && (DataArray[i + 9] == "" || DataArray[i + 9] == null)) {
            //        $("#displayErrorMessage").text("Please Enter batch.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
            //        return false;
            //    }

            //else if (DataArray[i + 20] == 2 && (DataArray[i + 12] == "" || DataArray[i + 12] == null)) {
            //    $("#displayErrorMessage").text("Please Enter Expiry date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
            //    return false;
            //}


            if (DataArray[i + 22] == 2 && $('#PurchaseOrderType').val() != 3) {
                if (DifferenceBetndates > DataArray[i + 24] || (DifferenceBetndates < DataArray[i + 24] && DataArray[i + 26] == 1)) {
                    ParameterXml = ParameterXml + "<row><ID>0</ID><GeneralItemCodeID>" + DataArray[i + 19] + "</GeneralItemCodeID><Itemnumber>" + DataArray[i + 2] + "</Itemnumber><BarCode>" + DataArray[i + 15] + "</BarCode><OrderUomCode>" + DataArray[i + 17] + "</OrderUomCode><BaseUOMCode>" + DataArray[i + 16] + "</BaseUOMCode><BaseUOMQuantity>" + DataArray[i + 18] + "</BaseUOMQuantity><ReceivedQuantity>" + (parseFloat(DataArray[i + 4]) + parseFloat(DataArray[i + 5])) + "</ReceivedQuantity><ReceivingLocationID>" + DataArray[i + 21] + "</ReceivingLocationID><StorageLocationID>" + DataArray[i + 20] + "</StorageLocationID><Remark>" + DataArray[i + 7] + "</Remark><BatchID>" + DataArray[i + 12] + "</BatchID><BatchNumber>" + DataArray[i + 11] + "</BatchNumber><ExpiryDate>" + DataArray[i + 14] + "</ExpiryDate><FOC>" + DataArray[i] + "</FOC><FocReceivedQuantity>" + parseFloat(DataArray[i + 5]) + "</FocReceivedQuantity></row>";

                }
                else if (DifferenceBetndates < DataArray[i + 24] && DataArray[i + 26] == 0) {
                    // alert("Can nnot Insert " + DataArray[i + 0] + " Item in Stock")
                    var DataAppend = '';
                    PurchaseGRNMaster.DataAppend = '';
                    DataAppend = DataArray[i + 2];
                    PurchaseGRNMaster.DataAppend = PurchaseGRNMaster.DataAppend + ',' + DataAppend; // 
                    PurchaseGRNMaster.DataApproved = 1;

                    alert(PurchaseGRNMaster.DataAppend)

                    //DataAppend.push(DataArray[i+1]);
                    ParameterXml = ParameterXml + "<row><ID>0</ID><GeneralItemCodeID>" + DataArray[i + 19] + "</GeneralItemCodeID><Itemnumber>" + DataArray[i + 2] + "</Itemnumber><BarCode>" + DataArray[i + 15] + "</BarCode><OrderUomCode>" + DataArray[i + 17] + "</OrderUomCode><BaseUOMCode>" + DataArray[i + 16] + "</BaseUOMCode><BaseUOMQuantity>" + DataArray[i + 18] + "</BaseUOMQuantity><ReceivedQuantity>0</ReceivedQuantity><ReceivingLocationID>" + DataArray[i + 21] + "</ReceivingLocationID><StorageLocationID>" + DataArray[i + 20] + "</StorageLocationID><Remark>" + DataArray[i + 7] + "</Remark><BatchID>" + DataArray[i + 12] + "</BatchID><BatchNumber>" + DataArray[i + 11] + "</BatchNumber><ExpiryDate>" + DataArray[i + 14] + "</ExpiryDate><FOC>" + DataArray[i] + "</FOC><FocReceivedQuantity>" +  parseFloat(DataArray[i + 5]) + "</FocReceivedQuantity></row>";

                }
                else if (DataArray[i + 4] > 0) {
                    if ((DataArray[i + 11] == "" || DataArray[i + 11] == null)) {
                        PurchaseGRNMaster.testBatch = false;
                    }
                    else if (DataArray[i + 14] == "" || DataArray[i + 14] == null) {
                        PurchaseGRNMaster.testExpiry = false;
                    }
                }
                else if (DataArray[i + 4] == 0) {
                    if ((DataArray[i + 11] == "" || DataArray[i + 11] == null)) {
                        ParameterXml = ParameterXml + "<row><ID>0</ID><GeneralItemCodeID>" + DataArray[i + 19] + "</GeneralItemCodeID><Itemnumber>" + DataArray[i + 2] + "</Itemnumber><BarCode>" + DataArray[i + 15] + "</BarCode><OrderUomCode>" + DataArray[i + 17] + "</OrderUomCode><BaseUOMCode>" + DataArray[i + 16] + "</BaseUOMCode><BaseUOMQuantity>" + DataArray[i + 18] + "</BaseUOMQuantity><ReceivedQuantity>" + (parseFloat(DataArray[i + 4]) + parseFloat(DataArray[i + 5])) + "</ReceivedQuantity><ReceivingLocationID>" + DataArray[i + 21] + "</ReceivingLocationID><StorageLocationID>" + DataArray[i + 20] + "</StorageLocationID><Remark>" + DataArray[i + 7] + "</Remark><BatchID>" + DataArray[i + 12] + "</BatchID><BatchNumber>" + DataArray[i + 11] + "</BatchNumber><ExpiryDate>" + DataArray[i + 14] + "</ExpiryDate><FOC>" + DataArray[i] + "</FOC><FocReceivedQuantity>" +  parseFloat(DataArray[i + 5]) + "</FocReceivedQuantity></row>";

                    }
                }
            }
            else {

                ParameterXml = ParameterXml + "<row><ID>0</ID><GeneralItemCodeID>" + DataArray[i + 19] + "</GeneralItemCodeID><Itemnumber>" + DataArray[i + 2] + "</Itemnumber><BarCode>" + DataArray[i + 15] + "</BarCode><OrderUomCode>" + DataArray[i + 17] + "</OrderUomCode><BaseUOMCode>" + DataArray[i + 16] + "</BaseUOMCode><BaseUOMQuantity>" + DataArray[i + 18] + "</BaseUOMQuantity><ReceivedQuantity>" + (parseFloat(DataArray[i + 4]) + parseFloat(DataArray[i + 5])) + "</ReceivedQuantity><ReceivingLocationID>" + DataArray[i + 21] + "</ReceivingLocationID><StorageLocationID>" + DataArray[i + 20] + "</StorageLocationID><Remark>" + DataArray[i + 7] + "</Remark><BatchID>" + DataArray[i + 12] + "</BatchID><BatchNumber>" + DataArray[i + 11] + "</BatchNumber><ExpiryDate>" + DataArray[i + 14] + "</ExpiryDate><FOC>" + DataArray[i] + "</FOC><FocReceivedQuantity>" +  parseFloat(DataArray[i + 5]) + "</FocReceivedQuantity></row>";
            }

        }

        //alert(ParameterXml)
        if (ParameterXml.length > 28) {
            PurchaseGRNMaster.XMLstring = ParameterXml + "</rows>";

            if (TotalIslocked == 0) {
                PurchaseGRNMaster.Islocked = true;
            }
            else {
                PurchaseGRNMaster.Islocked = false;
            }

        }
        else {
            PurchaseGRNMaster.XMLstring = "";
            return false;
        }
       // alert(ParameterXml)
    },


    //GetXmlDataForAccountVoucher: function () {

       
    //    var DataArray = [];
    //    $('#DivAddRowTable1 input').each(function () {
    //        DataArray.push($(this).val());
    //    });
    //    //alert(DataArray);
    //    var TotalRecord = DataArray.length;

    //    //alert(TotalRecord)
    //    var ParameterXml = "<rows>";
    //    var currentdate = new Date();
    //    var datetime =
    //                     currentdate.getUTCFullYear() + "-"
    //                    + (currentdate.getUTCMonth() + 1) + "-"
    //                    + currentdate.getUTCDate() + " "
    //                    + currentdate.getUTCHours() + ":"
    //                    + currentdate.getUTCMinutes() + ":"
    //                    + currentdate.getUTCSeconds() + "."
    //                    + currentdate.getUTCMilliseconds();
    //    //alert(datetime)
    //    for (var i = 0; i < TotalRecord; i = i + 6) {
           
    //            if (DataArray[i + 2] == 0)
    //         {
    //            ParameterXml = ParameterXml + "<row><GenericNumber>" + DataArray[i + 3] + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtInventoryAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>-" + DataArray[i + 1] + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + DataArray[i + 4] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + DataArray[i + 3] + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtGRNClearing</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>" + DataArray[i + 1] + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + DataArray[i + 4] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
    //        }
    //        else {
                
    //            ParameterXml = ParameterXml + "<row><GenericNumber>" + DataArray[i + 3] + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtInventoryAmount</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + DataArray[i + 1] + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + DataArray[i + 4] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + DataArray[i + 3] + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtGRNClearing</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + parseFloat(parseFloat(DataArray[i + 1]) - parseFloat(DataArray[i + 2])).toFixed(2) + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + DataArray[i + 4] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + DataArray[i + 3] + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtFreight</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + DataArray[i + 2] + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + DataArray[i + 4] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

    //            }
          

    //    }

    //    //alert(ParameterXml)
    //    if (ParameterXml.length > 7) {
    //        PurchaseGRNMaster.XMLstringForVouchar = ParameterXml + "</rows>";

    //    }
    //    else {
    //        PurchaseGRNMaster.XMLstringForVouchar = "";
    //    }

    //},
    //Fire ajax call to insert update and delete record
    AjaxCallPurchaseGRNMaster: function () {
        var PurchaseGRNMasterData = null;
        if (PurchaseGRNMaster.ActionName == "Create") {
           
           
            $("#FormCreatePurchaseGRNMaster").validate();
            if ($("#FormCreatePurchaseGRNMaster").valid()) {
                PurchaseGRNMasterData = null;
                PurchaseGRNMasterData = PurchaseGRNMaster.GetPurchaseGRNMaster();
                ajaxRequest.makeRequest("/PurchaseGRNMaster/Create", "POST", PurchaseGRNMasterData, PurchaseGRNMaster.Success, "CreatePurchaseGRNMasterRecord");
            }


        }
        else if (PurchaseGRNMaster.ActionName == "Edit") {
            $("#FormEditPurchaseGRNMaster").validate();
            if ($("#FormEditPurchaseGRNMaster").valid()) {
                PurchaseGRNMasterData = null;

                PurchaseGRNMasterData = PurchaseGRNMaster.GetPurchaseGRNMaster();

                ajaxRequest.makeRequest("/PurchaseGRNMaster/Edit", "POST", PurchaseGRNMasterData, PurchaseGRNMaster.Success);

            }
        }
        else if (PurchaseGRNMaster.ActionName == "Delete") {
            PurchaseGRNMasterData = null;
            //$("#FormCreatePurchaseGRNMaster").validate();
            PurchaseGRNMasterData = PurchaseGRNMaster.GetPurchaseGRNMaster();
            ajaxRequest.makeRequest("/PurchaseGRNMaster/Delete", "POST", PurchaseGRNMasterData, PurchaseGRNMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetPurchaseGRNMaster: function () {
        var Data = {
        };
        if (PurchaseGRNMaster.ActionName == "Create" || PurchaseGRNMaster.ActionName == "Edit") {
            
            //   Data.PurchaseGRNMasterID = $('input[name=PurchaseGRNMasterID]').val();
            Data.PurchaseOrderMasterID = $('#PurchaseOrderMasterID').val();
            Data.XMLstring = PurchaseGRNMaster.XMLstring;
            //Data.XMLstringForVouchar = PurchaseGRNMaster.XMLstringForVouchar;
            Data.IsLocked = PurchaseGRNMaster.Islocked;
            Data.IsCompletePO = $('#IsCompletePO').is(":checked") ? "true" : "false";
            if (Data.IsCompletePO == "true")
            {
                Data.IsLocked = 1;
            }
            else
            {
                if (Data.IsLocked == true) {
                    Data.IsLocked = 1;
                } else {
                    Data.IsLocked = 0;
                }
                
            }
        }
        else if (PurchaseGRNMaster.ActionName == "Delete") {
            Data.PurchaseGRNMasterID = $('input[name=PurchaseGRNMasterID]').val();

        }
        return Data;
    },




    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            PurchaseGRNMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

