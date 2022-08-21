//this class contain methods related to nationality functionality
var CCRMTonerRequestAuthorisation = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMTonerRequestAuthorisation.constructor();
        //CCRMTonerRequestAuthorisation.initializeValidation();
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
        $('#CreateCCRMTonerRequestAuthorisationRecord').on("click", function () {
            CCRMTonerRequestAuthorisation.ActionName = "Create";
            CCRMTonerRequestAuthorisation.AjaxCallCCRMTonerRequestAuthorisation();
        });

        $('#EditCCRMTonerRequestAuthorisationRecord').on("click", function () {

            CCRMTonerRequestAuthorisation.ActionName = "Edit";
            CCRMTonerRequestAuthorisation.AjaxCallCCRMTonerRequestAuthorisation();
        });

        $('#DeleteCCRMTonerRequestAuthorisationRecord').on("click", function () {

            CCRMTonerRequestAuthorisation.ActionName = "Delete";
            CCRMTonerRequestAuthorisation.AjaxCallCCRMTonerRequestAuthorisation();
        });
        $("#FOC").prop("checked", true);
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });
        $("#Date").click(function () {
            if ($(this).is(":checked")) {
                $("#FromDate").removeAttr("disabled");
                $("#FromDate").focus();
            } else {
                $("#FromDate").attr("disabled", "disabled");
            }
        });
        $("#Date").click(function () {
            if ($(this).is(":checked")) {
                $("#UptoDate").removeAttr("disabled");
                //$("#UptoDate").focus();
            } else {
                $("#UptoDate").attr("disabled", "disabled");
            }
        });
        //$("#Date").click(function () {
        //    if ($(this).is(":checked")) {
        //        $("#dvFromDate").show(300);
        //        $("#dvUptoDate").show(300);
        //    } else {
        //        $("#dvFromDate").hide(200);
        //        $("#dvUptoDate").hide(200);
        //    }
        //});
        //$("#CurrentMeterRead").on("keydown keyup", function () {

        //    sub();
        //});
        //function sub() {

        //    var num1 = document.getElementById('CurrentMeterRead').value;
        //    var num2 = document.getElementById('LastMtrRead').value;

        //    var result1 = parseInt(num1) - parseInt(num2);
        //    // if (!isNaN(result)) {

        //    document.getElementById('Consumption').value = result1;
        //    // }
        //}
        $('#btnShowListforList').click(function () {
            debugger;
            var FromDate = $('#FromDate').val();
            var UptoDate = $('#UptoDate').val();
            //if (TransactionUptoDate == " " || TransactionUptoDate == null) {
            //    notify("Please Transaction Upto Date", "danger");
            //}
            //else if (TransactionFromDate == "" || TransactionFromDate == null) {
            //    notify("Please Transaction From Date", "danger");
            //    // $('#DivCreateNew').hide(true);
            //}
           // else if (TransactionUptoDate != "" && TransactionFromDate != "") {
            CCRMTonerRequestAuthorisation.LoadList(FromDate, UptoDate);
            //}
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

    },
    //LoadList method is used to load List page
    LoadList: function (FromDate, UptoDate) {
        debugger;
        $.ajax({
            cache: false,
            type: "POST",
            // data: { "FromDate": $("#FromDate").val(), "UptoDate": $("#UptoDate").val() },
            data: { FromDate: FromDate, UptoDate: UptoDate },
            dataType: "html",
            url: '/CCRMTonerRequestAuthorisation/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var FromDate = $('#FromDate').val();
        var UptoDate = $('#UptoDate').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, FromDate: FromDate, UptoDate: UptoDate },
            url: '/CCRMTonerRequestAuthorisation/List',
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
    AjaxCallCCRMTonerRequestAuthorisation: function () {
        var CCRMTonerRequestAuthorisationData = null;
        if (CCRMTonerRequestAuthorisation.ActionName == "Create") {
            $("#FormCreateCCRMTonerRequestAuthorisation").validate();
            if ($("#FormCreateCCRMTonerRequestAuthorisation").valid()) {
                CCRMTonerRequestAuthorisationData = null;
                CCRMTonerRequestAuthorisationData = CCRMTonerRequestAuthorisation.GetCCRMTonerRequestAuthorisation();
                ajaxRequest.makeRequest("/CCRMTonerRequestAuthorisation/Create", "POST", CCRMTonerRequestAuthorisationData, CCRMTonerRequestAuthorisation.Success);
            }
        }
        else if (CCRMTonerRequestAuthorisation.ActionName == "Edit") {
            $("#FormEditCCRMTonerRequestAuthorisation").validate();
            if ($("#FormEditCCRMTonerRequestAuthorisation").valid()) {
                CCRMTonerRequestAuthorisationData = null;
                CCRMTonerRequestAuthorisationData = CCRMTonerRequestAuthorisation.GetCCRMTonerRequestAuthorisation();
                ajaxRequest.makeRequest("/CCRMTonerRequestAuthorisation/Edit", "POST", CCRMTonerRequestAuthorisationData, CCRMTonerRequestAuthorisation.Success);
            }
        }
        else if (CCRMTonerRequestAuthorisation.ActionName == "Delete") {
            CCRMTonerRequestAuthorisationData = null;
            //$("#FormCreateCCRMTonerRequestAuthorisation").validate();
            CCRMTonerRequestAuthorisationData = CCRMTonerRequestAuthorisation.GetCCRMTonerRequestAuthorisation();

            ajaxRequest.makeRequest("/CCRMTonerRequestAuthorisation/Delete", "POST", CCRMTonerRequestAuthorisationData, CCRMTonerRequestAuthorisation.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMTonerRequestAuthorisation: function () {

        var Data = {
        };
        if (CCRMTonerRequestAuthorisation.ActionName == "Create" || CCRMTonerRequestAuthorisation.ActionName == "Edit") {
            Data.ID = $('#ID').val();

            Data.CallDate = $('#CallDate').val();
            Data.CallTktNo = $('#CallTktNo').val();
            Data.SerialNo = $('#SerialNo').val();
            Data.ContractID = $('#ContractID').val();
            Data.ContractCode = $('#ContractCode').val();
            Data.MIFID = $('#MIFID').val();
            Data.MIFName = $('#MIFName').val();
            Data.ModelNo = $('#ModelNo').val();
            Data.MachineFamilyID = $('#MachineFamilyID').val();
            Data.PartNO = $('#PartNO').val();
            Data.PartName = $('#PartName').val();
            Data.BalanceQuantity = $('#BalanceQuantity').val();
            Data.Quantity = $('#Quantity').val();
            Data.FOC = $('input[id=FOC]:checked').val() ? true : false;
            Data.CurrentMeterRead = $('#CurrentMeterRead').val();
            Data.CallerName = $('#CallerName').val();
            Data.CallerPh = $('#CallerPh').val();
            Data.Remarks = $('#Remarks').val();
            Data.CallNo = $('#CallNo').val();
            Data.Consumption = $('#Consumption').val();
            Data.LastCallNo = $('#LastCallNo').val();
            Data.LastCallDate = $('#LastCallDate').val();
            Data.LastQuantity = $('#LastQuantity').val();
            Data.LastMtrRead = $('#LastMtrRead').val();
            Data.StandardCopy = $('#StandardCopy').val();
            Data.Authorised = $('#Authorised').val();
        }
        else if (CCRMTonerRequestAuthorisation.ActionName == "Delete") {
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

            CCRMTonerRequestAuthorisation.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMTonerRequestAuthorisation.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMTonerRequestAuthorisation.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMTonerRequestAuthorisation.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

