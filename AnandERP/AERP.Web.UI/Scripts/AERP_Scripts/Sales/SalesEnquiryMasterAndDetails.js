//this class contain methods related to nationality functionality
var SalesEnquiryMasterAndDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SalesEnquiryMasterAndDetails.constructor();
        //SalesEnquiryMasterAndDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :radio').val("");
            $('input:radio').removeAttr('checked');
          

            return false;
        });

        // Create new record
        $('#CreateSalesEnquiryMasterAndDetailsRecord').on("click", function () {
            debugger;
            SalesEnquiryMasterAndDetails.ActionName = "Create";
            SalesEnquiryMasterAndDetails.GetXmlData();
            if ($('#CustomerMasterName').val() == "" || $('#CustomerMasterName').val() == null)
            {
                $("#displayErrorMessage p").text("Please Select Customer Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#CustomerContactPersonName').val() == "" || $('#CustomerContactPersonName').val() == null) {
                $("#displayErrorMessage p").text("Please Select Customer Contact Person.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#TransactionDate').val() == "" || $('#TransactionDate').val() == null) {
                $("#displayErrorMessage p").text("Please Select Transaction Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
           else  if (SalesEnquiryMasterAndDetails.ParameterXml == "" || SalesEnquiryMasterAndDetails.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                SalesEnquiryMasterAndDetails.AjaxCallSalesEnquiryMasterAndDetails();
            }
        });

        $('#EditSalesEnquiryMasterAndDetailsRecord').on("click", function () {

            SalesEnquiryMasterAndDetails.ActionName = "Edit";
            SalesEnquiryMasterAndDetails.GetXmlData();
            if ($('#CustomerMasterName').val() == "" || $('#CustomerMasterName').val() == null) {
                $("#displayErrorMessage p").text("Please Select Customer Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#CustomerContactPersonName').val() == "" || $('#CustomerContactPersonName').val() == null) {
                $("#displayErrorMessage p").text("Please Select Customer Contact Person.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#TransactionDate').val() == "" || $('#TransactionDate').val() == null) {
                $("#displayErrorMessage p").text("Please Select Transaction Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if (SalesEnquiryMasterAndDetails.ParameterXml == "" || SalesEnquiryMasterAndDetails.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                SalesEnquiryMasterAndDetails.AjaxCallSalesEnquiryMasterAndDetails();
            }
        });

        $('#DeleteSalesEnquiryMasterAndDetailsRecord').on("click", function () {

            SalesEnquiryMasterAndDetails.ActionName = "Delete";
            SalesEnquiryMasterAndDetails.AjaxCallSalesEnquiryMasterAndDetails();
        });
      
        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });
        $("#btnShowListforList").unbind('click').click(function () {
            debugger;
            var SelectedTransactionDate = $('#TransactionDate').val();
            if (SelectedTransactionDate == '') {
                notify('Please select Transaction Date', 'warning');
                return false;
            }
            else{
                SalesEnquiryMasterAndDetails.LoadList();
            }
        });

        $("#searchBtn").click(function () {

            $("#UserSearch").focus();
        });

        

         $('#Quantity').on("keydown keypress", function (e) {
             AERPValidation.AllowNumbersWithDecimalOnly(e);
             var inputKeyCode = e.keyCode ? e.keyCode : e.which;
             if (inputKeyCode == 45 || inputKeyCode == 95) {
                 return false;
             }
         });

        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();
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
                        if (data.length > 0) {
                            $("#ConsumptionPrice").val((data[0].UomPurchasePrice) * $("#Quantity").val());
                            $("#ConsumptionPrice1").val((data[0].UomPurchasePrice));
                        }
                    }
                });
            }
            else {
                $("#ConsumptionPrice").val(0);
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

            //to check duplication of item while adding the item(Restrict Duplication of Item)
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });

            TotalRecord = DataArray.length;

            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 5) {
                if (DataArray[i + 0] == $('#ItemNumber').val() && DataArray[i + 3] == $('#UOM').val()) {
                    $("#displayErrorMessage ").text("You Cannot Enter the same item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");

                    $("#ItemDescription").val("");
                    $('#ItemDescription').typeahead('val', '');
                    $("#ItemNumber").val(0);
                    $("#Quantity").val(0);
                    $("#UOM").val("");
                    $("#ItemDescription").focus();
                    return false
                }
            }


            //End Of Code for Duplication of Item



            var i = 0;

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
            else if ($("#UOM").val() == null || $("#UOM").val() == "") {
                $("#displayErrorMessage ").text("Please Select UoM Code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
           
       
            if ($('#ItemDescription').val() != "" && $('#ItemDescription').val() != null) {
                //Code For IsBase Uom Check box Ends

                $("#tblData tbody").append(
                                     "<tr>" +
                                      "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                                     "<td><input id='ItemDescription' type='text' value=" + $('#ItemDescription').val() + " style='display:none' />" + $('#ItemDescription').val() + "</td>" +
                                     "<td><input id='Quantity' type='text' value=" + $('#Quantity').val() + " style='display:none' />" + $('#Quantity').val() + "</td>" +
                                     "<td ><input type='text' value=" + $('#UOM').val() + " style='display:none' /> " + $('#UOM').val() + "</td>" +
                                      "<td style=display:none><input id='SaleEnquiryDetailsID' type='hidden'  value=0  style='display:none' />" + $('#SaleEnquiryDetailsID').val() + "</td>" +
                                     "<td> <i class='zmdi zmdi-delete zmdi-hc-fw ENQDetail' style='cursor:pointer'' title = Delete ></td>" +
                                     "</tr>"
                                    );

                $("#ItemDescription").val("");
                $('#ItemDescription').typeahead('val', '');
                $("#ItemNumber").val(0);
                $("#Quantity").val(0);
                $("#UOM").val("");
               
            }

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i.ENQDetail", function () {
                $(this).closest('tr').remove();
            });

        });
    },



    //LoadList method is used to load List page
    LoadList: function () {
        debugger;

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/SalesEnquiryMasterAndDetails/List',
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
            data: { "actionMode": actionMode },
            url: '/SalesEnquiryMasterAndDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    GetXmlData: function () {

        var DataArray = [];
        //CustomerMaster.flag = true;
        debugger;
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
        debugger;
       
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 5) {

            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i + 4] + "</ID><ItemNumber>" + DataArray[i + 0] + "</ItemNumber><Quantity>" + DataArray[i + 2] + "</Quantity><UOM>" + DataArray[i + 3] + "</UOM></row>";

        }
        // alert(ParameterXml);
        if (ParameterXml.length > 10)
            SalesEnquiryMasterAndDetails.ParameterXml = ParameterXml + "</rows>";

        else
            SalesEnquiryMasterAndDetails.ParameterXml = "";
        // alert(CustomerMaster.ParameterXml)
    },



    //Fire ajax call to insert update and delete record
    AjaxCallSalesEnquiryMasterAndDetails: function () {
        var SalesEnquiryMasterAndDetailsData = null;
        if (SalesEnquiryMasterAndDetails.ActionName == "Create") {
            $("#FormCreateSalesEnquiryMasterAndDetails").validate();
            if ($("#FormCreateSalesEnquiryMasterAndDetails").valid()) {
                SalesEnquiryMasterAndDetailsData = null;
                SalesEnquiryMasterAndDetailsData = SalesEnquiryMasterAndDetails.GetSalesEnquiryMasterAndDetails();
                ajaxRequest.makeRequest("/SalesEnquiryMasterAndDetails/Create", "POST", SalesEnquiryMasterAndDetailsData, SalesEnquiryMasterAndDetails.Success);
            }
        }
        else if (SalesEnquiryMasterAndDetails.ActionName == "Edit") {
            $("#FormEditSalesEnquiryMasterAndDetails").validate();
            if ($("#FormEditSalesEnquiryMasterAndDetails").valid()) {
                SalesEnquiryMasterAndDetailsData = null;
                SalesEnquiryMasterAndDetailsData = SalesEnquiryMasterAndDetails.GetSalesEnquiryMasterAndDetails();
                ajaxRequest.makeRequest("/SalesEnquiryMasterAndDetails/Edit", "POST", SalesEnquiryMasterAndDetailsData, SalesEnquiryMasterAndDetails.Success);
            }
        }
        else if (SalesEnquiryMasterAndDetails.ActionName == "Delete") {
            SalesEnquiryMasterAndDetailsData = null;
            //$("#FormCreateSalesEnquiryMasterAndDetails").validate();
            SalesEnquiryMasterAndDetailsData = SalesEnquiryMasterAndDetails.GetSalesEnquiryMasterAndDetails();
            ajaxRequest.makeRequest("/SalesEnquiryMasterAndDetails/Delete", "POST", SalesEnquiryMasterAndDetailsData, SalesEnquiryMasterAndDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalesEnquiryMasterAndDetails: function () {
        var Data = {
        };
        if (SalesEnquiryMasterAndDetails.ActionName == "Create" || SalesEnquiryMasterAndDetails.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.XmlString = SalesEnquiryMasterAndDetails.ParameterXml;
            Data.CustomerMasterID = $('#CustomerMasterID').val();
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            Data.ContactPersonID = $('#ContactPersonID').val();
            Data.ReferenceBy = $('#ReferenceBy').val();
            Data.TransactionDate = $('#TransactionDate').val();

            Data.SalesEnquiryMasterID = $('#SalesEnquiryMasterID').val();
            // Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
        }
        else if (SalesEnquiryMasterAndDetails.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SalesEnquiryMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SalesEnquiryMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

