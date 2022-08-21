////this class contain methods related to nationality functionality
//var EmployeeChildrenDetails = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeeChildrenDetails.constructor();
//        //EmployeeChildrenDetails.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#NameTitle').focus();
//            $('#NameTitle').val('');
//        });




//        // Create new record
//        $('#CreateEmployeeChildrenDetailsRecord').on("click", function () {
//            EmployeeChildrenDetails.ActionName = "Create";
//            EmployeeChildrenDetails.AjaxCallEmployeeChildrenDetails();
//        });

//        $('#EditEmployeeChildrenDetailsRecord').on("click", function () {
//            EmployeeChildrenDetails.ActionName = "Edit";
//            EmployeeChildrenDetails.AjaxCallEmployeeChildrenDetails();
//        });

//        $('#DeleteEmployeeChildrenDetailsRecord').on("click", function () {

//            EmployeeChildrenDetails.ActionName = "Delete";
//            EmployeeChildrenDetails.AjaxCallEmployeeChildrenDetails();
//        });
       
//        $("#UserSearch").keyup(function () {
//            oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $('#NameTitle').change(function () {

//            if ($(this).val() == "Mr") {
//                document.getElementById('Male').checked = true;
//                EmployeeInformation.GenderCode = 'M';
//            }
//            else if ($(this).val() == "Mrs" || $(this).val() == "Ms") {
//                document.getElementById('Female').checked = true;
//                EmployeeInformation.GenderCode = 'F';
//            }

//        });



//        $('#ChildDateOfBirth').datepicker({
//            onSelect: function (date) {

//            },
        
//            changeMonth: true,
//            changeYear: true,
//            selectWeek: true,
           
           
//        });




//        $('#MedalReceivedDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//        })

//        $('#ScholarshipStartDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#ScholarshipUptoDate").datepicker("option", "minDate", selectedDate);
//            }
//        })

//        $('#ScholarshipUptoDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onClose: function (selectedDate) {
//                $("#ScholarshipStartDate").datepicker("option", "maxDate", selectedDate);
//            }
//        })


//        $('#WeddingAnniversaryDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//        })




//        if ($("#GotAnyMedal").val() == 'true') {
//            $('#MedalDescription').show();
//        }
//        else {
//            $('#MedalDescription').hide();

//        }

//        if ($("#GotAnyMedal").val() == 'true') {
//            $('#MedalDescription').show();
//        }
//        else {
//            $('#MedalDescription').hide();

//        }

//        $("#GotAnyMedal").click(function () {

//            if (this.checked) {
//                $("#Medal").fadeIn();
//                $('#MedalDescription').val("");
//                $('#MedalReceivedDate').val("");
//                EmployeeChildrenDetails.GotAnyMedal = true;
//            }
//            else {
//                $("#Medal").fadeOut();
//                $('#MedalDescription').val("");
//                $('#MedalReceivedDate').val("");
//                EmployeeChildrenDetails.GotAnyMedal = false;
//            }
//        });


//        if ($("#IsScholarshipReceived").val() == 'true') {
//            $('#ScholarshipDescription').show();
//        }
//        else {
//            $('#ScholarshipDescription').hide();
//        }

//        $("#IsScholarshipReceived").click(function () {

//            if (this.checked) {
//                $("#Scholarship").fadeIn();
//                $('#ScholarshipDescription').val("");
//                $('#ScholarshipAmount').val(0.00);
//                $('#ScholarshipStartDate').val("");
//                $('#ScholarshipUptoDate').val("");
//                EmployeeChildrenDetails.IsScholarshipReceived = true;

//            }
//            else {
//                $("#Scholarship").fadeOut();
//                $('#ScholarshipDescription').val("");
//                $('#ScholarshipAmount').val(0.00);
//                $('#ScholarshipStartDate').val("");
//                $('#ScholarshipUptoDate').val("");
//                EmployeeChildrenDetails.IsScholarshipReceived = false;
//            }
//        });


//        $('#ChildName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });


//        $('#ChildrenRelation').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#MedalDescription').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

      

//        $('#ScholarshipAmount').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });


//        $('#ScholarshipDescription').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });



//        $('#CurriculamActivity').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });


//        $('#Hobby').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
      
//        $('#Sports').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
      
//        $('#Profession').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();


