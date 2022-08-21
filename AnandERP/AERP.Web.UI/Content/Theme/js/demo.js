$(window).load(function(){
    //Welcome Message (not for login page)
    function notify(message, type){
        $.growl({
            message: message
        },{
            type: type,
            allow_dismiss: false,
            label: 'Cancel',
            className: 'btn-xs btn-inverse',
            placement: {
                from: 'top',
                align: 'right'
            },
            delay: 2500,
            animate: {
                    enter: 'animated fadeIn',
                    exit: 'animated fadeOut'
            },
            offset: {
                x: 20,
                y: 85
            }
        });
    };
    


    /*if (!$('.login-content')[0]) {
        notify('Welcome back Mallinda Hollaway', 'inverse');
    } */
});


/* Custom function not originally added in couponia theme start */
$(document).ajaxStart(function () {
    $('.page-loader2').show();
});

$(document).ajaxStop(function () {
    $('.page-loader2').hide();
    $('.mfpAjaxModal').magnificPopup({
        type: 'ajax',
        settings: null,
       // alignTop: true,
        overflowY: 'scroll',
        closeOnContentClick: false,
        cursor: 'mfp-ajax-cur',
        tError: '<a href="%url%">The content</a> could not be loaded.'
    });
    $.closeMfp();    
});

$(function () {
    $('.mfpAjaxModal').magnificPopup({
        type: 'ajax',
        settings: null,
       // alignTop: true,
        overflowY: 'scroll',
        closeOnContentClick: false,
        cursor: 'mfp-ajax-cur',
        tError: '<a href="%url%">The content</a> could not be loaded.'

    });
    $.closeMfp();
});



$.closeMfp = function () {
    $("#closeMfp").click(function () {
        $.magnificPopup.close();
    });
};

$(document).on('click', '.mfp-close', function (e) {
    //e.preventDefault();
    $.magnificPopup.close();
});

// This is used to submit a search for on listing pages
$.fn.searchSubmit = function(options) {
	var settings = $.extend({
		clickid : "",
		formname : ""
	}, options);
	
	$("#" + settings.clickid).bind("click", function(event) {
		$('.page-loader').show();
		$.ajax({
			data : $("#" + settings.formname).serialize(),
			dataType : "html",
			success : function(data, textStatus) {
				$("#content").html(data);
				$('.page-loader').hide();
			},
			type : "post",
			url : $("#" + settings.formname).attr('action')
		});
		return false;
	});
};


$.fn.viewLimitSubmit = function(options) {
	var settings = $.extend({
		clickid : "",
		formname : ""
	}, options);

	$("#" + settings.clickid).bind("change", function(event) {
		$('.page-loader').show();
		$.ajax({
			data : $("#" + settings.formname).serialize(),
			dataType : "html",
			success : function(data, textStatus) {
				$("#content").html(data);
				$('.page-loader').hide();
			},
			type : "post",
			url : $("#" + settings.formname).attr('action')
		});
		return false;
	});
	
};


// This is used to submit a bulk submit form on listing pages
$.fn.bulkSubmit = function(options) {
	var settings = $.extend({
		bulkclick : "",
		formname : "",
		bulktype : "",
		confirm : ""
	}, options);

	$("#" + settings.bulkclick).bind(
			"click",
			function(event) {
				$("#bulkType").val(parseInt(settings.bulktype));				
				var points = {
						'0' : {'title' : 'In-Activate ', 'type' : 'warning', 'buttontype' : 'btn-warning'},
					    '1' : {'title' : 'Activate ', 'type' : 'success', 'buttontype' : 'btn-success'},
					    '2' : {'title' : 'Delete ', 'type' : 'error', 'buttontype' : 'btn-danger'}
					};
				
				swal({
			        title: points[parseInt(settings.bulktype)]['title'],
			        text: "Are you sure? want to " + settings.confirm + " ?",
			        type: points[parseInt(settings.bulktype)]['type'],
			        showCancelButton: true,
			        confirmButtonClass: points[parseInt(settings.bulktype)]['buttontype'],
			        confirmButtonText: "Yes!"
			    },function(isConfirm){
			    	if (isConfirm) {   		
			    	 $('.page-loader').show();
						$.ajax({
							data : $("#" + settings.formname).serialize(),
							dataType : "html",
							success : function(data, textStatus) {
								$("#content").html(data);
								$('.page-loader').hide();
							},
							type : "post",
							url : $("#" + settings.formname).attr('action')
						});
			    		return false;
			    	}
			    });				
				
		  return false;
		});
};

