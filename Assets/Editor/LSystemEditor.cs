using UnityEngine;
using System.Collections;
using UnityEditor;
using LSystem;
[CustomEditor (typeof (Generator))]
public class LSystemEditor : Editor {

    private Generator generator;


    // void OnEnable()
    // {
    //     generator = serializedObject.FindProperty("lookAtPoint");
    // }

    // public override void OnInspectorGUI()
    // {
    //     serializedObject.Update();
    //     EditorGUILayout.PropertyField(lookAtPoint);
    //     serializedObject.ApplyModifiedProperties();
    // }
    // https://www.raywenderlich.com/7751-unity-custom-inspectors-tutorial-getting-started
   
    void Awake() { generator =(Generator) target;  }

	public override void OnInspectorGUI() {
        
        base.DrawDefaultInspector();

		if (GUILayout.Button ("Generate")) {
			// mapGen.GenerateMap ();
            generator.Hi();
		}
	}
}