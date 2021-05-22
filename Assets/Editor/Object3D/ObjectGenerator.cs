using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (ObjectGenerator))]
public class Object3DMeshGeneratorEditor : Editor {

    private ObjectGenerator generator;

    void Awake() { generator =(ObjectGenerator) target;  }

	public override void OnInspectorGUI() {
        
        base.DrawDefaultInspector();

		if (GUILayout.Button ("Generate")) {
            generator.Generate();
		}

        // if (GUILayout.Button ("Reset")) {
        //     generator.Reset();
		// } 
        // if (GUILayout.Button ("Draw")) {
        //     generator.Draw();
		// }
	}
}