function fancyBoxPopUpAjax(title,text,type,confirmButtonClass,confirmButtonText,url,container,loader,childClass) {		
	swal({
        title: title,
        text: text,
        type: type,
        showCancelButton: true,
        confirmButtonClass: confirmButtonClass,
        confirmButtonText: confirmButtonText
    },function(isConfirm){
    	if (isConfirm) {
    		var actionUrl = url;
    		///window.location.href=actionUrl;
    		
    		$.ajax({
    			//beforeSend:function (XMLHttpRequest) {$("."+loader).fadeIn();}, 
    			//complete:function (XMLHttpRequest, textStatus) {$("."+loader).fadeOut();}, 
    			dataType:"html", 
    			success: function (data, textStatus) {    			    
    			    var splitData = data.split(',');
    			    eval(childClass + ".ReloadList(String(splitData[0]).slice(1) , splitData[1] , splitData[2] , String(splitData[3]).slice(0,-1))");
    			},
    			url:actionUrl
    		});
    		return false;
    	}
    });
};

function fancyBoxPopUp(title,text,type,confirmButtonClass,confirmButtonText,url) {		
	swal({
        title: title,
        text: text,
        type: type,
        showCancelButton: true,
        confirmButtonClass: confirmButtonClass,
        confirmButtonText: confirmButtonText
    },function(isConfirm){
    	if (isConfirm) {
    		var actionUrl = url;
    		window.location.href=actionUrl;
    	}
    });
};
function InitAnimatedBorder() {
    //Add blue animated border and remove with condition when focus and blur
    if ($('.fg-line')[0]) {
        $('body').on('focus', '.fg-line .form-control', function () {
            $(this).closest('.fg-line').addClass('fg-toggled');
        })

        $('body').on('blur', '.form-control', function () {
            var p = $(this).closest('.form-group, .input-group');
            var i = p.find('.form-control').val();

            if (p.hasClass('fg-float')) {
                if (i.length == 0) {
                    $(this).closest('.fg-line').removeClass('fg-toggled');
                }
            }
            else {
                $(this).closest('.fg-line').removeClass('fg-toggled');
            }
        });
    }

    //Add blue border for pre-valued fg-flot text feilds
    if ($('.fg-float')[0]) {
        $('.fg-float .form-control').each(function () {
            var i = $(this).val();

            if (!i.length == 0) {
                $(this).closest('.fg-line').addClass('fg-toggled');
            }

        });
    }
};
function notify(message, type) {
    $.growl({
        message: message
    }, {
        type: type,
        allow_dismiss: false,
        label: 'Cancel',
        className: 'btn-xs btn-inverse',
        placement: {
            from: 'bottom',
            align: 'right'
        },
        delay: 2500,
        animate: {
            enter: 'animated fadeIn',
            exit: 'animated fadeOut'
        },
        offset: {
            x: 20,
            y: 85
        }
    });
};
function CloseAlert() {
    $("#displayErrorMessage button[class=close]").on("click", function () {
        $("#displayErrorMessage").hide();
    });
};
function sparklineBar(id, values, height, barWidth, barColor, barSpacing) {
    $('.' + id).sparkline(values, {
        type: 'bar',
        height: height,
        barWidth: barWidth,
        barColor: barColor,
        barSpacing: barSpacing
    })
};
function sparklineLine(id, values, width, height, lineColor, fillColor, lineWidth, maxSpotColor, minSpotColor, spotColor, spotRadius, hSpotColor, hLineColor) {
    $('.' + id).sparkline(values, {
        type: 'line',
        width: width,
        height: height,
        lineColor: lineColor,
        fillColor: fillColor,
        lineWidth: lineWidth,
        maxSpotColor: maxSpotColor,
        minSpotColor: minSpotColor,
        spotColor: spotColor,
        spotRadius: spotRadius,
        highlightSpotColor: hSpotColor,
        highlightLineColor: hLineColor
    })
};
function DataTableSettings(oTable,tableID,toggleTableColumnID) {
    $('#'+toggleTableColumnID+' li input[type="checkbox"]').on('click', function (e) {
        //e.preventDefault();
        var count = 0;
        $('#'+toggleTableColumnID+' li input[type="checkbox"]').each(function () {
            if (this.checked) {
                count = parseInt(count + 1);
                $(this).prop("disabled", false);
            }
        });       
        if (count >= 1) {
            if ($(this).prop('checked') == true) {
                $(this).prop("checked", true);
            }
            else {
                $(this).prop("checked", false);
            }
            // Get the column API object
            var column = oTable.column($(this).val());

            // Toggle the visibility
            column.visible(!column.visible());
            if (count == 1) {
                $('#'+toggleTableColumnID+' li input[type="checkbox"]').each(function () {
                    if (this.checked) {
                        $(this).prop("disabled", true);
                    }
                });
            }
        }
    });

    $("#"+tableID+"_length").hide();
    $("#"+tableID+"_filter").hide();

    $("#UserSearch").keyup(function () {
        var table = $("#"+tableID+"").dataTable();
        table.fnFilter(this.value);
    });

    $("#showrecords li a").on("click", function () {
        $(this).closest('div').removeClass("open");
        var showRecord = $(this).text();
        $("select[name*='"+tableID+"_length']").val(showRecord);
        $("select[name*='"+tableID+"_length']").change();
        $("#tblDisplayRowLength").text($(this).text());
        $('#showrecords li').each(function () {
            $(this).removeClass("active");
        });
        $(this).closest("li").addClass("active");
    });

};