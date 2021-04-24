using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using System;

public class ApiClient 
{
    public static readonly string GET = "GET";
    public static readonly string POST = "POST";
    public Response Call(string method, string url,  string body) {
        var request = new UnityWebRequest (url, method);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(body);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        var asyncRequest = request.SendWebRequest();
        while (asyncRequest.isDone != true) {
           //Wait while call is not complete
        } 
        Response response = new Response();
        response.code = request.responseCode;

        if (request.error != null)
        {
            response.success = false;
            response.error = request.error;
        }
        else
        {
            response.success = true;
            response.body = request.downloadHandler.text;
        }
        response.error = request.error;
        return response;
    }
}

[Serializable]
public class Response {
    public bool success;
    public long code;
    public string error;
    public string body;
}