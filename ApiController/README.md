# API : Routine Explorer

Routine explorer is a free and open source application that helps finding
class schedule of the Department of Software Engineering of Daffodil International
University in a **6 x 6 Grid**.  In it's v3.0 it has arrive with API so that some other
applications like:

- Room booking (By using the data of unused rooms)
- Weekly class tracking of each room
- Schedule maker of teachers using initials
- Most importantly "MOBILE" applications can be built.

Rest of the part of this documentation will be discussed on module-wise API so that
people willing to built applications for the Dept. of SWE, can gather some idea on how to use these APIs.

## GET all versions of routine

To get the list of routine files you need to hit the api at ```api/versions```. For example, if you hit a 
```GET``` request:
- In localhost - ```http://localhost:5000/api/versions```
- In heroku - ```http://routine-explorer.herokuapp.com/api/versions```

Then it will respond with an array of objects like below :
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
###### Code Snippets : api/versions
These are some code snippets that might help you dealing with the API at
```api/versions``` :
- **Python3 HTTP Client**
```python
import http.client

conn = http.client.HTTPConnection("http://routine-explorer.herokuapp.com")

headers = {
    'Accept': "*/*",
    'Cache-Control': "no-cache",
    'Host': "http://routine-explorer.herokuapp.com",
    'Accept-Encoding': "gzip, deflate",
    'Connection': "keep-alive",
    'cache-control': "no-cache"
    }

conn.request("GET", "api,versions", headers=headers)

res = conn.getresponse()
data = res.read()

print(data.decode("utf-8"))
```
- **Java OK HTTP**
```java
OkHttpClient client = new OkHttpClient();

Request request = new Request.Builder()
  .url("http://routine-explorer.herokuapp.com/api/versions")
  .get()
  .addHeader("Accept", "*/*")
  .addHeader("Cache-Control", "no-cache")
  .addHeader("Host", "http://routine-explorer.herokuapp.com")
  .addHeader("Accept-Encoding", "gzip, deflate")
  .addHeader("Connection", "keep-alive")
  .addHeader("cache-control", "no-cache")
  .build();

Response response = client.newCall(request).execute();
```
- **C# RestSharp**
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

To get the latest version of routine object you need to hit the api at ```api/versions/GetLatestVersion```. For example, if you hit a 
```GET``` request:
- at localhost - ```http://localhost:5000/api/versions/GetLatestVersion```
- at heroku - ```http://routine-explorer.herokuapp.com/api/versions/GetLatestVersion```
Then it will respond with a single object like below :
```json
    {
        "id": 1,
        "nameOfFilesUploaded": "Spring 2020 Version-2",
        "statusOfPublish": true,
        "timeOfUpload": "2020-01-23T23:27:22.8211125"
    }
```
###### Code Snippets : api/versions/GetLatestVersion
- **Python3**
```python
import http.client

conn = http.client.HTTPConnection("http://routine-explorer.herokuapp.com")

headers = {
    'Accept': "*/*",
    'Cache-Control': "no-cache",
    'Host': "http://routine-explorer.herokuapp.com",
    'Accept-Encoding': "gzip, deflate",
    'Connection': "keep-alive",
    'cache-control': "no-cache"
    }

conn.request("GET", "api,versions,GetLatestVersion", headers=headers)

res = conn.getresponse()
data = res.read()

print(data.decode("utf-8"))
```
- **Java OK HTTP**
```java
OkHttpClient client = new OkHttpClient();

Request request = new Request.Builder()
  .url("http://routine-explorer.herokuapp.com/api/versions/GetLatestVersion")
  .get()
  .addHeader("Accept", "*/*")
  .addHeader("Cache-Control", "no-cache")
  .addHeader("Host", "http://routine-explorer.herokuapp.com")
  .addHeader("Accept-Encoding", "gzip, deflate")
  .addHeader("Connection", "keep-alive")
  .addHeader("cache-control", "no-cache")
  .build();

Response response = client.newCall(request).execute();
```


- **C# REST**
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