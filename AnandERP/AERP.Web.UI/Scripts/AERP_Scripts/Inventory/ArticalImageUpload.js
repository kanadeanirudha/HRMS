﻿// ================================================================
//  Description: Avatar Upload supporting script
//  License:     MIT - check License.txt file for details
//  Author:      Codative Corp. (http://www.codative.com/)
// ================================================================
var jcrop_api,
    boundx,
    boundy,
    xsize,
    ysize;

// ToDo - change the size limit of the file. You may need to change web.config if larger files are necessary.
var maxSizeAllowed = 2;     // Upload limit in MB
var maxSizeInBytes = maxSizeAllowed * 1024 * 1024;
var keepUploadBox = false;  // ToDo - Remove if you want to keep the upload box
var keepCropBox = false;    // ToDo - Remove if you want to keep the crop box

$(function () {

    $("#displayErrorMessage button[class=close]").on("click", function () {
        $("#displayErrorMessage").hide();
    });

    if (typeof $('#avatar-upload-form') !== undefined) {
        initAvatarUpload();
        $('#avatar-max-size').html(maxSizeAllowed);
        $('#avatar-upload-form input:file').on("change", function (e) {
            var files = e.currentTarget.files;
            for (var x in files) {
                if (files[x].name != "item" && typeof files[x].name != "undefined") {
                    if (files[x].size <= maxSizeInBytes) {
                        // Submit the selected file
                        $('#avatar-upload-form .upload-file-notice').removeClass('bg-danger');
                        $('#avatar-upload-form').submit();
                    } else {
                        // File too large
                        $('#avatar-upload-form .upload-file-notice').addClass('bg-danger');
                    }
                }
            }
        });
    }
});

function initAvatarUpload() {
    $('#avatar-upload-form').ajaxForm({
        beforeSend: function () {
            updateProgress(0);
            //$('#avatar-upload-form').addClass('hidden');
        },
        uploadProgress: function (event, position, total, percentComplete) {
            updateProgress(percentComplete);
        },
        success: function (data) {
            //updateProgress(0);
            $(".upload-progress").addClass('hidden');
            if (data.success === false) {
                $("#displayErrorMessage p").text(data.errorMessage).closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                
            } else {
                $('#preview-pane .preview-container img').attr('src', data.fileName);
                var img = $('#crop-avatar-target');
                img.attr('src', data.fileName);

                if (!keepUploadBox) {
                    $('#avatar-upload-box').addClass('hidden');
                }
                $('#avatar-crop-box').removeClass('hidden');
                initAvatarCrop(img);
            }
        },
        complete: function (xhr) {
        }
    });
}

function updateProgress(percentComplete) {
    $('.upload-percent-bar').width(percentComplete + '%');
    $('.upload-percent-value').html(percentComplete + '%');
    if (percentComplete === 0) {
        $('#upload-status').empty();
        $('.upload-progress').removeClass('hidden');
    }
}

function initAvatarCrop(img) {
    img.Jcrop({
        onChange: updatePreviewPane,
        onSelect: updatePreviewPane,
        aspectRatio: xsize / ysize
    }, function () {
        var bounds = this.getBounds();
        boundx = bounds[0];
        boundy = bounds[1];

        jcrop_api = this;
        jcrop_api.setOptions({ allowSelect: true });
        jcrop_api.setOptions({ allowMove: true });
        jcrop_api.setOptions({ allowResize: true });
        jcrop_api.setOptions({ aspectRatio: 1 });

        // Maximise initial selection around the centre of the image,
        // but leave enough space so that the boundaries are easily identified.
        var padding = 10;
        var shortEdge = (boundx < boundy ? boundx : boundy) - padding;
        var longEdge = boundx < boundy ? boundy : boundx;
        var xCoord = longEdge / 2 - shortEdge / 2;
        jcrop_api.animateTo([xCoord, padding, shortEdge, shortEdge]);

        var pcnt = $('#preview-pane .preview-container');
        xsize = pcnt.width();
        ysize = pcnt.height();
        $('#preview-pane').appendTo(jcrop_api.ui.holder);
        jcrop_api.focus();
    });
}

function updatePreviewPane(c) {
    if (parseInt(c.w) > 0) {
        var rx = xsize / c.w;
        var ry = ysize / c.h;

        $('#preview-pane .preview-container img').css({
            width: Math.round(rx * boundx) + 'px',
            height: Math.round(ry * boundy) + 'px',
            marginLeft: '-' + Math.round(rx * c.x) + 'px',
            marginTop: '-' + Math.round(ry * c.y) + 'px'
        });
    }
}

function saveAvatar() {
    var img = $('#preview-pane .preview-container img');
   // $('#avatar-crop-box button').addClass('disabled');

    $.ajax({
        type: "POST",
        url: "/GeneralItemMaster/Save",
        traditional: true,
        data: {
            w: img.css('width'),
            h: img.css('height'),
            l: img.css('marginLeft'),
            t: img.css('marginTop'),
            fileName: img.attr('src')
        }
    }).done(function (data) {
        if (data.success === true) {
            $('#ArticleImageUpload img').attr('src', data.avatarFileLocation);
            //hidden (.val(data.ArticleFileName))
            $('#CroppedImagePath').val((data.ArticleFileName))
            $.magnificPopup.close();
            $('#avatar-result').removeClass('hidden');

            if (!keepCropBox) {
                $('#avatar-crop-box').addClass('hidden');
            }
        } else {
            alert(data.errorMessage)
        }
    }).fail(function (e) {
        alert('Cannot upload Image at this time');
    });
}

function saveMultipleAvatarImage() {
    var img = $('#preview-pane .preview-container img');
    // $('#avatar-crop-box button').addClass('disabled');

    $.ajax({
        type: "POST",
        url: "/GeneralItemMaster/Save",
        traditional: true,
        data: {
            w: img.css('width'),
            h: img.css('height'),
            l: img.css('marginLeft'),
            t: img.css('marginTop'),
            fileName: img.attr('src')
        }
    }).done(function (data) {
        if (data.success === true) {
            $('#imageuploadDiv').append('<div class="col-sm-3 imgdiv"><button class="close" type="button"><span aria-hidden="true">×</span></button><input type="hidden" value="' + data.ArticleFileName + '" class="ImageNameSaved"/><input type="hidden" value="0" class="ImageIDSaved"/><img src="' + data.avatarFileLocation + '" width="100%"></div>')
            if ($('#EComCroppedImagePath').val() == '') {
                $('#EComCroppedImagePath').val(data.ArticleFileName)
            }
            else{
                $('#EComCroppedImagePath').val(($('#EComCroppedImagePath').val() + ',' + (data.ArticleFileName)))
            }
            $.magnificPopup.close();
            $('#avatar-result').removeClass('hidden');

            if (!keepCropBox) {
                $('#avatar-crop-box').addClass('hidden');

            }
            $(".close").on("click", function () {
                var ImageName = $(this).next().val();
                var ID = $(this).next().next().val();
                    $.ajax({
                        url: "/GeneralItemMaster/DeleteEComImage",
                        type: "POST",
                        data: { "ID": ID, "ImageName": ImageName },
                        dataType: 'json',
                        success: function (data) {
                            $(this).parent(".imgdiv").remove();
                        },
                    });
                    $(this).parent(".imgdiv").remove();
            });
        } else {
            alert(data.errorMessage)
        }
    }).fail(function (e) {
        alert('Cannot upload Image at this time');
    });
}

$(".close").on("click", function () {
    $(this).parent(".imgdiv").remove();

});