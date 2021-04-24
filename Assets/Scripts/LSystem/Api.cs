using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LSystem
{

  
    public class Api 
    {
        public string baseUrl = "http://127.0.0.1:3000";
        public string Status() {
            var endpoint = "/status";
            ApiClient client = new ApiClient();
            Response res = client.Call(ApiClient.GET, baseUrl+endpoint, "{}");
            if (res.success && res.code == 200) {
                StatusResponse statusResponse = JsonUtility.FromJson<StatusResponse>(res.body);
                return statusResponse.status;
            }
            
            return "not ok";
        }
    }
}

