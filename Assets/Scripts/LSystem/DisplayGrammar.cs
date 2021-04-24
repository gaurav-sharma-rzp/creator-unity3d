using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayGrammar : MonoBehaviour {

	public Renderer textureRender;
    public int height;
    public int width;
    public int noiseScale;
    float[,] noiseMap;

    Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        noiseMap = Noise.GenerateNoiseMap (width, height, noiseScale);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("update" );
        StartCoroutine(updateColour()); 
        StartCoroutine(updateTexture());
    }

    Color[] screenColourMap;

    public void Init(){
        screenColourMap = new Color[width * height];
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Color curColor = Color.white;
                screenColourMap[y * width + x] = curColor;
            }
        }
        texture = new Texture2D (width, height);
        texture.SetPixels (screenColourMap);
		texture.Apply ();
		textureRender.sharedMaterial.mainTexture = texture;
    }

    public IEnumerator updateColour(){
        for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				screenColourMap [y * width + x] = Color.Lerp (Color.black, Color.white, noiseMap [x, y]);
                if(x==width-1){
                    yield return null;
                }
			}
		}
    }

    public IEnumerator updateTexture(){
        Texture2D texture = new Texture2D (width, height);
        texture.SetPixels (screenColourMap);
		texture.Apply ();
		textureRender.sharedMaterial.mainTexture = texture;
        yield return null;
    }


    public void DrawNoiseMap(float[,] noiseMap) {
		int width = noiseMap.GetLength (0);
		int height = noiseMap.GetLength (1);

		Texture2D texture = new Texture2D (width, height);

		Color[] colourMap = new Color[width * height];
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
                // Color curColor = Color.white;
                // if (x>=5 && x <=5 && y>=5 && y<=5) {
                    // curColor = Color.black;
                // }
                // // if (x>=6 && x <=8 && y>=6 && y<=6) {
                // //     curColor = Color.black;
                // // }
                // colourMap [y * width + x] = curColor;
				colourMap [y * width + x] = Color.Lerp (Color.black, Color.white, noiseMap [x, y]);
			}
		}
		texture.SetPixels (colourMap);
		texture.Apply ();

		textureRender.sharedMaterial.mainTexture = texture;
		// textureRender.transform.localScale = new Vector3 (width, 1, height);
	}
	
}