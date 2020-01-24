$(function () {
    $.get('GetUserName', function () {
    }).done(function (response) {
        $('#customizedMessage').text('Hi, ' + toTitleCase(response));
        toast('😎 Welcome back, ' + toTitleCase(response), "rounded blue darken-2");
    });

    let auditData = {};
    let request = $.getJSON('https://api.ipdata.co/?api-key=test', function (responseData, status) {
        auditData = {
            areaAccessed: "Admin Panel",
            actionDateTime: new Date().getDate(),
            userIP: responseData["ip"],
            userLocation: " latitude : " + responseData["latitude"] + " longitude : " + responseData["longitude"]
        };
    }).done(function () {
        $.post('Audit', { audit: auditData }, function() { console.log("audited"); }, "json");
    });
    
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
            },
            error: function () {
                toast("Something went wrong", "rounded red darken-1");
                $('#fileUploaderForm')[0].reset();
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

function toTitleCase(str) {
    return str.replace(
        /\w\S*/g,
        function(txt) {
            return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
        }
    );
}