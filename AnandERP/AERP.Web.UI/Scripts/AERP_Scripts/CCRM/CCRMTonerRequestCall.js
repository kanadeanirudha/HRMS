//this class contain methods related to nationality functionality
var CCRMTonerRequestCall = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMTonerRequestCall.constructor();
        //CCRMTonerRequestCall.initializeValidation();
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
        $('#CreateCCRMTonerRequestCallRecord').on("click", function () {
            CCRMTonerRequestCall.ActionName = "Create";
            CCRMTonerRequestCall.AjaxCallCCRMTonerRequestCall();
        });

        $('#EditCCRMTonerRequestCallRecord').on("click", function () {

            CCRMTonerRequestCall.ActionName = "Edit";
            CCRMTonerRequestCall.AjaxCallCCRMTonerRequestCall();
        });

        $('#DeleteCCRMTonerRequestCallRecord').on("click", function () {

            CCRMTonerRequestCall.ActionName = "Delete";
            CCRMTonerRequestCall.AjaxCallCCRMTonerRequestCall();
        });
        $("#FOC").prop("checked", true);
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });
        $("#CurrentMeterRead").on("keydown keyup", function () {
            
            sub();
        });
        function sub() {
          
            var num1 = document.getElementById('CurrentMeterRead').value;
            var num2 = document.getElementById('LastMtrRead').value;
           
            var result1 = parseInt(num1) - parseInt(num2);
           // if (!isNaN(result)) {
              
                document.getElementById('Consumption').value = result1;
           // }
        }
        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });
        $('#CallDate').datetimepicker({
            
            format: 'DD MMM YYYY',
            maxDate: moment(),
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

    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/CCRMTonerRequestCall/List',
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
            url: '/CCRMTonerRequestCall/List',
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
    AjaxCallCCRMTonerRequestCall: function () {
        var CCRMTonerRequestCallData = null;
        if (CCRMTonerRequestCall.ActionName == "Create") {
            $("#FormCreateCCRMTonerRequestCall").validate();
            if ($("#FormCreateCCRMTonerRequestCall").valid()) {
                CCRMTonerRequestCallData = null;
                CCRMTonerRequestCallData = CCRMTonerRequestCall.GetCCRMTonerRequestCall();
                ajaxRequest.makeRequest("/CCRMTonerRequestCall/Create", "POST", CCRMTonerRequestCallData, CCRMTonerRequestCall.Success);
            }
        }
        else if (CCRMTonerRequestCall.ActionName == "Edit") {
            $("#FormEditCCRMTonerRequestCall").validate();
            if ($("#FormEditCCRMTonerRequestCall").valid()) {
                CCRMTonerRequestCallData = null;
                CCRMTonerRequestCallData = CCRMTonerRequestCall.GetCCRMTonerRequestCall();
                ajaxRequest.makeRequest("/CCRMTonerRequestCall/Edit", "POST", CCRMTonerRequestCallData, CCRMTonerRequestCall.Success);
            }
        }
        else if (CCRMTonerRequestCall.ActionName == "Delete") {
            CCRMTonerRequestCallData = null;
            //$("#FormCreateCCRMTonerRequestCall").validate();
            CCRMTonerRequestCallData = CCRMTonerRequestCall.GetCCRMTonerRequestCall();

            ajaxRequest.makeRequest("/CCRMTonerRequestCall/Delete", "POST", CCRMTonerRequestCallData, CCRMTonerRequestCall.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMTonerRequestCall: function () {

        var Data = {
        };
        if (CCRMTonerRequestCall.ActionName == "Create" || CCRMTonerRequestCall.ActionName == "Edit") {
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
        }
        else if (CCRMTonerRequestCall.ActionName == "Delete") {
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

            CCRMTonerRequestCall.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMTonerRequestCall.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMTonerRequestCall.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMTonerRequestCall.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

