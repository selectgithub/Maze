using UnityEngine;
using System.Collections;

public class EndDestroyPlayer : MonoBehaviour {
	public GameObject congrats;
	
	// Use this for initialization
	void Start () {
		TweenScale.Begin(congrats,0.0f,new Vector3(0,0,0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c){
		Destroy(c.gameObject);
		//Application.LoadLevel("LineGraph");
		TweenScale.Begin(congrats,0.3f,new Vector3(1,1,1));
	}
}
