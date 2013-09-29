using UnityEngine;
using System.Collections;

public class MenuUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnLevel1Clicked(){
		Application.LoadLevel("C");
	}
	void OnLevel2Clicked(){
		Application.LoadLevel("D");
	}
	void OnLevel3Clicked(){
		Application.LoadLevel("E");
	}
}
