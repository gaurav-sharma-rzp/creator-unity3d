using UnityEngine;
using System.Collections;
using UnityEditor;
using LSystem;
[CustomEditor (typeof (ListGrammarGenerator))]
public class LSystemListEditor : Editor {

    private ListGrammarGenerator generator;

    void Awake() { generator =(ListGrammarGenerator) target;  }

	public override void OnInspectorGUI() {
        
        base.DrawDefaultInspector();

		if (GUILayout.Button ("Generate")) {
            generator.Generate();
		}
	}
}