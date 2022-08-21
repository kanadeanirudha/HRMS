//this class contain methods related to nationality functionality
var CCRMMIFMasterAndDetails = {
    //Member variables
    ActionName: null,
    //SelectedContactDetailsIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMMIFMasterAndDetails.constructor();
        //CCRMMIFMasterAndDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SelectedRegionID').focus();
            $('#SelectedRegionID').val('');
        });

        // Create new record
        $('#CreateCCRMMIFMasterAndDetailsRecord').on("click", function () {
            debugger;
            CCRMMIFMasterAndDetails.ActionName = "Create";
            //CCRMMIFMasterAndDetails.getValueUsingParentTag_Check_UnCheck();

            if ($('#CustomerMasterName').val() == "" || $('#CustomerMasterName').val() == null) {
                $("#displayErrorMessage p").text("Please Select Customer Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#ItemDescription').val() == "" || $('#ItemDescription').val() == null) {
                $("#displayErrorMessage p").text("Please Select Model No.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#AreaPatchName').val() == "" || $('#AreaPatchName').val() == null) {
                $("#displayErrorMessage p").text("Please Select Area Patch Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                CCRMMIFMasterAndDetails.AjaxCallCCRMMIFMasterAndDetails();
            }
        });

        $('#EditCCRMMIFMasterAndDetailsRecord').on("click", function () {
            debugger;
            CCRMMIFMasterAndDetails.ActionName = "Edit";
            //CCRMMIFMasterAndDetails.getValueUsingParentTag_Check_UnCheck();

        if ($('#ItemDescription').val() == "" || $('#ItemDescription').val() == null) {
                $("#displayErrorMessage p").text("Please Select Model No.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
        else if ($('#AreaPatchName').val() == "" || $('#AreaPatchName').val() == null) {
                $("#displayErrorMessage p").text("Please Select Area Patch Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
        else {
            CCRMMIFMasterAndDetails.AjaxCallCCRMMIFMasterAndDetails();
        }
           
        });

        $('#DeleteCCRMMIFMasterAndDetailsRecord').on("click", function () {

            CCRMMIFMasterAndDetails.ActionName = "Delete";
            CCRMMIFMasterAndDetails.AjaxCallCCRMMIFMasterAndDetails();
        });
        //$('#SegementName').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        $('#InstallationDate').datetimepicker({
            format: 'DD MMM YYYY',
            maxDate: moment(),

        });
        $('#InactiveDate').datetimepicker({
            format: 'DD MMM YYYY',
            maxDate: moment(),
        });
        //$('#WarantyExpiryDate').datetimepicker({
        //    format: 'DD MMM YYYY',
        //    maxDate: moment(),

        //});
        $('#Status').on('change', function() {
            if($(this).val() == '1'){
                $("#dvInactiveDate").hide();
            } 
            else{
                $("#dvInactiveDate").show();
            }
        });
        
        $("#WarantyInDays").on("change paste keyup", function () {
            // alert($(this).val());
           
            
            var someDate = new Date($('#InstallationDate').val());
            //var numberOfDaysToAdd = $(this).val();
            var numberOfDaysToAdd = parseInt($(this).val(), 10);
            if (isNaN(numberOfDaysToAdd)) {
                // invalid number; show an error message
                return;
            }
            someDate.setDate(someDate.getDate() + numberOfDaysToAdd);
            var date = someDate.getFullYear() + '-' + (someDate.getMonth() + 1) + '-' + someDate.getDate();
            //var date = someDate.getDate() + '-' + (someDate.getMonth() + 1) + '-' + someDate.getFullYear();
          
            $('#WarantyExpiryDate').val(date);
          
        });
       
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
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
        //to upend the data
        //$('#btnAdd').on("click", function () {
           
        //    var DataArray = [];
        //    var data = $('#tblData tbody tr td input').each(function () {
        //        if ($(this).val() != "on") {
        //            DataArray.push($(this).val());
        //        }
        //    });
        //    TotalRecord = DataArray.length;

        //    //to check duplication of item while adding the item(Restrict Duplication of Item)
        //    var DataArray = [];
        //    var data = $('#tblData tbody tr td input').each(function () {
        //        DataArray.push($(this).val());
        //    });

        //    TotalRecord = DataArray.length;

        //    var i = 0;
        //    for (var i = 0; i < TotalRecord; i = i + 5) {
        //        if (DataArray[i + 0] == $('#CustomerContactDetailsID').val() && DataArray[i + 3] == $('#MobileNumber').val()) {
        //            $("#displayErrorMessage ").text("You Cannot Enter the same item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
        //            $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");

        //            $("#KeyOperator").val("");
        //            $('#KeyOperator').typeahead('val', '');
        //            $("#CustomerContactDetailsID").val();
        //            $("#Phone").val(0);
        //            $("#MobileNumber").val("");
        //            $("#KeyOperator").focus();
        //            return false
        //        }
        //    }


        //    //End Of Code for Duplication of Item



        //    var i = 0;

        //    if ($("#KeyOperator").val() == null || $("#KeyOperator").val() == "") {
        //        $("#displayErrorMessage ").text("Please Enter Item Description.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
        //        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
        //        return false;
        //    }
        //    else if ($("#Phone").val() == 0 || $("#Phone").val() == "") {
        //        $("#displayErrorMessage ").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
        //        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
        //        return false;
        //    }
        //    else if ($("#MobileNumber").val() == null || $("#MobileNumber").val() == "") {
        //        $("#displayErrorMessage ").text("Please Enter MobleNo.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
        //        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
        //        return false;
        //    }


        //    if ($('#KeyOperator').val() != "" && $('#KeyOperator').val() != null) {
        //        //Code For IsBase Uom Check box Ends

        //        $("#tblData tbody").append(
        //                             "<tr>" +
        //                                "<td style=display:none><input id='CustomerContactDetailsID' type='hidden'  value=" + $('#CustomerContactDetailsID').val() + "  style='display:none' />" + $('#CustomerContactDetailsID').val() + "</td>" +
        //                             "<td><input id='KeyOperator' type='text' value=" + $('#KeyOperator').val() + " style='display:none' />" + $('#KeyOperator').val() + "</td>" +
        //                             "<td><input id='Phone' type='text' value=" + $('#Phone').val() + " style='display:none' />" + $('#Phone').val() + "</td>" +
        //                             "<td ><input type='text' value=" + $('#MobileNumber').val() + " style='display:none' /> " + $('#MobileNumber').val() + "</td>" +
        //                              "<td style=display:none><input id='ID' type='hidden'  value=0  style='display:none' />" + $('#ID').val() + "</td>" +
        //                             "<td> <i class='zmdi zmdi-delete zmdi-hc-fw ENQDetail' style='cursor:pointer'' title = Delete ></td>" +
        //                             "</tr>"
        //                            );

        //        $("#KeyOperator").val("");
        //        $('#KeyOperator').typeahead('val', '');
        //        $("#CustomerContactDetailsID").val();
        //        $("#Phone").val(0);
        //        $("#MobileNumber").val("");

        //    }

        //    //Delete record in table
        //    $("#tblData tbody").on("click", "tr td i.ENQDetail", function () {
        //        $(this).closest('tr').remove();
        //    });

        //});
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/CCRMMIFMasterAndDetails/List',
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
            url: '/CCRMMIFMasterAndDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallCCRMMIFMasterAndDetails: function () {
        debugger;
        var CCRMMIFMasterAndDetailsData = null;
        if (CCRMMIFMasterAndDetails.ActionName == "Create") {
            $("#FormCreateCCRMMIFMasterAndDetails").validate();
            if ($("#FormCreateCCRMMIFMasterAndDetails").valid()) {
                CCRMMIFMasterAndDetailsData = null;
                CCRMMIFMasterAndDetailsData = CCRMMIFMasterAndDetails.GetCCRMMIFMasterAndDetails();
                ajaxRequest.makeRequest("/CCRMMIFMasterAndDetails/Create", "POST", CCRMMIFMasterAndDetailsData, CCRMMIFMasterAndDetails.Success);
            }
        }
        else if (CCRMMIFMasterAndDetails.ActionName == "Edit") {
            $("#FormEditCCRMMIFMasterAndDetails").validate();
            if ($("#FormEditCCRMMIFMasterAndDetails").valid()) {
                CCRMMIFMasterAndDetailsData = null;
                CCRMMIFMasterAndDetailsData = CCRMMIFMasterAndDetails.GetCCRMMIFMasterAndDetails();
                ajaxRequest.makeRequest("/CCRMMIFMasterAndDetails/Edit", "POST", CCRMMIFMasterAndDetailsData, CCRMMIFMasterAndDetails.Success);
            }
        }
        else if (CCRMMIFMasterAndDetails.ActionName == "Delete") {
            CCRMMIFMasterAndDetailsData = null;
            //$("#FormCreateCCRMMIFMasterAndDetails").validate();
            CCRMMIFMasterAndDetailsData = CCRMMIFMasterAndDetails.GetCCRMMIFMasterAndDetails();

            ajaxRequest.makeRequest("/CCRMMIFMasterAndDetails/Delete", "POST", CCRMMIFMasterAndDetailsData, CCRMMIFMasterAndDetails.Success);

        }
    },
    //getValueUsingParentTag_Check_UnCheck: function () {
       
    //    var DataArray = [];
    //    //CustomerMaster.flag = true;

    //    $('#tblData tbody tr td input').each(function () {
    //        if ($(this).val() != "on") {
    //            if ($(this).attr('type') == 'checkbox') {
    //                DataArray.push($(this).is(":checked") ? 1 : 0);
    //            }
    //            else {
    //                DataArray.push($(this).val());
    //            }
    //        }
    //    });
    //    var TotalRecord = DataArray.length;
    //    alert(DataArray)

    //    var ParameterXml = "<rows>";
    //    for (var i = 0; i < TotalRecord; i = i + 5) {

    //        ParameterXml = ParameterXml + "<row><ID>" + DataArray[i + 4] + "</ID><KeyOperatorName>" + DataArray[i + 1] + "</KeyOperatorName><PhoneNo>" + DataArray[i + 2] + "</PhoneNo><MobileNo>" + DataArray[i + 3] + "</MobileNo></row>";

    //    }
    //    alert(ParameterXml);
    //    if (ParameterXml.length > 10)
    //        CCRMMIFMasterAndDetails.SelectedContactDetailsIDs = ParameterXml + "</rows>";

    //    else
    //        CCRMMIFMasterAndDetails.SelectedContactDetailsIDs = "";
    //    // alert(CustomerMaster.ParameterXml)
    //},


    //Get properties data from the Create, Update and Delete page
    GetCCRMMIFMasterAndDetails: function () {

        var Data = {
        };
        if (CCRMMIFMasterAndDetails.ActionName == "Create" || CCRMMIFMasterAndDetails.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();

            Data.InstallationDate = $('#InstallationDate').val();
            Data.CustomerCode = $('#CustomerCode').val();
            Data.CustomerMasterID = $('#CustomerMasterID').val();
            Data.CustomerAddress = $('#CustomerAddress').val();
            Data.CustomerMasterName = $('#CustomerMasterName').val();
            Data.CustomerPinCode = $('#CustomerPinCode').val();
            Data.CutomerSegementMasterID = $('#CutomerSegementMasterID').val();

            Data.MIFTitle = $('#MIFTitle').val();
            Data.MIFAddress = $('#MIFAddress').val();
            Data.MIFPinCode = $('#MIFPinCode').val();
            Data.FolioNo = $('#FolioNo').val();
            Data.BillTitle = $('#BillTitle').val();
            Data.BillAddress = $('#BillAddress').val();
            Data.ModelNo = $('#ItemNumber').val();
            Data.SerialNo = $('#SerialNo').val();
            Data.MIFType = $('#MIFType').val();
            Data.MachineFamilyID = $('#MachineFamilyID').val();
            Data.CCRMEngineersGroupMasterID = $('#CCRMEngineersGroupMasterID').val();
            Data.CCRMAreaPatchMasterID = $('#CCRMAreaPatchMasterID').val();
            Data.CountryID = $('#CountryID').val();
            Data.StateID = $('#StateID').val();
            Data.CityID = $('#CityID').val();
            Data.Category = $('#Category').val();
            Data.CCRMLocationTypeID = $('#CCRMLocationTypeID').val();
            Data.Priority = $('#Priority').val();
            Data.InstalledById = $('#InstalledById').val();
            Data.ServiceEngID = $('#ServiceEngID').val();
            Data.CollExecId = $('#CollExecId').val();
            Data.ISPrinter = $('#ISPrinter').val();
            Data.ISScanner = $('#ISScanner').val();
            Data.ISFax = $('#ISFax').val();
            Data.Others = $('#Others').val();
            Data.WarantyInDays = $('#WarantyInDays').val();
            Data.WarantyExpiryDate = $('#WarantyExpiryDate').val();
            Data.Status = $('#Status').val();
            Data.InactiveDate = $('#InactiveDate').val();
            Data.Remarks = $('#Remarks').val();

            Data.CustomerContactDetailsID = $('#CustomerContactDetailsID').val();
            Data.ItemNumber = $('#ItemNumber').val();
            Data.ItemDescription = $('#ItemDescription').val();
            Data.AreaPatchName = $('#CCRMAreaPatchMasterID').val();
            Data.EmailCorporate = $('#EmailCorporate').val();
            Data.EmailAccounts = $('#EmailAccounts').val();
            Data.Emailservices = $('#Emailservices').val();
            Data.KeyOperatorName = $('#KeyOperatorName').val();
            Data.PhoneNo = $('#PhoneNo').val();
            Data.MobileNo = $('#MobileNo').val();
            // Data.SelectedContactDetailsIDs = $('#SelectedContactDetailsIDs').val();
           // Data.SelectedContactDetailsIDs = CCRMMIFMasterAndDetails.SelectedContactDetailsIDs;
           // Data.Description = $('#Description').val();
            Data.RegionName = $('#RegionName').val();
           
        }
        else if (CCRMMIFMasterAndDetails.ActionName == "Delete") {
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

            CCRMMIFMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMMIFMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMMIFMasterAndDetails.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {

    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        CCRMMIFMasterAndDetails.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

