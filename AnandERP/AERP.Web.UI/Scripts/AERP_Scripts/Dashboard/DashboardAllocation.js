
//this class contain methods related to nationality functionality
var DashboardAllocation = {

    ActionName: null,

    Initialize: function () {      
        DashboardAllocation.constructor();
    },

    //Attach all event of page
    constructor: function () {


        $("#btnShowList").on("click", function () {
            debugger;
            DashboardAllocation.LoadAllocatedDashBoardList($('#AdminRoleMasterID').val(), $('#ModuleCode').val());
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
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

        InitAnimatedBorder();
        CloseAlert();
    },

    ////Load method is used to load *-Load-* page
    LoadList: function () {
        debugger;
        $.ajax({
             cache: false,
             type: "POST",
             data: { AdminRoleMasterID: 0, ModuleCode: null, actionMode: null },
             dataType: "html",
             url: '/DashboardAllocation/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            data: { AdminRoleMasterID: $("#AdminRoleMasterID").val(), ModuleCode: $("#ModuleCode").val(), actionMode: actionMode },
            url: '/DashboardAllocation/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    LoadAllocatedDashBoardList: function (AdminRoleMasterID, ModuleCode) {
        debugger;
        $.ajax({
              cache: false,
              type: "POST",
              data: { AdminRoleMasterID: AdminRoleMasterID, ModuleCode: ModuleCode },
              dataType: "html",
              url: '/DashboardAllocation/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
              }
          });
    },


};