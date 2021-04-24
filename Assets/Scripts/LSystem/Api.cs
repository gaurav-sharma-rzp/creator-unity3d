using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LSystem
{ 
    public class Api 
    {
        public static readonly string baseUrl = "http://127.0.0.1:3000";
        private ApiClient client = new ApiClient();
        public string Status() {
            var endpoint = "/status";
            Response res = client.Call(ApiClient.GET, baseUrl+endpoint, "{}");
            if (res.success && res.code == 200) {
                StatusResponse statusResponse = JsonUtility.FromJson<StatusResponse>(res.body);
                return statusResponse.status;
            }
            
            return "not ok";
        }

        public List<string> ExpandGrammar(Grammar grammar, int steps){
            var endpoint = "/lsystem/expand";
            ExpandRequest request = new ExpandRequest();
            request.grammar = grammar;
            request.steps = steps;
            var body = request.json();
            // var body = MiniJSON.Json.Serialize(bodyAsDict);
            Debug.Log("serialized: " + body);
            Response res = client.Call(ApiClient.POST, baseUrl+endpoint, body);
            // Debug.Log(res.success);
            // Debug.Log(res.error);
            // Debug.Log(body);
            Debug.Log(res.body);
            if (res.success && res.code == 200) {
                ExpandResponse response = JsonUtility.FromJson<ExpandResponse>(res.body);
                // Debug.Log(response);
                // Debug.Log(response.result);
                return response.result;
            }
            
            return null;
        }
    }
}

