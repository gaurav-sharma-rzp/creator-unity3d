using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using System;


// using RestClient;
public class test : MonoBehaviour
{
    private readonly string basePath = "http://127.0.0.1:3000/lsystem/expand";

    // Start is called before the first frame update
    void Start()
    {
        var api = new LSystem.Api();
        var res = api.Status();
        Debug.Log(res);
        // var client = new RestClient("http://127.0.0.1:3000");
        // client.Timeout = -1;
        // var request = new RestRequest(Method.POST);
        // request.AddHeader("Content-Type", "application/json");
        // request.AddParameter("application/json", "{\n    \"grammar\": {\n        \"initiator\": [\n            \"A\"\n        ],\n        \"alphabet\": [\n            \"A\",\n            \"B\"\n        ],\n        \"rules\": {\n            \"A\": [\n                \"A\",\n                \"B\"\n            ],\n            \"B\": [\n                \"A\"\n            ]\n        }\n    },\n    \"steps\":8\n}",  ParameterType.RequestBody);
        // IRestResponse response = client.Execute(request);
        // Console.WriteLine(response.Content);

        // Debug.Log("Start");


		// // We can add default query string params for all requests
		// RestClient.DefaultRequestParams["grammar"] = "{\n        \"initiator\": [\n            \"A\"\n        ],\n        \"alphabet\": [\n            \"A\",\n            \"B\"\n        ],\n        \"rules\": {\n            \"A\": [\n                \"A\",\n                \"B\"\n            ],\n            \"B\": [\n                \"A\"\n            ]\n        }\n    }";
		// RestClient.DefaultRequestParams["steps"] = 3;

		// currentRequest = new RequestHelper {
		// 	Uri = basePath + "/lsystem/expand",
		// 	Params = new Dictionary<string, string> {
		// 		// { "grammar", "{\n        \"initiator\": [\n            \"A\"\n        ],\n        \"alphabet\": [\n            \"A\",\n            \"B\"\n        ],\n        \"rules\": {\n            \"A\": [\n                \"A\",\n                \"B\"\n            ],\n            \"B\": [\n                \"A\"\n            ]\n        }\n    }" },
		// 		// { "steps", "3"}
		// 	},
		// 	Body = new Post {
		// 		title = "foo",
		// 		body = "{\n    \"grammar\": {\n        \"initiator\": [\n            \"A\"\n        ],\n        \"alphabet\": [\n            \"A\",\n            \"B\"\n        ],\n        \"rules\": {\n            \"A\": [\n                \"A\",\n                \"B\"\n            ],\n            \"B\": [\n                \"A\"\n            ]\n        }\n    },\n    \"steps\":8\n}",
		// 		// userId = 1
		// 	},
		// 	EnableDebug = true
		// };
		// RestClient.Post<Post>(currentRequest)
		// .Then(res => {

		// 	// And later we can clear the default query string params for all requests
		// 	RestClient.ClearDefaultParams();

		// 	this.LogMessage("Success", JsonUtility.ToJson(res, true));
		// })
		// .Catch(err => this.LogMessage("Error", err.Message));


        // https://stackoverflow.com/questions/45470315/unity-3d-call-post-api-with-json-request
        // public IEnumerator CallLogin(string url, string logindataJsonString)
        // {
            // var url = "http://127.0.0.1:3000/status";
            // var nodata = "{}";
            // var request = new UnityWebRequest (url, "GET");
            // byte[] bodyRaw = Encoding.UTF8.GetBytes(nodata);
            // request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            // request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            // request.SetRequestHeader("Content-Type", "application/json");
            // request.SendWebRequest();

            // if (request.error != null)
            // {
            //     Debug.Log("Erro: " + request.error);
            // }
            // else
            // {
            //      Debug.Log(JsonUtility.ToJson(request.downloadHandler.data, true));
            //    Debug.Log(JsonUtility.ToJson(request, true));
            //     Debug.Log(request.downloadHandler.text);
            //     Debug.Log("All OK");
            //     Debug.Log("Status Code: " + request.responseCode);
            //     var jsonResponse = request.downloadHandler.text;
            //     //  JSONObject json = new JSONObject(results);
            //     Status info = JsonUtility.FromJson<Status>(jsonResponse);
            //     Debug.Log("STATUS: ");
            //     Debug.Log(info.status);
            // }


            // var url2 = "http://127.0.0.1:3000/lsystem/expand";
            // var dataJsonAsString2 = "{\n    \"grammar\": {\n        \"initiator\": [\n            \"A\"\n        ],\n        \"alphabet\": [\n            \"A\",\n            \"B\"\n        ],\n        \"rules\": {\n            \"A\": [\n                \"A\",\n                \"B\"\n            ],\n            \"B\": [\n                \"A\"\n            ]\n        }\n    },\n    \"steps\":8\n}";
            // var nodata2 = "{}";
            // var request2 = new UnityWebRequest (url2, "POST");
            // byte[] bodyRaw2 = Encoding.UTF8.GetBytes(dataJsonAsString2);
            // request2.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw2);
            // request2.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            // request2.SetRequestHeader("Content-Type", "application/json");
            // request2.SendWebRequest();

            // if (request2.error != null)
            // {
            //     Debug.Log("Erro: " + request2.error);
            // }
            // else
            // {
            //      Debug.Log(JsonUtility.ToJson(request2.downloadHandler.data, true));
            //    Debug.Log(JsonUtility.ToJson(request2, true));
            //     Debug.Log(request2.downloadHandler.text);
            //     Debug.Log("All OK");
            //     Debug.Log("Status Code: " + request2.responseCode);
            //     Result res = JsonUtility.FromJson<Result>(request2.downloadHandler.text);
            //     Debug.Log("Result: ");
            //     Debug.Log(res);
            //       Debug.Log(res.result);
            // }

        //  HttpWebRequest request = 
        //   (HttpWebRequest)WebRequest.Create(String.Format("http://127.0.0.1:3000/lsystem/expand", 
        //    CityId, API_KEY));
        //   HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //   StreamReader reader = new StreamReader(response.GetResponseStream());
        //   string jsonResponse = reader.ReadToEnd();
        //   WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
        //   return info;
    }

    [Serializable]
    public class Result {
         public List<string> result;
    }

    [Serializable]
    public class Status {
        public string status;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
