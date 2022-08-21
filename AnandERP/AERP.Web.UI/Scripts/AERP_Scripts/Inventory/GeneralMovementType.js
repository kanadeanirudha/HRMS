//this class contain methods related to nationality functionality
var GeneralMovementType = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralMovementType.constructor();
        //GeneralMovementType.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#MovementType').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
          
            return false;
        });



        // Create new record

        $('#CreateGeneralMovementTypeRecord').on("click", function () {
            
            GeneralMovementType.ActionName = "Create";
            GeneralMovementType.AjaxCallGeneralMovementType();
        });

        $('#CreateGeneralMovementTypeRulesRecord').on("click", function () {

            GeneralMovementType.ActionName = "CreateMovementTypeRules";
            //if ($('#TransactionType').val() == 3 && ($('#Action :selected').val() == 0 || $('#Action :selected').val() == null || $('#Action :selected').val() == ""))
            //{
            //    $("#displayErrorMessage p").text("Please Select Action.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    return false;
            //}
            GeneralMovementType.AjaxCallGeneralMovementType();
        });
        $('#EditGeneralMovementTypeRecord').on("click", function () {

            GeneralMovementType.ActionName = "Edit";
            GeneralMovementType.AjaxCallGeneralMovementType();
        });

        $('#DeleteGeneralMovementTypeRecord').on("click", function () {

            GeneralMovementType.ActionName = "Delete";
            GeneralMovementType.AjaxCallGeneralMovementType();
        });

        $('#MovementType').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MovementCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);

        });

        $("#TransactionType").on("change", function () {
            
        //    if ($('#TransactionType').val() == 0)
        //    {
                
        //        $('#Action').hide();
        //    }
        //else
        //    {
                $('#Action').show();
         //   }
          

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
        debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralMovementType/List',
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
            url: '/GeneralMovementType/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralMovementType: function () {
        var GeneralMovementTypeData = null;

        if (GeneralMovementType.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralMovementType").validate();
            if ($("#FormCreateGeneralMovementType").valid()) {
                GeneralMovementTypeData = null;
                GeneralMovementTypeData = GeneralMovementType.GetGeneralMovementType();
                ajaxRequest.makeRequest("/GeneralMovementType/Create", "POST", GeneralMovementTypeData, GeneralMovementType.Success, "CreateGeneralMovementTypeRecord");
            }
        }
        else if (GeneralMovementType.ActionName == "CreateMovementTypeRules") {
            $("#FormCreateGeneralMovementTypeRules").validate();
            if ($("#FormCreateGeneralMovementTypeRules").valid()) {
                GeneralMovementTypeData = null;
                GeneralMovementTypeData = GeneralMovementType.GetGeneralMovementType();
                ajaxRequest.makeRequest("/GeneralMovementType/CreateMovementTypeRules", "POST", GeneralMovementTypeData, GeneralMovementType.Success, "CreateGeneralMovementTypeRulesRecord");
            }
        }
        else if (GeneralMovementType.ActionName == "Edit") {
            $("#FormEditGeneralMovementType").validate();
            if ($("#FormEditGeneralMovementType").valid()) {
                GeneralMovementTypeData = null;
                GeneralMovementTypeData = GeneralMovementType.GetGeneralMovementType();
                ajaxRequest.makeRequest("/GeneralMovementType/Edit", "POST", GeneralMovementTypeData, GeneralMovementType.Success);
            }
        }
        else if (GeneralMovementType.ActionName == "Delete") {

            GeneralMovementTypeData = null;
            //$("#FormCreateGeneralMovementType").validate();
            GeneralMovementTypeData = GeneralMovementType.GetGeneralMovementType();
            ajaxRequest.makeRequest("/GeneralMovementType/Delete", "POST", GeneralMovementTypeData, GeneralMovementType.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralMovementType: function () {
        var Data = {
        };

        if (GeneralMovementType.ActionName == "Create" || GeneralMovementType.ActionName == "Edit") {
  
            Data.ID = $('#ID').val();
            Data.MovementType = $('#MovementType').val();
            Data.MovementCode = $('#MovementCode').val();
            Data.IsActive = $("#IsActive").is(":checked") ? "true" : "false";
        }
        else if (GeneralMovementType.ActionName == "CreateMovementTypeRules") {

            Data.ID = $('#ID').val();
            Data.TransactionType = $('#TransactionType').val();
            Data.Direction = $('#Direction').val();
            Data.Behaviour = $('#Behaviour').val();
            Data.Action = $('#Action :selected').val();
        }
        else if (GeneralMovementType.ActionName == "Delete") {

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
            GeneralMovementType.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

