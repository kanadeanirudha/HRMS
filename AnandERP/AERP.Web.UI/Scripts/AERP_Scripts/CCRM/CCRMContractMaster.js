//this class contain methods related to nationality functionality
var CCRMContractMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMContractMaster.constructor();
        //CCRMContractMaster.initializeValidation();
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
        $('#CreateCCRMContractMasterRecord').on("click", function () {
            debugger;
            CCRMContractMaster.ActionName = "Create";
            CCRMContractMaster.AjaxCallCCRMContractMaster();
        });

        $('#EditCCRMContractMasterRecord').on("click", function () {

            CCRMContractMaster.ActionName = "Edit";
            CCRMContractMaster.AjaxCallCCRMContractMaster();
        });

        $('#DeleteCCRMContractMasterRecord').on("click", function () {

            CCRMContractMaster.ActionName = "Delete";
            CCRMContractMaster.AjaxCallCCRMContractMaster();
        });
        //$('#ActionTitle').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        //$('#FeedbackPoints').on("keydown", function (e) {
        //    AERPValidation.AllowNumbersOnly(e);
        //});
        $('#ContractDate').datetimepicker({
            format: 'DD MMM YYYY',
           // maxDate: moment(),

        });
       
        $('#ContractOpDate').datetimepicker({
            format: 'DD MMM YYYY',
            maxDate: moment(),
           
           // ignoreReadonly: true,
        })
        $('#ContractClosingDate').datetimepicker({
            format: 'DD MMM YYYY',
            minDate: moment(),

        });
        $('#CustOrderDate').datetimepicker({
            format: 'DD MMM YYYY',
           // maxDate: moment(),

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

    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/CCRMContractMaster/List',
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
            url: '/CCRMContractMaster/List',
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
    AjaxCallCCRMContractMaster: function () {
        var CCRMContractMasterData = null;
        if (CCRMContractMaster.ActionName == "Create") {
            $("#FormCreateCCRMContractMaster").validate();
            if ($("#FormCreateCCRMContractMaster").valid()) {
                CCRMContractMasterData = null;
                CCRMContractMasterData = CCRMContractMaster.GetCCRMContractMaster();
                ajaxRequest.makeRequest("/CCRMContractMaster/Create", "POST", CCRMContractMasterData, CCRMContractMaster.Success);
            }
        }
        else if (CCRMContractMaster.ActionName == "Edit") {
            $("#FormEditCCRMContractMaster").validate();
            if ($("#FormEditCCRMContractMaster").valid()) {
                CCRMContractMasterData = null;
                CCRMContractMasterData = CCRMContractMaster.GetCCRMContractMaster();
                ajaxRequest.makeRequest("/CCRMContractMaster/Edit", "POST", CCRMContractMasterData, CCRMContractMaster.Success);
            }
        }
        else if (CCRMContractMaster.ActionName == "Delete") {
            CCRMContractMasterData = null;
            //$("#FormCreateCCRMContractMaster").validate();
            CCRMContractMasterData = CCRMContractMaster.GetCCRMContractMaster();

            ajaxRequest.makeRequest("/CCRMContractMaster/Delete", "POST", CCRMContractMasterData, CCRMContractMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMContractMaster: function () {
       
        var Data = {
        };
        if (CCRMContractMaster.ActionName == "Create" || CCRMContractMaster.ActionName == "Edit") {
             debugger;
            Data.ID = $('#ID').val();

            Data.FinancialyearID = $('#FinancialyearID').val();
            Data.ContractDate = $('#ContractDate').val();
            Data.ContractTypeId = $('#ContractTypeId').val();
            alert($('#ContractTypeId').val())
            Data.ContractNo = $('#ContractNo').val();
            Data.SerialNo = $('#SerialNo').val();
            Data.ModelNo = $('#ModelNo').val();
            Data.MIFName = $('#MIFName').val();
            Data.MIFAddress = $('#MIFAddress').val();
            //Data.CustomerCode = $('#CustomerCode').val();
            Data.CustomerMasterID = $('#CustomerMasterID').val();
            Data.CustomerAddress = $('#CustomerAddress').val();
         
            Data.PaperSize = $('#PaperSize').val();
            Data.ContractOpDate = $('#ContractOpDate').val();
            Data.ContractClosingDate = $('#ContractClosingDate').val();
            Data.CustOrderNo = $('#CustOrderNo').val();
            Data.CustOrderDate = $('#CustOrderDate').val();
            Data.BillTypeId = $('#BillTypeId').val();
            Data.BillType = $('#BillType').val();
            Data.ContractStatus = $('#ContractStatus').val();
            Data.StartReadA4Mono = $('#StartReadA4Mono').val();
            Data.StartReadA4Col = $('#StartReadA4Col').val();
            Data.StartReadA3Mono = $('#StartReadA3Mono').val();
            Data.StartReadA3Col = $('#StartReadA3Col').val();
            Data.RentPerCopyA4Mono = $('#RentPerCopyA4Mono').val();
            Data.RentPerCopyA4Col = $('#RentPerCopyA4Col').val();
            Data.RentPerCopyA3Mono = $('#RentPerCopyA3Mono').val();
            Data.RentPerCopyA3Col = $('#RentPerCopyA3Col').val();
            Data.FreeCopiesA4Mono = $('#FreeCopiesA4Mono').val();
            Data.FreeCopiesA4Col = $('#FreeCopiesA4Col').val();
            Data.FreeCopiesA3Mono = $('#FreeCopiesA3Mono').val();
            Data.FreeCopiesA3Col = $('#FreeCopiesA3Col').val();
            Data.MinCopiesA4Mono = $('#MinCopiesA4Mono').val();
            Data.MinCopiesA4Col = $('#MinCopiesA4Col').val();
            Data.MinCopiesA3Mono = $('#MinCopiesA3Mono').val();
            Data.MinCopiesA3Col = $('#MinCopiesA3Col').val();
            Data.TotalFreeA4Mono = $('#TotalFreeA4Mono').val();
            Data.TotalFreeA4Col = $('#TotalFreeA4Col').val();
            Data.TotalFreeA3Mono = $('#TotalFreeA3Mono').val();
            Data.TotalFreeA3Col = $('#TotalFreeA3Col').val();
            Data.InitFreeCopiesA4Mono = $('#InitFreeCopiesA4Mono').val();
            Data.InitFreeCopiesA4Col = $('#InitFreeCopiesA4Col').val();
            Data.InitFreeCopiesA3Mono = $('#InitFreeCopiesA3Mono').val();
            Data.InitFreeCopiesA3Col = $('#InitFreeCopiesA3Col').val();
            Data.ContractValue = $('#ContractValue').val();
            Data.BilledValue = $('#BilledValue').val();
            Data.RentalAmt = $('#RentalAmt').val();
            Data.WastePerc = $('#WastePerc').val();
            Data.AnnualCharges = $('#AnnualCharges').val();
            Data.ApplicableMonth = $('#ApplicableMonth').val();
            Data.BasicCharges = $('#BasicCharges').val();
            Data.PMPeriod = $('#PMPeriod').val();
            Data.CallsAllowed = $('#CallsAllowed').val();
            Data.Remarks = $('#Remarks').val();
            Data.CustomerName = $('#CustomerName').val();
            Data.ItemDescription = $('#ItemDescription').val();
            Data.ContractType = $('#ContractType').val();
            Data.ContractName = $('#ContractName').val();
            Data.Colour = $('#Colour').val();
           
          
        }
        else if (CCRMContractMaster.ActionName == "Delete") {
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

            CCRMContractMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMContractMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMContractMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMContractMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

