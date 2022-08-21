//this class contain methods related to nationality functionality
var ECommerceSystemSettings = {
    //Member variables
    ActionName: null,
    map: {},
    map2: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ECommerceSystemSettings.constructor();
        //ECommerceSystemSettings.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });
      
        InitAnimatedBorder();

        CloseAlert();

    },
    Save: function () {
        $('#SaveECommerceSystemSettingsRecord').on("click", function () {
            debugger
            ECommerceSystemSettings.ActionName = "Save";
            if ($('#TaskCode').val() == 'GeneralMenusData') {
                ECommerceSystemSettings.getValueUsingParentTag_Check_UnCheck();
            }
            ECommerceSystemSettings.AjaxCallECommerceSystemSettings();
        });
    },
    CreateTab: function () {
        $('ul#TaskList li').click(function () {
            debugger;
            var Newurl = '';
            var TaskCode = $(this).attr('id');
            if (TaskCode == "GeneralStoreData") {
                Newurl = '/ECommerceSystemSettings/CreateGeneralStoreData';
            }
            else if (TaskCode == "GeneralMenusData") {
                Newurl = '/ECommerceSystemSettings/CreateGeneralMenusData';
            }
            $.ajax(
                  {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: { "TaskCode": TaskCode },
                      url: Newurl,
                      success: function (result) {
                          //alert(result);
                          $('.tab-content').html(result);
                      }
                  });
             });
        },
    //LoadList method is used to load List page
    LoadList: function () {
        debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { },
             dataType: "html",
             url: '/ECommerceSystemSettings/List',
             success: function (result) {
                 //Rebind Grid Data                
                 $('#ListViewModel').html(result);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
     
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { },
            url: '/ECommerceSystemSettings/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    
   
    getValueUsingParentTag_Check_UnCheck: function () {
        debugger
        var sArray = [];
        var chkArray = [];
        var xmlParamList = "<rows>"
        $(".gruop:checked").each(function () {
            chkArray.push($(this).val());
            sArray.push($(this).next().next().text());
        });
            var TotalRecord = chkArray.length;
            var x = 1;
            for (var i = 0; i < TotalRecord; i++) {

                xmlParamList = xmlParamList + "<row>" + "<ID>" + 0 + "</ID>" + "<SequenceNumber>" + x + "</SequenceNumber>" + "<LevelNumber>" + chkArray[i] + "</LevelNumber>" + "<Name>" + sArray[i] + "</Name>" + "<NextLevel>" + chkArray[i + 1] + "</NextLevel>" + "</row>";
                x = x + 1;
                  }
            //alert(xmlParamList)
              if(xmlParamList.length > 6)
                  ECommerceSystemSettings.SelectedIDs = xmlParamList + "</rows>";
             else
                  ECommerceSystemSettings.SelectedIDs = " ";
         
      

    },
    //Fire ajax call to insert update and delete record

    AjaxCallECommerceSystemSettings: function () {
        var ECommerceSystemSettingsData = null;
         if (ECommerceSystemSettings.ActionName == "Save") {

            $("#FormCreateGeneralMenusData").validate();
            if ($("#FormCreateECommerceSystemSettings").valid()) {
                ECommerceSystemSettingsData = null;
                ECommerceSystemSettingsData = ECommerceSystemSettings.GetECommerceSystemSettings();
                ajaxRequest.makeRequest("/ECommerceSystemSettings/Create", "POST", ECommerceSystemSettingsData, ECommerceSystemSettings.Success, "SaveECommerceSystemSettingsRecord");

            }
        }
       
    },
    //Get properties data from the Create, Update and Delete page
    GetECommerceSystemSettings: function () {
        debugger;
        var GeneralUnitsID = $('#GeneralUnitsID :selected').val();
        var Data = {
        };
        if (ECommerceSystemSettings.ActionName == "Create" || ECommerceSystemSettings.ActionName == "Save") {
            Data.TaskCode = $('#TaskCode').val();
            //ECommerceStoreData
            if (Data.TaskCode == 'GeneralStoreData' || Data.TaskCode == '' || Data.TaskCode == null) {
                Data.EComStoreSettingID = $('#EComStoreSettingID').val();
                Data.GeneralUnitsID = GeneralUnitsID;
            }
             //ECommerceCategoryData
            else if (Data.TaskCode == 'GeneralMenusData') {
                Data.EComCategorySettingID = $('#EComCategorySettingID').val();
                Data.SelectedIDs = ECommerceSystemSettings.SelectedIDs;
            }
        }
        
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            notify(splitData[0], splitData[1]);
            var TaskCode = $('#TaskCode').val();
            $("#" + TaskCode).click();
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};




