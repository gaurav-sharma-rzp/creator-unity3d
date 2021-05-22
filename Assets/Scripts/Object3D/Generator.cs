using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Siccity.GLTFUtility;
using System.IO;
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
            if (wrapper == null){
                wrapper = new GameObject
                {
                    name = "Model"
                };
            }else{
                 foreach(Transform trans in wrapper.transform)
                {
                    DestroyImmediate(trans.gameObject);
                }
            }
            var resGltf = Api.TestGltf();
            File.WriteAllText(filePath, resGltf);
            GameObject model = Importer.LoadFromFile(filePath);
            model.transform.SetParent(wrapper.transform);
        }

       
        string filePath = "/Users/gauravsharma/Library/Application Support/DefaultCompany/Creator3D/Files/test.gltf";
        GameObject wrapper;
        public string url = "http://127.0.0.1:3000/gltf";

    }
}