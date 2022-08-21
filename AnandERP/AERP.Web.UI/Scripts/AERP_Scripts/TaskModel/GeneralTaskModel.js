////this class contain methods related to nationality functionality
//var GeneralTaskModel = {
//    //Member variables
//    ActionName: null,
//    SelectedCriteriaParamXMLstring: null,
//    SelectedAccBalsheetMstIDs: null,
//    //Class intialisation method
//    Initialize: function () {
//        GeneralTaskModel.constructor();
//    },
//    //Attach all event of page
//    constructor: function () {
//        //Reset button click event function to reset all controls of form



//        $('#CreateGeneralTaskModelRecord').on("click", function () {
            
//            GeneralTaskModel.ActionName = "Create";
//            GeneralTaskModel.AjaxCallGeneralTaskModel();
//        });
//        $('#DeleteGeneralTaskModelRecord').on("click", function () {
            
//            GeneralTaskModel.ActionName = "Delete";
//            GeneralTaskModel.AjaxCallGeneralTaskModel();
//        });



//        $("#UserSearch").on("keyup", function () {
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").on("click", function () {
//            $("#UserSearch").focus();
//        });

//        $("#showrecord").on("change", function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();



//        $('#reset').on("click", function () {
//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#TaskDescription').focus();
//            $('#MenuCode').val("");
//            $('#LinkMenuCode').val("");
//            return false;
//        });





//        $('#TaskDescription').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#TaskCode').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });


//    },
//    //LoadList method is used to load List page
//    LoadList: function () {
//            $.ajax(
//               {
//                   cache: false,
//                   type: "POST",
//                   dataType: "html",
//                   url: '/GeneralTaskModel/List',
//                   success: function (data) {
//                       //Rebind Grid Data
//                       $('#ListViewModel').html(data);
//                   }
//               });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
//        $.ajax(
//        {
//            cache: false,
//            type: "GET",
//            data: { "actionMode": actionMode },
//            dataType: "html",
//            url: '/GeneralTaskModel/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                ////twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },
//    //Fire ajax call to insert update and delete record
//    AjaxCallGeneralTaskModel: function () {
//        var GeneralTaskModelData = null;
//        if (GeneralTaskModel.ActionName == "Create") {
//            $("#FormCreateGeneralTaskModel").validate();
//            if ($("#FormCreateGeneralTaskModel").valid()) {
//                GeneralTaskModelData = null;
//                GeneralTaskModelData = GeneralTaskModel.GetGeneralTaskModel();
//                ajaxRequest.makeRequest("/GeneralTaskModel/Create", "POST", GeneralTaskModelData, GeneralTaskModel.Success);
//            }
//        }
//        else if (GeneralTaskModel.ActionName == "Delete") {
//            $("#FormDeleteGeneralTaskModel").validate();
//            GeneralTaskModelData = null;
//            GeneralTaskModelData = GeneralTaskModel.GetGeneralTaskModel();
//            ajaxRequest.makeRequest("/GeneralTaskModel/Delete", "POST", GeneralTaskModelData, GeneralTaskModel.Success);
//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetGeneralTaskModel: function () {
//        var Data = {
//        };
//        if (GeneralTaskModel.ActionName == "Create") {
//            Data.TaskDescription = $('#TaskDescription').val();
//            Data.TaskCode = $('#TaskCode').val();
//            Data.MenuCode = $("#MenuCode").val();
//            Data.LinkMenuCode = $("#LinkMenuCode").val();
//            Data.TaskModelApplicableTo = $("#TaskModelApplicableTo").val();
//        }
//        if (GeneralTaskModel.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },
//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {

//        var splitData = data.split(',');
//        parent.$.colorbox.close();
//        GeneralTaskModel.ReloadList(splitData[0], splitData[1], splitData[2]);

//    },
//};

///////////////////new code/////////////////


//this class contain methods related to nationality functionality
var GeneralTaskModel = {
    //Member variables
    ActionName: null,
    SelectedCriteriaParamXMLstring: null,
    SelectedAccBalsheetMstIDs: null,
    //Class intialisation method
    Initialize: function () {
        GeneralTaskModel.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form



        $('#CreateGeneralTaskModelRecord').on("click", function () {

            GeneralTaskModel.ActionName = "Create";
            GeneralTaskModel.AjaxCallGeneralTaskModel();
        });
        $('#DeleteGeneralTaskModelRecord').on("click", function () {

            GeneralTaskModel.ActionName = "Delete";
            GeneralTaskModel.AjaxCallGeneralTaskModel();
        });



        //$("#UserSearch").on("keyup", function () {
        //    oTable.fnFilter(this.value);
        //});

        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();



        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#TaskDescription').focus();
            $('#MenuCode').val("");
            $('#LinkMenuCode').val("");
            return false;
        });





        $('#TaskDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#TaskCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });


    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
           {
               cache: false,
               type: "POST",
               dataType: "html",
               url: '/GeneralTaskModel/List',
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
            type: "GET",
            data: { "actionMode": actionMode },
            dataType: "html",
            url: '/GeneralTaskModel/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                ////twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallGeneralTaskModel: function () {
        var GeneralTaskModelData = null;
        if (GeneralTaskModel.ActionName == "Create") {
            $("#FormCreateGeneralTaskModel").validate();
            if ($("#FormCreateGeneralTaskModel").valid()) {
                GeneralTaskModelData = null;
                GeneralTaskModelData = GeneralTaskModel.GetGeneralTaskModel();
                ajaxRequest.makeRequest("/GeneralTaskModel/Create", "POST", GeneralTaskModelData, GeneralTaskModel.Success);
            }
        }
        else if (GeneralTaskModel.ActionName == "Delete") {
            $("#FormDeleteGeneralTaskModel").validate();
            GeneralTaskModelData = null;
            GeneralTaskModelData = GeneralTaskModel.GetGeneralTaskModel();
            ajaxRequest.makeRequest("/GeneralTaskModel/Delete", "POST", GeneralTaskModelData, GeneralTaskModel.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralTaskModel: function () {
        var Data = {
        };
        if (GeneralTaskModel.ActionName == "Create") {
            Data.TaskDescription = $('#TaskDescription').val();
            Data.TaskCode = $('#TaskCode').val();
            Data.MenuCode = $("#MenuCode").val();
            Data.LinkMenuCode = $("#LinkMenuCode").val();
            Data.TaskModelApplicableTo = $("#TaskModelApplicableTo").val();
        }
        if (GeneralTaskModel.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        GeneralTaskModel.ReloadList(splitData[0], splitData[1], splitData[2]);

    },
};