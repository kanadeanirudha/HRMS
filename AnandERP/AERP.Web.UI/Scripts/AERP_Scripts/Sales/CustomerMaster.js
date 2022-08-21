//this class contain methods related to nationality functionality
var CustomerMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CustomerMaster.constructor();
        //CustomerMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#TaxName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :radio').val("");
            $('input:radio').removeAttr('checked');
            $('#TaxName').focus();
            $('#IsOtherState').removeAttr('checked');

            return false;
        });

        // Create new record
        $('#CreateCustomerMasterRecord').on("click", function () {
            debugger;
            CustomerMaster.ActionName = "Create";
            
            if (($('#FirstName').val() == '' || $('#FirstName').val() == null) && ($('#CustomerType').val()==1))
            {
                $("#displayErrorMessage p").text("Please Enter First Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if (($('#LastName').val() == '' || $('#LastName').val() == null)&& ($('#CustomerType').val()==1))
            {
                $("#displayErrorMessage p").text("Please Enter Last Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#Address1').val() == '' || $('#Address1').val() == null) {
                $("#displayErrorMessage p").text("Please Enter Address.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#StateID').val()==''||$('#StateID').val()==null||$('#StateID').val()==0)
            {
                $("#displayErrorMessage p").text("Please Enter State.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            //else if ($('#MobileNumber').val() == '' || $('#MobileNumber').val() == null) {
            //    $("#displayErrorMessage p").text("Please Enter Mobile Number.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    return false;
            //}
            //else if (($('#CustomerType :selected').val() == '2') && ($('#CompanyName').val() = '' || $('#CompanyName').val() == null)) {
            //    $("#displayErrorMessage p").text("Please Enter Company Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    return false;
            //}

            else {
                CustomerMaster.AjaxCallCustomerMaster();
            }
        });
        $('#EditCustomerMasterRecord').on("click", function () {
            debugger;
            CustomerMaster.ActionName = "EditCustomerDetails";

            if (($('#FirstName').val() == '' || $('#FirstName').val() == null) && ($('#CustomerType').val() == 1)) {
                $("#displayErrorMessage p").text("Please Enter First Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if (($('#LastName').val() == '' || $('#LastName').val() == null) && ($('#CustomerType').val() == 1)) {
                $("#displayErrorMessage p").text("Please Enter Last Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#Address1').val() == '' || $('#Address1').val() == null) {
                $("#displayErrorMessage p").text("Please Enter Address.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#StateID').val() == '' || $('#StateID').val() == null || $('#StateID').val() == 0) {
                $("#displayErrorMessage p").text("Please Enter State.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }

            else {
                CustomerMaster.AjaxCallCustomerMaster();
            }
        });

        $('#CustomerType').on("change", function () {
            
            var code = $('#CustomerType :selected').val();
            if ((code) == '1' || (code) == '') {
                $('#CompanyName').attr("disabled", "disabled");
                $('#CompanyName').val(' ');
            }
            else {
                $('#CompanyName').prop('disabled', false);
            }
        });

        $('#CreateCustomerBranchMasterRecord').on("click", function () {
            CustomerMaster.ActionName = "CreateBranchRecord";
            if ($('#CustomerBranchMasterName').val() == '' || $('#CustomerBranchMasterName').val() == null) {
                $("#displayErrorMessage p").text("Please Enter Branch Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
          
            else if ($('#Address1').val() == '' || $('#Address1').val() == null) {
                $("#displayErrorMessage p").text("Please Enter Address.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#StateID').val() == '' || $('#StateID').val() == null || $('#StateID').val() == 0) {
                $("#displayErrorMessage p").text("Please Enter State.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
           
            else
                {
                CustomerMaster.AjaxCallCustomerMaster();
            }
        });
        
        $('#CreateCustomerContactDetailsRecord').on("click", function () {
            CustomerMaster.ActionName = "CreateContactDetails";
            CustomerMaster.flag = true;
            CustomerMaster.GetXmlData();
            if (CustomerMaster.ParameterXml == "" || CustomerMaster.ParameterXml == null) {
                $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                CustomerMaster.AjaxCallCustomerMaster();
            }
        });


        $('#EditCustomerBranchMasterRecord').on("click", function () {

            CustomerMaster.ActionName = "Edit";
            CustomerMaster.AjaxCallCustomerMaster();
        });

        $('#DeleteCustomerMasterRecord').on("click", function () {

            CustomerMaster.ActionName = "Delete";
            CustomerMaster.AjaxCallCustomerMaster();
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

            //for (var i = 0; i < TotalRecord; i = i + 7) {
            //    if (DataArray[i] == $('#ItemNumber').val()) {
            //        $("#displayErrorMessage p").text("You Cannot Enter Same Item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
            //        $("#ItemDescription").val("");
            //        $("#Quantity").val(0);
            //        $("#UoMCode").val("");
            //        $("#WastageInPercentage").val(0);
            //        return false;
            //    }
            //}


            if ($("#CustomerContactFirstName").val() == null || $("#CustomerContactFirstName").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Customer Contact First Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#CustomerContactLastName").val() == null || $("#CustomerContactLastName").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Customer Contact Last Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#CustomerContactEmailID").val() == null || $("#CustomerContactEmailID").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Customer Contact Email ID.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            else if ($("#CustomerContactMobileNumber").val() == null || $("#CustomerContactMobileNumber").val() == "") {
                $("#displayErrorMessage ").text("Please Enter Customer Contact Mobile Number.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
                return false;
            }
            var IsPrimaryContact = $("#IsPrimaryContact").is(":checked") ? "true" : "false";
            if (IsPrimaryContact == "true") {
                IsPrimaryContact = "<td> <input id='IsPrimaryContact' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
                $("#IsPrimaryContact").removeAttr('checked');
                $("#IsPrimaryContact").val("");
            }
            else {
                IsPrimaryContact = "<td> <input id='IsPrimaryContact' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
                $("#IsPrimaryContact").removeAttr('checked');
                $("#IsPrimaryContact").val("");
            }

           
            if ($('#CustomerContactFirstName').val() != "" && $('#CustomerContactFirstName').val() != null) {
                //Code For IsBase Uom Check box Ends

                $("#tblData tbody").append(
                                     "<tr>" +
                                     "<td><input id='CustomerContactFirstName' type='text' value='" + $('#CustomerContactFirstName').val() + "' style='display:none' />" + $('#CustomerContactFirstName').val() + "</td>" +
                                   "<td><input id='CustomerContactMiddleName' type='text' value='" + $('#CustomerContactMiddleName').val() + "' style='display:none' />" + $('#CustomerContactMiddleName').val() + "</td>" +
                                    "<td><input id='CustomerContactLastName' type='text' value='" + $('#CustomerContactLastName').val() + "' style='display:none' />" + $('#CustomerContactLastName').val() + "</td>" +
                                    IsPrimaryContact +
                                     "<td><input id='CustomerContactEmailID' type='text' value='" + $('#CustomerContactEmailID').val() + "' style='display:none' />" + $('#CustomerContactEmailID').val() + "</td>" +
                                     "<td><input id='CustomerContactMobileNumber' type='text' value='" + $('#CustomerContactMobileNumber').val() + "' style='display:none' />" + $('#CustomerContactMobileNumber').val() + "</td>" +
                                     "<td><input id='CustomerContactDesignation' type='text' value='" + $('#CustomerContactDesignation').val() + "' style='display:none' />" + $('#CustomerContactDesignation').val() + "</td>" +
                                     "<td style=display:none><input id='CustomerContactDetailsID' type='hidden' value=0 style='display:none' />" + $('#CustomerContactDetailsID').val() + "</td>" +
                                     "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                     "</tr>"
                                    );

                $("#CustomerContactFirstName").val("");
                $("#CustomerContactMiddleName").val("");
                $("#CustomerContactLastName").val("");
                $("#CustomerContactEmailID").val("");
                $("#CustomerContactMobileNumber").val("");
                $("#CustomerContactDesignation").val("");

            }

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

        });

        $("#UserSearch").on("keyup", function () {
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

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $("#CountryID").change(function () {

            $('#CityID').find('option').remove().end().append('<option value>----Select City----</option>');
            $("#CityID").prop("disabled", true);
            var selectedItem = $(this).val();
            if (selectedItem != "") {
                var $ddlRegion = $("#StateID");
                var $RegionProgress = $("#states-loading-progress");
                $RegionProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralLocationMaster/GetRegionByCountryID",
                    data: { "SelectedCountryID": selectedItem },
                    success: function (data) {
                        $ddlRegion.html('');
                        $('#StateID').append('<option value>----Select State----</option>');
                        $.each(data, function (id, option) {

                            $ddlRegion.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $RegionProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Region.');
                        $RegionProgress.hide();
                    }
                });
            }
            else {
                $('#StateID').find('option').remove().end().append('<option value>----Select State----</option>');
                $('#CityID').find('option').remove().end().append('<option value>----Select City----</option>');
            }
        });

        $("#StateID").change(function () {

            var selectedItem = $(this).val();
            if (selectedItem != "") {
                $("#CityID").prop("disabled", false);
                var $ddlCity = $("#CityID");
                var $CityProgress = $("#states-loading-progress");
                $CityProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralLocationMaster/GetCityByRegionID", 
                    data: { "SelectedRegionID": selectedItem },
                    success: function (data) {
                        $ddlCity.html('');
                        $('#CityID').append('<option value>----Select City----</option>');
                        $.each(data, function (id, option) {

                            $ddlCity.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $CityProgress.hide();

                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve City.');
                        $CityProgress.hide();
                    }
                });
            }
            else {
                $('#CityID').find('option').remove().end().append('<option value>----Select City----</option>');
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
             url: '/CustomerMaster/List',
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
            url: '/CustomerMaster/List',
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
        //alert(DataArray);
        //alert(TotalRecord);
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 8) {
           
            ParameterXml = ParameterXml + "<row><FirstName>" + DataArray[i + 0] + "</FirstName><Middlename>" + DataArray[i + 1] + "</Middlename><LastName>" + DataArray[i + 2] + "</LastName><MobileNumber>" + DataArray[i + 5] + "</MobileNumber><Email>" + DataArray[i + 4] + "</Email><Designation>" + DataArray[i + 6] + "</Designation><IsPrimaryContact>" + DataArray[i + 3] + "</IsPrimaryContact><CustomerContactDetailsID>" + DataArray[i + 7] + "</CustomerContactDetailsID></row>";
           
        }
       // alert(ParameterXml);
        if (ParameterXml.length > 10)
            CustomerMaster.ParameterXml = ParameterXml + "</rows>";

        else
            CustomerMaster.ParameterXml = "";
       // alert(CustomerMaster.ParameterXml)
    },

    //Fire ajax call to insert update and delete record
    AjaxCallCustomerMaster: function () {
        var CustomerMasterData = null;
        if (CustomerMaster.ActionName == "Create") {
            $("#FormCreateCustomerMaster").validate();
            if ($("#FormCreateCustomerMaster").valid()) {
                CustomerMasterData = null;
                CustomerMasterData = CustomerMaster.GetCustomerMaster();
                ajaxRequest.makeRequest("/CustomerMaster/Create", "POST", CustomerMasterData, CustomerMaster.Success);
            }
        }
        else if (CustomerMaster.ActionName == "CreateBranchRecord") {
            $("#FormCreateBranchCustomerMaster").validate();
            if ($("#FormCreateBranchCustomerMaster").valid()) {
                CustomerMasterData = null;
                CustomerMasterData = CustomerMaster.GetCustomerMaster();
                ajaxRequest.makeRequest("/CustomerMaster/CreateBranchDetails", "POST", CustomerMasterData, CustomerMaster.Success);
            }
        }
        else if (CustomerMaster.ActionName == "Edit") {
            $("#FormEditCustomerMaster").validate();
            if ($("#FormEditCustomerMaster").valid()) {
                CustomerMasterData = null;
                CustomerMasterData = CustomerMaster.GetCustomerMaster();
                ajaxRequest.makeRequest("/CustomerMaster/Edit", "POST", CustomerMasterData, CustomerMaster.Success);
            }
        }
        else if (CustomerMaster.ActionName == "EditCustomerDetails") {
            $("#FormEditCustomerMaster").validate();
            if ($("#FormEditCustomerMaster").valid()) {
                CustomerMasterData = null;
                CustomerMasterData = CustomerMaster.GetCustomerMaster();
                ajaxRequest.makeRequest("/CustomerMaster/EditCustomerDetails", "POST", CustomerMasterData, CustomerMaster.Success);
            }
        }

        
        else if (CustomerMaster.ActionName == "Delete") {
            CustomerMasterData = null;
            //$("#FormCreateCustomerMaster").validate();
            CustomerMasterData = CustomerMaster.GetCustomerMaster();
            ajaxRequest.makeRequest("/CustomerMaster/Delete", "POST", CustomerMasterData, CustomerMaster.Success);

        }
        else if (CustomerMaster.ActionName == "CreateContactDetails") {
            $("#FormCreateCustomerContactDetails").validate();
            if ($("#FormCreateCustomerContactDetails").valid()) {
                CustomerMasterData = null;
                CustomerMasterData = CustomerMaster.GetCustomerMaster();
                ajaxRequest.makeRequest("/CustomerMaster/CreateContactDetails", "POST", CustomerMasterData, CustomerMaster.Success);
            }
        }
        
    },
    //Get properties data from the Create, Update and Delete page
    GetCustomerMaster: function () {
        var Data = {
        };
        if (CustomerMaster.ActionName == "Create" || CustomerMaster.ActionName == "EditCustomerDetails") {
            Data.ID = $('#ID').val();
            Data.CustomerType = $('#CustomerType').val();
            Data.CompanyName = $('#CompanyName').val();
            Data.FirstName = $('#FirstName').val();
            Data.MiddleName = $('#MiddleName').val();
            Data.LastName = $('#LastName').val();
            Data.Address1 = $('#Address1').val();
            Data.Address2 = $('#Address2').val();
            Data.Address3 = $('#Address3').val();
            Data.CountryID = $('#CountryID').val();
            Data.StateID = $('#StateID').val();                         
            Data.CityID = $('#CityID').val();
            Data.MobileNumber = $('#MobileNumber').val();
            Data.Email = $('#Email').val();
            Data.Currency = $('#Currency').val();
            Data.GSTNumber = $('#GSTNumber').val();
            Data.IsTaxExempted = $('#IsTaxExempted').val();
            Data.ReasonForExemption = $('#ReasonForExemption').val();
            Data.BankName = $('#BankName').val();
            Data.IFCICODE = $('#IFCICODE').val();
            Data.BankAccountNumber = $('#BankAccountNumber').val();
            Data.CreditPeriod = $('#CreditPeriod').val();
            Data.UnitMasterId = $('#UnitMasterId').val();
            Data.ShortCode = $('#ShortCode').val();
            Data.IsTaxExempted = $('input[id=IsTaxExempted]').is(":checked") ? "true" : "false";
            Data.IsBillToSameAsShipTo = $('input[id=IsBillToSameAsShipTo]').is(":checked") ? "true" : "false";
            Data.CustomerMasterID = $('#CustomerMasterID').val();
            Data.PinCode = $('#PinCode').val();
            Data.Code = 'CustomerMaster';
            Data.TaxExemptionRemark = $('#TaxExemptionRemark').val();
            Data.IsCentre = $('input[id=IsCentre]').is(":checked") ? "true" : "false";
            Data.CentreCode = $('#CentreCode').val();

            // Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
        }
        else if (CustomerMaster.ActionName == "CreateBranchRecord" || CustomerMaster.ActionName == "Edit")
        {
            Data.CustomerMasterID = $('#CustomerMasterID').val();
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val();
            Data.CustomerType = $('#CustomerType').val();
            Data.CompanyName = $('#CompanyName').val();
            Data.FirstName = $('#FirstName').val();
            Data.MiddleName = $('#MiddleName').val();
            Data.LastName = $('#LastName').val();
            Data.Address1 = $('#Address1').val();
            Data.Address2 = $('#Address2').val();
            Data.Address3 = $('#Address3').val();
            Data.CountryID = $('#CountryID').val();
            Data.StateID = $('#StateID').val();
            Data.CityID = $('#CityID').val();
            Data.MobileNumber = $('#MobileNumber').val();
            Data.Email = $('#Email').val();
            Data.Currency = $('#Currency').val();
            Data.GSTNumber = $('#GSTNumber').val();
            Data.IsTaxExempted = $('#IsTaxExempted').val();
            Data.ReasonForExemption = $('#ReasonForExemption').val();
            Data.BankName = $('#BankName').val();
            Data.IFCICODE = $('#IFCICODE').val();
            Data.BankAccountNumber = $('#BankAccountNumber').val();
            Data.CreditPeriod = $('#CreditPeriod').val();
            Data.UnitMasterId = $('#UnitMasterId').val();
            Data.IsTaxExempted = $('input[id=IsTaxExempted]').is(":checked") ? "true" : "false";
            Data.IsMainBranch = $('input[id=IsMainBranch]').is(":checked") ? "true" : "false";
            Data.CustomerBranchMasterName = $('#CustomerBranchMasterName').val();
            Data.ShortCode = $('#ShortCode').val();
            Data.IsBillToSameAsShipTo = $('input[id=IsBillToSameAsShipTo]').is(":checked") ? "true" : "false";
            Data.PinCode = $('#PinCode').val();
            Data.Code = 'CustomerBranchMaster';
            Data.TaxExemptionRemark = $('#TaxExemptionRemark').val();
            Data.IsCentre = $('input[id=IsCentre]').is(":checked") ? "true" : "false";
            Data.CentreCode = $('#CentreCode').val();
        }
        else if (CustomerMaster.ActionName == "CreateContactDetails")
        {
            debugger;
            Data.XmlString = CustomerMaster.ParameterXml;
            Data.CustomerBranchMasterID = $('#CustomerBranchMasterID').val() == 0 ? null : $('#CustomerBranchMasterID').val();
            Data.CustomerMasterID = $('#CustomerMasterID').val();

        }
        else if (CustomerMaster.ActionName == "Delete") {
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
            CustomerMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            CustomerMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

