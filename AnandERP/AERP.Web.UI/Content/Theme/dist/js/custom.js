$.fn.checkUnchekAll = function() {
	// check and uncheck all
	$('#selectAll').click(function(event) { // on click
		// alert('in select all'); return false;
		if (this.checked) { // check select status
			$('.listRowCheckbox').each(function() { // loop through each
													// checkbox
				this.checked = true; // select all checkboxes with class
										// "checkbox1"
			});
		} else {
			$('.listRowCheckbox').each(function() { // loop through each
													// checkbox
				this.checked = false; // deselect all checkboxes with class
										// "checkbox1"
			});
		}
	});

	$('.listRowCheckbox').click(function(event) {
		if (this.checked == false) {
			if ($("#selectAll").is(':checked')) {
				$("#selectAll").attr('checked', false);
			}
		}
	});
};

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

function fancyBoxPopUpAjax(title,text,type,confirmButtonClass,confirmButtonText,url,container,loader) {		
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
    			beforeSend:function (XMLHttpRequest) {$("."+loader).fadeIn();}, 
    			complete:function (XMLHttpRequest, textStatus) {$("."+loader).fadeOut();}, 
    			dataType:"html", 
    			success:function (data, textStatus) {$("#"+container).html(data);}, 
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


