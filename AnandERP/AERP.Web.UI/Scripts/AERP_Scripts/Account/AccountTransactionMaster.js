//this class contain methods related to nationality functionality
var AccountTransactionMaster = {
    //Member variables
    ActionName: null,
    VoucherAmount:null,
    accountIdForSubLedger: null,
    mainLegerName: null,
    personType: null,
    TransactionTypeCode: null,
    rowCount: null,
    SelectedXmlData: null,
    map: {},
    map2: {},
    flag: true,
    // t: null,
    //Class intialisation method
    Initialize: function () {
        AccountTransactionMaster.constructor();
        AccountTransactionMaster.rowCount = 0;
    },
    //Attach all event of page
    constructor: function () {

        $('#SelectedTransactionType').focus();
        $('#ResetAccountTransactionMasterRecord').hide();
        $('#CreateAccountTransactionMasterRecord').hide();


        $(document).keyup(function (e) {

            if (e.shiftKey && e.ctrlKey && e.keyCode == 115) {
                $("#SelectedTransactionType").val("C ");
                AccountTransactionMaster.SelectTransactionTyoeFun();
                return false;
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode === 116) {
                $("#SelectedTransactionType").val('P ');
                AccountTransactionMaster.SelectTransactionTyoeFun();
                return false;
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode === 117) {
                $("#SelectedTransactionType").val('R ');
                AccountTransactionMaster.SelectTransactionTyoeFun();
                return false;
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode === 118) {
                $("#SelectedTransactionType").val('J ');
                AccountTransactionMaster.SelectTransactionTyoeFun();
                return false;
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode === 119) {
                $("#SelectedTransactionType").val('S ');
                AccountTransactionMaster.SelectTransactionTyoeFun();
                return false;
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode === 120) {
                $("#SelectedTransactionType").val('H ');
                AccountTransactionMaster.SelectTransactionTyoeFun();
                return false;
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode === 113) {
                $("#SelectedTransactionType").val('N ');
                AccountTransactionMaster.SelectTransactionTyoeFun();
                return false;
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode === 114) {
                $("#SelectedTransactionType").val('D ');
                AccountTransactionMaster.SelectTransactionTyoeFun();
                return false;
            }
            //To Show All Posted Voucher
            if (e.altKey && (e.which === 76 || e.which === 108)) {
                $('#IconShowList').hide(true);
                $('#DivVoucherDate').hide(true);
                $('#btnShowList').show(true);
                $('#divBtnShowList').show(true);
                $('#IconShowPostVoucher').show(true);
                $('#btnAdd').attr("disabled", true);
                var Balancesheet = $("#selectedBalsheetID").val();

                $.ajax(
               {
                   cache: false,
                   type: "Get",
                   data: { "selectedBalsheet": Balancesheet },
                   dataType: "html",
                   url: '/AccountTransactionMaster/List',
                   success: function (data) {
                       //Rebind Grid Data
                       $('#ListViewModel').html(data);
                   }
               });
                return false;
            }
            //To Add a Voucher
            if (e.altKey && (e.which === 65 || e.which === 97)) {
                $('#btnShowList').hide(true);
                $('#divBtnShowList').show(true);
                $('#IconShowPostVoucher').hide(true);
                $('#IconShowList').show(true);
                $('#DivVoucherDate').show(true);
                $('#btnAdd').attr("disabled", true);
                AccountTransactionMaster.Reset();
                return false;
            }
            //To Add a Row
            if (e.altKey && (e.which === 82 || e.which === 114)) {
                var valuTransactionType = $('#SelectedTransactionType :selected').val();
                if (valuTransactionType != "") {
                    AccountTransactionMaster.AddRow();
                }
                else if (valuTransactionType == "") {
                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectTransactionType", "SuccessMessage", "#FFCC80");
                }
                return false;
            }

            //To Post Voucher
            if (e.which === 13 && e.shiftKey) {
                if ($('#example tbody tr').length >= 1) {
                    AccountTransactionMaster.CreateData();
                }
            }
            if (e.altKey && (e.which === 88 || e.which === 120)) {
                AccountTransactionMaster.Reset();

            }
        });

        //$("#example_info").remove();
        //$(".sorting").attr('disabled', true);

        AccountTransactionMaster.TransactionTypeCode = $("#TransactionTypeCode").val();

        // ADDS NEW ROW IN TABLE
        $('#btnAdd').on('click', function () {
            $('#ResetAccountTransactionMasterRecord').show();
            $('#CreateAccountTransactionMasterRecord').show();

            AccountTransactionMaster.AddRow();
        });

        //FOLLOWING FUNCTION ADDS NEW ROW IN TABLE WITH TOTAL DEBIT AND TOTAL CREDIT AMOUNT

        $("#currentDateTime").datetimepicker({
            format: "DD MMMM YYYY",
            maxDate: 0,

        });



        //DATEPICKER FOR CHEQUE DATE FIELD
        $("#example tbody tr td input[id^=AccChequeDate]").datetimepicker({
            format: "DD MMMM YYYY",

        });

        //$("#TransactionDate").datetimepicker({
        //    format: "DD MMMM YYYY",
        //    //changeMonth: true,
        //    //changeYear: true,
        //    //maxDate: '0',
        //    maxDate: moment(),
        //    //numberOfMonths: 1
        //});
 

        $('#CreateAccountTransactionMasterRecord').on("click", function () {
       
            AccountTransactionMaster.CreateData();
        });

        $('#ResetAccountTransactionMasterRecord').on("click", function () {
            AccountTransactionMaster.Reset();
            $('#btnAdd').attr("disabled", true);
        });

        $('#EditAccountTransactionMasterRecord').on("click", function () {
            
            var _creditBal = 0, _debitBal = 0;
            $('#example tbody tr').each(function (i) {
                
                //var rowCount = $('#example tbody tr').length;
                //if (i < parseInt(rowCount - 1)) {
                    var x;
                    x = $(this).find('td input[id^=debitBal]').val();
                    _debitBal += parseFloat(x);

                    var y;
                    y = $(this).find('td input[id^=creditBal]').val();
                    _creditBal += parseFloat(y);
                //}
            });

            if (_debitBal == _creditBal) {
                AccountTransactionMaster.ActionName = "Edit";
                AccountTransactionMaster.getDataFromDataTable();
                AccountTransactionMaster.AjaxCallAccountTransactionMaster();
            }
            else {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_DebitBlncDoesnotmatchwithCreditBlnc", "SuccessMessage", "#FFCC80");
                //$('#TransactionMessage').html("Debit balance does not match with the Credit balance");
                //$('#TransactionMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
            }
        });

        $('#DeleteAccountTransactionMasterRecord').on("click", function () {
            AccountTransactionMaster.ActionName = "Delete";
            AccountTransactionMaster.AjaxCallAccountTransactionMaster();
        });

        $("#UserSearch").on("keyup", function () {
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        InitAnimatedBorder();
        CloseAlert();
        //$(".ajax").colorbox();

        $('#VoucherNumber').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
        });

        $('#RateOfInterest').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#SelectedTransactionType').on("change", function () {
            AccountTransactionMaster.SelectTransactionTyoeFun();
        });
        $('#IconShowList').click(function () {
            $('#IconShowList').hide(true);
            $('#DivVoucherDate').hide(true);
            $('#btnShowList').show(true);
            $('#divBtnShowList').show(true);
            $('#IconShowPostVoucher').show(true);
            $('#btnAdd').attr("disabled", true);
            $('#SelectedTransactionType').val("");
            var Balancesheet = $("#selectedBalsheetID").val();
            $('#example tbody tr').remove();
            $.ajax(
           {
               cache: false,
               type: "Get",
               data: { "selectedBalsheet": Balancesheet },
               dataType: "html",
               url: '/AccountTransactionMaster/List',
               success: function (data) {
                   //Rebind Grid Data
                   $('#ListViewModel').html(data);
               }
           });
            //$('#btnShowList').show(true);
            //$('#DivShowListVoucher').show(true);
        });

        $('#IconShowPostVoucher').click(function () {
            $('#btnShowList').hide(true);
            $('#divBtnShowList').show(true);
            $('#IconShowPostVoucher').hide(true);
            $('#IconShowList').show(true);
            $('#DivVoucherDate').show(true);
            $('#btnAdd').attr("disabled", true);
            AccountTransactionMaster.Reset();

        });

        $('#btnShowList').click(function () {

            var valuTransactionType = $('#SelectedTransactionType :selected').val();
            var Balancesheet = $("#selectedBalsheetID").val();

            if (valuTransactionType != "" && Balancesheet > 0) {
                AccountTransactionMaster.LoadListBySelectedTransactionType();

            }
            else if (valuTransactionType == "" && Balancesheet > 0) {

                notify("Please select voucher type.", "danger");
                $('#LiSessionName').hide(true);
                //  $('#btnCreateTransaction').hide(true);
            }
            else if (valuTransactionType != "" && Balancesheet <= 0) {
                notify("Please select balancesheet", "danger");
                $('#LiSessionName').hide(true);
                // $('#btnCreateTransaction').hide(true);
            }
            else {
                notify("Please select balancesheet & transaction type", "danger");
                $('#LiSessionName').hide(true);
                //  $('#btnCreateTransaction').hide(true);
            }

        });
    },

    Reset: function () {
        window.location.reload();
        $("#NarrationDescription").val("");
        $("#debitBal").val(0);
        $("#creditBal").val(0);
        var test = new Date();
        $("#TransactionDate").val("");
        $("#SelectedTransactionType").val("");
        $("#tableDebitCredit").hide(true);
        $('#example tbody tr').remove();
    },

    SelectTransactionTyoeFun: function () {
        $('#LiSessionName').hide(true);
        var valuTransactionType = $('#SelectedTransactionType :selected').val();
        if (valuTransactionType != "") {
            $('#btnAdd').attr("disabled", false);
        }
        else {
            $('#btnAdd').attr("disabled", true);
        }
        $("#tableDebitCredit").hide(true);
        $('#example tbody tr').remove();
        $("#debitBal").val(0);
        $("#creditBal").val(0);
        $('#myDataTable').html("");
        $('#myDataTable_info').text("No entries to show");
        //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
    },
    CreateData: function () {

        AccountTransactionMaster.flag = true;


        if ($('#example tbody tr').length >= 2) {
            var _creditBal = 0, _debitBal = 0;
            $('#example tbody tr').each(function (i) {

                if (i < AccountTransactionMaster.rowCount) {
                    var x;
                    x = $(this).find('td input[id^=debitBal]').val();
                    _debitBal += parseFloat(x);
                    var y;
                    y = $(this).find('td input[id^=creditBal]').val();
                    _creditBal += parseFloat(y);
                }
            });
            if (_debitBal == 0 && _creditBal == 0) {
                //$('#SuccessMessage').html("Total debit and total credit should be greater than zero.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                notify("Total debit or total credit should be greater than zero.", "warning");
                AccountTransactionMaster.flag = false;
                return false;
            }
            else if ($("#TransactionDate").val() == "") {
                //$('#SuccessMessage').html("Please select voucher date.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                notify("Please select voucher date.", "warning");
                AccountTransactionMaster.flag = false;
                return false;
            }
            else if (_debitBal == _creditBal) {
                AccountTransactionMaster.VoucherAmount = _debitBal;
                AccountTransactionMaster.ActionName = "Create";
                AccountTransactionMaster.getDataFromDataTable();
                $('#CreateAccountTransactionMasterRecord').attr("disabled", false);
                if (AccountTransactionMaster.flag == true) {
                    AccountTransactionMaster.AjaxCallAccountTransactionMaster();
                }
            }
            else {
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_DebitBlncDoesnotmatchwithCreditBlnc", "SuccessMessage", "#FFCC80");
                notify("Debit balance does not match with the Credit balance.", "danger");
                //$('#TransactionMessage').html("Debit balance does not match with the Credit balance");
                //$('#TransactionMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
            }

        }

        else {
            //$('#SuccessMessage').html("Atleast one debit and one credit entry should be required.");
            //$('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
            notify("Atleast one debit and one credit entry should be required.", "warning");
        }
    },
    AddRow: function () {

        var tableLength = $('#example tbody tr').length;

        if (tableLength == 0) {
            $("#debitBal").val(0);
            $("#creditBal").val(0);
        }
        if (tableLength != 0) {
            var accName = $("#AccName" + tableLength).val();
            var debitBal = $("#debitBal" + tableLength).val();
            var creditBal = $("#creditBal" + tableLength).val();
            var AccChequeNumber = $("#AccChequeNumber" + tableLength).val();
            var AccChequeDate = $("#AccChequeDate" + tableLength).val();
            var CashBankFlag = $("#CashBankFlag" + tableLength).val();
            var AccBranchName = $("#AccBranchName" + tableLength).val();
            var PersonType = $("#PersonType" + tableLength).val();
            var PersonID = $("#PersonID" + tableLength).val();

            var AccID = $("#AccID" + tableLength).val();
            if (accName == "") {
                notify("Please select account.", "danger")
                return false;
            }
            else if (AccID == 0 || AccID == "") {
                notify("Please select proper account", "danger")
                return false;
            }
            else if (debitBal == 0 && creditBal == 0) {
                notify("Total debit and total credit should be greater than zero", "danger")
                return false;
            }
            else if (CashBankFlag == "B" && AccBranchName == "") {
                notify("Please enter branch name", "danger")
                return false;
            }
            else if (AccChequeNumber != "" && AccChequeDate == "") {
                notify("Please enter cheque date of cheque no" + AccChequeNumber, "danger")
                return false;
            }
            else if (CashBankFlag == "L" && PersonType != "" && PersonID == 0) {
                notify("Please select sub-ledger account", "danger")
                return false;
            }

        }
        $('#CreateAccountTransactionMasterRecord').attr("disabled", false);
        AccountTransactionMaster.rowCount = tableLength + 1;
        $('#tableDebitCredit').show();
        $('#example tbody tr td input[type=text]').attr('disabled', true);
        //   $('#example tbody').find('tr').eq(AccountTransactionMaster.rowCount - 2).find('td').eq(4).text('');
        //  var $td = $('#example tbody').find('tr').eq(AccountTransactionMaster.rowCount - 2).find('td').eq(4).append('<a href="#" class="edit-row" ><i class="icon-edit"></i><a> | <a href="#" class="remove-row" ><i  class="icon-trash"></i><a>'); //  | <a href="#" class="remove-row" ><i  class="icon-trash"></i><a>

        $("#example tbody").append(
                '<tr>' +
                '<td><div class="form-group fg-line"><input id="AccName' + AccountTransactionMaster.rowCount + '" class="form-control input-sm typeahead" placeholder="Search Account*"  style="text-align:centre" type="text"  maxlength="200"  /></div><input type="hidden" id="TransactionSubID' + AccountTransactionMaster.rowCount + '"  /> <input type="hidden" id="AccID' + AccountTransactionMaster.rowCount + '" /> <div class="form-group fg-line"><input type="text" id="SubLedger' + AccountTransactionMaster.rowCount + '" class="form-control input-sm typeahead" placeholder="Search Sub-Ledger Account*"  maxlength="200" style="display:none;" /></div><div class="form-group fg-line"><input class="form-control input-sm" type="text" id="AccBranchName' + AccountTransactionMaster.rowCount + '" placeholder="Enter Branch Name"  maxlength="30"  style="display:none;" /></div> </td>' +
                '<td><div class="form-group fg-line"><input class="form-control input-sm" type="text" maxlength="500" placeholder="Narration"  /></div> <div class="form-group fg-line"><input class="form-control input-sm" type="text" id="AccChequeNumber' + AccountTransactionMaster.rowCount + '" placeholder="Enter Cheque Number"  maxlength="20" style="display:none;" /></div></td>' +
                '<td><div class="form-group fg-line"><input class="form-control input-sm" type="text" id="debitBal' + AccountTransactionMaster.rowCount + '" maxlength="10" style="text-align:right;" value="0" /></div><div class="form-group  fg-line dtp-container"><input class="input-sm form-control" type="text" id="AccChequeDate' + AccountTransactionMaster.rowCount + '" placeholder="Cheque Date" style="display:none;" /></div></td>' +
                '<td><div class="form-group fg-line"><input class="form-control input-sm" type="text" id="creditBal' + AccountTransactionMaster.rowCount + '" maxlength="10" style="text-align:right;" value="0"/> <input type="hidden" id="PersonID' + AccountTransactionMaster.rowCount + '" /><input type="hidden" id="PersonType' + AccountTransactionMaster.rowCount + '" /> <input type="hidden" id="CashBankFlag' + AccountTransactionMaster.rowCount + '" /></div></td>' +//</br><a href="#" class="hide-row" style="text-align:centre;display:none;width:500px"><i class="icon-ok"></i><a>',
                '<td><div class="form-group fg-line"><input id="RefAccountName' + AccountTransactionMaster.rowCount + '" class="form-control input-sm typeahead" placeholder="Search Account*"  style="text-align:centre" type="text"  maxlength="200"  /></div><input type="hidden" id="RefAccountTransactionSubID' + AccountTransactionMaster.rowCount + '"  /> <input type="hidden" id="RefAccountID' + AccountTransactionMaster.rowCount + '" /> <div class="form-group fg-line"><input type="text" id="RefAccountSubLedger' + AccountTransactionMaster.rowCount + '" class="form-control input-sm typeahead" placeholder="Search Sub-Ledger Account*"  maxlength="200" style="display:none;" /></div><div class="form-group fg-line"><input class="form-control input-sm" type="text" id="RefAccountBranchName' + AccountTransactionMaster.rowCount + '" placeholder="Enter Branch Name"  maxlength="30"  style="display:none;" /><input type="hidden" id="RefAccountPersonID' + AccountTransactionMaster.rowCount + '" /><input type="hidden" id="RefAccountPersonType' + AccountTransactionMaster.rowCount + '" /></div> </td>' +
                "<td style='text-align:center; '><a href='#' id='edit-row' class='btn edit-row btn-default'><i class='zmdi zmdi-edit'></i><a>  <a href='#' class='btn btn-default remove-row' id='remove-row'><i  class='zmdi zmdi-delete'></i><a></td>" +
                '</tr>'
        );

        $("#AccName" + AccountTransactionMaster.rowCount).focus();
        // FOLLOWING FUNCTION ADD LAST ROW IN TABLE WITH TOTAL DEBIT AND TOTAL CREDIT AMOUNT
        //  AccountTransactionMaster.AddLastRow();
        AccountTransactionMaster.HideControls()

        //FOLLOWING FUNCTION IS SEARCHLIST OF ACCOUNT NAMES
        //$("#AccName" + AccountTransactionMaster.rowCount + "").autocomplete({

        //    source: function (request, response) {
        //        var valuTransactionType = $('#SelectedTransactionType :selected').val();
        //        //    var Balancesheet = $("#selectedBalsheetID").val();
        //        $.ajax({
        //            url: "/AccountTransactionMaster/GetAccounts",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, maxResults: 10, accountId: 0, personType: "", transactionTypeCode: valuTransactionType },
        //            success: function (data) {
        //                response($.map(data, function (item) {
        //                    return { label: item.name, value: item.name, id: item.id, personType: item.personType, cashBankFlag: item.cashBankFlag };
        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {

        //        $(this).val(ui.item.label);                                             
        //        AccountTransactionMaster.mainLegerName = ui.item.label;
        //        $("#AccID" + AccountTransactionMaster.rowCount + "").val(ui.item.id);    
        //        $(this).closest('tr').find('td input[id^=CashBankFlag]').val(ui.item.cashBankFlag);

        //        AccountTransactionMaster.HideControls();

        //        if (ui.item.cashBankFlag == 'B') {
        //            $(this).closest('tr').find('td input[id^=PersonID]').val('');
        //            $(this).closest('tr').find('td input[id^=PersonType]').val('');
        //            $(this).closest('tr').find('td input[id^=AccBranchName]').show();
        //            $(this).closest('tr').find('td input[id^=AccChequeNumber]').show();
        //            $(this).closest('tr').find('td input[id^=AccChequeDate]').show();
        //        }
        //        else if (ui.item.cashBankFlag == 'C') {
        //            $(this).closest('tr').find('td input[id^=PersonID]').val('');
        //            $(this).closest('tr').find('td input[id^=PersonType]').val('');
        //            AccountTransactionMaster.HideControls();
        //        }
        //        else if (ui.item.personType != null && ui.item.cashBankFlag == "L") {
        //            $(this).closest('tr').find('td input[id^=SubLedger]').val('');
        //            $(this).closest('tr').find('td input[id^=SubLedger]').show();
        //            $(this).closest('tr').find('td input[id^=PersonType]').val(ui.item.personType);
        //            AccountTransactionMaster.accountIdForSubLedger = ui.item.id;
        //            AccountTransactionMaster.personType = ui.item.personType;
        //        }
        //        else if (ui.item.personType == null && ui.item.cashBankFlag == "L") {
        //            $(this).closest('tr').find('td input[id^=PersonID]').val('');
        //            $(this).closest('tr').find('td input[id^=PersonType]').val('');
        //            AccountTransactionMaster.HideControls();
        //        }
        //    }
        //});


        ///end here
        //New SEARCHLIST OF ACCOUNT NAMES 




        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var valuTransactionType = $('#SelectedTransactionType :selected').val();
                $.ajax({
                    url: "/AccountTransactionMaster/GetAccounts",
                    type: "POST",
                    data: { term: q, maxResults: 10, accountId: 0, personType: "", transactionTypeCode: valuTransactionType },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.name)) {
                                AccountTransactionMaster.map[response.name] = response;
                                matches.push(response.name);
                            }
                        });
                    },
                    async: false
                })
                cb(matches);
            };

        };


        $("#AccName" + AccountTransactionMaster.rowCount).typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        },
        {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {

            //$(this).closest('tbody tr').find('td input[id^=employeeid_]').val(AccountTransactionMaster.map[item].id);
            //  $(this).val(AccountTransactionMaster.map[item].label);    

            AccountTransactionMaster.mainLegerName = AccountTransactionMaster.map[item].name;
            $("#AccID" + AccountTransactionMaster.rowCount + "").val(AccountTransactionMaster.map[item].id);
            //$("#AccID" + AccountTransactionMaster.rowCount + "").val(item.id);



            $(this).closest('tr').find('td input[id^=CashBankFlag]').val(AccountTransactionMaster.map[item].cashBankFlag);

            AccountTransactionMaster.HideControls();

            if (AccountTransactionMaster.map[item].cashBankFlag == 'B') {
                $(this).closest('tr').find('td input[id^=PersonID]').val('');
                $(this).closest('tr').find('td input[id^=PersonType]').val('');
                $(this).closest('tr').find('td input[id^=AccBranchName]').show();
                $(this).closest('tr').find('td input[id^=AccChequeNumber]').show();
                $(this).closest('tr').find('td input[id^=AccChequeDate]').show();
            }
            else if (AccountTransactionMaster.map[item].cashBankFlag == 'C') {
                $(this).closest('tr').find('td input[id^=PersonID]').val('');
                $(this).closest('tr').find('td input[id^=PersonType]').val('');
                AccountTransactionMaster.HideControls();
            }
            else if (AccountTransactionMaster.map[item].personType != null && AccountTransactionMaster.map[item].cashBankFlag == "L") {
                $(this).closest('tr').find('td input[id^=SubLedger]').val('');
                $(this).closest('tr').find('td input[id^=SubLedger]').show();
                $(this).closest('tr').find('td input[id^=PersonType]').val(AccountTransactionMaster.map[item].personType);
                AccountTransactionMaster.accountIdForSubLedger = AccountTransactionMaster.map[item].id;
                AccountTransactionMaster.personType = AccountTransactionMaster.map[item].personType;
            }
            else if (AccountTransactionMaster.map[item].personType == null && AccountTransactionMaster.map[item].cashBankFlag == "L") {
                $(this).closest('tr').find('td input[id^=PersonID]').val('');
                $(this).closest('tr').find('td input[id^=PersonType]').val('');
                AccountTransactionMaster.HideControls();
            }

        });

        $("#RefAccountName" + AccountTransactionMaster.rowCount).typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        },
         {
             source: getData()
         }).on("typeahead:selected", function (obj, item) {

             //$(this).closest('tbody tr').find('td input[id^=employeeid_]').val(AccountTransactionMaster.map[item].id);
             //  $(this).val(AccountTransactionMaster.map[item].label);    

             AccountTransactionMaster.mainLegerName = AccountTransactionMaster.map[item].name;
             $("#RefAccountID" + AccountTransactionMaster.rowCount + "").val(AccountTransactionMaster.map[item].id);
             
             AccountTransactionMaster.HideControls();

             if (AccountTransactionMaster.map[item].personType != null && AccountTransactionMaster.map[item].cashBankFlag == "L") {
                 $(this).closest('tr').find('td input[id^=RefAccountSubLedger]').val('');
                 $(this).closest('tr').find('td input[id^=RefAccountSubLedger]').show();
                 $(this).closest('tr').find('td input[id^=RefAccountPersonType]').val(AccountTransactionMaster.map[item].personType);
                 AccountTransactionMaster.accountIdForSubLedger = AccountTransactionMaster.map[item].id;
                 AccountTransactionMaster.personType = AccountTransactionMaster.map[item].personType;
             }
         });
        //End new SEARCHLIST OF ACCOUNT NAMES


        //FOLLOWING FUNCTION IS FOR SEARCHLIST OF SUBLEDGER ACCOUNTS

        //$("#SubLedger" + AccountTransactionMaster.rowCount + "").autocomplete({
        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/AccountTransactionMaster/GetAccounts",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, maxResults: 10, accountId: AccountTransactionMaster.accountIdForSubLedger, personType: AccountTransactionMaster.personType, transactionTypeCode: "" },
        //            success: function (data) {

        //                if (!data.length) {
        //                    var result = [{ label: 'No matches found', value: response.term }];
        //                    response(result);
        //                }
        //                else {
        //                    response($.map(data, function (item) {

        //                        return { label: item.subLedgerName, value: item.subLedgerName, personId: item.personId, id: item.id, personType: item.personType };
        //                    }))
        //                }

        //            }
        //        })
        //    },
        //    select: function (event, ui) {
        //        if (ui.item.value != "No matches found") {
        //            $(this).closest('tr').find('td input[id^=AccName]').val(AccountTransactionMaster.mainLegerName + " [" + ui.item.label + "]");    // save selected id to hidden input
        //            $(this).closest('tr').find('td input[id^=PersonID]').val(ui.item.personId);
        //            //$(this).closest('tr').find('td input[id^=PersonType]').val(ui.item.personType);
        //            //$(this).closest('tr').find('td input[id^=AccID]').val(ui.item.id);
        //            $(this).closest('tr').find('td input[id^=SubLedger]').hide();
        //        }
        //        else {
        //            $(this).closest('tr').find('td input[id^=SubLedger]').hide();
        //        }

        //    }
        //});
        var getDataForSubLedger = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var valuTransactionType = $('#SelectedTransactionType :selected').val();
                $.ajax({
                    url: "/AccountTransactionMaster/GetAccounts",
                    type: "POST",
                    data: { term: q, maxResults: 10, accountId: AccountTransactionMaster.accountIdForSubLedger, personType: AccountTransactionMaster.personType, transactionTypeCode: "" },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.subLedgerName)) {
                                AccountTransactionMaster.map2[response.subLedgerName] = response;
                                matches.push(response.subLedgerName);
                            }
                        });
                    },
                    async: false
                })
                cb(matches);
            };

        };


        $("#SubLedger" + AccountTransactionMaster.rowCount).typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        },
        {
            source: getDataForSubLedger()
        }).on("typeahead:selected", function (obj, item) {
            if (AccountTransactionMaster.map2[item].value != "No matches found") {
                $(this).closest('tr').find('td input[id^=AccName]').val(AccountTransactionMaster.mainLegerName + " [" + AccountTransactionMaster.map2[item].subLedgerName + "]");    // save selected id to hidden input
                $(this).closest('tr').find('td input[id^=PersonID]').val(AccountTransactionMaster.map2[item].personId);
                //$(this).closest('tr').find('td input[id^=PersonType]').val(ui.item.personType);
                //$(this).closest('tr').find('td input[id^=AccID]').val(ui.item.id);
                $(this).closest('tr').find('td input[id^=SubLedger]').hide();
            }
            else {
                $(this).closest('tr').find('td input[id^=SubLedger]').hide();
            }

        });

        $("#RefAccountSubLedger" + AccountTransactionMaster.rowCount).typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        },
        {
            source: getDataForSubLedger()
        }).on("typeahead:selected", function (obj, item) {
            if (AccountTransactionMaster.map2[item].value != "No matches found") {
                $(this).closest('tr').find('td input[id^=RefAccountName]').val(AccountTransactionMaster.mainLegerName + " [" + AccountTransactionMaster.map2[item].subLedgerName + "]");    // save selected id to hidden input
                $(this).closest('tr').find('td input[id^=RefAccountPersonID]').val(AccountTransactionMaster.map2[item].personId);
                //$(this).closest('tr').find('td input[id^=PersonType]').val(ui.item.personType);
                //$(this).closest('tr').find('td input[id^=AccID]').val(ui.item.id);
                $(this).closest('tr').find('td input[id^=RefAccountSubLedger]').hide();
            }
            else {
                $(this).closest('tr').find('td input[id^=RefAccountSubLedger]').hide();
            }

        });
        //alert(AccountTransactionMaster.rowCount);
        $("#AccChequeNumber" + AccountTransactionMaster.rowCount + "").on("keydown", function (e) {
            if (e.altKey && (e.which === 65 || e.which === 97)) {
                var vat = "";
            }
            else { AERPValidation.AllowNumbersOnly(e); }
           
        });

        //VALIDATION FOR DEBIT BALANCE INPUT
        $("#debitBal" + AccountTransactionMaster.rowCount + "").on("keydown", function (e) {
            if (e.altKey && (e.which === 65 || e.which === 97)) {
                var vat = "";
            }
            else { AERPValidation.AllowNumbersWithDecimalOnly(e); }

        });

        //VALIDATION FOR CREDIT BALANCE INPUT
        $("#creditBal" + AccountTransactionMaster.rowCount + "").on("keydown", function (e) {
            if (e.altKey && (e.which === 65 || e.which === 97)) {
                var vat = "";
            }
            else { AERPValidation.AllowNumbersWithDecimalOnly(e); }
        });

        //FORMAT OF INPUT TEXT IN DEBIT BALANCE 
        $("#debitBal" + AccountTransactionMaster.rowCount + "").on('keyup', function (e) {
            //  this.value = parseFloat(this.value).toFixed(2);
            var _debitBal = 0;
            $('#example tbody tr').length;

            for (var i = 0; i <= parseInt($('#example tbody tr').length) ; i++) {
                var x;
                x = $('#example tbody tr:eq(' + i + ')').find('td input[id^=debitBal]').val();

                _debitBal += parseFloat(x != null ? x : 0);

            }

            $("#debitBal").val(_debitBal.toFixed(2));

        });

        //FORMAT OF INPUT TEXT IN CREDIT BALANCE
        $("#creditBal" + AccountTransactionMaster.rowCount + "").on('keyup', function (e) {

            //  this.value = parseFloat(this.value).toFixed(2);
            var _creditBal = 0;
            var t_length = $('#example tbody tr').length;

            for (var i = 0; i <= t_length ; i++) {
                var x;
                x = $('#example tbody tr:eq(' + i + ')').find('td input[id^=creditBal]').val();

                _creditBal += parseFloat(x != null ? x : 0);

            }

            $("#creditBal").val(_creditBal.toFixed(2));
        });
        //FOLLOWING FUNCTION PROVIDES EDIT PARTICULAR ROW FUNCTIONALITY IN TABLE
        $(".edit-row").click(function () {
            
            

            AccountTransactionMaster.HideControls();
            $(this).closest('tr').find('td input[id^=AccName]').focus();
            $('#example tbody tr td input[type=text]').attr('disabled', true);
            if ($(this).closest('tr').find('td input[id^=CashBankFlag]').val() == "B") {
                $(this).closest('tr').find('td input[id^=AccBranchName]').show();
                $(this).closest('tr').find('td input[id^=AccChequeNumber]').show();
                $(this).closest('tr').find('td input[id^=AccChequeDate]').show();
            }
            if ($(this).closest('tr').find('td input[id^=CashBankFlag]').val() == "L" && $(this).closest('tr').find('td input[id^=PersonType]').val() == "") {
                $(this).closest('tr').find('td input[id^=SubLedger]').hide();
            }
            if ($(this).closest('tr').find('td input[id^=CashBankFlag]').val() == "L" && $(this).closest('tr').find('td input[id^=PersonType]').val() != "") {
                $(this).closest('tr').find('td input[id^=SubLedger]').show();
            }
            $(this).closest('tr').find('td input[type=text]').attr("disabled", false);
            //$('#example tbody').find('tr').eq(AccountTransactionMaster.rowCount - 1).find('td').eq(4).text('');
            //$('#example tbody').find('tr').eq(AccountTransactionMaster.rowCount - 1).find('td').eq(4).append('<a href="#" class="activate-row" ><i style="" class="icon-ok"></i></a>');

            //FOLLOWING FUNCTION MAKES DISABLED ROW ACTIVE
            $(".activate-row").click(function () {
                AccountTransactionMaster.HideControls();
                $('#example tbody tr td input[type=text]').attr('disabled', true);
                if ($(this).closest('tr').find('td input[id^=CashBankFlag]').val() == "B") {
                    $(this).closest('tr').find('td input[id^=AccBranchName]').show();
                    $(this).closest('tr').find('td input[id^=AccChequeNumber]').show();
                    $(this).closest('tr').find('td input[id^=AccChequeDate]').show();
                }
                if ($(this).closest('tr').find('td input[id^=CashBankFlag]').val() == "L" && $(this).closest('tr').find('td input[id^=PersonType]').val() == "") {
                    $(this).closest('tr').find('td input[id^=SubLedger]').hide();
                }
                if ($(this).closest('tr').find('td input[id^=CashBankFlag]').val() == "L" && $(this).closest('tr').find('td input[id^=PersonType]').val() != "") {
                    $(this).closest('tr').find('td input[id^=SubLedger]').show();
                }

                $(this).closest('tr').find('td input[type=text]').attr("disabled", false);
            });

        });


        //FOLLOWING FUNCTION IS TO REMOVE SELECTED ROW
        $('.remove-row').on("click", function () {

            $(this).closest('tr').remove();
            var _debitBal = 0;
            var _creditBal = 0;
            var length = $('#example tbody tr').length;

            for (var i = 0; i <= length ; i++) {
                var x;
                var y;
                x = $('#example tbody tr:eq(' + i + ')').find('td input[id^=debitBal]').val();
                _debitBal += parseFloat(x != null ? x : 0);

                y = $('#example tbody tr:eq(' + i + ')').find('td input[id^=creditBal]').val();
                _creditBal += parseFloat(y != null ? y : 0);

            }

            $("#debitBal").val(_debitBal.toFixed(2));
            $("#creditBal").val(_creditBal.toFixed(2));
            if (length == 0) {
                $("#tableDebitCredit").hide(true);
            }

        });


        //VALIDATION FOR DEBIT BALANCE
        $("#example tbody tr td input[id^=debitBal]").on('keydown', function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode != 9) {
                if ($(this).closest('tr').find('td input[id^=creditBal]').val() > 0) {
                    return false;
                }
            }
            else {
                return true;
            }

        });

        //VALIDATION FOR CREDIT BALANCE
        $("#example tbody tr td input[id^=creditBal]").on('keydown', function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode != 9) {
                if ($(this).closest('tr').find('td input[id^=debitBal]').val() > 0) {
                    return false;
                }
            }
            else {
                return true;
            }
        });

        //DATEPICKER FOR CHEQUE DATE FIELD
        $("#example tbody tr td input[id^=AccChequeDate]").datetimepicker({
            format: "DD MMMM YYYY",
            //changeMonth: true,
            //changeYear: true
        });

        //FOLLOWING FUNCTION BLOCKS KEYDOWN EVENT ON ACCCHEQUEDATE CONTROL
        $("#example tbody tr td input[id^=AccChequeDate]").on("keyup", function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode != 9) {
                return false;
            }
            else {
                return true;
            }
        });
    },


    HideControls: function () {
        $('#example tbody tr td input[id^=AccBranchName]').hide();
        $('#example tbody tr td input[id^=AccChequeNumber]').hide();
        $('#example tbody tr td input[id^=AccChequeDate]').hide();
        $('#example tbody tr td input[id^=SubLedger]').hide();
    },

    getDataFromDataTable: function () {
        //debugger;
        var DataArray = [];
        //  AccountTransactionMaster.t.destroy();
        //  var table = AccountTransactionMaster.t;
        var table = $('#example').DataTable();
        var data = table.$('input').each(function () {
            DataArray.push($(this).val());
        });
        AccountTransactionMaster.flag = true;
        table.destroy();
        var xmlParamList = "<rows>";
        var x = 0;
        debugger
        var Count = DataArray.length / 24;
        var transactionAmount = 0;
        var statusFlag = "";
        for (var i = 0; i < Count; i++) {
            debugger
            // String for Insert  DataArray[x + 3] == AccountID
            if (DataArray[x + 3] == "" && DataArray[x + 9] >= 0 && DataArray[x + 11] >= 0) {
                //$('#SuccessMessage').html("Please select account of debited amount " + DataArray[x + 9] + " or credited amount " + DataArray[x + 11]);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                notify("Please select account of debited amount " + DataArray[x + 9] + " or credited amount " + DataArray[x + 11], "warning");
                AccountTransactionMaster.flag = false;
                return false;
            }
                //else if (DataArray[x + 2] == "" && DataArray[x + 11] >= 0) {
                //    $('#SuccessMessage').html("Please select Account of credited amount " + DataArray[x + 11]);
                //    $('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                //    return false;
                //}
            else if (DataArray[x + 8] != "" && DataArray[x + 9] == "") {
                //$('#SuccessMessage').html("Please enter cheque date of cheque no" + DataArray[x + 8]);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                notify("Please enter cheque date of cheque no" + DataArray[x + 8], "warning");

                AccountTransactionMaster.flag = false;
                return false;
            }
            else if (DataArray[x + 3] == 0 || DataArray[x + 3] == "") {
                //$('#SuccessMessage').html("Please select proper account.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                notify("Please select proper account.", "warning");
                AccountTransactionMaster.flag = false;
                return false;
            }
            else if (DataArray[x + 14] == "B" && DataArray[x + 6] == "") {
                //$('#SuccessMessage').html("Please enter branch name.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                notify("Please enter branch name.", "warning");
                AccountTransactionMaster.flag = false;
                return false;
            }
            else if (DataArray[x + 8] != "" && DataArray[x + 10] == "") {
                //$('#SuccessMessage').html("Please enter cheque date of cheque no" + DataArray[x + 8]);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                notify("Please enter cheque date of cheque no" + DataArray[x + 8], "warning");
                AccountTransactionMaster.flag = false;
                return false;
            }
            else if (DataArray[x + 14] == "L" && DataArray[x + 13] != "" && DataArray[x + 12] == 0) {
                //$('#SuccessMessage').html("Please select sub-ledger account.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                notify("Please select sub-ledger account.", "warning");
                AccountTransactionMaster.flag = false;
                return false;
            }

            else if (DataArray[x + 3] != "" && DataArray[x + 9] > 0 || DataArray[x + 3] != "" && DataArray[x + 11] > 0) {
                if (DataArray[x + 9] > 0) {
                    transactionamount = DataArray[x + 9];
                    statusFlag = 'D';
                }
                else if (DataArray[x + 11] > 0) {
                    transactionamount = DataArray[x + 11];
                    statusFlag = 'C';
                }
                xmlParamList = xmlParamList + "<row><TransactionSubID>" + DataArray[x] + "</TransactionSubID><AccountID>" + DataArray[x + 3] + "</AccountID><DebitCreditFlag>" + statusFlag + "</DebitCreditFlag><TransactionAmount>" + transactionamount + "</TransactionAmount><ChequeNo>" + DataArray[x + 8] + "</ChequeNo><ChequeDatetime>" + DataArray[x + 10] + "</ChequeDatetime><NarrationDescription>" + DataArray[x + 7] + "</NarrationDescription><BankName>" + DataArray[x + 1] + "</BankName><BranchName>" + DataArray[x + 6] + "</BranchName><PersonID>" + DataArray[x + 12] + "</PersonID><PersonType>" + DataArray[x + 13] + "</PersonType><IsActive>1</IsActive><ReferencePersonType>" + DataArray[x + 23] + "</ReferencePersonType><ReferencePersonID>" + DataArray[x + 22] + "</ReferencePersonID></row>";
                //"<row><TransactionSubID>" + 0 + "</TransactionSubID><AccountID>" + DataArray[x + 1] + "</AccountID><DebitCreditFlag>" + statusFlag + "</DebitCreditFlag><TransactionAmount>" + transactionamount + "</TransactionAmount><ChequeNo>" + 00001 + "</ChequeNo><ChequeDatetime>" + 2014 - 01 - 01 + "</ChequeDatetime><NarrationDescription>" + DataArray[x + 2] + "</NarrationDescription><BankName>" + DataArray[x] + "</BankName><BranchName>" + ASD + "</BranchName><PersonID>" + 0 + "</PersonID><PersonType>" + S + "</PersonType><IsActive>1</IsActive></row>"
                // xmlParamList = xmlParamList + "<row><AccountName>" + DataArray[x] + "</AccountName><AccountID>" + DataArray[x + 1] + "</AccountID><Narration>" + DataArray[x + 2] + "</Narration><DebitAmount>" + DataArray[x + 3] + "</DebitAmount><CreditAmount>" +  DataArray[x + 4] * -1 + "</CreditAmount></row>";
            }
            x = x + 24
            ;
        }
        xmlParamList = xmlParamList + "</rows>";
        AccountTransactionMaster.SelectedXmlData = xmlParamList;

        //alert($("#Total_debitBal").val());
        //alert($("#Total_creditBal").val());

    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        //debugger;

        var Balancesheet = $("#selectedBalsheetID").val();
        var SelectedTransactionType = $('#SelectedTransactionType :selected').val();
        var selectedTransactionTypeText = $('#SelectedTransactionType :selected').text();

        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { "selectedTransactionCode": SelectedTransactionType, "selectedTransactionTypeText": selectedTransactionTypeText, "selectedBalsheet": Balancesheet, "actionMode": actionMode },
            dataType: "html",
            url: '/AccountTransactionMaster/Create',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                $("#NarrationDescription").val("");
                $("#debitBal").val(0);
                $("#creditBal").val(0);
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    //LoadList method is used to load List page
    LoadListBySelectedTransactionType: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        var SelectedTransactionType = $('#SelectedTransactionType :selected').val();
        var selectedTransactionTypeText = $('#SelectedTransactionType :selected').text();
        $.ajax(
         {
             cache: false,
             type: "GET",
             dataType: "html",
             data: { "selectedTransactionCode": SelectedTransactionType, "selectedTransactionTypeText": selectedTransactionTypeText, "selectedBalsheet": Balancesheet },
             url: '/AccountTransactionMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
                 $('#LiSessionName').show(true);
                 //  $('#btnCreateTransaction').show(true);
             }
         });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAccountTransactionMaster: function () {

        var AccountTransactionMasterData = null;
        if (AccountTransactionMaster.ActionName == "Create") {
            $("#FormCreateAccountTransactionMaster").validate();
            if ($("#FormCreateAccountTransactionMaster").valid()) {
                AccountTransactionMasterData = null;
                AccountTransactionMasterData = AccountTransactionMaster.GetAccountTransactionMaster();
                ajaxRequest.makeRequest("/AccountTransactionMaster/Create", "POST", AccountTransactionMasterData, AccountTransactionMaster.Success);
            }
        }
        else if (AccountTransactionMaster.ActionName == "Edit") {

            AccountTransactionMasterData = null;
            AccountTransactionMasterData = AccountTransactionMaster.GetAccountTransactionMaster();
            ajaxRequest.makeRequest("/AccountTransactionMaster/Edit", "POST", AccountTransactionMasterData, AccountTransactionMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountTransactionMaster: function () {
        var Data = {
        };

        if (AccountTransactionMaster.ActionName == "Create" || AccountTransactionMaster.ActionName == "Edit") {

            Data.AccBalsheetMstID = $("#selectedBalsheetID").val();
            Data.TransactionDate = $("#TransactionDate").val();
            Data.NarrationDescription = $("#NarrationDescription").val();
            Data.ID = $("#ID").val();
            Data.AccSessionID = $("#AccSessionID").val();
            Data.TransactionTypeCode = $("#SelectedTransactionType :selected").val();
            Data.SelectedXmlData = AccountTransactionMaster.SelectedXmlData;
            Data.VoucherAmount = AccountTransactionMaster.VoucherAmount;
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            // parent.$.colorbox.close();
            AccountTransactionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
            //$('#SuccessMessage').html(splitData[0]);
            //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
        } else {
            //parent.$.colorbox.close();

            AccountTransactionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },

};