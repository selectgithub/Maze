using UnityEngine;
using System.Collections;

public class LevelButtonController : MonoBehaviour {
	public GameObject tutorial;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.S)){
			TweenAlpha.Begin(tutorial,1.0f,0.0f);
		}
	}
	
	void OnChartButtonClicked(){
		Application.LoadLevel("LineGraph");
	}
	
	void OnHomeButtonClicked(){
		Application.LoadLevel("Menu");
	}
}
