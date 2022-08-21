//this class contain methods related to nationality functionality
var CCRMCallClosure = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMCallClosure.constructor();
        //CCRMCallClosure.initializeValidation();
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
        $('#CreateCCRMCallClosureRecord').on("click", function () {
            CCRMCallClosure.ActionName = "Create";
            CCRMCallClosure.AjaxCallCCRMCallClosure();
            
        });

        $('#EditCCRMCallClosureRecord').on("click", function () {
            debugger;
            CCRMCallClosure.ActionName = "Edit";
            CCRMCallClosure.GetXmlData();
            //if (CCRMCallClosure.ParameterXml == "" || CCRMCallClosure.ParameterXml == null) {
            //    $("#displayErrorMessage p").text("No Data Available in table.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    return false;
            //}
            //else {
                CCRMCallClosure.AjaxCallCCRMCallClosure();
           // }
          
        });

        $('#DeleteCCRMCallClosureRecord').on("click", function () {

            CCRMCallClosure.ActionName = "Delete";
            CCRMCallClosure.AjaxCallCCRMCallClosure();
        });
        //$('#ActionTitle').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        //$('#FeedbackPoints').on("keydown", function (e) {
        //    AERPValidation.AllowNumbersOnly(e);
        //});
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });
        $('#ArrivalDate').datetimepicker({
            format: 'DD MMM YYYY hh:mm',
           // minDate: moment(),
            ignoreReadonly: true,
            // format: 'DD MMM YYYY',
            //allowInputToggle: true
            // maxDate: moment(),
           // inline: true,
            // sideBySide: true
        });
        $('#CompletionDate').datetimepicker({
            format: 'DD MMM YYYY hh:mm',
           // maxDate: moment(),
            ignoreReadonly: true,
          //  inline: true,
            // sideBySide: true
        });
        
        $('#JobstartDate').datetimepicker({
            format: 'DD MMM YYYY hh:mm',
           // inline: true,
            // sideBySide: true
            
        });
        $('#CallStatus').on('change', function () {
            if ($(this).val() == '1') {
                $("#dvResonCode").hide();
            }
            else {
                $("#dvResonCode").show();
            }
        });
  
        $("#JobstartDate").on("dp.change", function (e) {
          //  $('#JobEndDate').data("DateTimePicker").minDate(e.date);
        });
        $("#JobEndDate").on("dp.change", function (e) {
            debugger;
            var d2 = new Date("#JobEndDate");
            var d1 = new Date("#JobstartDate");
            $("#JobPeriod").html("Diff. Seconds : " + ((d2 - d1) / 100).toString());
        });
        $('#JobEndDate').datetimepicker({
            format: 'DD MMM YYYY hh:mm',
          //  inline: true,
            // sideBySide: true
           
        });
       
        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();
      //  Data Apend//
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
            for (var i = 0; i < TotalRecord; i = i + 6) {
                if (DataArray[i + 0] == $('#ItemNumber').val() && DataArray[i + 4] == $('#Requierd').val()) {
                    $("#displayErrorMessage ").text("You Cannot Enter the same item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");

                    $("#ItemName").val("");
                    $('#ItemName').typeahead('val', '');
                    $("#ItemNumber").val(0);
                    $("#ItemCategoryCode").val("");
                    $("#Quantity").val(0);
                   // $("#Requierd").val("");
                    $("#ItemName").focus();
                    return false
                }
            }


            //End Of Code for Duplication of Item



           // var i = 0;

            //if ($("#ItemName").val() == null || $("#ItemName").val() == "") {
            //    $("#displayErrorMessage ").text("Please Enter Item Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
            //    return false;
            //}
            //else if ($("#Quantity").val() == 0 || $("#Quantity").val() == "") {
            //    $("#displayErrorMessage ").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
            //    return false;
            //}
            //else if ($("#Requierd").val() == null || $("#Requierd").val() == "") {
            //    $("#displayErrorMessage ").text("Please Select Requierd.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "warning");
            //    return false;
            //}
           
       
            if ($('#ItemName').val() != "" && $('#ItemName').val() != null) {
                //Code For IsBase Uom Check box Ends

                $("#tblData tbody").append(
                                     "<tr>" +
                                      "<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                                     "<td><input id='ItemName' type='text' value=" + $('#ItemName').val() + " style='display:none' />" + $('#ItemName').val() + "</td>" +
                                        "<td><input id='ItemCategoryCode' type='text' value=" + $('#ItemCategoryCode').val() + " style='display:none' />" + $('#ItemCategoryCode').val() + "</td>" +
                                    "<td><input id='Quantity' type='text' value=" + $('#Quantity').val() + " style='display:none' />" + $('#Quantity').val() + "</td>" +
                                     "<td ><input type='text' value=" + $('#Requierd').val() + " style='display:none' /> " + $('#Requierd :Selected').text() + "</td>" +
                                      "<td style=display:none><input id='ID' type='hidden'  value=0  style='display:none' />" + $('#ID').val() + "</td>" +
                                     "<td> <i class='zmdi zmdi-delete zmdi-hc-fw ENQDetail' style='cursor:pointer'' title = Delete ></td>" +
                                     "</tr>"
                                    );

                $("#ItemName").val("");
                $('#ItemName').typeahead('val', '');
                $("#ItemNumber").val(0);
                $("#ItemCategoryCode").val("");
                $("#Quantity").val(0);
                $("#Requierd").val("");
               
               
            }

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i.ENQDetail", function () {
                $(this).closest('tr').remove();
            });

        });

    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/CCRMCallClosure/List',
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
            url: '/CCRMCallClosure/List',
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
      

        var ParameterXml = "<rows>";
       
        for (var i = 0; i < TotalRecord; i = i + 6) {

            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i + 5] + "</ID><ItemNumber>" + DataArray[i + 0] + "</ItemNumber><ItemName>" + DataArray[i + 1] + "</ItemName><ItemCategoryCode>" + DataArray[i + 2] + "</ItemCategoryCode><Quantity>" + DataArray[i + 3] + "</Quantity><Requierd>" + DataArray[i + 4] + "</Requierd></row>";

        }
         //alert(ParameterXml);
        if (ParameterXml.length > 10)
            CCRMCallClosure.ParameterXml = ParameterXml + "</rows>";

        else
            CCRMCallClosure.ParameterXml = "";
        // alert(CustomerMaster.ParameterXml)
    },

    //Fire ajax call to insert update and delete record
    AjaxCallCCRMCallClosure: function () {
        var CCRMCallClosureData = null;
        if (CCRMCallClosure.ActionName == "Create") {
            $("#FormCreateCCRMCallClosure").validate();
            if ($("#FormCreateCCRMCallClosure").valid()) {
                CCRMCallClosureData = null;
                CCRMCallClosureData = CCRMCallClosure.GetCCRMCallClosure();
                ajaxRequest.makeRequest("/CCRMCallClosure/Create", "POST", CCRMCallClosureData, CCRMCallClosure.Success);
            }
        }
        else if (CCRMCallClosure.ActionName == "Edit") {
            debugger;
            $("#FormEditCCRMCallClosure").validate();
            if ($("#FormEditCCRMCallClosure").valid()) {
                CCRMCallClosureData = null;
                CCRMCallClosureData = CCRMCallClosure.GetCCRMCallClosure();
                ajaxRequest.makeRequest("/CCRMCallClosure/Editdata", "POST", CCRMCallClosureData, CCRMCallClosure.Success, "EditCCRMCallClosureRecord");
            }
        }
        else if (CCRMCallClosure.ActionName == "Delete") {
            CCRMCallClosureData = null;
            //$("#FormCreateCCRMCallClosure").validate();
            CCRMCallClosureData = CCRMCallClosure.GetCCRMCallClosure();

            ajaxRequest.makeRequest("/CCRMCallClosure/Delete", "POST", CCRMCallClosureData, CCRMCallClosure.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMCallClosure: function () {

        var Data = {
        };
        if (CCRMCallClosure.ActionName == "Create" || CCRMCallClosure.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();

            Data.CallTktNo = $('#CallTktNo').val();
            Data.CallDate = $('#CallDate').val();
            Data.SerialNo = $('#SerialNo').val();
            Data.ModelNo = $('#ModelNo').val();
            Data.MIFName = $('#MIFName').val();
            Data.MIFID = $('#MIFID').val();
            Data.SymptomID = $('#SymptomID').val();
            Data.SymptomTitle = $('#SymptomTitle').val();
            Data.CallerName = $('#CallerName').val();
           // Data.CallerPh = $('#CallerPh').val();
          // Data.SRDate = $('#SRDate').val();
           // Data.CallCloseDate = $('#CallCloseDate').val();
            Data.EngineerID = $('#EngineerID').val();
            Data.EnggName = $('#EmployeeName').val();
           // Data.CallId = $('#CallId').val();
            Data.ContractType = $('#ContractCode').val();
            Data.ContractTypeID = $('#ContractTypeID').val();
            Data.ComPlaint = $('#ComPlaint').val();
            //Data.DispDate = $('#DispDate').val();
            Data.ArrivalDate = $('#ArrivalDate').val();
            Data.CompletionDate = $('#CompletionDate').val();
            Data.ArrivalPeriod = $('#ArrivalPeriod').val();
            Data.CompletionPeriod = $('#CompletionPeriod').val();
            Data.A4Mono = $('#A4Mono').val();
            Data.A4Col = $('#A4Col').val();
            Data.A3Mono = $('#A3Mono').val();
            Data.A3Col = $('#A3Col').val();
            Data.CallStatus = $('#CallStatus').val();
            Data.SymptomID = $('#SymptomID').val();
            Data.SymptomCode = $('#SymptomCode').val();
            Data.CauseID = $('#CauseID').val();
            Data.CauseCode = $('#CauseCode').val();
            Data.ActionID = $('#ActionID').val();
            Data.ActionCode = $('#ActionCode').val();
            Data.Symptom = $('#Symptom').val();
            Data.CauseTitle = $('#CauseTitle').val();
            Data.ActionTitle = $('#ActionTitle').val();
            Data.SignedBy = $('#SignedBy').val();
            Data.PhoneNo = $('#PhoneNo').val();
            Data.Remarks = $('#Remarks').val();
            Data.FeedbackID = $('#FeedbackID').val();
            Data.Feedback = $('#Feedback').val();
           // Data.ItemDescription = $('#ItemDescription').val();
            Data.AllotDate = $('#AllotDate').val();
            Data.AllotPeriod = $('#AllotPeriod').val();
            Data.SymptomDescrip = $('#SymptomDescrip').val();
            Data.CauseDescrip = $('#CauseDescrip').val();
            Data.ActionDescrip = $('#ActionDescrip').val();
            Data.SCNSubmitted = $('input[id=SCNSubmitted]:checked').val() ? true : false;
           // Data.CentreCode = $('#CentreCode').val();
            //Data.AdminRoleMasterID = $('#AdminRoleMasterID').val();
            //Data.RightName = $('#RightName').val();
            //Data.EmployeeID = $('#EmployeeID').val();
            //Data.EmployeeCode = $('#EmployeeCode').val();
           // Data.ReasonCode = $('#ReasonCode').val();
            Data.ReasonCode = $('#ReasonCode :selected').text();
            if (Data.CallStatus == 1) {
                Data.ReasonCode = '';
            }
            else {
                Data.ReasonCode = $('#ReasonCode :selected').text();
            }
            Data.EmployeeName = $('#EmployeeName').val();
            Data.CurrentReadA4Mono = $('#CurrentReadA4Mono').val();
            Data.CurrentReadA4Col = $('#CurrentReadA4Col').val();
            Data.CurrentReadA3Mono = $('#CurrentReadA3Mono').val();
            Data.CurrentReadA3Col = $('#CurrentReadA3Col').val();
            Data.JobstartDate = $('#JobstartDate').val();
            Data.JobEndDate = $('#JobEndDate').val();
            Data.XmlString = CCRMCallClosure.ParameterXml;
        }
        else if (CCRMCallClosure.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        debugger;
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMCallClosure.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMCallClosure.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMCallClosure.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMCallClosure.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

