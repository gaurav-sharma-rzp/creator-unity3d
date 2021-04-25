using UnityEngine;
using System.Collections;
using UnityEditor;
using LSystem;
[CustomEditor (typeof (DisplayGrammar))]
public class LSystemTextEditor : Editor {

    private DisplayGrammar generator;

    void Awake() { generator =(DisplayGrammar) target;  }

	public override void OnInspectorGUI() {
        
        base.DrawDefaultInspector();

		if (GUILayout.Button ("Generate")) {
            generator.Generate();
		}

        if (GUILayout.Button ("Reset")) {
            generator.Reset();
		} 
        if (GUILayout.Button ("Draw")) {
            generator.Draw();
		}
	}
}