//this class contain methods related to nationality functionality
var GeneralUnitType = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralUnitType.constructor();
        //GeneralUnitType.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#UnitType').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#UnitType').focus();
            return false;
        });



        // Create new record
       
        $('#CreateGeneralUnitTypeRecord').on("click", function ()
        {
            
            GeneralUnitType.ActionName = "Create";
            GeneralUnitType.AjaxCallGeneralUnitType();
        });

        $('#EditGeneralUnitTypeRecord').on("click", function () {

            GeneralUnitType.ActionName = "Edit";
            GeneralUnitType.AjaxCallGeneralUnitType();
        });

        $('#DeleteGeneralUnitTypeRecord').on("click", function () {
            
            GeneralUnitType.ActionName = "Delete";
            GeneralUnitType.AjaxCallGeneralUnitType();
        });

        $('#UnitType').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
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
             url: '/GeneralUnitType/List',
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
            url: '/GeneralUnitType/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralUnitType: function () {
        var GeneralUnitTypeData = null;
        
        if (GeneralUnitType.ActionName == "Create") {
            $("#FormCreateGeneralUnitType").validate();
            if ($("#FormCreateGeneralUnitType").valid()) {
                GeneralUnitTypeData = null;
                GeneralUnitTypeData = GeneralUnitType.GetGeneralUnitType();
             ajaxRequest.makeRequest("/GeneralUnitType/Create", "POST", GeneralUnitTypeData, GeneralUnitType.Success, "CreateGeneralUnitTypeRecord");
            }
        }
        else if (GeneralUnitType.ActionName == "Edit") {
            $("#FormEditGeneralUnitType").validate();
            if ($("#FormEditGeneralUnitType").valid()) {
                GeneralUnitTypeData = null;
                GeneralUnitTypeData = GeneralUnitType.GetGeneralUnitType();
                ajaxRequest.makeRequest("/GeneralUnitType/Edit", "POST", GeneralUnitTypeData, GeneralUnitType.Success);
            }
        }
        else if (GeneralUnitType.ActionName == "Delete") {
            
            GeneralUnitTypeData = null;
            //$("#FormCreateGeneralUnitType").validate();
            GeneralUnitTypeData = GeneralUnitType.GetGeneralUnitType();
            ajaxRequest.makeRequest("/GeneralUnitType/Delete", "POST", GeneralUnitTypeData, GeneralUnitType.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralUnitType: function () {
        var Data = {
        };
        
        if (GeneralUnitType.ActionName == "Create" || GeneralUnitType.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.UnitType = $('#UnitType').val();
            Data.RelatedWith = $('#RelatedWith').val();
           // Data.SeqNo = $('#SeqNo').val();
           // Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
        }
        else if (GeneralUnitType.ActionName == "Delete")
        {
            
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
            GeneralUnitType.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
  
};

   
