var Upload = {
    UploadImage: function (inputId , outputId) {
        var fileInput = document.getElementById(inputId);
        var file = fileInput.files[0];
        var formData = new FormData();
        formData.append('pic', file);
        Upload.CreateLoading();
        $.ajax({
            url: "/Gallery/UploadImage",
            type: "POST",
            data: formData,
            contentType: false,
            cache: false,
            processData: false,
            beforeSend: function () {
                $("#loader").show();
            },
            complete: function () {
                $("#loader").hide();
            },
            success: function (data) {
                //alert(JSON.stringify( data));
                var image = "<img src='" + data.url + "' style='height:60px;' />";
                $("#"+inputId).after(image);
                $("#" + outputId).val(data.url);
                $("#loader").hide();
            },

            error: function (e) {
            }
        });
    }
    ,
    CreateLoading: function () {
        $("body").prepend("<div id='loader' class='loader'><img src='/Files/Preloader_8.gif' /></div>");
    }
}