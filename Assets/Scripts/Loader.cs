using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
	
	ThinkGearDataController dataController;
	bool isNewMental = false;
	bool isNewFamil = false;
	
	void Awake(){
		dataController = GameObject.Find("ThinkGearDataController").GetComponent<ThinkGearDataController>();
		dataController.MentalEffortEvent += OnMentalEffortReceived;
		dataController.TaskFamiliarityEvent += OnTaskFamiliarityReceived;
	}
	
	// Use this for initialization
	void Start () {
	
		//Invoke("Load",5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(isNewFamil && isNewMental){
			Invoke("Load",1.0f);
			isNewFamil = isNewMental = false;
		}
	}
	
	void OnMentalEffortReceived(double value){
		isNewMental = true;
	}

	void OnTaskFamiliarityReceived(double value){
		isNewFamil = true;
	}
	
	void Load(){
		Application.LoadLevel("Menu");
	}
}
