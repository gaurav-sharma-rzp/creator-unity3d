using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LSystem
{ 
    public class TextGrammarGenerator : MonoBehaviour
    {
        public string initiator;
        public string alphabet;
        public List<RuleString> rules;

        public int steps;

        public int mapWidth;
        public int mapHeight;
        public int noiseScale;

        public void Hi(){
            Debug.Log("Hi");
        }

        public void Generate(){
            var grammar = new Grammar();
            List<string> init = new List<string>();
            List<string> alpa = new List<string>();
            
            grammar.initiator = strToCharList(initiator);
            grammar.alphabet = strToCharList(alphabet);
            grammar.rules = RuleListToDict(rules);

            var resList = Api.ExpandGrammar(grammar, steps);
            Debug.Log(resList);
        }

        private List<string> strToCharList(string s){
            List<string> res = new List<string>();
            foreach (char c in s) {
                res.Add(Char.ToString(c));
            }
            return res;
        }
        private Dictionary<string,List<string>> RuleListToDict(List<RuleString> rules){
            Dictionary<string,List<string>> dict = new Dictionary<string,List<string>>();
            
            foreach (var rule in rules) {
                dict.Add(rule.alphabet, strToCharList(rule.transformation));
            }
            return dict;
        }

        public void Draw(){
            float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, noiseScale);
		    DisplayGrammar display = FindObjectOfType<DisplayGrammar> ();
		    display.DrawNoiseMap (noiseMap);
        }
    }

    [System.Serializable]
    public class RuleString
    {
        public string alphabet;
        public string transformation;
    }
    
}