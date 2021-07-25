using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    // 	const int mapChunkSize = 241;
	// [Range(0,6)]
	// public int levelOfDetail;
	// public float noiseScale;

	// public int octaves;
	// [Range(0,1)]
	// public float persistance;
	// public float lacunarity;

	// public int seed;
	// public Vector2 offset;

	// public float meshHeightMultiplier;
	// public AnimationCurve meshHeightCurve;

	// public bool autoUpdate;

	// public TerrainType[] regions;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Generate(){
        Debug.Log("Generate");
        generateQuad();
        // float[,] noiseMap = Noise.GenerateNoiseMap (mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistance, lacunarity, offset);

		// Color[] colourMap = new Color[mapChunkSize * mapChunkSize];
		// for (int y = 0; y < mapChunkSize; y++) {
		// 	for (int x = 0; x < mapChunkSize; x++) {
		// 		float currentHeight = noiseMap [x, y];
		// 		for (int i = 0; i < regions.Length; i++) {
		// 			if (currentHeight <= regions [i].height) {
		// 				colourMap [y * mapChunkSize + x] = regions [i].colour;
		// 				break;
		// 			}
		// 		}
		// 	}
		// }
        
        // Display display = FindObjectOfType<Display> ();
		// // display.DrawMesh (MeshGenerator.GenerateTerrainMesh (noiseMap, meshHeightMultiplier, meshHeightCurve, levelOfDetail), TextureGenerator.TextureFromColourMap (colourMap, mapChunkSize, mapChunkSize));
        // display.DrawMesh(MeshGenerator.GenerateTerrainMesh (noiseMap, meshHeightMultiplier, meshHeightCurve, levelOfDetail), null);
    }

   void generateQuad(){
        // GameObject gameObject = new GameObject();
        GameObject gameObject =  GameObject.Find("go");
        // gameObject.name = "go";
        Debug.Log(gameObject);
    //    MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
    //     MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
       MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
       MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
       meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        Mesh mesh = new Mesh();
        int width = 10, height =10;
        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(-width, -height, 0),
            new Vector3(width, -height, 0),
            new Vector3(-width, height, 0),
            new Vector3(width, height, 0)
        };
        mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };
        mesh.triangles = tris;

        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        mesh.uv = uv;

        meshFilter.mesh = mesh;
   }
}

[System.Serializable]
public struct TerrainType {
	public string name;
	public float height;
	public Color colour;
}