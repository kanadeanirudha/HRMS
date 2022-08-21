//this class contain methods related to nationality functionality
var PurchaseRequirementMaster = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    map: {},
    map2: {},
    BlockForProcurement: false,
    flag: true,
    RequestFlag:true,
    //Class intialisation method
    Initialize: function () {
        PurchaseRequirementMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //if ($('input[name=errorMessage]').val() != "NoMessage") {
        //    var splitedMsg = ($('input[name=errorMessage]').val()).split(',');
        //    $('#SuccessMessage').html(splitedMsg[0]);
        //    $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', splitedMsg[1]);
        //    $('input[name=errorMessage]').val("NoMessage");
        //}

        // if policy default answer is 1 means backdated date is allowed. else only current and forwared date is allowed.
        if ($("#PolicyDefaultAnswer").val() == 1) {
            //$('#TransDate').datepicker({
            //    dateFormat: 'd M yy',
            //    changeMonth: true,
            //    changeYear: true,
            //    yearRange: '1915:document.write(currentYear.getFullYear()',

            //})
            $('#TransDate').datetimepicker({
                format: 'DD MMMM YYYY',
                minDate: moment(),
                ignoreReadonly: true,
            })


        }
        else {
            //$('#TransDate').datepicker({
            //    dateFormat: 'd M yy',
            //    changeMonth: true,
            //    changeYear: true,
            //    yearRange: '1915:document.write(currentYear.getFullYear()',
            //    minDate: 0,
            //})

            $('#TransDate').attr("readonly", true);

            $('#TransDate').datetimepicker({
                format: 'DD MMMM YYYY',
                //maxDate: moment(),
                ignoreReadonly: true,
            })


        }
        if ($("#PolicyDefaultAnswerForExcel").val() == 1) {
            //$('#TransDate').datepicker({
            //    dateFormat: 'd M yy',
            //    changeMonth: true,
            //    changeYear: true,
            //    yearRange: '1915:document.write(currentYear.getFullYear()',

            //})

            $('#TransDate').datetimepicker({
                format: 'DD MMMM YYYY',
                minDate: moment(),
                ignoreReadonly: true,
            })

        }
        else {
            //$('#TransDate').datepicker({
            //    dateFormat: 'd M yy',
            //    changeMonth: true,
            //    changeYear: true,
            //    yearRange: '1915:document.write(currentYear.getFullYear()',
            //    minDate: 0,
            //})

            $('#TransDate').datetimepicker({
                format: 'DD MMMM YYYY',
                maxDate: moment(),
                ignoreReadonly: true,
            })



        }
        //$('#ExpectedDate').datepicker({
        //    dateFormat: 'd M yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()',
        //    minDate: 0,
        //})

        $('#ExpectedDate').datetimepicker({
            format: 'DD MMMM YYYY',
            minDate: moment(),
            ignoreReadonly: true,
        })

        $('#IconShowList').click(function () {
            //alert('here');
            $('#IconShowList').fadeOut();
            $('#IconShowPurchaseRequirement').fadeIn();
            //debugger;
            $.ajax(
           {
               cache: false,
               type: "Get",
               // data: { "selectedBalsheet": Balancesheet },
               dataType: "html",
               url: '/PurchaseRequirementMaster/List',
               success: function (data) {
                   //Rebind Grid Data
                   $('#divContent').empty();
                   $('#divContent').html(data);
                   $('#divContent').fadeIn("slow");
               }
           });
        });

        //  FOLLOWING FUNCTION IS SEARCHLIST OF item list
        //$("#ItemName").autocomplete({
        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/PurchaseRequirementMaster/GetItemSearchList",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, StorageLocationID: $("#StorageLocationID").val() },
        //            success: function (data) {
        //                response($.map(data, function (item) {
        //                    return { label: item.itemDescription, value: item.itemDescription, itemNumber: item.itemNumber, barCode: item.barCode, uomCode: item.uomCode, GenTaxGroupMasterID: item.GenTaxGroupMasterID, lastPurchasePrice: item.lastPurchasePrice, generalItemCodeID: item.generalItemCodeID, id: item.id };
        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {
        //        $(this).val(ui.item.label);                                             // display the selected text
        //        $("#ItemNumber").val(parseFloat(ui.item.itemNumber));
        //        $("#BarCode").val(ui.item.barCode);
        //        $("#UnitCode").val(ui.item.uomCode);
        //        $("#GenTaxGroupMasterID").val(ui.item.GenTaxGroupMasterID);
        //        $("#Rate").val(ui.item.lastPurchasePrice);
        //        $("#GeneralItemCodeID").val(ui.item.generalItemCodeID);
        //        //    $("#ItemID").val(ui.item.id);

        //    }
        //});

        /////////////new search functionality///////////////////////////////////
        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var valuStorageLocationID = $("#StorageLocationID").val();

                $.ajax({
                    url: "/PurchaseRequirementMaster/GetItemSearchList",
                    type: "POST",
                    data: { term: q, StorageLocationID: valuStorageLocationID },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.itemDescription)) {
                                PurchaseRequirementMaster.map[response.itemDescription] = response;
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
            //$("#ItemID").val(PurchaseRequirementMaster.map[item].id);

            $("#ItemNumber").val(parseFloat(PurchaseRequirementMaster.map[item].itemNumber));
            $("#BarCode").val(PurchaseRequirementMaster.map[item].barCode);
            $("#UnitCode").val(PurchaseRequirementMaster.map[item].uomCode);
            $("#GenTaxGroupMasterID").val(PurchaseRequirementMaster.map[item].GenTaxGroupMasterID);
            $("#Rate").val(PurchaseRequirementMaster.map[item].lastPurchasePrice);
            $("#GeneralItemCodeID").val(PurchaseRequirementMaster.map[item].generalItemCodeID);
            $("#MinimumOrderquantity").val(PurchaseRequirementMaster.map[item].MinimumOrderquantity);
            //    $("#ItemID").val(PurchaseRequirementMaster.map[item].id);
        });
        //end new search functionality


        // Create new record
        $('#addItem').on("click", function () {
            debugger;
            var a, b;
            if ($("#ItemName").val() == "") {
                notify("Please Enter Item Name.", "danger");
                $("#ItemName").focus();
                return false;
            }
            else if ($("#Quantity").val() == "")
            {
                notify("Please Enter Quantity.", "danger");
                return false;
            }
            //to check duplication of item while adding the item(Restrict Duplication of Item)
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
           
            TotalRecord = DataArray.length;
            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 7) {
                if (DataArray[i] == $('#GeneralItemCodeID').val() && DataArray[i + 5] == $('#StorageLocationID').val()) {
                    notify("You Cannot Enter the same item Twice.", "danger");
                    $("#ItemName").val("");
                    //  $("#ItemID").val(0);
                    $("#Quantity").val("");
                    $("#ExpectedDate").val("");
                    $("#PriorityFlag").val("");
                    $("#Rate").val("");
                    $("#Remark").val("");
                    $("#StorageLocationID").val("");
                    $("#ItemNumber").val("");
                    $("#BarCode").val("");
                    $("#GeneralItemCodeID").val(0);
                    $('#UnitCode').val("");
                    $("#ItemName").focus();
                    return false
                }
            }


            //End Of Code
            //******************* CODE FOR CALENDER********************//
            if ($("#ExpectedDate").val() == null || $("#ExpectedDate").val() == "" || $("#ExpectedDate").val() == "Invalid Date") {
                notify("Please Enter Expected Date.", "danger");
                $("#ExpectedDate").focus();
                return false;
            }

            var d = new Date($("#ExpectedDate").val());

            var curr_date = d.getDate();
            var curr_month = d.getMonth() + 1; //Months are zero based
            var curr_year = d.getFullYear();

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
                var aaaa = "<td ><input type='text' style='display:none'  value=" + ExpectedDate + " >" + $('#ExpectedDate').val() + "</td>"
            }

            //******************* CODE FOR CALENDER ENDS********************//
            //******************* CODE FOR  Priority Flag DROPDOWN ********************//
            var Priority = $("#PriorityFlag").val()
            if (Priority == 1) {
                Pr1 = "High";
            }
            else if (Priority == 2) {
                Pr1 = "Medium";
            }
            else if (Priority == 3) {
                Pr1 = "Low";
            }

            var Priority1 = "<td ><input type='text' style='display:none'  value=" + $("#PriorityFlag").val() + " />" + Pr1 + "</td>"

            //******************* CODE FOR  Priority Flag DROPDOWN ENDS ********************//
            debugger;
            debugger;

            var StorageLocationID = $('#StorageLocationID').val();
            var abc1 = $('#StorageLocationID :selected').text();
            if ($("#StorageLocationID").val() == "" || $("#StorageLocationID").val() == 0 || $("#StorageLocationID").val() == null) {
                notify("Please Select Location.", "danger");
                $("#StorageLocationID").focus();
                return false;
            }

            else if (parseFloat($("#MinimumOrderquantity").val()) > parseFloat($("#Quantity").val())) {
                notify("Please Enter Quantity Greater Than Minimum order quantity.", "danger");
                return false;
            }

            else if ($("#Remark").val() == "" || $("#Remark").val() == null) {
                notify("Please Enter Remark.", "danger");
                $("#Remark").focus();
                return false;
            }
            
           
            debugger;
            var ItemName = $('#ItemName').val();
            var ItemNumber = $('#ItemNumber').val();
            var StorageLocationID = $('#StorageLocationID').val();
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
                       $('#BlockForProcurement').val(true)
                        PurchaseRequirementMaster.BlockForProcurement = true;
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
                        return false;
                    }
                },
                async: false,
                error: function (er) {
                    // alert(er);
                    
                }
            });
           
           
            if (PurchaseRequirementMaster.BlockForProcurement == false) {
                {
                    //if ($('#ItemName').val() != "" && $("#GeneralItemCodeID").val() > 0 && parseFloat($("#Quantity").val()) > 0) {
                    if ($('#ItemName').val() != "" && $("#GeneralItemCodeID").val() > 0) {
                        $("#tblData tbody").append(
                            "<tr>" +
                            "<td ><input type='text' value=" + $('#GeneralItemCodeID').val() + " style='display:none' /> " + $('#ItemName').val() + "</td>" +
                            "<td><input id='quantity' class='form-control' maxlength='8' type='text' value=" + parseFloat($('#Quantity').val()).toFixed(2) + " style=''/></td>" +
                            "<td>" + $('#UnitCode').val() + "</td>" +
                            "<td ><input type='text' value=" + $('#Rate').val() + " style='display:none' /> " + $('#Rate').val() + "</td>" +
                            aaaa +
                            Priority1 +
                            "<td ><input type='text' value=" + $('#StorageLocationID').val() + " style='display:none' /> " + abc1 + "</td>" +
                            "<td ><input type='text' value=" + $('#Remark').val() + " style='display:none' /> " + $('#Remark').val() + "</td>" +
                            "<td  style='text-align:center;'><button class='btn btn-default' title='Delete' type='button'><i class='zmdi zmdi-delete' style='cursor:pointer;'  title = Delete> <input type='text' value=" + $('#ItemNumber').val() + " style='display:none' /><input type='text' value='" + $('#BarCode').val() + "' style='display:none' /><input type='text' value=" + $('#UnitCode').val() + " style='display:none' /></i></button> </td>" +
                            "</tr>");

                   
                        //
                        //<td  style='text-align:center; '><i class='zmdi zmdi-delete' style='cursor:pointer;'  title = Delete> <input type='text' value=" + $('#ItemNumber').val() + " style='display:none' /><input type='text' value=" + $('#BarCode').val() + " style='display:none' /><input type='text' value=" + $('#UnitCode').val() + " style='display:none' /> </td>

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

                    

                        $('input[id^=quantity]').on("keydown", function (e) {
                            AERPValidation.AllowNumbersWithDecimalOnly(e);
                            AERPValidation.NotAllowSpaces(e);
                        });
                        $('input[id^=quantity]').on("keyup", function (e) {
                            parseFloat($(this).val()).toFixed(2);

                        });

                        PurchaseRequirementMaster.TotalItem();
                    }

                    else if ($("#GeneralItemCodeID").val() == 0) {
                        //$('#msgDiv').html("Invalid item selected");
                        //$('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                        notify("Invalid item selected", "danger");
                    }

                    else if ($("#Quantity").val() == "" || $("#Quantity").val() == 0 || $("#Quantity").val() == '.') {
                        notify("Please Enter Quantity.", "danger");
                        $("#Quantity").focus();
                        return false;
                    }

                }
            }
            PurchaseRequirementMaster.BlockForProcurement = false;
        
        });

        //Delete
        $("#tblData tbody").on("click", "tr td button", function () {
            $(this).closest('tr').remove();
            PurchaseRequirementMaster.TotalItem();
        });
        // Create new record
        $('#CreatePurchaseRequirementMaster').on("click", function () {
            //alert('in');
            debugger;
            PurchaseRequirementMaster.ActionName = "Create";
            if ($('#SelectedCentreCode').val() == "" || $('#SelectedCentreCode').val() == null) {
                notify("Please Select Centre", "danger");
                return false;
            }
            else if ($('#SelectedDepartmentID').val() == "" || $('#SelectedDepartmentID').val() == null || $('#SelectedDepartmentID').val() == 0) {
                notify("Please Select Deprtment", "danger");
                return false;
            }
            else if (parseFloat($("#MinimumOrderquantity").val()) > parseFloat($("#quantity").val())) {
                notify("Please Enter Quantity Greater Than Minimum order qunatity.", "danger");
                return false;
            }
            
            else {
                //debugger;
                PurchaseRequirementMaster.flag = true;
                PurchaseRequirementMaster.GetXmlData();
                if (PurchaseRequirementMaster.flag == false) {
                    notify("Please Enter Quantity", "danger");
                    return false;
                }
                if (PurchaseRequirementMaster.XMLstring != null && PurchaseRequirementMaster.XMLstring != "") {
                    PurchaseRequirementMaster.AjaxCallPurchaseRequirementMaster();
                }
                else {
                    notify("No data available in table", "danger");
                }
            }
            $('#PurchaseRequirementNumber').val("");
            $('#SelectedCentreCode').val("");
            $('#SelectedDepartmentID').val("");
            $("#tblData tbody tr").remove();
            PurchaseRequirementMaster.TotalItem();
        });

        $('#EditPurchaseRequirementMaster').on("click", function () {
            debugger;
            PurchaseRequirementMaster.ActionName = "Edit";
            PurchaseRequirementMaster.flag = true;

            PurchaseRequirementMaster.GetXmlData();

            if (PurchaseRequirementMaster.flag == false) {
                $("#displayErrorMessage").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            PurchaseRequirementMaster.AjaxCallPurchaseRequirementMaster();
        });

        $('#CreatePurchaseRequirementMasterRecordExcel').on("click", function () {
            debugger;
            PurchaseRequirementMaster.ActionName = "CreateExcel";
            //if ($('#SelectedCentreCode').val() == "" || $('#SelectedCentreCode').val() == null) {
            //    $("#displayErrorMessage p").text("Please Select Centre.").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
            //    return false;
            //}
            //else if ($('#SelectedDepartmentID').val() == "" || $('#SelectedDepartmentID').val() == null || $('#SelectedDepartmentID').val() == 0) {
            //    $("#displayErrorMessage p").text("Please Select Department.").closest('div').fadeIn().closest('div').addClass('alert-' + "danger");
            //    return false;
            //}
            //else {
                PurchaseRequirementMaster.AjaxCallPurchaseRequirementMaster();
            //}
        });
        $('#CreateApprovePurchaseRequirementMaster').on("click", function () {
            //alert("asdfasdfasdf");
            debugger;
            debugger;
            PurchaseRequirementMaster.ActionName = "ApprovePurchaseRequirement";
            PurchaseRequirementMaster.GetApprovedPurchaseRequirementXmlData();
            if (PurchaseRequirementMaster.XMLstring != null && PurchaseRequirementMaster.XMLstring != "") {
                $('#CreateApprovePurchaseRequirement').attr("disabled", true);
                PurchaseRequirementMaster.AjaxCallPurchaseRequirementMaster();
            }
            else {
                notify("No data available in table", "danger");
            }
        });
        $('#Quantity').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

        //validation for quantity on key up
        $('#Quantity').on("keyup", function (e) {
            if ($("#Quantity").val() == "" || $("#Quantity").val() == 0)
            {
              notify("Please Enter Quantity.","danger");
              return false;
            }
            else if (parseFloat($("#MinimumOrderquantity").val()) > parseFloat($("#Quantity").val())) {
                notify("Please Enter Quantity Greater Than Minimum order quantity.", "danger");
                return false;
            }
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
        $("#tblData tbody").on("keyup", "tr td input[id^=quantity]", function () {
            var quantity = parseFloat($(this).closest('tr').find('td input[id^=quantity]').val());
          
            if (parseFloat(quantity) == 0 || parseFloat(quantity) == "") {
                notify("Please Enter Quantity", "danger");
            }
            else if (parseFloat($("#MinimumOrderquantity").val()) > parseFloat(quantity))
            {
                notify("Please Enter Quantity Greater Than Minimum order quantity.", "danger");
                return false;
            }
        });
        //$("#FromDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    onSelect: function (selected) {
        //        $("#UptoDate").datepicker("option", "minDate", selected)
        //    }
        //});
        //$("#UptoDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    onSelect: function (selected) {
        //        $("#FromDate").datepicker("option", "maxDate", selected)
        //    }
        //});

        $('#FromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
            ignoreReadonly: true,
        })

        $('#UptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
            ignoreReadonly: true,
        })

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        //to check selected file is in correct formate or not.
        //$("#MyFile").change(function () {
        //    var file = $('#MyFile')[0].files[0];
        //    var MyFileFileName = file.name;
        //    var Extension = '.' + MyFileFileName.split('.').pop();
        //    if (MyFileFileName != "" && MyFileFileName != "undefined") {

        //        if (Extension == ".xls" || Extension == ".xlsx") {
        //            var a = "";
        //        }
        //        else {
        //            $("#CreatePurchaseByExcel").hide(false)

        //            notify("Option excel only allows file types of xls and xlsx.", "danger");
        //            $("#MyFile").replaceWith($("#MyFile").val('').clone(true));

        //            return false;
        //        }
        //    }
        //    else {
        //        $("#CreatePurchaseByExcel").hide(false)
        //        notify("The selected file does not appear to be an excel file.", "danger");
        //        $("#MyFile").replaceWith($("#MyFile").val('').clone(true));

        //    }
        //    $("#CreatePurchaseByExcel").show(true);
        //});

        /////////////////
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
                    $("#displayErrorMessage p").text("Option excel only allows file types of xls and xlsx.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#MyFile").replaceWith($("#ExcelFile").val('').clone(true));
                    return false;
                }
            }
            else {
                alert();
                $("#displayErrorMessage p").text("The selected file does not appear to be an excel file.").closest('div').fadeIn().closest('div').addClass('alert-' + "success");

                $("#MyFile").replaceWith($("#ExcelFile").val('').clone(true));

            }
        });

        $("#SelectedCentreCode").change(function () {
            debugger;
            //debugger;
            var selectedItem = $(this).val();
            var $ddlDepartment = $("#SelectedDepartmentID");
            var $DepartmentProgress = $("#states-loading-progress");
            $DepartmentProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/PurchaseRequirementMaster/GetDepartmentByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlDepartment.html('');
                        $ddlDepartment.append('<option value="">----Select Department----</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartment.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $DepartmentProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Department.');
                        $DepartmentProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>All</option>');
            }
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');

        });

        $("#SelectedCentreCode").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });

        $("#btnShowList").click(function () {

            var SelectedCentreCode = $('#SelectedCentreCode').val();

            if (SelectedCentreCode != "") {
                $.ajax(
                {
                    cache: false,
                    type: "POST",
                    data: { actionMode: null, centerCode: SelectedCentreCode },
                    dataType: "html",
                    url: '/PurchaseRequirementMaster/List',
                    success: function (result) {
                        //Rebind Grid Data                
                        // $('#ListViewModel').html(result);
                        $('#divContent').html(result);
                        $("#createDiv").show();
                    }
                });
            }

            else if (SelectedCentreCode == "") {
                //PurchaseRequirementMaster.ReloadList("Please select centre", "#FFCC80", null);
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                notify("Please Select Centre.", "warning");
                return false;
            }
            else if (SelectedDepartmentID.length <= 1) {
                //PurchaseRequirementMaster.ReloadList("Please select centre", "#FFCC80", null);
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_DepartmentNotAllotedToCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Department not alloted to centre.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if (SelectedFromDate == "") {
                //PurchaseRequirementMaster.ReloadList("Please select centre", "#FFCC80", null);
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_FromDateNotBlank", "SuccessMessage", "#FFCC80");

                //$('#SuccessMessage').html("Please select from date");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if (SelectedUptoDate == "") {
                //PurchaseRequirementMaster.ReloadList("Please select centre", "#FFCC80", null);
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_UptoDateNotBlank", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select upto date");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
        });
        
        $("#myDataTable tbody").on("keyup", "tr td input[id^=Quantity]", function () {

            var Quantity = parseFloat($(this).closest('tr').find('td input[id=Quantity]').val()).toFixed(2);
            if (Quantity == 0 || Quantity == null || Quantity == "") {
                $("#displayErrorMessage").text("Please Enter Quantity.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;

            }
        });

      

    },

    TotalItem: function () {
        var length = $("#tblData tbody tr").length;
        $("#TotalItem").val(length);
    },

    ////Load method is used to load *-Load-* page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/PurchaseRequirementMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        //var SelectedCentreCode = $('#CentreCode').val();
        //var SelectedCentreName = $('#CentreCode :selected').text();
        var CentreCode = $('#SelectedCentreCode').val();

        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            data: { "actionMode": actionMode, "centerCode": CentreCode },
            url: '/PurchaseRequirementMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, "success");
            }
        });
    },
    ReloadPendingRequestList: function (message, colorCode, actionMode) {

        var TaskCode = "PR";
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "TaskCode": TaskCode },
            url: '/Home/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html('Request approved successfully');
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', '#9FEA7A');
                notify("Request approved successfully", "success");
            }
        });
    },
    //Method to create xml
    GetXmlData: function () {

        var DataArray = [];
        $('#DivAddRowTable input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
        //alert(DataArray);
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 10) {

            if (DataArray[i + 1] == 0 || DataArray[i + 1] == "")
            {
                PurchaseRequirementMaster.flag = false;
            }
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><GeneralItemCodeID>" + DataArray[i] + "</GeneralItemCodeID><Rate>" + parseFloat(DataArray[i + 2]).toFixed(2) + "</Rate><Quantity>" + parseFloat(DataArray[i + 1]).toFixed(2) + "</Quantity><ExpectedDate>" + DataArray[i + 3] + "</ExpectedDate><PriorityFlag>" + DataArray[i + 4] + "</PriorityFlag><StorageLocationID>" + DataArray[i + 5] + "</StorageLocationID><Remark>" + DataArray[i + 6] + "</Remark><ItemNumber>" + DataArray[i + 7] + "</ItemNumber><BarCode>" + DataArray[i + 8] + "</BarCode><UomCode>" + DataArray[i + 9] + "</UomCode></row>";

        }
        //alert(ParameterXml);
        if (ParameterXml.length > 10)
            PurchaseRequirementMaster.XMLstring = ParameterXml + "</rows>";

        else
            PurchaseRequirementMaster.XMLstring = "";

        //   alert(PurchaseRequirementMaster.XMLstring);
    },


    GetApprovedPurchaseRequirementXmlData: function () {

        var DataArray = []; var DataArray1 = [];
        var data = $('#tblData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });
        var data = $('#tblData tbody tr td select').each(function () {
            DataArray1.push($(this).val());
        });

        var TotalRecord = DataArray.length;
        var ParameterXml = "<rows>";
        var aa = []; var TotalReject = 0; var TotalAccepted = 0;
        var Count = DataArray1.length;

        var y = 0;
        for (var x = 0; x < Count; x++) {
            if (DataArray1[x] == "3") {//3 for Reject,//2 For Pending and 1 for Approved
                TotalReject = TotalReject + 1;
            }
            else {
                TotalAccepted = TotalAccepted + 1;
            }
        }
        var v = 0;
        for (var i = 0; i < TotalRecord; i = i + 7) {
            //  ParameterXml = ParameterXml + "<row><PurchaseRequirementDetailsID>" + DataArray[i + 6] + "</PurchaseRequirementDetailsID><GeneralItemCodeID>" + DataArray[i + 0] + "</GeneralItemCodeID><Quantity>" + DataArray[i + 1] + "</Quantity><ApprovedStatus>" + DataArray1[v] + "</ApprovedStatus><ItemNumber>" + DataArray1[i + 7] + "</ItemNumber><BarCode>" + DataArray1[i + 8] + "</BarCode></row>";
            ParameterXml = ParameterXml + "<row><PurchaseRequirementDetailsID>" + DataArray[i + 6] + "</PurchaseRequirementDetailsID><ItemNumber>" + DataArray[i + 0] + "</ItemNumber><Quantity>" + DataArray[i + 1] + "</Quantity><ApprovedStatus>" + DataArray1[v] + "</ApprovedStatus></row>";
            v = v + 1;
        }
        //alert(ParameterXml);
        if (ParameterXml.length > 7) {
            PurchaseRequirementMaster.XMLstring = ParameterXml + "</rows>";
            if (TotalReject > 0) {
                PurchaseRequirementMaster.ApprovedStatus = false;
            }
            else {
                PurchaseRequirementMaster.ApprovedStatus = true;
            }
        }
        else
            PurchaseRequirementMaster.XMLstring = "";


        // alert(PurchaseRequirementMaster.XMLstring);
    },
    //Fire ajax call to insert update and delete record
    AjaxCallPurchaseRequirementMaster: function () {

        var PurchaseRequirementMasterData = null;
        if (PurchaseRequirementMaster.ActionName == "Create") {
            $("#FormCreatePurchaseRequirementMaster").validate();
            //if ($("#FormCreatePurchaseRequirementMaster").valid()) {
            PurchaseRequirementMasterData = null;
            PurchaseRequirementMasterData = PurchaseRequirementMaster.GetPurchaseRequirementMaster();
            ajaxRequest.makeRequest("/PurchaseRequirementMaster/Create", "POST", PurchaseRequirementMasterData, PurchaseRequirementMaster.Success);
            // }
        }
        else if (PurchaseRequirementMaster.ActionName == "Edit") {
            
            $("#FormEditPurchaseRequirementMaster").validate();
            if ($("#FormEditPurchaseRequirementMaster").valid()) {
                PurchaseRequirementMasterData = null;
                PurchaseRequirementMasterData = PurchaseRequirementMaster.GetPurchaseRequirementMaster();
                ajaxRequest.makeRequest("/PurchaseRequirementMaster/Edit", "POST", PurchaseRequirementMasterData, PurchaseRequirementMaster.Success);
            }
        }
        else if (PurchaseRequirementMaster.ActionName == "CreateExcel") {

            $("#FormCreatePurchaseRequirementMasterExcel").validate();
            if ($("#FormCreatePurchaseRequirementMasterExcel").valid()) {
                PurchaseRequirementMaster = null;
                PurchaseRequirementMaster = PurchaseRequirementMaster.GetExcelDetails();

                ajaxRequest.makeRequest("/PurchaseRequirementMaster/CreateExcel", "POST", PurchaseRequirementMasterData, PurchaseRequirementMaster.SaveSuccess, "CreatePurchaseRequirementMasterRecordExcel");

            }
        }
        if (PurchaseRequirementMaster.ActionName == "ApprovePurchaseRequirement") {

            $("#FormApprovePurchaseRequirementMaster").validate();
            if ($("#FormApprovePurchaseRequirementMaster").valid()) {
                PurchaseRequirementMasterData = null;
                PurchaseRequirementMasterData = PurchaseRequirementMaster.GetPurchaseRequirementMaster();
                ajaxRequest.makeRequest("/PurchaseRequirementMaster/PurchaseRequirementRequestApproval", "POST", PurchaseRequirementMasterData, PurchaseRequirementMaster.SuccessRequestList);
            }
        }

    },

    GetExcelDetails: function () {
        var Data = {
        };
        if (PurchaseRequirementMaster.ActionName == "CreateExcel") {


            var data = new FormData();
            var files = $("#MyFile").get(0).files;
            if (files.length > 0) {
                data.append("MyFile", files[0]);
                $.ajax({
                    url: "/PurchaseRequirementMaster/UploadQuestionFile1",
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
    GetPurchaseRequirementMaster: function () {
        var Data = {
        };
        if (PurchaseRequirementMaster.ActionName == "Create" || PurchaseRequirementMaster.ActionName == "Edit" || PurchaseRequirementMaster.ActionName == "ApprovePurchaseRequirement") {

            Data.ID = $('#ID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.DepartmentID = $('#DepartmentID').val();
            Data.StorageLocationID = $('#StorageLocationID').val();
            Data.Quantity = $('#Quantity').val();
            Data.Rate = $('#Rate').val();
            Data.PriorityFlag = $('#PriorityFlag').val();
            Data.Remark = $('#Remark').val();
            Data.PurchaseRequirementNumber = $('#PurchaseRequirementNumber').val();
            Data.TransDate = $('#TransDate').val();
            Data.XMLstring = PurchaseRequirementMaster.XMLstring;
            Data.SelectedCentreCode = $('#SelectedCentreCode').val();
            Data.SelectedDepartmentID = $('#SelectedDepartmentID').val();

            Data.TaskCode = "PR";
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            Data.PersonID = $('input[name=PersonID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.BalanceSheetID = $("input[name=BalanceSheetID]").val();
            Data.LocationID = $("input[name=LocationID]").val();
            Data.ApprovedStatus = PurchaseRequirementMaster.ApprovedStatus;
        }
        else if (PurchaseRequirementMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        //alert('success');
        //parent.$.colorbox.close();
        //notify("Saved","success");
        $.magnificPopup.close();
        PurchaseRequirementMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    },

    SuccessRequestList: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();
        //$('#CreateApproveDumpAndShrinkMasterAndDetails').attr("disabled", false);
        //notify("Saved", "success");
        PurchaseRequirementMaster.ReloadPendingRequestList(splitData[0], splitData[1], splitData[2]);
    },

};



