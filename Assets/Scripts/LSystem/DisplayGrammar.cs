using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LSystem;

public class DisplayGrammar : MonoBehaviour {

	public Renderer textureRender;

    public Mode drawMode;
    public enum Mode {
        Custom,
        KochCurve3,
        KochCurve4
    }
    public int height;
    public int width;
    public int noiseScale;
    float[,] noiseMap;
    public int startX;
    public int startY;
    public int forwardLength;
    public string grammarString;
    private List<string> grammarSymbol;


    public string initiator;
    public string alphabet;
    public List<RuleString> rules;

    public int steps;

    [System.Serializable]
    public class RuleString
    {
        public string alphabet;
        public string transformation;
    }


    Texture2D texture;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("update" );
        // StartCoroutine(updateColour()); 
        updateFrame();
        
    }

    void updateFrame() {
        updateTexture();
    }
    Color[] screenColourMap;

    public void Init(){ 
        FillBasedOnMode();
        noiseMap = Noise.GenerateNoiseMap (width, height, noiseScale);
        
        screenColourMap = new Color[width * height];
        for (int x = 0; x < height; x++) {
            for (int y = 0; y < width; y++) {
                Color curColor = Color.white;
                screenColourMap[x * width + y] = curColor;
            }
        }
        texture = new Texture2D (width, height);
        texture.SetPixels (screenColourMap);
		texture.Apply ();
		textureRender.sharedMaterial.mainTexture = texture;
        // grammarSymbol = strToCharList(grammarString);
        Generate();
        // Debug.Log(grammarSymbol);
        
        StartCoroutine(drawGrammar()); 
    }

    public void FillBasedOnMode(){
        switch(drawMode) {
            case Mode.Custom : break;
            case Mode.KochCurve3:
                height = 100;
                width = 100; 
                startX = 10;
                startY = 90;
                forwardLength = 3;
                initiator = "F";
                alphabet = "F+-";
                rules = new List<RuleString>();
                var rule1 = new RuleString();
                rule1.alphabet = "F";
                rule1.transformation = "F+F-F-F+F";
                rules.Add(rule1);
                steps = 3;
            break;
            case Mode.KochCurve4:

                height = 300;
                width = 300; 
                startX = 10;
                startY = 290;
                forwardLength = 3;
                initiator = "F";
                alphabet = "F+-";
                rules = new List<RuleString>();
                var rulekc41 = new RuleString();
                rulekc41.alphabet = "F";
                rulekc41.transformation = "F+F-F-F+F";
                rules.Add(rulekc41);
                steps = 4;
            break;
        }    
    }

    public IEnumerator drawGrammar(){
        int x = startX;
        int y = startY;
        string direction = "R";
        foreach (var s in grammarSymbol){
            
            switch (s){
                case "G":
                case "F":
                    for(int i=0; i< forwardLength; ++i){
                        switch(direction) { 
                            case "T": y--;
                            break;
                            case "B": y++;
                            break;
                            case "L": x--;
                            break;
                            case "R": x++;
                            break;
                        }
                        screenColourMap [x * width + y] = Color.black;
                    }
                    
                break;
                case "+":
                    switch(direction) { 
                        case "T": direction="L";
                        break;
                        case "B": direction="R";
                        break;
                        case "L": direction="B";
                        break;
                        case "R": direction="T";
                        break;
                    }
                break;
                case "-":
                    switch(direction) { 
                        case "T": direction="R";
                        break;
                        case "B": direction="L";
                        break;
                        case "L": direction="T";
                        break;
                        case "R": direction="B";
                        break;
                    }
                break;
                
                default:
                Debug.Log("Unsupported operation");
                break;
            }
            // Debug.Log(s + " " + direction + " " + x + " " + y);
            yield return null;
        }
         Debug.Log("break");
        yield break;
    }

     public IEnumerator drawFractalPlant(){
        int x = startX;
        int y = startY;
        string direction = "R";
        foreach (var s in grammarSymbol){
            
            switch (s){
                case "G":
                case "F":
                    for(int i=0; i< forwardLength; ++i){
                        switch(direction) { 
                            case "T": y--;
                            break;
                            case "B": y++;
                            break;
                            case "L": x--;
                            break;
                            case "R": x++;
                            break;
                        }
                        screenColourMap [x * width + y] = Color.black;
                    }
                    
                break;
                case "+":
                    switch(direction) { 
                        case "T": direction="L";
                        break;
                        case "B": direction="R";
                        break;
                        case "L": direction="B";
                        break;
                        case "R": direction="T";
                        break;
                    }
                break;
                case "-":
                    switch(direction) { 
                        case "T": direction="R";
                        break;
                        case "B": direction="L";
                        break;
                        case "L": direction="T";
                        break;
                        case "R": direction="B";
                        break;
                    }
                break;
                
                default:
                Debug.Log("Unsupported operation");
                break;
            }
            // Debug.Log(s + " " + direction + " " + x + " " + y);
            yield return null;
        }
         Debug.Log("break");
        yield break;
    }

    public void updateTexture(){
        texture = new Texture2D (width, height);
        texture.SetPixels (screenColourMap);
		texture.Apply ();
		textureRender.sharedMaterial.mainTexture = texture;
    }


    public void DrawNoiseMap(float[,] noiseMap) {
		int width = noiseMap.GetLength (0);
		int height = noiseMap.GetLength (1);

		Texture2D texture = new Texture2D (width, height);

		Color[] colourMap = new Color[width * height];
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				colourMap [y * width + x] = Color.Lerp (Color.black, Color.white, noiseMap [x, y]);
			}
		}
		texture.SetPixels (colourMap);
		texture.Apply ();

		textureRender.sharedMaterial.mainTexture = texture;
	}
	
    public void Reset(){
        Init();
    }

    public void Draw(){
        Init();
        drawGrammarComplete();
         updateFrame();
    }

    public void drawGrammarComplete(){
        int x = startX;
        int y = startY;
        string direction = "R";
        foreach (var s in grammarSymbol){
            
            switch (s){
                case "F":
                    for(int i=0; i< forwardLength; ++i){
                        switch(direction) { 
                            case "T": y--;
                            break;
                            case "B": y++;
                            break;
                            case "L": x--;
                            break;
                            case "R": x++;
                            break;
                        }
                        screenColourMap [x * width + y] = Color.black;
                    }
                    
                break;
                case "+":
                    switch(direction) { 
                        case "T": direction="L";
                        break;
                        case "B": direction="R";
                        break;
                        case "L": direction="B";
                        break;
                        case "R": direction="T";
                        break;
                    }
                break;
                case "-":
                    switch(direction) { 
                        case "T": direction="R";
                        break;
                        case "B": direction="L";
                        break;
                        case "L": direction="T";
                        break;
                        case "R": direction="B";
                        break;
                    }
                break;
                
                default:
                Debug.Log("Unsupported operation");
                break;
            }
            Debug.Log(s + " " + direction + " " + x + " " + y);
        }
         Debug.Log("break");
        return;
    }

    public void Generate(){
        var grammar = new Grammar();
        List<string> init = new List<string>();
        List<string> alpa = new List<string>();
        
        grammar.initiator = strToCharList(initiator);
        grammar.alphabet = strToCharList(alphabet);
        grammar.rules = RuleListToDict(rules);

        var resList = Api.ExpandGrammar(grammar, steps);
        grammarSymbol = resList;
        Debug.Log(grammarSymbol);
    }

    private List<string> strToCharList(string s){
        List<string> res = new List<string>();
        foreach (char c in s) {
            res.Add(Char.ToString(c));
        }
        return res;
    }
    private Dictionary<string,List<string>> RuleListToDict(List<RuleString> rules){
        Dictionary<string,List<string>> dict = new Dictionary<string,List<string>>();
        
        foreach (var rule in rules) {
            dict.Add(rule.alphabet, strToCharList(rule.transformation));
        }
        return dict;
    }
    

    
}