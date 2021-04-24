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

        var grammar = new LSystem.Grammar();
        List<string> initiator = new List<string>();
        initiator.Add("A");
        List<string> alphabet = new List<string>();
        alphabet.Add("A");
        alphabet.Add("B");

        List<string> ruleA = new List<string>();
        ruleA.Add("B");
        ruleA.Add("B");
        ruleA.Add("A");
        List<string> ruleB = new List<string>();
        ruleA.Add("A");
        ruleA.Add("B");
        Dictionary<string,List<string>> rules = new Dictionary<string,List<string>>();
        rules.Add("A",ruleA);
        rules.Add("B",ruleB);

        grammar.initiator = initiator;
        grammar.alphabet = alphabet;
        grammar.rules = rules;

        var resList = api.ExpandGrammar(grammar, 10);
        if (resList != null) {
            foreach (var str in resList) {
                Debug.Log(str);
            }
        }else {
            Debug.Log("failed");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
