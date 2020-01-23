$(function () {
    $('#SignInForm').submit(function(e){
       e.preventDefault();
       $('.progress').show();
       let cookieSetter = {
         "credentialEmail" : $('#CredentialEmail').val(),
         "credentialKey" :  $('#CredentialKey').val()
       };
        $.post('', {cookieSetter: cookieSetter}, function (response) {
            if(Array.isArray(response)) {
                toast("DIU mails are accepted only 😓", "blue darken-1");
            } else {
                response["hasError"] ? toast("😓 Invalid credentials", "grey darken-3") : redirect("/Routines/Create");
            }
            $('.progress').hide();
        });
    });
});

function toast(data, style) {
    M.toast({
        html : data,
        classes : style
    });
}

function redirect(link){
    setTimeout(function(){
        toast("Verified. Redirecting ...", "green darken-1")
    }, 1500);
    window.location.replace(link);
}