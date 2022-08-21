//this class contain methods related to nationality functionality
var GeneralRequestMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralRequestMaster.constructor();
        //GeneralRequestMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

       $('#GroupDescription').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GroupDescription').focus();
            return false;
        });

        //*************For Only Get Primary key ID in Dropdown List****************
        $("#RequestApprovalBasedTable").change(function () {
            
            debugger;
            var selectedItem = $(this).val();
            GeneralRequestMaster.ResetBaseTableKeyValues();
            if (selectedItem != "") {
                var $ddlPrimaryKey = $("#RequestApprovalParamPrimaryKey");
                var $PrimaryKeyProgress = $("#states-loading-progress");
                var $ddlColumnList = $("#TaskApprovalTableDisplayField");
                var $ColumnListProgress = $("#states-loading-progress");
                $PrimaryKeyProgress.show();
                $ColumnListProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralRequestMaster/GetPrimaryKeyList",
                    data: { "tableName": selectedItem },
                    success: function (data) {
                        //------------------binding dropdown 1
                        $ddlPrimaryKey.html('');
                        $('#RequestApprovalParamPrimaryKey').append('<option value>----------Select Primary Key ----------</option>');
                        $.each(data.Result1, function (id, option) {

                            $ddlPrimaryKey.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $PrimaryKeyProgress.hide();
                        //------------------binding dropdown 2
                        $ddlColumnList.html('');
                        $('#TaskApprovalTableDisplayField').append('<option value>----------Select Display Field----------</option>');
                        $.each(data.Result2, function (id, option) {

                            $ddlColumnList.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ColumnListProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve data.');
                        $PrimaryKeyProgress.hide();
                    }
                });
            }
            else {
                $('#RequestApprovalParamPrimaryKey').find('option').remove().end().append('<option value>----------Select Primary Key ----------</option>');
                $('#TaskApprovalTableDisplayField').find('option').remove().end().append('<option value>----------Select Display Field----------</option>');
            }
        });

        $('#RequestApprovalParamPrimaryKey').on("change", function () {
            GeneralRequestMaster.ResetBaseTableKeyValues();
        });
       


        // Create new record

        $('#CreateGeneralRequestMasterRecord').on("click", function () {
            debugger;
            GeneralRequestMaster.ActionName = "Create";
            //GeneralRequestMaster.GetPrimaryKeyValues();
            GeneralRequestMaster.AjaxCallGeneralRequestMaster();
        });

        //$('#EditGeneralRequestMasterRecord').on("click", function () {

        //    GeneralRequestMaster.ActionName = "Edit";
        //    GeneralRequestMaster.AjaxCallGeneralRequestMaster();
        //});

        $('#DeleteGeneralRequestMasterRecord').on("click", function () {
            debugger;
            GeneralRequestMaster.ActionName = "Delete";
            GeneralRequestMaster.AjaxCallGeneralRequestMaster();
        });

         //ResetBaseTableKeyValues: function () {
         //   $('#TaskApprovalKeyValue').find('option').remove().end().append('<option value>-----Select Primary Key Values-------</option>');
         //   $('#e5_f .ms-drop ul').html('<li class="ms-no-results" style="display: list-item;">No matches found</li>');



        //$('#GroupDescription').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        //$('#MarchandiseGroupCode').on("keydown", function (e) {
        //    AMSValidation.NotAllowSpaces(e);

        //});

        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AMSValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AMSValidation.AllowCharacterOnly(e);
        //  if (e.keyCode == 32) {
        //       return false;
        // }
        // });
        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").dataTable();
        //    oTable.fnFilter(this.value);
        //});

        //$("#searchBtn").click(function () {
        //    $("#UserSearch").focus();
        //});


        //$("#showrecord").change(function () {
        //    var showRecord = $("#showrecord").val();
        //    $("select[name*='myDataTable_length']").val(showRecord);
        //    $("select[name*='myDataTable_length']").change();
        //});

        // $(".ajax").colorbox();

        //ResetBaseTableKeyValues: function () {
        //    $('#TaskApprovalKeyValue').find('option').remove().end().append('<option value>-----Select Primary Key Values-------</option>');
        //    $('#e5_f .ms-drop ul').html('<li class="ms-no-results" style="display: list-item;">No matches found</li>');



    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralRequestMaster/List',
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
            url: '/GeneralRequestMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    ResetBaseTableKeyValues: function ()//**********For ID Append********** 
    {
        $('#TaskApprovalKeyValue').find('option').remove().end().append('<option value>-----Select Primary Key Values-------</option>');
        $('#e5_f .ms-drop ul').html('<li class="ms-no-results" style="display: list-item;">No matches found</li>');
    },

    AjaxCallGeneralRequestMaster: function () {
        var GeneralRequestMasterData = null;

        if (GeneralRequestMaster.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralRequestMaster").validate();
            if ($("#FormCreateGeneralRequestMaster").valid()) {
                GeneralRequestMasterData = null;
                GeneralRequestMasterData = GeneralRequestMaster.GetGeneralRequestMaster();
                ajaxRequest.makeRequest("/GeneralRequestMaster/Create", "POST", GeneralRequestMasterData, GeneralRequestMaster.Success, "CreateGeneralRequestMasterRecord");
            }
        }
      
            //else if (GeneralRequestMaster.ActionName == "Edit") {
            //    $("#FormEditGeneralRequestMaster").validate();
            //    if ($("#FormEditGeneralRequestMaster").valid()) {
            //        GeneralRequestMasterData = null;
            //        GeneralRequestMasterData = GeneralRequestMaster.GetGeneralRequestMaster();
            //        ajaxRequest.makeRequest("/GeneralRequestMaster/Edit", "POST", GeneralRequestMasterData, GeneralRequestMaster.Success);
            //    }
            //}
        else if (GeneralRequestMaster.ActionName == "Delete") {

            GeneralRequestMasterData = null;
            //$("#FormCreateGeneralRequestMaster").validate();
            GeneralRequestMasterData = GeneralRequestMaster.GetGeneralRequestMaster();
            ajaxRequest.makeRequest("/GeneralRequestMaster/Delete", "POST", GeneralRequestMasterData, GeneralRequestMaster.Success);

        }
    },



    //Method to create xml of Selected Criteria Param  
    GetPrimaryKeyValues: function () {
        debugger;
        var xmlParamList = "<rows>"
        $('#e5_f input[type=checkbox]').each(function () {

            if ($(this).val() != "on") {
                if (this.checked == true) {
                    xmlParamList = xmlParamList + "<row>" + "<PrimaryKeyValue>" + $(this).val().split('~')[0] + "</PrimaryKeyValue><DisplayKeyValue>" + $(this).val().split('~')[1] + "</DisplayKeyValue></row>";
                }
            }
        });
        if (xmlParamList.length > 6)
            GeneralRequestMaster.SelectedXMLstring = xmlParamList + "</rows>";
        else
            GeneralRequestMaster.SelectedXMLstring = "";
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralRequestMaster: function () {
        var Data = {
        };

        if (GeneralRequestMaster.ActionName == "Create") {
            debugger;
            //Data.ID = $('#ID').val();
            Data.RequestCode = $('#RequestCode').val();
            Data.RequestDescription = $('#RequestDescription').val();
            Data.MenuCode = $('#MenuCode').val();
            Data.RequestApprovalBasedTable = $('#RequestApprovalBasedTable').val();
            Data.RequestApprovalParamPrimaryKey = $('#RequestApprovalParamPrimaryKey').val();
           // Data.LinkMenuCode = $('#LinkMenuCode').val();
        }
        else if (GeneralRequestMaster.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            GeneralRequestMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
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
//       GeneralRequestMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        GeneralRequestMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


