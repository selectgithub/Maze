using UnityEngine;
using System.Collections;

public class HelpUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMenuButtonClicked(){
		Application.LoadLevel("Menu");
	}
}
