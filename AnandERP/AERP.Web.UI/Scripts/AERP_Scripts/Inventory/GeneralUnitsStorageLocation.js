//this class contain methods related to nationality functionality
var GeneralUnitsStorageLocation = {
    //Member variables
    ActionName: null,
    XmlString:null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralUnitsStorageLocation.constructor();
        //GeneralUnitsStorageLocation.initializeValidation();
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

        $('#CreateGeneralUnitsStorageLocationRecord').on("click", function () {
           
            GeneralUnitsStorageLocation.ActionName = "Create";
            if (GeneralUnitsStorageLocation.XmlString != null || GeneralUnitsStorageLocation.XmlString != "") {
                GeneralUnitsStorageLocation.getDataFromDataTable();
                GeneralUnitsStorageLocation.AjaxCallGeneralUnitsStorageLocation();
            }
            else
            {
                $("#displayErrorMessage p").text("No data Found in table").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            }
            
        });

        $('#EditGeneralUnitsStorageLocationRecord').on("click", function () {

            GeneralUnitsStorageLocation.ActionName = "Edit";
            GeneralUnitsStorageLocation.AjaxCallGeneralUnitsStorageLocation();
        });

        $('#DeleteGeneralUnitsStorageLocationRecord').on("click", function () {

            GeneralUnitsStorageLocation.ActionName = "Delete";
            GeneralUnitsStorageLocation.AjaxCallGeneralUnitsStorageLocation();
        });
        $("#LocationName").focusout(function () {
           
            var data = $("#LocationName").val() + '~' + $("#GeneralUnitsID").val();
            GeneralUnitsStorageLocation.FocusOut("LocationName", data);
        });
        $('#UnitType').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        // Add new record in table
        $('#btnAdd').on("click", function () {

           
            var abc =0;
            var DataArray = [];
            var data = $('#DivAddRowTable tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            var Count = DataArray.length / 2;
            for (var i = 0; i < Count; i++) {
                
                if (DataArray[i] == $('#InventoryLocationMasterID').val()) {
                    $("#displayErrorMessage p").text("you cannot add the same location").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#IsDefault").removeAttr('checked');
                    $("#IsDefault").val("");
                    $("#LocationName").val("");
                    $("#InventoryLocationMasterID").val("");
                    $('#LocationName').focus();
                    return false;
                }
                var abc = DataArray[i+1]
                if (abc == 1) {
                    abc = abc + 1;
                }
                if(abc > 0)
                {
                    $("#displayErrorMessage p").text("Only one can be a default location.. so please unchecked the is default").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#IsDefault").removeAttr('checked');
                    $("#IsDefault").val("");
                    $("#LocationName").val("");
                    $("#InventoryLocationMasterID").val("");
                    $('#LocationName').focus();
                    return false;
                }

                }
              
            
            var IsDefault = $("#IsDefault").is(":checked") ? "true" : "false";
     
            var aaa;
            if (IsDefault == "true") {
                aaa = "<td> <input id='IsDefault1' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
                $("#IsDefault").removeAttr('checked');
                $("#IsDefault").val("");
            }
            else {
                aaa = "<td> <input id='IsDefault1' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
                $("#IsDefault").removeAttr('checked');
                $("#IsDefault").val("");
            }
            //alert($("#IsDefaultCount").val());
            if ($("#IsDefaultCount").val() > 0  && IsDefault == "true")
            {
                $("#displayErrorMessage p").text("There should be only one Default location.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#IsDefault").removeAttr('checked');
                $("#IsDefault").val("");
                $("#LocationName").val("");
                $("#InventoryLocationMasterID").val("");
                $('#LocationName').focus();
                return false;
            }
            else{
            if ($('#LocationName').val() != "" && $('#InventoryLocationMasterID').val() != 0) {
                    $("#tblData tbody").append(
                                            "<tr>" +
                                            "<td><input id='LocationID' type='text' value=" + $('#InventoryLocationMasterID').val() + " style='display:none' />" + $('#LocationName').val() + "</td>" +
                                                aaa+
                                            "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                            "</tr>"
                                            );
                    
                    $("#LocationName").val("");
                    $("#InventoryLocationMasterID").val("");
                    $('#LocationName').focus();
                    //$("#IsDefault").removeAttr('checked');
                    aaa = "";
                   
            }
            else if ($("#LocationName").val() == "" || $("#LocationName").val()==null) {
                $("#displayErrorMessage p").text("Please select Location").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            }
                
            }
            //Delete record in table
            $("#tblData tbody").on("click", "tr td i", function () {
                //   var b = parseInt($('#PendingCalls').val()) + parseInt($(this).attr('id'));
                $(this).closest('tr').remove();
            });
               
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
    //Check On Focus Out.

    FocusOut: function (actionOn, data) {
        debugger;
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionOn": actionOn, "data": data},
            url: '/GeneralUnitsStorageLocation/CheckFocusOnAction',
            success: function (data) {
                debugger;
                debugger;
                //Rebind Grid Data
                //if (actionOn == "LocatioName") {
                    var abc = data.split('~');
                    $("#InventoryLocationMasterID").val(abc[0].replace('"', ''));
                    $("#IsDefaultCount").val(abc[1].replace('"', ''));
                   
                //}
            }
        });
    },


    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralUnitsStorageLocation/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        debugger;
        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/GeneralUnitsStorageLocation/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralUnitsStorageLocation: function () {
        var GeneralUnitsStorageLocationData = null;

        if (GeneralUnitsStorageLocation.ActionName == "Create") {
            $("#FormCreateGeneralUnitStorageLocation").validate();
            if ($("#FormCreateGeneralUnitStorageLocation").valid()) {
                GeneralUnitsStorageLocationData = null;
                GeneralUnitsStorageLocationData = GeneralUnitsStorageLocation.GetGeneralUnitsStorageLocation();
                ajaxRequest.makeRequest("/GeneralUnitsStorageLocation/Create", "POST", GeneralUnitsStorageLocationData, GeneralUnitsStorageLocation.Success, "CreateGeneralUnitsStorageLocationRecord");
            }
        }
        else if (GeneralUnitsStorageLocation.ActionName == "Edit") {
            $("#FormEditGeneralUnitsStorageLocation").validate();
            if ($("#FormEditGeneralUnitsStorageLocation").valid()) {
                GeneralUnitsStorageLocationData = null;
                GeneralUnitsStorageLocationData = GeneralUnitsStorageLocation.GetGeneralUnitsStorageLocation();
                ajaxRequest.makeRequest("/GeneralUnitsStorageLocation/Edit", "POST", GeneralUnitsStorageLocationData, GeneralUnitsStorageLocation.Success);
            }
        }
        else if (GeneralUnitsStorageLocation.ActionName == "Delete") {

            GeneralUnitsStorageLocationData = null;
            //$("#FormCreateGeneralUnitsStorageLocation").validate();
            GeneralUnitsStorageLocationData = GeneralUnitsStorageLocation.GetGeneralUnitsStorageLocation();
            ajaxRequest.makeRequest("/GeneralUnitsStorageLocation/Delete", "POST", GeneralUnitsStorageLocationData, GeneralUnitsStorageLocation.Success);

        }
    },

    getDataFromDataTable: function () {
        var DataArray = [];
        var table = $('#tblData').DataTable();
        var data = table.$('input,select,input tag').each(function () {
            DataArray.push($(this).val());
        });

        //alert(DataArray)
        //alert(DataArray.length)
        var xmlParamList = "<rows>";
        var aa = [];
        var x = 0;
        var Count = DataArray.length / 2;
        for (var i = 0; i < Count; i++) {
            //  aa = DataArray[x + 1].split('~');
            if (DataArray[x] != 0) {
                xmlParamList = xmlParamList + "<row><ID>0</ID><InventoryLocationMasterID>" + DataArray[x] + "</InventoryLocationMasterID>" + "<IsDefault>" + DataArray[x + 1] + "</IsDefault>";
                xmlParamList = xmlParamList + "</row>";
                x = x + 2;
            }
        }
        table.destroy();
        //alert(xmlParamList)
        if (xmlParamList.length > 5) {
            GeneralUnitsStorageLocation.XmlString = xmlParamList + "</rows>";
            //alert(CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring);

        }
        else {
            //alert(xmlParamList.length);
            GeneralUnitsStorageLocation.XmlString = "";
        }
        //alert(CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring);

    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralUnitsStorageLocation: function () {
        var Data = {
        };

        if (GeneralUnitsStorageLocation.ActionName == "Create" || GeneralUnitsStorageLocation.ActionName == "Edit") {
            debugger;
            debugger;
            Data.ID = $('#ID').val();
            Data.UnitName = $('#UnitName').val();
            Data.IsDefault = $('#IsDefault').val();
            Data.LocationName = $('#LocationName').val();
            Data.GeneralUnitsID = $('#GeneralUnitsID').val();
            Data.XmlString = GeneralUnitsStorageLocation.XmlString;
            // Data.SeqNo = $('#SeqNo').val();
            // Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
        }
        else if (GeneralUnitsStorageLocation.ActionName == "Delete") {

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
            GeneralUnitsStorageLocation.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

