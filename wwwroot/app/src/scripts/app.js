$(document).ready(function() {
    $.get('Home/GetLatestCodes', function (response) {
        // Course array to single object with null values for image in suggestion
        $('.inputCourse').autocomplete({
            data: response.reduce(function(acc, curr) {
                acc[curr] = null;
                return acc;
            }, {})
        });
    });

    $('#closeBtn').click(function () {
        $('#modal1').modal('close');
        exitFullScreen();
    });
    
    $('#btnStudentRoutine').click(function () {
        $('.progress').show();
        clearCache();
        let courses = {
            "selectedRoutineId": $('#SelectedRoutineId').val(),
            "firstSubject": $('#FirstSubject').val().toUpperCase(),
            "secondSubject": $('#SecondSubject').val().toUpperCase(),
            "thirdSubject": $('#ThirdSubject').val().toUpperCase(),
            "fourthSubject": $('#FourthSubject').val().toUpperCase(),
            "fifthSubject": $('#FifthSubject').val().toUpperCase(),
        };
        
        $.post('', { courses : courses }, function (response) {
            if(response.length === 0) {
                showMaterialToast('Provide at least a course', 'red darken-1');
            } else {
                response.forEach(function (element) {
                    let placesToWriteData = element["dayOfWeek"] + element["timeRange"];
                    placesToWriteData = replaceAll(placesToWriteData, ':', '\\:');
                    $('#'+placesToWriteData).append(element['courseCode'] + '<br>' + '(' + element["roomNumber"] + ')' + ' - ' + element["teacher"] + '<br>');
                });
                $('#semesterName').text('Class Schedule : ' + response[0]["status"]["nameOfFilesUploaded"]);
                $('#modal1').modal('open');
                
                toggleFullScreen(document.body);
            }
        }).always(function() {
            $('.progress').hide();
        });
        
    });
    
    function clearCache() {
        $('.routineData').html('');
    }

    function showMaterialToast(data, style) {
        M.toast({
            html : data,
            classes : style
        });
    }

    function replaceAll(str, find, replace) {
        return str.replace(new RegExp(find, 'g'), replace);
    }

    function isInFullScreen() {
        const document = window.document;
        return (document.fullscreenElement && true) || (document.webkitFullscreenElement && true) || (document.mozFullScreenElement && true) || (document.msFullscreenElement && true);
    }

    function requestFullScreen(elem) {
        if (elem.requestFullscreen) {
            elem.requestFullscreen();
        } else if (elem.mozRequestFullScreen) {
            elem.mozRequestFullScreen();
        } else if (elem.webkitRequestFullScreen) {
            elem.webkitRequestFullScreen();
        } else if (elem.msRequestFullscreen) {
            elem.msRequestFullscreen();
        } else {
            console.warn("Did not find a requestFullScreen method on this element", elem);
        }
    }

    function exitFullScreen() {
        const document = window.document;
        if (document.exitFullscreen) {
            document.exitFullscreen();
        } else if (document.webkitExitFullscreen) {
            document.webkitExitFullscreen();
        } else if (document.mozCancelFullScreen) {
            document.mozCancelFullScreen();
        } else if (document.msExitFullscreen) {
            document.msExitFullscreen();
        }
    }

    function toggleFullScreen(elem) {
        // based on https://stackoverflow.com/questions/36672561/how-to-exit-fullscreen-onclick-using-javascript
        if (isInFullScreen()) {
            exitFullScreen();
        } else {
            requestFullScreen(elem || document.body);
        }
    }
});