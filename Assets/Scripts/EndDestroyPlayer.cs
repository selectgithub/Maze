using UnityEngine;
using System.Collections;

public class EndDestroyPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c){
		Destroy(c.gameObject);
		Application.LoadLevel("LineGraph");
	}
}