//    },
//    //LoadList method is used to load List page
//    LoadList: function () {
//        var EmployeeID = $("#EmployeeID").val();
//        $.ajax(

//         {

//             cache: false,
//             type: "POST",
//             data: { "EmployeeID": EmployeeID },
//             dataType: "html",
//             url: '/EmployeeChildrenDetails/List',

//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
//        var EmployeeID = $("#EmployeeID").val();
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { "actionMode": actionMode, "EmployeeID": EmployeeID },
//            url: '/EmployeeChildrenDetails/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#EmployeeFormStatusMessages').html(message);
//                $('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
//            }
//        });
//    },



//    //Fire ajax call to insert update and delete record
//    AjaxCallEmployeeChildrenDetails: function () {
//        var EmployeeChildrenDetailsData = null;
//        if (EmployeeChildrenDetails.ActionName == "Create") {

//            $("#FormCreateEmployeeChildrenDetails").validate();
//            if ($("#FormCreateEmployeeChildrenDetails").valid()) {
//                EmployeeChildrenDetailsData = null;
//                EmployeeChildrenDetailsData = EmployeeChildrenDetails.GetEmployeeChildrenDetails();
//                ajaxRequest.makeRequest("/EmployeeChildrenDetails/Create", "POST", EmployeeChildrenDetailsData, EmployeeChildrenDetails.Success);
//            }
//        }
//        else if (EmployeeChildrenDetails.ActionName == "Edit") {

//            $("#FormEditEmployeeChildrenDetails").validate();
//            if ($("#FormEditEmployeeChildrenDetails").valid()) {
//                EmployeeChildrenDetailsData = null;
//                EmployeeChildrenDetailsData = EmployeeChildrenDetails.GetEmployeeChildrenDetails();
//                ajaxRequest.makeRequest("/EmployeeChildrenDetails/Edit", "POST", EmployeeChildrenDetailsData, EmployeeChildrenDetails.Success);
//            }
//        }
//        else if (EmployeeChildrenDetails.ActionName == "Delete") {
//            EmployeeChildrenDetailsData = null;
//            $("#FormDeleteEmployeeChildrenDetails").validate();
//            EmployeeChildrenDetailsData = EmployeeChildrenDetails.GetEmployeeChildrenDetails();
//            ajaxRequest.makeRequest("/EmployeeChildrenDetails/Delete", "POST", EmployeeChildrenDetailsData, EmployeeChildrenDetails.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeeChildrenDetails: function () {
//        var Data = {
//        };
//        if (EmployeeChildrenDetails.ActionName == "Create" || EmployeeChildrenDetails.ActionName == "Edit") {
//            ;
//            Data.ID = $('#ID').val();
//            Data.EmployeeID = $("#EmployeeID").val()
//            Data.TitleMasterID = $('#TitleMasterID').val();

//            Data.NameTitle = $('#NameTitle').val();

//            if ($("#NameTitle").val() == "Mr") {
//                Data.GenderCode = 'M';
//            }
//            else {
//                Data.GenderCode = 'F';
//            }
//            Data.ChildName = $('#ChildName').val();
//            Data.ChildQualification = $('#ChildQualification').val();
//            Data.ChildDateOfBirth = $('#ChildDateOfBirth').val();
//            Data.Hobby = $('#Hobby').val();
//            Data.Sports = $('#Sports').val();
//            Data.CurriculamActivity = $('#CurriculamActivity').val();
//            Data.GotAnyMedal = $('#GotAnyMedal:checked').val() ? true : false;
//            Data.MedalReceivedDate = $('#MedalReceivedDate').val();
//            Data.MedalDescription = $('#MedalDescription').val();

//            Data.IsScholarshipReceived = $('#IsScholarshipReceived:checked').val() ? true : false;
//            Data.ScholarshipStartDate = $('#ScholarshipStartDate').val();
//            Data.ScholarshipUptoDate = $('#ScholarshipUptoDate').val();
//            Data.ScholarshipDescription = $('#ScholarshipDescription').val();
//            Data.ScholarshipAmount = $('#ScholarshipAmount').val();

