using UnityEngine;
using System.Collections;

public class TimeCounter : MonoBehaviour {
	
	int time = 0;
	UILabel timeLabel;
	
	void Awake(){
		timeLabel = GetComponent<UILabel>();
	}
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("IncreaseSecond",0.0f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void IncreaseSecond(){
		time ++;
		timeLabel.text = "" + time + " s";
	}
}
