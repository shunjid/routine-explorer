$(function () {
    $('#fileUploaderForm').submit(function(e){
        e.preventDefault();
        if ($('#file').val() === '') {
            toast("No file was selected", "red darken-1");
        }
        
        let getFiles = $("#file").get(0);
        let extractFiles = getFiles.files;
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
            success: function (message) {
                console.log(message);
            },
            error: function () {
                console.log("Error!");
            },
            complete: function () {
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