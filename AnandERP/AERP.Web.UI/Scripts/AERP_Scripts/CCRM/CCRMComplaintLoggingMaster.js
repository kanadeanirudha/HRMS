//this class contain methods related to nationality functionality
var CCRMComplaintLoggingMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMComplaintLoggingMaster.constructor();
        //CCRMComplaintLoggingMaster.initializeValidation();
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
        $('#CreateCCRMComplaintLoggingMasterRecord').on("click", function () {
            debugger;
            CCRMComplaintLoggingMaster.ActionName = "Create";
            CCRMComplaintLoggingMaster.AjaxCallCCRMComplaintLoggingMaster();
        });

        $('#EditCCRMComplaintLoggingMasterRecord').on("click", function () {

            CCRMComplaintLoggingMaster.ActionName = "Edit";
            CCRMComplaintLoggingMaster.AjaxCallCCRMComplaintLoggingMaster();
        });

        $('#DeleteCCRMComplaintLoggingMasterRecord').on("click", function () {

            CCRMComplaintLoggingMaster.ActionName = "Delete";
            CCRMComplaintLoggingMaster.AjaxCallCCRMComplaintLoggingMaster();
        });
        //$('#ActionTitle').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});
        //$('#FeedbackPoints').on("keydown", function (e) {
        //    AERPValidation.AllowNumbersOnly(e);
        //});
        $('#CallDate').datetimepicker({
            format: 'DD MMM YYYY hh:mm',
          //  format: 'YYYY-MM-DD hh:mm',
             //allowInputToggle: true
            // maxDate: moment(),
            //language: 'en',
            //pick12HourFormat: true
          //  inline: true,
           // sideBySide: true
        });
       
        $('#CompanyCallDate').datetimepicker({
            format: 'DD MMM YYYY',
            // maxDate: moment(),

        });
        $('#ContOpDate').datetimepicker({
            format: 'DD MMM YYYY',
            // maxDate: moment(),

        });
        $('#ContClDate').datetimepicker({
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
            url: '/CCRMComplaintLoggingMaster/List',
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
            url: '/CCRMComplaintLoggingMaster/List',
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
    AjaxCallCCRMComplaintLoggingMaster: function () {
        var CCRMComplaintLoggingMasterData = null;
        if (CCRMComplaintLoggingMaster.ActionName == "Create") {
            $("#FormCreateCCRMComplaintLoggingMaster").validate();
            if ($("#FormCreateCCRMComplaintLoggingMaster").valid()) {
                CCRMComplaintLoggingMasterData = null;
                CCRMComplaintLoggingMasterData = CCRMComplaintLoggingMaster.GetCCRMComplaintLoggingMaster();
                ajaxRequest.makeRequest("/CCRMComplaintLoggingMaster/Create", "POST", CCRMComplaintLoggingMasterData, CCRMComplaintLoggingMaster.Success);
            }
        }
        else if (CCRMComplaintLoggingMaster.ActionName == "Edit") {
            $("#FormEditCCRMComplaintLoggingMaster").validate();
            if ($("#FormEditCCRMComplaintLoggingMaster").valid()) {
                CCRMComplaintLoggingMasterData = null;
                CCRMComplaintLoggingMasterData = CCRMComplaintLoggingMaster.GetCCRMComplaintLoggingMaster();
                ajaxRequest.makeRequest("/CCRMComplaintLoggingMaster/Edit", "POST", CCRMComplaintLoggingMasterData, CCRMComplaintLoggingMaster.Success);
            }
        }
        else if (CCRMComplaintLoggingMaster.ActionName == "Delete") {
            CCRMComplaintLoggingMasterData = null;
            //$("#FormCreateCCRMComplaintLoggingMaster").validate();
            CCRMComplaintLoggingMasterData = CCRMComplaintLoggingMaster.GetCCRMComplaintLoggingMaster();

            ajaxRequest.makeRequest("/CCRMComplaintLoggingMaster/Delete", "POST", CCRMComplaintLoggingMasterData, CCRMComplaintLoggingMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMComplaintLoggingMaster: function () {

        var Data = {
        };
        if (CCRMComplaintLoggingMaster.ActionName == "Create" || CCRMComplaintLoggingMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();

            Data.CallDate = $('#CallDate').val();
            Data.CallTktNo = $('#CallTktNo').val();
            Data.CallTypeID = $('#CallTypeID').val();
            Data.SerialNo = $('#SerialNo').val();
            Data.MIFName = $('#MIFName').val();
            Data.CompanyCallDate = $('#CompanyCallDate').val();
            Data.CompanyCallNo = $('#CompanyCallNo').val();
            Data.CallerName = $('#CallerName').val();
            Data.CallerPh = $('#CallerPh').val();
            Data.EmailID = $('#EmailID').val();
            Data.SymptomID = $('#SymptomID').val();
            Data.SymptomCode = $('#SymptomCode').val();
            Data.SymptomTitle = $('#SymptomTitle').val();
            Data.ComPlaint = $('#ComPlaint').val();
            Data.MachineStatus = $('#MachineStatus').val();
            Data.Priority = $('#Priority').val();
            Data.A4Mono = $('#A4Mono').val();
            Data.A4Col = $('#A4Col').val();
            Data.A3Mono = $('#A3Mono').val();
            Data.A3Col = $('#A3Col').val();
            Data.CallCharges = $('#CallCharges').val();
            Data.CustApproval = $('input[id=CustApproval]:checked').val() ? true : false;
            Data.TeleSolution = $('input[id=TeleSolution]:checked').val() ? true : false;
            Data.SSSApproval = $('input[id=SSSApproval]:checked').val() ? true : false;
        
            Data.SplRemarks = $('#SplRemarks').val();
            Data.SplInstructions = $('#SplInstructions').val();
            Data.MCAddress = $('#MCAddress').val();
            Data.CustomertID = $('#CustomertID').val();
            Data.CustomerName = $('#CustomerName').val();
            Data.KeyOperatorID = $('#KeyOperatorID').val();
            Data.KeyOperator = $('#KeyOperator').val();
            Data.Phoneno = $('#Phoneno').val();
            Data.ModelNo = $('#ModelNo').val();
            Data.ContractTypeId = $('#ContractTypeId').val();
            Data.ContractType = $('#ContractType').val();
            Data.ContractNo = $('#ContractNo').val();
            Data.ContOpDate = $('#ContOpDate').val();
            Data.ContClDate = $('#ContClDate').val();
            Data.EngineerID = $('#EngineerID').val();
            Data.EnggMobNo = $('#EnggMobNo').val();
            Data.ItemDescription = $('#ItemDescription').val();
            Data.Solution = $('#Solution').val();
            Data.ComplaintSrNo = $('#ComplaintSrNo').val();
            Data.MIFID = $('#MIFID').val();
            Data.Allotment = $('input[id=Allotment]:checked').val() ? true : false;
            Data.CallStatus = $('#CallStatus').val();
        }
        else if (CCRMComplaintLoggingMaster.ActionName == "Delete") {
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

            CCRMComplaintLoggingMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMComplaintLoggingMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMComplaintLoggingMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        CCRMComplaintLoggingMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

