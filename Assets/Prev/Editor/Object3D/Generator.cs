using UnityEngine;
using System.Collections;
using UnityEditor;
using Object3D;
[CustomEditor (typeof (Generator))]
public class Object3DGeneratorEditor : Editor {

    private Generator generator;

    void Awake() { generator =(Generator) target;  }

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