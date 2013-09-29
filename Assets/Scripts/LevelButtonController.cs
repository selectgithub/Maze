using UnityEngine;
using System.Collections;

public class LevelButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnHomeButtonClicked(){
		Application.LoadLevel("Menu");
	}
}
