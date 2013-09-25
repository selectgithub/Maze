using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour {
	public float speed = 1.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward*Time.deltaTime*speed);
		}
		if(Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S)){
			transform.Translate(Vector3.back*Time.deltaTime*speed);
		}
		if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D)){
			transform.Translate(Vector3.right*Time.deltaTime*speed);
		}
		if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)){
			transform.Translate(Vector3.left*Time.deltaTime*speed);
		}
	}
}
