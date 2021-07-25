using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using System;
namespace LSystem
{
    [Serializable]
    public class StatusResponse {
        public string status;
    }

    [Serializable]
    public class ExpandRequest {
        public Grammar grammar;
        public int steps;
    
        public Dictionary<object,object> ToDict(){
            Dictionary<object,object> dict = new Dictionary<object,object>();
            dict.Add("grammar",this.grammar.ToDict());
            dict.Add("steps",this.steps);
            return dict;
        }

        public string json() {
            var data = MiniJSON.Json.Serialize(this.ToDict());
            return data;
        }
    }

    [Serializable]
    public class ExpandResponse {
        public List<string> result;
    }

    [Serializable]
    public class Grammar {
        public List<string> initiator;
        public List<string> alphabet;
        public Dictionary<string, List<string>> rules; 

        public override string ToString(){
            return "HahA";
        }

        public Dictionary<object,object> ToDict(){
            Dictionary<object,object> dict = new Dictionary<object,object>();
            dict.Add("initiator",this.initiator);
            dict.Add("alphabet",this.alphabet);
            dict.Add("rules",this.rules);
            return dict;
        } 

        public string json() {
            var data = MiniJSON.Json.Serialize(this.ToDict());
            return data;
        }
    }
}
