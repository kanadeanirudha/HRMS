//this class contain methods related to nationality functionality
var OrderingAndDeliveryDay = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrderingAndDeliveryDay.constructor();
        //OrderingAndDeliveryDay.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

     

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });



        // Create new record

        $('#CreateOrderingAndDeliveryDayRecord').on("click", function () {

            OrderingAndDeliveryDay.ActionName = "Create";
            OrderingAndDeliveryDay.GetXmlData();
            OrderingAndDeliveryDay.AjaxCallOrderingAndDeliveryDay();
        });

        $('#CreateOrderingAndDeliveryDayRulesRecord').on("click", function () {

            OrderingAndDeliveryDay.ActionName = "CreateMovementTypeRules";
            OrderingAndDeliveryDay.AjaxCallOrderingAndDeliveryDay();
        });
        $('#EditOrderingAndDeliveryDayRecord').on("click", function () {

            OrderingAndDeliveryDay.ActionName = "Edit";
            OrderingAndDeliveryDay.AjaxCallOrderingAndDeliveryDay();
        });

        $('#DeleteOrderingAndDeliveryDayRecord').on("click", function () {

            OrderingAndDeliveryDay.ActionName = "Delete";
            OrderingAndDeliveryDay.AjaxCallOrderingAndDeliveryDay();
        });

        $('#MovementType').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MovementCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);

        });

        $('#btnAdd').on("click", function () {
            var sunday = $('input[name=Sunday]:checked').val() ? true : false;
            var sun;
            if (sunday == true) {
                sun = "<td> <input id='Sunday' type='checkbox' checked='checked'  disabled='disabled' value='Sun' style='text-align:center' >" + " </td>"

            }
            else {
                sun = "<td> <input id='Sunday' type='checkbox'   disabled='disabled' value=''>" + " </td>"
            }
            /////////////////////////////////////
            var monday = $('input[name=Monday]:checked').val() ? true : false;
            var mon;
            if (monday == true) {
                mon = "<td> <input id='Monday' type='checkbox' checked='checked'  disabled='disabled' value='Mon' style='text-align:center' >" + " </td>"
            }
            else {
                mon = "<td> <input id='Monday' type='checkbox'   disabled='disabled' value='' >" + " </td>"
            }
            /////////////////////////////////////
            var tuesday = $('input[name=Tuesday]:checked').val() ? true : false;
            var tue;
            if (tuesday == true) {
                tue = "<td> <input id='value='Tuesday'' type='checkbox' checked='checked'  disabled='disabled' value='Tue'  style='text-align:center' >" + " </td>"
            }
            else {
                tue = "<td> <input id='Tuesday' type='checkbox'   disabled='disabled' value='' >" + " </td>"
            }
            /////////////////////////////////////
            var wednesday = $('input[name=Wednesday]:checked').val() ? true : false;
            var wed;
            if (wednesday == true) {
                wed = "<td> <input id='Wednesday' type='checkbox' checked='checked'  disabled='disabled' value='Wed'  style='text-align:center' >" + " </td>"
            }
            else {
                wed = "<td> <input id='Wednesday' type='checkbox'   disabled='disabled' value=''>" + " </td>"
            }
            /////////////////////////////////////
            var thursday = $('input[name=Thursday]:checked').val() ? true : false;
            var thu;
            if (thursday == true) {
                thu = "<td> <input id='Thursday' type='checkbox' checked='checked'  disabled='disabled' value='Thu'  style='text-align:center' >" + " </td>"
            }
            else {
                thu = "<td> <input id='Thursday' type='checkbox'   disabled='disabled' value=''>" + " </td>"
            }
            /////////////////////////////////////
            var friday = $('input[name=Friday]:checked').val() ? true : false;
            var fri;
            if (friday == true) {
                fri = "<td> <input id='Friday' type='checkbox' checked='checked'  disabled='disabled' value='Fri' style='text-align:center' >" + " </td>"
            }
            else {
                fri = "<td> <input id='Friday' type='checkbox'   disabled='disabled' value=''>" + " </td>"
            }
            /////////////////////////////////////
            var saturday = $('input[name=Saturday]:checked').val() ? true : false;
            var sat;
            if (saturday == true) {
                sat = "<td> <input id='Saturday' type='checkbox' checked='checked'  disabled='disabled' value='Sat' style='text-align:center' >" + " </td>"
            }
            else {
                sat = "<td> <input id='Saturday' type='checkbox'   disabled='disabled' value=''>" + " </td>"
            }

            var ChkArray = [];
            var ChkArray1 = [];
            var abc;
            debugger
            $.each($("div#divAllocateJob input[type='checkbox']"), function () {
                if ($(this).is(":checked")) {
                    ChkArray1.push($(this).attr('class'));
                    ChkArray.push($(this).attr('id'));

                }
                 abc = ChkArray.join(', ');
                //alert(abc)
            });
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 9) {
                if (DataArray[i + 8] == ChkArray1.join("")) {
                    $("#displayErrorMessage p").text("You Cannot Enter Same Item Twice.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#sunday").removeAttr('checked');
                    $("#monday").removeAttr('checked');
                    $("#tuesday").removeAttr('checked');
                    $("#wednesday").removeAttr('checked');
                    $("#thursday").removeAttr('checked');
                    $("#friday").removeAttr('checked');
                    $("#saturday").removeAttr('checked');
                    return false;
                }
            }
          
            if (ChkArray1.length == 0) {
                $("#displayErrorMessage p").text("Please check atleast one day.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            } else {
                $("#tblData tbody").append(
                                              "<tr>" +
                                              sun + 
                                                 mon +
                                                tue +
                                                 wed +
                                                thu +
                                                  fri +
                                                sat +
                                                 "<td style=display:none><input id='OrderingDay' type='hidden' value=" + abc.replace(/ /g, "~") + " style='display:none' />" + abc.replace(/ /g, "~") + "</td>" +
                                               "<td><input id='favorite1' type='text' value=" + ChkArray1.join("") + " style='display:none' /> " + ChkArray1.join("") + "</td>" +
                                              "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                              "</tr>"
                                              );



                $("#Sun").removeAttr('checked');
                $("#Mon").removeAttr('checked');
                $("#Tue").removeAttr('checked');
                $("#Wed").removeAttr('checked');
                $("#Thu").removeAttr('checked');
                $("#Fri").removeAttr('checked');
                $("#Sat").removeAttr('checked');
            }
        });

     
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });
        
            InitAnimatedBorder();

            CloseAlert();

          
        

    },
    //LoadList method is used to load List page
    LoadList: function () {
        debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/OrderingAndDeliveryDay/List',
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
            url: '/OrderingAndDeliveryDay/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    GetXmlData: function () {

        var DataArray = [];
        //BOMAndRecipeDetails.flag = true;
        $('#tblData input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
     
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 9) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><Code>" + DataArray[i + 8] + "</Code><OrderingDay>" + DataArray[i + 7].replace(/~/g,' ') + "</OrderingDay></row>";
        }
       
        if (ParameterXml.length > 10)
            OrderingAndDeliveryDay.ParameterXml = ParameterXml + "</rows>";

        else
            OrderingAndDeliveryDay.ParameterXml = "";
    },
    //Fire ajax call to insert update and delete record

    AjaxCallOrderingAndDeliveryDay: function () {
        var OrderingAndDeliveryDayData = null;

        if (OrderingAndDeliveryDay.ActionName == "Create") {
            debugger;
            $("#FormCreateOrderingAndDeliveryDay").validate();
            if ($("#FormCreateOrderingAndDeliveryDay").valid()) {
                OrderingAndDeliveryDayData = null;
                OrderingAndDeliveryDayData = OrderingAndDeliveryDay.GetOrderingAndDeliveryDay();
                ajaxRequest.makeRequest("/OrderingAndDeliveryDay/Create", "POST", OrderingAndDeliveryDayData, OrderingAndDeliveryDay.Success, "CreateOrderingAndDeliveryDayRecord");
            }
        }
        
        else if (OrderingAndDeliveryDay.ActionName == "Edit") {
            $("#FormEditOrderingAndDeliveryDay").validate();
            if ($("#FormEditOrderingAndDeliveryDay").valid()) {
                OrderingAndDeliveryDayData = null;
                OrderingAndDeliveryDayData = OrderingAndDeliveryDay.GetOrderingAndDeliveryDay();
                ajaxRequest.makeRequest("/OrderingAndDeliveryDay/Edit", "POST", OrderingAndDeliveryDayData, OrderingAndDeliveryDay.Success);
            }
        }
        else if (OrderingAndDeliveryDay.ActionName == "Delete") {

            OrderingAndDeliveryDayData = null;
            //$("#FormCreateOrderingAndDeliveryDay").validate();
            OrderingAndDeliveryDayData = OrderingAndDeliveryDay.GetOrderingAndDeliveryDay();
            ajaxRequest.makeRequest("/OrderingAndDeliveryDay/Delete", "POST", OrderingAndDeliveryDayData, OrderingAndDeliveryDay.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOrderingAndDeliveryDay: function () {
        var Data = {
        };

        if (OrderingAndDeliveryDay.ActionName == "Create" || OrderingAndDeliveryDay.ActionName == "Edit") {

            Data.ID = $('#ID').val();
          
            Data.ParameterXml = OrderingAndDeliveryDay.ParameterXml;
        }
       
        else if (OrderingAndDeliveryDay.ActionName == "Delete") {

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
            OrderingAndDeliveryDay.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};