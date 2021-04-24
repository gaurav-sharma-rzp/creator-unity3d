using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // https://stackoverflow.com/questions/45470315/unity-3d-call-post-api-with-json-request
        // public IEnumerator CallLogin(string url, string logindataJsonString)
        // {
        //     var request = new UnityWebRequest (url, "POST");
        //     byte[] bodyRaw = Encoding.UTF8.GetBytes(logindataJsonString);
        //     request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        //     request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        //     request.SetRequestHeader("Content-Type", "application/json");
        //     yield return request.SendWebRequest();

        //     if (request.error != null)
        //     {
        //         Debug.Log("Erro: " + www.error);
        //     }
        //     else
        //     {
        //         Debug.Log("All OK");
        //         Debug.Log("Status Code: " + request.responseCode);
        //     }



        //  HttpWebRequest request = 
        //   (HttpWebRequest)WebRequest.Create(String.Format("http://127.0.0.1:3000/lsystem/expand", 
        //    CityId, API_KEY));
        //   HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //   StreamReader reader = new StreamReader(response.GetResponseStream());
        //   string jsonResponse = reader.ReadToEnd();
        //   WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
        //   return info;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
