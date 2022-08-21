//this class contain methods related to nationality functionality
var GeneralJobStatus = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralJobStatus.constructor();
        //GeneralJobStatus.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#RegionID').focus();
            $('#RegionID').val('');
        });

        // Create new record
        $('#CreateGeneralJobStatusRecord').on("click", function () {
            
            GeneralJobStatus.ActionName = "Create";
            GeneralJobStatus.AjaxCallGeneralJobStatus();
        });

        $('#EditGeneralJobStatusRecord').on("click", function () {
            
            GeneralJobStatus.ActionName = "Edit";
            GeneralJobStatus.AjaxCallGeneralJobStatus();
        });

        $('#DeleteGeneralJobStatusRecord').on("click", function () {

            GeneralJobStatus.ActionName = "Delete";
            GeneralJobStatus.AjaxCallGeneralJobStatus();
        });

        $('#JobStatusDescription').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });


        $('#JobStatusCode').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
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

        //$("#IsActive").change(function (e) {
        //    isActive = e.target;
        //    e.checked;
        //    //isActive = $("input[id=IsActive]:checked").val(); //? true : false;
        //    //alert(e.checked);
        //    alert((e.target || e.srcElement).value);
        //});

        

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralJobStatus/List',
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
            url: '/GeneralJobStatus/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralJobStatus: function () {
        var GeneralJobStatusData = null;
        if (GeneralJobStatus.ActionName == "Create") {
            $("#FormCreateGeneralJobStatus").validate();
            if ($("#FormCreateGeneralJobStatus").valid()) {
                GeneralJobStatusData = null;
                GeneralJobStatusData = GeneralJobStatus.GetGeneralJobStatus();
                ajaxRequest.makeRequest("/GeneralJobStatus/Create", "POST", GeneralJobStatusData, GeneralJobStatus.Success);
            }
        }
        else if (GeneralJobStatus.ActionName == "Edit") {
            debugger;
            $("#FormEditGeneralJobStatus").validate();
            if ($("#FormEditGeneralJobStatus").valid()) {
                GeneralJobStatusData = null;
                GeneralJobStatusData = GeneralJobStatus.GetGeneralJobStatus();
                ajaxRequest.makeRequest("/GeneralJobStatus/Edit", "POST", GeneralJobStatusData, GeneralJobStatus.Success);
            }
        }
        else if (GeneralJobStatus.ActionName == "Delete") {
            GeneralJobStatusData = null;
            $("#FormDeleteGeneralJobStatus").validate();
            GeneralJobStatusData = GeneralJobStatus.GetGeneralJobStatus();
            ajaxRequest.makeRequest("/GeneralJobStatus/Delete", "POST", GeneralJobStatusData, GeneralJobStatus.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralJobStatus: function () {
        var Data = {
        };
        if (GeneralJobStatus.ActionName == "Create" || GeneralJobStatus.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.JobStatusDescription = $('#JobStatusDescription').val();
            Data.JobStatusCode = $('#JobStatusCode').val();
            //Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
            //Data.IsActive = $('input[id=IsActive]:checked').val() ? true : false;
            Data.IsActive = $("input[id=IsActive]:checked").val() ? true : false;

        }
        else if (GeneralJobStatus.ActionName == "Delete") {
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
            GeneralJobStatus.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralJobStatus.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    
    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GeneralJobStatus.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        GeneralJobStatus.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

