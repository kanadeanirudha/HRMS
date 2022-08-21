//this class contain methods related to nationality functionality
var AttendenceMonitoringSystem = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AttendenceMonitoringSystem.constructor();
        //AttendenceMonitoringSystem.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#myDataTable tbody').on('click', 'tr td a', function () {
            var aaa = $(this).attr("class");
            
            //alert(aaa);
            var splitData = aaa.split('~');
            AttendenceMonitoringSystem.LoadList(splitData[1], splitData[0], 0)

        });

        $('#myDataTable1 tbody').on('click', 'tr td a', function () {
            var aaa = $(this).attr("class");
            
            // alert(aaa);
            var splitData = aaa.split('~');
            AttendenceMonitoringSystem.LoadList(splitData[0], splitData[1], splitData[2])

        });

        $('#myDataTable2 tbody').on('click', 'tr td a', function () {
            
            var EmpIDAndName = $(this).attr("class").split('~');
            var EmpID = EmpIDAndName[0];
            var EmpName = EmpIDAndName[1];

            //var splitData = aaa.split('~');
            //  AttendenceMonitoringSystem.LoadList(splitData[0], splitData[1], splitData[2])
            $.ajax(
                 {
                     cache: false,
                     data: { employeeID: EmpID, employeeName: EmpName },
                     dataType: "html",
                     url: '/AttendenceMonitoringSystem/AttendenceDetails',
                     success: function (result) {

                         //Rebind Grid Data     
                         
                         $('#ListViewModel').html('');
                         $('#ListViewModel').html('<div class="container-fluid wrapper">' + result + '</div>');
                     }
                 });
        });
    },
    //LoadList method is used to load List page
    LoadList: function (Level, CentreCode, DeptID) {
        
        $.ajax(
         {

             cache: false,
             type: "POST",
             dataType: "html",
             data: { level: Level, centreCode: CentreCode, DepartmentID: DeptID },
             url: '/AttendenceMonitoringSystem/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
};

