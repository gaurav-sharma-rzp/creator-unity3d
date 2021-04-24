using UnityEngine;
using System.Collections;
using UnityEditor;
using LSystem;
[CustomEditor (typeof (TextGrammarGenerator))]
public class LSystemTextEditor : Editor {

    private TextGrammarGenerator generator;

    void Awake() { generator =(TextGrammarGenerator) target;  }

	public override void OnInspectorGUI() {
        
        base.DrawDefaultInspector();

		if (GUILayout.Button ("Generate")) {
            generator.Generate();
		}
        if (GUILayout.Button ("Draw")) {
            generator.Draw();
		}
	}
}