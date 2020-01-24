# API : Routine Explorer

Routine explorer is a free and open source application that helps finding
class schedule of the Department of Software Engineering of Daffodil International
University in a **6 x 6 Grid**.  In it's v3.0 it has arrive with API so that some other
applications like:

-   Room booking (By using the data of unused rooms)
-   Weekly class tracking of each room
-   Schedule maker of teachers using initials
-   Most importantly "MOBILE" applications can be built.

Rest of the part of this documentation will be discussed on module-wise API so that
people willing to built applications for the Dept. of SWE, can gather some idea on how to use these APIs.

## GET all versions of routine

To get the **list** of routines of different versions, you need to hit the api at `api/versions`. For example, if you hit a 
`GET` request:

-   at localhost - `http://localhost:5000/api/versions`
-   at heroku - `http://routine-explorer.herokuapp.com/api/versions`

After successful execution server will respond with an **Array of Objects** like below :

```json
[
    {
        "id": 1,
        "nameOfFilesUploaded": "Spring 2020 Version-2",
        "statusOfPublish": true,
        "timeOfUpload": "2020-01-23T23:27:22.8211125"
    }
]
```

#### Code Snippets : api/versions

Here are some code snippets that might help you dealing with the API at
`api/versions`:

-   **Kotlin: OkHTTP3**

```kotlin
import okhttp3.RequestBody.Companion.toRequestBody

fun main(args: Array) {
    var client = OkHttpClient()
    
    var request = Request.Builder()
    .url("http://routine-explorer.herokuapp.com/api/versions")
    .get()
    .addHeader("Accept", "*/*")
    .addHeader("Cache-Control", "no-cache")
    .addHeader("Host", "http://routine-explorer.herokuapp.com")
    .addHeader("Accept-Encoding", "gzip, deflate")
    .addHeader("Connection", "keep-alive")
    .addHeader("cache-control", "no-cache")
    .build()
    
    var response = client.newCall(request).execute()   
}
```

