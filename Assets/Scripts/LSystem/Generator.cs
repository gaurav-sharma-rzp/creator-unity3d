using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSystem
{ 
    [System.Serializable]
    public class Generator : MonoBehaviour
    {
        [SerializeField]
        public List<string> initiator;
        [SerializeField]
        public List<string> alphabet;

        public int mapWidth;
        

        public void Hi(){
            Debug.Log("Hi");
        }
    }
}