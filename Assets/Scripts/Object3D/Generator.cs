using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Siccity.GLTFUtility;

namespace Object3D
{ 
    public class Generator : MonoBehaviour
    {
        public int hi;
        public void Hi(){
            Debug.Log("Hi");
        }

        public void Generate(){

            var resList = Api.Status();
            Debug.Log(resList);
            wrapper = new GameObject
            {
                name = "Model1"
            };
            DownloadFile(url);
        }

       
        string filePath = "/Users/gauravsharma/Library/Application Support/DefaultCompany/Creator3D/Files/test.gltf";
        GameObject wrapper;
        public string url = "http://127.0.0.1:3000/gltf";

        private void Start()
        {
            // filePath = $"{Application.persistentDataPath}/Files/test.gltf";
            
        }

        public void DownloadFile(string url)
        {
            Debug.Log(filePath);
            StartCoroutine(GetFileRequest(url, (UnityWebRequest req) =>
            {
                if (req.isNetworkError || req.isHttpError)
                {
                    // Log any errors that may happen
                    Debug.Log($"{req.error} : {req.downloadHandler.text}");
                } else
                {
                    // Success!
                    ResetWrapper();
                    GameObject model = Importer.LoadFromFile(filePath);
                    model.transform.SetParent(wrapper.transform);
                }
            }));
        }

        IEnumerator GetFileRequest(string url, Action<UnityWebRequest> callback)
        {
            using(UnityWebRequest req = UnityWebRequest.Get(url))
            {
                Debug.Log(filePath);
                req.downloadHandler = new DownloadHandlerFile(filePath);
                yield return req.SendWebRequest();
                callback(req);
            }
        }

        void ResetWrapper()
        {
            if (wrapper != null)
            {
                foreach(Transform trans in wrapper.transform)
                {
                    Destroy(trans.gameObject);
                }
            }
        }

    }
    
}