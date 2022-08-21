//this class contain methods related to nationality functionality
var __Sidebar = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    initialize: function () {
        //organisationStudyCentre.loadData();

        __Sidebar.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        LoadMenuWithActiveTab(path);
    },

    //ReloadList method is used to load List page

    LoadMenuWithActiveTab: function (path) {
        debugger;
        //  var selectedText = $('#SelectedDepartmentIDforRoleMaster').text();
        var selectedText = $('#ddlModule :selected').text();
        var selectedVal = $('input[id=DefaultModuleID]').val();

        $.ajax(
          {
              cache: false,
              type: "GET",
              data: { ModuleID: selectedVal, path: path },

              dataType: "html",
              url: 'Base/BuildMenu',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#_Sidebar').html(result);
              }
          });
    },
};

