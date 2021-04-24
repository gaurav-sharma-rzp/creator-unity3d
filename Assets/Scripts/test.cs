using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using System;


// using RestClient;
public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var api = new LSystem.Api();
        var res = api.Status();
        Debug.Log(res);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
