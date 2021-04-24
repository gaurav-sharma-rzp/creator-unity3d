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
    }
}
