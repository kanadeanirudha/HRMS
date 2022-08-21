//this class contain methods related to nationality functionality
var GeneralTaxGroupMaster = {
    //Member variables
    ActionName: null,
    SelectedTaxMaterIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralTaxGroupMaster.constructor();
        //GeneralTaxGroupMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#TaxGroupName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $(".ms-choice span").text('');

            $('#TaxGroupName').focus();
            return false;
        });

        // Create new record
        $('#CreateGeneralTaxGroupMasterRecord').on("click", function () {
            debugger;
            GeneralTaxGroupMaster.ActionName = "Create";
            GeneralTaxGroupMaster.getValueUsingParentTag_Check_UnCheck();
            if (GeneralTaxGroupMaster.SelectedTaxMaterIDs != "" && GeneralTaxGroupMaster.SelectedTaxMaterIDs != null) {
                GeneralTaxGroupMaster.AjaxCallGeneralTaxGroupMaster();
            }
            else {
                //  ajaxRequest.ErrorMessageForJS("Message_RecordAlreadyExists", "DivSuccessMessage");
                $('#DivSuccessMessage').html("Please select at least one tax name.");
                $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }

        });

        $('#EditGeneralTaxGroupMasterRecord').on("click", function () {

            GeneralTaxGroupMaster.ActionName = "Edit";
            GeneralTaxGroupMaster.AjaxCallGeneralTaxGroupMaster();
        });

        $('#DeleteGeneralTaxGroupMasterRecord').on("click", function () {

            GeneralTaxGroupMaster.ActionName = "Delete";
            GeneralTaxGroupMaster.AjaxCallGeneralTaxGroupMaster();
        });
        $('#TaxGroupName').on("keydown", function (e) {
            AERPValidation.AllowAlphaNumericOnly(e);
        });

        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
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



    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralTaxGroupMaster/List',
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
            data: { "actionMode": actionMode },
            url: '/GeneralTaxGroupMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralTaxGroupMaster: function () {
        var GeneralTaxGroupMasterData = null;
        if (GeneralTaxGroupMaster.ActionName == "Create") {
            $("#FormCreateGeneralTaxGroupMaster").validate();
            if ($("#FormCreateGeneralTaxGroupMaster").valid()) {
                GeneralTaxGroupMasterData = null;
                GeneralTaxGroupMasterData = GeneralTaxGroupMaster.GetGeneralTaxGroupMaster();
                ajaxRequest.makeRequest("/GeneralTaxGroupMaster/Create", "POST", GeneralTaxGroupMasterData, GeneralTaxGroupMaster.Success);
            }
        }
        else if (GeneralTaxGroupMaster.ActionName == "Edit") {
            $("#FormEditGeneralTaxGroupMaster").validate();
            if ($("#FormEditGeneralTaxGroupMaster").valid()) {
                GeneralTaxGroupMasterData = null;
                GeneralTaxGroupMasterData = GeneralTaxGroupMaster.GetGeneralTaxGroupMaster();
                ajaxRequest.makeRequest("/GeneralTaxGroupMaster/Edit", "POST", GeneralTaxGroupMasterData, GeneralTaxGroupMaster.Success);
            }
        }
        else if (GeneralTaxGroupMaster.ActionName == "Delete") {
            GeneralTaxGroupMasterData = null;
            //$("#FormCreateGeneralTaxGroupMaster").validate();
            GeneralTaxGroupMasterData = GeneralTaxGroupMaster.GetGeneralTaxGroupMaster();
            ajaxRequest.makeRequest("/GeneralTaxGroupMaster/Delete", "POST", GeneralTaxGroupMasterData, GeneralTaxGroupMaster.Success);

        }
    },


    getValueUsingParentTag_Check_UnCheck: function () {

        var sList = "";
        var taxMasterID = 0;
        var xmlParamList = "<rows>"
        //alert();
        //$('#checkboxlist input[type=checkbox]').each(function () {
        $('#checkboxlist option').each(function () {
            
            if ($(this).val() != "on") {
                taxMasterID = $(this).val();
                //sArray = $(this).val().split("~");
                if (this.selected == true) {
                    
                    //xmlInsert code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + 0 + "</ID>" + "<GenTaxMasterID>" + taxMasterID + "</GenTaxMasterID></row>";
                }

            }
            
        });
        if (xmlParamList.length > 6)
            GeneralTaxGroupMaster.SelectedTaxMaterIDs = xmlParamList + "</rows>";
        else
            GeneralTaxGroupMaster.SelectedTaxMaterIDs = "";
        // alert(GeneralTaxGroupMaster.SelectedTaxMaterIDs);
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralTaxGroupMaster: function () {
        var Data = {
        };
        if (GeneralTaxGroupMaster.ActionName == "Create" || GeneralTaxGroupMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.TaxGroupName = $('#TaxGroupName').val();
            Data.SelectedTaxMaterIDs = GeneralTaxGroupMaster.SelectedTaxMaterIDs;
        }
        else if (GeneralTaxGroupMaster.ActionName == "Delete") {
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
            GeneralTaxGroupMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralTaxGroupMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

