using UnityEngine;
using System.Collections;

public class MoveCloud : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * Time.deltaTime * speed);

		if(gameObject.transform.localPosition.x <= -900.0f){
			gameObject.transform.localPosition = new Vector3(927.0f,gameObject.transform.localPosition.y,gameObject.transform.localPosition.z);
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
