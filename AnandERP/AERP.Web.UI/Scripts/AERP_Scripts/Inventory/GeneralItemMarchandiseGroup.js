//this class contain methods related to nationality functionality
var GeneralItemMarchandiseGroup = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralItemMarchandiseGroup.constructor();
        //GeneralItemMarchandiseGroup.initializeValidation();
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



        // Create new record

        $('#CreateGeneralItemMarchandiseGroupRecord').on("click", function () {
          
            GeneralItemMarchandiseGroup.ActionName = "Create";
            GeneralItemMarchandiseGroup.AjaxCallGeneralItemMarchandiseGroup();
        });

        $('#EditGeneralItemMarchandiseGroupRecord').on("click", function () {

            GeneralItemMarchandiseGroup.ActionName = "Edit";
            GeneralItemMarchandiseGroup.AjaxCallGeneralItemMarchandiseGroup();
        });

        $('#DeleteGeneralItemMarchandiseGroupRecord').on("click", function () {

            GeneralItemMarchandiseGroup.ActionName = "Delete";
            GeneralItemMarchandiseGroup.AjaxCallGeneralItemMarchandiseGroup();
        });

        $('#GroupDescription').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MarchandiseGroupCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
           
        });

        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AERPValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AERPValidation.AllowCharacterOnly(e);
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


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralItemMarchandiseGroup/List',
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
            url: '/GeneralItemMarchandiseGroup/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralItemMarchandiseGroup: function () {
        var GeneralItemMarchandiseGroupData = null;

        if (GeneralItemMarchandiseGroup.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralItemMarchandiseGroup").validate();
            if ($("#FormCreateGeneralItemMarchandiseGroup").valid()) {
                GeneralItemMarchandiseGroupData = null;
                GeneralItemMarchandiseGroupData = GeneralItemMarchandiseGroup.GetGeneralItemMarchandiseGroup();
                ajaxRequest.makeRequest("/GeneralItemMarchandiseGroup/Create", "POST", GeneralItemMarchandiseGroupData, GeneralItemMarchandiseGroup.Success, "CreateGeneralItemMarchandiseGroupRecord");
            }
        }
        else if (GeneralItemMarchandiseGroup.ActionName == "Edit") {
            $("#FormEditGeneralItemMarchandiseGroup").validate();
            if ($("#FormEditGeneralItemMarchandiseGroup").valid()) {
                GeneralItemMarchandiseGroupData = null;
                GeneralItemMarchandiseGroupData = GeneralItemMarchandiseGroup.GetGeneralItemMarchandiseGroup();
                ajaxRequest.makeRequest("/GeneralItemMarchandiseGroup/Edit", "POST", GeneralItemMarchandiseGroupData, GeneralItemMarchandiseGroup.Success);
            }
        }
        else if (GeneralItemMarchandiseGroup.ActionName == "Delete") {

            GeneralItemMarchandiseGroupData = null;
            //$("#FormCreateGeneralItemMarchandiseGroup").validate();
            GeneralItemMarchandiseGroupData = GeneralItemMarchandiseGroup.GetGeneralItemMarchandiseGroup();
            ajaxRequest.makeRequest("/GeneralItemMarchandiseGroup/Delete", "POST", GeneralItemMarchandiseGroupData, GeneralItemMarchandiseGroup.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralItemMarchandiseGroup: function () {
        var Data = {
        };
        
        if (GeneralItemMarchandiseGroup.ActionName == "Create" || GeneralItemMarchandiseGroup.ActionName == "Edit") {
           
            Data.ID = $('#ID').val();
            Data.GroupDescription = $('#GroupDescription').val();
            Data.MarchandiseGroupCode = $('#MarchandiseGroupCode').val();
          
           
        }
        else if (GeneralItemMarchandiseGroup.ActionName == "Delete") {

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
            GeneralItemMarchandiseGroup.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

