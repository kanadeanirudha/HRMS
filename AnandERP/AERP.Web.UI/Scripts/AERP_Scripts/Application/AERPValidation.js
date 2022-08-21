var AERPValidation = {
    Initialize: function () {
        AERPValidation.attachEvents();
    },
    attachEvents: function () {

        //to allow only numbers
        $('input[type="number"]').keydown(function (e) {
            var keyCode = (e.keyCode ? e.keyCode : e.which);
            if (keyCode > 64 && keyCode < 91 || keyCode > 218 && keyCode < 223 || keyCode > 185 && keyCode < 193 || keyCode > 105 && keyCode < 112 || keyCode == 16 || keyCode == 17 || keyCode == 18 || (((e.shiftKey && e.which) > 47) && ((e.shiftKey && e.which) < 58)) || (((e.shiftKey && e.which) > 218) && ((e.shiftKey && e.which) < 223)) || (((e.shiftKey && e.which) > 185) && ((e.shiftKey && e.which) < 193)) || (((e.shiftKey && e.which) > 105) && ((e.shiftKey && e.which) < 112))) {
                e.preventDefault();
            }
        });

        //to allow only numbers
        $('.allowNumbersOnly').keydown(function (e) {
            var keyCode = (e.keyCode ? e.keyCode : e.which);
            if (keyCode > 64 && keyCode < 91 || keyCode > 218 && keyCode < 223 || keyCode > 185 && keyCode < 193 || keyCode > 105 && keyCode < 112 || keyCode == 16 || keyCode == 17 || keyCode == 18 || (((e.shiftKey && e.which) > 47) && ((e.shiftKey && e.which) < 58)) || (((e.shiftKey && e.which) > 218) && ((e.shiftKey && e.which) < 223)) || (((e.shiftKey && e.which) > 185) && ((e.shiftKey && e.which) < 193)) || (((e.shiftKey && e.which) > 105) && ((e.shiftKey && e.which) < 112))) {
                e.preventDefault();
            }
        });

        //to allow only numbers with decimal values
        $('.allowNumbersWithDecimalOnly').keydown(function (e) {
            var keyCode = (e.keyCode ? e.keyCode : e.which);
            if (keyCode > 64 && keyCode < 91 || keyCode > 218 && keyCode < 223 || keyCode > 185 && keyCode < 190 || keyCode == 191 || keyCode == 192 || keyCode > 105 && keyCode < 110 || keyCode == 111 || keyCode == 16 || keyCode == 17 || keyCode == 18 || (((e.shiftKey && e.which) > 47) && ((e.shiftKey && e.which) < 58)) || (((e.shiftKey && e.which) > 218) && ((e.shiftKey && e.which) < 223)) || (((e.shiftKey && e.which) > 185) && ((e.shiftKey && e.which) < 193)) || (((e.shiftKey && e.which) > 105) && ((e.shiftKey && e.which) < 112))) {
                e.preventDefault();
            }
            else {
                if (keyCode == 190 || keyCode == 110) {
                    var id = $(this).attr("id");
                    if ($('#' + id).val().indexOf(".") >= 0) {
                        e.preventDefault();
                    }
                }
            }
        });

        $('.allowCharacterOnly').keydown(function (e) {
            var keyCode = (e.keyCode ? e.keyCode : e.which);
            if (keyCode > 64 && keyCode < 91 || keyCode == 8 || keyCode == 9 || keyCode == 16 || keyCode == 32 || keyCode == 36 || keyCode == 46 || keyCode == 17 || keyCode == 35 || keyCode == 37 || keyCode == 38 || keyCode == 39 || keyCode == 40) {
            }
            else {
                e.preventDefault();
            }
        });



    },

    //To validate the charater
    AllowCharacterOnly: function (e) {
        var keyCode = (e.keyCode ? e.keyCode : e.which);
        
        if (keyCode > 64 && keyCode < 91 || keyCode == 8 || keyCode == 9 || keyCode == 16 || keyCode == 32 || keyCode == 36 || keyCode == 46 || keyCode == 17 || keyCode == 35 || keyCode == 37 || keyCode == 38 || keyCode == 39 || keyCode == 40) {
            
        }
        else {
            e.preventDefault();
        }
    },

    //To validate the charater
    AllowNumbersOnly: function (e) {
        var keyCode = (e.keyCode ? e.keyCode : e.which);
        if (keyCode > 64 && keyCode < 91 || keyCode > 218 && keyCode < 223 || keyCode > 185 && keyCode < 193 || keyCode > 105 && keyCode < 112 || keyCode == 16 || keyCode == 17 || keyCode == 18 || (((e.shiftKey && e.which) > 47) && ((e.shiftKey && e.which) < 58)) || (((e.shiftKey && e.which) > 218) && ((e.shiftKey && e.which) < 223)) || (((e.shiftKey && e.which) > 185) && ((e.shiftKey && e.which) < 193)) || (((e.shiftKey && e.which) > 105) && ((e.shiftKey && e.which) < 112))) {
            e.preventDefault();
        }
    },

    //To validate the charater
    AllowNumbersWithDecimalOnly: function (e) {
        var keyCode = (e.keyCode ? e.keyCode : e.which);
       // alert(keyCode);
        if (keyCode > 64 && keyCode < 91 || keyCode > 218 && keyCode < 223 || keyCode > 185 && keyCode < 193 || keyCode > 105 && keyCode < 109 || keyCode > 111 && keyCode < 112 || keyCode == 16 || keyCode == 17 || keyCode == 18 || (((e.shiftKey && e.which) > 47) && ((e.shiftKey && e.which) < 58)) || (((e.shiftKey && e.which) > 218) && ((e.shiftKey && e.which) < 223)) || (((e.shiftKey && e.which) > 185) && ((e.shiftKey && e.which) < 193)) || (((e.shiftKey && e.which) > 105) && ((e.shiftKey && e.which) < 112))) {
            e.preventDefault();
        }
    },

    //To validate the special charecter
    AllowAlphaNumericOnly: function (e) {
        var keyCode = (e.keyCode ? e.keyCode : e.which);
        
        if (((e.shiftKey && e.which) > 42) && ((e.shiftKey && e.which) < 58) || (((e.shiftKey && e.which) > 218) && ((e.shiftKey && e.which) < 223)) || (((e.shiftKey && e.which) > 185) && ((e.shiftKey && e.which) < 193)) || (((e.shiftKey && e.which) > 105) && ((e.shiftKey && e.which) < 112))) {
            //alert(keyCode);
            e.preventDefault();
        }
        if (keyCode > 57 && keyCode < 65 || keyCode > 90 && keyCode < 97) {           
            e.preventDefault();
            //alert(keyCode);
        }
        if (keyCode == 219 || keyCode == 220 || keyCode == 221 || keyCode == 222 || keyCode == 188 || keyCode == 190 || keyCode == 191 || keyCode == 192) {
            e.preventDefault();
            //alert(keyCode);
        }

        //else {
        //    e.preventDefault();
        //}
    },

    //To validate the spaces
    NotAllowSpaces: function (e) {
        var keyCode = (e.keyCode ? e.keyCode : e.which);      
        if (keyCode == 32) {
            e.preventDefault();
            //alert(keyCode);
        }
        //else {
        //    e.preventDefault();
        //}
    },

    //To validate the date formate
    validateEmail: function (sEmail) {
        var filter = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        if (filter.test(sEmail)) {
            return true;
        }
        else {
            return false;
        }
    },

    //To check the date formate
    isDate: function (txtDate) {
        //var reg = /^(0[1-9]|1[012])([\/-])(0[1-9]|[12][0-9]|3[01])([\/-])(19|20)\d\d$/;
        var reg = /^([1-9]|0[1-9]|1[012])([\/-])([1-9]|0[1-9]|[12][0-9]|3[01])([\/-])(\d\d|(19|20)\d\d)$/;
        return reg.test(txtDate);
    },

    //To check the Character length
    CheckNumberLength: function (e, len) {

        if ($(this).val().length == parseInt(len)) {
            var keyCode = (e.keyCode ? e.keyCode : e.which);
            if (keyCode === 8 || (keyCode > 34 && keyCode < 41) || keyCode === 46) { }
            else { e.preventDefault(); }
        }

    },

    //To sort Drop down list element
    sortSelect: function (selElem) {
        var selEle = document.getElementById(selElem);
        var tmpAry = new Array();
        for (var i = 0; i < selEle.options.length; i++) {
            tmpAry[i] = new Array();
            tmpAry[i][0] = selEle.options[i].text;
            tmpAry[i][1] = selEle.options[i].value;
        }
        tmpAry.sort();
        while (selEle.options.length > 0) {
            selEle.options[0] = null;
        }
        for (var i = 0; i < tmpAry.length; i++) {
            var op = new Option(tmpAry[i][0], tmpAry[i][1]);
            selEle.options[i] = op;
        }
        return;
    },

};
