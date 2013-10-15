using UnityEngine;
using System.Collections;

public class LineGraphUIController : MonoBehaviour {
	public GameObject fButton;
	public GameObject mButton;
	
	public delegate void ButtonClickedDelegate();
	
	public event ButtonClickedDelegate FamiButtonActived;
	public event ButtonClickedDelegate EffoButtonActived;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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


















