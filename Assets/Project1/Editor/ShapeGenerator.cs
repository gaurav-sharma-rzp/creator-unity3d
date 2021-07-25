using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (ShapeGenerator))]
public class ShapeGeneratorEditor : Editor {

    private ShapeGenerator generator;

    void Awake() { generator =(ShapeGenerator) target;  }

	public override void OnInspectorGUI() {
        
        base.DrawDefaultInspector();

		if (GUILayout.Button ("Generate")) {
            generator.Generate();
		}
	}
}