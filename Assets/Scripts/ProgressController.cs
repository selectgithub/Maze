using UnityEngine;
using System.Collections;

public class ProgressController : MonoBehaviour {

	ThinkGearDataController dataController;
	UISlider slider;
	
	int timeCount = 0;
	
	int signal = 200;
	
	void Awake(){
		dataController = GameObject.Find("ThinkGearDataController").GetComponent<ThinkGearDataController>();
		dataController.PoorSignalEvent += OnPoorSignal;
		
		slider = GetComponent<UISlider>();
	}
	
	void IncreaseCount(){
		timeCount++;
		float value = timeCount/76.0f;
		slider.sliderValue = value;
		//Debug.Log(timeCount);
	}
	
	void OnPoorSignal(int value){
		signal = value;                   
	}
	
	// Use this for initialization
	void Start () {
		slider.sliderValue = 0.0f;
		dataController.Connect();
	}
	
	// Update is called once per frame
	void Update () {
		if(signal == 0){
			if(!IsInvoking("IncreaseCount")){
				InvokeRepeating("IncreaseCount",0.0f,1.0f);
			}
		}else if(signal == 29 || signal == 54 || signal == 55 || signal == 56 || signal == 80 || signal == 81 || signal == 82 || signal == 107 || signal == 200){
			CancelInvoke("IncreaseCount");
			timeCount = 0;
		}else{
			
		}
	}
}
