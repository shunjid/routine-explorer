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
        $('#modal1').modal('open');
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
                showMaterialToast('Classes not found', 'red darken-1');
            } else {
                response.forEach(function (element) {
                    let placesToWriteData = element["dayOfWeek"] + element["timeRange"];
                    placesToWriteData = replaceAll(placesToWriteData, ':', '\\:');
                    $('#'+placesToWriteData).html(element['courseCode'] + '<br>' + '(' + element["roomNumber"] + ')' + ' - ' + element["teacher"]);
                });
            }
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