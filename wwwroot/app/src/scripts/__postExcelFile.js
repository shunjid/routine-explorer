$(function () {
    $('#fileUploaderForm').submit(function(e){
        e.preventDefault();
        if ($('#file').val() === '') {
            toast("No file was selected", "red darken-1");
        }
        
        let extractFiles = $("#file").get(0).files;
        let data = new FormData();
        data.append(extractFiles[0].name, extractFiles[0]);

        $.ajax({
            type: "POST",
            url: "PostExcelFile",
            contentType: false,
            processData: false,
            data: data,
            beforeSend: function () {
                $(".progress").show();
            },
            success: function (response) {
                toast(response["message"], response["toastStyle"]);
                $(".progress").hide();
            },
            error: function () {
                toast("Something went wrong", "rounded red darken-1");
                $(".progress").hide();
            },
            complete: function () {
                $('#fileUploaderForm')[0].reset();
                $(".progress").hide();
            }
        });
    });
});

function toast(data, style) {
    M.toast({
        html : data,
        classes : style
    });
}