//            Data.IdentityMarks = $('#IdentityMarks').val();
//            Data.Profession = $('#Profession').val();
//            Data.Height = $('#Height').val();
//            Data.Weight = $('#Weight').val();
//            Data.ChildrenRelation = $('#ChildrenRelation').val();
//            Data.ScholarshipAmount = $('#ScholarshipAmount').val();

           
//        }
//        else if (EmployeeChildrenDetails.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            EmployeeChildrenDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            EmployeeChildrenDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    ;
//    //    ;
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        EmployeeChildrenDetails.ReloadList("Record Updated Sucessfully.", actionMode);
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {

//    //    ;
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        EmployeeChildrenDetails.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

/////////////////////////////////////////////new js///////////////////////////////////

//this class contain methods related to nationality functionality
var EmployeeChildrenDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeChildrenDetails.constructor();
        //EmployeeChildrenDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#NameTitle').focus();
            $('#NameTitle').val('');
        });




        // Create new record
        $('#CreateEmployeeChildrenDetailsRecord').on("click", function () {
            EmployeeChildrenDetails.ActionName = "Create";
            EmployeeChildrenDetails.AjaxCallEmployeeChildrenDetails();
        });

        $('#EditEmployeeChildrenDetailsRecord').on("click", function () {
            EmployeeChildrenDetails.ActionName = "Edit";
            EmployeeChildrenDetails.AjaxCallEmployeeChildrenDetails();
        });

        $('#DeleteEmployeeChildrenDetailsRecord').on("click", function () {

            EmployeeChildrenDetails.ActionName = "Delete";
            EmployeeChildrenDetails.AjaxCallEmployeeChildrenDetails();
        });

        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $('#NameTitle').change(function () {

            if ($(this).val() == "Mr") {
                document.getElementById('Male').checked = true;
                EmployeeInformation.GenderCode = 'M';
            }
            else if ($(this).val() == "Mrs" || $(this).val() == "Ms") {
                document.getElementById('Female').checked = true;
                EmployeeInformation.GenderCode = 'F';
            }

        });



        //$('#ChildDateOfBirth').datepicker({
        //    onSelect: function (date) {

        //    },

        //    changeMonth: true,
        //    changeYear: true,
        //    selectWeek: true,
        //});

        $('#ChildDateOfBirth').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });


        //$('#MedalReceivedDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //})

        $('#MedalReceivedDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });

        //$('#ScholarshipStartDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ScholarshipUptoDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        $('#ScholarshipStartDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });

        //$('#ScholarshipUptoDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onClose: function (selectedDate) {
        //        $("#ScholarshipStartDate").datepicker("option", "maxDate", selectedDate);
        //    }
        //})

        $('#ScholarshipUptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });


        //$('#WeddingAnniversaryDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //})

        $('#WeddingAnniversaryDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
            ignoreReadonly: true,

        });





        if ($("#GotAnyMedal").val() == 'true') {
            //$('#MedalDescription').show();
        }
        else {
            //$('#MedalDescription').hide();

        }

        if ($("#GotAnyMedal").val() == 'true') {
            //$('#MedalDescription').show();
        }
        else {
            //$('#MedalDescription').hide();

        }

        $("#GotAnyMedal").click(function () {

            if (this.checked) {
                $("#Medal").fadeIn();
                $('#MedalDescription').val("");
                $('#MedalReceivedDate').val("");
                EmployeeChildrenDetails.GotAnyMedal = true;
            }
            else {
                $("#Medal").fadeOut();
                $('#MedalDescription').val("");
                $('#MedalReceivedDate').val("");
                EmployeeChildrenDetails.GotAnyMedal = false;
            }
        });


        if ($("#IsScholarshipReceived").val() == 'true') {
            //$('#ScholarshipDescription').show();
        }
        else {
            //$('#ScholarshipDescription').hide();
        }

        $("#IsScholarshipReceived").click(function () {

            if (this.checked) {
                $("#Scholarship").fadeIn();
                $('#ScholarshipDescription').val("");
                $('#ScholarshipAmount').val(0.00);
                $('#ScholarshipStartDate').val("");
                $('#ScholarshipUptoDate').val("");
                EmployeeChildrenDetails.IsScholarshipReceived = true;

            }
            else {
                $("#Scholarship").fadeOut();
                $('#ScholarshipDescription').val("");
                $('#ScholarshipAmount').val(0.00);
                $('#ScholarshipStartDate').val("");
                $('#ScholarshipUptoDate').val("");
                EmployeeChildrenDetails.IsScholarshipReceived = false;
            }
        });


        $('#ChildName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


        $('#ChildrenRelation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MedalDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });



        $('#ScholarshipAmount').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });


        $('#ScholarshipDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });



        $('#CurriculamActivity').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


        $('#Hobby').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#Sports').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#Profession').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();


    },
    //LoadList method is used to load List page
    LoadList: function () {
        var EmployeeID = $("#EmployeeID").val();
        $.ajax(

         {

             cache: false,
             type: "POST",
             data: { "EmployeeID": EmployeeID },
             dataType: "html",
             url: '/EmployeeChildrenDetails/List',

             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var EmployeeID = $("#EmployeeID").val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "EmployeeID": EmployeeID },
            url: '/EmployeeChildrenDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },



    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeChildrenDetails: function () {
        var EmployeeChildrenDetailsData = null;
        if (EmployeeChildrenDetails.ActionName == "Create") {

            $("#FormCreateEmployeeChildrenDetails").validate();
            if ($("#FormCreateEmployeeChildrenDetails").valid()) {
                EmployeeChildrenDetailsData = null;
                EmployeeChildrenDetailsData = EmployeeChildrenDetails.GetEmployeeChildrenDetails();
                ajaxRequest.makeRequest("/EmployeeChildrenDetails/Create", "POST", EmployeeChildrenDetailsData, EmployeeChildrenDetails.Success);
            }
        }
        else if (EmployeeChildrenDetails.ActionName == "Edit") {

            $("#FormEditEmployeeChildrenDetails").validate();
            if ($("#FormEditEmployeeChildrenDetails").valid()) {
                EmployeeChildrenDetailsData = null;
                EmployeeChildrenDetailsData = EmployeeChildrenDetails.GetEmployeeChildrenDetails();
                ajaxRequest.makeRequest("/EmployeeChildrenDetails/Edit", "POST", EmployeeChildrenDetailsData, EmployeeChildrenDetails.Success);
            }
        }
        else if (EmployeeChildrenDetails.ActionName == "Delete") {
            EmployeeChildrenDetailsData = null;
            $("#FormDeleteEmployeeChildrenDetails").validate();
            EmployeeChildrenDetailsData = EmployeeChildrenDetails.GetEmployeeChildrenDetails();
            ajaxRequest.makeRequest("/EmployeeChildrenDetails/Delete", "POST", EmployeeChildrenDetailsData, EmployeeChildrenDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeChildrenDetails: function () {
        var Data = {
        };
        if (EmployeeChildrenDetails.ActionName == "Create" || EmployeeChildrenDetails.ActionName == "Edit") {
            ;
            Data.ID = $('#ID').val();
            Data.EmployeeID = $("#EmployeeID").val()
            Data.TitleMasterID = $('#TitleMasterID').val();

            Data.NameTitle = $('#NameTitle').val();

            if ($("#NameTitle").val() == "Mr") {
                Data.GenderCode = 'M';
            }
            else {
                Data.GenderCode = 'F';
            }
            Data.ChildName = $('#ChildName').val();
            Data.ChildQualification = $('#ChildQualification').val();
            Data.ChildDateOfBirth = $('#ChildDateOfBirth').val();
            Data.Hobby = $('#Hobby').val();
            Data.Sports = $('#Sports').val();
            Data.CurriculamActivity = $('#CurriculamActivity').val();
            Data.GotAnyMedal = $('#GotAnyMedal:checked').val() ? true : false;
            Data.MedalReceivedDate = $('#MedalReceivedDate').val();
            Data.MedalDescription = $('#MedalDescription').val();

            Data.IsScholarshipReceived = $('#IsScholarshipReceived:checked').val() ? true : false;
            Data.ScholarshipStartDate = $('#ScholarshipStartDate').val();
            Data.ScholarshipUptoDate = $('#ScholarshipUptoDate').val();
            Data.ScholarshipDescription = $('#ScholarshipDescription').val();
            Data.ScholarshipAmount = $('#ScholarshipAmount').val();

            Data.IdentityMarks = $('#IdentityMarks').val();
            Data.Profession = $('#Profession').val();
            Data.Height = $('#Height').val();
            Data.Weight = $('#Weight').val();
            Data.ChildrenRelation = $('#ChildrenRelation').val();
            Data.ScholarshipAmount = $('#ScholarshipAmount').val();


        }
        else if (EmployeeChildrenDetails.ActionName == "Delete") {
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
            EmployeeChildrenDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeChildrenDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

