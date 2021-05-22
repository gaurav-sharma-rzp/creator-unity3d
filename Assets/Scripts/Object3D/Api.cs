using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using System;
namespace Object3D
{ 
    public class Api 
    {
        public static readonly string baseUrl = "http://127.0.0.1:3000";
        private static ApiClient client = new ApiClient();
        public static string Status() {
            var endpoint = "/status";
            Response res = client.Call(ApiClient.GET, baseUrl+endpoint, "{}");
            if (res.success && res.code == 200) {
                StatusResponse statusResponse = JsonUtility.FromJson<StatusResponse>(res.body);
                return statusResponse.status;
            }
            
            return "not ok";
        }

        public static string TestGltf() {
            var endpoint = "/gltf";
            Response res = client.Call(ApiClient.GET, baseUrl+endpoint, "{}");
            if (res.success && res.code == 200) {
               return res.body;
            }
            
            return "{'status':'failed'}";
        }

        // public static List<string> ExpandGrammar(Grammar grammar, int steps){
        //     var endpoint = "/lsystem/expand";
        //     ExpandRequest request = new ExpandRequest();
        //     request.grammar = grammar;
        //     request.steps = steps;
        //     var body = request.json();
        //     Debug.Log("serialized: " + body);
        //     Response res = client.Call(ApiClient.POST, baseUrl+endpoint, body);
        //     Debug.Log(res.body);
        //     if (res.success && res.code == 200) {
        //         ExpandResponse response = JsonUtility.FromJson<ExpandResponse>(res.body);
        //         return response.result;
        //     }
            
        //     return null;
        // }
    }
     
    [Serializable]
    public class StatusResponse {
        public string status;
    }

// Concurrent Code for api requests
    //   public void DownloadFile(string url)
    //     {
    //         Debug.Log(filePath);
    //         StartCoroutine(GetFileRequest(url, (UnityWebRequest req) =>
    //         {
    //             if (req.isNetworkError || req.isHttpError)
    //             {
    //                 // Log any errors that may happen
    //                 Debug.Log($"{req.error} : {req.downloadHandler.text}");
    //             } else
    //             {
    //                 // Success!
    //                 ResetWrapper();
    //                 GameObject model = Importer.LoadFromFile(filePath);
    //                 model.transform.SetParent(wrapper.transform);
    //             }
    //         }));
    //     }

    //     IEnumerator GetFileRequest(string url, Action<UnityWebRequest> callback)
    //     {
    //         using(UnityWebRequest req = UnityWebRequest.Get(url))
    //         {
    //             Debug.Log(filePath);
    //             req.downloadHandler = new DownloadHandlerFile(filePath);
    //             yield return req.SendWebRequest();
    //             callback(req);
    //         }
    //     }

    //     void ResetWrapper()
    //     {
    //         if (wrapper != null)
    //         {
    //             foreach(Transform trans in wrapper.transform)
    //             {
    //                 Destroy(trans.gameObject);
    //             }
    //         }
    //     }

    // }
    
}

