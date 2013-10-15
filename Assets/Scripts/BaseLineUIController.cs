using UnityEngine;
using System.Collections;

public class BaseLineUIController : MonoBehaviour {
	
	public GameObject tutorial;
	
	ThinkGearDataController dataController;
	bool isNewMental = false;
	bool isNewFamil = false;
	
	int signal = 200;
	
	void Awake(){
		dataController = GameObject.Find("ThinkGearDataController").GetComponent<ThinkGearDataController>();
		dataController.PoorSignalEvent += OnPoorSignal;
		dataController.MentalEffortEvent += OnMentalEffortReceived;
		dataController.TaskFamiliarityEvent += OnTaskFamiliarityReceived;
	}
	
	void OnPoorSignal(int value){
		signal = value;                
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		if(isNewFamil && isNewMental){
			Invoke("Load",1.0f);
			isNewFamil = isNewMental = false;
		}
		
		if(signal == 0){
			tutorial.SetActive(false);
		}else if(signal == 29 || signal == 54 || signal == 55 || signal == 56 || signal == 80 || signal == 81 || signal == 82 || signal == 107 || signal == 200){
			tutorial.SetActive(true);
		}else{
			
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
