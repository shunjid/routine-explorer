# Routine Explorer, v2.0

![Docker Build](https://img.shields.io/docker/cloud/build/shunjid/routine-explorer)  ![action badge](https://action-badges.now.sh/shunjid/routine-explorer)

In every semester, Department of Software Engineering of the [Daffodil International University](https://diu.edu.bd) provides class schedule in **.xlsx** file format. 

Mobile             |  Desktop
:-------------------------:|:-------------------------:
![Mobile View](https://media.giphy.com/media/ZBytgye9cARGijyWhH/giphy.gif)  |  ![Desktop View](https://media.giphy.com/media/gfrmGrqkdk7PgFJiVE/giphy.gif)

It's not an easy task for a student to find class schedule of 6 working days from a lot of data.

![Routine Image](https://i.stack.imgur.com/BOUyX.png)

To solve this problem, routine-explorer comes with the idea to help students finding their class schedule in a **6 x 6 GRID** where :

- Student's can select the latest routine version provided by the department
- Search for classes of 5 (max) courses through the keyword pattern 'Course Name' + 'Section'.

## API Usage
To find a 6 x 6 Grid class schedule you need to hit the API at ```'/Home/Index'``` and send a **courses** object. To know more about the model structure, traverse at ```Models/Course```.

#### Sample code snippet (jQuery)
```js
let courses = {
	"selectedRoutineId": 1,
	"firstSubject": "SWE426A"
};

$.post('', { courses : courses }, function (response) {
    console.log(response);
});
```

#### Response
```json
[
    {
        "id": 2,
        "roomNumber": "304AB",
        "courseCode": "SWE426A_LAB",
        "teacher": "TBA",
        "dayOfWeek": "Tuesday",
        "timeRange": "04:00-05:30",
        "status": {
            "id": 1,
            "nameOfFilesUploaded": "Spring 2019 Version 1.1",
            "statusOfPublish": true,
            "timeOfUpload": "2020-01-11T13:39:54.2045517"
        }
    }
]
```