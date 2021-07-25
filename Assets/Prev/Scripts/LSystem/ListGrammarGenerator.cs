using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSystem
{ 
    public class ListGrammarGenerator : MonoBehaviour
    {
        public List<string> initiator;
        public List<string> alphabet;
        public List<Rule> rules;

        public int steps;
        public void Hi(){
            Debug.Log("Hi");
        }

        public void Generate(){
            var grammar = new Grammar();
            grammar.initiator = initiator;
            grammar.alphabet = alphabet;
            grammar.rules = RuleListToDict(rules);

            var resList = Api.ExpandGrammar(grammar, steps);
            Debug.Log(resList);
        }

        private Dictionary<string,List<string>> RuleListToDict(List<Rule> rules){
            Dictionary<string,List<string>> dict = new Dictionary<string,List<string>>();
            foreach (var rule in rules) {
                // Debug.Log(str);
                dict.Add(rule.alphabet, rule.transformation);
            }
            return dict;
        }
    }

    [System.Serializable]
    public class Rule
    {
        public string alphabet;
        public List<string> transformation;
    }
    
}