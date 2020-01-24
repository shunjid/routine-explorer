let _validFileExtensions = [".xlsx"];
function ValidateSingleInput(oInput) {
    if (oInput.type === "file") {
        let sFileName = oInput.value;
        if (sFileName.length > 0) {
            let blnValid = false;
            for (let j = 0; j < _validFileExtensions.length; j++) {
                let sCurExtension = _validFileExtensions[j];
                if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() === sCurExtension.toLowerCase()) {
                    blnValid = true;
                    break;
                }
            }
            if (!blnValid) {
                toast("🙄 Must be an Excel file", "rounded white deep-purple lighten-1");
                oInput.value = "";
            }
        }
    }
}

function toast(data, style) {
    M.toast({
        html : data,
        classes : style
    });
}