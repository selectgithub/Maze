using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class DrawLineGraph : MonoBehaviour {
	
	public Transform grid;
	public Transform label;
	
	public GameObject fButton;
	public GameObject mButton;
	
	public UIFont font;
	
	string folderPath;
	ArrayList eff_DataArrays;
	ArrayList fam_DataArrays;
	ArrayList color_Arrays;
	
	float positionXMax = 10.0f;
	float positionXMin = -10.0f;
	float positionYMax = 5.0f;
	float positionYMin = -5.0f;
	
	float xLength;
	
	float valueYMax = 0;
	float valueYMin = 0;
	int maxCount = 0;
	
	void Awake(){
		eff_DataArrays = new ArrayList();
		fam_DataArrays = new ArrayList();
		color_Arrays = new ArrayList();
		xLength = positionXMax - positionXMin;
	}
	
	// Use this for initialization
	void Start () {
		folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MazeData\\" + StatusKeeper.LEVEL;
		string[] files = Directory.GetFiles(folderPath);
		//Debug.Log(folderPath);
		foreach(string file in files){
			//Debug.Log(file);
			ReadParse2Array(file);
			
			Color c = new Color(UnityEngine.Random.Range(0.0f,1.0f),UnityEngine.Random.Range(0.0f,1.0f),UnityEngine.Random.Range(0.0f,1.0f),1.0f);
			color_Arrays.Add(c);
			
			DrawLabel(file,c);
			
		}
		
		//Debug.Log(eff_DataArrays.Count);
		//Debug.Log(fam_DataArrays.Count);

		DrawFAMLine();
		
	}
	
	void DrawLabel(string path,Color c){
		string dateWord = path.Substring(path.Length-23,19);
		//Debug.Log(dateWord);
		
		GameObject go = new GameObject("Label");
		go.AddComponent<UILabel>();
		go.layer = 8;
		go.transform.parent = grid;
		go.transform.localScale = new Vector3(25,25,1);
		
		UILabel theLabel = go.GetComponent<UILabel>();
		theLabel.font = font;
		theLabel.text = dateWord;
		theLabel.color = c;
	}
	
	void DrawEFFLine(){
		DestroyGOWithTag("line");
		CalcMaxMinCount(eff_DataArrays);
		DrawLine(eff_DataArrays,color_Arrays);
		mButton.SetActive(false);
		fButton.SetActive(true);
	}
	void DrawFAMLine(){
		DestroyGOWithTag("line");
		CalcMaxMinCount(fam_DataArrays);
		DrawLine(fam_DataArrays,color_Arrays);
		fButton.SetActive(false);
		mButton.SetActive(true);
	}
	
	void ReadParse2Array(string filePath){
		ArrayList effArray = new ArrayList();
		ArrayList famArray = new ArrayList();
		
		string[] lines = File.ReadAllLines(filePath);
		foreach(string line in lines){
			if(line.Contains("END") || line.Contains("Time")){
				continue;
			}
			//Debug.Log(line);
			string[] words = line.Split(',');
			//Debug.Log(words[1]);
			//Debug.Log(words[2]);
			effArray.Add(words[1]);
			famArray.Add(words[2]);
		}
		eff_DataArrays.Add(effArray);
		fam_DataArrays.Add(famArray);
		
	}
	
	void CalcMaxMinCount(ArrayList dataList){
		for(int i = 0; i < dataList.Count; i++){
			
			ArrayList theList = (ArrayList)dataList[i];
			if(i == 0){
				maxCount = theList.Count;
			}else{
				if(theList.Count > maxCount){
					maxCount = theList.Count;
				}
			}
			
			for(int j = 0; j < theList.Count; j++){
				string str = (string)theList[j];
				float value = float.Parse(str);
				
				if(i == 0 && j == 0){
					valueYMax = valueYMin = value;
				}else{
				
					if(value > valueYMax){
						valueYMax = value;
					}
					if(value < valueYMin){
						valueYMin = value;
					}
				}
			}//end for "j"
			
		}
	}
	
	void DrawLine(ArrayList dataList,ArrayList colorList){
		string str;//
		float value;//
		
		float afterMoveMax = valueYMax - ((valueYMax + valueYMin)/2);
		float scaleRate = positionYMax / afterMoveMax;
				
		for(int i = 0; i < dataList.Count; i++){
			GameObject go = new GameObject("FMLine" + i);
			go.tag = "line";
			LineRenderer lineRen = go.AddComponent<LineRenderer>();
			lineRen.material = new Material(Shader.Find("Particles/Additive"));
			Color c = (Color)colorList[i];
			go.renderer.material.SetColor("_TintColor",c);
			lineRen.SetColors(c,c);
			lineRen.SetWidth(0.1f,0.1f);
			
			ArrayList theList = (ArrayList)dataList[i];
			
			lineRen.SetVertexCount(theList.Count);
			
			for(int j = 0; j < theList.Count; j++){
				str = (string)theList[j];
				value = float.Parse(str);
				
				value = value - ((valueYMax + valueYMin)/2); //move
				value = scaleRate * value; // scale
				

				Vector3 pos = new Vector3(positionXMin + j * (xLength/(maxCount - 1)),value,0);
				lineRen.SetPosition(j,pos);
				
			}//end for "j"

		}
	}
	
	void DestroyGOWithTag(string theTag){
		GameObject[] gos = GameObject.FindGameObjectsWithTag(theTag);
		foreach(GameObject go in gos){
			Destroy(go);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