-   **Flutter: ([HTTP](https://pub.dev/packages/http#-readme-tab-))**

```dart
import 'package:http/http.dart' as http;

var url = 'http://routine-explorer.herokuapp.com/api/versions';
var response = await http.get(url);
print('Response body: ${response.body}');
```

-   **Xamarin ([RestSharp](https://www.nuget.org/packages/RestSharp))**

```c#
var client = new RestClient("http://routine-explorer.herokuapp.com/api/versions");
var request = new RestRequest(Method.GET);
request.AddHeader("cache-control", "no-cache");
request.AddHeader("Connection", "keep-alive");
request.AddHeader("Accept-Encoding", "gzip, deflate");
request.AddHeader("Host", "http://routine-explorer.herokuapp.com");
request.AddHeader("Cache-Control", "no-cache");
request.AddHeader("Accept", "*/*");
IRestResponse response = client.Execute(request);
```

## GET the latest version of routine

To get the latest version of routine object you need to hit the api at `api/versions/GetLatestVersion`. For example, if you hit a 
`GET` request:

-   at localhost - `http://localhost:5000/api/versions/GetLatestVersion`
-   at heroku - `http://routine-explorer.herokuapp.com/api/versions/GetLatestVersion`
    Then a successful execution will respond with a single object like JSON snippet below :

```json
    {
        "id": 1,
        "nameOfFilesUploaded": "Spring 2020 Version-2",
        "statusOfPublish": true,
        "timeOfUpload": "2020-01-23T23:27:22.8211125"
    }
```

#### Code Snippets : api/versions/GetLatestVersion

-   **Kotlin: OkHTTP3**

```kotlin
import okhttp3.RequestBody.Companion.toRequestBody

fun main(args: Array) {
    var client = OkHttpClient()
    var request = Request.Builder()
    .url("http://routine-explorer.herokuapp.com/api/versions/GetLatestVersion")
    .get()
    .addHeader("Accept", "*/*")
    .addHeader("Cache-Control", "no-cache")
    .addHeader("Host", "http://routine-explorer.herokuapp.com")
    .addHeader("Accept-Encoding", "gzip, deflate")
    .addHeader("Connection", "keep-alive")
    .addHeader("cache-control", "no-cache")
    .build()
    var response = client.newCall(request).execute()
}
```

-   **Flutter: ([HTTP](https://pub.dev/packages/http))**

```dart
import 'package:http/http.dart' as http;

var url = 'http://routine-explorer.herokuapp.com/api/versions/GetLatestVersion';
var response = await http.get(url);
print('Response body: ${response.body}');
```

-   **Xamarin ([RestSharp](https://www.nuget.org/packages/RestSharp))**

```c#
var client = new RestClient("http://routine-explorer.herokuapp.com/api/versions/GetLatestVersion");
var request = new RestRequest(Method.GET);
request.AddHeader("cache-control", "no-cache");
request.AddHeader("Connection", "keep-alive");
request.AddHeader("Accept-Encoding", "gzip, deflate");
request.AddHeader("Host", "http://routine-explorer.herokuapp.com");
request.AddHeader("Cache-Control", "no-cache");
request.AddHeader("Accept", "*/*");
IRestResponse response = client.Execute(request);
```

## Find the unused rooms (Routine Version Wise)

In this context, you `POST`  to the `api/vacant`
and include a Routine-Version object to the body from the previous context.

For example, if you hit a `POST` request:

-   at localhost - `http://localhost:5000/api/vacant`
-   at heroku - `http://routine-explorer.herokuapp.com/api/vacant`
    and include a Routine-Version object to the body like:

```json
{
    "id": 1,
    "nameOfFilesUploaded": "Spring 2020 Version-2",
    "statusOfPublish": true,
    "timeOfUpload": "2020-01-23T23:27:22.8211125"
}
```

Then you will get a response which is an array of object returning the unused rooms in that routine version you requested from the body like:

```json
[
    {
        "id": 1,
        "roomNumber": "505AB",
        "dayOfWeek": "Wednesday",
        "timeRange": "10:00-11:30",
        "status": null
    },
    {
        "id": 2,
        "roomNumber": "505AB",
        "dayOfWeek": "Wednesday",
        "timeRange": "08:30-10:00",
        "status": null
}]
```

#### Code Snippets : /api/vacant

-   **HTTP Request Snippet Example**

```http request
POST /api/vacant HTTP/1.1
Host: http://routine-explorer.herokuapp.com
Content-Type: application/json
Accept: */*
Cache-Control: no-cache
Host: http://routine-explorer.herokuapp.com
Accept-Encoding: gzip, deflate
Content-Length: 147
Connection: keep-alive
cache-control: no-cache

{
    "id": 1,
    "nameOfFilesUploaded": "Spring 2020 Version-2",
    "statusOfPublish": true,
    "timeOfUpload": "2020-01-23T23:27:22.8211125"
}
```

-   **Kotlin: OkHTTP3**

```kotlin
import okhttp3.RequestBody.Companion.toRequestBody

fun main(args: Array) {
    var client = OkHttpClient()
    var mediaType = MediaType.parse("application/json")
    var body = RequestBody.create(mediaType, "{\n \"id\": 1,\n \"nameOfFilesUploaded\": \"Spring 2020 Version-2\",\n \"statusOfPublish\": true,\n \"timeOfUpload\": \"2020-01-23T23:27:22.8211125\"\n}")
    var request = Request.Builder()
    .url("http://routine-explorer.herokuapp.com/api/vacant")
    .post(body)
    .addHeader("Content-Type", "application/json")
    .addHeader("Accept", "*/*")
    .addHeader("Cache-Control", "no-cache")
    .addHeader("Host", "http://routine-explorer.herokuapp.com")
    .addHeader("Accept-Encoding", "gzip, deflate")
    .addHeader("Content-Length", "147")
    .addHeader("Connection", "keep-alive")
    .addHeader("cache-control", "no-cache")
    .build()
    var response = client.newCall(request).execute()
}
```

-   **Flutter: ([HTTP](https://pub.dev/packages/http))**

```dart
import 'package:http/http.dart' as http;

var url = 'http://routine-explorer.herokuapp.com/api/vacant';
var response = await http.post(url, body: {
                                      'id': 1,
                                      'nameOfFilesUploaded': 'Spring 2020 Version-2',
                                      'statusOfPublish': true,
                                      'timeOfUpload': '2020-01-23T23:27:22.8211125'
                                      });
print('Response body: ${response.body}');
```

-   **Xamarin ([RestSharp](https://www.nuget.org/packages/RestSharp))**

```c#
var client = new RestClient("http://routine-explorer.herokuapp.com/api/vacant");
var request = new RestRequest(Method.POST);
request.AddHeader("cache-control", "no-cache");
request.AddHeader("Connection", "keep-alive");
request.AddHeader("Content-Length", "147");
request.AddHeader("Accept-Encoding", "gzip, deflate");
request.AddHeader("Host", "http://routine-explorer.herokuapp.com");
request.AddHeader("Cache-Control", "no-cache");
request.AddHeader("Accept", "*/*");
request.AddHeader("Content-Type", "application/json");
request.AddParameter("status", "{\n    \"id\": 1,\n    \"nameOfFilesUploaded\": \"Spring 2020 Version-2\",\n    \"statusOfPublish\": true,\n    \"timeOfUpload\": \"2020-01-23T23:27:22.8211125\"\n}", ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
```

## GET all class schedules of a specific Routine version

In this context, you hit `GET`  to the `api/routine`
and include a Routine-Version object.

For example, if you hit a `GET` request:

-   at localhost - `http://localhost:5000/api/routine`
-   at heroku - `http://routine-explorer.herokuapp.com/api/routine`
    and include a Routine-Version object to the body like:

```json
{
    "id": 1,
    "nameOfFilesUploaded": "Spring 2020 Version-2",
    "statusOfPublish": true,
    "timeOfUpload": "2020-01-23T23:27:22.8211125"
}
```

Then you will get a response which is an array of object returning the class schedules in that routine version you requested from the body like:

```json
[
    {
            "id": 1,
            "roomNumber": "601AB",
            "courseCode": "CS312A",
            "teacher": "MAR",
            "dayOfWeek": "Saturday",
            "timeRange": "02:30-04:00",
            "status": null
        },
        {
            "id": 2,
            "roomNumber": "305AB",
            "courseCode": "ENG101A",
            "teacher": "SM",
            "dayOfWeek": "Tuesday",
            "timeRange": "10:00-11:30",
            "status": null
        }
]
```

#### Code Snippets : /api/routine

-   **HTTP Request Snippet Example**

```http request
GET /api/routine HTTP/1.1
Host: http://routine-explorer.herokuapp.com
Content-Type: application/json
Accept: */*
Cache-Control: no-cache
Host: http://routine-explorer.herokuapp.com
Accept-Encoding: gzip, deflate
Content-Length: 147
Connection: keep-alive
cache-control: no-cache

{
    "id": 1,
    "nameOfFilesUploaded": "Spring 2020 Version-2",
    "statusOfPublish": true,
    "timeOfUpload": "2020-01-23T23:27:22.8211125"
}
```

-   **Kotlin: OkHTTP3**

```kotlin
import okhttp3.RequestBody.Companion.toRequestBody

fun main(args: Array) {
    var client = OkHttpClient()
    var mediaType = MediaType.parse("application/json")
    var body = RequestBody.create(mediaType, "{\n \"id\": 1,\n \"nameOfFilesUploaded\": \"Spring 2020 Version-2\",\n \"statusOfPublish\": true,\n \"timeOfUpload\": \"2020-01-23T23:27:22.8211125\"\n}")
    var request = Request.Builder()
    .url("http://routine-explorer.herokuapp.com/api/routine")
    .get(body)
    .addHeader("Content-Type", "application/json")
    .addHeader("Accept", "*/*")
    .addHeader("Cache-Control", "no-cache")
    .addHeader("Host", "http://routine-explorer.herokuapp.com")
    .addHeader("Accept-Encoding", "gzip, deflate")
    .addHeader("Content-Length", "147")
    .addHeader("Connection", "keep-alive")
    .addHeader("cache-control", "no-cache")
    .build()
    var response = client.newCall(request).execute()
}
```

-   **Flutter: ([HTTP](https://pub.dev/packages/http))**

```dart
import 'package:http/http.dart' as http;

var url = 'http://routine-explorer.herokuapp.com/api/routine';
var response = await http.get(url, body: {
                                      'id': 1,
                                      'nameOfFilesUploaded': 'Spring 2020 Version-2',
                                      'statusOfPublish': true,
                                      'timeOfUpload': '2020-01-23T23:27:22.8211125'
                                      });
print('Response body: ${response.body}');
```

-   **Xamarin ([RestSharp](https://www.nuget.org/packages/RestSharp))**

```c#
var client = new RestClient("http://routine-explorer.herokuapp.com/api/routine");
var request = new RestRequest(Method.GET);
request.AddHeader("cache-control", "no-cache");
request.AddHeader("Connection", "keep-alive");
request.AddHeader("Content-Length", "147");
request.AddHeader("Accept-Encoding", "gzip, deflate");
request.AddHeader("Host", "http://routine-explorer.herokuapp.com");
request.AddHeader("Cache-Control", "no-cache");
request.AddHeader("Accept", "*/*");
request.AddHeader("Content-Type", "application/json");
request.AddParameter("status", "{\n    \"id\": 1,\n    \"nameOfFilesUploaded\": \"Spring 2020 Version-2\",\n    \"statusOfPublish\": true,\n    \"timeOfUpload\": \"2020-01-23T23:27:22.8211125\"\n}", ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
```

## Find class schedule by courses (Routine Version Wise)

In this context, you `POST`  to the `api/routine/GetRoutineByCourses`
and include a **subjects** object to the body.

For example, if you hit a `POST` request:

-   at localhost - `http://localhost:5000/api/routine/GetRoutineByCourses`
-   at heroku - `http://routine-explorer.herokuapp.com/api/routine/GetRoutineByCourses`
    and include a **subjects** object to the body like:

```json
{
	"subject01": "SWE422A",
	"subject02": null,
	"subject03": "SWE425A",
	"subject04": null,
	"subject05": null,
	"status" : {
			     "id": 1,
			     "nameOfFilesUploaded": "Spring 2020 Version-2",
			     "statusOfPublish": true,
			     "timeOfUpload": "2020-01-23T23:27:22.8211125"
			   }
}
```

Then you will get a response which is an array of object returning the class schedules in that routine version for the subjects you requested from the body like:

```json
[
{
        "id": 333,
        "roomNumber": "405AB",
        "courseCode": "SWE422A_LAB",
        "teacher": "LR",
        "dayOfWeek": "Sunday",
        "timeRange": "10:00-11:30",
        "status": null
    },
    {
        "id": 358,
        "roomNumber": "507MB",
        "courseCode": "SWE425A_LAB",
        "teacher": "ZI",
        "dayOfWeek": "Sunday",
        "timeRange": "04:00-05:30",
        "status": null
}]
```

#### Code Snippets : /api/routine/GetRoutineByCourses

-   **Kotlin: OkHTTP3**

```kotlin
import okhttp3.RequestBody.Companion.toRequestBody

fun main(args: Array) {
    var client = OkHttpClient()
    var mediaType = MediaType.parse("application/json")
    var body = RequestBody.create(mediaType, "{\n\t\"subject01\": \"SWE422A\",\n\t\"subject02\": null,\n\t\"subject03\": \"SWE425A\",\n\t\"subject04\": null,\n\t\"subject05\": null,\n\t\"status\" : {\n\t\t\t     \"id\": 1,\n\t\t\t     \"nameOfFilesUploaded\": \"Spring 2020 Version-2\",\n\t\t\t     \"statusOfPublish\": true,\n\t\t\t     \"timeOfUpload\": \"2020-01-23T23:27:22.8211125\"\n\t\t\t   }\n}")
    var request = Request.Builder()
    .url("http://routine-explorer.herokuapp.com/api/routine/GetRoutineByCourses")
    .post(body)
    .addHeader("Content-Type", "application/json")
    .addHeader("Accept", "*/*")
    .addHeader("Cache-Control", "no-cache")
    .addHeader("Host", "http://routine-explorer.herokuapp.com")
    .addHeader("Accept-Encoding", "gzip, deflate")
    .addHeader("Content-Length", "295")
    .addHeader("Connection", "keep-alive")
    .addHeader("cache-control", "no-cache")
    .build()
    var response = client.newCall(request).execute()
}
```

-   **Flutter: ([HTTP](https://pub.dev/packages/http))**

```dart
import 'package:http/http.dart' as http;

var url = 'http://routine-explorer.herokuapp.com/api/routine/GetRoutineByCourses';
var response = await http.get(url, body: {
                                         	'subject01': 'SWE422A',
                                         	'subject02': null,
                                         	'subject03': 'SWE425A',
                                         	'subject04': null,
                                         	'subject05': null,
                                         	'status' : {
                                         			  'id': 1,
                                         			  'nameOfFilesUploaded': 'Spring 2020 Version-2',
                                         			  'statusOfPublish': true,
                                         			  'timeOfUpload': '2020-01-23T23:27:22.8211125'
                                         			}
                                         });
print('Response body: ${response.body}');
```

-   **Xamarin ([RestSharp](https://www.nuget.org/packages/RestSharp))**

```c#
var client = new RestClient("http://routine-explorer.herokuapp.com/api/routine/GetRoutineByCourses");
var request = new RestRequest(Method.POST);
request.AddHeader("cache-control", "no-cache");
request.AddHeader("Connection", "keep-alive");
request.AddHeader("Content-Length", "295");
request.AddHeader("Accept-Encoding", "gzip, deflate");
request.AddHeader("Host", "localhost:5000");
request.AddHeader("Cache-Control", "no-cache");
request.AddHeader("Accept", "*/*");
request.AddHeader("Content-Type", "application/json");
request.AddParameter("undefined", "{\n\t\"subject01\": \"SWE422A\",\n\t\"subject02\": null,\n\t\"subject03\": \"SWE425A\",\n\t\"subject04\": null,\n\t\"subject05\": null,\n\t\"status\" : {\n\t\t\t     \"id\": 1,\n\t\t\t     \"nameOfFilesUploaded\": \"Spring 2020 Version-2\",\n\t\t\t     \"statusOfPublish\": true,\n\t\t\t     \"timeOfUpload\": \"2020-01-23T23:27:22.8211125\"\n\t\t\t   }\n}", ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
```

## Find class schedule of teacher by initial (Routine Version Wise)

In this context, you `POST`  to the `api/routine/GetScheduleForTeacher`
and include a **teacher** object to the body.

For example, if you hit a `POST` request:

-   at localhost - `http://localhost:5000/api/routine/GetScheduleForTeacher`
-   at heroku - `http://routine-explorer.herokuapp.com/api/routine/GetScheduleForTeacher`
    and include a **teacher** object to the body like:

```json
{
	"teacherInitial": "MAH",
	"status" : {
			     "id": 1,
			     "nameOfFilesUploaded": "Spring 2020 Version-2",
			     "statusOfPublish": true,
			     "timeOfUpload": "2020-01-23T23:27:22.8211125"
			   }
}
```

Then you will get a response which is an array of object returning the class schedules in that routine version for the **teacher** you requested from the body like:

```json
[
{
        "id": 333,
        "roomNumber": "405AB",
        "courseCode": "SWE422A_LAB",
        "teacher": "MAH",
        "dayOfWeek": "Sunday",
        "timeRange": "10:00-11:30",
        "status": null
    },
    {
        "id": 358,
        "roomNumber": "507MB",
        "courseCode": "SWE425A_LAB",
        "teacher": "MAH",
        "dayOfWeek": "Sunday",
        "timeRange": "04:00-05:30",
        "status": null
}]
```

#### Code Snippets : /api/routine/GetScheduleForTeacher

-   **Kotlin: OkHTTP3**

```kotlin
import okhttp3.RequestBody.Companion.toRequestBody

fun main(args: Array) {
    var client = OkHttpClient()
    var mediaType = MediaType.parse("application/json")
    var body = RequestBody.create(mediaType, "{\n\t\"TeacherInitial\": \"MAH\",\n\t\"status\" : {\n\t\t\t     \"id\": 1,\n\t\t\t     \"nameOfFilesUploaded\": \"Spring 2020 Version-2\",\n\t\t\t     \"statusOfPublish\": true,\n\t\t\t     \"timeOfUpload\": \"2020-01-23T23:27:22.8211125\"\n\t\t\t   }\n}")
    var request = Request.Builder()
    .url("http://routine-explorer.herokuapp.com/api/routine/GetScheduleForTeacher")
    .post(body)
    .addHeader("Content-Type", "application/json")
    .addHeader("Accept", "*/*")
    .addHeader("Cache-Control", "no-cache")
    .addHeader("Host", "http://routine-explorer.herokuapp.com")
    .addHeader("Accept-Encoding", "gzip, deflate")
    .addHeader("Content-Length", "211")
    .addHeader("Connection", "keep-alive")
    .addHeader("cache-control", "no-cache")
    .build()
    var response = client.newCall(request).execute()
}
```

-   **Flutter: ([HTTP](https://pub.dev/packages/http))**

```dart
import 'package:http/http.dart' as http;

var url = 'http://routine-explorer.herokuapp.com/api/routine/GetScheduleForTeacher';
var response = await http.get(url, body: {
                                         	'teacherInitial': 'MAH',
                                         	'status' : {
                                         			'id': 1,
                                         			'nameOfFilesUploaded': 'Spring 2020 Version-2',
                                         			'statusOfPublish': true,
                                         			'timeOfUpload': '2020-01-23T23:27:22.8211125'
                                         		    }
                                         });
print('Response body: ${response.body}');
```

-   **Xamarin ([RestSharp](https://www.nuget.org/packages/RestSharp))**

```c#
var client = new RestClient("http://routine-explorer.herokuapp.com/api/routine/GetScheduleForTeacher");
var request = new RestRequest(Method.POST);
request.AddHeader("cache-control", "no-cache");
request.AddHeader("Connection", "keep-alive");
request.AddHeader("Content-Length", "211");
request.AddHeader("Accept-Encoding", "gzip, deflate");
request.AddHeader("Host", "localhost:5000");
request.AddHeader("Cache-Control", "no-cache");
request.AddHeader("Accept", "*/*");
request.AddHeader("Content-Type", "application/json");
request.AddParameter("undefined", "{\n\t\"TeacherInitial\": \"MAH\",\n\t\"status\" : {\n\t\t\t     \"id\": 1,\n\t\t\t     \"nameOfFilesUploaded\": \"Spring 2020 Version-2\",\n\t\t\t     \"statusOfPublish\": true,\n\t\t\t     \"timeOfUpload\": \"2020-01-23T23:27:22.8211125\"\n\t\t\t   }\n}", ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
```