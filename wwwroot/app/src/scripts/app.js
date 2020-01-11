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
});