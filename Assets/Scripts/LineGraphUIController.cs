using UnityEngine;
using System.Collections;

public class LineGraphUIController : MonoBehaviour {
	public GameObject fButton;
	public GameObject mButton;
	
	public GameObject homeButton;
	
	public delegate void ButtonClickedDelegate();
	
	public event ButtonClickedDelegate FamiButtonActived;
	public event ButtonClickedDelegate EffoButtonActived;
	
	float px = 0.0f;
	float py = 0.0f;
	float pz = 0.0f;
	
	bool isAppear = true;
	
	// Use this for initialization
	void Start () {
		Invoke("HideUI",5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.mousePosition.x != px || Input.mousePosition.y != py || Input.mousePosition.z != pz){
			if(!isAppear){
				Invoke("DisplayUI",0.0f);
				Invoke("HideUI",5.0f);
			}
		}
		px = Input.mousePosition.x;
		py = Input.mousePosition.y;
		pz = Input.mousePosition.z;
	}
	
	void HideUI(){
		isAppear = false;
		if(fButton){
			TweenAlpha.Begin(fButton,1.0f,0.0f);
		}
		if(mButton){
			TweenAlpha.Begin(mButton,1.0f,0.0f);
		}
		if(homeButton){
			TweenAlpha.Begin(homeButton,1.0f,0.0f);
		}
	}
	void DisplayUI(){
		isAppear = true;
		if(fButton){
			TweenAlpha.Begin(fButton,0.1f,1.0f);
		}
		if(mButton){
			TweenAlpha.Begin(mButton,0.1f,1.0f);
		}
		if(homeButton){
			TweenAlpha.Begin(homeButton,0.1f,1.0f);
		}
	}
	
	void OnHomeButtonClicked(){
		Application.LoadLevel("Menu");
	}
	
	void DrawEFFLine(){
		mButton.SetActive(false);
		fButton.SetActive(true);
		if(FamiButtonActived != null){
			FamiButtonActived();
		}
	}
	void DrawFAMLine(){
		fButton.SetActive(false);
		mButton.SetActive(true);
		if(EffoButtonActived != null){
			EffoButtonActived();
		}
	}
}


















