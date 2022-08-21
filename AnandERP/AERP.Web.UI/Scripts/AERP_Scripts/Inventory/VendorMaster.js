//this class contain methods related to nationality functionality
var VendorMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        flag:true
        VendorMaster.constructor();
        //VendorMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#MovementType').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });

        $('#VendorRestriction').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('input[id^=LeadTime]').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        $('#LeadTime').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });
        // Create new recordbtn

        $('#CreateVendorMasterRecordExcel').on("click", function () {

            VendorMaster.ActionName = "UploadExcel";
            VendorMaster.AjaxCallVendorMaster();
        });
        //$('#CreateVendorMasterRecord').on("click", function () {

        //   VendorMaster.ActionName = "Create";
        //    VendorMaster.AjaxCallVendorMaster();
        //});
        
        $('#EditVendorMasterRecord').on("click", function () {

            VendorMaster.ActionName = "Edit";
            VendorMaster.AjaxCallVendorMaster();
        });

        $('#DeleteVendorMasterRecord').on("click", function () {

            VendorMaster.ActionName = "Delete";
            VendorMaster.AjaxCallVendorMaster();
        });

      
        //$('#PhoneNumber').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        $('#ContactPersonMobNumber').on("keydown", function (e) {
            //    AERPValidation.AllowNumbersOnly(e);
        });
        
       
    

        $('#DeleteVendor').unbind('click').on('click', function () {
            var VendorID = $('#VendorID').val();
            if (VendorID == '' || VendorID == 0) {
                notify('Please select Vendor', 'warning');
                return false;
            }
            $.ajax(
            {
                cache: false,
                type: "GET",
                dataType: "json",
                data: { "VendorID": VendorID },
                url: '/VendorMaster/Delete',
                success: function (result) {
                    var splitData = result.split(',');

                    if (splitData[1] == 'success') {

                        $("#VendorNumber").val("0");
                        $("#VendorName").val("");
                        $("#GeneralData").click();
                    }
                    notify(splitData[0], splitData[1]);
                }
            });
        });



        $('#btnAdd2').unbind("click").on("click", function () {
            debugger;
            //Email ID validation
            //if ($("#EmailID").val() != null || $("#EmailID").val() != "") {
            //    function ValidateEmail(email) {

            //        var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            //        return expr.test(email);
            //    };

            //    if (!ValidateEmail($("#EmailID").val())) {

            //        notify("Please Check Email ID.", "danger");
            //        return false;
            //    }
            //    else { var a = 0 }
            //}
            if ($("#CPFirstName").val() == "" || $("#CPFirstName").val() == null) {
                $("#displayErrorMessage p").text("Please Enter First Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($("#CPLastName").val() == "" || $("#CPLastName").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Last Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
           else if ($("#ContactPersonMobNumber").val() == "" || $("#ContactPersonMobNumber").val() == null) {
               $("#displayErrorMessage p").text("Please Enter Mobile Number.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
           else if ($("#EmailID").val() == "" || $("#EmailID").val() == null) {
               $("#displayErrorMessage p").text("Please Enter Email ID.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
           else if ($("#PersonDesgDesc").val() == "" || $("#PersonDesgDesc").val() == null) {
               $("#displayErrorMessage p").text("Please Enter Designation.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
               return false;
           }
           else {
               var ContactPersonMobNumber = $('#ContactPersonMobNumber').val();
               if (!/^[0-9-_+ ]+$/.test(ContactPersonMobNumber)) {
                   $('#DataValidationMessageForContactPersonMobNumber').text("Please enter Valid Mobile Number.").css("color", "red");
                   return false;
               }
           }
            $('#DataValidationMessageForContactPersonMobNumber').text("");
          
               if ($('#ContactPersonMobNumber').val() != "" && $('#EmailID').val() && $('#CPFirstName').val() != "" && $('#PersonDesgDesc').val() != "" && $('#CPLastName').val() != "") {
                   $("#tblData tbody").append(
                                            "<tr>" +
                                            "<td style=display:none><input id='VendorContactPersoninfoID' type='hidden' value=0 style='display:none' />" + $('#VendorContactPersoninfoID').val() + "</td>" +
                                            "<td style=display:none><input id='VendorID' type='hidden' value='" + $('#VendorID').val() + "' style='display:none' />" + $('#VendorID').val() + "</td>" +
                                            "<td><input id='CPFirstName' type='text' value='" + $('#CPFirstName').val() + "' style='display:none' />" + $('#CPFirstName').val() + "</td>" +
                                            "<td><input id='CPMiddleName' type='text' value='" + $('#CPMiddleName').val() + "' style='display:none' />" + $('#CPMiddleName').val() + "</td>" +
                                            "<td><input id='CPLastName' type='text' value='" + $('#CPLastName').val() + "' style='display:none' />" + $('#CPLastName').val() + "</td>" +
                                            "<td><input id='ContactPersonMobNumber' type='text' value='" + $('#ContactPersonMobNumber').val() + "' style='display:none' /> " + $('#ContactPersonMobNumber').val() + "</td>" +
                                             "<td><input id='EmailID' type='text' value='" + $('#EmailID').val() + "' style='display:none' /> " + $('#EmailID').val() + "</td>" +
                                              "<td><input id='PersonDesgDesc' type='text' value='" + $('#PersonDesgDesc').val() + "' style='display:none' /> " + $('#PersonDesgDesc').val() + "</td>" +
                                              //"<td><input id='PersonDesg' type='text' value='" + $('#PersonDesg').val() + "' style='display:none' /> " + $('#PersonDesg :selected').text() + "</td>" +
                                             "<td><i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                            "</tr>");

                   $("#CPFirstName").val("");
                   $("#CPMiddleName").val("");
                   $("#CPLastName").val("");
                   $("#ContactPersonMobNumber").val("");
                   $("#EmailID").val("");
                   $("#PersonDesgDesc").val("");
               }
           

               $("#tblData tbody").on("click", "tr td i", function () {
                   $(this).closest('tr').remove();
               });
           
        });
    
        $('#btnAdd').on("click", function () {

            if ($("#MerchandiseCategory").val() == "" || $("#MerchandiseCategory").val() == null) {
                $("#displayErrorMessage p").text("Please Select Merchandise Category").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($("#LeadTime").val() == "" || $("#LeadTime").val() == 0 || $("#LeadTime").val() == '.') {
                $("#displayErrorMessage p").text("Please Enter Lead Time").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
           
            //Code for duplicate entry validation//
            var cnt = 0;
            var DataArray = [];
            var data = $('#tblData1 tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 4) {


                if (DataArray[i + 2] == $('#MerchandiseCategory').val()) {
                    $("#displayErrorMessage p").text("You Cannot Enter the Same Category.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#MerchandiseCategory").val("");
                    $("#LeadTime").val("");
                    return false;
                }

            }

            if ($('#MerchandiseCategory').val() != "" && $('#LeadTime').val() != "") {
                $("#tblData1 tbody").append(
                                         "<tr>" +
                                         "<td style=display:none><input id='VendorReplenishmentInfoID' type='hidden' value=0 style='display:none' />" + $('#VendorReplenishmentInfoID').val() + "</td>" +
                                         "<td style=display:none><input id='VendorID' type='hidden' value='" + $('#VendorID').val() + "' style='display:none' />" + $('#VendorID').val() + "</td>" +
                                         "<td><input id='Name' type='text' value='" + $('#MerchandiseCategory').val() + "' style='display:none' />" + $('#MerchandiseCategory').val() + "</td>" +
                                         //"<td><input type='text' value='" + $('#LeadTime').val() + "' style='display:none' /> " + $('#LeadTime').val() + "</td>" +
                                          "<td><input id='LeadTime' class='form-control' type='text' value=" + $('#LeadTime').val() + " style=''/></td>" +
                                         "<td><i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                         "</tr>");

                $("#MerchandiseCategory").val("");
                $("#LeadTime").val("");
            }

            $("#tblData1 tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

        });

        $("#MyFile").change(function () {

            ////  var filename = "OptionImageFile";
            //var MyFileType = $('#MyFile')[0].files[0].type;
            //var Extension = MyFileType.split('/');
            //MyFileFileName = $('#MyFile')[0].files[0].name;
            var file = $('#MyFile')[0].files[0];
            var MyFileFileName = file.name;
            var Extension = '.' + MyFileFileName.split('.').pop();
            if (MyFileFileName != "" && MyFileFileName != "undefined") {

                if (Extension == ".xls" || Extension == ".xlsx") {
                    var a = "";
                }
                else {
                    $("#displayErrorMessagee p").text("Option excel only allows file types of xls and xlsx.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#MyFile").replaceWith($("#MyFile").val('').clone(true));
                    return false;
                }
            }
            else {
                alert();
                $("#displayErrorMessagee p").text("The selected file does not appear to be an excel file.").closest('div').fadeIn().closest('div').addClass('alert-' + "success");

                $("#MyFile").replaceWith($("#MyFile").val('').clone(true));

            }
        });

        InitAnimatedBorder();

        CloseAlert();

     },
    Save: function () {
        $('#SaveVendorMasterRecord').on("click", function () {
            var val = $('#VendorName').val();
            if (!/^[a-zA-Z0-9_/&',.() ]+$/.test(val)) {
                $('#DataValidationMessageForVendorName').text("Please enter alpha-numeric text.").css("color", "red");
                return false;
            }

            VendorMaster.ActionName = "Save";
            var TaskCode = $('#TaskCode').val();
            if (TaskCode == 'GeneralData') {

                $('#DataValidationMessageForVendorName').text("");
                if ($('#State').val() == "" || $('#State').val() == null) {
                    $('#DataValidationMessageForState').text("Please enter State.").css("color", "red");
                    return false;
                }
                $('#DataValidationMessageForState').text("");

                var MobileNumber = $('#MobileNumber').val();
                if (!/^[0-9-_+ ]+$/.test(MobileNumber)) {
                    $('#DataValidationMessageForMobileNumber').text("Please enter Valid Mobile Number.").css("color", "red");
                    return false;
                }
                $('#DataValidationMessageForMobileNumber').text("");

                var PhoneNumber = $('#PhoneNumber').val();
                if (!/^[0-9-_+ ]+$/.test(PhoneNumber)) {
                    $('#DataValidationMessageForPhoneNumber').text("Please enter Valid Phone Number.").css("color", "red");
                    return false;
                }
                $('#DataValidationMessageForPhoneNumber').text("");

               
                if($('#Country :selected').val() == null || $('#Country :selected').val() == "")
                {
                    notify("Please select country", "warning");
                    return false;
                }
                else if ($('#Currency :selected').val() == null || $('#Currency :selected').val() == "")
            {
                    
                    notify("Please select currency", "warning");
                    return false;
            }
               else
                {
                    VendorMaster.GetXmlData();
                    VendorMaster.AjaxCallVendorMaster();
                 }
            }
            else if (TaskCode == 'ReplenishmentData') {

                debugger;
                VendorMaster.GetXmlReplenishmentData();
                
                if (VendorMaster.XMLstring1 != null && VendorMaster.XMLstring1 != "") {
                    VendorMaster.AjaxCallVendorMaster();
                }
                else
                    {
                    notify("Please Enter Data","warning")
                    return false;
                }
            }
            if (TaskCode == 'FinanceData') {
               
                VendorMaster.AjaxCallVendorMaster();
            }
           
            
          
        });
    },
    CreateTab: function () {
        $('ul#TaskList li').click(function () {
            var Newurl = '';
            var TaskCode = $(this).attr('id');
            var VendorID = $('input[name=VendorID]').val();
            var VendorNumber = $("#VendorNumber").val();

            if (TaskCode == "GeneralData") {
                Newurl = '/VendorMaster/GeneralData';
            }
            else if (TaskCode == "ReplenishmentData") {
                Newurl = '/VendorMaster/ReplenishmentData';
            }
            else if (TaskCode == "FinanceData") {
                Newurl = '/VendorMaster/FinanceData';
            }
            
            $.ajax(
                  {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: { "TaskCode": TaskCode, "VendorID": VendorID, "VendorNumber": VendorNumber },
                      url: Newurl,
                      success: function (result) {
                          //alert(result);
                          $('.tab-content').html(result);
                      }
                  });

        });
    },
    Create: function () {
        $('#CreateVendorMasterRecord').on("click", function () {


            var val = $('#VendorName').val();
            if (!/^[a-zA-Z0-9_/&',.() ]+$/.test(val)) {
                $('#DataValidationMessageForVendorName').text("Please enter alpha-numeric text.").css("color", "red");
                return false;
            }
            VendorMaster.ActionName = "Create";
            
            var TaskCode = $('#TaskCode').val();
           
            if (TaskCode == 'GeneralData') {
                $('#DataValidationMessageForVendorName').text("");
                if ($('#State').val() == "" || $('#State').val() == null)
                {
                    $('#DataValidationMessageForState').text("Please enter State.").css("color", "red");
                    return false;
                }
                $('#DataValidationMessageForState').text("");

                var MobileNumber = $('#MobileNumber').val();
                if (!/^[0-9-_+ ]+$/.test(MobileNumber)) {
                    $('#DataValidationMessageForMobileNumber').text("Please enter Valid Mobile Number.").css("color", "red");
                    return false;
                }
                $('#DataValidationMessageForMobileNumber').text("");

                var PhoneNumber = $('#PhoneNumber').val();
                if (!/^[0-9-_+ ]+$/.test(PhoneNumber)) {
                    $('#DataValidationMessageForPhoneNumber').text("Please enter Valid Phone Number.").css("color", "red");
                    return false;
                }
                $('#DataValidationMessageForPhoneNumber').text("");

                VendorMaster.GetXmlData();
                VendorMaster.AjaxCallVendorMaster();
            }
            else if (TaskCode == 'ReplenishmentData') {

                debugger;
                VendorMaster.GetXmlReplenishmentData();

                if (VendorMaster.XMLstring1 != null && VendorMaster.XMLstring1 != "") {
                    VendorMaster.AjaxCallVendorMaster();
                }
                else {
                    notify("Please Enter Data", "warning")
                    return false;
                }
            }
            if (TaskCode == 'FinanceData') {

                VendorMaster.AjaxCallVendorMaster();
            }
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
             url: '/VendorMaster/List',
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
            url: '/VendorMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    GetXmlData: function () {
        debugger;
        var DataArray = [];
        var data = $('#tblData tbody tr td  input').each(function () {
            
                DataArray.push($(this).val());
        });
      //alert(DataArray)
        var TotalRecord = DataArray.length;
        debugger;
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 8) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><VendorContactPersoninfoID>" + DataArray[i] + "</VendorContactPersoninfoID><VendorID>" + DataArray[i + 1] + "</VendorID><ContactPersonFirstName>" + DataArray[i + 2] + "</ContactPersonFirstName><ContactPersonMiddleName>" + DataArray[i + 3] + "</ContactPersonMiddleName><ContactPersonLastName>" + DataArray[i + 4] + "</ContactPersonLastName><ContactPersonMobNo>" + DataArray[i + 5] + "</ContactPersonMobNo><ContactPersonEmailID>" + (DataArray[i + 6]) + "</ContactPersonEmailID><Designation>" + (DataArray[i + 7]) + "</Designation></row>";
        }
        debugger;
        if (ParameterXml.length > 9)
            VendorMaster.XMLstring = ParameterXml + "</rows>";
        else
            VendorMaster.XMLstring = "";
       // alert(VendorMaster.XMLstring)


    },
    GetXmlReplenishmentData: function () {
        
        var DataArray = [];
        VendorMaster.flag = true;
        var data = $('#tblData1 tbody tr td  input').each(function () {

            DataArray.push($(this).val());
        });
       // alert(DataArray)
        var TotalRecord = DataArray.length;

        var ParameterXml1 = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 4) {
            ParameterXml1 = ParameterXml1 + "<row><ID>" + 0 + "</ID><VendorReplenishmentInfoID>" + DataArray[i] + "</VendorReplenishmentInfoID><VendorID>" + DataArray[i + 1] + "</VendorID><CategoryCode>" + DataArray[i + 2] + "</CategoryCode><LeadTime>" + DataArray[i + 3] + "</LeadTime></row>";
        }
        debugger;
        if (ParameterXml1.length > 7)
            VendorMaster.XMLstring1 = ParameterXml1 + "</rows>";
        else
            VendorMaster.XMLstring1 = "";



    },
    //Fire ajax call to insert update and delete record

    AjaxCallVendorMaster: function () {
        var VendorMasterData = null;

        if (VendorMaster.ActionName == "Create") {
            debugger;
            $("#FormCreateVendorMaster").validate();
            if ($("#FormCreateVendorMaster").valid()) {
                VendorMasterData = null;
                VendorMasterData = VendorMaster.GetVendorMaster();
                ajaxRequest.makeRequest("/VendorMaster/Create", "POST", VendorMasterData, VendorMaster.Success, "CreateVendorMasterRecord");
            }
        }
        else if (VendorMaster.ActionName == "Save") {

            $("#FormCreateVendorMaster").validate();
            if ($("#FormCreateVendorMaster").valid()) {
                VendorMasterData = null;
                VendorMasterData = VendorMaster.GetVendorMaster();

                ajaxRequest.makeRequest("/VendorMaster/Create", "POST", VendorMasterData, VendorMaster.SaveSuccess, "SaveVendorMasterRecord");

            }
        }
        else if (VendorMaster.ActionName == "UploadExcel") {

            $("#FormCreateVendorMasterExcel").validate();
            if ($("#FormCreateVendorMasterExcel").valid()) {
                VendorMasterData = null;
                VendorMasterData = VendorMaster.GetVendorDetails();

                ajaxRequest.makeRequest("/VendorMaster/UploadExcel", "POST", VendorMasterData, VendorMaster.SaveSuccess, "CreateVendorMasterRecordExcel");

            }
        }
        else if (VendorMaster.ActionName == "Edit") {
            $("#FormEditVendorMaster").validate();
            if ($("#FormEditVendorMaster").valid()) {
                VendorMasterData = null;
                VendorMasterData = VendorMaster.GetVendorMaster();
                ajaxRequest.makeRequest("/VendorMaster/Edit", "POST", VendorMasterData, VendorMaster.Success);
            }
        }
        else if (VendorMaster.ActionName == "Delete") {

            VendorMasterData = null;
            //$("#FormCreateVendorMaster").validate();
            VendorMasterData = VendorMaster.GetVendorMaster();
            ajaxRequest.makeRequest("/VendorMaster/Delete", "POST", VendorMasterData, VendorMaster.Success);

        }
    },
    //Get property for excel upload
    GetVendorDetails: function () {
        var Data = {
        };
        if (VendorMaster.ActionName == "UploadExcel") {

           
            var data = new FormData();
            var files = $("#MyFile").get(0).files;
            if (files.length > 0) {
                data.append("MyFile", files[0]);
                $.ajax({
                    url: "/VendorMaster/UploadExcelFile",
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
    GetVendorMaster: function () {
        var Data = {
        };

        if (VendorMaster.ActionName == "Create" || VendorMaster.ActionName == "Edit" || VendorMaster.ActionName == "Save") {
            debugger;
            Data.ID = $('#ID').val();
            Data.VendorNumber = $('#VendorNumber').val();
            Data.VendorName = $('#VendorName').val();
            Data.VendorID = $('#VendorID').val();
            Data.TaskCode = $('#TaskCode').val();
            Data.VendorContactPersoninfoID = $('#VendorContactPersoninfoID').val();
            Data.VendorReplenishmentInfoID = $('#VendorReplenishmentInfoID').val();

            if (Data.TaskCode == 'GeneralData')
              {
                Data.Address1 = $('#Address1').val();
                Data.Address2 = $('#Address2').val();
                Data.Address3 = $('#Address3').val();
                Data.Country = $('#Country').val();
                Data.Currency = $('#Currency').val();
                Data.PhoneNumber = $('#PhoneNumber').val();
                Data.MobileNumber = $('#MobileNumber').val();
                Data.XMLstring = VendorMaster.XMLstring;
                Data.VendorID = $('#VendorID').val();
                Data.TaskCode = $('#TaskCode').val();
                Data.VendorNumber = $('#VendorNumber').val();
                Data.City = $('#City').val();
                Data.CityId = $('#City').val();
                Data.State = $('#State').val();
                Data.PinCode = $('#PinCode').val();
                Data.FirstName = $('#FirstName').val();
                Data.MiddleName = $('#MiddleName').val();
                Data.LastName = $('#LastName').val();
                Data.State = $('#State').val();
                Data.IsCentre = $('#IsCentre').is(":checked") ? "true" : "false";
                Data.CentreCode = $('#CentreCode').val();
            }
            else if (Data.TaskCode == 'FinanceData')
            {
                Data.CreditLimit = $('#CreditLimit').val();
                Data.Incoterms = $('#Incoterms').val();
                Data.AccountNo = $('#AccountNo').val();
                Data.BankName = $('#BankName').val();
                Data.BranchName = $('#BranchName').val();
                Data.BankAddress = $('#BankAddress').val();
                Data.IFSCCode = $('#IFSCCode').val();
                Data.VendorID = $('#VendorID').val();
                Data.VendorFinanceDetailsID = $('#VendorFinanceDetailsID').val();
                Data.TaskCode = $('#TaskCode').val();
                Data.CashDiscount = $('#CashDiscount').val();
                Data.Rebate = $('#Rebate').val();
                Data.CashOnDelivery = $('#CashOnDelivery').is(":checked") ? "true" : "false";
                Data.CurrentDatedCheque = $('#CurrentDatedCheque').is(":checked") ? "true" : "false";
                Data.Credit = $('#Credit').is(":checked") ? "true" : "false";
            }
            else  
             {
                Data.XMLstring1 = VendorMaster.XMLstring1;
                Data.VendorID = $('#VendorID').val();
                Data.TaskCode = $('#TaskCode').val();
                Data.VendorNumber = $('#VendorNumber').val();
                Data.VendorRestriction = parseFloat($('#VendorRestriction').val()).toFixed(2);
                Data.ReturnGoods = $('#ReturnGoods').is(":checked") ? "true" : "false";
                Data.Currency = $('#Currency').val();
             }
      }
        
        else if (VendorMaster.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        

        var splitData = data.errorMessage.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            VendorMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
    SaveSuccess: function (data) {
        debugger;
        var splitData = data.errorMessage.split(',');
        //var splitData = data.split(',');
        if (data.VendorID == 0) {

            $("#VendorNumber").val(data.VendorNumber);
            $("#VendorID").val(data.ID);
        //    alert($("#VendorID").val())
        //    alert($("#VendorNumber").val())
        }
        if (splitData[1] == 'success') {
            notify(splitData[0], splitData[1]);
            var TaskCode = data.TaskCode;
            if (TaskCode == 'GeneralData') {
               // GeneralItemMaster.ResetGeneralUnitsID = data.GeneralUnitsID;
            }
          
            $("#" + TaskCode).click();
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
//       VendorMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        VendorMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


